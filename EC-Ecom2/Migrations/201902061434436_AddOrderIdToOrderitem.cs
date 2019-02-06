namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderIdToOrderitem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orderitems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Orderitems", new[] { "Order_Id" });
            RenameColumn(table: "dbo.Orderitems", name: "Order_Id", newName: "OrderId");
            AlterColumn("dbo.Orderitems", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orderitems", "OrderId");
            AddForeignKey("dbo.Orderitems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orderitems", "OrderId", "dbo.Orders");
            DropIndex("dbo.Orderitems", new[] { "OrderId" });
            AlterColumn("dbo.Orderitems", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.Orderitems", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.Orderitems", "Order_Id");
            AddForeignKey("dbo.Orderitems", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
