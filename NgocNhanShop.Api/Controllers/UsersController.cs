using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgocNhanShop.Business.System.Dtos;
using NgocNhanShop.Business.System.Users;

namespace NgocNhanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Login(request);
            if (resultToken == null)
            {
                return BadRequest("Cannot login with username or password");
            }
            return Ok(resultToken);
        }

        [HttpGet("{Username}")]
        public async Task<IActionResult> GetByUsername(string Username)
        {
            var user = await _userService.GetByUsername(Username);
            if (user == null)
            {
                return BadRequest($"Cannot find product id {Username}");
            }
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest("Cannot register user");
            }
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]UserPageRequest request)
        {
            var products = await _userService.GetUsersPaging(request);
            return Ok(products);
        }
    }
}