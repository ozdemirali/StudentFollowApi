using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class StudentDetail
    {

        [Key]
        [ForeignKey("Student")]
        [MaxLength(11)]
        public string StudentId { get; set; }

        [MaxLength(50)]
        public string UseMedicine { get; set; }
        public byte NumberOfBrotherAndSister { get; set; }
        
        [MaxLength(50)]
        public string ContinuallyIllness { get; set; } // Sürekli Hasatalığı
        
        [MaxLength(50)]
        public string PastIlness { get; set; }

        public decimal Weight { get; set; }

        public decimal Size { get; set; } //Boyu

        [MaxLength(50)]
        public string UseProthes { get; set; }  //Kullandığı Protez

        [MaxLength(50)]
        public string PastOperation { get; set; }

        [MaxLength(50)]
        public string Accident { get; set; } //Geçirdiği Kazalar

        public decimal FamilyIncomeMoney { get; set; } // Ailenin Kazandığı Para Miktarı

        [MaxLength(50)]
        public string TypeOfDisability { get; set; } //Özür Türü

        public bool Scheck { get; set; } // Sosyal Hiz. Çocuk Esirgeme Kurumuna Tabi mi?

        [MaxLength(50)]
        public string PlaceOfBirth { get; set; } //Doğum Yeri

        public DateTime DateOfBirth { get; set; }

        [MaxLength(9)]
        public string RecordNumberOfIdentityCard { get; set; }
        public DateTime GivenDateOfIdentityCard { get;set; }

        public bool RentOfHouse { get; set; }  //Evi Kira mı?

        public bool HaveOwnHouse { get; set; } //Keni Odası var mı?

        public bool Working { get; set; } //Bir İşte Çalışıyor mu?

        public bool OutsideFromFamily { get; set; } //Aile dışında evde kalan var mı?

        public bool CameFromAbroad { get; set; } //Yurt Dışından Geldi mi?

        public bool Scholarship { get; set; } //Burslu mu?

        public byte HomeHeatingId { get; set; }
        public HomeHeating HomeHeating { get; set; }

        public byte WhitWhomLiveId { get; set; }
        public WhitWhomLive WhitWhomLive { get; set; }

        public byte BloodGroupId { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public byte ReligionId { get; set; }
        public Religion Religion { get; set; }


        public byte HowToGetSchoolId { get; set; }
        public HowToGetSchool HowToGetSchool { get; set; }

        public byte FamilyIncomeStatusId { get; set; }
        public FamilyIncomeStatus FamilyIncomeStatus { get; set; }

        [MaxLength(11)]
        public string GuardianId { get; set; }
        public Guardian Guardian { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Student Student { get; set; }


    }
}