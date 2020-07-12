namespace IndyBeerNavigator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventAndReviewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        EventDate = c.DateTime(nullable: false),
                        BreweryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Brewery", t => t.BreweryId, cascadeDelete: true)
                .Index(t => t.BreweryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "BreweryId", "dbo.Brewery");
            DropIndex("dbo.Event", new[] { "BreweryId" });
            DropTable("dbo.Event");
        }
    }
}
