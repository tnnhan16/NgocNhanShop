using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.System.Users.Dtos
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserUpdateRequest User { get; set; } 
    }
}
