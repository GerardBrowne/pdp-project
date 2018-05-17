namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0ca36ee7-8f45-4e57-adb8-519f059e7158', N'guest@pdp.com', 0, N'ACVqjHEh/449FEuhXCjPrwhXkGtf6ZqSMkdYRc7WLPSoTimeVvcWaIai2cIRDcJXQQ==', N'434e4065-9c48-439a-aca2-e367b53b24e9', NULL, 0, 0, NULL, 1, 0, N'guest@pdp.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'14877eb5-b6ca-46bb-98d6-c1692c8f1e06', N'admin@pdp.com', 0, N'AEt+M8YPkbUBfvsb/Jc5CUTCX6dZUG988gs4xIT9LZq39c6thK1XirmkfirxZGzEvA==', N'd777a4a3-fab9-4fcf-b0d0-1d81f5b86cf0', NULL, 0, 0, NULL, 1, 0, N'admin@pdp.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c2a23a88-10a3-4849-995c-979acbfa39ee', N'CanAccessAll')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14877eb5-b6ca-46bb-98d6-c1692c8f1e06', N'c2a23a88-10a3-4849-995c-979acbfa39ee')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
