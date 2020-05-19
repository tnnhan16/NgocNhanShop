using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NgocNhanShop.AdminApp.Service.Response
{
    public class ResponseBase
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
