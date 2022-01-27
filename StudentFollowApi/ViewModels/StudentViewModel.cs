using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentFollowApi.ViewModels
{
    public class StudentViewModel
    {
        public string Id { get; set; }

        public string NameAndSurname { get; set; }

        public string UseMedicine { get; set; }
        public byte NumberOfBrotherAndSister { get; set; }

        public string ContinuallyIllness { get; set; } // Sürekli Hasatalığı

        public string PastIlness { get; set; }

        public decimal Weight { get; set; }

        public decimal Size { get; set; } //Boyu

        public string Phone { get; set; }

        public string Number { get; set; }

        public string UseProthes { get; set; }  //Kullandığı Protez

        public string PastOperation { get; set; }

        public string Accident { get; set; } //Geçirdiği Kazalar

        public decimal FamilyIncomeMoney { get; set; } // Ailenin Kazandığı Para Miktarı

        public string TypeOfDisability { get; set; } //Özür Türü

        public byte Scheck { get; set; } // Sosyal Hiz. Çocuk Esirgeme Kurumuna Tabi mi?

        public string PlaceOfBirth { get; set; } //Doğum Yeri

        public DateTime DateOfBirth { get; set; }

        public string RecordNumberOfIdentityCard { get; set; } // Nüfüz Cüzdanı Kayıt Tarihi

        public DateTime GivenDateOfIdentityCard { get; set; } // Nüfüz Cüzdanı Kayıt Tarihi

        public bool RentOfHouse { get; set; }  //Evi Kira mı?

        public bool HaveOwnHouse { get; set; } //Keni Odası var mı?

        public bool Working { get; set; } //Bir İşte Çalışıyor mu?

        public bool OutsideFromFamily { get; set; } //Aile dışında evde kalan var mı?

        public bool CameFromAbroad { get; set; } //Yurt Dışından Geldi mi?

        public bool Scholarship { get; set; } //Burslu mu?

        public byte HomeHeatingId { get; set; }
        public byte BranchId { get; set; }

        public byte ClassroomId { get; set; }

        public byte WhitWhomLiveId { get; set; }

        public byte BooldGroupId { get; set; }

        public byte ReligionId { get; set; }


        public byte HowToGetSchoolId { get; set; }

        public byte FamilyIncomeStatusId { get; set; }

        public string GuardianId { get; set; }
    }
}