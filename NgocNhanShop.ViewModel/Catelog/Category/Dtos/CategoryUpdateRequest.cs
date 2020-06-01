using NgocNhanShop.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.Catelog.Category.Dtos
{
    public class CategoryUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UserUpdate { get; set; }
    }
}
