using NgocNhanShop.Business.Catelog.Dtos;
using NgocNhanShop.Business.System.Dtos;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.System.Users
{
    public interface IUserService
    {
        Task<string> Login(UserLoginRequest request);
        Task<bool> Register(UserRegisterRequest request);

        Task<PageResult<UserViewModel>> GetUsersPaging(UserPageRequest request);
        Task<AppUser>GetByUsername(string Username);
    }
}
