using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC_Ecom2.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }

        public string MainImageUrl { get; set; }
    }
}