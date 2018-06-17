namespace IEP_Project_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Parametertabletypofix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PortalParameters", "DefaultAuctionsToDisplay", c => c.Long(nullable: false));
            DropColumn("dbo.PortalParameters", "DefaultActionsToDisplay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PortalParameters", "DefaultActionsToDisplay", c => c.Long(nullable: false));
            DropColumn("dbo.PortalParameters", "DefaultAuctionsToDisplay");
        }
    }
}
