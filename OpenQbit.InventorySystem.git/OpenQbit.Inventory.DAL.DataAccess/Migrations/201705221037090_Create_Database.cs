namespace OpenQbit.Inventory.DAL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Database : DbMigration
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Item", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Supplier", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.ItemID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.Damage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Qty = c.Int(nullable: false),
                        BatchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Batch", t => t.BatchID, cascadeDelete: true)
                .Index(t => t.BatchID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        reOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Return",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Qty = c.Int(nullable: false),
                        BatchID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Batch", t => t.BatchID, cascadeDelete: true)
                .ForeignKey("dbo.Supplier", t => t.SupplierID, cascadeDelete: false)
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
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TransferDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BatchID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DistributerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Batch", t => t.BatchID, cascadeDelete: true)
                .ForeignKey("dbo.Distributer", t => t.DistributerID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.BatchID)
                .Index(t => t.LocationID)
                .Index(t => t.DistributerID);
            
            CreateTable(
                "dbo.Distributer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransferDetail", "LocationID", "dbo.Location");
            DropForeignKey("dbo.TransferDetail", "DistributerID", "dbo.Distributer");
            DropForeignKey("dbo.TransferDetail", "BatchID", "dbo.Batch");
            DropForeignKey("dbo.Return", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Batch", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Return", "BatchID", "dbo.Batch");
            DropForeignKey("dbo.Batch", "ItemID", "dbo.Item");
            DropForeignKey("dbo.Damage", "BatchID", "dbo.Batch");
            DropIndex("dbo.TransferDetail", new[] { "DistributerID" });
            DropIndex("dbo.TransferDetail", new[] { "LocationID" });
            DropIndex("dbo.TransferDetail", new[] { "BatchID" });
            DropIndex("dbo.Return", new[] { "SupplierID" });
            DropIndex("dbo.Return", new[] { "BatchID" });
            DropIndex("dbo.Damage", new[] { "BatchID" });
            DropIndex("dbo.Batch", new[] { "SupplierID" });
            DropIndex("dbo.Batch", new[] { "ItemID" });
            DropTable("dbo.Location");
            DropTable("dbo.Distributer");
            DropTable("dbo.TransferDetail");
            DropTable("dbo.Supplier");
            DropTable("dbo.Return");
            DropTable("dbo.Item");
            DropTable("dbo.Damage");
            DropTable("dbo.Batch");
        }
    }
}
