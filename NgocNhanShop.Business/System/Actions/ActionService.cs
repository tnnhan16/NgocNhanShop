using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NgocNhanShop.ViewModel.Common.Dtos;
using NgocNhanShop.Data.Entities;
using NgocNhanShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NgocNhanShop.EF.Data;
using NgocNhanShop.ViewModel.System.Actions.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Http.Internal;

namespace NgocNhanShop.Business.System.Action
{
    public class ActionService : IActionService
    {
        private readonly IMapper _mapper;
        private readonly NgocNhanShopDbContext _context;
        public ActionService(IMapper mapper, NgocNhanShopDbContext context)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<ApiResult<Message>> Render(ActionRegisterRequest request,List<ActionViewModel> listAction)
        {
            var listMessage = new List<Message>();
            if (listAction.Count() > 0)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var ActionRegister = new List<AppAction>();
                        var ActionUpdate = new List<AppAction>();
                        foreach (var item in listAction)
                        {
                            var action = await _context.AppActions
                                .Where(x => x.ControllerName == item.ControllerName && x.ActionName == item.ActionName)
                                .FirstOrDefaultAsync();
                            if (action == null)
                            {
                                var actionRegister = new AppAction
                                {
                                    ActionName = item.ActionName,
                                    ControllerName = item.ControllerName,
                                    Description = item.Description,
                                    CreateTime = DateTime.Now,
                                    UserCreate = request.UserCreate,
                                    IsDelete = false
                                };
                                ActionRegister.Add(actionRegister);
                            }
                            else
                            {
                                action.UserUpdate = request.UserUpdate;
                                action.UpdateTime = DateTime.Now;
                                ActionUpdate.Add(action);
                            }

                        }
                        if (ActionRegister.Count() > 0)
                        {
                            await _context.AppActions.AddRangeAsync(ActionRegister);
                        }
                        if (ActionUpdate.Count() > 0)
                        {
                            _context.AppActions.UpdateRange(ActionUpdate);
                        }
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return new ApiSuccessResult<Message>();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new NgocNhanShopException(ex.Message);
                    }
                }
            }
            return new ApiErrorResult<Message>("Không tìm thấy action nào trong project");
        }

        public async Task<ApiResult<PageResult<ActionViewModel>>> GetActionPaging(ActionPageRequest request)
        {
            var query = from a in _context.AppActions select a;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.ActionName.Contains(request.Keyword) 
                        || x.ControllerName.Contains(request.Keyword) 
                        || x.Description.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var result = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            var Roles = _mapper.Map<List<ActionViewModel>>(result);

            var pagedResult = new PageResult<ActionViewModel>()
            {
                Total = totalRow,
                Items = Roles,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return new ApiSuccessResult<PageResult<ActionViewModel>>(pagedResult);
        }
        public async Task<ApiResult<Message>> Update(Guid actionId, ActionUpdateRequest request)
        {
            var action = await _context.AppActions.FindAsync(actionId);
            _mapper.Map<ActionUpdateRequest, AppAction>(request, action);
            _context.AppActions.Update(action);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new ApiSuccessResult<Message>();
            }
            return new ApiErrorResult<Message>("Cập nhật không thành công");
        }

        public async Task<ApiResult<ActionViewModel>> GetByActionId(Guid actionId)
        {
            var action = await _context.AppActions.FindAsync(actionId.ToString());

            if (action == null)
            {
                return new ApiErrorResult<ActionViewModel>("Không tìm thấy action này");
            }

            var actionDto = _mapper.Map<ActionViewModel>(action);

            return new ApiSuccessResult<ActionViewModel>(actionDto);
        }

        public async Task<ApiResult<bool>> Delete(Guid actionId)
        {
            var action = await _context.AppActions.FindAsync(actionId.ToString());
            if (action == null)
            {
                return new ApiErrorResult<bool>("Action không tồn tại");
            }
            _context.AppActions.Remove(action);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new ApiSuccessResult<bool>();
            }

            return new ApiErrorResult<bool>("Xóa không thành công");
        }

        public async Task<ApiResult<List<ControllerNameOption>>> GetOptions()
        {
            var actions = await _context.AppActions.ToListAsync();

            List<ControllerNameOption> controllerNames = new List<ControllerNameOption>();
            List<ActionNameOption> actionNames = new List<ActionNameOption>();

            string controllerName = null;

            foreach (var item in actions)
            {
                actionNames.Add(new ActionNameOption
                {
                    Id = item.Id,
                    Description = item.Description,
                });

                if (item.ControllerName != controllerName)
                {
                    controllerNames.Add(new ControllerNameOption
                    {
                       ControllerName = item.ControllerName,
                       ActionNameOptions = actionNames,
                    });

                    controllerName = item.ControllerName;
                    actionNames = new List<ActionNameOption>();
                }

            }
            return new ApiSuccessResult<List<ControllerNameOption>>(controllerNames);
        }
    }
}
