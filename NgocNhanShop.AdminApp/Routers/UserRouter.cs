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
        public string GetRouterApiAll(UserPageRequest request)
        {
            return $"/api/users/getallpaging?pageIndex=" + $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}";
        }
        public string GetRouterApiByUserId(Guid Id)
        {
            return $"/api/users/getbyuserid/{Id}";
        }

        public string GetRouterApiByUserName(string UserName)
        {
            return $"/api/users/getbyusername?Username=" + $"{UserName}";
        }

        public string GetRouterApiDetail(Guid Id)
        {
            return $"/api/users/detail/{Id}";
        }

        public string GetRouterApiUpdate(Guid Id)
        {
            return $"/api/users/update/{Id}";
        }

        public string GetRouterApiDelete(Guid Id)
        {
            return $"/api/users/delete/{Id}";
        }

        public string GetRouterApiRegister()
        {
            return "/api/users/register";
        }

        public string GetRouterApiLogin()
        {
            return "/api/users/login";
        }


    }
}
