namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentDetails",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 11),
                        UseMedicine = c.String(maxLength: 50),
                        NumberOfBrotherAndSister = c.Byte(nullable: false),
                        ContinuallyIllness = c.String(maxLength: 50),
                        PastIlness = c.String(maxLength: 50),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UseProthes = c.String(maxLength: 50),
                        PastOperation = c.String(maxLength: 50),
                        Accident = c.String(maxLength: 50),
                        FamilyIncomeMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Scheck = c.Boolean(nullable: false),
                        PlaceOfBirth = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        RecordNumberOfIdentityCard = c.String(maxLength: 9),
                        GivenDateOfIdentityCard = c.DateTime(nullable: false),
                        RentOfHouse = c.Boolean(nullable: false),
                        HaveOwnRoom = c.Boolean(nullable: false),
                        Working = c.Boolean(nullable: false),
                        OutsideFromFamily = c.Boolean(nullable: false),
                        CameFromAbroad = c.Boolean(nullable: false),
                        Scholarship = c.Boolean(nullable: false),
                        TypeOfDisabilityId = c.Byte(nullable: false),
                        HomeHeatingId = c.Byte(nullable: false),
                        WhitWhomLiveId = c.Byte(nullable: false),
                        BloodGroupId = c.Byte(nullable: false),
                        ReligionId = c.Byte(nullable: false),
                        HowToGetSchoolId = c.Byte(nullable: false),
                        FamilyIncomeStatusId = c.Byte(nullable: false),
                        GuardianId = c.String(maxLength: 11),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.BloodGroups", t => t.BloodGroupId, cascadeDelete: true)
                .ForeignKey("dbo.FamilyIncomeStatus", t => t.FamilyIncomeStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Guardians", t => t.GuardianId)
                .ForeignKey("dbo.HomeHeatings", t => t.HomeHeatingId, cascadeDelete: true)
                .ForeignKey("dbo.HowToGetSchools", t => t.HowToGetSchoolId, cascadeDelete: true)
                .ForeignKey("dbo.Religions", t => t.ReligionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.TypeOfDisabilities", t => t.TypeOfDisabilityId, cascadeDelete: true)
                .ForeignKey("dbo.WhitWhomLives", t => t.WhitWhomLiveId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TypeOfDisabilityId)
                .Index(t => t.HomeHeatingId)
                .Index(t => t.WhitWhomLiveId)
                .Index(t => t.BloodGroupId)
                .Index(t => t.ReligionId)
                .Index(t => t.HowToGetSchoolId)
                .Index(t => t.FamilyIncomeStatusId)
                .Index(t => t.GuardianId);
            
            CreateTable(
                "dbo.FamilyIncomeStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Guardians",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 11),
                        NameAndSurname = c.String(maxLength: 50),
                        MobilePhone = c.String(maxLength: 11),
                        ProximityId = c.Byte(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proximities", t => t.ProximityId, cascadeDelete: true)
                .Index(t => t.ProximityId);
            
            CreateTable(
                "dbo.Proximities",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeHeatings",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HowToGetSchools",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 11),
                        NameAndSurname = c.String(maxLength: 50),
                        Number = c.String(maxLength: 4),
                        Phone = c.String(maxLength: 11),
                        ClassroomId = c.Byte(nullable: false),
                        BranchId = c.Byte(nullable: false),
                        Address = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .Index(t => t.ClassroomId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Siblings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 11),
                        NameAndSurname = c.String(maxLength: 50),
                        ContinuallyIllness = c.String(maxLength: 50),
                        EducationId = c.Byte(nullable: false),
                        JobId = c.Byte(nullable: false),
                        StudentId = c.String(maxLength: 11),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.EducationId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.EducationId)
                .Index(t => t.JobId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 11),
                        NameAndSurname = c.String(maxLength: 50),
                        OfficePhone = c.String(maxLength: 11),
                        MobilePhone = c.String(maxLength: 11),
                        HomePhone = c.String(maxLength: 11),
                        MatherOrFarher = c.Boolean(nullable: false),
                        DisabilitySituation = c.String(maxLength: 50),
                        ContinuallyIllness = c.String(maxLength: 50),
                        Mail = c.String(maxLength: 50),
                        AliveOrDead = c.Boolean(nullable: false),
                        TogetherOrSeparetly = c.Boolean(nullable: false),
                        EducationId = c.Byte(nullable: false),
                        JobId = c.Byte(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.EducationId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.EducationId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.FamilyStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FamilyId = c.String(maxLength: 11),
                        StudentId = c.String(maxLength: 11),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.FamilyId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.FamilyId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfDisabilities",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WhitWhomLives",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 11),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.StudentDetails", "WhitWhomLiveId", "dbo.WhitWhomLives");
            DropForeignKey("dbo.StudentDetails", "TypeOfDisabilityId", "dbo.TypeOfDisabilities");
            DropForeignKey("dbo.StudentDetails", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Siblings", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Siblings", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.Siblings", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Families", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.FamilyStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.FamilyStudents", "FamilyId", "dbo.Families");
            DropForeignKey("dbo.Families", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.Students", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Students", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.StudentDetails", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.StudentDetails", "HowToGetSchoolId", "dbo.HowToGetSchools");
            DropForeignKey("dbo.StudentDetails", "HomeHeatingId", "dbo.HomeHeatings");
            DropForeignKey("dbo.StudentDetails", "GuardianId", "dbo.Guardians");
            DropForeignKey("dbo.Guardians", "ProximityId", "dbo.Proximities");
            DropForeignKey("dbo.StudentDetails", "FamilyIncomeStatusId", "dbo.FamilyIncomeStatus");
            DropForeignKey("dbo.StudentDetails", "BloodGroupId", "dbo.BloodGroups");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.FamilyStudents", new[] { "StudentId" });
            DropIndex("dbo.FamilyStudents", new[] { "FamilyId" });
            DropIndex("dbo.Families", new[] { "JobId" });
            DropIndex("dbo.Families", new[] { "EducationId" });
            DropIndex("dbo.Siblings", new[] { "StudentId" });
            DropIndex("dbo.Siblings", new[] { "JobId" });
            DropIndex("dbo.Siblings", new[] { "EducationId" });
            DropIndex("dbo.Students", new[] { "BranchId" });
            DropIndex("dbo.Students", new[] { "ClassroomId" });
            DropIndex("dbo.Guardians", new[] { "ProximityId" });
            DropIndex("dbo.StudentDetails", new[] { "GuardianId" });
            DropIndex("dbo.StudentDetails", new[] { "FamilyIncomeStatusId" });
            DropIndex("dbo.StudentDetails", new[] { "HowToGetSchoolId" });
            DropIndex("dbo.StudentDetails", new[] { "ReligionId" });
            DropIndex("dbo.StudentDetails", new[] { "BloodGroupId" });
            DropIndex("dbo.StudentDetails", new[] { "WhitWhomLiveId" });
            DropIndex("dbo.StudentDetails", new[] { "HomeHeatingId" });
            DropIndex("dbo.StudentDetails", new[] { "TypeOfDisabilityId" });
            DropIndex("dbo.StudentDetails", new[] { "StudentId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Errors");
            DropTable("dbo.WhitWhomLives");
            DropTable("dbo.TypeOfDisabilities");
            DropTable("dbo.Jobs");
            DropTable("dbo.FamilyStudents");
            DropTable("dbo.Families");
            DropTable("dbo.Educations");
            DropTable("dbo.Siblings");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Branches");
            DropTable("dbo.Students");
            DropTable("dbo.Religions");
            DropTable("dbo.HowToGetSchools");
            DropTable("dbo.HomeHeatings");
            DropTable("dbo.Proximities");
            DropTable("dbo.Guardians");
            DropTable("dbo.FamilyIncomeStatus");
            DropTable("dbo.StudentDetails");
            DropTable("dbo.BloodGroups");
        }
    }
}
