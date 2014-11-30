namespace CL.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "SourceCard", c => c.Guid());
            AlterColumn("dbo.Transactions", "DestinationCard", c => c.Guid());
            AlterColumn("dbo.Transactions", "SourceTransaction", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "SourceTransaction", c => c.String());
            AlterColumn("dbo.Transactions", "DestinationCard", c => c.String());
            AlterColumn("dbo.Transactions", "SourceCard", c => c.String());
        }
    }
}
