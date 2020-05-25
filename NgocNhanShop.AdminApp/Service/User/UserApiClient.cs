using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NgocNhanShop.ViewModel.Common.Dtos;
using NgocNhanShop.ViewModel.System.Dtos;
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

        public async Task<ApiResult<string>>Login(UserLoginRequest request)
        {

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.AppSettings.BaseAddress]);
            var response = await client.PostAsync(userRouter.GetRouterApiLogin(), httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                ApiResult<string> myDeserializedObj = (ApiResult<string>)JsonConvert.DeserializeObject(body,
                    typeof(ApiResult<string>));

                return myDeserializedObj;
            }

            return JsonConvert.DeserializeObject<ApiResult<string>>(body);
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

            var response = await client.PostAsync($"/api/users", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<Message>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<Message>>(result);
        }

        public async Task<ApiResult<UserUpdateRequest>> GetByUserId(Guid id)
        {
            var url = $"/api/users/byid/{id}";
            return await GetByAsync<UserUpdateRequest>(url);
        }

        public async Task<ApiResult<UserViewModel>> GetUserDetail(Guid id)
        {
            var url = $"/api/users/detail/{id}";
            return await GetByAsync<UserViewModel>(url);
        }

        public async Task<ApiResult<UserViewModel>> GetByUsername(string Username)
        {
            var url = $"/api/users/byname?Username=" + $"{Username}";
            return await GetByAsync<UserViewModel>(url);
        }

        public async Task<ApiResult<PageResult<UserViewModel>>> GetUsersPagings(UserPageRequest request)
        {
            var url = $"/api/users/paging?pageIndex=" + $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}";
            return await GetAllAsync<ApiResult<PageResult<UserViewModel>>>(url);

        }

        public async Task<ApiResult<Message>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            var url = $"/api/users/{id}";
            return await PutAsync<Message>(url, request);
        }

        public async Task<ApiResult<bool>> DeleteUser(Guid id)
        {
            var url = $"/api/users/{id}";
            return await DeleteAsync<bool>(url);
        }
    }
}
