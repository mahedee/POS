namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Supplier", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Supplier", "Mobile", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Supplier", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Supplier", "Address", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Supplier", "Address", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Supplier", "Email", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Supplier", "Mobile", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Supplier", "Name", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
