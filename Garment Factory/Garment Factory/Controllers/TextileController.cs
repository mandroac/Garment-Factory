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
    public class TextileController : Controller
    {
        private HolovatyiDBEntities db = new HolovatyiDBEntities();

        // GET: Textile
        public ActionResult Index()
        {
            var textile = db.Textile.Include(t => t.Supplier).Include(t => t.Warehouse);
            return View(textile.ToList());
        }

        // GET: Textile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Textile textile = db.Textile.Find(id);
            if (textile == null)
            {
                return HttpNotFound();
            }
            return View(textile);
        }

        // GET: Textile/Create
        public ActionResult Create()
        {
            ViewBag.Supplier_ID = new SelectList(db.Supplier, "Supplier_ID", "Name");
            ViewBag.Warehouse_ID = new SelectList(db.Warehouse, "Warehouse_ID", "Address");
            return View();
        }

        // POST: Textile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,AvailableSquare,PricePerSquare,Thickness,Color,Description,Textile_ID,Warehouse_ID,Supplier_ID,CreateDate,UpdateDate")] Textile textile)
        {
            if (ModelState.IsValid)
            {
                db.Textile.Add(textile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Supplier_ID = new SelectList(db.Supplier, "Supplier_ID", "Name", textile.Supplier_ID);
            ViewBag.Warehouse_ID = new SelectList(db.Warehouse, "Warehouse_ID", "Address", textile.Warehouse_ID);
            return View(textile);
        }

        // GET: Textile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Textile textile = db.Textile.Find(id);
            if (textile == null)
            {
                return HttpNotFound();
            }
            ViewBag.Supplier_ID = new SelectList(db.Supplier, "Supplier_ID", "Name", textile.Supplier_ID);
            ViewBag.Warehouse_ID = new SelectList(db.Warehouse, "Warehouse_ID", "Address", textile.Warehouse_ID);
            return View(textile);
        }

        // POST: Textile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,AvailableSquare,PricePerSquare,Thickness,Color,Description,Textile_ID,Warehouse_ID,Supplier_ID,CreateDate,UpdateDate")] Textile textile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(textile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Supplier_ID = new SelectList(db.Supplier, "Supplier_ID", "Name", textile.Supplier_ID);
            ViewBag.Warehouse_ID = new SelectList(db.Warehouse, "Warehouse_ID", "Address", textile.Warehouse_ID);
            return View(textile);
        }

        // GET: Textile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Textile textile = db.Textile.Find(id);
            if (textile == null)
            {
                return HttpNotFound();
            }
            return View(textile);
        }

        // POST: Textile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Textile textile = db.Textile.Find(id);
            db.Textile.Remove(textile);
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
