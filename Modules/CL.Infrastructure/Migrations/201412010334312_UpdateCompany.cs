namespace CL.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "GiveBackPercentage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "GiveBackPercentage");
        }
    }
}
