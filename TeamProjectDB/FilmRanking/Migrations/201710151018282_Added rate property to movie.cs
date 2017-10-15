namespace FilmRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedratepropertytomovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "Rate", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "Rate");
        }
    }
}
