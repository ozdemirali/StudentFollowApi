using StudentFollowApi.Context;
using StudentFollowApi.Models;
using StudentFollowApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentFollowApi.Controllers
{
    [Authorize]
    public class FilterController : ApiController
    {

        /// <summary>
        /// This method get data acording to filter
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Filter/GetFilter")]
        public IHttpActionResult GetFilter(string userName)
        {
            try
            {
                if(userName == null || userName == "")
                {
                    return BadRequest("Invalid id");
                }
                using (var db = new StudentFollowDbContext())
                {
                    var filter = db.Filters.Find(userName);
                    if (filter == null || filter.Applied==false) 
                    {
                        var students = (from sd in db.StudentDetails
                                              select new
                                              {
                                                  sd.StudentId,
                                                  sd.Student.NameAndSurname,
                                                  sd.Student.Number,
                                                  Branch=sd.Student.Branch.Name,
                                                  sd.Student.Phone,
                                                  sd.Student.Address,
                                                  Classroom = sd.Student.Classroom.Name,
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
                                                  TypeOfDisability = sd.TypeOfDisability.Name,
                                                  sd.Scheck,
                                                  sd.PlaceOfBirth,
                                                  sd.DateOfBirth,
                                                  sd.RecordNumberOfIdentityCard,
                                                  sd.GivenDateOfIdentityCard,
                                                  sd.RentOfHouse,
                                                  sd.HaveOwnRoom,
                                                  sd.Working,
                                                  sd.OutsideFromFamily,
                                                  sd.CameFromAbroad,
                                                  sd.Scholarship,
                                                  HomeHeating = sd.HomeHeating.Name,
                                                  WhitWhomLive = sd.WhitWhomLive.Name,
                                                  BloodGroup = sd.BloodGroup.Name,
                                                  Religion = sd.Religion.Name,
                                                  HowToGetSchool = sd.HowToGetSchool.Name,
                                                  Guardian = sd.Guardian.NameAndSurname,
                                                  GuardianPhone = sd.Guardian.MobilePhone
                                              }).ToList();
                        return Ok(students);
                    }
                    else
                    {
                        var students = (from sd in db.StudentDetails
                                              where sd.IsDeleted == false && sd.FamilyIncomeMoney<= filter.FamilyIncomeMoney && sd.WhitWhomLiveId==filter.WhitWhomLive
                                                    && sd.Scheck == filter.Scheck && sd.RentOfHouse == filter.RentOfHouse && sd.HowToGetSchoolId == filter.HowToGetSchool
                                                    && sd.TypeOfDisabilityId == filter.TypeOfDisability && sd.Working == filter.Working 
                                                    && sd.OutsideFromFamily == filter.OutsideFromFamily && sd.HaveOwnRoom==filter.HaveOwnRoom
                                                    && sd.CameFromAbroad==filter.CameFromAbroad && sd.NumberOfBrotherAndSister == filter.SiblingCount
                                                    && sd.Scholarship==filter.Scholarship
                                              select new
                                              {
                                                  sd.StudentId,
                                                  sd.Student.NameAndSurname,
                                                  sd.Student.Number,
                                                  sd.Student.Branch.Name,
                                                  sd.Student.Phone,
                                                  sd.Student.Address,
                                                  Classroom = sd.Student.Classroom.Name,
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
                                                  TypeOfDisability = sd.TypeOfDisability.Name,
                                                  sd.Scheck,
                                                  sd.PlaceOfBirth,
                                                  sd.DateOfBirth,
                                                  sd.RecordNumberOfIdentityCard,
                                                  sd.GivenDateOfIdentityCard,
                                                  sd.RentOfHouse,
                                                  sd.HaveOwnRoom,
                                                  sd.Working,
                                                  sd.OutsideFromFamily,
                                                  sd.CameFromAbroad,
                                                  sd.Scholarship,
                                                  HomeHeating = sd.HomeHeating.Name,
                                                  WhitWhomLive = sd.WhitWhomLive.Name,
                                                  BloodGroup = sd.BloodGroup.Name,
                                                  Religion = sd.Religion.Name,
                                                  HowToGetSchool = sd.HowToGetSchool.Name,
                                                  Guardian = sd.Guardian.NameAndSurname,
                                                  GuardianPhone = sd.Guardian.MobilePhone
                                              }).ToList();
                        return Ok(students);
                    }
                   

                    //var studentDetails = (from sd in db.StudentDetails
                    //                      join s in db.Students
                    //                      on sd.StudentId equals s.Id
                    //                      join bg in db.BloodGroups
                    //                      on sd.BloodGroupId equals bg.Id
                    //                      join fis in db.FamilyIncomeStatuses
                    //                      on sd.FamilyIncomeStatusId equals fis.Id
                    //                      join hh in db.HomeHeatings
                    //                      on sd.HomeHeatingId equals hh.Id
                    //                      join hgs in db.HowToGetSchools
                    //                      on sd.HowToGetSchoolId equals hgs.Id
                    //                      join rg in db.Religions
                    //                      on sd.ReligionId equals rg.Id
                    //                      join wwl in db.WhitWhomLives
                    //                      on sd.WhitWhomLiveId equals wwl.Id
                    //                      where sd.IsDeleted == false && sd.FamilyIncomeStatusId == 1
                    //                            && sd.Scheck == false && sd.RentOfHouse == false && sd.HowToGetSchoolId == 1
                    //                            && sd.TypeOfDisabilityId == 1 && sd.Working == false && sd.OutsideFromFamily == false
                    //                            && sd.NumberOfBrotherAndSister == 1
                    //                      select new
                    //                      {
                    //                          sd.StudentId,
                    //                          s.NameAndSurname,
                    //                          s.Number,
                    //                          s.Branch.Name,
                    //                          Classroom = s.Classroom.Name,
                    //                          sd.UseMedicine,
                    //                          sd.NumberOfBrotherAndSister,
                    //                          sd.ContinuallyIllness,
                    //                          sd.PastIlness,
                    //                          sd.Weight,
                    //                          sd.Size,
                    //                          sd.UseProthes,
                    //                          sd.PastOperation,
                    //                          sd.Accident,
                    //                          sd.FamilyIncomeMoney,
                    //                          TypeOfDisability = sd.TypeOfDisability.Name,
                    //                          sd.Scheck,
                    //                          sd.PlaceOfBirth,
                    //                          sd.DateOfBirth,
                    //                          sd.RecordNumberOfIdentityCard,
                    //                          sd.GivenDateOfIdentityCard,
                    //                          sd.RentOfHouse,
                    //                          sd.HaveOwnRoom,
                    //                          sd.Working,
                    //                          sd.OutsideFromFamily,
                    //                          sd.CameFromAbroad,
                    //                          sd.Scholarship,
                    //                          HomeHeating = hh.Name,
                    //                          WhitWhomLive = wwl.Name,
                    //                          BloodGroup = bg.Name,
                    //                          Religion = rg.Name,
                    //                          HowToGetSchool = hgs.Name,
                    //                          FamilyIncomeStatus = fis.Name,
                    //                          sd.GuardianId
                    //                      }).ToList();
                    
                }



            }
            catch (Exception e)
            {

                using (var db = new StudentFollowDbContext())
                {
                    var error = new Error
                    {
                        Message = e.Message
                    };
                    db.Errors.Add(error);
                    db.SaveChanges();
                }

                return Ok(e.Message);
            }
         
        }

        /// <summary>
        /// This method get data acording to filter essential
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Filter/GetFilterEssential")]
        public IHttpActionResult GetFilterEssential(string userName)
        {
            try
            {
                if (userName == null || userName == "")
                {
                    return BadRequest("Invalid id");
                }
                using (var db = new StudentFollowDbContext())
                {
                    var filter = db.Filters.Find(userName);
                    if (filter == null || filter.Applied == false)
                    {
                        var students = (from sd in db.StudentDetails
                                        select new
                                        {
                                            sd.StudentId,
                                            sd.Student.NameAndSurname,
                                            sd.Student.Number,
                                            Branch = sd.Student.Branch.Name,
                                            sd.Student.Phone,
                                            sd.Student.Address,
                                            Classroom = sd.Student.Classroom.Name,
                                            sd.NumberOfBrotherAndSister,
                                            FamilyIncomeMoney=(int)sd.FamilyIncomeMoney,
                                            TypeOfDisability = sd.TypeOfDisability.Name,
                                            sd.Scheck,
                                            sd.RentOfHouse,
                                            sd.HaveOwnRoom,
                                            sd.Working,
                                            sd.OutsideFromFamily,
                                            sd.CameFromAbroad,
                                            sd.Scholarship,
                                            HomeHeating = sd.HomeHeating.Name,
                                            WhitWhomLive = sd.WhitWhomLive.Name,
                                            HowToGetSchool = sd.HowToGetSchool.Name,
                                            Guardian = sd.Guardian.NameAndSurname,
                                            GuardianPhone = sd.Guardian.MobilePhone,
                                        }).ToList();
                        return Ok(students);
                    }
                    else
                    {
                        var students = (from sd in db.StudentDetails
                                        where sd.IsDeleted == false && sd.FamilyIncomeMoney <= filter.FamilyIncomeMoney && sd.WhitWhomLiveId == filter.WhitWhomLive
                                              && sd.Scheck == filter.Scheck && sd.RentOfHouse == filter.RentOfHouse && sd.HowToGetSchoolId == filter.HowToGetSchool
                                              && sd.TypeOfDisabilityId == filter.TypeOfDisability && sd.Working == filter.Working
                                              && sd.OutsideFromFamily == filter.OutsideFromFamily && sd.HaveOwnRoom == filter.HaveOwnRoom
                                              && sd.CameFromAbroad == filter.CameFromAbroad && sd.NumberOfBrotherAndSister == filter.SiblingCount
                                              && sd.Scholarship==filter.Scholarship
                                        select new
                                        {
                                            sd.StudentId,
                                            sd.Student.NameAndSurname,
                                            sd.Student.Number,
                                            Branch = sd.Student.Branch.Name,
                                            sd.Student.Phone,
                                            sd.Student.Address,
                                            Classroom = sd.Student.Classroom.Name,
                                            sd.NumberOfBrotherAndSister,
                                            FamilyIncomeMoney=(int)sd.FamilyIncomeMoney,
                                            TypeOfDisability = sd.TypeOfDisability.Name,
                                            sd.Scheck,
                                            sd.RentOfHouse,
                                            sd.HaveOwnRoom,
                                            sd.Working,
                                            sd.OutsideFromFamily,
                                            sd.CameFromAbroad,
                                            sd.Scholarship,
                                            HomeHeating = sd.HomeHeating.Name,
                                            WhitWhomLive = sd.WhitWhomLive.Name,
                                            HowToGetSchool = sd.HowToGetSchool.Name,
                                            Guardian = sd.Guardian.NameAndSurname,
                                            GuardianPhone = sd.Guardian.MobilePhone.ToString(),
                                        }).ToList();
                        return Ok(students);
                    }
                  
                }



            }
            catch (Exception e)
            {

                using (var db = new StudentFollowDbContext())
                {
                    var error = new Error
                    {
                        Message = e.Message
                    };
                    db.Errors.Add(error);
                    db.SaveChanges();
                }

                return Ok(e.Message);
            }

        }

        [HttpGet]
        [Route("api/Filter/GetFilterData")]
        public IHttpActionResult GetFilterData(string userName)
        {
            try
            {
                using (var db=new StudentFollowDbContext())
                {
                    var data = db.Filters.Find(userName);
                    return Ok(data);
                }
            }
            catch (Exception e)
            {
                using (var db = new StudentFollowDbContext())
                {
                    var error = new Error
                    {
                        Message = e.Message
                    };
                    db.Errors.Add(error);
                    db.SaveChanges();
                }

                return Ok(e.Message);
            }
        }



        /// <summary>
        /// This method add or modify data which send
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Filter/PostNewFilter")]
        public IHttpActionResult PostNewFilter(Filter filter )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid data");
                }

                using (var db=new StudentFollowDbContext() )
                {


                    var data = new Filter() {
                        UserName = filter.UserName,
                        WhitWhomLive = filter.WhitWhomLive,
                        RentOfHouse = filter.RentOfHouse,
                        HowToGetSchool = filter.HowToGetSchool,
                        TypeOfDisability = filter.TypeOfDisability,
                        SiblingCount = filter.SiblingCount,
                        FamilyIncomeMoney = filter.FamilyIncomeMoney,
                        Working = filter.Working,
                        OutsideFromFamily = filter.OutsideFromFamily,
                        HaveOwnRoom = filter.HaveOwnRoom,
                        CameFromAbroad = filter.CameFromAbroad,
                        Scholarship=filter.Scholarship,
                        Scheck = filter.Scheck,
                        Applied = filter.Applied,

                    };
                    


                    if (db.Filters.Where(f=>f.UserName==filter.UserName).Count()>0){
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(data).State = System.Data.Entity.EntityState.Added;

                    }

                    db.SaveChanges();
                }
                return Ok("Ok");
            }
            catch (Exception e)
            {
                using (var db = new StudentFollowDbContext())
                {
                    var error = new Error
                    {
                        Message = e.Message
                    };
                    db.Errors.Add(error);
                    db.SaveChanges();
                }

                return Ok(e.Message);
            }

        }
    }
}
