namespace gasDiesel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittypesinlocationtable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Location", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Location", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Location", "Longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Location", "Latitude", c => c.Single(nullable: false));
        }
    }
}
