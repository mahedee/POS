namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Mobile = c.String(nullable: false, maxLength: 20, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Address = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesInvoiceNo = c.String(nullable: false, maxLength: 100, unicode: false),
                        SalesDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Remarks = c.String(maxLength: 100, unicode: false),
                        Total = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        PercentDiscount = c.Double(nullable: false),
                        GrandTotal = c.Double(nullable: false),
                        DueTotal = c.Double(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.SalesDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        SRate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        PercentVat = c.Double(nullable: false),
                        PercentDiscount = c.Double(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SalesId, cascadeDelete: true)
                .Index(t => t.SalesId)
                .Index(t => t.ProductId)
                .Index(t => t.CreatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesDetail", "SalesId", "dbo.Sales");
            DropForeignKey("dbo.SalesDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.SalesDetail", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Sales", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customer", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.SalesDetail", new[] { "CreatedBy" });
            DropIndex("dbo.SalesDetail", new[] { "ProductId" });
            DropIndex("dbo.SalesDetail", new[] { "SalesId" });
            DropIndex("dbo.Sales", new[] { "CreatedBy" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Customer", new[] { "CreatedBy" });
            DropTable("dbo.SalesDetail");
            DropTable("dbo.Sales");
            DropTable("dbo.Customer");
        }
    }
}
