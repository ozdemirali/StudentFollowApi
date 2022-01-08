using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class Education
    {
        public byte Id { get; set; }

        [MaxLength(50)]
        public string  Name { get; set; }

        public ICollection<Family> Families { get; set; }
        public ICollection<Sibling> Siblings { get; set; }
    }
}