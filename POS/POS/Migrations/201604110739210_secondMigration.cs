namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        PRate = c.Double(nullable: false),
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
                .ForeignKey("dbo.Purchase", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.PurchaseId)
                .Index(t => t.ProductId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(nullable: false, maxLength: 100, unicode: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        SupplierId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, unicode: false),
                        Mobile = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Supplier", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchase");
            DropForeignKey("dbo.Purchase", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Product");
            DropForeignKey("dbo.PurchaseDetails", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Supplier", new[] { "CreatedBy" });
            DropIndex("dbo.Purchase", new[] { "CreatedBy" });
            DropIndex("dbo.Purchase", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseDetails", new[] { "CreatedBy" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropTable("dbo.Supplier");
            DropTable("dbo.Purchase");
            DropTable("dbo.PurchaseDetails");
        }
    }
}
