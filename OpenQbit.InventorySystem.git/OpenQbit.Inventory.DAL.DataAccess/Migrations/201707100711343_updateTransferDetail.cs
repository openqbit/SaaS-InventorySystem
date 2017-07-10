namespace OpenQbit.Inventory.DAL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTransferDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransferDetail", "qty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransferDetail", "qty");
        }
    }
}
