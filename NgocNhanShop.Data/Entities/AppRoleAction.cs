using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
    public class AppRoleAction
    {
        public Guid Id { get; set; }
        public bool? IsDelete { get; set; }
        public Guid RoleId { get; set; }
        public AppRole AppRoles { get; set; }
        public Guid ActionId { get; set; }
        public AppAction AppActions { get; set; }
    }
}
