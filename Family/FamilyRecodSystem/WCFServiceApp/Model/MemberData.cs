using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceApp.Model
{
    public class MemberData
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberMiddleName { get; set; }
        public string MemberLastName { get; set; }
        public int Suffix { get; set; }
        public string DateOfBirth { get; set; }
        public int Gender { get; set; }
        public int ApplicantId { get; set; }
    }
}