namespace OpenQbit.Inventory.DAL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batch",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Qty = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        ItemID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: false)
                .ForeignKey("dbo.Item", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Supplier", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.ItemID)
                .Index(t => t.SupplierID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Damage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Qty = c.Int(nullable: false),
                        BatchID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Batch", t => t.BatchID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: false)
                .Index(t => t.BatchID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Distributer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Telephone = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: false)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.TransferDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        BatchID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DistributerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Batch", t => t.BatchID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: false)
                .ForeignKey("dbo.Distributer", t => t.DistributerID, cascadeDelete: false)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.BatchID)
                .Index(t => t.LocationID)
                .Index(t => t.DistributerID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: false)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        reOrder = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: false)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Return",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Qty = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        BatchID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Batch", t => t.BatchID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: false)
                .ForeignKey("dbo.Supplier", t => t.SupplierID, cascadeDelete: false)
                .Index(t => t.CustomerID)
                .Index(t => t.BatchID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        company = c.String(),
                        telephone = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: false)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Return", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Supplier", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Batch", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Return", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Return", "BatchID", "dbo.Batch");
            DropForeignKey("dbo.Item", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Batch", "ItemID", "dbo.Item");
            DropForeignKey("dbo.TransferDetail", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Location", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.TransferDetail", "DistributerID", "dbo.Distributer");
            DropForeignKey("dbo.TransferDetail", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.TransferDetail", "BatchID", "dbo.Batch");
            DropForeignKey("dbo.Distributer", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Damage", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Damage", "BatchID", "dbo.Batch");
            DropForeignKey("dbo.Batch", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Supplier", new[] { "CustomerID" });
            DropIndex("dbo.Return", new[] { "SupplierID" });
            DropIndex("dbo.Return", new[] { "BatchID" });
            DropIndex("dbo.Return", new[] { "CustomerID" });
            DropIndex("dbo.Item", new[] { "CustomerID" });
            DropIndex("dbo.Location", new[] { "CustomerID" });
            DropIndex("dbo.TransferDetail", new[] { "DistributerID" });
            DropIndex("dbo.TransferDetail", new[] { "LocationID" });
            DropIndex("dbo.TransferDetail", new[] { "BatchID" });
            DropIndex("dbo.TransferDetail", new[] { "CustomerID" });
            DropIndex("dbo.Distributer", new[] { "CustomerID" });
            DropIndex("dbo.Damage", new[] { "CustomerID" });
            DropIndex("dbo.Damage", new[] { "BatchID" });
            DropIndex("dbo.Batch", new[] { "CustomerID" });
            DropIndex("dbo.Batch", new[] { "SupplierID" });
            DropIndex("dbo.Batch", new[] { "ItemID" });
            DropTable("dbo.Supplier");
            DropTable("dbo.Return");
            DropTable("dbo.Item");
            DropTable("dbo.Location");
            DropTable("dbo.TransferDetail");
            DropTable("dbo.Distributer");
            DropTable("dbo.Damage");
            DropTable("dbo.Customer");
            DropTable("dbo.Batch");
        }
    }
}
