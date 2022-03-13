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
    [Authorize]
    public class FamilyController : ApiController
    {
        /// <summary>
        /// This model get all data about students' families
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Family/GetAllFamilies")]
        public IHttpActionResult GetAllFamilies()
        {
            try
            {
                using (var db = new StudentFollowDbContext())
                {
                    var families = (from f in db.Families
                                    join j in db.Jobs
                                    on f.JobId equals j.Id
                                    join e in db.Educations
                                    on f.EducationId equals e.Id
                                    where f.IsDeleted == false
                                    select new
                                    {
                                        f.Id,
                                        f.NameAndSurname,
                                        f.OfficePhone,
                                        f.MobilePhone,
                                        f.MatherOrFather,
                                        f.DisabilitySituation,
                                        f.ContinuallyIllness,
                                        f.Mail,
                                        f.AliveOrDead,
                                        f.TogetherOrSeparetly,
                                    }).ToList();


                    if (families.Count == 0)
                    {
                        return NotFound();
                    }

                    return Ok(families);
                }
            }
            catch (Exception e)
            {
                using (var db=new StudentFollowDbContext())
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
        /// This model get information about family by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Family/GetFamilyById")]
        public IHttpActionResult GetFamilyById(string id)
        {
            try
            {
                if (id == null || id == "")
                    return BadRequest("Invalid id");

                using (var db = new StudentFollowDbContext())
                {
                    var family = (from f in db.Families
                                  join j in db.Jobs
                                  on f.JobId equals j.Id
                                  join e in db.Educations
                                  on f.EducationId equals e.Id
                                  where f.Id == id && f.IsDeleted == false
                                  select new
                                  {
                                      f.Id,
                                      f.NameAndSurname,
                                      f.OfficePhone,
                                      f.MobilePhone,
                                      f.MatherOrFather,
                                      f.DisabilitySituation,
                                      f.ContinuallyIllness,
                                      f.Mail,
                                      f.AliveOrDead,
                                      f.TogetherOrSeparetly,
                                  }).FirstOrDefault();


                    if (family == null)
                    {
                        return NotFound();
                    }

                    return Ok(family);
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
        /// This model get information about students' families by studentId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Family/GetFamilyByStudentId")]
        public IHttpActionResult GetFamilyByStudentId(string id)
        {
            try
            {
                if (id == null || id == "")
                    return BadRequest("Invalid id");

                using (var db = new StudentFollowDbContext())
                {
                    var families = (from f in db.Families
                                    join fs in db.FamilyStudents
                                    on f.Id equals fs.FamilyId
                                    join j in db.Jobs
                                    on f.JobId equals j.Id
                                    join e in db.Educations
                                    on f.EducationId equals e.Id
                                    where f.IsDeleted == false && fs.StudentId == id
                                    select new
                                    {
                                        f.Id,
                                        f.NameAndSurname,
                                        f.OfficePhone,
                                        f.MobilePhone,
                                        f.MatherOrFather,
                                        f.DisabilitySituation,
                                        f.ContinuallyIllness,
                                        f.Mail,
                                        f.AliveOrDead,
                                        f.TogetherOrSeparetly,
                                    }).ToList();


                    if (families.Count == 0)
                    {
                        return NotFound();
                    }

                    return Ok(families);
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
        /// The method new Family insert to Family Table
        /// </summary>
        /// <param name="family"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Family/PostNewFamily")]
        public IHttpActionResult PostNewFamily(FamilyViewModel family)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data");

                using (var db = new StudentFollowDbContext())
                {
                    db.Families.Add(new Family()
                    {
                        Id = family.Id,
                        NameAndSurname = family.NameAndSurname,
                        OfficePhone = family.OfficePhone,
                        MobilePhone = family.MobilePhone,
                        HomePhone = family.HomePhone,
                        MatherOrFather=family.MatherOrFather,
                        DisabilitySituation = family.DisabilitySituation,
                        ContinuallyIllness = family.ContinuallyIllness,
                        Mail = family.Mail,
                        AliveOrDead = family.AliveOrDead,
                        TogetherOrSeparetly = family.TogetherOrSeparetly,
                        EducationId = family.EducationId,
                        JobId = family.JobId,
                    });
                    db.SaveChanges();
                }
                return Ok();
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
        /// This method update family from Family Table
        /// </summary>
        /// <param name="family"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("api/Family/PutFamily")]
        public IHttpActionResult PutFamily(FamilyViewModel family)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                using (var db = new StudentFollowDbContext())
                {
                    var existingFamily = db.Families.Where(f => f.Id == family.Id).FirstOrDefault();

                    if (existingFamily != null)
                    {
                        existingFamily.NameAndSurname = family.NameAndSurname;
                        existingFamily.OfficePhone = family.OfficePhone;
                        existingFamily.MobilePhone = family.MobilePhone;
                        existingFamily.HomePhone = family.HomePhone;
                        existingFamily.MatherOrFather = family.MatherOrFather;
                        existingFamily.DisabilitySituation = family.DisabilitySituation;
                        existingFamily.ContinuallyIllness = family.ContinuallyIllness;
                        existingFamily.Mail = family.Mail;
                        existingFamily.AliveOrDead = family.AliveOrDead;
                        existingFamily.TogetherOrSeparetly = family.TogetherOrSeparetly;
                        existingFamily.EducationId = family.EducationId;
                        existingFamily.JobId = family.JobId;
                        db.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return Ok();
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
        /// This model delete by id a record from Family Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Family/DeleteFamily")]
        public IHttpActionResult DeleteFamily(string id)
        {
            try
            {
                if (id == null || id == "")
                {
                    return BadRequest("Not a valid student id");
                }
                using (var db = new StudentFollowDbContext())
                {
                    var family = db.Families.Where(f => f.Id == id).FirstOrDefault();

                    if (family != null)
                    {
                        family.IsDeleted = true;
                        db.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                return Ok();
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
