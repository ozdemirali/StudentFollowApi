using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.ViewModels
{
    public class FilterViewModel
    {
        [MaxLength(11)]
        public string Id { get; set; }
        public byte WhitWhomLive { get; set; }
        public byte HowToGetSchool { get; set; }
        public byte TypeOfDisability { get; set; }
        public byte SiblingCount { get; set; }
        public decimal FamilyIncomeMoney { get; set; }
        public bool RentOfHouse { get; set; }
        public bool Working { get; set; }
        public bool OutsideFromFamily { get; set; }
        public bool HaveOwnRoom { get; set; }
        public bool CameFromAbroad { get; set; }
        public bool Scheck { get; set; }
        public bool IsDeleted { get; set; }




    }
}