using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using NgocNhanShop.Data.Entities;

namespace NgocNhanShop.ViewModel.System.Roles.Dtos
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Role name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<AppRoleAction> AppRoleActions { get; set; }
    }
}
