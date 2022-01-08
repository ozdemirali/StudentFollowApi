﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class Role
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}