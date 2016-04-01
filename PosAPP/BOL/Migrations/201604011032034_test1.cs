namespace BOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
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
                        CatId = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblBrand", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.tblCategory", t => t.CatId, cascadeDelete: true)
                .ForeignKey("dbo.tblShop", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.CatId)
                .Index(t => t.ShopId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.tblBrand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblShop",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, unicode: false),
                        Address = c.String(maxLength: 200, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        WebAddress = c.String(maxLength: 100, unicode: false),
                        Phone = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblFinancialYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartingDate = c.DateTime(nullable: false),
                        EndingDate = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblShop", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProduct", "ShopId", "dbo.tblShop");
            DropForeignKey("dbo.tblFinancialYear", "ShopId", "dbo.tblShop");
            DropForeignKey("dbo.tblProduct", "CatId", "dbo.tblCategory");
            DropForeignKey("dbo.tblProduct", "BrandId", "dbo.tblBrand");
            DropIndex("dbo.tblFinancialYear", new[] { "ShopId" });
            DropIndex("dbo.tblProduct", new[] { "BrandId" });
            DropIndex("dbo.tblProduct", new[] { "ShopId" });
            DropIndex("dbo.tblProduct", new[] { "CatId" });
            DropTable("dbo.tblFinancialYear");
            DropTable("dbo.tblShop");
            DropTable("dbo.tblCategory");
            DropTable("dbo.tblBrand");
            DropTable("dbo.tblProduct");
        }
    }
}
