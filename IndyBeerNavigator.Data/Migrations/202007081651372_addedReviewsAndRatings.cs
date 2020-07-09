namespace IndyBeerNavigator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedReviewsAndRatings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BeerReview", "Rev", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.BeerReview", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.BeerReview", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.BreweryReview", "Rev", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.BreweryReview", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.BreweryReview", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.BeerReview", "Review");
            DropColumn("dbo.BreweryReview", "Review");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BreweryReview", "Review", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.BeerReview", "Review", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.BreweryReview", "ModifiedUtc");
            DropColumn("dbo.BreweryReview", "CreatedUtc");
            DropColumn("dbo.BreweryReview", "Rev");
            DropColumn("dbo.BeerReview", "ModifiedUtc");
            DropColumn("dbo.BeerReview", "CreatedUtc");
            DropColumn("dbo.BeerReview", "Rev");
        }
    }
}
