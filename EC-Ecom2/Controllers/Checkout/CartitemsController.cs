using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EC_Ecom2.Models;
using EC_Ecom2.Models.Checkout;

namespace EC_Ecom2.Controllers.Checkout
{
    public class CartitemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cartitems
        public ActionResult Index()
        {
            var cartitems = db.Cartitems.Include(c => c.Product);
            return View(cartitems.ToList());
        }

        // GET: Cartitems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartitem cartitem = db.Cartitems.Find(id);
            if (cartitem == null)
            {
                return HttpNotFound();
            }
            return View(cartitem);
        }

        // GET: Cartitems/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: Cartitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,CartitemTotal,ProductId")] Cartitem cartitem)
        {
            if (ModelState.IsValid)
            {
                db.Cartitems.Add(cartitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", cartitem.ProductId);
            return View(cartitem);
        }

        // GET: Cartitems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartitem cartitem = db.Cartitems.Find(id);
            if (cartitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", cartitem.ProductId);
            return View(cartitem);
        }

        // POST: Cartitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,CartitemTotal,ProductId")] Cartitem cartitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", cartitem.ProductId);
            return View(cartitem);
        }

        // GET: Cartitems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartitem cartitem = db.Cartitems.Find(id);
            if (cartitem == null)
            {
                return HttpNotFound();
            }
            return View(cartitem);
        }

        // POST: Cartitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cartitem cartitem = db.Cartitems.Find(id);
            db.Cartitems.Remove(cartitem);
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
    }
}
