using FluentValidation;
using NgocNhanShop.ViewModel.System.Users.Dtos;
using NgocNhanShop.Validator.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Validator.Validator.Users
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Tên người dùng"));
            RuleFor(x => x.Password).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Mật khẩu"));
        }
    }
}
