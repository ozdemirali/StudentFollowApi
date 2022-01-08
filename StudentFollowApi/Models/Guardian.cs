﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class Guardian
    {
        [MaxLength(11)]
        public string Id { get; set; }
        public string NameAndSurname { get; set; }
        
        [MaxLength(11)]
        public string MobilePhone { get; set; }

        public byte ProximityId { get; set; }
        public Proximity Proximity { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}