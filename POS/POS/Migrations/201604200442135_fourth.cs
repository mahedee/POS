namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseDetails", "ProductName", c => c.String());
            AddColumn("dbo.PurchaseDetails", "BarcodeImage", c => c.Binary());
            AddColumn("dbo.PurchaseDetails", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseDetails", "ImageUrl");
            DropColumn("dbo.PurchaseDetails", "BarcodeImage");
            DropColumn("dbo.PurchaseDetails", "ProductName");
        }
    }
}
