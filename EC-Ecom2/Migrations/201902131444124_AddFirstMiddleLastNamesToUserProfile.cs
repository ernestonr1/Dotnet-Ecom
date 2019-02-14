namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstMiddleLastNamesToUserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Firstname", c => c.String());
            AddColumn("dbo.UserProfiles", "Lastname", c => c.String());
            AddColumn("dbo.UserProfiles", "Middlename", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Middlename");
            DropColumn("dbo.UserProfiles", "Lastname");
            DropColumn("dbo.UserProfiles", "Firstname");
        }
    }
}
