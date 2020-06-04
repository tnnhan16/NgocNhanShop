using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.System.Dtos.Users
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserUpdateRequest User { get; set; } 
    }
}
