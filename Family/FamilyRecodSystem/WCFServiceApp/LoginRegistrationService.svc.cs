using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceApp.DatabaseEntity;
using WCFServiceApp.Model;

namespace WCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginRegistrationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginRegistrationService.svc or LoginRegistrationService.svc.cs at the Solution Explorer and start debugging.
    public class LoginRegistrationService : ILoginRegistrationService
    {
        public void DoWork()
        {
        }

        public UserDetail CheckLogin(string userName, string password)
        {
            using (FamilyDBEntities familyDB = new FamilyDBEntities())
            {

                var checkUser = familyDB.UserDetails.Where(a => a.UserName == userName && a.Password == password).FirstOrDefault();

                return checkUser;
            }
        }

        public int Register(string userName, string email, string password, string userType)
        {
            using(FamilyDBEntities familyDB = new FamilyDBEntities())
            {
                UserDetail registrationDetails = new UserDetail();
                registrationDetails.UserName = userName;
                registrationDetails.Email = email;
                registrationDetails.Password = password;
                registrationDetails.UserType = userType;
                familyDB.UserDetails.Add(registrationDetails);
                familyDB.SaveChanges();

                int userId = registrationDetails.UserId;
                return userId;
            }
        }
    }
}
