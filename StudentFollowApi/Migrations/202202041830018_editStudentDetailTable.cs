namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editStudentDetailTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentDetails", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "Phone", c => c.String(maxLength: 11));
            AlterColumn("dbo.StudentDetails", "UseProthes", c => c.String(maxLength: 50));
            AlterColumn("dbo.StudentDetails", "RecordNumberOfIdentityCard", c => c.String(maxLength: 9));
            AlterColumn("dbo.Families", "OfficePhone", c => c.String(maxLength: 11));
            AlterColumn("dbo.Families", "MobilePhone", c => c.String(maxLength: 11));
            AlterColumn("dbo.Families", "HomePhone", c => c.String(maxLength: 11));
            DropColumn("dbo.StudentDetails", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentDetails", "Phone", c => c.String(maxLength: 11));
            AlterColumn("dbo.Families", "HomePhone", c => c.String(maxLength: 10));
            AlterColumn("dbo.Families", "MobilePhone", c => c.String(maxLength: 10));
            AlterColumn("dbo.Families", "OfficePhone", c => c.String(maxLength: 10));
            AlterColumn("dbo.StudentDetails", "RecordNumberOfIdentityCard", c => c.String(maxLength: 50));
            AlterColumn("dbo.StudentDetails", "UseProthes", c => c.String(maxLength: 4));
            DropColumn("dbo.Students", "Phone");
            DropColumn("dbo.StudentDetails", "IsDeleted");
        }
    }
}
