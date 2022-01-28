﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class Student
    {
        [MaxLength(11)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string NameAndSurname { get; set; }

        [MaxLength(4)]
        public string Number { get; set; }

        public byte ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        public virtual StudentDetail StudentDetail { get; set; }
    }
}