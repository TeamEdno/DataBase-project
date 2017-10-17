namespace FilmRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2mactorsFilms : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.Films", new[] { "Actor_Id" });
            CreateTable(
                "dbo.FilmActors",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Actor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Actor_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Actor_Id);
            
            DropColumn("dbo.Films", "Actor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "Actor_Id", c => c.Int());
            DropForeignKey("dbo.FilmActors", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.FilmActors", "Film_Id", "dbo.Films");
            DropIndex("dbo.FilmActors", new[] { "Actor_Id" });
            DropIndex("dbo.FilmActors", new[] { "Film_Id" });
            DropTable("dbo.FilmActors");
            CreateIndex("dbo.Films", "Actor_Id");
            AddForeignKey("dbo.Films", "Actor_Id", "dbo.Actors", "Id");
        }
    }
}
