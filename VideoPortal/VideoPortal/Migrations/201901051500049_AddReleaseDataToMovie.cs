namespace VideoPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseDataToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
