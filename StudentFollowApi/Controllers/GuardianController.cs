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
    public class GuardianController : ApiController
    {
        /// <summary>
        /// This method get all guardians data from Guardian Table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Guardian/GetAllGuardians")]
        public IHttpActionResult GetAllGuardians()
        {

            using (var db = new StudentFollowDbContext())
            {
                var guardians = (from g in db.Guardians
                                join p in db.Proximities
                                on g.ProximityId equals p.Id
                                where g.IsDeleted == false
                                select new
                                {
                                    g.Id,
                                    g.NameAndSurname,
                                    g.MobilePhone,
                                    Proximity=p.Name
                                }).ToList();


                if (guardians.Count == 0)
                {
                    return NotFound();
                }

                return Ok(guardians);

            }
        }

        /// <summary>
        /// This method get data from Guardian Table by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetGuardianById(string id)
        {
            if (id == null || id == "")
                return BadRequest("Invalid id");

            using (var db = new StudentFollowDbContext())
            {
                var guardian = (from g in db.Guardians
                                 join p in db.Proximities
                                 on g.ProximityId equals p.Id
                                 where g.Id==id && g.IsDeleted == false
                                 select new
                                 {
                                     g.Id,
                                     g.NameAndSurname,
                                     g.MobilePhone,
                                     Proximity = p.Name
                                 }).ToList();


                if (guardian.Count == 0)
                {
                    return NotFound();
                }

                return Ok(guardian);

            }
        }

        /// <summary>
        /// The method new Guardian insert to Guardian Table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Guardian/PostNewGuardian")]
        public IHttpActionResult PostNewGuardian(GuardianViewModel guardian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            using (var db = new StudentFollowDbContext())
            {
                db.Guardians.Add(new Guardian()
                {
                    Id = guardian.Id,
                    NameAndSurname = guardian.NameAndSurname,
                    MobilePhone=guardian.MobilePhone,
                    ProximityId=guardian.ProximityId
                });

                db.SaveChanges();
            }

            return Ok();
        }



        /// <summary>
        /// This method update guardian from Guardian Table
        /// </summary>
        /// <param name="guardian"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Guardian/PutGuardian")]
        public IHttpActionResult PutGuardian(GuardianViewModel guardian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            using (var db = new StudentFollowDbContext())
            {
                var existingGuardian = db.Guardians.Where(g => g.Id == guardian.Id && g.IsDeleted == false)
                                                .FirstOrDefault();
                if (existingGuardian != null)
                {
                    existingGuardian.NameAndSurname = guardian.NameAndSurname;
                    existingGuardian.MobilePhone = guardian.MobilePhone;
                    existingGuardian.ProximityId = guardian.ProximityId;
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
        /// This model delete by id a record from Guardian Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Guardian/DeleteGuardian")]
        public IHttpActionResult DeleteGuardian(string id)
        {
            if (id == null || id == "")
            {
                return BadRequest("Not a valid student id");
            }
            using (var db = new StudentFollowDbContext())
            {
                var guardian = db.Guardians
                              .Where(g => g.Id == id && g.IsDeleted == false)
                              .FirstOrDefault();
                if (guardian != null)
                {
                    guardian.IsDeleted = true;
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
