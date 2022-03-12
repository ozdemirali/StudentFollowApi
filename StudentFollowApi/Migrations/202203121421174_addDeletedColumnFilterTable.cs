namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeletedColumnFilterTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filters", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Filters", "IsDeleted");
        }
    }
}
