using NgocNhanShop.AdminApp.Service.Response;
using NgocNhanShop.Business.Catelog.Dtos;
using NgocNhanShop.Business.Common.Dtos;
using NgocNhanShop.Business.System.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgocNhanShop.AdminApp.Service.User
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Login(UserLoginRequest request);

        Task<ApiResult<PageResult<UserViewModel>>> GetUsersPagings(UserPageRequest request);

        Task<ApiResult<bool>> RegisterUser(UserRegisterRequest request);

        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserViewModel>> GetByUsername(string Username);

        Task<ApiResult<UserUpdateRequest>> GetByUserId(Guid UserId);
    }
}
