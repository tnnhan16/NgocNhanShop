using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NgocNhanShop.ViewModel.Common.Dtos;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NgocNhanShop.Utilities.Constant;
using NgocNhanShop.AdminApp.Routers;
using NgocNhanShop.ViewModel.System.Users.Dtos;

namespace NgocNhanShop.AdminApp.Service.User
{
    public class UserApiClient : ApiClientBase, IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private UserRouter userRouter = new UserRouter();
        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
           
        }

        public async Task<ApiResult<LoginResponse>>Login(UserLoginRequest request)
        {

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.AppSettings.BaseAddress]);
            var response = await client.PostAsync(userRouter.GetRouterApiLogin(), httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                ApiResult<LoginResponse> myDeserializedObj = (ApiResult<LoginResponse>)JsonConvert.DeserializeObject(body,
                    typeof(ApiResult<LoginResponse>));

                return myDeserializedObj;
            }

            return JsonConvert.DeserializeObject<ApiResult<LoginResponse>>(body);
        }

        public async Task<ApiResult<Message>> RegisterUser(UserRegisterRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstant.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.AppSettings.BaseAddress]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(userRouter.GetRouterApiRegister(), httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<Message>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<Message>>(result);
        }

        public async Task<ApiResult<UserUpdateRequest>> GetByUserId(Guid id)
        {
            var url = userRouter.GetRouterApiByUserId(id);
            return await GetByAsync<UserUpdateRequest>(url);
        }

        public async Task<ApiResult<UserViewModel>> GetUserDetail(Guid id)
        {
            var url = userRouter.GetRouterApiDetail(id);
            return await GetByAsync<UserViewModel>(url);
        }

        public async Task<ApiResult<UserViewModel>> GetByUsername(string Username)
        {
            var url = userRouter.GetRouterApiByUserName(Username);
            return await GetByAsync<UserViewModel>(url);
        }

        public async Task<ApiResult<PageResult<UserViewModel>>> GetUsersPagings(UserPageRequest request)
        {
            var url = userRouter.GetRouterApiAll(request);
            return await GetAllAsync<ApiResult<PageResult<UserViewModel>>>(url);

        }

        public async Task<ApiResult<Message>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            var url = userRouter.GetRouterApiUpdate(id);
            return await PutAsync<Message>(url, request);
        }

        public async Task<ApiResult<bool>> DeleteUser(Guid id)
        {
            var url = userRouter.GetRouterApiDelete(id);
            return await DeleteAsync<bool>(url);
        }
    }
}
