namespace BOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 300, unicode: false),
                        Stock = c.Int(nullable: false),
                        BarCode = c.String(maxLength: 200, unicode: false),
                        ShopId = c.Int(nullable: false),
                        MeasurementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Measurement", t => t.MeasurementId, cascadeDelete: true)
                .ForeignKey("dbo.tblShop", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId)
                .Index(t => t.MeasurementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProduct", "ShopId", "dbo.tblShop");
            DropForeignKey("dbo.tblProduct", "MeasurementId", "dbo.Measurement");
            DropIndex("dbo.tblProduct", new[] { "MeasurementId" });
            DropIndex("dbo.tblProduct", new[] { "ShopId" });
            DropTable("dbo.tblProduct");
        }
    }
}
