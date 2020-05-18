using NgocNhanShop.Business.System.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgocNhanShop.AdminApp.Service.User
{
    public interface IUserApiClient
    {
        Task<string> Login(UserLoginRequest request);
    }
}
