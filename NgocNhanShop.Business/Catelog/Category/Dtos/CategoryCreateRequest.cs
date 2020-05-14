using NgocNhanShop.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Category.Dtos
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; } = Status.Active;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public Guid UserCreate { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
