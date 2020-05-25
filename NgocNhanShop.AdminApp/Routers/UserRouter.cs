using NgocNhanShop.ViewModel.System.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace NgocNhanShop.AdminApp.Routers
{
    public class UserRouter
    {
        public string GetRouterApiUserAll(UserPageRequest request)
        {
            return $"/api/users/paging?pageIndex=" + $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}";
        }
        public string GetRouterApiUserById(Guid Id)
        {
            return $"/api/users/byid/{Id}";
        }

        public string GetRouterApiUserByUserName(string UserName)
        {
            return $"/api/users/byname?Username=" + $"{UserName}";
        }

        public string GetRouterApiDetailUser(Guid Id)
        {
            return $"/api/users/detail/{Id}";
        }

        public string GetRouterApiUpdateOrDeleteUser(Guid Id)
        {
            return $"/api/users/{Id}";
        }

        public string GetRouterApiRegisterUser()
        {
            return "/api/users";
        }

        public string GetRouterApiLogin()
        {
            return "/api/users/login";
        }


    }
}
