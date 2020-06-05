using FluentValidation;
using NgocNhanShop.ViewModel.System.Users.Dtos;
using NgocNhanShop.Validator.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Validator.Validator.Users
{
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Họ người dùng"));

            RuleFor(x => x.LastName).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Tên người dùng"))
                .MaximumLength(200).WithMessage(String.Format(MessageValidator_VN.maxLenght, "Tên người dùng", 200));

            RuleFor(x => x.Email).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Email"))
                .EmailAddress().WithMessage(String.Format(MessageValidator_VN.email, "Email"));

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Số điện thoại"))
                .MinimumLength(10).WithMessage(String.Format(MessageValidator_VN.minLenght, "Số điện thoại", 10))
                .MaximumLength(15).WithMessage(String.Format(MessageValidator_VN.maxLenght, "Số điện thoại", 15));

            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Ngày sinh"))
                .GreaterThan(DateTime.Now.AddYears(-100)).WithMessage(String.Format(MessageValidator_VN.minDate, "Ngày sinh", 100))
                .LessThan(DateTime.Now).WithMessage(String.Format(MessageValidator_VN.maxDate, "Ngày sinh", DateTime.Now.ToString()));
        }
    }
}
