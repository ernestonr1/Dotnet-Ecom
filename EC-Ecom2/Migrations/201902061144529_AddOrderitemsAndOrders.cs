namespace EC_Ecom2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderitemsAndOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orderitems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderitemTotal = c.Double(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        State = c.String(),
                        SessionId = c.String(),
                        UserId = c.String(),
                        Streetaddress = c.String(),
                        ShippingCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orderitems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Orderitems", new[] { "Order_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.Orderitems");
        }
    }
}
