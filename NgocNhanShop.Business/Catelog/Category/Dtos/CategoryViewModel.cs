using NgocNhanShop.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Category.Dtos
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? UserCreate { get; set; }
        public bool? IsDelete { get; set; }
    }
}
