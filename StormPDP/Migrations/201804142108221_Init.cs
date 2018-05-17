namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevelopmentPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        QuarterlyReviewDate = c.DateTime(),
                        AnnualReviewDate = c.DateTime(),
                        CurrentRole = c.String(),
                        Function = c.String(),
                        CurrentCertification = c.String(),
                        Ambition = c.String(),
                        Comment = c.String(),
                        StormHelp = c.String(),
                        EmployeeComment = c.String(),
                        ManagerComment = c.String(),
                        EmployeeRating = c.Int(),
                        ManagerRating = c.Int(),
                        AgreedRating = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StormId = c.Int(),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(),
                        Position = c.String(),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.EmployeeSkills",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                        IsTechnical = c.Boolean(nullable: false),
                        IsCurrent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.SkillId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StormId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Objectives",
                c => new
                    {
                        ObjectiveId = c.Int(nullable: false, identity: true),
                        DevelopmentPlanId = c.Int(nullable: false),
                        Name = c.String(),
                        Competency = c.Int(),
                        Timing = c.DateTime(),
                        IsAchieved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectiveId)
                .ForeignKey("dbo.DevelopmentPlans", t => t.DevelopmentPlanId, cascadeDelete: true)
                .Index(t => t.DevelopmentPlanId);
            
            CreateTable(
                "dbo.TrainingPlans",
                c => new
                    {
                        TrainingId = c.Int(nullable: false, identity: true),
                        DevelopmentPlanId = c.Int(nullable: false),
                        Name = c.String(),
                        Competency = c.Int(),
                        Timing = c.DateTime(),
                        Opportunity = c.String(),
                    })
                .PrimaryKey(t => t.TrainingId)
                .ForeignKey("dbo.DevelopmentPlans", t => t.DevelopmentPlanId, cascadeDelete: true)
                .Index(t => t.DevelopmentPlanId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TrainingPlans", "DevelopmentPlanId", "dbo.DevelopmentPlans");
            DropForeignKey("dbo.Objectives", "DevelopmentPlanId", "dbo.DevelopmentPlans");
            DropForeignKey("dbo.DevelopmentPlans", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.EmployeeSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.EmployeeSkills", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TrainingPlans", new[] { "DevelopmentPlanId" });
            DropIndex("dbo.Objectives", new[] { "DevelopmentPlanId" });
            DropIndex("dbo.EmployeeSkills", new[] { "SkillId" });
            DropIndex("dbo.EmployeeSkills", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "ManagerId" });
            DropIndex("dbo.DevelopmentPlans", new[] { "EmployeeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TrainingPlans");
            DropTable("dbo.Objectives");
            DropTable("dbo.Managers");
            DropTable("dbo.Skills");
            DropTable("dbo.EmployeeSkills");
            DropTable("dbo.Employees");
            DropTable("dbo.DevelopmentPlans");
        }
    }
}
