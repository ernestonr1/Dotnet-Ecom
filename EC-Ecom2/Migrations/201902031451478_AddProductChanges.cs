namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.Cart_Id);
            
            AddColumn("dbo.Cartitems", "CartViewModel_Id", c => c.Int());
            CreateIndex("dbo.Cartitems", "CartViewModel_Id");
            AddForeignKey("dbo.Cartitems", "CartViewModel_Id", "dbo.CartViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cartitems", "CartViewModel_Id", "dbo.CartViewModels");
            DropForeignKey("dbo.CartViewModels", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.CartViewModels", new[] { "Cart_Id" });
            DropIndex("dbo.Cartitems", new[] { "CartViewModel_Id" });
            DropColumn("dbo.Cartitems", "CartViewModel_Id");
            DropTable("dbo.CartViewModels");
        }
    }
}
