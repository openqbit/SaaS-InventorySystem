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
    public class DamageController : Controller
    {
        private OpenQbitInventoryContext db = new OpenQbitInventoryContext();

        // GET: Damage
        public ActionResult Index()
        {
            var damage = db.Damage.Include(d => d.Batch).Include(d => d.customer);
            return View(damage.ToList());
        }

        // GET: Damage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Damage damage = db.Damage.Find(id);
            if (damage == null)
            {
                return HttpNotFound();
            }
            return View(damage);
        }

        // GET: Damage/Create
        public ActionResult Create()
        {
            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        // POST: Damage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Qty,BatchID,CustomerID")] Damage damage)
        {
            if (ModelState.IsValid)
            {
                db.Damage.Add(damage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID", damage.BatchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", damage.CustomerID);
            return View(damage);
        }

        // GET: Damage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Damage damage = db.Damage.Find(id);
            if (damage == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID", damage.BatchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", damage.CustomerID);
            return View(damage);
        }

        // POST: Damage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Qty,BatchID,CustomerID")] Damage damage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(damage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatchID = new SelectList(db.Batch, "ID", "ID", damage.BatchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", damage.CustomerID);
            return View(damage);
        }

        // GET: Damage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Damage damage = db.Damage.Find(id);
            if (damage == null)
            {
                return HttpNotFound();
            }
            return View(damage);
        }

        // POST: Damage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Damage damage = db.Damage.Find(id);
            db.Damage.Remove(damage);
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
