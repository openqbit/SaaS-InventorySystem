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
    public class BatchUnitTest
    {
        [TestMethod]
        public void BatchInsertTest()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Batch newBatch = new Batch {Date = DateTime.Today, Qty = 50, UnitPrice = 42.00, ItemID = 1, SupplierID = 1 };

            newBatch.Item = new Item { ID = 1, Name = "Dhal", Active = true, reOrder = 10 };
            newBatch.Supplier = new Supplier { ID = 1, name = "Dhanapala", address = "Galle Road,Kaluwella", company = "Harishchandra", telephone = "077-1234567" };

            db.Batch.Add(newBatch);
            db.SaveChanges();

            Item findItem = db.Item.Where(C => C.Name == "Dhal").FirstOrDefault();
            Assert.AreEqual(newBatch.Item.Name, findItem.Name);

            //if(findBatch != null)
            //{
              //  db.Batch.Remove(findBatch);
            //}

        }

        [TestMethod]
        public bool BatchUpdate(int id, Batch batch)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Batch newBatch = db.Batch.Find(id);
            if (newBatch == null)
            {
                return false;
            }
            db.Entry(newBatch).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public bool BatchDelete(int id)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();

            Batch batch = db.Batch.Find(id);
            if (batch == null)
            {
                return false;
            }
            db.Batch.Remove(batch);
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public List<Batch> BatchView()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            List<Batch> batchList = db.Batch.ToList();
            return batchList;
        }

    }
}
