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
    public class FurnitureController : Controller
    {
        private HolovatyiDBEntities db = new HolovatyiDBEntities();

        // GET: Furniture
        public ActionResult Index()
        {
            var furniture = db.Furniture.Include(f => f.Warehouse);
            return View(furniture.ToList());
        }

        // GET: Furniture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furniture.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // GET: Furniture/Create
        public ActionResult Create()
        {
            ViewBag.Warehouse_ID = new SelectList(db.Warehouse, "Warehouse_ID", "Address");
            return View();
        }

        // POST: Furniture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Furniture_ID,Name,Description,Amount,Warehouse_ID,CreateDate,UpdateDate")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                db.Furniture.Add(furniture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Warehouse_ID = new SelectList(db.Warehouse, "Warehouse_ID", "Address", furniture.Warehouse_ID);
            return View(furniture);
        }

        // GET: Furniture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furniture.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            ViewBag.Warehouse_ID = new SelectList(db.Warehouse, "Warehouse_ID", "Address", furniture.Warehouse_ID);
            return View(furniture);
        }

        // POST: Furniture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Furniture_ID,Name,Description,Amount,Warehouse_ID,CreateDate,UpdateDate")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(furniture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Warehouse_ID = new SelectList(db.Warehouse, "Warehouse_ID", "Address", furniture.Warehouse_ID);
            return View(furniture);
        }

        // GET: Furniture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furniture.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // POST: Furniture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Furniture furniture = db.Furniture.Find(id);
            db.Furniture.Remove(furniture);
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
