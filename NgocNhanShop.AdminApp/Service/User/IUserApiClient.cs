using NgocNhanShop.AdminApp.Service.Response;
using NgocNhanShop.Business.Catelog.Dtos;
using NgocNhanShop.Business.System.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgocNhanShop.AdminApp.Service.User
{
    public interface IUserApiClient
    {
        Task<ResponseBase> Login(UserLoginRequest request);

        Task<PageResult<UserViewModel>> GetUsersPagings(UserPageRequest request);

        Task<bool> RegisterUser(UserRegisterRequest request);
        Task<UserViewModel> GetByUsername(string Username, string Token);
    }
}
