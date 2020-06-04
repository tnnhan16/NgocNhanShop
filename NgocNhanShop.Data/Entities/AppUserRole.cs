using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public Guid Id { get; set; }

        public bool? IsDelete { get; set; }

        public AppRole AppRoles { get; set; }

        public AppUser AppUsers { get; set; }
    }
}
