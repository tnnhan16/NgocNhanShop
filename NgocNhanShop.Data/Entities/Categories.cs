using NgocNhanShop.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid UserCreate { get; set; }
        public Guid? UserUpdate { get; set; }
        public bool? IsDelete { get; set; }

        public List<Product> Products { get; set; }

    }
}
