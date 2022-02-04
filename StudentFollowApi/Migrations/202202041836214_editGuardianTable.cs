namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editGuardianTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guardians", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Guardians", "NameAndSurname", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Guardians", "NameAndSurname", c => c.String());
            DropColumn("dbo.Guardians", "IsDeleted");
        }
    }
}
