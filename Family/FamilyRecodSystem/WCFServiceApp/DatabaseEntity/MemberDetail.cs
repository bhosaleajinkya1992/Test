//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFServiceApp.DatabaseEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class MemberDetail
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberMiddleName { get; set; }
        public string MemberLastName { get; set; }
        public Nullable<int> Suffix { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public int ApplicantId { get; set; }
        public int RelationId { get; set; }
    }
}
