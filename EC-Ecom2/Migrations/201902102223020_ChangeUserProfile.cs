namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserProfile : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            DropColumn("dbo.UserProfiles", "ApplicationUserId");
            RenameColumn(table: "dbo.UserProfiles", name: "User_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.UserProfiles", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserProfiles", "ApplicationUserId");
            DropColumn("dbo.UserProfiles", "Streetaddress");
            DropColumn("dbo.UserProfiles", "Postalcode");
            DropColumn("dbo.UserProfiles", "Phonenumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Phonenumber", c => c.String());
            AddColumn("dbo.UserProfiles", "Postalcode", c => c.String());
            AddColumn("dbo.UserProfiles", "Streetaddress", c => c.String());
            DropIndex("dbo.UserProfiles", new[] { "ApplicationUserId" });
            AlterColumn("dbo.UserProfiles", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.UserProfiles", name: "ApplicationUserId", newName: "User_Id");
            AddColumn("dbo.UserProfiles", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserProfiles", "User_Id");
        }
    }
}
