namespace BOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFinancialYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartingDate = c.DateTime(nullable: false),
                        EndingDate = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
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
                        FinancialYearId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblFinancialYear", t => t.FinancialYearId, cascadeDelete: true)
                .Index(t => t.FinancialYearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblShop", "FinancialYearId", "dbo.tblFinancialYear");
            DropIndex("dbo.tblShop", new[] { "FinancialYearId" });
            DropTable("dbo.tblShop");
            DropTable("dbo.tblFinancialYear");
        }
    }
}
