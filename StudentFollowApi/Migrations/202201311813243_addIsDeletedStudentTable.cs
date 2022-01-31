﻿namespace StudentFollowApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsDeletedStudentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "IsDeleted");
        }
    }
}
