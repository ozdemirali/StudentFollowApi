using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    /// <summary>
    /// Ailenin gelir durumu iyi kötü vb.- How does famimlt get money good-bad etc.
    /// </summary>
    public class FamilyIncomeStatus
    {
        public byte Id { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }
    }
}