using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC.Models
{
    public class HtmlResult : ActionResult
    {
        private readonly string _htmlCode;
        public HtmlResult(string html)
        {
            _htmlCode = html;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title> Main Page</title>";
            fullHtmlCode += "<meta charset=utf-8 />";
            fullHtmlCode += "</head> <body>";
            fullHtmlCode += _htmlCode;
            fullHtmlCode += "</body></html>";
            context.HttpContext.Response.Write(fullHtmlCode);

        }


       
    }
}