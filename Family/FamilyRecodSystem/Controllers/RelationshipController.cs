using FamilyRecodSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyRecodSystem.Controllers
{
    public class RelationshipController : Controller
    {
        // GET: Relationship
        public ActionResult Relation()
        {
            return View();
        }

        public JsonResult LoadRelation()
        {
            try
            {
                ServiceRef_MemberService.MemberServiceClient memberServiceClient = new ServiceRef_MemberService.MemberServiceClient();
                List<RelationOptions> relationOptions = new List<RelationOptions>();
                var lstRelations = memberServiceClient.GetRelations();
                foreach (var item in lstRelations)
                {
                    relationOptions.Add(new RelationOptions() { RelationId = item.RelationId, RelationName = item.RelationName});
                }
                return Json(relationOptions, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception("Error occured while getting relations: " + ex.Message);
            }
        }
        public JsonResult LoadMembers(int userId)
        {
            try
            {
                ServiceRef_MemberService.MemberServiceClient memberServiceClient = new ServiceRef_MemberService.MemberServiceClient();
                List<MemberDetails> memberData = new List<MemberDetails>(); 
                var lstMembers = memberServiceClient.GetExistingMembers(userId);
                if (Session["MemberData"] != null)
                {
                    memberData = (List<MemberDetails>)Session["MemberData"];
                    return Json(memberData, JsonRequestBehavior.AllowGet);
                }
               
                else
                {
                    if (lstMembers.Count() > 0)
                    {
                        foreach (var item in lstMembers)
                        {
                            memberData.Add(new MemberDetails() { MemberId = item.MemberId, MemberName = item.MemberName, MemberMiddleName = item.MemberMiddleName, MemberLastName = item.MemberLastName, Suffix = (int)item.Suffix, DateOfBirth = string.Format("{0:MM/dd/yyyy}", Convert.ToString(item.DateOfBirth.ToShortDateString())), Gender = item.Gender, RelationId = item.RelationId });
                        }

                        Session["MemberData"] = memberData;
                        return Json(memberData, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        memberData = new List<MemberDetails>();
                        return Json(memberData, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error occured while getting members: " + ex.Message);
            }
        }

        public JsonResult UpdateRelation(int memberId, int relationId)
        {
            try
            {
                List<MemberDetails> updatedMemberData = new List<MemberDetails>();
                List<MemberDetails> memberData = (List<MemberDetails>)Session["MemberData"];
                foreach (var item in memberData)
                {
                    if (item.MemberId == memberId)
                    {
                        updatedMemberData.Add(new MemberDetails() { MemberId = item.MemberId, MemberName = item.MemberName, MemberMiddleName = item.MemberMiddleName, MemberLastName = item.MemberLastName, Suffix = item.Suffix, DateOfBirth = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(item.DateOfBirth).ToShortDateString()), Gender = item.Gender, RelationId = relationId });
                    }
                    else
                    {
                        updatedMemberData.Add(new MemberDetails() { MemberId = item.MemberId, MemberName = item.MemberName, MemberMiddleName = item.MemberMiddleName, MemberLastName = item.MemberLastName, Suffix = item.Suffix, DateOfBirth = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(item.DateOfBirth).ToShortDateString()), Gender = item.Gender, RelationId = item.RelationId });
                    }                    
                }
                Session["MemberData"] = updatedMemberData;
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult UpdateOrSaveRelationOfMember()
        {
            try
            {
                ServiceRef_MemberService.MemberServiceClient memberServiceClient = new ServiceRef_MemberService.MemberServiceClient();
                List<MemberDetails> lstMember = (List<MemberDetails>)Session["MemberData"];

                if (lstMember.Count() > 0)
                {
                    var applicantId = memberServiceClient.CreateOrGetApplicantId(Convert.ToInt32(Session["UserId"].ToString()));

                    foreach (var member in lstMember)
                    {
                        var memberId = memberServiceClient.SaveMembers(member.MemberId, member.MemberName, member.MemberMiddleName, member.MemberLastName, member.Suffix, Convert.ToDateTime(member.DateOfBirth), member.Gender, applicantId, member.RelationId);
                    }
                    return Json("Success");
                }
                else
                {
                    return Json("Please add memeber(s)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while saving relation of member(s): " + ex.Message);
            }
        }

        public ActionResult Confirmation()
        {
            return View();
        }
    }
}