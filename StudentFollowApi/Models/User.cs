﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class User
    {
        [MaxLength(11)]
        public string Id { get; set; }
        public string NameAndSurname { get; set; }
        public string Password { get; set; }

        public byte RoleId { get; set; }
        public Role Role { get; set; }
    }
}