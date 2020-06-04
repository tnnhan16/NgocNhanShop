using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
