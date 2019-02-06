namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartAndCartitems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cartitems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        CartitemTotal = c.Double(nullable: false, defaultValue: 0),
                        ProductId = c.Int(nullable: false),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false, defaultValue: 0),
                        State = c.String(),
                        SessionId = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cartitems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Carts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cartitems", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropIndex("dbo.Cartitems", new[] { "Cart_Id" });
            DropIndex("dbo.Cartitems", new[] { "ProductId" });
            DropTable("dbo.Carts");
            DropTable("dbo.Cartitems");
        }
    }
}
