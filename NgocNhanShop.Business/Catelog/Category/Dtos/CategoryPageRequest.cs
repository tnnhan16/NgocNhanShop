using NgocNhanShop.Business.Catelog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Category.Dtos
{
    public class CategoryPageRequest: PageRequestBase
    {
        public string KeyWork { get; set; }
    }
}
