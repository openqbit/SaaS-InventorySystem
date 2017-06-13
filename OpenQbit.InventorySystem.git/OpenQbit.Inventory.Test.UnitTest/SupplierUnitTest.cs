using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQbit.Inventory.Common.Models;
using OpenQbit.Inventory.DAL.DataAccess;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace OpenQbit.Inventory.Test.UnitTest
{
    [TestClass]
    public class SupplierUnitTest
    {
        [TestMethod]
        public void SupplierInsertTest()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Supplier newSupplier = new Supplier {name = "Dhanapala",address = "Galle Road,Kaluwella",company = "Harishchandra",telephone = "077-1234567"};
            db.Supplier.Add(newSupplier);
            db.SaveChanges();

            Supplier findSupplier = db.Supplier.Where(C => C.name == "Dhanapala").FirstOrDefault();
            Assert.AreEqual(newSupplier.name, findSupplier.name);

            //if(findSupplier != null)
           // {
             //   db.Supplier.Remove(findSupplier);
            //}

        }

        [TestMethod]
        public bool SupplierUpdate(int id, Supplier supplier)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Supplier newSupplier = db.Supplier.Find(id);
            if (newSupplier == null)
            {
                return false;
            }
            db.Entry(newSupplier).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public bool SupplierDelete(int id)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();

            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return false;
            }
            db.Supplier.Remove(supplier);
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public List<Supplier> SupplierView()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            List<Supplier> supplierList = db.Supplier.ToList();
            return supplierList;
        }

    }
}
