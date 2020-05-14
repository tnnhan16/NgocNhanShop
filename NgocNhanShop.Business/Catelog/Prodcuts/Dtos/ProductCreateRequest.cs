using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Prodcuts.Dtos
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public Guid UserCreate { get; set; }
        public bool IsDelete { get; set; } = false;
        public int CategoryId { get; set; }
    }
}
