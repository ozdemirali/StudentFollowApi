namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeColumnStudentDetailTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Siblings", "StudentId", "dbo.StudentDetails");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.Siblings", "StudentId", "dbo.StudentDetails", "StudentId");
        }
    }
}
