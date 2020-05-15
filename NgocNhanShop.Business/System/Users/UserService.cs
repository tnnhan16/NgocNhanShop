using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NgocNhanShop.Business.System.Dtos;
using NgocNhanShop.Business.System.Users;
using NgocNhanShop.Data.Entities;
using NgocNhanShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.System
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration config, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _mapper = mapper;

        }
        public async Task<string> Login(UserLoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if(user == null)
            {
                return null;
            }
            var result = _signInManager.PasswordSignInAsync(user, request.Password, true, true);
            if(result == null)
            {
                return null;
            }
            var roles = _userManager.GetRolesAsync(user);
            var claim = new Claim[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role,string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claim,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(UserRegisterRequest request)
        {
            var user = _mapper.Map<AppUser>(request);
            if (user == null)
            {
                throw new NgocNhanShopException($"Cannot register user");
            }
            var result = await _userManager.CreateAsync(user,request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
