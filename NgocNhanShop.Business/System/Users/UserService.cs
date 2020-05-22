using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NgocNhanShop.Business.Catelog.Dtos;
using NgocNhanShop.Business.Common.Dtos;
using NgocNhanShop.Business.System.Dtos;
using NgocNhanShop.Business.System.Users;
using NgocNhanShop.Data.Entities;
using NgocNhanShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        public async Task<ApiResult<string>> Login(UserLoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if(user == null)
            {
                return null;
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, true, true);
            if(!result.Succeeded)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claim = new Claim[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role,string.Join(";",roles)),
                new Claim(ClaimTypes.Name, user.LastName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claim,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<Message>> Register(UserRegisterRequest request)
        {
            var listMessage = new List<Message>();
            var checkUserName = await _userManager.FindByNameAsync(request.UserName);
            if (checkUserName != null)
            {
                listMessage.Add(new Message { Key= "UserName",Value= "Tài khoản này đã tồn tại" });
                //return new ApiErrorResult<bool>("Tài khoản này đã tồn tại");
            }
            var checkEmail = await _userManager.FindByEmailAsync(request.Email);
            if (checkEmail != null)
            {
                listMessage.Add(new Message { Key = "Email", Value = "Email này đã tồn tại" });
                //return new ApiErrorResult<bool>("Email này đã tồn tại");
            }
            if (listMessage.Count > 0)
            {
                return new ApiErrorResult<Message>(listMessage);
            }
            var user = _mapper.Map<AppUser>(request);
            if (user == null)
            {
                throw new NgocNhanShopException($"Cannot register user");
            }
            var result = await _userManager.CreateAsync(user,request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<Message>();
            }
            return new ApiErrorResult<Message>("Đăng ký không thành công");
        }

        public async Task<ApiResult<PageResult<UserViewModel>>> GetUsersPaging(UserPageRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword)
                 || x.PhoneNumber.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var result = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).Select(x => new UserViewModel
                { 
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Birdthay = x.BirthDay,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,          
                }).ToListAsync();

            //var users = _mapper.Map<List<UserViewModel>>(result);

            var pagedResult = new PageResult<UserViewModel>()
            {
                Total = totalRow,
                Items = result
            };
            return new ApiSuccessResult<PageResult<UserViewModel>>(pagedResult);
        }
        public async Task<ApiResult<Message>> Update(Guid id, UserUpdateRequest request)
        {

            var listMessage = new List<Message>();
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                listMessage.Add(new Message { Key = "Email", Value = "Email này đã tồn tại" });
            }
            if (listMessage.Count > 0)
            {
                return new ApiErrorResult<Message>(listMessage);
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            _mapper.Map<UserUpdateRequest,AppUser>(request, user);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<Message>();
            }
            return new ApiErrorResult<Message>("Cập nhật không thành công");
        }

        public async Task<ApiResult<UserUpdateRequest>> GetByUsername(string Username)
        {
            var user = await _userManager.FindByNameAsync(Username);
            if (user == null)
            {
                return new ApiErrorResult<UserUpdateRequest>($"Không tìm thấy người dùng có username: {Username}");
            }
            return new ApiSuccessResult<UserUpdateRequest>();
        }

        public async Task<ApiResult<UserUpdateRequest>> GetByUserId(Guid UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId.ToString());

            if (user == null)
            {
                return new ApiErrorResult<UserUpdateRequest>($"Không tìm thấy người dùng này");
            }

            var userDto = _mapper.Map<UserUpdateRequest>(user);

            return new ApiSuccessResult<UserUpdateRequest>(userDto);
        }
    }
}
