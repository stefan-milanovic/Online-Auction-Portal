namespace IEP_Project_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOtherTablesVer1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auction",
                c => new
                    {
                        AuctionId = c.Guid(nullable: false),
                        Name = c.String(),
                        Image = c.Binary(),
                        StartingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        OpenedAt = c.DateTime(),
                        ClosedAt = c.DateTime(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.AuctionId);
            
            CreateTable(
                "dbo.Bid",
                c => new
                    {
                        BidId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        AuctionId = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BidId);
            
            CreateTable(
                "dbo.TokenOrder",
                c => new
                    {
                        TokenOrderId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TokenOrderId);
            
            DropColumn("dbo.AspNetUsers", "Tokens");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Tokens", c => c.Int(nullable: false));
            DropTable("dbo.TokenOrder");
            DropTable("dbo.Bid");
            DropTable("dbo.Auction");
        }
    }
}
