using NgocNhanShop.AdminApp.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgocNhanShop.AdminApp.Service.User
{
    public class UserResponse<T> : ResponseBase 
    {
        public T Data { get; set; }
    }
}
