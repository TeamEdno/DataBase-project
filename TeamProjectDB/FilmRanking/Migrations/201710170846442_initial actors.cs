namespace FilmRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialactors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        YearBorn = c.Int(),
                        ShortBio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Films", "Actor_Id", c => c.Int());
            CreateIndex("dbo.Films", "Actor_Id");
            AddForeignKey("dbo.Films", "Actor_Id", "dbo.Actors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.Films", new[] { "Actor_Id" });
            DropColumn("dbo.Films", "Actor_Id");
            DropTable("dbo.Actors");
        }
    }
}
