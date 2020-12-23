using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ItemCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; }

        public decimal Total => Quantity * Product.Prix; 
    }
}