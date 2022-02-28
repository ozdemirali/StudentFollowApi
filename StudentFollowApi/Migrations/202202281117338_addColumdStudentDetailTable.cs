namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumdStudentDetailTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentDetails", "MartyrChild", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentDetails", "MartyrChild");
        }
    }
}
