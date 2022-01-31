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
        public string Number { get; set; }

        public byte ClassroomId { get; set; }
        public byte BranchId { get; set; }
        public string Address { get; set; }
    }
}