﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.DAL.DataAccess
{
    class InventoryContext : DbContext
    {
        public InventoryContext() : base("InventoryContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Batch> Batch { get; set; }
        public DbSet<Damage> Damage { get; set; }
        public DbSet<Distributer> Distributer { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Return> Return { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
