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
    public class ItemUnitTest
    {
        [TestMethod]
        public void ItemInsertTest()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Item newItem = new Item {  Name = "TestItem", Active = true, reOrder = 10 };

            db.Item.Add(newItem);
            db.SaveChanges();

            Item findItem = db.Item.Where(C => C.Name == "TestItem").FirstOrDefault();
            Assert.AreEqual(newItem.Name, findItem.Name);

            //db.Item.Remove(findItem);

            //if(findBatch != null)
            //{
              //  db.Batch.Remove(findBatch);
            //}

        }

        [TestMethod]
        public bool ItemUpdate(int id, Item item)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Item newItem = db.Item.Find(id);
            if (newItem == null)
            {
                return false;
            }
            db.Entry(newItem).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public bool ItemDelete(int id)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();

            Item item = db.Item.Find(id);
            if(item == null)
            {
                return false;
            }
            db.Item.Remove(item);
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public List<Item> ItemView()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            List<Item> itemList = db.Item.ToList();
            return itemList;
        }
    }
}
