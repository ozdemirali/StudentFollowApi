using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class FamilyStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FamilyId { get; set; }
        public Family Family { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}