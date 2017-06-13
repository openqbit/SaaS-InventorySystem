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
    public class ReturnUnitTest
    {
        [TestMethod]
        public void ReturnInsertTest()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Return newReturn = new Return {Description = "Dates are expired", Qty = 2, BatchID = 1, SupplierID = 1 };

            newReturn.Batch = new Batch { ID = 1, Date = DateTime.Today, Qty = 50, UnitPrice = 42.00, ItemID = 1, SupplierID = 1 };
            newReturn.Supplier = new Supplier { ID = 1, name = "Dhanapala", address = "Galle Road,Kaluwella", company = "Harishchandra", telephone = "077-1234567" };
            db.Return.Add(newReturn);
            db.SaveChanges();

            Supplier findSupplier = db.Supplier.Where(C => C.name == "Dhanapala").FirstOrDefault();
            Assert.AreEqual(newReturn.Supplier.name, findSupplier.name);

            //if(findReturn != null)
           // {
           //     db.Return.Remove(findReturn);
           // }

        }

        [TestMethod]
        public bool ReturnUpdate(int id, Return re)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Return newReturn = db.Return.Find(id);
            if (newReturn == null)
            {
                return false;
            }
            db.Entry(newReturn).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public bool ReturnDelete(int id)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();

            Return re = db.Return.Find(id);
            if (re == null)
            {
                return false;
            }
            db.Return.Remove(re);
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public List<Return> ReturnView()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            List<Return> returnList = db.Return.ToList();
            return returnList;
        }

    }
}
