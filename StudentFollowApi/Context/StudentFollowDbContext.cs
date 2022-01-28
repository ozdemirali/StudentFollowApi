using StudentFollowApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace StudentFollowApi.Context
{
    public class StudentFollowDbContext:DbContext
    {
        public StudentFollowDbContext():base("StudentFollowDbConnectionString")
        {

        }

        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyIncomeStatus> FamilyIncomeStatuses { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<HomeHeating> HomeHeatings { get; set; }
        public DbSet<HowToGetSchool> HowToGetSchools { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Proximity> Proximities { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Sibling> Siblings { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<WhitWhomLive> WhitWhomLives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Error> Errors { get; set; }


    }
}