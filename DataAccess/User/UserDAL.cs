using System;
using System.Collections.Generic;
using Falcon.Entity.User;
using System.Data;
using System.Data.SqlClient;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Core.Enum;


namespace Falcon.DataAccess.User
{
    public class UserDAL
    {

        private string connectionstring = ConnectionHandler.GetConnectionString();
        
        #region "Role Shell"
        public List<EUserShellModuleRole> GetRoleShellByUserID( int inputMode,String filterString)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = inputMode;
            arParms[1] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[1].Value = filterString;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getroleshell", arParms);

            List<EUserShellModuleRole> returnusershellrole = new List<EUserShellModuleRole>();
            returnusershellrole = ParseUserShellRoleDataSet(tempdataset);
            return returnusershellrole;
        }

        private List<EUserShellModuleRole> ParseUserShellRoleDataSet(DataSet usershellroledataset)
        {
            List<EUserShellModuleRole> returnusershellrole = new List<EUserShellModuleRole>();

            for (int count = 0; count < usershellroledataset.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EUserShellModuleRole usershellrole = new EUserShellModuleRole();

                    usershellrole.UserID        = Convert.ToString(usershellroledataset.Tables[0].Rows[count]["UserID"]);
                    usershellrole.ShellID       = Convert.ToString(usershellroledataset.Tables[0].Rows[count]["ShellID"]);
                    usershellrole.ShellType     = Convert.ToString(usershellroledataset.Tables[0].Rows[count]["ShellType"]);
                    usershellrole.ShellName     = Convert.ToString(usershellroledataset.Tables[0].Rows[count]["Name"]);
                    usershellrole.RoleID        = Convert.ToString(usershellroledataset.Tables[0].Rows[count]["RoleID"]);
                    usershellrole.RoleName      = Convert.ToString(usershellroledataset.Tables[0].Rows[count]["RoleAlias"]); //changed to RoleAlias for "hack"
                    usershellrole.DefaultPage   = Convert.ToString(usershellroledataset.Tables[0].Rows[count]["DefaultPage"]);
                    usershellrole.IsDefault     = Convert.ToBoolean(usershellroledataset.Tables[0].Rows[count]["IsDefault"]);
                    usershellrole.UserName      = Convert.ToString(usershellroledataset.Tables[0].Rows[count]["UserName"]);
                    usershellrole.RoleShellID   = Convert.ToInt32(usershellroledataset.Tables[0].Rows[count]["RoleShellID"]);
                    usershellrole.IsDefaultRole = Convert.ToBoolean(usershellroledataset.Tables[0].Rows[count]["IsDefaultRole"]);

                    returnusershellrole.Add(usershellrole);
                }
                catch
                {
                    
                }
            }
            return returnusershellrole;
        }

        /// <summary>
        /// this function return the modules list for a user in a shell
        /// </summary>
        /// <param name="usershellmodulerole"></param>
        /// <returns></returns>
        public List<Entity.Other.EModule> GetUserRoleModule(EUserShellModuleRole usershellmodulerole)
        { 
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt64(usershellmodulerole.UserID);
            arParms[1] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[1].Value = Convert.ToInt64(usershellmodulerole.RoleID);
            arParms[2] = new SqlParameter("@roletypeid", SqlDbType.BigInt);
            arParms[2].Value = Convert.ToInt64(usershellmodulerole.ShellID);
            arParms[3] = new SqlParameter("@roletype", SqlDbType.VarChar, 500);
            arParms[3].Value = usershellmodulerole.ShellType;
           
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getuserrolemodule", arParms);

            List<Entity.Other.EModule> returnmodule = new List<Entity.Other.EModule>();
            returnmodule = ParseUserRoleModuleDataSet(tempdataset);
            return returnmodule;
        }
        /// <summary>
        /// this function parse the module dataset in the modules
        /// </summary>
        /// <param name="userrolemoduledataset"></param>
        /// <returns></returns>
        private List<Entity.Other.EModule> ParseUserRoleModuleDataSet(DataSet userrolemoduledataset)
        {
            List<Entity.Other.EModule> returnuserrolemodule = new List<Entity.Other.EModule>();
            if (userrolemoduledataset == null)
                return returnuserrolemodule;

            if (userrolemoduledataset.Tables.Count < 1)
                return returnuserrolemodule;

            for (int count = 0; count < userrolemoduledataset.Tables[0].Rows.Count; count++)
            {
                Entity.Other.EModule userrolemodule = new Entity.Other.EModule();

                userrolemodule.AccessType = (EAccessType)Convert.ToInt32(userrolemoduledataset.Tables[0].Rows[count]["AccessID"]);
                userrolemodule.ModuleID = Convert.ToInt32(userrolemoduledataset.Tables[0].Rows[count]["ModuleID"]);
                userrolemodule.Name = Convert.ToString(userrolemoduledataset.Tables[0].Rows[count]["Name"]);
                userrolemodule.ParentModuleID = Convert.ToInt32(userrolemoduledataset.Tables[0].Rows[count]["ParentModuleID"]);
                userrolemodule.TargetURL = Convert.ToString(userrolemoduledataset.Tables[0].Rows[count]["TargetURL"]);

                if (userrolemoduledataset.Tables[0].Rows[count]["MenuOrder"] != DBNull.Value)
                    userrolemodule.MenuOrder = Convert.ToInt32(userrolemoduledataset.Tables[0].Rows[count]["MenuOrder"]);

                returnuserrolemodule.Add(userrolemodule);
            }
            return returnuserrolemodule;
        }

        
        private List<Entity.Other.ERole> ParseShellRoleDataSet(DataSet shellroledataset)
        {
            List<Entity.Other.ERole> returnshellrole = new List<Entity.Other.ERole>();

            for (int count = 0; count < shellroledataset.Tables[0].Rows.Count; count++)
            {
                try
                {

                    Entity.Other.ERole shellrole = new Entity.Other.ERole();

                    shellrole.RoleID = Convert.ToInt32(shellroledataset.Tables[0].Rows[count]["RoleId"]);
                    shellrole.Name = Convert.ToString(shellroledataset.Tables[0].Rows[count]["Name"]);
                    returnshellrole.Add(shellrole);

                }
                catch
                {

                }
            }
            return returnshellrole;
        }

        public List<Entity.Other.ERole> GetShellAllRole(String shelltype)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@shell", SqlDbType.VarChar, 500);
            arParms[0].Value = shelltype;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getshellallrole", arParms);
            List<Entity.Other.ERole> returnrole = new List<Entity.Other.ERole>();
            returnrole = ParseShellRoleDataSet(tempdataset);
            return returnrole;
        }

        public List<Entity.Other.EModule> GetRoleAllModule(Int32 roleid)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@roleid", SqlDbType.Int );
            arParms[0].Value = roleid;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getroleallmodule", arParms);
            List<Entity.Other.EModule> returnmodule = new List<Entity.Other.EModule>();
            returnmodule = ParseUserRoleModuleDataSet(tempdataset);
            return returnmodule;
        }

        public List<Entity.Other.EModule> GetModuleAllSubModule(Int32 moduleid,Int32 roleid)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@moduleid", SqlDbType.Int);
            arParms[0].Value = moduleid;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[1].Value = roleid;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmoduleallsubmodule", arParms);
            List<Entity.Other.EModule> returnmodule = new List<Entity.Other.EModule>();
            returnmodule = ParseUserRoleModuleDataSet(tempdataset);
            return returnmodule;
        }

        public Int64 SaveRoleModuleAccess(Int64 roleid, Int64 moduleid, Int32 accessid, int mode)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[0].Value = roleid;
            arParms[1] = new SqlParameter("@moduleid", SqlDbType.BigInt);
            arParms[1].Value = moduleid;
            arParms[2] = new SqlParameter("@accessid", SqlDbType.Int );
            arParms[2].Value = accessid;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = mode;
            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saverolemoduleaccess", arParms);
            returnvalue = (Int64)arParms[4].Value;
            return returnvalue;
        }

        public List<EUserShellModuleRole> GetRolesForUserManagement(string username, int roleId, string organization, string userroleid, string franchiseeid)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            
            arParms[0] = new SqlParameter("@username", SqlDbType.NVarChar, 500);
            arParms[0].Value = username;
            
            arParms[1] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[1].Value = roleId;

            arParms[2] = new SqlParameter("@organization", SqlDbType.NVarChar, 500);
            arParms[2].Value = organization;

            arParms[3] = new SqlParameter("@userroleid", SqlDbType.Int);
            arParms[3].Value = Convert.ToInt32(userroleid);

            arParms[4] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            if (franchiseeid == "")
                arParms[4].Value = DBNull.Value;
            else
                arParms[4].Value = Convert.ToInt64(franchiseeid);

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getuser", arParms);
           
            List<EUserShellModuleRole> returnusershellrole = new List<EUserShellModuleRole>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EUserShellModuleRole usershellrole = new EUserShellModuleRole();

                usershellrole.UserID = dr["UserID"].ToString();
                usershellrole.UserName = dr["UserName"].ToString();
                usershellrole.Email = dr["Email"].ToString();
                usershellrole.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                usershellrole.LoginName = dr["LoginID"].ToString();
                usershellrole.HintQuestion = dr["HintQuestion"].ToString();
                usershellrole.HintAnswer = dr["HintAnswer"].ToString();
                usershellrole.IsLocked = Convert.ToBoolean(dr["IsLocked"].ToString());
                returnusershellrole.Add(usershellrole);
            }

            return returnusershellrole;
        }

        public List<Entity.Other.EUser> GetUserPersonalDetails(string strEmail)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@email", SqlDbType.VarChar, 500);
            arParms[0].Value = strEmail;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "[usp_UI_getUserPersonalDetails]", arParms);

            return ParseUserDetail(tempdataset);
        }

        private List<Entity.Other.EUser> ParseUserDetail(DataSet dsUser)
        {
            List<Entity.Other.EUser> objUserDetail = new List<Entity.Other.EUser>();
            if (dsUser == null)
                return objUserDetail;

            DataTable dtUser = dsUser.Tables[0];
            DataTable dtAddress = dsUser.Tables[1];

            for (int count = 0; count < dtUser.Rows.Count; count++)
            {
                try
                {
                    Entity.Other.EUser objUser = new Entity.Other.EUser();
                    objUser.UserID = Convert.ToInt32(dtUser.Rows[count]["UserID"]);
                    objUser.FirstName = Convert.ToString(dtUser.Rows[count]["FirstName"]);
                    objUser.MiddleName = Convert.ToString(dtUser.Rows[count]["MiddleName"]);
                    objUser.LastName = Convert.ToString(dtUser.Rows[count]["LastName"]);
                    objUser.PhoneCell = Convert.ToString(dtUser.Rows[count]["PhoneCell"]);
                    objUser.PhoneHome = Convert.ToString(dtUser.Rows[count]["PhoneHome"]);
                    objUser.PhoneOffice = Convert.ToString(dtUser.Rows[count]["PhoneOffice"]);
                    objUser.EMail1 = Convert.ToString(dtUser.Rows[count]["EMail1"]);
                    objUser.EMail2 = Convert.ToString(dtUser.Rows[count]["EMail2"]);
                    objUser.DOB = Convert.ToString(dtUser.Rows[count]["DOB"]);
                    objUser.SSN = Convert.ToString(dtUser.Rows[count]["SSN"]);
                    objUser.UserName = Convert.ToString(dtUser.Rows[count]["UserName"]);
                    objUser.Password = Convert.ToString(dtUser.Rows[count]["Password"]);

                    objUser.HomeAddress = new Entity.Other.EAddress();
                    objUser.HomeAddress.Address1 = Convert.ToString(dtAddress.Rows[count]["Address1"]);
                    objUser.HomeAddress.Address2=Convert.ToString(dtAddress.Rows[count]["Address2"]);
                    objUser.HomeAddress.City=Convert.ToString(dtAddress.Rows[count]["CityName"]);
                    objUser.HomeAddress.CityID = Convert.ToInt32(dtAddress.Rows[count]["CityID"]);
                    objUser.HomeAddress.StateID = Convert.ToInt32(dtAddress.Rows[count]["StateID"]);
                    objUser.HomeAddress.CountryID = Convert.ToInt32(dtAddress.Rows[count]["CountryID"]);
                    objUser.HomeAddress.Zip = Convert.ToString(dtAddress.Rows[count]["ZipCode"]);
                    objUser.HomeAddress.ZipID = Convert.ToInt32(dtAddress.Rows[count]["ZipID"]);

                    objUserDetail.Add(objUser);
                }
                catch
                {
                }
            }
            return objUserDetail;
        }

        public void UpdateUserDefaultRole(Int32 userId, int roleid)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userId;

            arParms[1] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[1].Value = roleid;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_updateuserdefaultrole", arParms);
        }
        

        /// <summary>
        /// To be used in user role management
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public Int64 RemoveUserRole(Int32 userID, int roleID)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userID;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[1].Value = roleID;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removeuserrole", arParms);
            returnvalue = (Int64)arParms[2].Value;

            return returnvalue;
        }

        public DataSet GetUserListByRoleNameAndOrganisationName(string rolename, string organisation)
        {
            DataSet ds = new DataSet();
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@rolename", SqlDbType.VarChar, 500);
            arParms[0].Value = rolename;
            arParms[1] = new SqlParameter("@Organisationname", SqlDbType.VarChar, 500);
            arParms[1].Value = organisation;
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getuserlistbyroleAndorganisation", arParms);
            return ds;
        }

        /// <summary>
        /// To Disable User from User Role Management
        /// </summary>
        /// <param name="userID"></param>
        public void DisableUser(Int32 userID)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userID;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removeuser", arParms);
        }

        /// <summary>
        /// To Enable User from User Role Management
        /// </summary>
        /// <param name="userID"></param>
        public void EnableUser(Int32 userID)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userID;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_enableuser", arParms);
        }
         
         
        public void UpdateUserRoleAndPage(int roleid, Int64 userid, string pageurl)
        {
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[0].Value = roleid;

            arParms[1] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[1].Value = userid;

            arParms[2] = new SqlParameter("@pageurl", SqlDbType.VarChar, 500);
            arParms[2].Value = pageurl;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_SaveUserSession", arParms);
        }

        #endregion
        //Moved these functions from Quick Data access to DAL.
        
        public Int64 SaveClient(string strIpAddress, string strAction)
        {
            var arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@IpAddress", SqlDbType.VarChar, 50) {Value = strIpAddress};

            arParms[1] = new SqlParameter("@Action", SqlDbType.VarChar, 20) {Value = strAction};

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt) {Direction = ParameterDirection.Output};

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveClient", arParms);
            
            return Convert.ToInt64(arParms[2].Value);
        }

        public Int64 CheckForLogin(string strEmail)
        {
        
            var arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@email", SqlDbType.VarChar, 500) {Value = strEmail};

            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt) {Direction = ParameterDirection.Output};
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UI_checkforlogin", arParms);
            return Convert.ToInt64(arParms[1].Value);

        }

        public string CheckForLoginByCustomerId(long lngCustomerId)
        {
            var arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@customerid", SqlDbType.BigInt) {Value = lngCustomerId};

            arParms[1] = new SqlParameter("@userid", SqlDbType.VarChar, 500) {Direction = ParameterDirection.Output};

            SqlHelper.ExecuteScalar(connectionstring, CommandType.StoredProcedure, "usp_UI_checkforlogin_bycustomerid", arParms);
            
            return Convert.ToString(arParms[1].Value);

        }
        public string CheckForLoginByEmail(string strEmail)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@email", SqlDbType.VarChar, 500) {Value = strEmail};
            arParms[1] = new SqlParameter("@userid", SqlDbType.VarChar, 500) {Direction = ParameterDirection.Output};
            SqlHelper.ExecuteScalar(connectionstring, CommandType.StoredProcedure, "usp_UI_checkforlogin_byemail", arParms);
            return Convert.ToString(arParms[1].Value);
        }
        public DataSet GetClient(string strIpAddress)
        {
            var arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@IpAddress", SqlDbType.VarChar, 50) {Value = strIpAddress};

            DataSet ds = SqlHelper.ExecuteDataset(connectionstring, "usp_EnableDisableClient", arParms);

            return ds;
        }
        public void DeleteClient(string strIpAddress)
        {
            var arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@IpAddress", SqlDbType.VarChar, 50) {Value = strIpAddress};

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_DeleteClient", arParms);

        }

        //public DataSet ChooseSecurityQuestion(string strEmail,int intQues)
        public DataSet ChooseSecurityQuestion(string strEmail)
        {
            var arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@email", SqlDbType.VarChar, 500) {Value = strEmail};

            //arParms[1] = new SqlParameter("@ques", SqlDbType.Int);
            //arParms[1].Value = intQues;
            return SqlHelper.ExecuteDataset(connectionstring, "usp_UI_choosesecurityquestion", arParms); 
        }
    }
}
