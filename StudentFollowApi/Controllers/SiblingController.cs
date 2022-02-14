﻿using StudentFollowApi.Context;
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
    public class SiblingController : ApiController
    {
        /// <summary>
        /// This methhod get all Sibling from table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Sibling/GetAllSiblings")]
        public IHttpActionResult GetAllSiblings()
        {
            try
            {
                using (var db = new StudentFollowDbContext())
                {
                    var siblings = (from sb in db.Siblings
                                    join j in db.Jobs
                                    on sb.JobId equals j.Id
                                    join e in db.Educations
                                    on sb.EducationId equals e.Id
                                    where sb.IsDeleted == false
                                    select new
                                    {
                                        sb.Id,
                                        sb.NameAndSurname,
                                        sb.ContinuallyIllness,
                                        Job = j.Name,
                                        Education = e.Name
                                    }).ToList();

                    if (siblings.Count == 0)
                    {
                        return NotFound();
                    }
                    return Ok(siblings);
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
        /// This methhod get Sibling from table by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Sibling/GetSiblingById")]
        public IHttpActionResult GetSiblingById(string id)
        {
            try
            {
                using (var db = new StudentFollowDbContext())
                {
                    var sibling = (from sb in db.Siblings
                                   join j in db.Jobs
                                   on sb.JobId equals j.Id
                                   join e in db.Educations
                                   on sb.EducationId equals e.Id
                                   where sb.Id == id && sb.IsDeleted == false
                                   select new
                                   {
                                       sb.Id,
                                       sb.NameAndSurname,
                                       sb.ContinuallyIllness,
                                       Job = j.Name,
                                       Education = e.Name
                                   }).ToList();

                    if (sibling == null)
                    {
                        return NotFound();
                    }
                    return Ok(sibling);
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
        /// This method get all sibling only by studentId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Sibling/GetSiblingsByStudentId")]
        public IHttpActionResult GetSiblingsByStudentId(string id)
        {
            try
            {
                using (var db = new StudentFollowDbContext())
                {
                    var siblings = (from sb in db.Siblings
                                    join j in db.Jobs
                                    on sb.JobId equals j.Id
                                    join e in db.Educations
                                    on sb.EducationId equals e.Id
                                    where sb.StudentId == id
                                    select new
                                    {
                                        sb.Id,
                                        sb.NameAndSurname,
                                        sb.ContinuallyIllness,
                                        Job = j.Name,
                                        Education = e.Name
                                    }).ToList();

                    if (siblings.Count == 0)
                    {
                        return NotFound();
                    }
                    return Ok(siblings);
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
        /// This method new sibling created on Sibling Table by StudentId
        /// </summary>
        /// <param name="sibling"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Sibling/PostNewSibling")]
        public IHttpActionResult PostNewSibling(SiblingViewModel sibling)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data");

                using (var db = new StudentFollowDbContext())
                {
                    db.Siblings.Add(new Models.Sibling()
                    {
                        Id = sibling.Id,
                        NameAndSurname = sibling.NameAndSurname,
                        ContinuallyIllness = sibling.ContinuallyIllness,
                        EducationId = sibling.EducationId,
                        JobId = sibling.JobId,
                        StudentId = sibling.StudentId,
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
        /// This method update sibling on Sibling Table
        /// </summary>
        /// <param name="sibling"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Sibling/PutSibling")]
        public IHttpActionResult PutSibling(SiblingViewModel sibling)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                using (var db = new StudentFollowDbContext())
                {
                    var existingSibling = db.Siblings.Where(sb => sb.Id == sibling.Id && sb.IsDeleted == false)
                                                    .FirstOrDefault();
                    if (existingSibling != null)
                    {
                        existingSibling.NameAndSurname = sibling.NameAndSurname;
                        existingSibling.ContinuallyIllness = sibling.ContinuallyIllness;
                        existingSibling.EducationId = sibling.EducationId;
                        existingSibling.JobId = sibling.JobId;
                        existingSibling.StudentId = sibling.StudentId;

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
        /// This method delete a recor by SiblingId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Sibling/DeleteSibling")]
        public IHttpActionResult DeleteSibling(string id)
        {
            try
            {
                if (id == null || id == "")
                {
                    return BadRequest("Not a valid student id");
                }
                using (var db = new StudentFollowDbContext())
                {
                    var student = db.Siblings
                                  .Where(sb => sb.Id == id && sb.IsDeleted == false)
                                  .FirstOrDefault();
                    if (student != null)
                    {
                        student.IsDeleted = true;
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
