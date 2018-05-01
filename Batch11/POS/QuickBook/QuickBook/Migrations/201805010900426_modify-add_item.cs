namespace QuickBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyadd_item : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemMasters",
                c => new
                    {
                        ItemSrl = c.Int(nullable: false, identity: true),
                        ItemNo = c.Int(nullable: false),
                        ItemName = c.String(),
                        ItemType = c.String(),
                    })
                .PrimaryKey(t => t.ItemSrl);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemMasters");
        }
    }
}
