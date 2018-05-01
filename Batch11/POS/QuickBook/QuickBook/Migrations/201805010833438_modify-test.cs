namespace QuickBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytest : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AdminInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdminInfoes",
                c => new
                    {
                        SerialNo = c.String(nullable: false, maxLength: 128),
                        CompanyCode = c.String(),
                        CompanyName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.SerialNo);
            
        }
    }
}
