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
    public class DamageUnitTest
    {
        [TestMethod]
        public void DamageInsertTest()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Damage newDamage = new Damage { Description = "when storing", Qty = 50, BatchID = 1 };

            newDamage.Batch = new Batch { ID = 1, Date = DateTime.Today, Qty = 50, UnitPrice = 42.00, ItemID = 1, SupplierID = 1 };
            db.Damage.Add(newDamage);
            db.SaveChanges();

            Item findItem = db.Item.Where(C => C.Name == "Dhal").FirstOrDefault();
            Assert.AreEqual(newDamage.Batch.Item.Name, findItem.Name);

            //if(findDamage != null)
            //{
            //    db.Damage.Remove(findDamage);
            //}

        }

        [TestMethod]
        public bool DamageUpdate(int id, Damage damage)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            Damage newDamage = db.Damage.Find(id);
            if (newDamage == null)
            {
                return false;
            }
            db.Entry(newDamage).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public bool DamageDelete(int id)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();

            Damage damage = db.Damage.Find(id);
            if (damage == null)
            {
                return false;
            }
            db.Damage.Remove(damage);
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public List<Damage> DamageView()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            List<Damage> damageList = db.Damage.ToList();
            return damageList;
        }
    }
}
