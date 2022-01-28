using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{ 
    /// <summary>
    /// Kiminle yaşıyor -Whom is living
    /// </summary>
    public class WhitWhomLive
    {
        public byte Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<StudentDetail> StudentDetails { get; set; }
    }
}