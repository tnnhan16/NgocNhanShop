using NgocNhanShop.ViewModel.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.System.Actions.Dtos
{
    public class ActionPageRequest : PageRequestBase
    {
        public string Keyword { get; set; }
    }
}
