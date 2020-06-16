using NgocNhanShop.ViewModel.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NgocNhanShop.ViewModel.System.Actions.Dtos;

namespace NgocNhanShop.Business.System.Action
{
    public interface IActionService
    {
        Task<ApiResult<Message>> Render(ActionRegisterRequest request,List<ActionViewModel> listAction);
        Task<ApiResult<Message>> Update(Guid actionId, ActionUpdateRequest request);
        Task<ApiResult<bool>> Delete(Guid actionId);
        Task<ApiResult<PageResult<ActionViewModel>>> GetActionPaging(ActionPageRequest request);
        Task<ApiResult<ActionViewModel>> GetByActionId(Guid actionId);
        Task<ApiResult<List<ControllerNameOption>>> GetOptions();

    }
}
