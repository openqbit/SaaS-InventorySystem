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
    public class TransferDetailUnitTest
    {
        [TestMethod]
        public void TransferDetailInsertTest()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            TransferDetail newTransferDetail = new TransferDetail {ID = 1, BatchID = 1, LocationID = 1, DistributerID = 1};

            newTransferDetail.Batch = new Batch {Date = DateTime.Today, Qty = 50, UnitPrice = 42.00, ItemID = 1, SupplierID = 1 };
            newTransferDetail.Location = new Location { ID = 1, Name = "Branch" };
            newTransferDetail.Distributer = new Distributer { ID = 1, Name = "Lasantha", Telephone = "0717896543" };

            db.TransferDetail.Add(newTransferDetail);
            db.SaveChanges();

            Distributer findDistributer = db.Distributer.Where(C => C.Name == "Lasantha").FirstOrDefault();
            Assert.AreEqual(newTransferDetail.Distributer.Name, findDistributer.Name);

            //if(findTransferDetail != null)
            //{
             //   db.TransferDetail.Remove(findTransferDetail);
            //}

        }

        [TestMethod]
        public bool TransferDetailUpdate(int id, TransferDetail transferDetail)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            TransferDetail newTransferDetail = db.TransferDetail.Find(id);
            if (newTransferDetail == null)
            {
                return false;
            }
            db.Entry(newTransferDetail).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public bool TransferDetailDelete(int id)
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();

            TransferDetail transferDetail = db.TransferDetail.Find(id);
            if (transferDetail == null)
            {
                return false;
            }
            db.TransferDetail.Remove(transferDetail);
            db.SaveChanges();
            return true;
        }

        [TestMethod]
        public List<TransferDetail> TransferDetailView()
        {
            OpenQbitInventoryContext db = new OpenQbitInventoryContext();
            List<TransferDetail> transferDetailList = db.TransferDetail.ToList();
            return transferDetailList;
        }

    }
}
