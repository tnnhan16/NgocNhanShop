using FluentValidation;
using Microsoft.AspNetCore.Http;
using NgocNhanShop.AdminApp.Service.User;
using NgocNhanShop.Validator.Message;
using NgocNhanShop.Validator.Validator.Users;
using System;

namespace NgocNhanShop.AdminApp.Validator
{
    public class UserRegisterValidator : UserRegisterRequestValidator
    {
        private readonly HttpContext _httpContent;
        private readonly IUserApiClient _userApiClient;
        public UserRegisterValidator(HttpContext httpContent, IUserApiClient userApiClient)
        {
            _httpContent = httpContent;
            _userApiClient = userApiClient;
        }
        public UserRegisterValidator()
        {
            RuleFor(x => x).Custom((request, context) =>
            {
                var token = _httpContent.Session.GetString("Token");
                var user = _userApiClient.GetByUsername(request.UserName, token);
                if (user != null)
                {
                    context.AddFailure("UserName", String.Format(MessageValidator_VN.existUserName, "Tài khoản người dùng"));
                }
            });

        }
    }
}
