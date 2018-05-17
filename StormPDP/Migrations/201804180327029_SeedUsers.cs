namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'04e26ad9-aaf4-4fac-a6b1-5974774a5343', N'admin@pdp.com', 0, N'AA7uMDayL0NIwfD16vrFsOxQP7tmHuJcRUjBw+8OF2YXLz2jrXJffnbHeo6kLzZ+yQ==', N'7d65b475-2457-40f4-ac23-5d33aa11da4c', NULL, 0, 0, NULL, 1, 0, N'admin@pdp.com')
                  
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c1d3f179-0d1d-4531-a19d-98d40efa5864', N'CanManagePlans')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'04e26ad9-aaf4-4fac-a6b1-5974774a5343', N'c1d3f179-0d1d-4531-a19d-98d40efa5864')

            ");
        }
    }
}
