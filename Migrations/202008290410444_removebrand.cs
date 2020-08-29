namespace BlackEyesMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removebrand : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductBrands", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.ProductBrands", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductBrands", new[] { "ProductId" });
            DropIndex("dbo.ProductBrands", new[] { "BrandId" });
            AddColumn("dbo.Brands", "Product_Id", c => c.Int());
            AddColumn("dbo.Products", "brandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Brands", "Product_Id");
            AddForeignKey("dbo.Brands", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Brands", "productId");
            DropColumn("dbo.Brands", "ImagePath");
            DropTable("dbo.ProductBrands");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductBrands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Brands", "ImagePath", c => c.String());
            AddColumn("dbo.Brands", "productId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Brands", "Product_Id", "dbo.Products");
            DropIndex("dbo.Brands", new[] { "Product_Id" });
            DropColumn("dbo.Products", "brandId");
            DropColumn("dbo.Brands", "Product_Id");
            CreateIndex("dbo.ProductBrands", "BrandId");
            CreateIndex("dbo.ProductBrands", "ProductId");
            AddForeignKey("dbo.ProductBrands", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductBrands", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
        }
    }
}
