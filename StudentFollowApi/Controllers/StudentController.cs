using StudentFollowApi.Context;
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
        public IHttpActionResult GetAllStudents()
        {
            IList<StudentViewModel> students = null;

            using (var ctx = new StudentFollowDbContext())
            {
                students = ctx.Students
                            .Select(s => new StudentViewModel()
                            {
                                Id = s.Id,
                                NameAndSurname = s.NameAndSurname,
                                Number=s.Number,
                                ClassroomId=s.ClassroomId
                            }).ToList<StudentViewModel>();

               // var students = ctx.Students.ToList();
                if (students.Count == 0)
                {
                    return NotFound();
                }

                return Ok(students);

            }
        }
    }
}
