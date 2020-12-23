using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Photo { get; set; }

        public string Description { get; set; }

        public decimal Prix { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }






    }
}