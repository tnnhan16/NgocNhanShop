using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgocNhanShop.ViewModel.System.Dtos;
using NgocNhanShop.Business.System.Users;

namespace NgocNhanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resutl = await _userService.Login(request);
            if (!resutl.IsSuccessed)
            {
                return BadRequest(resutl);
            }
            return Ok(resutl);
        }


        [HttpGet("GetByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(Guid id)
        {
            var result = await _userService.GetByUserId(id);
            return Ok(result);
        }

        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await _userService.GetUserDetail(id);
            return Ok(result);
        }

        [HttpGet("GetByUsername/{Username}")]
        public async Task<IActionResult> GetByUsername(string Username)
        {
            var result = await _userService.GetByUsername(Username);
            return Ok(result);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _userService.Register(request);
            if (result.IsSuccessed)
            {
                return Ok(result);              
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]UserPageRequest request)
        {
            var products = await _userService.GetUsersPaging(request);
            return Ok(products);
        }

        [HttpPut("Update/{UserId}")]
        public async Task<IActionResult> Update(Guid UserId, [FromBody]UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Update(UserId, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.Delete(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}