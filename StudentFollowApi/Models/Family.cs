using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class Family
    {
        [MaxLength(11)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string NameAndSurname { get; set; }

        [MaxLength(10)]
        public string OfficePhone { get; set; }
        
        [MaxLength(10)]
        public string MobilePhone { get; set; }

        [MaxLength(10)]
        public string HomePhone { get; set; }

        public bool MatherOrFarher { get; set; }

        [MaxLength(50)]
        public string DisabilitySituation { get; set; } //Engel Durumu

        [MaxLength(50)]
        public string ContinuallyIllness { get; set; } //Sürekli Hastalığı

        [MaxLength(50)]
        public string Mail { get; set; }

        public bool AliveOrDead { get; set; }

        public bool TogetherOrSeparetly { get; set; }

        public byte EducationId { get; set; }
        public Education Education { get; set; }


        public byte JobId { get; set; }
        public Job Job { get; set; }

      
        [MaxLength(11)]
        public string StudentDetailId { get; set; }
        public StudentDetail StudentDetail { get; set; }

    }
}