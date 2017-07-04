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
    public class DistributerController : Controller
    {
        private OpenQbitInventoryContext db = new OpenQbitInventoryContext();

        // GET: Distributer
        public ActionResult Index()
        {
            var distributer = db.Distributer.Include(d => d.customer);
            return View(distributer.ToList());
        }

        // GET: Distributer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distributer distributer = db.Distributer.Find(id);
            if (distributer == null)
            {
                return HttpNotFound();
            }
            return View(distributer);
        }

        // GET: Distributer/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        // POST: Distributer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Telephone,CustomerID")] Distributer distributer)
        {
            if (ModelState.IsValid)
            {
                db.Distributer.Add(distributer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", distributer.CustomerID);
            return View(distributer);
        }

        // GET: Distributer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distributer distributer = db.Distributer.Find(id);
            if (distributer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", distributer.CustomerID);
            return View(distributer);
        }

        // POST: Distributer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Telephone,CustomerID")] Distributer distributer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distributer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", distributer.CustomerID);
            return View(distributer);
        }

        // GET: Distributer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distributer distributer = db.Distributer.Find(id);
            if (distributer == null)
            {
                return HttpNotFound();
            }
            return View(distributer);
        }

        // POST: Distributer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distributer distributer = db.Distributer.Find(id);
            db.Distributer.Remove(distributer);
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
