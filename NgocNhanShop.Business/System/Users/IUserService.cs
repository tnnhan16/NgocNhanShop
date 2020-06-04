using NgocNhanShop.ViewModel.Common.Dtos;
using NgocNhanShop.ViewModel.System.Dtos;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<LoginResponse>> Login(UserLoginRequest request);
        Task<ApiResult<Message>> Register(UserRegisterRequest request);
        Task<ApiResult<Message>> Update(Guid id, UserUpdateRequest request);
        Task<ApiResult<bool>> Delete(Guid id);
        Task<ApiResult<PageResult<UserViewModel>>> GetUsersPaging(UserPageRequest request);
        Task<ApiResult<UserUpdateRequest>>GetByUsername(string Username);
        Task<ApiResult<UserUpdateRequest>> GetByUserId(Guid UserId);
        Task<ApiResult<UserViewModel>> GetUserDetail(Guid UserId);

    }
}
