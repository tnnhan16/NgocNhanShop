using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Dtos
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
    }
}
