using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentFollowApi.ViewModels
{
    public class StudentDetailViewModel
    {
        public string StudentId { get; set; }
        public string UseMedicine { get; set; }
        public byte NumberOfBrotherAndSister { get; set; }
        public string ContinuallyIllness { get; set; } // Sürekli Hasatalığı
        public string PastIlness { get; set; }
        public decimal Weight { get; set; }
        public decimal Size { get; set; } //Boyu
        public string UseProthes { get; set; }  //Kullandığı Protez
        public string PastOperation { get; set; }
        public string Accident { get; set; } //Geçirdiği Kazalar
        public decimal FamilyIncomeMoney { get; set; } // Ailenin Kazandığı Para Miktarı
       
        public bool Scheck { get; set; } // Sosyal Hiz. Çocuk Esirgeme Kurumuna Tabi mi?
        public string PlaceOfBirth { get; set; } //Doğum Yeri
        public DateTime DateOfBirth { get; set; }
        public string RecordNumberOfIdentityCard { get; set; }
        public DateTime GivenDateOfIdentityCard { get; set; }
        public bool RentOfHouse { get; set; }  //Evi Kira mı?
        public bool HaveOwnRoom { get; set; } //Keni Odası var mı?
        public bool Working { get; set; } //Bir İşte Çalışıyor mu?
        public bool OutsideFromFamily { get; set; } //Aile dışında evde kalan var mı?
        public bool CameFromAbroad { get; set; } //Yurt Dışından Geldi mi?
        public bool Scholarship { get; set; } //Burslu mu?
        public bool MartyrChild { get; set; } // Şehit Çocuğu mu?
        public byte TypeOfDisabilityId { get; set; } //Özür Türü
        public byte HomeHeatingId { get; set; }
        public byte WhitWhomLiveId { get; set; }
        public byte BloodGroupId { get; set; }
        public byte ReligionId { get; set; }
        public byte HowToGetSchoolId { get; set; }
        public byte FamilyIncomeStatusId { get; set; }
        public string GuardianId { get; set; }
        public bool IsDeleted { get; set; }
    }
}