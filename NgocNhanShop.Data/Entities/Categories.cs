using NgocNhanShop.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
    public class Categories : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }

        public List<Product> Products { get; set; }

    }
}
