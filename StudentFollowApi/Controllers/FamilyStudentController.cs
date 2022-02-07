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
    public class FamilyStudentController : ApiController
    {
        /// <summary>
        /// This method get data from familyStudent Table by studentId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/FamilyStudent/GetFamilyStudentById")]
        public IHttpActionResult GetFamilyStudentById(string id)
        {
            IList<FamilyStudentViewModel> familyStudent = null;

            if (id == null || id == "")
                return BadRequest("Invalid id");

            using (var db=new StudentFollowDbContext())
            {
                    familyStudent = db.FamilyStudents
                                    .Where(fs => fs.StudentId == id)
                                    .Select(s=>new FamilyStudentViewModel(){ 
                                     Id=s.Id,
                                     FamilyId=s.FamilyId,
                                     StudentId=s.StudentId,
                                    }).ToList();
            }

            if (familyStudent.Count == 0)
                return NotFound();
            return Ok(familyStudent);
        }


        /// <summary>
        /// This method add new record to FamiltStudent Table
        /// </summary>
        /// <param name="familyStudent"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/FamilyStudent/PostNewFamilyStudent")]
        public IHttpActionResult PostNewFamilyStudent(FamilyStudentViewModel familyStudent)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            
            using (var db=new StudentFollowDbContext())
            {
                db.FamilyStudents.Add(new Models.FamilyStudent() {
                    FamilyId = familyStudent.FamilyId,
                    StudentId =familyStudent.StudentId,
                });
                db.SaveChanges();
            }

            return Ok();
        }


        /// <summary>
        /// This model update record from FamilyStudent Table
        /// </summary>
        /// <param name="familyStudent"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/FamilyStudent/PutFamilyStudent")]
        public IHttpActionResult PutFamilyStudent(FamilyStudentViewModel familyStudent)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var db=new StudentFollowDbContext())
            {
                var existingFamilyStudent = db.FamilyStudents
                                            .Where(fs => fs.Id == familyStudent.Id)
                                            .FirstOrDefault();

                if(existingFamilyStudent != null)
                {
                    existingFamilyStudent.FamilyId = familyStudent.FamilyId;
                    existingFamilyStudent.StudentId = familyStudent.StudentId;
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
        /// This method delete record from FamilyStudent Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/FamilyStudent/DeleteFamilyStudent")]
        public IHttpActionResult DeleteFamilyStudent(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid familyStudent id");
            using (var db= new StudentFollowDbContext())
            {
                var familyStudent = db.FamilyStudents
                                    .Where(fs => fs.Id == id)
                                    .FirstOrDefault();
                db.Entry(familyStudent).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
