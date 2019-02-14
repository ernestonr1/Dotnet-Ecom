using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EC_Ecom2.Models;
using EC_Ecom2.Models.Products;
using EC_Ecom2.Models.Checkout;
using Microsoft.AspNet.Identity;


namespace EC_Ecom2.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,MainImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,MainImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

        // Add a product to the cart.
        public ActionResult addtocart(int id)
        {
            var product = db.Products.Find(id);
            var cartViewModel = new CartViewModel();
            ICollection<Cartitem> cartItemList;
            Cart cart;
            string sessionId = System.Web.HttpContext.Current.Session.SessionID;
            // Check if the current user has a cart object connected to his sessionid.
            var existingCart = from c in db.Carts
                               where c.SessionId == sessionId && c.State == "active"
                               select c;
            // If the current user doesn't have a cart ...
            if (!existingCart.Any())
            {
                cart = new Cart();
                cart.SessionId = sessionId;
                cart.State = "active";

                if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    cart.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                }

                cartItemList = new List<Cartitem>();
                var Cartitem = new Cartitem();
                Cartitem.ProductId = id;
                Cartitem.Quantity = 1;
                Cartitem.CartitemTotal = product.Price;
                cart.Total = Cartitem.CartitemTotal;
                db.Cartitems.Add(Cartitem);
                cartItemList.Add(Cartitem);
                cart.Cartitems = cartItemList;
                db.Carts.Add(cart);
                db.SaveChanges();
                cartViewModel.Cart = cart;
                cartViewModel.Cartitems = cart.Cartitems;

            }
            // If the current user does have a cart ...
            else
            {
                cart = existingCart.First();
                if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    cart.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                }
                    cartItemList = cart.Cartitems;
                // Check if there already is a cartitem with this product id.
                var checkCartitem = from c in db.Cartitems
                                    where c.ProductId == id && c.CartId == cart.Id
                                    select c;
                // If the product is not in the cart ...
                if (!checkCartitem.Any())
                {
                    var Cartitem = new Cartitem();
                    Cartitem.ProductId = id;
                    Cartitem.Quantity = 1;
                    Cartitem.CartitemTotal = product.Price;
                    cart.Total += Cartitem.CartitemTotal;
                    db.Cartitems.Add(Cartitem);
                    cartItemList.Add(Cartitem);
                    cart.Cartitems = cartItemList;
                    db.SaveChanges();
                    cartViewModel.Cart = cart;
                    cartViewModel.Cartitems = cart.Cartitems;
                }
                //If the product is already in the cart put a message out and stay on the
                // product page.
                else
                {
                    return RedirectToAction("Index");
                }
            }
            //cart = db.Carts.Find(cart.Id);
            //var cartItems = from c in db.Cartitems
            //                where c.Cart.Id == cart.Id
            //                select c;
            //cartViewModel.Cart = cart;
            //cartViewModel.Cartitems = cartItems.ToList();
            //return RedirectToAction("CartIndex", "Carts");
            return View("~/Views/Carts/CartIndex.cshtml", cartViewModel);
        }
    }
}




