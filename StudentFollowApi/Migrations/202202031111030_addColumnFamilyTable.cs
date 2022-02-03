namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnFamilyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Families", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Families", "IsDeleted");
        }
    }
}
