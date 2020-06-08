using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgocNhanShop.ViewModel.System.Users.Dtos;
using NgocNhanShop.Business.System.Users;
using NgocNhanShop.Business.System.Action;
using NgocNhanShop.ViewModel.System.Actions.Dtos;
using System.Reflection;

namespace NgocNhanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ActionController : ControllerBase
    {
        private readonly IActionService _actionService;
        public ActionController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpGet("GetByActionId/{actionId}")]
        public async Task<IActionResult> GetByActionId(Guid actionId)
        {
            var result = await _actionService.GetByActionId(actionId);
            return Ok(result);
        }

        [HttpPost("Render")]
        public async Task<IActionResult> Render([FromBody]ActionRegisterRequest request)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var listAction = asm.GetTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods())
                .Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute))
                   && method.ReturnType == typeof(Task<IActionResult>))
                .Select(x => new ActionViewModel
                {
                    ControllerName = x.DeclaringType.Name,
                    ActionName = x.Name,
                    Description = x.ReturnType.Name,
                }).OrderBy(x => x.ControllerName).ThenBy(x => x.ActionName).ToList();
            var result = await _actionService.Render(request, listAction);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]ActionPageRequest request)
        {
            var products = await _actionService.GetActionPaging(request);
            return Ok(products);
        }

        [HttpPut("Update/{actionId}")]
        public async Task<IActionResult> Update(Guid actionId, [FromBody]ActionUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _actionService.Update(actionId, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{actionId}")]
        public async Task<IActionResult> Delete(Guid actionId)
        {
            var result = await _actionService.Delete(actionId);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}