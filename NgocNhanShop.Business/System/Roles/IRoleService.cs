using NgocNhanShop.ViewModel.Common.Dtos;
using NgocNhanShop.ViewModel.System.Dtos.Users;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.System.Roles
{
    public interface IRoleService
    {
        Task<ApiResult<Message>> Register(UserRegisterRequest request);
        Task<ApiResult<Message>> Update(Guid id, UserUpdateRequest request);
        Task<ApiResult<bool>> Delete(Guid id);
        Task<ApiResult<PageResult<UserViewModel>>> GetUsersPaging(UserPageRequest request);
        Task<ApiResult<UserViewModel>> GetByUserId(Guid UserId);

    }
}
