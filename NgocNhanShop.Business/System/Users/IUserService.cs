using NgocNhanShop.Business.Catelog.Dtos;
using NgocNhanShop.Business.Common.Dtos;
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
        Task<ApiResult<string>> Login(UserLoginRequest request);
        Task<ApiResult<Message>> Register(UserRegisterRequest request);
        Task<ApiResult<Message>> Update(Guid id, UserUpdateRequest request);
        Task<ApiResult<PageResult<UserViewModel>>> GetUsersPaging(UserPageRequest request);
        Task<ApiResult<UserUpdateRequest>>GetByUsername(string Username);
        Task<ApiResult<UserUpdateRequest>> GetByUserId(Guid UserId);

    }
}
