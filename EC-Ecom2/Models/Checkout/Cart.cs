using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC_Ecom2.Models.Checkout
{
    public class Cart
    {
        public int Id { get; set; }

        
        public double Total { get; set; }
        public string State { get; set; } // Can be "active", "ordered", "abandoned"

        public string SessionId { get; set; }

        public string UserId { get; set; }
        //public ApplicationUser User { get; set; }

        public virtual ICollection<Cartitem> Cartitems { get; set; }
    }
}