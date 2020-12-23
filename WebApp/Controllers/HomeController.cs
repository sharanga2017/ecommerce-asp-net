using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public async Task<ActionResult> Index()
        {

            List<Product> products = await db.Products.ToListAsync();
            return View(products);

            
        }


        public async Task<ActionResult> ProductByGenre(string genre)
        {

            List<Product> products = await db.Products.Include(p => p.Genre).Where(p => p.Genre.Name == genre).ToListAsync();
            return View(products);
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



        public ActionResult Products()
        {
            List<Product> model = db.Products.ToList<Product>();

            return View(model);
        }
    }
}