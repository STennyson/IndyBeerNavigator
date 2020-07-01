namespace IndyBeerNavigator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beer", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.Brewery", "Rating");
            DropColumn("dbo.Brewery", "Review");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brewery", "Review", c => c.String(maxLength: 500));
            AddColumn("dbo.Brewery", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.Beer", "Rating");
        }
    }
}
