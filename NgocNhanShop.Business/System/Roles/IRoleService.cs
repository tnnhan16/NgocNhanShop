using NgocNhanShop.ViewModel.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NgocNhanShop.ViewModel.System.Roles.Dtos;

namespace NgocNhanShop.Business.System.Roles
{
    public interface IRoleService
    {
        Task<ApiResult<Message>> Register(RoleRegisterRequest request);
        Task<ApiResult<Message>> Update(Guid RoleId, RoleUpdateRequest request);
        Task<ApiResult<bool>> Delete(Guid RoleId);
        Task<ApiResult<PageResult<RoleViewModel>>> GetRolePaging(RolePageRequest request);
        Task<ApiResult<RoleViewModel>> GetByRoleId(Guid RoleId);

    }
}
