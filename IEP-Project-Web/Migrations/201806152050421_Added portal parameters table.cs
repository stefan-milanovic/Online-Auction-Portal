namespace IEP_Project_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedportalparameterstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortalParameters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DefaultActionsToDisplay = c.Long(nullable: false),
                        DefaultAuctionDuration = c.Long(nullable: false),
                        SilverPackageTokenAmount = c.Long(nullable: false),
                        GoldPackageTokenAmount = c.Long(nullable: false),
                        PlatinumPackageTokenAmount = c.Long(nullable: false),
                        Currency = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TokenValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PortalParameters");
        }
    }
}
