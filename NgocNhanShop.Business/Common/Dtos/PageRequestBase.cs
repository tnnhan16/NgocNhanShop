using NgocNhanShop.Business.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Dtos
{
    public class PageRequestBase : RequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 10;
    }
}
