namespace IEP_Project_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOtherTablesVer2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auction", "Duration", c => c.Long(nullable: false));
            AddColumn("dbo.AspNetUsers", "Tokens", c => c.Long(nullable: false));
            AddColumn("dbo.Bid", "Tokens", c => c.Long(nullable: false));
            AddColumn("dbo.TokenOrder", "Tokens", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TokenOrder", "Tokens");
            DropColumn("dbo.Bid", "Tokens");
            DropColumn("dbo.AspNetUsers", "Tokens");
            DropColumn("dbo.Auction", "Duration");
        }
    }
}
