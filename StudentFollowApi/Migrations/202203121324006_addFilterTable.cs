namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFilterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filters",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 11),
                        WhitWhomLive = c.Byte(nullable: false),
                        RentOfHouse = c.Byte(nullable: false),
                        HowToGetSchool = c.Byte(nullable: false),
                        TypeOfDisability = c.Byte(nullable: false),
                        SiblingCount = c.Byte(nullable: false),
                        Working = c.Boolean(nullable: false),
                        OutsideFromFamily = c.Boolean(nullable: false),
                        HaveOwnRoom = c.Boolean(nullable: false),
                        CameFromAbroad = c.Boolean(nullable: false),
                        Scheck = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Filters");
        }
    }
}
