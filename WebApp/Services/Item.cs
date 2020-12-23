using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Services
{
    public class Item
    {
        public int Quantity { get; set; }
       

        public Product Product { get; set; } = null;
        

        public string Description
        {
            get { return Product.Description; }
        }

        public decimal UnitPrice
        {
            get { return Product.Prix; }
        }

        public decimal TotalPrice
        {
            get
            {
                if(Product != null)
                {
                    return Product.Prix * Quantity;
                }
                return 0;
                
            }
        }

        public Item(Product p)
        {
            this.Product = p;
        }

        public bool Equals(Item item)
        {
            return item.Product.Id == this.Product.Id;
        }

    }
}