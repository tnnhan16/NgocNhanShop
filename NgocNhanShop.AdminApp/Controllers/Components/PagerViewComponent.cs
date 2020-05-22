using Microsoft.AspNetCore.Mvc;
using NgocNhanShop.Business.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgocNhanShop.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageRequestBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
