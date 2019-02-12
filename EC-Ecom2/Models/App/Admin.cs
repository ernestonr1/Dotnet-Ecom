//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

/* This class contains things that do not have an obvious place yet 
 TODO:
 - add the total of an order to the total income of admin
 - if the cart is empty disable the buttons Update and Place order.
 - add roles and tests different scenarios
 - change db to mysql
 */

namespace EC_Ecom2.Models.App
{
    public class Admin
    {
        public int Id { get; set; }
        public double ShippingCost { get; set; }
        public double Vat { get; set; }
        public decimal TotalIncome { get; set; }
    }
}