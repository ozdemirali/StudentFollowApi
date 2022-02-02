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

    }
}
