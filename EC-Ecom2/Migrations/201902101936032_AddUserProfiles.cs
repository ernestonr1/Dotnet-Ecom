namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        City = c.String(),
                        Streetaddress = c.String(),
                        Postalcode = c.String(),
                        Phonenumber = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "ProfileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "ProfileId");
            DropTable("dbo.UserProfiles");
        }
    }
}
