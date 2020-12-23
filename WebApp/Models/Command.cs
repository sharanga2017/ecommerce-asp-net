using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Command
    {
        public int Id { get; set; }
        public int PanierId { get; set; }
       public virtual Panier Panier { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}