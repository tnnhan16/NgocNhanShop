using NgocNhanShop.Business.Catelog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.Catelog.Prodcuts.Dtos
{
    public class ProductPageRequest : PageRequestBase
    {
        public string? KeyWork { get; set; }
        public int? CategoryId { get; set; }
    }
}
