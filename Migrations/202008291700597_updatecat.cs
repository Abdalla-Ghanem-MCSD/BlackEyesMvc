namespace BlackEyesMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecat : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "productId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "productId", c => c.Int(nullable: false));
        }
    }
}
