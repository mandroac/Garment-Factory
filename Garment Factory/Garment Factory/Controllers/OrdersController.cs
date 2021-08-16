using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garment_Factory.Models;

namespace Garment_Factory.Controllers
{
    public class OrdersController : Controller
    {
        private HolovatyiDBEntities db = new HolovatyiDBEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var order = db.Order.Include(o => o.Client).Include(o => o.DeliveryInfo).Include(o => o.Product);
            return View(order.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.Client_ID = new SelectList(db.Client, "ClientID", "Name");
            ViewBag.DeliveryInfo_ID = new SelectList(db.DeliveryInfo, "DeliveryInfo_ID", "TrackingNumber");
            ViewBag.Product_ID = new SelectList(db.Product, "Product_ID", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_ID,CreateDate,Amount,Product_ID,Client_ID,Coupon,DeliveryInfo_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Client_ID = new SelectList(db.Client, "ClientID", "Name", order.Client_ID);
            ViewBag.DeliveryInfo_ID = new SelectList(db.DeliveryInfo, "DeliveryInfo_ID", "TrackingNumber", order.DeliveryInfo_ID);
            ViewBag.Product_ID = new SelectList(db.Product, "Product_ID", "Name", order.Product_ID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client_ID = new SelectList(db.Client, "ClientID", "Name", order.Client_ID);
            ViewBag.DeliveryInfo_ID = new SelectList(db.DeliveryInfo, "DeliveryInfo_ID", "TrackingNumber", order.DeliveryInfo_ID);
            ViewBag.Product_ID = new SelectList(db.Product, "Product_ID", "Name", order.Product_ID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_ID,CreateDate,Amount,Product_ID,Client_ID,Coupon,DeliveryInfo_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client_ID = new SelectList(db.Client, "ClientID", "Name", order.Client_ID);
            ViewBag.DeliveryInfo_ID = new SelectList(db.DeliveryInfo, "DeliveryInfo_ID", "TrackingNumber", order.DeliveryInfo_ID);
            ViewBag.Product_ID = new SelectList(db.Product, "Product_ID", "Name", order.Product_ID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
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
