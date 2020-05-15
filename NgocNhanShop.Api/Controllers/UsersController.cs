using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgocNhanShop.Business.System.Dtos;
using NgocNhanShop.Business.System.Users;

namespace NgocNhanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var resultToken = await _userService.Login(request);
            if (resultToken == null)
            {
                return BadRequest("Cannot login with username or password");
            }
            return Ok(new { token = resultToken });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest("Cannot register user");
            }
            return Ok();
        }
    }
}