namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editColumnFilterTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Filters", "RentOfHouse", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filters", "RentOfHouse", c => c.Byte(nullable: false));
        }
    }
}
