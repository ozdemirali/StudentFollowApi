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
    public class StudentController : ApiController
    {

        /// <summary>
        /// This method get all students data from Student Table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAllStudents()
        {
            //IList<StudentViewModel> students = null;

            using (var db = new StudentFollowDbContext())
            {
              var  students = (from s in db.Students
                            join c in db.Classrooms
                            on s.ClassroomId equals c.Id
                            join b in db.Branches
                            on s.BranchId equals b.Id
                            where s.IsDeleted == false
                           select new 
                           {
                               Id=s.Id,
                               NameAndSurname=s.NameAndSurname,
                               Number =s.Number,
                               Classroom=c.Name,
                               Branch=b.Name,
                               Address=s.Address
                           }).ToList();

            
                if (students.Count == 0)
                {
                    return NotFound();
                }

                return Ok(students);

            }
        }

        /// <summary>
        /// The method new Student insert to Student Table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PostNewStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            using (var db=new StudentFollowDbContext())
            {
                db.Students.Add(new Student() { 
                    Id=student.Id,
                    NameAndSurname=student.NameAndSurname,
                    Number=student.Number,
                    ClassroomId=student.ClassroomId,
                    BranchId=student.BranchId,
                    Address=student.Address
                });

                db.SaveChanges();
            }

            return Ok();
        }


        /// <summary>
        /// This method update student from Student Table
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult PutStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            using (var db=new StudentFollowDbContext())
            {
                var existingStudent = db.Students.Where(s => s.Id == student.Id && s.IsDeleted == false)
                                                .FirstOrDefault<Student>();
                if (existingStudent != null)
                {
                    existingStudent.NameAndSurname = student.NameAndSurname;
                    existingStudent.Number = student.Number;
                    existingStudent.ClassroomId = student.ClassroomId;
                    existingStudent.BranchId = student.BranchId;
                    existingStudent.Address = student.Address;

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
        /// This model delete by id a record from Student Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteStudent(string id)
        {
            if(id==null || id == "")
            {
                return BadRequest("Not a valid student id");
            }
            using (var db=new StudentFollowDbContext())
            {
                var student = db.Students
                              .Where(s => s.Id == id && s.IsDeleted == false)
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
    }
}
