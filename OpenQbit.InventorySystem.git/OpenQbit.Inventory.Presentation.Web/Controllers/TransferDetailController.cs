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
    public class TransferDetailController : Controller
    {
        private OpenQbitInventoryContext db = new OpenQbitInventoryContext();

        // GET: TransferDetail
        public ActionResult Index()
        {
            var transferDetail = db.TransferDetail.Include(t => t.Batch).Include(t => t.customer).Include(t => t.Distributer).Include(t => t.Location);
            return View(transferDetail.ToList());
        }

        // GET: TransferDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferDetail transferDetail = db.TransferDetail.Find(id);
            if (transferDetail == null)
            {
                return HttpNotFound();
            }
            return View(transferDetail);
        }

        // GET: TransferDetail/Create
        public ActionResult Create()
        {
            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            ViewBag.DistributerID = new SelectList(db.Distributer, "ID", "Name");
            ViewBag.LocationID = new SelectList(db.Location, "ID", "Name");
            return View();
        }

        // POST: TransferDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,BatchID,LocationID,DistributerID")] TransferDetail transferDetail)
        {
            if (ModelState.IsValid)
            {
                db.TransferDetail.Add(transferDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID", transferDetail.BatchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", transferDetail.CustomerID);
            ViewBag.DistributerID = new SelectList(db.Distributer, "ID", "Name", transferDetail.DistributerID);
            ViewBag.LocationID = new SelectList(db.Location, "ID", "Name", transferDetail.LocationID);
            return View(transferDetail);
        }

        // GET: TransferDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferDetail transferDetail = db.TransferDetail.Find(id);
            if (transferDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID", transferDetail.BatchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", transferDetail.CustomerID);
            ViewBag.DistributerID = new SelectList(db.Distributer, "ID", "Name", transferDetail.DistributerID);
            ViewBag.LocationID = new SelectList(db.Location, "ID", "Name", transferDetail.LocationID);
            return View(transferDetail);
        }

        // POST: TransferDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,BatchID,LocationID,DistributerID")] TransferDetail transferDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transferDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID", transferDetail.BatchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", transferDetail.CustomerID);
            ViewBag.DistributerID = new SelectList(db.Distributer, "ID", "Name", transferDetail.DistributerID);
            ViewBag.LocationID = new SelectList(db.Location, "ID", "Name", transferDetail.LocationID);
            return View(transferDetail);
        }

        // GET: TransferDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferDetail transferDetail = db.TransferDetail.Find(id);
            if (transferDetail == null)
            {
                return HttpNotFound();
            }
            return View(transferDetail);
        }

        // POST: TransferDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransferDetail transferDetail = db.TransferDetail.Find(id);
            db.TransferDetail.Remove(transferDetail);
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
