using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC_Ecom2.Models.Checkout
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public virtual ICollection<Cartitem> Cartitems { get; set; }
    }
}