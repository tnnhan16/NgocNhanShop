using NgocNhanShop.ViewModel.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.System.Dtos.Users
{
    public class UserPageRequest : PageRequestBase
    {
        public string Keyword { get; set; }
    }
}
