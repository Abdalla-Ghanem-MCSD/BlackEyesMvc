namespace BlackEyesMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class register1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Registers", "ConfirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registers", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Registers", "Password", c => c.String());
        }
    }
}
