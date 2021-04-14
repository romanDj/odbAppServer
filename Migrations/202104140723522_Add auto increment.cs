namespace gasDiesel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addautoincrement : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LiveMetric");
            DropPrimaryKey("dbo.Location");
            AlterColumn("dbo.LiveMetric", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Location", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.LiveMetric", "Id");
            AddPrimaryKey("dbo.Location", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Location");
            DropPrimaryKey("dbo.LiveMetric");
            AlterColumn("dbo.Location", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.LiveMetric", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Location", "Id");
            AddPrimaryKey("dbo.LiveMetric", "Id");
        }
    }
}
