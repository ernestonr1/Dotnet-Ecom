using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EC_Ecom2.Models.Products; 

namespace EC_Ecom2.Models.Checkout
{
    public class Cartitem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double CartitemTotal { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}