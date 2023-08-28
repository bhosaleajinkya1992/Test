using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Web.Services;
using WCFServiceApp.DatabaseEntity;
using WCFServiceApp.Model;

namespace WCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MemberService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MemberService.svc or MemberService.svc.cs at the Solution Explorer and start debugging.
    public class MemberService : IMemberService
    {
        public void DoWork()
        {
        }
        [WebMethod]
        public List<RelationMst> GetRelations()
        {
            using (FamilyDBEntities familyDB = new FamilyDBEntities())
            {
                List<RelationMst> lstRelation = new List<RelationMst>();
                lstRelation = familyDB.RelationMsts.ToList();

                return lstRelation;
            }
        }

        [WebMethod]
        public List<MemberDetail> GetExistingMembers(int id)
        {
            using (FamilyDBEntities familyDB = new FamilyDBEntities())
            {
                List<MemberDetail> memberList = new List<MemberDetail>();
                var applicantId = familyDB.Applicants.Where(a => a.UserId == id).Select(a=>a.ApplicantId).FirstOrDefault();
                if (applicantId!=0)
                {
                    memberList = familyDB.MemberDetails.Where(m=>m.ApplicantId == applicantId).ToList();
                    //foreach (var item in members)
                    //{
                    //    memberList.Add(item);
                    //}
                }
                //else
                //{
                //    return memberList;
                //}
                return memberList;
            }
        }

        [WebMethod]
        public int CreateOrGetApplicantId(int userId)
        {
            using (FamilyDBEntities familyDB = new FamilyDBEntities())
            {
                var applicantId = familyDB.Applicants.Where(a => a.UserId == userId).Select(a => a.ApplicantId).FirstOrDefault();
                if (applicantId != 0)
                {
                    return applicantId;
                }
                else
                {
                    Applicant applicant = new Applicant();
                    applicant.UserId = userId;
                    familyDB.Applicants.Add(applicant);
                    familyDB.SaveChanges();
                    return applicant.ApplicantId;
                }
            }
        }

        [WebMethod]
        public int SaveMembers(int memberId, string memberName, string memberMiddleName, string memberLastName, int suffix, DateTime dateOfBirth, int gender, int applicantId, int relationId)
        {
            using (FamilyDBEntities familyDB = new FamilyDBEntities())
            {
                if (memberId > 0) {
                   
                    var existingMember = familyDB.MemberDetails.Where(m => m.MemberId == memberId && m.ApplicantId == applicantId).FirstOrDefault();
                    existingMember.MemberName = memberName;
                    existingMember.MemberMiddleName = memberMiddleName;
                    existingMember.MemberLastName = memberLastName;
                    existingMember.Suffix = suffix;
                    existingMember.DateOfBirth = Convert.ToDateTime(dateOfBirth);
                    existingMember.Gender = gender;
                    existingMember.RelationId = relationId;

                    familyDB.MemberDetails.AddOrUpdate(existingMember);
                    familyDB.SaveChanges();

                    return memberId;
                }
                else
                {
                    MemberDetail memberDetail = new MemberDetail();
                    memberDetail.MemberName = memberName;
                    memberDetail.MemberMiddleName = memberMiddleName;
                    memberDetail.MemberLastName = memberLastName;
                    memberDetail.Suffix = suffix;
                    memberDetail.DateOfBirth = Convert.ToDateTime(dateOfBirth);
                    memberDetail.Gender = gender;
                    memberDetail.ApplicantId = applicantId;
                    memberDetail.RelationId = relationId;

                    familyDB.MemberDetails.Add(memberDetail);
                    familyDB.SaveChanges();

                    return memberDetail.MemberId;
                }
            }
        }
        //[WebMethod]
        //public int SaveMembers(List<MemberDetail> members, int userId)
        //{
        //    using (FamilyDBEntities familyDB = new FamilyDBEntities())
        //    {
        //        MemberDetail memberList;
        //        var applicantId = familyDB.Applicants.Where(a => a.UserId == userId).Select(a => a.ApplicantId).FirstOrDefault();
        //        if (applicantId != 0)
        //        {
        //            foreach (var item in members)
        //            {
        //                memberList = new MemberDetail();
        //                if (item.MemberId > 0)
        //                {
        //                    var memberExist = familyDB.MemberDetails.Where(m => m.MemberId == item.MemberId).FirstOrDefault();
        //                    if (memberExist!=null)
        //                    {
        //                        //memberExist.ApplicantId = applicantId;
        //                        memberExist.MemberName = item.MemberName;
        //                        memberExist.MemberMiddleName = item.MemberMiddleName;
        //                        memberExist.MemberLastName = item.MemberLastName;
        //                        memberExist.Suffix = item.Suffix;
        //                        memberExist.DateOfBirth = Convert.ToDateTime(item.DateOfBirth);
        //                        memberExist.Gender = item.Gender;

        //                        familyDB.MemberDetails.AddOrUpdate(memberExist);
        //                        familyDB.SaveChanges();
        //                    }
                            

        //                }
        //                else
        //                {
        //                    memberList.ApplicantId = applicantId;
        //                    memberList.MemberName = item.MemberName;
        //                    memberList.MemberMiddleName = item.MemberMiddleName;
        //                    memberList.MemberLastName = item.MemberLastName;
        //                    memberList.Suffix = item.Suffix;
        //                    memberList.DateOfBirth = Convert.ToDateTime(item.DateOfBirth);
        //                    memberList.Gender = item.Gender;

        //                    familyDB.MemberDetails.Add(memberList);
        //                    familyDB.SaveChanges();
        //                }
                        
        //            }
        //        }
        //        //else
        //        //{
        //        //    return memberList;
        //        //}
        //        return applicantId;
        //    }
            
        //}
    }
}
