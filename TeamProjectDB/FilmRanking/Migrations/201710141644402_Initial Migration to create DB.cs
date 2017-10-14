namespace FilmRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationtocreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Films");
        }
    }
}
