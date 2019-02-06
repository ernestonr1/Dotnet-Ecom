using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC_Ecom2.Models.Checkout
{
    public class Orderitem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double OrderitemTotal { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}