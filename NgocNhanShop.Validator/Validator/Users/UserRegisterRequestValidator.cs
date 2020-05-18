using FluentValidation;
using NgocNhanShop.Business.System.Dtos;
using NgocNhanShop.Validator.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Validator.Validator.Users
{
    public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Họ người dùng"));

            RuleFor(x => x.LastName).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Tên người dùng"))
                .MaximumLength(200).WithMessage(String.Format(MessageValidator_VN.maxLenght, "Tên người dùng", 200));

            RuleFor(x => x.UserName).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Tài khoản người dùng"))
                .MaximumLength(255).WithMessage(String.Format(MessageValidator_VN.maxLenght, "Tài khoản người dùng", 255));

            RuleFor(x => x.Password).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Mật khẩu"))
                 .MinimumLength(8).WithMessage(String.Format(MessageValidator_VN.minLenght, "Mật khẩu", 8));

            RuleFor(x => x.Email).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Email"))
                .EmailAddress().WithMessage(String.Format(MessageValidator_VN.email, "Email"));

            RuleFor(x => x.PhoneNumber).MinimumLength(10).WithMessage(String.Format(MessageValidator_VN.minLenght, "Số điện thoại", 10))
                .MaximumLength(15).WithMessage(String.Format(MessageValidator_VN.maxLenght, "Số điện thoại", 15));

            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Ngày sinh"))
                .GreaterThan(DateTime.Now.AddYears(-100)).WithMessage(String.Format(MessageValidator_VN.maxYear, "Ngày sinh", 100))
                .LessThan(DateTime.Now).WithMessage(String.Format(MessageValidator_VN.minDay, "Ngày sinh", DateTime.Now.ToString()));

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ComfirmPassword)
                {
                    context.AddFailure(String.Format(MessageValidator_VN.isComformPassword, "Mật khẩu xác nhận"));
                }
            });

        }
    }
}
