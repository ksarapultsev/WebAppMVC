using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWork1.Models;

namespace HomeWork1.Controllers
{
    public class EmployeesController : Controller
    {
        //BookContext db = new BookContext();

        //public ActionResult Index()
        //{
        //    SelectList books = new SelectList(db.Books, "Author", "Name");
        //    ViewBag.Books = books;
        //    return View();
        //}

        // GET: Employees
        AppContext db = new AppContext();

        public ActionResult Index()
        {
            SelectList employee = new SelectList(db.Employees, "Пользователь", "имя");
            ViewBag.Employees = employee;
            return View();
        }

      
    }
}
