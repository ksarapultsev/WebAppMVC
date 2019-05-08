using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAppMVC.Controllers
{
    public class MyController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            var ip = requestContext.HttpContext.Request.UserHostAddress;
            var response = requestContext.HttpContext.Response;
            response.Write("<h2> Ваш адрес " + ip + "</h2>");
        }
    }
}