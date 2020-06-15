using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.System.Actions.Dtos
{
    public class ActionUpdateRequest
    {
        public string Description { get; set; }

        public Guid UserUpdate { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
