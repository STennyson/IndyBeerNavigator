namespace IndyBeerNavigator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPropertiesToBeer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beer", "ABV", c => c.Double(nullable: false));
            AddColumn("dbo.Beer", "IBUs", c => c.Int(nullable: false));
            AddColumn("dbo.Beer", "SRM", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beer", "SRM");
            DropColumn("dbo.Beer", "IBUs");
            DropColumn("dbo.Beer", "ABV");
        }
    }
}
