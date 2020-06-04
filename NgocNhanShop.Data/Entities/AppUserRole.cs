using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }
        public AppRole AppRoles { get; set; }


        public Guid UserId { get; set; }
        public AppAction AppAction { get; set; }
    }
}
