namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FinancialYear", "Name", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FinancialYear", "Name", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
