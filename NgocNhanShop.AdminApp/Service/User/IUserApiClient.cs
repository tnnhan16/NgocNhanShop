using NgocNhanShop.ViewModel.Common.Dtos;
using NgocNhanShop.ViewModel.System.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgocNhanShop.AdminApp.Service.User
{
    public interface IUserApiClient
    {
        Task<ApiResult<LoginResponse>> Login(UserLoginRequest request);

        Task<ApiResult<PageResult<UserViewModel>>> GetUsersPagings(UserPageRequest request);

        Task<ApiResult<Message>> RegisterUser(UserRegisterRequest request);

        Task<ApiResult<Message>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<ApiResult<bool>> DeleteUser(Guid id);

        Task<ApiResult<UserViewModel>> GetByUsername(string Username);

        Task<ApiResult<UserUpdateRequest>> GetByUserId(Guid UserId);

        Task<ApiResult<UserViewModel>> GetUserDetail(Guid UserId);
    }
}
