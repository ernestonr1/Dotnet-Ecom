using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EC_Ecom2.Models;
using EC_Ecom2.Models.Checkout;
using EC_Ecom2.Models.Users;

namespace EC_Ecom2.ViewModels.Checkout
{
    public class CheckoutDetailsViewModel
    {
        public int Id { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}