namespace prypo3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fants", "Photo", c => c.String());
            AddColumn("dbo.Fants", "Proof", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fants", "Proof");
            DropColumn("dbo.Fants", "Photo");
        }
    }
}
