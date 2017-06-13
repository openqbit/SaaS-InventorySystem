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
    public class LocationUnitTest
    {
        [TestMethod]
        public void LocationInsertTest()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Location newLocation = new Location {Name = "Branch" };
            db.Location.Add(newLocation);
            db.SaveChanges();

            Location findLocation = db.Location.Where(C => C.Name == "Branch").FirstOrDefault();
            Assert.AreEqual(newLocation.Name, findLocation.Name);

           // if(findLocation != null)
           // {
            //    db.Location.Remove(findLocation);
           // }

        }

        [TestMethod]
        public bool LocationUpdate(int id, Location item)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Location newLocation = db.Location.Find(id);
            if (newLocation == null)
            {
                return false;
            }
            db.Entry(newLocation).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public bool LocationDelete(int id)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();

            Location location = db.Location.Find(id);
            if (location == null)
            {
                return false;
            }
            db.Location.Remove(location);
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public List<Location> LocationView()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            List<Location> locationList = db.Location.ToList();
            return locationList;
        }

    }
}
