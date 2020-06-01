using NgocNhanShop.ViewModel.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.Catelog.Prodcuts.Dtos
{
    public class ProductPageRequest : PageRequestBase
    {
        public string? KeyWork { get; set; }
        public int? CategoryId { get; set; }
    }
}
