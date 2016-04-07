namespace BOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tblProduct", "Category_Id", c => c.Int());
            CreateIndex("dbo.tblProduct", "Category_Id");
            AddForeignKey("dbo.tblProduct", "Category_Id", "dbo.tblCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProduct", "Category_Id", "dbo.tblCategory");
            DropIndex("dbo.tblProduct", new[] { "Category_Id" });
            DropColumn("dbo.tblProduct", "Category_Id");
            DropTable("dbo.tblCategory");
        }
    }
}
