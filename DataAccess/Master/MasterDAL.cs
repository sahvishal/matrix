using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Operations.Impl;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Franchisor;
using Falcon.Entity.Other;
using Falcon.Entity.User;
using Falcon.App.Core;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Core.Enum;
using EPaymentType = Falcon.Entity.Other.EPaymentType;
using EUser = Falcon.Entity.Other.EUser;
using Falcon.App.Core.Scheduling;

namespace Falcon.DataAccess.Master
{
    public class MasterDAL
    {

        private readonly string _connectionString = ConnectionHandler.GetConnectionString();

        private readonly CryptographyService _cryptographyService = new PasswordCryptographyService();

        public SqlTransaction TransactionObject()
        {
            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.BeginTransaction();
        }

        public List<EContactMeeting> GetMeetings(String filterString, int inputMode, int userid, int shellid, int roleid,
            Int64 iProspectId)
        {
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            arParms[2] = new SqlParameter("@userid", SqlDbType.Int);
            arParms[2].Value = userid;
            arParms[3] = new SqlParameter("@shellid", SqlDbType.Int);
            arParms[3].Value = shellid;
            arParms[4] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[4].Value = roleid;
            arParms[5] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[5].Value = iProspectId;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getmeetingdetails", arParms);

            var returnMeeting = new List<EContactMeeting>();
            returnMeeting = ParseMeetingDataSet(tempdataset);
            return returnMeeting;
        }

        public List<EEvent> GetCustomerEvent(string filterstring, Int16 mode)
        {
            var arparams = new SqlParameter[2];
            arparams[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 500);
            arparams[0].Value = filterstring;

            arparams[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[1].Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getcustomereventinfo", arparams);
            List<EEvent> returnvalue = ParseCustomerEvent(dstemp);
            return returnvalue;
        }

        private List<EEvent> ParseCustomerEvent(DataSet dstemp)
        {
            var listevent = new List<EEvent>();
            if (dstemp == null)
            {
                return listevent;
            }

            if (dstemp.Tables.Count == 0)
            {
                return listevent;
            }

            DataTable dtevent = dstemp.Tables[0];
            DataTable dtpackage = dstemp.Tables[1];
            DataTable dtAddOnTest = dstemp.Tables[3];
            //DataTable dttest = dstemp.Tables[2];

            for (int icount = 0; icount < dtevent.Rows.Count; icount++)
            {
                var objevent = new EEvent();

                objevent.EventID = Convert.ToInt32(dtevent.Rows[icount]["EventID"]);
                objevent.Name = Convert.ToString(dtevent.Rows[icount]["EventName"]);
                objevent.EventDate = Convert.ToString(dtevent.Rows[icount]["EventDate"]);
                // added event status
                objevent.EventStatus = Convert.ToInt32(dtevent.Rows[icount]["EventStatus"]);

                objevent.Host = new EHost();
                objevent.Host.HostID = Convert.ToInt32(dtevent.Rows[icount]["HostID"]);
                objevent.Host.Name = Convert.ToString(dtevent.Rows[icount]["HostName"]);

                objevent.Host.Address = new EAddress();
                objevent.Host.Address.AddressID = Convert.ToInt32(dtevent.Rows[icount]["AddressID"]);
                objevent.Host.Address.Zip = Convert.ToString(dtevent.Rows[icount]["ZipCode"]);
                objevent.Host.Address.City = Convert.ToString(dtevent.Rows[icount]["City"]);

                objevent.Host.Address.Address1 = Convert.ToString(dtevent.Rows[icount]["Address1"]);
                objevent.Host.Address.Address2 = Convert.ToString(dtevent.Rows[icount]["Address2"]);
                objevent.Host.Address.Country = Convert.ToString(dtevent.Rows[icount]["Country"]);
                objevent.Host.Address.State = Convert.ToString(dtevent.Rows[icount]["State"]);

                objevent.Customer = new List<EEventCustomer>();

                var objeventcustomer = new EEventCustomer();
                objeventcustomer.Interpreted = Convert.ToBoolean(dtevent.Rows[icount]["IsInterpreted"]);

                objeventcustomer.CustomerEventTestID = Convert.ToInt32(dtevent.Rows[icount]["EventCustomerID"]);
                if (dtevent.Rows[icount]["bMailReports"] != DBNull.Value)
                {
                    objeventcustomer.ReportEmail = Convert.ToBoolean(dtevent.Rows[icount]["bMailReports"]);
                }

                objeventcustomer.PaymentDetail = new EPaymentDetail();
                objeventcustomer.PaymentDetail.PaymentType = new EPaymentType();
                objeventcustomer.PaymentDetail.PaymentType.Name = Convert.ToString(dtevent.Rows[icount]["PaymentType"]);

                objeventcustomer.EventAppointment = new EEventAppointment();
                objeventcustomer.EventAppointment.StartTime = Convert.ToString(dtevent.Rows[icount]["StartTime"]);
                objeventcustomer.EventAppointment.EndTime = Convert.ToString(dtevent.Rows[icount]["EndTime"]);

                var package = new EPackage();
                DataRow[] rowpackage = dtpackage.Select("EventID = " + objevent.EventID);
                if (rowpackage.Length > 0)
                {
                    package.PackageID = Convert.ToInt32(rowpackage[0]["PackageID"]);
                    package.PackageName = Convert.ToString(rowpackage[0]["PackageName"]);
                }

                DataRow[] rowTest = dtAddOnTest.Select("EventID = " + objevent.EventID);
                for (int count = 0; count < rowTest.Length; count++)
                {
                    if (package.PackageName.Length > 0)
                    {
                        package.PackageName += ", " + Convert.ToString(rowTest[count]["TestName"]);
                    }
                    else
                    {
                        package.PackageName += Convert.ToString(rowTest[count]["TestName"]);
                    }
                }

                var eventpackage = new EEventPackage();
                eventpackage.Package = package;

                objeventcustomer.EventPackage = eventpackage;
                objevent.Customer = new List<EEventCustomer>();
                objevent.Customer.Add(objeventcustomer);

                listevent.Add(objevent);
            }
            return listevent;
        }

        public Int64 UpdatePaymentPaidStatus(Int32 intPaymentDetailID, string UserID, string Shell,
            string Role)
        {
            Int64 returnvalue = 0;
            var arparams = new SqlParameter[4];
            arparams[0] = new SqlParameter("@paymentdetailid", SqlDbType.BigInt);
            arparams[0].Value = intPaymentDetailID;
            arparams[1] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arparams[1].Value = UserID;
            arparams[2] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arparams[2].Value = Shell;
            arparams[3] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arparams[3].Value = Role;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_updatepaymentstatus",
                arparams);
            returnvalue = 0;

            return returnvalue;
        }

        public List<ETask> GetTaskForCalendar(long franchiseeId, long salesrepId, string hostName, string strStartDate,
            string strEndDate, Int16 mode)
        {
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@hostname", SqlDbType.VarChar, 100);
            arParms[0].Value = hostName;
            arParms[1] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            arParms[1].Value = franchiseeId;
            arParms[2] = new SqlParameter("@salesrepid", SqlDbType.BigInt);
            arParms[2].Value = salesrepId;

            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 30);
            arParms[3].Value = strStartDate;
            arParms[4] = new SqlParameter("@enddate", SqlDbType.VarChar, 30);
            arParms[4].Value = strEndDate;
            arParms[5] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[5].Value = mode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getTaskForCalendar", arParms);
            var objListTask = new List<ETask>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var objTask = new ETask();
                    objTask.DueDate = Convert.ToString(tempdataset.Tables[0].Rows[count]["DueDate"]);
                    objTask.DueTime = Convert.ToString(tempdataset.Tables[0].Rows[count]["DueTime"]);
                    objTask.Notes = Convert.ToString(tempdataset.Tables[0].Rows[count]["Notes"]);
                    objTask.StartDate = Convert.ToString(tempdataset.Tables[0].Rows[count]["StartDate"]);
                    objTask.StartTime = Convert.ToString(tempdataset.Tables[0].Rows[count]["StartTime"]);
                    objTask.Subject = Convert.ToString(tempdataset.Tables[0].Rows[count]["Subject"]);
                    objTask.TaskID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["TaskID"]);
                    objTask.TaskPriorityType = new ETaskPriorityType();
                    objTask.TaskPriorityType.Name = Convert.ToString(tempdataset.Tables[0].Rows[count]["Priority"]);
                    objTask.TaskPriorityType.TaskPriorityTypeID =
                        Convert.ToInt32(tempdataset.Tables[0].Rows[count]["TaskPriorityID"]);

                    objTask.TaskStatusType = new ETaskStatusType();
                    objTask.TaskStatusType.Name = Convert.ToString(tempdataset.Tables[0].Rows[count]["Status"]);
                    objTask.TaskStatusType.TaskStatusTypeID =
                        Convert.ToInt32(tempdataset.Tables[0].Rows[count]["TaskStatusID"]);

                    //Added w\ calendar enhancement start
                    objTask.EventName = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventName"]);
                    objTask.EventID = Convert.ToInt64(tempdataset.Tables[0].Rows[count]["EventID"]);
                    objTask.EventDate = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventDate"]);

                    objTask.HostOrgName = Convert.ToString(tempdataset.Tables[0].Rows[count]["OrganizationName"]);
                    objTask.HostAddress =
                        CommonClass.FormatAddress(Convert.ToString(tempdataset.Tables[0].Rows[count]["Address1"]),
                            Convert.ToString(tempdataset.Tables[0].Rows[count]["Address2"]),
                            Convert.ToString(tempdataset.Tables[0].Rows[count]["CityName"]),
                            Convert.ToString(tempdataset.Tables[0].Rows[count]["StateName"]),
                            Convert.ToString(tempdataset.Tables[0].Rows[count]["ZipCode"]));
                    objTask.OwnerName = Convert.ToString(tempdataset.Tables[0].Rows[count]["HSCName"]);
                    //Added w\ calendar enhancement end

                    objListTask.Add(objTask);
                }

                catch (Exception)
                { }
            }

            return objListTask;
        }

        public List<EContact> SearchContact(string strContactName, string strStateName, string strCity,
            string strZipCode, int mode, int userid, int roleid, int shellid,
            string strCustomerid, Int64 ProspectID)
        {
            var arParms = new SqlParameter[10];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userid;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[1].Value = roleid;
            arParms[2] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[2].Value = shellid;

            arParms[3] = new SqlParameter("@contactname", SqlDbType.VarChar, 200);
            if (strContactName.Trim().Length < 1)
            {
                arParms[3].Value = DBNull.Value;
            }
            else
            {
                arParms[3].Value = strContactName;
            }

            arParms[4] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (strStateName.Trim().Length < 1)
            {
                arParms[4].Value = DBNull.Value;
            }
            else
            {
                arParms[4].Value = strStateName;
            }

            arParms[5] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (strCity.Trim().Length < 1)
            {
                arParms[5].Value = DBNull.Value;
            }
            else
            {
                arParms[5].Value = strCity;
            }

            arParms[6] = new SqlParameter("@zipcode", SqlDbType.VarChar, 50);
            if (strZipCode.Trim().Length < 1)
            {
                arParms[6].Value = DBNull.Value;
            }
            else
            {
                arParms[6].Value = strZipCode;
            }

            arParms[7] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[7].Value = mode;
            arParms[8] = new SqlParameter("@customerid", SqlDbType.VarChar, 50);
            if (strCustomerid.Trim().Length < 1)
            {
                arParms[8].Value = DBNull.Value;
            }
            else
            {
                arParms[8].Value = strCustomerid;
            }

            arParms[9] = new SqlParameter("@ProspectID", SqlDbType.BigInt);
            arParms[9].Value = ProspectID;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_searchcontact",
                arParms);

            var returnContactDetails = new List<EContact>();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                var objContactDetails = new EContact();
                objContactDetails.ContactID = Convert.ToInt32(dr["ContactID"]);
                objContactDetails.EMail = dr["EMail"].ToString();
                objContactDetails.FirstName = dr["FirstName"].ToString();
                objContactDetails.LastName = dr["LastName"].ToString();
                objContactDetails.PhoneOffice = dr["PhoneOffice"].ToString();
                //   objContactDetails.Primary = Convert.ToBoolean(dr["IsPrimary"]);

                objContactDetails.Address = new EAddress();

                objContactDetails.Address.Address1 = dr["Address1"].ToString();
                objContactDetails.Address.Zip = dr["ZipCode"].ToString();
                objContactDetails.Address.City = dr["City"].ToString();
                objContactDetails.Address.State = dr["State"].ToString();
                objContactDetails.Address.Country = dr["Country"].ToString();

                returnContactDetails.Add(objContactDetails);
            }
            return returnContactDetails;
        }

        public EContact GetContactPreFill(Int64 prospectid, int mode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[0].Value = prospectid;
            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;


            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getcontactProspect", arParms);
            var objContactDetails = new EContact();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                objContactDetails.ContactID = Convert.ToInt32(dr["ContactID"]);
                objContactDetails.EMail = dr["EMail"].ToString();
                objContactDetails.FirstName = dr["FirstName"].ToString();
                objContactDetails.LastName = dr["LastName"].ToString();
                objContactDetails.PhoneOffice = dr["PhoneOffice"].ToString();

                objContactDetails.Address = new EAddress();

                objContactDetails.Address.Address1 = dr["Address1"].ToString();
                objContactDetails.Address.Zip = dr["ZipCode"].ToString();
                objContactDetails.Address.City = dr["City"].ToString();
                objContactDetails.Address.State = dr["State"].ToString();
                objContactDetails.Address.Country = dr["Country"].ToString();
            }
            return objContactDetails;
        }

        public List<EContactMeeting> GetMeetingForCalendar(long franchiseeId, long salesrepId, string hostName,
            string strStartDate, string strEndDate, Int16 mode)
        {
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@hostname", SqlDbType.VarChar, 100);
            arParms[0].Value = hostName;
            arParms[1] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            arParms[1].Value = franchiseeId;
            arParms[2] = new SqlParameter("@salesrepid", SqlDbType.BigInt);
            arParms[2].Value = salesrepId;

            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 30);
            arParms[3].Value = strStartDate;
            arParms[4] = new SqlParameter("@enddate", SqlDbType.VarChar, 30);
            arParms[4].Value = strEndDate;
            arParms[5] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[5].Value = mode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getMeetingForCalendar", arParms);
            var objListMeeting = new List<EContactMeeting>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                var objMeeting = new EContactMeeting();
                objMeeting.Subject = Convert.ToString(tempdataset.Tables[0].Rows[count]["Subject"]);
                objMeeting.StartDate = Convert.ToString(tempdataset.Tables[0].Rows[count]["StartDate"]);
                objMeeting.StartTime = Convert.ToString(tempdataset.Tables[0].Rows[count]["StartTime"]);
                objMeeting.ContactMeetingID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["ContactMeetingID"]);

                objMeeting.Venue = Convert.ToString(tempdataset.Tables[0].Rows[count]["MeetingVenue"]);
                objMeeting.CallStatus = new ECallStatus();
                objMeeting.CallStatus.Status = Convert.ToString(tempdataset.Tables[0].Rows[count]["Status"]);

                objMeeting.Duration = Convert.ToDecimal(tempdataset.Tables[0].Rows[count]["Duration"]);
                objMeeting.Reminder = Convert.ToBoolean(tempdataset.Tables[0].Rows[count]["Reminder"]);

                objMeeting.Contact = new EContact();
                objMeeting.Contact.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[count]["FirstName"]);
                objMeeting.Contact.LastName = Convert.ToString(tempdataset.Tables[0].Rows[count]["LastName"]);
                objMeeting.Contact.Title = Convert.ToString(tempdataset.Tables[0].Rows[count]["Salutation"]);
                objMeeting.Description = Convert.ToString(tempdataset.Tables[0].Rows[count]["Description"]);


                objListMeeting.Add(objMeeting);

            }

            return objListMeeting;
        }


        public Int64 SetNoShow(int EventCustomerID, bool check)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@EventCustomerID", SqlDbType.BigInt);
            arParms[0].Value = EventCustomerID;
            arParms[1] = new SqlParameter("@check", SqlDbType.Bit);
            arParms[1].Value = check;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_SetNoshow", arParms);
            return Convert.ToInt64(arParms[2].Value);
        }

        /// <summary>
        /// Sets CheckIn CheckOut Time of a customer for an event
        /// </summary>
        public Int64 SetCheckInCheckOutTime(string appointmentid, string checkintime, string checkouttime,
            out string authorizationTime)
        {
            long returnvalue;
            var arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@appointmentid", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt32(appointmentid);

            arParms[1] = new SqlParameter("@checkintime", SqlDbType.VarChar, 200);
            if (checkintime.Length < 1)
            {
                arParms[1].Value = DBNull.Value;
            }
            else
            {
                arParms[1].Value = checkintime;
            }

            arParms[2] = new SqlParameter("@checkouttime", SqlDbType.VarChar, 200);
            if (checkouttime.Length < 1)
            {
                arParms[2].Value = DBNull.Value;
            }
            else
            {
                arParms[2].Value = checkouttime;
            }

            arParms[3] = new SqlParameter("@authorizationtime", SqlDbType.DateTime);
            arParms[3].Direction = ParameterDirection.Output;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_setcheckincheckouttime",
                arParms);
            returnvalue = Convert.ToInt64(arParms[4].Value);

            if (arParms[3].Value != null && arParms[3].Value != DBNull.Value)
            {
                authorizationTime = Convert.ToString(arParms[3].Value);
            }
            else
            {
                authorizationTime = string.Empty;
            }

            return returnvalue;
        }

        /// <summary>
        /// save PCP Details
        /// </summary>
        /// <param name="objCustomer"></param>
        /// <returns></returns>
        private Int64 SavePCPDetails(ECustomers objCustomer, long organizationRoleUserId, SqlTransaction sqlTransaction)
        {
            var returnresult = new Int64();
            var arParms = new SqlParameter[14];

            arParms[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arParms[1] = new SqlParameter("@physicianfirstname", SqlDbType.VarChar, 500);
            arParms[2] = new SqlParameter("@physicianmiddlename", SqlDbType.VarChar, 500);
            arParms[3] = new SqlParameter("@physicianlastname", SqlDbType.VarChar, 500);
            arParms[4] = new SqlParameter("@pcpaddressid", SqlDbType.BigInt);
            arParms[5] = new SqlParameter("@phonenumber", SqlDbType.VarChar, 100);
            arParms[6] = new SqlParameter("@email", SqlDbType.VarChar, 200);
            arParms[7] = new SqlParameter("@sendemail", SqlDbType.Bit);
            arParms[8] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[9] = new SqlParameter("@phoneother", SqlDbType.VarChar, 500);
            arParms[10] = new SqlParameter("@emailother", SqlDbType.VarChar, 500);
            arParms[11] = new SqlParameter("@website", SqlDbType.VarChar, 1000);
            arParms[12] = new SqlParameter("@hasPcpInfo", SqlDbType.Bit);
            arParms[13] = new SqlParameter("@updatedByOrgRoleUserId", SqlDbType.BigInt);


            arParms[0].Value = objCustomer.CustomerID;
            arParms[8].Direction = ParameterDirection.Output;
            if (organizationRoleUserId > 0)
            {
                arParms[13].Value = organizationRoleUserId;
            }
            else
            {
                arParms[13].Value = DBNull.Value;
            }

            if (objCustomer.PrimaryCarePhysician != null)
            {
                arParms[1].Value = objCustomer.PrimaryCarePhysician.FirstName;
                arParms[2].Value = objCustomer.PrimaryCarePhysician.MiddleName;
                arParms[3].Value = objCustomer.PrimaryCarePhysician.LastName;

                if (objCustomer.PrimaryCarePhysician.PCPAddress != null &&
                    objCustomer.PrimaryCarePhysician.PCPAddress.AddressID > 0)
                {
                    arParms[4].Value = objCustomer.PrimaryCarePhysician.PCPAddress.AddressID;
                }
                else
                {
                    arParms[4].Value = DBNull.Value;
                }

                arParms[5].Value = objCustomer.PrimaryCarePhysician.PhoneNumber;
                arParms[6].Value = objCustomer.PrimaryCarePhysician.Email;
                arParms[7].Value = objCustomer.PrimaryCarePhysician.SendEmail;
                arParms[9].Value = objCustomer.PrimaryCarePhysician.PhoneOther;
                arParms[10].Value = objCustomer.PrimaryCarePhysician.EmailOther;
                arParms[11].Value = objCustomer.PrimaryCarePhysician.Website;
                arParms[12].Value = true;
            }
            else
            {
                arParms[1].Value = "";
                arParms[2].Value = DBNull.Value;
                arParms[3].Value = "";

                arParms[4].Value = DBNull.Value;

                arParms[5].Value = "";
                arParms[6].Value = "";
                arParms[7].Value = false;
                arParms[9].Value = "";
                arParms[10].Value = "";
                arParms[11].Value = "";
                arParms[12].Value = false;
            }


            if (sqlTransaction == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savePCPDetails", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.StoredProcedure, "usp_savePCPDetails", arParms);
            }

            returnresult = Convert.ToInt64(arParms[8].Value);
            return returnresult;
        }

        /// <summary>
        /// Check Duplicate Event Registration
        /// </summary>
        public EEvent CheckDuplicateEventRegistration(long hostId, string eventDate)
        {
            var arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@HostId", SqlDbType.BigInt);
            arParms[0].Value = hostId;

            arParms[1] = new SqlParameter("@EventDate", SqlDbType.VarChar, 20);
            arParms[1].Value = eventDate;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_CheckDuplicateEventRegistration", arParms);
            var objEvent = new EEvent();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                objEvent.Host = new EHost();
                objEvent.Name = Convert.ToString(tempdataset.Tables[0].Rows[0]["EventName"]);
                objEvent.EventDate = Convert.ToString(tempdataset.Tables[0].Rows[0]["EventDate"]);
                objEvent.Host.Name = Convert.ToString(tempdataset.Tables[0].Rows[0]["OrganizationName"]);
            }
            return objEvent;
        }

        public Int64 SaveProspectCustomer(EProspectCustomer objProspectCustomer, int mode)
        {
            var arParms = new SqlParameter[21];

            arParms[0] = new SqlParameter("@ProspectCustomerID", SqlDbType.BigInt);
            arParms[0].Value = objProspectCustomer.ProspectCustomerID;

            arParms[1] = new SqlParameter("@FirstName", SqlDbType.VarChar, 100);
            if (objProspectCustomer.FirstName != null && objProspectCustomer.FirstName.Trim() != "")
            {
                arParms[1].Value = objProspectCustomer.FirstName;
            }
            else
            {
                arParms[1].Value = DBNull.Value;
            }

            arParms[2] = new SqlParameter("@LastName", SqlDbType.VarChar, 100);
            if (objProspectCustomer.LastName != null && objProspectCustomer.LastName.Trim() != "")
            {
                arParms[2].Value = objProspectCustomer.LastName;
            }
            else
            {
                arParms[2].Value = DBNull.Value;
            }

            arParms[3] = new SqlParameter("@ZipCode", SqlDbType.VarChar, 50);
            if (objProspectCustomer.ZipCode != null && objProspectCustomer.ZipCode.Trim() != "")
            {
                arParms[3].Value = objProspectCustomer.ZipCode;
            }
            else
            {
                arParms[3].Value = DBNull.Value;
            }

            arParms[4] = new SqlParameter("@CallbackNo", SqlDbType.VarChar, 50);
            if (objProspectCustomer.CallbackNo != null && objProspectCustomer.CallbackNo.Trim() != "")
            {
                arParms[4].Value = objProspectCustomer.CallbackNo;
            }
            else
            {
                arParms[4].Value = DBNull.Value;
            }

            arParms[5] = new SqlParameter("@CustomerID", SqlDbType.BigInt);
            if (objProspectCustomer.CustomerID != 0)
            {
                arParms[5].Value = objProspectCustomer.CustomerID;
            }
            else
            {
                arParms[5].Value = DBNull.Value;
            }

            arParms[6] = new SqlParameter("@Address1", SqlDbType.VarChar, 200);
            if (objProspectCustomer.Address1 != null && objProspectCustomer.Address1.Trim() != "")
            {
                arParms[6].Value = objProspectCustomer.Address1;
            }
            else
            {
                arParms[6].Value = DBNull.Value;
            }

            arParms[7] = new SqlParameter("@Address2", SqlDbType.VarChar, 200);
            if (objProspectCustomer.Address2 != null && objProspectCustomer.Address2.Trim() != "")
            {
                arParms[7].Value = objProspectCustomer.Address2;
            }
            else
            {
                arParms[7].Value = DBNull.Value;
            }

            arParms[8] = new SqlParameter("@City", SqlDbType.VarChar, 100);
            if (objProspectCustomer.City != null && objProspectCustomer.City.Trim() != "")
            {
                arParms[8].Value = objProspectCustomer.City;
            }
            else
            {
                arParms[8].Value = DBNull.Value;
            }

            arParms[9] = new SqlParameter("@DOB", SqlDbType.VarChar, 100);
            if (objProspectCustomer.DOB != null && objProspectCustomer.DOB.Trim() != "")
            {
                arParms[9].Value = objProspectCustomer.DOB;
            }
            else
            {
                arParms[9].Value = DBNull.Value;
            }

            arParms[10] = new SqlParameter("@Email", SqlDbType.VarChar, 100);
            if (objProspectCustomer.Email != null && objProspectCustomer.Email.Trim() != "")
            {
                arParms[10].Value = objProspectCustomer.Email;
            }
            else
            {
                arParms[10].Value = DBNull.Value;
            }

            arParms[11] = new SqlParameter("@Phone2", SqlDbType.VarChar, 100);
            if (objProspectCustomer.Phone2 != null && objProspectCustomer.Phone2.Trim() != "")
            {
                arParms[11].Value = objProspectCustomer.Phone2;
            }
            else
            {
                arParms[11].Value = DBNull.Value;
            }

            arParms[12] = new SqlParameter("@IsConverted", SqlDbType.Bit);
            arParms[12].Value = objProspectCustomer.IsConverted;

            arParms[13] = new SqlParameter("@Source", SqlDbType.VarChar, 100);
            if (objProspectCustomer.Source != null && objProspectCustomer.Source.Trim() != "")
            {
                arParms[13].Value = objProspectCustomer.Source;
            }
            else
            {
                arParms[13].Value = DBNull.Value;
            }

            arParms[14] = new SqlParameter("@Tag", SqlDbType.VarChar, 100);
            if (objProspectCustomer.Tag != null && objProspectCustomer.Tag.Trim() != "")
            {
                arParms[14].Value = objProspectCustomer.Tag;
            }
            else
            {
                arParms[14].Value = DBNull.Value;
            }

            arParms[15] = new SqlParameter("@Mode", SqlDbType.Int);
            arParms[15].Value = mode;

            arParms[16] = new SqlParameter("@State", SqlDbType.VarChar, 100);
            if (objProspectCustomer.State != null && objProspectCustomer.State.Trim() != "")
            {
                arParms[16].Value = objProspectCustomer.State;
            }
            else
            {
                arParms[16].Value = DBNull.Value;
            }

            arParms[17] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[17].Direction = ParameterDirection.Output;

            arParms[18] = new SqlParameter("@MarketingSource", SqlDbType.VarChar, 100);
            if (objProspectCustomer.MarketingSource != null && objProspectCustomer.MarketingSource.Trim() != "")
            {
                arParms[18].Value = objProspectCustomer.MarketingSource;
            }
            else
            {
                arParms[18].Value = DBNull.Value;
            }

            arParms[19] = new SqlParameter("@SourceCode", SqlDbType.VarChar, 50);
            if (objProspectCustomer.SourceCode != null && objProspectCustomer.SourceCode.Trim() != "")
            {
                arParms[19].Value = objProspectCustomer.SourceCode;
            }
            else
            {
                arParms[19].Value = DBNull.Value;
            }

            arParms[20] = new SqlParameter("@IncomingPhoneLine", SqlDbType.VarChar, 20);
            if (objProspectCustomer.IncomingPhoneLine != null && objProspectCustomer.IncomingPhoneLine.Trim() != "")
            {
                arParms[20].Value = objProspectCustomer.IncomingPhoneLine;
            }
            else
            {
                arParms[20].Value = DBNull.Value;
            }

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveProspectCustomer",
                arParms);
            return Convert.ToInt64(arParms[17].Value);
        }

        // Get ProspectCustomer Details By NotificationPhoneID 
        public EProspectCustomer GetProspectCustomer(Int64 iNotificationPhoneID)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@NotificationPhoneID", SqlDbType.BigInt);
            arParms[0].Value = iNotificationPhoneID;

            arParms[1] = new SqlParameter("@mode", SqlDbType.BigInt);
            arParms[1].Value = 0;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString, "usp_GetProspectCustomerByPhoneID", arParms);

            var objEProspectCustomer = new EProspectCustomer();

            if (dstemp.Tables.Count > 0)
            {
                if (dstemp.Tables[0].Rows.Count > 0)
                {
                    objEProspectCustomer.FirstName = Convert.ToString(dstemp.Tables[0].Rows[0]["FirstName"]);
                    objEProspectCustomer.LastName = Convert.ToString(dstemp.Tables[0].Rows[0]["LastName"]);
                    objEProspectCustomer.CallbackNo = Convert.ToString(dstemp.Tables[0].Rows[0]["CallBackNo"]);
                    objEProspectCustomer.ProspectCustomerID =
                        Convert.ToInt32(dstemp.Tables[0].Rows[0]["ProspectCustomerID"]);
                    objEProspectCustomer.Address1 = Convert.ToString(dstemp.Tables[0].Rows[0]["Address1"]);
                    objEProspectCustomer.Address2 = Convert.ToString(dstemp.Tables[0].Rows[0]["Address2"]);
                    objEProspectCustomer.City = Convert.ToString(dstemp.Tables[0].Rows[0]["City"]);
                    objEProspectCustomer.State = Convert.ToString(dstemp.Tables[0].Rows[0]["State"]);
                }
            }
            return objEProspectCustomer;
        }

        public Int64 SavePCPDetails(ECustomers objCustomer, long organizationRoleUserId)
        {
            SqlTransaction sqlTransaction = TransactionObject();
            Int64 returnresult = 0;

            if (objCustomer.PrimaryCarePhysician != null)
            {
                if (objCustomer.PrimaryCarePhysician.PCPAddress != null)
                {
                    if (objCustomer.PrimaryCarePhysician.PCPAddress.AddressID < 1)
                    {
                        returnresult = SaveAddress(objCustomer.PrimaryCarePhysician.PCPAddress,
                            Convert.ToInt32(EOperationMode.Insert), sqlTransaction);
                        if (returnresult == 999998 || returnresult == -1)
                        {
                            sqlTransaction.Rollback();
                            return returnresult;
                        }

                        if (returnresult != -5)
                        {
                            objCustomer.PrimaryCarePhysician.PCPAddress.AddressID = Convert.ToInt32(returnresult);
                        }
                        else
                        {
                            objCustomer.PrimaryCarePhysician.PCPAddress.AddressID = 0;
                        }
                    }
                    else
                    {
                        returnresult = SaveAddress(objCustomer.PrimaryCarePhysician.PCPAddress,
                            Convert.ToInt32(EOperationMode.Update), sqlTransaction);
                        if (returnresult == -1)
                        {
                            sqlTransaction.Rollback();
                            return returnresult;
                        }
                        if (returnresult == -5)
                        {
                            objCustomer.PrimaryCarePhysician.PCPAddress.AddressID = 0;
                        }
                    }
                }

                returnresult = SavePCPDetails(objCustomer, organizationRoleUserId, sqlTransaction);

                if (returnresult == 999998 || returnresult == -1)
                {
                    sqlTransaction.Rollback();
                    return returnresult;
                }

                sqlTransaction.Commit();
            }
            else
            {
                returnresult = SavePCPDetails(objCustomer, organizationRoleUserId, sqlTransaction);
                if (returnresult == 999998 || returnresult == -1)
                {
                    sqlTransaction.Rollback();
                    return returnresult;
                }

                sqlTransaction.Commit();
            }
            return returnresult;
        }

        public EEvent SearchFranchisorCustomerList(int customerid, string customername, string cityname,
            string statename, string zipcode, string fromdate, string todate,
            int franchiseeid, int dateType, int pageNo, int pageSize,
            out long pageCount)
        {
            var objEvent = new EEvent();
            objEvent = GetCustomerList(customerid, customername, cityname, statename, zipcode, fromdate, todate,
                franchiseeid, dateType, 1, pageNo, pageSize, out pageCount);
            //if (dateType == 0)
            //{
            //    var objEvent1 = new EEvent();
            //    objEvent1 = GetCustomerList(customerid, customername, cityname, statename, zipcode, fromdate, todate,
            //        franchiseeid, dateType, 2, pageNo, pageSize, out pageCount);
            //    objEvent.TotalRecord = objEvent.TotalRecord + objEvent1.TotalRecord;

            //    if (objEvent1.Customer != null && objEvent1.Customer.Count > 0)
            //    {
            //        objEvent.Customer.InsertRange(objEvent.Customer.Count, objEvent1.Customer);
            //    }
            //}
            return objEvent;
        }

        public DataSet GetCityOnStateName(String statename, string cityname)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@statename", SqlDbType.VarChar, 500) { Value = statename };
            arParms[1] = new SqlParameter("@cityname", SqlDbType.VarChar, 500) { Value = cityname };
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getcityonstatename", arParms);
            return tempdataset;
        }

        // TODO: This is tempory and need to migrates on new order system using LLBGen and JQuery
        // NOTE: these sprocs seem to be missing from my copy of the database. Do we have them?

        public long OrderShipping(long eventId, long customerId, ShippingDetail shippingDetail)
        {
            NullArgumentChecker.CheckIfNull(shippingDetail, "shippingDetail");
            using (var transaction = new TransactionScope())
            {
                IShippingController shippingController = new ShippingController();

                if (shippingDetail.Id == 0)
                {
                    shippingDetail = shippingController.OrderShipping(shippingDetail);
                }

                if (shippingDetail.Id > 0)
                {
                    var commandParameters = new List<SqlParameter>
                    {
                        new SqlParameter("@ShippingDetailID", SqlDbType.BigInt)
                        {Value = shippingDetail.Id},
                        new SqlParameter("@EventID", SqlDbType.BigInt) {Value = eventId},
                        new SqlParameter("@CustomerID", SqlDbType.BigInt)
                        {Value = customerId},
                        new SqlParameter("@ReturnResult", SqlDbType.BigInt)
                        {Direction = ParameterDirection.Output}
                    };

                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                        "usp_saveShippingPaymentDetail", commandParameters.ToArray());

                    transaction.Complete();
                    return Convert.ToInt64(commandParameters[3].Value);
                }
                return 0;
            }
        }

        public long SaveShippingPayment(long eventCustomerId, decimal paymentAmount, int paymentTypeId, long roleShellId,
            int roleId)
        {
            var commandParameters = new List<SqlParameter>
            {
                new SqlParameter("@EventCustomerID", SqlDbType.BigInt)
                {Value = eventCustomerId},
                new SqlParameter("@PaymentAmount", SqlDbType.Decimal)
                {Value = paymentAmount},
                new SqlParameter("@PaymentTypeID", SqlDbType.Int)
                {Value = paymentTypeId},
                new SqlParameter("@RoleShellID", SqlDbType.BigInt)
                {Value = roleShellId},
                new SqlParameter("@RoleID", SqlDbType.BigInt)
                {Value = roleId},
                new SqlParameter("@PaymentID", SqlDbType.BigInt)
                {Direction = ParameterDirection.Output}
            };
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                "usp_saveShippingPayment", commandParameters.ToArray());
            return Convert.ToInt64(commandParameters[5].Value);
        }

        public List<OrderedPair<string, long>> GetShippingDetailForRegistration(long eventCustomerId)
        {
            var shippingDetail = new List<OrderedPair<string, long>>();
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@eventCustomerId", SqlDbType.BigInt) { Value = eventCustomerId };
            DataSet tempDataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_GetShippingDetailForRegistration",
                arParms);
            foreach (DataRow row in tempDataset.Tables[0].Rows)
            {
                shippingDetail.Add(new OrderedPair<string, long>(Convert.ToString(row["ShippingOption"]),
                    Convert.ToInt64(row["ShippingDetailID"])));
            }
            return shippingDetail;
        }

        public List<OrderedPair<string, long>> GetPendingEventForAuthorization(long medicalVendorMedicalVendorUserId,
            Int16 mode)
        {
            var pendingEventDetail = new List<OrderedPair<string, long>>();
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@medicalvendormvuserId", SqlDbType.BigInt);
            arParms[0].Value = medicalVendorMedicalVendorUserId;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;

            DataSet tempDataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_GetPendingEventForAuthorization",
                arParms);

            foreach (DataRow row in tempDataset.Tables[0].Rows)
            {
                string eventDetail = row["EventName"] + " at " + row["Address1"] + ", " + row["City"] + ", " +
                    row["State"] + ",  " + row["ZipCode"];
                pendingEventDetail.Add(new OrderedPair<string, long>(eventDetail, Convert.ToInt64(row["EventID"])));
            }

            return pendingEventDetail;
        }

        //TODo: RollBack the function written in repostory as the entity is not updated.
        public String getCCRepInstructionForEvent(long eventId)
        {
            var commandParameter = new List<SqlParameter>
            {
                new SqlParameter("@eventid", SqlDbType.BigInt)
                {Value = eventId}
            };
            return
                SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure,
                    "[usp_getCCRepInstructionOfEevent]", commandParameter.ToArray()).ToString();
        }


        public Int64 SaveBlurbToEvent(long eventMarketingMaterialId, long eventId, long marketingMaterialId,
            long advocateId,
            long organizationRoleUserId, string phoneNumber, string tempSourceCode)
        {
            var arParms = new SqlParameter[8];
            arParms[0] = new SqlParameter("@eventMarketingMaterialID", SqlDbType.BigInt) { Value = eventMarketingMaterialId };
            arParms[1] = new SqlParameter("@eventID", SqlDbType.BigInt) { Value = eventId };
            arParms[2] = new SqlParameter("@marketingMaterialID", SqlDbType.BigInt) { Value = marketingMaterialId };
            arParms[3] = new SqlParameter("@advocateId", SqlDbType.BigInt) { Value = advocateId };
            arParms[4] = new SqlParameter("@phoneNumber", SqlDbType.VarChar, 100) { Value = phoneNumber };
            arParms[5] = new SqlParameter("@organizationRoleUserId", SqlDbType.BigInt) { Value = organizationRoleUserId };
            arParms[6] = new SqlParameter("@returnResult", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            arParms[7] = new SqlParameter("@tempSourceCode", SqlDbType.VarChar, 100) { Value = tempSourceCode };

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "[usp_saveBlurbToEvent]", arParms);

            return Convert.ToInt64(arParms[6].Value);
        }

        public Int64 EditEventBlurb(long eventMarketingMaterialId, long marketingMaterialId, long organizationRoleUserId)
        {
            return SaveBlurbToEvent(eventMarketingMaterialId, 0, marketingMaterialId, 0, organizationRoleUserId, "", "");
        }

        #region "Gift Certificate"

        public void UpdateGiftCertificatePaymentDetails(long eventId, long customerId, long giftCertificateId,
            decimal giftCertificateAmount)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@EventId", SqlDbType.BigInt) { Value = eventId };
            arParms[1] = new SqlParameter("@CustomerId", SqlDbType.BigInt) { Value = customerId };
            arParms[2] = new SqlParameter("@GiftCertificateId", SqlDbType.BigInt) { Value = giftCertificateId };
            arParms[3] = new SqlParameter("@GiftCertificateAmount", SqlDbType.Decimal) { Value = giftCertificateAmount };

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                "usp_UpdateGiftCertificatePaymentDetails", arParms);
        }

        public void SaveGiftCertificatePaymentDetails(long paymentId, long giftCertificateId,
            decimal giftCertificateAmount)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@paymentId", SqlDbType.BigInt) { Value = paymentId };
            arParms[1] = new SqlParameter("@giftCertificateId", SqlDbType.BigInt) { Value = giftCertificateId };
            arParms[2] = new SqlParameter("@giftCertificateAmount", SqlDbType.Decimal) { Value = giftCertificateAmount };

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                "usp_saveGiftCertificatePaymentDetails", arParms);
        }


        #endregion

        #region "Deposite Slip"

        public List<EDepositeSlip> GetDepositeSlip(Int64 eventid)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = eventid;

            var dsDepositeSlip = new DataSet();
            dsDepositeSlip = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getdepositeslip", arParms);

            var lstEDepositeSlip = new List<EDepositeSlip>();

            if (dsDepositeSlip.Tables.Count >= 2)
            {
                if (dsDepositeSlip.Tables[0].Rows.Count > 0 || dsDepositeSlip.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsDepositeSlip.Tables[0].Rows)
                    {
                        var objEDepositeSlip = new EDepositeSlip();
                        objEDepositeSlip.SerialNo = Convert.ToInt64(dr["SerialNo"]);
                        objEDepositeSlip.CustomerName = Convert.ToString(dr["Name"]);
                        objEDepositeSlip.PaymentType = Convert.ToString(dr["PaymentMode"]);
                        objEDepositeSlip.PaymentAmount = Convert.ToDouble(dr["Amount"]);
                        if (dr["ChequeNumber"] != DBNull.Value && dr["ChequeNumber"].ToString() != "")
                        {
                            objEDepositeSlip.ChequeNumber = Convert.ToString(dr["ChequeNumber"]);
                        }
                        if (dr["RoutingNumber"] != DBNull.Value && dr["RoutingNumber"].ToString() != "")
                        {
                            objEDepositeSlip.RoutingNumber = Convert.ToString(dr["RoutingNumber"]);
                        }
                        if (dr["AccountNumber"] != DBNull.Value && dr["AccountNumber"].ToString() != "")
                        {
                            objEDepositeSlip.AccountNumber = Convert.ToString(dr["AccountNumber"]);
                        }
                        lstEDepositeSlip.Add(objEDepositeSlip);
                    }
                    if (dsDepositeSlip.Tables.Count == 2)
                    {
                        if (dsDepositeSlip.Tables[1].Rows.Count > 0)
                        {
                            DataRow drTotalCheck = dsDepositeSlip.Tables[1].Rows[0];

                            if (lstEDepositeSlip.Count > 0)
                            {
                                lstEDepositeSlip[0].TotalAmountCheck =
                                    Convert.ToDecimal(drTotalCheck["check"]).ToString("0.00");
                                lstEDepositeSlip[0].TotalAmountCash =
                                    Convert.ToDecimal(drTotalCheck["cash"]).ToString("0.00");
                                lstEDepositeSlip[0].TotalAmount =
                                    (Convert.ToDecimal(drTotalCheck["check"]) + Convert.ToDecimal(drTotalCheck["cash"]))
                                        .ToString("0.00");
                            }
                            else
                            {
                                var objEDepositeSlip = new EDepositeSlip();
                                lstEDepositeSlip.Add(objEDepositeSlip);
                                lstEDepositeSlip[0].TotalAmountCheck =
                                    Convert.ToDecimal(drTotalCheck["check"]).ToString("0.00");
                                lstEDepositeSlip[0].TotalAmountCash =
                                    Convert.ToDecimal(drTotalCheck["cash"]).ToString("0.00");
                                lstEDepositeSlip[0].TotalAmount =
                                    (Convert.ToDecimal(drTotalCheck["check"]) + Convert.ToDecimal(drTotalCheck["cash"]))
                                        .ToString("0.00");
                            }
                        }
                    }
                }
            }

            return lstEDepositeSlip;
        }

        #endregion

        #region MArketingOffer

        public List<EMarketingOffer> GetMarketingOfferPaged(String strMarketingOffer, Int16 intMode, Int64 intPageNumber,
            Int32 intPageSize, out int iTotalRecordCount)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@marketingoffer", SqlDbType.VarChar, 500);
            arParms[0].Value = strMarketingOffer;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = intMode;
            arParms[2] = new SqlParameter("@pagenumber", SqlDbType.Int);
            arParms[2].Value = intPageNumber;
            arParms[3] = new SqlParameter("@pagesize", SqlDbType.Int);
            arParms[3].Value = intPageSize;
            arParms[4] = new SqlParameter("@othersearch", SqlDbType.VarChar, 500);
            arParms[4].Value = "";
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getmarketingoffer", arParms);
            iTotalRecordCount = 0;
            if (tempdataset != null && tempdataset.Tables[1].Rows.Count > 0)
            {
                iTotalRecordCount = Convert.ToInt32(tempdataset.Tables[1].Rows[0][0]);
            }
            return ParseMarketingOffer(tempdataset);
        }


        private List<EMarketingOffer> ParseMarketingOffer(DataSet MarketingOfferDataSet)
        {
            var objReturnMarketingOffer = new List<EMarketingOffer>();

            for (int count = 0; count < MarketingOfferDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var objMarketingOffer = new EMarketingOffer();
                    objMarketingOffer.Active = Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsActive"]);
                    objMarketingOffer.MarketingOffer =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOffer"]);
                    objMarketingOffer.MarketingOfferID =
                        Convert.ToInt32(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOfferID"]);
                    objMarketingOffer.MarketingOfferType = new EMarketingOfferType();
                    objMarketingOffer.MarketingOfferType.MarketingOfferTypeID =
                        Convert.ToInt32(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOfferTypeID"]);
                    objMarketingOffer.MarketingOfferType.Name =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["Name"]);
                    objMarketingOffer.MarketingOfferValue =
                        Convert.ToDecimal(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOfferValue"]);
                    objMarketingOffer.MarketingOfferDes =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOfferDescription"]);
                    objMarketingOffer.CreatedbyUserID =
                        Convert.ToInt64(MarketingOfferDataSet.Tables[0].Rows[count]["CreatedUserID"]);
                    objMarketingOffer.IsDiscountTypePackageWise =
                        Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["DiscountType"]);

                    objMarketingOffer.IsEventBased =
                        Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsEventbased"]);
                    objMarketingOffer.IsFree = Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsFree"]);
                    objMarketingOffer.IsGlobal =
                        Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsGlobal"]);
                    objMarketingOffer.IsPercentage =
                        Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsPercentage"]);
                    objMarketingOffer.CustomerRange =
                        Convert.ToInt16(MarketingOfferDataSet.Tables[0].Rows[count]["CustomerRange"]);

                    objMarketingOffer.MaximumNumberTimesUsed =
                        Convert.ToInt64(MarketingOfferDataSet.Tables[0].Rows[count]["MaximumNumberTimesUsed"]);
                    objMarketingOffer.MinPurchaseAmount =
                        Convert.ToDecimal(MarketingOfferDataSet.Tables[0].Rows[count]["MinimumPurchaseAmount"]);
                    objMarketingOffer.ValidityEndDate =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["ValidityEndDate"]);
                    objMarketingOffer.ValidityStartDate =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["ValidityStartDate"]);
                    objReturnMarketingOffer.Add(objMarketingOffer);
                }
                catch
                { }
            }


            return objReturnMarketingOffer;
        }

        #endregion

        # region "EventWizard"

        public List<EProspect> GetHostDetailsForEventWizard(string filterstring, int mode, long roleshellid, int roleid,
            string city)
        {
            var arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[0].Value = mode;

            arParms[1] = new SqlParameter("@filterstring", SqlDbType.VarChar, 50);
            arParms[1].Value = filterstring;

            arParms[2] = new SqlParameter("@roleshellid", SqlDbType.BigInt);
            arParms[2].Value = roleshellid;

            arParms[3] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[3].Value = roleid;

            arParms[4] = new SqlParameter("@City", SqlDbType.VarChar, 50);
            arParms[4].Value = city;

            var ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getHostDetailsForEventWizard", arParms);
            var objlProsect = new List<EProspect>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dtHost = ds.Tables[0];
                DataTable dtEventCount = ds.Tables[1];
                DataTable dtPrimaryContact = ds.Tables[2];
                DataTable dtTotalSlots = ds.Tables[3];
                DataTable dtBookedSlots = ds.Tables[4];
                for (int count = 0; count < dtHost.Rows.Count; count++)
                {
                    var objProspect = new EProspect();
                    objProspect.ProspectID = Convert.ToInt32(dtHost.Rows[count]["HostID"]);
                    objProspect.OrganizationName = Convert.ToString(dtHost.Rows[count]["OrganizationName"]);
                    // TaxIdNumber
                    objProspect.TaxIdNumber = Convert.ToString(dtHost.Rows[count]["TaxIdNumber"]);
                    objProspect.Address = new EAddress();
                    objProspect.Address.AddressID = Convert.ToInt32(dtHost.Rows[count]["AddressId"]);
                    objProspect.Address.Address1 = Convert.ToString(dtHost.Rows[count]["Address1"]);
                    objProspect.Address.Address2 = Convert.ToString(dtHost.Rows[count]["Address2"]);
                    objProspect.Address.City = Convert.ToString(dtHost.Rows[count]["City"]);
                    objProspect.Address.State = Convert.ToString(dtHost.Rows[count]["State"]);
                    objProspect.Address.Zip = Convert.ToString(dtHost.Rows[count]["ZipCode"]);
                    objProspect.Address.Latitude = Convert.ToString(dtHost.Rows[count]["Latitude"]);
                    objProspect.Address.Longitude = Convert.ToString(dtHost.Rows[count]["Longitude"]);
                    if (dtHost.Rows[count]["IsManuallyVerified"] == DBNull.Value)
                    {
                        objProspect.Address.IsManuallyVerified = null;
                    }
                    else
                    {
                        objProspect.Address.IsManuallyVerified =
                            Convert.ToBoolean(dtHost.Rows[count]["IsManuallyVerified"]);
                    }

                    objProspect.Address.UseLatLogForMapping =
                        Convert.ToBoolean(dtHost.Rows[count]["UseLatLogForMapping"]);

                    objProspect.ProspectDetails = new EProspectDetails();
                    objProspect.ProspectDetails.FacilitiesFee = Convert.ToString(dtHost.Rows[count]["FacilitiesFee"]);
                    objProspect.ProspectDetails.DepositsAmount = Convert.ToDecimal(dtHost.Rows[count]["DepositsAmount"]);
                    objProspect.ProspectDetails.PaymentMethod = Convert.ToString(dtHost.Rows[count]["PaymentMethod"]);
                    if (dtEventCount.Rows.Count > 0)
                    {
                        dtEventCount.DefaultView.RowFilter = "HostID = " + objProspect.ProspectID;
                        if (dtEventCount.DefaultView.Count > 0)
                        {
                            objProspect.TotalEvent = Convert.ToInt32(dtEventCount.DefaultView[0]["TotalEvents"]);
                            objProspect.TotalCustomer = Convert.ToInt32(dtEventCount.DefaultView[0]["TotalCustomers"]);
                            objProspect.CustomersPerEvent = objProspect.TotalCustomer / objProspect.TotalEvent;
                        }
                    }

                    if (dtPrimaryContact.Rows.Count > 0)
                    {
                        objProspect.Contact = new List<EContact>();
                        dtPrimaryContact.DefaultView.RowFilter = "HostID = " + objProspect.ProspectID;
                        if (dtPrimaryContact.DefaultView.Count > 0)
                        {
                            var objContact = new EContact();
                            objContact.PhoneHome = Convert.ToString(dtPrimaryContact.DefaultView[0]["PhoneHome"]);
                            objContact.PhoneCell = Convert.ToString(dtPrimaryContact.DefaultView[0]["PhoneCell"]);
                            objContact.EMail = Convert.ToString(dtPrimaryContact.DefaultView[0]["EMail"]);
                            objContact.ContactID = Convert.ToInt32(dtPrimaryContact.DefaultView[0]["ContactID"]);
                            objContact.FirstName = Convert.ToString(dtPrimaryContact.DefaultView[0]["FirstName"]);
                            objContact.MiddleName = Convert.ToString(dtPrimaryContact.DefaultView[0]["MiddleName"]);
                            objContact.LastName = Convert.ToString(dtPrimaryContact.DefaultView[0]["LastName"]);
                            objProspect.Contact.Add(objContact);
                        }
                    }
                    if (dtTotalSlots.Rows.Count > 0 && dtBookedSlots.Rows.Count > 0)
                    {
                        dtBookedSlots.DefaultView.RowFilter = "HostID = " + objProspect.ProspectID;
                        dtTotalSlots.DefaultView.RowFilter = "HostID = " + objProspect.ProspectID;
                        if (dtBookedSlots.DefaultView.Count > 0 && dtTotalSlots.DefaultView.Count > 0)
                        {
                            int ranking = (Convert.ToInt32(dtBookedSlots.DefaultView[0]["TotalBookedSlots"]) * 100) /
                                Convert.ToInt32(dtTotalSlots.DefaultView[0]["TotalSlots"]);
                            objProspect.Ranking = ranking;
                        }
                        else
                        {
                            objProspect.Ranking = -1;
                        }
                    }
                    else
                    {
                        objProspect.Ranking = -1;
                    }
                    objlProsect.Add(objProspect);
                }
            }
            return objlProsect;
        }

        public Boolean CheckDuplicateInvitationCode(string strCouponCode)
        {
            var arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@InvitationCode", SqlDbType.VarChar, 200);
            arParms[0].Value = strCouponCode;

            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.Bit);
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_checkDuplicateInvitationCode",
                arParms);
            var returnvalue = new Boolean();

            returnvalue = Convert.ToBoolean(arParms[1].Value);
            return returnvalue;
        }

        public Int64 SaveEventWizard(EEventWizard eevent, int Mode, string UserID, string Shell, string Role)
        {
            var returnvalue = new Int64();
            Int64 eventid = 0;

            //SqlTransaction sqltran = TransactionObject();
            try
            {
                var arParms = new SqlParameter[69];
                arParms[0] = new SqlParameter("@eventname", SqlDbType.VarChar, 500) { Value = eevent.Name };
                arParms[1] = new SqlParameter("@eventdate", SqlDbType.VarChar, 500) { Value = eevent.EventDate };

                arParms[2] = new SqlParameter("@eventstarttime", SqlDbType.VarChar, 500) { Value = eevent.EventStartTime };

                arParms[3] = new SqlParameter("@eventendtime", SqlDbType.VarChar, 500) { Value = eevent.EventEndTime };

                arParms[4] = new SqlParameter("@timezone", SqlDbType.VarChar, 500) { Value = eevent.TimeZone };

                arParms[5] = new SqlParameter("@hostid", SqlDbType.BigInt) { Value = eevent.Host.HostID };

                arParms[6] = new SqlParameter("@isrescheduled", SqlDbType.Bit) { Value = eevent.Rescheduled };

                arParms[7] = new SqlParameter("@InvitationCode", SqlDbType.VarChar, 255) { Value = eevent.InvitationCode };

                arParms[8] = new SqlParameter("@eventypeid", SqlDbType.BigInt) { Value = eevent.EventType.EventTypeID };

                arParms[9] = new SqlParameter("@costtousehostsite", SqlDbType.Decimal) { Value = eevent.CosttoUseHostSite };

                arParms[10] = new SqlParameter("@userid", SqlDbType.VarChar, 100) { Value = UserID };

                arParms[11] = new SqlParameter("@shell", SqlDbType.VarChar, 1000) { Value = Shell };

                arParms[12] = new SqlParameter("@role", SqlDbType.VarChar, 500) { Value = Role };

                arParms[13] = new SqlParameter("@returnvalue", SqlDbType.BigInt) { Direction = ParameterDirection.Output };

                arParms[14] = new SqlParameter("@eventid", SqlDbType.BigInt) { Value = eevent.EventID };

                arParms[15] = new SqlParameter("@communicationmodeid", SqlDbType.BigInt) { Value = eevent.CommunicationModeID };

                arParms[16] = new SqlParameter("@rowstateid", SqlDbType.TinyInt) { Value = Mode };

                arParms[17] = new SqlParameter("@scheduleTemplateID", SqlDbType.BigInt) { Value = eevent.ScheduleTemplateID };

                arParms[18] = new SqlParameter("@confirmminrequirement", SqlDbType.Bit) { Value = eevent.MinimumSiteRequirements };

                arParms[19] = new SqlParameter("@confirmedvisually", SqlDbType.Bit) { Value = eevent.ConfirmVisually };

                arParms[20] = new SqlParameter("@confirmedcomments", SqlDbType.VarChar, 5000)
                {
                    Value = eevent.ConfirmComments == null || eevent.ConfirmComments.Trim().Length < 1
                        ? (object)DBNull.Value
                        : eevent.ConfirmComments
                };


                arParms[21] = new SqlParameter("@schedulemethodid", SqlDbType.BigInt)
                {
                    Value = eevent.ScheduleMethodID
                };


                arParms[22] = new SqlParameter("@franchiseeid", SqlDbType.BigInt)
                {
                    Value = eevent.Franchisee != null && eevent.Franchisee.FranchiseeID > 0
                        ? (object)eevent.Franchisee.FranchiseeID
                        : DBNull.Value
                };


                arParms[23] = new SqlParameter("@franchiseefranchiseeuserid", SqlDbType.BigInt)
                {
                    Value =
                        eevent.FranchiseeFranchiseeUser != null &&
                            eevent.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID > 0
                            ? (object)eevent.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID
                            : DBNull.Value
                };


                arParms[24] = new SqlParameter("@eventactivitytemplateid", SqlDbType.BigInt)
                {
                    Value = eevent.EventActivityTemplateID > 0 ? (object)eevent.EventActivityTemplateID : DBNull.Value
                };

                arParms[25] = new SqlParameter("@TeamArrivalTime", SqlDbType.VarChar, 500) { Value = eevent.TeamArrivalTime };

                arParms[26] = new SqlParameter("@TeamDepartureTime", SqlDbType.VarChar, 500) { Value = eevent.TeamDepartureTime };


                arParms[27] = new SqlParameter("@PaymentTypeID", SqlDbType.BigInt)
                {
                    Value = eevent.PaymentTypeID > 0 ? (object)eevent.PaymentTypeID : DBNull.Value
                };


                arParms[28] = new SqlParameter("@IsActive", SqlDbType.VarChar, 500) { Value = eevent.Active };

                arParms[29] = new SqlParameter("@PaymentDueBy", SqlDbType.VarChar, 50)
                {
                    Value = !string.IsNullOrEmpty(eevent.PaymentDueDate)
                        ? (object)eevent.PaymentDueDate
                        : DBNull.Value
                };


                arParms[30] = new SqlParameter("@HSCSalesRepID", SqlDbType.BigInt)
                {
                    Value = eevent.HSCSalesRepID > 0
                        ? (object)eevent.HSCSalesRepID
                        : DBNull.Value
                };


                arParms[31] = new SqlParameter("@DepositDueBy", SqlDbType.VarChar, 50)
                {
                    Value = !string.IsNullOrEmpty(eevent.DepositDueDate)
                        ? (object)eevent.DepositDueDate
                        : DBNull.Value
                };

                arParms[32] = new SqlParameter("@DepositAmount", SqlDbType.Decimal) { Value = eevent.DepositAmount };

                arParms[33] = new SqlParameter("@PayByCheck", SqlDbType.Bit) { Value = eevent.PayByCheck };

                arParms[34] = new SqlParameter("@PayByCreditCard", SqlDbType.Bit) { Value = eevent.PayByCreditCard };

                arParms[35] = new SqlParameter("@eventnotes", SqlDbType.VarChar, 5000) { Value = eevent.Notes };

                arParms[36] = new SqlParameter("@EventStatus", SqlDbType.Int) { Value = eevent.EventStatus };

                arParms[37] = new SqlParameter("@UpdatedByOrganizationRoleUser", SqlDbType.BigInt) { Value = eevent.UpdatedByOrganizationRoleUser };

                arParms[38] = new SqlParameter("@InstructionForCallCenter", SqlDbType.VarChar, 5000)
                {
                    Value = !string.IsNullOrEmpty(eevent.InstructionForCallCenter)
                        ? (object)eevent.InstructionForCallCenter
                        : DBNull.Value
                };
                arParms[39] = new SqlParameter("@TaxIdNumber", SqlDbType.VarChar, 255) { Value = eevent.Host.TaxIdNumber };

                arParms[40] = new SqlParameter("@CooperateAccountId", SqlDbType.BigInt) { Value = eevent.CooperateAccountId };
                arParms[41] = new SqlParameter("@HospitalPartnerId", SqlDbType.BigInt) { Value = eevent.HospitalPartnerId };

                arParms[42] = new SqlParameter("@AttachHospitalMaterial", SqlDbType.Bit) { Value = eevent.AttachHospitalMaterial };

                arParms[43] = new SqlParameter("@EnableAlaCarteOnline", SqlDbType.Bit) { Value = eevent.EnableAlaCarteOnline };
                arParms[44] = new SqlParameter("@EnableAlaCarteCallCenter", SqlDbType.Bit) { Value = eevent.EnableAlaCarteCallCenter };
                arParms[45] = new SqlParameter("@EnableAlaCarteTechnician", SqlDbType.Bit) { Value = eevent.EnableAlaCarteTechnician };
                arParms[46] = new SqlParameter("@IsDynamicScheduling", SqlDbType.Bit) { Value = eevent.IsDynamicScheduling };
                arParms[47] = new SqlParameter("@SlotInterval", SqlDbType.Int) { Value = eevent.SlotInterval.HasValue && eevent.SlotInterval.Value > 0 ? (object)eevent.SlotInterval.Value : DBNull.Value };
                arParms[48] = new SqlParameter("@ServerRooms", SqlDbType.Int) { Value = eevent.ServerRooms.HasValue && eevent.ServerRooms.Value > 0 ? (object)eevent.ServerRooms.Value : DBNull.Value };
                arParms[49] = new SqlParameter("@LunchStartTime", SqlDbType.DateTime) { Value = eevent.LunchStartTime.HasValue ? (object)eevent.LunchStartTime.Value : DBNull.Value };
                arParms[50] = new SqlParameter("@LunchDuration", SqlDbType.Int) { Value = eevent.LunchDuration.HasValue && eevent.LunchDuration.Value > 0 ? (object)eevent.LunchDuration.Value : DBNull.Value };
                arParms[51] = new SqlParameter("@HafTemplateId", SqlDbType.Int) { Value = eevent.HealthAssessmentTemplateId.HasValue && eevent.HealthAssessmentTemplateId.Value > 0 ? (object)eevent.HealthAssessmentTemplateId.Value : DBNull.Value };

                arParms[52] = new SqlParameter("@CaptureInsuranceId", SqlDbType.Bit) { Value = eevent.CaptureInsuranceId };
                arParms[53] = new SqlParameter("@InsuranceIdRequired", SqlDbType.Bit) { Value = eevent.InsuranceIdRequired };
                arParms[54] = new SqlParameter("@EnableProduct", SqlDbType.Bit) { Value = eevent.EnableProduct };
                arParms[55] = new SqlParameter("@CaptureSsn", SqlDbType.Bit) { Value = eevent.CaptureSsn };
                arParms[56] = new SqlParameter("@IsFemaleOnly", SqlDbType.Bit) { Value = eevent.IsFemaleOnly };
                arParms[57] = new SqlParameter("@RecommendPackage", SqlDbType.Bit) { Value = eevent.RecommendPackage };
                arParms[58] = new SqlParameter("@AskPreQualificationQuestion", SqlDbType.Bit) { Value = eevent.AskPreQualificationQuestion };
                arParms[59] = new SqlParameter("@FixedGroupScreeningTime", SqlDbType.Int) { Value = eevent.FixedGroupScreeningTime.HasValue && eevent.FixedGroupScreeningTime.Value > 0 ? (object)eevent.FixedGroupScreeningTime.Value : DBNull.Value };
                arParms[60] = new SqlParameter("@RestrictEvaluation", SqlDbType.Bit) { Value = eevent.RestrictEvaluation };
                arParms[61] = new SqlParameter("@EventCancellationReasonId", SqlDbType.BigInt) { Value = eevent.EventCancellationReason.HasValue && eevent.EventCancellationReason.Value > 0 ? (object)eevent.EventCancellationReason.Value : DBNull.Value };
                arParms[62] = new SqlParameter("@EnableForCallCenter", SqlDbType.Bit) { Value = eevent.EnableForCallCenter };
                arParms[63] = new SqlParameter("@EnableForTechnician", SqlDbType.Bit) { Value = eevent.EnableForTechnician };
                arParms[64] = new SqlParameter("@IsPackageTimeOnly", SqlDbType.Bit) { Value = eevent.IsPackageTimeOnly };

                arParms[65] = new SqlParameter("@IsManual", SqlDbType.Bit) { Value = eevent.IsManual };
                
                arParms[66] = new SqlParameter("@UpdatedByAdmin", SqlDbType.BigInt)
                {
                    Value = eevent.UpdatedByAdmin.HasValue ? (object) eevent.UpdatedByAdmin.Value : DBNull.Value
                };

                arParms[67] = new SqlParameter("@AllowNonMammoPatients", SqlDbType.Bit) { Value = eevent.AllowNonMammoPatients };
                arParms[68] = new SqlParameter("@ProductType", SqlDbType.NVarChar) { Value = eevent.ProductType };

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveEventWizard", arParms);
                returnvalue = (Int64)arParms[13].Value;

                if (returnvalue == -1)
                {
                    //sqltran.Rollback();
                    return -1;
                }

                eventid = Mode == 0 ? returnvalue : eevent.EventID;

                if (eventid > 0)
                {
                    // Save Test Details
                    if (eevent.EventTest != null && eevent.EventTest.Count > 0)
                    {
                        SaveEventTestDetails(eevent.EventTest, Convert.ToInt32(eventid), null);
                    }
                    // delete all tests for event
                    else
                    {
                        string sqlquery = "delete from TblEventTest where EventID = @eventid";
                        var eventparam = new SqlParameter("@eventid", SqlDbType.BigInt);
                        eventparam.Value = eventid;
                        SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery, eventparam);
                    }

                    if (eevent.EventPackage != null && eevent.EventPackage.Count > 0)
                    {
                        SaveEventPackageDetails(eevent.EventPackage, Convert.ToInt32(eventid), null);
                    }
                    // delete all packages for event
                    else
                    {
                        string sqlquery = "delete from TblEventPackageTest where EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId = @eventid)";
                        var eventparam = new SqlParameter("@eventid", SqlDbType.BigInt);
                        eventparam.Value = eventid;
                        SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery, eventparam);

                        sqlquery = "delete from TblEventPackageDetails where EventID = @eventid";
                        eventparam = new SqlParameter("@eventid", SqlDbType.BigInt);
                        eventparam.Value = eventid;
                        SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery, eventparam);
                    }
                }
                //sqltran.Commit();
            }
            catch (Exception)
            {
                //sqltran.Rollback();
                return -1;
            }

            return eventid;
        }


        public Int64 DeleteEventAffiliateDetails(int EventID)
        {
            Int64 returnResult = 0;
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@EventID", SqlDbType.BigInt);
            arParms[1] = new SqlParameter("@returnresult", SqlDbType.BigInt);

            arParms[0].Value = EventID;
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_deleteEventAffilateDetails",
                arParms);
            returnResult = (Int64)arParms[1].Value;

            return returnResult;
        }

        private Int64 SaveEventPackageDetails(List<EEventPackage> objlEPackage, int eventID, SqlTransaction sqltran)
        {
            Int64 returnResult = 0;
            string packageIds = "";
            foreach (EEventPackage objEPackage in objlEPackage)
            {
                packageIds += objEPackage.Package.PackageID + ",";
            }
            packageIds = packageIds.Substring(0, packageIds.Length - 1);
            returnResult = DeleteEventPackageDetails(eventID, packageIds, sqltran);
            if (returnResult == 0)
            {
                return returnResult;
            }
            else
            {
                foreach (EEventPackage objEPackage in objlEPackage)
                {
                    var arParms = new SqlParameter[9];
                    arParms[0] = new SqlParameter("@EventID", SqlDbType.BigInt);
                    arParms[0].Value = eventID;
                    arParms[1] = new SqlParameter("@PackageID", SqlDbType.BigInt);
                    arParms[1].Value = objEPackage.Package.PackageID;
                    arParms[2] = new SqlParameter("@PackagePrice", SqlDbType.Decimal);
                    arParms[2].Value = objEPackage.Package.RecommendedPrice;
                    arParms[3] = new SqlParameter("@returnResult", SqlDbType.BigInt);
                    arParms[3].Direction = ParameterDirection.Output;
                    arParms[4] = new SqlParameter("@ScreeningTime", SqlDbType.Int);
                    arParms[4].Value = objEPackage.ScreeningTime > 0 ? (object)objEPackage.ScreeningTime : DBNull.Value;
                    arParms[5] = new SqlParameter("@IsRecommended", SqlDbType.Bit);
                    arParms[5].Value = objEPackage.IsRecommended;
                    arParms[6] = new SqlParameter("@MostPopular", SqlDbType.Bit);
                    arParms[6].Value = objEPackage.MostPopular;
                    arParms[7] = new SqlParameter("@BestValue", SqlDbType.Bit);
                    arParms[7].Value = objEPackage.BestValue;
                    arParms[8] = new SqlParameter("@PodRoomID", SqlDbType.BigInt);
                    arParms[8].Value = objEPackage.PodRoomID.HasValue ? (object)objEPackage.PodRoomID.Value : DBNull.Value;

                    if (sqltran == null)
                    {
                        SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                            "usp_saveEventPackageDetails", arParms);
                    }
                    else
                    {
                        SqlHelper.ExecuteNonQuery(sqltran, CommandType.StoredProcedure, "usp_saveEventPackageDetails",
                            arParms);
                    }
                    returnResult = Convert.ToInt64(arParms[3].Value);
                    if (returnResult == 0)
                    {
                        break;
                    }
                }
                return returnResult;
            }
        }

        private Int64 SaveEventTestDetails(List<ETest> tests, int eventID, SqlTransaction sqltran)
        {
            Int64 returnResult = 0;
            string testIds = "";
            foreach (ETest test in tests)
            {
                testIds += test.TestID + ",";
            }
            testIds = testIds.Substring(0, testIds.Length - 1);

            returnResult = DeleteEventTests(eventID, testIds, sqltran);

            if (returnResult == 0)
            {
                return returnResult;
            }
            foreach (ETest test in tests)
            {
                var arParms = new SqlParameter[7];
                arParms[0] = new SqlParameter("@EventID", SqlDbType.BigInt);
                arParms[0].Value = eventID;
                arParms[1] = new SqlParameter("@TestId", SqlDbType.BigInt);
                arParms[1].Value = test.TestID;
                arParms[2] = new SqlParameter("@TestPrice", SqlDbType.Decimal);
                arParms[2].Value = test.RecommendedPrice;
                arParms[3] = new SqlParameter("@returnResult", SqlDbType.BigInt);
                arParms[3].Direction = ParameterDirection.Output;
                arParms[4] = new SqlParameter("@ShowInAlaCarte", SqlDbType.Bit);
                arParms[4].Value = test.ShowInAlaCarte;
                arParms[5] = new SqlParameter("@ScreeningTime", SqlDbType.Int);
                arParms[5].Value = test.ScreeningTime >= 0 ? (object)test.ScreeningTime : DBNull.Value;
                arParms[6] = new SqlParameter("@WithPackagePrice", SqlDbType.Decimal);
                arParms[6].Value = test.WithPackagePrice;
                if (sqltran == null)
                {
                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                        "usp_saveEventTests", arParms);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(sqltran, CommandType.StoredProcedure, "usp_saveEventTests",
                        arParms);
                }
                returnResult = Convert.ToInt64(arParms[3].Value);
                if (returnResult == 0)
                {
                    break;
                }
            }
            return returnResult;
        }

        public Int64 DeleteEventTests(int eventID, string testIds, SqlTransaction sqltran)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@EventID", SqlDbType.BigInt);
            arParms[0].Value = eventID;
            arParms[1] = new SqlParameter("@returnResult", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            arParms[2] = new SqlParameter("@TestIds", SqlDbType.VarChar, 1000);
            arParms[2].Value = testIds;
            if (sqltran == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_deleteEventTests",
                    arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqltran, CommandType.StoredProcedure, "usp_deleteEventTests", arParms);
            }
            Int64 returnResult = Convert.ToInt64(arParms[1].Value);
            return returnResult;
        }

        public Int64 DeleteEventPackageDetails(int eventID, string packageIds, SqlTransaction sqltran)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@EventID", SqlDbType.BigInt);
            arParms[0].Value = eventID;
            arParms[1] = new SqlParameter("@returnResult", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            arParms[2] = new SqlParameter("@PackageIds", SqlDbType.VarChar, 1000);
            arParms[2].Value = packageIds;
            if (sqltran == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                    "usp_deleteEventPackageDetails",
                    arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqltran, CommandType.StoredProcedure, "usp_deleteEventPackageDetails", arParms);
            }
            Int64 returnResult = Convert.ToInt64(arParms[1].Value);
            return returnResult;
        }

        public DataSet GetPodCalendarDetailsByPodID(int podid, string startdate, string enddate)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@PodID", SqlDbType.BigInt);
            arParms[0].Value = podid;
            arParms[1] = new SqlParameter("@StartDate", SqlDbType.VarChar, 50);
            arParms[1].Value = startdate;
            arParms[2] = new SqlParameter("enddate", SqlDbType.VarChar, 50);
            arParms[2].Value = enddate;

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getPodCalendarDetailsByPodID", arParms);
            return ds;
        }


        public int SavePrintOrderDetails(long AffiliateId, long eventId, string Address1, string Address2, string city,
            string state, long zipCode, string firstName, string middleName, string lastName, long addedByUserId)
        {
            int returnValue;
            var arParms = new SqlParameter[12];

            arParms[0] = new SqlParameter("@AffiliateId", SqlDbType.BigInt);
            arParms[0].Value = AffiliateId;

            arParms[1] = new SqlParameter("@eventId", SqlDbType.BigInt);
            arParms[1].Value = eventId;

            arParms[2] = new SqlParameter("@Address1", SqlDbType.VarChar, 255);
            arParms[2].Value = Address1;

            arParms[3] = new SqlParameter("@Address2", SqlDbType.VarChar, 255);
            arParms[3].Value = Address2;

            arParms[4] = new SqlParameter("@city", SqlDbType.VarChar, 100);
            arParms[4].Value = city;

            arParms[5] = new SqlParameter("@state", SqlDbType.VarChar, 100);
            arParms[5].Value = state;

            arParms[6] = new SqlParameter("@zipcode", SqlDbType.BigInt);
            arParms[6].Value = zipCode;

            arParms[7] = new SqlParameter("@firstName", SqlDbType.VarChar, 100);
            arParms[7].Value = firstName;

            arParms[8] = new SqlParameter("@middleName", SqlDbType.VarChar, 100);
            arParms[8].Value = middleName;

            arParms[9] = new SqlParameter("@lastName", SqlDbType.VarChar, 100);
            arParms[9].Value = lastName;

            arParms[10] = new SqlParameter("@addedByUserId", SqlDbType.BigInt);
            arParms[10].Value = addedByUserId;

            arParms[11] = new SqlParameter("@returnValue", SqlDbType.Int);
            arParms[11].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                "usp_UpdateContactAddressForPrintOrderDetails", arParms);
            returnValue = (Int32)arParms[11].Value;

            return returnValue;
        }


        public EEventWizard GetEventWizardDetails(int eventID)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@EventID", SqlDbType.BigInt);
            arParms[0].Value = eventID;

            var ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(_connectionString, "usp_getEventWizardDetails",
                arParms);
            var objEventWizard = new EEventWizard();
            if (ds != null && ds.Tables.Count > 4)
            {
                DataTable dtEventDetails = ds.Tables[0];
                DataTable dtEventTask = ds.Tables[1];
                DataTable dtEventPackage = ds.Tables[2];
                DataTable dtEventPod = ds.Tables[3];
                DataTable dteventTests = ds.Tables[4];

                if (dtEventDetails.Rows.Count > 0)
                {
                    objEventWizard.EventID = Convert.ToInt32(dtEventDetails.Rows[0]["EventID"]);
                    objEventWizard.Host = new EHost();
                    objEventWizard.Host.HostID = Convert.ToInt32(dtEventDetails.Rows[0]["HostID"]);
                    objEventWizard.CosttoUseHostSite = Convert.ToSingle(dtEventDetails.Rows[0]["CosttoUseHostSite"]);
                    objEventWizard.PaymentTypeID = Convert.ToInt32(dtEventDetails.Rows[0]["PaymentTypeID"]);
                    objEventWizard.ScheduleMethodID = Convert.ToInt32(dtEventDetails.Rows[0]["ScheduleMethodID"]);
                    objEventWizard.CommunicationModeID = Convert.ToInt32(dtEventDetails.Rows[0]["CommunicationModeID"]);
                    objEventWizard.MinimumSiteRequirements =
                        Convert.ToBoolean(dtEventDetails.Rows[0]["bConfirmMinRequirements"]);
                    objEventWizard.ConfirmVisually = Convert.ToBoolean(dtEventDetails.Rows[0]["bConfirmedVisually"]);
                    objEventWizard.ConfirmComments =
                        Convert.ToString(dtEventDetails.Rows[0]["ConfirmedVisuallyComments"]);
                    objEventWizard.ScheduleTemplateID = Convert.ToInt32(dtEventDetails.Rows[0]["ScheduleTemplateID"]);
                    objEventWizard.EventType = new EEventType();
                    objEventWizard.EventType.EventTypeID = Convert.ToInt32(dtEventDetails.Rows[0]["EventTypeID"]);
                    objEventWizard.Active = Convert.ToBoolean(dtEventDetails.Rows[0]["IsActive"]);
                    objEventWizard.EventDate = Convert.ToString(dtEventDetails.Rows[0]["EventDate"]);
                    objEventWizard.TimeZone = Convert.ToString(dtEventDetails.Rows[0]["TimeZone"]);
                    objEventWizard.InvitationCode = Convert.ToString(dtEventDetails.Rows[0]["InvitationCode"]);
                    objEventWizard.EventStartTime = Convert.ToString(dtEventDetails.Rows[0]["EventStartTime"]);
                    objEventWizard.EventEndTime = Convert.ToString(dtEventDetails.Rows[0]["EventEndTime"]);
                    objEventWizard.TeamArrivalTime = Convert.ToString(dtEventDetails.Rows[0]["TeamArrivalTime"]);
                    objEventWizard.TeamDepartureTime = Convert.ToString(dtEventDetails.Rows[0]["TeamDepartureTime"]);
                    objEventWizard.Franchisee = new EFranchisee();
                    objEventWizard.Franchisee.FranchiseeID = Convert.ToInt32(dtEventDetails.Rows[0]["FranchiseeID"]);
                    objEventWizard.FranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser();
                    objEventWizard.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID =
                        Convert.ToInt32(dtEventDetails.Rows[0]["SalesRepID"]);
                    objEventWizard.EventActivityTemplateID =
                        Convert.ToInt32(dtEventDetails.Rows[0]["EventActivityTemplateID"]);
                    objEventWizard.HSCSalesRepID = Convert.ToInt32(dtEventDetails.Rows[0]["EventActivitySalesRep"]);
                    objEventWizard.EventStatus = Convert.ToInt32(dtEventDetails.Rows[0]["EventStatus"]);
                    objEventWizard.Notes = Convert.ToString(dtEventDetails.Rows[0]["EventNotes"]);
                    objEventWizard.InstructionForCallCenter =
                        Convert.ToString(dtEventDetails.Rows[0]["InstructionForCallCenter"]);
                    objEventWizard.CooperateAccountId =
                        Convert.ToInt64(dtEventDetails.Rows[0]["AccountID"]);
                    objEventWizard.HospitalPartnerId =
                        Convert.ToInt64(dtEventDetails.Rows[0]["HospitalPartnerID"]);
                    objEventWizard.TerritoryId = Convert.ToInt64(dtEventDetails.Rows[0]["TerritoryId"]);
                    objEventWizard.AttachHospitalMaterial = Convert.ToBoolean(dtEventDetails.Rows[0]["AttachHospitalMaterial"]);
                    objEventWizard.EnableAlaCarteOnline = Convert.ToBoolean(dtEventDetails.Rows[0]["EnableAlaCarteOnline"]);
                    objEventWizard.EnableAlaCarteCallCenter = Convert.ToBoolean(dtEventDetails.Rows[0]["EnableAlaCarteCallCenter"]);
                    objEventWizard.EnableAlaCarteTechnician = Convert.ToBoolean(dtEventDetails.Rows[0]["EnableAlaCarteTechnician"]);
                    objEventWizard.IsDynamicScheduling = Convert.ToBoolean(dtEventDetails.Rows[0]["IsDynamicScheduling"]);
                    objEventWizard.SlotInterval = Convert.ToInt32(dtEventDetails.Rows[0]["SlotInterval"]);
                    objEventWizard.ServerRooms = Convert.ToInt32(dtEventDetails.Rows[0]["ServerRooms"]);
                    if (dtEventDetails.Rows[0]["LunchStartTime"] != DBNull.Value)
                    {
                        objEventWizard.LunchStartTime = Convert.ToDateTime(dtEventDetails.Rows[0]["LunchStartTime"]);
                    }
                    objEventWizard.LunchDuration = Convert.ToInt32(dtEventDetails.Rows[0]["LunchDuration"]);
                    objEventWizard.HealthAssessmentTemplateId = Convert.ToInt32(dtEventDetails.Rows[0]["HAFTemplateId"]);
                    objEventWizard.CaptureInsuranceId = Convert.ToBoolean(dtEventDetails.Rows[0]["CaptureInsuranceId"]);
                    objEventWizard.InsuranceIdRequired = Convert.ToBoolean(dtEventDetails.Rows[0]["InsuranceIdRequired"]);
                    objEventWizard.EnableProduct = Convert.ToBoolean(dtEventDetails.Rows[0]["EnableProduct"]);
                    objEventWizard.CaptureSsn = Convert.ToBoolean(dtEventDetails.Rows[0]["CaptureSsn"]);
                    objEventWizard.IsFemaleOnly = Convert.ToBoolean(dtEventDetails.Rows[0]["IsFemaleOnly"]);
                    objEventWizard.AllowNonMammoPatients = Convert.ToBoolean(dtEventDetails.Rows[0]["AllowNonMammoPatients"]);
                    objEventWizard.RecommendPackage = Convert.ToBoolean(dtEventDetails.Rows[0]["RecommendPackage"]);
                    objEventWizard.AskPreQualificationQuestion = Convert.ToBoolean(dtEventDetails.Rows[0]["AskPreQualifierQuestion"]);
                    objEventWizard.FixedGroupScreeningTime = Convert.ToInt32(dtEventDetails.Rows[0]["FixedGroupScreeningTime"]);
                    objEventWizard.RestrictEvaluation = Convert.ToBoolean(dtEventDetails.Rows[0]["RestrictEvaluation"]);
                    objEventWizard.EnableForCallCenter = Convert.ToBoolean(dtEventDetails.Rows[0]["EnableForCallCenter"]);
                    objEventWizard.EnableForTechnician = Convert.ToBoolean(dtEventDetails.Rows[0]["EnableForTechnician"]);
                    objEventWizard.ProductType = Convert.ToString(dtEventDetails.Rows[0]["ProductType"]);

                    if (dtEventDetails.Rows[0]["EventCancellationReasonId"] != DBNull.Value)
                    {
                        objEventWizard.EventCancellationReason = Convert.ToInt64(dtEventDetails.Rows[0]["EventCancellationReasonId"]);
                    }
                    
                    objEventWizard.IsPackageTimeOnly = Convert.ToBoolean(dtEventDetails.Rows[0]["IsPackageTimeOnly"]);
                    objEventWizard.IsLock = Convert.ToBoolean(dtEventDetails.Rows[0]["IsLocked"]);
                    objEventWizard.IsManual = Convert.ToBoolean(dtEventDetails.Rows[0]["IsManual"]);

                    if (dtEventDetails.Rows[0]["UpdatedByAdmin"] != DBNull.Value)
                    {
                        objEventWizard.UpdatedByAdmin = Convert.ToInt64(dtEventDetails.Rows[0]["UpdatedByAdmin"]);
                    }

                }
                if (dtEventTask.Rows.Count > 0)
                {
                    dtEventTask.DefaultView.RowFilter = "EventID = " + objEventWizard.EventID;
                    if (dtEventTask.DefaultView.Count > 0)
                    {
                        objEventWizard.PaymentDueDate = dtEventTask.DefaultView[0]["PaymentDueDate"].ToString();
                        objEventWizard.DepositDueDate = dtEventTask.DefaultView[0]["DepositDueDate"].ToString();
                        objEventWizard.PayByCheck = Convert.ToBoolean(dtEventTask.DefaultView[0]["PayByCheck"]);
                        objEventWizard.PayByCreditCard = Convert.ToBoolean(dtEventTask.DefaultView[0]["PayByCreditCard"]);
                        objEventWizard.DepositAmount = Convert.ToSingle(dtEventTask.DefaultView[0]["DepositAmount"]);
                    }
                }
                if (dtEventPackage.Rows.Count > 0)
                {
                    dtEventPackage.DefaultView.RowFilter = "EventID = " + objEventWizard.EventID;
                    if (dtEventPackage.DefaultView.Count > 0)
                    {
                        var objlEPackge = new List<EEventPackage>();
                        for (int count = 0; count < dtEventPackage.DefaultView.Count; count++)
                        {
                            var objEPackage = new EEventPackage();
                            objEPackage.PackagePrice = Convert.ToSingle(dtEventPackage.DefaultView[count]["PackagePrice"]);
                            objEPackage.Package = new EPackage();
                            objEPackage.Package.PackageID = Convert.ToInt32(dtEventPackage.DefaultView[count]["PackageID"]);
                            objEPackage.Package.PackageName = Convert.ToString(dtEventPackage.DefaultView[count]["PackageName"]);
                            objEPackage.ScreeningTime = Convert.ToInt32(dtEventPackage.DefaultView[count]["ScreeningTime"]);
                            objEPackage.Gender = Convert.ToInt64(dtEventPackage.DefaultView[count]["Gender"]);
                            objEPackage.IsRecommended = Convert.ToBoolean(dtEventPackage.DefaultView[count]["IsRecommended"]);
                            objEPackage.MostPopular = Convert.ToBoolean(dtEventPackage.DefaultView[count]["MostPopular"]);
                            objEPackage.BestValue = Convert.ToBoolean(dtEventPackage.DefaultView[count]["BestValue"]);
                            if (dtEventPackage.DefaultView[count]["PodRoomID"] != DBNull.Value)
                            {
                                objEPackage.PodRoomID = Convert.ToInt64(dtEventPackage.DefaultView[count]["PodRoomID"]);
                            }
                            objlEPackge.Add(objEPackage);
                        }
                        objEventWizard.EventPackage = objlEPackge;
                    }
                }
                if (dtEventPod.Rows.Count > 0)
                {
                    var lsteventpod = new List<EEventPod>();
                    dtEventPod.DefaultView.RowFilter = "EventID=" + objEventWizard.EventID;
                    for (int jcount = 0; jcount < dtEventPod.DefaultView.Count; jcount++)
                    {
                        var objeventpod = new EEventPod();
                        objeventpod.EventID = Convert.ToInt32(dtEventPod.DefaultView[jcount]["EventID"]);
                        objeventpod.Pod = new EPod();
                        objeventpod.Pod.PodID = Convert.ToInt32(dtEventPod.DefaultView[jcount]["PodID"]);
                        objeventpod.Pod.Name = Convert.ToString(dtEventPod.DefaultView[jcount]["Name"]);
                        objeventpod.Pod.Description = Convert.ToString(dtEventPod.DefaultView[jcount]["Description"]);
                        objeventpod.Pod.Van = new EVan();
                        objeventpod.Pod.Van.Name = Convert.ToString(dtEventPod.DefaultView[jcount]["VanName"]);
                        objeventpod.Pod.Van.RegistrationNumber =
                            Convert.ToString(dtEventPod.DefaultView[jcount]["RegistrationNumber"]);
                        objeventpod.Pod.Van.Make = Convert.ToString(dtEventPod.DefaultView[jcount]["Make"]);
                        objeventpod.EventPodID = Convert.ToInt32(dtEventPod.DefaultView[jcount]["EventPodID"]);

                        lsteventpod.Add(objeventpod);
                    }
                    objEventWizard.EventPod = lsteventpod;
                }
                objEventWizard.EventTest = new List<ETest>();
                for (int count = 0; count < dteventTests.DefaultView.Count; count++)
                {
                    var test = new ETest
                    {
                        Name = Convert.ToString(dteventTests.DefaultView[count]["Name"]),
                        TestID = Convert.ToInt32(dteventTests.DefaultView[count]["TestId"]),
                        Description = Convert.ToString(dteventTests.DefaultView[count]["Description"]),
                        RecommendedPrice = Convert.ToSingle(dteventTests.DefaultView[count]["Price"]),
                        ShowInAlaCarte = Convert.ToBoolean(dteventTests.DefaultView[count]["ShowInAlaCarte"]),
                        ScreeningTime = Convert.ToInt32(dteventTests.DefaultView[count]["ScreeningTime"]),
                        WithPackagePrice = Convert.ToDecimal(dteventTests.DefaultView[count]["WithPackagePrice"]),
                    };
                    objEventWizard.EventTest.Add(test);
                }
            }
            return objEventWizard;
        }

        public Int64 SaveEventSalesRepAsAdvocate(int eventID)
        {
            var arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@EventID", SqlDbType.BigInt);
            arParms[0].Value = eventID;
            arParms[1] = new SqlParameter("@returnResult", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveEventSalesRepAsAdvocate",
                arParms);
            Int64 returnResult = Convert.ToInt64(arParms[1].Value);
            return returnResult;
        }

        public void DeleteAllPrintOrderItems(int eventId)
        {
            var arParm = new SqlParameter[1];
            arParm[0] = new SqlParameter("@EventID", SqlDbType.BigInt);
            arParm[0].Value = eventId;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_deleteAllPrintOrderItems",
                arParm);
        }

        public int DeletePrintOrderItem(int eventCampaignId)
        {
            var arParm = new SqlParameter[2];
            arParm[0] = new SqlParameter("@EventCampaignID", SqlDbType.BigInt);
            arParm[0].Value = eventCampaignId;

            arParm[1] = new SqlParameter("@returnResult", SqlDbType.Int);
            arParm[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_deletePrintOrderItem", arParm);
            return Convert.ToInt32(arParm[1].Value);
        }

        public string CheckPackageTestDependencyRule(string packageIds, string testIds)
        {
            string testIdsNotSelected = string.Empty;

            var arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@packageIds", SqlDbType.VarChar, 500);
            arParms[0].Value = packageIds;

            arParms[1] = new SqlParameter("@testIds", SqlDbType.VarChar, 500);
            arParms[1].Value = testIds;

            arParms[2] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[2].Value = 0;


            DataSet testIdsDataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_CheckPackageTest", arParms);

            if (testIdsDataset != null && testIdsDataset.Tables.Count > 0)
            {
                for (int count = 0; count < testIdsDataset.Tables[0].Rows.Count; count++)
                {
                    testIdsNotSelected = testIdsNotSelected +
                        Convert.ToString(testIdsDataset.Tables[0].Rows[count]["TestId"]) + ",";
                }
            }
            if (!string.IsNullOrEmpty(testIdsNotSelected))
            {
                testIdsNotSelected = testIdsNotSelected.Substring(0, testIdsNotSelected.Length - 1);
            }

            return testIdsNotSelected;
        }

        public List<ETest> CheckDependentOnTests(string testIds)
        {
            var testList = new List<ETest>();

            string previousTestName = string.Empty;
            var arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@packageIds", SqlDbType.VarChar, 500);
            arParms[0].Value = "";

            arParms[1] = new SqlParameter("@testIds", SqlDbType.VarChar, 500);
            arParms[1].Value = testIds;

            arParms[2] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[2].Value = 1;

            DataSet testDepedentTests = SqlHelper.ExecuteDataset(_connectionString,
                "usp_CheckPackageTest", arParms);

            if (testDepedentTests != null && testDepedentTests.Tables.Count > 0)
            {
                for (int count = 0; count < testDepedentTests.Tables[0].Rows.Count; count++)
                {
                    var test = new ETest();
                    test.TestID = Convert.ToInt32(testDepedentTests.Tables[0].Rows[count]["TestId"]);
                    test.Name = Convert.ToString(testDepedentTests.Tables[0].Rows[count]["TestName"]);
                    test.Description = Convert.ToString(testDepedentTests.Tables[0].Rows[count]["DependentTestName"]);
                    testList.Add(test);
                }
            }
            return testList;
        }

        # endregion

        #region TaskStatusType

        public List<ETaskStatusType> GetTaskStatusType(string filterString, int mode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_gettaskstatustype", arParms);

            var returnTaskType = new List<ETaskStatusType>();
            returnTaskType = ParseTaskStatusTypeDataSet(tempdataset);
            return returnTaskType;
        }

        private List<ETaskStatusType> ParseTaskStatusTypeDataSet(DataSet taskstatustypeDataSet)
        {
            var returnTaskType = new List<ETaskStatusType>();

            for (int count = 0; count < taskstatustypeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var taskstatus = new ETaskStatusType();
                    taskstatus.Active = Convert.ToBoolean(taskstatustypeDataSet.Tables[0].Rows[count]["IsActive"]);
                    taskstatus.TaskStatusTypeID =
                        Convert.ToInt32(taskstatustypeDataSet.Tables[0].Rows[count]["TaskStatusID"]);
                    taskstatus.Description = Convert.ToString(taskstatustypeDataSet.Tables[0].Rows[count]["Description"]);
                    taskstatus.Name = Convert.ToString(taskstatustypeDataSet.Tables[0].Rows[count]["Name"]);
                    returnTaskType.Add(taskstatus);
                }
                catch
                { }
            }
            return returnTaskType;
        }

        #endregion

        #region TaskPriorityType

        public List<ETaskPriorityType> GetTaskPriorityType(string filterString, int mode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_gettaskprioritytype", arParms);

            var returnTaskpriorityType = new List<ETaskPriorityType>();
            returnTaskpriorityType = ParseTaskPriorityTypeDataSet(tempdataset);
            return returnTaskpriorityType;
        }

        private List<ETaskPriorityType> ParseTaskPriorityTypeDataSet(DataSet taskprioritytypeDataSet)
        {
            var returnTaskpriorityType = new List<ETaskPriorityType>();

            for (int count = 0; count < taskprioritytypeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var taskpriority = new ETaskPriorityType();
                    taskpriority.Active = Convert.ToBoolean(taskprioritytypeDataSet.Tables[0].Rows[count]["IsActive"]);
                    taskpriority.TaskPriorityTypeID =
                        Convert.ToInt32(taskprioritytypeDataSet.Tables[0].Rows[count]["TaskPriorityID"]);
                    taskpriority.Description =
                        Convert.ToString(taskprioritytypeDataSet.Tables[0].Rows[count]["Description"]);
                    taskpriority.Name = Convert.ToString(taskprioritytypeDataSet.Tables[0].Rows[count]["Name"]);
                    returnTaskpriorityType.Add(taskpriority);
                }
                catch
                { }
            }
            return returnTaskpriorityType;
        }

        #endregion

        #region CallStatus

        public List<ECallStatus> GetCallStatusType(string filterString, int mode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getcallstatus",
                arParms);

            var returnCallStatus = new List<ECallStatus>();
            returnCallStatus = ParseCallStatusDataSet(tempdataset);
            return returnCallStatus;
        }

        private List<ECallStatus> ParseCallStatusDataSet(DataSet CallStatusDataSet)
        {
            var returnCallStatus = new List<ECallStatus>();

            for (int count = 0; count < CallStatusDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var CallStatus = new ECallStatus();
                    CallStatus.CallActive = Convert.ToBoolean(CallStatusDataSet.Tables[0].Rows[count]["IsActive"]);
                    CallStatus.CallStatusID =
                        Convert.ToInt32(CallStatusDataSet.Tables[0].Rows[count]["ContactCallStatusID"]);
                    CallStatus.Status = Convert.ToString(CallStatusDataSet.Tables[0].Rows[count]["Status"]);
                    returnCallStatus.Add(CallStatus);
                }
                catch
                { }
            }
            return returnCallStatus;
        }

        /// <summary>
        /// this routine update the status of call with specified id to held
        /// </summary>
        /// <param name="contactcallid"></param>
        /// <param name="Mode"></param>
        /// <returns></returns>
        public Int64 ChangeCallStatus(int contactcallid, int Mode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@contactcallid", SqlDbType.BigInt);
            arParms[0].Value = contactcallid;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removecall", arParms);
            returnvalue = (Int64)arParms[2].Value;

            return returnvalue;
        }

        #endregion

        #region "Coupon"

        public List<ECouponType> GetCouponType(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getcoupontype",
                arParms);

            var returnCouponType = new List<ECouponType>();
            if (tempdataset == null)
            {
                return returnCouponType;
            }


            returnCouponType = ParseCouponTypeDataSet(tempdataset);


            return returnCouponType;
        }

        private List<ECouponType> ParseCouponTypeDataSet(DataSet CouponTypeDataSet)
        {
            var returnCouponType = new List<ECouponType>();

            for (int count = 0; count < CouponTypeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var CouponType = new ECouponType();
                    CouponType.Active = Convert.ToBoolean(CouponTypeDataSet.Tables[0].Rows[count]["IsActive"]);
                    CouponType.CouponTypeID = Convert.ToInt32(CouponTypeDataSet.Tables[0].Rows[count]["CouponTypeID"]);
                    CouponType.Description = Convert.ToString(CouponTypeDataSet.Tables[0].Rows[count]["Description"]);
                    CouponType.Name = Convert.ToString(CouponTypeDataSet.Tables[0].Rows[count]["Name"]);
                    CouponType.EventCoupon = Convert.ToBoolean(CouponTypeDataSet.Tables[0].Rows[count]["IsEventCoupon"]);

                    returnCouponType.Add(CouponType);
                }
                catch
                { }
            }
            return returnCouponType;
        }

        public Boolean CheckCouponCode(string strCouponCode)
        {
            var arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@couponcode", SqlDbType.VarChar, 200);
            arParms[0].Value = strCouponCode;

            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_checkcouponcode", arParms);

            return Convert.ToBoolean(arParms[1].Value);
        }

        /// <summary>
        /// Inserts or Updates  marketing offer
        /// </summary>
        public Int64 SaveMarketingOffer(EMarketingOffer objMarketingOffer, int Mode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[19];

            arParms[0] = new SqlParameter("@marketingoffertypeid", SqlDbType.BigInt);
            arParms[0].Value = objMarketingOffer.MarketingOfferType.MarketingOfferTypeID;
            arParms[1] = new SqlParameter("@isglobal", SqlDbType.Bit);
            arParms[1].Value = objMarketingOffer.IsGlobal;
            arParms[2] = new SqlParameter("@ispercentage", SqlDbType.Bit);
            arParms[2].Value = objMarketingOffer.IsPercentage;
            arParms[3] = new SqlParameter("@marketingoffervalue", SqlDbType.Decimal, 18);
            arParms[3].Value = objMarketingOffer.MarketingOfferValue;

            arParms[4] = new SqlParameter("@marketingofferdescription", SqlDbType.VarChar, 100);
            arParms[4].Value = objMarketingOffer.MarketingOfferDes;

            arParms[5] = new SqlParameter("@isfree", SqlDbType.Bit);
            arParms[5].Value = objMarketingOffer.IsFree;
            arParms[6] = new SqlParameter("@iseventbased", SqlDbType.Bit);
            arParms[6].Value = objMarketingOffer.IsEventBased;
            arParms[7] = new SqlParameter("@minimumpurchaseamount", SqlDbType.Decimal, 18);
            arParms[7].Value = objMarketingOffer.MinPurchaseAmount;
            arParms[8] = new SqlParameter("@createduserid", SqlDbType.BigInt);
            arParms[8].Value = objMarketingOffer.CreatedbyUserID;
            arParms[9] = new SqlParameter("@validitystartdate", SqlDbType.DateTime);
            if ((objMarketingOffer.ValidityStartDate == null) || (objMarketingOffer.ValidityStartDate == string.Empty))
            {
                objMarketingOffer.ValidityStartDate = DateTime.Now.ToShortDateString();
            }

            arParms[9].Value = objMarketingOffer.ValidityStartDate;

            arParms[10] = new SqlParameter("@validityenddate", SqlDbType.DateTime);
            arParms[10].Value = objMarketingOffer.ValidityEndDate;
            arParms[11] = new SqlParameter("@isactive", SqlDbType.Bit);
            arParms[11].Value = objMarketingOffer.Active;
            arParms[12] = new SqlParameter("@maximumnumbertimesused", SqlDbType.Int);
            arParms[12].Value = objMarketingOffer.MaximumNumberTimesUsed;
            arParms[13] = new SqlParameter("@marketingoffercode", SqlDbType.VarChar, 50);
            arParms[13].Value = objMarketingOffer.MarketingOffer;
            arParms[14] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[14].Value = Mode;

            arParms[15] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[15].Direction = ParameterDirection.Output;
            arParms[16] = new SqlParameter("@marketingofferid", SqlDbType.BigInt);
            arParms[16].Value = objMarketingOffer.MarketingOfferID;

            arParms[17] = new SqlParameter("@customerrange", SqlDbType.TinyInt);
            arParms[17].Value = objMarketingOffer.CustomerRange;

            arParms[18] = new SqlParameter("@DiscountType", SqlDbType.Bit);
            arParms[18].Value = objMarketingOffer.IsDiscountTypePackageWise;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveMarketingOffer", arParms);
            returnvalue = (Int64)arParms[15].Value;

            if (objMarketingOffer.ListSignUpMode != null && objMarketingOffer.ListSignUpMode.Count > 0)
            {
                SaveMarkettingOfferSignUpMode(objMarketingOffer.ListSignUpMode, returnvalue);
            }

            if (objMarketingOffer.ListRole != null && objMarketingOffer.ListRole.Count > 0)
            {
                SaveMarkettingOfferRole(objMarketingOffer.ListRole, returnvalue);
            }

            // Insert/Updates event coupon mapping table
            if (objMarketingOffer.EventMarketingOffer != null)
            {
                SaveEventMarketingOffer(objMarketingOffer.EventMarketingOffer, returnvalue, Mode);
            }
            if (objMarketingOffer.IsEventBased == false)
            {
                SaveEventMarketingOffer(returnvalue, Mode);
            }

            if (objMarketingOffer.MarketingOfferRole != null)
            {
                SaveMarketingOfferRole(objMarketingOffer.MarketingOfferRole, returnvalue);
            }


            // Update Package Coupon mapping records 
            if (objMarketingOffer.IsDiscountTypePackageWise &&
                objMarketingOffer.PackageMarketingOfferDiscount != null)
            {
                // Inserts new records or Updates the existing ones
                SavePackageMarketingOfferDiscountMapping(objMarketingOffer.PackageMarketingOfferDiscount,
                    Convert.ToInt32(returnvalue));
            }
            else if (objMarketingOffer.MarketingOfferID > 0 && objMarketingOffer.IsDiscountTypePackageWise == false)
            {
                // Deactivates all the records if Discount Type is different now
                string sqlquery =
                    "Update [TblPackageMarketingOfferDiscount] set isactive = 0 where [MarketingOfferID] = " +
                        objMarketingOffer.MarketingOfferID;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery);
            }

            return returnvalue;
        }

        public Int64 SaveMarketingOfferRole(List<EMarketingOfferRole> MarketingOfferRole, Int64 iMarketingOfferId)
        {
            var returnvalue = new Int64();
            for (int icount = 0; icount < MarketingOfferRole.Count; icount++)
            {
                var arParms = new SqlParameter[4];
                arParms[0] = new SqlParameter("@marketingOfferId", SqlDbType.BigInt);
                arParms[0].Value = iMarketingOfferId;
                arParms[1] = new SqlParameter("@roleId", SqlDbType.BigInt);
                arParms[1].Value = MarketingOfferRole[icount].RoleID;
                arParms[2] = new SqlParameter("@rowstate", SqlDbType.Int);
                arParms[2].Value = MarketingOfferRole[icount].RowState;
                ;
                arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveMarketingOfferRole",
                    arParms);
                returnvalue = (Int64)arParms[3].Value;
            }

            return returnvalue;
        }


        public Int64 SaveEventMarketingOffer(List<EEventMarketingOffer> EventMarketingOffer, Int64 intMarketingOfferId,
            int Mode)
        {
            var returnvalue = new Int64();
            for (int icount = 0; icount < EventMarketingOffer.Count; icount++)
            {
                var arParms = new SqlParameter[7];
                arParms[0] = new SqlParameter("@eventmarketingofferid", SqlDbType.BigInt);
                arParms[0].Value = EventMarketingOffer[icount].EventMarketingOfferID;
                arParms[1] = new SqlParameter("@eventid", SqlDbType.BigInt);
                arParms[1].Value = EventMarketingOffer[icount].Event.EventID;
                arParms[2] = new SqlParameter("@MarketingOfferid", SqlDbType.BigInt);
                arParms[2].Value = intMarketingOfferId;
                arParms[3] = new SqlParameter("@numberoftimeused", SqlDbType.BigInt);
                arParms[3].Value = EventMarketingOffer[icount].NoOfTimeUsed;
                arParms[4] = new SqlParameter("@isactive", SqlDbType.Bit);
                arParms[4].Value = EventMarketingOffer[icount].Active;
                arParms[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[5].Direction = ParameterDirection.Output;
                arParms[6] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[6].Value = Mode;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventmarketingoffer",
                    arParms);
                returnvalue = (Int64)arParms[5].Value;
            }

            return returnvalue;
        }


        private void SavePackageMarketingOfferDiscountMapping(
            List<EPackageMarketingOfferMapping> lstPackageMarketingOfferMapping, Int64 marketingOfferid)
        {
            var arparams = new SqlParameter[5];

            arparams[0] = new SqlParameter("@packageid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@marketingofferid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@discountamount", SqlDbType.Decimal);
            arparams[3] = new SqlParameter("@ispercentage", SqlDbType.Bit);
            arparams[4] = new SqlParameter("@returnvalue", SqlDbType.Int);
            arparams[4].Direction = ParameterDirection.Output;

            for (int icount = 0; icount < lstPackageMarketingOfferMapping.Count; icount++)
            {
                arparams[0].Value = lstPackageMarketingOfferMapping[icount].PackageID;
                arparams[1].Value = marketingOfferid;
                arparams[2].Value = lstPackageMarketingOfferMapping[icount].DiscountAmount;
                arparams[3].Value = lstPackageMarketingOfferMapping[icount].IsPercentage;

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                    "usp_savePackageMarketingOfferMapping", arparams);
            }
        }


        public Int64 SaveEventMarketingOffer(Int64 intMarketingOfferId, int Mode)
        {
            var arprams = new SqlParameter[2];
            arprams[0] = new SqlParameter("@marketingofferid", SqlDbType.BigInt);
            arprams[0].Value = intMarketingOfferId;

            arprams[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arprams[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savealleventmarketingoffer",
                arprams);
            Int64 returnresult = Convert.ToInt64(arprams[1].Value);
            return returnresult;
        }


        /// <summary>
        /// Inserts or Updates TblCoupon with the values passed through the Ecoupon Entity
        /// </summary>
        public Int64 SaveCoupon(ECoupon objCoupon, int Mode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[19];

            arParms[0] = new SqlParameter("@coupontypeid", SqlDbType.BigInt);
            arParms[0].Value = objCoupon.CouponType.CouponTypeID;
            arParms[1] = new SqlParameter("@isglobal", SqlDbType.Bit);
            arParms[1].Value = objCoupon.IsGlobal;
            arParms[2] = new SqlParameter("@ispercentage", SqlDbType.Bit);
            arParms[2].Value = objCoupon.IsPercentage;
            arParms[3] = new SqlParameter("@couponvalue", SqlDbType.Decimal, 18);
            arParms[3].Value = objCoupon.CouponValue;

            arParms[4] = new SqlParameter("@coupondescription", SqlDbType.VarChar, 100);
            arParms[4].Value = objCoupon.CouponDes;

            arParms[5] = new SqlParameter("@isfree", SqlDbType.Bit);
            arParms[5].Value = objCoupon.IsFree;
            arParms[6] = new SqlParameter("@iseventbased", SqlDbType.Bit);
            arParms[6].Value = objCoupon.IsEventBased;
            arParms[7] = new SqlParameter("@minimumpurchaseamount", SqlDbType.Decimal, 18);
            arParms[7].Value = objCoupon.MinPurchaseAmount;
            arParms[8] = new SqlParameter("@createduserid", SqlDbType.BigInt);
            arParms[8].Value = objCoupon.CreatedbyUserID;
            arParms[9] = new SqlParameter("@validitystartdate", SqlDbType.DateTime);
            if (string.IsNullOrEmpty(objCoupon.ValidityStartDate))
            {
                objCoupon.ValidityStartDate = DateTime.Now.ToShortDateString();
            }

            arParms[9].Value = objCoupon.ValidityStartDate;

            arParms[10] = new SqlParameter("@validityenddate", SqlDbType.DateTime);
            arParms[10].Value = string.IsNullOrEmpty(objCoupon.ValidityEndDate) ? DBNull.Value : (object)objCoupon.ValidityEndDate;
            arParms[11] = new SqlParameter("@isactive", SqlDbType.Bit);
            arParms[11].Value = objCoupon.Active;
            arParms[12] = new SqlParameter("@maximumnumbertimesused", SqlDbType.Int);
            arParms[12].Value = objCoupon.MaximumNumberTimesUsed;
            arParms[13] = new SqlParameter("@couponcode", SqlDbType.VarChar, 50);
            arParms[13].Value = objCoupon.CouponCode;
            arParms[14] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[14].Value = Mode;
            arParms[15] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[15].Direction = ParameterDirection.Output;
            arParms[16] = new SqlParameter("@couponid", SqlDbType.BigInt);
            arParms[16].Value = objCoupon.CouponID;

            arParms[17] = new SqlParameter("@customerrange", SqlDbType.TinyInt);
            if (objCoupon.CustomerRange >= 0)
            {
                arParms[17].Value = objCoupon.CustomerRange;
            }
            else
            {
                arParms[17].Value = DBNull.Value;
            }

            arParms[18] = new SqlParameter("@DiscountType", SqlDbType.Bit);
            arParms[18].Value = objCoupon.IsDiscountTypePackageWise;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savecoupon", arParms);
            returnvalue = (Int64)arParms[15].Value;

            if (objCoupon.ListSignUpMode != null && objCoupon.ListSignUpMode.Count > 0)
            {
                SaveCouponSignUpMode(objCoupon.ListSignUpMode, returnvalue);
            }

            // Insert/Updates event coupon mapping table
            if (objCoupon.EventCoupon != null)
            {
                SaveEventCoupon(objCoupon.EventCoupon, returnvalue, Mode);
            }
            if (objCoupon.IsEventBased == false)
            {
                SaveEventCoupon(returnvalue, Mode);
            }

            // Update Package Coupon mapping records 
            if (objCoupon.IsDiscountTypePackageWise && objCoupon.PackageSourceCodeDiscount != null)
            {
                // Inserts new records or Updates the existing ones
                SavePackageCouponDiscountMapping(objCoupon.PackageSourceCodeDiscount, Convert.ToInt32(returnvalue));
            }
            else if (objCoupon.CouponID > 0 && objCoupon.IsDiscountTypePackageWise == false)
            {
                // Deactivates all the records if Discount Type is different now
                string sqlquery = "Update [TblPackageSourceCodeDiscount] set isactive = 0 where [SourceCodeID] = " +
                    objCoupon.CouponID;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery);
            }

            return returnvalue;
        }

        private Int64 SaveCouponSignUpMode(List<Int16> listsignupmode, Int64 couponid)
        {
            var arparams = new SqlParameter[4];
            arparams[0] = new SqlParameter("@couponid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@signupmode", SqlDbType.TinyInt);
            arparams[2] = new SqlParameter("@recordcount", SqlDbType.TinyInt);
            arparams[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);

            int icount = 0;
            foreach (Int16 signupmode in listsignupmode)
            {
                arparams[0].Value = couponid;
                arparams[1].Value = signupmode;
                arparams[2].Value = icount;
                arparams[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savecouponsignupmode",
                    arparams);
                icount++;
            }
            return 0;
        }

        private Int64 SaveMarkettingOfferRole(List<Int16> listRole, Int64 couponid)
        {
            var arparams = new SqlParameter[4];
            arparams[0] = new SqlParameter("@marketingOfferid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@Role", SqlDbType.TinyInt);
            arparams[2] = new SqlParameter("@recordcount", SqlDbType.TinyInt);
            arparams[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);

            int icount = 0;
            foreach (Int16 role in listRole)
            {
                arparams[0].Value = couponid;
                arparams[1].Value = role;
                arparams[2].Value = icount;
                arparams[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savemarketingofferRole",
                    arparams);
                icount++;
            }
            return 0;
        }

        private Int64 SaveMarkettingOfferSignUpMode(List<Int16> listsignupmode, Int64 couponid)
        {
            var arparams = new SqlParameter[4];
            arparams[0] = new SqlParameter("@marketingOfferid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@signupmode", SqlDbType.TinyInt);
            arparams[2] = new SqlParameter("@recordcount", SqlDbType.TinyInt);
            arparams[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);

            int icount = 0;
            foreach (Int16 signupmode in listsignupmode)
            {
                arparams[0].Value = couponid;
                arparams[1].Value = signupmode;
                arparams[2].Value = icount;
                arparams[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                    "usp_savemarketingoffersignupmode", arparams);
                icount++;
            }
            return 0;
        }

        /// <summary>
        /// Insert/Updates Coupon Package Mapping Records
        /// Saves Per package discount for a particular coupon
        /// </summary>
        /// <param name="lstPackageCouponMapping"></param>
        private void SavePackageCouponDiscountMapping(List<EPackageCouponMapping> lstPackageCouponMapping,
            Int64 couponid)
        {
            var arparams = new SqlParameter[5];

            arparams[0] = new SqlParameter("@packageid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@couponid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@discountamount", SqlDbType.Decimal);
            arparams[3] = new SqlParameter("@ispercentage", SqlDbType.Bit);
            arparams[4] = new SqlParameter("@returnvalue", SqlDbType.Int);
            arparams[4].Direction = ParameterDirection.Output;

            for (int icount = 0; icount < lstPackageCouponMapping.Count; icount++)
            {
                arparams[0].Value = lstPackageCouponMapping[icount].PackageID;
                arparams[1].Value = couponid;
                arparams[2].Value = lstPackageCouponMapping[icount].DiscountAmount;
                arparams[3].Value = lstPackageCouponMapping[icount].IsPercentage;

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savePackageCouponMapping",
                    arparams);
            }
        }

        public Int64 SaveCoupon(String CouponID, int Mode)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@couponid", SqlDbType.VarChar, 3000);
            arParms[0].Value = CouponID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removecoupon", arParms);
            return (Int64)arParms[2].Value;
        }

        public Int64 SaveEventCoupon(List<EEventCoupon> EventCoupon, Int64 intCouponId, int Mode)
        {
            var returnvalue = new Int64();
            for (int icount = 0; icount < EventCoupon.Count; icount++)
            {
                var arParms = new SqlParameter[7];
                arParms[0] = new SqlParameter("@eventcouponid", SqlDbType.BigInt);
                arParms[0].Value = EventCoupon[icount].EventCouponID;
                arParms[1] = new SqlParameter("@eventid", SqlDbType.BigInt);
                arParms[1].Value = EventCoupon[icount].Event.EventID;
                arParms[2] = new SqlParameter("@couponid", SqlDbType.BigInt);
                arParms[2].Value = intCouponId;
                arParms[3] = new SqlParameter("@numberoftimeused", SqlDbType.BigInt);
                arParms[3].Value = EventCoupon[icount].NoOfTimeUsed;
                arParms[4] = new SqlParameter("@isactive", SqlDbType.Bit);
                arParms[4].Value = EventCoupon[icount].Active;
                arParms[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[5].Direction = ParameterDirection.Output;
                arParms[6] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[6].Value = Mode;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventcoupon", arParms);
                returnvalue = (Int64)arParms[5].Value;
            }

            return returnvalue;
        }

        public List<EMarketingOffer> GetMarketingOffer(String strMarketingOffer, String strOtherSearch, int inputMode)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@marketingOffer", SqlDbType.VarChar, 500);
            arParms[0].Value = strMarketingOffer;
            arParms[1] = new SqlParameter("@othersearch", SqlDbType.VarChar, 500);
            arParms[1].Value = strOtherSearch;
            arParms[2] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[2].Value = inputMode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getMarketingOffer", arParms);
            var objReturnMarketingOffer = new List<EMarketingOffer>();
            if (tempdataset == null)
            {
                return objReturnMarketingOffer;
            }
            objReturnMarketingOffer = ParseMarketingOfferDataSet(tempdataset, inputMode);
            return objReturnMarketingOffer;
        }

        private List<EMarketingOffer> ParseMarketingOfferDataSet(DataSet MarketingOfferDataSet, int inputMode)
        {
            var objReturnMarketingOffer = new List<EMarketingOffer>();
            DataTable dtMarketingOfferEvent = null;
            if (inputMode == 1)
            {
                dtMarketingOfferEvent = MarketingOfferDataSet.Tables[2];
            }

            DataTable dtCouponSignUpMode = null;
            if (inputMode == 1 || inputMode == 2)
            {
                dtCouponSignUpMode = MarketingOfferDataSet.Tables[MarketingOfferDataSet.Tables.Count - 1];
            }

            DataTable dtCouponRole = null;
            if (inputMode == 1 || inputMode == 2)
            {
                dtCouponRole = MarketingOfferDataSet.Tables[MarketingOfferDataSet.Tables.Count - 2];
            }

            // Last Table returned by Stored Procedure in the dataset
            DataTable dtPackageMarketingOfferMapping = MarketingOfferDataSet.Tables[3];

            for (int count = 0; count < MarketingOfferDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var objMarketingOffer = new EMarketingOffer();
                    objMarketingOffer.Active = Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsActive"]);
                    objMarketingOffer.MarketingOffer =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOfferCode"]);
                    objMarketingOffer.MarketingOfferID =
                        Convert.ToInt32(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOfferID"]);
                    objMarketingOffer.MarketingOfferType = new EMarketingOfferType();
                    objMarketingOffer.MarketingOfferType.MarketingOfferTypeID =
                        Convert.ToInt32(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOfferTypeID"]);
                    objMarketingOffer.MarketingOfferType.Name =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["Name"]);
                    objMarketingOffer.MarketingOfferValue =
                        Convert.ToDecimal(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOfferValue"]);
                    objMarketingOffer.MarketingOfferDes =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["MarketingOfferDescription"]);
                    objMarketingOffer.CreatedbyUserID =
                        Convert.ToInt64(MarketingOfferDataSet.Tables[0].Rows[count]["CreatedUserID"]);
                    objMarketingOffer.IsDiscountTypePackageWise =
                        Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["DiscountType"]);

                    objMarketingOffer.IsEventBased =
                        Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsEventbased"]);
                    objMarketingOffer.IsFree = Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsFree"]);
                    objMarketingOffer.IsGlobal =
                        Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsGlobal"]);
                    objMarketingOffer.IsPercentage =
                        Convert.ToBoolean(MarketingOfferDataSet.Tables[0].Rows[count]["IsPercentage"]);
                    objMarketingOffer.CustomerRange =
                        Convert.ToInt16(MarketingOfferDataSet.Tables[0].Rows[count]["CustomerRange"]);

                    objMarketingOffer.MaximumNumberTimesUsed =
                        Convert.ToInt64(MarketingOfferDataSet.Tables[0].Rows[count]["MaximumNumberTimesUsed"]);
                    objMarketingOffer.MinPurchaseAmount =
                        Convert.ToDecimal(MarketingOfferDataSet.Tables[0].Rows[count]["MinimumPurchaseAmount"]);
                    objMarketingOffer.ValidityEndDate =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["ValidityEndDate"]);
                    objMarketingOffer.ValidityStartDate =
                        Convert.ToString(MarketingOfferDataSet.Tables[0].Rows[count]["ValidityStartDate"]);
                    objMarketingOffer.EventMarketingOffer = new List<EEventMarketingOffer>();

                    if (dtMarketingOfferEvent != null)
                    {
                        dtMarketingOfferEvent.DefaultView.RowFilter = "MarketingOfferID = " +
                            objMarketingOffer.MarketingOfferID;
                        for (int jcount = 0; jcount < dtMarketingOfferEvent.DefaultView.Count; jcount++)
                        {
                            var objEventMarketingOffer = new EEventMarketingOffer();
                            objEventMarketingOffer.Active =
                                Convert.ToBoolean(dtMarketingOfferEvent.DefaultView[jcount]["IsActive"]);
                            objEventMarketingOffer.MarketingOfferID = objMarketingOffer.MarketingOfferID;
                            objEventMarketingOffer.EventMarketingOfferID =
                                Convert.ToInt32(dtMarketingOfferEvent.DefaultView[jcount]["EventMarketingOfferID"]);
                            objEventMarketingOffer.NoOfTimeUsed =
                                Convert.ToInt32(dtMarketingOfferEvent.DefaultView[jcount]["NumberOfTimesUsed"]);
                            /////////////
                            objEventMarketingOffer.Event = new EEvent();
                            objEventMarketingOffer.Event.EventID =
                                Convert.ToInt32(dtMarketingOfferEvent.DefaultView[jcount]["EventID"]);

                            objEventMarketingOffer.Event.Name =
                                Convert.ToString(dtMarketingOfferEvent.DefaultView[jcount]["eventname"]);

                            objEventMarketingOffer.Event.EventDate =
                                Convert.ToString(dtMarketingOfferEvent.DefaultView[jcount]["eventdate"]);

                            objEventMarketingOffer.Event.Host = new EHost();
                            objEventMarketingOffer.Event.Host.Address = new EAddress();

                            objEventMarketingOffer.Event.Host.Address.Address1 =
                                Convert.ToString(dtMarketingOfferEvent.DefaultView[jcount]["Address1"]);
                            objEventMarketingOffer.Event.Host.Address.Address2 =
                                Convert.ToString(dtMarketingOfferEvent.DefaultView[jcount]["Address2"]);
                            objEventMarketingOffer.Event.Host.Address.City =
                                Convert.ToString(dtMarketingOfferEvent.DefaultView[jcount]["City"]);
                            objEventMarketingOffer.Event.Host.Address.State =
                                Convert.ToString(dtMarketingOfferEvent.DefaultView[jcount]["State"]);
                            objEventMarketingOffer.Event.Host.Address.Country =
                                Convert.ToString(dtMarketingOfferEvent.DefaultView[jcount]["Country"]);
                            objEventMarketingOffer.Event.Host.Address.Zip =
                                Convert.ToString(dtMarketingOfferEvent.DefaultView[jcount]["ZipCode"]);

                            objMarketingOffer.EventMarketingOffer.Add(objEventMarketingOffer);
                        }
                    }
                    if (dtCouponSignUpMode != null)
                    {
                        objMarketingOffer.ListSignUpMode = new List<short>();
                        dtCouponSignUpMode.DefaultView.RowFilter = "MarketingOfferID = " +
                            objMarketingOffer.MarketingOfferID;
                        for (int jcount = 0; jcount < dtCouponSignUpMode.DefaultView.Count; jcount++)
                        {
                            objMarketingOffer.ListSignUpMode.Add(
                                Convert.ToInt16(dtCouponSignUpMode.Rows[jcount]["SignUpMode"]));
                        }
                    }

                    if (dtCouponRole != null)
                    {
                        objMarketingOffer.ListRole = new List<short>();
                        dtCouponRole.DefaultView.RowFilter = "MarketingOfferID = " + objMarketingOffer.MarketingOfferID;
                        for (int jcount = 0; jcount < dtCouponRole.DefaultView.Count; jcount++)
                        {
                            objMarketingOffer.ListRole.Add(Convert.ToInt16(dtCouponRole.Rows[jcount]["RoleId"]));
                        }
                    }

                    if (objMarketingOffer.IsDiscountTypePackageWise)
                    {
                        dtPackageMarketingOfferMapping.DefaultView.RowFilter = "MarketingOfferID = " +
                            objMarketingOffer.MarketingOfferID;

                        if (dtPackageMarketingOfferMapping.DefaultView.Count > 0)
                        {
                            objMarketingOffer.PackageMarketingOfferDiscount = new List<EPackageMarketingOfferMapping>();
                            foreach (
                                DataRowView drvPackageMarketingOfferMapping in
                                    dtPackageMarketingOfferMapping.DefaultView)
                            {
                                var objpackagesourcecodediscount = new EPackageMarketingOfferMapping();

                                objpackagesourcecodediscount.PackageID =
                                    Convert.ToInt64(drvPackageMarketingOfferMapping["PackageID"]);
                                objpackagesourcecodediscount.DiscountAmount =
                                    Convert.ToDecimal(drvPackageMarketingOfferMapping["Discount"]);
                                objpackagesourcecodediscount.IsPercentage =
                                    Convert.ToBoolean(drvPackageMarketingOfferMapping["IsPercentage"]);

                                objMarketingOffer.PackageMarketingOfferDiscount.Add(objpackagesourcecodediscount);
                            }
                        }
                    }
                    var objLstMarketingOfferRole = new List<EMarketingOfferRole>();
                    for (int rolecount = 0; rolecount < MarketingOfferDataSet.Tables[4].Rows.Count; rolecount++)
                    {
                        try
                        {
                            var objMarketingOfferRole = new EMarketingOfferRole();
                            objMarketingOfferRole.MarketingOfferID =
                                Convert.ToInt64(MarketingOfferDataSet.Tables[4].Rows[rolecount]["MarketingOfferId"]);
                            objMarketingOfferRole.RoleID =
                                Convert.ToInt64(MarketingOfferDataSet.Tables[4].Rows[rolecount]["RoleId"]);
                            objMarketingOfferRole.RoleName =
                                Convert.ToString(MarketingOfferDataSet.Tables[4].Rows[rolecount]["Name"]);
                            objLstMarketingOfferRole.Add(objMarketingOfferRole);
                        }
                        catch
                        { }
                    }
                    objMarketingOffer.MarketingOfferRole = objLstMarketingOfferRole;
                    objReturnMarketingOffer.Add(objMarketingOffer);
                }
                catch
                { }
            }
            return objReturnMarketingOffer;
        }

        public Int64 SaveEventCoupon(Int64 intCouponId, int mode)
        {
            var arprams = new SqlParameter[2];
            arprams[0] = new SqlParameter("@couponid", SqlDbType.BigInt);
            arprams[0].Value = intCouponId;
            arprams[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arprams[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savealleventcoupon", arprams);
            return Convert.ToInt64(arprams[1].Value);
        }

        #endregion

        # region "MessageSendType"

        private List<EMessageSendType> ParseMessageSendTypeDataSet(DataSet messagesendtypeDataSet)
        {
            var returnMessageSendType = new List<EMessageSendType>();

            for (int count = 0; count < messagesendtypeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var messagesendtype = new EMessageSendType();
                    messagesendtype.Active = Convert.ToBoolean(messagesendtypeDataSet.Tables[0].Rows[count]["IsActive"]);
                    messagesendtype.MessageSendTypeID =
                        Convert.ToInt32(messagesendtypeDataSet.Tables[0].Rows[count]["MessageSendTypeID"]);
                    messagesendtype.Description =
                        Convert.ToString(messagesendtypeDataSet.Tables[0].Rows[count]["Description"]);
                    messagesendtype.SendOption =
                        Convert.ToString(messagesendtypeDataSet.Tables[0].Rows[count]["SendOption"]);
                    returnMessageSendType.Add(messagesendtype);
                }
                catch
                { }
            }
            return returnMessageSendType;
        }

        #endregion

        # region "Location"

        private List<ELocation> ParseLocationDataSet(DataSet locationDataSet)
        {
            var returnLocation = new List<ELocation>();

            for (int count = 0; count < locationDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var location = new ELocation();
                    var parentlocation = new ELocation();

                    parentlocation.LocationID = Convert.ToInt32(locationDataSet.Tables[0].Rows[count]["LocationID"]);

                    location.Active = Convert.ToBoolean(locationDataSet.Tables[0].Rows[count]["IsActive"]);
                    location.LocationID = Convert.ToInt32(locationDataSet.Tables[0].Rows[count]["LocationID"]);
                    location.LocationName = Convert.ToString(locationDataSet.Tables[0].Rows[count]["Name"]);
                    location.LocationType = Convert.ToInt32(locationDataSet.Tables[0].Rows[count]["LocationType"]);

                    location.Location = parentlocation;
                    returnLocation.Add(location);
                }
                catch
                { }
            }
            return returnLocation;
        }

        #endregion

        #region "Contract"

        public Int64 SaveContract(EContract contract, int Mode)
        {

            var arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@contractid", SqlDbType.BigInt);
            arParms[0].Value = contract.ContractID;
            arParms[1] = new SqlParameter("@contractname", SqlDbType.VarChar, 500);
            arParms[1].Value = contract.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = contract.Description;
            arParms[3] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[3].Value = contract.State.StateID;
            arParms[4] = new SqlParameter("@contract", SqlDbType.VarChar, 1000);
            arParms[4].Value = contract.Contract;
            arParms[5] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[5].Value = Mode;

            arParms[6] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[6].Direction = ParameterDirection.Output;
            arParms[7] = new SqlParameter("@StartDate", SqlDbType.VarChar, 50);
            arParms[7].Value = contract.StartDate;
            arParms[8] = new SqlParameter("@Enddate", SqlDbType.VarChar, 50);
            arParms[8].Value = contract.EndDate;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savecontract", arParms);
            return (Int64)arParms[6].Value;

        }

        public Int64 SaveContract(String contractID, int Mode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@contractid", SqlDbType.VarChar, 3000);
            arParms[0].Value = contractID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removecontract", arParms);
            returnvalue = (Int64)arParms[2].Value;
            return returnvalue;
        }

        public List<EContract> GetContract(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getcontract",
                arParms);

            var returnContract = new List<EContract>();
            returnContract = ParseContractDataSet(tempdataset);
            return returnContract;
        }

        private List<EContract> ParseContractDataSet(DataSet contractDataSet)
        {
            var returnContract = new List<EContract>();

            for (int count = 0; count < contractDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var state = new EState();
                    var contract = new EContract();


                    state.StateID = Convert.ToInt32(contractDataSet.Tables[0].Rows[count]["StateID"]);
                    state.Name = Convert.ToString(contractDataSet.Tables[0].Rows[count]["StateName"]);

                    contract.Active = Convert.ToBoolean(contractDataSet.Tables[0].Rows[count]["IsActive"]);
                    contract.ContractID = Convert.ToInt32(contractDataSet.Tables[0].Rows[count]["ContractID"]);
                    contract.Description = Convert.ToString(contractDataSet.Tables[0].Rows[count]["Description"]);
                    contract.Contract = Convert.ToString(contractDataSet.Tables[0].Rows[count]["Contract"]);
                    contract.Name = Convert.ToString(contractDataSet.Tables[0].Rows[count]["ContractName"]);
                    contract.StartDate = Convert.ToString(contractDataSet.Tables[0].Rows[count]["StartDate"]);
                    contract.EndDate = Convert.ToString(contractDataSet.Tables[0].Rows[count]["EndDate"]);
                    contract.State = state;
                    returnContract.Add(contract);
                }
                catch
                { }
            }
            return returnContract;
        }

        #endregion

        #region "Login"


        /// <summary>
        /// to lock or unlock the user in TblUserLogin
        /// </summary>
        /// <param name="filterString1">Username</param>
        /// <param name="isLock">to lock or unlock the user</param>
        /// <param name="browserSessionId">to log sessionid</param>
        public void LockUnlockBMSUser(String filterString1, bool isLock)
        {
            var arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@filterString1", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString1;

            arParms[1] = new SqlParameter("@mode", SqlDbType.VarChar, 1);
            if (isLock)
            {
                arParms[1].Value = "0";
            }
            else
            {
                arParms[1].Value = "1";
            }

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_lockuser", arParms);
        }


        #endregion

        #region "Country"

        public long SaveCountry(ECountry country, int Mode)
        {
            var arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[0].Value = country.CountryID;
            arParms[1] = new SqlParameter("@countryname", SqlDbType.VarChar, 500);
            arParms[1].Value = country.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = country.Description;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = Mode;


            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;
            arParms[5] = new SqlParameter("@countrycode", SqlDbType.VarChar, 2);
            arParms[5].Value = country.CountryCode;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savecountry", arParms);
            return (long)arParms[4].Value;
        }

        /* NOTE: despite the name SaveCountry, this method does something different than the method above it.
         * (it deletes, deactivates, or reactives countries)
         * 
         * The method is only ever called with userId = 1, Shell = 1, role = 1.
         */

        public Int64 SaveCountry(String countryID, int Mode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@countryid", SqlDbType.VarChar, 3000);
            arParms[0].Value = countryID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            // note removecountry
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removecountry", arParms);
            returnvalue = (Int64)arParms[2].Value;

            return returnvalue;
        }

        /* NOTE: this is always called with (string.Empty, 3) except in Franchisor/Masters/Country.aspx.cs, where it is called once with
         *  searchtext, 2, and once with string.Empty, 0.)
         *  
         * inputMode 3, despite comment in sproc, gets all *active* rows.
         * 2 filters by name.
         * 0 is same as 3 but does not filter out inactive countries, and orders by name instead of by id. This seems presentational;
         *      we can probably just expose GetAllCountries for 0 and 3.
         */

        public List<ECountry> GetCountry(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getcountry",
                arParms);

            var returnCountry = new List<ECountry>();
            returnCountry = ParseCountryDataSet(tempdataset);
            return returnCountry;
        }

        private List<ECountry> ParseCountryDataSet(DataSet countryDataSet)
        {
            try
            {
                return countryDataSet.Tables[0].Rows.OfType<DataRow>().Select(MapCountry).ToList();
            }
            catch
            {
                return new List<ECountry>();
            }
        }

        private ECountry MapCountry(DataRow row)
        {
            return new ECountry
            {
                Active = Convert.ToBoolean(row["IsActive"]),
                CountryID = Convert.ToInt32(row["CountryID"]),
                Description = Convert.ToString(row["Description"]),
                Name = Convert.ToString(row["Name"]),
                CountryCode = Convert.ToString(row["CountryCode"])
            };
        }

        #endregion

        #region "City"

        // *** Added By Viranjay 
        public Int64 GetZipCodeId(Int64 ZipCode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@zipcode", SqlDbType.BigInt);
            arParms[0].Value = ZipCode;
            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_checkzip", arParms);
            returnvalue = (Int64)arParms[1].Value;
            return returnvalue;
        }

        /// <summary>
        /// returns 0 if eventid is of future event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public int CheckIffutureEvent(Int64 eventId)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@eventId", SqlDbType.BigInt);
            arParms[0].Value = eventId;
            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.Int);
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_checkIfFutureEvent", arParms);
            var returnvalue = (int)arParms[1].Value;
            return returnvalue;
        }

        public Int64 SaveCity(ECity City, int Mode)
        {
            var arParms = new SqlParameter[8];

            arParms[0] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[0].Value = City.Zipcode.ZipID;

            arParms[1] = new SqlParameter("@zipcode", SqlDbType.BigInt);
            arParms[1].Value = City.Zipcode.ZipCode;

            arParms[2] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[2].Value = City.CityID;

            arParms[3] = new SqlParameter("@cityname", SqlDbType.VarChar, 500);
            arParms[3].Value = City.Name;

            arParms[4] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[4].Value = City.Description;

            arParms[5] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[5].Value = City.State.StateID;
            //arParms[4] = new SqlParameter("@countryid", SqlDbType.BigInt);
            //arParms[4].Value = City.Country.CountryID;
            arParms[6] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[6].Value = Mode;


            arParms[7] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savecity", arParms);
            var returnvalue = (Int64)(arParms[7].Value);
            return returnvalue;
        }

        public Int64 SaveCity(String CityID, int Mode)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@cityid", SqlDbType.VarChar, 3000);
            arParms[0].Value = CityID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removecity", arParms);
            var returnvalue = (Int64)arParms[2].Value;
            return returnvalue;
        }

        public List<ECity> GetCitybyState(String filterString, String citytext, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getcity",
                arParms);

            var returnCity = new List<ECity>();
            if (tempdataset == null)
            {
                return returnCity;
            }

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                tempdataset.Tables[0].DefaultView.RowFilter = "Name like '%" + citytext + "%'";
                if (tempdataset.Tables[0].DefaultView.Count > 0)
                {
                    returnCity = ParseCityDataView(tempdataset.Tables[0].DefaultView);
                }
            }

            return returnCity;
        }

        private List<ECity> ParseCityDataView(DataView cityDataView)
        {
            var returnCity = new List<ECity>();

            for (int count = 0; count < cityDataView.Count; count++)
            {
                try
                {
                    var city = new ECity();
                    var state = new EState();
                    var country = new ECountry();
                    country.CountryID = Convert.ToInt32(cityDataView[count]["CountryID"]);
                    country.Name = Convert.ToString(cityDataView[count]["CountryName"]);
                    state.StateID = Convert.ToInt32(cityDataView[count]["StateID"]);
                    state.Name = Convert.ToString(cityDataView[count]["StateName"]);
                    city.Active = Convert.ToBoolean(cityDataView[count]["IsActive"]);
                    city.CityID = Convert.ToInt32(cityDataView[count]["CityID"]);
                    city.Description = Convert.ToString(cityDataView[count]["Description"]);
                    city.Name = Convert.ToString(cityDataView[count]["Name"]);
                    city.Country = country;
                    city.State = state;
                    returnCity.Add(city);
                }
                catch
                { }
            }
            return returnCity;
        }

        public List<ECity> GetCity(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getcity",
                arParms);

            return ParseCityDataSet(tempdataset);
        }

        private List<ECity> ParseCityDataSet(DataSet cityDataSet)
        {
            var returnCity = new List<ECity>();

            for (int count = 0; count < cityDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var city = new ECity();
                    var state = new EState();
                    var country = new ECountry();
                    // *** Viranjay [Manage City]
                    var zip = new EZip();
                    country.CountryID = Convert.ToInt32(cityDataSet.Tables[0].Rows[count]["CountryID"]);
                    country.Name = Convert.ToString(cityDataSet.Tables[0].Rows[count]["CountryName"]);
                    state.StateID = Convert.ToInt32(cityDataSet.Tables[0].Rows[count]["StateID"]);
                    state.Name = Convert.ToString(cityDataSet.Tables[0].Rows[count]["StateName"]);
                    // *** Start Viranjay [Manage City]
                    zip.ZipID = Convert.ToInt32(cityDataSet.Tables[0].Rows[count]["ZipID"]);
                    zip.ZipCode = Convert.ToString(cityDataSet.Tables[0].Rows[count]["ZipCode"]);
                    // *** End Viranjay [Manage City]
                    city.Active = Convert.ToBoolean(cityDataSet.Tables[0].Rows[count]["IsActive"]);
                    city.CityID = Convert.ToInt32(cityDataSet.Tables[0].Rows[count]["CityID"]);
                    city.Description = Convert.ToString(cityDataSet.Tables[0].Rows[count]["Description"]);
                    city.Name = Convert.ToString(cityDataSet.Tables[0].Rows[count]["Name"]);
                    city.Country = country;
                    city.State = state;
                    city.Zipcode = zip;
                    returnCity.Add(city);
                }
                catch
                { }
            }
            return returnCity;
        }

        public List<ECity> GetUniqueCity(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getcity",
                arParms);

            List<ECity> returnCity = ParseUniiqueCityDataSet(tempdataset);
            return returnCity;
        }

        private List<ECity> ParseUniiqueCityDataSet(DataSet cityDataSet)
        {
            var returnCity = new List<ECity>();

            for (int count = 0; count < cityDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var city = new ECity();

                    city.Active = Convert.ToBoolean(cityDataSet.Tables[0].Rows[count]["IsActive"]);
                    city.Description = Convert.ToString(cityDataSet.Tables[0].Rows[count]["Description"]);
                    city.Name = Convert.ToString(cityDataSet.Tables[0].Rows[count]["Name"]);
                    returnCity.Add(city);
                }
                catch
                { }
            }
            return returnCity;
        }

        public List<ECity> GetStateCityByName(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getstatecity",
                arParms);

            List<ECity> returnCity = ParseStateCityDataSet(tempdataset);
            return returnCity;
        }

        private List<ECity> ParseStateCityDataSet(DataSet cityDataSet)
        {
            var returnCity = new List<ECity>();

            for (int count = 0; count < cityDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var city = new ECity();
                    city.Name = Convert.ToString(cityDataSet.Tables[0].Rows[count]["Name"]);
                    returnCity.Add(city);
                }
                catch
                { }
            }
            return returnCity;
        }

        #endregion

        #region "User"

        public Int64 SaveAddress(EAddress address, int Mode, SqlTransaction sqltransaction)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[10];
            arParms[0] = new SqlParameter("@addressid", SqlDbType.BigInt);
            arParms[0].Value = address.AddressID;
            arParms[1] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
            arParms[1].Value = address.Address1;
            arParms[2] = new SqlParameter("@address2", SqlDbType.VarChar, 500);


            if (address.Address2 == null)
            {
                arParms[2].Value = DBNull.Value;
            }
            else if (address.Address2 == string.Empty || address.Address2 == "")
            {
                arParms[2].Value = DBNull.Value;
            }
            else
            {
                arParms[2].Value = address.Address2;
            }


            arParms[3] = new SqlParameter("@cityid", SqlDbType.BigInt);
            if (address.CityID > 0)
            {
                arParms[3].Value = address.CityID;
            }
            else
            {
                arParms[3].Value = DBNull.Value;
            }

            arParms[4] = new SqlParameter("@stateid", SqlDbType.BigInt);
            if (address.StateID > 0)
            {
                arParms[4].Value = address.StateID;
            }
            else
            {
                arParms[4].Value = DBNull.Value;
            }

            arParms[5] = new SqlParameter("@countryid", SqlDbType.BigInt);
            if (address.CountryID > 0)
            {
                arParms[5].Value = address.CountryID;
            }
            else
            {
                arParms[5].Value = DBNull.Value;
            }

            arParms[6] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[6].Value = address.ZipID;

            arParms[7] = new SqlParameter("@phonenumber", SqlDbType.VarChar, 50);
            if (address.PhoneNumber == null)
            {
                arParms[7].Value = DBNull.Value;
            }
            else if (address.PhoneNumber == string.Empty || address.PhoneNumber == "")
            {
                arParms[7].Value = DBNull.Value;
            }
            else
            {
                arParms[7].Value = address.PhoneNumber;
            }

            arParms[8] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[8].Value = Mode;

            arParms[9] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[9].Direction = ParameterDirection.Output;

            if (sqltransaction == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveaddress", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_saveaddress", arParms);
            }
            // returnresult -5 Address  not inserted in the database. AddressId for the coresponding record is either 0 or null
            if (arParms[9].Value.ToString() == "" || arParms[9].Value == null || arParms[9].Value.ToString() == "-5")
            {
                arParms[9].Value = "";
                returnvalue = -5;
            }
            else
            {
                returnvalue = (Int64)arParms[9].Value;
                arParms[9].Value = "";
            }
            return returnvalue;
        }

        public Int64 SaveUser(EUser user, int Mode, SqlTransaction sqltransaction)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[19];
            arParms[0] = new SqlParameter("@saveuserid", SqlDbType.BigInt);
            arParms[0].Value = user.UserID;
            arParms[1] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[1].Value = user.FirstName;
            arParms[2] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[2].Value = user.MiddleName;
            arParms[3] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[3].Value = user.LastName;

            arParms[4] = new SqlParameter("@homeaddressid", SqlDbType.BigInt);
            arParms[4].Value = user.HomeAddress.AddressID;
            arParms[5] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            if (user.PhoneOffice == null)
            {
                arParms[5].Value = DBNull.Value;
            }
            else if (user.PhoneOffice.Trim().Length < 1)
            {
                arParms[5].Value = DBNull.Value;
            }
            else
            {
                arParms[5].Value = user.PhoneOffice;
            }

            arParms[6] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            if (user.PhoneCell == null)
            {
                arParms[6].Value = DBNull.Value;
            }
            else if (user.PhoneCell.Trim().Length < 1)
            {
                arParms[6].Value = DBNull.Value;
            }
            else
            {
                arParms[6].Value = user.PhoneCell;
            }

            arParms[7] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            if (user.PhoneHome == null)
            {
                arParms[7].Value = DBNull.Value;
            }
            else if (user.PhoneHome.Trim().Length < 1)
            {
                arParms[7].Value = DBNull.Value;
            }
            else
            {
                arParms[7].Value = user.PhoneHome;
            }

            arParms[8] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[8].Value = user.EMail1;
            arParms[9] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[9].Value = user.EMail2;
            arParms[10] = new SqlParameter("@ssn", SqlDbType.VarChar, 50);
            arParms[10].Value = user.SSN;
            arParms[11] = new SqlParameter("@dob", SqlDbType.SmallDateTime);
            if (user.DOB.Trim().Length < 1)
            {
                arParms[11].Value = DBNull.Value;
            }
            else
            {
                arParms[11].Value = user.DOB;
            }

            arParms[12] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[12].Value = Mode;
            //arParms[13] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            //arParms[13].Value = UserID;
            //arParms[14] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            //arParms[14].Value = Shell;
            //arParms[15] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            //arParms[15].Value = Role;
            arParms[13] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[13].Direction = ParameterDirection.Output;

            arParms[14] = new SqlParameter("@tempusername", SqlDbType.VarChar, 500);
            if (user.UserName == null || user.UserName.Trim().Length < 1)
            {
                arParms[14].Value = DBNull.Value;
            }
            else
            {
                arParms[14].Value = user.UserName;
            }

            arParms[15] = new SqlParameter("@password", SqlDbType.VarChar, 100);
            if (user.Password == null || user.Password.Trim().Length < 1)
            {
                arParms[15].Value = DBNull.Value;
            }
            else
            {
                arParms[15].Value = user.Password;
            }

            arParms[16] = new SqlParameter("@HintQuestion", SqlDbType.VarChar, 100);
            if (user.Question == null || user.Question.Trim().Length < 1)
            {
                arParms[16].Value = DBNull.Value;
            }
            else
            {
                arParms[16].Value = user.Question;
            }

            arParms[17] = new SqlParameter("@HintAnswer", SqlDbType.VarChar, 100);
            if (user.Answer == null || user.Answer.Trim().Length < 1)
            {
                arParms[17].Value = DBNull.Value;
            }
            else
            {
                arParms[17].Value = user.Answer;
            }

            arParms[18] = new SqlParameter("@IsSecurityQuestionVerified", SqlDbType.Bit);
            arParms[18].Value = user.Login.IsSecurityQuestionVerified;

            if (sqltransaction == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveuser", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_saveuser", arParms);
            }
            returnvalue = (Int64)arParms[13].Value;
            return returnvalue;
        }

        /// <summary>
        /// Calls Sql Procedure to store a user's images corresponding to the user id passed.
        /// </summary>
        /// <returns></returns>
        public Int64 SaveUserImages(Int64 roleuserid, string mypicture, string teampicture, List<string> otherpictures,
            ERoleType roletype, int Mode, long Shell, SqlTransaction sqltransaction)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[18];
            arParms[0] = new SqlParameter("@userid1", SqlDbType.BigInt);
            arParms[0].Value = roleuserid;
            arParms[1] = new SqlParameter("@mypicture", SqlDbType.VarChar, 2000);
            arParms[1].Value = mypicture;
            if (mypicture.Trim().Length < 1)
            {
                arParms[1].Value = DBNull.Value;
            }
            else
            {
                arParms[1].Value = mypicture;
            }

            arParms[2] = new SqlParameter("@teampicture", SqlDbType.VarChar, 2000);
            if (teampicture.Trim().Length < 1)
            {
                arParms[2].Value = DBNull.Value;
            }
            else
            {
                arParms[2].Value = teampicture;
            }
            arParms[3] = new SqlParameter("@picture1", SqlDbType.VarChar, 2000);
            arParms[3].Value = otherpictures[0];
            arParms[4] = new SqlParameter("@picture2", SqlDbType.VarChar, 2000);
            arParms[4].Value = otherpictures[1];
            arParms[5] = new SqlParameter("@picture3", SqlDbType.VarChar, 2000);
            arParms[5].Value = otherpictures[2];
            arParms[6] = new SqlParameter("@picture4", SqlDbType.VarChar, 2000);
            arParms[6].Value = otherpictures[3];
            arParms[7] = new SqlParameter("@picture5", SqlDbType.VarChar, 2000);
            arParms[7].Value = otherpictures[4];
            arParms[8] = new SqlParameter("@picture6", SqlDbType.VarChar, 2000);
            arParms[8].Value = otherpictures[5];
            arParms[9] = new SqlParameter("@picture7", SqlDbType.VarChar, 2000);
            arParms[9].Value = otherpictures[6];
            arParms[10] = new SqlParameter("@picture8", SqlDbType.VarChar, 2000);
            arParms[10].Value = otherpictures[7];
            arParms[11] = new SqlParameter("@picture9", SqlDbType.VarChar, 2000);
            arParms[11].Value = otherpictures[8];
            arParms[12] = new SqlParameter("@picture10", SqlDbType.VarChar, 2000);
            arParms[12].Value = otherpictures[9];
            arParms[13] = new SqlParameter("@picture11", SqlDbType.VarChar, 2000);
            arParms[13].Value = otherpictures[10];
            arParms[14] = new SqlParameter("@picture12", SqlDbType.VarChar, 2000);
            arParms[14].Value = otherpictures[11];

            arParms[15] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[15].Value = Shell;
            arParms[16] = new SqlParameter("@userroletype", SqlDbType.VarChar, 500);
            arParms[16].Value = roletype.ToString();
            arParms[17] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[17].Direction = ParameterDirection.Output;
            if (sqltransaction == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveuserimage", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_saveuserimage", arParms);
            }
            returnvalue = (Int64)arParms[17].Value;
            return returnvalue;
        }

        #endregion

        #region "State"

        public ECity GetStateCityZipfromCode(string stateCode, string cityName, string zipCode, int countryId)
        {
            var arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@stateid", SqlDbType.VarChar, 100);
            arparams[1] = new SqlParameter("@cityid", SqlDbType.VarChar, 100);
            arparams[2] = new SqlParameter("@zipid", SqlDbType.VarChar, 100);

            arparams[0].Direction = ParameterDirection.Output;
            arparams[1].Direction = ParameterDirection.Output;
            arparams[2].Direction = ParameterDirection.Output;

            string sqlQuery = "SELECT @stateid=TS.StateID FROM dbo.TblState TS WHERE TS.StateCode = '" + stateCode +
                "' AND TS.CountryID = " + countryId + "; " +
                    " SELECT @cityid=TC.CityID FROM dbo.TblCity TC WHERE TC.[Name] = '" + cityName +
                        "' AND TC.StateID = @stateid ;   " +
                            " SELECT @zipid=TZ.ZipID FROM dbo.TblZip TZ WHERE TZ.ZipCode = '" + zipCode +
                                "' AND TZ.CityID = @cityid ";

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlQuery, arparams);

            var state = new EState();
            var city = new ECity();

            if (arparams[0].Value != null && arparams[0].Value != DBNull.Value)
            {
                state.StateID = Convert.ToInt32(arparams[0].Value);
            }

            if (arparams[1].Value != null && arparams[1].Value != DBNull.Value)
            {
                city.CityID = Convert.ToInt32(arparams[1].Value);
            }
            city.State = state;
            if (arparams[2].Value != null && arparams[2].Value != DBNull.Value)
            {
                city.Zipcode = new EZip();
                city.Zipcode.ZipID = Convert.ToInt32(arparams[2].Value);
            }
            return city;
        }

        public Int64 SaveState(EState State, int Mode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[7];
            arParms[0] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[0].Value = State.StateID;
            arParms[1] = new SqlParameter("@statename", SqlDbType.VarChar, 500);
            arParms[1].Value = State.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = State.Description;
            arParms[3] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[3].Value = State.Country.CountryID;
            arParms[4] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[4].Value = Mode;

            //arParms[5] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            //arParms[5].Value = UserID;
            //arParms[6] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            //arParms[6].Value = Shell;
            //arParms[7] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            //arParms[7].Value = Role;
            arParms[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[5].Direction = ParameterDirection.Output;
            arParms[6] = new SqlParameter("@statecode", SqlDbType.VarChar, 100);
            arParms[6].Value = State.StateCode;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savestate", arParms);
            returnvalue = (Int64)arParms[5].Value;
            return returnvalue;
        }

        public Int64 SaveState(String StateID, int Mode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@stateid", SqlDbType.VarChar, 3000);
            arParms[0].Value = StateID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            //arParms[2] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            //arParms[2].Value = UserID;
            //arParms[3] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            //arParms[3].Value = Shell;
            //arParms[4] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            //arParms[4].Value = Role;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removestate", arParms);
            returnvalue = (Int64)arParms[2].Value;
            return returnvalue;
        }

        public List<EState> GetState(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getstate",
                arParms);

            var returnState = new List<EState>();
            returnState = ParseStateDataSet(tempdataset);
            return returnState;
        }

        private List<EState> ParseStateDataSet(DataSet stateDataSet)
        {
            var returnState = new List<EState>();

            for (int count = 0; count < stateDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var state = new EState();
                    var country = new ECountry();
                    country.CountryID = Convert.ToInt32(stateDataSet.Tables[0].Rows[count]["CountryID"]);
                    country.Name = Convert.ToString(stateDataSet.Tables[0].Rows[count]["CountryName"]);
                    state.Active = Convert.ToBoolean(stateDataSet.Tables[0].Rows[count]["IsActive"]);
                    state.StateID = Convert.ToInt32(stateDataSet.Tables[0].Rows[count]["StateID"]);
                    state.Description = Convert.ToString(stateDataSet.Tables[0].Rows[count]["Description"]);
                    state.Name = Convert.ToString(stateDataSet.Tables[0].Rows[count]["Name"]);
                    state.StateCode = Convert.ToString(stateDataSet.Tables[0].Rows[count]["StateCode"]);
                    //state.Country.CountryID = Convert.ToInt32(stateDataSet.Tables[0].Rows[count]["CountryID"]);
                    //state.Country.Name = Convert.ToString(stateDataSet.Tables[0].Rows[count]["CountryName"]);
                    state.Country = country;
                    returnState.Add(state);
                }
                catch
                { }
            }
            return returnState;
        }

        #endregion


        #region "ItemType"

        public List<EItemType> GetItemType(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getitemtype",
                arParms);

            List<EItemType> returnItemType = ParseItemTypeDataSet(tempdataset);
            return returnItemType;
        }

        private List<EItemType> ParseItemTypeDataSet(DataSet itemtypeDataSet)
        {
            var returnItemType = new List<EItemType>();

            for (int count = 0; count < itemtypeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var itemtype = new EItemType();
                    itemtype.Active = Convert.ToBoolean(itemtypeDataSet.Tables[0].Rows[count]["IsActive"]);
                    itemtype.ItemTypeID = Convert.ToInt32(itemtypeDataSet.Tables[0].Rows[count]["ItemTypeID"]);
                    itemtype.Description = Convert.ToString(itemtypeDataSet.Tables[0].Rows[count]["Description"]);
                    itemtype.Name = Convert.ToString(itemtypeDataSet.Tables[0].Rows[count]["Name"]);
                    itemtype.TestAssociated =
                        Convert.ToBoolean(itemtypeDataSet.Tables[0].Rows[count]["IsTestAssociated"]);
                    returnItemType.Add(itemtype);
                }
                catch
                { }
            }
            return returnItemType;
        }

        #endregion

        #region "Payment"

        /// <summary>
        /// THIS FUNCTION SAVE PAYMENT INFORMATION INCLUDING REPORT AMOUNT AND COUPON DETAIL. 
        /// SavePaymentDetails MAY BE OBSOLETE
        /// </summary>
        public Int64 SavePaymentInformation(EEventCustomer objEventCustomer, string UserID, string Shell, string Role,
            SqlTransaction sqltransaction)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[16];
            arParms[0] = new SqlParameter("@packagecost", SqlDbType.Decimal, 18);
            arParms[0].Value = objEventCustomer.EventPackage.PackagePrice;
            arParms[1] = new SqlParameter("@reportmailcost", SqlDbType.Decimal, 18);
            arParms[1].Value = objEventCustomer.ReportEmailAmt;
            arParms[2] = new SqlParameter("@coupondiscount", SqlDbType.Decimal, 18);
            arParms[2].Value = objEventCustomer.Coupon.CouponAmount;
            arParms[3] = new SqlParameter("@paymenttypeid", SqlDbType.BigInt);
            arParms[3].Value = objEventCustomer.PaymentDetail.PaymentType.PaymentTypeID;

            arParms[4] = new SqlParameter("@paymentuserid", SqlDbType.BigInt);
            if (objEventCustomer.CallCenterCallCenterUser == null)
            {
                arParms[4].Value = DBNull.Value;
            }
            else
            {
                arParms[4].Value = objEventCustomer.CallCenterCallCenterUser.CallCenterCallCenterUserID;
            }


            arParms[5] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arParms[5].Value = objEventCustomer.Customer.CustomerID;
            arParms[6] = new SqlParameter("@couponid", SqlDbType.BigInt);
            arParms[6].Value = objEventCustomer.Coupon.CouponID;
            arParms[7] = new SqlParameter("@userid", SqlDbType.VarChar, 500);
            arParms[7].Value = UserID;
            arParms[8] = new SqlParameter("@shell", SqlDbType.VarChar, 500);
            arParms[8].Value = Shell;
            arParms[9] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[9].Value = Role;
            arParms[10] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[10].Direction = ParameterDirection.Output;
            arParms[11] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[11].Value = objEventCustomer.EventID;
            arParms[12] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arParms[12].Value = objEventCustomer.CustomerEventTestID;

            arParms[13] = new SqlParameter("@mailreports", SqlDbType.Bit);
            arParms[13].Value = objEventCustomer.ReportEmail;
            arParms[14] = new SqlParameter("@packagecostapplicable", SqlDbType.Bit);
            if (objEventCustomer.EventPackage.Package.PackageID > 0)
            {
                arParms[14].Value = true;
            }
            else
            {
                arParms[14].Value = false;
            }

            arParms[15] = new SqlParameter("@paymentdetailsid", SqlDbType.BigInt);
            arParms[15].Value = objEventCustomer.PaymentDetail.PaymentDetailID;

            if (sqltransaction != null)
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_savepaymentinformation",
                    arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savepaymentinformation",
                    arParms);
            }

            returnvalue = Convert.ToInt32(arParms[10].Value);
            return returnvalue;
        }

        /// <summary>
        /// Saves credit card payment details in db
        /// </summary>
        public Int64 SaveCreditCardPaymentDetails(ECreditCardPaymentDetail cardpaymentdetails, string UserID,
            string Shell, string Role, Int16 mode, SqlTransaction sqltransaction)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[14];
            arParms[0] = new SqlParameter("@creditcardpaymentID", SqlDbType.BigInt);
            arParms[0].Value = cardpaymentdetails.CreditCardPaymentID;
            arParms[1] = new SqlParameter("@creditcardnumber", SqlDbType.VarChar, 50);
            arParms[1].Value = cardpaymentdetails.CreditCardNumber;
            arParms[2] = new SqlParameter("@creditcardtypeid", SqlDbType.BigInt);
            arParms[2].Value = cardpaymentdetails.CreditCardType.CreditCardTypeID;
            arParms[3] = new SqlParameter("@paymentid", SqlDbType.BigInt);
            arParms[3].Value = cardpaymentdetails.PaymentID;
            arParms[4] = new SqlParameter("@paymentstatus", SqlDbType.VarChar, 50);
            arParms[4].Value = cardpaymentdetails.PaymentStatus;
            arParms[5] = new SqlParameter("@expirationdate", SqlDbType.DateTime);
            arParms[5].Value = cardpaymentdetails.ExpirationDate;

            arParms[6] = new SqlParameter("@userid", SqlDbType.VarChar, 500);
            arParms[6].Value = UserID;
            arParms[7] = new SqlParameter("@shell", SqlDbType.VarChar, 500);
            arParms[7].Value = Shell;
            arParms[8] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[8].Value = Role;
            arParms[9] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[9].Value = mode;
            arParms[10] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[10].Direction = ParameterDirection.Output;

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
            {
                arParms[12].Value = cardpaymentdetails.SecurityCode;
            }
            else
            {
                arParms[12].Value = DBNull.Value;
            }

            arParms[13] = new SqlParameter("@drorcr", SqlDbType.Bit);
            arParms[13].Value = cardpaymentdetails.DrOrCr;

            if (sqltransaction != null)
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure,
                    "usp_savecreditcardpaymentdetails", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                    "usp_savecreditcardpaymentdetails", arParms);
            }

            returnvalue = Convert.ToInt32(arParms[10].Value);
            return returnvalue;
        }

        /// <summary>
        /// saves cheque payment details in db
        /// </summary>
        public Int64 SaveChequePaymentDetails(EChequePaymentDetail chequepaymentdetails, string UserID, string Shell,
            string Role, Int16 mode, SqlTransaction sqltransaction)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[12];
            arParms[0] = new SqlParameter("@chequenumber", SqlDbType.VarChar, 50);
            arParms[0].Value = chequepaymentdetails.ChequeNumber;
            arParms[1] = new SqlParameter("@routingnumber", SqlDbType.VarChar, 50);
            arParms[1].Value = chequepaymentdetails.RoutingNumber;
            arParms[2] = new SqlParameter("@bankname", SqlDbType.VarChar, 50);
            arParms[2].Value = chequepaymentdetails.BankName;
            arParms[3] = new SqlParameter("@accountnumber", SqlDbType.VarChar, 50);
            arParms[3].Value = chequepaymentdetails.AccountNumber;
            arParms[4] = new SqlParameter("@paymentstatus", SqlDbType.VarChar, 50);
            arParms[4].Value = chequepaymentdetails.PaymentStatus;
            arParms[5] = new SqlParameter("@paymentid", SqlDbType.BigInt);
            arParms[5].Value = chequepaymentdetails.PaymentID;

            arParms[6] = new SqlParameter("@userid", SqlDbType.VarChar, 500);
            arParms[6].Value = UserID;
            arParms[7] = new SqlParameter("@shell", SqlDbType.VarChar, 500);
            arParms[7].Value = Shell;
            arParms[8] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[8].Value = Role;
            arParms[9] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[9].Value = mode;
            arParms[10] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[10].Direction = ParameterDirection.Output;

            arParms[11] = new SqlParameter("@drorcr", SqlDbType.Bit);
            arParms[11].Value = chequepaymentdetails.DrorCr;

            if (sqltransaction != null)
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_savechequepaymentdetails",
                    arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savechequepaymentdetails",
                    arParms);
            }

            returnvalue = Convert.ToInt32(arParms[10].Value);
            return returnvalue;
        }

        /// <summary>
        /// saves cash payment details in db
        /// </summary>
        public Int64 SaveCashPaymentDetails(ECashPaymentDetail cashpaymentdetails, string UserID, string Shell,
            string Role, Int16 mode, SqlTransaction sqltransaction)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@paymentstatus", SqlDbType.VarChar, 50);
            arParms[0].Value = "Recieved";
            arParms[1] = new SqlParameter("@amount", SqlDbType.Decimal);
            if (cashpaymentdetails.CashAmount > 0)
            {
                arParms[1].Value = cashpaymentdetails.CashAmount;
            }
            else
            {
                arParms[1].Value = 0.00;
            }

            arParms[2] = new SqlParameter("@paymentid", SqlDbType.BigInt);
            arParms[2].Value = cashpaymentdetails.PaymentID;
            arParms[3] = new SqlParameter("@drorcr", SqlDbType.VarChar, 50);
            arParms[3].Value = cashpaymentdetails.DrorCr;

            arParms[4] = new SqlParameter("@userid", SqlDbType.VarChar, 500);
            arParms[4].Value = UserID;
            arParms[5] = new SqlParameter("@shell", SqlDbType.VarChar, 500);
            arParms[5].Value = Shell;
            arParms[6] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[6].Value = Role;
            arParms[7] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[7].Value = mode;
            arParms[8] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[8].Direction = ParameterDirection.Output;

            if (sqltransaction != null)
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_savecashpaymentdetails",
                    arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savecashpaymentdetails",
                    arParms);
            }

            returnvalue = Convert.ToInt32(arParms[8].Value);
            return returnvalue;
        }

        public List<EPaymentType> GetPaymentType(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getpaymenttype",
                arParms);

            var returnPaymentType = new List<EPaymentType>();
            returnPaymentType = ParsePaymentTypeDataSet(tempdataset);
            return returnPaymentType;
        }

        public List<ECreditCardType> GetCreditCardTypes(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getcreditcardtype", arParms);

            return ParseCreditCardTypes(tempdataset);
        }

        private List<ECreditCardType> ParseCreditCardTypes(DataSet dstemp)
        {
            var cardtype = new List<ECreditCardType>();

            if (dstemp == null || dstemp.Tables.Count < 1)
            {
                return cardtype;
            }

            for (int icount = 0; icount < dstemp.Tables[0].Rows.Count; icount++)
            {
                var creditcardtype = new ECreditCardType
                {
                    CreditCardTypeID = Convert.ToInt32(dstemp.Tables[0].Rows[icount]["CreditCardTypeID"]),
                    Name = Convert.ToString(dstemp.Tables[0].Rows[icount]["Name"]),
                    Active = Convert.ToBoolean(dstemp.Tables[0].Rows[icount]["IsActive"])
                };
                cardtype.Add(creditcardtype);
            }

            return cardtype;
        }

        private List<EPaymentType> ParsePaymentTypeDataSet(DataSet paymenttypeDataSet)
        {
            var returnPaymentType = new List<EPaymentType>();

            for (int count = 0; count < paymenttypeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var paymenttype = new EPaymentType();
                    paymenttype.Active = Convert.ToBoolean(paymenttypeDataSet.Tables[0].Rows[count]["IsActive"]);
                    paymenttype.PaymentTypeID =
                        Convert.ToInt32(paymenttypeDataSet.Tables[0].Rows[count]["PaymentTypeID"]);
                    paymenttype.Description = Convert.ToString(paymenttypeDataSet.Tables[0].Rows[count]["Description"]);
                    paymenttype.Name = Convert.ToString(paymenttypeDataSet.Tables[0].Rows[count]["Name"]);
                    returnPaymentType.Add(paymenttype);
                }
                catch
                { }
            }
            return returnPaymentType;
        }

        /// <summary>
        /// Set PayementDetail for Public Site
        /// </summary>
        /// <param name="strStatus"></param>
        /// <param name="UserId"></param>
        /// <param name="PaymentDetailId"></param>
        /// <returns></returns>
        public Int64 SetPaymentDetails(string strStatus, Int64 UserId, Int64 PaymentDetailId, string CCName, string CVV)
        {
            var arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@status", SqlDbType.VarChar, 2000);
            arParms[0].Value = strStatus;

            arParms[1] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[1].Value = UserId;

            arParms[2] = new SqlParameter("@paymentdetailId", SqlDbType.BigInt);
            arParms[2].Value = PaymentDetailId;

            arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;

            arParms[4] = new SqlParameter("@CCName", SqlDbType.VarChar, 50);
            arParms[4].Value = CCName;

            arParms[5] = new SqlParameter("@CVV", SqlDbType.VarChar, 200);
            arParms[5].Value = CVV;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_UI_setpaymentresponse",
                arParms);
            return Convert.ToInt64(arParms[3].Value);
        }

        public Int64 InsertFailCCInformation(ECreditCardPaymentDetail objCCPaymentDetail, string CCName)
        {
            var arPrams = new SqlParameter[8];

            arPrams[0] = new SqlParameter("@CreditCardNumber", SqlDbType.VarChar, 50);
            arPrams[0].Value = objCCPaymentDetail.CreditCardNumber;

            arPrams[1] = new SqlParameter("@CreditCardTypeID", SqlDbType.BigInt);
            arPrams[1].Value = objCCPaymentDetail.CreditCardType.CreditCardTypeID;

            arPrams[2] = new SqlParameter("@PaymentID", SqlDbType.BigInt);
            arPrams[2].Value = objCCPaymentDetail.PaymentID;

            arPrams[3] = new SqlParameter("@PaymentStatus", SqlDbType.VarChar, 50);
            arPrams[3].Value = objCCPaymentDetail.PaymentStatus;

            arPrams[4] = new SqlParameter("@ExpirationDate", SqlDbType.DateTime);
            arPrams[4].Value = objCCPaymentDetail.ExpirationDate;

            arPrams[5] = new SqlParameter("@CCName", SqlDbType.VarChar, 50);
            arPrams[5].Value = CCName;

            arPrams[6] = new SqlParameter("@CVV", SqlDbType.VarChar, 50);
            arPrams[6].Value = objCCPaymentDetail.SecurityCode;

            arPrams[7] = new SqlParameter("@CreditCardPaymentID", SqlDbType.BigInt);
            arPrams[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_insertfailccinformation",
                arPrams);

            Int64 returnvalue;
            returnvalue = Convert.ToInt64(arPrams[7].Value);
            return returnvalue;
        }

        /// <summary>
        /// Save eCheck Info
        /// </summary>
        /// <param name="objECheck"></param>
        /// <returns></returns>
        public Int64 SaveECheckPaymentDetails(EECheckPaymentDetails objECheck, SqlTransaction sqltransaction)
        {
            var arParms = new SqlParameter[12];

            arParms[0] = new SqlParameter("@RoutingNumber", SqlDbType.VarChar, 50);
            arParms[0].Value = objECheck.RoutingNumber;

            arParms[1] = new SqlParameter("@AccountNumber", SqlDbType.VarChar, 50);
            arParms[1].Value = objECheck.AccountNumber;

            arParms[2] = new SqlParameter("@AccountType", SqlDbType.VarChar, 50);
            arParms[2].Value = objECheck.AccountType;

            arParms[3] = new SqlParameter("@ECheckNumber", SqlDbType.VarChar, 10);
            arParms[3].Value = objECheck.EChequeNumber;

            arParms[4] = new SqlParameter("@BankName", SqlDbType.VarChar, 50);
            arParms[4].Value = objECheck.BankName;

            arParms[5] = new SqlParameter("@AccountHolder", SqlDbType.VarChar, 200);
            arParms[5].Value = objECheck.AccountHolder;

            arParms[6] = new SqlParameter("@PaymentID", SqlDbType.BigInt);
            arParms[6].Value = objECheck.PaymentID;

            arParms[7] = new SqlParameter("@PaymentStatus", SqlDbType.VarChar, 5000);
            arParms[7].Value = objECheck.PaymentStatus;

            arParms[8] = new SqlParameter("@Status", SqlDbType.VarChar, 20);
            arParms[8].Value = objECheck.Status;

            arParms[9] = new SqlParameter("@DrOrCr", SqlDbType.Bit);
            arParms[9].Value = objECheck.DrorCr;

            arParms[10] = new SqlParameter("@TransactionID", SqlDbType.VarChar, 20);
            arParms[10].Value = objECheck.TransactionID;

            arParms[11] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[11].Direction = ParameterDirection.Output;
            if (sqltransaction != null)
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_SaveECheckPaymentDetails",
                    arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_SaveECheckPaymentDetails",
                    arParms);
            }

            Int64 returnresult = Convert.ToInt64(arParms[11].Value);
            return returnresult;
        }

        #endregion

        #region "Events"

        public long GetNextCustomerforPostAudit(long eventId, long customerId)
        {
            var parameterSql = new[]
            {
                new SqlParameter("@eventId", SqlDbType.BigInt) {Value = eventId},
                new SqlParameter("@customerId", SqlDbType.BigInt) {Value = customerId},
                new SqlParameter("@returnId", SqlDbType.BigInt) {Direction = ParameterDirection.Output}
            };

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_getNextCustomerforPostAudit",
                parameterSql);

            if (parameterSql[2].Value != null && parameterSql[2].Value != DBNull.Value)
            {
                return Convert.ToInt64(parameterSql[2].Value);
            }

            return 0;
        }

        /// <summary>
        /// Fetches List of Customers, for an event, with missing Records.
        /// </summary>
        /// <param name="EventID"></param>
        /// <returns></returns>
        public List<EEndOfDayInfo> GetEndofDayListing(Int64 EventID, out bool blnTechTeamConfigured, out bool blnSignOff)
        {
            blnTechTeamConfigured = false;
            blnSignOff = false;
            // declare all parameters
            var arParms = new SqlParameter[2];
            // eventid
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = EventID;
            // tech team configured flag
            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.Bit);
            arParms[1].Direction = ParameterDirection.Output;

            DataSet dsEndofdayInfo = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getendofdaylist", arParms);
            if (dsEndofdayInfo == null)
            {
                return null;
            }
            if ((dsEndofdayInfo.Tables[0].Rows.Count < 1) && (dsEndofdayInfo.Tables.Count == 1))
            {
                return null;
            }

            var lstEndOfDayInfo = new List<EEndOfDayInfo>();
            foreach (DataRow dr in dsEndofdayInfo.Tables[0].Rows)
            {
                var objEndOfDayinfo = new EEndOfDayInfo();

                objEndOfDayinfo.FirstName = dr["FirstName"].ToString().Trim();
                objEndOfDayinfo.LastName = dr["LastName"].ToString().Trim();
                objEndOfDayinfo.MiddleName = dr["MiddleName"].ToString().Trim();
                objEndOfDayinfo.CustomerID = Convert.ToInt64(dr["CustomerID"]);

                objEndOfDayinfo.AAAInfo = Convert.ToBoolean(dr["AAAInfo"]);
                objEndOfDayinfo.StrokeInfo = Convert.ToBoolean(dr["StrokeInfo"]);
                objEndOfDayinfo.MedicalHistory = Convert.ToBoolean(dr["MedicalHistory"]);

                objEndOfDayinfo.StartTime = Convert.ToBoolean(dr["CheckInTime"]);
                objEndOfDayinfo.EndTime = Convert.ToBoolean(dr["CheckOutTime"]);
                objEndOfDayinfo.PaymentInfo = Convert.ToBoolean(dr["PaymentInfo"]);

                objEndOfDayinfo.DOB = Convert.ToBoolean(dr["DOB"]);
                objEndOfDayinfo.Phone = Convert.ToBoolean(dr["Phone"]);
                objEndOfDayinfo.Gender = Convert.ToBoolean(dr["Gender"]);
                objEndOfDayinfo.Race = Convert.ToBoolean(dr["Race"]);
                objEndOfDayinfo.Height = Convert.ToBoolean(dr["Height"]);
                objEndOfDayinfo.Weight = Convert.ToBoolean(dr["Weight"]);
                objEndOfDayinfo.PCP = Convert.ToBoolean(dr["PCP"]);

                objEndOfDayinfo.City = Convert.ToBoolean(dr["City"]);
                objEndOfDayinfo.State = Convert.ToBoolean(dr["State"]);
                objEndOfDayinfo.Zip = Convert.ToBoolean(dr["Zip"]);

                objEndOfDayinfo.HIPAAStatus = (short)(dr["HIPAAStatus"]);
                objEndOfDayinfo.AppointmentTime = Convert.ToDateTime(dr["AppointmentTime"]).ToString("hh:mm tt");

                objEndOfDayinfo.IsAuthorized = Convert.ToBoolean(dr["IsAuthorized"]);

                lstEndOfDayInfo.Add(objEndOfDayinfo);
            }
            // tech team configured
            blnTechTeamConfigured = Convert.ToBoolean(arParms[1].Value);

            if (dsEndofdayInfo.Tables.Count > 1 && dsEndofdayInfo.Tables[1].Rows.Count > 0)
            {
                blnSignOff = Convert.ToBoolean(dsEndofdayInfo.Tables[1].Rows[0]["IsSignoff"]);
                if (lstEndOfDayInfo == null || lstEndOfDayInfo.Count == 0)
                {
                    // initilized first index if not
                    var objEndOfDayinfo = new EEndOfDayInfo();
                    lstEndOfDayInfo.Add(objEndOfDayinfo);
                }

                lstEndOfDayInfo[0].IsSignOff = Convert.ToBoolean(dsEndofdayInfo.Tables[1].Rows[0]["IsSignoff"]);
                lstEndOfDayInfo[0].SignoffByUserId = Convert.ToInt64(dsEndofdayInfo.Tables[1].Rows[0]["SignoffByUserId"]);
                if (dsEndofdayInfo.Tables[1].Rows[0]["SignoffDatetime"] != DBNull.Value)
                {
                    lstEndOfDayInfo[0].SignoffDatetime =
                        Convert.ToDateTime(dsEndofdayInfo.Tables[1].Rows[0]["SignoffDatetime"]).ToString(
                            "MM/dd/yyyy hh:mm tt");
                }
                lstEndOfDayInfo[0].SignoffBy = Convert.ToString(dsEndofdayInfo.Tables[1].Rows[0]["SignoffBy"]);

                // reset flag if customer register after signoff process
                if (dsEndofdayInfo.Tables[0].Rows.Count > 0 && lstEndOfDayInfo[0].IsSignOff)
                {
                    UpdateEventSignOff(0, EventID, 0, 0);
                }
            }
            return lstEndOfDayInfo;
        }

        public bool UpdateEventSignOff(Int64 UserIdNumber, Int64 EventIdNumber, int roleIdNumber, int shellIdNumber)
        {
            int returnvalue = 0;
            var arParms = new SqlParameter[5];
            // eventid
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = EventIdNumber;
            // user id
            arParms[1] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[1].Value = UserIdNumber;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.TinyInt);
            arParms[2].Direction = ParameterDirection.Output;

            arParms[3] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[3].Value = roleIdNumber;

            arParms[4] = new SqlParameter("@shellid", SqlDbType.Int);
            arParms[4].Value = shellIdNumber;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_updateeventsignoff", arParms);
            returnvalue = Convert.ToInt16(arParms[2].Value);
            if (returnvalue > 0)
            {
                return false;
            }
            return true;
        }

        public List<EEventActivityTemplate> GetEventActivityTemplateEventWizard(long hostId)
        {
            var arparam = new SqlParameter("@hostid", SqlDbType.BigInt);
            arparam.Value = hostId;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_geteventactivitytemplateForEventWizard", arparam);

            var lsteventactiviyttemplate = new List<EEventActivityTemplate>();
            foreach (DataRow dr in dstemp.Tables[0].Rows)
            {
                var objeventactivity = new EEventActivityTemplate();
                objeventactivity.EventActivityTemplateID = Convert.ToInt64(dr["EventActivityTemplateID"]);
                objeventactivity.Name = dr["TemplateName"].ToString();
                objeventactivity.IsActive = Convert.ToBoolean(dr["IsActive"]);
                objeventactivity.DateCreated = Convert.ToString(dr["DateCreated"]);
                lsteventactiviyttemplate.Add(objeventactivity);
            }
            return lsteventactiviyttemplate;
        }

        public EEventActivityTemplate GetEventActivityTemplatebyID(int eventtemplateid)
        {
            var arparam = new SqlParameter("@activitytemplateid", SqlDbType.BigInt);
            arparam.Value = eventtemplateid;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_geteventactivitytemplatebyid", arparam);
            return ParseEventActivityTemplateDataset(dstemp);
        }

        private EEventActivityTemplate ParseEventActivityTemplateDataset(DataSet dstemp)
        {
            if (dstemp == null)
            {
                return null;
            }
            if (dstemp.Tables[0].Rows.Count < 1)
            {
                return null;
            }

            var objeventactivitytemplate = new EEventActivityTemplate();

            objeventactivitytemplate.EventActivityTemplateID =
                Convert.ToInt32(dstemp.Tables[0].Rows[0]["EventActivityTemplateID"]);
            objeventactivitytemplate.Name = Convert.ToString(dstemp.Tables[0].Rows[0]["TemplateName"]);

            objeventactivitytemplate.ListHostIDs = new List<long>();
            foreach (DataRow drhost in dstemp.Tables[1].Rows)
            {
                objeventactivitytemplate.ListHostIDs.Add(Convert.ToInt64(drhost["HostID"]));
            }

            objeventactivitytemplate.ListActivities = new List<EEventActivityTemplateActivity>();
            foreach (DataRow drtask in dstemp.Tables[2].Rows)
            {
                var objeventactivity = new EEventActivityTemplateActivity();
                objeventactivity.EventActivity = EEventActivity.Task;
                objeventactivity.ActivityID = Convert.ToInt64(drtask["EventActivityTemplateTaskID"]);
                objeventactivity.ActivityDay = Convert.ToInt32(drtask["TaskDuration"]);
                objeventactivity.ForAfterEvent = Convert.ToBoolean(drtask["ForAfterEvent"]);
                objeventactivity.Notes = Convert.ToString(drtask["Notes"]);
                objeventactivity.ResponsibleRoleID = Convert.ToInt32(drtask["ResponsibleRoleID"]);
                objeventactivity.ResponsibleRoleShellID = Convert.ToInt32(drtask["ResponsibleRoleShellID"]);
                objeventactivity.ResponsibleSpecifiedEmail = Convert.ToString(drtask["ResponsibleEmailSpecified"]);
                objeventactivity.ResponsibleRoleName = Convert.ToString(drtask["ResponsibleRoleName"]);
                objeventactivity.Subject = Convert.ToString(drtask["Subject"]);
                if (drtask["UserName"] != DBNull.Value)
                {
                    objeventactivity.SpecifiedUserName = Convert.ToString(drtask["UserName"]);
                }
                objeventactivitytemplate.ListActivities.Add(objeventactivity);
            }

            foreach (DataRow drcall in dstemp.Tables[3].Rows)
            {
                var objeventactivity = new EEventActivityTemplateActivity();
                objeventactivity.EventActivity = EEventActivity.Call;
                objeventactivity.ActivityID = Convert.ToInt64(drcall["EventActivityTemplateCallID"]);
                objeventactivity.ActivityDay = Convert.ToInt32(drcall["CallingDay"]);
                objeventactivity.ForAfterEvent = Convert.ToBoolean(drcall["ForAfterEvent"]);
                objeventactivity.Notes = Convert.ToString(drcall["Notes"]);
                objeventactivity.ResponsibleRoleID = Convert.ToInt32(drcall["ResponsibleRoleID"]);
                objeventactivity.ResponsibleRoleShellID = Convert.ToInt32(drcall["ResponsibleRoleShellID"]);
                objeventactivity.ResponsibleSpecifiedEmail = Convert.ToString(drcall["ResponsibleEmailSpecified"]);
                objeventactivity.ResponsibleRoleName = Convert.ToString(drcall["ResponsibleRoleName"]);
                objeventactivity.Subject = Convert.ToString(drcall["Subject"]);
                if (drcall["UserName"] != DBNull.Value)
                {
                    objeventactivity.SpecifiedUserName = Convert.ToString(drcall["UserName"]);
                }
                objeventactivitytemplate.ListActivities.Add(objeventactivity);
            }

            foreach (DataRow drmeeting in dstemp.Tables[4].Rows)
            {
                var objeventactivity = new EEventActivityTemplateActivity();
                objeventactivity.EventActivity = EEventActivity.Meeting;
                objeventactivity.ActivityID = Convert.ToInt64(drmeeting["EventActivityTemplateMeetingID"]);
                objeventactivity.ActivityDay = Convert.ToInt32(drmeeting["MeetingDay"]);
                objeventactivity.ForAfterEvent = Convert.ToBoolean(drmeeting["ForAfterEvent"]);
                objeventactivity.Notes = Convert.ToString(drmeeting["Notes"]);
                objeventactivity.ResponsibleRoleID = Convert.ToInt32(drmeeting["ResponsibleRoleID"]);
                objeventactivity.ResponsibleRoleShellID = Convert.ToInt32(drmeeting["ResponsibleRoleShellID"]);
                objeventactivity.ResponsibleSpecifiedEmail = Convert.ToString(drmeeting["ResponsibleEmailSpecified"]);
                objeventactivity.ResponsibleRoleName = Convert.ToString(drmeeting["ResponsibleRoleName"]);
                objeventactivity.Subject = Convert.ToString(drmeeting["Subject"]);
                if (drmeeting["UserName"] != DBNull.Value)
                {
                    objeventactivity.SpecifiedUserName = Convert.ToString(drmeeting["UserName"]);
                }
                objeventactivitytemplate.ListActivities.Add(objeventactivity);
            }

            foreach (DataRow dremail in dstemp.Tables[5].Rows)
            {
                var objeventactivity = new EEventActivityTemplateActivity();
                objeventactivity.EventActivity = EEventActivity.EMail;
                objeventactivity.ActivityID = Convert.ToInt64(dremail["EventActivityTemplateEmailID"]);
                objeventactivity.ActivityDay = Convert.ToInt32(dremail["EmailSentDay"]);
                objeventactivity.EmailContent = Convert.ToString(dremail["EmailContent"]);
                objeventactivity.ForAfterEvent = Convert.ToBoolean(dremail["ForAfterEvent"]);
                objeventactivity.ResponsibleRoleID = Convert.ToInt32(dremail["ResponsibleRoleID"]);
                objeventactivity.ResponsibleRoleShellID = Convert.ToInt32(dremail["ResponsibleRoleShellID"]);
                objeventactivity.ResponsibleSpecifiedEmail = Convert.ToString(dremail["ResponsibleEmailSpecified"]);
                objeventactivity.ResponsibleRoleName = Convert.ToString(dremail["ResponsibleRoleName"]);
                objeventactivity.Subject = Convert.ToString(dremail["Subject"]);
                if (dremail["UserName"] != DBNull.Value)
                {
                    objeventactivity.SpecifiedUserName = Convert.ToString(dremail["UserName"]);
                }
                objeventactivitytemplate.ListActivities.Add(objeventactivity);
            }
            return objeventactivitytemplate;
        }

        public Int64 SaveEventActivityTemplate(EEventActivityTemplate objeventactivitytemplate, int roleid,
            Int64 roleshellid, bool isglobal)
        {
            Int64 returnvalue = 0;
            var arparams = new SqlParameter[6];
            arparams[0] = new SqlParameter("@eventactivitytemplateid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@templatename", SqlDbType.VarChar, 500);
            arparams[2] = new SqlParameter("@isglobal", SqlDbType.Bit);
            arparams[3] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arparams[4] = new SqlParameter("@roleshellid", SqlDbType.BigInt);
            arparams[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt);

            arparams[0].Value = objeventactivitytemplate.EventActivityTemplateID;
            arparams[1].Value = objeventactivitytemplate.Name;
            arparams[2].Value = isglobal;
            arparams[3].Value = roleid;
            arparams[4].Value = roleshellid;
            arparams[5].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventactivitytemplate",
                arparams);

            if (arparams[5].Value == DBNull.Value)
            {
                returnvalue = -1;
            }
            else
            {
                returnvalue = Convert.ToInt64(arparams[5].Value);
            }

            if (returnvalue >= 0)
            {
                if (objeventactivitytemplate.EventActivityTemplateID > 0)
                {
                    returnvalue = objeventactivitytemplate.EventActivityTemplateID;
                }

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text,
                    "UPDATE [TblEventActivityTemplateHost] SET [IsActive] = 0 WHERE [EventActivityTemplateID] = " +
                        returnvalue);

                var arparamhost = new SqlParameter[2];
                arparamhost[0] = new SqlParameter("@eventtemplateactivityid", SqlDbType.BigInt);
                arparamhost[1] = new SqlParameter("@hostid", SqlDbType.BigInt);

                foreach (Int64 hostid in objeventactivitytemplate.ListHostIDs)
                {
                    arparamhost[0].Value = returnvalue;
                    arparamhost[1].Value = hostid;

                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                        "usp_saveeventactivitytemplatehost", arparamhost);
                }

                SaveEventActivityTemplateActivity(objeventactivitytemplate.ListActivities, returnvalue);
            }

            return returnvalue;
        }

        private void SaveEventActivityTemplateActivity(List<EEventActivityTemplateActivity> listeventactivity,
            Int64 eventactivitytemplateid)
        {
            string strTaskIds, strCallIDs, strMeetingIDs, strEmailIDs;
            strTaskIds = strCallIDs = strMeetingIDs = strEmailIDs = "";

            foreach (EEventActivityTemplateActivity objeventactivity in listeventactivity)
            {
                if (objeventactivity.ActivityID < 1)
                {
                    continue;
                }

                if (objeventactivity.EventActivity == EEventActivity.Call)
                {
                    strCallIDs += objeventactivity.ActivityID + ", ";
                }
                else if (objeventactivity.EventActivity == EEventActivity.Meeting)
                {
                    strMeetingIDs += objeventactivity.ActivityID + ", ";
                }
                else if (objeventactivity.EventActivity == EEventActivity.Task)
                {
                    strTaskIds += objeventactivity.ActivityID + ", ";
                }
                else if (objeventactivity.EventActivity == EEventActivity.EMail)
                {
                    strEmailIDs += objeventactivity.ActivityID + ", ";
                }
            }

            string strquery = "";
            if (strTaskIds.Trim().Length > 0)
            {
                strTaskIds = strTaskIds.Remove(strTaskIds.LastIndexOf(", "), 2);
                strquery = strquery + " DELETE FROM [TblEventActivityTemplateTask] WHERE [EventActivityTemplateID] = " +
                    eventactivitytemplateid + " AND [EventActivityTemplateTaskID] NOT IN (" +
                        strTaskIds + ") ";
            }
            else
            {
                strquery = strquery + " DELETE FROM [TblEventActivityTemplateTask] WHERE [EventActivityTemplateID] = " +
                    eventactivitytemplateid;
            }

            if (strCallIDs.Trim().Length > 0)
            {
                strCallIDs = strCallIDs.Remove(strCallIDs.LastIndexOf(", "), 2);
                strquery = strquery + " DELETE FROM [TblEventActivityTemplateCall] WHERE [EventActivityTemplateID] = " +
                    eventactivitytemplateid + " AND [EventActivityTemplateCallID] NOT IN (" +
                        strCallIDs + ") ";
            }
            else
            {
                strquery = strquery + " DELETE FROM [TblEventActivityTemplateCall] WHERE [EventActivityTemplateID] = " +
                    eventactivitytemplateid;
            }

            if (strMeetingIDs.Trim().Length > 0)
            {
                strMeetingIDs = strMeetingIDs.Remove(strMeetingIDs.LastIndexOf(", "), 2);
                strquery = strquery +
                    " DELETE FROM [TblEventActivityTemplateMeeting] WHERE [EventActivityTemplateID] = " +
                        eventactivitytemplateid + " AND [EventActivityTemplateMeetingID] NOT IN (" +
                            strMeetingIDs + ") ";
            }
            else
            {
                strquery = strquery +
                    " DELETE FROM [TblEventActivityTemplateMeeting] WHERE [EventActivityTemplateID] = " +
                        eventactivitytemplateid;
            }

            if (strEmailIDs.Trim().Length > 0)
            {
                strEmailIDs = strEmailIDs.Remove(strEmailIDs.LastIndexOf(", "), 2);
                strquery = strquery + " DELETE FROM [TblEventActivityTemplateEmail] WHERE [EventActivityTemplateID] = " +
                    eventactivitytemplateid + " AND [EventActivityTemplateEmailID] NOT IN (" +
                        strEmailIDs + ") ";
            }
            else
            {
                strquery = strquery + " DELETE FROM [TblEventActivityTemplateEmail] WHERE [EventActivityTemplateID] = " +
                    eventactivitytemplateid;
            }

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, strquery);

            var arparams = new SqlParameter[12];
            arparams[0] = new SqlParameter("@activityid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@eventactivitytemplateid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@subject", SqlDbType.VarChar, 500);
            arparams[3] = new SqlParameter("@notes", SqlDbType.VarChar, 2000);
            arparams[4] = new SqlParameter("@when", SqlDbType.Int);
            arparams[5] = new SqlParameter("@forafterevent", SqlDbType.Bit);
            arparams[6] = new SqlParameter("@rolename", SqlDbType.VarChar, 200);
            arparams[7] = new SqlParameter("@roleshellid", SqlDbType.BigInt);
            arparams[8] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arparams[9] = new SqlParameter("@specifiedemail", SqlDbType.VarChar, 200);
            arparams[10] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[11] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arparams[11].Direction = ParameterDirection.Output;

            foreach (EEventActivityTemplateActivity objeventactivity in listeventactivity)
            {
                arparams[0].Value = objeventactivity.ActivityID;
                arparams[1].Value = eventactivitytemplateid;
                arparams[2].Value = objeventactivity.Subject;

                if (objeventactivity.EventActivity == EEventActivity.EMail)
                {
                    arparams[3].Value = objeventactivity.EmailContent;
                }
                else
                {
                    arparams[3].Value = objeventactivity.Notes;
                }

                arparams[4].Value = objeventactivity.ActivityDay;
                arparams[5].Value = objeventactivity.ForAfterEvent;
                arparams[6].Value = objeventactivity.ResponsibleRoleName;
                if (objeventactivity.ResponsibleRoleShellID > 0)
                    arparams[7].Value = objeventactivity.ResponsibleRoleShellID;
                else
                    arparams[7].Value = DBNull.Value;
                if (objeventactivity.ResponsibleRoleID > 0)
                    arparams[8].Value = objeventactivity.ResponsibleRoleID;
                else
                    arparams[8].Value = DBNull.Value;

                arparams[9].Value = objeventactivity.ResponsibleSpecifiedEmail;
                arparams[10].Value = (Int16)objeventactivity.EventActivity;

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                    "usp_saveeventactivitytemplateactivity", arparams);
            }
        }

        /// <summary>
        /// Fetches List of Customers with Missing Result info based on mode supplied.
        /// Mode 0 - No Results
        /// Mode 1 - Partial Results
        /// Mode 2 - No Images
        /// </summary>
        public List<EEvent> GetEventsMissingRecordDetail(Int16 mode, Int16 pagenum, Int16 pagesize, Int32 eventid,
            string eventname, string datefrom, string dateto,
            out int itotalrecordcount)
        {
            var arparams = new SqlParameter[7];

            arparams[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[1] = new SqlParameter("@pageno", SqlDbType.Int);
            arparams[2] = new SqlParameter("@pagesize", SqlDbType.TinyInt);
            arparams[3] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[4] = new SqlParameter("@eventname", SqlDbType.VarChar, 500);
            arparams[5] = new SqlParameter("@eventdatefrom", SqlDbType.DateTime);
            arparams[6] = new SqlParameter("@eventdateto", SqlDbType.DateTime);

            arparams[0].Value = mode;
            arparams[1].Value = pagenum;
            arparams[2].Value = pagesize;
            arparams[3].Value = eventid;

            if (eventname.Trim().Length < 1)
            {
                arparams[4].Value = DBNull.Value;
            }
            else
            {
                arparams[4].Value = eventname;
            }

            if (datefrom.Trim().Length < 1)
            {
                arparams[5].Value = DBNull.Value;
            }
            else
            {
                arparams[5].Value = datefrom;
            }

            if (dateto.Trim().Length < 1)
            {
                arparams[6].Value = DBNull.Value;
            }
            else
            {
                arparams[6].Value = dateto;
            }

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getMissingResultDetail", arparams);

            itotalrecordcount = 0;
            if (dstemp == null)
            {
                return null;
            }

            DataTable dtevents = dstemp.Tables[0];
            DataTable dteventcustomers = dstemp.Tables[1];

            if (dtevents.Rows.Count < 1)
            {
                return null;
            }
            if (dteventcustomers.Rows.Count < 1)
            {
                return null;
            }

            if (dstemp.Tables[2].Rows.Count > 0)
            {
                itotalrecordcount = Convert.ToInt32(dstemp.Tables[2].Rows[0]["RecordCount"]);
            }
            else
            {
                itotalrecordcount = 0;
            }

            var lstevents = new List<EEvent>();
            foreach (DataRow drevent in dtevents.Rows)
            {
                var objevent = new EEvent();

                objevent.EventID = Convert.ToInt32(drevent["EventID"]);
                objevent.Name = drevent["EventName"].ToString();
                objevent.EventDate = drevent["EventDate"].ToString();

                dteventcustomers.DefaultView.RowFilter = "";
                dteventcustomers.DefaultView.RowFilter = "EventID = " + objevent.EventID;

                objevent.Customer = new List<EEventCustomer>();
                foreach (DataRowView drveventcustomers in dteventcustomers.DefaultView)
                {
                    var objeventcustomer = new EEventCustomer();
                    objeventcustomer.EventCustomerID = Convert.ToInt32(drveventcustomers["EventCustomerID"]);

                    if (drveventcustomers["DateCreated"] != DBNull.Value)
                    {
                        objeventcustomer.DateCreated = Convert.ToDateTime(drveventcustomers["DateCreated"]);
                    }

                    objeventcustomer.Customer = new ECustomers();
                    objeventcustomer.Customer.CustomerID = Convert.ToInt32(drveventcustomers["CustomerID"]);
                    objeventcustomer.Customer.User = new EUser();
                    objeventcustomer.Customer.User.FirstName = drveventcustomers["FirstName"].ToString();
                    objeventcustomer.Customer.User.LastName = drveventcustomers["LastName"].ToString();

                    objevent.Customer.Add(objeventcustomer);
                }
                lstevents.Add(objevent);
            }
            return lstevents;
        }

        /// <summary>
        /// Fetches Paymentdetail for a customer for an event,
        /// based on event customerid provided.
        /// </summary>
        public List<EPaymentDetail> GetPaymentDetailsforEventCustomerList(Int64 eventcustomerid)
        {
            var arparam = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparam.Value = eventcustomerid;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getPaymentDetailforEventCustomerList", arparam);

            if (dstemp == null)
            {
                return null;
            }

            DataTable dtPaymentDetail = dstemp.Tables[0];
            var lstpaymentdetail = new List<EPaymentDetail>();

            foreach (DataRow dr in dtPaymentDetail.Rows)
            {
                var objpaymentdetail = new EPaymentDetail();

                objpaymentdetail.PayDate = Convert.ToString(dr["DateCreated"]);
                objpaymentdetail.PaymentType = new EPaymentType();
                objpaymentdetail.PaymentType.Name = Convert.ToString(dr["Mode"]);

                if (objpaymentdetail.PaymentType.Name == "Cash")
                {
                    objpaymentdetail.CashPayment = new ECashPaymentDetail();
                }
                if (objpaymentdetail.PaymentType.Name == "Credit Card")
                {
                    objpaymentdetail.CreditCardPaymentDetail = new ECreditCardPaymentDetail();
                    if (dr["CreditCardNumber"] != DBNull.Value)
                    {
                        objpaymentdetail.CreditCardPaymentDetail.CreditCardNumber =
                            Convert.ToString(dr["CreditCardNumber"]);
                    }
                    if (dr["ExpirationDate"] != DBNull.Value)
                    {
                        objpaymentdetail.CreditCardPaymentDetail.ExpirationDate =
                            Convert.ToDateTime(dr["ExpirationDate"]).ToString("MM / yyyy");
                    }
                    if (dr["PaymentStatus"] != DBNull.Value)
                    {
                        objpaymentdetail.CreditCardPaymentDetail.PaymentStatus = Convert.ToString(dr["PaymentStatus"]);
                    }
                    objpaymentdetail.CreditCardPaymentDetail.CreditCardType = new ECreditCardType();
                    if (dr["CardName"] != DBNull.Value)
                    {
                        objpaymentdetail.CreditCardPaymentDetail.CreditCardType.Name = Convert.ToString(dr["CardName"]);
                    }
                }
                if (objpaymentdetail.PaymentType.Name == "Check")
                {
                    objpaymentdetail.ChequePayment = new EChequePaymentDetail();
                    if (dr["BankName"] != DBNull.Value)
                    {
                        objpaymentdetail.ChequePayment.BankName = Convert.ToString(dr["BankName"]);
                    }
                    if (dr["ChequeNumber"] != DBNull.Value)
                    {
                        objpaymentdetail.ChequePayment.ChequeNumber = Convert.ToString(dr["ChequeNumber"]);
                    }
                }
                if (objpaymentdetail.PaymentType.Name == "eCheck")
                {
                    objpaymentdetail.ECheckPaymentDetail = new EECheckPaymentDetails();
                    if (dr["eBankName"] != DBNull.Value)
                    {
                        objpaymentdetail.ECheckPaymentDetail.BankName = Convert.ToString(dr["eBankName"]);
                    }
                    if (dr["ECheckNumber"] != DBNull.Value)
                    {
                        objpaymentdetail.ECheckPaymentDetail.EChequeNumber = Convert.ToString(dr["ECheckNumber"]);
                    }
                    if (dr["AccountNumber"] != DBNull.Value)
                    {
                        objpaymentdetail.ECheckPaymentDetail.AccountNumber = Convert.ToString(dr["AccountNumber"]);
                    }
                    if (dr["AccountType"] != DBNull.Value)
                    {
                        objpaymentdetail.ECheckPaymentDetail.AccountType = Convert.ToString(dr["AccountType"]);
                    }
                    if (dr["TransactionID"] != DBNull.Value)
                    {
                        objpaymentdetail.ECheckPaymentDetail.TransactionID = Convert.ToString(dr["TransactionID"]);
                    }
                }
                // case added for giftCertificate
                if (objpaymentdetail.PaymentType.Name == "Gift Certificate")
                {
                    objpaymentdetail.GiftCertificate = new List<OrderedPair<string, string>>();

                    if (dr["claimcode"] != DBNull.Value)
                    {
                        objpaymentdetail.GiftCertificate.Add(new OrderedPair<string, string>("claimcode",
                            Convert.ToString(dr["claimcode"])));
                    }
                }

                objpaymentdetail.PaymentNet = Convert.ToSingle(dr["PaymentNet"]);
                if (dr["Via"] != DBNull.Value)
                {
                    objpaymentdetail.PaymentVia = Convert.ToString(dr["Via"]);
                }
                if (dr["DateCreated"] != DBNull.Value)
                {
                    objpaymentdetail.PayDate = Convert.ToString(dr["DateCreated"]);
                }

                lstpaymentdetail.Add(objpaymentdetail);
            }
            return lstpaymentdetail;
        }

        /// <summary>
        /// Fetches Event and Pending Result Status Count
        /// </summary>
        public List<EEvent> GetEventswithPendingResultStatus(int pagenumber, int pagesize, short mode, int eventid,
            out int iTotalEventCount)
        {
            var arparams = new SqlParameter[4];

            arparams[0] = new SqlParameter("@pageno", SqlDbType.TinyInt);
            arparams[1] = new SqlParameter("@pagesize", SqlDbType.TinyInt);
            arparams[2] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[3] = new SqlParameter("@eventid", SqlDbType.BigInt);

            arparams[0].Value = pagenumber;
            arparams[1].Value = pagesize;
            arparams[2].Value = mode;
            arparams[3].Value = eventid;

            DataSet dsEventResults = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getEventPendingResultDetails", arparams);

            iTotalEventCount = 0;
            if (dsEventResults.Tables.Count < 1)
            {
                return null;
            }

            DataTable dtEventResults = dsEventResults.Tables[1];
            var lstEvent = new List<EEvent>();

            iTotalEventCount = Convert.ToInt32(dsEventResults.Tables[2].Rows[0]["EventCount"]);

            foreach (DataRow drEvent in dsEventResults.Tables[0].Rows)
            {
                var objEvent = new EEvent();
                objEvent.Host = new EHost();
                objEvent.Host.Address = new EAddress();

                objEvent.EventID = Convert.ToInt32(drEvent["EventID"]);
                objEvent.Name = Convert.ToString(drEvent["EventName"]);
                objEvent.Host.Name = Convert.ToString(drEvent["OrganizationName"]);
                objEvent.EventDate = Convert.ToDateTime(drEvent["EventDate"]).ToLongDateString();
                objEvent.Host.Address.Address1 = Convert.ToString(drEvent["Address1"]);
                objEvent.Host.Address.City = Convert.ToString(drEvent["City"]);
                objEvent.Host.Address.State = Convert.ToString(drEvent["State"]);
                objEvent.Host.Address.Country = Convert.ToString(drEvent["Country"]);
                objEvent.Host.Address.Zip = Convert.ToString(drEvent["ZipCode"]);
                objEvent.CustomerCount = Convert.ToInt32(drEvent["customercount"]);

                dtEventResults.DefaultView.RowFilter = "EventID = " + objEvent.EventID;

                for (int icount = 0; icount < dtEventResults.DefaultView.Count; icount++)
                {
                    int customerCount = Convert.ToInt32(dtEventResults.DefaultView[icount]["CustomerCount"]);
                    switch (Convert.ToInt32(dtEventResults.DefaultView[icount]["ResultState"]))
                    {
                        case 1:
                            objEvent.EvalStatus_ONE = customerCount;
                            break;

                        case 2:
                            objEvent.EvalStatus_TWO = customerCount;
                            break;

                        case 3:
                            objEvent.EvalStatus_THREE = customerCount;
                            break;

                        case 4:
                            objEvent.EvalStatus_FOUR = customerCount;
                            break;

                        case 5:
                            objEvent.EvalStatus_FIVE = customerCount;
                            break;

                        case 6:
                            objEvent.EvalStatus_SIX = customerCount;
                            break;

                        case 7:
                            objEvent.EvalStatus_SEVEN = customerCount;
                            break;
                    }
                }

                lstEvent.Add(objEvent);
            }
            return lstEvent;
        }


        // Fetches the dataset for event records on the basis of parameters supplied
        public List<EEvent> SearchEventDetailsTechDashboard(Int64 eventid, string eventname, string cityname, string statename,
           string zipcode, string fromdate, string todate, Int16 mode, int pageNumber, int pageSize, out long totalRecords, Int64 technicianId = 0)
        {
            var arparams = new SqlParameter[11];

            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[0].Value = eventid;

            arparams[1] = new SqlParameter("@eventname", SqlDbType.VarChar, 200);
            if (eventname.Trim().Length < 1)
            {
                arparams[1].Value = DBNull.Value;
            }
            else
            {
                arparams[1].Value = eventname;
            }

            arparams[2] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (statename.Trim().Length < 1)
            {
                arparams[2].Value = DBNull.Value;
            }
            else
            {
                arparams[2].Value = statename;
            }

            arparams[3] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (cityname.Trim().Length < 1)
            {
                arparams[3].Value = DBNull.Value;
            }
            else
            {
                arparams[3].Value = cityname;
            }

            arparams[4] = new SqlParameter("@zipcode", SqlDbType.VarChar, 100);
            if (zipcode.Trim().Length < 1)
            {
                arparams[4].Value = DBNull.Value;
            }
            else
            {
                arparams[4].Value = zipcode;
            }

            arparams[5] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            if (fromdate.Trim().Length < 1)
            {
                arparams[5].Value = DBNull.Value;
            }
            else
            {
                arparams[5].Value = fromdate;
            }


            arparams[6] = new SqlParameter("@todate", SqlDbType.DateTime);
            if (todate.Trim().Length < 1)
            {
                arparams[6].Value = DBNull.Value;
            }
            else
            {
                arparams[6].Value = todate;
            }


            arparams[7] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[7].Value = mode;

            arparams[8] = new SqlParameter("@technicianId", SqlDbType.BigInt);
            arparams[8].Value = technicianId;

            arparams[9] = new SqlParameter("@PageSize", SqlDbType.Int);
            arparams[9].Value = pageSize;

            arparams[10] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arparams[10].Value = pageNumber;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString, "usp_getevents",
                arparams);
            var returnvalue = new List<EEvent>();

            totalRecords = 0;
            if (mode != 8)
            {
                returnvalue = ParseEventDataSet(dstemp);
                totalRecords = Convert.ToInt64(dstemp.Tables[dstemp.Tables.Count - 1].Rows[0]["TotalRecords"]);

            }
            else
            {
                returnvalue = ParseEventWithPodName(dstemp);
            }
            return returnvalue;
        }

        // Fetches the dataset for event records on the basis of parameters supplied
        public List<EEvent> SearchEventDetails(Int64 eventid, string eventname, string cityname, string statename,
           string zipcode, string fromdate, string todate, Int16 mode, Int64 technicianId = 0)
        {
            var arparams = new SqlParameter[11];

            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[0].Value = eventid;

            arparams[1] = new SqlParameter("@eventname", SqlDbType.VarChar, 200);
            if (eventname.Trim().Length < 1)
            {
                arparams[1].Value = DBNull.Value;
            }
            else
            {
                arparams[1].Value = eventname;
            }

            arparams[2] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (statename.Trim().Length < 1)
            {
                arparams[2].Value = DBNull.Value;
            }
            else
            {
                arparams[2].Value = statename;
            }

            arparams[3] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (cityname.Trim().Length < 1)
            {
                arparams[3].Value = DBNull.Value;
            }
            else
            {
                arparams[3].Value = cityname;
            }

            arparams[4] = new SqlParameter("@zipcode", SqlDbType.VarChar, 100);
            if (zipcode.Trim().Length < 1)
            {
                arparams[4].Value = DBNull.Value;
            }
            else
            {
                arparams[4].Value = zipcode;
            }

            arparams[5] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            if (fromdate.Trim().Length < 1)
            {
                arparams[5].Value = DBNull.Value;
            }
            else
            {
                arparams[5].Value = fromdate;
            }


            arparams[6] = new SqlParameter("@todate", SqlDbType.DateTime);
            if (todate.Trim().Length < 1)
            {
                arparams[6].Value = DBNull.Value;
            }
            else
            {
                arparams[6].Value = todate;
            }


            arparams[7] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[7].Value = mode;

            arparams[8] = new SqlParameter("@technicianId", SqlDbType.BigInt);
            arparams[8].Value = technicianId;

            arparams[9] = new SqlParameter("@PageSize", SqlDbType.Int);
            arparams[9].Value = technicianId;

            arparams[10] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arparams[10].Value = technicianId;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString, "usp_getevents",
                arparams);
            var returnvalue = new List<EEvent>();

            if (mode != 8)
            {
                returnvalue = ParseEventDataSet(dstemp);
            }
            else
            {
                returnvalue = ParseEventWithPodName(dstemp);
            }
            return returnvalue;
        }

        /// <summary>
        /// Fills info from dataset into Event object
        /// </summary>
        /// <param name="dstemp"></param>
        /// <returns></returns>
        private List<EEvent> ParseEventDataSet(DataSet dstemp)
        {
            var listobjevent = new List<EEvent>();
            if (dstemp == null)
            {
                return listobjevent;
            }

            DataTable dtevent = dstemp.Tables[0];
            DataTable dtaddress = dstemp.Tables[1];

            for (int icount = 0; icount < dtevent.Rows.Count; icount++)
            {
                try
                {
                    var objevent = new EEvent();
                    objevent.Active = Convert.ToBoolean(dtevent.Rows[icount]["IsActive"]);

                    objevent.CosttoUseHostSite = Convert.ToSingle(dtevent.Rows[icount]["CosttoUseHostSite"]);

                    objevent.EventDate = Convert.ToString(dtevent.Rows[icount]["EventDate"]);
                    objevent.EventEndTime = Convert.ToString(dtevent.Rows[icount]["EventEndTime"]);
                    objevent.EventID = Convert.ToInt32(dtevent.Rows[icount]["EventID"]);
                    objevent.EventStartTime = Convert.ToString(dtevent.Rows[icount]["EventStartTime"]);

                    objevent.Name = Convert.ToString(dtevent.Rows[icount]["EventName"]);
                    objevent.Rescheduled = Convert.ToBoolean(dtevent.Rows[icount]["IsRescheduled"]);
                    objevent.TimeZone = Convert.ToString(dtevent.Rows[icount]["TimeZone"]);
                    objevent.CustomerCount = Convert.ToInt32(dtevent.Rows[icount]["CustomerCount"]);

                    int addressid = Convert.ToInt32(dtevent.Rows[icount]["AddressID"]);
                    dtaddress.DefaultView.RowFilter = "AddressID = " + addressid;
                    if (dtaddress.DefaultView.Count < 1)
                    {
                        continue;
                    }

                    var hostaddress = new EAddress();
                    hostaddress.Address1 = Convert.ToString(dtaddress.DefaultView[0]["Address1"]);
                    hostaddress.Address2 = Convert.ToString(dtaddress.DefaultView[0]["Address2"]);
                    hostaddress.AddressID = Convert.ToInt32(dtaddress.DefaultView[0]["AddressID"]);
                    hostaddress.City = Convert.ToString(dtaddress.DefaultView[0]["City"]);
                    hostaddress.State = Convert.ToString(dtaddress.DefaultView[0]["State"]);
                    hostaddress.Country = Convert.ToString(dtaddress.DefaultView[0]["Country"]);
                    hostaddress.Zip = Convert.ToString(dtaddress.DefaultView[0]["ZipCode"]);

                    objevent.Host = new EHost();
                    objevent.Host.Address = hostaddress;
                    objevent.Host.Name = Convert.ToString(dtevent.Rows[icount]["HostName"]);
                    objevent.Host.PhoneOffice = Convert.ToString(dtevent.Rows[icount]["HostPhone"]);

                    if (dstemp.Tables.Count > 2)
                    {
                        DataTable dtPod = dstemp.Tables[2];

                        int eventid = Convert.ToInt32(dtevent.Rows[icount]["EventID"]);
                        dtPod.DefaultView.RowFilter = "EventID = " + eventid;
                        if (dtPod.DefaultView.Count > 0)
                        {
                            objevent.EventPod = new List<EEventPod>();
                            for (int pCount = 0; pCount < dtPod.DefaultView.Count; pCount++)
                            {
                                var objEventPod = new EEventPod();
                                objEventPod.Pod = new EPod();
                                objEventPod.Pod.Name = Convert.ToString(dtPod.DefaultView[pCount]["PodName"]);
                                objEventPod.Pod.PodID = Convert.ToInt32(dtPod.DefaultView[pCount]["PodID"]);

                                objevent.EventPod.Add(objEventPod);
                            }
                        }
                    }

                    else
                    {
                        if (dtevent.Columns.Contains("PodName"))
                        {
                            objevent.PodName = Convert.ToString(dtevent.Rows[icount]["PodName"]);
                        }
                    }

                    listobjevent.Add(objevent);
                }
                catch (Exception)
                { }
            }
            return listobjevent;
        }

        /// <summary>
        /// Fills info from dataset into Event object
        /// </summary>
        /// <param name="dstemp"></param>
        /// <returns></returns>
        private List<EEvent> ParseEventWithPodName(DataSet dstemp)
        {
            var listobjevent = new List<EEvent>();
            if (dstemp == null)
            {
                return listobjevent;
            }

            DataTable dtevent = dstemp.Tables[0];
            DataTable dtaddress = dstemp.Tables[1];

            for (int icount = 0; icount < dtevent.Rows.Count; icount++)
            {
                string strPodName = Convert.ToString(dtevent.Rows[icount]["PodName"]);
                int iIndex = icount + 1;
                if (icount == dtevent.Rows.Count - 1)
                {
                    #region "1"

                    try
                    {
                        var objevent = new EEvent();
                        objevent.Active = Convert.ToBoolean(dtevent.Rows[icount]["IsActive"]);
                        if (dtevent.Rows[icount]["Amount"] != DBNull.Value)
                        {
                            objevent.Amount = Convert.ToSingle(dtevent.Rows[icount]["Amount"]);
                        }

                        if (dtevent.Rows[icount]["Communicatewithmembers"] != DBNull.Value)
                        {
                            objevent.CommunicateWithMembers =
                                Convert.ToBoolean(dtevent.Rows[icount]["Communicatewithmembers"]);
                        }

                        if (dtevent.Rows[icount]["ComplimentaryScreens"] != DBNull.Value)
                        {
                            objevent.ComplimentaryScreens = Convert.ToInt32(dtevent.Rows[icount]["ComplimentaryScreens"]);
                        }

                        objevent.CosttoUseHostSite = Convert.ToSingle(dtevent.Rows[icount]["CosttoUseHostSite"]);
                        objevent.DeliverSeminar = Convert.ToBoolean(dtevent.Rows[icount]["DeliverSeminar"]);
                        objevent.EventDate = Convert.ToString(dtevent.Rows[icount]["EventDate"]);
                        objevent.EventEndTime = Convert.ToString(dtevent.Rows[icount]["EventEndTime"]);
                        objevent.EventID = Convert.ToInt32(dtevent.Rows[icount]["EventID"]);
                        objevent.EventStartTime = Convert.ToString(dtevent.Rows[icount]["EventStartTime"]);

                        if (dtevent.Rows[icount]["FundRaiser"] != DBNull.Value)
                        {
                            objevent.FundRaiser = Convert.ToBoolean(dtevent.Rows[icount]["FundRaiser"]);
                        }

                        if (dtevent.Rows[icount]["MarketingMaterialType"] != DBNull.Value)
                        {
                            objevent.MarketingMaterialType =
                                Convert.ToInt32(dtevent.Rows[icount]["MarketingMaterialType"]);
                        }

                        if (dtevent.Rows[icount]["MinPatients"] != DBNull.Value)
                        {
                            objevent.MinPatients = Convert.ToInt32(dtevent.Rows[icount]["MinPatients"]);
                        }

                        objevent.Name = Convert.ToString(dtevent.Rows[icount]["EventName"]);
                        objevent.Rescheduled = Convert.ToBoolean(dtevent.Rows[icount]["IsRescheduled"]);
                        objevent.TimeZone = Convert.ToString(dtevent.Rows[icount]["TimeZone"]);
                        objevent.CustomerCount = Convert.ToInt32(dtevent.Rows[icount]["CustomerCount"]);

                        if (dtevent.Rows[icount]["Type"] != DBNull.Value)
                        {
                            objevent.Type = Convert.ToString(dtevent.Rows[icount]["Type"]);
                        }

                        int addressid = Convert.ToInt32(dtevent.Rows[icount]["AddressID"]);
                        dtaddress.DefaultView.RowFilter = "AddressID = " + addressid;
                        if (dtaddress.DefaultView.Count < 1)
                        {
                            continue;
                        }

                        var hostaddress = new EAddress();
                        hostaddress.Address1 = Convert.ToString(dtaddress.DefaultView[0]["Address1"]);
                        hostaddress.Address2 = Convert.ToString(dtaddress.DefaultView[0]["Address2"]);
                        hostaddress.AddressID = Convert.ToInt32(dtaddress.DefaultView[0]["AddressID"]);
                        hostaddress.City = Convert.ToString(dtaddress.DefaultView[0]["City"]);
                        hostaddress.State = Convert.ToString(dtaddress.DefaultView[0]["State"]);
                        hostaddress.Country = Convert.ToString(dtaddress.DefaultView[0]["Country"]);
                        hostaddress.Zip = Convert.ToString(dtaddress.DefaultView[0]["ZipCode"]);

                        objevent.Host = new EHost();
                        objevent.Host.Address = hostaddress;
                        objevent.Host.Name = Convert.ToString(dtevent.Rows[icount]["HostName"]);
                        objevent.Host.PhoneOffice = Convert.ToString(dtevent.Rows[icount]["HostPhone"]);

                        objevent.PodName = strPodName;

                        listobjevent.Add(objevent);
                    }
                    catch (Exception)
                    { }

                    #endregion
                }
                else
                {
                    #region "2"

                    for (int jcount = iIndex; jcount < dtevent.Rows.Count; jcount++)
                    {
                        if (dtevent.Rows[icount]["EventId"].ToString() == dtevent.Rows[jcount]["EventId"].ToString())
                        {
                            strPodName = strPodName + ", " + Convert.ToString(dtevent.Rows[jcount]["PodName"]);
                            if (jcount == dtevent.Rows.Count - 1)
                            {
                                var objevent = new EEvent();
                                objevent.Active = Convert.ToBoolean(dtevent.Rows[icount]["IsActive"]);
                                if (dtevent.Rows[icount]["Amount"] != DBNull.Value)
                                {
                                    objevent.Amount = Convert.ToSingle(dtevent.Rows[icount]["Amount"]);
                                }

                                if (dtevent.Rows[icount]["Communicatewithmembers"] != DBNull.Value)
                                {
                                    objevent.CommunicateWithMembers =
                                        Convert.ToBoolean(dtevent.Rows[icount]["Communicatewithmembers"]);
                                }

                                if (dtevent.Rows[icount]["ComplimentaryScreens"] != DBNull.Value)
                                {
                                    objevent.ComplimentaryScreens =
                                        Convert.ToInt32(dtevent.Rows[icount]["ComplimentaryScreens"]);
                                }

                                objevent.CosttoUseHostSite = Convert.ToSingle(dtevent.Rows[icount]["CosttoUseHostSite"]);
                                objevent.DeliverSeminar = Convert.ToBoolean(dtevent.Rows[icount]["DeliverSeminar"]);
                                objevent.EventDate = Convert.ToString(dtevent.Rows[icount]["EventDate"]);
                                objevent.EventEndTime = Convert.ToString(dtevent.Rows[icount]["EventEndTime"]);
                                objevent.EventID = Convert.ToInt32(dtevent.Rows[icount]["EventID"]);
                                objevent.EventStartTime = Convert.ToString(dtevent.Rows[icount]["EventStartTime"]);

                                if (dtevent.Rows[icount]["FundRaiser"] != DBNull.Value)
                                {
                                    objevent.FundRaiser = Convert.ToBoolean(dtevent.Rows[icount]["FundRaiser"]);
                                }

                                if (dtevent.Rows[icount]["MarketingMaterialType"] != DBNull.Value)
                                {
                                    objevent.MarketingMaterialType =
                                        Convert.ToInt32(dtevent.Rows[icount]["MarketingMaterialType"]);
                                }

                                if (dtevent.Rows[icount]["MinPatients"] != DBNull.Value)
                                {
                                    objevent.MinPatients = Convert.ToInt32(dtevent.Rows[icount]["MinPatients"]);
                                }

                                objevent.Name = Convert.ToString(dtevent.Rows[icount]["EventName"]);
                                objevent.Rescheduled = Convert.ToBoolean(dtevent.Rows[icount]["IsRescheduled"]);
                                objevent.TimeZone = Convert.ToString(dtevent.Rows[icount]["TimeZone"]);
                                objevent.CustomerCount = Convert.ToInt32(dtevent.Rows[icount]["CustomerCount"]);

                                if (dtevent.Rows[icount]["Type"] != DBNull.Value)
                                {
                                    objevent.Type = Convert.ToString(dtevent.Rows[icount]["Type"]);
                                }

                                int addressid = Convert.ToInt32(dtevent.Rows[icount]["AddressID"]);
                                dtaddress.DefaultView.RowFilter = "AddressID = " + addressid;
                                if (dtaddress.DefaultView.Count < 1)
                                {
                                    continue;
                                }

                                var hostaddress = new EAddress();
                                hostaddress.Address1 = Convert.ToString(dtaddress.DefaultView[0]["Address1"]);
                                hostaddress.Address2 = Convert.ToString(dtaddress.DefaultView[0]["Address2"]);
                                hostaddress.AddressID = Convert.ToInt32(dtaddress.DefaultView[0]["AddressID"]);
                                hostaddress.City = Convert.ToString(dtaddress.DefaultView[0]["City"]);
                                hostaddress.State = Convert.ToString(dtaddress.DefaultView[0]["State"]);
                                hostaddress.Country = Convert.ToString(dtaddress.DefaultView[0]["Country"]);
                                hostaddress.Zip = Convert.ToString(dtaddress.DefaultView[0]["ZipCode"]);

                                objevent.Host = new EHost();
                                objevent.Host.Address = hostaddress;
                                objevent.Host.Name = Convert.ToString(dtevent.Rows[icount]["HostName"]);
                                objevent.Host.PhoneOffice = Convert.ToString(dtevent.Rows[icount]["HostPhone"]);

                                objevent.PodName = strPodName;

                                listobjevent.Add(objevent);
                                icount = jcount;
                            }
                        }
                        else
                        {
                            try
                            {
                                var objevent = new EEvent();
                                objevent.Active = Convert.ToBoolean(dtevent.Rows[icount]["IsActive"]);
                                if (dtevent.Rows[icount]["Amount"] != DBNull.Value)
                                {
                                    objevent.Amount = Convert.ToSingle(dtevent.Rows[icount]["Amount"]);
                                }

                                if (dtevent.Rows[icount]["Communicatewithmembers"] != DBNull.Value)
                                {
                                    objevent.CommunicateWithMembers =
                                        Convert.ToBoolean(dtevent.Rows[icount]["Communicatewithmembers"]);
                                }

                                if (dtevent.Rows[icount]["ComplimentaryScreens"] != DBNull.Value)
                                {
                                    objevent.ComplimentaryScreens =
                                        Convert.ToInt32(dtevent.Rows[icount]["ComplimentaryScreens"]);
                                }

                                objevent.CosttoUseHostSite = Convert.ToSingle(dtevent.Rows[icount]["CosttoUseHostSite"]);
                                objevent.DeliverSeminar = Convert.ToBoolean(dtevent.Rows[icount]["DeliverSeminar"]);
                                objevent.EventDate = Convert.ToString(dtevent.Rows[icount]["EventDate"]);
                                objevent.EventEndTime = Convert.ToString(dtevent.Rows[icount]["EventEndTime"]);
                                objevent.EventID = Convert.ToInt32(dtevent.Rows[icount]["EventID"]);
                                objevent.EventStartTime = Convert.ToString(dtevent.Rows[icount]["EventStartTime"]);

                                if (dtevent.Rows[icount]["FundRaiser"] != DBNull.Value)
                                {
                                    objevent.FundRaiser = Convert.ToBoolean(dtevent.Rows[icount]["FundRaiser"]);
                                }

                                if (dtevent.Rows[icount]["MarketingMaterialType"] != DBNull.Value)
                                {
                                    objevent.MarketingMaterialType =
                                        Convert.ToInt32(dtevent.Rows[icount]["MarketingMaterialType"]);
                                }

                                if (dtevent.Rows[icount]["MinPatients"] != DBNull.Value)
                                {
                                    objevent.MinPatients = Convert.ToInt32(dtevent.Rows[icount]["MinPatients"]);
                                }

                                objevent.Name = Convert.ToString(dtevent.Rows[icount]["EventName"]);
                                objevent.Rescheduled = Convert.ToBoolean(dtevent.Rows[icount]["IsRescheduled"]);
                                objevent.TimeZone = Convert.ToString(dtevent.Rows[icount]["TimeZone"]);
                                objevent.CustomerCount = Convert.ToInt32(dtevent.Rows[icount]["CustomerCount"]);

                                if (dtevent.Rows[icount]["Type"] != DBNull.Value)
                                {
                                    objevent.Type = Convert.ToString(dtevent.Rows[icount]["Type"]);
                                }

                                int addressid = Convert.ToInt32(dtevent.Rows[icount]["AddressID"]);
                                dtaddress.DefaultView.RowFilter = "AddressID = " + addressid;
                                if (dtaddress.DefaultView.Count < 1)
                                {
                                    continue;
                                }

                                var hostaddress = new EAddress();
                                hostaddress.Address1 = Convert.ToString(dtaddress.DefaultView[0]["Address1"]);
                                hostaddress.Address2 = Convert.ToString(dtaddress.DefaultView[0]["Address2"]);
                                hostaddress.AddressID = Convert.ToInt32(dtaddress.DefaultView[0]["AddressID"]);
                                hostaddress.City = Convert.ToString(dtaddress.DefaultView[0]["City"]);
                                hostaddress.State = Convert.ToString(dtaddress.DefaultView[0]["State"]);
                                hostaddress.Country = Convert.ToString(dtaddress.DefaultView[0]["Country"]);
                                hostaddress.Zip = Convert.ToString(dtaddress.DefaultView[0]["ZipCode"]);

                                objevent.Host = new EHost();
                                objevent.Host.Address = hostaddress;
                                objevent.Host.Name = Convert.ToString(dtevent.Rows[icount]["HostName"]);
                                objevent.Host.PhoneOffice = Convert.ToString(dtevent.Rows[icount]["HostPhone"]);

                                objevent.PodName = strPodName;

                                listobjevent.Add(objevent);
                                icount = jcount - 1;
                                break;
                            }
                            catch (Exception)
                            { }
                        }
                    }

                    #endregion
                }
            }
            return listobjevent;
        }

        /// <summary>
        /// Search Customers on the basis of search parameters.
        /// </summary>
        /// <param name="customerid"></param>
        /// <param name="customername"></param>
        /// <param name="stateid"></param>
        /// <param name="cityid"></param>
        /// <param name="zipcode"></param>
        /// <param name="regdate"></param>
        /// <param name="mode"></param>
        /// <param name="filterstring"></param>
        /// <returns></returns>
        public List<EEventCustomer> SearchEventCustomers(int customerid, string customername, string statename,
            string cityname, string zipcode, string regdate, int mode,
            string filterstring)
        {
            var arparms = new SqlParameter[8];
            arparms[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arparms[0].Value = customerid;

            arparms[1] = new SqlParameter("@customername", SqlDbType.VarChar, 100);
            if (customername.Trim().Length < 1)
            {
                arparms[1].Value = DBNull.Value;
            }
            else
            {
                arparms[1].Value = customername;
            }

            arparms[2] = new SqlParameter("@regdate", SqlDbType.DateTime);
            if (regdate.Trim().Length < 1)
            {
                arparms[2].Value = DBNull.Value;
            }
            else
            {
                arparms[2].Value = regdate;
            }

            arparms[3] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (statename.Trim().Length < 1)
            {
                arparms[3].Value = DBNull.Value;
            }
            else
            {
                arparms[3].Value = statename;
            }

            arparms[4] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (cityname.Trim().Length < 1)
            {
                arparms[4].Value = DBNull.Value;
            }
            else
            {
                arparms[4].Value = cityname;
            }

            arparms[5] = new SqlParameter("@zipcode", SqlDbType.VarChar, 50);
            if (zipcode.Trim().Length < 1)
            {
                arparms[5].Value = DBNull.Value;
            }
            else
            {
                arparms[5].Value = zipcode;
            }

            arparms[6] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparms[6].Value = mode;
            arparms[7] = new SqlParameter("@filterstring", SqlDbType.VarChar, 50);
            arparms[7].Value = filterstring;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_searchcustomers",
                arparms);

            var returncustomers = new List<EEventCustomer>();
            returncustomers = ParseEventCustomersDataSet(tempdataset);
            return returncustomers;
        }

        /// <summary>
        /// Fills info from dataset into customer entity object.
        /// </summary>
        /// <param name="dscustomer"></param>
        /// <returns></returns>
        private List<EEventCustomer> ParseEventCustomersDataSet(DataSet dscustomer)
        {
            var listcustomer = new List<EEventCustomer>();
            if (dscustomer == null)
            {
                return listcustomer;
            }
            if (dscustomer.Tables.Count < 1)
            {
                return listcustomer;
            }
            DataTable dtcustomerusers = dscustomer.Tables[0];
            DataTable dtuseraddress = dscustomer.Tables[1];

            for (int icount = 0; icount < dtcustomerusers.Rows.Count; icount++)
            {
                var objeventcustomer = new EEventCustomer();
                var customer = new ECustomers();
                var user = new EUser();
                var address = new EAddress();

                customer.CustomerID = Convert.ToInt32(dtcustomerusers.Rows[icount]["CustomerID"]);
                objeventcustomer.EventID = Convert.ToInt32(dtcustomerusers.Rows[icount]["EventID"]);
                if (dtcustomerusers.Rows[icount]["EventDate"] != null &&
                    Convert.ToDateTime(dtcustomerusers.Rows[icount]["EventDate"]) <= DateTime.Now)
                {
                    objeventcustomer.TestConducted = true;
                }
                else
                {
                    objeventcustomer.TestConducted = false;
                }

                user.UserID = Convert.ToInt32(dtcustomerusers.Rows[icount]["UserID"]);
                user.FirstName = Convert.ToString(dtcustomerusers.Rows[icount]["FirstName"]);
                user.MiddleName = Convert.ToString(dtcustomerusers.Rows[icount]["MiddleName"]);
                user.LastName = Convert.ToString(dtcustomerusers.Rows[icount]["LastName"]);

                int addressid = Convert.ToInt32(dtcustomerusers.Rows[icount]["HomeAddressID"]);

                dtuseraddress.DefaultView.RowFilter = "AddressID = " + addressid;

                if (dtuseraddress.DefaultView.Count < 1)
                {
                    continue;
                }

                address.AddressID = Convert.ToInt32(dtuseraddress.DefaultView[0]["AddressID"]);
                address.Address1 = Convert.ToString(dtuseraddress.DefaultView[0]["Address1"]);
                address.Address2 = Convert.ToString(dtuseraddress.DefaultView[0]["Address2"]);
                address.City = Convert.ToString(dtuseraddress.DefaultView[0]["City"]);
                address.State = Convert.ToString(dtuseraddress.DefaultView[0]["State"]);
                address.Country = Convert.ToString(dtuseraddress.DefaultView[0]["Country"]);
                address.Zip = Convert.ToString(dtuseraddress.DefaultView[0]["ZipCode"]);

                user.HomeAddress = address;
                customer.User = user;
                objeventcustomer.Customer = customer;
                listcustomer.Add(objeventcustomer);
            }

            return listcustomer;
        }

        public EEvent GetEventSummaryPodDetails(Int64 eventid, Int16 mode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = eventid;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_geteventsummaryPodDetails", arParms);

            var returnEventCustomerlist = new EEvent();
            returnEventCustomerlist = ParseEventSummaryPodDetails(tempdataset);
            return returnEventCustomerlist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dseventsummary"></param>
        /// <returns></returns>
        private EEvent ParseEventSummaryPodDetails(DataSet dseventsummary)
        {
            EEvent objevent = null;
            if (dseventsummary != null && dseventsummary.Tables[0].Rows.Count > 0 &&
                dseventsummary.Tables[1].Rows.Count > 0)
            {
                objevent = new EEvent();
                DataTable dtevent = dseventsummary.Tables[0];
                DataTable dtPodDetail = dseventsummary.Tables[1];
                DataTable dtEventPodTeamDetail = dseventsummary.Tables[2];
                DataTable dtSalesRepInfo = dseventsummary.Tables[3];
                DataTable dtEventRole = dseventsummary.Tables[4];

                objevent.Host = new EHost();
                objevent.Host.PhoneOffice = Convert.ToString(dtevent.Rows[0]["HostPhoneOffice"]);
                //// event booked by
                //if (dtevent.Columns.Contains("EventBookedBy"))
                //    objevent.EventBookedBy = Convert.ToString(dtevent.Rows[0]["EventBookedBy"]);

                if (dtSalesRepInfo.Rows.Count > 0)
                {
                    var objsalesrep = new EFranchiseeFranchiseeUser();
                    objsalesrep.FranchiseeFranchiseeUserID =
                        Convert.ToInt32(dtSalesRepInfo.Rows[0]["FranchiseeFranchiseeUserID"]);
                    objsalesrep.FranchiseeUser = new EFranchiseeUser();
                    objsalesrep.FranchiseeUser.User = new EUser();
                    objsalesrep.FranchiseeUser.User.UserID = Convert.ToInt32(dtSalesRepInfo.Rows[0]["UserID"]);
                    objsalesrep.FranchiseeUser.User.FirstName = Convert.ToString(dtSalesRepInfo.Rows[0]["FirstName"]);
                    objsalesrep.FranchiseeUser.User.MiddleName = Convert.ToString(dtSalesRepInfo.Rows[0]["MiddleName"]);
                    objsalesrep.FranchiseeUser.User.LastName = Convert.ToString(dtSalesRepInfo.Rows[0]["LastName"]);
                    objsalesrep.FranchiseeUser.User.PhoneHome = Convert.ToString(dtSalesRepInfo.Rows[0]["Phone"]);
                    objsalesrep.FranchiseeUser.User.EMail1 = Convert.ToString(dtSalesRepInfo.Rows[0]["EMail"]);
                    objevent.FranchiseeFranchiseeUser = objsalesrep;
                }
                objevent.EventPod = new List<EEventPod>();
                foreach (DataRow drpod in dtPodDetail.Rows)
                {
                    var objeventpod = new EEventPod();
                    objeventpod.Pod = new EPod();
                    objeventpod.Pod.PodID = Convert.ToInt32(drpod["PodID"]);
                    objeventpod.Pod.Name = Convert.ToString(drpod["PodName"]);
                    objeventpod.Pod.Description = Convert.ToString(drpod["Description"]);
                    objeventpod.Pod.PodProcessingCapacity = Convert.ToInt32(drpod["PodProcessingCapacity"]);
                    objeventpod.Pod.Van = new EVan();
                    objeventpod.Pod.Van.Name = Convert.ToString(drpod["vanname"]);
                    objeventpod.Pod.Van.Make = Convert.ToString(drpod["Make"]);
                    objeventpod.Pod.Van.VIN = Convert.ToString(drpod["VIN"]);
                    objeventpod.Pod.Van.Description = Convert.ToString(drpod["VanDescription"]);

                    dtEventPodTeamDetail.DefaultView.RowFilter = "PodID = " + objeventpod.Pod.PodID;
                    objeventpod.Pod.TeamIDList = new List<EFranchiseeFranchiseeUser>();
                    foreach (DataRowView drvevtpodteam in dtEventPodTeamDetail.DefaultView)
                    {
                        var objfranchiseefranchuser = new EFranchiseeFranchiseeUser();
                        objfranchiseefranchuser.FranchiseeFranchiseeUserID =
                            Convert.ToInt32(drvevtpodteam["FranchiseeFranchiseeUserID"]);
                        dtEventRole.DefaultView.RowFilter = "StaffEventRoleID = " +
                            Convert.ToString(drvevtpodteam["EventRoleID"]);
                        if (dtEventRole.DefaultView.Count > 0)
                        {
                            objfranchiseefranchuser.RoleType = Convert.ToString(dtEventRole.DefaultView[0]["Name"]);
                        }
                        //Convert.ToString(drvevtpodteam["rolename"]);
                        objfranchiseefranchuser.FranchiseeUser = new EFranchiseeUser();
                        objfranchiseefranchuser.FranchiseeUser.User = new EUser();
                        objfranchiseefranchuser.FranchiseeUser.User.FirstName =
                            Convert.ToString(drvevtpodteam["FirstName"]);
                        objfranchiseefranchuser.FranchiseeUser.User.MiddleName =
                            Convert.ToString(drvevtpodteam["MiddleName"]);
                        objfranchiseefranchuser.FranchiseeUser.User.LastName =
                            Convert.ToString(drvevtpodteam["LastName"]);
                        objeventpod.Pod.TeamIDList.Add(objfranchiseefranchuser);
                    }

                    objevent.EventPod.Add(objeventpod);
                }
            }
            return objevent;
        }

        /// <summary>
        /// Fetches Event Summary Details for event customer list, based on modes
        /// Mode 0 for Technician and Mode 1 for Franchisor/Franchisee
        /// Mode 1 contains some additional Information related to revenue
        /// </summary>
        /// <param name="eventid"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public EEvent GetEventSummaryDetailsWithPackage(Int64 eventid, Int16 mode, out string strPackageDetails)
        {
            strPackageDetails = string.Empty;

            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = eventid;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_geteventsummarydetailswithpackage", arParms);

            var returnEventCustomerlist = new EEvent();
            returnEventCustomerlist = ParseEventSummaryDetails(tempdataset);
            //ToDo: This is obsolete as we are showing only test count
            // get event package summary
            //DataTable dtEventPachage = tempdataset.Tables[6];
            //foreach (DataRow drpackage in dtEventPachage.Rows)
            //{
            //    strPackageDetails = strPackageDetails + Convert.ToString(drpackage["packagename"]) + ": <b>" +
            //                        Convert.ToString(drpackage["total"]) + " </b>&nbsp;|&nbsp;";
            //}
            return returnEventCustomerlist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dseventsummary"></param>
        /// <returns></returns>
        private EEvent ParseEventSummaryDetails(DataSet dseventsummary)
        {
            EEvent objevent = null;
            //if (dseventsummary == null)
            //    return objevent;
            if (dseventsummary != null && dseventsummary.Tables[0].Rows.Count > 0 &&
                dseventsummary.Tables[1].Rows.Count > 0)
            {
                objevent = new EEvent();

                DataTable dtevent = dseventsummary.Tables[0];
                DataTable dteventaddress = dseventsummary.Tables[1];
                DataTable dtPodDetail = dseventsummary.Tables[2];
                DataTable dtEventPodTeamDetail = dseventsummary.Tables[3];
                DataTable dtSalesRepInfo = dseventsummary.Tables[4];
                DataTable dtEventRole = dseventsummary.Tables[5];

                objevent.EventDate = Convert.ToString(dtevent.Rows[0]["EventDate"]);
                objevent.EventEndTime = Convert.ToString(dtevent.Rows[0]["EventEndTime"]);
                objevent.EventID = Convert.ToInt32(dtevent.Rows[0]["EventID"]);
                objevent.EventStartTime = Convert.ToString(dtevent.Rows[0]["EventStartTime"]);
                objevent.EventNotes = Convert.ToString(dtevent.Rows[0]["EventNotes"]);
                objevent.EventStatus = Convert.ToInt32(dtevent.Rows[0]["EventStatus"]);
                if (dtevent.Rows[0]["EventCancellationReasonId"] != DBNull.Value)
                {
                    objevent.EventCancellationReasonId = Convert.ToInt64(dtevent.Rows[0]["EventCancellationReasonId"]);
                }
                // event booked by
                if (dtevent.Columns.Contains("EventBookedBy"))
                {
                    objevent.EventBookedBy = Convert.ToString(dtevent.Rows[0]["EventBookedBy"]);
                }

                // event booked by
                if (dtevent.Columns.Contains("EventTypeID"))
                {
                    objevent.Type = Convert.ToString(dtevent.Rows[0]["EventTypeID"]);
                }

                if (dtSalesRepInfo.Rows.Count > 0)
                {
                    var objsalesrep = new EFranchiseeFranchiseeUser();
                    objsalesrep.FranchiseeFranchiseeUserID =
                        Convert.ToInt32(dtSalesRepInfo.Rows[0]["FranchiseeFranchiseeUserID"]);
                    objsalesrep.FranchiseeUser = new EFranchiseeUser();
                    objsalesrep.FranchiseeUser.User = new EUser();
                    objsalesrep.FranchiseeUser.User.UserID = Convert.ToInt32(dtSalesRepInfo.Rows[0]["UserID"]);
                    objsalesrep.FranchiseeUser.User.FirstName = Convert.ToString(dtSalesRepInfo.Rows[0]["FirstName"]);
                    objsalesrep.FranchiseeUser.User.MiddleName = Convert.ToString(dtSalesRepInfo.Rows[0]["MiddleName"]);
                    objsalesrep.FranchiseeUser.User.LastName = Convert.ToString(dtSalesRepInfo.Rows[0]["LastName"]);
                    objsalesrep.FranchiseeUser.User.PhoneHome = Convert.ToString(dtSalesRepInfo.Rows[0]["Phone"]);
                    objsalesrep.FranchiseeUser.User.EMail1 = Convert.ToString(dtSalesRepInfo.Rows[0]["EMail"]);
                    objevent.FranchiseeFranchiseeUser = objsalesrep;
                }

                objevent.Name = Convert.ToString(dtevent.Rows[0]["EventName"]);
                objevent.TimeZone = Convert.ToString(dtevent.Rows[0]["TimeZone"]);
                objevent.CustomerCount = Convert.ToInt32(dtevent.Rows[0]["TotalCustomers"]);
                objevent.AttendedCustomersCount = Convert.ToInt32(dtevent.Rows[0]["ActualCustomers"]);
                objevent.CancelCustomersCount = Convert.ToInt32(dtevent.Rows[0]["CanceledCustomers"]);
                objevent.NoShowCustomer = Convert.ToInt32(dtevent.Rows[0]["NoShowCustomer"]);
                objevent.PaidCustomersCount = Convert.ToInt32(dtevent.Rows[0]["PaidCustomers"]);
                objevent.UnpaidCustomersCount = Convert.ToInt32(dtevent.Rows[0]["UnPaidCustomers"]);

                // Added HipaaStatus story(story-#7625)
                // These are not identical column in all the cases like EventDetails page summary
                if (dtevent.Columns.Contains("HipaaStatusYes"))
                {
                    objevent.HippaStatusYes = Convert.ToInt64(dtevent.Rows[0]["HipaaStatusYes"]);
                }
                if (dtevent.Columns.Contains("HipaaStatusNo"))
                {
                    objevent.HippaStatusNo = Convert.ToInt64(dtevent.Rows[0]["HipaaStatusNo"]);
                }
                if (dtevent.Columns.Contains("TotalAverageRevenuePerClient"))
                {
                    objevent.AverageRevenuePerClient = Convert.ToDecimal(dtevent.Rows[0]["TotalAverageRevenuePerClient"]);
                }
                if (dtevent.Columns.Contains("TotalAverageRevenuePerClientCount"))
                {
                    objevent.AverageRevenuePerClientCount =
                        Convert.ToInt32(dtevent.Rows[0]["TotalAverageRevenuePerClientCount"]);
                }
                if (dtevent.Columns.Contains("UnPaidAmount"))
                {
                    objevent.UnPaidAmount = Convert.ToDecimal(dtevent.Rows[0]["UnPaidAmount"]);
                }
                if (dtevent.Columns.Contains("AverageRevenueUnPaidCount"))
                {
                    objevent.AverageRevenueUnPaidCount = Convert.ToInt32(dtevent.Rows[0]["AverageRevenueUnPaidCount"]);
                }
                if (dtevent.Columns.Contains("DateCreated"))
                {
                    objevent.DateCreated = Convert.ToString(dtevent.Rows[0]["DateCreated"]);
                }


                objevent.EIPDeposit = Convert.ToDouble(dtevent.Rows[0]["EIPDeposit"]);
                objevent.CashPayment = Convert.ToDouble(dtevent.Rows[0]["CashPayment"]);
                objevent.CardPayment = Convert.ToDouble(dtevent.Rows[0]["CardPayment"]);
                objevent.ChequePayment = Convert.ToDouble(dtevent.Rows[0]["ChequePayment"]);
                objevent.eCheckPayment = Convert.ToDouble(dtevent.Rows[0]["eCheckPayment"]);
                objevent.TotalPayment = Convert.ToDouble(dtevent.Rows[0]["TotalPayment"]);

                objevent.PhonePaymentCount = Convert.ToInt16(dtevent.Rows[0]["PhoneCustomer"]);
                objevent.InetPaymentCount = Convert.ToInt16(dtevent.Rows[0]["InetCustomer"]);
                objevent.OnsitePaymentCount = Convert.ToInt16(dtevent.Rows[0]["OnsiteCustomer"]);
                objevent.UpgradePaymentCount = Convert.ToInt16(dtevent.Rows[0]["UpgradeCustomer"]);
                objevent.DowngradePaymentCount = Convert.ToInt16(dtevent.Rows[0]["DowngradeCustomer"]);

                objevent.PhonePayment = Convert.ToDecimal(dtevent.Rows[0]["PhonePayment"]);
                objevent.InetPayment = Convert.ToDecimal(dtevent.Rows[0]["InetPayment"]);
                objevent.OnsitePayment = Convert.ToDecimal(dtevent.Rows[0]["OnsitePayment"]);
                objevent.UpgradePayment = Convert.ToDecimal(dtevent.Rows[0]["UpgradePayment"]);
                objevent.DowngradePayment = Convert.ToDecimal(dtevent.Rows[0]["DowngradePayment"]);

                objevent.CashPaymentCount = Convert.ToInt32(dtevent.Rows[0]["CashPaymentCount"]);
                objevent.CardPaymentCount = Convert.ToInt32(dtevent.Rows[0]["CardPaymentCount"]);
                objevent.ChequePaymentCount = Convert.ToInt32(dtevent.Rows[0]["ChequePaymentCount"]);
                objevent.eCheckPaymentCount = Convert.ToInt32(dtevent.Rows[0]["eCheckPaymentCount"]);

                //TODO: to make clean up easier, this code has been kept here.
                if (dtevent.Columns.Contains("GCPaymentCount"))
                {
                    objevent.GiftCertificatePaymentCount = Convert.ToInt16(dtevent.Rows[0]["GCPaymentCount"]);
                }
                if (dtevent.Columns.Contains("GCPaymentTotal"))
                {
                    objevent.GiftCertificatePayment = Convert.ToDecimal(dtevent.Rows[0]["GCPaymentTotal"]);
                }

                objevent.Host = new EHost();
                objevent.Host.Name = Convert.ToString(dtevent.Rows[0]["HostName"]);
                objevent.Host.PhoneOffice = Convert.ToString(dtevent.Rows[0]["HostPhone"]);

                int addressid = Convert.ToInt32(dtevent.Rows[0]["AddressID"]);
                dteventaddress.DefaultView.RowFilter = "AddressID = " + addressid;
                if (dteventaddress.DefaultView.Count > 0)
                {
                    var hostaddress = new EAddress();
                    hostaddress.Address1 = Convert.ToString(dteventaddress.DefaultView[0]["Address1"]);
                    hostaddress.Address2 = Convert.ToString(dteventaddress.DefaultView[0]["Address2"]);
                    hostaddress.AddressID = Convert.ToInt32(dteventaddress.DefaultView[0]["AddressID"]);
                    hostaddress.City = Convert.ToString(dteventaddress.DefaultView[0]["City"]);
                    hostaddress.State = Convert.ToString(dteventaddress.DefaultView[0]["State"]);
                    hostaddress.Country = Convert.ToString(dteventaddress.DefaultView[0]["Country"]);
                    hostaddress.Zip = Convert.ToString(dteventaddress.DefaultView[0]["ZipCode"]);
                    // Address Latitude and Longitude
                    hostaddress.Latitude = Convert.ToString(dteventaddress.DefaultView[0]["Latitude"]);
                    hostaddress.Longitude = Convert.ToString(dteventaddress.DefaultView[0]["Longitude"]);
                    if (dteventaddress.DefaultView[0]["IsManuallyVerified"] == DBNull.Value)
                    {
                        hostaddress.IsManuallyVerified = null;
                    }
                    else
                    {
                        hostaddress.IsManuallyVerified =
                            Convert.ToBoolean(dteventaddress.DefaultView[0]["IsManuallyVerified"]);
                    }

                    hostaddress.UseLatLogForMapping =
                        Convert.ToBoolean(dteventaddress.DefaultView[0]["UseLatLogForMapping"]);
                    hostaddress.GoogleAddressVerifiedBy =
                        Convert.ToString(dteventaddress.DefaultView[0]["AddressVerifiedBy"]);
                    objevent.Host.Address = hostaddress;
                }

                objevent.EventPod = new List<EEventPod>();
                foreach (DataRow drpod in dtPodDetail.Rows)
                {
                    var objeventpod = new EEventPod();
                    objeventpod.Pod = new EPod();
                    objeventpod.Pod.PodID = Convert.ToInt32(drpod["PodID"]);
                    objeventpod.Pod.Name = Convert.ToString(drpod["PodName"]);
                    objeventpod.Pod.Description = Convert.ToString(drpod["Description"]);
                    objeventpod.Pod.PodProcessingCapacity = Convert.ToInt32(drpod["PodProcessingCapacity"]);
                    objeventpod.Pod.Van = new EVan();
                    objeventpod.Pod.Van.Name = Convert.ToString(drpod["vanname"]);
                    objeventpod.Pod.Van.Make = Convert.ToString(drpod["Make"]);
                    objeventpod.Pod.Van.VIN = Convert.ToString(drpod["VIN"]);
                    objeventpod.Pod.Van.Description = Convert.ToString(drpod["VanDescription"]);

                    dtEventPodTeamDetail.DefaultView.RowFilter = "PodID = " + objeventpod.Pod.PodID;
                    objeventpod.Pod.TeamIDList = new List<EFranchiseeFranchiseeUser>();
                    foreach (DataRowView drvevtpodteam in dtEventPodTeamDetail.DefaultView)
                    {
                        var objfranchiseefranchuser = new EFranchiseeFranchiseeUser();
                        objfranchiseefranchuser.FranchiseeFranchiseeUserID =
                            Convert.ToInt32(drvevtpodteam["FranchiseeFranchiseeUserID"]);
                        dtEventRole.DefaultView.RowFilter = "StaffEventRoleID = " +
                            Convert.ToString(drvevtpodteam["EventRoleID"]);
                        if (dtEventRole.DefaultView.Count > 0)
                        {
                            objfranchiseefranchuser.RoleType = Convert.ToString(dtEventRole.DefaultView[0]["Name"]);
                        }
                        //Convert.ToString(drvevtpodteam["rolename"]);
                        objfranchiseefranchuser.FranchiseeUser = new EFranchiseeUser();
                        objfranchiseefranchuser.FranchiseeUser.User = new EUser();
                        objfranchiseefranchuser.FranchiseeUser.User.FirstName =
                            Convert.ToString(drvevtpodteam["FirstName"]);
                        objfranchiseefranchuser.FranchiseeUser.User.MiddleName =
                            Convert.ToString(drvevtpodteam["MiddleName"]);
                        objfranchiseefranchuser.FranchiseeUser.User.LastName =
                            Convert.ToString(drvevtpodteam["LastName"]);
                        objeventpod.Pod.TeamIDList.Add(objfranchiseefranchuser);
                    }

                    objevent.EventPod.Add(objeventpod);
                }
            }
            return objevent;
        }

        /// <summary>
        /// Fetches Customers participating in a event
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EEventCustomer> GetEventCustomerList(String filterString, int inputMode, bool bolsortdescending)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            arParms[2] = new SqlParameter("@sortingmode", SqlDbType.Bit);
            arParms[2].Value = bolsortdescending;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_newspeventcustomerlist", arParms);

            var returnEventCustomerlist = new List<EEventCustomer>();
            returnEventCustomerlist = ParseEventCustomerDataSet(tempdataset);
            return returnEventCustomerlist;
        }

        /// <summary>
        /// Fetches Customers participating in a event
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EEventCustomer> GetEventCustomerListNew(String filterString, int inputMode, bool bolsortdescending,
            int PageSize, int PageIndex, out int total)
        {
            total = 0;
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            arParms[2] = new SqlParameter("@sortingmode", SqlDbType.Bit);
            arParms[2].Value = bolsortdescending;

            arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParms[3].Value = PageSize;

            arParms[4] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParms[4].Value = PageIndex;


            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_speventdetailscustomerlist", arParms);

            var returnEventCustomerlist = new List<EEventCustomer>();
            returnEventCustomerlist = ParseEventCustomerDataSet(tempdataset);
            if (tempdataset.Tables.Count > 1)
            {
                if (tempdataset.Tables[1].Rows.Count > 0)
                {
                    total = Convert.ToInt32(tempdataset.Tables[1].Rows[0]["total"]);
                }
            }
            return returnEventCustomerlist;
        }

        /// <summary>
        /// Fills info from dataset into Event entity object
        /// </summary>
        /// <param name="dseventcustomer"></param>
        /// <returns></returns>
        private List<EEventCustomer> ParseEventCustomerDataSet(DataSet dseventcustomer)
        {
            List<EEventCustomer> listcustomer = null;
            if (dseventcustomer == null)
            {
                return listcustomer;
            }

            DataTable dtcustomerusers = dseventcustomer.Tables[0];

            listcustomer = new List<EEventCustomer>();
            for (int icount = 0; icount < dtcustomerusers.Rows.Count; icount++)
            {
                var objeventcustomer = new EEventCustomer();
                var customer = new ECustomers();
                var user = new EUser();
                var address = new EAddress();
                var coupon = new ECoupon();

                objeventcustomer.EventAppointment = new EEventAppointment();
                if (dtcustomerusers.Rows[icount]["AppointmentID"] != DBNull.Value)
                {
                    objeventcustomer.EventAppointment.AppointmentID =
                        Convert.ToInt32(dtcustomerusers.Rows[icount]["AppointmentID"]);
                }

                if (dtcustomerusers.Rows[icount]["CheckInTime"] != DBNull.Value &&
                    dtcustomerusers.Rows[icount]["CheckInTime"].ToString().Trim().Length > 1)
                {
                    objeventcustomer.EventAppointment.CheckInTime =
                        Convert.ToDateTime(dtcustomerusers.Rows[icount]["CheckInTime"]).ToString("hh:mm tt");
                }


                if (dtcustomerusers.Rows[icount]["CheckOutTime"] != DBNull.Value &&
                    dtcustomerusers.Rows[icount]["CheckOutTime"].ToString().Trim().Length > 1)
                {
                    objeventcustomer.EventAppointment.CheckOutTime =
                        Convert.ToDateTime(dtcustomerusers.Rows[icount]["CheckOutTime"]).ToString("hh:mm tt");
                }


                if (dtcustomerusers.Rows[icount]["StartTime"] != DBNull.Value)
                {
                    objeventcustomer.EventAppointment.StartTime =
                        Convert.ToDateTime(dtcustomerusers.Rows[icount]["StartTime"]).ToString("hh:mm tt");
                }

                if (dtcustomerusers.Rows[icount]["EndTime"] != DBNull.Value)
                {
                    objeventcustomer.EventAppointment.EndTime =
                        Convert.ToDateTime(dtcustomerusers.Rows[icount]["EndTime"]).ToString("hh:mm tt");
                }

                objeventcustomer.AdditionalTest =
                    Convert.ToString(dtcustomerusers.Rows[icount]["AdditionalTest"]);

                objeventcustomer.TestConducted = Convert.ToBoolean(dtcustomerusers.Rows[icount]["IsTestConducted"]);
                objeventcustomer.EventAppointment.Reason = Convert.ToString(dtcustomerusers.Rows[icount]["Reason"]);

                if (dtcustomerusers.Columns.Contains("Subject"))
                {
                    objeventcustomer.EventAppointment.Subject = Convert.ToString(dtcustomerusers.Rows[icount]["Subject"]);
                }

                objeventcustomer.EventAppointment.ScheduleByID =
                    Convert.ToInt32(dtcustomerusers.Rows[icount]["ScheduledByID"]);

                objeventcustomer.RegisteredBy = Convert.ToString(dtcustomerusers.Rows[icount]["RegisteredBy"]);

                objeventcustomer.DateCreated = Convert.ToDateTime(dtcustomerusers.Rows[icount]["DateRegisteredOn"]);

                objeventcustomer.HIPAAStatus = Convert.ToInt16(dtcustomerusers.Rows[icount]["HIPAAStatus"]);
                objeventcustomer.CustomerEventTestID = Convert.ToInt32(dtcustomerusers.Rows[icount]["EventCustomerID"]);
                objeventcustomer.Paid = Convert.ToBoolean(dtcustomerusers.Rows[icount]["IsPaid"]);
                objeventcustomer.NoShow = Convert.ToBoolean(dtcustomerusers.Rows[icount]["Noshow"]);

                if (dtcustomerusers.Columns.Contains("ShippingCost"))
                {
                    objeventcustomer.ShippingCost = Convert.ToDecimal(dtcustomerusers.Rows[icount]["ShippingCost"]);
                }
                if (dtcustomerusers.Columns.Contains("Cash"))
                {
                    objeventcustomer.CashPayment = Convert.ToDecimal(dtcustomerusers.Rows[icount]["Cash"]);
                }
                if (dtcustomerusers.Columns.Contains("CreditCard"))
                {
                    objeventcustomer.CreditCardPayment = Convert.ToDecimal(dtcustomerusers.Rows[icount]["CreditCard"]);
                }
                if (dtcustomerusers.Columns.Contains("Check"))
                {
                    objeventcustomer.CheckPayment = Convert.ToDecimal(dtcustomerusers.Rows[icount]["Check"]);
                }
                if (dtcustomerusers.Columns.Contains("ECheck"))
                {
                    objeventcustomer.EcheckPayment = Convert.ToDecimal(dtcustomerusers.Rows[icount]["ECheck"]);
                }
                if (dtcustomerusers.Columns.Contains("GC"))
                {
                    objeventcustomer.GCPayment = Convert.ToDecimal(dtcustomerusers.Rows[icount]["GC"]);
                }

                decimal amount = (objeventcustomer.CashPayment + objeventcustomer.CreditCardPayment +
                    objeventcustomer.CheckPayment + objeventcustomer.EcheckPayment + objeventcustomer.GCPayment);
                decimal sourceCodeAmount = Convert.ToDecimal(dtcustomerusers.Rows[icount]["CouponValue"]);
                amount = amount > 0 ? (amount + objeventcustomer.ShippingCost) - sourceCodeAmount : 0.0m;


                objeventcustomer.Paid = Convert.ToBoolean(dtcustomerusers.Rows[icount]["IsPaid"]);
                if (objeventcustomer.Paid)
                {
                    objeventcustomer.PaidAmount = Convert.ToSingle(amount);
                }
                else
                {
                    objeventcustomer.UnpaidAmount = Convert.ToSingle(amount);
                }

                objeventcustomer.IsAuthorized = Convert.ToBoolean(dtcustomerusers.Rows[icount]["IsAuthorized"]);

                objeventcustomer.EventPackage = new EEventPackage();
                objeventcustomer.EventPackage.Package = new EPackage();
                objeventcustomer.EventPackage.PackagePrice =
                    Convert.ToSingle(dtcustomerusers.Rows[icount]["PackagePrice"]);
                objeventcustomer.EventPackage.Package.PackageID =
                    Convert.ToInt32(dtcustomerusers.Rows[icount]["PackageID"]);
                objeventcustomer.EventPackage.Package.PackageName =
                    Convert.ToString(dtcustomerusers.Rows[icount]["PackageName"]);

                //netPayment = (Convert.ToDecimal(objeventcustomer.EventPackage.PackagePrice) +
                //    objeventcustomer.ShippingCost) - sourceCodeAmount;
                decimal netPayment = Convert.ToDecimal(dtcustomerusers.Rows[icount]["EffectiveCost"]);

                objeventcustomer.PaymentDetail = new EPaymentDetail();
                objeventcustomer.PaymentDetail.Amount = Convert.ToSingle(netPayment);

                objeventcustomer.EventCustomerID = Convert.ToInt32(dtcustomerusers.Rows[icount]["CustomerEventTestID"]);
                objeventcustomer.CustomerTestStatus = Convert.ToInt32(dtcustomerusers.Rows[icount]["TestStatus"]);

                customer.CustomerID = Convert.ToInt32(dtcustomerusers.Rows[icount]["CustomerID"]);
                customer.IsHistoryFilled = Convert.ToBoolean(dtcustomerusers.Rows[icount]["IsHistoryFilled"]);

                objeventcustomer.IsResultReadyForCustomerViewing =
                    Convert.ToBoolean(dtcustomerusers.Rows[icount]["IsResultReady"]);
                if (dtcustomerusers.Columns.Contains("IsResultPdfGenerated"))
                {
                    objeventcustomer.IsResultPDFGenerated =
                        Convert.ToBoolean(dtcustomerusers.Rows[icount]["IsResultPdfGenerated"]);
                }
                if (dtcustomerusers.Columns.Contains("IsClinicalFormGenerated"))
                {
                    objeventcustomer.IsClinicalFormGenerated =
                        Convert.ToBoolean(dtcustomerusers.Rows[icount]["IsClinicalFormGenerated"]);
                }

                customer.IsResultsReady = objeventcustomer.IsResultReadyForCustomerViewing;

                customer.EventCount = Convert.ToInt32(dtcustomerusers.Rows[icount]["EventCount"]);
                customer.UserCreationMode = Convert.ToString(dtcustomerusers.Rows[icount]["UserCreatedMode"]);

                coupon.CouponCode = Convert.ToString(dtcustomerusers.Rows[icount]["CouponCode"]);
                coupon.CouponAmount = Convert.ToDecimal(dtcustomerusers.Rows[icount]["CouponValue"]);

                //user.UserID = Convert.ToInt32(dtcustomerusers.Rows[icount]["UserID"]);
                user.FirstName = Convert.ToString(dtcustomerusers.Rows[icount]["FirstName"]);
                user.MiddleName = Convert.ToString(dtcustomerusers.Rows[icount]["MiddleName"]);
                user.LastName = Convert.ToString(dtcustomerusers.Rows[icount]["LastName"]);
                user.EMail1 = Convert.ToString(dtcustomerusers.Rows[icount]["Email1"]);
                user.PhoneCell = Convert.ToString(dtcustomerusers.Rows[icount]["Phone"]);

                if (dtcustomerusers.Rows[icount]["UserCreatedOn"].ToString().Length > 0)
                {
                    user.DateApplied = Convert.ToDateTime(dtcustomerusers.Rows[icount]["UserCreatedOn"]);
                }

                //int addressid = Convert.ToInt32(dtcustomerusers.Rows[icount]["HomeAddressID"]);

                customer.User = user;

                objeventcustomer.Customer = customer;
                objeventcustomer.Coupon = coupon;
                listcustomer.Add(objeventcustomer);
            }

            return listcustomer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventcustomerid"></param>
        public void SetHIPAAStatus(long eventcustomerid, short HIPAAStatus)
        {
            string sqlquery =
                "UPDATE [TblEventCustomers] SET [HIPAAStatus] = @HIPAAStatus WHERE [EventCustomerID] = @eventcustomerid";

            var arparams = new SqlParameter[2];
            arparams[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@HIPAAStatus", SqlDbType.SmallInt);

            arparams[0].Value = eventcustomerid;
            arparams[1].Value = HIPAAStatus;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery, arparams);
        }

        public List<EEvent> GetEventsByUserID(int userid, int roleid, int shellid)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userid;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[1].Value = roleid;
            arParms[2] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[2].Value = shellid;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getuserevent",
                arParms);

            var returnEvent = new List<EEvent>();
            returnEvent = ParseUserEventDataSet(tempdataset);
            return returnEvent;
        }

        private List<EEvent> ParseUserEventDataSet(DataSet eventDataSet)
        {
            var returnEvent = new List<EEvent>();


            foreach (DataRow dr in eventDataSet.Tables[0].Rows)
            {
                var eevent = new EEvent();

                eevent.EventID = Convert.ToInt32(dr["EventID"]);
                eevent.Active = Convert.ToBoolean(dr["IsActive"]);
                ///eevent.PodTeamID = Convert.ToInt32(dr["PodTeamID"]);
                eevent.Name = dr["EventName"].ToString();
                eevent.CustomerCount = Convert.ToInt32(dr["CustomerCount"]);
                eevent.EventEndTime = (Convert.ToDateTime(dr["EventEndTime"])).ToShortTimeString();
                eevent.EventDate = Convert.ToDateTime(dr["EventDate"].ToString()).ToShortDateString();


                var eventpodlist = new List<EEventPod>();
                DataTable tblpod = eventDataSet.Tables[1];
                tblpod.DefaultView.RowFilter = "EventID = " + eevent.EventID;
                int fcount = 0;
                while (fcount < tblpod.DefaultView.Count)
                {
                    var eventpod = new EEventPod();
                    eventpod.Pod = new EPod();
                    eventpod.Pod.PodID = Convert.ToInt32(tblpod.DefaultView[fcount]["PodID"]);
                    eventpod.Pod.Name = tblpod.DefaultView[fcount]["Pod"].ToString();
                    eventpodlist.Add(eventpod);
                    fcount++;
                }
                eevent.EventPod = eventpodlist;

                returnEvent.Add(eevent);
            }
            return returnEvent;
        }

        public List<EEvent> GetViewEventForHostDetails
            (
            string filterstring, int mode, long userid, long roleid, long shellid, string sortColumn, string sortOrder,
            int pageSize, int pageNumber, out long totalEventsonHost, out long totalEventOnHostZip,
            out long totalEventOnDistance
            )
        {
            //[usp_getvieweventForHostDetails] 
            //@filterstring='769',@mode=4,@userid=1058,@roleid=1,@shellid=3,
            //@SortColumn='EventDate',@SortOrder='DESC',@PageSize=10,@PageIndex=1
            totalEventsonHost = 0;
            totalEventOnHostZip = 0;
            totalEventOnDistance = 0;

            var arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 200);
            arParms[0].Value = filterstring;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;

            arParms[2] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[2].Value = userid;

            arParms[3] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[3].Value = roleid;

            arParms[4] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[4].Value = shellid;

            arParms[5] = new SqlParameter("@SortColumn", SqlDbType.VarChar, 255);
            arParms[5].Value = sortColumn;

            arParms[6] = new SqlParameter("@SortOrder", SqlDbType.VarChar, 20);
            arParms[6].Value = sortOrder;

            arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParms[7].Value = pageSize;

            arParms[8] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParms[8].Value = pageNumber;

            DataSet eventDataSet = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getvieweventForHostDetails",
                arParms);

            var returnEvent = new List<EEvent>();

            foreach (DataRow dr in eventDataSet.Tables[0].Rows)
            {
                var eevent = new EEvent();
                var ffuser = new EFranchiseeFranchiseeUser();
                eevent.EventID = Convert.ToInt32(dr["EventID"]);
                eevent.Active = Convert.ToBoolean(dr["IsActive"]);
                eevent.Name = dr["EventName"].ToString();
                eevent.EventDate = Convert.ToDateTime(dr["EventDate"].ToString()).ToShortDateString();
                eevent.CustomerCount = Convert.ToInt32(dr["Customer"]);
                eevent.Host = new EHost();
                eevent.Host.Name = dr["Host"].ToString();
                eevent.Host.HostID = Convert.ToInt32(dr["ProspectID"]);
                eevent.EventStatus = Convert.ToInt32(dr["EventStatus"]);
                eevent.HostEventType = Convert.ToInt32(dr["HostEventType"]);

                ffuser.FranchiseeFranchiseeUserID = Convert.ToInt32(dr["SalesRepID"]);

                if (Convert.ToBoolean(dr["IsPodAllocated"]))
                {
                    eevent.EventPod = new List<EEventPod>();
                }
                else
                {
                    eevent.EventPod = null;
                }

                eevent.FranchiseeFranchiseeUser = ffuser;


                returnEvent.Add(eevent);
            }
            // Bind total records
            if (eventDataSet.Tables.Count == 2)
            {
                if (eventDataSet.Tables[1].Rows.Count > 0)
                {
                    totalEventsonHost = Convert.ToInt64(eventDataSet.Tables[1].Rows[0]["TotalRecord"]);
                }
            }
            else if (eventDataSet.Tables.Count == 4)
            {
                if (eventDataSet.Tables[1].Rows.Count > 0)
                {
                    totalEventsonHost = Convert.ToInt64(eventDataSet.Tables[1].Rows[0]["TotalRecord"]);
                }
                if (eventDataSet.Tables[2].Rows.Count > 0)
                {
                    totalEventOnHostZip = Convert.ToInt64(eventDataSet.Tables[2].Rows[0]["TotalRecordEventsHostZip"]);
                }
                if (eventDataSet.Tables[3].Rows.Count > 0)
                {
                    totalEventOnDistance =
                        Convert.ToInt64(eventDataSet.Tables[3].Rows[0]["TotalRecordEventsHostZipDistance"]);
                }
            }
            return returnEvent;
        }

        public List<EEvent> GetCustomerEventPackageDetails(string filterstring, Int16 mode)
        {
            var arparams = new SqlParameter[2];
            arparams[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 500);
            arparams[0].Value = filterstring;

            arparams[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[1].Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getcustomereventdetail", arparams);
            List<EEvent> returnvalue = ParseCustomerEventPackageDetails(dstemp);
            return returnvalue;
        }

        private List<EEvent> ParseCustomerEventPackageDetails(DataSet dstemp)
        {
            var listevent = new List<EEvent>();
            if (dstemp == null)
            {
                return listevent;
            }

            if (dstemp.Tables.Count == 0)
            {
                return listevent;
            }

            DataTable dtevent = dstemp.Tables[0];
            DataTable dtpackage = dstemp.Tables[1];
            DataTable dttest = dstemp.Tables[2];

            for (int icount = 0; icount < dtevent.Rows.Count; icount++)
            {
                var objevent = new EEvent();

                objevent.EventID = Convert.ToInt32(dtevent.Rows[icount]["EventID"]);
                objevent.Name = Convert.ToString(dtevent.Rows[icount]["EventName"]);
                objevent.EventDate = Convert.ToString(dtevent.Rows[icount]["EventDate"]);
                objevent.Host = new EHost();
                objevent.Host.HostID = Convert.ToInt32(dtevent.Rows[icount]["HostID"]);
                objevent.Host.Address = new EAddress();
                objevent.Host.Address.AddressID = Convert.ToInt32(dtevent.Rows[icount]["AddressID"]);
                objevent.Host.Address.Zip = Convert.ToString(dtevent.Rows[icount]["ZipID"]);
                objevent.Host.Address.City = Convert.ToString(dtevent.Rows[icount]["City"]);
                objevent.Host.Address.Address1 = Convert.ToString(dtevent.Rows[icount]["HostAddress"]);
                objevent.Host.Name = Convert.ToString(dtevent.Rows[icount]["HostName"]);
                objevent.Host.Address.State = Convert.ToString(dtevent.Rows[icount]["State"]);
                objevent.Customer = new List<EEventCustomer>();

                var objeventcustomer = new EEventCustomer();
                objeventcustomer.Interpreted = Convert.ToBoolean(dtevent.Rows[icount]["IsInterpreted"]);

                //objeventcustomer.EventPaymentDetail = new EEventPaymentDetail();
                objeventcustomer.PaymentDetail = new EPaymentDetail();
                objeventcustomer.PaymentDetail.PaymentType = new EPaymentType();
                objeventcustomer.PaymentDetail.PaymentType.Name = Convert.ToString(dtevent.Rows[icount]["PaymentType"]);

                objeventcustomer.EventAppointment = new EEventAppointment();
                objeventcustomer.EventAppointment.StartTime = Convert.ToString(dtevent.Rows[icount]["StartTime"]);
                objeventcustomer.EventAppointment.EndTime = Convert.ToString(dtevent.Rows[icount]["EndTime"]);

                DataRow[] rowpackage = dtpackage.Select("EventID = " + objevent.EventID);
                if (rowpackage.Length < 1)
                {
                    continue;
                }

                var package = new EPackage();
                package.PackageID = Convert.ToInt32(rowpackage[0]["PackageID"]);
                package.PackageName = Convert.ToString(rowpackage[0]["PackageName"]);


                DataRow[] rowtest = dttest.Select("PackageID = " + package.PackageID);
                if (rowtest.Length < 1)
                {
                    continue;
                }

                package.Test = new List<ETest>();
                for (int iicount = 0; iicount < rowtest.Length; iicount++)
                {
                    var test = new ETest();
                    test.TestID = Convert.ToInt32(rowtest[iicount]["TestID"]);
                    test.Name = Convert.ToString(rowtest[iicount]["Name"]);
                    package.Test.Add(test);
                }
                var eventpackage = new EEventPackage();
                eventpackage.Package = package;

                objeventcustomer.EventPackage = eventpackage;
                objevent.Customer = new List<EEventCustomer>();
                objevent.Customer.Add(objeventcustomer);

                listevent.Add(objevent);
            }
            return listevent;
        }

        private List<EEventAppointment> ParseEventSlotDataSet(DataSet dsEventSlot)
        {
            var returnEventSlot = new List<EEventAppointment>();


            foreach (DataRow dr in dsEventSlot.Tables[0].Rows)
            {
                var eeventslot = new EEventAppointment();
                eeventslot.EventID = Convert.ToInt32(dr["EventID"]);
                eeventslot.StartTime = Convert.ToString(dr["StartTime"]);
                eeventslot.EndTime = Convert.ToString(dr["EndTime"]);
                eeventslot.AppointmentID = Convert.ToInt32(dr["AppointmentID"]);
                eeventslot.ScheduleByID = Convert.ToInt32(dr["ScheduledByID"]);
                returnEventSlot.Add(eeventslot);
            }
            return returnEventSlot;
        }

        // get configuration value
        public int GetConfigurationValue(string strFilterString)
        {
            var arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 500);
            arParms[0].Value = strFilterString;
            int maximumSlotInterval;
            maximumSlotInterval =
                Convert.ToInt32(SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure,
                    "usp_getconfigurationvalue", arParms));
            return maximumSlotInterval;
        }

        public Int64 SaveEventPod(List<EEventPod> pod, int Mode, Int64 eventid, Int32 franchiseeid, SqlTransaction sqltran, long territoryId)
        {
            var returnvalue = new Int64();
            try
            {
                if (Mode == 1)
                {
                    string sqlquery = "Update tbleventpod set IsActive = 0 where EventID = @eventid";
                    var eventparam = new SqlParameter("@eventid", SqlDbType.BigInt);
                    eventparam.Value = eventid;
                    if (sqltran == null)
                    {
                        SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery, eventparam);
                    }
                    else
                    {
                        SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, sqlquery, eventparam);
                    }
                }
                //string podIds = string.Empty;
                for (int icount = 0; icount < pod.Count; icount++)
                {
                    var arParms = new SqlParameter[4];
                    arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
                    arParms[0].Value = eventid;
                    arParms[1] = new SqlParameter("@podid", SqlDbType.BigInt);
                    arParms[1].Value = pod[icount].Pod.PodID;

                    //podIds += pod[icount].Pod.PodID + ",";

                    arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@territoryId", SqlDbType.BigInt);
                    if (territoryId > 0)
                        arParms[3].Value = territoryId;
                    else
                        arParms[3].Value = DBNull.Value;
                    if (sqltran == null)
                    {
                        SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventpod",
                            arParms);
                    }
                    else
                    {
                        SqlHelper.ExecuteNonQuery(sqltran, CommandType.StoredProcedure, "usp_saveeventpod", arParms);
                    }

                    returnvalue = (Int64)arParms[2].Value;
                    if (returnvalue == -1)
                    {
                        return returnvalue;
                    }

                }
                //podIds = podIds.Substring(0, podIds.Length - 1);
                //if (Mode == 1)
                //{
                //    string sqlquery =
                //        "Update TblEventPodTeam set IsActive = 0 where EventID = @eventid and PodID NOT IN (" + podIds +
                //            ") and franchiseeid = @franchiseeid";
                //    var eventteamparam = new SqlParameter[2];
                //    eventteamparam[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
                //    eventteamparam[0].Value = eventid;
                //    eventteamparam[1] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
                //    eventteamparam[1].Value = franchiseeid;
                //    if (sqltran == null)
                //    {
                //        SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery, eventteamparam);
                //    }
                //    else
                //    {
                //        SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, sqlquery, eventteamparam);
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnvalue;
        }

        /// <summary>
        /// Saves Event Referrals in database, corresponding to the eventid
        /// </summary>
        /// <param name="eventref"></param>
        /// <param name="EventID"></param>
        /// <param name="UserID"></param>
        /// <param name="Shell"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Int64 SaveEventRefferal(List<EEventReferral> eventref, Int64 EventID)
        {
            var returnvalue = new Int64();
            for (int icount = 0; icount < eventref.Count; icount++)
            {
                var arParms = new SqlParameter[6];
                arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
                arParms[0].Value = EventID;
                arParms[1] = new SqlParameter("@organizationname", SqlDbType.VarChar, 500);
                arParms[1].Value = eventref[icount].OrganizationName;
                arParms[2] = new SqlParameter("@contactperson", SqlDbType.VarChar, 500);
                arParms[2].Value = eventref[icount].ContactPerson;
                arParms[3] = new SqlParameter("@contactinfo", SqlDbType.VarChar, 500);
                arParms[3].Value = eventref[icount].PhoneNumber;

                arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[4].Direction = ParameterDirection.Output;
                arParms[5] = new SqlParameter("@eventreferralid", SqlDbType.BigInt);
                arParms[5].Value = eventref[icount].EventReferralID;
                arParms[6] = new SqlParameter("@mode", SqlDbType.TinyInt);
                arParms[6].Value = icount;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventreferral",
                    arParms);
                returnvalue = (Int64)arParms[4].Value;
            }

            return returnvalue;
        }

        public Int64 SaveEventPodTeam(List<EFranchiseeFranchiseeUser> lstTeam, int podid, Int64 eventid, SqlTransaction sqltran)
        {
            var returnvalue = new Int64();
            if (lstTeam == null || lstTeam.Count == 0)
            {
                var arparams = new SqlParameter[8];
                arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
                arparams[0].Value = eventid;

                arparams[1] = new SqlParameter("@podid", SqlDbType.BigInt);
                arparams[1].Value = podid;

                arparams[2] = new SqlParameter("@franchiseefranchiseeuserid", SqlDbType.BigInt);
                arparams[2].Value = 0;


                arparams[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arparams[3].Value = 1;

                arparams[4] = new SqlParameter("@returnvalue", SqlDbType.TinyInt);
                arparams[4].Direction = ParameterDirection.Output;
                arparams[5] = new SqlParameter("@eventroleid", SqlDbType.BigInt);
                arparams[5].Value = DBNull.Value;
                arparams[6] = new SqlParameter("@showonreport", SqlDbType.Bit);
                arparams[6].Value = false;
                arparams[7] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
                arparams[7].Value = 0;
                if (sqltran == null)
                {
                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventpodteam",
                        arparams);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(sqltran, CommandType.StoredProcedure, "usp_saveeventpodteam", arparams);
                }

                return Convert.ToInt64(arparams[4].Value);
            }

            for (int icount = 0; icount < lstTeam.Count; icount++)
            {
                var arparams = new SqlParameter[8];
                arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
                arparams[0].Value = eventid;

                arparams[1] = new SqlParameter("@podid", SqlDbType.BigInt);
                arparams[1].Value = podid;

                arparams[2] = new SqlParameter("@franchiseefranchiseeuserid", SqlDbType.BigInt);
                arparams[2].Value = lstTeam[icount].FranchiseeFranchiseeUserID;

                arparams[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arparams[3].Value = 0;

                arparams[4] = new SqlParameter("@returnvalue", SqlDbType.TinyInt);
                arparams[4].Direction = ParameterDirection.Output;

                arparams[5] = new SqlParameter("@eventroleid", SqlDbType.BigInt);
                arparams[5].Value = lstTeam[icount].EventRoleID;

                arparams[6] = new SqlParameter("@showonreport", SqlDbType.Bit);
                arparams[6].Value = lstTeam[icount].ShowOnReport;
                arparams[7] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
                arparams[7].Value = 0;

                if (sqltran == null)
                {
                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventpodteam",
                        arparams);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(sqltran, CommandType.StoredProcedure, "usp_saveeventpodteam", arparams);
                }

                returnvalue = Convert.ToInt64(arparams[4].Value);
            }
            return returnvalue;
        }

        public Int64 SaveEventCustomers(EEventCustomer eventcustomer, string UserID, string Shell, string Role,
            SqlTransaction sqltransaction)
        {
            Int64 returnvalue;
            var arParms = new SqlParameter[17];

            arParms[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arParms[0].Value = eventcustomer.CustomerEventTestID;

            arParms[1] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[1].Value = eventcustomer.EventID;

            arParms[2] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arParms[2].Value = eventcustomer.Customer.CustomerID;

            arParms[3] = new SqlParameter("@ispaymentonline", SqlDbType.Bit);
            arParms[3].Value = eventcustomer.PaymentOnline;

            arParms[4] = new SqlParameter("@appointmentid", SqlDbType.BigInt);
            arParms[4].Value = eventcustomer.AppointmentID;

            arParms[5] = new SqlParameter("@packageid", SqlDbType.BigInt);
            arParms[5].Value = eventcustomer.EventPackage.Package.PackageID;

            arParms[6] = new SqlParameter("@istestconducted", SqlDbType.Bit);
            arParms[6].Value = eventcustomer.TestConducted;

            arParms[7] = new SqlParameter("@ispaid", SqlDbType.Bit);
            arParms[7].Value = eventcustomer.Paid;
            /// after DB change eventCustomerId is inserting in the tblPaymentdetails 
            /// instead of the paymentdetailsid in the tbleventcustomer,. SO BELOW MENTIONED 
            /// PARAMETER IS NOT USED INTHE SP.
            arParms[8] = new SqlParameter("@paymentdetailsid", SqlDbType.BigInt);
            arParms[8].Value = eventcustomer.PaymentDetail.PaymentDetailID;
            /////////
            arParms[9] = new SqlParameter("@callcentercallcenteruserid", SqlDbType.BigInt);
            if (eventcustomer.CallCenterCallCenterUser == null)
            {
                arParms[9].Value = DBNull.Value;
            }
            else
            {
                arParms[9].Value = eventcustomer.CallCenterCallCenterUser.CallCenterCallCenterUserID;
            }

            arParms[10] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[10].Value = UserID;
            arParms[11] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[11].Value = Shell;
            arParms[12] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[12].Value = Role;
            arParms[13] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[13].Direction = ParameterDirection.Output;
            arParms[14] = new SqlParameter("@mailreports", SqlDbType.Bit);
            arParms[14].Value = eventcustomer.ReportEmail;

            // added column marketingsource 
            arParms[15] = new SqlParameter("@marketingSource", SqlDbType.VarChar, 500);
            arParms[15].Value = eventcustomer.MarketingSource;

            arParms[16] = new SqlParameter("@ClickId", SqlDbType.BigInt);
            arParms[16].Value = eventcustomer.ClickId;

            if (sqltransaction == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventcustomer",
                    arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_saveeventcustomer", arParms);
            }

            returnvalue = Convert.ToInt64(arParms[13].Value);
            return returnvalue;
        }

        public Int64 AssignAffiliate(Int64 intEventCustomerID, Int64 intCallID, string UserID, string Shell, string Role,
            SqlTransaction sqltransaction)
        {
            Int64 returnvalue = 0;
            var arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arParms[0].Value = intEventCustomerID;

            arParms[1] = new SqlParameter("@callid", SqlDbType.BigInt);
            arParms[1].Value = intCallID;
            arParms[2] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[2].Value = UserID;
            arParms[3] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[3].Value = Shell;
            arParms[4] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[4].Value = Role;
            if (sqltransaction == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_AFSaveEventAffiliate",
                    arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_AFSaveEventAffiliate",
                    arParms);
            }
            return returnvalue;
        }



        public List<EEventCustomer> GetCustomerListRoaster(string eventid, int mode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = mode;
            arParms[1] = new SqlParameter("@filterstring", SqlDbType.BigInt);
            arParms[1].Value = eventid;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getprintroaster",
                arParms);

            var returnEvent = new List<EEventCustomer>();
            returnEvent = ParsePrintRoasterDataSet(tempdataset);
            return returnEvent;
        }

        private List<EEventCustomer> ParsePrintRoasterDataSet(DataSet dsRoster)
        {
            var returnRoaster = new List<EEventCustomer>();
            foreach (DataRow dr in dsRoster.Tables[0].Rows)
            {
                var objEvent = new EEventCustomer();
                objEvent.EventPackage = new EEventPackage();
                objEvent.Customer = new ECustomers();
                objEvent.Customer.User = new EUser();
                objEvent.EventPackage.Package = new EPackage();
                objEvent.EventAppointment = new EEventAppointment();
                objEvent.Coupon = new ECoupon();
                objEvent.Customer.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                objEvent.Customer.User.FirstName = dr["FirstName"].ToString();
                objEvent.Customer.User.MiddleName = dr["MiddleName"].ToString();
                objEvent.Customer.User.LastName = dr["LastName"].ToString();
                objEvent.EventAppointment.CheckInTime = dr["CheckInTime"].ToString();
                objEvent.EventAppointment.CheckOutTime = dr["CheckOutTime"].ToString();
                objEvent.Customer.User.EMail1 = dr["Email1"].ToString();
                objEvent.Customer.User.PhoneCell = dr["Phone"].ToString();

                objEvent.Paid = Convert.ToBoolean(dr["IsPaid"]);
                objEvent.EventPackage.Package.PackageName = dr["PackageName"].ToString();
                objEvent.AdditionalTest = dr["AdditionalTest"].ToString();
                objEvent.IsShippingApplied = Convert.ToBoolean(dr["isShipping"]);
                objEvent.PaymentDetail = new EPaymentDetail();
                if (dr["NetPayment"] != DBNull.Value)
                {
                    objEvent.PaymentDetail.Amount = Convert.ToSingle(dr["NetPayment"]);
                }
                else
                {
                    objEvent.PaymentDetail.Amount = 0;
                }

                objEvent.EventAppointment.StartTime = dr["StartTime"].ToString();
                objEvent.EventAppointment.EndTime = dr["EndTime"].ToString();
                objEvent.EventAppointment.AppointmentID = Convert.ToInt64(dr["AppointmentId"]);
                if ((dr["CouponCode"].ToString() != string.Empty) || (dr["CouponCode"].ToString() != ""))
                {
                    objEvent.Coupon.CouponCode = dr["CouponCode"].ToString();
                    objEvent.Coupon.CouponValue = Convert.ToDecimal(dr["DiscountAmount"]);
                }
                returnRoaster.Add(objEvent);
            }

            return returnRoaster;
        }

        public List<EEvent> GetEventDetails(int eventid)
        {
            var arparams = new SqlParameter[1];
            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[0].Value = eventid;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString, "usp_geteventdetails", arparams);
            return ParseEventDetailsDataset(dstemp);
        }

        private List<EEvent> ParseEventDetailsDataset(DataSet dseventdetails)
        {
            var lstevent = new List<EEvent>();
            if (dseventdetails == null)
            {
                return lstevent;
            }

            DataTable dtevents = dseventdetails.Tables[0];
            DataTable dthostevent = dseventdetails.Tables[1];
            DataTable dtseminar = dseventdetails.Tables[2];
            DataTable dteventpod = dseventdetails.Tables[3];
            DataTable dteventreferrals = dseventdetails.Tables[4];
            DataTable dteventpodteam = dseventdetails.Tables[5];
            DataTable dtHostAddress = dseventdetails.Tables[6];

            for (int icount = 0; icount < dtevents.Rows.Count; icount++)
            {
                var objevent = new EEvent();
                var objhost = new EHost();
                var listeventreferral = new List<EEventReferral>();

                objevent.EventID = Convert.ToInt32(dtevents.Rows[icount]["EventID"]);
                objevent.Name = Convert.ToString(dtevents.Rows[icount]["EventName"]);
                objevent.EventDate = Convert.ToString(dtevents.Rows[icount]["EventDate"]);

                objevent.EventStartTime = Convert.ToString(dtevents.Rows[icount]["EventStartTime"]);
                objevent.EventEndTime = Convert.ToString(dtevents.Rows[icount]["EventEndTime"]);
                objevent.EventType = new EEventType();
                objevent.EventType.EventTypeID = Convert.ToInt32(dtevents.Rows[icount]["EventTypeID"]);
                objevent.ScheduleTemplateID = Convert.ToInt32(dtevents.Rows[icount]["ScheduleTemplateID"]);
                objevent.Rescheduled = Convert.ToBoolean(dtevents.Rows[icount]["IsRescheduled"]);
                objevent.EventActivityTemplateID = Convert.ToInt64(dtevents.Rows[icount]["EventActivityTemplateID"]);

                objevent.Franchisee = new EFranchisee();
                objevent.FranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser();

                objevent.Franchisee.FranchiseeID = Convert.ToInt32(dtevents.Rows[icount]["FranchiseeID"]);
                objevent.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID =
                    Convert.ToInt32(dtevents.Rows[icount]["SalesRepID"]);

                objevent.EventNotes = Convert.ToString(dtevents.Rows[icount]["EventNotes"]);

                objevent.EventScheduleMethod = new EEventScheduleMethod();
                if (dtevents.Rows[icount]["ScheduleMethodID"] != DBNull.Value)
                {
                    objevent.EventScheduleMethod.EventScheduleMethodID =
                        Convert.ToInt32(dtevents.Rows[icount]["ScheduleMethodID"]);
                }

                objevent.CosttoUseHostSite = Convert.ToSingle(dtevents.Rows[icount]["CosttoUseHostSite"]);
                objevent.CommunicationMode = new ECommunicationMode();
                if (dtevents.Rows[icount]["CommunicationModeID"] != DBNull.Value)
                {
                    objevent.CommunicationMode.CommunicationModeID =
                        Convert.ToInt32(dtevents.Rows[icount]["CommunicationModeID"]);
                }

                objevent.GoogleURI = Convert.ToString(dtevents.Rows[icount]["GoogleURI"]);
                objevent.CustomerCount = Convert.ToInt32(dtevents.Rows[icount]["CustomerCount"]);

                if (dthostevent.Rows.Count < 1)
                {
                    continue;
                }

                dthostevent.DefaultView.RowFilter = "EventID = " + objevent.EventID;
                if (dthostevent.DefaultView.Count < 1)
                {
                    continue;
                }
                objhost.HostID = Convert.ToInt32(dthostevent.Rows[0]["HostID"]);
                objhost.Name = Convert.ToString(dthostevent.Rows[0]["Host"]);
                objevent.MinimumSiteRequirements = Convert.ToBoolean(dthostevent.Rows[icount]["bConfirmMinRequirements"]);
                objevent.ConfirmVisually = Convert.ToBoolean(dthostevent.Rows[icount]["bConfirmedVisually"]);
                objevent.ConfirmComments = Convert.ToString(dthostevent.Rows[icount]["ConfirmedVisuallyComments"]);

                var lsteventpod = new List<EEventPod>();
                dteventpod.DefaultView.RowFilter = "EventID=" + objevent.EventID;
                for (int jcount = 0; jcount < dteventpod.DefaultView.Count; jcount++)
                {
                    var objeventpod = new EEventPod();
                    objeventpod.EventID = Convert.ToInt32(dteventpod.DefaultView[jcount]["EventID"]);
                    objeventpod.Pod = new EPod();
                    objeventpod.Pod.PodID = Convert.ToInt32(dteventpod.DefaultView[jcount]["PodID"]);
                    objeventpod.Pod.Name = Convert.ToString(dteventpod.DefaultView[jcount]["Name"]);
                    objeventpod.Pod.Description = Convert.ToString(dteventpod.DefaultView[jcount]["Description"]);
                    objeventpod.Pod.Van = new EVan();
                    objeventpod.Pod.Van.Name = Convert.ToString(dteventpod.DefaultView[jcount]["VanName"]);
                    objeventpod.Pod.Van.RegistrationNumber =
                        Convert.ToString(dteventpod.DefaultView[jcount]["RegistrationNumber"]);
                    objeventpod.Pod.Van.Make = Convert.ToString(dteventpod.DefaultView[jcount]["Make"]);
                    objeventpod.EventPodID = Convert.ToInt32(dteventpod.DefaultView[jcount]["EventPodID"]);
                    objeventpod.Pod.TeamIDList = new List<EFranchiseeFranchiseeUser>();
                    if (dteventpodteam.Rows.Count > 0)
                    {
                        dteventpodteam.DefaultView.RowFilter = "EventID = " + objevent.EventID +
                            " and PodID = " + objeventpod.Pod.PodID;
                        for (int scount = 0; scount < dteventpodteam.DefaultView.Count; scount++)
                        {
                            var userteamobj = new EFranchiseeFranchiseeUser();
                            userteamobj.FranchiseeFranchiseeUserID =
                                Convert.ToInt32(dteventpodteam.DefaultView[scount]["FranchiseeFranchiseeUserID"]);
                            userteamobj.RoleID = Convert.ToInt32(dteventpodteam.DefaultView[scount]["RoleID"]);
                            userteamobj.RoleType = Convert.ToString(dteventpodteam.DefaultView[scount]["RoleName"]);
                            userteamobj.ShowOnReport =
                                Convert.ToBoolean(dteventpodteam.DefaultView[scount]["DisplayOnReport"]);
                            userteamobj.EventRoleID = Convert.ToInt32(dteventpodteam.DefaultView[scount]["EventRoleID"]);
                            userteamobj.EventRoleName =
                                Convert.ToString(dteventpodteam.DefaultView[scount]["EventRoleName"]);
                            userteamobj.FranchiseeUser = new EFranchiseeUser();
                            userteamobj.FranchiseeUser.User = new EUser();
                            userteamobj.FranchiseeUser.User.FirstName =
                                Convert.ToString(dteventpodteam.DefaultView[scount]["FirstName"]);

                            if (dteventpodteam.DefaultView[scount]["MiddleName"] != DBNull.Value)
                            {
                                userteamobj.FranchiseeUser.User.MiddleName =
                                    Convert.ToString(dteventpodteam.DefaultView[scount]["MiddleName"]);
                            }

                            userteamobj.FranchiseeUser.User.LastName =
                                Convert.ToString(dteventpodteam.DefaultView[scount]["LastName"]);
                            objeventpod.Pod.TeamIDList.Add(userteamobj);
                        }
                    }
                    lsteventpod.Add(objeventpod);
                }

                if (dteventreferrals.Rows.Count > 0)
                {
                    dteventreferrals.DefaultView.RowFilter = "EventID=" + objevent.EventID;
                    for (int jcount = 0; jcount < dteventreferrals.DefaultView.Count; jcount++)
                    {
                        var objeventreferral = new EEventReferral();
                        objeventreferral.EventID = Convert.ToInt32(dteventreferrals.DefaultView[jcount]["EventID"]);
                        objeventreferral.EventReferralID =
                            Convert.ToInt32(dteventreferrals.DefaultView[jcount]["EventReferralID"]);
                        objeventreferral.OrganizationName =
                            Convert.ToString(dteventreferrals.DefaultView[jcount]["OrganizationName"]);
                        objeventreferral.ContactPerson =
                            Convert.ToString(dteventreferrals.DefaultView[jcount]["ContactPerson"]);
                        objeventreferral.PhoneNumber =
                            Convert.ToString(dteventreferrals.DefaultView[jcount]["contactinfo"]);
                        listeventreferral.Add(objeventreferral);
                    }
                }


                var hostaddress = new EAddress();
                hostaddress.Address1 = Convert.ToString(dtHostAddress.Rows[0]["Address1"]);
                hostaddress.Address2 = Convert.ToString(dtHostAddress.Rows[0]["Address2"]);
                hostaddress.AddressID = Convert.ToInt32(dtHostAddress.Rows[0]["AddressID"]);
                hostaddress.City = Convert.ToString(dtHostAddress.Rows[0]["City"]);
                hostaddress.State = Convert.ToString(dtHostAddress.Rows[0]["State"]);
                hostaddress.Country = Convert.ToString(dtHostAddress.Rows[0]["Country"]);
                hostaddress.Zip = Convert.ToString(dtHostAddress.Rows[0]["ZipCode"]);


                objhost.Address = hostaddress;

                objevent.Host = objhost;
                objevent.EventPod = lsteventpod;
                objevent.EventReferrral = listeventreferral;
                lstevent.Add(objevent);
            }
            return lstevent;
        }


        /// <summary>
        /// Verify Invitation code for private event
        /// </summary>
        /// <param name="EventID"></param>
        /// <param name="strInvitationcode"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public Int16 VerifyInvitation(int EventID, string strInvitationcode, int mode)
        {
            Int16 returnvalue = 0;
            var arparams = new SqlParameter[4];

            arparams[0] = new SqlParameter("@eventid", SqlDbType.Int);
            arparams[0].Value = EventID;

            arparams[1] = new SqlParameter("@invitationcode", SqlDbType.VarChar, 255);
            arparams[1].Value = strInvitationcode;

            arparams[2] = new SqlParameter("@mode", SqlDbType.Int);
            arparams[2].Value = mode;

            arparams[3] = new SqlParameter("@returnvalue", SqlDbType.Int);
            arparams[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_VerifyInvitation", arparams);
            returnvalue = Convert.ToInt16(arparams[3].Value);
            return returnvalue;
        }

        /// <summary>
        /// Deletes the event from database.
        /// </summary>
        /// <param name="EventID"></param>
        /// <param name="UserID"></param>
        /// <param name="Shell"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Int16 RemoveEvent(long EventID)
        {
            var arparams = new SqlParameter[2];

            arparams[0] = new SqlParameter("@eventID", SqlDbType.BigInt);
            arparams[0].Value = EventID;


            arparams[1] = new SqlParameter("@returnvalue", SqlDbType.SmallInt);
            arparams[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removeevent", arparams);
            return Convert.ToInt16(arparams[1].Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventcustomer"></param>
        /// <returns></returns>
        public Int64 SaveEventAttendTiming(List<EEventCustomer> eventcustomer)
        {
            var arparams = new SqlParameter[6];

            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@appointmentid", SqlDbType.BigInt);
            arparams[3] = new SqlParameter("@checkintime", SqlDbType.VarChar, 200);
            arparams[4] = new SqlParameter("@checkouttime", SqlDbType.VarChar, 200);
            arparams[5] = new SqlParameter("@noshow", SqlDbType.Bit);
            foreach (EEventCustomer objeventcust in eventcustomer)
            {
                arparams[0].Value = objeventcust.EventID;
                arparams[1].Value = objeventcust.Customer.CustomerID;
                arparams[2].Value = objeventcust.EventAppointment.AppointmentID;
                if (objeventcust.EventAppointment.CheckInTime == null ||
                    objeventcust.EventAppointment.CheckInTime.Length < 1)
                {
                    arparams[3].Value = DBNull.Value;
                }
                else
                {
                    arparams[3].Value = objeventcust.EventAppointment.CheckInTime;
                }
                if (objeventcust.EventAppointment.CheckOutTime == null ||
                    objeventcust.EventAppointment.CheckOutTime.Length < 1)
                {
                    arparams[4].Value = DBNull.Value;
                }
                else
                {
                    arparams[4].Value = objeventcust.EventAppointment.CheckOutTime;
                }
                arparams[5].Value = objeventcust.NoShow;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                    "usp_savecustomereventattendtiming", arparams);
            }

            return 0;
        }

        /// <summary>
        /// Fetches All Events for a particular state, city, and zipcode and for a particular range of distance
        /// </summary>
        /// <param name="state"></param>
        /// <param name="city"></param>
        /// <param name="zipcode"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public List<EEvent> SearchNearestEvents(string state, string city, string zipcode, string range,
            string strFromDate, string strToDate, string eventname, string host,
            string invitationcode, int mode)
        {
            var arparams = new SqlParameter[10];

            arparams[0] = new SqlParameter("@state", SqlDbType.VarChar, 100);
            arparams[0].Value = state;
            arparams[1] = new SqlParameter("@city", SqlDbType.VarChar, 100);
            arparams[1].Value = city;
            arparams[2] = new SqlParameter("@zip", SqlDbType.VarChar, 100);
            arparams[2].Value = zipcode;
            arparams[3] = new SqlParameter("@range", SqlDbType.VarChar, 10);
            arparams[3].Value = range;
            arparams[4] = new SqlParameter("@fromdate", SqlDbType.VarChar, 20);
            arparams[4].Value = strFromDate;
            arparams[5] = new SqlParameter("@todate", SqlDbType.VarChar, 20);
            arparams[5].Value = strToDate;
            arparams[6] = new SqlParameter("@eventname", SqlDbType.VarChar, 100);
            arparams[6].Value = eventname;
            arparams[7] = new SqlParameter("@host", SqlDbType.VarChar, 100);
            arparams[7].Value = host;

            arparams[8] = new SqlParameter("@invitationcode", SqlDbType.VarChar, 255);
            arparams[8].Value = invitationcode;

            arparams[9] = new SqlParameter("@mode", SqlDbType.Int);
            arparams[9].Value = mode;

            DataSet dsEvent = SqlHelper.ExecuteDataset(_connectionString,
                "usp_UI_searcheventandhost", arparams);

            return ParseNearestEventsDetailsDataset(dsEvent);
        }

        /// <summary>
        /// Search for source code is applicable for private events or not.
        /// </summary>
        /// <param name="eventid"></param>
        /// <returns></returns>
        public int SearchInvitationSourceCode(int eventid)
        {
            int returnvalue;

            var arparams = new SqlParameter[2];

            arparams[0] = new SqlParameter("@eventid", SqlDbType.Int);
            arparams[0].Value = eventid;

            arparams[1] = new SqlParameter("@returnvalue", SqlDbType.Int);
            arparams[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_CheckInvitationSourceCode",
                arparams);
            returnvalue = Convert.ToInt32(arparams[1].Value);

            return returnvalue;
        }

        private List<EEvent> ParseNearestEventsDetailsDataset(DataSet dsEvent)
        {
            var lstevent = new List<EEvent>();

            if (dsEvent == null)
            {
                return lstevent;
            }

            DataTable dtEvents = dsEvent.Tables[0];
            for (int icount = 0; icount < dtEvents.Rows.Count; icount++)
            {
                var objEvents = new EEvent();
                objEvents.Host = new EHost();
                objEvents.Host.Address = new EAddress();
                objEvents.EventType = new EEventType();
                objEvents.SlotCount = Convert.ToInt32(dtEvents.Rows[icount]["Slot"]);
                objEvents.OccupiedSlotCount = Convert.ToInt32(dtEvents.Rows[icount]["OccupiedSlot"]);
                objEvents.Distance = Convert.ToDouble(dtEvents.Rows[icount]["distance"]);
                objEvents.EventID = Convert.ToInt32(dtEvents.Rows[icount]["EventID"]);
                objEvents.Name = Convert.ToString(dtEvents.Rows[icount]["Name"]);
                objEvents.EventDate = Convert.ToString(dtEvents.Rows[icount]["Date"]);
                objEvents.Host.Name = Convert.ToString(dtEvents.Rows[icount]["Host"]);
                objEvents.Host.Address.Address1 = Convert.ToString(dtEvents.Rows[icount]["Address1"]);
                objEvents.Host.Address.City = Convert.ToString(dtEvents.Rows[icount]["City"]);
                objEvents.Host.Address.State = Convert.ToString(dtEvents.Rows[icount]["State"]);
                objEvents.Host.Address.Zip = Convert.ToString(dtEvents.Rows[icount]["ZipCode"]);
                objEvents.IsActiveSlots = Convert.ToInt32(dtEvents.Rows[icount]["ActiveSlots"]);
                if (dtEvents.Rows[icount]["EventType"] != DBNull.Value)
                {
                    objEvents.EventType.Name = Convert.ToString(dtEvents.Rows[icount]["EventType"]);
                }
                objEvents.IsSourceCodeApply = Convert.ToBoolean(dtEvents.Rows[icount]["IsSourceCodeApply"]);
                objEvents.EventNotes = Convert.ToString(dtEvents.Rows[icount]["EventNotes"]);
                objEvents.EventStatus = Convert.ToInt32(dtEvents.Rows[icount]["EventStatus"]);
                lstevent.Add(objEvents);
            }
            return lstevent;
        }

        /// <summary>
        /// Search event on the basis of zip, distance and date
        /// </summary>
        /// <param name="zipcode"></param>
        /// <param name="range"></param>
        /// <param name="strFromDate"></param>
        /// <param name="strToDate"></param>
        /// <returns></returns>
        public List<EEvent> SearchEventsByDistance(string zipcode, string range, string strFromDate, string strToDate)
        {
            var arparams = new SqlParameter[4];

            arparams[0] = new SqlParameter("@zip", SqlDbType.VarChar, 100);
            arparams[0].Value = zipcode;
            arparams[1] = new SqlParameter("@range", SqlDbType.VarChar, 10);
            arparams[1].Value = range;
            arparams[2] = new SqlParameter("@fromdate", SqlDbType.VarChar, 20);
            arparams[2].Value = strFromDate;
            arparams[3] = new SqlParameter("@todate", SqlDbType.VarChar, 20);
            arparams[3].Value = strToDate;

            DataSet dsEvent = SqlHelper.ExecuteDataset(_connectionString,
                "usp_SearcheventByDistance", arparams);
            return ParseEventsByDistance(dsEvent);
        }

        private List<EEvent> ParseEventsByDistance(DataSet dsEvent)
        {
            var lstevent = new List<EEvent>();

            if (dsEvent == null)
            {
                return lstevent;
            }

            DataTable dtEvents = dsEvent.Tables[0];
            for (int icount = 0; icount < dtEvents.Rows.Count; icount++)
            {
                var objEvents = new EEvent();
                objEvents.Host = new EHost();
                objEvents.Host.Address = new EAddress();
                //objEvents.SlotCount = Convert.ToInt32(dtEvents.Rows[icount]["Slot"]);
                // objEvents.OccupiedSlotCount = Convert.ToInt32(dtEvents.Rows[icount]["OccupiedSlot"]);
                objEvents.Distance = Convert.ToDouble(dtEvents.Rows[icount]["distance"]);
                objEvents.EventID = Convert.ToInt32(dtEvents.Rows[icount]["EventID"]);
                objEvents.Name = Convert.ToString(dtEvents.Rows[icount]["Name"]);
                objEvents.EventDate = Convert.ToString(dtEvents.Rows[icount]["Date"]);
                objEvents.Host.Name = Convert.ToString(dtEvents.Rows[icount]["Host"]);
                objEvents.Host.Address.Address1 = Convert.ToString(dtEvents.Rows[icount]["Address1"]);
                objEvents.Host.Address.City = Convert.ToString(dtEvents.Rows[icount]["City"]);
                objEvents.Host.Address.State = Convert.ToString(dtEvents.Rows[icount]["State"]);
                objEvents.Host.Address.Zip = Convert.ToString(dtEvents.Rows[icount]["ZipCode"]);
                //objEvents.IsActiveSlots = Convert.ToInt32(dtEvents.Rows[icount]["ActiveSlots"]);
                lstevent.Add(objEvents);
            }
            return lstevent;
        }

        public List<EEvent> SearchFreeEventDetails(Int64 eventid, string eventname, string cityname, string statename,
            string zipcode, string fromdate, string todate, int franchiseeid,
            Int16 mode)
        {
            var arparams = new SqlParameter[9];

            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[0].Value = eventid;

            arparams[1] = new SqlParameter("@eventname", SqlDbType.VarChar, 200);
            if (eventname.Trim().Length < 1)
            {
                arparams[1].Value = DBNull.Value;
            }
            else
            {
                arparams[1].Value = eventname;
            }

            //arparams[2] = new SqlParameter("@stateid", SqlDbType.Int);
            //arparams[2].Value = stateid;

            //arparams[3] = new SqlParameter("@cityid", SqlDbType.Int);
            //arparams[3].Value = cityid;

            arparams[2] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (statename.Trim().Length < 1)
            {
                arparams[2].Value = DBNull.Value;
            }
            else
            {
                arparams[2].Value = statename;
            }

            arparams[3] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (cityname.Trim().Length < 1)
            {
                arparams[3].Value = DBNull.Value;
            }
            else
            {
                arparams[3].Value = cityname;
            }
            arparams[4] = new SqlParameter("@zipcode", SqlDbType.VarChar, 100);
            if (zipcode.Trim().Length < 1)
            {
                arparams[4].Value = DBNull.Value;
            }
            else
            {
                arparams[4].Value = zipcode;
            }

            arparams[5] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            if (fromdate.Trim().Length < 1)
            {
                arparams[5].Value = DBNull.Value;
            }
            else
            {
                arparams[5].Value = fromdate;
            }


            arparams[6] = new SqlParameter("@todate", SqlDbType.DateTime);
            if (todate.Trim().Length < 1)
            {
                arparams[6].Value = DBNull.Value;
            }
            else
            {
                arparams[6].Value = todate;
            }


            arparams[7] = new SqlParameter("@franchiseeid", SqlDbType.Int);
            arparams[7].Value = franchiseeid;

            arparams[8] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[8].Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getfreeevents",
                arparams);
            var returnvalue = new List<EEvent>();
            returnvalue = ParseEventDataSet(dstemp);
            return returnvalue;
        }

        public List<EEvent> GetEvent(string eventID, string mode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt64(eventID);

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = Convert.ToInt16(mode);

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getevents",
                arParms);
            var objListEvent = new List<EEvent>();

            var objevent = new EEvent();
            objevent.Host = new EHost();
            var address = new EAddress();
            //objEvent[0].Host.Address = new EAddress();
            objevent.EventID = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["EventID"]);
            objevent.Name = Convert.ToString(tempdataset.Tables[0].Rows[0]["EventName"]);
            objevent.EventDate = Convert.ToString(tempdataset.Tables[0].Rows[0]["EventDate"]);
            objevent.TimeZone = Convert.ToString(tempdataset.Tables[0].Rows[0]["TimeZone"]);
            address.Address1 = Convert.ToString(tempdataset.Tables[1].Rows[0]["Address1"]);
            address.Address2 = Convert.ToString(tempdataset.Tables[1].Rows[0]["Address2"]);
            address.City = Convert.ToString(tempdataset.Tables[1].Rows[0]["City"]);
            address.Zip = Convert.ToString(tempdataset.Tables[1].Rows[0]["ZipCode"]);
            address.State = Convert.ToString(tempdataset.Tables[1].Rows[0]["State"]);
            objevent.Host.Name = Convert.ToString(tempdataset.Tables[0].Rows[0]["HostName"]);
            objevent.Host.Address = address;
            objListEvent.Add(objevent);
            return objListEvent;
        }

        /// <summary>
        /// Fetches Event Schedule Template from database
        /// </summary>
        /// <param name="filterstring"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<EScheduleTemplate> GetEventScheduleTemplate(string filterstring, long franchiseeid, Int16 mode)
        {
            var arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 100);
            arparams[0].Value = filterstring;
            arparams[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[1].Value = mode;
            arparams[2] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            arparams[2].Value = franchiseeid;


            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getscheduletemplate", arparams);
            return ParseEventScheduleDataset(dstemp);
        }

        /// <summary>
        /// Parses DataSet into Schedule Template List Object
        /// </summary>
        /// <param name="dsScheduletemplate"></param>
        /// <returns></returns>
        private List<EScheduleTemplate> ParseEventScheduleDataset(DataSet dsScheduletemplate)
        {
            var lstscheduletemplate = new List<EScheduleTemplate>();
            if (dsScheduletemplate == null)
            {
                return lstscheduletemplate;
            }

            foreach (DataRow drow in dsScheduletemplate.Tables[0].Rows)
            {
                var objscheduletemplate = new EScheduleTemplate();
                objscheduletemplate.ScheduleTemplateID = Convert.ToInt32(drow["ScheduleTemplateID"]);
                objscheduletemplate.Name = Convert.ToString(drow["Name"]);
                objscheduletemplate.Description = Convert.ToString(drow["Description"]);
                objscheduletemplate.Global = Convert.ToBoolean(drow["IsGlobal"]);
                objscheduletemplate.IsActive = Convert.ToBoolean(drow["IsActive"]);
                objscheduletemplate.CreatedByRole = Convert.ToBoolean(drow["CreatedByRole"]);
                objscheduletemplate.CreateBy = Convert.ToInt32(drow["Createdby"]);
                if (drow["ModifiedByRole"] != DBNull.Value) objscheduletemplate.ModifiedByRole = Convert.ToBoolean(drow["ModifiedByRole"]);
                if (drow["ModifiedBy"] != DBNull.Value) objscheduletemplate.ModifiedBy = Convert.ToInt32(drow["ModifiedBy"]);
                objscheduletemplate.DateCreated = Convert.ToString(drow["DateCreated"]);
                objscheduletemplate.DateModified = Convert.ToString(drow["DateModified"]);

                lstscheduletemplate.Add(objscheduletemplate);
            }
            return lstscheduletemplate;
        }

        /// <summary>
        /// Creates a new EventSchedule Template or
        /// Updates according to the mode supplied to function
        /// </summary>
        /// <param name="objScheduleTemplate"></param>
        /// <param name="mode"></param>
        /// <param name="UserID"></param>
        /// <param name="Shell"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Int64 SaveScheduleTemplate(EScheduleTemplate objScheduleTemplate, short mode)
        {
            Int64 returnvalue = 0;

            var arparams = new SqlParameter[9];

            arparams[0] = new SqlParameter("@scheduletemplateid", SqlDbType.BigInt);
            arparams[0].Value = objScheduleTemplate.ScheduleTemplateID;

            arparams[1] = new SqlParameter("@schedulename", SqlDbType.VarChar, 500);
            arparams[1].Value = objScheduleTemplate.Name;

            arparams[2] = new SqlParameter("@description", SqlDbType.VarChar, 5000);
            arparams[2].Value = objScheduleTemplate.Description;

            arparams[3] = new SqlParameter("@isglobal", SqlDbType.Bit);
            arparams[3].Value = objScheduleTemplate.Global;

            arparams[4] = new SqlParameter("@CreatedByOrgRoleUserId", SqlDbType.BigInt);
            arparams[4].Value = objScheduleTemplate.CreateBy;

            arparams[5] = new SqlParameter("@ModifiedByOrgRoleUserId", SqlDbType.BigInt);
            arparams[5].Value = objScheduleTemplate.ModifiedBy > 0 ? (object)objScheduleTemplate.ModifiedBy : DBNull.Value;

            arparams[6] = new SqlParameter("@isactive", SqlDbType.Bit);
            arparams[6].Value = objScheduleTemplate.IsActive;

            arparams[7] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arparams[7].Value = mode;

            arparams[8] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arparams[8].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_createscheduletemplate",
                arparams);
            returnvalue = Convert.ToInt64(arparams[8].Value);

            if (((mode == 0 && returnvalue > 0) || mode == 1 && returnvalue >= 0) && objScheduleTemplate.Global == false &&
                objScheduleTemplate.ScheduleTemplateFranchiseeAccess != null)
            {
                if (mode == 1)
                {
                    returnvalue = objScheduleTemplate.ScheduleTemplateID;
                }
                SaveScheduleTemplateFranchiseeAccess(objScheduleTemplate.ScheduleTemplateFranchiseeAccess,
                    Convert.ToInt32(returnvalue));
            }

            if (((mode == 0 && returnvalue > 0) || mode == 1 && returnvalue >= 0) &&
                objScheduleTemplate.ScheduleTemplateTime != null)
            {
                if (mode == 1)
                {
                    returnvalue = objScheduleTemplate.ScheduleTemplateID;
                }
                SaveScheduleTemplateTime(objScheduleTemplate.ScheduleTemplateTime, Convert.ToInt32(returnvalue));
            }

            return returnvalue;
        }

        /// <summary>
        /// Save EventScheduleTemplateFranchiseeAccess Info into the db
        /// </summary>
        /// <param name="lstScheduleTemplateFranchiseeAccess"></param>
        /// <returns></returns>
        public Int64 SaveScheduleTemplateFranchiseeAccess(
            List<EScheduleTemplateFranchiseeAccess> lstScheduleTemplateFranchiseeAccess, int scheduletemplateid)
        {
            var arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@scheduletemplateid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@mode", SqlDbType.TinyInt);

            for (int icount = 0; icount < lstScheduleTemplateFranchiseeAccess.Count; icount++)
            {
                arparams[0].Value = scheduletemplateid;
                arparams[1].Value = lstScheduleTemplateFranchiseeAccess[icount].FranchiseeID;
                arparams[2].Value = icount;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                    "usp_savescheduletemplatefranchiseeaccess", arparams);
            }
            return 0;
        }

        /// <summary>
        /// Save EventSchedule Template AppointmentTime
        /// </summary>
        /// <param name="lstScheduleTemplateTime"></param>
        /// <param name="scheduletemplateid"></param>
        /// <returns></returns>
        public Int64 SaveScheduleTemplateTime(List<EScheduleTemplateTime> lstScheduleTemplateTime,
            int scheduletemplateid)
        {
            var arparams = new SqlParameter[4];
            arparams[0] = new SqlParameter("@scheduletemplateid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@starttime", SqlDbType.VarChar, 10);
            arparams[2] = new SqlParameter("@appointmentcount", SqlDbType.TinyInt);
            arparams[3] = new SqlParameter("@mode", SqlDbType.TinyInt);

            for (int icount = 0; icount < lstScheduleTemplateTime.Count; icount++)
            {
                arparams[0].Value = scheduletemplateid;
                arparams[1].Value = lstScheduleTemplateTime[icount].StartTime;
                arparams[2].Value = lstScheduleTemplateTime[icount].AppointmentCount;
                arparams[3].Value = icount;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                    "usp_savescheduleappointmenttime", arparams);
            }
            return 0;
        }

        /// <summary>
        /// Get Schedule Template details for a particular templateid
        /// </summary>
        /// <param name="templateid"></param>
        /// <returns></returns>
        public EScheduleTemplate GetScheduleTemplateDetails(int templateid)
        {
            var arparam = new SqlParameter("@scheduletemplateid", SqlDbType.BigInt);
            arparam.Value = templateid;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getscheduletemplatedetailbyid", arparam);
            return ParseTemplateDetailDataset(dstemp);
        }

        /// <summary>
        /// Parses Dataset object from DB and fills the scheduletemplate entity object.
        /// </summary>
        /// <param name="dsscheduletemplate"></param>
        /// <returns></returns>
        private EScheduleTemplate ParseTemplateDetailDataset(DataSet dsscheduletemplate)
        {
            var objscheduletemplate = new EScheduleTemplate();
            if (dsscheduletemplate == null)
            {
                return objscheduletemplate;
            }

            DataTable dtscheduletemplate = dsscheduletemplate.Tables[0];
            DataTable dtscheduletemplatefranchiseeaccess = dsscheduletemplate.Tables[1];
            DataTable dtscheduletemplatetime = dsscheduletemplate.Tables[2];

            if (dtscheduletemplate.Rows.Count < 1)
            {
                return objscheduletemplate;
            }

            objscheduletemplate.ScheduleTemplateID = Convert.ToInt32(dtscheduletemplate.Rows[0]["ScheduleTemplateID"]);
            objscheduletemplate.Name = Convert.ToString(dtscheduletemplate.Rows[0]["Name"]);
            objscheduletemplate.Global = Convert.ToBoolean(dtscheduletemplate.Rows[0]["IsGlobal"]);
            objscheduletemplate.IsActive = Convert.ToBoolean(dtscheduletemplate.Rows[0]["IsActive"]);
            objscheduletemplate.Description = Convert.ToString(dtscheduletemplate.Rows[0]["Description"]);
            objscheduletemplate.CreateBy = Convert.ToInt32(dtscheduletemplate.Rows[0]["CreatedBy"]);
            objscheduletemplate.CreatedByRole = Convert.ToBoolean(dtscheduletemplate.Rows[0]["CreatedByRole"]);
            objscheduletemplate.ModifiedBy = Convert.ToInt32(dtscheduletemplate.Rows[0]["ModifiedBy"]);
            objscheduletemplate.ModifiedByRole = Convert.ToBoolean(dtscheduletemplate.Rows[0]["ModifiedByRole"]);

            var lsttemplatefranchiseeaccess = new List<EScheduleTemplateFranchiseeAccess>();
            foreach (DataRow dr in dtscheduletemplatefranchiseeaccess.Rows)
            {
                var objtemplatefranchiseeaccess = new EScheduleTemplateFranchiseeAccess();
                objtemplatefranchiseeaccess.FranchiseeID = Convert.ToInt32(dr["FranchiseeID"]);
                objtemplatefranchiseeaccess.ScheduleTemplateID = Convert.ToInt32(dr["ScheduleTemplateID"]);
                objtemplatefranchiseeaccess.ScheduleTemplateFranchiseeAccessID =
                    Convert.ToInt32(dr["ScheduleTemplateFranchiseeAccessID"]);
                objtemplatefranchiseeaccess.IsActive = Convert.ToBoolean(dr["IsActive"]);
                lsttemplatefranchiseeaccess.Add(objtemplatefranchiseeaccess);
            }
            objscheduletemplate.ScheduleTemplateFranchiseeAccess = lsttemplatefranchiseeaccess;

            var lstScheduletemplatetime = new List<EScheduleTemplateTime>();
            foreach (DataRow dr in dtscheduletemplatetime.Rows)
            {
                var objscheduletemplatetime = new EScheduleTemplateTime();
                objscheduletemplatetime.ScheduleTemplateID = Convert.ToInt32(dr["ScheduleTemplateID"]);
                objscheduletemplatetime.StartTime = Convert.ToString(dr["StartTime"]);
                objscheduletemplatetime.ScheduleTemplateTimeID = Convert.ToInt32(dr["ScheduleTemplateTimeID"]);
                lstScheduletemplatetime.Add(objscheduletemplatetime);
            }
            objscheduletemplate.ScheduleTemplateTime = lstScheduletemplatetime;

            return objscheduletemplate;
        }

        public Int64 ActiveSeminar(long eventId, long seminarId, int mode)
        {
            var arparams = new SqlParameter[4];

            arparams[0] = new SqlParameter("@eventID", SqlDbType.BigInt);
            arparams[0].Value = eventId;

            arparams[1] = new SqlParameter("@seminarid", SqlDbType.BigInt);
            arparams[1].Value = seminarId;

            arparams[2] = new SqlParameter("@mode", SqlDbType.Int);
            arparams[2].Value = mode;

            arparams[3] = new SqlParameter("@returnvalue", SqlDbType.SmallInt);
            arparams[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_ActiveSeminar", arparams);
            return Convert.ToInt16(arparams[3].Value);
        }

        public Int64 DeleteSeminar(long eventId, long seminarId)
        {
            var arparams = new SqlParameter[3];

            arparams[0] = new SqlParameter("@eventID", SqlDbType.BigInt);
            arparams[0].Value = eventId;

            arparams[1] = new SqlParameter("@seminarid", SqlDbType.BigInt);
            arparams[1].Value = seminarId;

            arparams[2] = new SqlParameter("@returnvalue", SqlDbType.SmallInt);
            arparams[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_deleteseminar", arparams);
            return Convert.ToInt16(arparams[2].Value);
        }

        public string GetMaxSourceCodeSeminar(int eventID)
        {
            var arparams = new SqlParameter[2];

            arparams[0] = new SqlParameter("@eventID", SqlDbType.BigInt);
            arparams[0].Value = eventID;

            arparams[1] = new SqlParameter("@sourceCode", SqlDbType.VarChar, 100);
            arparams[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_getMaxSourceCodeSeminar",
                arparams);
            return Convert.ToString(arparams[1].Value);
        }

        public Int64 SaveEventPublications(List<EEventLocalPublications> lstEventPublications, int eventid)
        {
            Int64 returnvalue = 0;
            var arparams = new SqlParameter[8];

            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@eventpublicationid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@publicationname", SqlDbType.VarChar, 500);
            arparams[3] = new SqlParameter("@contactname", SqlDbType.VarChar, 500);
            arparams[4] = new SqlParameter("@description", SqlDbType.VarChar, 500);
            arparams[5] = new SqlParameter("@contactinfo", SqlDbType.VarChar, 500);
            arparams[6] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arparams[7] = new SqlParameter("@mode", SqlDbType.TinyInt);
            int icount = 0;

            foreach (EEventLocalPublications objEventPublications in lstEventPublications)
            {
                arparams[0].Value = eventid;
                arparams[1].Value = objEventPublications.EventPublicationID;
                arparams[2].Value = objEventPublications.PublicationName;

                if (objEventPublications.ContactName == null || objEventPublications.ContactName.Trim().Length < 1)
                {
                    arparams[3].Value = DBNull.Value;
                }
                else
                {
                    arparams[3].Value = objEventPublications.ContactName;
                }

                if (objEventPublications.Description == null || objEventPublications.Description.Trim().Length < 1)
                {
                    arparams[4].Value = DBNull.Value;
                }
                else
                {
                    arparams[4].Value = objEventPublications.Description;
                }

                if (objEventPublications.ContactInfo == null || objEventPublications.ContactInfo.Trim().Length < 1)
                {
                    arparams[5].Value = DBNull.Value;
                }
                else
                {
                    arparams[5].Value = objEventPublications.ContactInfo;
                }

                arparams[6].Direction = ParameterDirection.Output;
                arparams[7].Value = icount;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventpublication",
                    arparams);
                returnvalue = Convert.ToInt32(arparams[6].Value);
                icount++;
            }
            return returnvalue;
        }

        public Int64 SaveEventHostPromotions(EEventHostPromotion objHostPromotion, int eventid, int promotiontype)
        {
            var arparams = new SqlParameter[25];
            arparams[0] = new SqlParameter("@promotionid", SqlDbType.BigInt);
            arparams[0].Value = objHostPromotion.EventPromotionID;
            arparams[1] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[1].Value = eventid;
            arparams[28] = new SqlParameter("@TotalPosters", SqlDbType.BigInt);
            arparams[28].Value = objHostPromotion.TotalPosters;
            arparams[2] = new SqlParameter("@bHostAllowPostersAndFlyers", SqlDbType.Bit);
            arparams[2].Value = objHostPromotion.HostAllowPostersandFlyers;
            arparams[3] = new SqlParameter("@TotalHostPosters", SqlDbType.BigInt);
            arparams[3].Value = objHostPromotion.TotalHostPosters;
            arparams[4] = new SqlParameter("@TotalRepPosters", SqlDbType.BigInt);
            arparams[4].Value = objHostPromotion.TotalRepPosters;
            arparams[5] = new SqlParameter("@bPosterPlacementDiscussedWithHost", SqlDbType.Bit);
            arparams[5].Value = objHostPromotion.PosterPlacementDiscussedwithHost;
            arparams[6] = new SqlParameter("@bHostWillPostAnnouncement", SqlDbType.Bit);
            arparams[6].Value = objHostPromotion.HostWillPostAnnouncement;

            arparams[7] = new SqlParameter("@bAnnouncementStartDate", SqlDbType.VarChar, 500);
            if (objHostPromotion.AnnouncementStartDate == null ||
                objHostPromotion.AnnouncementStartDate.Trim().Length < 1)
            {
                arparams[7].Value = DBNull.Value;
            }
            else
            {
                arparams[7].Value = objHostPromotion.AnnouncementStartDate;
            }

            arparams[8] = new SqlParameter("@bAnnouncemcentEndDate", SqlDbType.VarChar, 500);
            if (objHostPromotion.AnnouncementEndDate == null || objHostPromotion.AnnouncementEndDate.Trim().Length < 1)
            {
                arparams[8].Value = DBNull.Value;
            }
            else
            {
                arparams[8].Value = objHostPromotion.AnnouncementEndDate;
            }

            arparams[9] = new SqlParameter("@bHostAllowBulletinInserts", SqlDbType.Bit);
            arparams[9].Value = objHostPromotion.HostAllowBulletinInserts;

            arparams[10] = new SqlParameter("@bInsertDate1", SqlDbType.VarChar, 500);
            if (objHostPromotion.InsertDate1 == null || objHostPromotion.InsertDate1.Trim().Length < 1)
            {
                arparams[10].Value = DBNull.Value;
            }
            else
            {
                arparams[10].Value = objHostPromotion.InsertDate1;
            }

            arparams[11] = new SqlParameter("@bInsertDate2", SqlDbType.VarChar, 500);
            if (objHostPromotion.InsertDate2 == null || objHostPromotion.InsertDate2.Trim().Length < 1)
            {
                arparams[11].Value = DBNull.Value;
            }
            else
            {
                arparams[11].Value = objHostPromotion.InsertDate2;
            }

            arparams[12] = new SqlParameter("@NumberofInserts", SqlDbType.BigInt);
            arparams[12].Value = objHostPromotion.NumberOfInserts;

            arparams[13] = new SqlParameter("@bHostAllowVerbalAnnnouncements", SqlDbType.Bit);
            arparams[13].Value = objHostPromotion.HostAllowVerbalAnnouncements;
            arparams[14] = new SqlParameter("@bVerbalAnnouncementByRepresentative", SqlDbType.Bit);
            arparams[14].Value = objHostPromotion.VerbalAnnouncementbyRepresentative;
            arparams[15] = new SqlParameter("@bVerbalAnnouncementBySalesRep", SqlDbType.Bit);
            arparams[15].Value = objHostPromotion.VerbalAnnouncementbySalesRep;
            arparams[16] = new SqlParameter("@VerbalAnnouncementBySalesRepDate", SqlDbType.VarChar, 500);
            if (objHostPromotion.VerbalAnnouncementbySalesRepDate == null ||
                objHostPromotion.VerbalAnnouncementbySalesRepDate.Trim().Length < 1)
            {
                arparams[16].Value = DBNull.Value;
            }
            else
            {
                arparams[16].Value = objHostPromotion.VerbalAnnouncementbySalesRepDate;
            }

            arparams[17] = new SqlParameter("@bHostAllowsDirectMailsToMembers", SqlDbType.Bit);
            arparams[17].Value = objHostPromotion.HostAllowDirectMailtoMembers;
            arparams[18] = new SqlParameter("@bProvidedWithMailingInformation", SqlDbType.Bit);
            arparams[18].Value = objHostPromotion.ProvidedwithMailingInformation;
            arparams[19] = new SqlParameter("@DirectMailingListArrivalDate", SqlDbType.VarChar, 500);
            if (objHostPromotion.DirectMailingListArrivalDate == null ||
                objHostPromotion.DirectMailingListArrivalDate.Trim().Length < 1)
            {
                arparams[19].Value = DBNull.Value;
            }
            else
            {
                arparams[19].Value = objHostPromotion.DirectMailingListArrivalDate;
            }

            arparams[20] = new SqlParameter("@bHostAllowEmailingtheMembersOfTheOrganisation", SqlDbType.Bit);
            arparams[20].Value = objHostPromotion.HostAllowMailingtheMembersofOrganisation;
            arparams[21] = new SqlParameter("@DateEmailsProvided", SqlDbType.VarChar, 500);
            if (objHostPromotion.DateEmailsProvided == null || objHostPromotion.DateEmailsProvided.Trim().Length < 1)
            {
                arparams[21].Value = DBNull.Value;
            }
            else
            {
                arparams[21].Value = objHostPromotion.DateEmailsProvided;
            }

            arparams[22] = new SqlParameter("@isactive", SqlDbType.Bit);
            arparams[22].Value = objHostPromotion.IsActive;
            arparams[23] = new SqlParameter("@promotiontype", SqlDbType.Bit);
            arparams[23].Value = objHostPromotion.StandardPromotion;

            arparams[24] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arparams[24].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveeventhostpromotion",
                arparams);
            return Convert.ToInt32(arparams[24].Value);
        }

        /// <summary>
        /// Fetches Event Marketing Detail corresponding to the eventid
        /// </summary>
        /// <param name="eventid"></param>
        /// <returns></returns>
        public EEventHostPromotion GetEventPromotion(int eventid)
        {
            var arparam = new SqlParameter("@eventID", SqlDbType.BigInt);
            arparam.Value = eventid;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getEventPromotionbyEvent", arparam);

            var objhostpromotion = new EEventHostPromotion();
            if (dstemp != null)
            {
                if (dstemp.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dstemp.Tables[0].Rows[0];

                    objhostpromotion.EventPromotionID = Convert.ToInt32(dr["EventPromotionID"]);
                    objhostpromotion.AnnouncementStartDate = Convert.ToString(dr["bAnnouncementStartDate"]);
                    objhostpromotion.AnnouncementEndDate = Convert.ToString(dr["bAnnouncemcentEndDate"]);
                    objhostpromotion.DateEmailsProvided = Convert.ToString(dr["DateEmailsProvided"]);
                    objhostpromotion.DirectMailingListArrivalDate = Convert.ToString(dr["DirectMailingListArrivalDate"]);
                    objhostpromotion.HostAllowBulletinInserts = Convert.ToBoolean(dr["bHostAllowBulletinInserts"]);
                    objhostpromotion.HostAllowDirectMailtoMembers =
                        Convert.ToBoolean(dr["bHostAllowsDirectMailsToMembers"]);
                    objhostpromotion.HostAllowMailingtheMembersofOrganisation =
                        Convert.ToBoolean(dr["bHostAllowEmailingtheMembersOfTheOrganisation"]);
                    objhostpromotion.HostAllowPostersandFlyers = Convert.ToBoolean(dr["bHostAllowPostersAndFlyers"]);
                    objhostpromotion.HostAllowVerbalAnnouncements =
                        Convert.ToBoolean(dr["bHostAllowVerbalAnnnouncements"]);
                    objhostpromotion.HostWillPostAnnouncement = Convert.ToBoolean(dr["bHostWillPostAnnouncement"]);
                    objhostpromotion.InsertDate1 = Convert.ToString(dr["bInsertDate1"]);
                    objhostpromotion.InsertDate2 = Convert.ToString(dr["bInsertDate2"]);
                    objhostpromotion.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objhostpromotion.NumberOfInserts = Convert.ToInt32(dr["NumberofInserts"]);
                    objhostpromotion.PosterPlacementDiscussedwithHost =
                        Convert.ToBoolean(dr["bPosterPlacementDiscussedWithHost"]);
                    objhostpromotion.ProvidedwithMailingInformation =
                        Convert.ToBoolean(dr["bProvidedWithMailingInformation"]);
                    objhostpromotion.TotalRepPosters = Convert.ToInt32(dr["TotalRepPosters"]);
                    objhostpromotion.TotalHostPosters = Convert.ToInt32(dr["TotalHostPosters"]);
                    objhostpromotion.TotalPosters = Convert.ToInt32(dr["TotalPosters"]);
                    objhostpromotion.VerbalAnnouncementbyRepresentative =
                        Convert.ToBoolean(dr["bVerbalAnnouncementByRepresentative"]);
                    objhostpromotion.VerbalAnnouncementbySalesRep =
                        Convert.ToBoolean(dr["bVerbalAnnouncementBySalesRep"]);
                    objhostpromotion.VerbalAnnouncementbySalesRepDate =
                        Convert.ToString(dr["VerbalAnnouncementBySalesRepDate"]);
                }
            }
            return objhostpromotion;
        }

        public List<EEvent> GetFranchisorHost(string filterstring, int mode)
        {
            var arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterstring;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getfranchisorhostdetails", arParms);

            var returnFranchisorHostDetails = new List<EEvent>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                var objHostDetails = new EEvent();
                var objProspectDetails = new EProspect();
                var objFranchisee = new EFranchisee();
                objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectID"]);
                objProspectDetails.OrganizationName = dr["OrganizationName"].ToString();
                objProspectDetails.FollowDate = Convert.ToDateTime(dr["DateCreated"]).ToShortDateString();
                if (dr["ActualMembersHIP"] != DBNull.Value)
                {
                    objProspectDetails.ActualMembership = Convert.ToDecimal(dr["ActualMembersHIP"]);
                }
                else
                {
                    objProspectDetails.ActualMembership = 0;
                }
                objFranchisee.Name = dr["Franchisee"].ToString();
                objHostDetails.SlotCount = Convert.ToInt32(dr["EventCount"]);
                objHostDetails.EventDate = Convert.ToDateTime(dr["EventDate"]).ToLongDateString();
                objHostDetails.AttendedCustomersCount = Convert.ToInt32(dr["CustomersPresent"].ToString());
                objHostDetails.Name = dr["EventName"].ToString();
                objHostDetails.Prospect = objProspectDetails;
                objHostDetails.Franchisee = objFranchisee;

                returnFranchisorHostDetails.Add(objHostDetails);
            }

            return returnFranchisorHostDetails;
        }

        /// <summary>
        /// updates google uri in event table
        /// </summary>
        /// <param name="bolpass"></param>
        /// <param name="uri"></param>
        /// <param name="eventid"></param>
        public void UpdateGoogleEventUri(bool bolpass, string uri, int eventid)
        {
            var arparam = new SqlParameter("@googleuri", SqlDbType.VarChar, 1000);
            if (bolpass)
            {
                arparam.Value = uri;
            }
            else
            {
                arparam.Value = DBNull.Value;
            }

            string sqlquery = "Update TblEvents set GoogleUri = @googleuri where eventid = " + eventid;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery, arparam);
        }

        public List<EEventCustomer> GetCouponDetailByEventCustomerID(int eventcustomeridID)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt64(eventcustomeridID);

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getcoupondetailbyeventcustomerid", arParms);
            var objListEvent = new List<EEventCustomer>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                var objevent = new EEventCustomer();
                objevent.Coupon = new ECoupon();
                objevent.Coupon.CouponID = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["SourceCodeID"]);
                objListEvent.Add(objevent);
            }
            return objListEvent;
        }

        public List<EEventCustomer> GetPackageDetailByEventCustomerID(int eventcustomeridID)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt64(eventcustomeridID);

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getpackagedetailbyeventcustomerid", arParms);
            var objListEvent = new List<EEventCustomer>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                var objevent = new EEventCustomer();
                objevent.EventPackage = new EEventPackage();
                objevent.EventPackage.PackagePrice = Convert.ToSingle(tempdataset.Tables[0].Rows[0]["PackagePrice"]);
                objevent.EventPackage.EventID = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["EventID"]);
                objListEvent.Add(objevent);
            }
            return objListEvent;
        }

        public Int64 UpdateOnSitePaymentInfo(EEventCustomer customer, Int64 RoleShellID, Int64 RoleID)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = customer.EventID;
            arParms[1] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arParms[1].Value = customer.CustomerEventTestID;


            arParms[2] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 50);
            arParms[2].Value = customer.PaymentDetail.PaymentType.Name;
            arParms[3] = new SqlParameter("@couponcost", SqlDbType.Float);
            arParms[3].Value = customer.Coupon.CouponAmount;

            arParms[4] = new SqlParameter("@couponid", SqlDbType.BigInt);
            arParms[4].Value = customer.Coupon.CouponID;
            arParms[5] = new SqlParameter("@netpayment", SqlDbType.Float);
            arParms[5].Value = customer.PaymentDetail.Amount;
            arParms[6] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[6].Direction = ParameterDirection.Output;

            arParms[7] = new SqlParameter("@roleshellid", SqlDbType.BigInt);
            arParms[7].Value = RoleShellID;

            arParms[8] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[8].Value = RoleID;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_updateonsitepaymentinfo",
                arParms);
            returnvalue = (Int64)arParms[6].Value;


            return returnvalue;
        }

        public EEvent GetCustomerList(int customerid, string customername, string cityname, string statename,
            string zipcode, string fromdate, string todate, int franchiseeid, int DateType,
            Int16 mode, int pageNo, int pageSize, out long pageCount)
        {
            var arparams = new SqlParameter[13];

            arparams[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            if (customerid > 0)
                arparams[0].Value = customerid;
            else
            {
                arparams[0].Value = DBNull.Value;
            }

            arparams[1] = new SqlParameter("@customername", SqlDbType.VarChar, 200);
            if (customername.Trim().Length < 1)
            {
                arparams[1].Value = DBNull.Value;
            }
            else
            {
                arparams[1].Value = customername.Replace("'", "''");
            }

            arparams[2] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (statename.Trim().Length < 1)
            {
                arparams[2].Value = DBNull.Value;
            }
            else
            {
                arparams[2].Value = statename;
            }

            arparams[3] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (cityname.Trim().Length < 1)
            {
                arparams[3].Value = DBNull.Value;
            }
            else
            {
                arparams[3].Value = cityname;
            }

            arparams[4] = new SqlParameter("@zipcode", SqlDbType.VarChar, 100);
            if (zipcode.Trim().Length < 1)
            {
                arparams[4].Value = DBNull.Value;
            }
            else
            {
                arparams[4].Value = zipcode;
            }

            arparams[5] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            if (fromdate.Trim().Length < 1)
            {
                arparams[5].Value = DBNull.Value;
            }
            else
            {
                arparams[5].Value = fromdate;
            }


            arparams[6] = new SqlParameter("@todate", SqlDbType.DateTime);
            if (todate.Trim().Length < 1)
            {
                arparams[6].Value = DBNull.Value;
            }
            else
            {
                arparams[6].Value = todate;
            }


            arparams[7] = new SqlParameter("@franchiseeid", SqlDbType.Int);
            arparams[7].Value = franchiseeid;

            arparams[8] = new SqlParameter("@datetype", SqlDbType.BigInt);
            arparams[8].Value = DateType;

            arparams[9] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[9].Value = mode;

            arparams[10] = new SqlParameter("@PageNo", SqlDbType.Int);
            arparams[10].Value = pageNo;

            arparams[11] = new SqlParameter("@PageSize", SqlDbType.Int);
            arparams[11].Value = pageSize;

            arparams[12] = new SqlParameter("@PageCount", SqlDbType.BigInt);
            arparams[12].Direction = ParameterDirection.Output;

            pageCount = Convert.ToInt64(arparams[12].Value);

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getnewcustomerlist", arparams);

            var listeventcustomer = new EEvent();
            var listcustomer = new List<EEventCustomer>();

            if (tempdataset.Tables[0].Rows.Count > 0 && tempdataset.Tables.Count >= 2)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    var objevent = new EEventCustomer();
                    objevent.Customer = new ECustomers();
                    objevent.Customer.User = new EUser();
                    objevent.EventPackage = new EEventPackage();
                    objevent.EventPackage.Package = new EPackage();
                    objevent.Customer.User.HomeAddress = new EAddress();
                    objevent.PaymentDetail = new EPaymentDetail();
                    objevent.EventAppointment = new EEventAppointment();
                    //////////////for using franchisee id,technician id attribute of eventcustomer entity is used/////
                    objevent.TechnicianID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["FranchiseeID"]);
                    objevent.Customer.CustomerID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["CustomerID"]);
                    //////////////for using event name,collectionmode attribute of customer entity is used/////
                    objevent.Customer.CollectionMode = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventName"]);
                    ////////for using eventid user id attribute of uer entity is used
                    objevent.Customer.User.UserID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["EventID"]);
                    objevent.Customer.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["FirstName"]);
                    objevent.Customer.User.MiddleName =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["MiddleName"]);
                    // added event status
                    objevent.EventStatus = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["EventStatus"]);
                    //// added salesrep column
                    //if (tempdataset.Tables[0].Rows[icount]["SalesRepID"] != DBNull.Value)
                    //{
                    //    if (Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["SalesRepID"]) > 0)
                    //    {
                    //        objevent.SalesRep = Convert.ToString(tempdataset.Tables[0].Rows[icount]["SalesRep"]);
                    //    }
                    //}

                    if (tempdataset.Tables[0].Rows[icount]["DateCreated"] != DBNull.Value ||
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["DateCreated"]).Length > 0)
                    {
                        objevent.Customer.User.DateApplied =
                            Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["DateCreated"]);
                    }
                    objevent.Customer.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["LastName"]);
                    objevent.Customer.User.HomeAddress.AddressID =
                        Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["HomeAddressID"]);
                    objevent.Customer.User.EMail1 = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EMail1"]);
                    objevent.Customer.User.PhoneOffice = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Phone"]);
                    objevent.EventPackage.Package.PackageName =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["PackageName"]);
                    objevent.AdditionalTest =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["AdditionalTest"]);
                    objevent.PaymentDetail.Amount = Convert.ToSingle(tempdataset.Tables[0].Rows[icount]["PaymentNet"]);
                    //////////////for using host name,ContactMethod attribute of customer entity is used/////
                    objevent.Customer.ContactMethod =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["OrganizationName"]);
                    //////////////for using marketing detail ,Gender attribute of customer entity is used/////
                    objevent.Customer.Gender =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["TrackingMarketingID"]);

                    objevent.Customer.RequestForNewsLetter =
                        Convert.ToBoolean(tempdataset.Tables[0].Rows[icount]["RequestNewsLetter"]);

                    //////////////for using eventdate,DOB attribute of User entity is used/////
                    //TODO added eventdate datafield to entity
                    if (tempdataset.Tables[0].Rows[icount]["EventDate"] != DBNull.Value ||
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventDate"]).Length > 0)
                    {
                        objevent.Customer.User.DOB =
                            Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["EventDate"]).ToLongDateString();
                        objevent.EventDate =
                            Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["EventDate"]).ToLongDateString();
                    }
                    objevent.Customer.AddedBy = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["RoleID"]);
                    ////for using DOB,Height attribute of Customer entity is used/////
                    if (tempdataset.Tables[0].Rows[icount]["DOB"] != DBNull.Value)
                    {
                        objevent.Customer.Height = Convert.ToString(tempdataset.Tables[0].Rows[icount]["DOB"]);
                    }
                    ////for using Gender,LastLogged attribute of Customer entity is used/////
                    objevent.Customer.LastLogged = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Gender"]);

                    objevent.Customer.BillingAddress = new EAddress();

                    string addressId = Convert.ToString(tempdataset.Tables[0].Rows[icount]["HomeAddressID"]);

                    if (tempdataset.Tables[0].Rows[icount]["HomeAddressID"] != DBNull.Value)
                    // address should be present with valid address id
                    {
                        DataRow drAddress = tempdataset.Tables[1].Select("AddressID=" + addressId)[0];
                        objevent.Customer.BillingAddress.AddressID = Convert.ToInt32(drAddress["AddressID"]);
                        objevent.Customer.BillingAddress.Address1 = drAddress["Address1"].ToString();
                        objevent.Customer.BillingAddress.ZipID = Convert.ToInt32(drAddress["ZIPID"]);
                        objevent.Customer.BillingAddress.Zip = Convert.ToString(drAddress["ZipCode"]);
                        objevent.Customer.BillingAddress.CountryID = Convert.ToInt32(drAddress["CountryID"]);
                        objevent.Customer.BillingAddress.StateID = Convert.ToInt32(drAddress["StateID"]);
                        objevent.Customer.BillingAddress.CityID = Convert.ToInt32(drAddress["CityID"]);
                        objevent.Customer.BillingAddress.City = drAddress["CityName"].ToString();
                        objevent.Customer.BillingAddress.State = drAddress["StateName"].ToString();
                        objevent.Customer.BillingAddress.Country = drAddress["CountryName"].ToString();
                    }

                    //used for Incoming Pohe line
                    objevent.Customer.User.HomeAddress.PhoneNumber =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["IncomingPhoneLine"]);
                    //used for Callers Phone Number
                    objevent.Customer.User.PhoneCell =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["CallersPhoneNumber"]);
                    objevent.Customer.User.Login = new ELogin();
                    objevent.Customer.User.Login.Locked =
                        Convert.ToBoolean(tempdataset.Tables[0].Rows[icount]["IsLocked"]);

                    objevent.Customer.DoNotContactReasonId = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["DoNotContactReasonId"]);
                    objevent.Customer.LastScreeningDate = "";

                    listcustomer.Add(objevent);
                }
            }
            if (tempdataset.Tables.Count >= 3)
            {
                if (tempdataset.Tables[2].Rows.Count >= 1)
                {
                    listeventcustomer.TotalRecord = Convert.ToInt64(tempdataset.Tables[2].Rows[0]["TotalRecords"]);
                    pageCount = Convert.ToInt64(tempdataset.Tables[2].Rows[0]["TotalRecords"]);
                }
            }


            // listeventcustomer[0] = new EEvent();
            listeventcustomer.Customer = listcustomer;
            return listeventcustomer;
        }

        public EEvent GetTechnicianCustomerList(string FirstName, string LastName, string zipcode, string customerid, string eventId,
            string datefrom, string dateto, int mode, int pageSize, int pageNumber, out long totalRecords, string phoneNumber, string email, string HICN, string MemberId, string dob,
            long organizationId,string mbi)
        {
            var arparams = new SqlParameter[17];

            arparams[0] = new SqlParameter("@FirstName", SqlDbType.VarChar, 100);
            if (FirstName.Trim().Length < 1)
            {
                arparams[0].Value = DBNull.Value;
            }
            else
            {
                arparams[0].Value = FirstName;
            }

            arparams[1] = new SqlParameter("@LastName", SqlDbType.VarChar, 100);
            if (LastName.Trim().Length < 1)
            {
                arparams[1].Value = DBNull.Value;
            }
            else
            {
                arparams[1].Value = LastName;
            }

            arparams[2] = new SqlParameter("@zipcode", SqlDbType.VarChar, 100);
            if (zipcode.Trim().Length < 1)
            {
                arparams[2].Value = DBNull.Value;
            }
            else
            {
                arparams[2].Value = zipcode;
            }

            arparams[3] = new SqlParameter("@customerid", SqlDbType.BigInt);
            if (customerid.Trim().Length < 1)
            {
                arparams[3].Value = DBNull.Value;
            }
            else
            {
                arparams[3].Value = customerid;
            }

            arparams[4] = new SqlParameter("@datefrom", SqlDbType.VarChar, 50);
            if (datefrom.Trim().Length < 1)
            {
                arparams[4].Value = DBNull.Value;
            }
            else
            {
                arparams[4].Value = datefrom;
            }

            arparams[5] = new SqlParameter("@dateto", SqlDbType.VarChar, 50);
            if (dateto.Trim().Length < 1)
            {
                arparams[5].Value = DBNull.Value;
            }
            else
            {
                arparams[5].Value = dateto;
            }

            arparams[6] = new SqlParameter("@mode", SqlDbType.Int);
            arparams[6].Value = mode;

            arparams[7] = new SqlParameter("@eventId", SqlDbType.VarChar, 50);
            if (eventId.Trim().Length < 1)
            {
                arparams[7].Value = DBNull.Value;
            }
            else
            {
                arparams[7].Value = eventId;
            }

            arparams[8] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arparams[8].Value = pageNumber;

            arparams[9] = new SqlParameter("@PageSize", SqlDbType.Int);
            arparams[9].Value = pageSize;

            arparams[10] = new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 12);
            if (phoneNumber.Length > 0)
                arparams[10].Value = phoneNumber;
            else
                arparams[10].Value = DBNull.Value;

            arparams[11] = new SqlParameter("@Email", SqlDbType.VarChar, 100);
            if (email.Length > 0)
                arparams[11].Value = email;
            else
                arparams[11].Value = DBNull.Value;

            arparams[12] = new SqlParameter("@HICN", SqlDbType.VarChar, 100);
            if (HICN.Length > 0)
                arparams[12].Value = HICN;
            else
                arparams[12].Value = DBNull.Value;

            arparams[13] = new SqlParameter("@MemberId", SqlDbType.VarChar, 100);
            if (MemberId.Length > 0)
                arparams[13].Value = MemberId;
            else
                arparams[13].Value = DBNull.Value;

            arparams[14] = new SqlParameter("@dob", SqlDbType.VarChar, 50);
            if (dob.Trim().Length < 1)
            {
                arparams[14].Value = DBNull.Value;
            }
            else
            {
                arparams[14].Value = dob;
            }

            arparams[15] = new SqlParameter("@OrganizationId", SqlDbType.BigInt);
            arparams[15].Value = organizationId;

            arparams[16] = new SqlParameter("@Mbi", SqlDbType.VarChar, 100);
            if (mbi.Length > 0)
                arparams[16].Value = mbi;
            else
                arparams[16].Value = DBNull.Value;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getTechnicianCustomerlist", arparams);
            var listeventcustomer = new EEvent();
            var listcustomer = new List<EEventCustomer>();

            totalRecords = 0;
            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    var objevent = new EEventCustomer();
                    objevent.Customer = new ECustomers();
                    objevent.Customer.User = new EUser();
                    objevent.EventPackage = new EEventPackage();
                    objevent.EventPackage.Package = new EPackage();
                    objevent.Customer.User.HomeAddress = new EAddress();
                    objevent.PaymentDetail = new EPaymentDetail();
                    objevent.EventAppointment = new EEventAppointment();
                    //objevent.Customer.BillingAddress = new EAddress();
                    objevent.Customer.CustomerID = Convert.ToInt64(tempdataset.Tables[0].Rows[icount]["CustomerID"]);
                    objevent.Customer.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["FirstName"]);
                    objevent.Customer.User.MiddleName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["MiddleName"]);
                    objevent.Customer.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["LastName"]);
                    if (tempdataset.Tables[0].Rows[icount]["DateCreated"] != DBNull.Value ||
                       Convert.ToString(tempdataset.Tables[0].Rows[icount]["DateCreated"]).Length > 0)
                    {
                        objevent.Customer.User.DateApplied =
                            Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["DateCreated"]);
                    }
                    objevent.Customer.LastLogged = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Gender"]);
                    objevent.Customer.AddedBy = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["RoleID"]);
                    ////for using DOB,Height attribute of Customer entity is used/////
                    objevent.Customer.Height = Convert.ToString(tempdataset.Tables[0].Rows[icount]["DOB"]);
                    objevent.Customer.User.EMail1 = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EMail1"]);
                    objevent.Customer.User.HomeAddress.AddressID = Convert.ToInt64(tempdataset.Tables[0].Rows[icount]["HomeAddressID"]);
                    objevent.Customer.User.PhoneOffice = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Phone"]);
                    objevent.Customer.Gender = Convert.ToString(tempdataset.Tables[0].Rows[icount]["TrackingMarketingID"]);


                    //////////////for using franchisee id,technician id attribute of eventcustomer entity is used/////
                    objevent.TechnicianID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["FranchiseeID"]);
                    //////////////for using event name,collectionmode attribute of customer entity is used/////
                    objevent.Customer.CollectionMode = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventName"]);
                    ////////for using eventid user id attribute of uer entity is used
                    objevent.Customer.User.UserID = Convert.ToInt64(tempdataset.Tables[0].Rows[icount]["EventID"]);


                    objevent.EventPackage.Package.PackageName =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["PackageName"]);
                    objevent.AdditionalTest = Convert.ToString(tempdataset.Tables[0].Rows[icount]["AdditionalTest"]);

                    if (tempdataset.Tables[0].Rows[icount]["PaymentNet"] == DBNull.Value)
                    {
                        continue;
                    }
                    objevent.PaymentDetail.Amount = Convert.ToSingle(tempdataset.Tables[0].Rows[icount]["PaymentNet"]);
                    //////////////for using host name,ContactMethod attribute of customer entity is used/////
                    objevent.Customer.ContactMethod =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["OrganizationName"]);
                    //////////////for using marketing detail ,Gender attribute of customer entity is used/////

                    //////////////for using eventdate,DOB attribute of User entity is used/////
                    if (tempdataset.Tables[0].Rows[icount]["EventDate"] != DBNull.Value ||
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventDate"]).Length > 0)
                    {
                        objevent.Customer.User.DOB =
                            Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["EventDate"]).ToLongDateString();
                    }

                    ////for using Gender,LastLogged attribute of Customer entity is used/////


                    objevent.Customer.BillingAddress = new EAddress();

                    string addressId = Convert.ToString(tempdataset.Tables[0].Rows[icount]["HomeAddressID"]);

                    if (!string.IsNullOrEmpty(addressId))
                    {
                        objevent.Customer.BillingAddress.AddressID = Convert.ToInt64(addressId);
                    }

                    //if (tempdataset.Tables[0].Rows[icount]["HomeAddressID"] != DBNull.Value)
                    //// address should be present with valid address id
                    //{
                    //    var addressParameter = new SqlParameter[2];

                    //    addressParameter[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
                    //    addressParameter[0].Value = 0;
                    //    addressParameter[1] = new SqlParameter("@filterstring", SqlDbType.VarChar, 20);
                    //    addressParameter[1].Value = Convert.ToString(tempdataset.Tables[0].Rows[icount]["HomeAddressID"]);

                    //    var addressDataSet = SqlHelper.ExecuteDataset(_connectionString, "usp_getaddressbyid", addressParameter);
                    //    //DataRow drAddress = tempdataset.Tables[0].Select("AddressID=" + addressId)[0];
                    //    DataRow drAddress = addressDataSet.Tables[0].Rows[0];

                    //    objevent.Customer.BillingAddress.AddressID = Convert.ToInt32(drAddress["AddressID"]);
                    //    objevent.Customer.BillingAddress.Address1 = drAddress["Address1"].ToString();
                    //    objevent.Customer.BillingAddress.Address2 = drAddress["Address2"].ToString();
                    //    objevent.Customer.BillingAddress.ZipID = Convert.ToInt32(drAddress["ZIPID"]);
                    //    objevent.Customer.BillingAddress.Zip = Convert.ToString(drAddress["ZipCode"]);
                    //    objevent.Customer.BillingAddress.CountryID = Convert.ToInt32(drAddress["CountryID"]);
                    //    objevent.Customer.BillingAddress.StateID = Convert.ToInt32(drAddress["StateID"]);
                    //    objevent.Customer.BillingAddress.CityID = Convert.ToInt32(drAddress["CityID"]);
                    //    objevent.Customer.BillingAddress.City = drAddress["CityName"].ToString();
                    //    objevent.Customer.BillingAddress.State = drAddress["StateName"].ToString();
                    //    objevent.Customer.BillingAddress.Country = drAddress["CountryName"].ToString();
                    //}

                    listcustomer.Add(objevent);
                }

                totalRecords = Convert.ToInt64(tempdataset.Tables[0].Rows[0]["TotalCount"]);
            }
            // listeventcustomer[0] = new EEvent();
            listeventcustomer.Customer = listcustomer;
            listeventcustomer = SetEEventObject(listeventcustomer);
            return listeventcustomer;
        }

        private EEvent SetEEventObject(EEvent eEvent)
        {
            var service = IoC.Resolve<ICustomAppointmentBookedReportingService>();
            if (!eEvent.Customer.IsNullOrEmpty())
            {
                var customers = eEvent.Customer;
                var addressIds = eEvent.Customer.Select(x => x.Customer.BillingAddress.AddressID);
                var customerBillingAddress = service.SetCustomerSearchDetails(addressIds);

                var offCallEventDetails = service.GetOffCallEventDetails(eEvent.Customer.Select(x => x.Customer.CustomerID).ToArray());

                var listcustomer = new List<EEventCustomer>();

                foreach (var objevent in customers)
                {
                    var custResult = customerBillingAddress.FirstOrDefault(x => x.Id == objevent.Customer.BillingAddress.AddressID);

                    var eventData = offCallEventDetails.FirstOrDefault(x => x.CustomerId == objevent.Customer.CustomerID);

                    if (custResult != null)
                    {
                        objevent.Customer.BillingAddress.AddressID = (int)custResult.Id;
                        objevent.Customer.BillingAddress.Address1 = custResult.StreetAddressLine1;
                        objevent.Customer.BillingAddress.Address2 = custResult.StreetAddressLine2;
                        objevent.Customer.BillingAddress.ZipID = (int)custResult.ZipCode.Id;
                        objevent.Customer.BillingAddress.Zip = custResult.ZipCode.Zip;
                        objevent.Customer.BillingAddress.CountryID = (int)custResult.CountryId;
                        objevent.Customer.BillingAddress.StateID = (int)custResult.StateId;
                        objevent.Customer.BillingAddress.CityID = (int)custResult.CityId;
                        objevent.Customer.BillingAddress.City = custResult.City;
                        objevent.Customer.BillingAddress.State = custResult.State;
                        objevent.Customer.BillingAddress.Country = custResult.Country;
                    }

                    if (eventData != null)
                    {
                        objevent.Customer.CollectionMode = eventData.EventName;
                        objevent.Customer.User.UserID = eventData.EventId;
                        objevent.Customer.User.DOB = eventData.EventDate.ToLongDateString();
                        objevent.Customer.ContactMethod = eventData.EventName;
                    }

                    listcustomer.Add(objevent);
                }
                eEvent.Customer = listcustomer;
            }

            return eEvent;
        }

        public List<EEvent> GetEventList(int eventid, string eventname, string cityname, string statename,
            string zipcode, string fromdate, string todate, long salesrepid,
            long franchiseeid, Int16 mode, string sortcolumn, string sortorder, int pagesize,
            int pageindex, out Int64 totalrecord, long podid, long territoryid, int roleid
            )
        {
            totalrecord = 0;

            var arparams = new SqlParameter[17];

            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[0].Value = eventid;

            arparams[1] = new SqlParameter("@eventname", SqlDbType.VarChar, 200);
            if (eventname.Trim().Length < 1)
            {
                arparams[1].Value = DBNull.Value;
            }
            else
            {
                arparams[1].Value = eventname;
            }

            arparams[2] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (statename.Trim().Length < 1)
            {
                arparams[2].Value = DBNull.Value;
            }
            else
            {
                arparams[2].Value = statename;
            }

            arparams[3] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (cityname.Trim().Length < 1)
            {
                arparams[3].Value = DBNull.Value;
            }
            else
            {
                arparams[3].Value = cityname;
            }

            arparams[4] = new SqlParameter("@zipcode", SqlDbType.VarChar, 100);
            if (zipcode.Trim().Length < 1)
            {
                arparams[4].Value = DBNull.Value;
            }
            else
            {
                arparams[4].Value = zipcode;
            }

            arparams[5] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            if (fromdate.Trim().Length < 1)
            {
                arparams[5].Value = DBNull.Value;
            }
            else
            {
                arparams[5].Value = fromdate;
            }


            arparams[6] = new SqlParameter("@todate", SqlDbType.DateTime);
            if (todate.Trim().Length < 1)
            {
                arparams[6].Value = DBNull.Value;
            }
            else
            {
                arparams[6].Value = todate;
            }


            arparams[7] = new SqlParameter("@salesrepid", SqlDbType.Int);
            arparams[7].Value = salesrepid;


            arparams[8] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[8].Value = mode;

            arparams[9] = new SqlParameter("@franchiseeid", SqlDbType.Int);
            arparams[9].Value = franchiseeid;

            arparams[10] = new SqlParameter("@SortColumn", SqlDbType.VarChar, 255);
            arparams[10].Value = sortcolumn;

            arparams[11] = new SqlParameter("@SortOrder", SqlDbType.VarChar, 100);
            arparams[11].Value = sortorder;

            arparams[12] = new SqlParameter("@PageSize", SqlDbType.Int);
            arparams[12].Value = pagesize;

            arparams[13] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arparams[13].Value = pageindex;

            arparams[14] = new SqlParameter("@podid", SqlDbType.BigInt);
            arparams[14].Value = podid;

            arparams[15] = new SqlParameter("@territoryid", SqlDbType.BigInt);
            arparams[15].Value = territoryid;

            arparams[16] = new SqlParameter("@roleid", SqlDbType.Int);
            arparams[16].Value = roleid;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getfranchisorevent", arparams);
            var listevent = new List<EEvent>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    var objevent = new EEvent();
                    objevent.FranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser();
                    objevent.FranchiseeFranchiseeUser.Franchisee = new EFranchisee();
                    objevent.FranchiseeFranchiseeUser.FranchiseeUser = new EFranchiseeUser();
                    objevent.FranchiseeFranchiseeUser.FranchiseeUser.User = new EUser();
                    objevent.Prospect = new EProspect();
                    objevent.EventType = new EEventType();

                    objevent.EventID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["EventID"]);
                    objevent.Name = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventName"]);
                    // added event status
                    objevent.EventStatus = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["EventStatus"]);
                    if (tempdataset.Tables[0].Rows[icount]["EventType"] != DBNull.Value)
                    {
                        objevent.EventType.Name = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventType"]);
                    }

                    objevent.InvitationCode = Convert.ToString(tempdataset.Tables[0].Rows[icount]["InvitationCode"]);

                    objevent.EventDate =
                        Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["EventDate"]).ToLongDateString();
                    /////////////CustomerCount attribute is used for using total customer count/////
                    objevent.CustomerCount = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["customercount"]);
                    /////////////SlotCount attribute is used for using total unpiad customer count/////
                    objevent.SlotCount = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["UnPaidCustomer"]);
                    /////////////OccupiedSlotCount attribute is used for using total piad customer count/////
                    objevent.OccupiedSlotCount = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["PaidCustomer"]);
                    objevent.Prospect.OrganizationName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["HostName"]);
                    objevent.Prospect.ProspectID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["HostID"]);
                    objevent.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID =
                        Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["SalesRepID"]);
                    objevent.FranchiseeFranchiseeUser.Franchisee.FranchiseeID =
                        Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["FranchiseeID"]);
                    objevent.FranchiseeFranchiseeUser.FranchiseeUser.User.FirstName =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["SalesRep"]);
                    objevent.FranchiseeFranchiseeUser.Franchisee.Name =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["Franchisee"]);
                    objevent.AttendedCustomersCount = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["Atteneded"]);
                    objevent.CancelCustomersCount = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["NoShow"]);

                    objevent.Prospect.Address = new EAddress();

                    string addressId = Convert.ToString(tempdataset.Tables[0].Rows[icount]["AddressID"]);

                    if (tempdataset.Tables[0].Rows[0]["AddressID"] != DBNull.Value)
                    // address should be present with valid address id
                    {
                        DataRow drAddress = tempdataset.Tables[1].Select("AddressID=" + addressId)[0];
                        objevent.Prospect.Address.AddressID = Convert.ToInt32(drAddress["AddressID"]);
                        objevent.Prospect.Address.Address1 = drAddress["Address1"].ToString();
                        objevent.Prospect.Address.ZipID = Convert.ToInt32(drAddress["ZIPID"]);
                        objevent.Prospect.Address.Zip = Convert.ToString(drAddress["ZipCode"]);
                        objevent.Prospect.Address.CountryID = Convert.ToInt32(drAddress["CountryID"]);
                        objevent.Prospect.Address.StateID = Convert.ToInt32(drAddress["StateID"]);
                        objevent.Prospect.Address.CityID = Convert.ToInt32(drAddress["CityID"]);
                        objevent.Prospect.Address.City = drAddress["CityName"].ToString();
                        objevent.Prospect.Address.State = drAddress["StateName"].ToString();
                        objevent.Prospect.Address.Country = drAddress["CountryName"].ToString();
                    }

                    var eventpod = new List<EEventPod>();
                    DataTable drEventPod = tempdataset.Tables[2];
                    drEventPod.DefaultView.RowFilter = "EventID = " + objevent.EventID;
                    int jcount = 0;
                    while (jcount < drEventPod.DefaultView.Count)
                    {
                        var pod = new EEventPod();
                        pod.EventID = Convert.ToInt32(drEventPod.DefaultView[jcount]["EventID"]);
                        pod.Pod = new EPod();
                        pod.Pod.PodID = Convert.ToInt32(drEventPod.DefaultView[jcount]["PodID"]);
                        pod.Pod.Name = drEventPod.DefaultView[jcount]["PodName"].ToString();

                        eventpod.Add(pod);
                        jcount++;
                    }
                    objevent.EventPod = eventpod;
                    listevent.Add(objevent);
                }
            }

            if (tempdataset.Tables.Count > 3 && tempdataset.Tables[3].Rows.Count > 0)
            {
                totalrecord = Convert.ToInt64(tempdataset.Tables[3].Rows[0]["TotalRecord"]);
            }
            return listevent;
        }

        public Int64 UpdateCustomerAppointmentInfo(int eventcustomerid, int neweventid, int userid, int appointmentid)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arParms[0].Value = eventcustomerid;
            arParms[1] = new SqlParameter("@neweventid", SqlDbType.BigInt);
            arParms[1].Value = neweventid;
            arParms[2] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[2].Value = userid;
            arParms[3] = new SqlParameter("@appointmentid", SqlDbType.BigInt);
            arParms[3].Value = appointmentid;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_updateappointmentinfo",
                arParms);
            returnvalue = (Int64)arParms[4].Value;


            return returnvalue;
        }

        public List<EEvent> SearchAdvanceEvent(Int64 eventid, string eventname, string cityname, string statename,
            string zipcode, string fromdate, string todate, int franchiseeid,
            int eventcustomerid, Int16 mode)
        {
            var arparams = new SqlParameter[10];

            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[0].Value = eventid;

            arparams[1] = new SqlParameter("@eventname", SqlDbType.VarChar, 200);
            if (eventname.Trim().Length < 1)
            {
                arparams[1].Value = DBNull.Value;
            }
            else
            {
                arparams[1].Value = eventname;
            }

            arparams[2] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (statename.Trim().Length < 1)
            {
                arparams[2].Value = DBNull.Value;
            }
            else
            {
                arparams[2].Value = statename;
            }

            arparams[3] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (cityname.Trim().Length < 1)
            {
                arparams[3].Value = DBNull.Value;
            }
            else
            {
                arparams[3].Value = cityname;
            }

            arparams[4] = new SqlParameter("@zipcode", SqlDbType.VarChar, 100);
            if (zipcode.Trim().Length < 1)
            {
                arparams[4].Value = DBNull.Value;
            }
            else
            {
                arparams[4].Value = zipcode;
            }

            arparams[5] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            if (fromdate.Trim().Length < 1)
            {
                arparams[5].Value = DBNull.Value;
            }
            else
            {
                arparams[5].Value = fromdate;
            }


            arparams[6] = new SqlParameter("@todate", SqlDbType.DateTime);
            if (todate.Trim().Length < 1)
            {
                arparams[6].Value = DBNull.Value;
            }
            else
            {
                arparams[6].Value = todate;
            }


            arparams[7] = new SqlParameter("@franchiseeid", SqlDbType.Int);
            arparams[7].Value = franchiseeid;

            arparams[8] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparams[8].Value = eventcustomerid;

            arparams[9] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[9].Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString, "usp_getevents",
                arparams);
            var returnvalue = new List<EEvent>();
            returnvalue = ParseSearchAdvanceEventDataSet(dstemp, mode);
            return returnvalue;
        }

        /// <summary>
        /// Fills info from dataset into Event object
        /// </summary>
        /// <param name="dstemp"></param>
        /// <returns></returns>
        private List<EEvent> ParseSearchAdvanceEventDataSet(DataSet dstemp, int mode)
        {
            var listobjevent = new List<EEvent>();
            if (dstemp == null)
            {
                return listobjevent;
            }

            DataTable dtevent = dstemp.Tables[0];
            DataTable dtaddress = dstemp.Tables[1];

            for (int icount = 0; icount < dtevent.Rows.Count; icount++)
            {
                try
                {
                    var objevent = new EEvent();
                    objevent.Active = Convert.ToBoolean(dtevent.Rows[icount]["IsActive"]);
                    if (dtevent.Rows[icount]["Amount"] != DBNull.Value)
                    {
                        objevent.Amount = Convert.ToSingle(dtevent.Rows[icount]["Amount"]);
                    }

                    if (dtevent.Rows[icount]["Communicatewithmembers"] != DBNull.Value)
                    {
                        objevent.CommunicateWithMembers =
                            Convert.ToBoolean(dtevent.Rows[icount]["Communicatewithmembers"]);
                    }

                    if (dtevent.Rows[icount]["ComplimentaryScreens"] != DBNull.Value)
                    {
                        objevent.ComplimentaryScreens = Convert.ToInt32(dtevent.Rows[icount]["ComplimentaryScreens"]);
                    }

                    objevent.CosttoUseHostSite = Convert.ToSingle(dtevent.Rows[icount]["CosttoUseHostSite"]);
                    objevent.DeliverSeminar = Convert.ToBoolean(dtevent.Rows[icount]["DeliverSeminar"]);
                    objevent.EventDate = Convert.ToString(dtevent.Rows[icount]["EventDate"]);
                    objevent.EventStatus = Convert.ToInt32(dtevent.Rows[icount]["EventStatus"]);
                    objevent.EventEndTime = Convert.ToString(dtevent.Rows[icount]["EventEndTime"]);
                    objevent.EventID = Convert.ToInt32(dtevent.Rows[icount]["EventID"]);
                    objevent.EventStartTime = Convert.ToString(dtevent.Rows[icount]["EventStartTime"]);
                    if (mode == 5 || mode == 6)
                    {
                        if (dtevent.Rows[icount]["ActiveSlots"] != DBNull.Value)
                        {
                            objevent.IsActiveSlots = Convert.ToInt32(dtevent.Rows[icount]["ActiveSlots"]);
                        }
                    }

                    if (dtevent.Rows[icount]["FundRaiser"] != DBNull.Value)
                    {
                        objevent.FundRaiser = Convert.ToBoolean(dtevent.Rows[icount]["FundRaiser"]);
                    }

                    if (dtevent.Rows[icount]["MarketingMaterialType"] != DBNull.Value)
                    {
                        objevent.MarketingMaterialType = Convert.ToInt32(dtevent.Rows[icount]["MarketingMaterialType"]);
                    }

                    if (dtevent.Rows[icount]["MinPatients"] != DBNull.Value)
                    {
                        objevent.MinPatients = Convert.ToInt32(dtevent.Rows[icount]["MinPatients"]);
                    }

                    objevent.Name = Convert.ToString(dtevent.Rows[icount]["EventName"]);
                    objevent.Rescheduled = Convert.ToBoolean(dtevent.Rows[icount]["IsRescheduled"]);
                    objevent.TimeZone = Convert.ToString(dtevent.Rows[icount]["TimeZone"]);
                    objevent.CustomerCount = Convert.ToInt32(dtevent.Rows[icount]["CustomerCount"]);

                    if (dtevent.Rows[icount]["Type"] != DBNull.Value)
                    {
                        objevent.Type = Convert.ToString(dtevent.Rows[icount]["Type"]);
                    }

                    int addressid = Convert.ToInt32(dtevent.Rows[icount]["AddressID"]);
                    dtaddress.DefaultView.RowFilter = "AddressID = " + addressid;
                    if (dtaddress.DefaultView.Count < 1)
                    {
                        continue;
                    }

                    var hostaddress = new EAddress();
                    hostaddress.Address1 = Convert.ToString(dtaddress.DefaultView[0]["Address1"]);
                    hostaddress.Address2 = Convert.ToString(dtaddress.DefaultView[0]["Address2"]);
                    hostaddress.AddressID = Convert.ToInt32(dtaddress.DefaultView[0]["AddressID"]);
                    hostaddress.City = Convert.ToString(dtaddress.DefaultView[0]["City"]);
                    hostaddress.State = Convert.ToString(dtaddress.DefaultView[0]["State"]);
                    hostaddress.Country = Convert.ToString(dtaddress.DefaultView[0]["Country"]);
                    hostaddress.Zip = Convert.ToString(dtaddress.DefaultView[0]["ZipCode"]);

                    objevent.Host = new EHost();
                    objevent.Host.Address = hostaddress;
                    objevent.Host.Name = Convert.ToString(dtevent.Rows[icount]["HostName"]);
                    objevent.Host.PhoneOffice = Convert.ToString(dtevent.Rows[icount]["HostPhone"]);

                    listobjevent.Add(objevent);
                }
                catch (Exception)
                { }
            }
            return listobjevent;
        }

        public List<EPaymentDetail> GetCustomerPaymentDetails(long eventCustomerId)
        {
            var arparams = new SqlParameter[1];

            arparams[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparams[0].Value = eventCustomerId;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getPaymentDetailforEventCustomerDetails", arparams);
            var listPaymentDetails = new List<EPaymentDetail>();
            if (tempdataset.Tables.Count > 0)
            {
                DataTable tblPayment = tempdataset.Tables[0];
                if (tblPayment.DefaultView.Count > 0)
                {
                    for (int i = 0; i < tblPayment.DefaultView.Count; i++)
                    {
                        var payment = new EPaymentDetail();
                        payment.PaymentDetailID = Convert.ToInt32(tblPayment.DefaultView[i]["PaymentID"]);
                        payment.PaidAmount = Convert.ToSingle(tblPayment.DefaultView[i]["PaidAmount"]);
                        // used forpayment Description
                        payment.CancelationReason = Convert.ToString(tblPayment.DefaultView[i]["Description"]);
                        ////for using debit/credit , IsPaid of payment entity is used.
                        payment.DrOrCr = Convert.ToBoolean(tblPayment.DefaultView[i]["DrOrCr"]);
                        payment.IsPaid = Convert.ToBoolean(tblPayment.DefaultView[i]["IsPaid"]);
                        payment.PaymentType = new EPaymentType();
                        payment.PaymentType.Name = Convert.ToString(tblPayment.DefaultView[i]["Mode"]);
                        listPaymentDetails.Add(payment);
                    }
                }
            }
            return listPaymentDetails;
        }

        //TODO: Added temporary and need to return with proper entity
        public ECustomers GetCustomerPaymentDetailsPrint(long eventCustomerId)
        {
            var arparams = new SqlParameter[1];

            arparams[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparams[0].Value = eventCustomerId;

            DataSet tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getPaymentDetailforPrint", arparams);
            var objECustomers = new ECustomers();
            if (tempdataset.Tables.Count > 0)
            {
                if (tempdataset.Tables[0].Rows.Count > 0)
                {
                    objECustomers.User = new EUser();
                    objECustomers.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[0]["FirstName"]);
                    objECustomers.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[0]["LastName"]);
                    objECustomers.CustomerID = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["CustomerID"]);
                    // TODO: remove this (Now eventid is taken in userid
                    objECustomers.User.UserID = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["EventID"]);
                    objECustomers.Gender = Convert.ToString(tempdataset.Tables[0].Rows[0]["EventName"]);
                    objECustomers.RegisteredBy = Convert.ToString(tempdataset.Tables[0].Rows[0]["EventDate"]);
                }
            }
            return objECustomers;
        }



        /// <summary>
        /// Performs certain operation on an Appointment slot, acc. to the mode supplied
        /// It can insert new slot, block an existing slot and delete an existing slot
        /// </summary>
        public Int64 UpdateAppointmentSlot(EEventAppointment objeventappointment, short mode)
        {
            Int64 retunresult = 0;
            var arparams = new SqlParameter[11];

            arparams[0] = new SqlParameter("@appointmentid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@scheduledbyid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 200);
            arparams[4] = new SqlParameter("@starttime", SqlDbType.VarChar, 200);
            arparams[5] = new SqlParameter("@enddate", SqlDbType.VarChar, 200);
            arparams[6] = new SqlParameter("@endtime", SqlDbType.VarChar, 200);
            arparams[7] = new SqlParameter("@reason", SqlDbType.VarChar, 500);
            arparams[8] = new SqlParameter("@subject", SqlDbType.VarChar, 500);
            arparams[9] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arparams[10] = new SqlParameter("@returnvalue", SqlDbType.BigInt);

            arparams[0].Value = objeventappointment.AppointmentID;
            arparams[1].Value = objeventappointment.ScheduleByID > 0
                                    ? (object)objeventappointment.ScheduleByID
                                    : DBNull.Value;
            arparams[2].Value = objeventappointment.EventID;

            if (objeventappointment.StartDate != null && objeventappointment.StartDate.Trim().Length > 1)
            {
                arparams[3].Value = objeventappointment.StartDate;
            }
            else
            {
                arparams[3].Value = DBNull.Value;
            }

            if (objeventappointment.StartTime != null && objeventappointment.StartTime.Trim().Length > 1)
            {
                arparams[4].Value = objeventappointment.StartTime;
            }
            else
            {
                arparams[4].Value = DBNull.Value;
            }

            if (objeventappointment.EndDate != null && objeventappointment.EndDate.Trim().Length > 1)
            {
                arparams[5].Value = objeventappointment.EndDate;
            }
            else
            {
                arparams[5].Value = DBNull.Value;
            }

            if (objeventappointment.EndTime != null && objeventappointment.EndTime.Trim().Length > 1)
            {
                arparams[6].Value = objeventappointment.EndTime;
            }
            else
            {
                arparams[6].Value = DBNull.Value;
            }

            if (objeventappointment.Reason != null)
            {
                arparams[7].Value = objeventappointment.Reason;
            }
            else
            {
                arparams[7].Value = DBNull.Value;
            }

            if (objeventappointment.Subject != null)
            {
                arparams[8].Value = objeventappointment.Subject;
            }
            else
            {
                arparams[8].Value = DBNull.Value;
            }

            arparams[9].Value = mode;
            arparams[10].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_manageappointmentslot",
                arparams);
            retunresult = Convert.ToInt32(arparams[10].Value);
            return retunresult;
        }

        /// <summary>
        /// Get Payment details for a customer corresponding to the eventcustomerid
        /// </summary>
        public List<EPaymentDetail> GetPaymentDetailForCustomer(int eventcustomerid)
        {
            var arparam = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparam.Value = eventcustomerid;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getpaymentdetailforchangepackage", arparam);
            if (dstemp == null)
            {
                return null;
            }

            if (dstemp.Tables.Count < 1)
            {
                return null;
            }

            var arrpaymentdetail = new List<EPaymentDetail>();

            foreach (DataRow drpaydetail in dstemp.Tables[0].Rows)
            {
                var objpaymentdetail = new EPaymentDetail();
                objpaymentdetail.PaidAmount = Convert.ToSingle(drpaydetail["PaidAmount"]);
                objpaymentdetail.UnpaidAmount = Convert.ToSingle(drpaydetail["UnpaidAmount"]);
                objpaymentdetail.PaymentType = new EPaymentType();
                objpaymentdetail.PaymentType.Name = Convert.ToString(drpaydetail["alias"]);
                objpaymentdetail.PaymentType.PaymentTypeID = Convert.ToInt32(drpaydetail["PaymentTypeID"]);
                arrpaymentdetail.Add(objpaymentdetail);
            }

            if (dstemp.Tables.Count > 1 && dstemp.Tables[1].Rows.Count > 0)
            {
                arrpaymentdetail[0].CreditCardPaymentDetail = new ECreditCardPaymentDetail();
                arrpaymentdetail[0].CreditCardPaymentDetail.CreditCardPaymentID =
                    Convert.ToInt32(dstemp.Tables[1].Rows[0]["CreditCardPaymentID"]);
                arrpaymentdetail[0].CreditCardPaymentDetail.CreditCardNumber =
                    Convert.ToString(dstemp.Tables[1].Rows[0]["CreditCardNumber"]);
                arrpaymentdetail[0].CreditCardPaymentDetail.CardHolderName =
                    Convert.ToString(dstemp.Tables[1].Rows[0]["CCName"]);
                arrpaymentdetail[0].CreditCardPaymentDetail.SecurityCode =
                    Convert.ToString(dstemp.Tables[1].Rows[0]["CVV"]);
                arrpaymentdetail[0].CreditCardPaymentDetail.PaymentStatus =
                    Convert.ToString(dstemp.Tables[1].Rows[0]["PaymentStatus"]);
                arrpaymentdetail[0].CreditCardPaymentDetail.ExpirationDate =
                    Convert.ToString(dstemp.Tables[1].Rows[0]["ExpirationDate"]);
                arrpaymentdetail[0].CreditCardPaymentDetail.CreditCardType = new ECreditCardType();
                arrpaymentdetail[0].CreditCardPaymentDetail.CreditCardType.CreditCardTypeID =
                    Convert.ToInt32(dstemp.Tables[1].Rows[0]["CreditCardTypeID"]);
                arrpaymentdetail[0].CreditCardPaymentDetail.CreditCardType.Name =
                    Convert.ToString(dstemp.Tables[1].Rows[0]["Name"]);
            }

            return arrpaymentdetail;
        }

        public List<EEvent> GetEventForCalendar(long intSalesRepID, string strStartDate, string strEndDate, Int16 mode,
            string hostName, long franchiseeId, string podIds, string territoryIds)
        {
            var arParms = new SqlParameter[8];
            arParms[0] = new SqlParameter("@hostname", SqlDbType.VarChar, 100);
            arParms[0].Value = hostName;
            arParms[1] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            arParms[1].Value = franchiseeId;
            arParms[2] = new SqlParameter("@salesrepid", SqlDbType.BigInt);
            arParms[2].Value = intSalesRepID;
            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 30);
            arParms[3].Value = strStartDate;
            arParms[4] = new SqlParameter("@enddate", SqlDbType.VarChar, 30);
            arParms[4].Value = strEndDate;
            arParms[5] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[5].Value = mode;

            arParms[6] = new SqlParameter("@podIds", SqlDbType.VarChar, 50);
            arParms[6].Value = podIds;
            arParms[7] = new SqlParameter("@territoryIds", SqlDbType.VarChar, 500);
            arParms[7].Value = territoryIds;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getEventsForCalendar", arParms);
            var objListEvent = new List<EEvent>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var objevent = new EEvent();
                    objevent.EventID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["EventID"]);
                    objevent.Name = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventName"]);
                    objevent.EventDate = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventDate"]);
                    objevent.EventStartTime = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventStartTime"]);
                    objevent.EventEndTime = Convert.ToString(tempdataset.Tables[0].Rows[count]["EventEndTime"]);
                    objevent.TimeZone = Convert.ToString(tempdataset.Tables[0].Rows[count]["TimeZone"]);
                    // added event status
                    objevent.EventStatus = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["EventStatus"]);
                    objevent.EventType = new EEventType();
                    objevent.EventType.EventTypeID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["EventTypeID"]);
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
                    objevent.Franchisee.Name = Convert.ToString(tempdataset.Tables[0].Rows[count]["FranchiseeName"]);
                    objevent.FranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser();
                    objevent.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID =
                        Convert.ToInt32(tempdataset.Tables[0].Rows[count]["SalesRepID"]);

                    objevent.FranchiseeFranchiseeUser.FranchiseeUser = new EFranchiseeUser();
                    objevent.FranchiseeFranchiseeUser.FranchiseeUser.User = new EUser();

                    objevent.FranchiseeFranchiseeUser.FranchiseeUser.User.FirstName =
                        Convert.ToString(tempdataset.Tables[0].Rows[count]["FirstName"]);
                    objevent.FranchiseeFranchiseeUser.FranchiseeUser.User.LastName =
                        Convert.ToString(tempdataset.Tables[0].Rows[count]["LastName"]);

                    //// paid , unpaid , register info
                    DataTable tblCustomersInfo = tempdataset.Tables[1];
                    tblCustomersInfo.DefaultView.RowFilter = "EventID = " + objevent.EventID;

                    objevent.UnpaidCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["UnpaidCustomers"]);
                    objevent.RegisteredCustomersCount =
                        Convert.ToInt32(tblCustomersInfo.DefaultView[0]["RegisteredCustomers"]);
                    objevent.PaidCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["PaidCustomers"]);
                    objevent.OnSiteCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["OnSiteCustomers"]);
                    objevent.CancelCustomersCount = Convert.ToInt32(tblCustomersInfo.DefaultView[0]["CancelCustomers"]);
                    objevent.AttendedCustomersCount =
                        Convert.ToInt32(tblCustomersInfo.DefaultView[0]["AttendedCustomers"]);

                    // Pods for event
                    objevent.EventPod = new List<EEventPod>();
                    if (tempdataset.Tables.Count >= 3)
                    {
                        var _lstEEventPod = new List<EEventPod>();

                        DataTable tblEventPods = tempdataset.Tables[2];
                        tblEventPods.DefaultView.RowFilter = "EventID = " + objevent.EventID;
                        foreach (DataRowView drvEventPods in tblEventPods.DefaultView)
                        {
                            var _objEEventPod = new EEventPod();
                            _objEEventPod.Pod = new EPod();
                            _objEEventPod.Pod.PodID = Convert.ToInt32(drvEventPods["PodID"]);
                            _objEEventPod.Pod.Name = Convert.ToString(drvEventPods["Name"]);
                            _lstEEventPod.Add(_objEEventPod);
                        }
                        objevent.EventPod = _lstEEventPod;
                    }
                    objListEvent.Add(objevent);
                }

                catch (Exception)
                { }
            }

            return objListEvent;
        }

        public Int64 DeleteAppointment(EPaymentDetail objpaymentdetail, int eventcustomerid, float amountpayable,
            int roleid, int roleshellid, int userid)
        {
            var arparams = new SqlParameter[19];

            arparams[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@paymentid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@amountpayable", SqlDbType.Decimal);
            arparams[3] = new SqlParameter("@chequenumber", SqlDbType.VarChar, 50);
            arparams[4] = new SqlParameter("@routingnumber", SqlDbType.VarChar, 50);
            arparams[5] = new SqlParameter("@bankname", SqlDbType.VarChar, 50);
            arparams[6] = new SqlParameter("@accountnumber", SqlDbType.VarChar, 50);
            arparams[7] = new SqlParameter("@creditcardnumber", SqlDbType.VarChar, 50);
            arparams[8] = new SqlParameter("@cardtype", SqlDbType.BigInt);
            arparams[9] = new SqlParameter("@cardexpirydate", SqlDbType.DateTime);
            arparams[10] = new SqlParameter("@paymentmodetext", SqlDbType.VarChar, 100);
            arparams[11] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arparams[12] = new SqlParameter("@ccname", SqlDbType.VarChar, 50);
            arparams[13] = new SqlParameter("@cvv", SqlDbType.VarChar, 50);
            arparams[14] = new SqlParameter("@paymentstatus", SqlDbType.VarChar, 5000);
            arparams[15] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arparams[16] = new SqlParameter("@roleshellid", SqlDbType.BigInt);
            arparams[17] = new SqlParameter("@reason", SqlDbType.VarChar, 1000);
            arparams[18] = new SqlParameter("@userid", SqlDbType.BigInt);

            arparams[0].Value = eventcustomerid;
            arparams[1].Value = objpaymentdetail.PaymentDetailID;
            arparams[2].Value = amountpayable;
            arparams[15].Value = roleid;
            arparams[16].Value = roleshellid;
            arparams[17].Value = objpaymentdetail.CancelationReason;
            arparams[18].Value = userid;
            arparams[10].Value = "None";
            if (objpaymentdetail.CashPayment != null)
            {
                arparams[10].Value = "Cash";
            }
            else if (objpaymentdetail.CreditCardPaymentDetail != null)
            {
                arparams[10].Value = "Credit Card";
                arparams[7].Value = objpaymentdetail.CreditCardPaymentDetail.CreditCardNumber;
                arparams[8].Value = objpaymentdetail.CreditCardPaymentDetail.CreditCardType.CreditCardTypeID;
                arparams[9].Value = Convert.ToDateTime(objpaymentdetail.CreditCardPaymentDetail.ExpirationDate);
                arparams[12].Value = objpaymentdetail.CreditCardPaymentDetail.CardHolderName;
                arparams[13].Value = objpaymentdetail.CreditCardPaymentDetail.SecurityCode;
                arparams[14].Value = objpaymentdetail.CreditCardPaymentDetail.PaymentStatus;
            }
            else if (objpaymentdetail.ChequePayment != null)
            {
                arparams[10].Value = "Check";
                arparams[3].Value = objpaymentdetail.ChequePayment.ChequeNumber;
                arparams[4].Value = objpaymentdetail.ChequePayment.RoutingNumber;
                arparams[5].Value = objpaymentdetail.ChequePayment.BankName;
                arparams[6].Value = objpaymentdetail.ChequePayment.AccountNumber;
            }

            arparams[11].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_deleteappointment", arparams);
            if (arparams[11].Value != DBNull.Value)
            {
                return Convert.ToInt64(arparams[11].Value);
            }

            return -1;
        }

        /// <summary>
        /// applies a new coupon or replaces the existing one.
        /// </summary>
        public Int64 ApplyCoupon(Int32 eventcustomerid, float diffamount, float couponcost, int couponid, bool drorcr,
            string paymentmode, bool ispaid, int roleshellid, string UserID, string Shell,
            string Role, bool bolchangepackage, SqlTransaction sqltran)
        {
            Int64 returnvalue = 0;

            var arparams = new SqlParameter[13];

            arparams[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@diffamount", SqlDbType.Decimal);
            arparams[2] = new SqlParameter("@couponid", SqlDbType.BigInt);
            arparams[3] = new SqlParameter("@drorcr", SqlDbType.Bit);
            arparams[4] = new SqlParameter("@paymentmode", SqlDbType.VarChar, 50);
            arparams[5] = new SqlParameter("@ispaid", SqlDbType.Bit);
            arparams[6] = new SqlParameter("@roleshellid", SqlDbType.BigInt);
            arparams[7] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arparams[8] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arparams[9] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arparams[10] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arparams[11] = new SqlParameter("@couponcost", SqlDbType.Decimal);
            arparams[12] = new SqlParameter("@withchangepackage", SqlDbType.Bit);

            arparams[0].Value = eventcustomerid;
            arparams[1].Value = diffamount;
            arparams[2].Value = couponid;
            arparams[3].Value = drorcr;
            arparams[4].Value = paymentmode;
            arparams[5].Value = ispaid;
            arparams[6].Value = roleshellid;
            arparams[7].Value = UserID;
            arparams[8].Value = Shell;
            arparams[9].Value = Role;
            arparams[10].Direction = ParameterDirection.Output;
            arparams[11].Value = couponcost;
            arparams[12].Value = bolchangepackage;

            if (sqltran == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_applycoupon", arparams);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqltran, CommandType.StoredProcedure, "usp_applycoupon", arparams);
            }

            returnvalue = Convert.ToInt32(arparams[10].Value);
            return returnvalue;
        }

        /// <summary>
        /// to get list of events for franchiseeid supplied
        /// </summary>
        public List<EEvent> GetFranchiseeEvent(int mode, int franchiseeid, string filterstring)
        {
            var arparams = new SqlParameter[3];

            arparams[0] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arparams[0].Value = franchiseeid;
            arparams[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[1].Value = mode;
            arparams[2] = new SqlParameter("@filterstring", SqlDbType.VarChar, 500);
            arparams[2].Value = filterstring;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getfranchiseeevent", arparams);
            var listevent = new List<EEvent>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    var objevent = new EEvent();

                    objevent.Name = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventName"]);
                    objevent.EventID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["EventID"]);
                    objevent.EventDate = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventDate"]);
                    listevent.Add(objevent);
                }
            }

            return listevent;
        }

        /// <summary>
        /// This sub routine gets the records which failed to get upload.
        /// </summary>
        public List<EUploadTestInfo> GetFailureRecords(int eventid, int mode)
        {
            var sqlparms = new SqlParameter[2];

            sqlparms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            sqlparms[0].Value = eventid;
            sqlparms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            sqlparms[1].Value = mode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getfaliurerecords", sqlparms);
            var lstFaliureRecords = new List<EUploadTestInfo>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                var objUploadTest = new EUploadTestInfo();
                ///for using test name , ActualReasonFailure attribute is used
                objUploadTest.ActualReasonFailure = Convert.ToString(tempdataset.Tables[0].Rows[count]["TestName"]);
                objUploadTest.TestID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["TestID"]);
                ///for using Customerid , PatientID attribute is used
                objUploadTest.PatientID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["CustomerID"]);
                /////for using Customerid , UploadZipInfoID attribute is used
                //objUploadTest.UploadZipInfoID = Convert.ToInt64(tempdataset.Tables[0].Rows[count]["CustomerID"]);

                lstFaliureRecords.Add(objUploadTest);
            }
            return lstFaliureRecords;
        }

        public List<EEventCustomer> GetEventCustomerCSV(int customerid, string customername, string cityname,
            string statename, string zipcode, string fromdate, string todate,
            int franchiseeid, int DateType, Int16 mode)
        {
            var arparams = new SqlParameter[10];

            arparams[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arparams[0].Value = customerid;

            arparams[1] = new SqlParameter("@customername", SqlDbType.VarChar, 200);
            if (customername.Trim().Length < 1)
            {
                arparams[1].Value = DBNull.Value;
            }
            else
            {
                arparams[1].Value = customername;
            }

            arparams[2] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (statename.Trim().Length < 1)
            {
                arparams[2].Value = DBNull.Value;
            }
            else
            {
                arparams[2].Value = statename;
            }

            arparams[3] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (cityname.Trim().Length < 1)
            {
                arparams[3].Value = DBNull.Value;
            }
            else
            {
                arparams[3].Value = cityname;
            }

            arparams[4] = new SqlParameter("@zipcode", SqlDbType.VarChar, 100);
            if (zipcode.Trim().Length < 1)
            {
                arparams[4].Value = DBNull.Value;
            }
            else
            {
                arparams[4].Value = zipcode;
            }

            arparams[5] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            if (fromdate.Trim().Length < 1)
            {
                arparams[5].Value = DBNull.Value;
            }
            else
            {
                arparams[5].Value = fromdate;
            }


            arparams[6] = new SqlParameter("@todate", SqlDbType.DateTime);
            if (todate.Trim().Length < 1)
            {
                arparams[6].Value = DBNull.Value;
            }
            else
            {
                arparams[6].Value = todate;
            }


            arparams[7] = new SqlParameter("@franchiseeid", SqlDbType.Int);
            arparams[7].Value = franchiseeid;

            arparams[8] = new SqlParameter("@datetype", SqlDbType.BigInt);
            arparams[8].Value = DateType;

            arparams[9] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[9].Value = mode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getcustomercsv",
                arparams);
            var listeventcustomer = new List<EEventCustomer>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    var objevent = new EEventCustomer();
                    objevent.Customer = new ECustomers();
                    objevent.Customer.User = new EUser();
                    objevent.EventPackage = new EEventPackage();
                    objevent.EventPackage.Package = new EPackage();
                    objevent.Customer.User.HomeAddress = new EAddress();
                    objevent.Customer.BillingAddress = new EAddress();
                    objevent.PaymentDetail = new EPaymentDetail();
                    objevent.PaymentDetail.PaymentType = new EPaymentType();
                    objevent.EventAppointment = new EEventAppointment();
                    objevent.Coupon = new ECoupon();
                    objevent.ListPaymentDetail = new List<EPaymentDetail>();

                    if (tempdataset.Tables[0].Rows[icount]["SalesRepID"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["SalesRepID"]) > 0)
                        {
                            objevent.SalesRep = Convert.ToString(tempdataset.Tables[0].Rows[icount]["SalesRep"]);
                        }
                    }
                    objevent.CustomerEventTestID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["EventCustomerID"]);
                    objevent.EventID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["EventID"]);


                    objevent.Customer.CustomerID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["CustomerID"]);
                    //////////////for using roleid ,userid attribute of user entity is used/////
                    objevent.Customer.User.UserID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["RoleID"]);
                    //////////////for using datecreated,DOB attribute of user entity is used/////
                    if (tempdataset.Tables[0].Rows[icount]["DateCreated"] != DBNull.Value)
                    {
                        objevent.Customer.User.DOB = Convert.ToString(tempdataset.Tables[0].Rows[icount]["DateCreated"]);
                    }
                    else
                    {
                        objevent.Customer.User.DOB = "";
                    }
                    //////////////for using event name,CollectionMode attribute of customer entity is used/////
                    objevent.Customer.CollectionMode = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventName"]);
                    //////////////for using event date,DateApplied attribute of user entity is used/////
                    if (tempdataset.Tables[0].Rows[icount]["EventDate"] != DBNull.Value)
                    {
                        objevent.Customer.User.DateApplied =
                            Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["EventDate"]);
                    }
                    //////////////for using host name,ContactMethod attribute of customer entity is used/////
                    objevent.Customer.ContactMethod =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["OrganizationName"]);
                    //////////////for using dob,Answer attribute of User entity is used/////
                    if (tempdataset.Tables[0].Rows[icount]["DOB"] != DBNull.Value)
                    {
                        objevent.Customer.User.Answer =
                            Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["DOB"]).ToString("MM/dd/yyyy");
                    }

                    objevent.Customer.Gender = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Gender"]);
                    objevent.Customer.Weight = Convert.ToSingle(tempdataset.Tables[0].Rows[icount]["WEIGHT"]);
                    objevent.Customer.Race = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Race"]);
                    objevent.Customer.Height = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Height"]);
                    objevent.Customer.RequestForNewsLetter = Convert.ToBoolean(tempdataset.Tables[0].Rows[icount]["RequestNewsLetter"]);

                    objevent.Customer.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["FirstName"]);
                    objevent.Customer.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["LastName"]);
                    if (tempdataset.Tables[0].Rows[icount]["PaidAmount"] != DBNull.Value)
                    {
                        objevent.EventPackage.PackagePrice =
                            Convert.ToSingle(tempdataset.Tables[0].Rows[icount]["PaidAmount"]);
                    }
                    else
                    {
                        objevent.EventPackage.PackagePrice = 0;
                    }
                    objevent.EventPackage.Package.PackageName =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["PackageName"]);
                    objevent.AdditionalTest =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["AdditionalTest"]);
                    objevent.EventPackage.Package.CostPrice =
                        decimal.Parse(tempdataset.Tables[0].Rows[icount]["PackagePrice"].ToString());
                    //////////////for using user email,Description attribute of Package entity is used/////
                    objevent.EventPackage.Package.Description =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["EMail1"]);
                    ///////////////////////////////////////////
                    objevent.Coupon.CouponCode = Convert.ToString(tempdataset.Tables[0].Rows[icount]["CouponCode"]);
                    objevent.Coupon.CouponAmount =
                        Convert.ToDecimal(tempdataset.Tables[0].Rows[icount]["DiscountAmount"]);
                    ///////////for using tracking source,EMail1 attribute of User entity is used/////
                    objevent.Customer.User.EMail1 =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["TrackingMarketingID"]);
                    //////customer address
                    objevent.Customer.User.HomeAddress.State =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["State"]);
                    objevent.Customer.User.HomeAddress.Zip =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["ZipCode"]);
                    objevent.Customer.User.HomeAddress.City =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["City"]);
                    objevent.Customer.User.HomeAddress.Address1 =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["Address1"]);
                    ////event address
                    objevent.Customer.BillingAddress.State =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventState"]);
                    objevent.Customer.BillingAddress.Zip =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventCode"]);
                    objevent.Customer.BillingAddress.City =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventCity"]);
                    objevent.Customer.BillingAddress.Address1 =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventAddress"]);
                    if (tempdataset.Tables[0].Rows[icount]["IsPaid"] == DBNull.Value)
                    {
                        continue;
                    }

                    objevent.Paid = Convert.ToBoolean(tempdataset.Tables[0].Rows[icount]["IsPaid"]);
                    objevent.CashPayment = Convert.ToDecimal(tempdataset.Tables[0].Rows[icount]["CashPayment"]);
                    objevent.CreditCardPayment =
                        Convert.ToDecimal(tempdataset.Tables[0].Rows[icount]["CreditCardPayment"]);
                    objevent.CheckPayment = Convert.ToDecimal(tempdataset.Tables[0].Rows[icount]["CheckPayment"]);
                    objevent.EcheckPayment = Convert.ToDecimal(tempdataset.Tables[0].Rows[icount]["ECheckPayment"]);
                    objevent.GCPayment = Convert.ToDecimal(tempdataset.Tables[0].Rows[icount]["GCPayment"]);

                    //used for incoming phone line
                    objevent.Customer.User.HomeAddress.PhoneNumber =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["IncomingPhoneLine"]);
                    //used for callers phone number
                    objevent.Customer.User.PhoneCell =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["CallersPhoneNumber"]);
                    string eventid = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventID"]);
                    if (tempdataset.Tables.Count > 1)
                    {
                        DataTable dtPod = tempdataset.Tables[1];
                        dtPod.DefaultView.RowFilter = "EventID = " + eventid;
                        if (dtPod.DefaultView.Count > 0)
                        {
                            if (dtPod.DefaultView.Count == 1)
                            {
                                objevent.PodName = Convert.ToString(dtPod.DefaultView[0]["PodName"]);
                            }
                            else
                            {
                                for (int count = 0; count < dtPod.DefaultView.Count; count++)
                                {
                                    objevent.PodName = objevent.PodName + "|" +
                                        Convert.ToString(dtPod.DefaultView[count]["PodName"]);
                                }
                                objevent.PodName = objevent.PodName.Substring(1);
                            }
                        }
                    }
                    objevent.Customer.DoNotContactReasonId = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["DoNotContactReasonId"]);
                    objevent.Customer.LastScreeningDate = "";
                    listeventcustomer.Add(objevent);
                }
            }

            return listeventcustomer;
        }

        /// <summary>
        /// Returns a customer Authorization Detail.
        /// </summary>
        /// <param name="eventcustomerid"></param>
        /// <param name="packageid"></param>
        /// <returns></returns>
        public DataSet GetCustomerAuthorizationDetail(Int64 eventcustomerid, int packageid)
        {
            var arparams = new SqlParameter[2];
            arparams[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@packageid", SqlDbType.Int);

            arparams[0].Value = eventcustomerid;
            arparams[1].Value = packageid;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getCustomerAuthorizationCardDetail", arparams);
            return dstemp;
        }


        public List<ETest> GetEventTest(Int64 intEventid)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = intEventid;

            DataSet testDataSet = SqlHelper.ExecuteDataset(_connectionString,
                "usp_geteventtest", arParms);

            var returnTest = new List<ETest>();

            for (int count = 0; count < testDataSet.Tables[0].Rows.Count; count++)
            {
                var objtest = new ETest
                {
                    Name = Convert.ToString(testDataSet.Tables[0].Rows[count]["Test"]),
                    TestID = Convert.ToInt32(testDataSet.Tables[0].Rows[count]["TestID"]),
                    Description = Convert.ToString(testDataSet.Tables[0].Rows[count]["Alias"]),
                    Version = Convert.ToInt16(testDataSet.Tables[0].Rows[count]["Version"])
                };
                returnTest.Add(objtest);
            }
            return returnTest;
        }

        public Int16 GetEventVersion(Int64 intEventid)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arParms[0].Value = intEventid;
            Object objreturn = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure,
                "usp_geteventversion", arParms);

            return objreturn == DBNull.Value ? (short)0 : Convert.ToInt16(objreturn);
        }

        #endregion

        # region "EventType"



        public List<EEventType> GetEventType(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getEventtype",
                arParms);

            var returnEventType = new List<EEventType>();
            returnEventType = ParseEventTypeDataSet(tempdataset);
            return returnEventType;
        }

        private List<EEventType> ParseEventTypeDataSet(DataSet eventtypeDataSet)
        {
            var returnEventType = new List<EEventType>();

            for (int count = 0; count < eventtypeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var eventtype = new EEventType();
                    eventtype.Active = Convert.ToBoolean(eventtypeDataSet.Tables[0].Rows[count]["IsActive"]);
                    eventtype.EventTypeID = Convert.ToInt32(eventtypeDataSet.Tables[0].Rows[count]["EventTypeID"]);
                    eventtype.Description = Convert.ToString(eventtypeDataSet.Tables[0].Rows[count]["Description"]);
                    eventtype.Name = Convert.ToString(eventtypeDataSet.Tables[0].Rows[count]["Name"]);
                    returnEventType.Add(eventtype);
                }
                catch
                { }
            }
            return returnEventType;
        }

        #endregion

        #region "TestResults"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterstring"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<ETestParameter> GetTestParameter(string filterstring, int mode)
        {
            var arparams = new SqlParameter[2];
            arparams[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 500);
            arparams[0].Value = filterstring;

            arparams[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[1].Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_gettestparameters", arparams);
            List<ETestParameter> listobjtestresult = ParseTestParameterDataset(dstemp);
            return listobjtestresult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dstestparameter"></param>
        /// <returns></returns>
        private List<ETestParameter> ParseTestParameterDataset(DataSet dstestparameter)
        {
            var listobjTestParameter = new List<ETestParameter>();
            if (dstestparameter == null)
            {
                return listobjTestParameter;
            }

            if (dstestparameter.Tables.Count < 1)
            {
                return listobjTestParameter;
            }

            DataTable dtTestParameter = dstestparameter.Tables[0];

            for (int icount = 0; icount < dtTestParameter.Rows.Count; icount++)
            {
                try
                {
                    var objTestParameter = new ETestParameter();
                    objTestParameter.TestParameterID = Convert.ToInt32(dtTestParameter.Rows[icount]["testparameterid"]);
                    objTestParameter.TestID = Convert.ToInt32(dtTestParameter.Rows[icount]["testid"]);
                    objTestParameter.ParameterName = Convert.ToString(dtTestParameter.Rows[icount]["name"]);
                    objTestParameter.ParameterValue = Convert.ToString(dtTestParameter.Rows[icount]["value"]);
                    objTestParameter.ParameterDescription = Convert.ToString(dtTestParameter.Rows[icount]["description"]);

                    listobjTestParameter.Add(objTestParameter);
                }
                catch (Exception)
                { }
            }
            return listobjTestParameter;
        }

        /// <summary>
        /// Saves Test Results Unable screening reasons,
        /// when test conduct is a failure.
        /// </summary>
        /// <param name="lstUnableScreenReason"></param>
        /// <param name="testresultid"></param>
        /// <param name="testname"></param>
        /// <returns></returns>
        private Int64 SaveTestUnableScreenReason(List<EUnableScreenReason> lstUnableScreenReason, Int64 testresultid,
            string testname)
        {
            Int64 returnvalue = 0;
            var arparams = new SqlParameter[5];
            arparams[0] = new SqlParameter("@testresultid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@testname", SqlDbType.VarChar, 100);
            arparams[2] = new SqlParameter("@unablescreenreasonid", SqlDbType.TinyInt);
            arparams[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arparams[3].Direction = ParameterDirection.Output;
            arparams[4] = new SqlParameter("@notes", SqlDbType.VarChar, 1000);

            foreach (EUnableScreenReason objUnablescreenreason in lstUnableScreenReason)
            {
                arparams[0].Value = testresultid;
                arparams[1].Value = testname;
                arparams[2].Value = objUnablescreenreason.UnableScreenReasonID;
                if (objUnablescreenreason.Notes != null && objUnablescreenreason.Notes.Trim().Length > 0)
                {
                    arparams[4].Value = objUnablescreenreason.Notes.Trim();
                }
                else
                {
                    arparams[4].Value = DBNull.Value;
                }

                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveunablescreenreason",
                    arparams);
                returnvalue = Convert.ToInt64(arparams[3].Value);
            }
            return returnvalue;
        }

        private string ResolveTestName(EETest testenum)
        {
            string testname = "";
            testname = testenum.ToString().Replace("_", " ");

            return testname;
        }

        public Int64 SaveUploadZipInfo(EUploadZipInfo objuploadzipinfo, int mode)
        {
            Int64 returnvalue = 0;
            var arparams = new SqlParameter[17];
            arparams[0] = new SqlParameter("@uploadzipinfoid", SqlDbType.BigInt);
            arparams[0].Value = objuploadzipinfo.UploadZipInfoID;

            arparams[1] = new SqlParameter("@filename", SqlDbType.VarChar, 256);
            arparams[1].Value = objuploadzipinfo.FileName;

            arparams[2] = new SqlParameter("@filesize", SqlDbType.VarChar, 50);
            arparams[2].Value = objuploadzipinfo.FileSize;

            arparams[3] = new SqlParameter("@numberoftest", SqlDbType.TinyInt);
            arparams[3].Value = objuploadzipinfo.TestCount;

            arparams[4] = new SqlParameter("@isuploadsuccessful", SqlDbType.Bit);
            arparams[4].Value = objuploadzipinfo.UploadSuccessful;

            arparams[5] = new SqlParameter("@isparsesuccessful", SqlDbType.Bit);
            arparams[5].Value = DBNull.Value;

            arparams[6] = new SqlParameter("@failurecount", SqlDbType.TinyInt);
            arparams[6].Value = objuploadzipinfo.FailureCount;

            arparams[7] = new SqlParameter("@uploadstarttime", SqlDbType.VarChar, 50);
            arparams[7].Value = objuploadzipinfo.UploadStartTime;

            arparams[8] = new SqlParameter("@uploadendtime", SqlDbType.VarChar, 50);
            arparams[8].Value = objuploadzipinfo.UploadEndTime;

            arparams[9] = new SqlParameter("@parsestarttime", SqlDbType.VarChar, 50);
            if (objuploadzipinfo.ParseStartTime == null || objuploadzipinfo.ParseStartTime == string.Empty)
            {
                arparams[9].Value = DBNull.Value;
            }
            else
            {
                arparams[9].Value = objuploadzipinfo.ParseStartTime;
            }

            arparams[10] = new SqlParameter("@parseendtime", SqlDbType.VarChar, 50);
            if (objuploadzipinfo.ParseEndTime == null || objuploadzipinfo.ParseEndTime == string.Empty)
            {
                arparams[10].Value = DBNull.Value;
            }
            else
            {
                arparams[10].Value = objuploadzipinfo.ParseEndTime;
            }

            arparams[11] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arparams[11].Value = mode;

            arparams[12] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arparams[12].Direction = ParameterDirection.Output;

            arparams[13] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[13].Value = objuploadzipinfo.Event.EventID;

            arparams[14] = new SqlParameter("@roleshellid", SqlDbType.BigInt);
            arparams[14].Value = objuploadzipinfo.UploadedBy.FranchiseeFranchiseeUserID;

            arparams[15] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arparams[15].Value = objuploadzipinfo.UploadedBy.RoleID;

            arparams[16] = new SqlParameter("@prevfilediscarded ", SqlDbType.Bit);
            arparams[16].Value = objuploadzipinfo.PreviousFileDiscarded;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveuploadzipinfo", arparams);
            returnvalue = Convert.ToInt64(arparams[12].Value);

            return returnvalue;
        }


        public void UpdateEvaluationTime(DateTime starttimeevaluation, DateTime endtimeevaluation,
            long customereventtestid, SqlTransaction sqlTransaction)
        {
            var arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@evalendtime", SqlDbType.DateTime);
            arparams[0].Value = endtimeevaluation.ToString("MM/dd/yyyy hh:mm:ss tt");
            arparams[1] = new SqlParameter("@evalstarttime", SqlDbType.DateTime);
            arparams[1].Value = starttimeevaluation.ToString("MM/dd/yyyy hh:mm:ss tt");
            arparams[2] = new SqlParameter("@customereventtestid", SqlDbType.Int);
            arparams[2].Value = customereventtestid;

            string sqlquery =
                "UPDATE [TblCustomerEventTests] SET [EvaluationEndTime] = @evalendtime, [EvaluationStartTime] = @evalstarttime	WHERE [CustomerEventTestID] = @customereventtestid";

            if (sqlTransaction == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sqlquery, arparams);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, sqlquery, arparams);
            }
        }

        /// <summary>
        /// Fetches list of files, which are uploaded for data extraction, from db.
        /// Data contains results obtained after tests conducted on the customers.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="eventtext"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="technicianid"></param>
        /// <param name="status"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<EUploadZipInfo> GetListUploadedFiles(string filename, string eventtext, string startdate,
            string enddate, int technicianid, string status,
            Int32 UploadZipInfoID, Int16 mode)
        {
            var arparams = new SqlParameter[9];
            arparams[0] = new SqlParameter("@filename", SqlDbType.VarChar, 100);
            arparams[1] = new SqlParameter("@eventname", SqlDbType.VarChar, 100);
            arparams[2] = new SqlParameter("@startdate", SqlDbType.VarChar, 100);
            arparams[3] = new SqlParameter("@enddate", SqlDbType.VarChar, 100);
            arparams[4] = new SqlParameter("@uploadedby", SqlDbType.BigInt);
            arparams[5] = new SqlParameter("@status", SqlDbType.VarChar, 50);
            arparams[6] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[7] = new SqlParameter("@uploadzipinfoid", SqlDbType.BigInt);
            arparams[8] = new SqlParameter("@eventid", SqlDbType.BigInt);

            if (filename != null && filename.Trim().Length > 0)
            {
                arparams[0].Value = filename.Replace("'", "''");
            }
            else
            {
                arparams[0].Value = DBNull.Value;
            }

            Int64 eventid = 0;
            if (Int64.TryParse(eventtext, out eventid))
            {
                arparams[8].Value = eventid;
            }
            else
            {
                arparams[8].Value = 0;
            }

            if (eventid < 1 && eventtext != null && eventtext.Trim().Length > 0)
            {
                arparams[1].Value = eventtext.Replace("'", "''");
            }
            else
            {
                arparams[1].Value = DBNull.Value;
            }

            if (startdate != null && startdate.Trim().Length > 0)
            {
                arparams[2].Value = startdate;
            }
            else
            {
                arparams[2].Value = DBNull.Value;
            }

            if (enddate != null && enddate.Trim().Length > 0)
            {
                arparams[3].Value = enddate;
            }
            else
            {
                arparams[3].Value = DBNull.Value;
            }

            arparams[4].Value = technicianid;

            if (status != null && status.Trim().Length > 0)
            {
                arparams[5].Value = status;
            }
            else
            {
                arparams[5].Value = DBNull.Value;
            }

            arparams[6].Value = mode;

            if (UploadZipInfoID > 0)
            {
                arparams[7].Value = UploadZipInfoID;
            }
            else
            {
                arparams[7].Value = DBNull.Value;
            }

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getuploadedlogfiles", arparams);

            return ParseDatasetListUploadedFiles(dstemp);
        }

        /// <summary>
        /// Parses the dataset for Uploaded files.
        /// </summary>
        /// <param name="dsuploadedfiles"></param>
        /// <returns></returns>
        private List<EUploadZipInfo> ParseDatasetListUploadedFiles(DataSet dsuploadedfiles)
        {
            var lstuploadzipinfo = new List<EUploadZipInfo>();

            if (dsuploadedfiles == null)
            {
                return lstuploadzipinfo;
            }

            DataTable dtuploadzipinfo = dsuploadedfiles.Tables[0];
            DataTable dteventlist = dsuploadedfiles.Tables[1];

            foreach (DataRow drupload in dtuploadzipinfo.Rows)
            {
                var objuploadzipinfo = new EUploadZipInfo();

                objuploadzipinfo.UploadZipInfoID = Convert.ToInt32(drupload["UploadZipInfoID"]);
                objuploadzipinfo.UploadStartTime = Convert.ToString(drupload["UploadStartTime"]);
                objuploadzipinfo.UploadEndTime = Convert.ToString(drupload["UploadEndTime"]);

                objuploadzipinfo.UploadedBy = new EFranchiseeFranchiseeUser();
                objuploadzipinfo.UploadedBy.FranchiseeUser = new EFranchiseeUser();
                objuploadzipinfo.UploadedBy.FranchiseeUser.User = new EUser();

                objuploadzipinfo.UploadedBy.FranchiseeFranchiseeUserID = Convert.ToInt32(drupload["RoleShellID"]);
                objuploadzipinfo.UploadedBy.FranchiseeUser.User.FirstName = Convert.ToString(drupload["FirstName"]);
                objuploadzipinfo.UploadedBy.FranchiseeUser.User.MiddleName = Convert.ToString(drupload["MiddleName"]);
                objuploadzipinfo.UploadedBy.FranchiseeUser.User.LastName = Convert.ToString(drupload["LastName"]);

                objuploadzipinfo.UploadTime = Convert.ToInt32(drupload["TotalUploadTime"]);
                objuploadzipinfo.FileName = Convert.ToString(drupload["FileName"]);
                objuploadzipinfo.FileSize = Convert.ToString(drupload["FileSize"]);
                objuploadzipinfo.FailureCount = Convert.ToInt16(drupload["FailureCount"]);
                objuploadzipinfo.TotalCount = Convert.ToInt16(drupload["RecordsCount"]);
                objuploadzipinfo.RecordsNotFoundCount = Convert.ToInt16(drupload["RecordsNotInZip"]);
                objuploadzipinfo.ParseTime = Convert.ToInt32(drupload["TotalParseTime"]);
                objuploadzipinfo.LogFilePath = Convert.ToString(drupload["LogFilePath"]);

                EEvent objevent = null;
                dteventlist.DefaultView.RowFilter = "EventID = " + Convert.ToInt32(drupload["EventID"]);

                foreach (DataRowView drvevent in dteventlist.DefaultView)
                {
                    objevent = new EEvent();
                    objevent.EventID = Convert.ToInt32(drvevent["EventID"]);
                    objevent.CustomerCount = Convert.ToInt32(drvevent["countscreeened"]);
                    objevent.EventDate = Convert.ToString(drvevent["EventDate"]);
                    objevent.EventEndTime = Convert.ToString(drvevent["EventEndTime"]);
                    objevent.Host = new EHost();
                    objevent.Host.Name = Convert.ToString(drvevent["HostName"]);
                    objevent.Host.Address = new EAddress();
                    objevent.Host.Address.Address1 = Convert.ToString(drvevent["Address1"]);
                    objevent.Host.Address.Address2 = Convert.ToString(drvevent["Address2"]);
                    objevent.Host.Address.City = Convert.ToString(drvevent["City"]);
                    objevent.Host.Address.Country = Convert.ToString(drvevent["Country"]);
                    objevent.Host.Address.State = Convert.ToString(drvevent["State"]);
                    objevent.Host.Address.Zip = Convert.ToString(drvevent["ZipCode"]);
                }
                objuploadzipinfo.Event = objevent;
                lstuploadzipinfo.Add(objuploadzipinfo);
            }
            return lstuploadzipinfo;
        }

        #endregion

        # region "CommunicationMode"

        public List<ECommunicationMode> GetCommunicationMode(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getcommunicationmode", arParms);

            var returnCommunicationMode = new List<ECommunicationMode>();
            returnCommunicationMode = ParseCommunicationModeDataSet(tempdataset);
            return returnCommunicationMode;
        }

        private List<ECommunicationMode> ParseCommunicationModeDataSet(DataSet communicationmodeDataSet)
        {
            var returnCommunicationMode = new List<ECommunicationMode>();

            for (int count = 0; count < communicationmodeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var communicationmode = new ECommunicationMode();
                    communicationmode.Active =
                        Convert.ToBoolean(communicationmodeDataSet.Tables[0].Rows[count]["IsActive"]);
                    communicationmode.CommunicationModeID =
                        Convert.ToInt32(communicationmodeDataSet.Tables[0].Rows[count]["CommunicationModeID"]);
                    communicationmode.Description =
                        Convert.ToString(communicationmodeDataSet.Tables[0].Rows[count]["Description"]);
                    communicationmode.Name = Convert.ToString(communicationmodeDataSet.Tables[0].Rows[count]["Name"]);
                    returnCommunicationMode.Add(communicationmode);
                }
                catch
                { }
            }
            return returnCommunicationMode;
        }

        #endregion

        # region "Zip"

        public List<ECity> GetZipDetails(string zipcode, int mode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = zipcode;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getzip", arParms);

            var returnCity = new List<ECity>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                var city = new ECity();
                city.Zipcode = new EZip();
                city.Zipcode.ZipID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["ZipID"]);
                city.Zipcode.ZipCode = Convert.ToString(tempdataset.Tables[0].Rows[count]["ZipCode"]);
                city.Zipcode.Latitude = Convert.ToString(tempdataset.Tables[0].Rows[count]["Latitude"]);
                city.Zipcode.Longitude = Convert.ToString(tempdataset.Tables[0].Rows[count]["Longitude"]);
                city.Zipcode.TimeZone = Convert.ToString(tempdataset.Tables[0].Rows[count]["TimeZone"]);
                city.Name = Convert.ToString(tempdataset.Tables[0].Rows[count]["City"]);
                city.State = new EState();
                city.State.Name = Convert.ToString(tempdataset.Tables[0].Rows[count]["State"]);

                returnCity.Add(city);
            }
            return returnCity;
        }

        #endregion

        # region "ScheduleMethod"

        public List<EScheduleMethod> GetScheduleMethod(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getschedulemethod", arParms);

            var returnScheduleMethod = new List<EScheduleMethod>();
            returnScheduleMethod = ParseScheduleMethodDataSet(tempdataset);
            return returnScheduleMethod;
        }

        private List<EScheduleMethod> ParseScheduleMethodDataSet(DataSet schedulemethodDataSet)
        {
            var returnScheduleMethod = new List<EScheduleMethod>();

            for (int count = 0; count < schedulemethodDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var schedulemethod = new EScheduleMethod();
                    schedulemethod.Active = Convert.ToBoolean(schedulemethodDataSet.Tables[0].Rows[count]["IsActive"]);
                    schedulemethod.ScheduleMethodID =
                        Convert.ToInt32(schedulemethodDataSet.Tables[0].Rows[count]["ScheduleMethodID"]);
                    schedulemethod.Description =
                        Convert.ToString(schedulemethodDataSet.Tables[0].Rows[count]["Description"]);
                    schedulemethod.Name = Convert.ToString(schedulemethodDataSet.Tables[0].Rows[count]["Name"]);
                    returnScheduleMethod.Add(schedulemethod);
                }
                catch
                { }
            }
            return returnScheduleMethod;
        }

        #endregion

        # region "Role"

        public List<ERole> GetRole(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getrole",
                arParms);

            var returnRole = new List<ERole>();
            returnRole = ParseRoleDataSet(tempdataset);
            return returnRole;
        }

        private List<ERole> ParseRoleDataSet(DataSet roleDataSet)
        {
            var returnRole = new List<ERole>();

            for (int count = 0; count < roleDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var role = new ERole();
                    role.Active = Convert.ToBoolean(roleDataSet.Tables[0].Rows[count]["IsActive"]);
                    role.RoleID = Convert.ToInt32(roleDataSet.Tables[0].Rows[count]["RoleID"]);
                    role.Description = Convert.ToString(roleDataSet.Tables[0].Rows[count]["Description"]);
                    role.Name = Convert.ToString(roleDataSet.Tables[0].Rows[count]["Name"]);
                    returnRole.Add(role);
                }
                catch
                { }
            }
            return returnRole;
        }

        #endregion


        # region "SecurityQuestion"

        public Int64 SaveSecurityQuestion(ESecurityQuestion securityquestion, int Mode)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@securityquestionid", SqlDbType.BigInt);
            arParms[0].Value = securityquestion.SecurityQuestionID;
            arParms[1] = new SqlParameter("@securityquestionname", SqlDbType.VarChar, 500);
            arParms[1].Value = securityquestion.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = securityquestion.Description;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = Mode;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savesecurityquestion",
                arParms);
            return (Int64)arParms[4].Value;
        }

        public Int64 SaveSecurityQuestion(String securityquestionID, int Mode)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@securityquestionid", SqlDbType.VarChar, 3000);
            arParms[0].Value = securityquestionID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removesecurityquestion",
                arParms);
            return (Int64)arParms[2].Value;

        }

        public List<ESecurityQuestion> GetSecurityQuestion(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getsecurityquestion", arParms);

            var returnSecurityQuestion = new List<ESecurityQuestion>();
            returnSecurityQuestion = ParseSecurityQuestionDataSet(tempdataset);
            return returnSecurityQuestion;
        }

        private List<ESecurityQuestion> ParseSecurityQuestionDataSet(DataSet securityquestionDataSet)
        {
            var returnSecurityQuestion = new List<ESecurityQuestion>();

            for (int count = 0; count < securityquestionDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var securityquestion = new ESecurityQuestion();
                    securityquestion.Active =
                        Convert.ToBoolean(securityquestionDataSet.Tables[0].Rows[count]["IsActive"]);
                    securityquestion.SecurityQuestionID =
                        Convert.ToInt32(securityquestionDataSet.Tables[0].Rows[count]["SecurityQuestionID"]);
                    securityquestion.Description =
                        Convert.ToString(securityquestionDataSet.Tables[0].Rows[count]["Description"]);
                    securityquestion.Name = Convert.ToString(securityquestionDataSet.Tables[0].Rows[count]["Name"]);
                    returnSecurityQuestion.Add(securityquestion);
                }
                catch
                { }
            }
            return returnSecurityQuestion;
        }


        #endregion

        #region "InventoryItem"

        public Int64 SaveInventoryItem(EInventoryItem inventoryitem, int Mode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@inventoryitemid", SqlDbType.BigInt);
            arParms[0].Value = inventoryitem.InventoryItemID;
            arParms[1] = new SqlParameter("@inventoryitemname", SqlDbType.VarChar, 500);
            arParms[1].Value = inventoryitem.Name;

            arParms[2] = new SqlParameter("@itemtype", SqlDbType.Int, 1000);
            arParms[2].Value = inventoryitem.ItemType.ItemTypeID;
            arParms[3] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[3].Value = inventoryitem.Description;
            arParms[4] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[4].Value = Mode;

            arParms[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveinventoryitem", arParms);
            returnvalue = (Int64)arParms[5].Value;
            if (inventoryitem.Test != null)
            {
                if (Mode == 0)
                {
                    SaveInventoryItemTest(inventoryitem.Test, returnvalue);
                }
                else if (Mode == 1)
                {
                    SaveInventoryItemTest(inventoryitem.Test, inventoryitem.InventoryItemID);
                }
            }
            return returnvalue;
        }

        public Int64 SaveInventoryItemTest(List<ETest> test, Int64 inventoryitemid)
        {
            var returnvalue = new Int64();
            for (int icount = 0; icount < test.Count; icount++)
            {
                var arParms = new SqlParameter[4];
                arParms[0] = new SqlParameter("@inventoryitemid", SqlDbType.BigInt);
                arParms[0].Value = inventoryitemid;
                arParms[1] = new SqlParameter("@testid", SqlDbType.BigInt);
                arParms[1].Value = test[icount].TestID;

                arParms[2] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[2].Value = icount;

                arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveinventoryitemtest", arParms);
                returnvalue = (Int64)arParms[3].Value;
            }

            return returnvalue;
        }

        public Int64 SaveInventoryItem(String inventoryitemID, int Mode)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@inventoryitemid", SqlDbType.VarChar, 3000);
            arParms[0].Value = inventoryitemID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removeinventoryitem", arParms);
            return (Int64)arParms[2].Value;

        }

        public List<EInventoryItem> GetInventoryItem(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getinventoryitem",
                arParms);

            var returnInventoryItem = new List<EInventoryItem>();
            returnInventoryItem = ParseInventoryItemDataSet(tempdataset);
            return returnInventoryItem;
        }

        public List<EInventoryItemTest> GetInventoryItemTestbyInventoryID(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getinventoryitem",
                arParms);

            var returnInventoryItemTest = new List<EInventoryItemTest>();
            returnInventoryItemTest = ParseInventoryItemTestDataTable(tempdataset.Tables[1]);
            return returnInventoryItemTest;
        }

        private List<EInventoryItemTest> ParseInventoryItemTestDataTable(DataTable inventoryitemtestDataTable)
        {
            var returnInventoryItemTest = new List<EInventoryItemTest>();

            for (int count = 0; count < inventoryitemtestDataTable.Rows.Count; count++)
            {
                try
                {
                    var inventoryitemtest = new EInventoryItemTest();

                    inventoryitemtest.InventoryItemTestID =
                        Convert.ToInt32(inventoryitemtestDataTable.Rows[count]["InventoryItemTestID"]);
                    inventoryitemtest.InventoryItemID =
                        Convert.ToInt32(inventoryitemtestDataTable.Rows[count]["InventoryItemID"]);
                    inventoryitemtest.TestID = Convert.ToInt32(inventoryitemtestDataTable.Rows[count]["TestID"]);
                    inventoryitemtest.Active = Convert.ToBoolean(inventoryitemtestDataTable.Rows[count]["IsActive"]);

                    returnInventoryItemTest.Add(inventoryitemtest);
                }
                catch
                { }
            }
            return returnInventoryItemTest;
        }

        private List<EInventoryItem> ParseInventoryItemDataSet(DataSet inventoryitemDataSet)
        {
            var returnInventoryItem = new List<EInventoryItem>();

            for (int count = 0; count < inventoryitemDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var inventoryitem = new EInventoryItem();
                    var itemtype = new EItemType();
                    itemtype.ItemTypeID = Convert.ToInt32(inventoryitemDataSet.Tables[0].Rows[count]["ItemType"]);
                    itemtype.Name = Convert.ToString(inventoryitemDataSet.Tables[0].Rows[count]["ItemTypeName"]);
                    itemtype.TestAssociated =
                        Convert.ToBoolean(inventoryitemDataSet.Tables[0].Rows[count]["IsTestAssociated"]);
                    inventoryitem.Active = Convert.ToBoolean(inventoryitemDataSet.Tables[0].Rows[count]["IsActive"]);
                    inventoryitem.InventoryItemID =
                        Convert.ToInt32(inventoryitemDataSet.Tables[0].Rows[count]["InventoryItemID"]);
                    inventoryitem.Description =
                        Convert.ToString(inventoryitemDataSet.Tables[0].Rows[count]["Description"]);
                    inventoryitem.Name = Convert.ToString(inventoryitemDataSet.Tables[0].Rows[count]["Name"]);

                    inventoryitem.ItemType = itemtype;
                    returnInventoryItem.Add(inventoryitem);
                }
                catch
                { }
            }
            return returnInventoryItem;
        }

        #endregion

        #region "Item"

        public Int64 SaveItem(EItem item, int Mode)
        {

            var arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@itemid", SqlDbType.BigInt);
            arParms[0].Value = item.ItemID;
            arParms[1] = new SqlParameter("@inventoryitemid", SqlDbType.BigInt);
            arParms[1].Value = item.InventoryItemID;
            arParms[2] = new SqlParameter("@itemcode", SqlDbType.VarChar, 500);
            arParms[2].Value = item.ItemCode;
            arParms[3] = new SqlParameter("@skucode", SqlDbType.VarChar, 500);
            arParms[3].Value = item.SKUCode;
            arParms[4] = new SqlParameter("@manufacturername", SqlDbType.VarChar, 500);
            arParms[4].Value = item.ManufacturerName;
            arParms[5] = new SqlParameter("@manufacturerid", SqlDbType.VarChar, 500);
            arParms[5].Value = item.ManufacturerID;
            arParms[6] = new SqlParameter("@notes", SqlDbType.VarChar, 1000);
            arParms[6].Value = item.Notes;
            arParms[7] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[7].Value = Mode;

            arParms[8] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveitem", arParms);
            return (Int64)arParms[8].Value;
        }

        public Int64 SaveItem(String itemID, int Mode)
        {

            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@itemid", SqlDbType.VarChar, 3000);
            arParms[0].Value = itemID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removeitem", arParms);
            return (Int64)arParms[2].Value;

        }

        public List<EItem> GetItem(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getitem",
                arParms);

            var returnItem = new List<EItem>();
            returnItem = ParseItemDataSet(tempdataset);
            return returnItem;
        }

        private List<EItem> ParseItemDataSet(DataSet itemDataSet)
        {
            var returnItem = new List<EItem>();

            for (int count = 0; count < itemDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var item = new EItem();
                    item.InventoryItemID = Convert.ToInt32(itemDataSet.Tables[0].Rows[count]["InventoryItemID"]);
                    item.Active = Convert.ToBoolean(itemDataSet.Tables[0].Rows[count]["IsActive"]);
                    item.ItemID = Convert.ToInt32(itemDataSet.Tables[0].Rows[count]["ItemID"]);
                    item.ManufacturerName = Convert.ToString(itemDataSet.Tables[0].Rows[count]["ManufacturerName"]);
                    item.ManufacturerID = Convert.ToString(itemDataSet.Tables[0].Rows[count]["ManufacturerID"]);
                    item.Notes = Convert.ToString(itemDataSet.Tables[0].Rows[count]["Notes"]);
                    item.ItemCode = Convert.ToString(itemDataSet.Tables[0].Rows[count]["ItemCode"]);
                    item.SKUCode = Convert.ToString(itemDataSet.Tables[0].Rows[count]["SKUCode"]);
                    item.Allocated = Convert.ToBoolean(itemDataSet.Tables[0].Rows[count]["IsAllocated"]);
                    returnItem.Add(item);
                }
                catch
                { }
            }
            return returnItem;
        }

        #endregion

        #region "Van"

        public Int64 SaveVan(EVan Van, int Mode)
        {
            Int64 returnvalue = 0;
            var arParms = new SqlParameter[9];
            arParms[0] = new SqlParameter("@vanid", SqlDbType.BigInt);
            arParms[0].Value = Van.VanID;
            arParms[1] = new SqlParameter("@registrationnumber", SqlDbType.VarChar, 1000);
            if (Van.RegistrationNumber == null)
            {
                arParms[1].Value = DBNull.Value;
            }
            else
            {
                arParms[1].Value = Van.RegistrationNumber;
            }
            arParms[2] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[2].Value = Van.State.StateID;
            arParms[3] = new SqlParameter("@vin", SqlDbType.VarChar, 500);
            if (Van.VIN == null)
            {
                arParms[3].Value = DBNull.Value;
            }
            else
            {
                arParms[3].Value = Van.VIN;
            }
            //arParms[3].Value = Van.VIN;
            arParms[4] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            arParms[4].Value = Van.Name;
            arParms[5] = new SqlParameter("@make", SqlDbType.VarChar, 1000);
            if (Van.Make == null)
            {
                arParms[5].Value = DBNull.Value;
            }
            else
            {
                arParms[5].Value = Van.Make;
            }
            // arParms[5].Value = Van.Make;
            arParms[6] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[6].Value = Van.Description;
            arParms[7] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[7].Value = Mode;

            arParms[8] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savevan", arParms);
            returnvalue = (Int64)arParms[8].Value;
            if (returnvalue == 0 && Mode == (int)EOperationMode.Insert)
            {
                returnvalue = 9999990;
            }
            if (returnvalue == 0 && Mode == (int)EOperationMode.Update)
            {
                returnvalue = 9999991;
            }
            return returnvalue;
        }

        public Int64 SaveVan(String VanID, int Mode)
        {

            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@vanid", SqlDbType.VarChar, 3000);
            arParms[0].Value = VanID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removevan", arParms);
            var returnvalue = (Int64)arParms[2].Value;
            return returnvalue;
        }

        public List<EVan> GetVan(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getvan", arParms);

            var returnVan = new List<EVan>();
            returnVan = ParseVanDataSet(tempdataset);
            return returnVan;
        }

        private List<EVan> ParseVanDataSet(DataSet vanDataSet)
        {
            var returnVan = new List<EVan>();

            for (int count = 0; count < vanDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var van = new EVan();
                    var state = new EState();
                    state.StateID = Convert.ToInt32(vanDataSet.Tables[0].Rows[count]["StateID"]);
                    state.Name = Convert.ToString(vanDataSet.Tables[0].Rows[count]["StateName"]);
                    van.Active = Convert.ToBoolean(vanDataSet.Tables[0].Rows[count]["IsActive"]);

                    van.VanID = Convert.ToInt32(vanDataSet.Tables[0].Rows[count]["VanID"]);
                    van.Description = Convert.ToString(vanDataSet.Tables[0].Rows[count]["Description"]);
                    van.VIN = Convert.ToString(vanDataSet.Tables[0].Rows[count]["VIN"]);
                    van.Name = Convert.ToString(vanDataSet.Tables[0].Rows[count]["Name"]);
                    van.Make = Convert.ToString(vanDataSet.Tables[0].Rows[count]["Make"]);
                    van.RegistrationNumber = Convert.ToString(vanDataSet.Tables[0].Rows[count]["RegistrationNumber"]);
                    van.State = state;
                    returnVan.Add(van);
                }
                catch
                { }
            }
            return returnVan;
        }

        #endregion

        #region "Pod"

        /// <summary>
        /// Creates or updates POD ino the database
        /// </summary>
        /// <param name="pod"></param>
        /// <param name="Mode"></param>
        /// <param name="UserID"></param>
        /// <param name="Shell"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Int64 SavePod(EPod pod, int Mode)
        {
            var arParms = new SqlParameter[8];
            arParms[0] = new SqlParameter("@podid", SqlDbType.BigInt);
            arParms[0].Value = pod.PodID;
            arParms[1] = new SqlParameter("@podname", SqlDbType.VarChar, 500);
            arParms[1].Value = pod.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = pod.Description;
            arParms[3] = new SqlParameter("@vanid", SqlDbType.BigInt);
            arParms[3].Value = pod.Van.VanID;
            arParms[4] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            if (pod.FranchiseeID > 0)
            {
                arParms[4].Value = pod.FranchiseeID;
            }
            else
            {
                arParms[4].Value = DBNull.Value;
            }
            arParms[5] = new SqlParameter("@podprocessingcapacity", SqlDbType.Int);
            arParms[5].Value = pod.PodProcessingCapacity;
            //arParms[6] = new SqlParameter("@teamidlist", SqlDbType.VarChar, 1000);
            //arParms[6].Value = pod.TeamIDList;
            arParms[6] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[6].Value = Mode;

            arParms[7] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[7].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savepoddetails", arParms);
            return (Int64)arParms[7].Value;
        }

        /// <summary>
        /// Activates, Deactivates or Delete the pod in DB
        /// </summary>
        /// <param name="podID"></param>
        /// <param name="Mode"></param>
        /// <param name="UserID"></param>
        /// <param name="Shell"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Int64 SavePod(String podID, int Mode)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@id", SqlDbType.VarChar, 3000);
            arParms[0].Value = podID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removepoddetails", arParms);
            return (Int64)arParms[2].Value;
        }

        /// <summary>
        /// Fetches PodDetail from Database
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EPod> GetPod(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getpoddetails",
                arParms);

            var returnPod = new List<EPod>();
            returnPod = ParsePodDataSet(tempdataset);
            return returnPod;
        }


        /// <summary>
        /// Parses dataset returned from DB and fills info in POD entity object.
        /// </summary>
        /// <param name="podDataSet"></param>
        /// <returns></returns>
        private List<EPod> ParsePodDataSet(DataSet podDataSet)
        {
            var returnPod = new List<EPod>();

            for (int count = 0; count < podDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var pod = new EPod();
                    var van = new EVan();
                    if (podDataSet.Tables[0].Rows[count]["FranchiseeID"] != DBNull.Value)
                        pod.FranchiseeID = Convert.ToInt32(podDataSet.Tables[0].Rows[count]["FranchiseeID"]);


                    van.VanID = Convert.ToInt32(podDataSet.Tables[0].Rows[count]["VanID"]);
                    van.Name = Convert.ToString(podDataSet.Tables[0].Rows[count]["VanName"]);
                    van.RegistrationNumber = Convert.ToString(podDataSet.Tables[0].Rows[count]["RegistrationNumber"]);
                    van.Make = Convert.ToString(podDataSet.Tables[0].Rows[count]["Make"]);
                    pod.Active = Convert.ToBoolean(podDataSet.Tables[0].Rows[count]["IsActive"]);
                    pod.PodID = Convert.ToInt32(podDataSet.Tables[0].Rows[count]["PodID"]);
                    pod.Description = Convert.ToString(podDataSet.Tables[0].Rows[count]["Description"]);
                    pod.Name = Convert.ToString(podDataSet.Tables[0].Rows[count]["Name"]);

                    pod.PodProcessingCapacity =
                        Convert.ToInt32(podDataSet.Tables[0].Rows[count]["PodProcessingCapacity"]);
                    pod.Van = van;

                    returnPod.Add(pod);
                }
                catch
                { }
            }
            return returnPod;
        }

        /// <summary>
        /// Saves Inventory allocated to a POD in DB
        /// </summary>
        /// <param name="podinventory"></param>
        /// <param name="mode"></param>
        /// <param name="UserID"></param>
        /// <param name="Shell"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Int64 SavePodInventory(EPodInventory podinventory, int mode)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@podinventoryid", SqlDbType.BigInt);
            arParms[0].Value = podinventory.PodInventoryID;
            arParms[1] = new SqlParameter("@podid", SqlDbType.BigInt);
            arParms[1].Value = podinventory.Pod.PodID;
            arParms[2] = new SqlParameter("@itemid", SqlDbType.BigInt);
            arParms[2].Value = podinventory.Item.ItemID;

            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = mode;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savepodinventoryitem",
                arParms);
            return (Int64)arParms[4].Value;

        }

        /// <summary>
        /// Saves info regarding manpower alocated to the POD
        /// </summary>
        /// <param name="podTeam"></param>
        /// <param name="intPodID"></param>
        /// <param name="mode"></param>
        /// <param name="UserID"></param>
        /// <param name="Shell"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Int64 SavePodTeam(EFranchiseeFranchiseeUser podTeam, int intPodID, int intEventRoleID, int mode)
        {
            var arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@podid", SqlDbType.BigInt);
            arParms[0].Value = intPodID;
            arParms[1] = new SqlParameter("@franchiseeuserid", SqlDbType.BigInt);
            arParms[1].Value = podTeam.FranchiseeFranchiseeUserID;

            arParms[2] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[2].Value = mode;
            arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;

            arParms[4] = new SqlParameter("@eventroleid", SqlDbType.BigInt);
            arParms[4].Value = intEventRoleID;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savepodteam", arParms);
            return (Int64)arParms[3].Value;

        }

        /// <summary>
        /// Fetches POD inventory from database
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EPodInventory> GetPodInventory(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getpodinventoryitems", arParms);

            var returnPodInventory = new List<EPodInventory>();
            returnPodInventory = ParsePodInventoryDataset(tempdataset);
            return returnPodInventory;
        }

        /// <summary>
        /// Parses POD inventory DataSet recieved from DB and fills info into POD Inventory Entity Object
        /// </summary>
        /// <param name="dsPodInventory"></param>
        /// <returns></returns>
        private List<EPodInventory> ParsePodInventoryDataset(DataSet dsPodInventory)
        {
            var returnPodInventory = new List<EPodInventory>();

            for (int count = 0; count < dsPodInventory.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var podinvobj = new EPodInventory();
                    podinvobj.PodInventoryID = Convert.ToInt64(dsPodInventory.Tables[0].Rows[count]["PodInventoryID"]);
                    podinvobj.Active = Convert.ToBoolean(dsPodInventory.Tables[0].Rows[count]["podinventoryactive"]);

                    podinvobj.Pod = new EPod();
                    podinvobj.Pod.PodID = Convert.ToInt32(dsPodInventory.Tables[0].Rows[count]["podid"]);
                    podinvobj.Pod.Name = dsPodInventory.Tables[0].Rows[count]["podname"].ToString();

                    podinvobj.Item = new EItem();
                    podinvobj.Item.ItemID = Convert.ToInt32(dsPodInventory.Tables[0].Rows[count]["itemid"]);
                    podinvobj.Item.ItemCode = Convert.ToString(dsPodInventory.Tables[0].Rows[count]["itemcode"]);
                    podinvobj.Item.ManufacturerName =
                        Convert.ToString(dsPodInventory.Tables[0].Rows[count]["ManufacturerName"]);
                    podinvobj.Item.SKUCode = Convert.ToString(dsPodInventory.Tables[0].Rows[count]["InventoryName"]);
                    podinvobj.Item.InventoryItemID =
                        Convert.ToInt32(dsPodInventory.Tables[0].Rows[count]["InventoryItemID"]);

                    returnPodInventory.Add(podinvobj);
                }
                catch
                { }
            }
            return returnPodInventory;
        }

        /// <summary>
        /// Fetches the team info. allocated to a POD
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EFranchiseeFranchiseeUser> GetPodTeam(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getpodteam",
                arParms);

            var returnPodTeam = new List<EFranchiseeFranchiseeUser>();
            returnPodTeam = ParsePodTeamDataset(tempdataset);
            return returnPodTeam;
        }

        /// <summary>
        /// Parses POD Team  Dataset and fills info into FranchiseeFranchiseeUser Entity Object
        /// </summary>
        /// <param name="franchiseeuserDataSet"></param>
        /// <returns></returns>
        private List<EFranchiseeFranchiseeUser> ParsePodTeamDataset(DataSet franchiseeuserDataSet)
        {
            var returnFranchiseeUser = new List<EFranchiseeFranchiseeUser>();

            for (int count = 0; count < franchiseeuserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var franchiseeuser = new EFranchiseeFranchiseeUser();

                    franchiseeuser.FranchiseeUser = new EFranchiseeUser();
                    franchiseeuser.FranchiseeUser.User = new EUser();
                    franchiseeuser.FranchiseeUser.User.UserID =
                        Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["UserID"]);
                    franchiseeuser.FranchiseeUser.User.FirstName =
                        Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["FirstName"]);
                    franchiseeuser.FranchiseeUser.User.MiddleName =
                        Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["MiddleName"]);
                    franchiseeuser.FranchiseeUser.User.LastName =
                        Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["LastName"]);
                    franchiseeuser.FranchiseeUser.FranchiseeUserID =
                        Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeUserID"]);
                    franchiseeuser.RoleType = Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["RoleType"]);
                    //// For eventRole of Tech

                    franchiseeuser.StartDate =
                        Convert.ToString(franchiseeuserDataSet.Tables[0].Rows[count]["EventRoleType"]);
                    franchiseeuser.EventRoleID =
                        Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["EventRoleID"]);


                    ////////////////
                    franchiseeuser.Franchisee = new EFranchisee();
                    franchiseeuser.Franchisee.FranchiseeID =
                        Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeID"]);
                    franchiseeuser.FranchiseeFranchiseeUserID =
                        Convert.ToInt32(franchiseeuserDataSet.Tables[0].Rows[count]["FranchiseeFranchiseeUserID"]);
                    returnFranchiseeUser.Add(franchiseeuser);
                }
                catch (Exception)
                { }
            }
            return returnFranchiseeUser;
        }

        #endregion

        #region "Prospect"

        public Int64 SaveProspect(EProspect prospect, int Mode, string UserID, string Shell, string Role)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[18];
            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[0].Value = prospect.ProspectID;
            arParms[1] = new SqlParameter("@title", SqlDbType.VarChar, 1000);
            arParms[1].Value = prospect.Title;
            arParms[2] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[2].Value = prospect.FirstName;
            arParms[3] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[3].Value = prospect.MiddleName;
            arParms[4] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[4].Value = prospect.LastName;
            arParms[5] = new SqlParameter("@emailid", SqlDbType.VarChar, 500);
            arParms[5].Value = prospect.EMailID;
            arParms[6] = new SqlParameter("@notes", SqlDbType.VarChar, 1000);
            arParms[6].Value = prospect.Notes;
            arParms[7] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 1000);
            arParms[7].Value = prospect.PhoneOffice;
            arParms[8] = new SqlParameter("@phonecell", SqlDbType.VarChar, 1000);
            arParms[8].Value = prospect.PhoneCell;
            arParms[9] = new SqlParameter("@phoneother", SqlDbType.VarChar, 1000);
            arParms[9].Value = prospect.PhoneOther;
            arParms[10] = new SqlParameter("@website", SqlDbType.VarChar, 1000);
            arParms[10].Value = prospect.WebSite;
            arParms[11] = new SqlParameter("@organisationname", SqlDbType.VarChar, 1000);
            arParms[11].Value = prospect.OrganizationName;
            arParms[12] = new SqlParameter("@addressid", SqlDbType.BigInt);
            arParms[12].Value = prospect.Address.AddressID;
            arParms[13] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[13].Value = Mode;

            arParms[14] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[14].Value = UserID;
            arParms[15] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[15].Value = Shell;
            arParms[16] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[16].Value = Role;
            arParms[17] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[17].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveprospect", arParms);
            returnvalue = (Int64)arParms[17].Value;
            return returnvalue;
        }

        public List<EProspect> GetProspect(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_getprospect",
                arParms);

            var returnProspect = new List<EProspect>();
            returnProspect = ParseProspectDataSet(tempdataset);
            return returnProspect;
        }

        private List<EProspect> ParseProspectDataSet(DataSet prospectDataSet)
        {
            var returnProspect = new List<EProspect>();

            for (int count = 0; count < prospectDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var prospect = new EProspect();
                    var address = new EAddress();
                    address.AddressID = Convert.ToInt32(prospectDataSet.Tables[0].Rows[count]["AddressID"]);
                    address.Address1 = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["Address"]);

                    prospect.Active = Convert.ToBoolean(prospectDataSet.Tables[0].Rows[count]["IsActive"]);
                    prospect.ProspectID = Convert.ToInt32(prospectDataSet.Tables[0].Rows[count]["ProspectID"]);
                    prospect.Notes = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["Notes"]);
                    prospect.EMailID = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["EMailID"]);
                    prospect.FirstName = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["FirstName"]);
                    prospect.MiddleName = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["MiddleName"]);
                    prospect.LastName = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["LastName"]);
                    prospect.PhoneOffice = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["PhoneOffice"]);
                    prospect.PhoneCell = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["PhoneCell"]);
                    prospect.PhoneOther = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["PhoneOther"]);
                    prospect.WebSite = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["WebSite"]);
                    prospect.OrganizationName =
                        Convert.ToString(prospectDataSet.Tables[0].Rows[count]["OrganizationName"]);
                    prospect.Title = Convert.ToString(prospectDataSet.Tables[0].Rows[count]["Title"]);
                    prospect.Address = address;
                    returnProspect.Add(prospect);
                }
                catch
                { }
            }
            return returnProspect;
        }

        #endregion

        #region "Customer"

        /// <summary>
        /// This routine executes Sql procedure to save customer data.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="Mode"></param>
        /// <param name="UserID"></param>
        /// <param name="Shell"></param>
        /// <param name="Role"></param>
        /// <param name="sqltransaction"></param>
        /// <returns></returns>
        public Int64 SaveCustomer(ECustomers customer, int Mode, string Role,
            SqlTransaction sqltransaction)
        {

            var arParms = new SqlParameter[18];

            arParms[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arParms[0].Value = customer.CustomerID;

            arParms[1] = new SqlParameter("@customeruserid", SqlDbType.BigInt);
            arParms[1].Value = customer.User.UserID;

            arParms[2] = new SqlParameter("@roletype", SqlDbType.VarChar, 100);
            arParms[2].Value = "Customer";

            arParms[3] = new SqlParameter("@contactmethod", SqlDbType.VarChar, 50);
            if (!string.IsNullOrEmpty(customer.ContactMethod))
            {
                arParms[3].Value = customer.ContactMethod;
            }
            else
            {
                arParms[3].Value = DBNull.Value;
            }

            arParms[4] = new SqlParameter("@height", SqlDbType.VarChar, 20);
            if (customer.Height == null || customer.Height.Trim().Length < 1)
            {
                arParms[4].Value = DBNull.Value;
            }
            else
            {
                arParms[4].Value = customer.Height;
            }

            arParms[5] = new SqlParameter("@weight", SqlDbType.Float);
            arParms[5].Value = customer.Weight;

            arParms[6] = new SqlParameter("@gender", SqlDbType.VarChar, 20);
            if (customer.Gender == null || customer.Gender.Trim().Length < 1)
            {
                arParms[6].Value = DBNull.Value;
            }
            else
            {
                arParms[6].Value = customer.Gender;
            }

            arParms[7] = new SqlParameter("@race", SqlDbType.VarChar, 500);
            if (customer.Race == null || customer.Race.Trim().Length < 1)
            {
                arParms[7].Value = DBNull.Value;
            }
            else
            {
                arParms[7].Value = customer.Race;
            }


            arParms[8] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[8].Value = Role;

            arParms[9] = new SqlParameter("@billingaddressid", SqlDbType.BigInt);
            if (customer.BillingAddress != null && customer.BillingAddress.AddressID > 0)
            {
                arParms[9].Value = customer.BillingAddress.AddressID;
            }
            else
            {
                arParms[9].Value = DBNull.Value;
            }

            arParms[10] = new SqlParameter("@collectionmode", SqlDbType.VarChar, 50);
            if (customer.CollectionMode == null)
            {
                arParms[10].Value = DBNull.Value;
            }
            else if (customer.CollectionMode.Trim().Length < 1)
            {
                arParms[10].Value = DBNull.Value;
            }
            else
            {
                arParms[10].Value = customer.CollectionMode;
            }

            arParms[11] = new SqlParameter("@mailinglist", SqlDbType.Bit);
            arParms[11].Value = customer.MailingList;

            arParms[12] = new SqlParameter("@directmail", SqlDbType.Bit);
            arParms[12].Value = customer.DirectMail;

            arParms[13] = new SqlParameter("@specialofficer", SqlDbType.Bit);
            arParms[13].Value = customer.SpecialOffer;

            arParms[14] = new SqlParameter("@age", SqlDbType.TinyInt);
            arParms[14].Value = customer.Age;

            arParms[15] = new SqlParameter("@TrackingMarketing", SqlDbType.VarChar, 500);
            arParms[15].Value = customer.User.TrackingMarketing;

            arParms[16] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[16].Value = Mode;

            arParms[17] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[17].Direction = ParameterDirection.Output;


            if (sqltransaction == null)
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savecustomer", arParms);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(sqltransaction, CommandType.StoredProcedure, "usp_savecustomer", arParms);
            }

            return (Int64)arParms[17].Value;

        }

        public Int64 SaveCustomerInfofromAuditScreen(ECustomers customer, long organizationRoleUserId)
        {
            var arParams = new SqlParameter[26];

            arParams[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arParams[0].Value = customer.CustomerID;

            arParams[1] = new SqlParameter("@height", SqlDbType.NVarChar, 20);
            arParams[1].Value = customer.Height;

            arParams[2] = new SqlParameter("@weight", SqlDbType.Float);
            arParams[2].Value = customer.Weight;

            arParams[3] = new SqlParameter("@gender", SqlDbType.NVarChar, 20);
            arParams[3].Value = customer.Gender;

            arParams[4] = new SqlParameter("@race", SqlDbType.VarChar, 500);
            arParams[4].Value = customer.Race;

            arParams[5] = new SqlParameter("@age", SqlDbType.TinyInt);
            arParams[5].Value = customer.Age;

            arParams[6] = new SqlParameter("@dob", SqlDbType.VarChar, 100);
            arParams[6].Value = customer.User.DOB;

            arParams[7] = new SqlParameter("@phoneHome", SqlDbType.VarChar, 100);
            arParams[7].Value = customer.User.PhoneHome;

            arParams[8] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParams[8].Value = customer.User.EMail1;

            arParams[9] = new SqlParameter("@address1", SqlDbType.VarChar, 200);
            arParams[9].Value = customer.User.HomeAddress.Address1;

            arParams[10] = new SqlParameter("@cityid", SqlDbType.Int);
            arParams[10].Value = customer.User.HomeAddress.CityID;

            arParams[11] = new SqlParameter("@stateid", SqlDbType.Int);
            arParams[11].Value = customer.User.HomeAddress.StateID;

            arParams[12] = new SqlParameter("@zipid", SqlDbType.Int);
            arParams[12].Value = customer.User.HomeAddress.ZipID;

            arParams[13] = new SqlParameter("@physicianinfo", SqlDbType.Bit);

            arParams[14] = new SqlParameter("@physicianfirstname", SqlDbType.VarChar, 500);

            arParams[15] = new SqlParameter("@physicianmiddlename", SqlDbType.VarChar, 500);

            arParams[16] = new SqlParameter("@physicianlastname", SqlDbType.VarChar, 500);

            arParams[17] = new SqlParameter("@phonenumber", SqlDbType.VarChar, 100);

            arParams[18] = new SqlParameter("@pcpaddressid", SqlDbType.Int);

            arParams[19] = new SqlParameter("@email", SqlDbType.VarChar, 200);

            arParams[20] = new SqlParameter("@primarycarephysicianid", SqlDbType.BigInt);

            if (customer.PrimaryCarePhysician != null && customer.PrimaryCarePhysician.PrimaryCarePhysicianID < 1)
            {
                arParams[13].Value = true;
                arParams[14].Value = customer.PrimaryCarePhysician.FirstName;
                arParams[15].Value = customer.PrimaryCarePhysician.MiddleName;
                arParams[16].Value = customer.PrimaryCarePhysician.LastName;
                arParams[17].Value = customer.PrimaryCarePhysician.PhoneNumber;
                arParams[20].Value = customer.PrimaryCarePhysician.PrimaryCarePhysicianID;

                if (customer.PrimaryCarePhysician.PCPAddress != null &&
                    customer.PrimaryCarePhysician.PCPAddress.AddressID > 0)
                {
                    arParams[18].Value = customer.PrimaryCarePhysician.PCPAddress.AddressID;
                }
                else
                {
                    arParams[18].Value = DBNull.Value;
                }

                arParams[19].Value = customer.PrimaryCarePhysician.Email;
            }
            else
            {
                arParams[13].Value = false;
                arParams[20].Value = 0;
                if (customer.PrimaryCarePhysician != null && customer.PrimaryCarePhysician.PrimaryCarePhysicianID > 0)
                {
                    arParams[20].Value = customer.PrimaryCarePhysician.PrimaryCarePhysicianID;
                    arParams[13].Value = true;
                }

                arParams[14].Value = "";
                arParams[15].Value = DBNull.Value;
                arParams[16].Value = "";
                arParams[17].Value = "";
                arParams[18].Value = DBNull.Value;
                arParams[19].Value = "";
            }

            arParams[21] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParams[21].Direction = ParameterDirection.Output;

            arParams[22] = new SqlParameter("@firstName", SqlDbType.VarChar, 500);
            arParams[22].Value = customer.User.FirstName;

            arParams[23] = new SqlParameter("@lastName", SqlDbType.VarChar, 500);
            arParams[23].Value = customer.User.LastName;

            arParams[24] = new SqlParameter("@middleName", SqlDbType.VarChar, 500);
            arParams[24].Value = customer.User.MiddleName;

            arParams[25] = new SqlParameter("@organizationRoleUserId", SqlDbType.BigInt);
            arParams[25].Value = organizationRoleUserId;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savepartialcustomerdetails",
                arParams);

            return Convert.ToInt64(arParams[21].Value);
        }

        public Int64 SaveCustomer(String customerID, int Mode, string UserID, string Shell, string Role)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@customerid", SqlDbType.VarChar, 3000);
            arParms[0].Value = customerID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            arParms[2] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[2].Value = UserID;
            arParms[3] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[3].Value = Shell;
            arParms[4] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[4].Value = Role;
            arParms[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removecustomer", arParms);
            returnvalue = (Int64)arParms[5].Value;
            return returnvalue;
        }

        public Int64 SaveReferrals(long customeruserid, string personname, string email, string strReferralPage)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@referringuserid", SqlDbType.BigInt);
            arParms[0].Value = customeruserid;
            arParms[1] = new SqlParameter("@referralname", SqlDbType.VarChar, 500);
            arParms[1].Value = personname;
            arParms[2] = new SqlParameter("@referralemail", SqlDbType.VarChar, 500);
            arParms[2].Value = email;
            arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;
            arParms[4] = new SqlParameter("@referralpage", SqlDbType.VarChar, 500);
            arParms[4].Value = strReferralPage;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savereferrals", arParms);
            return Convert.ToInt32(arParms[3].Value);
        }



        /// <summary>
        /// Fetches a customer's profile data
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public ECustomers GetCustomerPCPInfo(Int64 iCustomerID, int mode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arParms[0].Value = iCustomerID;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getCustomerPCPInfo", arParms);

            var objCustomer = new ECustomers();
            if (tempdataset != null && tempdataset.Tables.Count > 0)
            {
                if (tempdataset.Tables[0].Rows.Count > 0)
                {
                    objCustomer.User = new EUser();
                    objCustomer.User.HomeAddress = new EAddress();

                    objCustomer.User.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[0]["FirstName"]);
                    objCustomer.User.LastName = Convert.ToString(tempdataset.Tables[0].Rows[0]["LastName"]);
                    objCustomer.User.DOB = Convert.ToString(tempdataset.Tables[0].Rows[0]["DOB"]);
                    objCustomer.User.PhoneCell = Convert.ToString(tempdataset.Tables[0].Rows[0]["PhoneCell"]);
                    objCustomer.User.PhoneOffice = Convert.ToString(tempdataset.Tables[0].Rows[0]["PhoneOffice"]);
                    objCustomer.User.PhoneHome = Convert.ToString(tempdataset.Tables[0].Rows[0]["PhoneHome"]);

                    objCustomer.User.HomeAddress.Address1 = Convert.ToString(tempdataset.Tables[0].Rows[0]["Address1"]);
                    objCustomer.User.HomeAddress.Address2 = Convert.ToString(tempdataset.Tables[0].Rows[0]["Address2"]);
                    objCustomer.User.HomeAddress.State = Convert.ToString(tempdataset.Tables[0].Rows[0]["StateName"]);
                    objCustomer.User.HomeAddress.City = Convert.ToString(tempdataset.Tables[0].Rows[0]["CityName"]);
                    objCustomer.User.HomeAddress.Zip = Convert.ToString(tempdataset.Tables[0].Rows[0]["ZipCode"]);
                }

                if (tempdataset.Tables.Count > 1)
                {
                    if (tempdataset.Tables[1].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(tempdataset.Tables[1].Rows[0]["HasPcp"]))
                        {
                            objCustomer.PrimaryCarePhysician = new EPrimaryCarePhysician();
                            objCustomer.PrimaryCarePhysician.PCPAddress = new EAddress();
                            objCustomer.PrimaryCarePhysician.FirstName =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["FirstName"]);
                            objCustomer.PrimaryCarePhysician.LastName =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["LastName"]);
                            objCustomer.PrimaryCarePhysician.MiddleName =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["MiddleName"]);
                            objCustomer.PrimaryCarePhysician.PCPAddress.AddressID =
                                Convert.ToInt32(tempdataset.Tables[1].Rows[0]["AddressID"]);

                            objCustomer.PrimaryCarePhysician.PCPAddress.Address1 =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["Address1"]);
                            objCustomer.PrimaryCarePhysician.PCPAddress.Address2 =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["Address2"]);
                            objCustomer.PrimaryCarePhysician.PCPAddress.City =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["CityName"]);
                            objCustomer.PrimaryCarePhysician.PCPAddress.State =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["StateName"]);
                            objCustomer.PrimaryCarePhysician.PCPAddress.Zip =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["ZipCode"]);

                            objCustomer.PrimaryCarePhysician.PhoneNumber =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["PhoneNumber"]);
                            objCustomer.PrimaryCarePhysician.Email =
                                Convert.ToString(tempdataset.Tables[1].Rows[0]["Email"]);
                        }
                    }
                }
            }
            return objCustomer;
        }

        public Int64 SaveCustomerAccessLog(ECustomerAccessLog objCustomerAccessLog, int mode)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@CustomerAccessLogID", SqlDbType.Int);
            arParms[0].Value = objCustomerAccessLog.CustomerAccessLogID;

            arParms[1] = new SqlParameter("@MedicalVendorUsedID", SqlDbType.Int);
            arParms[1].Value = objCustomerAccessLog.MedicalVendorUsedID;

            arParms[2] = new SqlParameter("@CustomerID", SqlDbType.Int);
            arParms[2].Value = objCustomerAccessLog.CustomerID;

            arParms[3] = new SqlParameter("@eventid", SqlDbType.Int);
            arParms[3].Value = objCustomerAccessLog.EventID;

            arParms[4] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[4].Value = mode;

            arParms[5] = new SqlParameter("@returnvalue", SqlDbType.Int);
            arParms[5].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_SaveCustomerAccessLog",
                arParms);
            returnvalue = Convert.ToInt32(arParms[5].Value);
            return returnvalue;
        }

        public List<ECustomers> SearchCustomers(long customerid, string customername, string statename, string cityname,
            string zipcode, string regdate, int mode, string filterstring,
            string firstname, string lastname)
        {
            var arparms = new SqlParameter[10];
            arparms[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arparms[0].Value = customerid;

            arparms[1] = new SqlParameter("@customername", SqlDbType.VarChar, 100);
            if (customername.Trim().Length < 1)
            {
                arparms[1].Value = DBNull.Value;
            }
            else
            {
                arparms[1].Value = customername;
            }

            arparms[2] = new SqlParameter("@regdate", SqlDbType.DateTime);
            if (regdate.Trim().Length < 1)
            {
                arparms[2].Value = DBNull.Value;
            }
            else
            {
                arparms[2].Value = Convert.ToDateTime(regdate);
            }

            arparms[3] = new SqlParameter("@statename", SqlDbType.VarChar, 200);
            if (statename.Trim().Length < 1)
            {
                arparms[3].Value = DBNull.Value;
            }
            else
            {
                arparms[3].Value = statename;
            }

            arparms[4] = new SqlParameter("@cityname", SqlDbType.VarChar, 200);
            if (cityname.Trim().Length < 1)
            {
                arparms[4].Value = DBNull.Value;
            }
            else
            {
                arparms[4].Value = cityname;
            }

            arparms[5] = new SqlParameter("@zipcode", SqlDbType.VarChar, 50);
            if (zipcode.Trim().Length < 1)
            {
                arparms[5].Value = DBNull.Value;
            }
            else
            {
                arparms[5].Value = zipcode;
            }

            arparms[6] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparms[6].Value = mode;
            arparms[7] = new SqlParameter("@filterstring", SqlDbType.VarChar, 50);
            if (filterstring == null)
            {
                arparms[7].Value = DBNull.Value;
            }
            else
            {
                arparms[7].Value = filterstring;
            }
            //arparms[7].IsNullable = true;
            arparms[8] = new SqlParameter("@firstname", SqlDbType.VarChar, 50);
            if (firstname.Trim().Length < 1)
            {
                arparms[8].Value = DBNull.Value;
            }
            else
            {
                arparms[8].Value = firstname;
            }

            arparms[9] = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
            if (lastname.Trim().Length < 1)
            {
                arparms[9].Value = DBNull.Value;
            }
            else
            {
                arparms[9].Value = lastname;
            }

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_searchcustomers",
                arparms);

            var returncustomers = new List<ECustomers>();
            returncustomers = ParseCustomersDataSet(tempdataset);
            return returncustomers;
        }

        public List<ECustomers> SearchCustomersOnCall(string firstname, string lastname, string zipcode, int mode,
            string CallBackNumber, string customerid, string insuranceId, string hicn, string phoneNumber, string emailId, long organizationId,string mbi)
        {
            var arparms = new SqlParameter[12];

            arparms[0] = new SqlParameter("@firstname", SqlDbType.VarChar, 50);
            if (firstname.Trim().Length < 1)
            {
                arparms[0].Value = DBNull.Value;
            }
            else
            {
                arparms[0].Value = firstname;
            }

            arparms[1] = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
            if (lastname.Trim().Length < 1)
            {
                arparms[1].Value = DBNull.Value;
            }
            else
            {
                arparms[1].Value = lastname;
            }

            arparms[2] = new SqlParameter("@zipcode", SqlDbType.VarChar, 50);
            if (zipcode.Trim().Length < 1)
            {
                arparms[2].Value = DBNull.Value;
            }
            else
            {
                arparms[2].Value = zipcode;
            }

            arparms[3] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparms[3].Value = mode;

            arparms[4] = new SqlParameter("@callbacknumber", SqlDbType.VarChar, 50);
            if (CallBackNumber.Trim().Length < 1)
            {
                arparms[4].Value = DBNull.Value;
            }
            else
            {
                arparms[4].Value = CallBackNumber;
            }

            arparms[5] = new SqlParameter("@customerid", SqlDbType.VarChar, 50);
            if (customerid.Trim().Length < 1)
            {
                arparms[5].Value = DBNull.Value;
            }
            else
            {
                arparms[5].Value = customerid;
            }

            arparms[6] = new SqlParameter("@InsuranceId", SqlDbType.VarChar, 50);
            if (insuranceId.Trim().Length < 1)
            {
                arparms[6].Value = DBNull.Value;
            }
            else
            {
                arparms[6].Value = insuranceId;
            }

            arparms[7] = new SqlParameter("@hicn", SqlDbType.VarChar, 50);
            if (hicn.Trim().Length < 1)
            {
                arparms[7].Value = DBNull.Value;
            }
            else
            {
                arparms[7].Value = hicn;
            }

            arparms[8] = new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 50);
            if (phoneNumber.Trim().Length < 1)
            {
                arparms[8].Value = DBNull.Value;
            }
            else
            {
                arparms[8].Value = phoneNumber;
            }

            arparms[9] = new SqlParameter("@Email", SqlDbType.VarChar, 100);
            if (emailId.Trim().Length < 1)
            {
                arparms[9].Value = DBNull.Value;
            }
            else
            {
                arparms[9].Value = emailId;
            }

            arparms[10] = new SqlParameter("@organizationId", SqlDbType.BigInt);
            arparms[10].Value = organizationId;


            arparms[11] = new SqlParameter("@Mbi", SqlDbType.VarChar, 50);
            if (mbi.Trim().Length < 1)
            {
                arparms[11].Value = DBNull.Value;
            }
            else
            {
                arparms[11].Value = mbi;
            }

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_SearchCustomersOnCall", arparms);

            var returncustomers = new List<ECustomers>();
            returncustomers = ParseCustomersDataSet(tempdataset);
            return returncustomers;
        }

        private List<ECustomers> ParseCustomersDataSet(DataSet dscustomer)
        {
            var listcustomer = new List<ECustomers>();
            DataTable dtCustomTag = null;
            DataTable dtPreApprovedTests = null;

            if (dscustomer == null)
            {
                return listcustomer;
            }
            if (dscustomer.Tables.Count < 1)
            {
                return listcustomer;
            }
            DataTable dtcustomerusers = dscustomer.Tables[0];
            DataTable dtuseraddress = dscustomer.Tables[1];

            if (dscustomer.Tables.Count > 1)
                dtCustomTag = dscustomer.Tables[2];

            if (dscustomer.Tables.Count > 2)
                dtPreApprovedTests = dscustomer.Tables[3];

            for (int icount = 0; icount < dtcustomerusers.Rows.Count; icount++)
            {
                var customer = new ECustomers();
                var user = new EUser();
                var address = new EAddress();
                customer.CustomerID = Convert.ToInt32(dtcustomerusers.Rows[icount]["CustomerID"]);

                customer.MemberId = Convert.ToString(dtcustomerusers.Rows[icount]["InsuranceId"]);
                customer.Hicn = Convert.ToString(dtcustomerusers.Rows[icount]["HICN"]);
                customer.Tag = Convert.ToString(dtcustomerusers.Rows[icount]["Tag"]);
                customer.Copay = Convert.ToString(dtcustomerusers.Rows[icount]["Copay"]);
                customer.MedicarePlanName = Convert.ToString(dtcustomerusers.Rows[icount]["MedicareAdvantagePlanName"]);
                customer.IsEligible = (dtcustomerusers.Rows[icount]["IsEligble"] == DBNull.Value) ? (bool?)null : Convert.ToBoolean(dtcustomerusers.Rows[icount]["IsEligble"]);
                customer.DoNotContactReasonId = Convert.ToInt32(dtcustomerusers.Rows[icount]["DoNotContactReasonId"]);
                customer.DoNotContactReasonNotesId = Convert.ToInt32(dtcustomerusers.Rows[icount]["DoNotContactReasonNotesId"]);
                customer.DoNotContactTypeId = Convert.ToInt32(dtcustomerusers.Rows[icount]["DoNotContactTypeId"]);

                user.UserID = Convert.ToInt32(dtcustomerusers.Rows[icount]["UserID"]);
                user.FirstName = Convert.ToString(dtcustomerusers.Rows[icount]["FirstName"]);
                user.MiddleName = Convert.ToString(dtcustomerusers.Rows[icount]["MiddleName"]);
                user.LastName = Convert.ToString(dtcustomerusers.Rows[icount]["LastName"]);
                user.EMail1 = Convert.ToString(dtcustomerusers.Rows[icount]["Email1"]);
                user.UserName = Convert.ToString(dtcustomerusers.Rows[icount]["UserName"]);
                user.Question = Convert.ToString(dtcustomerusers.Rows[icount]["Question"]);
                user.Answer = string.IsNullOrWhiteSpace(Convert.ToString((dtcustomerusers.Rows[icount]["Answer"]))) ? string.Empty : _cryptographyService.Decrypt(Convert.ToString(dtcustomerusers.Rows[icount]["Answer"]));
                user.DOB = Convert.ToString(dtcustomerusers.Rows[icount]["DOB"]);
                int addressid = Convert.ToInt32(dtcustomerusers.Rows[icount]["HomeAddressID"]);

                dtuseraddress.DefaultView.RowFilter = "AddressID = " + addressid;

                if (dtuseraddress.DefaultView.Count < 1)
                {
                    continue;
                }

                address.AddressID = Convert.ToInt32(dtuseraddress.DefaultView[0]["AddressID"]);
                address.Address1 = Convert.ToString(dtuseraddress.DefaultView[0]["Address1"]);
                address.Address2 = Convert.ToString(dtuseraddress.DefaultView[0]["Address2"]);
                address.City = Convert.ToString(dtuseraddress.DefaultView[0]["City"]);
                address.State = Convert.ToString(dtuseraddress.DefaultView[0]["State"]);
                address.Country = Convert.ToString(dtuseraddress.DefaultView[0]["Country"]);
                address.Zip = Convert.ToString(dtuseraddress.DefaultView[0]["ZipCode"]);

                customer.CustomTag = string.Empty;

                if (dtCustomTag != null)
                {
                    var results = from DataRow myRow in dtCustomTag.Rows
                                  where (long)myRow["CustomerId"] == customer.CustomerID
                                  select myRow["Tag"];

                    if (!results.IsNullOrEmpty())
                    {
                        customer.CustomTag = string.Join(", ", results);
                    }
                }

                customer.PreApprovedTest = string.Empty;
                if (dtPreApprovedTests != null)
                {
                    var results = from DataRow myRow in dtPreApprovedTests.Rows
                                  where (long)myRow["CustomerId"] == customer.CustomerID
                                  select myRow["TestName"];

                    if (!results.IsNullOrEmpty())
                    {
                        results = results.Select(s => string.Format("\"{0}\"", s));
                        customer.PreApprovedTest = string.Join(", ", results);
                    }
                }

                user.HomeAddress = address;
                customer.User = user;
                listcustomer.Add(customer);
            }

            return listcustomer;
        }

        public EEvent GetCustomerInfoforTestEntry(int eventid, int customerid, Int16 mode)
        {
            var arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[0].Value = eventid;
            arparams[1] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arparams[1].Value = customerid;
            arparams[2] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arparams[2].Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_gettestformanualentry", arparams);

            var objEvent = new EEvent();
            objEvent.EventID = Convert.ToInt32(dstemp.Tables[0].Rows[0]["EventID"]);
            objEvent.Name = Convert.ToString(dstemp.Tables[0].Rows[0]["EventName"]);
            objEvent.EventDate = Convert.ToString(dstemp.Tables[0].Rows[0]["EventDate"]);

            objEvent.Host = new EHost();
            objEvent.Host.Name = Convert.ToString(dstemp.Tables[0].Rows[0]["HostName"]);
            objEvent.Host.PhoneOffice = Convert.ToString(dstemp.Tables[0].Rows[0]["HostPhone"]);

            objEvent.Host.Address = new EAddress();
            objEvent.Host.Address.Address1 = Convert.ToString(dstemp.Tables[0].Rows[0]["Address1"]);
            objEvent.Host.Address.Address2 = Convert.ToString(dstemp.Tables[0].Rows[0]["Address2"]);
            objEvent.Host.Address.Country = Convert.ToString(dstemp.Tables[0].Rows[0]["Country"]);
            objEvent.Host.Address.City = Convert.ToString(dstemp.Tables[0].Rows[0]["City"]);
            objEvent.Host.Address.State = Convert.ToString(dstemp.Tables[0].Rows[0]["State"]);
            objEvent.Host.Address.Zip = Convert.ToString(dstemp.Tables[0].Rows[0]["ZipCode"]);

            objEvent.Customer = new List<EEventCustomer>();
            var objcustomer = new EEventCustomer();

            foreach (DataRow dr in dstemp.Tables[1].Rows)
            {
                objcustomer.Customer = new ECustomers();
                objcustomer.Customer.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                objcustomer.Customer.NextCustomerID = Convert.ToInt32(dr["NextCustomerID"]);
                objcustomer.Customer.Height = Convert.ToString(dr["Height"]);
                objcustomer.Customer.Weight = Convert.ToSingle(dr["Weight"]);
                objcustomer.Customer.Gender = Convert.ToString(dr["Gender"]);
                objcustomer.Customer.Race = Convert.ToString(dr["Race"]);
                objcustomer.Customer.Age = Convert.ToInt16(dr["Age"]);
                objcustomer.Customer.IsHistoryFilled = Convert.ToBoolean(dr["IsHistoryFilled"]);
                objcustomer.Customer.MyPicture = Convert.ToString(dr["Picture"]);
                objcustomer.Customer.User = new EUser();
                objcustomer.Customer.User.FirstName = Convert.ToString(dr["FirstName"]);
                objcustomer.Customer.User.LastName = Convert.ToString(dr["LastName"]);
                objcustomer.Customer.User.MiddleName = Convert.ToString(dr["MiddleName"]);

                objcustomer.Customer.User.PhoneHome = Convert.ToString(dr["PhoneHome"]);
                objcustomer.Customer.User.EMail1 = Convert.ToString(dr["EMail1"]);
                objcustomer.Customer.User.DOB = Convert.ToDateTime(dr["DOB"]).ToString("MM/dd/yyyy");

                objcustomer.Customer.User.HomeAddress = new EAddress();
                objcustomer.Customer.User.HomeAddress.Address1 = Convert.ToString(dr["Address1"]);
                objcustomer.Customer.User.HomeAddress.Address2 = Convert.ToString(dr["Address2"]);
                objcustomer.Customer.User.HomeAddress.Country = Convert.ToString(dr["CountryName"]);

                objcustomer.Customer.User.HomeAddress.CountryID = Convert.ToInt32(dr["CountryId"]);
                objcustomer.Customer.User.HomeAddress.StateID = Convert.ToInt32(dr["StateId"]);

                objcustomer.Customer.User.HomeAddress.State = Convert.ToString(dr["StateName"]);
                objcustomer.Customer.User.HomeAddress.City = Convert.ToString(dr["CityName"]);
                objcustomer.Customer.User.HomeAddress.Zip = Convert.ToString(dr["ZipCode"]);
            }
            objEvent.Customer.Add(objcustomer);
            return objEvent;
        }


        /// <summary>
        /// this subroutine returns the customerdetail
        /// </summary>
        /// <param name="customereventtestid"></param>
        /// <returns></returns>
        public EEvent GetCustomerDetailsByCustomerEventTestID(int customereventtestid)
        {
            var arparams = new SqlParameter[2];
            arparams[0] = new SqlParameter("@customereventtestid", SqlDbType.BigInt);
            arparams[0].Value = customereventtestid;
            arparams[1] = new SqlParameter("@mode", SqlDbType.BigInt);
            arparams[1].Value = 0;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getcustomerbycustomereventtestid", arparams);

            var eventObject = new EEvent();
            var objEventCustomer = new EEventCustomer();
            objEventCustomer.Customer = new ECustomers();
            objEventCustomer.Customer.User = new EUser();
            objEventCustomer.Customer.User.HomeAddress = new EAddress();
            objEventCustomer.EventPackage = new EEventPackage();
            objEventCustomer.EventPackage.Package = new EPackage();
            objEventCustomer.Customer.BillingAddress = new EAddress();

            objEventCustomer.EventID = Convert.ToInt32(dstemp.Tables[0].Rows[0]["EventID"]);
            eventObject.EventDate = Convert.ToString(dstemp.Tables[0].Rows[0]["EventDate"]);
            eventObject.Name = Convert.ToString(dstemp.Tables[0].Rows[0]["EventName"]);
            eventObject.Prospect = new EProspect();
            eventObject.Prospect.OrganizationName = Convert.ToString(dstemp.Tables[0].Rows[0]["HostName"]);
            eventObject.Prospect.PhoneOffice = Convert.ToString(dstemp.Tables[0].Rows[0]["HostPhone"]);

            eventObject.Prospect.Address = new EAddress
            {
                Address1 = Convert.ToString(dstemp.Tables[0].Rows[0]["Address1"]),
                Address2 = Convert.ToString(dstemp.Tables[0].Rows[0]["Address2"]),
                Country = Convert.ToString(dstemp.Tables[0].Rows[0]["Country"]),
                City = Convert.ToString(dstemp.Tables[0].Rows[0]["City"]),
                State = Convert.ToString(dstemp.Tables[0].Rows[0]["State"]),
                Zip = Convert.ToString(dstemp.Tables[0].Rows[0]["ZipCode"])
            };

            objEventCustomer.Customer.CustomerID = Convert.ToInt32(dstemp.Tables[1].Rows[0]["CustomerID"]);
            objEventCustomer.Customer.NextCustomerID = Convert.ToInt32(dstemp.Tables[1].Rows[0]["NextCustomerID"]);
            objEventCustomer.NextCustomerEventTestID =
                Convert.ToInt32(dstemp.Tables[1].Rows[0]["NextCustomerEventTestID"]);

            objEventCustomer.Customer.User.FirstName = Convert.ToString(dstemp.Tables[1].Rows[0]["FirstName"]);
            objEventCustomer.Customer.User.LastName = Convert.ToString(dstemp.Tables[1].Rows[0]["LastName"]);

            objEventCustomer.Customer.Race = Convert.ToString(dstemp.Tables[1].Rows[0]["Race"]);
            objEventCustomer.Customer.Age = Convert.ToInt16(dstemp.Tables[1].Rows[0]["Age"]);
            objEventCustomer.Customer.IsHistoryFilled = Convert.ToBoolean(dstemp.Tables[1].Rows[0]["IsHistoryFilled"]);
            objEventCustomer.Customer.MyPicture = Convert.ToString(dstemp.Tables[1].Rows[0]["Picture"]);
            objEventCustomer.Customer.Weight = Convert.ToSingle(dstemp.Tables[1].Rows[0]["weight"]);

            objEventCustomer.Customer.Gender = Convert.ToString(dstemp.Tables[1].Rows[0]["gender"]);
            objEventCustomer.Customer.Height = Convert.ToString(dstemp.Tables[1].Rows[0]["Height"]);

            objEventCustomer.Customer.User.HomeAddress.Address1 = Convert.ToString(dstemp.Tables[1].Rows[0]["Address1"]);
            objEventCustomer.Customer.User.HomeAddress.Country =
                Convert.ToString(dstemp.Tables[1].Rows[0]["CountryName"]);
            objEventCustomer.Customer.User.HomeAddress.State = Convert.ToString(dstemp.Tables[1].Rows[0]["StateName"]);
            objEventCustomer.Customer.User.HomeAddress.City = Convert.ToString(dstemp.Tables[1].Rows[0]["CityName"]);
            objEventCustomer.Customer.User.HomeAddress.Zip = Convert.ToString(dstemp.Tables[1].Rows[0]["ZipCode"]);

            dstemp.Tables[2].DefaultView.RowFilter = "CustomerID = " + objEventCustomer.Customer.CustomerID;
            if (dstemp.Tables[2].DefaultView.Count > 0)
            {
                var objprimarycarephysician = new EPrimaryCarePhysician();
                objprimarycarephysician.FirstName = Convert.ToString(dstemp.Tables[2].DefaultView[0]["FirstName"]);
                objprimarycarephysician.LastName = Convert.ToString(dstemp.Tables[2].DefaultView[0]["LastName"]);
                objprimarycarephysician.Email = Convert.ToString(dstemp.Tables[2].DefaultView[0]["Email"]);
                objprimarycarephysician.PhoneNumber = Convert.ToString(dstemp.Tables[2].DefaultView[0]["PhoneNumber"]);

                if (Convert.ToInt32(dstemp.Tables[2].DefaultView[0]["PCPAddress"]) > 0)
                {
                    if (dstemp.Tables[2].DefaultView[0]["AddressID"] != DBNull.Value)
                    {
                        var pcpAddress = new EAddress();
                        pcpAddress.AddressID = Convert.ToInt32(dstemp.Tables[2].DefaultView[0]["AddressID"]);
                        pcpAddress.Address1 = Convert.ToString(dstemp.Tables[2].DefaultView[0]["Address1"]);
                        pcpAddress.Address2 = Convert.ToString(dstemp.Tables[2].DefaultView[0]["Address2"]);
                        pcpAddress.City = Convert.ToString(dstemp.Tables[2].DefaultView[0]["City"]);
                        pcpAddress.CityID = Convert.ToInt32(dstemp.Tables[2].DefaultView[0]["CityID"]);
                        pcpAddress.Country = Convert.ToString(dstemp.Tables[2].DefaultView[0]["Country"]);
                        pcpAddress.CountryID = Convert.ToInt32(dstemp.Tables[2].DefaultView[0]["CountryID"]);
                        pcpAddress.State = Convert.ToString(dstemp.Tables[2].DefaultView[0]["State"]);
                        pcpAddress.StateID = Convert.ToInt32(dstemp.Tables[2].DefaultView[0]["StateID"]);
                        pcpAddress.Zip = Convert.ToString(dstemp.Tables[2].DefaultView[0]["ZipCode"]);
                        objprimarycarephysician.PCPAddress = pcpAddress;
                    }
                }
                objEventCustomer.Customer.PrimaryCarePhysician = objprimarycarephysician;
            }
            eventObject.Customer = new List<EEventCustomer>();
            eventObject.Customer.Add(objEventCustomer);
            return eventObject;
        }

        /// <summary>
        /// Fetches a Customers Biling Information, for the purpose of payment processing
        /// at the time of event, by technicians
        /// </summary>
        /// <param name="eventcustomerid"></param>
        /// <returns></returns>
        public DataSet GetCustomerBillingInformation(int eventcustomerid)
        {
            var arparam = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparam.Value = eventcustomerid;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getpaymentdetail", arparam);
            return dstemp;
        }

        /// <summary>
        /// Fetches Customers total amout payable
        /// </summary>
        /// <param name="eventcustomerid"></param>
        /// <returns></returns>
        public DataSet GetAmountPayable(int eventcustomerid)
        {
            var arparam = new SqlParameter("@eventcustomerid", SqlDbType.BigInt);
            arparam.Value = eventcustomerid;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getamountpayable", arparam);
            return dstemp;
        }

        public Int64 RemoveCustomer(int userid)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@userid", SqlDbType.VarChar, 3000);
            arParms[0].Value = userid;
            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_removecustomer", arParms);
            returnvalue = (Int64)arParms[1].Value;
            return returnvalue;
        }

        public List<ECustomerSurveyQuestion> GetAllCustomerSurveyQuestionsAnswers()
        {
            DataSet dsTemp = SqlHelper.ExecuteDataset(_connectionString, "usp_GetAllCustomerSurveyQuestionsAnswers", null);
            var objlCustSurveyQues = new List<ECustomerSurveyQuestion>();
            foreach (DataRow dr in dsTemp.Tables[0].Rows)
            {
                var objCustSurveyQues = new ECustomerSurveyQuestion();
                objCustSurveyQues.CustomerSurveyQuestionID = Convert.ToInt32(dr["CustomerSurveyQuestionID"]);
                objCustSurveyQues.Question = Convert.ToString(dr["Question"]);

                dsTemp.Tables[1].DefaultView.RowFilter = "CustomerSurveyQuestionID=" +
                    dr["CustomerSurveyQuestionID"];
                objCustSurveyQues.Answer = new List<ECustomerSurveyQuestionAnswer>();
                foreach (DataRowView drRow in dsTemp.Tables[1].DefaultView)
                {
                    var objCustSurveyQuesAns = new ECustomerSurveyQuestionAnswer();
                    objCustSurveyQuesAns.CustomerSurveyQuestionAnswerID =
                        Convert.ToInt32(drRow["CustomerSurveyQuestionAnswerID"]);
                    objCustSurveyQuesAns.CustomerSurveyQuestionID = Convert.ToInt32(drRow["CustomerSurveyQuestionID"]);
                    objCustSurveyQuesAns.Answer = Convert.ToString(drRow["Answer"]);
                    objCustSurveyQuesAns.IsShowTextBox = Convert.ToBoolean(drRow["IsShowTextBox"]);

                    objCustSurveyQues.Answer.Add(objCustSurveyQuesAns);
                }

                objlCustSurveyQues.Add(objCustSurveyQues);
            }

            return objlCustSurveyQues;
        }

        public Int64 SaveCustomerSurvey(List<ECustomerSurvey> objlCustSurvey)
        {
            var returnvalue = new Int64();
            for (int count = 0; count < objlCustSurvey.Count; count++)
            {
                var arPrms = new SqlParameter[8];

                arPrms[0] = new SqlParameter("@CustomerSurveyID", SqlDbType.BigInt);
                arPrms[0].Value = objlCustSurvey[count].CustomerSurveyID;

                arPrms[1] = new SqlParameter("@CustomerID", SqlDbType.BigInt);
                arPrms[1].Value = objlCustSurvey[count].CustomerID;

                arPrms[2] = new SqlParameter("@CustomerSurveyQuestionAnswerID", SqlDbType.BigInt);
                arPrms[2].Value = objlCustSurvey[count].CustomerSurveyQuestionAnswerID;

                arPrms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                arPrms[3].Value = objlCustSurvey[count].IsActive;

                arPrms[4] = new SqlParameter("@DateCreated", SqlDbType.VarChar, 20);
                arPrms[4].Value = objlCustSurvey[count].DateCreated;

                arPrms[5] = new SqlParameter("@DateModified", SqlDbType.VarChar, 20);
                arPrms[5].Value = objlCustSurvey[count].DateModified;

                arPrms[6] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arPrms[6].Direction = ParameterDirection.Output;

                arPrms[7] = new SqlParameter("@TextBoxValue", SqlDbType.VarChar, 1000);
                if (objlCustSurvey[count].TextBoxValue != null && objlCustSurvey[count].TextBoxValue.Trim().Length > 0)
                {
                    arPrms[7].Value = objlCustSurvey[count].TextBoxValue;
                }
                else
                {
                    arPrms[7].Value = DBNull.Value;
                }
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_SaveCustomerSurvey",
                    arPrms);
                returnvalue = Convert.ToInt64(arPrms[6].Value);
            }
            return returnvalue;
        }

        #endregion

        # region "Host"

        public List<EHost> GetHost(String filterString, int inputMode)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            var tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_gethost",
                arParms);

            var returnHost = ParseHostDataSet(tempdataset);
            return returnHost;
        }

        private List<EHost> ParseHostDataSet(DataSet hostDataSet)
        {
            var returnHost = new List<EHost>();

            for (int count = 0; count < hostDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var host = new EHost();
                    var hosttype = new EHostType();
                    var address = new EAddress();
                    var hostcontactp = new EHostContacts();
                    var hostcontacts = new EHostContacts();

                    host.Active = Convert.ToBoolean(hostDataSet.Tables[0].Rows[count]["IsActive"]);
                    host.HostID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["HostID"]);
                    host.WebAddress = Convert.ToString(hostDataSet.Tables[0].Rows[count]["WebAddress"]);
                    host.Map = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Map"]);
                    host.MethodObtainedID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["MethodObtainedID"]);
                    host.HostSize = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["HostSize"]);
                    host.Name = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Name"]);
                    host.PhoneCell = Convert.ToString(hostDataSet.Tables[0].Rows[count]["PhoneCell"]);
                    host.PhoneHome = Convert.ToString(hostDataSet.Tables[0].Rows[count]["PhoneHome"]);
                    host.PhoneOffice = Convert.ToString(hostDataSet.Tables[0].Rows[count]["PhoneOffice"]);
                    host.EMail1 = Convert.ToString(hostDataSet.Tables[0].Rows[count]["EMail1"]);
                    host.EMail2 = Convert.ToString(hostDataSet.Tables[0].Rows[count]["EMail2"]);

                    hostcontactp.ContactID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["PrimaryContactID"]);
                    hostcontactp.FirstName = Convert.ToString(hostDataSet.Tables[0].Rows[count]["FNamep"]);
                    hostcontactp.MiddleName = Convert.ToString(hostDataSet.Tables[0].Rows[count]["MNamep"]);
                    hostcontactp.LastName = Convert.ToString(hostDataSet.Tables[0].Rows[count]["LNamep"]);
                    hostcontactp.Phone1 = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Phone1p"]);
                    hostcontactp.Phone2 = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Phone2p"]);
                    hostcontactp.Phone1Extension = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Ext1p"]);
                    hostcontactp.Phone2Extension = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Ext2p"]);
                    hostcontactp.Fax = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Faxp"]);
                    hostcontactp.EMail = Convert.ToString(hostDataSet.Tables[0].Rows[count]["EMailp"]);
                    hostcontactp.Title = Convert.ToString(hostDataSet.Tables[0].Rows[count]["titile1"]);
                    if (hostDataSet.Tables[0].Rows[count]["PCPP"] != DBNull.Value)
                    {
                        hostcontactp.Primary = Convert.ToBoolean(hostDataSet.Tables[0].Rows[count]["PCPP"]);
                    }

                    if (hostDataSet.Tables[0].Rows[count]["SecondaryContactID"] != DBNull.Value)
                    {
                        hostcontacts.ContactID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["SecondaryContactID"]);
                        hostcontacts.FirstName = Convert.ToString(hostDataSet.Tables[0].Rows[count]["FirstName"]);
                        hostcontacts.MiddleName = Convert.ToString(hostDataSet.Tables[0].Rows[count]["MiddleName"]);
                        hostcontacts.LastName = Convert.ToString(hostDataSet.Tables[0].Rows[count]["LastName"]);
                        hostcontacts.Phone1 = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Phone1"]);
                        hostcontacts.Phone2 = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Phone2"]);
                        hostcontacts.Phone1Extension =
                            Convert.ToString(hostDataSet.Tables[0].Rows[count]["Phone1Extension"]);
                        hostcontacts.Phone2Extension =
                            Convert.ToString(hostDataSet.Tables[0].Rows[count]["Phone2Extension"]);
                        hostcontacts.Fax = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Fax"]);
                        hostcontacts.EMail = Convert.ToString(hostDataSet.Tables[0].Rows[count]["EMail"]);
                        hostcontacts.Primary = Convert.ToBoolean(hostDataSet.Tables[0].Rows[count]["IsPrimaryContact"]);
                        hostcontacts.Title = Convert.ToString(hostDataSet.Tables[0].Rows[count]["titile2"]);
                    }

                    hosttype.HostTypeID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["HostTypeID"]);
                    address.AddressID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["AddressID"]);
                    address.Address1 = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Address1"]);
                    address.Address2 = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Address2"]);
                    address.City = Convert.ToString(hostDataSet.Tables[0].Rows[count]["City"]);
                    address.CityID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["CityID"]);
                    address.State = Convert.ToString(hostDataSet.Tables[0].Rows[count]["State"]);
                    address.StateID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["StateID"]);
                    address.Country = Convert.ToString(hostDataSet.Tables[0].Rows[count]["Country"]);
                    address.CountryID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["CountryID"]);
                    address.ZipID = Convert.ToInt32(hostDataSet.Tables[0].Rows[count]["ZipCode"]);


                    if (hostDataSet.Tables[1].Rows.Count > 0)
                    {
                        var note = new List<ENoteCommon>();
                        int fcount = 0;
                        DataTable tblnote = hostDataSet.Tables[1];
                        tblnote.DefaultView.RowFilter = "HostID = " + host.HostID;
                        while (fcount < tblnote.DefaultView.Count)
                        {
                            var enote = new ENoteCommon();

                            enote.Notes = tblnote.DefaultView[fcount]["Notes"].ToString();
                            enote.NoteSequence = Convert.ToInt32(tblnote.DefaultView[fcount]["NotesSequence"]);
                            note.Add(enote);
                            fcount++;
                        }

                        host.NoteCommon = note;
                    }
                    host.HostType = hosttype;
                    host.HostContacts = hostcontacts;
                    host.PrimaryContact = hostcontactp;
                    host.Address = address;


                    returnHost.Add(host);
                }
                catch
                { }
            }
            return returnHost;
        }

        #endregion

        # region "Task"

        public Int64 SaveTask(ETask task, int Mode, string UserID, string Shell, string Role)
        {
            var returnvalue = new Int64();
            var arParms = new SqlParameter[21];

            arParms[0] = new SqlParameter("@taskid", SqlDbType.BigInt);
            arParms[0].Value = task.TaskID;
            arParms[1] = new SqlParameter("@tasksubject", SqlDbType.VarChar, 500);
            arParms[1].Value = task.Subject;
            arParms[2] = new SqlParameter("@notes", SqlDbType.VarChar, 1000);
            if (task.Notes == null || task.Notes == String.Empty)
            {
                arParms[2].Value = DBNull.Value;
            }
            else
            {
                arParms[2].Value = task.Notes;
            }
            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 500);
            if (task.StartDate == null || task.StartDate == String.Empty)
            {
                arParms[3].Value = DBNull.Value;
            }
            else
            {
                arParms[3].Value = task.StartDate;
            }
            arParms[4] = new SqlParameter("@starttime", SqlDbType.VarChar, 500);
            if (task.StartTime == null || task.StartTime == String.Empty)
            {
                arParms[4].Value = DBNull.Value;
            }
            else
            {
                arParms[4].Value = task.StartTime;
            }

            arParms[5] = new SqlParameter("@duedate", SqlDbType.VarChar, 500);
            if (task.DueDate != null && task.DueDate != "")
            {
                arParms[5].Value = task.DueDate;
            }
            else
            {
                arParms[5].Value = DBNull.Value;
            }


            arParms[6] = new SqlParameter("@duetime", SqlDbType.VarChar, 500);
            if (task.DueTime != null && task.DueTime != "")
            {
                arParms[6].Value = task.DueTime;
            }
            else
            {
                arParms[6].Value = DBNull.Value;
            }


            arParms[7] = new SqlParameter("@taskstatusid", SqlDbType.BigInt);
            if (task.TaskStatusType.TaskStatusTypeID == 0)
            {
                arParms[7].Value = DBNull.Value;
            }
            else
            {
                arParms[7].Value = task.TaskStatusType.TaskStatusTypeID;
            }

            arParms[8] = new SqlParameter("@taskpriorityid", SqlDbType.BigInt);
            if (task.TaskPriorityType.TaskPriorityTypeID == 0)
            {
                arParms[8].Value = DBNull.Value;
            }
            else
            {
                arParms[8].Value = task.TaskPriorityType.TaskPriorityTypeID;
            }
            arParms[9] = new SqlParameter("@createdby", SqlDbType.BigInt);
            arParms[9].Value = task.CreatedBY;
            arParms[10] = new SqlParameter("@modifiedby", SqlDbType.BigInt);
            arParms[10].Value = task.ModifiedBY;

            arParms[11] = new SqlParameter("@assignedTouserid", SqlDbType.BigInt);
            if (task.UserShellModule.UserID != null && task.UserShellModule.UserID != "")
            {
                arParms[11].Value = task.UserShellModule.UserID;
            }
            else
            {
                arParms[11].Value = DBNull.Value;
            }

            arParms[12] = new SqlParameter("@assignedToshellid", SqlDbType.BigInt);
            if (task.UserShellModule.ShellID != null && task.UserShellModule.ShellID != "")
            {
                arParms[12].Value = task.UserShellModule.ShellID;
            }
            else
            {
                arParms[12].Value = DBNull.Value;
            }

            arParms[13] = new SqlParameter("@assignedToroleid", SqlDbType.BigInt);
            if (task.UserShellModule.RoleID != null && task.UserShellModule.RoleID != "")
            {
                arParms[13].Value = task.UserShellModule.RoleID;
            }
            else
            {
                arParms[13].Value = DBNull.Value;
            }

            arParms[14] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[14].Value = Mode;


            arParms[15] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[15].Value = UserID;
            arParms[16] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[16].Value = Shell;
            arParms[17] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[17].Value = Role;
            arParms[18] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[18].Direction = ParameterDirection.Output;

            arParms[19] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[19].Value = task.ProspectID;

            arParms[20] = new SqlParameter("@contactid", SqlDbType.BigInt);
            arParms[20].Value = task.ContactID;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_savetaskdetails", arParms);

            returnvalue = (Int64)arParms[18].Value;
            return returnvalue;
        }

        private List<ETask> ParseTaskDataSet(DataSet taskDataSet)
        {
            var returnTask = new List<ETask>();

            for (int count = 0; count < taskDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var task = new ETask();
                    //ETaskType tasktype = new ETaskType();
                    //ETaskStatusType taskstatustype = new ETaskStatusType();
                    //ETaskPriorityType taskprioritytype = new ETaskPriorityType();
                    task.TaskPriorityType = new ETaskPriorityType();
                    task.TaskStatusType = new ETaskStatusType();
                    task.UserShellModule = new EUserShellModuleRole();

                    task.DueDate = Convert.ToString(taskDataSet.Tables[0].Rows[count]["DueDate"]);
                    task.DueTime = Convert.ToString(taskDataSet.Tables[0].Rows[count]["DueTime"]);
                    task.Subject = Convert.ToString(taskDataSet.Tables[0].Rows[count]["Subject"]);
                    task.Notes = Convert.ToString(taskDataSet.Tables[0].Rows[count]["Notes"]);
                    task.StartDate = Convert.ToString(taskDataSet.Tables[0].Rows[count]["StartDate"]);
                    task.StartTime = Convert.ToString(taskDataSet.Tables[0].Rows[count]["StartTime"]);
                    task.ModifiedBY = Convert.ToInt32(taskDataSet.Tables[0].Rows[count]["ModifiedBy"]);
                    task.CreatedBY = Convert.ToInt32(taskDataSet.Tables[0].Rows[count]["CreatedBy"]);

                    task.TaskPriorityType.TaskPriorityTypeID =
                        Convert.ToInt32(taskDataSet.Tables[0].Rows[count]["TaskPriorityID"]);

                    task.TaskStatusType.TaskStatusTypeID =
                        Convert.ToInt32(taskDataSet.Tables[0].Rows[count]["TaskStatusID"]);
                    task.TaskID = Convert.ToInt32(taskDataSet.Tables[0].Rows[count]["TaskID"]);
                    task.Active = Convert.ToBoolean(taskDataSet.Tables[0].Rows[count]["IsActive"]);
                    task.Contact = Convert.ToString(taskDataSet.Tables[0].Rows[count]["Contact"]);


                    task.UserShellModule.UserName = Convert.ToString(taskDataSet.Tables[0].Rows[count]["Assigned"]);
                    task.UserShellModule.RoleID = Convert.ToString(taskDataSet.Tables[0].Rows[count]["AssignedToRoleID"]);
                    task.UserShellModule.ShellID =
                        Convert.ToString(taskDataSet.Tables[0].Rows[count]["AssignedToShellID"]);
                    task.UserShellModule.UserID = Convert.ToString(taskDataSet.Tables[0].Rows[count]["AssignedToUserID"]);
                    task.UserShellModule.RoleName = Convert.ToString(taskDataSet.Tables[0].Rows[count]["AssignedToRole"]);
                    task.UserShellModule.ShellName =
                        Convert.ToString(taskDataSet.Tables[0].Rows[count]["AssignedToShell"]);

                    task.TaskPriorityType.Name = Convert.ToString(taskDataSet.Tables[0].Rows[count]["PriorityTypesName"]);
                    task.TaskStatusType.Name = Convert.ToString(taskDataSet.Tables[0].Rows[count]["StatusTypesName"]);
                    returnTask.Add(task);
                }

                catch
                { }
            }
            return returnTask;
        }


        private List<EContactMeeting> ParseMeetingDataSet(DataSet meetingDataSet)
        {
            var returnMeeting = new List<EContactMeeting>();

            for (int count = 0; count < meetingDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var meeting = new EContactMeeting();
                    meeting.UserShellModule = new EUserShellModuleRole();

                    meeting.Contact = new EContact();
                    meeting.CallStatus = new ECallStatus();


                    meeting.ContactMeetingID = Convert.ToInt32(meetingDataSet.Tables[0].Rows[count]["ContactMeetingID"]);
                    if (meetingDataSet.Tables[0].Rows[count]["ProspectName"] != null)
                    {
                        meeting.ProspectName = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["ProspectName"]);
                    }

                    meeting.Description = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["Description"]);
                    meeting.CallStatus.CallStatusID =
                        Convert.ToInt32(meetingDataSet.Tables[0].Rows[count]["ContactMeetingStatusID"]);

                    if (meetingDataSet.Tables[0].Rows[count]["Starttime"] != DBNull.Value)
                    {
                        meeting.StartTime = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["Starttime"]);
                    }
                    else
                    {
                        meeting.StartTime = null;
                    }

                    meeting.AssignedToUserId = Convert.ToInt32(meetingDataSet.Tables[0].Rows[count]["AssignedToUserId"]);
                    meeting.AssignedToShellID =
                        Convert.ToInt32(meetingDataSet.Tables[0].Rows[count]["AssignedToShellID"]);
                    meeting.AssignedToRoleID = Convert.ToInt32(meetingDataSet.Tables[0].Rows[count]["AssignedToRoleID"]);
                    meeting.Venue = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["MeetingVenue"]);

                    meeting.Reminder = Convert.ToBoolean(meetingDataSet.Tables[0].Rows[count]["Reminder"]);

                    meeting.CreatedByUserId = Convert.ToInt32(meetingDataSet.Tables[0].Rows[count]["CreatedByUserId"]);
                    meeting.CreatedByShellID = Convert.ToInt32(meetingDataSet.Tables[0].Rows[count]["CreatedByShellID"]);
                    meeting.CreatedByRoleID = Convert.ToInt32(meetingDataSet.Tables[0].Rows[count]["CreatedByRoleID"]);


                    meeting.Contact.ContactID = Convert.ToInt32(meetingDataSet.Tables[0].Rows[count]["ContactID"]);


                    meeting.Subject = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["Subject"]);
                    meeting.Duration = Convert.ToDecimal(meetingDataSet.Tables[0].Rows[count]["Duration"]);

                    if (meetingDataSet.Tables[0].Rows[count]["StartDate"] != DBNull.Value)
                    {
                        meeting.StartDate = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["StartDate"]);
                    }
                    else
                    {
                        meeting.StartDate = null;
                    }

                    meeting.Contact.FirstName = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["FirstName"]);
                    meeting.Contact.LastName = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["LastName"]);

                    //meeting.UserShellModule.UserName = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["AssignedTo"]);
                    //meeting.UserShellModule.RoleName = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["AssignedToRole"]);
                    //meeting.UserShellModule.ShellName = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["AssignedToShell"]);
                    meeting.CallStatus.Status = Convert.ToString(meetingDataSet.Tables[0].Rows[count]["Status"]);

                    returnMeeting.Add(meeting);
                }

                catch
                { }
            }
            if (meetingDataSet.Tables.Count > 1)
            {
                if (meetingDataSet.Tables[1].Rows.Count > 0)
                {
                    if (returnMeeting.Count > 0)
                    {
                        returnMeeting[0].ProspectName =
                            Convert.ToString(meetingDataSet.Tables[1].Rows[0]["ProspectName"]);
                    }
                }
            }

            return returnMeeting;
        }

        public Int64 SaveCall(EContactCall call, int Mode)
        {
            var arParms = new SqlParameter[22];

            arParms[0] = new SqlParameter("@contactcallid", SqlDbType.BigInt);
            arParms[0].Value = call.ContactCallID;
            arParms[1] = new SqlParameter("@contactid", SqlDbType.BigInt);
            if (call.Contact.ContactID == 0)
            {
                arParms[1].Value = DBNull.Value;
            }
            else
            {
                arParms[1].Value = call.Contact.ContactID;
            }

            arParms[2] = new SqlParameter("@callsubject", SqlDbType.VarChar, 1500);
            arParms[2].Value = call.Subject;
            arParms[3] = new SqlParameter("@notes", SqlDbType.VarChar, 5000);
            arParms[3].Value = call.Notes;

            arParms[4] = new SqlParameter("@startdate", SqlDbType.VarChar, 500);
            if (!string.IsNullOrEmpty(call.StartDate))
            {
                arParms[4].Value = call.StartDate;
            }
            else
            {
                arParms[4].Value = DBNull.Value;
            }

            arParms[5] = new SqlParameter("@starttime", SqlDbType.VarChar, 500);
            if (!string.IsNullOrEmpty(call.StartTime))
            {
                arParms[5].Value = call.StartTime;
            }
            else
            {
                arParms[5].Value = DBNull.Value;
            }

            arParms[6] = new SqlParameter("@contactcallstatusid", SqlDbType.BigInt);
            if (call.CallStatus.CallStatusID > 0)
            {
                arParms[6].Value = call.CallStatus.CallStatusID;
            }
            else
            {
                arParms[6].Value = DBNull.Value;
            }
            arParms[7] = new SqlParameter("@isinbound", SqlDbType.Bit);
            arParms[7].Value = call.IsInbound;
            arParms[8] = new SqlParameter("@duration", SqlDbType.Decimal);
            arParms[8].Value = call.Duration;
            arParms[9] = new SqlParameter("@assignedtouserid", SqlDbType.BigInt);
            arParms[9].Value = call.AssignedToUserId;
            arParms[10] = new SqlParameter("@assignedtoshellid", SqlDbType.BigInt);
            arParms[10].Value = call.AssignedToShellID;
            arParms[11] = new SqlParameter("@assignedtoroleid", SqlDbType.BigInt);
            arParms[11].Value = call.AssignedToRoleID;
            arParms[12] = new SqlParameter("@createdbyuserid", SqlDbType.BigInt);
            arParms[12].Value = call.CreatedByUserId;
            arParms[13] = new SqlParameter("@createdbyshellid", SqlDbType.BigInt);
            arParms[13].Value = call.CreatedByShellID;
            arParms[14] = new SqlParameter("@createdbyroleid", SqlDbType.BigInt);
            arParms[14].Value = call.CreatedByRoleID;
            arParms[15] = new SqlParameter("@reminder", SqlDbType.Bit);
            arParms[15].Value = call.Reminder;
            arParms[16] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[16].Value = Mode;
            arParms[17] = new SqlParameter("@isactive", SqlDbType.Bit);
            arParms[17].Value = call.IsActive;
            arParms[18] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[18].Direction = ParameterDirection.Output;

            arParms[19] = new SqlParameter("@callresult", SqlDbType.Int);
            arParms[19].Value = call.CallResult;

            arParms[20] = new SqlParameter("@futureaction", SqlDbType.Int);
            arParms[20].Value = call.FutureAction;

            arParms[21] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[21].Value = call.ProspectID;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveContactCall", arParms);

            return (Int64)arParms[21].Value;
        }

        public Int64 SaveMeeting(EContactMeeting Meeting, int Mode)
        {

            var arParms = new SqlParameter[22];

            arParms[0] = new SqlParameter("@contactmeetingid", SqlDbType.BigInt);
            arParms[0].Value = Meeting.ContactMeetingID;
            arParms[1] = new SqlParameter("@contactid", SqlDbType.BigInt);
            if (Meeting.Contact.ContactID == 0)
            {
                arParms[1].Value = DBNull.Value;
            }
            else
            {
                arParms[1].Value = Meeting.Contact.ContactID;
            }

            arParms[2] = new SqlParameter("@meetingsubject", SqlDbType.VarChar, 1500);
            arParms[2].Value = Meeting.Subject;
            arParms[3] = new SqlParameter("@description", SqlDbType.VarChar, 5000);
            arParms[3].Value = Meeting.Description;

            arParms[4] = new SqlParameter("@startdate", SqlDbType.DateTime);
            if (Meeting.StartDate != null && Meeting.StartDate != "")
            {
                arParms[4].Value = Convert.ToDateTime(Meeting.StartDate);
            }
            else
            {
                arParms[4].Value = DBNull.Value;
            }

            arParms[5] = new SqlParameter("@starttime", SqlDbType.DateTime);
            if (Meeting.StartTime != null && Meeting.StartTime != "")
            {
                arParms[5].Value = Convert.ToDateTime(Meeting.StartTime);
            }
            else
            {
                arParms[5].Value = DBNull.Value;
            }

            arParms[6] = new SqlParameter("@contactmeetingstatusid", SqlDbType.BigInt);
            if (Meeting.CallStatus.CallStatusID > 0)
            {
                arParms[6].Value = Meeting.CallStatus.CallStatusID;
            }
            else
            {
                arParms[6].Value = DBNull.Value;
            }
            arParms[7] = new SqlParameter("@meetingvenue", SqlDbType.VarChar, 5000);
            arParms[7].Value = Meeting.Venue;
            arParms[8] = new SqlParameter("@duration", SqlDbType.Decimal);
            arParms[8].Value = Meeting.Duration;
            arParms[9] = new SqlParameter("@assignedtouserid", SqlDbType.BigInt);
            arParms[9].Value = Meeting.AssignedToUserId;
            arParms[10] = new SqlParameter("@assignedtoshellid", SqlDbType.BigInt);
            arParms[10].Value = Meeting.AssignedToShellID;
            arParms[11] = new SqlParameter("@assignedtoroleid", SqlDbType.BigInt);
            arParms[11].Value = Meeting.AssignedToRoleID;
            arParms[12] = new SqlParameter("@createdbyuserid", SqlDbType.BigInt);
            arParms[12].Value = Meeting.CreatedByUserId;
            arParms[13] = new SqlParameter("@createdbyshellid", SqlDbType.BigInt);
            arParms[13].Value = Meeting.CreatedByShellID;
            arParms[14] = new SqlParameter("@createdbyroleid", SqlDbType.BigInt);
            arParms[14].Value = Meeting.CreatedByRoleID;
            arParms[15] = new SqlParameter("@reminder", SqlDbType.Bit);
            arParms[15].Value = Meeting.Reminder;
            arParms[16] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[16].Value = Mode;

            arParms[17] = new SqlParameter("@isactive", SqlDbType.Bit);
            arParms[17].Value = Meeting.IsActive;
            arParms[18] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[18].Direction = ParameterDirection.Output;

            arParms[19] = new SqlParameter("@ProspectID", SqlDbType.BigInt);
            arParms[19].Value = Meeting.ProspectID;

            arParms[20] = new SqlParameter("@FollowUpDate", SqlDbType.DateTime);
            if (!string.IsNullOrEmpty(Meeting.FollowUpDate))
            {
                arParms[20].Value = Convert.ToDateTime(Meeting.FollowUpDate);
            }
            else
            {
                arParms[20].Value = DBNull.Value;
            }

            arParms[21] = new SqlParameter("@MeetingType", SqlDbType.Int);
            arParms[21].Value = Meeting.MeetingType;


            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_saveContactMeeting", arParms);

            return (Int64)arParms[18].Value;

        }

        public List<ETask> GetTask(String filterString, int inputMode, int userid, int shellid, int roleid)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            arParms[2] = new SqlParameter("@userid", SqlDbType.Int);
            arParms[2].Value = userid;
            arParms[3] = new SqlParameter("@shellid", SqlDbType.Int);
            arParms[3].Value = shellid;
            arParms[4] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[4].Value = roleid;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_gettaskdetails",
                arParms);

            var returnTask = new List<ETask>();
            returnTask = ParseTaskDataSet(tempdataset);
            return returnTask;
        }


        #endregion

        # region Calls

        public List<EContactCall> GetCalls(String filterString, int inputMode, long orgRoleUserId, Int64 iProspectID)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            arParms[2] = new SqlParameter("@OrganizationRoleUserId", SqlDbType.Int);
            arParms[2].Value = orgRoleUserId;

            arParms[3] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[3].Value = iProspectID;

            var callDataSet = new DataSet();
            callDataSet = SqlHelper.ExecuteDataset(_connectionString, "usp_getcalldetails",
                arParms);

            var returnCall = new List<EContactCall>();

            for (int count = 0; count < callDataSet.Tables[0].Rows.Count; count++)
            {
                var call = new EContactCall();

                call.UserShellModule = new EUserShellModuleRole();
                call.Contact = new EContact();
                call.CallStatus = new ECallStatus();

                if (callDataSet.Tables[0].Rows[count]["ContactCallID"] != DBNull.Value &&
                    Convert.ToString(callDataSet.Tables[0].Rows[count]["ContactCallID"]) != "")
                {
                    call.ContactCallID = Convert.ToInt32(callDataSet.Tables[0].Rows[count]["ContactCallID"]);
                }

                call.Subject = Convert.ToString(callDataSet.Tables[0].Rows[count]["Subject"]);
                call.Duration = Convert.ToDecimal(callDataSet.Tables[0].Rows[count]["Duration"]);

                call.StartDate = Convert.ToString(callDataSet.Tables[0].Rows[count]["StartDate"]);
                call.Notes = Convert.ToString(callDataSet.Tables[0].Rows[count]["Notes"]);

                if (callDataSet.Tables[0].Rows[count]["ContactCallStatusID"] != DBNull.Value &&
                    Convert.ToString(callDataSet.Tables[0].Rows[count]["ContactCallStatusID"]) != "")
                {
                    call.CallStatus.CallStatusID =
                        Convert.ToInt32(callDataSet.Tables[0].Rows[count]["ContactCallStatusID"]);
                }
                if (callDataSet.Tables[0].Rows[count]["IsInbound"] != DBNull.Value &&
                    Convert.ToString(callDataSet.Tables[0].Rows[count]["IsInbound"]) != "")
                {
                    call.IsInbound = Convert.ToBoolean(callDataSet.Tables[0].Rows[count]["IsInbound"]);
                }

                call.StartTime = Convert.ToString(callDataSet.Tables[0].Rows[count]["Starttime"]);

                call.AssignedToUserId = Convert.ToInt32(callDataSet.Tables[0].Rows[count]["AssignedToUserId"]);

                call.AssignedToShellID = Convert.ToInt32(callDataSet.Tables[0].Rows[count]["AssignedToShellID"]);
                call.AssignedToRoleID = Convert.ToInt32(callDataSet.Tables[0].Rows[count]["AssignedToRoleID"]);

                call.Reminder = Convert.ToBoolean(callDataSet.Tables[0].Rows[count]["Reminder"]);

                call.CreatedByUserId = Convert.ToInt32(callDataSet.Tables[0].Rows[count]["CreatedByUserId"]);
                call.CreatedByShellID = Convert.ToInt32(callDataSet.Tables[0].Rows[count]["CreatedByShellID"]);
                call.CreatedByRoleID = Convert.ToInt32(callDataSet.Tables[0].Rows[count]["CreatedByRoleID"]);
                call.CallResult = Convert.ToInt32(callDataSet.Tables[0].Rows[count]["CallResult"]);
                call.Contact.FirstName = Convert.ToString(callDataSet.Tables[0].Rows[count]["FirstName"]);
                call.Contact.LastName = Convert.ToString(callDataSet.Tables[0].Rows[count]["LastName"]);
                call.CallStatus.Status = Convert.ToString(callDataSet.Tables[0].Rows[count]["Status"]);
                returnCall.Add(call);
            }
            if (callDataSet.Tables.Count > 1)
            {
                if (callDataSet.Tables[1].Rows.Count > 0)
                {
                    if (returnCall.Count > 0)
                    {
                        returnCall[0].ProspectName = Convert.ToString(callDataSet.Tables[1].Rows[0]["ProspectName"]);
                    }
                }
            }

            return returnCall;
        }

        public List<EContactCall> GetCallForCalendar(long franchiseeId, long salesrepId, string hostName,
            string strStartDate,
            string strEndDate, Int16 mode)
        {
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@hostname", SqlDbType.VarChar, 100);
            arParms[0].Value = hostName;
            arParms[1] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            arParms[1].Value = franchiseeId;
            arParms[2] = new SqlParameter("@salesrepid", SqlDbType.BigInt);
            arParms[2].Value = salesrepId;

            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 30);
            arParms[3].Value = strStartDate;
            arParms[4] = new SqlParameter("@enddate", SqlDbType.VarChar, 30);
            arParms[4].Value = strEndDate;
            arParms[5] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[5].Value = mode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getCallForCalendar", arParms);
            var objListCall = new List<EContactCall>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var objCall = new EContactCall();
                    objCall.Subject = Convert.ToString(tempdataset.Tables[0].Rows[count]["Subject"]);
                    objCall.StartDate = Convert.ToString(tempdataset.Tables[0].Rows[count]["StartDate"]);
                    objCall.StartTime = Convert.ToString(tempdataset.Tables[0].Rows[count]["StartTime"]);
                    objCall.ContactCallID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["ContactCallID"]);

                    objCall.CallStatus = new ECallStatus();
                    objCall.CallStatus.Status = Convert.ToString(tempdataset.Tables[0].Rows[count]["Status"]);

                    objCall.Duration = Convert.ToDecimal(tempdataset.Tables[0].Rows[count]["Duration"]);
                    objCall.Reminder = Convert.ToBoolean(tempdataset.Tables[0].Rows[count]["Reminder"]);

                    objCall.Contact = new EContact();
                    objCall.Contact.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[count]["FirstName"]);
                    objCall.Contact.LastName = Convert.ToString(tempdataset.Tables[0].Rows[count]["LastName"]);
                    objCall.Contact.Title = Convert.ToString(tempdataset.Tables[0].Rows[count]["Salutation"]);
                    objCall.Notes = Convert.ToString(tempdataset.Tables[0].Rows[count]["Notes"]);


                    objListCall.Add(objCall);
                }

                catch (Exception)
                { }
            }

            return objListCall;
        }

        public List<EContactCall> CheckUserShellRole(string userid, string roleid, string shellid)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@roleid", SqlDbType.VarChar, 50);
            arParms[0].Value = roleid;


            arParms[1] = new SqlParameter("@shellid", SqlDbType.VarChar, 50);
            arParms[1].Value = shellid;
            arParms[2] = new SqlParameter("@userid", SqlDbType.VarChar, 50);
            arParms[2].Value = userid;


            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_CheckUserShellRole", arParms);
            var objListCall = new List<EContactCall>();
            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                try
                {
                    var objCall = new EContactCall();
                    objCall.UserShellModule = new EUserShellModuleRole();

                    objCall.UserShellModule.RoleName = Convert.ToString(tempdataset.Tables[0].Rows[count]["RoleName"]);
                    objCall.UserShellModule.UserName = Convert.ToString(tempdataset.Tables[0].Rows[count]["UserName"]);
                    objCall.UserShellModule.ShellName = Convert.ToString(tempdataset.Tables[0].Rows[count]["ShellName"]);

                    objListCall.Add(objCall);
                }

                catch (Exception)
                { }
            }

            return objListCall;
        }


        /// <summary>
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="ProspectID"></param>
        /// <returns></returns>
        public List<EContactCall> GetCallsMeetingsTasks(int mode, Int64 ProspectID)
        {
            var arparams = new SqlParameter[2];

            arparams[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparams[0].Value = mode;
            arparams[1] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arparams[1].Value = ProspectID;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_getCallMeetingTask", arparams);
            var listcall = new List<EContactCall>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    try
                    {
                        var objcall = new EContactCall();

                        objcall.UserShellModule = new EUserShellModuleRole();
                        objcall.Contact = new EContact();
                        objcall.CallStatus = new ECallStatus();

                        // call details
                        objcall.Type = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Type"]);
                        objcall.ContactCallID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["ID"]);
                        objcall.Subject = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Subject"]);
                        objcall.Notes = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Notes"]);
                        objcall.Duration = Convert.ToDecimal(tempdataset.Tables[0].Rows[icount]["Duration"]);
                        objcall.StartDate = Convert.ToString(tempdataset.Tables[0].Rows[icount]["StartDate"]);
                        // contact details
                        if (tempdataset.Tables[0].Rows[icount]["ContactID"] != DBNull.Value)
                        {
                            objcall.Contact.ContactID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["ContactID"]);
                        }

                        if (tempdataset.Tables[0].Rows[icount]["ContactName"] != DBNull.Value)
                        {
                            objcall.Contact.FirstName =
                                Convert.ToString(tempdataset.Tables[0].Rows[icount]["ContactName"]);
                        }
                        else
                        {
                            objcall.Contact.FirstName = "";
                        }

                        if (tempdataset.Tables[0].Rows[icount]["AssignedToUserId"] != DBNull.Value)
                        {
                            objcall.AssignedToUserId =
                                Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["AssignedToUserId"]);
                        }
                        else
                        {
                            objcall.AssignedToUserId = 0;
                        }

                        if (tempdataset.Tables[0].Rows[icount]["Assignedby"] != DBNull.Value)
                        {
                            objcall.UserShellModule.UserName =
                                Convert.ToString(tempdataset.Tables[0].Rows[icount]["Assignedby"]);
                        }
                        else
                        {
                            objcall.UserShellModule.UserName = "";
                        }

                        objcall.StartTime = Convert.ToString(tempdataset.Tables[0].Rows[icount]["DateModified"]);

                        listcall.Add(objcall);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return listcall;
        }

        /// <summary>
        /// /// Get activity for event like calls and meetings and task.
        /// </summary>
        /// <param name="eventid"></param>
        /// <param name="pagenumber"></param>
        /// <param name="pagesize"></param>
        /// <param name="sortorder"></param>
        /// <param name="sortcolumn"></param>
        /// <param name="totalrecords"></param>
        /// <returns></returns>
        public List<EContactCall> GetEventActivity(Int64 eventid, int pagenumber, int pagesize, string sortorder,
            string sortcolumn, out int totalrecords)
        {
            var arparams = new SqlParameter[5];
            totalrecords = 0;
            // eventid
            arparams[0] = new SqlParameter("@eventid", SqlDbType.BigInt);
            arparams[0].Value = eventid;

            // pagenumber
            arparams[1] = new SqlParameter("@pagenumber", SqlDbType.Int);
            arparams[1].Value = pagenumber;

            // pagesize
            arparams[2] = new SqlParameter("@pagesize", SqlDbType.Int);
            arparams[2].Value = pagesize;

            // sortorder
            arparams[3] = new SqlParameter("@sortorder", SqlDbType.VarChar, 10);
            arparams[3].Value = sortorder;

            // sortcolumn
            arparams[4] = new SqlParameter("@sortcolumn", SqlDbType.VarChar, 255);
            arparams[4].Value = sortcolumn;


            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_GetEventActivityDetails", arparams);
            var listcall = new List<EContactCall>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    var objcall = new EContactCall();
                    objcall.CallStatus = new ECallStatus();

                    // activity date 
                    objcall.ContactCallID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["ID"]);
                    // days to event
                    objcall.CallResult = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["DaysToEvent"]);
                    // type (call/meeting/task)    
                    objcall.Type = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Type"]);
                    objcall.Subject = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Subject"]);
                    objcall.Notes = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Notes"]);
                    if (tempdataset.Tables[0].Rows[icount]["Date"] != DBNull.Value)
                    {
                        objcall.StartDate =
                            Convert.ToString(
                                Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["Date"]).ToString("MM/dd/yyyy"));
                    }
                    objcall.CallStatus.Status = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Status"]);

                    listcall.Add(objcall);
                }
            }

            if (tempdataset.Tables.Count > 1 && tempdataset.Tables[1].Rows.Count > 0)
            {
                totalrecords = Convert.ToInt32(tempdataset.Tables[1].Rows[0]["TotalRecord"]);
            }
            return listcall;
        }

        /// <summary>
        /// change activity status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="activitytype"></param>
        public void UpdateActivityStatus(Int64 id, string activitytype)
        {
            var arparams = new SqlParameter[2];

            // id
            arparams[0] = new SqlParameter("@id", SqlDbType.BigInt);
            arparams[0].Value = id;

            // activity type
            arparams[1] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            arparams[1].Value = activitytype;

            // execute query
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_UpdateActivityStatus",
                arparams);
        }

        /// <summary>
        ///  get call details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EContactCall GetActivityDetailsViewCall(Int64 id)
        {
            var arparams = new SqlParameter[2];
            var objCall = new EContactCall();
            objCall.CallStatus = new ECallStatus();

            // id
            arparams[0] = new SqlParameter("@id", SqlDbType.BigInt);
            arparams[0].Value = id;
            // activity type
            arparams[1] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            arparams[1].Value = "Call";

            // execute query
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_GetEventActivityDetailsView", arparams);

            if (tempdataset.Tables.Count > 0 && tempdataset.Tables[0].Rows.Count > 0)
            {
                objCall.ContactCallID = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["ContactCallID"]);
                objCall.Subject = Convert.ToString(tempdataset.Tables[0].Rows[0]["Subject"]);
                objCall.Notes = Convert.ToString(tempdataset.Tables[0].Rows[0]["Notes"]);
                // call date
                if (tempdataset.Tables[0].Rows[0]["CallDate"] != DBNull.Value)
                {
                    objCall.StartDate =
                        Convert.ToDateTime(tempdataset.Tables[0].Rows[0]["CallDate"]).ToString("MM/dd/yyyy");
                }
                else
                {
                    objCall.StartDate = "";
                }
                // call time
                if (tempdataset.Tables[0].Rows[0]["CallTime"] != DBNull.Value)
                {
                    objCall.StartTime =
                        Convert.ToDateTime(tempdataset.Tables[0].Rows[0]["CallTime"]).ToString("0:hh:mm tt");
                }
                else
                {
                    objCall.StartTime = "";
                }

                // duration
                objCall.Duration = Convert.ToDecimal(tempdataset.Tables[0].Rows[0]["Duration"]);
                // call status 
                objCall.CallStatus.Status = Convert.ToString(tempdataset.Tables[0].Rows[0]["Status"]);
            }
            return objCall;
        }

        /// <summary>
        ///  get meeting details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EContactMeeting GetActivityDetailsViewMeeting(Int64 id)
        {
            var arparams = new SqlParameter[2];
            var objMeeting = new EContactMeeting();
            objMeeting.CallStatus = new ECallStatus();

            // id
            arparams[0] = new SqlParameter("@id", SqlDbType.BigInt);
            arparams[0].Value = id;
            // activity type
            arparams[1] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            arparams[1].Value = "Meeting";

            // execute query
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_GetEventActivityDetailsView", arparams);

            if (tempdataset.Tables.Count > 0 && tempdataset.Tables[0].Rows.Count > 0)
            {
                objMeeting.ContactMeetingID = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["ContactMeetingID"]);
                objMeeting.Subject = Convert.ToString(tempdataset.Tables[0].Rows[0]["Subject"]);
                objMeeting.Description = Convert.ToString(tempdataset.Tables[0].Rows[0]["Notes"]);
                // meeting date
                if (tempdataset.Tables[0].Rows[0]["MeetingDate"] != DBNull.Value)
                {
                    objMeeting.StartDate =
                        Convert.ToDateTime(tempdataset.Tables[0].Rows[0]["MeetingDate"]).ToString("MM/dd/yyyy");
                }
                else
                {
                    objMeeting.StartDate = "";
                }
                // call time
                if (tempdataset.Tables[0].Rows[0]["MeetingTime"] != DBNull.Value)
                {
                    objMeeting.StartTime =
                        Convert.ToDateTime(tempdataset.Tables[0].Rows[0]["MeetingTime"]).ToString("0:hh:mm tt");
                }
                else
                {
                    objMeeting.StartTime = "";
                }

                // duration
                objMeeting.Duration = Convert.ToDecimal(tempdataset.Tables[0].Rows[0]["Duration"]);
                // meeting status 
                objMeeting.CallStatus.Status = Convert.ToString(tempdataset.Tables[0].Rows[0]["Status"]);

                // meeting venue
                objMeeting.Venue = Convert.ToString(tempdataset.Tables[0].Rows[0]["Venue"]);
            }
            return objMeeting;
        }

        /// <summary>
        ///  get task details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ETask GetActivityDetailsViewTask(Int64 id)
        {
            var arparams = new SqlParameter[2];
            // id
            arparams[0] = new SqlParameter("@id", SqlDbType.BigInt);
            arparams[0].Value = id;
            // activity type
            arparams[1] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            arparams[1].Value = "Task";

            // execute query
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,
                "usp_GetEventActivityDetailsView", arparams);

            var objTask = new ETask();
            objTask.TaskStatusType = new ETaskStatusType();

            if (tempdataset.Tables.Count > 0 && tempdataset.Tables[0].Rows.Count > 0)
            {
                objTask.TaskID = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["TaskID"]);
                objTask.Subject = Convert.ToString(tempdataset.Tables[0].Rows[0]["Subject"]);
                objTask.Notes = Convert.ToString(tempdataset.Tables[0].Rows[0]["Notes"]);

                // task date
                if (tempdataset.Tables[0].Rows[0]["DueDate"] != DBNull.Value)
                {
                    objTask.StartDate =
                        Convert.ToDateTime(tempdataset.Tables[0].Rows[0]["DueDate"]).ToString("MM/dd/yyyy");
                }
                else
                {
                    objTask.StartDate = "";
                }
                // call time
                if (tempdataset.Tables[0].Rows[0]["DueTime"] != DBNull.Value)
                {
                    objTask.StartTime =
                        Convert.ToDateTime(tempdataset.Tables[0].Rows[0]["DueTime"]).ToString("0:hh:mm tt");
                }
                else
                {
                    objTask.StartTime = "";
                }

                // task status 
                objTask.TaskStatusType.Name = Convert.ToString(tempdataset.Tables[0].Rows[0]["Status"]);
            }
            return objTask;
        }

        #endregion
    }
}
