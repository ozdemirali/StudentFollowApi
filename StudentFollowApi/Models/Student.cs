using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string NameAndSurname { get; set; }
        
        [MaxLength(50)]
        public string UseMedicine { get; set; }
        public byte NumberOfBrotherAndSister { get; set; }
        
        [MaxLength(50)]
        public string ContinuallyIllness { get; set; } // Sürekli Hasatalığı
        
        [MaxLength(50)]
        public string PastIlness { get; set; }

        public decimal Weight { get; set; }

        public decimal Size { get; set; } //Boyu

        [MaxLength(11)]
        public string Phone { get; set; }

        [MaxLength(4)]
        public string Number { get; set; }

        [MaxLength(4)]
        public string UseProthes { get; set; }  //Kullandığı Protez

        [MaxLength(50)]
        public string PastOperation { get; set; }

        [MaxLength(50)]
        public string Accident { get; set; } //Geçirdiği Kazalar

        public decimal FamilyIncomeMoney { get; set; } // Ailenin Kazandığı Para Miktarı

        [MaxLength(50)]
        public string TypeOfDisability { get; set; } //Özür Türü

        public byte Scheck { get; set; } // Sosyal Hiz. Çocuk Esirgeme Kurumuna Tabi mi?

        [MaxLength(50)]
        public string PlaceOfBirth { get; set; } //Doğum Yeri

        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string RecordOfIdentityCard { get; set; }

        public bool RentOfHouse { get; set; }  //Evi Kira mı?

        public bool HaveOwnHouse { get; set; } //Keni Odası var mı?

        public bool Working { get; set; } //Bir İşte Çalışıyor mu?

        public bool OutsideFromFamily { get; set; } //Aile dışında evde kalan var mı?

        public bool CameFromAbroad { get; set; } //Yurt Dışından Geldi mi?

        public bool scholarship { get; set; } //Burslu mu?










    }
}