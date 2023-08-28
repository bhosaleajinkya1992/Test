using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyRecodSystem.Models;

namespace FamilyRecodSystem.Controllers
{
    public class LoginAndRegistrationController : Controller
    {
        // GET: LoginAndRegistration
        public ActionResult Login()
        {
            Session.Clear();
            //Session["MemberData"] = null;
            //Session["UserId"] = null;
            //Session["UserType"] = null;
            return View();
        }

       
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult CheckCredentials(Login userData)
        {
            ServiceRef_LoginRegistration.LoginRegistrationServiceClient userLogin = new ServiceRef_LoginRegistration.LoginRegistrationServiceClient();

            var user = userLogin.CheckLogin(userData.UserName, userData.Password);
            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserType"] = user.UserType;
                Session["UserName"] = user.UserName;
                return Json("Login Successfully", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Invalid Credentials", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddRegistration(Registration registration)
        {
            try
            {
                ServiceRef_LoginRegistration.LoginRegistrationServiceClient userRegistration = new ServiceRef_LoginRegistration.LoginRegistrationServiceClient();

                var user = userRegistration.Register(registration.UserName, registration.Email, registration.Password, "Applicant");
                if (user != 0)
                {
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Failed to create", JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured in AddRegistration " + ex.Message);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}