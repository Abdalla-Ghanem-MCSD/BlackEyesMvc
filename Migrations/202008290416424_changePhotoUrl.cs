namespace BlackEyesMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePhotoUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "PhotoUrl", c => c.String());
            DropColumn("dbo.Brands", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brands", "Photo", c => c.String());
            DropColumn("dbo.Brands", "PhotoUrl");
        }
    }
}
