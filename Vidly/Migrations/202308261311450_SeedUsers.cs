namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'41124139-dec9-4f75-86d9-7fcc39690e72', N'guest@vidly.com', 1, N'AHL49MFS/hi5o6KpsXtpVBlHs3gSyRbQ7Tp0p1S9+hbd59/FKOOJMZ+04+Cc7Ib1mg==', N'223236d4-c286-44dc-917d-b2120e19686c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ed3b5dd2-c87e-4429-a3e9-8c1d3f2b4b9c', N'admin@vidly.com', 1, N'AEnhvYost5nZI9MG1lQLQtWX7uAVSBQ/Wqa70VSsGUp8NIg5AYXQxUVh93PVP+Rcbg==', N'1967b09f-79f4-47ef-b4ea-856d70d3eec9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3dccd397-803f-4f31-8dbd-5e4938181daf', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ed3b5dd2-c87e-4429-a3e9-8c1d3f2b4b9c', N'3dccd397-803f-4f31-8dbd-5e4938181daf')
            
            ");
        }
        
        public override void Down()
        {
        }
    }
}
