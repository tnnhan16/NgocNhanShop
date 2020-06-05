using NgocNhanShop.ViewModel.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.System.Users.Dtos
{
    public class UserPageRequest : PageRequestBase
    {
        public string Keyword { get; set; }
    }
}
