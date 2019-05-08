
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;
using System.Net.Http;
using System.Data.Entity;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var userName = await GetUserName();
            var user = await GetUser(userName);
            if (user == null)
            {
                user = await AddUser(new User { UserName = userName });
            }

            return View(user);
        }

        private async Task<User> GetUser(string userName)
        {
            User result = null;
            using (var appContext = new AppContext())
            {
                result = await appContext.Users.FirstOrDefaultAsync(f => f.UserName.ToLower() == userName.ToLower());
            }
            return result;
        }

        public async Task<User> AddUser(User user)
        {
            using (var appContext = new AppContext())
            {
                appContext.Users.Add(user);
                await appContext.SaveChangesAsync();
            }
            return user;
        }

        private async Task<string> GetUserName()
        {
            var userName = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:4172/");
                var response = await client.GetAsync("api/app/GetUserName");
                userName = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : string.Empty;
            }
            return userName;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private int CalculateTriangleSquare(int a, int h)
        {
            return (a * h) / 2;
        }

        [HttpPost]
        public ActionResult CalculateSquare(int a, int h)
        {
            return new HtmlResult("Triangle Square:" + CalculateTriangleSquare(a, h));
        }

        [HttpGet]
        public ActionResult GetUserNameFull()
        {
            return new HtmlResult("All users");
        }

        public ActionResult PermentRedirect()
        {
            return RedirectPermanent("Index");
        }

        public ActionResult Redirect()
        {
            return Redirect("Index");
        }

        public ActionResult NotFound()
        {
            return HttpNotFound();
        }

        public ActionResult StatusCode()
        {
            return new HttpStatusCodeResult(500);
        }

        public FileResult GetFile()
        {
            var filePath = Server.MapPath("~/Content/Site.css");
            var fileType = "application/css";
            var fileName = "Site.css";

            return File(filePath, fileType, fileName);
        }

        public ActionResult ShowInfo()
        {
            var browser = HttpContext.Request.Browser.Browser;
            var userAgent = HttpContext.Request.UserAgent;
            var ip = HttpContext.Request.UserHostAddress;

            // Cookies
            HttpContext.Response.Cookies["IP"].Value = "Статический IP 192.168.1.5";
            var resultIP = HttpContext.Response.Cookies["IP"].Value;

            // Session
            Session["IP"] = ip;
            var resultSessionIP = Session["IP"];


            return new HtmlResult("Browser Name: "+ browser +"; </br>" + "User Agent "+ userAgent + "</br>" + "IP Address: "+ip + "; </br>" + "Session IP: "+ resultSessionIP + "; </br>" + "Cookies IP: " + resultIP);
        }

        public async Task<ActionResult> MethodAsync()
        {
            return await Task.Run(() => { return new HtmlResult("Async Test"); });
        }

        public ActionResult ShowBook()
        {
            var book = new Book { Title = "C# for Begineers", Author = "Rihter", Price = 40 };
            return View(book);
        }

        public ActionResult ShowPartialView()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Buy()
        {
            return View();
        }

    }
}