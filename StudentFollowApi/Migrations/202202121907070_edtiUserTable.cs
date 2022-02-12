namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edtiUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
            DropColumn("dbo.Users", "NameAndSurname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "NameAndSurname", c => c.String());
            DropColumn("dbo.Users", "UserName");
        }
    }
}
