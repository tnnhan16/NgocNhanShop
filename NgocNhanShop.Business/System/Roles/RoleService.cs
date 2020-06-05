using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NgocNhanShop.ViewModel.Common.Dtos;
using NgocNhanShop.ViewModel.System.Roles.Dtos;
using NgocNhanShop.Data.Entities;
using NgocNhanShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NgocNhanShop.Business.System.Roles;
using Microsoft.AspNetCore.Http;
using NgocNhanShop.EF.Data;
using Microsoft.AspNetCore.Http.Internal;

namespace NgocNhanShop.Business.System
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly NgocNhanShopDbContext _context;
        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper, NgocNhanShopDbContext context)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _context = context;

        }

        public async Task<ApiResult<Message>> Register(RoleRegisterRequest request)
        {
            var listMessage = new List<Message>();
            var checkRoleName = await _roleManager.FindByNameAsync(request.Name);
            if (checkRoleName != null)
            {
                listMessage.Add(new Message { Key= "RoleName",Value= "Role name này đã tồn tại" });
            }

            if (listMessage.Count > 0)
            {
                return new ApiErrorResult<Message>(listMessage);
            }
            var role = _mapper.Map<AppRole>(request);
            if (role == null)
            {
                throw new NgocNhanShopException($"Cannot register Role");
            }
            
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        var listRoleAction = new List<AppRoleAction>();
                        foreach (var item in role.AppRoleActions)
                        {
                            var roleAction = new AppRoleAction
                            {
                                RoleId = role.Id,
                                ActionId = item.ActionId,
                                IsDelete = false
                            };
                            listRoleAction.Add(roleAction);
                        }

                        await _context.AppRoleActions.AddRangeAsync(listRoleAction);
                        transaction.Commit();
                        return new ApiSuccessResult<Message>();
                    }
                    
                }
                catch (Exception ex)
                {                    
                    transaction.Rollback();
                    throw new NgocNhanShopException(ex.Message);
                }
            }
            return new ApiErrorResult<Message>("Đăng ký không thành công");
        }

        public async Task<ApiResult<PageResult<RoleViewModel>>> GetRolePaging(RolePageRequest request)
        {
            var query = _roleManager.Roles;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword)
                 || x.Description.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var result = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            var Roles = _mapper.Map<List<RoleViewModel>>(result);

            var pagedResult = new PageResult<RoleViewModel>()
            {
                Total = totalRow,
                Items = Roles,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return new ApiSuccessResult<PageResult<RoleViewModel>>(pagedResult);
        }
        public async Task<ApiResult<Message>> Update(Guid id, RoleUpdateRequest request)
        {

            var listMessage = new List<Message>();
            if (await _roleManager.Roles.AnyAsync(x => x.Name == request.Name && x.Id != id))
            {
                listMessage.Add(new Message { Key = "Email", Value = "Role name này đã tồn tại" });
            }
            if (listMessage.Count > 0)
            {
                return new ApiErrorResult<Message>(listMessage);
            }
            var role = await _roleManager.FindByIdAsync(id.ToString());
            _mapper.Map<RoleUpdateRequest, AppRole>(request, role);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        var listRoleAction = new List<AppRoleAction>();
                        foreach (var item in request.AppRoleActions)
                        {
                            var roleAction = new AppRoleAction
                            {
                                RoleId = role.Id,
                                ActionId = item.ActionId,
                                IsDelete = false
                            };
                            listRoleAction.Add(roleAction);
                        }

                        await _context.AppRoleActions.AddRangeAsync(listRoleAction);
                        var listRoleActions = await _context.AppRoleActions.Where(x=>x.RoleId == role.Id).ToListAsync();
                        _context.AppRoleActions.RemoveRange(listRoleActions);
                        transaction.Commit();
                        return new ApiSuccessResult<Message>();
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new NgocNhanShopException(ex.Message);
                }
            }
            return new ApiErrorResult<Message>("Cập nhật không thành công");
        }

        public async Task<ApiResult<RoleViewModel>> GetByRoleId(Guid RoleId)
        {
            var role = await _roleManager.FindByIdAsync(RoleId.ToString());

            if (role == null)
            {
                return new ApiErrorResult<RoleViewModel>($"Không tìm thấy role này");
            }

            var roleDto = _mapper.Map<RoleViewModel>(role);

            return new ApiSuccessResult<RoleViewModel>(roleDto);
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return new ApiErrorResult<bool>("Role không tồn tại");
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        var listRoleActions = await _context.AppRoleActions.Where(x => x.RoleId == role.Id).ToListAsync();
                        _context.AppRoleActions.RemoveRange(listRoleActions);
                        transaction.Commit();
                        return new ApiSuccessResult<bool>();
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new NgocNhanShopException(ex.Message);
                }
            }
            return new ApiErrorResult<bool>("Xóa không thành công");
        }
    }
}
