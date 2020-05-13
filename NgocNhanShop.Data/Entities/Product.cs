using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public Guid UserCreate { get; set; }
        public Guid? UserUpdate { get; set; }
        public bool IsDelete { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
