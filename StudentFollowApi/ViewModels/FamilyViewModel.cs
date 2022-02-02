using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentFollowApi.ViewModels
{
    public class FamilyViewModel
    {
        public string Id { get; set; }
        public string NameAndSurname { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public bool MatherAndFather { get; set; }
        public string DisabilitySituation { get; set; } //Engel Durumu
        public string ContinuallyIllness { get; set; } //Sürekli Hastalığı
        public string Mail { get; set; }
        public bool AliveOrDead { get; set; }
        public bool TogetherOrSeparetly { get; set; }
        public byte EducationId { get; set; }
        public byte JobId { get; set; }
    }
}