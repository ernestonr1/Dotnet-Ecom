using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC_Ecom2.Models.Checkout
{
    public class Order
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public string State { get; set; } // Can be "Shipped", "Handling", "New"

        public string SessionId { get; set; }

        public string UserId { get; set; }
        //public ApplicationUser User { get; set; }

        public string Streetaddress { get; set; }

        public double ShippingCost { get; set; }

        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}