
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Falcon.Entity.Affiliate;
using Falcon.Entity.CallCenter;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Franchisor;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.Entity.Other;
using Falcon.App.Core;
using EMarketingMaterialType = Falcon.Entity.Affiliate.EMarketingMaterialType;
using EPaymentType = Falcon.Entity.Other.EPaymentType;

namespace Falcon.DataAccess.MarketingPartner
{
    public class MarketingPartnerDAL
    {
        private readonly string _connectionString = ConnectionHandler.GetConnectionString();

        #region "Campaign"
        
        /// <summary>
        /// This function will return list of EFranchisee based on search criteria
        /// </summary>
        public List<EFranchisee> SearchFranchisee(string searchString)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@name", SqlDbType.VarChar, 3000);
            arParms[0].Value = searchString;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString,  "usp_searchFranchisee",
                                                   arParms);
            return ParseFranchiseeDataSet(tempdataset);
        }

        private List<EFranchisee> ParseFranchiseeDataSet(DataSet franchiseeDataSet)
        {
            var returnFranchisee = new List<EFranchisee>();

            for (int count = 0; count < franchiseeDataSet.Tables[0].Rows.Count; count++)
            {
                var franchisee = new EFranchisee();
                franchisee.FranchiseeID = Convert.ToInt32(franchiseeDataSet.Tables[0].Rows[count]["FranchiseeID"]);
                franchisee.Name = Convert.ToString(franchiseeDataSet.Tables[0].Rows[count]["Name"]);
                returnFranchisee.Add(franchisee);
            }
            return returnFranchisee;
        }

        /// <summary>
        /// Method to get CamapignReport Data
        /// </summary>
        public List<ECampaignReport> GetCampaignReportData(string campaignId, string affiliateId, string startDate,
                                                           string endDate)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@campaignid", SqlDbType.VarChar, 300);
            arParms[0].Value = campaignId;
            arParms[1] = new SqlParameter("@affiliateid", SqlDbType.VarChar, 300);
            arParms[1].Value = affiliateId;
            arParms[2] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[2].Value = startDate;
            arParms[3] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[3].Value = endDate;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFgetCampaignReport", arParms);
            var returnCampaign = new List<ECampaignReport>();
            returnCampaign = ParseCampaignReportData(tempdataset);
            return returnCampaign;
        }


        /// <summary>
        /// Method to get CamapignReport Data
        /// </summary>
        public List<ECampaignReport> GetCampaignReportAgeGraphData(string campaignId, string affiliateId,
                                                                   string startDate, string endDate)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@campaignid", SqlDbType.VarChar, 300);
            arParms[0].Value = campaignId;
            arParms[1] = new SqlParameter("@affiliateid", SqlDbType.VarChar, 300);
            arParms[1].Value = affiliateId;
            arParms[2] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[2].Value = startDate;
            arParms[3] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[3].Value = endDate;
            arParms[4] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[4].Value = 0;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFgetCampaignReportGraph", arParms);
            var returnCampaign = new List<ECampaignReport>();
            returnCampaign = ParseCampaignReportAgeGraphData(tempdataset);
            return returnCampaign;
        }

        /// <summary>
        /// Method to get CamapignReport Data
        /// </summary>
        public List<ECampaignReport> GetCampaignReportLeadGraphData(string campaignId, string affiliateId,
                                                                    string startDate, string endDate)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@campaignid", SqlDbType.VarChar, 300);
            arParms[0].Value = campaignId;
            arParms[1] = new SqlParameter("@affiliateid", SqlDbType.VarChar, 300);
            arParms[1].Value = affiliateId;
            arParms[2] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[2].Value = startDate;
            arParms[3] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[3].Value = endDate;
            arParms[4] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[4].Value = 1;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFgetCampaignReportGraph", arParms);
            var returnCampaign = new List<ECampaignReport>();
            returnCampaign = ParseCampaignReportLeadgraphData(tempdataset);
            return returnCampaign;
        }

        private List<ECampaignReport> ParseCampaignReportAgeGraphData(DataSet campaignDataSet)
        {
            var campaignReportList = new List<ECampaignReport>();
            for (int count = 0; count < campaignDataSet.Tables[0].Rows.Count; count++)
            {
                var campaignReport = new ECampaignReport();
                campaignReport.ECustomers = new ECustomers();
                campaignReport.ECustomers.User = new EUser();
                campaignReport.Event = new EEvent();
                campaignReport.Event.Host = new EHost();
                campaignReport.Event.Host.Address = new EAddress();
                //set the no of registeration for partical record
                if (campaignDataSet.Tables[0].Rows[count]["HostCount"] != DBNull.Value)
                    campaignReport.Event.Host.HostSize =
                        Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["HostCount"]);
                if (campaignDataSet.Tables[0].Rows[count]["Gender"] != DBNull.Value)
                    campaignReport.ECustomers.Gender = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Gender"]);
                if (campaignDataSet.Tables[0].Rows[count]["Age"] != DBNull.Value)
                    campaignReport.ECustomers.User.DOB = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Age"]);

                campaignReportList.Add(campaignReport);
            }
            return campaignReportList;
        }

        private List<ECampaignReport> ParseCampaignReportLeadgraphData(DataSet campaignDataSet)
        {
            var campaignReportList = new List<ECampaignReport>();
            for (int count = 0; count < campaignDataSet.Tables[0].Rows.Count; count++)
            {
                var campaignReport = new ECampaignReport();
                campaignReport.ECustomers = new ECustomers();
                campaignReport.ECustomers.User = new EUser();
                campaignReport.Event = new EEvent();
                campaignReport.Event.Host = new EHost();
                campaignReport.Event.Host.Address = new EAddress();
                //set the no of registeration for partical record
                if (campaignDataSet.Tables[0].Rows[count]["DateCreated"] != DBNull.Value)
                    campaignReport.ECustomers.User.DateCreated =
                        Convert.ToString(campaignDataSet.Tables[0].Rows[count]["DateCreated"]);
                if (campaignDataSet.Tables[0].Rows[count]["LeadCount"] != DBNull.Value)
                    campaignReport.ECustomers.User.LeadCount =
                        Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["LeadCount"]);
                if (campaignDataSet.Tables[0].Rows[count]["SignUpCount"] != DBNull.Value)
                    campaignReport.ECustomers.User.SignUpCount =
                        Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["SignUpCount"]);

                campaignReportList.Add(campaignReport);
            }
            return campaignReportList;
        }

       
        private List<ECampaignReport> ParseCampaignReportData(DataSet campaignDataSet)
        {
            var campaignReportList = new List<ECampaignReport>();
            for (int count = 0; count < campaignDataSet.Tables[0].Rows.Count; count++)
            {
                var campaignReport = new ECampaignReport();
                campaignReport.ECustomers = new ECustomers();
                campaignReport.ECustomers.User = new EUser();
                campaignReport.Event = new EEvent();
                campaignReport.Event.Host = new EHost();
                campaignReport.Event.Host.Address = new EAddress();
                campaignReport.PackageName = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["PackageName"]);
                campaignReport.SaleAmout = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["SaleAmount"]);
                campaignReport.Commission = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Commision"]);
                campaignReport.Event.Host.Name = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["HostName"]);
                campaignReport.Event.Host.Address.Address1 =
                    Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Address1"]);
                campaignReport.Event.Host.Address.City = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["City"]);
                campaignReport.Event.Host.Address.State =
                    Convert.ToString(campaignDataSet.Tables[0].Rows[count]["State"]);
                campaignReport.Event.Host.Address.Zip =
                    Convert.ToString(campaignDataSet.Tables[0].Rows[count]["ZipCode"]);
                campaignReport.ECustomers.CustomerID =
                    Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["CustomerID"]);
                campaignReport.ECustomers.Gender = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Gender"]);
                //Commission affiliate id
                campaignReport.AffiliateId =
                    Convert.ToString(campaignDataSet.Tables[0].Rows[count]["CommissionAffiliate"]);
                campaignReport.EventCustomerId =
                    Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["EventCustomerId"]);

                campaignReport.ECustomers.User.DOB = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Age"]);
                campaignReport.ECustomers.User.FirstName =
                    Convert.ToString(campaignDataSet.Tables[0].Rows[count]["FName"]);
                campaignReport.ECustomers.User.LastName =
                    Convert.ToString(campaignDataSet.Tables[0].Rows[count]["LName"]);

                campaignReport.IsPaymentConfirm =
                    Convert.ToBoolean(campaignDataSet.Tables[0].Rows[count]["IsPaymentConfirm"]);
                campaignReportList.Add(campaignReport);
            }
            return campaignReportList;
        }

        /// <summary>
        /// get campaign report for campaign type PPC and CPM
        /// </summary>
        public List<ECampaignReport> GetCamapignReportDataforPPCandCPM(string campaignId, string startDate,
                                                                       string endDate)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@campaignid", SqlDbType.VarChar, 300);
            arParms[0].Value = campaignId;

            arParms[1] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[1].Value = startDate;
            arParms[2] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[2].Value = endDate;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFCampaignReportforPPCandCPM", arParms);
            var returnCampaign = new List<ECampaignReport>();
            returnCampaign = ParseCampaignReportDataForCPMandPPC(tempdataset);
            return returnCampaign;
        }

        private List<ECampaignReport> ParseCampaignReportDataForCPMandPPC(DataSet campaignDataSet)
        {
            var campaignReportList = new List<ECampaignReport>();
            for (int count = 0; count < campaignDataSet.Tables[0].Rows.Count; count++)
            {
                var campaignReport = new ECampaignReport();

                campaignReport.Date = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Date"]);
                campaignReport.SaleAmout = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["SaleAmount"]);
                campaignReport.Commission = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Commission"]);
                campaignReport.Impressions = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["ImpressionCount"]);
                campaignReport.CTR = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["CTR"]);
                campaignReport.SignUpCount = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["SignUpCount"]);
                campaignReport.ClickCount = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["ClickCount"]);

                campaignReportList.Add(campaignReport);
            }
            return campaignReportList;
        }

        public List<ECampaignReport> GetCamapignReportDataforPPCandCPMforCustomer(string customerid,
                                                                                  string compensationType,
                                                                                  string startDate, string endDate)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@customerid", SqlDbType.VarChar, 300);
            arParms[0].Value = customerid;
            arParms[1] = new SqlParameter("@compensationType", SqlDbType.VarChar, 300);
            arParms[1].Value = compensationType;
            arParms[2] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[2].Value = startDate;
            arParms[3] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[3].Value = endDate;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_AFgetCampaignReportPPC_CPMforCustomer", arParms);
            var returnCampaign = new List<ECampaignReport>();
            returnCampaign = ParseCampaignReportDataForCPMandPPCforCustomer(tempdataset);
            return returnCampaign;
        }

        private List<ECampaignReport> ParseCampaignReportDataForCPMandPPCforCustomer(DataSet campaignDataSet)
        {
            var campaignReportList = new List<ECampaignReport>();
            for (int count = 0; count < campaignDataSet.Tables[0].Rows.Count; count++)
            {
                var campaignReport = new ECampaignReport();
                campaignReport.CallId = Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["campaignid"]);

                campaignReport.Date = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Date"]);
                campaignReport.SaleAmout = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["SaleAmount"]);
                campaignReport.Commission = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Commission"]);
                campaignReport.Impressions = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["ImpressionCount"]);
                campaignReport.CTR = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["CTR"]);
                campaignReport.SignUpCount = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["SignUpCount"]);
                campaignReport.ClickCount = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["ClickCount"]);

                campaignReportList.Add(campaignReport);
            }
            return campaignReportList;
        }

        #endregion

        #region Affiliate
        
        /// <summary>
        /// method to change affiliate's approved status
        /// </summary>
        /// <param name="status"></param>
        /// <param name="affiliateId"></param>
        public void ChangeAffiliateApprovedStatus(bool status, int affiliateId)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@isapproved", SqlDbType.Bit);
            arParms[0].Value = status;
            arParms[1] = new SqlParameter("@affiliateid", SqlDbType.Int);
            arParms[1].Value = affiliateId;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                                      "usp_AFUpdateAffiliateApprovedStatus", arParms);
        }

       
        /// <summary>
        /// Chnage app user to advocate
        /// </summary>
        /// <returns></returns>
        public Int32 ConvertAppUserToAffiliate()
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@usercount", SqlDbType.Int);
            arParms[0].Direction = ParameterDirection.Output;
            Int32 intConvertedUser;
            //intConvertedUser = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "usp_AFCreateAppUserAffiliate",));
            //return intConvertedUser;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_AFCreateAppUserAffiliate",
                                      arParms);
            intConvertedUser = (Int32)arParms[0].Value;
            return intConvertedUser;
            ;
        }

        /// <summary>
        /// Method to get user list of app users who are not advocate
        /// </summary>
        /// <returns></returns>
        public Int32 getPendingAppUserForAffiliate()
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@usercount", SqlDbType.Int);
            arParms[0].Direction = ParameterDirection.Output;
            Int32 intConvertedUser;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_getPendingAppUserForAffiliate",
                                      arParms);
            intConvertedUser = (Int32)arParms[0].Value;
            return intConvertedUser;
        }
        

        /// <summary>
        /// Check whether advocate is express advocate
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool CheckExpressAdvocate(long customerId)
        {
            var arparams = new SqlParameter[1];
            arparams[0] = new SqlParameter("@customerid", SqlDbType.VarChar, 200);
            arparams[0].Value = customerId;

            Object objreturnvalue = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure,
                                                            "usp_AFcheckExpressAdvocate", arparams);
            if (objreturnvalue != null)
            {
                return (bool)objreturnvalue;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool CheckMonetizedAdvocate(long customerId)
        {
            var arparams = new SqlParameter[1];
            arparams[0] = new SqlParameter("@customerid", SqlDbType.VarChar, 200);
            arparams[0].Value = customerId;

            Object objreturnvalue = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure,
                                                            "usp_AFcheckIsMonetizedAdvocate", arparams);
            return (bool)objreturnvalue;
        }

        /// <summary>
        /// change  express advocate to advance advocate
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public void ChangeExpressToAdvancedAdvocate(long customerId, bool isexpressaffiliate)
        {
            var arparams = new SqlParameter[2];
            arparams[0] = new SqlParameter("@customerid", SqlDbType.VarChar, 200);
            arparams[0].Value = customerId;
            arparams[1] = new SqlParameter("@isexpressaffiliate", SqlDbType.Bit);
            arparams[1].Value = isexpressaffiliate;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                                      "usp_AFchangeExpressAdvocateToAdvanced", arparams);
        }

        /// <summary>
        /// Change the monetise status of affiliate
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="ismonitizedaffiliate"></param>
        public void ChangeIsMonetizedAdvocateStatus(int customerId, bool ismonitizedaffiliate)
        {
            var arparams = new SqlParameter[2];
            arparams[0] = new SqlParameter("@customerid", SqlDbType.VarChar, 200);
            arparams[0].Value = customerId;
            arparams[1] = new SqlParameter("@IsMoneytized", SqlDbType.Bit);
            arparams[1].Value = ismonitizedaffiliate;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                                      "usp_afUpdateIsMoneytizedAdvocateStatus", arparams);
        }


        /// <summary>
        /// Get express advocate source code
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public string GetExpressAdvocateSourceCode(long customerId)
        {
            var arparams = new SqlParameter[1];
            arparams[0] = new SqlParameter("@customerid", SqlDbType.VarChar, 200);
            arparams[0].Value = customerId;

            Object objreturnvalue = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure,
                                                            "usp_AFgetExpressAdvocateSourceCode", arparams);
            return (string)objreturnvalue;
        }
        
        /// <summary>
        /// Get Advocate Report
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="affiliateId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ECampaignReport> GetAdvocateReportData(string affiliateId, string startDate, string endDate)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@affiliateId", SqlDbType.VarChar, 300);
            arParms[0].Value = affiliateId;

            arParms[1] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[1].Value = startDate;
            arParms[2] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[2].Value = endDate;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFGetAffiliateReport", arParms);
            var returnCampaign = new List<ECampaignReport>();
            returnCampaign = ParseAdvocateReportData(tempdataset);
            return returnCampaign;
        }

        /// <summary>
        /// Get Advocate Report by age
        /// </summary>
        /// <param name="affiliateId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ECampaignReport> GetAdvocateReportAgeGraphData(string affiliateId, string startDate, string endDate)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@affiliateId", SqlDbType.VarChar, 300);
            arParms[0].Value = affiliateId;

            arParms[1] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[1].Value = startDate;
            arParms[2] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[2].Value = endDate;
            arParms[3] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[3].Value = 0;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFGetAffiliateReportGraph", arParms);
            var returnCampaign = new List<ECampaignReport>();
            returnCampaign = ParseAdvocateReportAgeGraphData(tempdataset);
            return returnCampaign;
        }

        /// <summary>
        /// Get Advocate Report by Lead/signup
        /// </summary>
        /// <param name="affiliateId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ECampaignReport> GetAdvocateReportLeadGraphData(string affiliateId, string startDate, string endDate)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@affiliateId", SqlDbType.VarChar, 300);
            arParms[0].Value = affiliateId;

            arParms[1] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[1].Value = startDate;
            arParms[2] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[2].Value = endDate;
            arParms[3] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[3].Value = 1;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFGetAffiliateReportGraph", arParms);
            var returnCampaign = new List<ECampaignReport>();
            returnCampaign = ParseAdvocateReportLeadGraphData(tempdataset);
            return returnCampaign;
        }

        private List<ECampaignReport> ParseAdvocateReportLeadGraphData(DataSet campaignDataSet)
        {
            var campaignReportList = new List<ECampaignReport>();
            for (int count = 0; count < campaignDataSet.Tables[0].Rows.Count; count++)
            {
                var campaignReport = new ECampaignReport();
                campaignReport.ECustomers = new ECustomers();
                campaignReport.ECustomers.User = new EUser();
                campaignReport.Event = new EEvent();
                campaignReport.Event.Host = new EHost();
                campaignReport.Event.Host.Address = new EAddress();
                //set the no of registeration for partical record
                if (campaignDataSet.Tables[0].Rows[count]["DateCreated"] != DBNull.Value)
                    campaignReport.ECustomers.User.DateCreated =
                        Convert.ToString(campaignDataSet.Tables[0].Rows[count]["DateCreated"]);
                if (campaignDataSet.Tables[0].Rows[count]["LeadCount"] != DBNull.Value)
                    campaignReport.ECustomers.User.LeadCount =
                        Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["LeadCount"]);
                if (campaignDataSet.Tables[0].Rows[count]["SignUpCount"] != DBNull.Value)
                    campaignReport.ECustomers.User.SignUpCount =
                        Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["SignUpCount"]);

                campaignReportList.Add(campaignReport);
            }
            return campaignReportList;
        }

        private List<ECampaignReport> ParseAdvocateReportAgeGraphData(DataSet campaignDataSet)
        {
            var campaignReportList = new List<ECampaignReport>();
            for (int count = 0; count < campaignDataSet.Tables[0].Rows.Count; count++)
            {
                var campaignReport = new ECampaignReport();
                campaignReport.ECustomers = new ECustomers();
                campaignReport.ECustomers.User = new EUser();
                campaignReport.Event = new EEvent();
                campaignReport.Event.Host = new EHost();
                campaignReport.Event.Host.Address = new EAddress();
                //set the no of registeration for partical record
                if (campaignDataSet.Tables[0].Rows[count]["HostCount"] != DBNull.Value)
                    campaignReport.Event.Host.HostSize =
                        Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["HostCount"]);
                if (campaignDataSet.Tables[0].Rows[count]["Gender"] != DBNull.Value)
                    campaignReport.ECustomers.Gender = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Gender"]);
                if (campaignDataSet.Tables[0].Rows[count]["Age"] != DBNull.Value)
                    campaignReport.ECustomers.User.DOB = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Age"]);

                campaignReportList.Add(campaignReport);
            }
            return campaignReportList;
        }


        private List<ECampaignReport> ParseAdvocateReportData(DataSet campaignDataSet)
        {
            var campaignReportList = new List<ECampaignReport>();
            for (int count = 0; count < campaignDataSet.Tables[0].Rows.Count; count++)
            {
                var campaignReport = new ECampaignReport();
                campaignReport.ECustomers = new ECustomers();
                campaignReport.ECustomers.User = new EUser();
                campaignReport.Event = new EEvent();
                campaignReport.Event.Host = new EHost();
                campaignReport.Event.Host.Address = new EAddress();
                if (campaignDataSet.Tables[0].Rows[count]["CallId"] != DBNull.Value)
                    campaignReport.CallId = Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["CallId"]);
                if (campaignDataSet.Tables[0].Rows[count]["PackageName"] != DBNull.Value)
                    campaignReport.PackageName = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["PackageName"]);
                if (campaignDataSet.Tables[0].Rows[count]["SaleAmount"] != DBNull.Value)
                    campaignReport.SaleAmout = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["SaleAmount"]);
                if (campaignDataSet.Tables[0].Rows[count]["Commision"] != DBNull.Value)
                    campaignReport.Commission = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Commision"]);
                if (campaignDataSet.Tables[0].Rows[count]["HostName"] != DBNull.Value)
                    campaignReport.Event.Host.Name = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["HostName"]);
                if (campaignDataSet.Tables[0].Rows[count]["Address1"] != DBNull.Value)
                    campaignReport.Event.Host.Address.Address1 =
                        Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Address1"]);
                if (campaignDataSet.Tables[0].Rows[count]["City"] != DBNull.Value)
                    campaignReport.Event.Host.Address.City =
                        Convert.ToString(campaignDataSet.Tables[0].Rows[count]["City"]);
                if (campaignDataSet.Tables[0].Rows[count]["State"] != DBNull.Value)
                    campaignReport.Event.Host.Address.State =
                        Convert.ToString(campaignDataSet.Tables[0].Rows[count]["State"]);
                if (campaignDataSet.Tables[0].Rows[count]["ZipCode"] != DBNull.Value)
                    campaignReport.Event.Host.Address.Zip =
                        Convert.ToString(campaignDataSet.Tables[0].Rows[count]["ZipCode"]);
                if (campaignDataSet.Tables[0].Rows[count]["CustomerID"] != DBNull.Value)
                    campaignReport.ECustomers.CustomerID =
                        Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["CustomerID"]);
                if (campaignDataSet.Tables[0].Rows[count]["Gender"] != DBNull.Value)
                    campaignReport.ECustomers.Gender = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Gender"]);
                if (campaignDataSet.Tables[0].Rows[count]["Age"] != DBNull.Value)
                    campaignReport.ECustomers.User.DOB = Convert.ToString(campaignDataSet.Tables[0].Rows[count]["Age"]);
                if (campaignDataSet.Tables[0].Rows[count]["DateCreated"] != DBNull.Value)
                    campaignReport.ECustomers.User.DateCreated =
                        Convert.ToString(campaignDataSet.Tables[0].Rows[count]["DateCreated"]);

                if (campaignDataSet.Tables[0].Rows[count]["FName"] != DBNull.Value)
                    campaignReport.ECustomers.User.FirstName =
                        Convert.ToString(campaignDataSet.Tables[0].Rows[count]["FName"]);
                if (campaignDataSet.Tables[0].Rows[count]["LName"] != DBNull.Value)
                    campaignReport.ECustomers.User.LastName =
                        Convert.ToString(campaignDataSet.Tables[0].Rows[count]["LName"]);
                if (campaignDataSet.Tables[0].Rows[count]["IsPaymentConfirm"] != DBNull.Value)
                    campaignReport.IsPaymentConfirm =
                        Convert.ToBoolean(campaignDataSet.Tables[0].Rows[count]["IsPaymentConfirm"]);
                if (campaignDataSet.Tables[0].Rows[count]["EventCustomerID"] != DBNull.Value)
                    campaignReport.EventCustomerId =
                        Convert.ToInt32(campaignDataSet.Tables[0].Rows[count]["EventCustomerID"]);

                campaignReportList.Add(campaignReport);
            }
            return campaignReportList;
        }
        

        #endregion

        #region Marketing Material

        /// <summary>
        /// To save maketing material
        /// </summary>
        /// <param name="marketingMaterial"></param>
        public void SaveMarketingMaterial(EMarketingMaterial marketingMaterial)
        {
            var arParms = new SqlParameter[22];
            arParms[0] = new SqlParameter("@MarketingMaterialId", SqlDbType.BigInt);
            arParms[0].Value = marketingMaterial.MarketingMaterialId;
            arParms[1] = new SqlParameter("@Title", SqlDbType.VarChar, 3000);
            arParms[1].Value = marketingMaterial.Title;
            arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar, 3000);
            arParms[2].Value = marketingMaterial.Description;
            arParms[3] = new SqlParameter("@IsEventSpecific", SqlDbType.Bit);
            arParms[3].Value = marketingMaterial.IsEventSpecific;
            arParms[4] = new SqlParameter("@MarketingMaterialTypeID", SqlDbType.BigInt);
            arParms[4].Value = marketingMaterial.MarketingMaterialTypeId;
            arParms[5] = new SqlParameter("@ImagePath", SqlDbType.VarChar, 3000);
            arParms[5].Value = marketingMaterial.ImagePath;
            arParms[6] = new SqlParameter("@Text", SqlDbType.VarChar, 3000);
            arParms[6].Value = marketingMaterial.Text;
            arParms[7] = new SqlParameter("@HTMLText", SqlDbType.VarChar, 3000);
            arParms[7].Value = marketingMaterial.HTMLText;
            arParms[8] = new SqlParameter("@CommonSizeName", SqlDbType.VarChar, 3000);
            arParms[8].Value = marketingMaterial.CommonSizeName;
            arParms[9] = new SqlParameter("@Height", SqlDbType.Int);
            arParms[9].Value = marketingMaterial.Height;
            arParms[10] = new SqlParameter("@Width", SqlDbType.Int);
            arParms[10].Value = marketingMaterial.Width;
            arParms[11] = new SqlParameter("@IsActive", SqlDbType.Bit);
            arParms[11].Value = marketingMaterial.Active;
            int mode = 0;
            if (marketingMaterial.MarketingMaterialId > 0)
                mode = 1;

            arParms[12] = new SqlParameter("@IsInternal", SqlDbType.Bit);
            arParms[12].Value = marketingMaterial.IsInternal;
            arParms[13] = new SqlParameter("@EventId", SqlDbType.Int);
            if (marketingMaterial.EventId == 0)
                arParms[13].Value = DBNull.Value;
            else
                arParms[13].Value = marketingMaterial.EventId;
            arParms[14] = new SqlParameter("@HeadingText", SqlDbType.VarChar, 2000);
            arParms[14].Value = marketingMaterial.HeadingText;
            arParms[15] = new SqlParameter("@LeadingInURL", SqlDbType.VarChar, 2000);
            arParms[15].Value = marketingMaterial.LeadingInURL;
            arParms[16] = new SqlParameter("@DisplayURL", SqlDbType.VarChar, 2000);
            arParms[16].Value = marketingMaterial.DisplayURL;
            arParms[17] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[17].Value = mode;
            arParms[18] = new SqlParameter("@IsInbound", SqlDbType.Bit);
            arParms[18].Value = marketingMaterial.IsInbound;
            arParms[19] = new SqlParameter("@isDefault", SqlDbType.Bit);
            arParms[19].Value = marketingMaterial.IsDefault;
            arParms[20] = new SqlParameter("@marketingOfferId", SqlDbType.BigInt);
            arParms[20].Value = marketingMaterial.MarketingOfferId;
            arParms[21] = new SqlParameter("@ThumbnailImagePath", SqlDbType.VarChar, 3000);
            arParms[21].Value = marketingMaterial.ThumbnailImagePath;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_AfsaveMarketingMaterial",
                                      arParms);
        }

        /// <summary>
        /// Sub routine to get marketing material data
        /// </summary>
        /// <param name="marketingMaterialId"></param>
        /// <returns></returns>
        public EMarketingMaterial GetMarketingMaterialDetails(string marketingMaterialId)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@MarketingMaterialId", SqlDbType.VarChar, 200);
            arParms[0].Value = marketingMaterialId;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFgetMarketingMaterial", arParms);
            EMarketingMaterial returnMarketingMaterial = ParseMarketingMaterialData(tempdataset);
            return returnMarketingMaterial;
        }

        private EMarketingMaterial ParseMarketingMaterialData(DataSet MarketingMaterialDataSet)
        {
            var marketingMaterial = new EMarketingMaterial();

            if (MarketingMaterialDataSet.Tables[0].Rows.Count > 0)
            {
                marketingMaterial.MarketingMaterialId =
                    Convert.ToInt32(MarketingMaterialDataSet.Tables[0].Rows[0]["MarketingMaterialId"]);
                marketingMaterial.Title = Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["Title"]);
                marketingMaterial.Description =
                    Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["Description"]);
                marketingMaterial.IsEventSpecific =
                    Convert.ToBoolean(MarketingMaterialDataSet.Tables[0].Rows[0]["IsEventSpecific"]);
                marketingMaterial.IsInbound = Convert.ToBoolean(MarketingMaterialDataSet.Tables[0].Rows[0]["IsInbound"]);
                marketingMaterial.MarketingMaterialTypeId =
                    Convert.ToInt32(MarketingMaterialDataSet.Tables[0].Rows[0]["MarketingMaterialTypeID"]);
                marketingMaterial.ImagePath = Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["ImagePath"]);
                marketingMaterial.ThumbnailImagePath =
                    Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["ThumbnailImagePath"]);
                marketingMaterial.Text = Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["Text"]);
                marketingMaterial.HTMLText = Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["HTMLText"]);
                marketingMaterial.CommonSizeName =
                    Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["CommonSizeName"]);
                marketingMaterial.Height = Convert.ToInt32(MarketingMaterialDataSet.Tables[0].Rows[0]["Height"]);
                marketingMaterial.Width = Convert.ToInt32(MarketingMaterialDataSet.Tables[0].Rows[0]["Width"]);
                marketingMaterial.Active = Convert.ToBoolean(MarketingMaterialDataSet.Tables[0].Rows[0]["IsActive"]);
                marketingMaterial.HeadingText =
                    Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["HeadingText"]);
                marketingMaterial.LeadingInURL =
                    Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["LeadingInURL"]);
                marketingMaterial.DisplayURL = Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["DisplayURL"]);
                marketingMaterial.Text = Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["Text"]);
                marketingMaterial.MarketingMaterialType = new EMarketingMaterialType();
                marketingMaterial.MarketingMaterialType.Tag =
                    Convert.ToString(MarketingMaterialDataSet.Tables[0].Rows[0]["Tag"]);
                marketingMaterial.MarketingMaterialType.MarketingMaterialTypeID =
                    Convert.ToInt32(MarketingMaterialDataSet.Tables[0].Rows[0]["MarketingMaterialTypeID"]);
                marketingMaterial.IsInternal =
                    Convert.ToBoolean(MarketingMaterialDataSet.Tables[0].Rows[0]["IsInternal"]);
                marketingMaterial.Inbound = Convert.ToBoolean(MarketingMaterialDataSet.Tables[0].Rows[0]["IsInbound"]);
                if (MarketingMaterialDataSet.Tables[0].Rows[0]["IsDefault"] != null)
                    marketingMaterial.IsDefault =
                        Convert.ToBoolean(MarketingMaterialDataSet.Tables[0].Rows[0]["IsDefault"]);
                else
                    marketingMaterial.IsDefault = false;

                //if((MarketingMaterialDataSet.Tables[0].Rows[0]["MarketingOfferId"]!=null)&&(MarketingMaterialDataSet.Tables[0].Rows[0]["MarketingOfferId"]!=""))
                marketingMaterial.MarketingOfferName =
                    MarketingMaterialDataSet.Tables[0].Rows[0]["MarketingOffer"].ToString();
                if ((MarketingMaterialDataSet.Tables[0].Rows[0]["GroupId"] != null) &&
                    ((MarketingMaterialDataSet.Tables[0].Rows[0]["GroupId"]).ToString() != ""))
                    marketingMaterial.MarketingMaterialGroupId =
                        Convert.ToInt32(MarketingMaterialDataSet.Tables[0].Rows[0]["GroupId"]);

                if (MarketingMaterialDataSet.Tables[0].Rows[0]["EventId"] != DBNull.Value)
                {
                    marketingMaterial.EventId = Convert.ToInt32(MarketingMaterialDataSet.Tables[0].Rows[0]["EventId"]);
                }

                marketingMaterial.Association =
                    Convert.ToInt32(MarketingMaterialDataSet.Tables[0].Rows[0]["Associations"]);
            }

            return marketingMaterial;
        }


        public List<EMarketingMaterialType> GetAllMarketingTypeWithGroup()
        {
            var arParms = new SqlParameter[0];

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_GetAllMarketingTypeWithGroup", arParms);
            var returnMarketingMaterial = new List<EMarketingMaterialType>();
            returnMarketingMaterial = ParseMarketingMaterialWithGroup(tempdataset);
            return returnMarketingMaterial;
        }

        private List<EMarketingMaterialType> ParseMarketingMaterialWithGroup(DataSet marketingMaterialDataSet)
        {
            var returnMarketingMaterial = new List<EMarketingMaterialType>();

            for (int count = 0; count < marketingMaterialDataSet.Tables[0].Rows.Count; count++)
            {
                var marketingMaterial = new EMarketingMaterialType();

                marketingMaterial.MarketingMaterialTypeID =
                    Convert.ToInt32(marketingMaterialDataSet.Tables[0].Rows[count]["MarketingMaterialTypeId"]);
                marketingMaterial.MarketingMaterialGroupID =
                    Convert.ToInt32(marketingMaterialDataSet.Tables[0].Rows[count]["MarketingMaterialGroupId"]);
                marketingMaterial.Title = Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["MMTitle"]);
                marketingMaterial.MMGroupTitle =
                    Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["GroupTitle"]);
                returnMarketingMaterial.Add(marketingMaterial);
            }
            return returnMarketingMaterial;
        }


        /// <summary>
        /// Get banner size
        /// </summary>
        /// <returns></returns>
        public List<EMarketingMaterial> GetMMBannerSizes()
        {
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, "usp_AFGetBannerSize",
                                                   null);
            var lstMM = new List<EMarketingMaterial>();
            lstMM = ParseMMBannerSizeDataSet(tempdataset);
            return lstMM;
        }

        private List<EMarketingMaterial> ParseMMBannerSizeDataSet(DataSet tempDataSet)
        {
            var lstMarketingMaterial = new List<EMarketingMaterial>();

            for (int count = 0; count < tempDataSet.Tables[0].Rows.Count; count++)
            {
                var mm = new EMarketingMaterial();

                mm.BannerId = Convert.ToInt32(tempDataSet.Tables[0].Rows[count]["MarketingmaterialBannersizeID"]);
                mm.BannerSize = Convert.ToString(tempDataSet.Tables[0].Rows[count]["BannerSize"]);

                lstMarketingMaterial.Add(mm);
            }
            return lstMarketingMaterial;
        }

        public List<EMarketingMaterial> GetAllPrintMarketingMaterialType()
        {
            var arParms = new SqlParameter[0];

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFgetPrintMarketingMaterialType", arParms);
            var returnMarketingMaterial = new List<EMarketingMaterial>();
            returnMarketingMaterial = ParsePrintMarketingMaterialType(tempdataset);
            return returnMarketingMaterial;
        }

        private List<EMarketingMaterial> ParsePrintMarketingMaterialType(DataSet marketingMaterialDataSet)
        {
            var returnMarketingMaterial = new List<EMarketingMaterial>();

            for (int count = 0; count < marketingMaterialDataSet.Tables[0].Rows.Count; count++)
            {
                var marketingMaterial = new EMarketingMaterial();
                marketingMaterial.MarketingMaterialId =
                    Convert.ToInt32(marketingMaterialDataSet.Tables[0].Rows[count]["MarketingMaterialId"]);
                marketingMaterial.Title = Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["MMTitle"]);

                var mmType = new EMarketingMaterialType();
                mmType.MarketingMaterialTypeID =
                    Convert.ToInt32(marketingMaterialDataSet.Tables[0].Rows[count]["MarketingMaterialTypeId"]);
                mmType.Title = Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["MMTypeTitle"]);

                marketingMaterial.MarketingMaterialType = mmType;
                returnMarketingMaterial.Add(marketingMaterial);
            }
            return returnMarketingMaterial;
        }

        public List<EMarketingMaterial> SearchPrintMarketingMaterial(string title, string strTypeID, int pagenumber,
                                                                     int pageSize, int mode, out int iTotalRecordCount)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@Title", SqlDbType.VarChar, 512);
            arParms[0].Value = title;
            arParms[1] = new SqlParameter("@typeID", SqlDbType.Int);
            arParms[1].Value = Convert.ToInt32(strTypeID);
            arParms[2] = new SqlParameter("@pagenumber", SqlDbType.Int);
            arParms[2].Value = pagenumber;
            arParms[3] = new SqlParameter("@pagesize", SqlDbType.Int);
            arParms[3].Value = pageSize;
            arParms[4] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[4].Value = mode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFSearchPrintMarketingMaterial", arParms);
            var returnMarketingMaterial = new List<EMarketingMaterial>();
            returnMarketingMaterial = ParsePrintMarketingMaterialDataSet(tempdataset);
            iTotalRecordCount = 0;
            if (tempdataset.Tables[1] != null && tempdataset.Tables[1].Rows.Count > 0)
                iTotalRecordCount = Convert.ToInt32(tempdataset.Tables[1].Rows[0][0]);
            return returnMarketingMaterial;
        }

        private List<EMarketingMaterial> ParsePrintMarketingMaterialDataSet(DataSet marketingMaterialDataSet)
        {
            var returnMarketingMaterial = new List<EMarketingMaterial>();

            for (int count = 0; count < marketingMaterialDataSet.Tables[0].Rows.Count; count++)
            {
                var marketingMaterial = new EMarketingMaterial();

                marketingMaterial.MarketingMaterialId =
                    Convert.ToInt32(marketingMaterialDataSet.Tables[0].Rows[count]["MarketingMaterialId"]);
                marketingMaterial.Title = Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["Title"]);
                marketingMaterial.Description =
                    Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["Description"]);
                marketingMaterial.ImagePath =
                    Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["ImagePath"]);
                marketingMaterial.CreatedDate =
                    Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["CreatedDate"]);
                marketingMaterial.ThumbnailImagePath = Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["ThumbnailImagePath"]);

                if (!string.IsNullOrEmpty(marketingMaterial.ImagePath)) marketingMaterial.ImagePath = marketingMaterial.ImagePath.Replace(@"/", @"\");
                if (!string.IsNullOrEmpty(marketingMaterial.ThumbnailImagePath)) marketingMaterial.ThumbnailImagePath = marketingMaterial.ThumbnailImagePath.Replace(@"/", @"\");

                returnMarketingMaterial.Add(marketingMaterial);
            }
            return returnMarketingMaterial;
        }
        
        /// <summary>
        /// To update hit count
        /// </summary>
        /// <param name="campaignMarketingMaterial"></param>
        public void UpdateClickImpressionCount(Int64 MarketingMaterialID, Int64 CampaignId, int mode)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@MarketingMaterialID", SqlDbType.BigInt);
            arParms[0].Value = MarketingMaterialID;


            arParms[1] = new SqlParameter("@mode", SqlDbType.VarChar, 3000);
            arParms[1].Value = mode;
            arParms[2] = new SqlParameter("@CampaignID", SqlDbType.BigInt);
            arParms[2].Value = CampaignId;
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                                      "usp_AFupdateClickandImpressionCount", arParms);
        }

        public string GetRoleGroup(Int64 franchiseeFranchiseeUserId)
        {
            string strRoleGroup = string.Empty;
            var tempdataset = new DataSet();

            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@franchiseeFranchiseeUserId", SqlDbType.BigInt);
            arParms[0].Value = franchiseeFranchiseeUserId;

            tempdataset = SqlHelper.ExecuteDataset(_connectionString,  "usp_GetRoleGroup",
                                                   arParms);
            if (tempdataset.Tables[0].Rows[0][0] != DBNull.Value)
            {
                strRoleGroup = tempdataset.Tables[0].Rows[0][0].ToString();
            }
            return strRoleGroup;
        }

        public string GetAffiliateUserCategory(Int64 affiliateUserId)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@affiliateUserId", SqlDbType.BigInt);
            arParms[0].Value = affiliateUserId;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_getAffilateCategory", arParms);

            string strcategory = string.Empty;
            if (tempdataset.Tables[0].Rows.Count > 0)
                if (tempdataset.Tables[0].Rows[0][0] != DBNull.Value)
                    strcategory = tempdataset.Tables[0].Rows[0][0].ToString();

            return strcategory;
        }

        /// <summary>
        /// Method for getting EMarketingMaterialType
        /// </summary>
        /// <returns></returns>
        public List<EMarketingMaterialType> GetAllMarketingMaterialType()
        {
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFgetMarketingMaterialType", null);
            var returnMarketingMaterialType = new List<EMarketingMaterialType>();
            returnMarketingMaterialType = ParseMarketingMaterialTypeDataSet(tempdataset);
            return returnMarketingMaterialType;
        }

        private List<EMarketingMaterialType> ParseMarketingMaterialTypeDataSet(DataSet marketingMaterialDataSet)
        {
            var returnMarketingMaterial = new List<EMarketingMaterialType>();

            for (int count = 0; count < marketingMaterialDataSet.Tables[0].Rows.Count; count++)
            {
                var marketingMaterialType = new EMarketingMaterialType();

                marketingMaterialType.Active =
                    Convert.ToBoolean(marketingMaterialDataSet.Tables[0].Rows[count]["IsActive"]);
                marketingMaterialType.Description =
                    Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["Description"]);
                marketingMaterialType.MarketingMaterialTypeID =
                    Convert.ToInt32(marketingMaterialDataSet.Tables[0].Rows[count]["MarketingMaterialTypeID"]);
                marketingMaterialType.Title = Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["Title"]);
                marketingMaterialType.MarketingMaterialTypeID =
                    Convert.ToInt32(marketingMaterialDataSet.Tables[0].Rows[count]["MarketingMaterialTypeID"]);
                marketingMaterialType.Tag = Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["Tag"]);

                returnMarketingMaterial.Add(marketingMaterialType);
            }
            return returnMarketingMaterial;
        }

        /// <summary>
        /// Get marketing material type by groupid
        /// </summary>
        /// <param name="strGroupId"></param>
        /// <returns></returns>
        public List<EMarketingMaterialType> GetMarketingMaterialTypeByGroupId(Int64 iGroupId)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@groupId", SqlDbType.BigInt);
            arParms[0].Value = iGroupId;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFgetMarketingMaterialTypeByGroupId", arParms);
            var returnMarketingMaterialType = new List<EMarketingMaterialType>();
            returnMarketingMaterialType = ParseMarketingMaterialTypeByGroupId(tempdataset);
            return returnMarketingMaterialType;
        }

        private List<EMarketingMaterialType> ParseMarketingMaterialTypeByGroupId(DataSet marketingMaterialDataSet)
        {
            var returnMarketingMaterial = new List<EMarketingMaterialType>();

            for (int count = 0; count < marketingMaterialDataSet.Tables[0].Rows.Count; count++)
            {
                var marketingMaterialType = new EMarketingMaterialType();

                marketingMaterialType.MarketingMaterialTypeID =
                    Convert.ToInt32(marketingMaterialDataSet.Tables[0].Rows[count]["MarketingMaterialTypeID"]);
                marketingMaterialType.Title = Convert.ToString(marketingMaterialDataSet.Tables[0].Rows[count]["Title"]);
                returnMarketingMaterial.Add(marketingMaterialType);
            }
            return returnMarketingMaterial;
        }


        public void UpdateProspectMMInfo(string strCID, string strMMID, string strAFFID, Int32 intProspect)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@MarketingMaterialID", SqlDbType.BigInt);
            arParms[0].Value = strMMID;
            arParms[1] = new SqlParameter("@CampaignID", SqlDbType.BigInt);
            arParms[1].Value = strCID;
            arParms[2] = new SqlParameter("@AffiliateID", SqlDbType.BigInt);
            arParms[2].Value = strAFFID;
            arParms[3] = new SqlParameter("@ProspectID", SqlDbType.BigInt);
            arParms[3].Value = intProspect;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_AFProspectMMInfo", arParms);
        }

        /// <summary>
        /// method to get the different counts for advocatemanger
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public string GetAdvocateManagerData(string startDate, string endDate)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@startdate", SqlDbType.VarChar, 12);
            arParms[0].Value = startDate;
            arParms[1] = new SqlParameter("@enddate", SqlDbType.VarChar, 12);
            arParms[1].Value = endDate;
            string advocateManagerdata = string.Empty;
            advocateManagerdata =
                Convert.ToString(SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure,
                                                         "usp_AFGetAdvocateManagerInfo", arParms));
            return advocateManagerdata;
        }

        /// <summary>
        /// Create camapign on the fly for the customer/advocate
        /// </summary>
        public void CreateCampaignforCustomer(string campaignName, int ownerAffiliateId)
        {
            var arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@campaignname", SqlDbType.VarChar, 3000);
            arParms[0].Value = campaignName;

            arParms[1] = new SqlParameter("@owneraffiliateid", SqlDbType.Int);
            arParms[1].Value = ownerAffiliateId;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_AFCreateCampaignForCustomer",
                                      arParms);
        }

        /// <summary>
        /// Create campaign for PPC type campaigns  
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="marketingMaterialId"></param>
        /// <param name="affiliateId"></param>
        /// <param name="ipAddress"></param>
        /// <param name="refferer"></param>
        public void GenerateCommissionForPPCCampaign(int campaignId, int marketingMaterialId, int affiliateId,
                                                     string ipAddress, string refferer)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@CampaignId", SqlDbType.BigInt);
            arParms[0].Value = campaignId;
            arParms[1] = new SqlParameter("@MMID", SqlDbType.BigInt);
            arParms[1].Value = marketingMaterialId;
            arParms[2] = new SqlParameter("@AffiliateId", SqlDbType.BigInt);
            arParms[2].Value = affiliateId;
            arParms[3] = new SqlParameter("@IP_Address", SqlDbType.VarChar, 200);
            arParms[3].Value = ipAddress;
            arParms[4] = new SqlParameter("@Referer", SqlDbType.VarChar, 500);
            arParms[4].Value = refferer;

            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                                      "usp_AFCreateCommissionforPPCCampaign", arParms);
        }

        /// <summary>
        /// check whether marketing material is already assigned to campaign
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="marketingMaterialId"></param>
        /// <returns></returns>
        public bool checkMMassignedToCampaign(string campaignId, string marketingMaterialId)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@campaignid", SqlDbType.BigInt);
            arParms[0].Value = campaignId;

            arParms[1] = new SqlParameter("@marketingmaterialid", SqlDbType.VarChar, 300);
            arParms[1].Value = marketingMaterialId;

            Object objreturnvalue = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure,
                                                            "usp_AFcheckMMAssignedtoCampaign", arParms);
            var i = (int)objreturnvalue;
            return i > 0 ? true : false;
        }

        #endregion
        

        public Boolean IsCouponUsedInCampaign(String strCriteria, Int16 intMode)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@criteria", SqlDbType.VarChar, 300);
            arParms[0].Value = strCriteria;

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = intMode;

            arParms[2] = new SqlParameter("@campaignexist", SqlDbType.Bit);
            arParms[2].Direction = ParameterDirection.Output;


            var tempdataset = new DataSet();
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "[usp_AFcheckCouponUsedInCampaign]",
                                      arParms);
            Boolean bolCouponUsed = false;


            bolCouponUsed = (Boolean)arParms[2].Value;
            return bolCouponUsed;
        }
        
        public List<EEventCustomer> GetAdvocateCustomerCSV(Int64 intAdvocateID)
        {
            var arparams = new SqlParameter[1];

            arparams[0] = new SqlParameter("@AdvocateId", SqlDbType.BigInt);
            arparams[0].Value = intAdvocateID;


            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "[usp_getAdvocateCustomerCSV]", arparams);
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

                    objevent.CustomerEventTestID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["EventCustomerID"]);
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
                        objevent.Customer.User.DateApplied =
                            Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["EventDate"]);
                    //////////////for using host name,ContactMethod attribute of customer entity is used/////
                    objevent.Customer.ContactMethod =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["OrganizationName"]);
                    //////////////for using dob,Answer attribute of User entity is used/////
                    objevent.Customer.User.Answer =
                        Convert.ToDateTime(tempdataset.Tables[0].Rows[icount]["DOB"]).ToString("MM/dd/yyyy");

                    objevent.Customer.Gender = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Gender"]);
                    objevent.Customer.Weight = Convert.ToSingle(tempdataset.Tables[0].Rows[icount]["WEIGHT"]);
                    objevent.Customer.Race = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Race"]);
                    objevent.Customer.Height = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Height"]);

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
                    objevent.EventPackage.Package.CostPrice =
                        decimal.Parse(tempdataset.Tables[0].Rows[icount]["CostPrice"].ToString());
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
                        continue;

                    objevent.Paid = Convert.ToBoolean(tempdataset.Tables[0].Rows[icount]["IsPaid"]);

                    DataTable tblPayment = tempdataset.Tables[1];
                    tblPayment.DefaultView.RowFilter = "EventCustomerID = " + objevent.CustomerEventTestID;

                    if (tblPayment.DefaultView.Count > 0)
                    {
                        for (int count = 0; count < tblPayment.DefaultView.Count; count++)
                        {
                            var payment = new EPaymentDetail();
                            payment.PaymentDetailID = Convert.ToInt32(tblPayment.DefaultView[count]["PaymentID"]);
                            payment.PaidAmount = Convert.ToSingle(tblPayment.DefaultView[count]["PaidAmount"]);
                            payment.PaymentType = new EPaymentType();
                            payment.PaymentType.Name = Convert.ToString(tblPayment.DefaultView[count]["Mode"]);
                            payment.DrOrCr = Convert.ToBoolean(tblPayment.DefaultView[count]["DrOrCr"]);
                            objevent.ListPaymentDetail.Add(payment);
                        }
                    }
                    //used for incoming phone line
                    objevent.Customer.User.HomeAddress.PhoneNumber =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["IncomingPhoneLine"]);
                    //used for callers phone number
                    objevent.Customer.User.PhoneCell =
                        Convert.ToString(tempdataset.Tables[0].Rows[icount]["CallersPhoneNumber"]);
                    string eventid = Convert.ToString(tempdataset.Tables[0].Rows[icount]["EventID"]);
                    if (tempdataset.Tables.Count > 2)
                    {
                        DataTable dtPod = tempdataset.Tables[2];
                        dtPod.DefaultView.RowFilter = "EventID = " + eventid;
                        if (dtPod.DefaultView.Count > 0)
                        {
                            if (dtPod.DefaultView.Count == 1)
                                objevent.PodName = Convert.ToString(dtPod.DefaultView[0]["PodName"]);
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
                    listeventcustomer.Add(objevent);
                }
            }

            return listeventcustomer;
        }

        public List<ECall> GetCategoryCall(int intCategoryID, string strStartdate, string strEndDate, int pagenumber,
                                           Int16 pagesize, out int iTotalRecordCount)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@categoryId", SqlDbType.Int);
            arParms[0].Value = intCategoryID;
            arParms[1] = new SqlParameter("@pagenumber", SqlDbType.Int);
            arParms[1].Value = pagenumber;
            arParms[2] = new SqlParameter("@pagesize", SqlDbType.Int);
            arParms[2].Value = pagesize;
            arParms[3] = new SqlParameter("@startDate", SqlDbType.VarChar, 20);
            arParms[3].Value = strStartdate;
            arParms[4] = new SqlParameter("@endDate", SqlDbType.VarChar, 20);
            arParms[4].Value = strEndDate;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "[usp_AFgetCategoryCall]", arParms);
            iTotalRecordCount = 0;
            if (tempdataset != null && tempdataset.Tables[1].Rows.Count > 0)
                iTotalRecordCount = Convert.ToInt32(tempdataset.Tables[1].Rows[0][0]);
            return ParseAdvocateCall(tempdataset);
        }

        public List<ECall> GetAdvocateCall(Int64 intAdvocateID, int pagenumber, Int16 pagesize,
                                           out int iTotalRecordCount, string strStartDate, string strEndDate)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@advocateid", SqlDbType.BigInt);
            arParms[0].Value = intAdvocateID;
            arParms[1] = new SqlParameter("@pagenumber", SqlDbType.Int);
            arParms[1].Value = pagenumber;
            arParms[2] = new SqlParameter("@pagesize", SqlDbType.Int);
            arParms[2].Value = pagesize;
            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 20);
            arParms[3].Value = strStartDate;
            arParms[4] = new SqlParameter("@enddate", SqlDbType.VarChar, 20);
            arParms[4].Value = strEndDate;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "[usp_AFgetAdvocateCall]", arParms);
            iTotalRecordCount = 0;
            if (tempdataset != null && tempdataset.Tables[1].Rows.Count > 0)
                iTotalRecordCount = Convert.ToInt32(tempdataset.Tables[1].Rows[0][0]);
            return ParseAdvocateCall(tempdataset);
        }

        public List<ECall> GetSalesRepCall(Int64 intAdvocateID, int pagenumber, Int16 pagesize,
                                           out int iTotalRecordCount, string strStartDate, string strEndDate)
        {
            var arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@salesRepid", SqlDbType.BigInt);
            arParms[0].Value = intAdvocateID;
            arParms[1] = new SqlParameter("@pagenumber", SqlDbType.Int);
            arParms[1].Value = pagenumber;
            arParms[2] = new SqlParameter("@pagesize", SqlDbType.Int);
            arParms[2].Value = pagesize;
            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 50);
            arParms[3].Value = strStartDate;
            arParms[4] = new SqlParameter("@enddate", SqlDbType.VarChar, 50);
            arParms[4].Value = strEndDate;
            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "[usp_AFgetSalesRepCall]", arParms);
            iTotalRecordCount = 0;
            if (tempdataset != null && tempdataset.Tables[1].Rows.Count > 0)
                iTotalRecordCount = Convert.ToInt32(tempdataset.Tables[1].Rows[0][0]);
            return ParseAdvocateCall(tempdataset);
        }


        private List<ECall> ParseAdvocateCall(DataSet tempdataset)
        {
            var objCalls = new List<ECall>();

            for (int count = 0; count < tempdataset.Tables[0].Rows.Count; count++)
            {
                ////////////////////////////////////////////
                var objCall = new ECall();
                objCall.SourceCode = Convert.ToString(tempdataset.Tables[0].Rows[count]["Callername"]);
                objCall.DateCreated = Convert.ToString(tempdataset.Tables[0].Rows[count]["DateCreated"]);
                objCall.CalledCustomerID = Convert.ToInt32(tempdataset.Tables[0].Rows[count]["CalledCustomerID"]);
                objCall.CallStatus = Convert.ToString(tempdataset.Tables[0].Rows[count]["CallStatus"]);
                objCall.CallBackNumber = Convert.ToString(tempdataset.Tables[0].Rows[count]["CallBackNumber"]);
                objCall.IncomingPhoneLine = Convert.ToString(tempdataset.Tables[0].Rows[count]["IncomingPhoneLine"]);

                ///////////////////////////////////////////////////////////////////////

                objCalls.Add(objCall);
            }

            return objCalls;
        }


        /// <summary>
        /// To save update source code for a customer
        /// </summary>
        /// <param name="ieventCustomerid"></param>
        /// <param name="strCouponCode"></param>
        public void UpdateSourceCode(Int64 ieventCustomerid, Int64 icouponId, string strCouponCode, Int64 icustomerId)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@eventCustomerId", SqlDbType.BigInt);
            arParms[0].Value = ieventCustomerid;

            arParms[1] = new SqlParameter("@oldcouponId", SqlDbType.BigInt);
            arParms[1].Value = icouponId;
            arParms[2] = new SqlParameter("@newCouponCode", SqlDbType.VarChar, 50);
            arParms[2].Value = strCouponCode;
            arParms[3] = new SqlParameter("@customerId", SqlDbType.BigInt);
            arParms[3].Value = icustomerId;


            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_UpdateSourceCode", arParms);
        }

        /// <summary>
        /// To save update marketing code for a customer
        /// </summary>
        /// <param name="icustomerid"></param>
        /// <param name="strMarketingSource"></param>
        public void UpdateMarketingSource(Int64 icustomerId, string strMarketingSource)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@customerId", SqlDbType.VarChar, 1000);
            arParms[0].Value = icustomerId.ToString();
            arParms[1] = new SqlParameter("@trackingmaterialId", SqlDbType.VarChar, 500);
            arParms[1].Value = strMarketingSource;


            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_UpdateMarketingSource",
                                      arParms);
        }

        /// <summary>
        /// update marketing source for customers
        /// </summary>
        /// <param name="strcustomerIds"></param>
        /// <param name="strMarketingSource"></param>
        public void UpdateAllMarketingSource(string strcustomerIds, string strMarketingSource)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@customerId", SqlDbType.VarChar, 1000);
            arParms[0].Value = strcustomerIds;
            arParms[1] = new SqlParameter("@trackingmaterialId", SqlDbType.VarChar, 500);
            arParms[1].Value = strMarketingSource;


            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_UpdateMarketingSource",
                                      arParms);
        }

        public DataTable GetCategoryGraph(int intCategoryID, Int32 intMode, string strStartdate, string strEndDate)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@categoryId", SqlDbType.VarChar, 300);
            arParms[0].Value = intCategoryID;
            /// passign string for existing SP will change once all the method replaced with new one
            arParms[1] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[1].Value = strStartdate;
            arParms[2] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[2].Value = strEndDate;
            arParms[3] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[3].Value = intMode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFGetCategoryReportGraph", arParms);
            return tempdataset.Tables[0];
        }

        public DataTable GetAdvocateGraph(Int64 intAdvocateID, Int32 intMode, string strStartDate, string strEndDate)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@affiliateId", SqlDbType.VarChar, 300);
            arParms[0].Value = intAdvocateID.ToString();
            /// passign string for existing SP will change once all the method replaced with new one
            arParms[1] = new SqlParameter("@startDate", SqlDbType.VarChar, 300);
            arParms[1].Value = strStartDate;
            arParms[2] = new SqlParameter("@endDate", SqlDbType.VarChar, 300);
            arParms[2].Value = strEndDate;
            arParms[3] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[3].Value = intMode;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFGetAffiliateReportGraph", arParms);
            return tempdataset.Tables[0];
        }

        public Int64 CreateExpressCampaignForAdvocate(String strCampaignName, Int64 intMMID, Int64 intUserId,
                                                      Int64 intRoleId, Int64 intShellId)
        {
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@campaignName", SqlDbType.VarChar, 500);
            arParms[0].Value = strCampaignName;

            arParms[1] = new SqlParameter("@MarketingMaterialID", SqlDbType.BigInt);
            arParms[1].Value = intMMID;

            arParms[2] = new SqlParameter("@campaignid", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            arParms[3] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[3].Value = intUserId;
            arParms[4] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[4].Value = intRoleId;
            arParms[5] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[5].Value = intShellId;

            var tempdataset = new DataSet();
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "[usp_AFCreateCampaignExpress]",
                                      arParms);
            Int64 intCampaign = 0;
            intCampaign = (Int64)arParms[2].Value;
            return intCampaign;
        }

        public EMarketingMaterial GetHPBannerForCustomer(Int64 intCustomerID, out Int64 intCampaignid,
                                                         out Int64 intAdvocateid, out string strassociatedphonenum)
        {
            var arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@customerid", SqlDbType.BigInt);
            arParms[0].Value = intCustomerID;

            arParms[1] = new SqlParameter("@campaignid", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;

            arParms[2] = new SqlParameter("@advocateid", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            arParms[3] = new SqlParameter("@associatedphonenumber", SqlDbType.VarChar, 100);
            arParms[3].Direction = ParameterDirection.Output;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "[usp_getHospitalFacilityBanner]", arParms);
            var objMM = new EMarketingMaterial();
            intCampaignid = 0;
            intAdvocateid = 0;
            strassociatedphonenum = "";

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                objMM.MarketingMaterialId = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["MarketingMaterialId"]);
                objMM.Title = Convert.ToString(tempdataset.Tables[0].Rows[0]["Title"]);
                objMM.IsInbound = Convert.ToBoolean(tempdataset.Tables[0].Rows[0]["IsInbound"]);
                objMM.ImagePath = Convert.ToString(tempdataset.Tables[0].Rows[0]["ImagePath"]);
                objMM.Text = Convert.ToString(tempdataset.Tables[0].Rows[0]["Text"]);
                objMM.HTMLText = Convert.ToString(tempdataset.Tables[0].Rows[0]["HTMLText"]);
                objMM.HeadingText = Convert.ToString(tempdataset.Tables[0].Rows[0]["HeadingText"]);
                objMM.LeadingInURL = Convert.ToString(tempdataset.Tables[0].Rows[0]["LeadingInURL"]);
                objMM.DisplayURL = Convert.ToString(tempdataset.Tables[0].Rows[0]["DisplayURL"]);
                intCampaignid = (Int64)arParms[1].Value;
                intAdvocateid = (Int64)arParms[2].Value;
                if (arParms[3].Value != DBNull.Value)
                    strassociatedphonenum = (string)arParms[3].Value;
            }

            return objMM;
        }

        public List<String> GetRedirectURL(Int64 intCampaignId, Int64 intMArketingMaterialID)
        {
            var arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@campaignid", SqlDbType.BigInt);
            arParms[0].Value = intCampaignId;
            arParms[1] = new SqlParameter("@marketingmaterialid", SqlDbType.BigInt);
            arParms[1].Value = intMArketingMaterialID;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "[usp_AFgetGetRedirectURL]", arParms);


            var strRedirectURLS = new List<String>();

            for (int i = 0; i < tempdataset.Tables[0].Rows.Count; i++)
            {
                String strURL;

                strURL = tempdataset.Tables[0].Rows[i]["RedirectUrl"].ToString();

                strRedirectURLS.Add(strURL);
            }
            return strRedirectURLS;
        }


        /// <summary>
        /// Gets no of customer for a category
        /// </summary>
        /// <param name="tinymode"></param>
        /// <returns></returns>
        public DataSet GetCategoryCustomer(Int16 mode, string strStartDate, string strEndDate)
        {
            var arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = mode;
            arParms[1] = new SqlParameter("@startDate", SqlDbType.VarChar, 20);
            arParms[1].Value = strStartDate;
            arParms[2] = new SqlParameter("@enddate", SqlDbType.VarChar, 20);
            arParms[2].Value = strEndDate;

            DataSet dstemp = SqlHelper.ExecuteDataset(_connectionString, 
                                                      "usp_AFgetCategoryCustomers", arParms);
            return dstemp;
        }

        public DataSet GetCampaignCustomer(int mode, Int64 intAdvocateID, string strStartdate, string strEndDate,
                                           int pagenumber, int pagesize)
        {
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[0].Value = mode;
            arParms[1] = new SqlParameter("@startDate", SqlDbType.VarChar, 20);
            arParms[1].Value = strStartdate;
            arParms[2] = new SqlParameter("@endDate", SqlDbType.VarChar, 20);
            arParms[2].Value = strEndDate;
            arParms[3] = new SqlParameter("@advocateId", SqlDbType.BigInt);
            arParms[3].Value = intAdvocateID;
            arParms[4] = new SqlParameter("@pagenumber", SqlDbType.Int);
            arParms[4].Value = pagenumber;
            arParms[5] = new SqlParameter("@pagesize", SqlDbType.Int);
            arParms[5].Value = pagesize;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFgetAdvocateCustomers", arParms);
            return tempdataset;
        }

        public DataSet GetCategoryAdvocateCustomer(int mode, Int64 intCategoryID, string strStartdate, string strEndDate,
                                                   int pagenumber, int pagesize)
        {
            var arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[0].Value = mode;
            arParms[1] = new SqlParameter("@startDate", SqlDbType.VarChar, 20);
            arParms[1].Value = strStartdate;
            arParms[2] = new SqlParameter("@endDate", SqlDbType.VarChar, 20);
            arParms[2].Value = strEndDate;
            arParms[3] = new SqlParameter("@categoryId", SqlDbType.BigInt);
            arParms[3].Value = intCategoryID;
            arParms[4] = new SqlParameter("@pagenumber", SqlDbType.Int);
            arParms[4].Value = pagenumber;
            arParms[5] = new SqlParameter("@pagesize", SqlDbType.Int);
            arParms[5].Value = pagesize;

            var tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(_connectionString, 
                                                   "usp_AFgetCategoryAdvocates", arParms);
            return tempdataset;
        }

        /// <summary>
        /// This function will return list of EFranchisee based on search criteria
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public int DeleteProspectCustomers(string strCustomerids)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@customerids", SqlDbType.VarChar, 3000);
            arParms[0].Value = strCustomerids;

            return SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "usp_DeleteProspectCustomer",
                                             arParms);
        }


    
    }
}