namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editFamliyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Families", "MatherOrFather", c => c.Boolean(nullable: false));
            DropColumn("dbo.Families", "MatherOrFarher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Families", "MatherOrFarher", c => c.Boolean(nullable: false));
            DropColumn("dbo.Families", "MatherOrFather");
        }
    }
}
