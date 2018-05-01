namespace QuickBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyadd_com : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyInfoes",
                c => new
                    {
                        SerialNo = c.Int(nullable: false, identity: true),
                        CompanyNo = c.String(),
                        CompanyName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.SerialNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompanyInfoes");
        }
    }
}
