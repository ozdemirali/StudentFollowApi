using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentFollowApi.ViewModels
{
    public class GuardianViewModel
    {
        public string Id { get; set; }
        public string NameAndSurname { get; set; }
        public string MobilePhone { get; set; }
        public byte ProximityId { get; set; }

    }
}