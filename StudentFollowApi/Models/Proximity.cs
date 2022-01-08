using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    /// <summary>
    /// Yakınlığı.(Annesi- Babası vb.) - closeness (your mother- your father - etc.) 
    /// </summary>
    public class Proximity
    {
        public byte Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Guardian> Guardians { get; set; }
    }
}