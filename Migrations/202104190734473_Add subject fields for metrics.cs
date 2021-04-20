namespace gasDiesel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addsubjectfieldsformetrics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LiveMetric", "Subject", c => c.String(maxLength: 70));
            AddColumn("dbo.Location", "Subject", c => c.String(maxLength: 70));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Location", "Subject");
            DropColumn("dbo.LiveMetric", "Subject");
        }
    }
}
