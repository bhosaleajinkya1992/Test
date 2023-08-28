using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using WCFServiceApp.DatabaseEntity;
using WCFServiceApp.Model;

namespace WCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMemberService" in both code and config file together.
    [ServiceContract]
    public interface IMemberService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        List<RelationMst> GetRelations();

        [OperationContract]
        List<MemberDetail> GetExistingMembers(int id);

        [OperationContract]
        int CreateOrGetApplicantId(int userId);
        [OperationContract]
        int SaveMembers(int memberId,string memberName,string memberMiddleName,string memberLastName, int suffix, DateTime dateOfBirth, int gender, int applicantId, int relationId);
    }
}
