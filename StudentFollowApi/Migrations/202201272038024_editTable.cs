namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "BloodGroup_Id", "dbo.BloodGroups");
            DropForeignKey("dbo.Students", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Families", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.Siblings", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.Families", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Siblings", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Students", "FamilyIncomeStatusId", "dbo.FamilyIncomeStatus");
            DropForeignKey("dbo.Guardians", "ProximityId", "dbo.Proximities");
            DropForeignKey("dbo.Students", "HomeHeatingId", "dbo.HomeHeatings");
            DropForeignKey("dbo.Students", "HowToGetSchoolId", "dbo.HowToGetSchools");
            DropForeignKey("dbo.Students", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.Students", "WhitWhomLiveId", "dbo.WhitWhomLives");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropPrimaryKey("dbo.BloodGroups");
            DropPrimaryKey("dbo.Classrooms");
            DropPrimaryKey("dbo.Educations");
            DropPrimaryKey("dbo.Jobs");
            DropPrimaryKey("dbo.FamilyIncomeStatus");
            DropPrimaryKey("dbo.Proximities");
            DropPrimaryKey("dbo.HomeHeatings");
            DropPrimaryKey("dbo.HowToGetSchools");
            DropPrimaryKey("dbo.Religions");
            DropPrimaryKey("dbo.WhitWhomLives");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.BloodGroups", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Classrooms", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Educations", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Jobs", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.FamilyIncomeStatus", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Proximities", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.HomeHeatings", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.HowToGetSchools", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Religions", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.WhitWhomLives", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Roles", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.BloodGroups", "Id");
            AddPrimaryKey("dbo.Classrooms", "Id");
            AddPrimaryKey("dbo.Educations", "Id");
            AddPrimaryKey("dbo.Jobs", "Id");
            AddPrimaryKey("dbo.FamilyIncomeStatus", "Id");
            AddPrimaryKey("dbo.Proximities", "Id");
            AddPrimaryKey("dbo.HomeHeatings", "Id");
            AddPrimaryKey("dbo.HowToGetSchools", "Id");
            AddPrimaryKey("dbo.Religions", "Id");
            AddPrimaryKey("dbo.WhitWhomLives", "Id");
            AddPrimaryKey("dbo.Roles", "Id");
            AddForeignKey("dbo.Students", "BloodGroup_Id", "dbo.BloodGroups", "Id");
            AddForeignKey("dbo.Students", "ClassroomId", "dbo.Classrooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Families", "EducationId", "dbo.Educations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Siblings", "EducationId", "dbo.Educations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Families", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Siblings", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "FamilyIncomeStatusId", "dbo.FamilyIncomeStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Guardians", "ProximityId", "dbo.Proximities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "HomeHeatingId", "dbo.HomeHeatings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "HowToGetSchoolId", "dbo.HowToGetSchools", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "ReligionId", "dbo.Religions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "WhitWhomLiveId", "dbo.WhitWhomLives", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Students", "WhitWhomLiveId", "dbo.WhitWhomLives");
            DropForeignKey("dbo.Students", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.Students", "HowToGetSchoolId", "dbo.HowToGetSchools");
            DropForeignKey("dbo.Students", "HomeHeatingId", "dbo.HomeHeatings");
            DropForeignKey("dbo.Guardians", "ProximityId", "dbo.Proximities");
            DropForeignKey("dbo.Students", "FamilyIncomeStatusId", "dbo.FamilyIncomeStatus");
            DropForeignKey("dbo.Siblings", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Families", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Siblings", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.Families", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.Students", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Students", "BloodGroup_Id", "dbo.BloodGroups");
            DropPrimaryKey("dbo.Roles");
            DropPrimaryKey("dbo.WhitWhomLives");
            DropPrimaryKey("dbo.Religions");
            DropPrimaryKey("dbo.HowToGetSchools");
            DropPrimaryKey("dbo.HomeHeatings");
            DropPrimaryKey("dbo.Proximities");
            DropPrimaryKey("dbo.FamilyIncomeStatus");
            DropPrimaryKey("dbo.Jobs");
            DropPrimaryKey("dbo.Educations");
            DropPrimaryKey("dbo.Classrooms");
            DropPrimaryKey("dbo.BloodGroups");
            AlterColumn("dbo.Roles", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.WhitWhomLives", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Religions", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.HowToGetSchools", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.HomeHeatings", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Proximities", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.FamilyIncomeStatus", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Jobs", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Educations", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Classrooms", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.BloodGroups", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Roles", "Id");
            AddPrimaryKey("dbo.WhitWhomLives", "Id");
            AddPrimaryKey("dbo.Religions", "Id");
            AddPrimaryKey("dbo.HowToGetSchools", "Id");
            AddPrimaryKey("dbo.HomeHeatings", "Id");
            AddPrimaryKey("dbo.Proximities", "Id");
            AddPrimaryKey("dbo.FamilyIncomeStatus", "Id");
            AddPrimaryKey("dbo.Jobs", "Id");
            AddPrimaryKey("dbo.Educations", "Id");
            AddPrimaryKey("dbo.Classrooms", "Id");
            AddPrimaryKey("dbo.BloodGroups", "Id");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "WhitWhomLiveId", "dbo.WhitWhomLives", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "ReligionId", "dbo.Religions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "HowToGetSchoolId", "dbo.HowToGetSchools", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "HomeHeatingId", "dbo.HomeHeatings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Guardians", "ProximityId", "dbo.Proximities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "FamilyIncomeStatusId", "dbo.FamilyIncomeStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Siblings", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Families", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Siblings", "EducationId", "dbo.Educations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Families", "EducationId", "dbo.Educations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "ClassroomId", "dbo.Classrooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "BloodGroup_Id", "dbo.BloodGroups", "Id");
        }
    }
}
