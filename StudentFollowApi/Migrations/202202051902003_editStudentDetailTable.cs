namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editStudentDetailTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentDetails", "BloodGroup_Id", "dbo.BloodGroups");
            DropIndex("dbo.StudentDetails", new[] { "BloodGroup_Id" });
            RenameColumn(table: "dbo.StudentDetails", name: "BloodGroup_Id", newName: "BloodGroupId");
            AlterColumn("dbo.StudentDetails", "BloodGroupId", c => c.Byte(nullable: false));
            CreateIndex("dbo.StudentDetails", "BloodGroupId");
            AddForeignKey("dbo.StudentDetails", "BloodGroupId", "dbo.BloodGroups", "Id", cascadeDelete: true);
            DropColumn("dbo.StudentDetails", "BooldGroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentDetails", "BooldGroupId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.StudentDetails", "BloodGroupId", "dbo.BloodGroups");
            DropIndex("dbo.StudentDetails", new[] { "BloodGroupId" });
            AlterColumn("dbo.StudentDetails", "BloodGroupId", c => c.Byte());
            RenameColumn(table: "dbo.StudentDetails", name: "BloodGroupId", newName: "BloodGroup_Id");
            CreateIndex("dbo.StudentDetails", "BloodGroup_Id");
            AddForeignKey("dbo.StudentDetails", "BloodGroup_Id", "dbo.BloodGroups", "Id");
        }
    }
}
