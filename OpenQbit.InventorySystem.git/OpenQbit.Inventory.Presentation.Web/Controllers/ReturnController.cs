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
    public class ReturnController : Controller
    {
        private OpenQbitInventoryContext db = new OpenQbitInventoryContext();

        // GET: Return
        public ActionResult Index()
        {
            var returns = db.Return.Include(b => b.Batch).Include(b => b.customer).Include(b => b.Supplier);
            return View(returns.ToList());
        }

        // GET: Return/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return @return = db.Return.Find(id);
            if (@return == null)
            {
                return HttpNotFound();
            }
            return View(@return);
        }

        // GET: Return/Create
        public ActionResult Create()
        {
            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            ViewBag.SupplierID = new SelectList(db.Supplier, "ID", "name");
            return View();
        }

        // POST: Return/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Qty,CustomerID,BatchID,SupplierID")] Return @return)
        {
            if (ModelState.IsValid)
            {
                db.Return.Add(@return);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID", @return.BatchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", @return.CustomerID);
            ViewBag.SupplierID = new SelectList(db.Supplier, "ID", "name", @return.SupplierID);
            return View(@return);
        }

        // GET: Return/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return @return = db.Return.Find(id);
            if (@return == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID", @return.BatchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", @return.CustomerID);
            ViewBag.SupplierID = new SelectList(db.Supplier, "ID", "name", @return.SupplierID);
            return View(@return);
        }

        // POST: Return/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Qty,CustomerID,BatchID,SupplierID")] Return @return)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@return).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID", @return.BatchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", @return.CustomerID);
            ViewBag.SupplierID = new SelectList(db.Supplier, "ID", "name", @return.SupplierID);
            return View(@return);
        }

        // GET: Return/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return @return = db.Return.Find(id);
            if (@return == null)
            {
                return HttpNotFound();
            }
            return View(@return);
        }

        // POST: Return/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Return @return = db.Return.Find(id);
            db.Return.Remove(@return);
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
