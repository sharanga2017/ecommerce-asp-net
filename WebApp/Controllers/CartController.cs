using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        //private ApplicationDbContext _db;

        ApplicationDbContext db = new ApplicationDbContext();
        //private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public CartController()
        {
        }

        //public CartController(/*ApplicationUserManager userManager,*//* ApplicationSignInManager signInManager*/)
        //{
        //    //UserManager = userManager;
        //   // SignInManager = signInManager;
        //}

        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set
        //    {
        //        _signInManager = value;
        //    }
        //}


        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}
        // GET: Cart
        //public ActionResult Index()
        //{
        //    return View();
        //}


        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Liste = CartUser.Instance.Items;
            ViewBag.total = CartUser.Instance.GetSubTotal();
            return View();

        }


        //public ActionResult AddToCart(int id)
        //{
        //    Product prod = db.Products.Find(id);
        //    if (TempData.Peek("CartId") == null)
        //    {
        //        TempData["CartId"] = Guid.NewGuid().ToString();

        //    }
        //    Cart c;
        //    using (c = new Cart(_db, TempData.Peek("CartId").ToString()))
        //    {
        //        c.AddProduct(id);
        //    }


        //    return View(c);
        //}

        
        [AllowAnonymous]
        public ActionResult AddProductToCart(int id)
        {

           // cart / AddProductToCart / 6
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product prod = db.Products.Find(id);                    


            CartUser.Instance.AddItem(prod);
            ViewBag.Liste = CartUser.Instance.Items;
            ViewBag.total = CartUser.Instance.GetSubTotal();
            return RedirectToAction("Index");
         
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult IncrementProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            CartUser.Instance.AddItem(product);
            Item trouve = null;

            foreach (Item item in CartUser.Instance.Items)
            {
                if (item.Product.Id == product.Id)
                    trouve = item;
            }

            var results = new
            {
                ct = 1,
                Total = CartUser.Instance.GetSubTotal(),
                Quatite = trouve.Quantity,
                TotalRow = trouve.TotalPrice
            };
            return Json(results);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DiminuerProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            CartUser.Instance.DecrimentItem(product);
            Item itemInCart = null;

            foreach (Item item in CartUser.Instance.Items)
            {
                if (item.Product.Id == product.Id)
                    itemInCart = item;
            }



            if (itemInCart != null)
            {
                var result = new
                {

                    Total = CartUser.Instance.GetSubTotal(),
                    Quantity = itemInCart.Quantity,
                    TotalPrix = itemInCart.TotalPrice,
                    ct = 1
                };

                return Json(result);

            }
            else
            {
                var results = new
                {
                    ct = 0
                };

                return Json(results);
            }
            return null;


        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            CartUser.Instance.RemoveItem(product);
            var results = new
            {
                Total = CartUser.Instance.GetSubTotal(),
            };

            return Json(results);
        }


        public ActionResult CheckOut()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(FormCollection collection)
        {



            Panier p = new Panier();

            p.ApplicationUser = db.Users.Find(User.Identity.GetUserId());

            db.Paniers.Add(p);
            db.SaveChanges();

            //Commande c = new Commande();
            //c.Panier = p;
            //p.ApplicationUser = db.Users.Find(User.Identity.GetUserId());
            //db.Commands.Add(c);
            //db.SaveChanges();


            //foreach (Item a in ListeCart.Instance.Items)
            //{
            //    db.ListeCards.Add(new ListeCard(p, a.Prod, a.quantite, a.TotalPrice));
            //    db.SaveChanges();

            //}





            CartUser.Instance.Items.Clear();

            ViewBag.Message = "Commande effectuée avec succès";

            return View();

        }

    }
}