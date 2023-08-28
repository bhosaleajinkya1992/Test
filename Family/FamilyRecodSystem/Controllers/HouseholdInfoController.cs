using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyRecodSystem.Models;
using Microsoft.Ajax.Utilities;

namespace FamilyRecodSystem.Controllers
{
    public class HouseholdInfoController : Controller
    {
        // GET: HouseholdInfo
        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult StoreDetailsIntoSession(MemberDetails memberDetails)
        {
            List<MemberDetails> memberData;
            if (Session["MemberData"]!=null)
            {
                memberData = (List<MemberDetails>)Session["MemberData"];
            }
            else
            {
                memberData = new List<MemberDetails>();
            }
            memberData.Add(new MemberDetails() {MemberId = memberDetails.MemberId, MemberName=memberDetails.MemberName, MemberMiddleName = memberDetails.MemberMiddleName, MemberLastName = memberDetails.MemberLastName, Suffix = memberDetails.Suffix, DateOfBirth = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(memberDetails.DateOfBirth).ToShortDateString()), Gender = memberDetails.Gender, RelationId = memberDetails.RelationId } );
            Session["MemberData"]= memberData;

            return Json("Success");
        }

        public JsonResult LoadExistingMembers(int userId)
        {
            try
            {
                ServiceRef_MemberService.MemberServiceClient memberServiceClient = new ServiceRef_MemberService.MemberServiceClient();
                List<MemberDetails> memberData = new List<MemberDetails>(); ;
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

        public JsonResult SaveMembers()
        {
            try
            {
                ServiceRef_MemberService.MemberServiceClient memberServiceClient = new ServiceRef_MemberService.MemberServiceClient();
                List<MemberDetails> lstMember = (List<MemberDetails>)Session["MemberData"];

                if (lstMember.Count() >0 )
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
                throw new Exception("Error occured while saving member(s): " + ex.Message);
            }
        }
    }
}