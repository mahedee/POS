namespace BOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblProduct", "Brand_Id", "dbo.tblBrand");
            DropForeignKey("dbo.tblProduct", "Category_Id", "dbo.tblCategory");
            DropIndex("dbo.tblProduct", new[] { "Brand_Id" });
            DropIndex("dbo.tblProduct", new[] { "Category_Id" });
            RenameColumn(table: "dbo.tblProduct", name: "Brand_Id", newName: "BrandId");
            RenameColumn(table: "dbo.tblProduct", name: "Category_Id", newName: "CatId");
            AlterColumn("dbo.tblProduct", "BrandId", c => c.Int(nullable: false));
            AlterColumn("dbo.tblProduct", "CatId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblProduct", "CatId");
            CreateIndex("dbo.tblProduct", "BrandId");
            AddForeignKey("dbo.tblProduct", "BrandId", "dbo.tblBrand", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tblProduct", "CatId", "dbo.tblCategory", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProduct", "CatId", "dbo.tblCategory");
            DropForeignKey("dbo.tblProduct", "BrandId", "dbo.tblBrand");
            DropIndex("dbo.tblProduct", new[] { "BrandId" });
            DropIndex("dbo.tblProduct", new[] { "CatId" });
            AlterColumn("dbo.tblProduct", "CatId", c => c.Int());
            AlterColumn("dbo.tblProduct", "BrandId", c => c.Int());
            RenameColumn(table: "dbo.tblProduct", name: "CatId", newName: "Category_Id");
            RenameColumn(table: "dbo.tblProduct", name: "BrandId", newName: "Brand_Id");
            CreateIndex("dbo.tblProduct", "Category_Id");
            CreateIndex("dbo.tblProduct", "Brand_Id");
            AddForeignKey("dbo.tblProduct", "Category_Id", "dbo.tblCategory", "Id");
            AddForeignKey("dbo.tblProduct", "Brand_Id", "dbo.tblBrand", "Id");
        }
    }
}
