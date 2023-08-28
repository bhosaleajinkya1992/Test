using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceApp.DatabaseEntity;
using WCFServiceApp.Model;

namespace WCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginRegistrationService" in both code and config file together.
    [ServiceContract]
    public interface ILoginRegistrationService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        //int CheckLogin(string userName, string password);
        UserDetail CheckLogin(string userName, string password);

        [OperationContract]
        int Register(string  userName,string email, string password, string userType);
    }

    [DataContract]
    public class RegistrationDetails
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string UserType { get; set; }
    }
}
