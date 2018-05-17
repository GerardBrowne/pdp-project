namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sync6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reviews", "OverallRatingComment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "OverallRatingComment", c => c.String());
        }
    }
}
