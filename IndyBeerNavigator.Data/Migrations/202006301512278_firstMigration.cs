namespace IndyBeerNavigator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeerReview",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Review = c.String(nullable: false, maxLength: 500),
                        Rating = c.Double(nullable: false),
                        BeerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beer", t => t.BeerId, cascadeDelete: true)
                .Index(t => t.BeerId);
            
            CreateTable(
                "dbo.BreweryReview",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Review = c.String(nullable: false, maxLength: 500),
                        Rating = c.Double(nullable: false),
                        BreweryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brewery", t => t.BreweryId, cascadeDelete: true)
                .Index(t => t.BreweryId);
            
            DropColumn("dbo.Beer", "Rating");
            DropColumn("dbo.Beer", "Review");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Beer", "Review", c => c.String(maxLength: 500));
            AddColumn("dbo.Beer", "Rating", c => c.Double(nullable: false));
            DropForeignKey("dbo.BreweryReview", "BreweryId", "dbo.Brewery");
            DropForeignKey("dbo.BeerReview", "BeerId", "dbo.Beer");
            DropIndex("dbo.BreweryReview", new[] { "BreweryId" });
            DropIndex("dbo.BeerReview", new[] { "BeerId" });
            DropTable("dbo.BreweryReview");
            DropTable("dbo.BeerReview");
        }
    }
}
