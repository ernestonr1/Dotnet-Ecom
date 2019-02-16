namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ProfileId]) VALUES (N'28287ff7-b064-411f-8e9a-34140efbcbd1', N'ronaldo@ronaldo.se', 0, N'ANh41eaBtiWIIFNSTHFGLnYQHk0v8lCsiUq9qTAkMAA30svw2cW9h7rA5lAa/jmxnQ==', N'9e14e110-16c4-4ab7-8305-f44e5db5b436', NULL, 0, 0, NULL, 1, 0, N'ronaldo@ronaldo.se', 0)");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ProfileId]) VALUES (N'28287ff7-b064-411f-8e9a-34140efbcbd2', N'zlatan@zlatan.se', 0, N'ANh41eaBtiWIIFNSTHFGLnYQHk0v8lCsiUq9qTAkMAA30svw2cW9h7rA5lAa/jmxnQ==', N'9e14e110-16c4-4ab7-8305-f44e5db5b436', NULL, 0, 0, NULL, 1, 0, N'zlatan@zlatan.se', 0)");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ProfileId]) VALUES (N'28287ff7-b064-411f-8e9a-34140efbcbd3', N'lars@lars.se', 0, N'ANh41eaBtiWIIFNSTHFGLnYQHk0v8lCsiUq9qTAkMAA30svw2cW9h7rA5lAa/jmxnQ==', N'9e14e110-16c4-4ab7-8305-f44e5db5b436', NULL, 0, 0, NULL, 1, 0, N'lars@lars.se', 0)");
        }

        public override void Down()
        {
        }
    }
}
