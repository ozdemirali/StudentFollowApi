namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnFilterTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filters", "Scholarship", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Filters", "Scholarship");
        }
    }
}
