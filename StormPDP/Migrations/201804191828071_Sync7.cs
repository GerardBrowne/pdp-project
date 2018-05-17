namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sync7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "DateCreated");
        }
    }
}
