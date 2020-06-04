using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
    public class AppAction: Base
    {
        public Guid Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public List<AppRoleAction> AppRoleActions { get; set; }
    }
}
