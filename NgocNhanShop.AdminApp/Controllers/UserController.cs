using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using NgocNhanShop.AdminApp.Service.User;
using NgocNhanShop.ViewModel.System.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System;

namespace NgocNhanShop.AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;

        private readonly IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 2)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new UserPageRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var result = await _userApiClient.GetUsersPagings(request);
            if(TempData["Success"] != null)
            {
                ViewBag.Message = TempData["Success"];
            }
            return View(result.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userApiClient.RegisterUser(request);
            if (result.IsSuccessed)
            {
                TempData["Success"] = "Thêm người dùng thành công";
                return RedirectToAction("Index", "User");
            }
            foreach (var item in result.ListError)
            {
                ModelState.AddModelError(item.Key.ToString(), item.Value.ToString());
            }
            if (result.ListError == null)
            {
                ViewBag.Message = "Thêm người dùng không thành công";
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _userApiClient.GetByUserId(id);
            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.UpdateUser(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["Success"] = "Cập nhật người dùng thành công";
                return RedirectToAction("Index");

            }

            foreach (var item in result.ListError)
            {
                ModelState.AddModelError(item.Key.ToString(), item.Value.ToString());
            }
            if(result.ListError == null)
            {
                ViewBag.Message = "Cập nhật người dùng không thành công";
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userApiClient.GetUserDetail(id);
            if (result.IsSuccessed)
            {              
                return View(result.ResultObj);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.DeleteUser(id);
            if (result.IsSuccessed)
            {
                TempData["Success"] = "Xóa người dùng thành công";
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Xóa người dùng không thành công";
            return View(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await _userApiClient.GetUserDetail(id);
            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return RedirectToAction("Error", "Home");
        }

    }
}