namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sync8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
