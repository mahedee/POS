namespace BOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrandTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblBrand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tblShop", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Measurement", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblProduct", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblProduct", "Brand_Id", c => c.Int());
            AlterColumn("dbo.Measurement", "Name", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.tblProduct", "Name", c => c.String(nullable: false, maxLength: 150, unicode: false));
            CreateIndex("dbo.tblProduct", "Brand_Id");
            AddForeignKey("dbo.tblProduct", "Brand_Id", "dbo.tblBrand", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProduct", "Brand_Id", "dbo.tblBrand");
            DropIndex("dbo.tblProduct", new[] { "Brand_Id" });
            AlterColumn("dbo.tblProduct", "Name", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.Measurement", "Name", c => c.String(maxLength: 200, unicode: false));
            DropColumn("dbo.tblProduct", "Brand_Id");
            DropColumn("dbo.tblProduct", "ModifiedDate");
            DropColumn("dbo.Measurement", "ModifiedDate");
            DropColumn("dbo.tblShop", "ModifiedDate");
            DropTable("dbo.tblBrand");
        }
    }
}
