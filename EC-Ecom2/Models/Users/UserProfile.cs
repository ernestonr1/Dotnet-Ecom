using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC_Ecom2.Models.Users
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string City { get; set; }
        public string Streetaddress { get; set; }
        public string Postalcode { get; set; }
        public string Phonenumber { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
    }
}