namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUserFilterTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Filters");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Filters", "UserName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Filters", "UserName");
            AddPrimaryKey("dbo.Users", "UserName");
            DropColumn("dbo.Filters", "Id");
            DropColumn("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 11));
            AddColumn("dbo.Filters", "Id", c => c.String(nullable: false, maxLength: 11));
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Filters");
            AlterColumn("dbo.Users", "UserName", c => c.String());
            DropColumn("dbo.Filters", "UserName");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Filters", "Id");
        }
    }
}
