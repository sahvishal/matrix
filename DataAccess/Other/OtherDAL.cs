using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Falcon.Entity.Other;
using Falcon.App.Core.Deprecated.Utility;

namespace Falcon.DataAccess.Other
{
    public class OtherDAL
    {
        private string connectionstring = ConnectionHandler.GetConnectionString();

        #region "Address"

        /// <summary>
        /// this function return the Address 
        /// </summary>
        public Entity.Other.EAddress GetAddressByID(Int64 addressid)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = 1;
            arParms[1] = new SqlParameter("@filterstring", SqlDbType.VarChar, 500);
            arParms[1].Value = addressid;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getaddressbyid", arParms);

            List<Entity.Other.EAddress> returnaddress = new List<Entity.Other.EAddress>();
            returnaddress = ParseAddressDataSet(tempdataset);

            if (returnaddress.Count == 0)
                return null;
            else
                return returnaddress[0];
        }
        /// <summary>
        /// this function parse the module dataset in the modules
        /// </summary>
        /// <param name="userrolemoduledataset"></param>
        /// <returns></returns>
        private List<Entity.Other.EAddress> ParseAddressDataSet(DataSet addressdataset)
        {
            List<Entity.Other.EAddress> returnaddress = new List<Entity.Other.EAddress>();

            for (int count = 0; count < addressdataset.Tables[0].Rows.Count; count++)
            {
                try
                {
                    Entity.Other.EAddress address = new Entity.Other.EAddress();

                    //address.Active = Convert.ToBoolean(addressdataset.Tables[0].Rows[count]["Active"]);
                    address.Address1 = Convert.ToString(addressdataset.Tables[0].Rows[count]["Address1"]);
                    address.Address2 = Convert.ToString(addressdataset.Tables[0].Rows[count]["Address2"]);
                    address.AddressID = Convert.ToInt32(addressdataset.Tables[0].Rows[count]["AddressID"]);
                    address.City = Convert.ToString(addressdataset.Tables[0].Rows[count]["City"]);
                    address.CityID = Convert.ToInt32(addressdataset.Tables[0].Rows[count]["CityID"]);
                    address.Country = Convert.ToString(addressdataset.Tables[0].Rows[count]["Country"]);
                    address.CountryID = Convert.ToInt32(addressdataset.Tables[0].Rows[count]["CountryID"]);
                    address.State = Convert.ToString(addressdataset.Tables[0].Rows[count]["State"]);
                    address.StateID = Convert.ToInt32(addressdataset.Tables[0].Rows[count]["StateID"]);
                    address.Zip = Convert.ToString(addressdataset.Tables[0].Rows[count]["ZipCode"]);
                    //address.ZipID = Convert.ToInt32(addressdataset.Tables[0].Rows[count]["ZipID"]);

                    returnaddress.Add(address);

                }
                catch
                {

                }
            }
            return returnaddress;
        }

        
        #endregion
        #region "General"

        public string GetConfigurationValue(string strFilterString)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 500);
            arParms[0].Value = strFilterString;
            string strreturnvalue;
            strreturnvalue = Convert.ToString(SqlHelper.ExecuteScalar(connectionstring, CommandType.StoredProcedure, "usp_getconfigurationvalue", arParms));
            return strreturnvalue;
        }

        public Int64 UpdateShellDescription(string strDescription, string strShellType, string Shell)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@shelldescription", SqlDbType.VarChar, 1000);

            arParms[0].Value = strDescription;
            arParms[1] = new SqlParameter("@shelltype", SqlDbType.VarChar, 500);
            arParms[1].Value = strShellType;
            arParms[2] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[2].Value = Shell;
            arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveshelldescription", arParms);
            long returnvalue = (Int64)arParms[3].Value;
            return returnvalue;
        }

        public byte[] GetEmailTemplate(string strEmailTitle)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@emailtemplate", SqlDbType.VarChar, 50);
            arParms[0].Value = strEmailTitle;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_UI_getemailtemplate", arParms);

            return CommonClass.CompressDataSet(tempdataset);
        }

        public Boolean CheckUniqueEmail(string strEmail, Int64 intUserID)
        {
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@email", SqlDbType.VarChar, 200);
            arParms[0].Value = strEmail;

            arParms[1] = new SqlParameter("@userid", SqlDbType.VarChar, 200);
            arParms[1].Value = intUserID;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_checkEmail", arParms);
            Boolean returnvalue = new Boolean();

            returnvalue = Convert.ToBoolean(arParms[2].Value);
            return returnvalue;
        }

        public Boolean VerifyUser(Int64 intUserID, string ResetPwdQueryString)
        {

            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@ResetPwdQueryString", SqlDbType.VarChar, 1000);
            arParms[0].Value = ResetPwdQueryString;

            arParms[1] = new SqlParameter("@UserID", SqlDbType.BigInt);
            arParms[1].Value = intUserID;

            arParms[2] = new SqlParameter("@IsUserValid", SqlDbType.Bit);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteScalar(connectionstring, CommandType.StoredProcedure, "usp_VerifyUser", arParms);
            Boolean returnvalue = new Boolean();

            returnvalue = Convert.ToBoolean(arParms[2].Value);
            return returnvalue;
        }

        public Boolean CheckUniqueUserName(string strUserName, Int64 intUserID)
        {

            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@username", SqlDbType.VarChar, 200);
            arParms[0].Value = strUserName;

            arParms[1] = new SqlParameter("@userid", SqlDbType.VarChar, 200);
            arParms[1].Value = intUserID;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_checkUserName", arParms);
            Boolean returnvalue = new Boolean();


            returnvalue = Convert.ToBoolean(arParms[2].Value);
            return returnvalue;
        }

        public EZip CheckCityZip(string strCity, string strZip, string strStateID)
        {

            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@city", SqlDbType.VarChar, 200);
            arParms[0].Value = strCity;

            arParms[1] = new SqlParameter("@zip", SqlDbType.VarChar, 200);
            arParms[1].Value = strZip;

            arParms[2] = new SqlParameter("@stateid", SqlDbType.VarChar, 200);
            arParms[2].Value = strStateID;

            arParms[3] = new SqlParameter("@returncityid", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;

            arParms[4] = new SqlParameter("@returnzipid", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UI_CheckCityZip", arParms);

            EZip returnvalue = new EZip();
            returnvalue.CityID = Convert.ToInt32(arParms[3].Value);
            returnvalue.ZipID = Convert.ToInt32(arParms[4].Value);

            return returnvalue;
        }


        public EZip GetCityZip(string strCity, string strStateID)
        {

            SqlParameter[] arParms = new SqlParameter[4];

            arParms[0] = new SqlParameter("@city", SqlDbType.VarChar, 200);
            arParms[0].Value = strCity;

            arParms[1] = new SqlParameter("@stateid", SqlDbType.VarChar, 200);
            arParms[1].Value = strStateID;

            arParms[2] = new SqlParameter("@returncityid", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            arParms[3] = new SqlParameter("@returnzipid", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UI_GetCityZip", arParms);

            EZip returnvalue = new EZip();
            returnvalue.CityID = Convert.ToInt32(arParms[2].Value);
            returnvalue.ZipID = Convert.ToInt32(arParms[3].Value);

            return returnvalue;
        }

        public EAddress GetCountryStateCityZipID(string strCountry, string strState, string strCity, string strZip)
        {

            SqlParameter[] arParms = new SqlParameter[8];

            arParms[0] = new SqlParameter("@country", SqlDbType.VarChar, 200);
            arParms[0].Value = strCountry;

            arParms[1] = new SqlParameter("@state", SqlDbType.VarChar, 200);
            arParms[1].Value = strState;

            arParms[2] = new SqlParameter("@city", SqlDbType.VarChar, 200);
            arParms[2].Value = strCity;

            arParms[3] = new SqlParameter("@zip", SqlDbType.VarChar, 200);
            arParms[3].Value = strZip;

            arParms[4] = new SqlParameter("@returncountryid", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;

            arParms[5] = new SqlParameter("@returnstateid", SqlDbType.BigInt);
            arParms[5].Direction = ParameterDirection.Output;

            arParms[6] = new SqlParameter("@returncityid", SqlDbType.BigInt);
            arParms[6].Direction = ParameterDirection.Output;

            arParms[7] = new SqlParameter("@returnzipid", SqlDbType.BigInt);
            arParms[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_getcountrystatecityzipid", arParms);

            EAddress returnvalue = new EAddress();
            returnvalue.CountryID = Convert.ToInt32(arParms[4].Value);
            returnvalue.StateID = Convert.ToInt32(arParms[5].Value);
            returnvalue.CityID = Convert.ToInt32(arParms[6].Value);
            returnvalue.ZipID = Convert.ToInt32(arParms[7].Value);

            return returnvalue;
        }
                
        /// <summary>
        /// update user personal information
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public Int64 UpdateUserPersonalInfo(Entity.Other.EUser objUser)
        {
            SqlParameter[] arParms = new SqlParameter[12];

            arParms[0] = new SqlParameter("@firstname", SqlDbType.VarChar, 50);
            arParms[0].Value = objUser.FirstName;

            arParms[1] = new SqlParameter("@middlename", SqlDbType.VarChar, 50);
            arParms[1].Value = objUser.MiddleName;

            arParms[2] = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
            arParms[2].Value = objUser.LastName;

            arParms[3] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
            arParms[3].Value = objUser.HomeAddress.Address1;

            arParms[4] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[4].Value = objUser.HomeAddress.Address2;

            arParms[5] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[5].Value = objUser.HomeAddress.CityID;

            arParms[6] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[6].Value = objUser.HomeAddress.StateID;

            arParms[7] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[7].Value = objUser.HomeAddress.ZipID;

            arParms[8] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[8].Value = objUser.PhoneHome;

            arParms[9] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[9].Value = objUser.UserID;

            arParms[10] = new SqlParameter("@addressid", SqlDbType.BigInt);
            arParms[10].Value = objUser.HomeAddress.AddressID;

            arParms[11] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[11].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_updatePersonalInfo", arParms);
            Int64 returnvalue = new Int64();

            returnvalue = Convert.ToInt64(arParms[11].Value);
            return returnvalue;
        }
        
        public void UpdateCouponUse(string strCouponCode, Int32 intEventID)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            try
            {

                arParms[0] = new SqlParameter("@couponcode", SqlDbType.VarChar, 50);
                arParms[0].Value = @strCouponCode;

                arParms[1] = new SqlParameter("@eventid", SqlDbType.BigInt);
                arParms[1].Value = intEventID;

                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_updatecouponused", arParms);

            }
            catch (Exception)
            {

            }

        }

        public DataSet GetOrganizationListByRoleName(string rolename)
        {
            DataSet ds = new DataSet();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@rolename", SqlDbType.VarChar, 500);
            arParms[0].Value = rolename;
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getorganizationlistbyrolename", arParms);
            return ds;
        }

        public Boolean AddRole(int userid, int roleid, int orgid)
        {
            Boolean result;
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userid;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[1].Value = roleid;
            arParms[2] = new SqlParameter("@orgid", SqlDbType.BigInt);
            if (orgid == -1)
            {
                arParms[2].Value = DBNull.Value; ;
            }
            else
            {
                arParms[2].Value = orgid;
            }
            try
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveuserrole", arParms);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public Int64 SaveTempCart(int tempcartid, int eventid, int customerid, int appointmentslotid, int eventpackageid, int couponid, string securitynumber, string name, string cardnumber, string cardtype, string expirationdate, string paymentmode)
        {
            SqlParameter[] arParms = new SqlParameter[13];
            arParms[0] = new SqlParameter("@tempcartid", SqlDbType.BigInt);
            arParms[0].Value = tempcartid;
            arParms[1] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[1].Value = eventid;
            arParms[2] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arParms[2].Value = customerid;
            arParms[3] = new SqlParameter("@appointmentslotid", SqlDbType.BigInt);
            arParms[3].Value = appointmentslotid;
            arParms[4] = new SqlParameter("@eventpackageid", SqlDbType.BigInt);
            arParms[4].Value = eventpackageid;
            arParms[5] = new SqlParameter("@couponid", SqlDbType.BigInt);
            arParms[5].Value = couponid;
            arParms[6] = new SqlParameter("@securitynumber", SqlDbType.VarChar, 200);
            arParms[6].Value = securitynumber;
            arParms[7] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            arParms[7].Value = name;
            arParms[8] = new SqlParameter("@cardnumber", SqlDbType.VarChar, 200);
            arParms[8].Value = cardnumber;
            arParms[9] = new SqlParameter("@cardtype", SqlDbType.VarChar, 50);
            arParms[9].Value = cardtype;
            arParms[10] = new SqlParameter("@expirationdate", SqlDbType.VarChar, 50);
            arParms[10].Value = expirationdate;
            arParms[11] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 50);
            arParms[11].Value = paymentmode;
            arParms[12] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[12].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savetempcart", arParms);

            return (Int64)arParms[12].Value;
        }

        public string GetCyberReasonCodeDescription(int reasoncode)
        {
            string result = string.Empty;
            SqlParameter[] arprams = new SqlParameter[2];
            arprams[0] = new SqlParameter("@reasoncode", SqlDbType.Int);
            arprams[0].Value = reasoncode;
            arprams[1] = new SqlParameter("@description", SqlDbType.VarChar, 5000);
            arprams[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_getCyberReasonCodeDescription", arprams);
            result = (string)arprams[1].Value;
            return result;
        }

        public DataSet GetLoginCredentials(int userid)
        {
            DataSet ds = new DataSet();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userid;
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getlogincredentials", arParms);
            return ds;
        }

        public Int64 PDFGenerated(int eventcustomerid)
        {

            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arParms[0].Value = eventcustomerid;
            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_pdfgenerated", arParms);
            returnvalue = (Int64)arParms[1].Value;
            return returnvalue; ;
        }

        #endregion

        #region "Customer"
        /// <summary>
        /// Update Customer Detail For Payment
        /// </summary>
        public Int64 UpdateCustomer(EEventCustomer objCustomer, bool chkbillingaddress, bool chkspecialoffer, out Int64 paymentdetailId)
        {
            SqlParameter[] arParms = new SqlParameter[25];

            paymentdetailId = 0;
            long returnvalue = -1;

            try
            {
                arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
                arParms[0].Value = Convert.ToInt64(objCustomer.EventID);

                arParms[1] = new SqlParameter("@packageid", SqlDbType.BigInt);
                arParms[1].Value = Convert.ToInt64(objCustomer.EventPackage.Package.PackageID);

                arParms[2] = new SqlParameter("@packagecost", SqlDbType.Decimal);
                arParms[2].Value = Convert.ToDecimal(objCustomer.EventPackage.Package.CostPrice);

                arParms[3] = new SqlParameter("@appointmentid", SqlDbType.BigInt);
                arParms[3].Value = Convert.ToInt64(objCustomer.EventAppointment.AppointmentID);

                arParms[4] = new SqlParameter("@chkbillingaddress", SqlDbType.Bit);
                arParms[4].Value = Convert.ToByte(chkbillingaddress);

                arParms[5] = new SqlParameter("@billaddress1", SqlDbType.VarChar, 500);
                arParms[5].Value = objCustomer.Customer.BillingAddress.Address1;

                arParms[6] = new SqlParameter("@billaddress2", SqlDbType.VarChar, 500);
                arParms[6].Value = objCustomer.Customer.BillingAddress.Address2;

                arParms[7] = new SqlParameter("@billcountryid", SqlDbType.BigInt);
                arParms[7].Value = Convert.ToInt64(objCustomer.Customer.BillingAddress.CountryID);

                arParms[8] = new SqlParameter("@billstateid", SqlDbType.BigInt);
                arParms[8].Value = Convert.ToInt64(objCustomer.Customer.BillingAddress.StateID);

                arParms[9] = new SqlParameter("@billcityid", SqlDbType.BigInt);
                arParms[9].Value = Convert.ToInt64(objCustomer.Customer.BillingAddress.CityID);

                arParms[10] = new SqlParameter("@billzip", SqlDbType.BigInt);
                arParms[10].Value = Convert.ToInt64(objCustomer.Customer.BillingAddress.ZipID);

                arParms[11] = new SqlParameter("@billphone", SqlDbType.VarChar, 500);
                arParms[11].Value = objCustomer.Customer.BillingAddress.PhoneNumber;


                arParms[12] = new SqlParameter("@paymentid", SqlDbType.BigInt);
                arParms[12].Value = Convert.ToInt64(objCustomer.PaymentDetail.PaymentType.PaymentTypeID);

                arParms[13] = new SqlParameter("@chkspecialoffer", SqlDbType.Bit);
                arParms[13].Value = Convert.ToByte(chkspecialoffer);

                arParms[14] = new SqlParameter("@ispayonline", SqlDbType.Bit);
                arParms[14].Value = Convert.ToByte(objCustomer.PaymentOnline);

                arParms[15] = new SqlParameter("@user", SqlDbType.VarChar, 500);
                arParms[15].Value = (objCustomer.Customer.User.UserName);

                arParms[16] = new SqlParameter("@userId", SqlDbType.BigInt);
                arParms[16].Value = Convert.ToInt64(objCustomer.Customer.User.UserID);

                arParms[17] = new SqlParameter("@paymentdetailId", SqlDbType.BigInt);
                arParms[17].Direction = ParameterDirection.Output;

                arParms[18] = new SqlParameter("returnvalue", SqlDbType.BigInt);
                arParms[18].Direction = ParameterDirection.Output;

                arParms[19] = new SqlParameter("@reportmailcost", SqlDbType.Decimal, 18);
                arParms[19].Value = Convert.ToDecimal(objCustomer.ReportEmailAmt);

                arParms[20] = new SqlParameter("@mailreports", SqlDbType.Bit);
                arParms[20].Value = Convert.ToInt64(objCustomer.ReportEmail);

                arParms[21] = new SqlParameter("@coupondiscount", SqlDbType.Decimal, 18);
                arParms[21].Value = Convert.ToDecimal(objCustomer.Coupon.CouponAmount);

                arParms[22] = new SqlParameter("@couponid", SqlDbType.BigInt);
                arParms[22].Value = Convert.ToInt64(objCustomer.Coupon.CouponID);

                arParms[23] = new SqlParameter("@paymentdetailsid", SqlDbType.BigInt);
                arParms[23].Value = Convert.ToInt64(objCustomer.PaymentDetail.PaymentDetailID);

                // added column marketingsource 
                arParms[24] = new SqlParameter("@marketingSource", SqlDbType.VarChar, 500);
                arParms[24].Value = objCustomer.MarketingSource;

                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UI_updateregistercustomer", arParms);

                paymentdetailId = Convert.ToInt64(arParms[17].Value);
                returnvalue = Convert.ToInt64(arParms[18].Value);
                return returnvalue;
            }
            catch (Exception)
            {
                return returnvalue;
            }

        }

        public Int64 UpdateCustomerWithoutCharge(EEventCustomer objCustomer, bool chkbillingaddress, bool chkspecialoffer, out Int64 paymentdetailId)
        {
            SqlParameter[] arParms = new SqlParameter[25];


            paymentdetailId = 0;
            Int64 returnvalue = new Int64();
            returnvalue = -1;

            try
            {

                arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
                arParms[0].Value = Convert.ToInt64(objCustomer.EventID);

                arParms[1] = new SqlParameter("@packageid", SqlDbType.BigInt);
                arParms[1].Value = Convert.ToInt64(objCustomer.EventPackage.Package.PackageID);

                arParms[2] = new SqlParameter("@packagecost", SqlDbType.Decimal);
                arParms[2].Value = Convert.ToDecimal(objCustomer.EventPackage.Package.CostPrice);

                arParms[3] = new SqlParameter("@appointmentid", SqlDbType.BigInt);
                arParms[3].Value = Convert.ToInt64(objCustomer.EventAppointment.AppointmentID);

                arParms[4] = new SqlParameter("@chkbillingaddress", SqlDbType.Bit);
                arParms[4].Value = Convert.ToByte(chkbillingaddress);

                arParms[5] = new SqlParameter("@billaddress1", SqlDbType.VarChar, 500);
                arParms[5].Value = objCustomer.Customer.BillingAddress.Address1;

                arParms[6] = new SqlParameter("@billaddress2", SqlDbType.VarChar, 500);
                arParms[6].Value = objCustomer.Customer.BillingAddress.Address2;

                arParms[7] = new SqlParameter("@billcountryid", SqlDbType.BigInt);
                arParms[7].Value = Convert.ToInt64(objCustomer.Customer.BillingAddress.CountryID);

                arParms[8] = new SqlParameter("@billstateid", SqlDbType.BigInt);
                arParms[8].Value = Convert.ToInt64(objCustomer.Customer.BillingAddress.StateID);

                arParms[9] = new SqlParameter("@billcityid", SqlDbType.BigInt);
                arParms[9].Value = Convert.ToInt64(objCustomer.Customer.BillingAddress.CityID);

                arParms[10] = new SqlParameter("@billzip", SqlDbType.BigInt);
                arParms[10].Value = Convert.ToInt64(objCustomer.Customer.BillingAddress.ZipID);

                arParms[11] = new SqlParameter("@billphone", SqlDbType.VarChar, 500);
                arParms[11].Value = objCustomer.Customer.BillingAddress.PhoneNumber;


                arParms[12] = new SqlParameter("@paymentid", SqlDbType.BigInt);
                arParms[12].Value = Convert.ToInt64(objCustomer.PaymentDetail.PaymentType.PaymentTypeID);

                arParms[13] = new SqlParameter("@chkspecialoffer", SqlDbType.Bit);
                arParms[13].Value = Convert.ToByte(chkspecialoffer);



                arParms[14] = new SqlParameter("@ispayonline", SqlDbType.Bit);
                arParms[14].Value = Convert.ToByte(objCustomer.PaymentOnline);

                arParms[15] = new SqlParameter("@user", SqlDbType.VarChar, 500);
                arParms[15].Value = (objCustomer.Customer.User.UserName);

                arParms[16] = new SqlParameter("@userId", SqlDbType.BigInt);
                arParms[16].Value = Convert.ToInt64(objCustomer.Customer.User.UserID);

                arParms[17] = new SqlParameter("@paymentdetailId", SqlDbType.BigInt);
                arParms[17].Direction = ParameterDirection.Output;

                arParms[18] = new SqlParameter("returnvalue", SqlDbType.BigInt);
                arParms[18].Direction = ParameterDirection.Output;

                arParms[19] = new SqlParameter("@reportmailcost", SqlDbType.Decimal, 18);
                //arParms[22].Scale = 2;
                arParms[19].Value = Convert.ToDecimal(objCustomer.ReportEmailAmt);

                arParms[20] = new SqlParameter("@mailreports", SqlDbType.Bit);
                arParms[20].Value = Convert.ToInt64(objCustomer.ReportEmail);

                arParms[21] = new SqlParameter("@coupondiscount", SqlDbType.Decimal, 18);
                //arParms[24].Scale = 2;
                arParms[21].Value = Convert.ToDecimal(objCustomer.Coupon.CouponAmount);

                arParms[22] = new SqlParameter("@couponid", SqlDbType.BigInt);
                arParms[22].Value = Convert.ToInt64(objCustomer.Coupon.CouponID);

                arParms[23] = new SqlParameter("@paymentdetailsid", SqlDbType.BigInt);
                arParms[23].Value = Convert.ToInt64(objCustomer.PaymentDetail.PaymentDetailID);


                // added column marketingsource 
                arParms[24] = new SqlParameter("@marketingSource", SqlDbType.VarChar, 500);
                arParms[24].Value = objCustomer.MarketingSource;
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UI_updatePaymentWithoutCharge", arParms);


                paymentdetailId = Convert.ToInt64(arParms[17].Value);
                returnvalue = Convert.ToInt64(arParms[18].Value);
                return returnvalue;
            }
            catch (Exception)
            {
                return returnvalue;
            }

        }
        #endregion

        public Int64 SaveBlockedDay(EBlockedDay objBlockedDay, int Mode)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[7];

            arParms[0] = new SqlParameter("@blockeddayid", SqlDbType.BigInt);
            arParms[0].Value = objBlockedDay.BlockedDayID;

            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;

            arParms[2] = new SqlParameter("@blockdate", SqlDbType.VarChar, 20);
            arParms[2].Value = objBlockedDay.BlockedDate;
            arParms[3] = new SqlParameter("@blockedreason", SqlDbType.VarChar, 500);
            arParms[3].Value = objBlockedDay.BlockedReason;
            arParms[4] = new SqlParameter("@isactive", SqlDbType.Bit);
            arParms[4].Value = objBlockedDay.IsActive;
            arParms[5] = new SqlParameter("@isglobal", SqlDbType.Bit);
            arParms[5].Value = objBlockedDay.IsGlobal;
            arParms[6] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[6].Value = Mode;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveblockedday", arParms);
            returnvalue = (Int64)arParms[1].Value;
            if (objBlockedDay.BlockDayFranchisee != null)
            {
                SaveBlockedDayFranchisee(objBlockedDay.BlockDayFranchisee, returnvalue, Mode);
            }

            return returnvalue;
        }
        
        public Int64 SaveBlockedDayFranchisee(List<EBlockedDayFranchisee> objBFranchisee, Int64 intBlockedDayId, int Mode)
        {
            Int64 returnvalue = new Int64();
            for (int icount = 0; icount < objBFranchisee.Count; icount++)
            {

                SqlParameter[] arParms = new SqlParameter[6];

                arParms[0] = new SqlParameter("@blockeddayfranchiseeid", SqlDbType.BigInt);
                arParms[0].Value = objBFranchisee[icount].BlockedDayFranchiseeID;
                arParms[1] = new SqlParameter("@blockeddayid", SqlDbType.BigInt);
                arParms[1].Value = intBlockedDayId;
                arParms[2] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
                arParms[2].Value = objBFranchisee[icount].Franchisee.FranchiseeID;

                arParms[3] = new SqlParameter("@isactive", SqlDbType.Bit);
                arParms[3].Value = objBFranchisee[icount].IsActive;
                arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[4].Direction = ParameterDirection.Output;
                arParms[5] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[5].Value = Mode;
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveblockeddayfranchisee", arParms);
                returnvalue = (Int64)arParms[4].Value;
            }

            return returnvalue;
        }
        
        public List<EBlockedDay> GetBlockedDayForCalendar(long intFranchiseeID, string strStartDate, string strEndDate, Int16 mode)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@OrganizationRoleUserId", SqlDbType.BigInt);
            arParms[0].Value = intFranchiseeID;
            arParms[1] = new SqlParameter("@startdate", SqlDbType.VarChar, 30);
            arParms[1].Value = strStartDate;
            arParms[2] = new SqlParameter("@enddate", SqlDbType.VarChar, 30);
            arParms[2].Value = strEndDate;
            arParms[3] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[3].Value = mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getBlockedDaysForCalendar", arParms);
            List<EBlockedDay> objListBlockedDay = new List<EBlockedDay>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EBlockedDay objBlockedDay = new EBlockedDay();

                    objBlockedDay.BlockedDate = Convert.ToString(tempdataset.Tables[0].Rows[count]["BlockedDay"]);
                    objBlockedDay.BlockedDayID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["BlockedDayID"]);
                    objBlockedDay.BlockedReason = Convert.ToString(tempdataset.Tables[0].Rows[count]["BlockedReason"]);
                    objBlockedDay.IsActive = Convert.ToBoolean(tempdataset.Tables[0].Rows[count]["IsActive"]);
                    objBlockedDay.IsGlobal = Convert.ToBoolean(tempdataset.Tables[0].Rows[count]["IsGlobal"]);

                    List<EBlockedDayFranchisee> objListBlockedDayFranchisee = new List<EBlockedDayFranchisee>();
                    if (tempdataset.Tables[1].Rows.Count > 0)
                    {
                        tempdataset.Tables[1].DefaultView.RowFilter = "BlockedDaysID =" + objBlockedDay.BlockedDayID;
                        if (tempdataset.Tables[1].DefaultView.Count > 0)
                        {
                            for (int icount = 0; icount < tempdataset.Tables[1].DefaultView.Count; icount++)
                            {
                                try
                                {
                                    EBlockedDayFranchisee objBlockedDayFranchisee = new EBlockedDayFranchisee();
                                    objBlockedDayFranchisee.BlockedDayFranchiseeID = Convert.ToInt32(tempdataset.Tables[1].Rows[icount]["BlockedDayFranchiseeID"]);
                                    objBlockedDayFranchisee.BlockedDayID = Convert.ToInt32(tempdataset.Tables[1].Rows[icount]["BlockedDaysID"]);
                                    //objBlockedDayFranchisee.FranchiseeID = Convert.ToInt32(tempdataset.Tables[1].Rows[icount]["FranchiseeID"]);
                                    objBlockedDayFranchisee.IsActive = Convert.ToBoolean(tempdataset.Tables[1].Rows[icount]["IsActive"]);
                                    objBlockedDayFranchisee.Franchisee = new Entity.Franchisee.EFranchisee();
                                    objBlockedDayFranchisee.Franchisee.FranchiseeID = Convert.ToInt32(tempdataset.Tables[1].Rows[icount]["FranchiseeID"]);
                                    objBlockedDayFranchisee.Franchisee.Name = Convert.ToString(tempdataset.Tables[1].Rows[icount]["Franchisee"]);

                                    objListBlockedDayFranchisee.Add(objBlockedDayFranchisee);
                                }
                                catch (Exception)
                                { }
                            }

                            objBlockedDay.BlockDayFranchisee = objListBlockedDayFranchisee;
                        }
                    }
                    objListBlockedDay.Add(objBlockedDay);
                }

                catch (Exception)
                { }
            }

            return objListBlockedDay;

        }

        public List<EPrimaryCarePhysician> GetPCPDetails(string name, int stateId)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 500);
            arParms[0].Value = name;
            arParms[1] = new SqlParameter("@stateId", SqlDbType.BigInt);
            arParms[1].Value = stateId;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getpcpdetails", arParms);
            var lstPCP = new List<EPrimaryCarePhysician>();

            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                var objPCP = new EPrimaryCarePhysician();
                objPCP.PrimaryCarePhysicianID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["PrimaryCarePhysicianID"]);
                objPCP.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[count]["FirstName"]);
                objPCP.LastName = Convert.ToString(tempdataset.Tables[0].Rows[count]["LastName"]);
                objPCP.PCPAddress = new EAddress();
                objPCP.PCPAddress.Address1 = Convert.ToString(tempdataset.Tables[0].Rows[count]["Address1"]);
                objPCP.PCPAddress.Address2 = Convert.ToString(tempdataset.Tables[0].Rows[count]["Address2"]);
                objPCP.PCPAddress.City = Convert.ToString(tempdataset.Tables[0].Rows[count]["City"]);
                objPCP.PCPAddress.State = Convert.ToString(tempdataset.Tables[0].Rows[count]["StateCode"]);
                objPCP.PCPAddress.ZipID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["ZipCode"]);
                lstPCP.Add(objPCP);
            }

            return lstPCP;
        }

        #region "MarketingSource"
        public Int64 SaveMarketingSource(EMarketingSource marketingsource, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@marketingsourceid", SqlDbType.BigInt);
            arParms[0].Value = marketingsource.MarketingSourceID;
            arParms[1] = new SqlParameter("@label", SqlDbType.VarChar, 500);
            arParms[1].Value = marketingsource.Label;
            arParms[2] = new SqlParameter("@notes", SqlDbType.VarChar, 1000);
            arParms[2].Value = marketingsource.Notes;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = Mode;
            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemarketingsource", arParms);
            return (Int64)arParms[4].Value;
        }
        public Int64 SaveMarketingSource(String marketingsourceID, int Mode)
        {
            
            SqlParameter[] arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@marketingsourceid", SqlDbType.VarChar, 3000);
            arParms[0].Value = marketingsourceID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removemarketingsource", arParms);
            return (Int64)arParms[2].Value;

            
        }
        public List<EMarketingSource> GetMarketingSource(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getMarketingSource", arParms);

            List<EMarketingSource> returnMarketingSource = new List<EMarketingSource>();
            returnMarketingSource = ParseMarketingSourceDataSet(tempdataset);
            return returnMarketingSource;
        }
        private List<EMarketingSource> ParseMarketingSourceDataSet(DataSet marketingsourceDataSet)
        {
            List<EMarketingSource> returnMarketingSource = new List<EMarketingSource>();

            for (int count = 0; count < marketingsourceDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EMarketingSource marketingsource = new EMarketingSource();
                    marketingsource.IsActive = Convert.ToBoolean(marketingsourceDataSet.Tables[0].Rows[count]["IsActive"]);
                    marketingsource.MarketingSourceID = Convert.ToInt32(marketingsourceDataSet.Tables[0].Rows[count]["MarketingSourceID"]);
                    marketingsource.Notes = Convert.ToString(marketingsourceDataSet.Tables[0].Rows[count]["Notes"]);
                    marketingsource.Label = Convert.ToString(marketingsourceDataSet.Tables[0].Rows[count]["Label"]);
                    returnMarketingSource.Add(marketingsource);
                }
                catch
                {
                }
            }
            return returnMarketingSource;
        }

        public Int64 GetUid(int customerid)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arParms[0].Value = customerid;

            arParms[1] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_getuidbycid", arParms);
            returnvalue = Convert.ToInt64(arParms[1].Value);
            return returnvalue;
        }
        #endregion

        public Int64 CheckDuplicateAppointment(string AppointmentID)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@AppointmentID", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt32(AppointmentID);

            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            Int64 returnvalue = new Int64();
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_CheckDuplicateAppointment", arParms);
            returnvalue = Convert.ToInt64(arParms[1].Value);
            return returnvalue;
        }

        public Int64 SaveUserLoginInfo(ELoginLog objLoginLog, out string lastLoginTime)
        {
            SqlParameter[] arPrms = new SqlParameter[10];

            arPrms[0] = new SqlParameter("@UserLoginLogID", SqlDbType.BigInt);
            arPrms[0].Value = objLoginLog.UserLoginLogID;

            arPrms[1] = new SqlParameter("@UserID", SqlDbType.BigInt);
            arPrms[1].Value = objLoginLog.UserID;

            arPrms[2] = new SqlParameter("@LoginDatetime", SqlDbType.VarChar, 20);
            arPrms[2].Value = objLoginLog.LoginDatetime;

            arPrms[3] = new SqlParameter("@LogoutDatetime", SqlDbType.VarChar, 20);
            if (objLoginLog.LogoutDatetime == null || objLoginLog.LogoutDatetime.Trim() == "")
                arPrms[3].Value = DBNull.Value;
            else
                arPrms[3].Value = objLoginLog.LogoutDatetime;

            arPrms[4] = new SqlParameter("@BrowserSessionID", SqlDbType.VarChar, 500);
            arPrms[4].Value = objLoginLog.BrowserSessionID;

            arPrms[5] = new SqlParameter("@BrowserType", SqlDbType.VarChar, 500);
            arPrms[5].Value = objLoginLog.BrowserType;

            arPrms[6] = new SqlParameter("@SessionIP", SqlDbType.VarChar, 50);
            arPrms[6].Value = objLoginLog.SessionIP;

            arPrms[7] = new SqlParameter("@ReferredlUrl", SqlDbType.VarChar, 1000);
            arPrms[7].Value = objLoginLog.ReferredlUrl;

            arPrms[8] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arPrms[8].Direction = ParameterDirection.Output;

            arPrms[9] = new SqlParameter("@LastLoginTime", SqlDbType.VarChar, 30);
            arPrms[9].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_SaveUserLoginInfo", arPrms);

            long returnvalue = Convert.ToInt64(arPrms[8].Value);
            lastLoginTime = Convert.ToString(arPrms[9].Value);
            return returnvalue;
        }

        public Int64 SaveProspectCustomerData(int ProspectCustomerID, string FieldName, string Value)
        {
            SqlParameter[] arPrams = new SqlParameter[4];

            arPrams[0] = new SqlParameter("@ProspectCustomerID", SqlDbType.BigInt);
            arPrams[0].Value = ProspectCustomerID;

            arPrams[1] = new SqlParameter("@FieldName", SqlDbType.VarChar, 200);
            arPrams[1].Value = FieldName;

            arPrams[2] = new SqlParameter("@Value", SqlDbType.VarChar, 200);
            arPrams[2].Value = Value;

            arPrams[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arPrams[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveProspectCustomerColumnWise", arPrams);

            return Convert.ToInt64(arPrams[3].Value);
        }

        public DataSet GetStateCityByZipCode(string Zipcode)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ZipCode", SqlDbType.VarChar, 10);
            arParms[0].Value = Zipcode;
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getStateCityByZipCode", arParms);
            return ds;
        }

        public List<EResultOrderCatalog> GetAllResultOrderCatalog()
        {
            List<EResultOrderCatalog> objListResultOrderCatalog = new List<EResultOrderCatalog>();
            DataSet tempDataset = new DataSet();
            tempDataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getAllResultOrderCatalog",null);
            if (tempDataset != null && tempDataset.Tables[0] != null && tempDataset.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = tempDataset.Tables[0];
                for (int count = 0; count < dt.Rows.Count; count++)
                {
                    EResultOrderCatalog objResultOrderCatalog = new EResultOrderCatalog();
                    objResultOrderCatalog.ResultOrderCatalogID = Convert.ToInt32(dt.Rows[count]["ResultOrderCatalogID"]);
                    objResultOrderCatalog.Title = Convert.ToString(dt.Rows[count]["Title"]);
                    objResultOrderCatalog.Description = Convert.ToString(dt.Rows[count]["Description"]);
                    objResultOrderCatalog.SalePrice = Convert.ToSingle(dt.Rows[count]["SalePrice"]);
                    objResultOrderCatalog.CostPrice = Convert.ToSingle(dt.Rows[count]["CostPrice"]);
                    objResultOrderCatalog.IsActive = Convert.ToBoolean(dt.Rows[count]["IsActive"]);
                    objResultOrderCatalog.DateCreated = Convert.ToString(dt.Rows[count]["DateCreated"]);
                    objResultOrderCatalog.DateModified = Convert.ToString(dt.Rows[count]["DateModified"]);
                    objResultOrderCatalog.Disclaimer = Convert.ToString(dt.Rows[count]["Disclaimer"]);

                    objListResultOrderCatalog.Add(objResultOrderCatalog);
                }
            }
            return objListResultOrderCatalog;
        }

        public Int64 SaveOrderDetail(EOrder objOrder)
        {
            SqlParameter[] arParms = new SqlParameter[10];

            arParms[0] = new SqlParameter("@ShippingAddressID", SqlDbType.BigInt);
            arParms[0].Value = objOrder.ShippingAddressID;

            arParms[1] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            arParms[1].Value = objOrder.CreatedBy;

            arParms[2] = new SqlParameter("@CustomerID", SqlDbType.BigInt);
            arParms[2].Value = objOrder.CustomerID;

            arParms[3] = new SqlParameter("@OrderTypeID", SqlDbType.BigInt);
            arParms[3].Value = objOrder.OrderTypeID;

            arParms[4] = new SqlParameter("@IsPaid", SqlDbType.Bit);
            arParms[4].Value = objOrder.IsPaid;

            arParms[5] = new SqlParameter("@Status", SqlDbType.BigInt);
            arParms[5].Value = objOrder.Status;

            arParms[6] = new SqlParameter("@ResultCatalogID", SqlDbType.BigInt);
            arParms[6].Value = objOrder.ResultCatalogID;

            arParms[7] = new SqlParameter("@OrderID", SqlDbType.BigInt);
            arParms[7].Direction = ParameterDirection.Output;

            arParms[8] = new SqlParameter("@EventID", SqlDbType.BigInt);
            arParms[8].Value = objOrder.EventID;

            arParms[9] = new SqlParameter("@CreatedByRole", SqlDbType.BigInt);
            arParms[9].Value = objOrder.CreatedByRole;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveOrderDetail", arParms);

            Int64 returnResult = new Int64();
            returnResult = Convert.ToInt64(arParms[7].Value);

            return returnResult;
        }

        public DataSet GetOrderDetail(string CustomerName, string StartDate, string EndDate, int CustomerID, int OrderStatus, int DeliveryMode, int mode)
        {
            SqlParameter[] arPrms = new SqlParameter[7];

            arPrms[0] = new SqlParameter("@customername", SqlDbType.VarChar, 50);
            if (CustomerName.Trim().Length > 0)
                arPrms[0].Value = CustomerName;
            else
                arPrms[0].Value = DBNull.Value;

            arPrms[1] = new SqlParameter("@startdate", SqlDbType.VarChar, 50);
            if (StartDate.Trim().Length > 0)
                arPrms[1].Value = StartDate;
            else
                arPrms[1].Value = DBNull.Value;

            arPrms[2] = new SqlParameter("@enddate", SqlDbType.VarChar, 50);
            if (EndDate.Trim().Length > 0)
                arPrms[2].Value = EndDate;
            else
                arPrms[2].Value = DBNull.Value;

            arPrms[3] = new SqlParameter("@Customerid", SqlDbType.BigInt);
            arPrms[3].Value = CustomerID;

            arPrms[4] = new SqlParameter("@orderstatus", SqlDbType.Int);
            arPrms[4].Value = OrderStatus;

            arPrms[5] = new SqlParameter("@deliverymode", SqlDbType.Int);
            arPrms[5].Value = DeliveryMode;

            arPrms[6] = new SqlParameter("@mode", SqlDbType.Int);
            arPrms[6].Value = mode;

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring,  "usp_getOrderDetail", arPrms);

            return ds;
        }

        public bool AcceptOrder(string OrderID, string UserID, string RoleID)
        {
            SqlParameter[] arParms = new SqlParameter[4];

            arParms[0] = new SqlParameter("@OrderID", SqlDbType.VarChar, 20);
            arParms[0].Value = OrderID;

            arParms[1] = new SqlParameter("@UserID", SqlDbType.VarChar, 20);
            arParms[1].Value = UserID;

            arParms[2] = new SqlParameter("@RoleID", SqlDbType.VarChar, 10);
            arParms[2].Value = RoleID;

            arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_AcceptOrder", arParms);

            return int.Parse(arParms[3].Value.ToString()) > 0;
        }

        public List<ECarrier> GetAllCarrier()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getAllCarrier",null);

            List<ECarrier> lobjCarrier = new List<ECarrier>();

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                for (int count = 0; count < dt.Rows.Count; count++)
                {
                    ECarrier objCarrier = new ECarrier();
                    objCarrier.CarrierID = Convert.ToInt32(dt.Rows[count]["CarrierID"]);
                    objCarrier.Carrier = Convert.ToString(dt.Rows[count]["Carrier"]);

                    lobjCarrier.Add(objCarrier);
                }

            }
            return lobjCarrier;
        }

        public EOrderShippingInformation GetShippingInfo(int OrderID, int OrderShippingInformationID)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@OrderID", SqlDbType.BigInt);
            arParms[0].Value = OrderID;

            arParms[1] = new SqlParameter("@OrderShippingInformationID", SqlDbType.BigInt);
            arParms[1].Value = OrderShippingInformationID;

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring,  "usp_getShippingInfo", arParms);

            EOrderShippingInformation objOrderShippingInfo = new EOrderShippingInformation();

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                objOrderShippingInfo.Carrier = Convert.ToInt32(dt.Rows[0]["Carrier"]);
                objOrderShippingInfo.CarrierTransactionNumber = Convert.ToString(dt.Rows[0]["CarrierTransactionNumber"]);
                objOrderShippingInfo.TrackingNumber = Convert.ToString(dt.Rows[0]["TrackingNumber"]);
                objOrderShippingInfo.OrderShippingInformationID = Convert.ToInt32(dt.Rows[0]["OrderShippingInformationID"]);
                objOrderShippingInfo.ShippingAddressID = Convert.ToInt32(dt.Rows[0]["ShippingAddressID"]);
                objOrderShippingInfo.ShippingDate = Convert.ToString(dt.Rows[0]["ShippingDate"]);
                objOrderShippingInfo.ShippingNotes = Convert.ToString(dt.Rows[0]["ShippingNotes"]);
                objOrderShippingInfo.ShippingAddress = new EAddress();
                objOrderShippingInfo.ShippingAddress.Address1 = Convert.ToString(dt.Rows[0]["Address1"]);
                objOrderShippingInfo.ShippingAddress.Address2 = Convert.ToString(dt.Rows[0]["Address2"]);
                objOrderShippingInfo.ShippingAddress.AddressID = Convert.ToInt32(dt.Rows[0]["ShippingAddressID"]);
                objOrderShippingInfo.ShippingAddress.City = Convert.ToString(dt.Rows[0]["City"]);
                objOrderShippingInfo.ShippingAddress.State = Convert.ToString(dt.Rows[0]["State"]);
                objOrderShippingInfo.ShippingAddress.Zip = Convert.ToString(dt.Rows[0]["ZipCode"]);
            }
            return objOrderShippingInfo;
        }

        public Int64 UpdateShippingInfo(EOrderShippingInformation objShippingInfo)
        {
            SqlParameter[] arParms = new SqlParameter[10];

            arParms[0] = new SqlParameter("@OrderShippingInformationID", SqlDbType.BigInt);
            arParms[0].Value = objShippingInfo.OrderShippingInformationID;

            arParms[1] = new SqlParameter("@Carrier", SqlDbType.BigInt);
            arParms[1].Value = objShippingInfo.Carrier;

            arParms[2] = new SqlParameter("@CarrierTransactionNumber", SqlDbType.VarChar, 255);
            arParms[2].Value = objShippingInfo.CarrierTransactionNumber;

            arParms[3] = new SqlParameter("@ShippingAddressID", SqlDbType.BigInt);
            arParms[3].Value = objShippingInfo.ShippingAddressID;

            arParms[4] = new SqlParameter("@TrackingNumber", SqlDbType.VarChar, 255);
            arParms[4].Value = objShippingInfo.TrackingNumber;

            arParms[5] = new SqlParameter("@ShippingDate", SqlDbType.DateTime);
            arParms[5].Value = Convert.ToDateTime(objShippingInfo.ShippingDate);

            arParms[6] = new SqlParameter("@ShippingNotes", SqlDbType.VarChar, 1024);
            arParms[6].Value = objShippingInfo.ShippingNotes;

            arParms[7] = new SqlParameter("@ModifiedBy", SqlDbType.BigInt);
            arParms[7].Value = objShippingInfo.LastModifiedBy;

            arParms[8] = new SqlParameter("@ModifiedByRole", SqlDbType.BigInt);
            arParms[8].Value = objShippingInfo.LastModifiedByRole;

            arParms[9] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[9].Direction = ParameterDirection.Output;

            Int64 returnvalue = new Int64();

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UpdateShippingInfo", arParms);

            returnvalue = Convert.ToInt64(arParms[9].Value);

            return returnvalue;

        }

        public DataSet SearchOrderForUpcomingEvents()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_searchOrderForUpcomingEvents",null);

            return ds;
        }

        public DataSet GetReceiptDetails(string customerid, string eventid)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@EventID", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt32(eventid);
            arParms[1] = new SqlParameter("@CustomerID", SqlDbType.BigInt);
            arParms[1].Value = Convert.ToInt32(customerid);
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring,  "usp_getReceiptDetails", arParms);

            return ds;
        }

        public List<EZip> GetSimilarZipCode(string filterstring, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 20);
            arParms[0].Value = filterstring;
            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring,  "usp_getSimilarZipCode", arParms);
            List<EZip> objLZip = new List<EZip>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dtZip = ds.Tables[0];
                if (dtZip.Rows.Count > 0)
                {
                    for (int count = 0; count < dtZip.Rows.Count; count++)
                    {
                        EZip objZip = new EZip();
                        objZip.ZipCode = Convert.ToString(dtZip.Rows[count]["ZipDetail"]);
                        objZip.ZipID = Convert.ToInt32(dtZip.Rows[count]["ZipID"]);
                        objLZip.Add(objZip);
                    }
                }
            }
            return objLZip;
        }

        public Int64 SaveCreditCardPaymentDetails(ECreditCardPaymentDetail cardpaymentdetails, Int16 mode)
        {
            var arParms = new SqlParameter[14];
            arParms[0] = new SqlParameter("@creditcardpaymentID", SqlDbType.BigInt) { Value = cardpaymentdetails.CreditCardPaymentID };
            arParms[1] = new SqlParameter("@creditcardnumber", SqlDbType.VarChar, 50) { Value = cardpaymentdetails.CreditCardNumber };
            arParms[2] = new SqlParameter("@creditcardtypeid", SqlDbType.BigInt)
                             {
                                 Value = cardpaymentdetails.CreditCardType.CreditCardTypeID
                             };
            arParms[3] = new SqlParameter("@paymentid", SqlDbType.BigInt) { Value = cardpaymentdetails.PaymentID };
            arParms[4] = new SqlParameter("@paymentstatus", SqlDbType.VarChar, 50) { Value = cardpaymentdetails.PaymentStatus };
            arParms[5] = new SqlParameter("@expirationdate", SqlDbType.DateTime) { Value = cardpaymentdetails.ExpirationDate };

            arParms[6] = new SqlParameter("@userid", SqlDbType.VarChar, 500) { Value = DBNull.Value };
            arParms[7] = new SqlParameter("@shell", SqlDbType.VarChar, 500) { Value = DBNull.Value };
            arParms[8] = new SqlParameter("@role", SqlDbType.VarChar, 500) { Value = DBNull.Value };
            arParms[9] = new SqlParameter("@mode", SqlDbType.TinyInt) { Value = mode };
            arParms[10] = new SqlParameter("@returnvalue", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            arParms[11] = new SqlParameter("@ccname", SqlDbType.VarChar, 50);
            if (cardpaymentdetails.CardHolderName != null && cardpaymentdetails.CardHolderName.Trim().Length > 1)
            {
                arParms[11].Value = cardpaymentdetails.CardHolderName;
            }
            else
            {
                arParms[11].Value = DBNull.Value;
            }

            arParms[12] = new SqlParameter("@cvv", SqlDbType.VarChar, 50);
            if (cardpaymentdetails.SecurityCode != null && cardpaymentdetails.SecurityCode.Trim().Length > 1)
                arParms[12].Value = cardpaymentdetails.SecurityCode;
            else
            {
                arParms[12].Value = DBNull.Value;
            }
            arParms[13] = new SqlParameter("@drorcr", SqlDbType.Bit) { Value = cardpaymentdetails.DrOrCr };

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savecreditcardpaymentdetails", arParms);

            return long.Parse(arParms[10].Value.ToString());
        }


        #region Check For PCB Details
        public Int64 CheckPCBDetails(Int64 UserId)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
            arParms[0].Value = UserId;

            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_CheckPCBDetails", arParms);

            Int64 returnResult = new Int64();
            returnResult = Convert.ToInt64(arParms[1].Value);
            return returnResult;

        }
        #endregion

        public Int64 UpdateUserHintQA(Entity.Other.EUser objUser)
        {
            SqlParameter[] arParms = new SqlParameter[7];

            arParms[0] = new SqlParameter("@email", SqlDbType.VarChar, 100);
            arParms[0].Value = objUser.EMail1;

            arParms[1] = new SqlParameter("@username", SqlDbType.VarChar, 200);
            arParms[1].Value = objUser.UserName;

            arParms[2] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            arParms[2].Value = objUser.Password;

            arParms[3] = new SqlParameter("@ques1", SqlDbType.VarChar, 100);
            arParms[3].Value = objUser.Question;

            arParms[4] = new SqlParameter("@ans1", SqlDbType.VarChar, 100);
            arParms[4].Value = objUser.Answer;

            arParms[5] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[5].Value = objUser.UserID;

            arParms[6] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[6].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UI_newUpdateUserDetails", arParms);

            Int64 returnresult = Convert.ToInt64(arParms[6].Value);
            return returnresult;
        }
                

        /// <summary>
        /// Get Similar ZipCode By Distance and zipcode
        /// </summary>
        /// <param name="filterstring"></param>
        /// <param name="distance"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<EZip> GetSimilarZipCodeByDistance(string filterstring, string distance, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 20);
            arParms[0].Value = filterstring;
            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;
            arParms[2] = new SqlParameter("@distance", SqlDbType.Int);
            arParms[2].Value = Convert.ToInt32(distance);
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getSimilarZipCode", arParms);
            List<EZip> objLZip = new List<EZip>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dtZip = ds.Tables[0];
                if (dtZip.Rows.Count > 0)
                {
                    for (int count = 0; count < dtZip.Rows.Count; count++)
                    {
                        EZip objZip = new EZip();
                        objZip.ZipCode = Convert.ToString(dtZip.Rows[count]["ZipDetail"]);
                        objZip.ZipID = Convert.ToInt32(dtZip.Rows[count]["ZipID"]);
                        objLZip.Add(objZip);
                    }
                }
            }
            return objLZip;
        }

        public string GetToolTipByTagName(string tagName)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@TagName", SqlDbType.VarChar, 500);
            arParms[0].Value = tagName;

            string content = "";
            DataSet ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getToolTipByTagName", arParms);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                content = ds.Tables[0].Rows[0]["Content"].ToString();
            }
            return content;

        }

        public List<string> GetEmailIdByEventId(long eventId, string podIds)
        {
            var emailIds = new List<string>();

            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@EventId", SqlDbType.BigInt);
            arParms[0].Value = eventId;

            arParms[1] = new SqlParameter("@podIds", SqlDbType.VarChar, 255);
            arParms[1].Value = podIds;

            var dsEmailIds = SqlHelper.ExecuteDataset(connectionstring,  "usp_getAllEmailByEventID", arParms);

            if (dsEmailIds.Tables.Count > 0 && dsEmailIds.Tables[0].Rows.Count > 0)
            {
                emailIds.Add(Convert.ToString(dsEmailIds.Tables[0].Rows[0]["SalesRepEmailId"]));
                emailIds.Add(Convert.ToString(dsEmailIds.Tables[0].Rows[0]["TechTeamEmailIds"]));
            }
            return emailIds;
        }


        public List<string> GetEventInformationOfPrintOrderItem(string sourceCode)
        {
            var eventInfo = new List<string>();

            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@sourceCode", SqlDbType.VarChar, 50);
            arParms[0].Value = sourceCode;


            var dsEventInfo = SqlHelper.ExecuteDataset(connectionstring,  "[usp_GetEventInformationOfPrintOrderItem]", arParms);

            if (dsEventInfo.Tables.Count > 0 && dsEventInfo.Tables[0].Rows.Count > 0)
            {
                eventInfo.Add(Convert.ToString(dsEventInfo.Tables[0].Rows[0]["SalesRepEmail"]));
                eventInfo.Add(Convert.ToString(dsEventInfo.Tables[0].Rows[0]["AdvocateName"]));
                eventInfo.Add(Convert.ToString(dsEventInfo.Tables[0].Rows[0]["MarektingMaterial"]));
                eventInfo.Add(Convert.ToString(dsEventInfo.Tables[0].Rows[0]["EventDetail"]));
                eventInfo.Add(Convert.ToString(dsEventInfo.Tables[0].Rows[0]["DateConfirm"]));
            }
            return eventInfo;
        }

        // Get Campaign Details Based on SourceCode ID
        public ECampaignDetailToolTip GetCampaignDetailsToolTip(string sourceCode)
        {
            ECampaignDetailToolTip campaignDetailToolTip = null;
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@sourceCode", SqlDbType.VarChar, 255);
            arParms[0].Value = sourceCode;

            arParms[1] = new SqlParameter("@IsSalesRepCampaign", SqlDbType.Bit);
            arParms[1].Direction = ParameterDirection.Output;

            var campaignDetail = SqlHelper.ExecuteDataset(connectionstring, "[usp_getCampaignDetailsToolTip]", arParms);
            if (campaignDetail.Tables.Count > 0 && campaignDetail.Tables[0].Rows.Count > 0)
            {
                campaignDetailToolTip = new ECampaignDetailToolTip();
                campaignDetailToolTip.SourceCode = Convert.ToString(campaignDetail.Tables[0].Rows[0]["SourceCode"]);
                campaignDetailToolTip.CampaignID = Convert.ToInt32(campaignDetail.Tables[0].Rows[0]["CampaignID"]);
                campaignDetailToolTip.CampaignName = Convert.ToString(campaignDetail.Tables[0].Rows[0]["CampaignName"]);
                campaignDetailToolTip.Commission = Convert.ToDecimal(campaignDetail.Tables[0].Rows[0]["Commision"]);
                campaignDetailToolTip.ParentCommission = Convert.ToDecimal(campaignDetail.Tables[0].Rows[0]["ParentAffiliateCommision"]);
                campaignDetailToolTip.CampaignStartDate = Convert.ToDateTime(campaignDetail.Tables[0].Rows[0]["StartDate"]);
                campaignDetailToolTip.CampaignEndDate = Convert.ToDateTime(campaignDetail.Tables[0].Rows[0]["EndDate"]);
                campaignDetailToolTip.IsPercentageCommission = Convert.ToBoolean(campaignDetail.Tables[0].Rows[0]["IsCommisionPercentage"]);

                // advocate name
                if (Convert.ToString(campaignDetail.Tables[0].Rows[0]["AdvocateMiddleName"]) != "")
                    campaignDetailToolTip.AdvocateName = Convert.ToString(campaignDetail.Tables[0].Rows[0]["AdvocateFirstName"]) + " " + Convert.ToString(campaignDetail.Tables[0].Rows[0]["AdvocateMiddleName"]) + " " + Convert.ToString(campaignDetail.Tables[0].Rows[0]["AdvocateLastName"]);
                else
                    campaignDetailToolTip.AdvocateName = Convert.ToString(campaignDetail.Tables[0].Rows[0]["AdvocateFirstName"]) + " " + Convert.ToString(campaignDetail.Tables[0].Rows[0]["AdvocateLastName"]);
                // parent advocate name
                if (Convert.ToString(campaignDetail.Tables[0].Rows[0]["ParentAdvocateMiddleName"]) != "")
                    campaignDetailToolTip.ParentAdvocateName = Convert.ToString(campaignDetail.Tables[0].Rows[0]["ParentAdvocateFirstName"]) + " " + Convert.ToString(campaignDetail.Tables[0].Rows[0]["ParentAdvocateMiddleName"]) + " " + Convert.ToString(campaignDetail.Tables[0].Rows[0]["ParentAdvocateLastName"]);
                else
                    campaignDetailToolTip.ParentAdvocateName = Convert.ToString(campaignDetail.Tables[0].Rows[0]["ParentAdvocateFirstName"]) + " " + Convert.ToString(campaignDetail.Tables[0].Rows[0]["ParentAdvocateLastName"]);

                campaignDetailToolTip.IsSalesRepCampaign = Convert.ToBoolean(arParms[1].Value);
               
            }
            return campaignDetailToolTip;
        }

    }
}
