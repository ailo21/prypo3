namespace prypo3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fants", "Publish", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fants", "Publish");
        }
    }
}
