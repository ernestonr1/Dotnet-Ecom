namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingBackUserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Streetaddress", c => c.String());
            AddColumn("dbo.UserProfiles", "Postalcode", c => c.String());
            AddColumn("dbo.UserProfiles", "Phonenumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Phonenumber");
            DropColumn("dbo.UserProfiles", "Postalcode");
            DropColumn("dbo.UserProfiles", "Streetaddress");
        }
    }
}
