namespace FilmRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class filmratingtocollection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Title", c => c.String(maxLength: 50));
            DropColumn("dbo.Films", "Rate");
        }

        public override void Down()
        {
            AddColumn("dbo.Films", "Rate", c => c.Double(nullable: false));
            AlterColumn("dbo.Films", "Title", c => c.String());
        }
    }
}
