using System;
using System.Collections.Generic;
using Falcon.App.Core.Users.ViewModels;
using Falcon.Entity.Franchisee;
using Falcon.DataAccess.Franchisee;
using Falcon.App.Core.Enum;
using Falcon.Entity.Franchisor;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.MedicalVendor;
using Falcon.DataAccess.MedicalVendor;

namespace Falcon.App.UI.Lib
{
    public class OrganizationUser
    {
        public static EFranchiseeUser GetFranchiseeUser(UserSessionModel objSession)
        {
            var franchiseeDAL = new FranchiseeDAL();
            List<EFranchiseeUser> franchiseeUserList = franchiseeDAL.GetFranchiseeUser(objSession.UserId.ToString(), objSession.UserId, Roles.FranchiseeAdmin.ToString(), 1);
            if (franchiseeUserList != null && franchiseeUserList.Count > 0)
                return franchiseeUserList[0];
            return null;
        }

        public static EFranchisorUser GetFranchisorUser(UserSessionModel objSession)
        {
            Int32 userid = Convert.ToInt32(objSession.UserId);
            Int32 shellid = Convert.ToInt32(objSession.CurrentOrganizationRole.OrganizationId);
            var franchisorDal = new FranchisorDAL();
            var franchisoruserList = franchisorDal.GetFranchisorUser(shellid.ToString(), userid.ToString(), 1);

            if (franchisoruserList != null && franchisoruserList.Count > 0)
                return franchisoruserList[0];
            return null;
        }

        public static EMedicalVendor GetMedicalVendor(UserSessionModel objSession)
        {
            
            var medicalvendorDAL = new MedicalVendorDAL();
            var listmedicalvendor = medicalvendorDAL.GetMedicalVendor(objSession.UserId.ToString(), objSession.UserId, Roles.MedicalVendorAdmin.ToString(), 1);

            if (listmedicalvendor != null && listmedicalvendor.Count > 0)
                return listmedicalvendor[0];
            return null;
        }
    }
}