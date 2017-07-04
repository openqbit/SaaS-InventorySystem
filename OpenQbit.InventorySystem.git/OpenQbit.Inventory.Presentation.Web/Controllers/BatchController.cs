using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenQbit.Inventory.Common.Models;
using OpenQbit.Inventory.DAL.DataAccess;

namespace OpenQbit.Inventory.Presentation.Web.Controllers
{
    public class BatchController : Controller
    {
        private OpenQbitInventoryContext db = new OpenQbitInventoryContext();

        // GET: Batch
        public ActionResult Index()
        {
            var batch = db.Batch.Include(b => b.customer).Include(b => b.Item).Include(b => b.Supplier);
            return View(batch.ToList());
        }

        // GET: Batch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batch.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // GET: Batch/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            ViewBag.ItemID = new SelectList(db.Item, "ID", "Name");
            ViewBag.SupplierID = new SelectList(db.Supplier, "ID", "name");
            return View();
        }

        // POST: Batch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Qty,UnitPrice,ItemID,SupplierID,CustomerID")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Batch.Add(batch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", batch.CustomerID);
            ViewBag.ItemID = new SelectList(db.Item, "ID", "Name", batch.ItemID);
            ViewBag.SupplierID = new SelectList(db.Supplier, "ID", "name", batch.SupplierID);
            return View(batch);
        }

        // GET: Batch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batch.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", batch.CustomerID);
            ViewBag.ItemID = new SelectList(db.Item, "ID", "Name", batch.ItemID);
            ViewBag.SupplierID = new SelectList(db.Supplier, "ID", "name", batch.SupplierID);
            return View(batch);
        }

        // POST: Batch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Qty,UnitPrice,ItemID,SupplierID,CustomerID")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", batch.CustomerID);
            ViewBag.ItemID = new SelectList(db.Item, "ID", "Name", batch.ItemID);
            ViewBag.SupplierID = new SelectList(db.Supplier, "ID", "name", batch.SupplierID);
            return View(batch);
        }

        // GET: Batch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batch.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: Batch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Batch batch = db.Batch.Find(id);
            db.Batch.Remove(batch);
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
