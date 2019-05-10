using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApp3.Models;

namespace WebApp3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CreateProuduct()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateProuduct(Product product)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Products.Add(product);
                dataContext.SaveChanges();

               // product.Users.Add(new User { FirstName = "Konstantin", LastName = "TheKoS", Email = "kos@mail.ru" });
               // dataContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int? id)
        {
            using (var dataContext = new DataContext())
            {
                var product = dataContext.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    dataContext.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                    dataContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult EditProduct(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            Product product = null;
            using (var dataContext = new DataContext())
                {
                    product = dataContext.Products.FirstOrDefault(p => p.Id == id);               
                }            
            if (product != null)
            {
                return View(product);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(product).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var productList = new List<Product>();
            var purchaseList = new List<Purchase>();
            using (var dataContext = new DataContext())
            {
                productList = dataContext.Products.ToList();
                purchaseList = dataContext.Purchases.Include("Product").ToList();
            }

            return View(new HomeViewModel { Products=productList, Purchases = purchaseList});
        }

        public ActionResult ShowProduct(int? id)
        {
            Product product = null;
            using (var dataContext = new DataContext())
            {
                product = dataContext.Products.FirstOrDefault(d => d.Id == id);
            }
            
            return View(product);
        }
        [HttpGet]
        public ActionResult BuyProduct(int? id)
        {
            Product product = null;
            using (var dataContext = new DataContext())
            {
                product = dataContext.Products.FirstOrDefault(d => d.Id == id);
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult CreatePurchase(int? id)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Purchases.Add(new Purchase { Date = DateTime.Now, ProductId = id });
                dataContext.SaveChanges();

            };
            return RedirectToAction("Index");
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