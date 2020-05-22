using NgocNhanShop.Business.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.System.Dtos
{
    public class UserPageRequest : PageRequestBase
    {
        public string Keyword { get; set; }
    }
}
