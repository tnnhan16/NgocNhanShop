using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Entities
{
    public class Base
    {
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid UserCreate { get; set; }
        public Guid? UserUpdate { get; set; }
        public bool? IsDelete { get; set; }
    }
}
