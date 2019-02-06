namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartIdToCartitem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cartitems", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Cartitems", new[] { "Cart_Id" });
            RenameColumn(table: "dbo.Cartitems", name: "Cart_Id", newName: "CartId");
            AlterColumn("dbo.Cartitems", "CartId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cartitems", "CartId");
            AddForeignKey("dbo.Cartitems", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cartitems", "CartId", "dbo.Carts");
            DropIndex("dbo.Cartitems", new[] { "CartId" });
            AlterColumn("dbo.Cartitems", "CartId", c => c.Int());
            RenameColumn(table: "dbo.Cartitems", name: "CartId", newName: "Cart_Id");
            CreateIndex("dbo.Cartitems", "Cart_Id");
            AddForeignKey("dbo.Cartitems", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
