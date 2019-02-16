namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingProducts : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Products] ON");
            Sql("INSERT INTO[dbo].[Products] ([Id], [Name], [Description], [Price], [MainImageUrl]) VALUES(6, N'Yellow jacket', N'Nice spring jacket', 3000, N'content/images/jacka-300x300.jpg')");
            Sql("INSERT INTO[dbo].[Products] ([Id], [Name], [Description], [Price], [MainImageUrl]) VALUES(7, N'Blue shoes', N'Nice shoes for walking in the park', 1000, N'content/images/jacka-300x300.jpg')");
            Sql("INSERT INTO[dbo].[Products] ([Id], [Name], [Description], [Price], [MainImageUrl]) VALUES(8, N'Skirt', N'Nice short skirt', 2500, N'content/images/jacka-300x300.jpg')");
            Sql("INSERT INTO[dbo].[Products] ([Id], [Name], [Description], [Price], [MainImageUrl]) VALUES(9, N'Black pants', N'Very black pants', 8, N'content/images/jacka-300x300.jpg')");
            Sql("INSERT INTO[dbo].[Products] ([Id], [Name], [Description], [Price], [MainImageUrl]) VALUES(10, N'Hoodie', N'Nice hoodie', 400, N'content/images/jacka-300x300.jpg')");
            Sql("SET IDENTITY_INSERT [dbo].[Products] OFF");
        }

        public override void Down()
        {
        }
    }
}
