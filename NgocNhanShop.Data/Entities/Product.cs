using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
   
    public class Product: Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }

    }
}
