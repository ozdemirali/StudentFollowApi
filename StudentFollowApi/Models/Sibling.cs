using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class Sibling
    {
        [MaxLength(11)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string NameAndSurname { get; set; }

        [MaxLength(50)]
        public string ContinuallyIllness { get; set; }

        public byte EducationId { get; set; }
        public Education Education { get; set; }

        public byte JobId { get; set; }
        public Job Job { get; set; }

        
        [MaxLength(11)]
        public string StudentId {get;set;}
        public Student Student { get; set; }


    }
}