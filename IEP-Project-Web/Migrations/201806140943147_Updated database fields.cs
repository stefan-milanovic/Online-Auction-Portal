namespace IEP_Project_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateddatabasefields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Auction", "MostRecentBidder_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bid", "AuctionId", "dbo.Auction");
            DropForeignKey("dbo.Bid", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TokenOrder", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Auction", new[] { "MostRecentBidder_Id" });
            DropIndex("dbo.Bid", new[] { "AuctionId" });
            DropIndex("dbo.Bid", new[] { "UserId" });
            DropIndex("dbo.TokenOrder", new[] { "UserId" });
            AlterColumn("dbo.Auction", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Auction", "Image", c => c.Binary(nullable: false));
            AlterColumn("dbo.Auction", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Bid", "AuctionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Bid", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TokenOrder", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.TokenOrder", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Bid", "AuctionId");
            CreateIndex("dbo.Bid", "UserId");
            CreateIndex("dbo.TokenOrder", "UserId");
            AddForeignKey("dbo.Bid", "AuctionId", "dbo.Auction", "AuctionId", cascadeDelete: true);
            AddForeignKey("dbo.Bid", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TokenOrder", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            // DropColumn("dbo.Auction", "MostRecentBidder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auction", "MostRecentBidder_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.TokenOrder", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bid", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bid", "AuctionId", "dbo.Auction");
            DropIndex("dbo.TokenOrder", new[] { "UserId" });
            DropIndex("dbo.Bid", new[] { "UserId" });
            DropIndex("dbo.Bid", new[] { "AuctionId" });
            AlterColumn("dbo.TokenOrder", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TokenOrder", "Status", c => c.String());
            AlterColumn("dbo.Bid", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Bid", "AuctionId", c => c.Guid());
            AlterColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String());
            AlterColumn("dbo.Auction", "Status", c => c.String());
            AlterColumn("dbo.Auction", "Image", c => c.Binary());
            AlterColumn("dbo.Auction", "Name", c => c.String());
            CreateIndex("dbo.TokenOrder", "UserId");
            CreateIndex("dbo.Bid", "UserId");
            CreateIndex("dbo.Bid", "AuctionId");
            CreateIndex("dbo.Auction", "MostRecentBidder_Id");
            AddForeignKey("dbo.TokenOrder", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Bid", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Bid", "AuctionId", "dbo.Auction", "AuctionId");
            AddForeignKey("dbo.Auction", "MostRecentBidder_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
