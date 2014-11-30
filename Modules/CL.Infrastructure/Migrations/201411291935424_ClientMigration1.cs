namespace CL.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "Active");
        }
    }
}
