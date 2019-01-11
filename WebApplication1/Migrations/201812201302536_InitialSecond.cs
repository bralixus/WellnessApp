namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSecond : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IdentityServices", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IdentityServices", "Data");
        }
    }
}
