using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Prodcuts.Dtos
{
    public class ProductUpdateRequest
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public Guid? UserUpdate { get; set; }
        public int CategoryId { get; set; }
    }
}
