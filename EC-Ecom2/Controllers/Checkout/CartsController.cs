using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EC_Ecom2.Models;
using EC_Ecom2.Models.App;
using EC_Ecom2.Models.Checkout;
using EC_Ecom2.ViewModels.Checkout;
using Microsoft.AspNet.Identity;

namespace EC_Ecom2.Controllers.Checkout
{
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carts
        //public ActionResult Index()
        //{
        //    return View(db.Carts.ToList());
        //}
        public ActionResult Index()
        {
            var cartViewModel = new CartViewModel();
            //ICollection<Cartitem> cartItemList;
            Cart cart = new Cart();
            //const string CartSessionKey = "CartId";
            string sessionId = System.Web.HttpContext.Current.Session.SessionID;
            var existingCart = from c in db.Carts
                               where c.SessionId == sessionId && c.State == "active"
                               select c;

            var cartItems = from c in db.Cartitems
                            //where c.Cart.Id == cart.Id
                            where c.Cart.Id == existingCart.FirstOrDefault().Id
                            select c;
            //foreach ( var item in cartItems)
            //{   
            //    System.Diagnostics.Debug.WriteLine("Product id: " + item.ProductId );
            //}
            
            foreach(var item in existingCart)
            {
                cart = item;
            }
            cartViewModel.Cart = cart;
            cartViewModel.Cartitems = cartItems.ToList();

            return View("CartIndex", cartViewModel);
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Total,State,SessionId,UserId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Total,State,SessionId,UserId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Handles cart.
        // Handles both updating of cart and placing of order.
        //public ActionResult HandleCart(int CartId, int CartitemId, int newQuantity)
        public ActionResult HandleCart(string submitButton, string returnUrl)
        {
            //System.Diagnostics.Debug.WriteLine("Inside HandleCart.");
            string cartId = Request.Form["item.Cart.Id"];
            //System.Diagnostics.Debug.WriteLine("CartId is: " + cartId[0]);
            //System.Diagnostics.Debug.WriteLine("CartId2 is: " + Request.Form["item.Cart.Id"]);

            var cartItemIds = Request.Form["item.Id"];
            var cartItemIdsArray = cartItemIds.Split(',');
            System.Diagnostics.Debug.WriteLine("Number of cartitemids is: " + cartItemIdsArray.Length);
            System.Diagnostics.Debug.WriteLine("First cartitemids is: " + cartItemIdsArray[0]);

            var productIds = Request.Form["item.Product.Id"];
            var productIdsArray = productIds.Split(',');
            System.Diagnostics.Debug.WriteLine("Number of productids is: " + productIdsArray.Length);

            var quantities = Request.Form["item.Quantity"];
            var quantitiesArray = quantities.Split(',');
            System.Diagnostics.Debug.WriteLine("Number of productids is: " + quantitiesArray.Length);

            // You will have to get product price somehow.
            System.Diagnostics.Debug.WriteLine("Quantity is: " + Request.Form["item.Quantity"][0]);

            switch (submitButton)
            {
                case "Uppdatera":
                    // Update the quantity and price for each cartitem                    
                    //System.Diagnostics.Debug.WriteLine("Klicked button: Uppdatera");
                    // The number of cartitem IDs is the same as there are cartitems in 
                    // the cart.
                    double cartTotal = 0;
                    for (int i = 0; i < cartItemIdsArray.Length; i++)
                    {
                        //System.Diagnostics.Debug.WriteLine("i is: " + i);
                        string counter = cartItemIdsArray[i].ToString();
                        //System.Diagnostics.Debug.WriteLine("counter is: " + counter);
                        int j = Convert.ToInt32(counter);
                        var cartItem = db.Cartitems.Find( j );
                        double productPrice = db.Products.Find(Int32.Parse(productIdsArray[i].ToString())).Price;
                        // If the number in the input field is 0 the cartitem will be removed.
                        if (Int32.Parse(quantitiesArray[i].ToString()) < 1)
                        {
                            db.Cartitems.Remove(cartItem);
                        }
                        else
                        {
                            cartItem.Quantity = Int32.Parse(quantitiesArray[i].ToString());
                            cartItem.CartitemTotal = Int32.Parse(quantitiesArray[i].ToString()) * db.Products.Find(Int32.Parse(productIdsArray[i].ToString())).Price;
                            cartTotal += cartItem.CartitemTotal;
                        }
                        
                        db.SaveChanges();
                    }
                    string sId = System.Web.HttpContext.Current.Session.SessionID;
                    var cartFromDb = from c in db.Carts
                                     where c.SessionId == sId && c.State == "active"
                                     select c;
                    var cartForTotal = cartFromDb.FirstOrDefault();
                    cartForTotal.Total = cartTotal;
                    db.SaveChanges();

                    ///////////////////////////////////////////////////////
                    // Getting the entire cart and redirecting to cartindex
                    ///////////////////////////////////////////////////////
                    var cartViewModel = new CartViewModel();
                    Cart cart = new Cart();
                    string sessionId = System.Web.HttpContext.Current.Session.SessionID;
                    var existingCart = from c in db.Carts
                                       where c.SessionId == sessionId && c.State == "active"
                                       select c;

                    var cartItems = from c in db.Cartitems
                                        //where c.Cart.Id == cart.Id
                                    where c.Cart.Id == existingCart.FirstOrDefault().Id
                                    select c;

                    foreach (var item in existingCart)
                    {
                        cart = item;
                    }
                    cartViewModel.Cart = cart;
                    cartViewModel.Cartitems = cartItems.ToList();
                    return View("CartIndex", cartViewModel);
                // Getting the entire cart and redirecting to cartindex ends here
                case "Checkoutdetaljer":

                    return RedirectToAction("CheckoutDetails");

                case "Lägg order":
                    ///////////////////
                    // Place the order.
                    ///////////////////
                    /* Now an order is created here automatic when the button is clicked.
                     * All this code has to be moved from here. Here the user should be
                     * taken to checkout details page.                     
                     */
                    if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        Order order = new Order();
                        Admin admin = db.Admins.Find(1);
                        order.Streetaddress = "Happy street 1";
                        string sessionIdForOrder = System.Web.HttpContext.Current.Session.SessionID;
                        var cartForOrderIQueriable = from c in db.Carts
                                                     where c.SessionId == sessionIdForOrder && c.State == "active"
                                                     select c;
                        var cartForOrder = cartForOrderIQueriable.FirstOrDefault();
                        order.Total = cartForOrder.Total;
                        admin.TotalIncome += (decimal)order.Total;
                        order.UserId = cartForOrder.UserId;
                        order.SessionId = cartForOrder.SessionId;
                        order.ShippingCost = 4.50;
                        order.State = "New";
                        db.Orders.Add(order);
                        db.SaveChanges();
                        var cartItemsForOrder = cartForOrder.Cartitems;
                        ICollection<Orderitem> Orderitems = new List<Orderitem>();
                        foreach (var item in cartItemsForOrder)
                        {
                            Orderitem orderItem = new Orderitem();
                            orderItem.OrderId = order.Id;
                            orderItem.OrderitemTotal = item.CartitemTotal;
                            orderItem.ProductId = item.ProductId;
                            orderItem.Quantity = item.Quantity;
                            db.Orderitems.Add(orderItem);
                            Orderitems.Add(orderItem);
                        }
                        cartForOrder.State = "ordered";
                        db.SaveChanges();
                        //return View("Index", "Orders");
                        return RedirectToAction("Index", "Orders");
                    }
                    else
                    {
                        return RedirectToAction("CheckoutLogin", "Account");
                    }
                    

                default:
                    // If they've submitted the form without a submitButton, 
                    // just return the view again.
                    return View();
            }
            return View("~/Views/Products/Index.cshtml");
        }
        public ActionResult CheckoutDetails()
        {
            CheckoutDetailsViewModel checkoutDetailsViewModel = new CheckoutDetailsViewModel();
            checkoutDetailsViewModel.ApplicationUserId = User.Identity.GetUserId();
            //string userId = checkoutDetailsViewModel.ApplicationUser.Id;
            var userProfile = from u in db.UserProfiles
                              where u.ApplicationUserId == checkoutDetailsViewModel.ApplicationUserId
                              select u;
            checkoutDetailsViewModel.UserProfile = userProfile.First();
            var cart = from c in db.Carts
                       where c.UserId == checkoutDetailsViewModel.ApplicationUserId && c.State == "active"
                       select c;
            checkoutDetailsViewModel.Cart = cart.First();
            return View(checkoutDetailsViewModel);
        }

        public ActionResult Payment()
        {
            CheckoutDetailsViewModel checkoutDetailsViewModel = new CheckoutDetailsViewModel();
            checkoutDetailsViewModel.ApplicationUserId = User.Identity.GetUserId();
            //string userId = checkoutDetailsViewModel.ApplicationUser.Id;
            var userProfile = from u in db.UserProfiles
                              where u.ApplicationUserId == checkoutDetailsViewModel.ApplicationUserId
                              select u;
            checkoutDetailsViewModel.UserProfile = userProfile.First();
            var cart = from c in db.Carts
                       where c.UserId == checkoutDetailsViewModel.ApplicationUserId && c.State == "active"
                       select c;
            checkoutDetailsViewModel.Cart = cart.First();
            Admin admin = db.Admins.Find(1);
            checkoutDetailsViewModel.ShippingCost = admin.ShippingCost;
            return View(checkoutDetailsViewModel);
        }

        public ActionResult PlaceOrder()
        {
            ///////////////////
            // Place the order.
            ///////////////////
            /* Now an order is created here automatic when the button is clicked.
             * All this code has to be moved from here. Here the user should be
             * taken to checkout details page.                     
             */
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Order order = new Order();
                Admin admin = db.Admins.Find(1);
                order.Streetaddress = "Happy street 1";
                string sessionIdForOrder = System.Web.HttpContext.Current.Session.SessionID;
                var cartForOrderIQueriable = from c in db.Carts
                                             where c.SessionId == sessionIdForOrder && c.State == "active"
                                             select c;
                var cartForOrder = cartForOrderIQueriable.FirstOrDefault();
                admin.TotalIncome += (decimal)order.Total;
                order.UserId = cartForOrder.UserId;
                order.SessionId = cartForOrder.SessionId;
                //order.ShippingCost = 4.50;
                order.ShippingCost = admin.ShippingCost;
                order.Total = cartForOrder.Total + admin.ShippingCost;
                order.State = "New";
                db.Orders.Add(order);
                db.SaveChanges();
                var cartItemsForOrder = cartForOrder.Cartitems;
                ICollection<Orderitem> Orderitems = new List<Orderitem>();
                foreach (var item in cartItemsForOrder)
                {
                    Orderitem orderItem = new Orderitem();
                    orderItem.OrderId = order.Id;
                    orderItem.OrderitemTotal = item.CartitemTotal;
                    orderItem.ProductId = item.ProductId;
                    orderItem.Quantity = item.Quantity;
                    db.Orderitems.Add(orderItem);
                    Orderitems.Add(orderItem);
                }
                cartForOrder.State = "ordered";
                db.SaveChanges();
                //return View("Index", "Orders");
                //return RedirectToAction("Index", "Orders");
                return RedirectToAction("Details", "Orders", new { id = order.Id });
                //return View();
            }
            else
            {
                return RedirectToAction("CheckoutLogin", "Account");
            }
        }
    }
}
