using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Common.Dtos
{
    public class PageResult<T> : PageRequestBase
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
    }
}
