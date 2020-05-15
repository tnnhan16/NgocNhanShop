using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Prodcuts.Dtos
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid UserCreate { get; set; }
        public bool? IsDelete { get; set; }
        public int CategoryId { get; set; }
    }
}
