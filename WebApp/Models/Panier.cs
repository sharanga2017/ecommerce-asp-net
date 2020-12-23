using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Panier
    {

       
        public Panier()
        {
           
        }
        public int PanierId { get; set; }

       
        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }
}