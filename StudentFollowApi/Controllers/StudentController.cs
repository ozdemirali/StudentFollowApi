using ExcelDataReader;
using StudentFollowApi.Context;
using StudentFollowApi.Models;
using StudentFollowApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentFollowApi.Controllers
{

    [Authorize]
    public class StudentController : ApiController
    {

        /// <summary>
        /// This method get all students data from Student Table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Student/GetAllStudents")]
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
                               s.Id,
                               s.NameAndSurname,
                               s.Number,
                               Classroom=c.Name,
                               Branch=b.Name,
                               s.Address
                           }).ToList();

            
                if (students.Count == 0)
                {
                    return NotFound();
                }

                return Ok(students);

            }
        }

        /// <summary>
        /// This method get student data from Student Table by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Student/GetStudentById")]
        public IHttpActionResult GetByStudent(string id)
        {
            if (id == null || id == "")
                return BadRequest("Invalid id");

            using (var db = new StudentFollowDbContext())
            {
                var student = (from s in db.Students
                                join c in db.Classrooms
                                on s.ClassroomId equals c.Id
                                join b in db.Branches
                                on s.BranchId equals b.Id
                                where s.Id==id && s.IsDeleted == false
                                select new
                                {
                                    s.Id,
                                    s.NameAndSurname,
                                    s.Number,
                                    Classroom = c.Name,
                                    Branch = b.Name,
                                    s.Address
                                }).FirstOrDefault();


                if (student== null)
                {
                    return NotFound();
                }

                return Ok(student);

            }
        }

        /// <summary>
        /// The method new Student insert to Student Table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Student/PostNewStudent")]
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
        [Route("api/Student/PutStudent")]
        public IHttpActionResult PutStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            using (var db=new StudentFollowDbContext())
            {
                var existingStudent = db.Students.Where(s => s.Id == student.Id && s.IsDeleted == false)
                                                .FirstOrDefault();
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
        [Route("api/Student/DeleteStudent")]
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


        [HttpPost]
        [Route("api/Student/Upload")]
        public async Task<string> Upload()
        {
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            IExcelDataReader excelDataReader = null;

            //extract file name and file contents
            Stream stream = new MemoryStream(await provider.Contents[0].ReadAsByteArrayAsync());

            //get fileName
            var filename = provider.Contents[0].Headers.ContentDisposition.FileName.Replace("\"", string.Empty);

            //Check file type
            if (filename.EndsWith(".xls"))
            {
                excelDataReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else if (filename.EndsWith(".xlsx"))
            {
                excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            else
            {
                return "The File is not Excel File";
            }

            DataSet dataSet = excelDataReader.AsDataSet();
            Student student = new Student();

            for (int i = 1; i < dataSet.Tables[0].Rows.Count; i++)
            {
                student.Id = dataSet.Tables[0].Rows[i][0].ToString();
                student.NameAndSurname = dataSet.Tables[0].Rows[i][1].ToString();
                student.Number = dataSet.Tables[0].Rows[i][2].ToString();
                student.ClassroomId = Convert.ToByte(dataSet.Tables[0].Rows[i][3].ToString());
                student.BranchId = Convert.ToByte(dataSet.Tables[0].Rows[i][4].ToString());

                using (var db = new StudentFollowDbContext())
                {
                    if (db.Students.Where(s => s.Id == student.Id).Count() > 0)
                    {
                        db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(student).State = System.Data.Entity.EntityState.Added;
                    }

                    db.SaveChanges();

                }
            }

            return "Ok";
        }


    }
}
