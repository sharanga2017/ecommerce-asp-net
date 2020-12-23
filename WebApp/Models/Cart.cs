using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Cart : IDisposable
    {

        private ApplicationDbContext _db = new ApplicationDbContext();
        private string _cartId;
        public Cart(ApplicationDbContext Db, string CartId)
        {
            // _db = Db;
            _db = new ApplicationDbContext();
            _cartId = CartId;

        }


        public void AddProduct(int id)
        {
            ItemCart item = _db.ItemsCart.
                SingleOrDefault(it => it.CartId == _cartId && it.ProductId == id);

            if (item == null)
            {
                item = new ItemCart()
                {
                    CartId = _cartId,
                    ProductId = id,
                    Quantity = 1,

                };
                _db.ItemsCart.Add(item);

            }
            else
            {
                item.Quantity++;

            }
            _db.SaveChanges();

        }


        public List<ItemCart> Items()
        {
            List<ItemCart> items;
            using (ApplicationDbContext _db = new ApplicationDbContext())
            {
                 items = _db.ItemsCart.Where(it => it.CartId == _cartId).Include(it => it.Product).ToList();
            }
            return items;
        }

        // montant Panier
        public decimal Total()
        {
            decimal Total;
            using (ApplicationDbContext _db = new ApplicationDbContext())
            {
                Total = _db.ItemsCart.Where(it => it.CartId == _cartId).Sum(it => (it.Total));
            }
                return Total;
        }

        // quantity items
        public int Quantity()
        {
            int q = 0;
            using (ApplicationDbContext _db = new ApplicationDbContext())
            {
                 q = _db.ItemsCart.Where(it => it.CartId == _cartId).ToList().Count;
            }
            

            

            return q;
        }

        public void Dispose()
        {
           if(_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }
    }
}