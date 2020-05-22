using NgocNhanShop.Business.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Common.Dtos
{
    public class PageRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 10;
        public int Total { get; set; }
        public int PageCount
        {
            get
            {
                var pageCount = (double)Total / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
