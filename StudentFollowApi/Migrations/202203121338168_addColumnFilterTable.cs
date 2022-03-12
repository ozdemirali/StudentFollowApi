namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnFilterTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filters", "FamilyIncomeMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Filters", "FamilyIncomeMoney");
        }
    }
}
