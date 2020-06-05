using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NgocNhanShop.ViewModel.System.Roles.Dtos
{
    public class RoleRegisterRequest: Base
    {
        [Display(Name = "Role name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public List<AppRoleAction> AppRoleActions { get; set; }
    }
}
