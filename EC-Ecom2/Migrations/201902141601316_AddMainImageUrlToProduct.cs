namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMainImageUrlToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "MainImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "MainImageUrl");
        }
    }
}
