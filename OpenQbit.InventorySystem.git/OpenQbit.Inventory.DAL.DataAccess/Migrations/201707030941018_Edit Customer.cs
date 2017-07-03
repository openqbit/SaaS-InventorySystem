namespace OpenQbit.Inventory.DAL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Batch", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Damage", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Return", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Supplier", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.TransferDetail", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Distributer", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Location", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Batch", "CustomerID");
            CreateIndex("dbo.Damage", "CustomerID");
            CreateIndex("dbo.Distributer", "CustomerID");
            CreateIndex("dbo.TransferDetail", "CustomerID");
            CreateIndex("dbo.Location", "CustomerID");
            CreateIndex("dbo.Item", "CustomerID");
            CreateIndex("dbo.Return", "CustomerID");
            CreateIndex("dbo.Supplier", "CustomerID");
            AddForeignKey("dbo.Batch", "CustomerID", "dbo.Customer", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Damage", "CustomerID", "dbo.Customer", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Distributer", "CustomerID", "dbo.Customer", "ID", cascadeDelete: false);
            AddForeignKey("dbo.TransferDetail", "CustomerID", "dbo.Customer", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Location", "CustomerID", "dbo.Customer", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Item", "CustomerID", "dbo.Customer", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Return", "CustomerID", "dbo.Customer", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Supplier", "CustomerID", "dbo.Customer", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supplier", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Return", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Item", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Location", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.TransferDetail", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Distributer", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Damage", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Batch", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Supplier", new[] { "CustomerID" });
            DropIndex("dbo.Return", new[] { "CustomerID" });
            DropIndex("dbo.Item", new[] { "CustomerID" });
            DropIndex("dbo.Location", new[] { "CustomerID" });
            DropIndex("dbo.TransferDetail", new[] { "CustomerID" });
            DropIndex("dbo.Distributer", new[] { "CustomerID" });
            DropIndex("dbo.Damage", new[] { "CustomerID" });
            DropIndex("dbo.Batch", new[] { "CustomerID" });
            DropColumn("dbo.Location", "CustomerID");
            DropColumn("dbo.Distributer", "CustomerID");
            DropColumn("dbo.TransferDetail", "CustomerID");
            DropColumn("dbo.Supplier", "CustomerID");
            DropColumn("dbo.Return", "CustomerID");
            DropColumn("dbo.Item", "CustomerID");
            DropColumn("dbo.Damage", "CustomerID");
            DropColumn("dbo.Batch", "CustomerID");
            DropTable("dbo.Customer");
        }
    }
}
