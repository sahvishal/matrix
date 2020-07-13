using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.Entity.Other;
using Falcon.Entity.MedicalVendor;
using Falcon.Entity.Franchisor;
using System.Data;
using System.Data.SqlClient;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;

namespace Falcon.DataAccess.MedicalVendor
{
    public class MedicalVendorDAL
    {
        private string connectionstring = ConnectionHandler.GetConnectionString();

        #region "MedicalVendorType"
        public Int64 SaveMedicalVendorType(EMedicalVendorType medicalvendortype, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@medicalvendortypeid", SqlDbType.BigInt);
            arParms[0].Value = medicalvendortype.MedicalVendorTypeID;
            arParms[1] = new SqlParameter("@medicalvendortypename", SqlDbType.VarChar, 500);
            arParms[1].Value = medicalvendortype.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = medicalvendortype.Description;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = Mode;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemedicalvendortype", arParms);
            return (Int64)arParms[4].Value;

        }
        public Int64 SaveMedicalVendorType(String medicalvendortypeID, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@medicalvendortypeid", SqlDbType.VarChar, 3000);
            arParms[0].Value = medicalvendortypeID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removemedicalvendortype", arParms);
            return (Int64)arParms[2].Value;

        }
        public List<EMedicalVendorType> GetMedicalVendorType(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getmedicalvendortype", arParms);

            List<EMedicalVendorType> returnMedicalVendorType = new List<EMedicalVendorType>();
            returnMedicalVendorType = ParseMedicalVendorTypeDataSet(tempdataset);
            return returnMedicalVendorType;
        }
        private List<EMedicalVendorType> ParseMedicalVendorTypeDataSet(DataSet medicalvendortypeDataSet)
        {
            List<EMedicalVendorType> returnMedicalVendorType = new List<EMedicalVendorType>();

            for (int count = 0; count < medicalvendortypeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EMedicalVendorType medicalvendortype = new EMedicalVendorType();
                    medicalvendortype.Active = Convert.ToBoolean(medicalvendortypeDataSet.Tables[0].Rows[count]["IsActive"]);
                    medicalvendortype.MedicalVendorTypeID = Convert.ToInt32(medicalvendortypeDataSet.Tables[0].Rows[count]["MedicalVendorTypeID"]);
                    medicalvendortype.Description = Convert.ToString(medicalvendortypeDataSet.Tables[0].Rows[count]["Description"]);
                    medicalvendortype.Name = Convert.ToString(medicalvendortypeDataSet.Tables[0].Rows[count]["Name"]);
                    returnMedicalVendorType.Add(medicalvendortype);
                }
                catch
                {
                }
            }
            return returnMedicalVendorType;
        }
        #endregion

        # region "MVUserSpecialization"
        public Int64 SaveMVUserSpecialization(EMVUserSpecialization mvuserspecialization, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@mvuserspecializationid", SqlDbType.BigInt);
            arParms[0].Value = mvuserspecialization.MVUserSpecilaizationID;
            arParms[1] = new SqlParameter("@mvuserspecializationname", SqlDbType.VarChar, 500);
            arParms[1].Value = mvuserspecialization.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = mvuserspecialization.Description;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = Mode;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvuserspecialization", arParms);
            return (Int64)arParms[4].Value;
        }

        public Int64 SaveMVUserSpecialization(String mvuserspecializationID, int Mode)
        {

            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@mvuserspecializationid", SqlDbType.VarChar, 3000);
            arParms[0].Value = mvuserspecializationID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removemvuserspecialization", arParms);
            return (Int64)arParms[2].Value;

        }
        public List<EMVUserSpecialization> GetMVUserSpecialization(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getmvuserspecializtion", arParms);

            List<EMVUserSpecialization> returnMVUserSpecialization = new List<EMVUserSpecialization>();
            returnMVUserSpecialization = ParseMVUserSpecializationDataSet(tempdataset);
            return returnMVUserSpecialization;
        }
        private List<EMVUserSpecialization> ParseMVUserSpecializationDataSet(DataSet mvuserspecializationDataSet)
        {
            List<EMVUserSpecialization> returnMVUserSpecialization = new List<EMVUserSpecialization>();

            for (int count = 0; count < mvuserspecializationDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EMVUserSpecialization mvuserspecialization = new EMVUserSpecialization();
                    mvuserspecialization.Active = Convert.ToBoolean(mvuserspecializationDataSet.Tables[0].Rows[count]["IsActive"]);
                    mvuserspecialization.MVUserSpecilaizationID = Convert.ToInt32(mvuserspecializationDataSet.Tables[0].Rows[count]["MVUserSpecializationID"]);
                    mvuserspecialization.Description = Convert.ToString(mvuserspecializationDataSet.Tables[0].Rows[count]["Description"]);
                    mvuserspecialization.Name = Convert.ToString(mvuserspecializationDataSet.Tables[0].Rows[count]["Name"]);
                    returnMVUserSpecialization.Add(mvuserspecialization);
                }
                catch
                {
                }
            }
            return returnMVUserSpecialization;
        }
        #endregion

        # region "MVUserClassification"
        public Int64 SaveMVUserClassification(EMVUserClassification mvuserclassification, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@mvuserclassificationid", SqlDbType.BigInt);
            arParms[0].Value = mvuserclassification.MVUserClassificationID;
            arParms[1] = new SqlParameter("@mvuserclassificationname", SqlDbType.VarChar, 500);
            arParms[1].Value = mvuserclassification.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = mvuserclassification.Description;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = Mode;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvuserclassification", arParms);
            return (Int64)arParms[4].Value;
        }
        public Int64 SaveMVUserClassification(String mvuserclassificationID, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@mvuserclassificationid", SqlDbType.VarChar, 3000);
            arParms[0].Value = mvuserclassificationID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removemvuserclassification", arParms);
            return (Int64)arParms[2].Value;
        }
        public List<EMVUserClassification> GetMVUserClassification(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmvuserclassification", arParms);

            List<EMVUserClassification> returnMVUserClassification = new List<EMVUserClassification>();
            returnMVUserClassification = ParseMVUserClassificationDataSet(tempdataset);
            return returnMVUserClassification;
        }
        private List<EMVUserClassification> ParseMVUserClassificationDataSet(DataSet mvuserclassificationDataSet)
        {
            List<EMVUserClassification> returnMVUserClassification = new List<EMVUserClassification>();

            for (int count = 0; count < mvuserclassificationDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EMVUserClassification mvuserclassification = new EMVUserClassification();
                    mvuserclassification.Active = Convert.ToBoolean(mvuserclassificationDataSet.Tables[0].Rows[count]["IsActive"]);
                    mvuserclassification.MVUserClassificationID = Convert.ToInt32(mvuserclassificationDataSet.Tables[0].Rows[count]["MVUserClassificationID"]);
                    mvuserclassification.Description = Convert.ToString(mvuserclassificationDataSet.Tables[0].Rows[count]["Description"]);
                    mvuserclassification.Name = Convert.ToString(mvuserclassificationDataSet.Tables[0].Rows[count]["Name"]);
                    returnMVUserClassification.Add(mvuserclassification);
                }
                catch
                {
                }
            }
            return returnMVUserClassification;
        }
        #endregion

        # region "MVUser"

        public List<EMVUser> GetMVUser(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmvuser", arParms);
            return ParseMVUserDataSet(tempdataset);

        }
        private List<EMVUser> ParseMVUserDataSet(DataSet mvuserDataSet)
        {
            List<EMVUser> returnMVUser = new List<EMVUser>();

            for (int count = 0; count < mvuserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EMVUser mvuser = new EMVUser();
                    EMVUserSpecialization mvuserspecialization = new EMVUserSpecialization();
                    EMVUserClassification mvuserclassification = new EMVUserClassification();
                    EAddress address = new EAddress();
                    EUser user = new EUser();
                    var references = new List<EReferences>();

                    mvuser.Active = Convert.ToBoolean(mvuserDataSet.Tables[0].Rows[count]["IsActive"]);
                    mvuser.MVUserID = Convert.ToInt32(mvuserDataSet.Tables[0].Rows[count]["MVUserID"]);
                    mvuser.Contract = Convert.ToString(mvuserDataSet.Tables[0].Rows[count]["Contract"]);
                    mvuser.Resume = Convert.ToString(mvuserDataSet.Tables[0].Rows[count]["Resume"]);
                    mvuser.DigitalSignature = Convert.ToString(mvuserDataSet.Tables[0].Rows[count]["DigitalSignature"]);
                    mvuserspecialization.MVUserSpecilaizationID = Convert.ToInt32(mvuserDataSet.Tables[0].Rows[count]["MVUserSpecializationID"]);
                    mvuserclassification.MVUserClassificationID = Convert.ToInt32(mvuserDataSet.Tables[0].Rows[count]["MVUserClassificationID"]);
                    address.AddressID = Convert.ToInt32(mvuserDataSet.Tables[0].Rows[count]["ContactAddressID"]);
                    user.UserID = Convert.ToInt32(mvuserDataSet.Tables[0].Rows[count]["ReferenceID"]);
                    references[0].ReferenceID = Convert.ToInt32(mvuserDataSet.Tables[0].Rows[count]["UserID"]);
                    mvuser.MVUserClassification = mvuserclassification;
                    mvuser.MVUserSpecialization = mvuserspecialization;
                    mvuser.Address = address;
                    mvuser.References = references;
                    mvuser.User = user;

                    returnMVUser.Add(mvuser);
                }
                catch
                {
                }
            }
            return returnMVUser;
        }


        /// <summary>
        /// This function will return the Doctors of a Medical vendor
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EMVUser> GetMedicalVendorUser(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendoruser", arParms);

            List<EMVUser> returnMVUser = new List<EMVUser>();
            returnMVUser = ParseMedicalVendorUserDataSet(tempdataset);
            return returnMVUser;
        }
        /// <summary>
        /// Parse the dataset and return the List of Doctors (MVUser)
        /// </summary>
        /// <param name="mvuserDataSet"></param>
        /// <returns></returns>
        private List<EMVUser> ParseMedicalVendorUserDataSet(DataSet mvuserDataSet)
        {
            List<EMVUser> returnMVUser = new List<EMVUser>();

            for (int count = 0; count < mvuserDataSet.Tables[0].Rows.Count; count++)
            {
                EMVUser mvuser = new EMVUser();
                mvuser.MVUserID = Convert.ToInt32(mvuserDataSet.Tables[0].Rows[count]["MVUserID"]);
                mvuser.User = new Entity.Other.EUser();
                mvuser.User.FirstName = Convert.ToString(mvuserDataSet.Tables[0].Rows[count]["FirstName"]);
                mvuser.User.MiddleName = Convert.ToString(mvuserDataSet.Tables[0].Rows[count]["MiddleName"]);
                mvuser.User.LastName = Convert.ToString(mvuserDataSet.Tables[0].Rows[count]["LastName"]);
                mvuser.MVUserSpecialization = new EMVUserSpecialization();
                mvuser.MVUserSpecialization.Name = Convert.ToString(mvuserDataSet.Tables[0].Rows[count]["Specialization"]);

                returnMVUser.Add(mvuser);

                // mvmvuser.MVUser.MVUserSpecialization.Name
            }
            return returnMVUser;
        }
        /// <summary>
        /// This function will return the Payment details of the Medical vendor
        /// </summary>
        /// <param name="strMedicalVendorID"></param>
        /// <param name="bolIsHistory"></param>
        /// <returns></returns>
        public List<EPaymentDetail> GetMedicalVendorPayment(String strMedicalVendorID, Boolean bolIsHistory)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = strMedicalVendorID;
            arParms[1] = new SqlParameter("@mode", SqlDbType.Bit);
            arParms[1].Value = bolIsHistory;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendorpayment", arParms);

            List<EPaymentDetail> returnPaymentDetail = new List<EPaymentDetail>();
            returnPaymentDetail = ParsePaymentDetailDataSet(tempdataset);
            return returnPaymentDetail;
        }
        /// <summary>
        /// Parse the Dataset into the PaymentDetail
        /// </summary>
        /// <param name="dtPaymentDetail"></param>
        /// <returns></returns>
        private List<EPaymentDetail> ParsePaymentDetailDataSet(DataSet dtPaymentDetail)
        {
            List<EPaymentDetail> returnPaymentDetail = new List<EPaymentDetail>();

            for (int count = 0; count < dtPaymentDetail.Tables[0].Rows.Count; count++)
            {
                EPaymentDetail paymentdetail = new EPaymentDetail();
                paymentdetail.Amount = Convert.ToSingle(dtPaymentDetail.Tables[0].Rows[count]["Amount"]);
                paymentdetail.FromDate = Convert.ToString(dtPaymentDetail.Tables[0].Rows[count]["FromDate"]);
                paymentdetail.ToDate = Convert.ToString(dtPaymentDetail.Tables[0].Rows[count]["ToDate"]);
                paymentdetail.PayDate = Convert.ToString(dtPaymentDetail.Tables[0].Rows[count]["PayDate"]);

                returnPaymentDetail.Add(paymentdetail);
            }
            return returnPaymentDetail;
        }

        #endregion

        # region "MedicalVendorMVUser"

        /// <summary>
        /// Fetches a customereventtestid from evaluation queue based on eventid and customerid provided
        /// </summary>
        /// <param name="eventid"></param>
        /// <param name="customerid"></param>
        /// <returns></returns>
        public int SearchCustomerinEvaluationQueue(long eventid, long customerid, long customereventtestid)
        {
            SqlParameter[] arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@customerEventTestId", SqlDbType.BigInt);

            arparams[0].Value = eventid;
            arparams[1].Value = customerid;
            arparams[2].Value = customereventtestid;

            int returnresults = -1;
            object objresults = SqlHelper.ExecuteScalar(connectionstring, CommandType.StoredProcedure, "usp_searchMVPendingqueue", arparams);

            if (objresults != null)
                returnresults = Convert.ToInt32(objresults);

            return returnresults;
        }

        public Int64 SaveMedicalVendorMVUser(String mvmvuserID, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@mvmvuserid", SqlDbType.VarChar, 3000);
            arParms[0].Value = mvmvuserID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removemedicalvendormvuser", arParms);
            return (Int64)arParms[5].Value;

        }
        public Int64 AddMedicalVendorMVUser(EMVMVUser medicalvendormedicalvendorUser, int mode, SqlTransaction transaction, out int userid)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[68];
            arParms[0] = new SqlParameter("@medicalvendormedicalvendoruserid", SqlDbType.BigInt);
            arParms[0].Value = medicalvendormedicalvendorUser.MedicalVendorMVUserID;
            arParms[1] = new SqlParameter("@businessname", SqlDbType.VarChar, 500);
            arParms[1].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessName;
            arParms[2] = new SqlParameter("@businessphone", SqlDbType.VarChar, 500);
            arParms[2].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessPhone;
            arParms[3] = new SqlParameter("@businessfax", SqlDbType.VarChar, 500);
            arParms[3].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessFax;
            arParms[4] = new SqlParameter("@medicalvendortypeid", SqlDbType.BigInt);
            arParms[4].Value = medicalvendormedicalvendorUser.MedicalVendor.MedicalVendorType.MedicalVendorTypeID;
            arParms[5] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
            arParms[5].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessAddress.Address1;
            arParms[6] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[6].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessAddress.Address2;
            arParms[7] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[7].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessAddress.CityID;
            arParms[8] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[8].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessAddress.StateID;
            arParms[9] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[9].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessAddress.CountryID;
            arParms[10] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[10].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessAddress.ZipID;
            arParms[11] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[11].Value = medicalvendormedicalvendorUser.MVUser.User.FirstName;
            arParms[12] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[12].Value = medicalvendormedicalvendorUser.MVUser.User.MiddleName;
            arParms[13] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[13].Value = medicalvendormedicalvendorUser.MVUser.User.LastName;
            arParms[14] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[14].Value = medicalvendormedicalvendorUser.MVUser.User.PhoneHome;
            arParms[15] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[15].Value = medicalvendormedicalvendorUser.MVUser.User.PhoneOffice;
            arParms[16] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[16].Value = medicalvendormedicalvendorUser.MVUser.User.PhoneCell;
            arParms[17] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[17].Value = medicalvendormedicalvendorUser.MVUser.User.EMail1;
            arParms[18] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[18].Value = medicalvendormedicalvendorUser.MVUser.User.EMail2;
            arParms[19] = new SqlParameter("@dob", SqlDbType.VarChar, 500);
            arParms[19].Value = medicalvendormedicalvendorUser.MVUser.User.DOB;
            arParms[20] = new SqlParameter("@ssn", SqlDbType.VarChar, 500);
            arParms[20].Value = medicalvendormedicalvendorUser.MVUser.User.SSN;
            arParms[21] = new SqlParameter("@caddress1", SqlDbType.VarChar, 500);
            arParms[21].Value = medicalvendormedicalvendorUser.MVUser.Address.Address1;
            arParms[22] = new SqlParameter("@caddress2", SqlDbType.VarChar, 500);
            arParms[22].Value = medicalvendormedicalvendorUser.MVUser.Address.Address2;
            arParms[23] = new SqlParameter("@ccityid", SqlDbType.BigInt);
            arParms[23].Value = medicalvendormedicalvendorUser.MVUser.Address.CityID;
            arParms[24] = new SqlParameter("@cstateid", SqlDbType.BigInt);
            arParms[24].Value = medicalvendormedicalvendorUser.MVUser.Address.StateID;
            arParms[25] = new SqlParameter("@ccountryid", SqlDbType.BigInt);
            arParms[25].Value = medicalvendormedicalvendorUser.MVUser.Address.CountryID;
            arParms[26] = new SqlParameter("@czipid", SqlDbType.BigInt);
            arParms[26].Value = medicalvendormedicalvendorUser.MVUser.Address.ZipID;
            arParms[27] = new SqlParameter("@refname1", SqlDbType.VarChar, 500);
            arParms[27].Value = medicalvendormedicalvendorUser.MVUser.References[0].Name;
            arParms[28] = new SqlParameter("@refemail1", SqlDbType.VarChar, 500);
            arParms[28].Value = medicalvendormedicalvendorUser.MVUser.References[0].EMail;
            arParms[29] = new SqlParameter("@refname2", SqlDbType.VarChar, 500);
            arParms[29].Value = medicalvendormedicalvendorUser.MVUser.References[1].Name;
            arParms[30] = new SqlParameter("@refemail2", SqlDbType.VarChar, 500);
            arParms[30].Value = medicalvendormedicalvendorUser.MVUser.References[1].EMail;
            arParms[31] = new SqlParameter("@refname3", SqlDbType.VarChar, 500);
            arParms[31].Value = medicalvendormedicalvendorUser.MVUser.References[2].Name;
            arParms[32] = new SqlParameter("@refemail3", SqlDbType.VarChar, 500);
            arParms[32].Value = medicalvendormedicalvendorUser.MVUser.References[2].EMail;
            arParms[33] = new SqlParameter("@specilizationid", SqlDbType.BigInt);
            if (medicalvendormedicalvendorUser.MVUser.MVUserSpecialization.MVUserSpecilaizationID.ToString() == "0")
                arParms[33].Value = DBNull.Value;
            else
                arParms[33].Value = medicalvendormedicalvendorUser.MVUser.MVUserSpecialization.MVUserSpecilaizationID;
            arParms[34] = new SqlParameter("@medicalvendorwiringid", SqlDbType.BigInt);
            arParms[34].Value = medicalvendormedicalvendorUser.MedicalVendor.MedicalVendorWiringID;
            arParms[35] = new SqlParameter("@contractid", SqlDbType.BigInt);
            arParms[35].Value = medicalvendormedicalvendorUser.MedicalVendor.Contract.ContractID;
            arParms[36] = new SqlParameter("@teampicture", SqlDbType.VarChar, 500);
            arParms[36].Value = medicalvendormedicalvendorUser.MedicalVendor.TeamPicture;
            arParms[37] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[37].Value = mode;
            arParms[38] = new SqlParameter("@note", SqlDbType.VarChar, 500);
            arParms[38].Value = medicalvendormedicalvendorUser.MedicalVendor.Note;
            arParms[39] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[39].Direction = ParameterDirection.Output;
            arParms[40] = new SqlParameter("@applicationid", SqlDbType.BigInt);
            arParms[40].IsNullable = true;
            arParms[40].Value = medicalvendormedicalvendorUser.MedicalVendorApplication.MedicalVendorApplicationID;
            arParms[41] = new SqlParameter("@userid1", SqlDbType.BigInt);
            arParms[41].Value = medicalvendormedicalvendorUser.MVUser.User.UserID;
            arParms[42] = new SqlParameter("@medicalvendorid1", SqlDbType.BigInt);
            arParms[42].Value = medicalvendormedicalvendorUser.MedicalVendor.MedicalVendorID;
            arParms[43] = new SqlParameter("@cmvuserid", SqlDbType.BigInt);
            arParms[43].Value = medicalvendormedicalvendorUser.MVUser.MVUserID;
            arParms[44] = new SqlParameter("@chomeaddressid", SqlDbType.BigInt);
            arParms[44].Value = medicalvendormedicalvendorUser.MVUser.User.HomeAddress.AddressID;
            arParms[45] = new SqlParameter("@cbusinessaddressid", SqlDbType.BigInt);
            arParms[45].Value = medicalvendormedicalvendorUser.MedicalVendor.BusinessAddress.AddressID;
            arParms[46] = new SqlParameter("@biaddress1", SqlDbType.VarChar, 500);
            arParms[46].Value = medicalvendormedicalvendorUser.MedicalVendor.BillingAddress.Address1;
            arParms[47] = new SqlParameter("@biaddress2", SqlDbType.VarChar, 500);
            arParms[47].Value = medicalvendormedicalvendorUser.MedicalVendor.BillingAddress.Address2;
            arParms[48] = new SqlParameter("@bicityid", SqlDbType.BigInt);
            arParms[48].Value = medicalvendormedicalvendorUser.MedicalVendor.BillingAddress.CityID;
            arParms[49] = new SqlParameter("@bistateid", SqlDbType.BigInt);
            arParms[49].Value = medicalvendormedicalvendorUser.MedicalVendor.BillingAddress.StateID;
            arParms[50] = new SqlParameter("@bicountryid", SqlDbType.BigInt);
            arParms[50].Value = medicalvendormedicalvendorUser.MedicalVendor.BillingAddress.CountryID;
            arParms[51] = new SqlParameter("@bizipid", SqlDbType.BigInt);
            arParms[51].Value = medicalvendormedicalvendorUser.MedicalVendor.BillingAddress.ZipID;
            arParms[52] = new SqlParameter("@cbillingaddressid", SqlDbType.BigInt);
            arParms[52].Value = medicalvendormedicalvendorUser.MedicalVendor.BillingAddress.AddressID;
            arParms[53] = new SqlParameter("@bankname", SqlDbType.VarChar, 50);
            arParms[53].Value = medicalvendormedicalvendorUser.MedicalVendor.BankName;
            arParms[54] = new SqlParameter("@paymentmode", SqlDbType.Int);
            arParms[54].Value = medicalvendormedicalvendorUser.MedicalVendor.PaymentMode;
            arParms[55] = new SqlParameter("@accountholdername", SqlDbType.VarChar, 50);
            arParms[55].Value = medicalvendormedicalvendorUser.MedicalVendor.AccountHolder;
            arParms[56] = new SqlParameter("@accounttype", SqlDbType.VarChar, 50);
            arParms[56].Value = medicalvendormedicalvendorUser.MedicalVendor.AccountType;
            arParms[57] = new SqlParameter("@routingNumber", SqlDbType.VarChar, 500);
            arParms[57].Value = medicalvendormedicalvendorUser.MedicalVendor.RountingNumber;
            arParms[58] = new SqlParameter("@accountnumber", SqlDbType.VarChar, 50);
            arParms[58].Value = medicalvendormedicalvendorUser.MedicalVendor.AccountNumber;
            arParms[59] = new SqlParameter("@memo", SqlDbType.VarChar, 500);
            arParms[59].Value = medicalvendormedicalvendorUser.MedicalVendor.Memo;
            arParms[60] = new SqlParameter("@specialinstructions", SqlDbType.VarChar, 500);
            arParms[60].Value = medicalvendormedicalvendorUser.MedicalVendor.SpecialInstruction;
            arParms[61] = new SqlParameter("@interval", SqlDbType.Int);
            arParms[61].Value = medicalvendormedicalvendorUser.MedicalVendor.Interval;
            arParms[62] = new SqlParameter("@frequency", SqlDbType.VarChar, 50);
            arParms[62].Value = medicalvendormedicalvendorUser.MedicalVendor.Frequency;
            arParms[63] = new SqlParameter("@emode", SqlDbType.VarChar, 500);
            if (medicalvendormedicalvendorUser.MedicalVendor.EvaluationMode.Length > 0 || medicalvendormedicalvendorUser.MedicalVendor.EvaluationMode != null)
                arParms[63].Value = medicalvendormedicalvendorUser.MedicalVendor.EvaluationMode;
            else
                arParms[63].Value = DBNull.Value;
            arParms[64] = new SqlParameter("@cpaymentfrequencyid", SqlDbType.BigInt);
            arParms[64].Value = medicalvendormedicalvendorUser.MedicalVendor.FrequencyID;
            arParms[65] = new SqlParameter("@mvmvuseridvalue", SqlDbType.BigInt);
            arParms[65].Direction = ParameterDirection.Output;
            arParms[66] = new SqlParameter("@returnuserid", SqlDbType.BigInt);
            arParms[66].Direction = ParameterDirection.Output;
            arParms[67] = new SqlParameter("@IsHospitalPartner", SqlDbType.Bit);
            arParms[67].Value = medicalvendormedicalvendorUser.MedicalVendor.IsHospitalPartner;

            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemedicalvendormedicalvendoruser", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemedicalvendormedicalvendoruser", arParms);
            }
            returnvalue = (Int64)arParms[39].Value;
            if (arParms[66].Value != null)
                userid = Convert.ToInt32(arParms[66].Value);
            else
                userid = 0;
            if (medicalvendormedicalvendorUser.MedicalVendor.MVPermittedTest != null && medicalvendormedicalvendorUser.MedicalVendor.MVPermittedTest.Count > 0 && (returnvalue >= 0 && returnvalue != 999998))
            {
                if (mode == 0)
                    SaveMVPermittedTest(medicalvendormedicalvendorUser.MedicalVendor.MVPermittedTest, Convert.ToInt32(arParms[65].Value), medicalvendormedicalvendorUser.MedicalVendor.MedicalVendorType.MedicalVendorTypeID, transaction);
                else
                {
                    if ((returnvalue != 547) && (mode == 1))
                        SaveMVPermittedTest(medicalvendormedicalvendorUser.MedicalVendor.MVPermittedTest, medicalvendormedicalvendorUser.MedicalVendorMVUserID, medicalvendormedicalvendorUser.MedicalVendor.MedicalVendorType.MedicalVendorTypeID, transaction);
                }
            }


            return returnvalue;
        }

        public Int64 SaveMVPermittedTest(List<Entity.MedicalVendor.EMVPermittedTest> test, Int32 MedicalVendorMVUserID, int typeid, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();
            for (int icount = 0; icount < test.Count; icount++)
            {
                SqlParameter[] arParms = new SqlParameter[5];
                arParms[0] = new SqlParameter("@medicalvendormvuserid", SqlDbType.BigInt);
                arParms[0].Value = MedicalVendorMVUserID;
                arParms[1] = new SqlParameter("@testid", SqlDbType.BigInt);
                arParms[1].Value = test[icount].Test.TestID;
                arParms[2] = new SqlParameter("@typeid", SqlDbType.BigInt);
                arParms[2].Value = typeid;
                arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[3].Value = icount;
                arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[4].Direction = ParameterDirection.Output;
                if (transaction == null)
                {
                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvpermittedtest", arParms);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemvpermittedtest", arParms);
                }
                returnvalue = (Int64)arParms[4].Value;
            }

            return returnvalue;
        }

        public Int64 SaveMVTest(List<EMVTest> test, int mode, Int32 MedicalVendorID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();
            for (int icount = 0; icount < test.Count; icount++)
            {
                SqlParameter[] arParms = new SqlParameter[5];
                arParms[0] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
                arParms[0].Value = MedicalVendorID;
                arParms[1] = new SqlParameter("@offerrate", SqlDbType.Decimal, 18);
                arParms[1].Precision = 18;
                arParms[1].Scale = 2;
                arParms[1].Value = test[icount].OfferRate;
                arParms[2] = new SqlParameter("@testid", SqlDbType.BigInt);
                arParms[2].Value = test[icount].Test.TestID;
                arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[3].Value = icount;
                arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[4].Direction = ParameterDirection.Output;
                if (transaction == null)
                {
                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvtest", arParms);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemvtest", arParms);
                }
                returnvalue = (Int64)arParms[4].Value;
            }

            return returnvalue;
        }

        public Int64 SaveMVPackage(List<EMVPackage> package, int mode, Int32 MedicalVendorID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();
            for (int icount = 0; icount < package.Count; icount++)
            {
                SqlParameter[] arParms = new SqlParameter[5];
                arParms[0] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
                arParms[0].Value = MedicalVendorID;
                arParms[1] = new SqlParameter("@offerrate", SqlDbType.Decimal, 18);
                arParms[1].Precision = 18;
                arParms[1].Scale = 2;
                arParms[1].Value = package[icount].OfferRate;
                arParms[2] = new SqlParameter("@packageid", SqlDbType.BigInt);
                arParms[2].Value = package[icount].Package.PackageID;
                arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[3].Value = icount;
                arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[4].Direction = ParameterDirection.Output;
                if (transaction == null)
                {
                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvpackage", arParms);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemvpackage", arParms);
                }
                returnvalue = (Int64)arParms[4].Value;
            }

            return returnvalue;
        }

        public Int64 SaveMVCustomer(EMVCustomerPayRate customer, int mode, Int32 MedicalVendorID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();

            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
            arParms[0].Value = MedicalVendorID;
            arParms[1] = new SqlParameter("@offerrate", SqlDbType.Decimal, 18);
            arParms[1].Precision = 18;
            arParms[1].Scale = 2;
            arParms[1].Value = customer.OfferRate;
            arParms[2] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[2].Value = 0;
            arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;
            //SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvcustomer", arParms);
            //returnvalue = (Int64)arParms[3].Value;
            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvcustomer", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemvcustomer", arParms);
            }
            returnvalue = (Int64)arParms[3].Value;
            return returnvalue;
        }

        public List<EMVMVUser> GetMedicalVendorMVUser(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendormvuser", arParms);

            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();
            returnMVMVUser = ParseMedicalVendorMVUserDataSet(tempdataset);
            return returnMVMVUser;
        }

        public List<EMVMVUser> GetMedicalVendorMedicalVendorUserProfile(string filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendormedicalvendoruser", arParms);

            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();
            returnMVMVUser = ParseMedicalVendorMedicalVendorUserDataSet(tempdataset);
            return returnMVMVUser;
        }

        public List<EMVMVUser> GetMedicalVendorMedicalVendorUser(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendormedicalvendoruser", arParms);

            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();
            returnMVMVUser = ParseMedicalVendorMedicalVendorUserDataSet(tempdataset);
            return returnMVMVUser;
        }

        private List<EMVMVUser> ParseMedicalVendorMedicalVendorUserDataSet(DataSet mvmvuserDataSet)
        {
            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();

            int intMaxPicCount = IoC.Resolve<ISettings>().MaximumPictureCount;

            DataTable dtMVMVPod = mvmvuserDataSet.Tables[mvmvuserDataSet.Tables.Count - 1];

            foreach (DataRow dr in mvmvuserDataSet.Tables[0].Rows)
            {
                EMVMVUser mvmvuser = new EMVMVUser();
                EMVUser mvuser = new EMVUser();
                Entity.Other.EUser user = new Entity.Other.EUser();
                EMVUserSpecialization mvuserspecialization = new EMVUserSpecialization();
                EMVUserClassification mvuserclassification = new EMVUserClassification();
                List<EReferences> reference = new List<EReferences>();
                EMedicalVendor medicalvendor = new EMedicalVendor();
                EAddress caddress = new EAddress();

                mvmvuser.MedicalVendorMVUserID = Convert.ToInt32(dr["MedicalVendorMVUserID"]);
                if (dr["Notes"] != DBNull.Value)
                {
                    mvmvuser.Notes = dr["Notes"].ToString();
                }
                else
                {
                    mvmvuser.Notes = "";
                }
                mvuser.MVUserID = Convert.ToInt32(dr["MVUserID"]);
                mvmvuser.CutOffDate = Convert.ToString(dr["CutOffDate"]);
                mvmvuser.ShowEarningAmount = Convert.ToBoolean(dr["ShowEarningAmount"]);
                mvmvuser.IsAuthorizationsAllowed = Convert.ToBoolean(dr["IsAuthorizationAllowed"]);
                mvmvuser.AuditRequired = Convert.ToBoolean(dr["IsAuditRequired"]);

                medicalvendor.MedicalVendorID = Convert.ToInt32(dr["MedicalVendorID"]);
                medicalvendor.EvaluationMode = dr["MEDICALVENDOREVALUATIONMODEID"].ToString();
                user.UserID = Convert.ToInt32(dr["UserID"]);
                user.FirstName = dr["FirstName"].ToString();
                user.MiddleName = dr["MiddleName"].ToString();
                user.LastName = dr["LastName"].ToString();
                user.PhoneCell = dr["PhoneCell"].ToString();
                user.PhoneHome = dr["PhoneHome"].ToString();
                user.PhoneOffice = dr["PhoneOffice"].ToString();
                user.DOB = dr["DOB"].ToString();
                user.DateApplied = Convert.ToDateTime(dr["DateCreated"]);
                user.SSN = dr["SSN"].ToString();
                user.EMail1 = dr["EMail1"].ToString();
                user.EMail2 = dr["EMail2"].ToString();

                caddress.AddressID = Convert.ToInt32(dr["HomeAddressID"]);
                caddress.Address1 = dr["Address1"].ToString();
                caddress.Address2 = dr["Address2"].ToString();
                caddress.ZipID = Convert.ToInt32(dr["ZipCode"]);
                caddress.City = dr["City"].ToString();
                caddress.CityID = Convert.ToInt32(dr["CityID"]);
                caddress.State = dr["State"].ToString();
                caddress.StateID = Convert.ToInt32(dr["StateID"]);
                caddress.Country = dr["Country"].ToString();
                caddress.CountryID = Convert.ToInt32(dr["CountryID"]);
                caddress.Zip = dr["ZipCode"].ToString();

                if (dr["MyPicture"] != DBNull.Value)
                    mvuser.MyPicture = dr["MyPicture"].ToString();

                List<string> otherpicture = new List<string>();
                for (int intcount = 1; intcount < 13; intcount++)
                {
                    if (intcount <= intMaxPicCount)
                    {
                        if (dr["Picture" + intcount] != DBNull.Value)
                            otherpicture.Add(dr["Picture" + intcount].ToString());
                        else
                            otherpicture.Add(string.Empty);
                    }
                    else
                    { otherpicture.Add(string.Empty); }
                }
                mvuser.OtherPictures = otherpicture;

                mvuser.Resume = dr["resume"].ToString();
                mvuser.DigitalSignature = dr["DigitalSignature"].ToString();

                user.HomeAddress = caddress;

                int i = 1;
                for (int icount = 0; mvmvuserDataSet.Tables[i].Rows.Count > 0 && icount < 3; icount++)
                {
                    DataRow drref = mvmvuserDataSet.Tables[i].Rows[0];
                    EReferences[] refer = new EReferences[3];
                    refer[icount] = new EReferences();
                    refer[icount].Name = drref["Ref" + i + "Name"].ToString();
                    refer[icount].EMail = drref["Ref" + i + "Email"].ToString();

                    reference.Add(refer[icount]);
                    i = i + 1;
                }
                if (dr["SpecializationID"] != DBNull.Value)
                {
                    mvuserspecialization.MVUserSpecilaizationID = Convert.ToInt32(dr["SpecializationID"]);
                    mvuserspecialization.Name = dr["Specialization"].ToString();
                }

                if (dr["MVUserClassificationID"] != DBNull.Value)
                {
                    mvuserclassification.MVUserClassificationID = Convert.ToInt32(dr["MVUserClassificationID"]);
                    mvuserclassification.Name = dr["Classification"].ToString();
                }

                medicalvendor.BusinessName = dr["BusinessName"].ToString();

                List<EMVTestPayRate> test = new List<EMVTestPayRate>();
                DataTable tblmvtest = mvmvuserDataSet.Tables[4];
                tblmvtest.DefaultView.RowFilter = "MVMVUserID = " + mvmvuser.MedicalVendorMVUserID;
                int fcount = 0;
                while (fcount < tblmvtest.DefaultView.Count)
                {
                    EMVTestPayRate mvtestpayrate = new EMVTestPayRate();
                    ETest objtest = new ETest();
                    objtest.TestID = Convert.ToInt32(tblmvtest.DefaultView[fcount]["TestID"]);
                    objtest.Name = tblmvtest.DefaultView[fcount]["TestName"].ToString();
                    mvtestpayrate.Test = objtest;
                    test.Add(mvtestpayrate);
                    fcount++;
                }

                if (dr["MEDICALVENDOREVALUATIONMODEID"] != DBNull.Value)
                {
                    // TODO: To remove the hardcoding for the evaluation mode
                    if (dr["MEDICALVENDOREVALUATIONMODEID"].ToString().Equals("1"))
                    {
                        if (mvmvuserDataSet.Tables[7].Rows.Count > 0)
                        {
                            if (mvmvuserDataSet.Tables[7].Select("MedicalVendorMVUserID = '" + dr["MedicalVendorMVUserID"].ToString() + "'").Length > 0)
                            {
                                DataRow drCust = mvmvuserDataSet.Tables[7].Select("MedicalVendorMVUserID = '" + dr["MedicalVendorMVUserID"].ToString() + "'")[0];

                                EMVCustomerPayRate customer = new EMVCustomerPayRate();
                                EMVMVUserCustomerPayRate mvusercustomer = new EMVMVUserCustomerPayRate();
                                mvusercustomer.MVMVUserCustomerPayRateID = Convert.ToInt32(drCust["MedicalVendorMVUserCustomerPayRatesID"]);
                                mvusercustomer.OfferRate = Convert.ToDecimal(drCust["PayRate"]);
                                customer.MVCustomerPayRateID = Convert.ToInt32(drCust["MedicalVendorCustomerPayRateID"]);
                                mvusercustomer.MVCustomerPayRate = customer;

                                mvmvuser.MVCustomerPayRate = mvusercustomer;
                            }

                        }
                    }
                    else if (dr["MEDICALVENDOREVALUATIONMODEID"].ToString().Equals("3"))
                    {
                        // DataRow drPackage = mvmvuserDataSet.Tables[5].Select("MedicalVendorID = '" + dr["MedicalVendorID"].ToString() + "'")[0];
                        List<EMVMVUserPackage> package = new List<EMVMVUserPackage>();
                        DataTable drPackage = mvmvuserDataSet.Tables[6];
                        drPackage.DefaultView.RowFilter = "MedicalVendorMVUserID = " + mvmvuser.MedicalVendorMVUserID;
                        int icount = 0;
                        while (icount < drPackage.DefaultView.Count)
                        {
                            EMVMVUserPackage mvuserpackage = new EMVMVUserPackage();
                            EMVPackage mvpackage = new EMVPackage();
                            EPackage userpackage = new EPackage();
                            userpackage.PackageID = Convert.ToInt32(drPackage.DefaultView[icount]["PackageID"]);
                            userpackage.PackageName = drPackage.DefaultView[icount]["PackageName"].ToString();
                            mvpackage.MVPackageID = Convert.ToInt32(drPackage.DefaultView[icount]["MedicalVendorPackageID"]);
                            mvpackage.Package = userpackage;
                            mvuserpackage.OfferRate = Convert.ToDecimal(drPackage.DefaultView[icount]["OfferRate"]);
                            mvuserpackage.MVMVUserPackageID = Convert.ToInt32(drPackage.DefaultView[icount]["MedicalVendorMVUserPackageID"]);
                            mvuserpackage.MVPackage = mvpackage;
                            package.Add(mvuserpackage);
                            icount++;
                        }
                        mvmvuser.MVPackage = package;
                    }
                    else if (dr["MEDICALVENDOREVALUATIONMODEID"].ToString().Equals("4"))
                    {
                        // DataRow drPackage = mvmvuserDataSet.Tables[5].Select("MedicalVendorID = '" + dr["MedicalVendorID"].ToString() + "'")[0];
                        List<EMVMVUserTest> mvmvtest = new List<EMVMVUserTest>();
                        DataTable drTest = mvmvuserDataSet.Tables[5];
                        drTest.DefaultView.RowFilter = "MedicalVendorMVUserID = " + mvmvuser.MedicalVendorMVUserID;
                        int jcount = 0;
                        while (jcount < drTest.DefaultView.Count)
                        {
                            EMVMVUserTest mvusertest = new EMVMVUserTest();
                            EMVTest mvtest = new EMVTest();
                            ETest usertest = new ETest();

                            usertest.Name = drTest.DefaultView[jcount]["TestName"].ToString();
                            usertest.TestID = Convert.ToInt32(drTest.DefaultView[jcount]["TestID"]);
                            mvtest.Test = usertest;
                            mvtest.MVTestID = Convert.ToInt32(drTest.DefaultView[jcount]["MedicalVendorTestID"]);
                            mvusertest.MVTest = mvtest;
                            mvusertest.OfferRate = Convert.ToDecimal(drTest.DefaultView[jcount]["OfferRate"]);
                            mvusertest.MVMVUserTestID = Convert.ToInt32(drTest.DefaultView[jcount]["MedicalVendorMVUserTestID"]);
                            mvmvtest.Add(mvusertest);
                            jcount++;
                        }
                        mvmvuser.MVTest = mvmvtest;
                    }
                }

                dtMVMVPod.DefaultView.RowFilter = "MedicalVendorMVUserID = " + mvmvuser.MedicalVendorMVUserID;

                foreach (DataRowView drv in dtMVMVPod.DefaultView)
                {
                    if (mvmvuser.ListPods == null)
                        mvmvuser.ListPods = new List<int>();

                    mvmvuser.ListPods.Add(Convert.ToInt32(drv["PodID"]));

                }

                mvuser.MVTestPayRate = test;
                mvuser.User = user;
                mvuser.References = reference;
                mvuser.MVUserClassification = mvuserclassification;
                mvuser.MVUserSpecialization = mvuserspecialization;
                mvmvuser.MedicalVendor = medicalvendor;
                mvuser.Address = caddress;
                mvmvuser.MVUser = mvuser;
                returnMVMVUser.Add(mvmvuser);
            }
            return returnMVMVUser;
        }

        private List<EMVMVUser> ParseMedicalVendorMVUserDataSet(DataSet mvmvuserDataSet)
        {
            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();

            for (int count = 0; count < mvmvuserDataSet.Tables[0].Rows.Count; count++)
            {
                EMVMVUser mvmvuser = new EMVMVUser();
                EMedicalVendor mv = new EMedicalVendor();
                Entity.Other.EUser user = new Entity.Other.EUser();

                mvmvuser.MedicalVendorMVUserID = Convert.ToInt32(mvmvuserDataSet.Tables[0].Rows[count]["MedicalVendorMVUserID"]);
                mv.BusinessName = Convert.ToString(mvmvuserDataSet.Tables[0].Rows[count]["BusinessName"]);
                user.FirstName = Convert.ToString(mvmvuserDataSet.Tables[0].Rows[count]["FirstName"]);
                user.MiddleName = Convert.ToString(mvmvuserDataSet.Tables[0].Rows[count]["MiddleName"]);
                user.LastName = Convert.ToString(mvmvuserDataSet.Tables[0].Rows[count]["LastName"]);

                mvmvuser.MedicalVendor = mv;
                mvmvuser.MVUser = new EMVUser();
                mvmvuser.MVUser.User = user;

                returnMVMVUser.Add(mvmvuser);
            }
            return returnMVMVUser;
        }
        public List<EMVMVUser> GetMVMVUser(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmvmvuser", arParms);

            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();
            returnMVMVUser = ParseMVMVUserDataSet(tempdataset);
            return returnMVMVUser;
        }
        private List<EMVMVUser> ParseMVMVUserDataSet(DataSet mvmvuserDataSet)
        {
            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();

            foreach (DataRow dr in mvmvuserDataSet.Tables[0].Rows)
            {
                EMVMVUser mvmvuser = new EMVMVUser();
                EMVUser mvuser = new EMVUser();
                Entity.Other.EUser user = new Entity.Other.EUser();
                EMVUserSpecialization mvuserspecialization = new EMVUserSpecialization();
                EMedicalVendorType mvtype = new EMedicalVendorType();
                List<EReferences> reference = new List<EReferences>();
                EMedicalVendor medicalvendor = new EMedicalVendor();
                EContract contract = new EContract();

                user.UserID = Convert.ToInt32(dr["UserID"]);
                user.FirstName = dr["FirstName"].ToString();
                user.MiddleName = dr["MiddleName"].ToString();
                user.LastName = dr["LastName"].ToString();
                user.PhoneCell = dr["PhoneCell"].ToString();
                user.PhoneHome = dr["PhoneHome"].ToString();
                user.PhoneOffice = dr["PhoneOffice"].ToString();
                user.DOB = dr["DOB"].ToString();
                user.SSN = dr["SSN"].ToString();
                user.EMail1 = dr["EMail1"].ToString();
                user.EMail2 = dr["EMail2"].ToString();


                DataRow drAdd = mvmvuserDataSet.Tables[2].Select("AddressID = '" + dr["CorrespondenceAddressID"].ToString() + "'")[0];

                EAddress caddress = new EAddress();
                caddress.AddressID = Convert.ToInt32(drAdd["AddressID"]);
                caddress.Address1 = drAdd["Address1"].ToString();
                caddress.Address2 = drAdd["Address2"].ToString();
                caddress.ZipID = Convert.ToInt32(drAdd["ZIPID"]);
                caddress.City = drAdd["CityName"].ToString();
                caddress.CityID = Convert.ToInt32(drAdd["CityID"]);
                caddress.State = drAdd["StateName"].ToString();
                caddress.StateID = Convert.ToInt32(drAdd["StateID"]);
                caddress.Country = drAdd["CountryName"].ToString();
                caddress.CountryID = Convert.ToInt32(drAdd["CountryID"]);

                user.HomeAddress = caddress;

                int i = 1;
                for (int icount = 0; icount < 3; icount++)
                {
                    EReferences[] refer = new EReferences[3];
                    refer[icount] = new EReferences();
                    refer[icount].Name = dr["Reference" + i + "Name"].ToString();
                    refer[icount].EMail = dr["Reference" + i + "Email"].ToString();
                    reference.Add(refer[icount]);
                    i = i + 1;
                }

                mvuserspecialization.MVUserSpecilaizationID = Convert.ToInt32(dr["MVUserSpecializationID"]);
                mvuserspecialization.Name = dr["Specialization"].ToString();

                mvtype.MedicalVendorTypeID = Convert.ToInt32(dr["MedicalVendorTypeID"]);
                mvtype.Name = dr["Typename"].ToString();

                medicalvendor.BusinessName = dr["BusinessName"].ToString();
                medicalvendor.BusinessPhone = dr["BusinessPhone"].ToString();
                medicalvendor.BusinessFax = dr["BusinessFax"].ToString();
                medicalvendor.TeamPicture = dr["TeamPicture"].ToString();

                DataRow drAddB = mvmvuserDataSet.Tables[1].Select("AddressID = '" + dr["BusinessAddressID"].ToString() + "'")[0];

                EAddress baddress = new EAddress();
                baddress.AddressID = Convert.ToInt32(drAddB["AddressID"]);
                baddress.Address1 = drAddB["Address1"].ToString();
                baddress.Address2 = drAddB["Address2"].ToString();
                baddress.ZipID = Convert.ToInt32(drAddB["ZIPID"]);
                baddress.City = drAddB["CityName"].ToString();
                baddress.CityID = Convert.ToInt32(drAddB["CityID"]);
                baddress.State = drAddB["StateName"].ToString();
                baddress.StateID = Convert.ToInt32(drAddB["StateID"]);
                baddress.Country = drAddB["CountryName"].ToString();
                baddress.CountryID = Convert.ToInt32(drAddB["CountryID"]);

                medicalvendor.MedicalVendorID = Convert.ToInt32(dr["MedicalVendorID"]);
                medicalvendor.BusinessAddress = baddress;
                medicalvendor.Note = dr["Notes"].ToString();
                medicalvendor.MedicalVendorWiringID = Convert.ToInt32(dr["MedicalVendorWiringID"]);

                contract.ContractID = Convert.ToInt32(dr["ContractID"]);
                contract.Name = dr["ContractName"].ToString();



                mvuser.User = user;
                mvuser.References = reference;
                medicalvendor.Contract = contract;
                mvuser.MVUserSpecialization = mvuserspecialization;
                mvmvuser.MedicalVendor = medicalvendor;
                mvuser.Address = caddress;
                medicalvendor.MedicalVendorType = mvtype;
                mvmvuser.MVUser = mvuser;




                returnMVMVUser.Add(mvmvuser);
            }
            return returnMVMVUser;
        }
        public List<EMVMVUser> GetMedicalVendorAdmin(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getmedicalvendoradmin", arParms);

            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();
            returnMVMVUser = ParseMVAdminDataSet(tempdataset);
            return returnMVMVUser;
        }
        private List<EMVMVUser> ParseMVAdminDataSet(DataSet mvmvuserDataSet)
        {
            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();

            foreach (DataRow dr in mvmvuserDataSet.Tables[0].Rows)
            {
                EMVMVUser mvmvuser = new EMVMVUser();
                EMVUser mvuser = new EMVUser();
                Entity.Other.EUser user = new Entity.Other.EUser();
                EMedicalVendor medicalvendor = new EMedicalVendor();

                mvmvuser.MedicalVendorMVUserID = Convert.ToInt32(dr["MedicalVendorMVUserID"]);
                user.FirstName = dr["FirstName"].ToString();
                user.MiddleName = dr["MiddleName"].ToString();
                user.LastName = dr["LastName"].ToString();
                user.EMail1 = dr["EMail1"].ToString();

                medicalvendor.BusinessName = dr["BusinessName"].ToString();
                medicalvendor.BusinessPhone = dr["BusinessPhone"].ToString();

                DataRow drAddB = mvmvuserDataSet.Tables[1].Select("AddressID = '" + dr["BusinessAddressID"].ToString() + "'")[0];

                EAddress baddress = new EAddress();
                baddress.AddressID = Convert.ToInt32(drAddB["AddressID"]);
                baddress.Address1 = drAddB["Address1"].ToString();
                baddress.Address2 = drAddB["Address2"].ToString();
                baddress.ZipID = Convert.ToInt32(drAddB["ZIPID"]);
                baddress.Zip = Convert.ToString(drAddB["ZipCode"]);
                baddress.City = drAddB["CityName"].ToString();
                baddress.CityID = Convert.ToInt32(drAddB["CityID"]);
                baddress.State = drAddB["StateName"].ToString();
                baddress.StateID = Convert.ToInt32(drAddB["StateID"]);
                baddress.Country = drAddB["CountryName"].ToString();
                baddress.CountryID = Convert.ToInt32(drAddB["CountryID"]);

                medicalvendor.MedicalVendorID = Convert.ToInt32(dr["MedicalVendorID"]);
                medicalvendor.BusinessAddress = baddress;



                mvuser.User = user;
                mvmvuser.MedicalVendor = medicalvendor;
                mvmvuser.MVUser = mvuser;
                returnMVMVUser.Add(mvmvuser);
            }
            return returnMVMVUser;
        }
        public List<EMVMVUser> GetMedicalVendorDetailByID(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = 0;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getmedicalvendordetail", arParms);

            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();
            returnMVMVUser = ParseMVAdminDetailDataSet(tempdataset);
            return returnMVMVUser;
        }
        private List<EMVMVUser> ParseMVAdminDetailDataSet(DataSet mvmvuserDataSet)
        {
            List<EMVMVUser> returnMVMVUser = new List<EMVMVUser>();

            foreach (DataRow dr in mvmvuserDataSet.Tables[0].Rows)
            {
                EMVMVUser mvmvuser = new EMVMVUser();
                EMVUser mvuser = new EMVUser();
                Entity.Other.EUser user = new Entity.Other.EUser();
                EMVUserSpecialization mvuserspecialization = new EMVUserSpecialization();
                EMedicalVendorType mvtype = new EMedicalVendorType();
                List<EReferences> reference = new List<EReferences>();
                List<EMVPermittedTest> lstPermittedTest = new List<EMVPermittedTest>();
                EMedicalVendor medicalvendor = new EMedicalVendor();
                EContract contract = new EContract();
                EAddress homeaddress = new EAddress();
                EAddress caddress = new EAddress();

                mvuser.MVUserID = Convert.ToInt32(dr["MVUserID"]);

                user.UserID = Convert.ToInt32(dr["UserID"]);
                user.FirstName = dr["FirstName"].ToString();
                user.MiddleName = dr["MiddleName"].ToString();
                user.LastName = dr["LastName"].ToString();
                user.PhoneCell = dr["PhoneCell"].ToString();
                user.PhoneHome = dr["PhoneHome"].ToString();
                user.PhoneOffice = dr["PhoneOffice"].ToString();

                user.DOB = dr["DOB"].ToString();
                user.DateApplied = Convert.ToDateTime(dr["DateCreated"]);
                user.SSN = dr["SSN"].ToString();
                user.EMail1 = dr["EMail1"].ToString();
                user.EMail2 = dr["EMail2"].ToString();

                homeaddress.AddressID = Convert.ToInt32(dr["HomeAddressID"]);
                homeaddress.Address1 = dr["Address1"].ToString();
                homeaddress.Address2 = dr["Address2"].ToString();
                homeaddress.ZipID = Convert.ToInt32(dr["ZipCode"]);
                homeaddress.City = dr["City"].ToString();
                homeaddress.CityID = Convert.ToInt32(dr["CityID"]);
                homeaddress.State = dr["State"].ToString();
                homeaddress.StateID = Convert.ToInt32(dr["StateID"]);
                homeaddress.Country = dr["Country"].ToString();
                homeaddress.CountryID = Convert.ToInt32(dr["CountryID"]);
                homeaddress.Zip = dr["ZipCode"].ToString();
                user.HomeAddress = homeaddress;
                if (dr["ContractID"] != DBNull.Value)
                {
                    contract.ContractID = Convert.ToInt32(dr["ContractID"]);
                    contract.Name = dr["ContractName"].ToString();
                }
                if (dr["MVUserSpecializationID"] != DBNull.Value)
                {
                    mvuserspecialization.MVUserSpecilaizationID = Convert.ToInt32(dr["MVUserSpecializationID"]);
                    mvuserspecialization.Name = dr["Specialization"].ToString();
                }

                if (dr["MedicalVendorTypeID"] != DBNull.Value)
                {
                    mvtype.MedicalVendorTypeID = Convert.ToInt32(dr["MedicalVendorTypeID"]);
                    mvtype.Name = dr["Typename"].ToString();
                }

                medicalvendor.MedicalVendorID = Convert.ToInt32(dr["MedicalVendorID"]);
                medicalvendor.BusinessName = dr["VendorName"].ToString();
                medicalvendor.BusinessPhone = dr["BusinessPhone"].ToString();
                medicalvendor.BusinessFax = dr["BusinessFax"].ToString();
                if (dr["MedicalVendorWiringID"] != DBNull.Value)
                {
                    medicalvendor.MedicalVendorWiringID = Convert.ToInt32(dr["MedicalVendorWiringID"]);
                    medicalvendor.AccountHolder = dr["AccountHolderName"].ToString();
                    medicalvendor.AccountNumber = dr["AccountNumber"].ToString();
                    medicalvendor.AccountType = dr["AccountType"].ToString();
                    medicalvendor.BankName = dr["BankName"].ToString();
                    medicalvendor.PaymentMode = Convert.ToInt32(dr["PaymentMode"]);
                    medicalvendor.RountingNumber = dr["RoutingNumber"].ToString();
                    medicalvendor.Memo = dr["Memo"].ToString();
                    medicalvendor.SpecialInstruction = dr["SpecialInstructions"].ToString();
                    medicalvendor.Interval = Convert.ToInt32(dr["Interval"]);
                    medicalvendor.Frequency = dr["Frequency"].ToString();
                    medicalvendor.FrequencyID = Convert.ToInt32(dr["PaymentFrequencyID"]);
                }
                medicalvendor.Note = dr["Notes"].ToString();
                medicalvendor.EvaluationMode = dr["MEDICALVENDOREVALUATIONMODEID"].ToString();
                medicalvendor.IsHospitalPartner = Convert.ToBoolean(dr["IsHospitalPartner"]);

                DataTable tblref = mvmvuserDataSet.Tables[1];
                tblref.DefaultView.RowFilter = "RefUserID = " + user.UserID;
                int fcount = 0;
                while (fcount < tblref.DefaultView.Count)
                {
                    EReferences refer = new EReferences();
                    refer.Name = tblref.DefaultView[fcount]["RefName"].ToString();
                    refer.EMail = tblref.DefaultView[fcount]["RefEMail"].ToString();
                    reference.Add(refer);
                    fcount++;
                }

                if (dr["BillingAddressID"] != DBNull.Value)
                {
                    DataRow drAdd = mvmvuserDataSet.Tables[3].Select("AddressID = '" + dr["BillingAddressID"].ToString() + "'")[0];


                    caddress.AddressID = Convert.ToInt32(drAdd["AddressID"]);
                    caddress.Address1 = drAdd["Address1"].ToString();
                    caddress.Address2 = drAdd["Address2"].ToString();
                    caddress.ZipID = Convert.ToInt32(drAdd["ZIPID"]);
                    caddress.City = drAdd["CityName"].ToString();
                    caddress.CityID = Convert.ToInt32(drAdd["CityID"]);
                    caddress.State = drAdd["StateName"].ToString();
                    caddress.StateID = Convert.ToInt32(drAdd["StateID"]);
                    caddress.Country = drAdd["CountryName"].ToString();
                    caddress.CountryID = Convert.ToInt32(drAdd["CountryID"]);
                    caddress.Zip = drAdd["ZipCode"].ToString();

                    medicalvendor.BillingAddress = caddress;
                }
                DataRow drAddB = mvmvuserDataSet.Tables[2].Select("AddressID = '" + dr["BusinessAddressID"].ToString() + "'")[0];

                EAddress baddress = new EAddress();
                baddress.AddressID = Convert.ToInt32(drAddB["AddressID"]);
                baddress.Address1 = drAddB["Address1"].ToString();
                baddress.Address2 = drAddB["Address2"].ToString();
                baddress.ZipID = Convert.ToInt32(drAddB["ZIPID"]);
                baddress.City = drAddB["CityName"].ToString();
                baddress.CityID = Convert.ToInt32(drAddB["CityID"]);
                baddress.State = drAddB["StateName"].ToString();
                baddress.StateID = Convert.ToInt32(drAddB["StateID"]);
                baddress.Country = drAddB["CountryName"].ToString();
                baddress.CountryID = Convert.ToInt32(drAddB["CountryID"]);
                baddress.Zip = drAddB["ZipCode"].ToString();

                if (dr["EvaluationMode"] != DBNull.Value)
                {
                    if (dr["EvaluationMode"].ToString().Equals("Customer"))
                    {
                        DataRow[] drcustlist = mvmvuserDataSet.Tables[4].Select("MedicalVendorID = '" + dr["MedicalVendorID"].ToString() + "'");
                        if (drcustlist != null && drcustlist.Length > 0)
                        {
                            DataRow drCust = drcustlist[0];
                            EMVCustomerPayRate customer = new EMVCustomerPayRate();
                            customer.MVCustomerPayRateID = Convert.ToInt32(drCust["MedicalVendorCustomerPayRateID"]);
                            customer.OfferRate = Convert.ToDecimal(drCust["OfferRate"]);
                            medicalvendor.MVCustomerPayRate = customer;
                        }
                    }
                    else if (dr["EvaluationMode"].ToString().Equals("Package"))
                    {
                        // DataRow drPackage = mvmvuserDataSet.Tables[5].Select("MedicalVendorID = '" + dr["MedicalVendorID"].ToString() + "'")[0];
                        List<EMVPackage> package = new List<EMVPackage>();
                        DataTable drPackage = mvmvuserDataSet.Tables[5];
                        drPackage.DefaultView.RowFilter = "MedicalVendorID = " + medicalvendor.MedicalVendorID;
                        int icount = 0;
                        while (icount < drPackage.DefaultView.Count)
                        {
                            EMVPackage mvpackage = new EMVPackage();
                            mvpackage.OfferRate = Convert.ToDecimal(drPackage.DefaultView[icount]["OfferRate"]);
                            mvpackage.MVPackageID = Convert.ToInt32(drPackage.DefaultView[icount]["MedicalVendorPackageID"]);
                            mvpackage.Package = new EPackage();
                            mvpackage.Package.PackageName = drPackage.DefaultView[icount]["PackageName"].ToString();
                            mvpackage.Package.PackageID = Convert.ToInt32(drPackage.DefaultView[icount]["PackageID"]);
                            package.Add(mvpackage);
                            icount++;
                        }
                        medicalvendor.MVPackage = package;
                    }
                    else if (dr["EvaluationMode"].ToString().Equals("Test"))
                    {
                        // DataRow drPackage = mvmvuserDataSet.Tables[5].Select("MedicalVendorID = '" + dr["MedicalVendorID"].ToString() + "'")[0];
                        List<EMVTest> test = new List<EMVTest>();
                        DataTable drTest = mvmvuserDataSet.Tables[6];
                        drTest.DefaultView.RowFilter = "MedicalVendorID = " + medicalvendor.MedicalVendorID;
                        int jcount = 0;
                        while (jcount < drTest.DefaultView.Count)
                        {
                            EMVTest mvtest = new EMVTest();
                            mvtest.OfferRate = Convert.ToDecimal(drTest.DefaultView[jcount]["OfferRate"]);
                            mvtest.MVTestID = Convert.ToInt32(drTest.DefaultView[jcount]["MedicalVendorTestID"]);
                            mvtest.Test = new ETest();
                            mvtest.Test.Name = drTest.DefaultView[jcount]["Test"].ToString();
                            mvtest.Test.TestID = Convert.ToInt32(drTest.DefaultView[jcount]["TestID"]);
                            test.Add(mvtest);
                            jcount++;
                        }
                        medicalvendor.MVTest = test;
                    }
                }

                DataTable tblMVPermittedTest = mvmvuserDataSet.Tables[7];
                tblMVPermittedTest.DefaultView.RowFilter = "MedicalVendorID = " + medicalvendor.MedicalVendorID;
                int pcount = 0;
                while (pcount < tblMVPermittedTest.DefaultView.Count)
                {
                    EMVPermittedTest objMVPermittedTest = new EMVPermittedTest();
                    objMVPermittedTest.Test = new ETest();
                    objMVPermittedTest.Test.TestID = Convert.ToInt32(tblMVPermittedTest.DefaultView[pcount]["TestID"]);
                    objMVPermittedTest.Test.Name = tblMVPermittedTest.DefaultView[pcount]["TestName"].ToString();
                    objMVPermittedTest.MedicalVendorID = Convert.ToInt32(tblMVPermittedTest.DefaultView[pcount]["MedicalVendorID"]);
                    objMVPermittedTest.MVPermittedTestID = Convert.ToInt32(tblMVPermittedTest.DefaultView[pcount]["MVPermittedTestID"]);
                    lstPermittedTest.Add(objMVPermittedTest);
                    pcount++;
                }


                medicalvendor.MVPermittedTest = lstPermittedTest;
                medicalvendor.BusinessAddress = baddress;

                if (mvmvuserDataSet.Tables.Count > 8)
                {
                    DataTable tblHP = mvmvuserDataSet.Tables[8];
                    tblHP.DefaultView.RowFilter = "MedicalVendorID = " + medicalvendor.MedicalVendorID;
                    pcount = 0;
                    while (pcount < tblHP.DefaultView.Count)
                    {
                        medicalvendor.HospitalPartner = new EHospitalPartner();
                        medicalvendor.HospitalPartner.AssociatedPhoneNumber = tblHP.DefaultView[pcount]["AssociatedPhoneNumber"].ToString();
                        medicalvendor.HospitalPartner.IsGlobal = Convert.ToBoolean(tblHP.DefaultView[pcount]["IsGlobal"]);
                        medicalvendor.HospitalPartner.TerritoryID = Convert.ToInt32(tblHP.DefaultView[pcount]["TerritoryID"]);
                        pcount++;

                    }
                }
                mvuser.User = user;
                mvuser.References = reference;
                medicalvendor.Contract = contract;
                mvuser.MVUserSpecialization = mvuserspecialization;
                mvmvuser.MedicalVendor = medicalvendor;
                mvuser.Address = caddress;
                medicalvendor.MedicalVendorType = mvtype;
                mvmvuser.MVUser = mvuser;
                returnMVMVUser.Add(mvmvuser);
            }
            return returnMVMVUser;
        }

        public List<EMVCustomerPayRate> GetMedicalVendorCustomer(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendorcustomer", arParms);

            List<EMVCustomerPayRate> returnMVMVUser = new List<EMVCustomerPayRate>();
            returnMVMVUser = ParseMedicalVendorCustomerDataSet(tempdataset);
            return returnMVMVUser;
        }

        public List<EMVTest> GetMedicalVendorTest(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getmedicalvendortest", arParms);

            List<EMVTest> returnMVMVUser = new List<EMVTest>();
            returnMVMVUser = ParseMedicalVendorTestDataSet(tempdataset);
            return returnMVMVUser;
        }

        public List<EMVPackage> GetMedicalVendorPackage(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendorpackage", arParms);

            List<EMVPackage> returnMVMVUser = new List<EMVPackage>();
            returnMVMVUser = ParseMedicalVendorPackageDataSet(tempdataset);
            return returnMVMVUser;
        }

        private List<EMVCustomerPayRate> ParseMedicalVendorCustomerDataSet(DataSet mvmvuserDataSet)
        {
            List<EMVCustomerPayRate> returnMVMVUser = new List<EMVCustomerPayRate>();

            for (int count = 0; count < mvmvuserDataSet.Tables[0].Rows.Count; count++)
            {

                EMVCustomerPayRate customer = new EMVCustomerPayRate();


                customer.OfferRate = Convert.ToDecimal(mvmvuserDataSet.Tables[0].Rows[count]["OfferRate"]);
                customer.MedicalVendorID = Convert.ToInt32(mvmvuserDataSet.Tables[0].Rows[count]["MedicalVendorID"]);
                customer.MVCustomerPayRateID = Convert.ToInt32(mvmvuserDataSet.Tables[0].Rows[count]["MedicalVendorCustomerPayrateID"]);

                returnMVMVUser.Add(customer);
            }
            return returnMVMVUser;
        }

        private List<EMVTest> ParseMedicalVendorTestDataSet(DataSet mvmvuserDataSet)
        {
            List<EMVTest> returnMVMVUser = new List<EMVTest>();

            for (int count = 0; count < mvmvuserDataSet.Tables[0].Rows.Count; count++)
            {
                EMVTest mvtest = new EMVTest();
                ETest test = new ETest();

                test.TestID = Convert.ToInt32(mvmvuserDataSet.Tables[0].Rows[count]["TestID"]);
                test.Name = Convert.ToString(mvmvuserDataSet.Tables[0].Rows[count]["Test"]);

                mvtest.MedicalVendorID = Convert.ToInt32(mvmvuserDataSet.Tables[0].Rows[count]["MedicalVendorID"]);
                mvtest.MVTestID = Convert.ToInt32(mvmvuserDataSet.Tables[0].Rows[count]["MedicalVendorTestID"]);
                mvtest.OfferRate = Convert.ToDecimal(mvmvuserDataSet.Tables[0].Rows[count]["OfferRate"]);

                mvtest.Test = test;
                returnMVMVUser.Add(mvtest);
            }
            return returnMVMVUser;
        }

        private List<EMVPackage> ParseMedicalVendorPackageDataSet(DataSet mvmvuserDataSet)
        {
            List<EMVPackage> returnMVMVUser = new List<EMVPackage>();

            for (int count = 0; count < mvmvuserDataSet.Tables[0].Rows.Count; count++)
            {
                EMVPackage mvpackage = new EMVPackage();
                EPackage package = new EPackage();

                package.PackageID = Convert.ToInt32(mvmvuserDataSet.Tables[0].Rows[count]["PackageID"]);
                package.PackageName = Convert.ToString(mvmvuserDataSet.Tables[0].Rows[count]["PackageName"]);

                mvpackage.MedicalVendorID = Convert.ToInt32(mvmvuserDataSet.Tables[0].Rows[count]["MedicalVendorID"]);
                mvpackage.MVPackageID = Convert.ToInt32(mvmvuserDataSet.Tables[0].Rows[count]["MedicalVendorPackageID"]);
                mvpackage.OfferRate = Convert.ToDecimal(mvmvuserDataSet.Tables[0].Rows[count]["OfferRate"]);

                mvpackage.Package = package;
                returnMVMVUser.Add(mvpackage);
            }
            return returnMVMVUser;
        }
     
        /// <summary>
        /// Manages Customer Event Lock based on customer event testid provided
        /// </summary>
        /// <param name="customereventtestid"></param>
        /// <param name="testname"></param>
        /// <param name="completecustomer"></param>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <param name="shellid"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public Int16 ManageCustomerEventLocks(int userid, int roleid, int shellid, int intCustomerEventtestID, int intTestID)
        {
            SqlParameter[] arparams = new SqlParameter[6];

            arparams[0] = new SqlParameter("@customereventtestid", SqlDbType.BigInt);
            arparams[0].Value = intCustomerEventtestID;
            arparams[1] = new SqlParameter("@testid", SqlDbType.BigInt);
            arparams[1].Value = intTestID;
            arparams[2] = new SqlParameter("@userid", SqlDbType.BigInt);
            arparams[2].Value = userid;
            arparams[3] = new SqlParameter("@shell", SqlDbType.BigInt);
            arparams[3].Value = shellid;
            arparams[4] = new SqlParameter("@role", SqlDbType.BigInt);
            arparams[4].Value = roleid;
            arparams[5] = new SqlParameter("@returnvalue", SqlDbType.SmallInt);
            arparams[5].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_ManageCustomerEventLock", arparams);
            return Convert.ToInt16(arparams[5].Value);

        }


        /// <summary>
        /// Releases Customer Event Lock based on customer event testid provided
        /// </summary>
        /// <param name="customereventtestid"></param>
        /// <param name="testname"></param>
        /// <param name="completecustomer"></param>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <param name="shellid"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public Int16 ReleaseCustomerEventLock(int userid, int roleid, int shellid, int intCustomerEventtestID,
                                                int intTestID)
        {
            SqlParameter[] arparams = new SqlParameter[7];

            arparams[0] = new SqlParameter("@customereventtestid", SqlDbType.BigInt);
            arparams[0].Value = intCustomerEventtestID;
            arparams[1] = new SqlParameter("@testid", SqlDbType.BigInt);
            arparams[1].Value = intTestID;
            arparams[2] = new SqlParameter("@userid", SqlDbType.BigInt);
            arparams[2].Value = userid;
            arparams[3] = new SqlParameter("@shell", SqlDbType.BigInt);
            arparams[3].Value = shellid;
            arparams[4] = new SqlParameter("@role", SqlDbType.BigInt);
            arparams[4].Value = roleid;
            arparams[5] = new SqlParameter("@returnvalue", SqlDbType.SmallInt);
            arparams[5].Direction = ParameterDirection.Output;
            arparams[6] = new SqlParameter("@removeLock", SqlDbType.Bit);
            arparams[6].Value = true;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_ManageCustomerEventLock", arparams);
            return Convert.ToInt16(arparams[5].Value);

        }

        public Int64 AddMedicalVendorMVUserPublic(EMedicalVendorApplication objMVendorMVUser)
        {
            SqlParameter[] arParms = new SqlParameter[35];
            arParms[0] = new SqlParameter("@businessname", SqlDbType.VarChar, 500);
            arParms[0].Value = objMVendorMVUser.Application.BusinessName;
            arParms[1] = new SqlParameter("@businessphone", SqlDbType.VarChar, 500);
            arParms[1].Value = objMVendorMVUser.BusinessPhone;
            arParms[2] = new SqlParameter("@businessfax", SqlDbType.VarChar, 500);
            arParms[2].Value = objMVendorMVUser.BusinessFax;
            arParms[3] = new SqlParameter("@medicalvendortypeid", SqlDbType.BigInt);
            arParms[3].Value = objMVendorMVUser.MedicalVendorType.MedicalVendorTypeID;
            arParms[4] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
            arParms[4].Value = objMVendorMVUser.Application.BusinessAddress.Address1;
            arParms[5] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[5].Value = objMVendorMVUser.Application.BusinessAddress.Address2;
            arParms[6] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[6].Value = objMVendorMVUser.Application.BusinessAddress.CityID;
            arParms[7] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[7].Value = objMVendorMVUser.Application.BusinessAddress.StateID;
            arParms[8] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[8].Value = objMVendorMVUser.Application.BusinessAddress.CountryID;
            arParms[9] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[9].Value = objMVendorMVUser.Application.BusinessAddress.ZipID;
            arParms[10] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[10].Value = objMVendorMVUser.Application.FirstName;
            arParms[11] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[11].Value = objMVendorMVUser.Application.MiddleName;
            arParms[12] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[12].Value = objMVendorMVUser.Application.LastName;
            arParms[13] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[13].Value = objMVendorMVUser.Application.PhoneHome;
            arParms[14] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[14].Value = objMVendorMVUser.Application.PhoneOffice;
            arParms[15] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[15].Value = objMVendorMVUser.Application.PhoneCell;
            arParms[16] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[16].Value = objMVendorMVUser.Application.Email1;
            arParms[17] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[17].Value = objMVendorMVUser.Application.Email2;
            arParms[18] = new SqlParameter("@caddress1", SqlDbType.VarChar, 500);
            arParms[18].Value = objMVendorMVUser.Application.ContactAddress.Address1;
            arParms[19] = new SqlParameter("@caddress2", SqlDbType.VarChar, 500);
            arParms[19].Value = objMVendorMVUser.Application.ContactAddress.Address2;
            arParms[20] = new SqlParameter("@ccityid", SqlDbType.BigInt);
            arParms[20].Value = objMVendorMVUser.Application.ContactAddress.CityID;
            arParms[21] = new SqlParameter("@cstateid", SqlDbType.BigInt);
            arParms[21].Value = objMVendorMVUser.Application.ContactAddress.StateID;
            arParms[22] = new SqlParameter("@ccountryid", SqlDbType.BigInt);
            arParms[22].Value = objMVendorMVUser.Application.ContactAddress.CountryID;
            arParms[23] = new SqlParameter("@czipid", SqlDbType.BigInt);
            arParms[23].Value = objMVendorMVUser.Application.ContactAddress.ZipID;
            arParms[24] = new SqlParameter("@refname1", SqlDbType.VarChar, 500);
            arParms[24].Value = objMVendorMVUser.Application.ReferenceName1;
            arParms[25] = new SqlParameter("@refemail1", SqlDbType.VarChar, 50);
            arParms[25].Value = objMVendorMVUser.Application.ReferenceEmail1;
            arParms[26] = new SqlParameter("@refname2", SqlDbType.VarChar, 500);
            arParms[26].Value = objMVendorMVUser.Application.ReferenceName2;
            arParms[27] = new SqlParameter("@refemail2", SqlDbType.VarChar, 50);
            arParms[27].Value = objMVendorMVUser.Application.ReferenceEmail2;
            arParms[28] = new SqlParameter("@refname3", SqlDbType.VarChar, 500);
            arParms[28].Value = objMVendorMVUser.Application.ReferenceName3;
            arParms[29] = new SqlParameter("@refemail3", SqlDbType.VarChar, 50);
            arParms[29].Value = objMVendorMVUser.Application.ReferenceEmail3;
            arParms[30] = new SqlParameter("@specilizationid", SqlDbType.BigInt);
            arParms[30].Value = objMVendorMVUser.MedicalSpecialization.MVUserSpecilaizationID;
            arParms[31] = new SqlParameter("@resume", SqlDbType.VarChar, 500);
            arParms[31].Value = objMVendorMVUser.Resume;

            arParms[32] = new SqlParameter("@ssn", SqlDbType.VarChar, 20);
            arParms[32].Value = objMVendorMVUser.Application.SSN;

            arParms[33] = new SqlParameter("@dob", SqlDbType.DateTime);
            if (arParms[33].Value == null)
                arParms[33].Value = DBNull.Value;
            else
                arParms[33].Value = objMVendorMVUser.Application.DOB;

            arParms[34] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[34].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UI_savemedicalvendormedicalvendoruser", arParms);
            Int64 returnvalue = new Int64();

            returnvalue = Convert.ToInt64(arParms[34].Value);
            return returnvalue;
        }

        public List<int> GetPendingQueue(int userid, int roleid, int shellid, string strEvaluationMode)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userid;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[1].Value = roleid;
            arParms[2] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[2].Value = shellid;
            arParms[3] = new SqlParameter("@evaluationmode", SqlDbType.VarChar, 100);
            arParms[3].Value = strEvaluationMode;


            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getpendingqueue", arParms);

            List<int> returnEvent = ParsePendingQueueDataSet(tempdataset);
            return returnEvent;
        }

        private List<int> ParsePendingQueueDataSet(DataSet dsPendingResult)
        {
            List<int> returnPending = new List<int>();

            if (dsPendingResult != null && dsPendingResult.Tables.Count > 0)
            {
                DataTable dttest = dsPendingResult.Tables[0];

                foreach (DataRow drTest in dttest.Rows)
                {
                    returnPending.Add(Convert.ToInt32(drTest["CustomerEventTestID"]));
                }
            }

            return returnPending;
        }

        public Boolean GetMVUserQueueInfo(Int32 UserID, Int32 Shell, Int32 Role,
            out string strMyTotalEvaluations, out string strMyEvaluationsAfterPay,
            out string strMyTotalEarning, out string strMyLastPayment, out string strAmountOwed, out string strMyTotalPayment)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = UserID;
            arParms[1] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[1].Value = Shell;
            arParms[2] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[2].Value = Role;

            arParms[3] = new SqlParameter("@strmytotalevaluations", SqlDbType.VarChar, 100);
            arParms[3].Direction = ParameterDirection.Output;
            arParms[4] = new SqlParameter("@strmyevaluationsafterpay", SqlDbType.VarChar, 100);
            arParms[4].Direction = ParameterDirection.Output;
            arParms[5] = new SqlParameter("@strmytotalearning", SqlDbType.VarChar, 100);
            arParms[5].Direction = ParameterDirection.Output;
            arParms[6] = new SqlParameter("@strmylastpayment", SqlDbType.VarChar, 100);
            arParms[6].Direction = ParameterDirection.Output;
            arParms[7] = new SqlParameter("@stramountowed", SqlDbType.VarChar, 100);
            arParms[7].Direction = ParameterDirection.Output;
            arParms[8] = new SqlParameter("@strmytotalpayment", SqlDbType.VarChar, 100);
            arParms[8].Direction = ParameterDirection.Output;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmvuserqueueinfo", arParms);

            strMyTotalEvaluations = arParms[3].Value.ToString();
            strMyEvaluationsAfterPay = arParms[4].Value.ToString();
            strMyTotalEarning = arParms[5].Value.ToString();
            strMyLastPayment = arParms[6].Value.ToString();
            strAmountOwed = arParms[7].Value.ToString();
            strMyTotalPayment = arParms[8].Value.ToString();

            return true;
        }

        public Boolean GetMVUserEarningInfo(Int32 UserID, Int32 Shell, Int32 Role,
            out string strEarningTotal, out string strEarningThisYear,
            out string strEarningThisMonth, out string strEarningThisQuarter,
            out string strEarningToday)
        {
            SqlParameter[] arParms = new SqlParameter[8];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = UserID;
            arParms[1] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[1].Value = Shell;
            arParms[2] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[2].Value = Role;

            arParms[3] = new SqlParameter("@strearningtotal", SqlDbType.VarChar, 100);
            arParms[3].Direction = ParameterDirection.Output;
            arParms[4] = new SqlParameter("@strearningthisyear", SqlDbType.VarChar, 100);
            arParms[4].Direction = ParameterDirection.Output;
            arParms[5] = new SqlParameter("@strearningthismonth", SqlDbType.VarChar, 100);
            arParms[5].Direction = ParameterDirection.Output;
            arParms[6] = new SqlParameter("@strearningthisquarter", SqlDbType.VarChar, 100);
            arParms[6].Direction = ParameterDirection.Output;
            arParms[7] = new SqlParameter("@strearningtoday", SqlDbType.VarChar, 100);
            arParms[7].Direction = ParameterDirection.Output;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getmvuserearninginfo", arParms);

            strEarningTotal = arParms[3].Value.ToString();
            strEarningThisYear = arParms[4].Value.ToString();
            strEarningThisMonth = arParms[5].Value.ToString();
            strEarningThisQuarter = arParms[6].Value.ToString();
            strEarningToday = arParms[7].Value.ToString();

            return true;
        }


        public List<EEventCustomer> GetMVUserPaymentAndEarning(int userid, int roleid, int shellid, string strStartDate, string strEndDate)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userid;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[1].Value = roleid;
            arParms[2] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[2].Value = shellid;

            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 20);
            if (strStartDate.Trim().Length < 1)
                arParms[3].Value = DBNull.Value;
            else
                arParms[3].Value = strStartDate;


            arParms[4] = new SqlParameter("@enddate", SqlDbType.VarChar, 20);
            if (strEndDate.Trim().Length < 1)
                arParms[4].Value = DBNull.Value;
            else
                arParms[4].Value = strEndDate;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmvuserpaymentearning", arParms);

            List<EEventCustomer> returnEventCustomer = new List<EEventCustomer>();
            returnEventCustomer = ParseMVUserPaymentAndEarningDataSet(tempdataset);
            return returnEventCustomer;
        }

        private List<EEventCustomer> ParseMVUserPaymentAndEarningDataSet(DataSet dsPaymentAndEarning)
        {
            List<EEventCustomer> lstECustomer = new List<EEventCustomer>();
            if (dsPaymentAndEarning == null)
                return lstECustomer;

            DataTable dtcustomerinfo = dsPaymentAndEarning.Tables[0];

            foreach (DataRow dr in dtcustomerinfo.Rows)
            {
                ////// Fill the Package and Test information


                EEvent objEvent = new EEvent();

                EEventCustomer objEventCustomer = new EEventCustomer();

                objEventCustomer.Customer = new ECustomers();
                objEventCustomer.Customer.User = new Entity.Other.EUser();

                objEventCustomer.CustomerEventTestID = Convert.ToInt32(dr["CustomerEventTestID"]);
                objEventCustomer.Customer.User.FirstName = dr["FirstName"].ToString();
                objEventCustomer.Customer.User.MiddleName = dr["MiddleName"].ToString();
                objEventCustomer.Customer.User.LastName = dr["LastName"].ToString();
                objEventCustomer.Customer.Gender = dr["Gender"].ToString();
                objEventCustomer.Customer.Age = Convert.ToInt16(dr["Age"]);

                objEventCustomer.PaymentDetail = new EPaymentDetail();
                objEventCustomer.PaymentDetail.PayDate = (dr["TransactionDate"]).ToString();


                if (Convert.ToInt16(dr["ProgressStatus"]) < 3)
                {
                    objEventCustomer.Paid = false;
                }
                else
                {
                    objEventCustomer.Paid = true;
                }
                objEventCustomer.PaidAmount = Convert.ToSingle(dr["MVMVUserPaymentAmount"]);

                objEventCustomer.EventPackage = new EEventPackage();
                objEventCustomer.EventPackage.Package = new EPackage();
                objEventCustomer.EventPackage.Package.PackageName = dr["PackageName"].ToString();
                //////////////

                lstECustomer.Add(objEventCustomer);

            }

            return lstECustomer;
        }
        
        public DataSet GetMVMVUserDetails(long MVMVUserID)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@MVMVUserID", SqlDbType.BigInt);
            arParms[0].Value = MVMVUserID;

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getMVMVUserDetails", arParms);
            return ds;
        }

        public List<EMVPaymentInfo> GetMVUserPaymentInfo(int userid, int roleid, int shellid, string strStartDate, string strEndDate)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userid;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[1].Value = roleid;
            arParms[2] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[2].Value = shellid;

            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 20);
            if (strStartDate.Trim().Length < 1)
                arParms[3].Value = DBNull.Value;
            else
                arParms[3].Value = strStartDate;


            arParms[4] = new SqlParameter("@enddate", SqlDbType.VarChar, 20);
            if (strEndDate.Trim().Length < 1)
                arParms[4].Value = DBNull.Value;
            else
                arParms[4].Value = strEndDate;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getMVUserPayment", arParms);
            List<EMVPaymentInfo> objlMVPaymentInfo = new List<EMVPaymentInfo>();
            if (tempdataset != null && tempdataset.Tables.Count > 0 && tempdataset.Tables[0].Rows.Count > 0)
            {
                DataTable dtMVPaymentInfo = tempdataset.Tables[0];
                foreach (DataRow dr in dtMVPaymentInfo.Rows)
                {
                    EMVPaymentInfo objMVPaymentInfo = new EMVPaymentInfo();
                    objMVPaymentInfo.LastPaymentDate = dr["PaymentDate"].ToString();
                    objMVPaymentInfo.TotalEvaluations = Convert.ToInt32(dr["EvaluationCount"].ToString());
                    objMVPaymentInfo.PayingAmount = Convert.ToDecimal(dr["PaymentAmount"].ToString());
                    objMVPaymentInfo.CheckNumber = dr["ChequeNumber"].ToString();

                    objlMVPaymentInfo.Add(objMVPaymentInfo);
                }
            }
            return objlMVPaymentInfo;

        }



        #endregion

        # region "MedicalVendor"

        public List<EMedicalVendor> GetAllMedicalVendor(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendor", arParms);

            List<EMedicalVendor> returnMV = new List<EMedicalVendor>();
            returnMV = ParseMVDataSet(tempdataset);
            return returnMV;
        }

        private List<EMedicalVendor> ParseMVDataSet(DataSet mvDataSet)
        {
            List<EMedicalVendor> returnMV = new List<EMedicalVendor>();

            for (int count = 0; count < mvDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EMedicalVendor medicalvendor = new EMedicalVendor();
                    EAddress medicaladdress = new EAddress();
                    EMedicalVendorType medicalvendortype = new EMedicalVendorType();

                    medicaladdress.AddressID = Convert.ToInt32(mvDataSet.Tables[0].Rows[count]["AddressId"]);

                    medicalvendortype.MedicalVendorTypeID = Convert.ToInt32(mvDataSet.Tables[0].Rows[count]["MedicalVendorTypeID"]);
                    //medicalvendor.EvaluationMode = Convert.ToString(mvDataSet.Tables[0].Rows[count]["MEDICALVENDOREVALUATIONMODEID"]);
                    medicalvendor.EvaluationMode = Convert.ToString(mvDataSet.Tables[0].Rows[count]["EvaluationMode"]);
                    medicalvendor.Active = Convert.ToBoolean(mvDataSet.Tables[0].Rows[count]["IsActive"]);
                    medicalvendor.BusinessAddress = medicaladdress;
                    medicalvendor.BusinessFax = Convert.ToString(mvDataSet.Tables[0].Rows[count]["BusinessFax"]);
                    medicalvendor.BusinessName = Convert.ToString(mvDataSet.Tables[0].Rows[count]["BusinessName"]);
                    medicalvendor.BusinessPhone = Convert.ToString(mvDataSet.Tables[0].Rows[count]["BusinessPhone"]);
                    if (mvDataSet.Tables[0].Rows[count]["ContractId"] != DBNull.Value)
                    {
                        medicalvendor.Contract = new EContract();
                        medicalvendor.Contract.ContractID = Convert.ToInt32(mvDataSet.Tables[0].Rows[count]["ContractId"]);
                    }
                    medicalvendor.MedicalVendorID = Convert.ToInt32(mvDataSet.Tables[0].Rows[count]["MedicalVendorID"]);
                    medicalvendor.MedicalVendorWiringID = Convert.ToInt32(mvDataSet.Tables[0].Rows[count]["MedicalVendorWiringId"]);
                    medicalvendor.Note = Convert.ToString(mvDataSet.Tables[0].Rows[count]["Notes"]);
                    medicalvendor.TeamPicture = Convert.ToString(mvDataSet.Tables[0].Rows[count]["TeamPicture"]);
                    medicalvendor.MedicalVendorType = medicalvendortype;


                    returnMV.Add(medicalvendor);
                }
                catch (Exception)
                {
                }
            }

            return returnMV;
        }

        public Int64 SaveMedicalVendorUser(EMVMVUser medicalvendorUser, int mode, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[38];
            arParms[0] = new SqlParameter("@medicalvendoruserid", SqlDbType.BigInt);
            arParms[0].Value = medicalvendorUser.MVUser.MVUserID;
            arParms[1] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
            arParms[1].Value = medicalvendorUser.MedicalVendor.MedicalVendorID;
            arParms[2] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
            arParms[2].Value = medicalvendorUser.MVUser.User.HomeAddress.Address1;
            arParms[3] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[3].Value = medicalvendorUser.MVUser.User.HomeAddress.Address2;
            arParms[4] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[4].Value = medicalvendorUser.MVUser.User.HomeAddress.CityID;
            arParms[5] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[5].Value = medicalvendorUser.MVUser.User.HomeAddress.StateID;
            arParms[6] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[6].Value = medicalvendorUser.MVUser.User.HomeAddress.CountryID;
            arParms[7] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[7].Value = medicalvendorUser.MVUser.User.HomeAddress.ZipID;
            arParms[8] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[8].Value = medicalvendorUser.MVUser.User.FirstName;
            arParms[9] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[9].Value = medicalvendorUser.MVUser.User.MiddleName;
            arParms[10] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[10].Value = medicalvendorUser.MVUser.User.LastName;
            arParms[11] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[11].Value = medicalvendorUser.MVUser.User.PhoneHome;
            arParms[12] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[12].Value = medicalvendorUser.MVUser.User.PhoneOffice;
            arParms[13] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[13].Value = medicalvendorUser.MVUser.User.PhoneCell;
            arParms[14] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[14].Value = medicalvendorUser.MVUser.User.EMail1;
            arParms[15] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[15].Value = medicalvendorUser.MVUser.User.EMail2;
            arParms[16] = new SqlParameter("@dob", SqlDbType.VarChar, 500);
            arParms[16].Value = medicalvendorUser.MVUser.User.DOB;
            arParms[17] = new SqlParameter("@ssn", SqlDbType.VarChar, 500);
            arParms[17].Value = medicalvendorUser.MVUser.User.SSN;
            arParms[18] = new SqlParameter("@refname1", SqlDbType.VarChar, 500);
            arParms[18].Value = medicalvendorUser.MVUser.References[0].Name;
            arParms[19] = new SqlParameter("@refemail1", SqlDbType.VarChar, 500);
            arParms[19].Value = medicalvendorUser.MVUser.References[0].EMail;
            arParms[20] = new SqlParameter("@refname2", SqlDbType.VarChar, 500);
            arParms[20].Value = medicalvendorUser.MVUser.References[1].Name;
            arParms[21] = new SqlParameter("@refemail2", SqlDbType.VarChar, 500);
            arParms[21].Value = medicalvendorUser.MVUser.References[1].EMail;
            arParms[22] = new SqlParameter("@refname3", SqlDbType.VarChar, 500);
            arParms[22].Value = medicalvendorUser.MVUser.References[2].Name;
            arParms[23] = new SqlParameter("@refemail3", SqlDbType.VarChar, 500);
            arParms[23].Value = medicalvendorUser.MVUser.References[2].EMail;
            arParms[24] = new SqlParameter("@specilizationid", SqlDbType.BigInt);
            arParms[24].Value = medicalvendorUser.MVUser.MVUserSpecialization.MVUserSpecilaizationID;
            arParms[25] = new SqlParameter("@classificationid", SqlDbType.BigInt);
            arParms[25].Value = medicalvendorUser.MVUser.MVUserClassification.MVUserClassificationID;
            arParms[26] = new SqlParameter("@resume", SqlDbType.VarChar, 500);
            arParms[26].Value = medicalvendorUser.MVUser.Resume;
            arParms[27] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[27].Value = mode;
           
            arParms[28] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[28].Direction = ParameterDirection.Output;
            arParms[29] = new SqlParameter("@userid1", SqlDbType.BigInt);
            arParms[29].Value = medicalvendorUser.MVUser.User.UserID;
            arParms[30] = new SqlParameter("@mvuserid1", SqlDbType.BigInt);
            arParms[30].Value = medicalvendorUser.MVUser.MVUserID;
            arParms[31] = new SqlParameter("@medicalvendormvuserid1", SqlDbType.BigInt);
            arParms[31].Value = medicalvendorUser.MedicalVendorMVUserID;
            arParms[32] = new SqlParameter("@digitalsignature", SqlDbType.VarChar, 500);
            arParms[32].Value = medicalvendorUser.MVUser.DigitalSignature;
            arParms[33] = new SqlParameter("@notes", SqlDbType.VarChar, 5000);
            arParms[33].Value = medicalvendorUser.Notes;
            arParms[34] = new SqlParameter("@cutoffdate", SqlDbType.DateTime);
            if (medicalvendorUser.CutOffDate.Trim().Length > 0)
                arParms[34].Value = medicalvendorUser.CutOffDate;
            else
                arParms[34].Value = DBNull.Value;

            if (medicalvendorUser.Notes.Length <= 0)
            {
                arParms[33].Value = "";
            }
            else
            {
                arParms[33].Value = medicalvendorUser.Notes;
            }
            arParms[35] = new SqlParameter("@ShowEarningAmount", SqlDbType.Bit);
            arParms[35].Value = medicalvendorUser.ShowEarningAmount;

            arParms[36] = new SqlParameter("@isauthorizationsallowed", SqlDbType.Bit);
            arParms[36].Value = medicalvendorUser.IsAuthorizationsAllowed;

            arParms[37] = new SqlParameter("@auditrequired", SqlDbType.Bit);
            arParms[37].Value = medicalvendorUser.AuditRequired;

            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemedicalvendoruser", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemedicalvendoruser", arParms);

            }
            returnvalue = (Int64)arParms[28].Value;

            if (medicalvendorUser.ListPods != null && medicalvendorUser.ListPods.Count > 0 && returnvalue >= 0 && returnvalue != 999999)
            {
                if (medicalvendorUser.MedicalVendorMVUserID > 0)
                    SaveMVMVuserPodMapping(medicalvendorUser.ListPods, medicalvendorUser.MedicalVendorMVUserID, transaction);
                else if (returnvalue > 0)
                    SaveMVMVuserPodMapping(medicalvendorUser.ListPods, returnvalue, transaction);
            }

            return returnvalue;
        }

        /// <summary>
        /// Saves Physician and Pods mapping
        /// </summary>
        /// <param name="listpod"></param>
        /// <param name="mvmvuserid"></param>
        private void SaveMVMVuserPodMapping(List<Int32> listpod, Int64 mvmvuserid, SqlTransaction sqltran)
        {
            SqlParameter[] arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@mvmvuser", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@podid", SqlDbType.Int);
            arparams[2] = new SqlParameter("@rowcount", SqlDbType.TinyInt);

            for (int icount = 0; icount < listpod.Count; icount++)
            {
                arparams[0].Value = mvmvuserid;
                arparams[1].Value = listpod[icount];
                arparams[2].Value = icount;

                if (sqltran == null)
                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveMVMVUserPodMapping", arparams);
                else
                    SqlHelper.ExecuteNonQuery(sqltran, CommandType.StoredProcedure, "usp_saveMVMVUserPodMapping", arparams);
            }
        }

        public Int64 SaveMVMVTest(List<EMVMVUserTest> test, int mode, Int32 mvmvuserID, Int32 MedicalVendorID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();
            for (int icount = 0; icount < test.Count; icount++)
            {
                SqlParameter[] arParms = new SqlParameter[6];
                arParms[0] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
                arParms[0].Value = MedicalVendorID;
                arParms[1] = new SqlParameter("@offerrate", SqlDbType.Decimal, 18);
                arParms[1].Precision = 18;
                arParms[1].Scale = 2;
                arParms[1].Value = test[icount].OfferRate;
                arParms[2] = new SqlParameter("@testid", SqlDbType.BigInt);
                arParms[2].Value = test[icount].MVTest.Test.TestID;
                arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[3].Value = icount;
                arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[4].Direction = ParameterDirection.Output;
                arParms[5] = new SqlParameter("@mvmvuserid", SqlDbType.BigInt);
                arParms[5].Value = mvmvuserID;
                if (transaction == null)
                {
                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvmvtest", arParms);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemvmvtest", arParms);
                }
                returnvalue = (Int64)arParms[4].Value;
            }

            return returnvalue;
        }

        public Int64 SaveMVMVPackage(List<EMVMVUserPackage> package, int mode, Int32 mvmvuserID, Int32 MedicalVendorID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();
            for (int icount = 0; icount < package.Count; icount++)
            {
                SqlParameter[] arParms = new SqlParameter[6];
                arParms[0] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
                arParms[0].Value = MedicalVendorID;
                arParms[1] = new SqlParameter("@offerrate", SqlDbType.Decimal, 18);
                arParms[1].Precision = 18;
                arParms[1].Scale = 2;
                arParms[1].Value = package[icount].OfferRate;
                arParms[2] = new SqlParameter("@packageid", SqlDbType.BigInt);
                arParms[2].Value = package[icount].MVPackage.Package.PackageID;
                arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[3].Value = icount;
                arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[4].Direction = ParameterDirection.Output;
                arParms[5] = new SqlParameter("@mvmvuserid", SqlDbType.BigInt);
                arParms[5].Value = mvmvuserID;
                if (transaction == null)
                {
                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvmvpackage", arParms);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemvmvpackage", arParms);
                }
                returnvalue = (Int64)arParms[4].Value;
            }

            return returnvalue;
        }

        public Int64 SaveMVMVCustomer(EMVMVUserCustomerPayRate customer, int mode, Int32 mvmvuserID, Int32 MedicalVendorID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();

            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
            arParms[0].Value = MedicalVendorID;
            arParms[1] = new SqlParameter("@offerrate", SqlDbType.Decimal, 18);
            arParms[1].Precision = 18;
            arParms[1].Scale = 2;
            arParms[1].Value = customer.OfferRate;
            arParms[2] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[2].Value = 0;
            arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;
            arParms[4] = new SqlParameter("@mvmvuserid", SqlDbType.BigInt);
            arParms[4].Value = mvmvuserID;
            //SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvcustomer", arParms);
            //returnvalue = (Int64)arParms[3].Value;
            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvmvcustomer", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemvmvcustomer", arParms);
            }
            returnvalue = (Int64)arParms[3].Value;
            return returnvalue;
        }

        public Int64 SaveMedicalVendorUserProfile(EMVMVUser medicalvendorUser, int mode, string UserID, long Shell, string Role)
        {
            SqlConnection conobj = new SqlConnection(connectionstring);
            if (conobj.State == ConnectionState.Closed)
            {
                conobj.Open();
            }
            SqlTransaction tranobj = conobj.BeginTransaction();
            Int64 returnvalue = new Int64();
            try
            {
                SqlParameter[] arParms = new SqlParameter[40];
                arParms[0] = new SqlParameter("@medicalvendoruserid", SqlDbType.BigInt);
                arParms[0].Value = medicalvendorUser.MVUser.MVUserID;
                arParms[1] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
                arParms[1].Value = medicalvendorUser.MedicalVendor.MedicalVendorID;
                arParms[2] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
                arParms[2].Value = medicalvendorUser.MVUser.User.HomeAddress.Address1;
                arParms[3] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
                arParms[3].Value = medicalvendorUser.MVUser.User.HomeAddress.Address2;
                arParms[4] = new SqlParameter("@cityid", SqlDbType.BigInt);
                arParms[4].Value = medicalvendorUser.MVUser.User.HomeAddress.CityID;
                arParms[5] = new SqlParameter("@stateid", SqlDbType.BigInt);
                arParms[5].Value = medicalvendorUser.MVUser.User.HomeAddress.StateID;
                arParms[6] = new SqlParameter("@countryid", SqlDbType.BigInt);
                arParms[6].Value = medicalvendorUser.MVUser.User.HomeAddress.CountryID;
                arParms[7] = new SqlParameter("@zipid", SqlDbType.BigInt);
                arParms[7].Value = medicalvendorUser.MVUser.User.HomeAddress.ZipID;
                arParms[8] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
                arParms[8].Value = medicalvendorUser.MVUser.User.FirstName;
                arParms[9] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
                arParms[9].Value = medicalvendorUser.MVUser.User.MiddleName;
                arParms[10] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
                arParms[10].Value = medicalvendorUser.MVUser.User.LastName;
                arParms[11] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
                arParms[11].Value = medicalvendorUser.MVUser.User.PhoneHome;
                arParms[12] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
                arParms[12].Value = medicalvendorUser.MVUser.User.PhoneOffice;
                arParms[13] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
                arParms[13].Value = medicalvendorUser.MVUser.User.PhoneCell;
                arParms[14] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
                arParms[14].Value = medicalvendorUser.MVUser.User.EMail1;
                arParms[15] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
                arParms[15].Value = medicalvendorUser.MVUser.User.EMail2;
                arParms[16] = new SqlParameter("@dob", SqlDbType.VarChar, 500);
                arParms[16].Value = medicalvendorUser.MVUser.User.DOB;
                arParms[17] = new SqlParameter("@ssn", SqlDbType.VarChar, 500);
                arParms[17].Value = medicalvendorUser.MVUser.User.SSN;
                arParms[18] = new SqlParameter("@refname1", SqlDbType.VarChar, 500);
                arParms[18].Value = medicalvendorUser.MVUser.References[0].Name;
                arParms[19] = new SqlParameter("@refemail1", SqlDbType.VarChar, 500);
                arParms[19].Value = medicalvendorUser.MVUser.References[0].EMail;
                arParms[20] = new SqlParameter("@refname2", SqlDbType.VarChar, 500);
                arParms[20].Value = medicalvendorUser.MVUser.References[1].Name;
                arParms[21] = new SqlParameter("@refemail2", SqlDbType.VarChar, 500);
                arParms[21].Value = medicalvendorUser.MVUser.References[1].EMail;
                arParms[22] = new SqlParameter("@refname3", SqlDbType.VarChar, 500);
                arParms[22].Value = medicalvendorUser.MVUser.References[2].Name;
                arParms[23] = new SqlParameter("@refemail3", SqlDbType.VarChar, 500);
                arParms[23].Value = medicalvendorUser.MVUser.References[2].EMail;
                arParms[24] = new SqlParameter("@specilizationid", SqlDbType.BigInt);
                arParms[24].Value = medicalvendorUser.MVUser.MVUserSpecialization.MVUserSpecilaizationID;
                arParms[25] = new SqlParameter("@classificationid", SqlDbType.BigInt);
                if (medicalvendorUser.MVUser.MVUserClassification.MVUserClassificationID == 0)
                    arParms[25].Value = DBNull.Value;
                else
                    arParms[25].Value = medicalvendorUser.MVUser.MVUserClassification.MVUserClassificationID;
                arParms[26] = new SqlParameter("@resume", SqlDbType.VarChar, 500);
                arParms[26].Value = medicalvendorUser.MVUser.Resume;
                arParms[27] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[27].Value = mode;
                arParms[28] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
                arParms[28].Value = UserID;
                arParms[29] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
                arParms[29].Value = Shell;
                arParms[30] = new SqlParameter("@role", SqlDbType.VarChar, 500);
                arParms[30].Value = Role;
                arParms[31] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[31].Direction = ParameterDirection.Output;
                arParms[32] = new SqlParameter("@userid1", SqlDbType.BigInt);
                arParms[32].Value = medicalvendorUser.MVUser.User.UserID;
                arParms[33] = new SqlParameter("@mvuserid1", SqlDbType.BigInt);
                arParms[33].Value = medicalvendorUser.MVUser.MVUserID;
                arParms[34] = new SqlParameter("@medicalvendormvuserid1", SqlDbType.BigInt);
                arParms[34].Value = medicalvendorUser.MedicalVendorMVUserID;

                arParms[35] = new SqlParameter("@digitalsignature", SqlDbType.VarChar, 500);
                arParms[35].Value = medicalvendorUser.MVUser.DigitalSignature;
                arParms[36] = new SqlParameter("@cutoffdate", SqlDbType.DateTime);
                if (medicalvendorUser.CutOffDate.Trim().Length < 1)
                    arParms[36].Value = DBNull.Value;
                else
                    arParms[36].Value = medicalvendorUser.CutOffDate;

                arParms[37] = new SqlParameter("@isauthorizationsallowed", SqlDbType.Bit);
                arParms[37].Value = medicalvendorUser.IsAuthorizationsAllowed;

                arParms[38] = new SqlParameter("@ShowEarningAmount", SqlDbType.Bit);
                arParms[38].Value = medicalvendorUser.ShowEarningAmount;

                arParms[39] = new SqlParameter("@auditrequired", SqlDbType.Bit);
                arParms[39].Value = medicalvendorUser.AuditRequired;
                /*parameter added as required in sp*/
                SqlHelper.ExecuteNonQuery(tranobj, CommandType.StoredProcedure, "usp_savemedicalvendoruser", arParms);

                Falcon.DataAccess.Master.MasterDAL masterdal = new Falcon.DataAccess.Master.MasterDAL();
                Int64 getreturn = masterdal.SaveUserImages(Convert.ToInt64(medicalvendorUser.MVUser.User.UserID), medicalvendorUser.MVUser.MyPicture, "", medicalvendorUser.MVUser.OtherPictures, ERoleType.MedicalVendorUser, mode, Shell, tranobj);
                if (getreturn == 999998 || getreturn == -1)
                {
                    tranobj.Rollback();
                    return -1;
                }

                tranobj.Commit();
                returnvalue = (Int64)arParms[31].Value;
            }

            catch (Exception ex)
            {
                tranobj.Rollback();
                throw ex;
            }
            return returnvalue;
        }

        public Int64 SaveMedicalVendorUserTestPayRate(List<EMVTestPayRate> testpayrate, Int32 medicalvendormvuserid, int mode, SqlTransaction transaction)
        {
            Int64 returnvalue = 0;
            for (int icount = 0; icount < testpayrate.Count; icount++)
            {
                SqlParameter[] arParms = new SqlParameter[4];
                arParms[0] = new SqlParameter("@mvmvuserid", SqlDbType.BigInt);
                arParms[0].Value = medicalvendormvuserid;
                arParms[1] = new SqlParameter("@testid", SqlDbType.BigInt);
                arParms[1].Value = testpayrate[icount].Test.TestID;
                arParms[2] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[2].Value = icount;
                arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[3].Direction = ParameterDirection.Output;

                if (transaction == null)
                {
                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemedicalvendorusertestpayrate", arParms);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_savemedicalvendorusertestpayrate", arParms);
                }
                returnvalue = (Int64)arParms[3].Value;
            }

            return returnvalue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="ShellID"></param>
        /// <param name="strRoleType"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EMedicalVendor> GetMedicalVendor(String filterString, Int64 ShellID, string strRoleType, int inputMode)
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
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendorprofile", arParms);
            List<EMedicalVendor> returnMedicalVendor = new List<EMedicalVendor>();
            returnMedicalVendor = ParseMedicalVendorDataSet(tempdataset);
            return returnMedicalVendor;
        }
        private List<EMedicalVendor> ParseMedicalVendorDataSet(DataSet mvDataSet)
        {
            List<EMedicalVendor> returnMedicalVendor = new List<EMedicalVendor>();

            int intMaxPicCount = IoC.Resolve<ISettings>().MaximumPictureCount;
            foreach (DataRow row in mvDataSet.Tables[0].Rows)
            {
                try
                {
                    EMedicalVendor medicalvendor = new EMedicalVendor();
                    EAddress BAddress = new EAddress();

                    if (row["PaymentMode"] != null)
                    {
                        medicalvendor.PaymentMode = Convert.ToInt32(row["PaymentMode"]);
                        medicalvendor.BankName = Convert.ToString(row["BankName"]);
                        medicalvendor.AccountHolder = Convert.ToString(row["AccountHolderName"]);
                        medicalvendor.AccountType = Convert.ToString(row["Accounttype"]);
                        medicalvendor.RountingNumber = Convert.ToString(row["RoutingNumber"]);
                        medicalvendor.AccountNumber = Convert.ToString(row["AccountNumber"]);
                        medicalvendor.Memo = Convert.ToString(row["Memo"]);
                        medicalvendor.Interval = Convert.ToInt32(row["Interval"]);
                        medicalvendor.SpecialInstruction = Convert.ToString(row["SpecialInstructions"]);
                        medicalvendor.Description = Convert.ToString(row["Description"]);
                    }
                    BAddress.Address1 = Convert.ToString(row["BAddress1"]);
                    BAddress.Address2 = Convert.ToString(row["BAddress2"]);
                    BAddress.CityID = Convert.ToInt32(row["BCityID"]);
                    BAddress.City = Convert.ToString(row["BCity"]);
                    BAddress.CountryID = Convert.ToInt32(row["BCountryID"]);
                    BAddress.Country = Convert.ToString(row["BCountry"]);
                    BAddress.StateID = Convert.ToInt32(row["BStateID"]);
                    BAddress.State = Convert.ToString(row["BState"]);
                    BAddress.Zip = Convert.ToString(row["BZipCode"]);
                    medicalvendor.BusinessAddress = BAddress;
                    medicalvendor.BusinessFax = Convert.ToString(row["BusinessFax"]);
                    medicalvendor.BusinessPhone = Convert.ToString(row["BusinessPhone"]);
                    medicalvendor.BusinessName = Convert.ToString(row["BusinessName"]);
                    medicalvendor.MedicalVendorType = new EMedicalVendorType();
                    medicalvendor.MedicalVendorType.MedicalVendorTypeID = Convert.ToInt32(row["MedicalVendorTypeID"]);
                    medicalvendor.MedicalVendorType.Name = Convert.ToString(row["VendorType"]);

                    EAddress Address = new EAddress();

                    Address.Address1 = Convert.ToString(row["Address1"]);
                    Address.Address2 = Convert.ToString(row["Address2"]);
                    Address.CityID = Convert.ToInt32(row["CityID"]);
                    Address.City = Convert.ToString(row["City"]);
                    Address.CountryID = Convert.ToInt32(row["CountryID"]);
                    Address.Country = Convert.ToString(row["Country"]);
                    Address.StateID = Convert.ToInt32(row["StateID"]);
                    Address.State = Convert.ToString(row["State"]);
                    Address.Zip = Convert.ToString(row["ZipCode"]);
                    // medicalvendor.MVUser.DigitalSignature = Convert.ToByte(mvDataSet.Tables[0].Rows[count]["DigitalSignature"]);

                    medicalvendor.MVUser = new EMVUser();

                    medicalvendor.MVUser.MVUserSpecialization = new EMVUserSpecialization();
                    medicalvendor.MVUser.MVUserSpecialization.MVUserSpecilaizationID = Convert.ToInt32(row["MVUserSpecializationID"]);
                    medicalvendor.MVUser.MVUserSpecialization.Name = Convert.ToString(row["Specialization"]);
                    medicalvendor.MVUser.MVUserID = Convert.ToInt32(row["MVUserID"]);
                    medicalvendor.MVUser.User = new Entity.Other.EUser();
                    medicalvendor.MVUser.User.HomeAddress = Address;
                    medicalvendor.MVUser.User.UserID = Convert.ToInt32(row["UserID"]);
                    medicalvendor.MVUser.User.FirstName = Convert.ToString(row["FirstName"]);
                    medicalvendor.MVUser.User.MiddleName = Convert.ToString(row["MiddleName"]);
                    medicalvendor.MVUser.User.LastName = Convert.ToString(row["LastName"]);
                    medicalvendor.MVUser.User.PhoneHome = Convert.ToString(row["PhoneHome"]);
                    medicalvendor.MVUser.User.PhoneCell = Convert.ToString(row["PhoneCell"]);
                    medicalvendor.MVUser.User.PhoneOffice = Convert.ToString(row["PhoneOffice"]);
                    medicalvendor.MVUser.User.EMail1 = Convert.ToString(row["EMail1"]);
                    medicalvendor.MVUser.User.EMail2 = Convert.ToString(row["EMail2"]);
                    medicalvendor.MVUser.User.DOB = Convert.ToString(row["DOB"]);
                    medicalvendor.MVUser.User.SSN = Convert.ToString(row["SSN"]);

                    medicalvendor.MVUser.MyPicture = Convert.ToString(row["MyPicture"]);
                    medicalvendor.MVUser.TeamPicture = Convert.ToString(row["TeamPicture"]);
                    medicalvendor.MedicalVendorID = Convert.ToInt32(row["MedicalVendorID"]);

                    // medicalvendor.MVUser.CreateDate = Convert.ToString(mvDataSet.Tables[0].Rows[count]["CreateDate"]);
                    List<string> otherpicture = new List<string>();
                    for (int icount = 1; icount < 13; icount++)
                    {

                        if (icount < intMaxPicCount)
                        { otherpicture.Add(row["Picture" + icount].ToString()); }
                        else
                        { otherpicture.Add(string.Empty); }
                    }
                    medicalvendor.MVUser.OtherPictures = otherpicture;

                    medicalvendor.Contract = new EContract();
                    medicalvendor.Contract.Name = Convert.ToString(row["ContractName"]);
                    returnMedicalVendor.Add(medicalvendor);
                }
                catch (Exception)
                {
                }
            }
            return returnMedicalVendor;
        }
        /// <summary>
        /// Update the medical vendor information.
        /// </summary>
        public Int64 SaveMedicalVendor(EMedicalVendor MedicalVendor, int mode, string Shell)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[40];

            arParms[0] = new SqlParameter("@Bphone", SqlDbType.VarChar, 500);
            arParms[0].Value = MedicalVendor.BusinessPhone;
            arParms[1] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
            arParms[1].Value = MedicalVendor.MedicalVendorID;
            arParms[2] = new SqlParameter("@Bfax", SqlDbType.VarChar, 500);
            arParms[2].Value = MedicalVendor.BusinessFax;
            arParms[3] = new SqlParameter("@Businessname", SqlDbType.VarChar, 500);
            arParms[3].Value = MedicalVendor.BusinessName;

            arParms[4] = new SqlParameter("@address", SqlDbType.VarChar, 500);
            arParms[4].Value = MedicalVendor.MVUser.User.HomeAddress.Address1;
            arParms[5] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[5].Value = MedicalVendor.MVUser.User.HomeAddress.Address2;
            arParms[6] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[6].Value = MedicalVendor.MVUser.User.HomeAddress.CityID;
            arParms[7] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[7].Value = MedicalVendor.MVUser.User.HomeAddress.StateID;
            arParms[8] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[8].Value = MedicalVendor.MVUser.User.HomeAddress.CountryID;
            arParms[9] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[9].Value = MedicalVendor.MVUser.User.HomeAddress.ZipID;

            arParms[10] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[10].Value = MedicalVendor.MVUser.User.FirstName;
            arParms[11] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[11].Value = MedicalVendor.MVUser.User.MiddleName;
            arParms[12] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[12].Value = MedicalVendor.MVUser.User.LastName;
            arParms[13] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[13].Value = MedicalVendor.MVUser.User.PhoneHome;
            arParms[14] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[14].Value = MedicalVendor.MVUser.User.PhoneOffice;
            arParms[15] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[15].Value = MedicalVendor.MVUser.User.PhoneCell;
            arParms[16] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[16].Value = MedicalVendor.MVUser.User.EMail1;
            arParms[17] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[17].Value = MedicalVendor.MVUser.User.EMail2;



            arParms[18] = new SqlParameter("@Baddress", SqlDbType.VarChar, 500);
            arParms[18].Value = MedicalVendor.BusinessAddress.Address1;
            arParms[19] = new SqlParameter("@Baddress2", SqlDbType.VarChar, 500);
            arParms[19].Value = MedicalVendor.BusinessAddress.Address2;
            arParms[20] = new SqlParameter("@Bcityid", SqlDbType.BigInt);
            arParms[20].Value = MedicalVendor.BusinessAddress.CityID;
            arParms[21] = new SqlParameter("@Bstateid", SqlDbType.BigInt);
            arParms[21].Value = MedicalVendor.BusinessAddress.StateID;
            arParms[22] = new SqlParameter("@Bcountryid", SqlDbType.BigInt);
            arParms[22].Value = MedicalVendor.BusinessAddress.CountryID;
            arParms[23] = new SqlParameter("@Bzipid", SqlDbType.BigInt);
            arParms[23].Value = MedicalVendor.BusinessAddress.ZipID;
            arParms[24] = new SqlParameter("@userid1", SqlDbType.VarChar, 500);
            arParms[24].Value = MedicalVendor.MVUser.User.UserID;
            arParms[25] = new SqlParameter("@mypicture", SqlDbType.VarChar, 2000);
            arParms[25].Value = MedicalVendor.MVUser.MyPicture;



            arParms[26] = new SqlParameter("@bankname", SqlDbType.VarChar, 50);
            arParms[26].Value = MedicalVendor.BankName;
            arParms[27] = new SqlParameter("@paymentmode", SqlDbType.Int);
            arParms[27].Value = MedicalVendor.PaymentMode;
            arParms[28] = new SqlParameter("@accountholdername", SqlDbType.VarChar, 50);
            arParms[28].Value = MedicalVendor.AccountHolder;
            arParms[29] = new SqlParameter("@accounttype", SqlDbType.VarChar, 50);
            arParms[29].Value = MedicalVendor.AccountType;
            arParms[30] = new SqlParameter("@routingNumber", SqlDbType.VarChar, 500);
            arParms[30].Value = MedicalVendor.RountingNumber;
            arParms[31] = new SqlParameter("@accountnumber", SqlDbType.VarChar, 50);
            arParms[31].Value = MedicalVendor.AccountNumber;
            arParms[32] = new SqlParameter("@memo", SqlDbType.VarChar, 500);
            arParms[32].Value = MedicalVendor.Memo;
            arParms[33] = new SqlParameter("@specialinstructions", SqlDbType.VarChar, 500);
            arParms[33].Value = MedicalVendor.SpecialInstruction;
            arParms[34] = new SqlParameter("@interval", SqlDbType.Int);
            arParms[34].Value = MedicalVendor.Interval;

            arParms[35] = new SqlParameter("@shell", SqlDbType.VarChar, 500);
            arParms[35].Value = Shell;
            arParms[36] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[36].Direction = ParameterDirection.Output;

            arParms[37] = new SqlParameter("@Description", SqlDbType.VarChar, 1000);
            arParms[37].Value = MedicalVendor.Description;



            arParms[38] = new SqlParameter("@dob", SqlDbType.VarChar, 2000);
            arParms[38].Value = MedicalVendor.MVUser.User.DOB;
            arParms[39] = new SqlParameter("@ssn", SqlDbType.VarChar, 2000);
            arParms[39].Value = MedicalVendor.MVUser.User.SSN;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemedicalvendor", arParms);
            returnvalue = (Int64)arParms[36].Value;
            SaveMVUserImages(MedicalVendor.MVUser, 0, Shell);
            return returnvalue;
        }

        public List<EMedicalVendor> GetMedicalVendor1(String filterString, Int64 ShellID, string strRoleType, int inputMode)
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
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendorprofile", arParms);
            List<EMedicalVendor> returnMedicalVendor = new List<EMedicalVendor>();
            returnMedicalVendor = ParseMedicalVendorDataSet(tempdataset);
            return returnMedicalVendor;
        }

        public Int64 SaveMVUserImages(EMVUser objMVUser, int Mode, string Shell)
        {

            
            SqlParameter[] arParms = new SqlParameter[19];
            arParms[0] = new SqlParameter("@userid1", SqlDbType.BigInt);
            arParms[0].Value = objMVUser.User.UserID;

            arParms[1] = new SqlParameter("@mypicture", SqlDbType.VarChar, 2000);
            if (objMVUser.MyPicture.Trim().Length < 1)
                arParms[1].Value = DBNull.Value;
            else
                arParms[1].Value = objMVUser.MyPicture;

            arParms[2] = new SqlParameter("@teampicture", SqlDbType.VarChar, 2000);
            if (objMVUser.TeamPicture.Trim().Length < 1)
                arParms[2].Value = DBNull.Value;
            else
                arParms[2].Value = objMVUser.TeamPicture;

            arParms[3] = new SqlParameter("@picture1", SqlDbType.VarChar, 2000);
            arParms[3].Value = objMVUser.OtherPictures[0];
            arParms[4] = new SqlParameter("@picture2", SqlDbType.VarChar, 2000);
            arParms[4].Value = objMVUser.OtherPictures[1];
            arParms[5] = new SqlParameter("@picture3", SqlDbType.VarChar, 2000);
            arParms[5].Value = objMVUser.OtherPictures[2];
            arParms[6] = new SqlParameter("@picture4", SqlDbType.VarChar, 2000);
            arParms[6].Value = objMVUser.OtherPictures[3];
            arParms[7] = new SqlParameter("@picture5", SqlDbType.VarChar, 2000);
            arParms[7].Value = objMVUser.OtherPictures[4];
            arParms[8] = new SqlParameter("@picture6", SqlDbType.VarChar, 2000);
            arParms[8].Value = objMVUser.OtherPictures[5];
            arParms[9] = new SqlParameter("@picture7", SqlDbType.VarChar, 2000);
            arParms[9].Value = objMVUser.OtherPictures[6];
            arParms[10] = new SqlParameter("@picture8", SqlDbType.VarChar, 2000);
            arParms[10].Value = objMVUser.OtherPictures[7];
            arParms[11] = new SqlParameter("@picture9", SqlDbType.VarChar, 2000);
            arParms[11].Value = objMVUser.OtherPictures[8];
            arParms[12] = new SqlParameter("@picture10", SqlDbType.VarChar, 2000);
            arParms[12].Value = objMVUser.OtherPictures[9];
            arParms[13] = new SqlParameter("@picture11", SqlDbType.VarChar, 2000);
            arParms[13].Value = objMVUser.OtherPictures[10];
            arParms[14] = new SqlParameter("@picture12", SqlDbType.VarChar, 2000);
            arParms[14].Value = objMVUser.OtherPictures[11];

            arParms[16] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[16].Value = Shell;
            arParms[17] = new SqlParameter("@userroletype", SqlDbType.VarChar, 500);
            arParms[17].Value = ERoleType.MedicalVendorAdmin;
            arParms[18] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[18].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveuserimage", arParms);
            return (Int64)arParms[18].Value;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvmvuserid"></param>
        /// <param name="bolAllowAuthorizations"></param>
        /// <param name="bolAllowEvaluations"></param>
        public void GetMVUserFunctionalities(Int64 mvmvuserid, out bool bolAllowAuthorizations, out bool bolAllowEvaluations)
        {
            bolAllowAuthorizations = false;
            bolAllowEvaluations = false;

            SqlParameter[] arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@mvmvuserid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@allowauthorizations", SqlDbType.Bit);
            arparams[2] = new SqlParameter("@allowevaluation", SqlDbType.Bit);

            arparams[0].Value = mvmvuserid;
            arparams[1].Direction = ParameterDirection.Output;
            arparams[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteScalar(connectionstring, CommandType.StoredProcedure, "usp_getPhysicianfunctionalities", arparams);

            if (arparams[1].Value != DBNull.Value) bolAllowAuthorizations = Convert.ToBoolean(arparams[1].Value);
            if (arparams[2].Value != DBNull.Value) bolAllowEvaluations = Convert.ToBoolean(arparams[2].Value);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objmvpaymentinfo"></param>
        /// <param name="paymenttype"></param>
        /// <param name="roleshellid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public Int64 SaveMVPaymentDetails(EMVPaymentInfo objmvpaymentinfo, string paymenttype, Int64 roleshellid, int roleid)
        {
            SqlParameter[] arparams = new SqlParameter[11];
            arparams[0] = new SqlParameter("@paymentamount", SqlDbType.Decimal);
            arparams[1] = new SqlParameter("@startpaymentinfoid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@endpaymentinfoid", SqlDbType.BigInt);
            arparams[3] = new SqlParameter("@invoicereference", SqlDbType.VarChar, 200);
            arparams[4] = new SqlParameter("@notes", SqlDbType.VarChar, 2000);
            arparams[5] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
            arparams[6] = new SqlParameter("@paymenttype", SqlDbType.VarChar, 200);
            arparams[7] = new SqlParameter("@roleshellid", SqlDbType.BigInt);
            arparams[8] = new SqlParameter("@roleid", SqlDbType.Int);
            arparams[9] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arparams[10] = new SqlParameter("@paymentid", SqlDbType.BigInt);

            arparams[9].Direction = ParameterDirection.Output;
            arparams[10].Direction = ParameterDirection.Output;

            arparams[0].Value = objmvpaymentinfo.PayingAmount;
            arparams[1].Value = objmvpaymentinfo.StartPaymentInfoID;
            arparams[2].Value = objmvpaymentinfo.EndPaymentInfoID;
            arparams[3].Value = objmvpaymentinfo.InvoiceReference;
            arparams[4].Value = objmvpaymentinfo.Notes;
            arparams[5].Value = objmvpaymentinfo.MedicalVendor.MedicalVendorID;
            arparams[6].Value = paymenttype;
            arparams[7].Value = roleshellid;
            arparams[8].Value = roleid;


            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveMVpaymentdetails", arparams);

            Int64 returnvalue = 0;
            if (arparams[9].Value == null) return -1;
            if (arparams[9].Value == DBNull.Value) return -1;

            Falcon.DataAccess.Master.MasterDAL objdal = new Falcon.DataAccess.Master.MasterDAL();
            EChequePaymentDetail objcheckpaymentdetails = new EChequePaymentDetail();
            objcheckpaymentdetails.ChequeNumber = objmvpaymentinfo.CheckNumber;
            objcheckpaymentdetails.PaymentID = Convert.ToInt32(arparams[10].Value);
            objcheckpaymentdetails.DrorCr = true;
            objcheckpaymentdetails.Description = "Medical Vendor Payment";
            objdal.SaveChequePaymentDetails(objcheckpaymentdetails, "", "", "", 0, null);

            returnvalue = Convert.ToInt64(arparams[9].Value);


            return returnvalue;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionstartdate"></param>
        /// <param name="transactionenddate"></param>
        /// <param name="minpaymentdue"></param>
        /// <param name="maxpaymentdue"></param>
        /// <param name="medicalvendorid"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<EMVPaymentInfo> GetAllMedicalVendorPayments(string transactionstartdate, string transactionenddate, decimal minpaymentdue,
                                                    decimal maxpaymentdue, Int64 medicalvendorid, Int16 mode)
        {
            SqlParameter[] arparams = new SqlParameter[6];
            arparams[0] = new SqlParameter("@transactionstartdate", SqlDbType.VarChar, 200);
            arparams[1] = new SqlParameter("@transactionenddate", SqlDbType.VarChar, 200);
            arparams[2] = new SqlParameter("@minpaymentamount", SqlDbType.BigInt);
            arparams[3] = new SqlParameter("@maxpaymentamount", SqlDbType.BigInt);
            arparams[4] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
            arparams[5] = new SqlParameter("@mode", SqlDbType.TinyInt);

            arparams[0].Value = transactionstartdate;
            arparams[1].Value = transactionenddate;
            arparams[2].Value = minpaymentdue;
            arparams[3].Value = maxpaymentdue;
            arparams[4].Value = medicalvendorid;
            arparams[5].Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(connectionstring, "usp_getallMVpaymentDues", arparams);
            return ParseDataSetAllMVPaymentInfo(dstemp);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dsallmvpaymentinfo"></param>
        /// <returns></returns>
        private List<EMVPaymentInfo> ParseDataSetAllMVPaymentInfo(DataSet dsallmvpaymentinfo)
        {
            if (dsallmvpaymentinfo.Tables[1].Rows.Count < 1) return null;
            List<EMVPaymentInfo> lstallMVPaymentInfo = new List<EMVPaymentInfo>();

            foreach (DataRow dr in dsallmvpaymentinfo.Tables[1].Rows)
            {
                EMVPaymentInfo objmvpaymentinfo = new EMVPaymentInfo();

                dsallmvpaymentinfo.Tables[0].DefaultView.RowFilter = "MedicalVendorID = " + dr["MedicalVendorID"].ToString();
                if (dsallmvpaymentinfo.Tables[0].DefaultView.Count < 1)
                    continue;
                DataRowView drv = dsallmvpaymentinfo.Tables[0].DefaultView[0];

                objmvpaymentinfo.MedicalVendor = new EMedicalVendor();
                objmvpaymentinfo.MedicalVendor.MedicalVendorID = Convert.ToInt32(dr["MedicalVendorID"]);
                objmvpaymentinfo.MedicalVendor.BusinessName = drv["BusinessName"].ToString();
                objmvpaymentinfo.MedicalVendor.BusinessPhone = drv["BusinessPhone"].ToString();

                objmvpaymentinfo.StartPaymentInfoID = Convert.ToInt64(dr["StartMVPaymentInfoID"]);
                objmvpaymentinfo.EndPaymentInfoID = Convert.ToInt64(dr["EndMVPaymentInfoID"]);

                objmvpaymentinfo.TotalAmountDue = Convert.ToDecimal(dr["LastMVPaymentDue"]);
                objmvpaymentinfo.LastPaymentMade = Convert.ToDecimal(dr["LastPaymentMade"]);
                objmvpaymentinfo.LastPaymentDate = Convert.ToString(dr["LastPaymentDate"]);

                lstallMVPaymentInfo.Add(objmvpaymentinfo);

            }

            return lstallMVPaymentInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicalvendorid"></param>
        /// <param name="startpaymentinfoid"></param>
        /// <param name="endpaymentinfoid"></param>
        /// <returns></returns>
        public EMVPaymentInfo GetMedicalvendorPaymentbyMVId(int medicalvendorid, Int64 startpaymentinfoid, Int64 endpaymentinfoid)
        {
            SqlParameter[] arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@medicalvendorid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@startpaymentinfoid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@endpaymentinfoid", SqlDbType.BigInt);

            arparams[0].Value = medicalvendorid;
            arparams[1].Value = startpaymentinfoid;
            arparams[2].Value = endpaymentinfoid;

            DataSet dstemp = SqlHelper.ExecuteDataset(connectionstring, "usp_getMVPaymentInfoforPayment", arparams);

            DataTable dtmedicalvendor = dstemp.Tables[0];
            DataTable dtmvmvuser = dstemp.Tables[1];
            DataTable dtmvpaymentinfo = dstemp.Tables[2];

            if (dtmedicalvendor.Rows.Count < 1) return null;

            EMVPaymentInfo objpaymentinfo = new EMVPaymentInfo();

            objpaymentinfo.MedicalVendor = new EMedicalVendor();
            objpaymentinfo.MedicalVendor.MedicalVendorID = Convert.ToInt32(dtmedicalvendor.Rows[0]["MedicalVendorID"]);
            objpaymentinfo.MedicalVendor.BusinessName = dtmedicalvendor.Rows[0]["BusinessName"].ToString();
            objpaymentinfo.MedicalVendor.BusinessPhone = dtmedicalvendor.Rows[0]["BusinessPhone"].ToString();

            objpaymentinfo.MedicalVendor.BusinessAddress = new EAddress();

            objpaymentinfo.MedicalVendor.BusinessAddress.Address1 = dtmedicalvendor.Rows[0]["Address1"].ToString();
            objpaymentinfo.MedicalVendor.BusinessAddress.Address2 = dtmedicalvendor.Rows[0]["Address2"].ToString();
            objpaymentinfo.MedicalVendor.BusinessAddress.City = dtmedicalvendor.Rows[0]["City"].ToString();
            objpaymentinfo.MedicalVendor.BusinessAddress.State = dtmedicalvendor.Rows[0]["State"].ToString();
            objpaymentinfo.MedicalVendor.BusinessAddress.Country = dtmedicalvendor.Rows[0]["Country"].ToString();

            if (dtmvmvuser.Rows.Count > 0)
            {
                foreach (DataRow dr in dtmvmvuser.Rows)
                {
                    objpaymentinfo.PhysicianString += dr["FirstName"].ToString() + (dr["MiddleName"].ToString().Length > 0 ? " " + dr["MiddleName"].ToString() + " " : " ") + dr["LastName"].ToString() + ", ";
                }
                objpaymentinfo.PhysicianString = objpaymentinfo.PhysicianString.Remove(objpaymentinfo.PhysicianString.LastIndexOf(", "));
            }

            objpaymentinfo.PayingAmount = Convert.ToDecimal(dtmvpaymentinfo.Rows[0]["MVPaymentDue"]);
            objpaymentinfo.TotalAmountDue = Convert.ToDecimal(dtmvpaymentinfo.Rows[0]["TotalPaymentDue"]);
            objpaymentinfo.EvaluationsSinceLastPayment = Convert.ToInt32(dtmvpaymentinfo.Rows[0]["EvaluationsDone"]);
            objpaymentinfo.LastPaymentMade = Convert.ToDecimal(dtmvpaymentinfo.Rows[0]["LastPaymentMade"]);
            objpaymentinfo.LastPaymentDate = Convert.ToString(dtmvpaymentinfo.Rows[0]["LastPaymentDate"]);


            return objpaymentinfo;
        }
        

        /// <summary>
        /// Saves a customers Authorization details
        /// </summary>
        /// <param name="streventcustomerid"></param>
        /// <param name="initials"></param>
        /// <param name="ipaddress"></param>
        /// <param name="hostname"></param>
        /// <param name="browseragent"></param>
        /// <param name="userid"></param>
        /// <param name="shellid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public Boolean SaveAuthorizeCustomerInfo(string streventcustomerid, string initials, string ipaddress, string hostname,
                                                    string browseragent, Int64 userid, Int64 shellid, int roleid)
        {
            SqlParameter[] arparams = new SqlParameter[9];

            arparams[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@roleid", SqlDbType.Int);
            arparams[3] = new SqlParameter("@initials", SqlDbType.VarChar, 100);
            arparams[4] = new SqlParameter("@ipaddress", SqlDbType.VarChar, 200);
            arparams[5] = new SqlParameter("@hostname", SqlDbType.VarChar, 200);
            arparams[6] = new SqlParameter("@browseragent", SqlDbType.VarChar, 200);
            arparams[7] = new SqlParameter("@eventcustomerids", SqlDbType.VarChar, 2000);
            arparams[8] = new SqlParameter("@issuccess", SqlDbType.Bit);

            arparams[0].Value = userid;
            arparams[1].Value = shellid;
            arparams[2].Value = roleid;
            arparams[3].Value = initials;
            arparams[4].Value = ipaddress;
            arparams[5].Value = hostname;
            arparams[6].Value = browseragent;
            arparams[7].Value = streventcustomerid;
            arparams[8].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveauthorizationdetails", arparams);

            if (arparams[8].Value == DBNull.Value)
                return false;

            return Convert.ToBoolean(arparams[8].Value);

        }

        #endregion

        #region "Medical Vendor Application"

        public List<EMedicalVendorApplication> GetMVApplication(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getmedicalvendorapplication", arParms);

            List<EMedicalVendorApplication> returnMVApplication = new List<EMedicalVendorApplication>();
            returnMVApplication = ParseMedicalVendorApplication(tempdataset);
            return returnMVApplication;
        }

        /// <summary>
        /// Private method to parse and fill Medical Vendor Entity list
        /// </summary>
        /// <param name="dsMVApp"></param>
        /// <returns></returns>
        private List<EMedicalVendorApplication> ParseMedicalVendorApplication(DataSet dsMVApp)
        {
            List<EMedicalVendorApplication> retMVApp = new List<EMedicalVendorApplication>();
            foreach (DataRow dr in dsMVApp.Tables[0].Rows)
            {
                EMedicalVendorApplication objMVApp = new EMedicalVendorApplication();
                objMVApp.Application = new EApplication();
                objMVApp.MedicalVendorApplicationID = Convert.ToInt32(dr["MedicalVendorApplicationID"]);
                objMVApp.Application.BusinessName = dr["BusinessName"].ToString();
                objMVApp.Application.FirstName = dr["FirstName"].ToString();
                objMVApp.Application.MiddleName = dr["MiddleName"].ToString();
                objMVApp.Application.LastName = dr["LastName"].ToString();
                objMVApp.Application.PhoneCell = dr["PhoneCell"].ToString();
                objMVApp.Application.PhoneHome = dr["PhoneHome"].ToString();
                objMVApp.Application.PhoneOffice = dr["PhoneOffice"].ToString();
                objMVApp.Application.Email1 = dr["Email1"].ToString();
                objMVApp.Application.Email2 = dr["Email2"].ToString();
                objMVApp.Resume = dr["Resume"].ToString();
                objMVApp.WFStage = new EWFStage();
                objMVApp.WFStage.WFStageID = Convert.ToInt32(dr["WorkFlowStageID"]);
                objMVApp.Application.BusinessAddress = new EAddress();
                objMVApp.Application.BusinessAddress.AddressID = Convert.ToInt32(dr["CorrespondenceAddressID"]);
                objMVApp.Application.ReferenceName1 = dr["Reference1Name"].ToString();
                objMVApp.Application.ReferenceEmail1 = dr["Reference1Email"].ToString();
                objMVApp.Application.ReferenceName2 = dr["Reference2Name"].ToString();
                objMVApp.Application.ReferenceEmail2 = dr["Reference2Email"].ToString();
                objMVApp.Application.ReferenceName3 = dr["Reference3Name"].ToString();
                objMVApp.Application.ReferenceEmail3 = dr["Reference3Email"].ToString();
                objMVApp.BusinessPhone = dr["BusinessPhone"].ToString();
                objMVApp.BusinessFax = dr["BusinessFax"].ToString();
                objMVApp.DateCreated = Convert.ToDateTime(dr["DateCreated"]);
                if (dr["DOB"] != DBNull.Value)
                {
                    objMVApp.Application.DOB = Convert.ToDateTime(dr["DOB"]).ToShortDateString();
                }
                objMVApp.Application.SSN = dr["SSN"].ToString();
                objMVApp.MedicalVendorType = new EMedicalVendorType();
                objMVApp.MedicalVendorType.MedicalVendorTypeID = Convert.ToInt32(dr["MedicalVendorTypeID"]);
                objMVApp.MedicalVendorType.Name = dr["VendorType"].ToString();
                objMVApp.MedicalVendorType.Description = dr["VendorTypeDescription"].ToString();
                if (dr["SpecializationID"] != DBNull.Value)
                {
                    objMVApp.MedicalSpecialization = new EMVUserSpecialization();
                    objMVApp.MedicalSpecialization.MVUserSpecilaizationID = Convert.ToInt32(dr["SpecializationID"]);
                    objMVApp.MedicalSpecialization.Name = dr["VendorSpecialization"].ToString();
                    objMVApp.MedicalSpecialization.Description = dr["VendorSpecializationDescription"].ToString();
                }

                DataRow drAdd = dsMVApp.Tables[1].Select("AddressID = '" + dr["BusinessAddressID"].ToString() + "'")[0];

                objMVApp.Application.BusinessAddress = new EAddress();
                objMVApp.Application.BusinessAddress.AddressID = Convert.ToInt32(drAdd["AddressID"]);
                objMVApp.Application.BusinessAddress.Address1 = drAdd["Address1"].ToString();
                objMVApp.Application.BusinessAddress.Address2 = drAdd["Address2"].ToString();
                objMVApp.Application.BusinessAddress.ZipID = Convert.ToInt32(drAdd["ZIPID"]);
                objMVApp.Application.BusinessAddress.PhoneNumber = drAdd["PhoneNumber"].ToString();
                objMVApp.Application.BusinessAddress.City = drAdd["CityName"].ToString();
                objMVApp.Application.BusinessAddress.State = drAdd["StateName"].ToString();
                objMVApp.Application.BusinessAddress.Country = drAdd["CountryName"].ToString();
                objMVApp.Application.BusinessAddress.CityID = Convert.ToInt32(drAdd["CityID"]);
                objMVApp.Application.BusinessAddress.StateID = Convert.ToInt32(drAdd["StateID"]);
                objMVApp.Application.BusinessAddress.CountryID = Convert.ToInt32(drAdd["CountryID"]);
                objMVApp.Application.BusinessAddress.Zip = drAdd["ZipCode"].ToString();

                DataRow drAddC = dsMVApp.Tables[2].Select("AddressID = '" + dr["CorrespondenceAddressID"].ToString() + "'")[0];

                objMVApp.Application.ContactAddress = new EAddress();
                objMVApp.Application.ContactAddress.AddressID = Convert.ToInt32(drAddC["AddressID"]);
                objMVApp.Application.ContactAddress.Address1 = drAddC["Address1"].ToString();
                objMVApp.Application.ContactAddress.Address2 = drAddC["Address2"].ToString();
                objMVApp.Application.ContactAddress.ZipID = Convert.ToInt32(drAddC["ZIPID"]);
                objMVApp.Application.ContactAddress.PhoneNumber = drAddC["PhoneNumber"].ToString();
                objMVApp.Application.ContactAddress.City = drAddC["CityName"].ToString();
                objMVApp.Application.ContactAddress.State = drAddC["StateName"].ToString();
                objMVApp.Application.ContactAddress.Country = drAddC["CountryName"].ToString();
                objMVApp.Application.ContactAddress.CityID = Convert.ToInt32(drAddC["CityID"]);
                objMVApp.Application.ContactAddress.StateID = Convert.ToInt32(drAddC["StateID"]);
                objMVApp.Application.ContactAddress.CountryID = Convert.ToInt32(drAddC["CountryID"]);
                objMVApp.Application.ContactAddress.Zip = drAddC["ZipCode"].ToString();

                retMVApp.Add(objMVApp);
            }

            return retMVApp;
        }

        /// <summary>
        /// To Update Medical Vendor Application's work flow stage
        /// later it will be dealt using WFF
        /// </summary>
        /// <param name="medicalVendorApplicationId">string</param>
        /// <param name="wfStage">string</param>
        /// <param name="userID">string</param>
        /// <param name="shell">string</param>
        /// <param name="role">sring</param>
        /// <returns></returns>
        public Int64 SaveMVApplication(Int32 medicalVendorApplicationId, string wfStage)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@medicalVendorApplicationId", SqlDbType.BigInt, 3000);
            arParms[0].Value = medicalVendorApplicationId;

            arParms[1] = new SqlParameter("@wfstage", SqlDbType.NVarChar, 20);
            arParms[1].Value = wfStage;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemedicalvendorapplication", arParms);
            returnvalue = (Int64)arParms[2].Value;

            return returnvalue;
        }

        public Int64 AcceptMedicalVendorApplication(Int32 medicalVendorApplicationId, string userID, string shell, string role)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@mvappid", SqlDbType.BigInt, 3000);
            arParms[0].Value = medicalVendorApplicationId;

            arParms[1] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[1].Value = userID;

            arParms[2] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[2].Value = shell;

            arParms[3] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[3].Value = role;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveapprovemvapplication", arParms);
            returnvalue = (Int64)arParms[4].Value;

            return returnvalue;
        }

        public Int64 SaveApplicationNotes(List<ENote> note, string UserID )
        {
            Int64 returnvalue = new Int64();
            for (int icount = 0; icount < note.Count; icount++)
            {
                SqlParameter[] arParms = new SqlParameter[6];
                arParms[0] = new SqlParameter("@notes", SqlDbType.VarChar, 5000);
                arParms[0].Value = note[icount].Notes;
                arParms[1] = new SqlParameter("@notesequence", SqlDbType.BigInt);
                arParms[1].Value = note[icount].NotesSequence;
                arParms[2] = new SqlParameter("@applicationid", SqlDbType.BigInt);
                arParms[2].Value = note[icount].ApplicationID;
                arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[3].Value = 1;
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
            arParms[1].Value = 1;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getapplicationnote", arParms);

            List<ENote> returnMVApplicationNote = new List<ENote>();
            returnMVApplicationNote = ParseMVApplicationNote(tempdataset);
            return returnMVApplicationNote;
        }
        private List<ENote> ParseMVApplicationNote(DataSet MVApplicationNoteDataSet)
        {
            List<ENote> returnNote = new List<ENote>();
            foreach (DataRow dr in MVApplicationNoteDataSet.Tables[0].Rows)
            {
                ENote note = new ENote();
                note.FranchiseeNotesID = Convert.ToInt32(dr["MedicalVendorNotesID"]);
                note.ApplicationID = Convert.ToInt32(dr["MedicalVendorAppID"]);
                note.Notes = dr["Notes"].ToString();
                note.NotesSequence = Convert.ToInt32(dr["NotesSequence"]);
                returnNote.Add(note);
            }

            return returnNote;
        }

        public Int64 UpdateEditApplication(EMedicalVendorApplication mvapp)
        {
            SqlParameter[] arParms = new SqlParameter[39];
            arParms[0] = new SqlParameter("@mvappid", SqlDbType.BigInt);
            arParms[0].Value = mvapp.MedicalVendorApplicationID;
            arParms[1] = new SqlParameter("@businessname", SqlDbType.VarChar, 500);
            arParms[1].Value = mvapp.Application.BusinessName;
            arParms[2] = new SqlParameter("@businessphone", SqlDbType.VarChar, 500);
            arParms[2].Value = mvapp.BusinessPhone;
            arParms[3] = new SqlParameter("@businessfax", SqlDbType.VarChar, 500);
            arParms[3].Value = mvapp.BusinessFax;
            arParms[4] = new SqlParameter("@medicalvendortypeid", SqlDbType.BigInt);
            arParms[4].Value = mvapp.MedicalVendorType.MedicalVendorTypeID;
            arParms[5] = new SqlParameter("@buaddress1", SqlDbType.VarChar, 500);
            arParms[5].Value = mvapp.Application.BusinessAddress.Address1;
            arParms[6] = new SqlParameter("@buaddress2", SqlDbType.VarChar, 500);
            arParms[6].Value = mvapp.Application.BusinessAddress.Address2;
            arParms[7] = new SqlParameter("@bucityid", SqlDbType.BigInt);
            arParms[7].Value = mvapp.Application.BusinessAddress.CityID;
            arParms[8] = new SqlParameter("@bustateid", SqlDbType.BigInt);
            arParms[8].Value = mvapp.Application.BusinessAddress.StateID;
            arParms[9] = new SqlParameter("@bucountryid", SqlDbType.BigInt);
            arParms[9].Value = mvapp.Application.BusinessAddress.CountryID;
            arParms[10] = new SqlParameter("@buzipid", SqlDbType.BigInt);
            arParms[10].Value = mvapp.Application.BusinessAddress.ZipID;
            arParms[11] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[11].Value = mvapp.Application.FirstName;
            arParms[12] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[12].Value = mvapp.Application.MiddleName;
            arParms[13] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[13].Value = mvapp.Application.LastName;
            arParms[14] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[14].Value = mvapp.Application.PhoneHome;
            arParms[15] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[15].Value = mvapp.Application.PhoneOffice;
            arParms[16] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[16].Value = mvapp.Application.PhoneCell;
            arParms[17] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[17].Value = mvapp.Application.Email1;
            arParms[18] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[18].Value = mvapp.Application.Email2;
            arParms[19] = new SqlParameter("@dob", SqlDbType.VarChar, 500);
            arParms[19].Value = mvapp.Application.DOB;
            arParms[20] = new SqlParameter("@ssn", SqlDbType.VarChar, 500);
            arParms[20].Value = mvapp.Application.SSN;
            arParms[21] = new SqlParameter("@caddress1", SqlDbType.VarChar, 500);
            arParms[21].Value = mvapp.Application.ContactAddress.Address1;
            arParms[22] = new SqlParameter("@caddress2", SqlDbType.VarChar, 500);
            arParms[22].Value = mvapp.Application.ContactAddress.Address2;
            arParms[23] = new SqlParameter("@ccityid", SqlDbType.BigInt);
            arParms[23].Value = mvapp.Application.ContactAddress.CityID;
            arParms[24] = new SqlParameter("@cstateid", SqlDbType.BigInt);
            arParms[24].Value = mvapp.Application.ContactAddress.StateID;
            arParms[25] = new SqlParameter("@ccountryid", SqlDbType.BigInt);
            arParms[25].Value = mvapp.Application.ContactAddress.CountryID;
            arParms[26] = new SqlParameter("@czipid", SqlDbType.BigInt);
            arParms[26].Value = mvapp.Application.ContactAddress.ZipID;
            arParms[27] = new SqlParameter("@refname1", SqlDbType.VarChar, 500);
            arParms[27].Value = mvapp.Application.ReferenceName1;
            arParms[28] = new SqlParameter("@refemail1", SqlDbType.VarChar, 500);
            arParms[28].Value = mvapp.Application.ReferenceEmail1;
            arParms[29] = new SqlParameter("@refname2", SqlDbType.VarChar, 500);
            arParms[29].Value = mvapp.Application.ReferenceName2;
            arParms[30] = new SqlParameter("@refemail2", SqlDbType.VarChar, 500);
            arParms[30].Value = mvapp.Application.ReferenceEmail2;
            arParms[31] = new SqlParameter("@refname3", SqlDbType.VarChar, 500);
            arParms[31].Value = mvapp.Application.ReferenceName3;
            arParms[32] = new SqlParameter("@refemail3", SqlDbType.VarChar, 500);
            arParms[32].Value = mvapp.Application.ReferenceEmail3;
            arParms[33] = new SqlParameter("@specilizationid", SqlDbType.BigInt);
            if (mvapp.MedicalSpecialization.MVUserSpecilaizationID.ToString() == "0")
                arParms[33].Value = DBNull.Value;
            else
                arParms[33].Value = mvapp.MedicalSpecialization.MVUserSpecilaizationID;
            arParms[34] = new SqlParameter("@resume", SqlDbType.VarChar, 500);
            arParms[34].Value = mvapp.Resume;
            arParms[35] = new SqlParameter("@contactaddressid", SqlDbType.BigInt);
            arParms[35].Value = mvapp.Application.ContactAddress.AddressID;
            arParms[36] = new SqlParameter("@businessaddressid", SqlDbType.BigInt);
            arParms[36].Value = mvapp.Application.BusinessAddress.AddressID;
            arParms[37] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[37].Value = 0;
            arParms[38] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[38].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveeditmvapplication", arParms);

            return (Int64)arParms[38].Value;


        }

        #endregion

        #region "Medical Vendor License"

        public Int64 SaveMVUserLicense(Int64 iLicenseID, Int64 iMVMVUserID, Int64 iStateID, string strLicenseNo, int iRowstate, int iMode, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();

            SqlParameter[] arParms = new SqlParameter[7];
            arParms[0] = new SqlParameter("@licenseID", SqlDbType.BigInt);
            arParms[0].Value = iLicenseID;
            arParms[1] = new SqlParameter("@mvMVUserID", SqlDbType.BigInt);
            arParms[1].Value = iMVMVUserID;

            arParms[2] = new SqlParameter("@StateID", SqlDbType.BigInt);
            arParms[2].Value = iStateID;
            arParms[3] = new SqlParameter("@licenseNo", SqlDbType.VarChar, 50);
            arParms[3].Value = strLicenseNo;
            //arParms[4].Direction = ParameterDirection.Output;
            arParms[4] = new SqlParameter("@rowState", SqlDbType.Int);
            arParms[4].Value = iRowstate;
            arParms[5] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[5].Value = iMode;
            arParms[6] = new SqlParameter("@returnValue", SqlDbType.BigInt);
            arParms[6].Direction = ParameterDirection.Output;

            //SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savemvcustomer", arParms);
            //returnvalue = (Int64)arParms[3].Value;
            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveMVLicense", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_saveMVLicense", arParms);
            }
            returnvalue = (Int64)arParms[6].Value;
            return returnvalue;
        }


        /// <summary>
        /// Get MVUser license details
        /// </summary>
        /// <param name="iMVUserID"></param>
        /// <param name="iMVRoleID"></param>
        /// <returns></returns>
        public List<EMVMVLicense> GetMVUserLicenseDetail(Int64 iMVMVUserID)
        {
            SqlParameter[] arparams = new SqlParameter[1];
            arparams[0] = new SqlParameter("@mvMVUserID", SqlDbType.BigInt);
            arparams[0].Value = iMVMVUserID;

            DataSet dstemp = SqlHelper.ExecuteDataset(connectionstring, "usp_getMVUserLicenseDetail", arparams);
            return ParseMVUserLicense(dstemp);

        }


        private List<EMVMVLicense> ParseMVUserLicense(DataSet dsLicense)
        {
            if (dsLicense.Tables[0].Rows.Count < 1) return null;
            List<EMVMVLicense> lstMVLicense = new List<EMVMVLicense>();

            foreach (DataRow dr in dsLicense.Tables[0].Rows)
            {
                EMVMVLicense objMVLicense = new EMVMVLicense();

                objMVLicense.LicenseID = Convert.ToInt32(dr["LicenseID"]);
                objMVLicense.MVMVUserID = Convert.ToInt32(dr["MVMVUserID"]);
                objMVLicense.StateID = Convert.ToInt32(dr["StateID"]);
                objMVLicense.LicenseNo = Convert.ToString(dr["LicenseNo"]);
                objMVLicense.RowState = Convert.ToInt32(dr["RowState"]);

                lstMVLicense.Add(objMVLicense);
            }

            return lstMVLicense;
        }

        public Int64 DeleteMedicalVendorUserTestPayRate(Int64 iMVMVUserID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();

            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@mvmvuserid", SqlDbType.BigInt);
            arParms[0].Value = iMVMVUserID;
            arParms[1] = new SqlParameter("@returnValue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_DeleteMedicalVendorUserTestPayRate", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_DeleteMedicalVendorUserTestPayRate", arParms);
            }
            returnvalue = (Int64)arParms[1].Value;
            return returnvalue;
        }

        public Int64 DeleteMVMVCustomer(Int64 iMVMVUserID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();

            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@mvmvuserid", SqlDbType.BigInt);
            arParms[0].Value = iMVMVUserID;
            arParms[1] = new SqlParameter("@returnValue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_DeleteMVMVCustomer", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_DeleteMVMVCustomer", arParms);
            }
            returnvalue = (Int64)arParms[1].Value;
            return returnvalue;
        }

        public Int64 DeleteMVMVPackage(Int64 iMVMVUserID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();

            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@mvmvuserid", SqlDbType.BigInt);
            arParms[0].Value = iMVMVUserID;
            arParms[1] = new SqlParameter("@returnValue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_DeleteMVMVPackage", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_DeleteMVMVPackage", arParms);
            }
            returnvalue = (Int64)arParms[1].Value;
            return returnvalue;
        }

        public Int64 DeleteMVMVTest(Int64 iMVMVUserID, SqlTransaction transaction)
        {
            Int64 returnvalue = new Int64();

            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@mvmvuserid", SqlDbType.BigInt);
            arParms[0].Value = iMVMVUserID;
            arParms[1] = new SqlParameter("@returnValue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_DeleteMVMVTest", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_DeleteMVMVTest", arParms);
            }
            returnvalue = (Int64)arParms[1].Value;
            return returnvalue;
        }
        #endregion

        #region "Hospital Facility"

        public Int64 SaveHospitalFacilty(EHospitalFacility objHospitalFacility, int mode, Int64 UserID)
        {
            Int64 returnvalue = new Int64();

            SqlParameter[] arParms = new SqlParameter[17];

            arParms[0] = new SqlParameter("@facilityid", SqlDbType.BigInt);
            arParms[0].Value = objHospitalFacility.HospitalFacilityID;

            arParms[1] = new SqlParameter("@MedicalVendorId", SqlDbType.BigInt);
            arParms[1].Value = objHospitalFacility.HospitalPartnerId;

            arParms[2] = new SqlParameter("@FacilityName", SqlDbType.VarChar, 255);
            arParms[2].Value = CheckNull(objHospitalFacility.FacilityName);

            arParms[3] = new SqlParameter("@AddressID", SqlDbType.BigInt);
            arParms[3].Value = objHospitalFacility.Address.AddressID;

            arParms[4] = new SqlParameter("@Address1", SqlDbType.VarChar, 500);
            arParms[4].Value = CheckNull(objHospitalFacility.Address.Address1);

            arParms[5] = new SqlParameter("@Address2", SqlDbType.VarChar, 500);
            arParms[5].Value = CheckNull(objHospitalFacility.Address.Address2);

            arParms[6] = new SqlParameter("@CityID", SqlDbType.BigInt);
            arParms[6].Value = objHospitalFacility.Address.CityID;

            arParms[7] = new SqlParameter("@StateID", SqlDbType.BigInt);
            arParms[7].Value = objHospitalFacility.Address.StateID;

            arParms[8] = new SqlParameter("@CountryID", SqlDbType.BigInt);
            arParms[8].Value = objHospitalFacility.Address.CountryID;

            arParms[9] = new SqlParameter("@ZipID ", SqlDbType.BigInt);
            arParms[9].Value = objHospitalFacility.Address.ZipID;

            arParms[10] = new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 50);
            arParms[10].Value = CheckNull(objHospitalFacility.Address.PhoneNumber);

            arParms[11] = new SqlParameter("@Fax", SqlDbType.VarChar, 100);
            arParms[11].Value = CheckNull(objHospitalFacility.Address.Fax);

            arParms[12] = new SqlParameter("@Email", SqlDbType.VarChar, 255);
            arParms[12].Value = CheckNull(objHospitalFacility.Email);

            arParms[13] = new SqlParameter("@PhoneCell", SqlDbType.VarChar, 100);
            arParms[13].Value = CheckNull(objHospitalFacility.PhoneCell);

            arParms[14] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[14].Value = mode;

            arParms[15] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[15].Value = UserID;

            arParms[16] = new SqlParameter("@returnValue", SqlDbType.BigInt);
            arParms[16].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveHospitalFacility", arParms);
            returnvalue = (Int64)arParms[16].Value;
            return returnvalue;
        }

        public Int64 SaveHospitalPartner(EHospitalPartner objHospitalPartner, int mode, int userid, SqlTransaction transaction, List<long> packageIds)
        {
            SqlParameter[] arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@MedicalVendorID", SqlDbType.BigInt);
            arParms[0].Value = objHospitalPartner.MedicalVendorID;

            arParms[1] = new SqlParameter("@AssociatedPhoneNumber", SqlDbType.VarChar, 50);
            arParms[1].Value = objHospitalPartner.AssociatedPhoneNumber;

            arParms[2] = new SqlParameter("@AdvocateID", SqlDbType.BigInt);
            arParms[2].Value = objHospitalPartner.AdvocateID;

            arParms[3] = new SqlParameter("@IsGlobal", SqlDbType.Bit);
            arParms[3].Value = objHospitalPartner.IsGlobal;


            arParms[4] = new SqlParameter("@TerritoryID", SqlDbType.BigInt);
            if (objHospitalPartner.TerritoryID > 0)
                arParms[4].Value = objHospitalPartner.TerritoryID;
            else
                arParms[4].Value = DBNull.Value;


            arParms[5] = new SqlParameter("@returnResult", SqlDbType.BigInt);
            arParms[5].Direction = ParameterDirection.Output;

            if (transaction == null)
            {
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveHospitalPartner", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_saveHospitalPartner", arParms);
            }

            
            Int64 returnResult = Convert.ToInt64(arParms[5].Value);

            var param = new SqlParameter[3];

            param[0] = new SqlParameter("@HospitalPartnerId", SqlDbType.BigInt);
            param[1] = new SqlParameter("@PackageId", SqlDbType.BigInt);
            param[2] = new SqlParameter("@DeleteAll", SqlDbType.Bit);

            var deleteall = true;
            if (packageIds != null && packageIds.Count > 0)
            {
                foreach (var packageId in packageIds)
                {
                    param[0].Value = objHospitalPartner.MedicalVendorID;
                    param[1].Value = packageId;
                    param[2].Value = deleteall;

                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure,
                                              "usp_saveHospitalPartnerPackage", param);

                    deleteall = false;
                }
            }
            else
            {
                param[0].Value = objHospitalPartner.MedicalVendorID;
                param[1].Value = 0;
                param[2].Value = deleteall;

                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure,
                                          "usp_saveHospitalPartnerPackage", param);
            }
            return returnResult;
        }

        public Int64 SaveHospitalFaciltyCompaign(Int64 iFacilityId, string strCampaignID, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[4];

            arParms[0] = new SqlParameter("@facilityid", SqlDbType.BigInt);
            arParms[0].Value = iFacilityId;

            arParms[1] = new SqlParameter("@campaignid", SqlDbType.VarChar, 255);
            arParms[1].Value = strCampaignID;

            arParms[2] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[2].Value = mode;

            arParms[3] = new SqlParameter("@returnValue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveHospitalFacilityCampaign", arParms);
            return (Int64)arParms[3].Value;
        }

        public List<EMedicalVendor> GetMedicalVendor()
        {
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getHospitalMedicalVendor",null);

            if (tempdataset.Tables[0].Rows.Count < 1) return null;

            List<EMedicalVendor> returnMedicalVendor = new List<EMedicalVendor>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EMedicalVendor objMedicalVendor = new EMedicalVendor();

                objMedicalVendor.MedicalVendorID = Convert.ToInt32(dr["MedicalVendorID"]);
                objMedicalVendor.BusinessName = Convert.ToString(dr["BusinessName"]);

                returnMedicalVendor.Add(objMedicalVendor);
            }
            return returnMedicalVendor;

        }

        public List<EHospitalFacility> GetHospitalFacility(string searchText, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[0].Value = mode;

            arParms[1] = new SqlParameter("@filterstring", SqlDbType.VarChar, 100);
            arParms[1].Value = searchText;

            DataSet ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getHospitalPartnerFacility", arParms);
            List<EHospitalFacility> objLHF = new List<EHospitalFacility>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtHF = ds.Tables[0];
                for (int count = 0; count < dtHF.Rows.Count; count++)
                {
                    EHospitalFacility objHF = new EHospitalFacility();
                    objHF.HospitalFacilityID = Convert.ToInt32(dtHF.Rows[count]["FacilityID"]);
                    objHF.FacilityName = Convert.ToString(dtHF.Rows[count]["FacilityName"]);
                    objHF.HospitalPartnerId = Convert.ToInt32(dtHF.Rows[count]["HospitalPartnerID"]);
                    objHF.MedicalVendor = Convert.ToString(dtHF.Rows[count]["MedicalVendor"]);
                    objHF.Address = new EAddress();
                    objHF.Address.Address1 = Convert.ToString(dtHF.Rows[count]["Address1"]);
                    objHF.Address.Address2 = Convert.ToString(dtHF.Rows[count]["Address2"]);
                    objHF.Address.City = Convert.ToString(dtHF.Rows[count]["City"]);
                    objHF.Address.State = Convert.ToString(dtHF.Rows[count]["State"]);
                    objHF.Address.Zip = Convert.ToString(dtHF.Rows[count]["ZipCode"]);

                    objLHF.Add(objHF);
                }
            }
            return objLHF;
        }

        public void DeleteHospitalFacility(int facilityId)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@FacilityID", SqlDbType.BigInt);
            arParms[0].Value = facilityId;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_deleteHPFacility", arParms);

        }

        public EHospitalFacility GetHospitalFacilityDetails(int FacilityId, int mode, out string strCampaignIDs)
        {
            strCampaignIDs = string.Empty;

            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@facilityid", SqlDbType.BigInt);
            arParms[0].Value = FacilityId;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getGetHospitalFacility", arParms);

            if (tempdataset.Tables[0].Rows.Count < 1) return null;

            EHospitalFacility objEHospitalFacility = new EHospitalFacility();
            objEHospitalFacility.Address = new EAddress();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                objEHospitalFacility.HospitalFacilityID = Convert.ToInt32(dr["FacilityID"]);
                objEHospitalFacility.HospitalPartnerId = Convert.ToInt32(dr["MedicalVendorID"]);
                objEHospitalFacility.FacilityName = Convert.ToString(dr["FacilityName"]);
                objEHospitalFacility.Email = Convert.ToString(dr["Email"]);
                objEHospitalFacility.PhoneCell = Convert.ToString(dr["PhoneCell"]);

                // Address details
                objEHospitalFacility.Address.AddressID = Convert.ToInt32(dr["AddressID"]);
                objEHospitalFacility.Address.Address1 = Convert.ToString(dr["Address1"]);
                objEHospitalFacility.Address.Address2 = Convert.ToString(dr["Address2"]);
                objEHospitalFacility.Address.City = Convert.ToString(dr["CityName"]);
                objEHospitalFacility.Address.StateID = Convert.ToInt32(dr["StateID"]);
                objEHospitalFacility.Address.ZipID = Convert.ToInt32(dr["ZipCode"]);
                objEHospitalFacility.Address.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);

            }
            if (tempdataset.Tables.Count > 1)
            {
                if (tempdataset.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in tempdataset.Tables[1].Rows)
                    {
                        if (dr["CampaignID"] != DBNull.Value)
                            strCampaignIDs = strCampaignIDs + Convert.ToString(dr["CampaignID"]) + ",";
                    }
                }
            }
            return objEHospitalFacility;
        }
        #endregion

        #region Common DAL Function
        private static object CheckNull(string strData)
        {
            if (strData == null || strData == "")
                return DBNull.Value;
            else return strData;
        }
        #endregion
    }
}
