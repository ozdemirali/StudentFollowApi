using StudentFollowApi.Context;
using StudentFollowApi.Models;
using StudentFollowApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentFollowApi.Controllers
{
    public class StudentDetailController : ApiController
    {
        /// <summary>
        /// this method get all data from StudentDetail Table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/StudentDetail/GetAllStudentDetails")]
        public IHttpActionResult GetAllStudentDetails()
        {
         
            using (var db=new StudentFollowDbContext())
            {
                var studentDetails = (from sd in db.StudentDetails
                                      join bg in db.BloodGroups
                                      on sd.BloodGroupId equals bg.Id
                                      join fis in db.FamilyIncomeStatuses 
                                      on sd.FamilyIncomeStatusId equals fis.Id
                                      join hh in db.HomeHeatings
                                      on sd.HomeHeatingId equals hh.Id
                                      join hgs in db.HowToGetSchools
                                      on sd.HowToGetSchoolId equals hgs.Id
                                      join rg in db.Religions
                                      on sd.ReligionId equals rg.Id
                                      join wwl in db.WhitWhomLives
                                      on sd.WhitWhomLiveId equals wwl.Id
                                    
                                where sd.IsDeleted == false
                                select new
                                {
                                    sd.StudentId,
                                    sd.UseMedicine,
                                    sd.NumberOfBrotherAndSister,
                                    sd.ContinuallyIllness,
                                    sd.PastIlness,
                                    sd.Weight,
                                    sd.Size,
                                    sd.UseProthes,
                                    sd.PastOperation,
                                    sd.Accident,
                                    sd.FamilyIncomeMoney,
                                    sd.TypeOfDisability,
                                    sd.Scheck,
                                    sd.PlaceOfBirth,
                                    sd.DateOfBirth,
                                    sd.RecordNumberOfIdentityCard,
                                    sd.GivenDateOfIdentityCard,
                                    sd.RentOfHouse,
                                    sd.HaveOwnHouse,
                                    sd.Working,
                                    sd.OutsideFromFamily,
                                    sd.CameFromAbroad,
                                    sd.Scholarship,
                                    HomeHeating=hh.Name,
                                    WhitWhomLive=wwl.Name,
                                    BloodGroup=bg.Name,
                                    Religion=rg.Name,
                                    HowToGetSchool=hgs.Name,
                                    FamilyIncomeStatus=fis.Name,
                                    sd.GuardianId
                                }).ToList();


                if (studentDetails.Count == 0)
                {
                    return NotFound();
                }

                return Ok(studentDetails);
            }
        }

        /// <summary>
        /// this method get data from StudentDetail Table by studentId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/StudentDetail/GetStudentDetailById")]
        public IHttpActionResult GetStudentDetailById(string id)
        {
            if (id == null || id == "")
                return BadRequest("Invalid id");

            using (var db = new StudentFollowDbContext())
            {
                var studentDetail = (from sd in db.StudentDetails
                                      join bg in db.BloodGroups
                                      on sd.BloodGroupId equals bg.Id
                                      join fis in db.FamilyIncomeStatuses
                                      on sd.FamilyIncomeStatusId equals fis.Id
                                      join hh in db.HomeHeatings
                                      on sd.HomeHeatingId equals hh.Id
                                      join hgs in db.HowToGetSchools
                                      on sd.HowToGetSchoolId equals hgs.Id
                                      join rg in db.Religions
                                      on sd.ReligionId equals rg.Id
                                      join wwl in db.WhitWhomLives
                                      on sd.WhitWhomLiveId equals wwl.Id

                                      where sd.IsDeleted == false
                                      select new
                                      {
                                          sd.StudentId,
                                          sd.UseMedicine,
                                          sd.NumberOfBrotherAndSister,
                                          sd.ContinuallyIllness,
                                          sd.PastIlness,
                                          sd.Weight,
                                          sd.Size,
                                          sd.UseProthes,
                                          sd.PastOperation,
                                          sd.Accident,
                                          sd.FamilyIncomeMoney,
                                          sd.TypeOfDisability,
                                          sd.Scheck,
                                          sd.PlaceOfBirth,
                                          sd.DateOfBirth,
                                          sd.RecordNumberOfIdentityCard,
                                          sd.GivenDateOfIdentityCard,
                                          sd.RentOfHouse,
                                          sd.HaveOwnHouse,
                                          sd.Working,
                                          sd.OutsideFromFamily,
                                          sd.CameFromAbroad,
                                          sd.Scholarship,
                                          HomeHeating = hh.Name,
                                          WhitWhomLive = wwl.Name,
                                          BloodGroup = bg.Name,
                                          Religion = rg.Name,
                                          HowToGetSchool = hgs.Name,
                                          FamilyIncomeStatus = fis.Name,
                                          sd.GuardianId
                                      }).FirstOrDefault();


                if (studentDetail == null)
                {
                    return NotFound();
                }

                return Ok(studentDetail);
            }
        }

        /// <summary>
        /// This method add new record to StudentDetail Table from Database
        /// </summary>
        /// <param name="studentDetail"></param>
        /// <returns></returns>
        [HttpPost]
       [Route("api/StudentDetail/PostNewStudentDetail")]
        public IHttpActionResult PostNewStudentDetail(StudentDetailViewModel studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            using (var db = new StudentFollowDbContext())
            {
                db.StudentDetails.Add(new StudentDetail()
                {
                    StudentId=studentDetail.StudentId,
                    UseMedicine=studentDetail.UseMedicine,
                    NumberOfBrotherAndSister=studentDetail.NumberOfBrotherAndSister,
                    ContinuallyIllness=studentDetail.ContinuallyIllness,
                    PastIlness=studentDetail.PastIlness,
                    Weight=studentDetail.Weight,
                    Size=studentDetail.Size,
                    UseProthes=studentDetail.UseProthes,
                    PastOperation=studentDetail.PastOperation,
                    Accident=studentDetail.Accident,
                    FamilyIncomeMoney=studentDetail.FamilyIncomeMoney,
                    TypeOfDisability=studentDetail.TypeOfDisability,
                    Scheck=studentDetail.Scheck,
                    PlaceOfBirth=studentDetail.PastOperation,
                    DateOfBirth=studentDetail.DateOfBirth,
                    RecordNumberOfIdentityCard=studentDetail.RecordNumberOfIdentityCard,
                    GivenDateOfIdentityCard=studentDetail.GivenDateOfIdentityCard,
                    RentOfHouse=studentDetail.RentOfHouse,
                    HaveOwnHouse=studentDetail.HaveOwnHouse,
                    Working=studentDetail.Working,
                    OutsideFromFamily=studentDetail.OutsideFromFamily,
                    CameFromAbroad=studentDetail.CameFromAbroad,
                    Scholarship=studentDetail.Scholarship,
                    HomeHeatingId = studentDetail.HomeHeatingId,
                    WhitWhomLiveId = studentDetail.WhitWhomLiveId,
                    BloodGroupId = studentDetail.BloodGroupId,
                    ReligionId =studentDetail.ReligionId,
                    HowToGetSchoolId = studentDetail.HowToGetSchoolId,
                    FamilyIncomeStatusId =studentDetail.FamilyIncomeStatusId,
                    GuardianId=studentDetail.GuardianId
                });

                db.SaveChanges();
            }

            return Ok();

        }


        /// <summary>
        /// This method update data from StudentDetail Table
        /// </summary>
        /// <param name="studentDetail"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/StudentDetail/PutStudentDetail")]
        public IHttpActionResult PutStudentDetail(StudentDetailViewModel studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            using (var db = new StudentFollowDbContext())
            {
                var existingStudentDetail = db.StudentDetails.Where(sd => sd.StudentId == studentDetail.StudentId && sd.IsDeleted == false)
                                                .FirstOrDefault();
                if (existingStudentDetail != null)
                {
                    existingStudentDetail.StudentId = studentDetail.StudentId;
                    existingStudentDetail.UseMedicine = studentDetail.UseMedicine;
                    existingStudentDetail.NumberOfBrotherAndSister = studentDetail.NumberOfBrotherAndSister;
                    existingStudentDetail.ContinuallyIllness = studentDetail.ContinuallyIllness;
                    existingStudentDetail.PastIlness = studentDetail.PastIlness;
                    existingStudentDetail.Weight = studentDetail.Weight;
                    existingStudentDetail.Size = studentDetail.Size;
                    existingStudentDetail.UseProthes = studentDetail.UseProthes;
                    existingStudentDetail.PastOperation = studentDetail.PastOperation;
                    existingStudentDetail.Accident = studentDetail.Accident;
                    existingStudentDetail.FamilyIncomeMoney = studentDetail.FamilyIncomeMoney;
                    existingStudentDetail.TypeOfDisability = studentDetail.TypeOfDisability;
                    existingStudentDetail.Scheck = studentDetail.Scheck;
                    existingStudentDetail.PlaceOfBirth = studentDetail.PastOperation;
                    existingStudentDetail.DateOfBirth = studentDetail.DateOfBirth;
                    existingStudentDetail.RecordNumberOfIdentityCard = studentDetail.RecordNumberOfIdentityCard;
                    existingStudentDetail.GivenDateOfIdentityCard = studentDetail.GivenDateOfIdentityCard;
                    existingStudentDetail.RentOfHouse = studentDetail.RentOfHouse;
                    existingStudentDetail.HaveOwnHouse = studentDetail.HaveOwnHouse;
                    existingStudentDetail.Working = studentDetail.Working;
                    existingStudentDetail.OutsideFromFamily = studentDetail.OutsideFromFamily;
                    existingStudentDetail.CameFromAbroad = studentDetail.CameFromAbroad;
                    existingStudentDetail.Scholarship = studentDetail.Scholarship;
                    existingStudentDetail.HomeHeatingId = studentDetail.HomeHeatingId;
                    existingStudentDetail.WhitWhomLiveId = studentDetail.WhitWhomLiveId;
                    existingStudentDetail.BloodGroupId = studentDetail.BloodGroupId;
                    existingStudentDetail.ReligionId = studentDetail.ReligionId;
                    existingStudentDetail.HowToGetSchoolId = studentDetail.HowToGetSchoolId;
                    existingStudentDetail.FamilyIncomeStatusId = studentDetail.FamilyIncomeStatusId;
                    existingStudentDetail.GuardianId = studentDetail.GuardianId;
                    db.SaveChanges();

                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();

        }

        /// <summary>
        /// This method delete data from StudentDetail Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/StudentDetail/DeleteStudentDetail")]
        public IHttpActionResult DeleteStudentDetail(string id)
        {
            if (id == null || id == "")
            {
                return BadRequest("Not a valid student id");
            }
            using (var db = new StudentFollowDbContext())
            {
                var studentDetail = db.StudentDetails
                              .Where(sd => sd.StudentId == id && sd.IsDeleted == false)
                              .FirstOrDefault();
                if (studentDetail != null)
                {
                    studentDetail.IsDeleted = true;
                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }
    }
}
