using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.Common.Dtos
{
    public class PageResult<T> : PageRequestBase
    {
        public List<T> Items { get; set; }
    }
}
