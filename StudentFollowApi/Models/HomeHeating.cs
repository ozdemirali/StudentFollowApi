﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class HomeHeating
    {
        public byte Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}