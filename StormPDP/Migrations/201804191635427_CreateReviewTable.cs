namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateReviewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        JobKnowledge = c.Int(nullable: false),
                        WorkQuality = c.Int(nullable: false),
                        Attendance = c.Int(nullable: false),
                        Initiative = c.Int(nullable: false),
                        Communication = c.Int(nullable: false),
                        Dependability = c.Int(nullable: false),
                        OverallRating = c.Int(nullable: false),
                        Comment = c.String(),
                        JobKnowledgeComment = c.String(),
                        WorkQualityComment = c.String(),
                        AttendanceComment = c.String(),
                        InitiativeComment = c.String(),
                        CommunicationComment = c.String(),
                        DependabilityComment = c.String(),
                        OverallRatingComment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Reviews", new[] { "EmployeeId" });
            DropTable("dbo.Reviews");
        }
    }
}
