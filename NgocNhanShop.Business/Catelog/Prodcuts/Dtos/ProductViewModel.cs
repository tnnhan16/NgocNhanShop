using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Prodcuts.Dtos
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid UserCreate { get; set; }
        public string CategoryName { get; set; }
    }
}
