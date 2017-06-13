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
    public class DistributerUnitTest
    {
        [TestMethod]
        public void DistributerInsertTest()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Distributer newDistributer = new Distributer {Name = "Lasantha", Telephone = "0717896543" };
            db.Distributer.Add(newDistributer);
            db.SaveChanges();

            Distributer findDistributer = db.Distributer.Where(C => C.Name == "Lasantha").FirstOrDefault();
            Assert.AreEqual(newDistributer.Name, findDistributer.Name);

           // if(findDistributer != null)
            //{
            //    db.Distributer.Remove(findDistributer);
            //}

        }

        [TestMethod]
        public bool DistributerUpdate(int id, Distributer distributer)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();

            Distributer newDistributer = db.Distributer.Find(id);
            if(newDistributer == null)
            {
                return false;
            }
            db.Entry(newDistributer).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public bool DistributerDelete(int id)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();

            Distributer distributer = db.Distributer.Find(id);
            if (distributer == null)
            {
                return false;
            }
            db.Distributer.Remove(distributer);
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public List<Distributer> DistributerView()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            List<Distributer> distributerList = db.Distributer.ToList();
            return distributerList;
        }
    }
}
