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
                                UseMedicine = s.UseMedicine,
                                NumberOfBrotherAndSister = s.NumberOfBrotherAndSister,
                                ContinuallyIllness = s.ContinuallyIllness,
                                PastIlness = s.PastIlness,
                                Weight = s.Weight,
                                Size = s.Size,
                                Phone = s.Phone,
                                Number = s.Number,
                                UseProthes = s.UseProthes,
                                PastOperation = s.PastOperation,
                                Accident = s.Accident,
                                FamilyIncomeMoney = s.FamilyIncomeMoney,
                                FamilyIncomeStatusId = s.FamilyIncomeStatusId,
                                TypeOfDisability = s.TypeOfDisability,
                                Scheck = s.Scheck,
                                PlaceOfBirth = s.PlaceOfBirth,
                                DateOfBirth = s.DateOfBirth,
                                RecordNumberOfIdentityCard = s.RecordNumberOfIdentityCard,
                                GivenDateOfIdentityCard = s.GivenDateOfIdentityCard,
                                RentOfHouse = s.RentOfHouse,
                                HaveOwnHouse = s.HaveOwnHouse,
                                Working = s.Working,
                                OutsideFromFamily = s.OutsideFromFamily,
                                CameFromAbroad = s.CameFromAbroad,
                                Scholarship = s.Scholarship,
                                HomeHeatingId = s.HomeHeatingId,
                                BranchId = s.BranchId,
                                ClassroomId = s.ClassroomId,
                                WhitWhomLiveId = s.WhitWhomLiveId,
                                BooldGroupId = s.BooldGroupId,
                                HowToGetSchoolId = s.HowToGetSchoolId,
                                GuardianId = s.GuardianId
                            }).ToList<StudentViewModel>();
                if (students.Count == 0)
                {
                    return NotFound();
                }

                return Ok(students);

            }
        }
    }
}
