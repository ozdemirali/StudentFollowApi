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

    }
}