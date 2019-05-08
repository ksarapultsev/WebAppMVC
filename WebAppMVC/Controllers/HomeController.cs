
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
               user =  await AddUser(new User { UserName = userName });
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
    }
}