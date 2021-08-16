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
    public class DeliveryInfoController : Controller
    {
        private HolovatyiDBEntities db = new HolovatyiDBEntities();

        // GET: DeliveryInfo
        public ActionResult Index()
        {
            return View(db.DeliveryInfo.ToList());
        }

        // GET: DeliveryInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryInfo deliveryInfo = db.DeliveryInfo.Find(id);
            if (deliveryInfo == null)
            {
                return HttpNotFound();
            }
            return View(deliveryInfo);
        }

        // GET: DeliveryInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryInfo_ID,CreateDate,UpdateDate,Order_ID,DispatchDate,ArrivalDate,TrackingNumber,DeliveryPrice,Received")] DeliveryInfo deliveryInfo)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryInfo.Add(deliveryInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryInfo);
        }

        // GET: DeliveryInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryInfo deliveryInfo = db.DeliveryInfo.Find(id);
            if (deliveryInfo == null)
            {
                return HttpNotFound();
            }
            return View(deliveryInfo);
        }

        // POST: DeliveryInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryInfo_ID,CreateDate,UpdateDate,Order_ID,DispatchDate,ArrivalDate,TrackingNumber,DeliveryPrice,Received")] DeliveryInfo deliveryInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryInfo);
        }

        // GET: DeliveryInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryInfo deliveryInfo = db.DeliveryInfo.Find(id);
            if (deliveryInfo == null)
            {
                return HttpNotFound();
            }
            return View(deliveryInfo);
        }

        // POST: DeliveryInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryInfo deliveryInfo = db.DeliveryInfo.Find(id);
            db.DeliveryInfo.Remove(deliveryInfo);
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
