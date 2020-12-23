using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Services
{
    public class CartUser
    {     

        public List<Item> Items { get; private set; }

        public static readonly CartUser Instance;

        static CartUser()
        {

            if (HttpContext.Current.Session["UserPanier"] == null)
            {

                Instance = new CartUser();
                Instance.Items = new List<Item>();
                HttpContext.Current.Session["UserPanier"] = Instance;

            }
            else
                Instance = (CartUser)HttpContext.Current.Session["UserPanier"];
        }

        protected CartUser() { }

        public void AddItem(Product prod)
        {

            Boolean existe = false;
           


            foreach (Item a in Items)
            {
                if (a.Product.Id == prod.Id)
                {
                    a.Quantity++;
                    existe = true;
                    return;
                }
            }
            if (existe == false)
            {

                Item newItem = new Item(prod);
                newItem.Quantity = 1;
                Items.Add(newItem);
            }


        }

        public void DeletePanier()
        {
            HttpContext.Current.Session["UserPanier"] = null;
        }
        public void DecrimentItem(Product produit)
        {

            foreach (Item a in Items)
            {
                if (a.Product.Id == produit.Id)
                {
                    if (a.Quantity <= 0)
                    {
                        RemoveItem(a.Product);
                        return;
                    }
                    else
                    {
                        a.Quantity--;
                        return;
                    }

                }
            }

        }

        public void SetItemQuantity(Product produit, int quantity)
        {

            if (quantity == 0)
            {
                RemoveItem(produit);
                return;
            }

            foreach (Item a in Items)
            {
                if (a.Product.Id == produit.Id)
                {
                    a.Quantity = quantity;
                    return;
                }
            }

        }



        public void RemoveItem(Product produit)
        {

            Item t = null;

            foreach (Item a in Items)
            {

                if (a.Product.Id == produit.Id)
                {
                    t = a;
                }
            }

            if (t != null)
            {
                Items.Remove(t);
            }

        }


        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (Item item in Items)
                subTotal += item.TotalPrice;
            return (decimal)subTotal;
        }

    }
}
