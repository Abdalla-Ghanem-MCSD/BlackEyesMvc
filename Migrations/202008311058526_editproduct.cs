namespace BlackEyesMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "OrderId", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "OrderId" });
            RenameColumn(table: "dbo.Products", name: "OrderId", newName: "Order_Id");
            AlterColumn("dbo.Products", "Order_Id", c => c.Int());
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            AlterColumn("dbo.Products", "Order_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "Order_Id", newName: "OrderId");
            CreateIndex("dbo.Products", "OrderId");
            AddForeignKey("dbo.Products", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
