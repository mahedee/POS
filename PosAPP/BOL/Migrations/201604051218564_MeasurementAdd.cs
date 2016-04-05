namespace BOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeasurementAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Measurement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Measurement");
        }
    }
}
