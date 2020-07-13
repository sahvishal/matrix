using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.Entity.Franchisee;
using System.Data;
using System.Data.SqlClient;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;


namespace Falcon.DataAccess.Franchisee
{
    public class FranchiseeDAL
    {
        private string connectionstring = ConnectionHandler.GetConnectionString();

        #region "Franchisee"
        

        /// <summary>
        /// Get all Sales Rep. 
        /// </summary>
        /// <returns>key-value pair list</returns>
        public List<EKeyValuepair> GetSalesRep(Int64 FranchiseeID)
        {
            DataSet tempdataset = new DataSet();

            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@FranchiseeID", SqlDbType.BigInt);
            arParms[0].Value = FranchiseeID;

            arParms[1] = new SqlParameter("@mode", SqlDbType.BigInt);
            arParms[1].Value = 1;

            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getsalesrepAll", arParms);

            List<Entity.Other.EKeyValuepair> returnKeyValue = new List<Entity.Other.EKeyValuepair>();
            returnKeyValue = ParseKeyValueDataSet(tempdataset);
            return returnKeyValue;
        }

        /// <summary>
        /// Get list of all sales rep with id
        /// </summary>
        /// <returns>key-value pair list</returns>
        public List<EKeyValuepair> GetSalesRepKeyValue()
        {
            SqlParameter[] arParms = new SqlParameter[0];
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getallsalesrep", arParms);

            List<Entity.Other.EKeyValuepair> returnKeyValue = new List<Entity.Other.EKeyValuepair>();
            returnKeyValue = ParseKeyValueDataSet(tempdataset);
            return returnKeyValue;
        }

        /// <summary>
        /// Get list of all prospect type with id
        /// </summary>
        /// <returns>key-value pair list</returns>
        public List<EKeyValuepair> GetProspectTypeKeyValue()
        {
            SqlParameter[] arParms = new SqlParameter[0];
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getallprospecttype", arParms);

            List<Entity.Other.EKeyValuepair> returnKeyValue = new List<Entity.Other.EKeyValuepair>();
            returnKeyValue = ParseKeyValueDataSet(tempdataset);
            return returnKeyValue;
        }

        private List<EKeyValuepair> ParseKeyValueDataSet(DataSet keyValueDataSet)
        {
            List<Entity.Other.EKeyValuepair> returnKeyValue = new List<Entity.Other.EKeyValuepair>();

            for (int count = 0; count < keyValueDataSet.Tables[0].Rows.Count; count++)
            {

                Entity.Other.EKeyValuepair keyValue = new Entity.Other.EKeyValuepair();

                keyValue.Key = Convert.ToInt32(keyValueDataSet.Tables[0].Rows[count]["ID"]);
                keyValue.Value = keyValueDataSet.Tables[0].Rows[count]["Value"].ToString();
                returnKeyValue.Add(keyValue);

            }
            return returnKeyValue;
        }

        public Int64 AddFranchiseePublic(EFranchiseeApplication objFranchisee)
        {
            SqlParameter[] arParms = new SqlParameter[36];
            arParms[0] = new SqlParameter("@businessname", SqlDbType.VarChar, 500);
            arParms[0].Value = objFranchisee.Application.BusinessName;
            arParms[1] = new SqlParameter("@businessphone", SqlDbType.VarChar, 500);
            arParms[1].Value = objFranchisee.BusinessPhone;
            arParms[2] = new SqlParameter("@businessfax", SqlDbType.VarChar, 500);
            arParms[2].Value = objFranchisee.BusinessFax;

            arParms[3] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
            arParms[3].Value = objFranchisee.Application.BusinessAddress.Address1;
            arParms[4] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[4].Value = objFranchisee.Application.BusinessAddress.Address2;
            arParms[5] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[5].Value = objFranchisee.Application.BusinessAddress.CityID;
            arParms[6] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[6].Value = objFranchisee.Application.BusinessAddress.StateID;
            arParms[7] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[7].Value = objFranchisee.Application.BusinessAddress.CountryID;
            arParms[8] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[8].Value = objFranchisee.Application.BusinessAddress.ZipID;

            arParms[9] = new SqlParameter("@billaddress1", SqlDbType.VarChar, 500);
            arParms[9].Value = objFranchisee.BillingAddress.Address1;
            arParms[10] = new SqlParameter("@billaddress2", SqlDbType.VarChar, 500);
            arParms[10].Value = objFranchisee.BillingAddress.Address2;
            arParms[11] = new SqlParameter("@billcityid", SqlDbType.BigInt);
            arParms[11].Value = objFranchisee.BillingAddress.CityID;
            arParms[12] = new SqlParameter("@billstateid", SqlDbType.BigInt);
            arParms[12].Value = objFranchisee.BillingAddress.StateID;
            arParms[13] = new SqlParameter("@billcountryid", SqlDbType.BigInt);
            arParms[13].Value = objFranchisee.BillingAddress.CountryID;
            arParms[14] = new SqlParameter("@billzipid", SqlDbType.BigInt);
            arParms[14].Value = objFranchisee.BillingAddress.ZipID;

            arParms[15] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[15].Value = objFranchisee.Application.FirstName;
            arParms[16] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[16].Value = objFranchisee.Application.MiddleName;
            arParms[17] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[17].Value = objFranchisee.Application.LastName;
            arParms[18] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[18].Value = objFranchisee.Application.PhoneHome;
            arParms[19] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[19].Value = objFranchisee.Application.PhoneOffice;
            arParms[20] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[20].Value = objFranchisee.Application.PhoneCell;
            arParms[21] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[21].Value = objFranchisee.Application.Email1;
            arParms[22] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[22].Value = objFranchisee.Application.Email2;
            arParms[23] = new SqlParameter("@caddress1", SqlDbType.VarChar, 500);
            arParms[23].Value = objFranchisee.Application.ContactAddress.Address1;
            arParms[24] = new SqlParameter("@caddress2", SqlDbType.VarChar, 500);
            arParms[24].Value = objFranchisee.Application.ContactAddress.Address2;
            arParms[25] = new SqlParameter("@ccityid", SqlDbType.BigInt);
            arParms[25].Value = objFranchisee.Application.ContactAddress.CityID;
            arParms[26] = new SqlParameter("@cstateid", SqlDbType.BigInt);
            arParms[26].Value = objFranchisee.Application.ContactAddress.StateID;
            arParms[27] = new SqlParameter("@ccountryid", SqlDbType.BigInt);
            arParms[27].Value = objFranchisee.Application.ContactAddress.CountryID;
            arParms[28] = new SqlParameter("@czipid", SqlDbType.BigInt);
            arParms[28].Value = objFranchisee.Application.ContactAddress.ZipID;
            arParms[29] = new SqlParameter("@refname1", SqlDbType.VarChar, 500);
            arParms[29].Value = objFranchisee.Application.ReferenceName1;
            arParms[30] = new SqlParameter("@refemail1", SqlDbType.VarChar, 50);
            arParms[30].Value = objFranchisee.Application.ReferenceEmail1;
            arParms[31] = new SqlParameter("@refname2", SqlDbType.VarChar, 500);
            arParms[31].Value = objFranchisee.Application.ReferenceName2;
            arParms[32] = new SqlParameter("@refemail2", SqlDbType.VarChar, 50);
            arParms[32].Value = objFranchisee.Application.ReferenceEmail2;
            arParms[33] = new SqlParameter("@refname3", SqlDbType.VarChar, 500);
            arParms[33].Value = objFranchisee.Application.ReferenceName3;
            arParms[34] = new SqlParameter("@refemail3", SqlDbType.VarChar, 50);
            arParms[34].Value = objFranchisee.Application.ReferenceEmail3;

            arParms[35] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[35].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UI_savefranchisee", arParms);
            Int64 returnvalue = new Int64();

            returnvalue = Convert.ToInt64(arParms[35].Value);
            return returnvalue;
        }
        #endregion

        #region "FranchiseeUser"
        public Int64 SaveFranchiseeUser(EFranchiseeUser franchiseeuser, int Mode, string Shell)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[25];
            arParms[0] = new SqlParameter("@franchiseeuserid", SqlDbType.BigInt);
            arParms[0].Value = franchiseeuser.FranchiseeUserID;
            arParms[1] = new SqlParameter("@userid1", SqlDbType.BigInt);
            arParms[1].Value = franchiseeuser.User.UserID;
            arParms[2] = new SqlParameter("@addressid", SqlDbType.BigInt);
            arParms[2].Value = franchiseeuser.User.HomeAddress.AddressID;
            arParms[3] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[3].Value = franchiseeuser.User.HomeAddress.CityID;
            arParms[4] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[4].Value = franchiseeuser.User.HomeAddress.StateID;
            arParms[5] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[5].Value = franchiseeuser.User.HomeAddress.CountryID;
            arParms[6] = new SqlParameter("@address", SqlDbType.VarChar, 500);
            arParms[6].Value = franchiseeuser.User.HomeAddress.Address1;
            arParms[7] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[7].Value = franchiseeuser.User.FirstName;
            arParms[8] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[8].Value = franchiseeuser.User.LastName;
            arParms[9] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[9].Value = franchiseeuser.User.PhoneHome;
            arParms[10] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[10].Value = franchiseeuser.User.PhoneOffice;
            arParms[11] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[11].Value = franchiseeuser.User.PhoneCell;
            arParms[12] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[12].Value = franchiseeuser.User.EMail1;
            arParms[13] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[13].Value = franchiseeuser.User.EMail2;
            arParms[14] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[14].Value = franchiseeuser.User.HomeAddress.ZipID;

            arParms[15] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[15].Value = franchiseeuser.User.MiddleName;
            arParms[16] = new SqlParameter("@ssn", SqlDbType.VarChar, 500);
            arParms[16].Value = franchiseeuser.User.SSN;
            arParms[17] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[17].Value = franchiseeuser.User.HomeAddress.Address2;
            arParms[18] = new SqlParameter("@dob", SqlDbType.VarChar, 500);
            arParms[18].Value = franchiseeuser.User.DOB;

            arParms[19] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[19].Value = Mode;
            arParms[20] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[20].Direction = ParameterDirection.Output;

            arParms[21] = new SqlParameter("@signature", SqlDbType.VarChar, 2000);
            if (!string.IsNullOrEmpty(franchiseeuser.User.DigitalSignatureImage))
                arParms[21].Value = franchiseeuser.User.DigitalSignatureImage;
            else
                arParms[21].Value = DBNull.Value;  

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savefranchiseeuser", arParms);
            returnvalue = (Int64)arParms[20].Value;
            OtherDAL objOtherDal = new Other.OtherDAL();
            objOtherDal.UpdateShellDescription(franchiseeuser.ShellDescription, ERoleType.Franchisee.ToString(), Shell);

            SaveFranchiseeUserImages(franchiseeuser, 0, "", "", "");
            return returnvalue;

        }

        public List<EFranchiseeUser> GetFranchiseeUser(String filterString, Int64 ShellID, string strRoleType, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            arParms[2] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[2].Value = ShellID;
            arParms[3] = new SqlParameter("@roletype", SqlDbType.VarChar, 500);
            arParms[3].Value = strRoleType;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getfranchiseeuser", arParms);

            List<EFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeUser>();
            returnFranchiseeUser = ParseFranchiseeUserDataSet(tempdataset);
            return returnFranchiseeUser;
        }

        private List<EFranchiseeUser> ParseFranchiseeUserDataSet(DataSet franchiseeuserDataSet)
        {
            List<EFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeUser>();
            ISettings settings = IoC.Resolve<ISettings>();

            int intMaxPicCount = settings.MaximumPictureCount;
            foreach (DataRow row in franchiseeuserDataSet.Tables[0].Rows)
            {
                try
                {                   
                    EAddress address = new EAddress
                    {
                        Address1 = Convert.ToString(row["Address1"]),
                        Address2 = Convert.ToString(row["Address2"]),
                        CityID = Convert.ToInt32(row["CityID"]),
                        City = Convert.ToString(row["City"]),
                        CountryID = Convert.ToInt32(row["CountryID"]),
                        Country = Convert.ToString(row["Country"]),
                        StateID = Convert.ToInt32(row["StateID"]),
                        State = Convert.ToString(row["State"]),
                        Zip = Convert.ToString(row["ZipCode"])
                    };

                    var user = new EUser
                    {
                        UserID = Convert.ToInt32(row["UserID"]),
                        FirstName = Convert.ToString(row["FirstName"]),
                        MiddleName = Convert.ToString(row["MiddleName"]),
                        LastName = Convert.ToString(row["LastName"]),
                        PhoneHome = Convert.ToString(row["PhoneHome"]),
                        PhoneCell = Convert.ToString(row["PhoneCell"]),
                        PhoneOffice = Convert.ToString(row["PhoneOffice"]),
                        EMail1 = Convert.ToString(row["EMail1"]),
                        EMail2 = Convert.ToString(row["EMail2"]),
                        DOB = Convert.ToString(row["DOB"]),
                        SSN = Convert.ToString(row["SSN"]),
                        DigitalSignatureImage = Convert.ToString(row["DigitalSignature"]),
                        HomeAddress = address
                    };

                    List<string> otherpicture = new List<string>();
                    for (int icount = 1; icount < 13; icount++)
                    {
                        if (icount <= intMaxPicCount)
                        { otherpicture.Add(row["Picture" + icount].ToString()); }
                        else
                        { otherpicture.Add(string.Empty); }
                    }

                    EFranchiseeUser franchiseeuser = new EFranchiseeUser
                    {
                        FranchiseeUserID = Convert.ToInt32(row["FranchiseeUserID"]),
                        MyPicture = Convert.ToString(row["MyPicture"]),
                        TeamPicture = Convert.ToString(row["TeamPicture"]),
                        CreateDate = Convert.ToString(row["CreateDate"]),
                        OtherPictures = otherpicture,
                        ShellDescription = Convert.ToString(row["Description"]),
                        User = user,
                        Address = address
                    };

                    returnFranchiseeUser.Add(franchiseeuser);
                }
                catch (Exception)
                {
                }

            }
            return returnFranchiseeUser;
        }
        public Int64 SaveFranchiseeUserImages(EFranchiseeUser franchiseeuser, int Mode, string UserID, string Shell, string Role)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[20];
            arParms[0] = new SqlParameter("@userid1", SqlDbType.BigInt);
            arParms[0].Value = franchiseeuser.User.UserID;

            arParms[1] = new SqlParameter("@mypicture", SqlDbType.VarChar, 2000);
            if (franchiseeuser.MyPicture.Trim().Length < 1)
                arParms[1].Value = DBNull.Value;
            else
                arParms[1].Value = franchiseeuser.MyPicture;

            arParms[2] = new SqlParameter("@teampicture", SqlDbType.VarChar, 2000);
            if (franchiseeuser.TeamPicture.Trim().Length < 1)
                arParms[2].Value = DBNull.Value;
            else
                arParms[2].Value = franchiseeuser.TeamPicture;

            arParms[3] = new SqlParameter("@picture1", SqlDbType.VarChar, 2000);
            arParms[3].Value = franchiseeuser.OtherPictures[0];
            arParms[4] = new SqlParameter("@picture2", SqlDbType.VarChar, 2000);
            arParms[4].Value = franchiseeuser.OtherPictures[1];
            arParms[5] = new SqlParameter("@picture3", SqlDbType.VarChar, 2000);
            arParms[5].Value = franchiseeuser.OtherPictures[2];
            arParms[6] = new SqlParameter("@picture4", SqlDbType.VarChar, 2000);
            arParms[6].Value = franchiseeuser.OtherPictures[3];
            arParms[7] = new SqlParameter("@picture5", SqlDbType.VarChar, 2000);
            arParms[7].Value = franchiseeuser.OtherPictures[4];
            arParms[8] = new SqlParameter("@picture6", SqlDbType.VarChar, 2000);
            arParms[8].Value = franchiseeuser.OtherPictures[5];
            arParms[9] = new SqlParameter("@picture7", SqlDbType.VarChar, 2000);
            arParms[9].Value = franchiseeuser.OtherPictures[6];
            arParms[10] = new SqlParameter("@picture8", SqlDbType.VarChar, 2000);
            arParms[10].Value = franchiseeuser.OtherPictures[7];
            arParms[11] = new SqlParameter("@picture9", SqlDbType.VarChar, 2000);
            arParms[11].Value = franchiseeuser.OtherPictures[8];
            arParms[12] = new SqlParameter("@picture10", SqlDbType.VarChar, 2000);
            arParms[12].Value = franchiseeuser.OtherPictures[9];
            arParms[13] = new SqlParameter("@picture11", SqlDbType.VarChar, 2000);
            arParms[13].Value = franchiseeuser.OtherPictures[10];
            arParms[14] = new SqlParameter("@picture12", SqlDbType.VarChar, 2000);
            arParms[14].Value = franchiseeuser.OtherPictures[11];

            arParms[15] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[15].Value = UserID;
            arParms[16] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[16].Value = Shell;
            arParms[17] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[17].Value = Role;
            arParms[18] = new SqlParameter("@userroletype", SqlDbType.VarChar, 500);
            arParms[18].Value = ERoleType.Franchisee;
            arParms[19] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[19].Direction = ParameterDirection.Output;
                        
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveuserimage", arParms);
            returnvalue = (Int64)arParms[19].Value;
            return returnvalue; ;
        }
        public List<EFranchiseeFranchiseeUser> GetFranchiseeTechnician(int intFranchiseeID, int intMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = intMode;
            arParms[1] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[1].Value = intFranchiseeID;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getfranchiseetechnician", arParms);

            List<EFranchiseeFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();
            returnFranchiseeUser = ParseFranchiseeTechnicianDataSet(tempdataset);
            return returnFranchiseeUser;
        }

        public List<EFranchiseeFranchiseeUser> GetFranchiseeUserForPod(long intFranchiseeID, int intMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = intMode;
            arParms[1] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[1].Value = intFranchiseeID;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getfranchiseeuserforpod", arParms);

            List<EFranchiseeFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();
            returnFranchiseeUser = ParseFranchiseeTechnicianDataSet(tempdataset);
            return returnFranchiseeUser;
        }

        private List<EFranchiseeFranchiseeUser> ParseFranchiseeTechnicianDataSet(DataSet franchiseeuserDataSet)
        {
            List<EFranchiseeFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();

            for (int count = 0; count < franchiseeuserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EFranchiseeFranchiseeUser franchiseeuser = new EFranchiseeFranchiseeUser();

                    franchiseeuser.FranchiseeUser = new EFranchiseeUser();
                    franchiseeuser.FranchiseeUser.User = new EUser();
                    franchiseeuser.FranchiseeUser.User.UserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["UserID"]);
                    franchiseeuser.FranchiseeUser.User.FirstName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["FirstName"]);
                    franchiseeuser.FranchiseeUser.User.MiddleName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["MiddleName"]);
                    franchiseeuser.FranchiseeUser.User.LastName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["LastName"]);
                    franchiseeuser.FranchiseeUser.FranchiseeUserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeUserID"]);
                    franchiseeuser.Franchisee = new EFranchisee();
                    franchiseeuser.Franchisee.FranchiseeID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeID"]);
                    franchiseeuser.FranchiseeFranchiseeUserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeFranchiseeUserID"]);

                    if (franchiseeuserDataSet.Tables[0].Columns.Contains("RoleName"))
                        franchiseeuser.RoleType = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["RoleName"]);
                    if (franchiseeuserDataSet.Tables[0].Columns.Contains("RoleID"))
                        franchiseeuser.RoleID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["RoleID"]);
                    
                    if (franchiseeuserDataSet.Tables[0].Columns.Contains("EventRoleName"))
                        franchiseeuser.EventRoleName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["EventRoleName"]);
                    if (franchiseeuserDataSet.Tables[0].Columns.Contains("EventRoleID"))
                        franchiseeuser.EventRoleID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["EventRoleID"]);

                    returnFranchiseeUser.Add(franchiseeuser);
                }
                catch (Exception)
                {
                }

            }
            return returnFranchiseeUser;
        }

        public List<EFranchiseeFranchiseeUser> GetFranchiseeEmployeeByName(string strName, int intFranchiseeID, int intMode)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = intMode;
            arParms[1] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[1].Value = intFranchiseeID;
            arParms[2] = new SqlParameter("@filterstring", SqlDbType.VarChar, 50);
            arParms[2].Value = strName;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getfranchiseeemployee", arParms);

            List<EFranchiseeFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();
            returnFranchiseeUser = ParseFranchiseeEmployeeByNameDataSet(tempdataset);
            return returnFranchiseeUser;
        }

        private List<EFranchiseeFranchiseeUser> ParseFranchiseeEmployeeByNameDataSet(DataSet franchiseeuserDataSet)
        {
            List<EFranchiseeFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();

            for (int count = 0; count < franchiseeuserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EFranchiseeFranchiseeUser franchiseeuser = new EFranchiseeFranchiseeUser();
                    franchiseeuser.FranchiseeUser = new EFranchiseeUser();
                    franchiseeuser.FranchiseeUser.User = new EUser();
                    franchiseeuser.Franchisee = new EFranchisee();
                    franchiseeuser.RoleID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["RoleID"]);

                    franchiseeuser.RoleType = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["Role"]);
                    franchiseeuser.FranchiseeUser.FranchiseeUserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeUserID"]);
                    franchiseeuser.Franchisee.FranchiseeID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeID"]);
                    franchiseeuser.Franchisee.Name = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeName"]);

                    franchiseeuser.FranchiseeFranchiseeUserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeFranchiseeUserID"]);


                    franchiseeuser.FranchiseeUser.User.UserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["UserID"]);
                    franchiseeuser.FranchiseeUser.User.FirstName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["FirstName"]);
                    franchiseeuser.FranchiseeUser.User.MiddleName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["MiddleName"]);
                    franchiseeuser.FranchiseeUser.User.LastName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["LastName"]);




                    returnFranchiseeUser.Add(franchiseeuser);
                }
                catch (Exception)
                {
                }

            }
            return returnFranchiseeUser;
        }

        public List<EFranchiseeFranchiseeUser> GetEmployeeForFranchisor(string strName, int intFranchiseeID, int intMode)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = intMode;
            arParms[1] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[1].Value = intFranchiseeID;
            arParms[2] = new SqlParameter("@filterstring", SqlDbType.VarChar, 50);
            arParms[2].Value = strName;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getfranchiseeemployee", arParms);

            List<EFranchiseeFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();
            returnFranchiseeUser = ParseFranchiseedataSet(tempdataset);
            return returnFranchiseeUser;
        }

        /// <summary>
        ///  Get list of Sales Rep for Franchiess
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="intFranchiseeID"></param>
        /// <param name="intMode"></param>
        /// <returns></returns>
        public List<EUser> GetSalesRepForFranchisee(string strName, long intFranchiseeID, int intMode)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@username", SqlDbType.VarChar, 500);
            arParms[0].Value = strName;
            arParms[1] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            arParms[1].Value = intFranchiseeID;
            arParms[2] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[2].Value = intMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getsalesrepuser", arParms);

            List<EUser> returnEUser = new List<EUser>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EUser objEUser = new EUser();
                    objEUser.UserID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["UserId"]);
                    objEUser.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[count]["Name"]);

                    returnEUser.Add(objEUser);
                }
                catch (Exception)
                {
                }
            }
            return returnEUser;
        }

        private List<EFranchiseeFranchiseeUser> ParseFranchiseedataSet(DataSet franchiseeuserDataSet)
        {
            List<EFranchiseeFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();

            for (int count = 0; count < franchiseeuserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EFranchiseeFranchiseeUser franchiseeuser = new EFranchiseeFranchiseeUser();
                    franchiseeuser.FranchiseeUser = new EFranchiseeUser();
                    franchiseeuser.FranchiseeUser.User = new EUser();
                    franchiseeuser.Franchisee = new EFranchisee();
                    franchiseeuser.RoleID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["RoleID"]);

                    franchiseeuser.RoleType = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["Role"]);
                    franchiseeuser.FranchiseeUser.FranchiseeUserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeUserID"]);
                    franchiseeuser.Franchisee.FranchiseeID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeID"]);
                    franchiseeuser.Franchisee.Name = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeName"]);

                    franchiseeuser.FranchiseeFranchiseeUserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeFranchiseeUserID"]);


                    franchiseeuser.FranchiseeUser.User.UserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["UserID"]);
                    franchiseeuser.FranchiseeUser.User.FirstName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["FirstName"]);
                    franchiseeuser.FranchiseeUser.User.MiddleName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["MiddleName"]);
                    franchiseeuser.FranchiseeUser.User.LastName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["LastName"]);




                    returnFranchiseeUser.Add(franchiseeuser);
                }
                catch (Exception)
                {
                }

            }
            return returnFranchiseeUser;
        }


        #endregion

        #region "FranchiseeFranchiseeUser"

        public List<EFranchiseeFranchiseeUser> ContactFranchisee(String filterString, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getfranchiseecontact", arParms);

            List<EFranchiseeFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();
            returnFranchiseeUser = ParseContactFranchiseeDataSet(tempdataset);
            return returnFranchiseeUser;
        }
        private List<EFranchiseeFranchiseeUser> ParseContactFranchiseeDataSet(DataSet franchiseeuserDataSet)
        {
            List<EFranchiseeFranchiseeUser> returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();

            for (int count = 0; count < franchiseeuserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EFranchiseeFranchiseeUser franchiseefranchiseeuser = new EFranchiseeFranchiseeUser();
                    EFranchiseeUser franchiseeuser = new EFranchiseeUser();
                    EUser user = new Entity.Other.EUser();
                    EAddress address = new EAddress();
                    EFranchisee franchisee = new EFranchisee();
                    franchisee.Name = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["BusinessName"]);
                    franchisee.HasPod = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["HasPod"]);
                    franchiseefranchiseeuser.FranchiseeFranchiseeUserID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeFranchiseeUserID"]);
                    user.FirstName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["FirstName"]);
                    user.LastName = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["LastName"]);
                    user.PhoneOffice = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["PhoneOffice"]);
                    user.EMail1 = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["EMail1"]);

                    address.Address1 = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["Address1"]);
                    address.Address2 = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["Address2"]);
                    address.CityID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["CityID"]);
                    address.City = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["City"]);
                    address.CountryID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["CountryID"]);
                    address.Country = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["Country"]);
                    address.StateID = Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["StateID"]);
                    address.State = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["State"]);
                    address.Zip = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["ZipCode"]);

                    franchiseefranchiseeuser.Franchisee = franchisee;
                    franchiseeuser.User = user;
                    user.HomeAddress = address;
                    franchiseeuser.Address = address;
                    franchiseefranchiseeuser.FranchiseeUser = franchiseeuser;
                    returnFranchiseeUser.Add(franchiseefranchiseeuser);
                }
                catch (Exception)
                {
                }

            }
            return returnFranchiseeUser;
        }

        public List<EEvent> GetSalesRepEventForCalendar(Int32 intSalesRepID, string strStartDate, string strEndDate, Int16 mode)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt64(intSalesRepID);
            arParms[1] = new SqlParameter("@startdate", SqlDbType.VarChar, 30);
            arParms[1].Value = strStartDate;
            arParms[2] = new SqlParameter("@enddate", SqlDbType.VarChar, 30);
            arParms[2].Value = strEndDate;
            arParms[3] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[3].Value = mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getSeminarForCalendar", arParms);
            List<EEvent> objListEvent = new List<EEvent>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EEvent objevent = new EEvent();
                    objevent.EventID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["EventID"]);
                    objevent.Name = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventName"]);
                    objevent.EventDate = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventDate"]);
                    objevent.EventStartTime = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventStartTime"]);
                    objevent.EventEndTime = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventEndTime"]);
                    objevent.TimeZone = Convert.ToString(tempdataset.Tables[0].Rows[count]["TimeZone"]);

                    objevent.CustomerCount = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["TotalCustomer"]);
                    objevent.Host = new EHost();
                    objevent.Host.Name = Convert.ToString(tempdataset.Tables[0].Rows[count]["OrganizationName"]);

                    objevent.Host.Address = new EAddress();

                    objevent.Host.Address.Address1 = Convert.ToString(tempdataset.Tables[0].Rows[count]["Address1"]);
                    objevent.Host.Address.Address2 = Convert.ToString(tempdataset.Tables[0].Rows[count]["Address2"]);
                    objevent.Host.Address.City = Convert.ToString(tempdataset.Tables[0].Rows[count]["City"]);
                    objevent.Host.Address.State = Convert.ToString(tempdataset.Tables[0].Rows[count]["State"]);
                    objevent.Host.Address.Country = Convert.ToString(tempdataset.Tables[0].Rows[count]["Country"]);
                    objevent.Host.Address.Zip = Convert.ToString(tempdataset.Tables[0].Rows[count]["ZipCode"]);

                    objevent.Franchisee = new EFranchisee();
                    objevent.Franchisee.FranchiseeID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["FranchiseeID"]);
                    objevent.FranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser();
                    objevent.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["SalesRepID"]);

                    objevent.FranchiseeFranchiseeUser.FranchiseeUser = new EFranchiseeUser();
                    objevent.FranchiseeFranchiseeUser.FranchiseeUser.User = new EUser();

                    objevent.FranchiseeFranchiseeUser.FranchiseeUser.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[count]["FirstName"]);
                    objevent.FranchiseeFranchiseeUser.FranchiseeUser.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[count]["LastName"]);

                    //// paid , unpaid , register info
                    DataTable tblCustomersInfo = tempdataset.Tables[1];
                    tblCustomersInfo.DefaultView.RowFilter = "EventID = " + objevent.EventID;

                    objevent.UnpaidCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["UnpaidCustomers"]);
                    objevent.RegisteredCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["RegisteredCustomers"]);
                    objevent.PaidCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["PaidCustomers"]);
                    objevent.OnSiteCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["OnSiteCustomers"]);
                    objevent.CancelCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["CancelCustomers"]);
                    objevent.AttendedCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["AttendedCustomers"]);



                    objListEvent.Add(objevent);
                }

                catch (Exception)
                {
                }
            }

            return objListEvent;

        }


        public List<EFranchiseeFranchiseeUser> GetSalesRep(String filterString, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getsalesrep", arParms);

            List<EFranchiseeFranchiseeUser> returnFranchisee = new List<EFranchiseeFranchiseeUser>();
            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    EFranchiseeFranchiseeUser ffuser = new EFranchiseeFranchiseeUser();
                    ffuser.Franchisee = new EFranchisee();
                    ffuser.FranchiseeUser = new EFranchiseeUser();
                    ffuser.FranchiseeUser.User = new EUser();


                    ffuser.FranchiseeFranchiseeUserID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["FranchiseeFranchiseeUserID"]);
                    ffuser.Franchisee.FranchiseeID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["FranchiseeID"]);
                    ffuser.FranchiseeUser.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["FirstName"]);
                    ffuser.FranchiseeUser.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["LastName"]);
                    ffuser.Franchisee.Name = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Franchisee"]);




                    returnFranchisee.Add(ffuser);
                }
            }

            return returnFranchisee;
        }

        /// <summary>
        /// this routine get list of techincian for eventid
        /// </summary>
        /// <param name="eventid"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<EFranchiseeFranchiseeUser> GetTechnician(int eventid, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = eventid;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_geteventtechnician", arParms);

            List<EFranchiseeFranchiseeUser> returnFranchisee = new List<EFranchiseeFranchiseeUser>();
            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    EFranchiseeFranchiseeUser ffuser = new EFranchiseeFranchiseeUser();
                    ffuser.Franchisee = new EFranchisee();
                    ffuser.FranchiseeUser = new EFranchiseeUser();
                    ffuser.FranchiseeUser.User = new EUser();

                    ffuser.FranchiseeFranchiseeUserID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["UserID"]);
                    ffuser.FranchiseeUser.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["FirstName"]);
                    ffuser.FranchiseeUser.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["LastName"]);
                    ffuser.FranchiseeUser.User.MiddleName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["MiddleName"]);

                    returnFranchisee.Add(ffuser);
                }
            }

            return returnFranchisee;
        }

        public List<EFranchiseeFranchiseeUser> GetSimilarFranchiseeFranchiseeUser(string filterstring, int mode, int franchiseeid)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 50);
            arParms[0].Value = filterstring;

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;

            arParms[2] = new SqlParameter("@franchiseeid", SqlDbType.Int);
            arParms[2].Value = franchiseeid;

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getSimilarFranchiseeUser", arParms);
            List<EFranchiseeFranchiseeUser> objListFranchiseeFranchiseeUser = new List<EFranchiseeFranchiseeUser>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int count = 0; count < dt.Rows.Count; count++)
                    {
                        EFranchiseeFranchiseeUser objFranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser();
                        objFranchiseeFranchiseeUser.FranchiseeFranchiseeUserID = Convert.ToInt32(dt.Rows[count]["FranchiseeFranchiseeUserID"]);
                        objFranchiseeFranchiseeUser.FranchiseeUser = new EFranchiseeUser();
                        objFranchiseeFranchiseeUser.FranchiseeUser.User = new EUser();
                        objFranchiseeFranchiseeUser.FranchiseeUser.User.FirstName = Convert.ToString(dt.Rows[count]["Name"]);
                        objListFranchiseeFranchiseeUser.Add(objFranchiseeFranchiseeUser);
                    }
                }
            }
            return objListFranchiseeFranchiseeUser;
        }
        /// <summary>
        /// Get Matching EFranchisee or SalesRepuser
        /// </summary>
        /// <param name="filterstring"></param>
        /// <param name="mode"></param>
        /// <param name="franchiseeid"></param>
        /// <returns></returns>
        public List<EFranchiseeFranchiseeUser> GetMatchingFranchiseeUserList(string filterstring, int mode, int franchiseeid)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 50);
            arParms[0].Value = filterstring;

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;

            arParms[2] = new SqlParameter("@franchiseeid", SqlDbType.Int);
            arParms[2].Value = franchiseeid;

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getSimilarFranchiseeFranchiseeUserID", arParms);
            List<EFranchiseeFranchiseeUser> objListFranchiseeFranchiseeUser = new List<EFranchiseeFranchiseeUser>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int count = 0; count < dt.Rows.Count; count++)
                    {
                        EFranchiseeFranchiseeUser objFranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser();
                        objFranchiseeFranchiseeUser.FranchiseeFranchiseeUserID = Convert.ToInt32(dt.Rows[count]["UserID"]);
                        objFranchiseeFranchiseeUser.FranchiseeUser = new EFranchiseeUser();
                        objFranchiseeFranchiseeUser.FranchiseeUser.User = new EUser();
                        objFranchiseeFranchiseeUser.FranchiseeUser.User.FirstName = Convert.ToString(dt.Rows[count]["Name"]);
                        objListFranchiseeFranchiseeUser.Add(objFranchiseeFranchiseeUser);
                    }
                }
            }
            return objListFranchiseeFranchiseeUser;
        }

        public List<EFranchiseeFranchiseeUser> GetTeamForAdvocateSalesManager(int inputMode, Int64 intAdvocateSalesManagerID)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@advocatesalesmanagerid", SqlDbType.VarChar, 500);
            arParms[0].Value = intAdvocateSalesManagerID;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();

            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_AFgetTeamForAdvocateSalesManager", arParms);

            List<EFranchiseeFranchiseeUser> returnFranchiseeFranchiseeUser = new List<EFranchiseeFranchiseeUser>();
            returnFranchiseeFranchiseeUser = ParseAdvocateSalesManagerTeam(tempdataset);
            return returnFranchiseeFranchiseeUser;
        }
        private List<EFranchiseeFranchiseeUser> ParseAdvocateSalesManagerTeam(DataSet franchiseefranchiseeuserDataSet)
        {
            List<EFranchiseeFranchiseeUser> returnFranchiseeFranchiseeUser = new List<EFranchiseeFranchiseeUser>();

            for (int count = 0; count < franchiseefranchiseeuserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EFranchiseeFranchiseeUser franchiseefranchiseeuser = new EFranchiseeFranchiseeUser();
                    EFranchisee franchisee = new EFranchisee();
                    EFranchiseeUser franchiseeuser = new EFranchiseeUser();
                    EUser objUser = new EUser();

                    franchisee.FranchiseeID = Convert.ToInt32(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["OrganizationId"]);
                    
                    franchiseefranchiseeuser.FranchiseeFranchiseeUserID = Convert.ToInt32(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["OrganizationroleUserId"]);
                    franchiseefranchiseeuser.RoleID = Convert.ToInt32(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["RoleID"]);
                    objUser.FirstName = Convert.ToString(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["FirstName"]);
                    objUser.MiddleName = Convert.ToString(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["MiddleName"]);
                    objUser.LastName = Convert.ToString(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["LastName"]);
                    objUser.PhoneHome = Convert.ToString(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["PhoneHome"]);
                    objUser.EMail1 = Convert.ToString(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["EMail1"]);

                    objUser.UserID = Convert.ToInt32(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["UserID"]);
                    if (Convert.ToInt32(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["Active"]) == 1)
                    {
                        franchiseefranchiseeuser.AdvocateSalesManagerID = Convert.ToInt32(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["ManagerID"]);
                        franchiseefranchiseeuser.AdvocateSalesManager = Convert.ToString(franchiseefranchiseeuserDataSet.Tables[0].Rows[count]["AdvocateSalesManager"]);
                    }


                    franchiseeuser.User = objUser;
                    franchiseefranchiseeuser.Franchisee = franchisee;
                    franchiseefranchiseeuser.FranchiseeUser = franchiseeuser;
                    returnFranchiseeFranchiseeUser.Add(franchiseefranchiseeuser);
                }
                catch
                {
                }
            }
            return returnFranchiseeFranchiseeUser;
        }

        public Int64 UpdateAdvocateSalesManagerTeam(Int64 intAdvocateSalesManagerID, Int64 intSalesRepId, Boolean bolStatus)
        {

            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@managerid", SqlDbType.BigInt);
            arParms[0].Value = intAdvocateSalesManagerID;
            arParms[1] = new SqlParameter("@salesrepid", SqlDbType.BigInt);
            arParms[1].Value = intSalesRepId;
            arParms[2] = new SqlParameter("@status", SqlDbType.Bit);
            arParms[2].Value = bolStatus;

            arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_AFUpdateAdvocateSalesManagerTeam", arParms);
            returnvalue = (Int64)arParms[3].Value;
            return returnvalue; ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesrepid"></param>
        /// <param name="pagenum"></param>
        /// <param name="pagesize"></param>
        /// <param name="datefrom"></param>
        /// <param name="dateto"></param>
        /// <param name="relatedkeyword"></param>
        /// <param name="relatedmode"></param>
        /// <param name="keyword"></param>
        /// <param name="issearch"></param>
        /// <param name="viewmode"></param>
        /// <param name="TotalRecords"></param>
        /// <returns></returns>
        public List<ESalesRepMyActivity> GetSalesRepMyActivityInfo(Int64 salesrepid, Int16 pagenum, Int16 pagesize, string datefrom, string dateto
                                                                    , string relatedkeyword, Int16 relatedmode, string keyword, bool issearch,
                                                                    Int16 viewmode, out Int64 TotalRecords,int mode)
        {
            SqlParameter[] arparams = new SqlParameter[11];
            arparams[0] = new SqlParameter("@roleshellid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@viewmode", SqlDbType.TinyInt);
            arparams[2] = new SqlParameter("@issearchmode", SqlDbType.Bit);
            arparams[3] = new SqlParameter("@datefrom", SqlDbType.VarChar, 100);
            arparams[4] = new SqlParameter("@dateto", SqlDbType.VarChar, 100);
            arparams[5] = new SqlParameter("@relatedmode", SqlDbType.TinyInt);
            arparams[6] = new SqlParameter("@relatedkeyword", SqlDbType.VarChar, 500);
            arparams[7] = new SqlParameter("@keyword", SqlDbType.VarChar, 500);
            arparams[8] = new SqlParameter("@pageno", SqlDbType.TinyInt);
            arparams[9] = new SqlParameter("@pagesize", SqlDbType.TinyInt);
            arparams[10] = new SqlParameter("@mode", SqlDbType.Int);

            arparams[0].Value = salesrepid;
            arparams[1].Value = viewmode;
            arparams[2].Value = issearch;

            if (datefrom.Trim().Length < 1) arparams[3].Value = DBNull.Value; 
            else arparams[3].Value = datefrom;

            if (dateto.Trim().Length < 1) arparams[4].Value = DBNull.Value;
            else arparams[4].Value = dateto;

            if(relatedmode > 0)
                arparams[5].Value = relatedmode;
            else
                arparams[5].Value = DBNull.Value;

            if (relatedkeyword.Trim().Length < 1)
            {
                //arparams[5].Value = DBNull.Value;
                arparams[6].Value = DBNull.Value;
            }
            else
            {
                //arparams[5].Value = relatedmode;
                arparams[6].Value = relatedkeyword;
            }
            

            if (keyword.Trim().Length < 1) arparams[7].Value = DBNull.Value;
            else arparams[7].Value = keyword;

            arparams[8].Value = pagenum;
            arparams[9].Value = pagesize;

            arparams[10].Value = mode;


            DataSet dsMyActivities = SqlHelper.ExecuteDataset(connectionstring,  "usp_getrecordsforMyActivities", arparams);
            TotalRecords = 0;
            if (dsMyActivities == null) return null;

            if (dsMyActivities.Tables[0].Rows.Count < 1) return null;

            List<ESalesRepMyActivity> lstSalesRepActivity = new List<ESalesRepMyActivity>();

            foreach (DataRow dr in dsMyActivities.Tables[0].Rows)
            {
                ESalesRepMyActivity objsalesrepactivity = new ESalesRepMyActivity();

                if (dr["ContactName"] != DBNull.Value) objsalesrepactivity.ContactName = dr["ContactName"].ToString();
                objsalesrepactivity.ProspectID = Convert.ToInt64(dr["ProspectID"]);
                objsalesrepactivity.Subject = dr["Subject"].ToString();
                objsalesrepactivity.ProspectContactID = Convert.ToInt64(dr["ProspectContactID"]);
                objsalesrepactivity.Prospect = dr["Prospect"].ToString();
                objsalesrepactivity.ContactID = Convert.ToInt64(dr["ContactID"]);
                objsalesrepactivity.ActivityType = dr["ActivityType"].ToString();
                if (dr["ActivityTime"] != DBNull.Value) objsalesrepactivity.ActivityTime = dr["ActivityTime"].ToString();
                objsalesrepactivity.ActivityID = Convert.ToInt64(dr["ID"]);
                if (dr["IsHost"] != DBNull.Value)
                    objsalesrepactivity.IsHost = Convert.ToBoolean(dr["IsHost"]);
                else objsalesrepactivity.IsHost = false;
                // added eventid and eventname
                objsalesrepactivity.EventId = Convert.ToInt64(dr["EventID"]);
                objsalesrepactivity.EventName = dr["EventName"].ToString();
                objsalesrepactivity.EventStatus = Convert.ToInt32(dr["EventStatus"]);
                if (Convert.ToString(dr["ActivityStatus"]) == ActivityMarkedStatus.Completed.ToString() || Convert.ToString(dr["ActivityStatus"]) == ActivityMarkedStatus.Held.ToString())
                {
                    objsalesrepactivity.ActivityMarkedStatus = true;
                }
                else objsalesrepactivity.ActivityMarkedStatus = false;

                lstSalesRepActivity.Add(objsalesrepactivity);
                
            }
            TotalRecords = Convert.ToInt64(dsMyActivities.Tables[1].Rows[0][0]);
            return lstSalesRepActivity;
        }

        public List<EFranchiseeFranchiseeUser> GetAllHSCSalesRep()
        {
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getHSCSalesRep",null);

            List<EFranchiseeFranchiseeUser> returnFranchisee = new List<EFranchiseeFranchiseeUser>();
            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    EFranchiseeFranchiseeUser ffuser = new EFranchiseeFranchiseeUser();
                    ffuser.Franchisee = new EFranchisee();
                    ffuser.FranchiseeUser = new EFranchiseeUser();
                    ffuser.FranchiseeUser.User = new EUser();


                    ffuser.FranchiseeFranchiseeUserID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["FranchiseeFranchiseeUserID"]);
                    ffuser.Franchisee.FranchiseeID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["FranchiseeID"]);
                    ffuser.FranchiseeUser.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["FirstName"]);
                    ffuser.FranchiseeUser.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["LastName"]);
                    ffuser.Franchisee.Name = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Franchisee"]);




                    returnFranchisee.Add(ffuser);
                }
            }

            return returnFranchisee;
        }
        public List<EFranchiseeFranchiseeUser> GetAllSalesRepOnTerritory(long organizationRoleUserId)
        {

            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@OrganizationRoleUserId", SqlDbType.BigInt);
            arParms[0].Value = organizationRoleUserId;

            DataSet tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_GetTerritorySalesRep", arParms);

            List<EFranchiseeFranchiseeUser> returnFranchisee = new List<EFranchiseeFranchiseeUser>();
            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    EFranchiseeFranchiseeUser ffuser = new EFranchiseeFranchiseeUser();                    
                    ffuser.FranchiseeUser = new EFranchiseeUser();
                    ffuser.FranchiseeUser.User = new EUser();

                    ffuser.FranchiseeFranchiseeUserID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["OrganizationRoleUserId"]);
                    ffuser.FranchiseeUser.User.UserID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["UserId"]);
                    ffuser.FranchiseeUser.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["FirstName"]);
                    ffuser.FranchiseeUser.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["LastName"]);
                    returnFranchisee.Add(ffuser);
                }
            }
            return returnFranchisee;
        }
        #endregion

        #region "FranchiseeApplication"
        
        public Int64 SaveFranchiseeApplicationReferences(List<EReferences> reference, Int64 userid, Int64 mode)
        {
            Int64 returnvalue = new Int64();
            for (int icount = 0; icount < reference.Count; icount++)
            {
                SqlParameter[] arParms = new SqlParameter[5];
                arParms[0] = new SqlParameter("@userid1", SqlDbType.BigInt);
                arParms[0].Value = userid;
                arParms[1] = new SqlParameter("@name", SqlDbType.VarChar, 500);
                arParms[1].Value = reference[icount].Name;
                arParms[2] = new SqlParameter("@email", SqlDbType.VarChar, 500);
                arParms[2].Value = reference[icount].EMail;

                arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[3].Value = icount;

                arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savefranchiseeapplicationrefernce", arParms);
                returnvalue = (Int64)arParms[4].Value;
            }

            return returnvalue;
        }

        public Int64 SaveApplicationReferences(List<EReferences> reference, Int64 applicationid, Int64 mode)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@applicationid", SqlDbType.BigInt);
            arParms[0].Value = applicationid;
            arParms[1] = new SqlParameter("@name1", SqlDbType.VarChar, 500);
            arParms[1].Value = reference[0].Name;
            arParms[2] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[2].Value = reference[0].EMail;
            arParms[3] = new SqlParameter("@name2", SqlDbType.VarChar, 500);
            arParms[3].Value = reference[1].Name;
            arParms[4] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[4].Value = reference[1].EMail;
            arParms[5] = new SqlParameter("@name3", SqlDbType.VarChar, 500);
            arParms[5].Value = reference[2].Name;
            arParms[6] = new SqlParameter("@email3", SqlDbType.VarChar, 500);
            arParms[6].Value = reference[2].EMail;

            arParms[7] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[7].Value = mode;

            arParms[8] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveapplicationrefernce", arParms);
            return (Int64)arParms[8].Value;
        }
       

        public List<EFranchiseeApplication> GetFranchiseeApplication(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getfranchiseeapplication", arParms);

            List<EFranchiseeApplication> returnFranchiseeApplication = new List<EFranchiseeApplication>();
            returnFranchiseeApplication = ParseFranchiseeApplication(tempdataset);
            return returnFranchiseeApplication;
        }
        private List<EFranchiseeApplication> ParseFranchiseeApplication(DataSet franchiseeApplicationDataSet)
        {
            List<EFranchiseeApplication> returnFranchiseeApplication = new List<EFranchiseeApplication>();
            foreach (DataRow dr in franchiseeApplicationDataSet.Tables[0].Rows)
            {
                EFranchiseeApplication franchiseeapplication = new EFranchiseeApplication();
                franchiseeapplication.Application = new EApplication();
                franchiseeapplication.WFStage = new EWFStage();
                franchiseeapplication.FranchiseeApplicationID = Convert.ToInt32(dr["ApplicationID"]);
                franchiseeapplication.Application.BusinessName = dr["BusinessName"].ToString();
                franchiseeapplication.Application.FirstName = dr["FirstName"].ToString();
                franchiseeapplication.Application.MiddleName = dr["MiddleName"].ToString();
                franchiseeapplication.Application.LastName = dr["LastName"].ToString();
                franchiseeapplication.Application.PhoneCell = dr["PhoneCell"].ToString();
                franchiseeapplication.Application.PhoneHome = dr["PhoneHome"].ToString();
                franchiseeapplication.Application.PhoneOffice = dr["PhoneOffice"].ToString();
                franchiseeapplication.Application.Email1 = dr["Email1"].ToString();
                franchiseeapplication.Application.Email2 = dr["Email2"].ToString();
                franchiseeapplication.DateCreated = Convert.ToDateTime(dr["DateCreated"]);
                franchiseeapplication.Application.ReferenceName1 = dr["Reference1Name"].ToString();
                franchiseeapplication.Application.ReferenceEmail1 = dr["Reference1Email"].ToString();
                franchiseeapplication.Application.ReferenceName2 = dr["Reference2Name"].ToString();
                franchiseeapplication.Application.ReferenceEmail2 = dr["Reference2Email"].ToString();
                franchiseeapplication.Application.ReferenceName3 = dr["Reference3Name"].ToString();
                franchiseeapplication.Application.ReferenceEmail3 = dr["Reference3Email"].ToString();
                franchiseeapplication.BusinessPhone = dr["BusinessPhone"].ToString();
                franchiseeapplication.BusinessFax = dr["BusinessFax"].ToString();
                franchiseeapplication.BillingAddressID = Convert.ToInt32(dr["BillingAddressID"]);
                franchiseeapplication.WFStage.WFStageID = Convert.ToInt32(dr["WorkFlowStageID"]);


                DataRow[] drBusinessAdd = franchiseeApplicationDataSet.Tables[1].Select("AddressID = '" + dr["BusinessAddressID"].ToString() + "'");
                if (drBusinessAdd.Length > 0)
                {
                    DataRow drAdd = drBusinessAdd[0];
                    franchiseeapplication.Application.BusinessAddress = new EAddress();
                    franchiseeapplication.Application.BusinessAddress.AddressID = Convert.ToInt32(drAdd["AddressID"]);
                    franchiseeapplication.Application.BusinessAddress.Address1 = drAdd["Address1"].ToString();
                    franchiseeapplication.Application.BusinessAddress.Address2 = drAdd["Address2"].ToString();
                    franchiseeapplication.Application.BusinessAddress.ZipID = Convert.ToInt32(drAdd["ZIPID"]);
                    franchiseeapplication.Application.BusinessAddress.PhoneNumber = drAdd["PhoneNumber"].ToString();
                    franchiseeapplication.Application.BusinessAddress.City = drAdd["CityName"].ToString();
                    franchiseeapplication.Application.BusinessAddress.CityID = Convert.ToInt32(drAdd["CityID"]);
                    franchiseeapplication.Application.BusinessAddress.State = drAdd["StateName"].ToString();
                    franchiseeapplication.Application.BusinessAddress.StateID = Convert.ToInt32(drAdd["StateID"]);
                    franchiseeapplication.Application.BusinessAddress.Country = drAdd["CountryName"].ToString();
                    franchiseeapplication.Application.BusinessAddress.CountryID = Convert.ToInt32(drAdd["CountryID"]);
                    franchiseeapplication.Application.BusinessAddress.Zip = drAdd["ZipCode"].ToString();
                }

                DataRow[] drBillingAdd = franchiseeApplicationDataSet.Tables[2].Select("AddressID = '" + dr["BillingAddressID"].ToString() + "'");
                if (drBillingAdd.Length > 0)
                {
                    DataRow drAddB = drBillingAdd[0];
                    franchiseeapplication.BillingAddress = new EAddress();
                    franchiseeapplication.BillingAddress.AddressID = Convert.ToInt32(drAddB["AddressID"]);
                    franchiseeapplication.BillingAddress.Address1 = drAddB["Address1"].ToString();
                    franchiseeapplication.BillingAddress.Address2 = drAddB["Address2"].ToString();
                    franchiseeapplication.BillingAddress.ZipID = Convert.ToInt32(drAddB["ZIPID"]);
                    franchiseeapplication.BillingAddress.PhoneNumber = drAddB["PhoneNumber"].ToString();
                    franchiseeapplication.BillingAddress.City = drAddB["CityName"].ToString();
                    franchiseeapplication.BillingAddress.CityID = Convert.ToInt32(drAddB["CityID"]);
                    franchiseeapplication.BillingAddress.State = drAddB["StateName"].ToString();
                    franchiseeapplication.BillingAddress.StateID = Convert.ToInt32(drAddB["StateID"]);
                    franchiseeapplication.BillingAddress.Country = drAddB["CountryName"].ToString();
                    franchiseeapplication.BillingAddress.CountryID = Convert.ToInt32(drAddB["CountryID"]);
                    franchiseeapplication.BillingAddress.Zip = drAddB["ZipCode"].ToString();
                }
                DataRow[] drContactAdd = franchiseeApplicationDataSet.Tables[3].Select("AddressID = '" + dr["ContactAddressID"].ToString() + "'");
                if (drContactAdd.Length > 0)
                {
                    DataRow drAddC = drContactAdd[0];
                    franchiseeapplication.Application.ContactAddress = new EAddress();
                    franchiseeapplication.Application.BusinessAddress.AddressID = Convert.ToInt32(drAddC["AddressID"]);
                    franchiseeapplication.Application.ContactAddress.Address1 = drAddC["Address1"].ToString();
                    franchiseeapplication.Application.ContactAddress.Address2 = drAddC["Address2"].ToString();
                    franchiseeapplication.Application.ContactAddress.ZipID = Convert.ToInt32(drAddC["ZIPID"]);
                    franchiseeapplication.Application.ContactAddress.PhoneNumber = drAddC["PhoneNumber"].ToString();
                    franchiseeapplication.Application.ContactAddress.City = drAddC["CityName"].ToString();
                    franchiseeapplication.Application.ContactAddress.CityID = Convert.ToInt32(drAddC["CityID"]);
                    franchiseeapplication.Application.ContactAddress.State = drAddC["StateName"].ToString();
                    franchiseeapplication.Application.ContactAddress.StateID = Convert.ToInt32(drAddC["StateID"]);
                    franchiseeapplication.Application.ContactAddress.Country = drAddC["CountryName"].ToString();
                    franchiseeapplication.Application.ContactAddress.CountryID = Convert.ToInt32(drAddC["CountryID"]);
                    franchiseeapplication.Application.ContactAddress.Zip = drAddC["ZipCode"].ToString();
                }
                returnFranchiseeApplication.Add(franchiseeapplication);
            }

            return returnFranchiseeApplication;
        }
        public Int64 UpdateFranchiseeApplication(Int32 FranchiseeApplicationID, string wfStage)
        {
            SqlParameter[] arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@franchiseeapplicationid", SqlDbType.BigInt, 3000);
            arParms[0].Value = FranchiseeApplicationID;

            arParms[1] = new SqlParameter("@wfstage", SqlDbType.NVarChar, 20);
            arParms[1].Value = wfStage;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savenewfranchiseeapplication", arParms);
            return (Int64)arParms[2].Value;

        }
        public Int64 AcceptFranchiseeApplication(Int32 FranchiseeApplicationID)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@franchiseeappid", SqlDbType.BigInt, 3000);
            arParms[0].Value = FranchiseeApplicationID;

            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveapprovefranchiseeapplication", arParms);
            return (Int64)arParms[1].Value;

        }
        public Int64 SaveApplicationNotes(List<ENote> note, string UserID )
        {
            Int64 returnvalue = new Int64();
            for (int icount = 0; icount < note.Count; icount++)
            {
                SqlParameter[] arParms = new SqlParameter[8];
                arParms[0] = new SqlParameter("@notes", SqlDbType.VarChar, 5000);
                arParms[0].Value = note[icount].Notes;
                arParms[1] = new SqlParameter("@notesequence", SqlDbType.BigInt);
                arParms[1].Value = note[icount].NotesSequence;
                arParms[2] = new SqlParameter("@applicationid", SqlDbType.BigInt);
                arParms[2].Value = note[icount].ApplicationID;
                arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[3].Value = 0;
                arParms[4] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
                arParms[4].Value = UserID;
                arParms[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveapplicationnote", arParms);
                returnvalue = (Int64)arParms[5].Value;
            }

            return returnvalue;
        }
        public List<ENote> GetNoteApplicationByID(String filterString)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = 0;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getapplicationnote", arParms);

            List<ENote> returnFranchiseeApplicationNote = new List<ENote>();
            returnFranchiseeApplicationNote = ParseFranchiseeApplicationNote(tempdataset);
            return returnFranchiseeApplicationNote;
        }
        private List<ENote> ParseFranchiseeApplicationNote(DataSet franchiseeApplicationNoteDataSet)
        {
            List<ENote> returnNote = new List<ENote>();
            foreach (DataRow dr in franchiseeApplicationNoteDataSet.Tables[0].Rows)
            {
                ENote note = new ENote();
                note.FranchiseeNotesID = Convert.ToInt32(dr["FranchiseeNotesID"]);
                note.ApplicationID = Convert.ToInt32(dr["FranchiseeAppID"]);
                note.Notes = dr["Notes"].ToString();
                note.NotesSequence = Convert.ToInt32(dr["NotesSequence"]);
                returnNote.Add(note);
            }

            return returnNote;
        }
        public Int64 SaveEditApplication(EFranchiseeApplication franchisee)
        {
            
            SqlParameter[] arParms = new SqlParameter[41];
            arParms[0] = new SqlParameter("@franchiseename", SqlDbType.VarChar, 500);
            arParms[0].Value = franchisee.Application.BusinessName;

            arParms[1] = new SqlParameter("@contactaddressid", SqlDbType.BigInt);
            arParms[1].Value = franchisee.Application.ContactAddress.AddressID;
            arParms[2] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
            arParms[2].Value = franchisee.Application.ContactAddress.Address1;
            arParms[3] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[3].Value = franchisee.Application.ContactAddress.Address2;
            arParms[4] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[4].Value = franchisee.Application.ContactAddress.CityID;
            arParms[5] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[5].Value = franchisee.Application.ContactAddress.StateID;
            arParms[6] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[6].Value = franchisee.Application.ContactAddress.CountryID;
            arParms[7] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[7].Value = franchisee.Application.ContactAddress.ZipID;

            arParms[8] = new SqlParameter("@businessaddress1", SqlDbType.VarChar, 500);
            arParms[8].Value = franchisee.Application.BusinessAddress.Address1;
            arParms[9] = new SqlParameter("@businessaddress2", SqlDbType.VarChar, 500);
            arParms[9].Value = franchisee.Application.BusinessAddress.Address2;
            arParms[10] = new SqlParameter("@businesscityid", SqlDbType.BigInt);
            arParms[10].Value = franchisee.Application.BusinessAddress.CityID;
            arParms[11] = new SqlParameter("@businessstateid", SqlDbType.BigInt);
            arParms[11].Value = franchisee.Application.BusinessAddress.StateID;
            arParms[12] = new SqlParameter("@businesscountryid", SqlDbType.BigInt);
            arParms[12].Value = franchisee.Application.BusinessAddress.CountryID;
            arParms[13] = new SqlParameter("@businesscityzipid", SqlDbType.BigInt);
            arParms[13].Value = franchisee.Application.BusinessAddress.ZipID;

            arParms[14] = new SqlParameter("@billingaddress1", SqlDbType.VarChar, 500);
            arParms[14].Value = franchisee.BillingAddress.Address1;
            arParms[15] = new SqlParameter("@billingaddress2", SqlDbType.VarChar, 500);
            arParms[15].Value = franchisee.BillingAddress.Address2;
            arParms[16] = new SqlParameter("@billingcityid", SqlDbType.BigInt);
            arParms[16].Value = franchisee.BillingAddress.CityID;
            arParms[17] = new SqlParameter("@billingstateid", SqlDbType.BigInt);
            arParms[17].Value = franchisee.BillingAddress.StateID;
            arParms[18] = new SqlParameter("@billingcountryid", SqlDbType.BigInt);
            arParms[18].Value = franchisee.BillingAddress.CountryID;
            arParms[19] = new SqlParameter("@billingzipid", SqlDbType.BigInt);
            arParms[19].Value = franchisee.BillingAddress.ZipID;


            arParms[20] = new SqlParameter("@firstname", SqlDbType.VarChar, 50);
            arParms[20].Value = franchisee.Application.FirstName;
            arParms[21] = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
            arParms[21].Value = franchisee.Application.LastName;
            arParms[22] = new SqlParameter("@phonehome", SqlDbType.VarChar, 50);
            arParms[22].Value = franchisee.Application.PhoneHome;
            arParms[23] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 50);
            arParms[23].Value = franchisee.Application.PhoneOffice;
            arParms[24] = new SqlParameter("@phonecell", SqlDbType.VarChar, 50);
            arParms[24].Value = franchisee.Application.PhoneCell;
            arParms[25] = new SqlParameter("@email1", SqlDbType.VarChar, 50);
            arParms[25].Value = franchisee.Application.Email1;
            arParms[26] = new SqlParameter("@email2", SqlDbType.VarChar, 200);
            arParms[26].Value = franchisee.Application.Email2;
            arParms[27] = new SqlParameter("@middlename", SqlDbType.VarChar, 200);
            arParms[27].Value = franchisee.Application.MiddleName;
            arParms[28] = new SqlParameter("@billingaddressid", SqlDbType.BigInt);
            arParms[28].Value = franchisee.BillingAddress.AddressID;
            arParms[29] = new SqlParameter("@businessaddressid", SqlDbType.BigInt);
            arParms[29].Value = franchisee.Application.BusinessAddress.AddressID;

            arParms[30] = new SqlParameter("@applicationid", SqlDbType.BigInt);
            arParms[30].Value = franchisee.FranchiseeApplicationID;
            arParms[31] = new SqlParameter("@businessphone", SqlDbType.VarChar, 500);
            arParms[31].Value = franchisee.BusinessPhone;
            arParms[32] = new SqlParameter("@businessfax", SqlDbType.VarChar, 500);
            arParms[32].Value = franchisee.BusinessFax;

            arParms[33] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[33].Value = 0;
            
            arParms[34] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[34].Direction = ParameterDirection.Output;
            arParms[35] = new SqlParameter("@refname1", SqlDbType.VarChar, 500);
            arParms[35].Value = franchisee.Application.ReferenceName1;
            arParms[36] = new SqlParameter("@refname2", SqlDbType.VarChar, 500);
            arParms[36].Value = franchisee.Application.ReferenceName2;
            arParms[37] = new SqlParameter("@refname3", SqlDbType.VarChar, 500);
            arParms[37].Value = franchisee.Application.ReferenceName3;
            arParms[38] = new SqlParameter("@refemail1", SqlDbType.VarChar, 500);
            arParms[38].Value = franchisee.Application.ReferenceEmail1;
            arParms[39] = new SqlParameter("@refemail2", SqlDbType.VarChar, 500);
            arParms[39].Value = franchisee.Application.ReferenceEmail2;
            arParms[40] = new SqlParameter("@refemail3", SqlDbType.VarChar, 500);
            arParms[40].Value = franchisee.Application.ReferenceEmail3;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveeditfranchiseeapplication", arParms);
            return (Int64)arParms[34].Value;
        }

        public Int64 SaveCustomerRegistrationNotes(ECustomerRegistrationNotes objCustRegNotes, long organizationRoleUserId)
        {
            SqlParameter[] arprams = new SqlParameter[5];
            arprams[0] = new SqlParameter("@OrganizationRoleUserId", SqlDbType.BigInt);
            arprams[0].Value = organizationRoleUserId;
            
            arprams[1] = new SqlParameter("@Notes", SqlDbType.VarChar, 5000);
            arprams[1].Value = objCustRegNotes.Notes;

            arprams[2] = new SqlParameter("@IsActive", SqlDbType.Bit);
            arprams[2].Value = objCustRegNotes.IsActive;

            arprams[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arprams[3].Direction = ParameterDirection.Output;

            arprams[4] = new SqlParameter("@CustomerID", SqlDbType.BigInt);
            arprams[4].Value = objCustRegNotes.Customer.CustomerID;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_SaveCustomerRegistrationNotes", arprams);

            Int64 returnvalue = Convert.ToInt64(arprams[3].Value);
            return returnvalue;
        }

        public List<ECustomerRegistrationNotes> GetCustomerRegistrationNotes(Int32 CustomerID)
        {
            SqlParameter[] arprams = new SqlParameter[1];
            arprams[0] = new SqlParameter("@CustomerID", SqlDbType.BigInt);
            arprams[0].Value = CustomerID;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_GetCustomerRegistrationnotes", arprams);

            List<ECustomerRegistrationNotes> returnCustRegNotes = new List<ECustomerRegistrationNotes>();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                ECustomerRegistrationNotes notes = new ECustomerRegistrationNotes();
                notes.Customer = new ECustomers();
                notes.CustomerRegistrationNotesID = Convert.ToInt32(dr["CustomerRegistrationNotesID"]);
                notes.RoleID = Convert.ToInt32(dr["RoleID"]);
                notes.ShellID = Convert.ToInt32(dr["ShellID"]);
                notes.Notes = Convert.ToString(dr["Notes"]);
                notes.Customer.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                returnCustRegNotes.Add(notes);
            }
            return returnCustRegNotes;
        }

        public bool UpdateCustomerRegistrationNotes(ECustomerRegistrationNotes[] objCustRegNotes)
        {
            SqlParameter[] arparams = new SqlParameter[5];
            arparams[0] = new SqlParameter("@CustomerRegistrationNotesId", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@CustomerID", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@Notes", SqlDbType.VarChar, 5000);
            arparams[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
            arparams[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            bool returnresult = false;
            for (int count = 0; count < objCustRegNotes.Length; count++)
            {
                arparams[0].Value = objCustRegNotes[count].CustomerRegistrationNotesID;
                arparams[1].Value = objCustRegNotes[count].Customer.CustomerID;
                arparams[2].Value = objCustRegNotes[count].Notes;
                arparams[3].Value = objCustRegNotes[count].IsActive;
                arparams[4].Direction = ParameterDirection.Output;
                if (objCustRegNotes[count].Action == "Edit")
                {
                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UpdateCustomerRegistrationNotes", arparams);
                }
                else if (objCustRegNotes[count].Action == "Delete")
                {
                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_DeleteCustomerRegistrationNotes", arparams);
                }
                returnresult = Convert.ToBoolean(arparams[4].Value);
            }
            return returnresult;

        }
        #endregion
    }
}
