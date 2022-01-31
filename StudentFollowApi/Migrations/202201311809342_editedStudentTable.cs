namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedStudentTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentDetails", "BranchId", "dbo.Branches");
            DropIndex("dbo.StudentDetails", new[] { "BranchId" });
            AddColumn("dbo.Students", "BranchId", c => c.Byte(nullable: false));
            AddColumn("dbo.Students", "Address", c => c.String(maxLength: 50));
            CreateIndex("dbo.Students", "BranchId");
            AddForeignKey("dbo.Students", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
            DropColumn("dbo.StudentDetails", "BranchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentDetails", "BranchId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Students", "BranchId", "dbo.Branches");
            DropIndex("dbo.Students", new[] { "BranchId" });
            DropColumn("dbo.Students", "Address");
            DropColumn("dbo.Students", "BranchId");
            CreateIndex("dbo.StudentDetails", "BranchId");
            AddForeignKey("dbo.StudentDetails", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
    }
}
