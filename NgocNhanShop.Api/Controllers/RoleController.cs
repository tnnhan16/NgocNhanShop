using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgocNhanShop.ViewModel.System.Roles.Dtos;
using NgocNhanShop.Business.System.Roles;

namespace NgocNhanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetByRoleId/{roleId}")]
        public async Task<IActionResult> GetByRoleId(Guid roleId)
        {
            var result = await _roleService.GetByRoleId(roleId);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RoleRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _roleService.Register(request);
            if (result.IsSuccessed)
            {
                return Ok(result);              
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]RolePageRequest request)
        {
            var products = await _roleService.GetRolePaging(request);
            return Ok(products);
        }

        [HttpPut("Update/{roleId}")]
        public async Task<IActionResult> Update(Guid roleId, [FromBody]RoleUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleService.Update(roleId, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{roleId}")]
        public async Task<IActionResult> Delete(Guid roleId)
        {
            var result = await _roleService.Delete(roleId);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}