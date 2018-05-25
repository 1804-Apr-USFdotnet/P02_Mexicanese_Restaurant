namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutITBACK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, maxLength: 255),
                        address = c.String(nullable: false, maxLength: 255),
                        city = c.String(nullable: false, maxLength: 255),
                        state = c.String(nullable: false, maxLength: 100),
                        zipcode = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.email, cascadeDelete: true)
                .Index(t => t.email);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 255),
                        Pwd = c.String(nullable: false, maxLength: 255),
                        AccessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.CustomerInformation",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 255),
                        firstName = c.String(maxLength: 100),
                        lastName = c.String(maxLength: 100),
                        phone = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Users", t => t.Email, cascadeDelete: true)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        couponCode = c.String(nullable: false, maxLength: 255),
                        expDate = c.DateTime(nullable: false, storeType: "date"),
                        discountAmount = c.Decimal(nullable: false, precision: 9, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrderCoupons",
                c => new
                    {
                        couponId = c.Int(nullable: false),
                        orderId = c.Int(nullable: false),
                        Order_OrderID = c.Int(),
                        Order_OrderID1 = c.Int(),
                        Order_OrderID2 = c.Int(),
                        Order1_OrderID = c.Int(),
                    })
                .PrimaryKey(t => new { t.couponId, t.orderId })
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID1)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID2)
                .ForeignKey("dbo.Orders", t => t.Order1_OrderID)
                .ForeignKey("dbo.Coupons", t => t.couponId)
                .Index(t => t.couponId)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Order_OrderID1)
                .Index(t => t.Order_OrderID2)
                .Index(t => t.Order1_OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        PaymentID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        itemID = c.Int(nullable: false),
                        orderID = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.itemID, t.orderID })
                .ForeignKey("dbo.MenuItems", t => t.itemID)
                .ForeignKey("dbo.Orders", t => t.orderID, cascadeDelete: true)
                .Index(t => t.itemID)
                .Index(t => t.orderID);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        itemID = c.Int(nullable: false, identity: true),
                        itemName = c.String(nullable: false, maxLength: 255),
                        itemDescription = c.String(maxLength: 1024),
                        itemPrice = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.itemID);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        id = c.Int(nullable: false),
                        email = c.String(nullable: false, maxLength: 255),
                        cardNumber = c.String(nullable: false, maxLength: 100),
                        securityCode = c.String(nullable: false, maxLength: 10),
                        expDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => new { t.id, t.email });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderCoupons", "couponId", "dbo.Coupons");
            DropForeignKey("dbo.OrderCoupons", "Order1_OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderCoupons", "Order_OrderID2", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "orderID", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "itemID", "dbo.MenuItems");
            DropForeignKey("dbo.OrderCoupons", "Order_OrderID1", "dbo.Orders");
            DropForeignKey("dbo.OrderCoupons", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.CustomerInformation", "Email", "dbo.Users");
            DropForeignKey("dbo.Addresses", "email", "dbo.Users");
            DropIndex("dbo.OrderItems", new[] { "orderID" });
            DropIndex("dbo.OrderItems", new[] { "itemID" });
            DropIndex("dbo.OrderCoupons", new[] { "Order1_OrderID" });
            DropIndex("dbo.OrderCoupons", new[] { "Order_OrderID2" });
            DropIndex("dbo.OrderCoupons", new[] { "Order_OrderID1" });
            DropIndex("dbo.OrderCoupons", new[] { "Order_OrderID" });
            DropIndex("dbo.OrderCoupons", new[] { "couponId" });
            DropIndex("dbo.CustomerInformation", new[] { "Email" });
            DropIndex("dbo.Addresses", new[] { "email" });
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.MenuItems");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderCoupons");
            DropTable("dbo.Coupons");
            DropTable("dbo.CustomerInformation");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
