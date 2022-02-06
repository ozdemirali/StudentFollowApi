using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentFollowApi.ViewModels
{
    public class FamilyStudentViewModel
    {
        public int Id { get; set; }
        public string FamilyId { get; set; }
        public string StudentId { get; set; }
    }
}