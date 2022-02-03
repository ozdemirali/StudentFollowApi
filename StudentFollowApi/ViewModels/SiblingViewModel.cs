using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentFollowApi.ViewModels
{
    public class SiblingViewModel
    {
        public string Id { get; set; }
        public string NameAndSurname { get; set; }
        public string ContinuallyIllness { get; set; }
        public byte EducationId { get; set; }
        public byte JobId { get; set; }
        public string StudentId { get; set; }
    }
}