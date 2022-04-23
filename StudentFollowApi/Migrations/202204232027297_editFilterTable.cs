namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editFilterTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filters", "Applied", c => c.Boolean(nullable: false));
            DropColumn("dbo.Filters", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Filters", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Filters", "Applied");
        }
    }
}
