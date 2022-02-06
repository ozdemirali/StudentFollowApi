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
    public class FamilyController : ApiController
    {
        /// <summary>
        /// This model get information about students' families
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Family/GetAllFamilies")]
        public IHttpActionResult GetAllFamilies()
        {
            using (var db=new StudentFollowDbContext())
            {
                var families = (from f in db.Families
                                join j in db.Jobs
                                on f.JobId equals j.Id
                                join e in db.Educations
                                on f.EducationId equals e.Id
                                where f.IsDeleted==false
                                select new
                                {
                                    f.Id,
                                    f.NameAndSurname,
                                    f.OfficePhone,
                                    f.MobilePhone,
                                    f.MatherOrFarher,
                                    f.DisabilitySituation,
                                    f.ContinuallyIllness,
                                    f.Mail,
                                    f.AliveOrDead,
                                    f.TogetherOrSeparetly,
                                }).ToList();


                if (families.Count==0)
                {
                    return NotFound();
                }

                return Ok(families);
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
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            using (var db =new StudentFollowDbContext())
            {
                db.Families.Add(new Family() 
                { 
                    Id=family.Id,
                    NameAndSurname=family.NameAndSurname,
                    OfficePhone=family.OfficePhone,
                    MobilePhone=family.MobilePhone,
                    HomePhone=family.HomePhone,
                    DisabilitySituation=family.DisabilitySituation,
                    ContinuallyIllness=family.ContinuallyIllness,
                    Mail=family.Mail,
                    AliveOrDead=family.AliveOrDead,
                    TogetherOrSeparetly=family.TogetherOrSeparetly,
                    EducationId=family.EducationId,
                    JobId=family.JobId,
                });
                db.SaveChanges();
            }
            return Ok();
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
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            using (var db=new StudentFollowDbContext())
            {
                var existingFamily = db.Families.Where(f => f.Id == family.Id).FirstOrDefault();

                if(existingFamily!=null)
                {
                    existingFamily.NameAndSurname = family.NameAndSurname;
                    existingFamily.OfficePhone = family.OfficePhone;
                    existingFamily.MobilePhone = family.MobilePhone;
                    existingFamily.HomePhone = family.HomePhone;
                    existingFamily.MatherOrFarher = family.MatherAndFather;
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


        /// <summary>
        /// This model delete by id a record from Family Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Family/DeleteFamily")]
        public IHttpActionResult DeleteFamily(string id)
        {
            if (id == null || id == "")
            {
                return BadRequest("Not a valid student id");
            }
            using (var db=new StudentFollowDbContext())
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
    }
}
