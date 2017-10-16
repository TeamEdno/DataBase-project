namespace FilmRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudionsDirectorsvalidations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        YearBorn = c.Int(),
                        ShortBio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 35),
                        YearEstablished = c.Int(),
                        Trivia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Films", "DirectorId", c => c.Int());
            AddColumn("dbo.Films", "StudioId", c => c.Int());
            CreateIndex("dbo.Films", "DirectorId");
            CreateIndex("dbo.Films", "StudioId");
            AddForeignKey("dbo.Films", "DirectorId", "dbo.Directors", "Id");
            AddForeignKey("dbo.Films", "StudioId", "dbo.Studios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "StudioId", "dbo.Studios");
            DropForeignKey("dbo.Films", "DirectorId", "dbo.Directors");
            DropIndex("dbo.Films", new[] { "StudioId" });
            DropIndex("dbo.Films", new[] { "DirectorId" });
            DropColumn("dbo.Films", "StudioId");
            DropColumn("dbo.Films", "DirectorId");
            DropTable("dbo.Studios");
            DropTable("dbo.Directors");
        }
    }
}
