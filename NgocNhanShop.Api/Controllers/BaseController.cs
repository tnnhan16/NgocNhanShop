using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using NgocNhanShop.ViewModel.Common.Dtos;

namespace NgocNhanShop.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

            Assembly asm = Assembly.GetExecutingAssembly();

            var controllers = asm.GetTypes()
                .Where(type => typeof(BaseController).IsAssignableFrom(type))
                .Select(x => new 
                {
                    Name = x.Name,
                    FullName = x.FullName,
                    Namespace = x.Namespace
                }).OrderBy(x => x.FullName).ToList();

            var methods = asm.GetTypes()
                .Where(type => typeof(BaseController).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods())
                .Where(method => method.IsPublic && !method.IsDefined(typeof(System.Web.Http.NonActionAttribute))
                   && method.ReturnType == typeof(Task<IActionResult>))
                .Select(x => new
                {
                    Controller = x.DeclaringType.Name,
                    Action = x.Name,
                    ReturnType = x.ReturnType.Name,
                }).OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

        }
    }
}
