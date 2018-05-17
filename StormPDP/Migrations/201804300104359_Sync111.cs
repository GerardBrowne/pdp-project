namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sync111 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "JobKnowledge", c => c.Int());
            AlterColumn("dbo.Reviews", "WorkQuality", c => c.Int());
            AlterColumn("dbo.Reviews", "Attendance", c => c.Int());
            AlterColumn("dbo.Reviews", "Initiative", c => c.Int());
            AlterColumn("dbo.Reviews", "Communication", c => c.Int());
            AlterColumn("dbo.Reviews", "Dependability", c => c.Int());
            AlterColumn("dbo.Reviews", "OverallRating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "OverallRating", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "Dependability", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "Communication", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "Initiative", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "Attendance", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "WorkQuality", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "JobKnowledge", c => c.Int(nullable: false));
        }
    }
}
