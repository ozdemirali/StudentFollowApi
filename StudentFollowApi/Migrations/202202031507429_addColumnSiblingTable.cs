namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnSiblingTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Siblings", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Siblings", "IsDeleted");
        }
    }
}
