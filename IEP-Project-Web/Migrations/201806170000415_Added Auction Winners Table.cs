namespace IEP_Project_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuctionWinnersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionWinners",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Auction_AuctionId = c.Guid(nullable: false),
                        Winner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auction", t => t.Auction_AuctionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Winner_Id, cascadeDelete: true)
                .Index(t => t.Auction_AuctionId)
                .Index(t => t.Winner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionWinners", "Winner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuctionWinners", "Auction_AuctionId", "dbo.Auction");
            DropIndex("dbo.AuctionWinners", new[] { "Winner_Id" });
            DropIndex("dbo.AuctionWinners", new[] { "Auction_AuctionId" });
            DropTable("dbo.AuctionWinners");
        }
    }
}
