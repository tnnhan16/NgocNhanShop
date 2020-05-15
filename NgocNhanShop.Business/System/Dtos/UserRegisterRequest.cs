using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.System.Dtos
{
    public class UserRegisterRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
