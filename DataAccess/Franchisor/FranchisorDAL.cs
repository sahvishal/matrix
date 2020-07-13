using System;
using System.Collections.Generic;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Franchisor;
using System.Data;
using System.Data.SqlClient;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Core.Enum;

namespace Falcon.DataAccess.Franchisor
{
    public class FranchisorDAL
    {
        private string connectionstring = ConnectionHandler.GetConnectionString();

        #region "Franchisor"



        public Int64 SaveFranchisorGlobalAttributes(EGlobalAttributes GlobalAttributes)
        {
            var arParms = new SqlParameter[72];
            arParms[0] = new SqlParameter("@daystochangepassword", SqlDbType.VarChar, 1000);
            arParms[0].Value = GlobalAttributes.DaysToChangePassword.ToString();
            arParms[1] = new SqlParameter("@numberofpictures", SqlDbType.VarChar, 1000);
            arParms[1].Value = GlobalAttributes.NumberOfPictures.ToString();
            arParms[2] = new SqlParameter("@appointmentslot", SqlDbType.VarChar, 1000);
            arParms[2].Value = GlobalAttributes.AppointmentSlot.ToString();

            arParms[3] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[3].Direction = ParameterDirection.Output;
            arParms[4] = new SqlParameter("@scheduletemplateid", SqlDbType.Int);
            arParms[4].Value = GlobalAttributes.ScheduleTemplateID;
            arParms[5] = new SqlParameter("@globalcutoffdate", SqlDbType.VarChar, 100);
            arParms[5].Value = GlobalAttributes.GlobalCutOffDate.ToString();
            arParms[6] = new SqlParameter("@mvaccessips", SqlDbType.VarChar, 1000);
            arParms[6].Value = GlobalAttributes.MVAccessIPs.ToString();

            // Begin Added By Viranjay
            arParms[7] = new SqlParameter("@ShowOrderCatalog", SqlDbType.VarChar, 100);
            arParms[7].Value = GlobalAttributes.ShowOrderCatalog;

            arParms[8] = new SqlParameter("@MVPermittedKey", SqlDbType.VarChar, 100);
            arParms[8].Value = GlobalAttributes.MVPermittedKey;

            arParms[9] = new SqlParameter("@SystemVersion", SqlDbType.VarChar, 100);
            arParms[9].Value = GlobalAttributes.SystemVersion;

            arParms[10] = new SqlParameter("@Eventdistance", SqlDbType.BigInt);
            arParms[10].Value = Convert.ToInt64(GlobalAttributes.Eventdistance);

            arParms[11] = new SqlParameter("@From", SqlDbType.VarChar, 255);
            arParms[11].Value = GlobalAttributes.FromEmailAddress;

            arParms[12] = new SqlParameter("@FromName", SqlDbType.VarChar, 255);
            arParms[12].Value = GlobalAttributes.FromEmailName;

            arParms[13] = new SqlParameter("@AdministratorEmail", SqlDbType.VarChar, 255);
            arParms[13].Value = GlobalAttributes.AdministratorEmailAddress;

            arParms[14] = new SqlParameter("@HealthyesContactEmail", SqlDbType.VarChar, 255);
            arParms[14].Value = GlobalAttributes.HealthyesContactEmailAddress;

            arParms[15] = new SqlParameter("@GoogleCalendarUsername", SqlDbType.VarChar, 255);
            arParms[15].Value = GlobalAttributes.GoogleCalendarUsername;

            arParms[16] = new SqlParameter("@GoogleCalendarPassword", SqlDbType.VarChar, 255);
            arParms[16].Value = GlobalAttributes.GoogleCalendarPassword;

            arParms[17] = new SqlParameter("@CouponPrefix", SqlDbType.VarChar, 100);
            arParms[17].Value = GlobalAttributes.CouponPrefix;

            arParms[18] = new SqlParameter("@CCRepDashBoardRefereshTime", SqlDbType.Int);
            arParms[18].Value = GlobalAttributes.CCRepDashBoardRefereshTime;

            arParms[19] = new SqlParameter("@DisplayBarOnQA", SqlDbType.VarChar, 100);
            arParms[19].Value = GlobalAttributes.DisplayQABar;

            // End Added By Viranjay

            //max commission dollar for advocvate
            arParms[20] = new SqlParameter("@MaxCommissionDollar", SqlDbType.VarChar, 100);
            arParms[20].Value = GlobalAttributes.MaxDollarCommission;

            arParms[21] = new SqlParameter("@MaxCommissionPercent", SqlDbType.VarChar, 100);
            arParms[21].Value = GlobalAttributes.MaxPercentCommission;
            arParms[22] = new SqlParameter("@MaxCommissionDollarSalesRep", SqlDbType.VarChar, 100);
            arParms[22].Value = GlobalAttributes.MaxDollarCommissionSalesRep;
            arParms[23] = new SqlParameter("@MaxCommissionPercentSalesRep", SqlDbType.VarChar, 100);
            arParms[23].Value = GlobalAttributes.MaxPercentCommissionSalesRep;
            arParms[24] = new SqlParameter("@HealthYesCompetitor", SqlDbType.VarChar, 1000);
            arParms[24].Value = GlobalAttributes.HealthYesCompetitor;
            arParms[25] = new SqlParameter("@CancellationFee", SqlDbType.VarChar, 10);
            arParms[25].Value = GlobalAttributes.CancellationFee.ToString();

            arParms[26] = new SqlParameter("@EventStartTime", SqlDbType.VarChar, 10);
            arParms[26].Value = GlobalAttributes.EventStartTime;

            arParms[27] = new SqlParameter("@EventEndTime", SqlDbType.VarChar, 10);
            arParms[27].Value = GlobalAttributes.EventEndTime;

            arParms[28] = new SqlParameter("@MinimumPurchaseAmount", SqlDbType.VarChar, 10);
            arParms[28].Value = GlobalAttributes.MinimumPurchaseAmount.ToString();

            arParms[29] = new SqlParameter("@IncomingPhoneLineRequired", SqlDbType.VarChar, 10);
            arParms[29].Value = GlobalAttributes.IncomingPhoneLineRequired;

            arParms[30] = new SqlParameter("@EnableAlaCarte", SqlDbType.VarChar, 10);
            arParms[30].Value = GlobalAttributes.EnableAlaCarte;

            arParms[31] = new SqlParameter("@Areacode", SqlDbType.VarChar, 10);
            arParms[31].Value = GlobalAttributes.AreaCode;

            arParms[32] = new SqlParameter("@EnableBarCode", SqlDbType.VarChar, 10);
            arParms[32].Value = GlobalAttributes.EnableBarCode;

            arParms[33] = new SqlParameter("@UpsellPackage", SqlDbType.VarChar, 10);
            arParms[33].Value = GlobalAttributes.UpsellPackage;

            arParms[34] = new SqlParameter("@UpsellCd", SqlDbType.VarChar, 10);
            arParms[34].Value = GlobalAttributes.UpsellCd;

            arParms[35] = new SqlParameter("@UpsellAlaCarte", SqlDbType.VarChar, 10);
            arParms[35].Value = GlobalAttributes.UpsellAlaCarte;

            arParms[36] = new SqlParameter("@MaxNoOfEventToShowOnline", SqlDbType.VarChar, 10);
            arParms[36].Value = GlobalAttributes.MaxNoOfEventToShowOnline.ToString();

            arParms[37] = new SqlParameter("@MaxNoOfAppointmentSlotsToShowOnline", SqlDbType.VarChar, 10);
            arParms[37].Value = GlobalAttributes.MaxNoOfAppointmentSlotsToShowOnline.ToString();

            arParms[38] = new SqlParameter("@EventListPageSizeOnline", SqlDbType.VarChar, 10);
            arParms[38].Value = GlobalAttributes.EventListPageSizeOnline.ToString();

            arParms[39] = new SqlParameter("@PaperSize", SqlDbType.VarChar, 20);
            arParms[39].Value = GlobalAttributes.PaperSize;

            arParms[40] = new SqlParameter("@DisplayPremiumVersiononPortal", SqlDbType.VarChar, 10);
            arParms[40].Value = GlobalAttributes.DisplayPremiumVersiononPortal;

            arParms[41] = new SqlParameter("@EnableResultDeliveryNotification", SqlDbType.VarChar, 10);
            arParms[41].Value = GlobalAttributes.EnableResultDeliveryNotification;

            arParms[42] = new SqlParameter("@EnableNewsletterPrompt", SqlDbType.VarChar, 10);
            arParms[42].Value = GlobalAttributes.EnableNewsletterPrompt;

            arParms[43] = new SqlParameter("@SourceCodeLabel", SqlDbType.VarChar, 20);
            arParms[43].Value = GlobalAttributes.SourceCodeLabel;

            arParms[44] = new SqlParameter("@CutOffHourNumberforOnlineEventSelection", SqlDbType.VarChar, 10);
            arParms[44].Value = GlobalAttributes.CutOffHourNumberforOnlineEventSelection;

            arParms[45] = new SqlParameter("@DisplayRescheduleAppointmentPortal", SqlDbType.VarChar, 10);
            arParms[45].Value = GlobalAttributes.DisplayRescheduleAppointmentPortal;

            arParms[46] = new SqlParameter("@ShowBasicBiometric", SqlDbType.VarChar, 10);
            arParms[46].Value = GlobalAttributes.ShowBasicBiometric;

            arParms[47] = new SqlParameter("@EnableQuickOnsiteRegistration", SqlDbType.VarChar, 10);
            arParms[47].Value = GlobalAttributes.EnableQuickOnsiteRegistration;

            arParms[48] = new SqlParameter("@PayLaterOnlineRegistration", SqlDbType.VarChar, 10);
            arParms[48].Value = GlobalAttributes.PayLaterOnlineRegistration;

            arParms[49] = new SqlParameter("@RestrictAvailableTimeSlotForCorporate", SqlDbType.VarChar, 10);
            arParms[49].Value = GlobalAttributes.RestrictAvailableTimeSlotForCorporate;

            arParms[50] = new SqlParameter("@ScreeningReminderNotification", SqlDbType.VarChar, 10);
            arParms[50].Value = GlobalAttributes.ScreeningReminderNotification;

            arParms[51] = new SqlParameter("@IsHipaaEnabled", SqlDbType.VarChar, 10);
            arParms[51].Value = GlobalAttributes.IsHipaaEnabled;

            arParms[52] = new SqlParameter("@EnableDynamicSlot", SqlDbType.VarChar, 10);
            arParms[52].Value = GlobalAttributes.EnableDynamicSlot;

            arParms[53] = new SqlParameter("@LunchStartTime", SqlDbType.VarChar, 10);
            arParms[53].Value = GlobalAttributes.LunchStartTime;

            arParms[54] = new SqlParameter("@SendEmptyQueueEvaluationReminder", SqlDbType.VarChar, 10);
            arParms[54].Value = GlobalAttributes.SendEmptyQueueEvaluationReminder;

            arParms[55] = new SqlParameter("@EventBookingThreshold", SqlDbType.VarChar, 10);
            arParms[55].Value = GlobalAttributes.EventBookingThreshold;

            arParms[56] = new SqlParameter("@PackageSelectionInfo", SqlDbType.VarChar, 10);
            arParms[56].Value = GlobalAttributes.PackageSelectionInfo;

            arParms[57] = new SqlParameter("@EnableSmsNotification", SqlDbType.VarChar, 10);
            arParms[57].Value = GlobalAttributes.EnableSmsNotification;

            arParms[58] = new SqlParameter("@EnablePhysicianPartnerCustomerResultFaxNotification", SqlDbType.VarChar, 10);
            arParms[58].Value = GlobalAttributes.EnablePhysicianPartnerCustomerResultFaxNotification;

            arParms[59] = new SqlParameter("@EnableAWVCustomerResultFaxNotification", SqlDbType.VarChar, 10);
            arParms[59].Value = GlobalAttributes.EnableAWVCustomerResultFaxNotification;

            arParms[60] = new SqlParameter("@AskPreQualificationQuestion", SqlDbType.VarChar, 10);
            arParms[60].Value = GlobalAttributes.AskPreQualificationQuestion;

            arParms[61] = new SqlParameter("@PasswordExpirationDays", SqlDbType.VarChar, 10);
            arParms[61].Value = GlobalAttributes.PasswordExpirationDays;

            arParms[62] = new SqlParameter("@PreviousPasswordNonRepetitionCount", SqlDbType.VarChar, 10);
            arParms[62].Value = GlobalAttributes.PreviousPasswordNonRepetitionCount;

            arParms[63] = new SqlParameter("@OtpNotificationMediumEmail", SqlDbType.VarChar, 10);
            arParms[63].Value = GlobalAttributes.OtpNotificationMediumEmail;

            arParms[64] = new SqlParameter("@OtpNotificationMediumSms", SqlDbType.VarChar, 10);
            arParms[64].Value = GlobalAttributes.OtpNotificationMediumSms;

            arParms[65] = new SqlParameter("@OtpExpirationMinutes", SqlDbType.VarChar, 10);
            arParms[65].Value = GlobalAttributes.OtpExpirationMinutes;

            arParms[66] = new SqlParameter("@OtpMisMatchAttemptCount", SqlDbType.VarChar, 10);
            arParms[66].Value = GlobalAttributes.OtpMisMatchAttemptCount;

            arParms[67] = new SqlParameter("@OtpByGoogleAuthenticator", SqlDbType.VarChar, 10);
            arParms[67].Value = GlobalAttributes.OtpByGoogleAuthenticator;

            arParms[68] = new SqlParameter("@AllowSafeComputerRemember", SqlDbType.VarChar, 10);
            arParms[68].Value = GlobalAttributes.AllowSafeComputerRemember;

            arParms[69] = new SqlParameter("@SafeDeviceExpiryDays", SqlDbType.VarChar, 10);
            arParms[69].Value = GlobalAttributes.SafeDeviceExpiryDays;

            arParms[70] = new SqlParameter("@AlertBeforePasswordExpirationInDays", SqlDbType.VarChar, 10);
            arParms[70].Value = GlobalAttributes.AlertBeforePasswordExpirationInDays;

            arParms[71] = new SqlParameter("@EnableVoiceMailNotification", SqlDbType.VarChar, 10);
            arParms[71].Value = GlobalAttributes.EnableVoiceMailNotification;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_SaveGlobalAttributesFranchisor", arParms);
            return (Int64)arParms[3].Value;
        }

        public EGlobalAttributes GetFranchisorGlobalAttributes()
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = 1;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getGlobalAttributesFranchisor", arParms);

            EGlobalAttributes returnFranchisorGlobalAttributes = new EGlobalAttributes();
            returnFranchisorGlobalAttributes = ParseFranchisorGlobalAttributes(tempdataset);
            return returnFranchisorGlobalAttributes;
        }

        private EGlobalAttributes ParseFranchisorGlobalAttributes(DataSet FranchisorGlobalAttributesDataSet)
        {
            var returnFranchisorGlobalAttributes = new EGlobalAttributes();

            for (int count = 0; count < FranchisorGlobalAttributesDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    returnFranchisorGlobalAttributes.AppointmentSlot = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["AppointmentSlot"]);
                    returnFranchisorGlobalAttributes.DaysToChangePassword = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["DaysToChangePassword"]);
                    returnFranchisorGlobalAttributes.NumberOfPictures = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["NumberOfPictures"]);
                    returnFranchisorGlobalAttributes.ScheduleTemplateID = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["ScheduleTemplateID"]);
                    returnFranchisorGlobalAttributes.GlobalCutOffDate = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["GlobalCutOffDate"]);
                    returnFranchisorGlobalAttributes.MVAccessIPs = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["MVAccessIPs"]);

                    returnFranchisorGlobalAttributes.ShowOrderCatalog = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["ShowOrderCatalog"]);
                    returnFranchisorGlobalAttributes.MVPermittedKey = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["MVPermittedKey"]);
                    returnFranchisorGlobalAttributes.SystemVersion = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["SystemVersion"]);
                    returnFranchisorGlobalAttributes.Eventdistance = Convert.ToInt64(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["Eventdistance"]);
                    returnFranchisorGlobalAttributes.FromEmailAddress = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["From"]);
                    returnFranchisorGlobalAttributes.FromEmailName = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["FromName"]);
                    returnFranchisorGlobalAttributes.AdministratorEmailAddress = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["AdministratorEmail"]);

                    returnFranchisorGlobalAttributes.GoogleCalendarUsername = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["GoogleCalendarUsername"]);
                    returnFranchisorGlobalAttributes.GoogleCalendarPassword = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["GoogleCalendarPassword"]);
                    returnFranchisorGlobalAttributes.CouponPrefix = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["CouponPrefix"]);
                    returnFranchisorGlobalAttributes.CCRepDashBoardRefereshTime = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["CCRepDashBoardRefereshTime"]);
                    returnFranchisorGlobalAttributes.DisplayQABar = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["DisplayBarOnQA"]);

                    returnFranchisorGlobalAttributes.MaxDollarCommission = Convert.ToDecimal(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["MaxDollarCommission"]);
                    returnFranchisorGlobalAttributes.MaxPercentCommission = Convert.ToDecimal(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["MaxPercentCommission"]);
                    returnFranchisorGlobalAttributes.MaxDollarCommissionSalesRep = Convert.ToDecimal(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["MaxDollarCommissionSalesRep"]);
                    returnFranchisorGlobalAttributes.MaxPercentCommissionSalesRep = Convert.ToDecimal(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["MaxPercentCommissionSalesRep"]);
                    returnFranchisorGlobalAttributes.HealthYesCompetitor = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["Competitor"]);
                    returnFranchisorGlobalAttributes.CancellationFee = Convert.ToDecimal(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["CancellationFee"]);
                    returnFranchisorGlobalAttributes.EventStartTime = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EventStartTime"]);
                    returnFranchisorGlobalAttributes.EventEndTime = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EventEndTime"]);
                    returnFranchisorGlobalAttributes.MinimumPurchaseAmount = Convert.ToDecimal(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["MinimumPurchaseAmount"]);
                    returnFranchisorGlobalAttributes.IncomingPhoneLineRequired = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["IncomingPhoneLineRequired"]);
                    returnFranchisorGlobalAttributes.EnableAlaCarte = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnableAlaCarte"]);
                    returnFranchisorGlobalAttributes.AreaCode = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["AreaCode"]);
                    returnFranchisorGlobalAttributes.EnableBarCode = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnableBarCode"]);
                    returnFranchisorGlobalAttributes.UpsellPackage = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["UpsellPackage"]);
                    returnFranchisorGlobalAttributes.UpsellCd = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["UpsellCd"]);
                    returnFranchisorGlobalAttributes.UpsellAlaCarte = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["UpsellAlaCarte"]);
                    returnFranchisorGlobalAttributes.MaxNoOfEventToShowOnline = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["MaxNoOfEventToShowOnline"]);
                    returnFranchisorGlobalAttributes.MaxNoOfAppointmentSlotsToShowOnline = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["MaxNoOfAppointmentSlotsToShowOnline"]);
                    returnFranchisorGlobalAttributes.EventListPageSizeOnline = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EventListPageSizeOnline"]);
                    returnFranchisorGlobalAttributes.PaperSize = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["PaperSize"]);
                    returnFranchisorGlobalAttributes.DisplayPremiumVersiononPortal = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["DisplayPremiumVersiononPortal"]);
                    returnFranchisorGlobalAttributes.EnableResultDeliveryNotification = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnableResultDeliveryNotification"]);
                    returnFranchisorGlobalAttributes.EnableNewsletterPrompt = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnableNewsletterPrompt"]);
                    returnFranchisorGlobalAttributes.SourceCodeLabel = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["SourceCodeLabel"]);
                    returnFranchisorGlobalAttributes.CutOffHourNumberforOnlineEventSelection = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["CutOffHourNumberforOnlineEventSelection"]);
                    returnFranchisorGlobalAttributes.DisplayRescheduleAppointmentPortal = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["DisplayRescheduleAppointmentPortal"]);
                    returnFranchisorGlobalAttributes.ShowBasicBiometric = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["ShowBasicBiometric"]);
                    returnFranchisorGlobalAttributes.EnableQuickOnsiteRegistration = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnableQuickOnsiteRegistration"]);
                    returnFranchisorGlobalAttributes.PayLaterOnlineRegistration = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["PayLaterOnlineRegistration"]);
                    returnFranchisorGlobalAttributes.RestrictAvailableTimeSlotForCorporate = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["RestrictAvailableTimeSlotForCorporate"]);
                    returnFranchisorGlobalAttributes.ScreeningReminderNotification = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["ScreeningReminderNotification"]);
                    returnFranchisorGlobalAttributes.IsHipaaEnabled = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["IsHipaaEnabled"]);
                    returnFranchisorGlobalAttributes.EnableDynamicSlot = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnableDynamicSlot"]);
                    returnFranchisorGlobalAttributes.LunchStartTime = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["LunchStartTime"]);
                    returnFranchisorGlobalAttributes.SendEmptyQueueEvaluationReminder = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["SendEmptyQueueEvaluationReminder"]);
                    returnFranchisorGlobalAttributes.EventBookingThreshold = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EventBookingThreshold"]);
                    returnFranchisorGlobalAttributes.PackageSelectionInfo = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["PackageSelectionInfo"]);
                    returnFranchisorGlobalAttributes.EnableSmsNotification = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnableSmsNotification"]);
                    returnFranchisorGlobalAttributes.EnablePhysicianPartnerCustomerResultFaxNotification = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnablePhysicianPartnerCustomerResultFaxNotification"]);
                    returnFranchisorGlobalAttributes.EnableAWVCustomerResultFaxNotification = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnableAWVCustomerResultFaxNotification"]);
                    returnFranchisorGlobalAttributes.AskPreQualificationQuestion = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["AskPreQualificationQuestion"]);
                    returnFranchisorGlobalAttributes.PasswordExpirationDays = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["PasswordExpirationDays"]);
                    returnFranchisorGlobalAttributes.PreviousPasswordNonRepetitionCount = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["PreviousPasswordNonRepetitionCount"]);
                    returnFranchisorGlobalAttributes.OtpNotificationMediumEmail = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["OtpNotificationMediumEmail"]);
                    returnFranchisorGlobalAttributes.OtpNotificationMediumSms = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["OtpNotificationMediumSms"]);
                    returnFranchisorGlobalAttributes.OtpExpirationMinutes = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["OtpExpirationMinutes"]);
                    returnFranchisorGlobalAttributes.OtpMisMatchAttemptCount = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["OtpMisMatchAttemptCount"]);

                    returnFranchisorGlobalAttributes.OtpByGoogleAuthenticator = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["OtpByGoogleAuthenticator"]);
                    returnFranchisorGlobalAttributes.AllowSafeComputerRemember = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["AllowSafeComputerRemember"]);
                    returnFranchisorGlobalAttributes.SafeDeviceExpiryDays = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["SafeDeviceExpiryDays"]);
                    returnFranchisorGlobalAttributes.AlertBeforePasswordExpirationInDays = Convert.ToInt32(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["AlertBeforePasswordExpirationInDays"]);
                    returnFranchisorGlobalAttributes.EnableVoiceMailNotification = Convert.ToString(FranchisorGlobalAttributesDataSet.Tables[0].Rows[count]["EnableVoiceMailNotification"]);

                }
                catch
                {
                }
            }
            return returnFranchisorGlobalAttributes;
        }

        /// <summary>
        /// Gets CustomerSignUps and Leads for Chart displayed on 
        /// Franchisor Dashboard
        /// </summary>
        /// <param name="tinymode"></param>
        /// <returns></returns>
        public DataSet GetCustomerSignUpsandLeadsforDashboard(Int16 mode)
        {
            SqlParameter arparam = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparam.Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(connectionstring, "usp_getCustomerSignUpsandLeadsforFranchisorDashboard", arparam);
            return dstemp;
        }

        /// <summary>
        /// Gets Package Wise Revenue for 
        /// Franchisor Dashboard
        /// </summary>
        /// <param name="tinymode"></param>
        /// <returns></returns>
        public DataSet GetPackageWiseRevenueDistributionforDashboard(Int16 mode)
        {
            SqlParameter arparam = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparam.Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(connectionstring, "usp_getPackageWiseRevenueDistribution", arparam);
            return dstemp;
        }

        /// <summary>
        /// Get Data for recent Activities Panel on Dashboard on the basis of mode supplied.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public DataSet GetRecentActivitiesforDashboard(Int16 mode)
        {
            SqlParameter arparam = new SqlParameter("@mode", SqlDbType.TinyInt);
            arparam.Value = mode;

            DataSet dstemp = SqlHelper.ExecuteDataset(connectionstring, "usp_getrecentactivitiesforfranchisordashboard", arparam);
            return dstemp;
        }

        /// <summary>
        ///  Get list users
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="intFranchiseeID"></param>
        /// <param name="intMode"></param>
        /// <returns></returns>
        public List<Entity.Other.EUser> GetUsers(string strName, int intMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@username", SqlDbType.VarChar, 100);
            arParms[0].Value = strName;

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = intMode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getUsers", arParms);

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
        #endregion

        #region "FranchisorUser"
        public Int64 SaveFranchisorUser(EFranchisorUser franchisoruser, int Mode, string Shell)
        {

            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[24];
            arParms[0] = new SqlParameter("@franchisoruserid", SqlDbType.BigInt);
            arParms[0].Value = franchisoruser.FranchisorUserID;
            arParms[1] = new SqlParameter("@userid1", SqlDbType.BigInt);
            arParms[1].Value = franchisoruser.User.UserID;
            arParms[2] = new SqlParameter("@addressid", SqlDbType.BigInt);
            arParms[2].Value = franchisoruser.Address.AddressID;
            arParms[3] = new SqlParameter("@cityid", SqlDbType.BigInt);
            arParms[3].Value = franchisoruser.Address.CityID;
            arParms[4] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[4].Value = franchisoruser.Address.StateID;
            arParms[5] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[5].Value = franchisoruser.Address.CountryID;
            arParms[6] = new SqlParameter("@address", SqlDbType.VarChar, 500);
            arParms[6].Value = franchisoruser.Address.Address1;
            arParms[7] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[7].Value = franchisoruser.User.FirstName;
            arParms[8] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[8].Value = franchisoruser.User.LastName;
            arParms[9] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[9].Value = franchisoruser.User.PhoneHome;
            arParms[10] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[10].Value = franchisoruser.User.PhoneOffice;
            arParms[11] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[11].Value = franchisoruser.User.PhoneCell;
            arParms[12] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
            arParms[12].Value = franchisoruser.User.EMail1;
            arParms[13] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
            arParms[13].Value = franchisoruser.User.EMail2;
            arParms[14] = new SqlParameter("@zipid", SqlDbType.BigInt);
            arParms[14].Value = franchisoruser.Address.ZipID;

            arParms[15] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[15].Value = franchisoruser.User.MiddleName;
            arParms[16] = new SqlParameter("@ssn", SqlDbType.VarChar, 500);
            arParms[16].Value = franchisoruser.User.SSN;
            arParms[17] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[17].Value = franchisoruser.Address.Address2;
            arParms[18] = new SqlParameter("@dob", SqlDbType.VarChar, 500);
            arParms[18].Value = franchisoruser.User.DOB;

            arParms[19] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[19].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savefranchisoruser", arParms);
            returnvalue = (Int64)arParms[19].Value;
            OtherDAL objOtherDal = new Other.OtherDAL();
            objOtherDal.UpdateShellDescription(franchisoruser.ShellDescription, ERoleType.Franchisor.ToString(), Shell);

            return returnvalue; ;
        }
        public Int64 SaveFranchisorUserImages(EFranchisorUser franchisoruser, int Mode, string UserID, string Shell, string Role)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[20];
            arParms[0] = new SqlParameter("@userid1", SqlDbType.BigInt);
            arParms[0].Value = franchisoruser.User.UserID;
            arParms[1] = new SqlParameter("@mypicture", SqlDbType.VarChar, 2000);
            arParms[1].Value = franchisoruser.MyPicture;
            arParms[2] = new SqlParameter("@teampicture", SqlDbType.VarChar, 2000);
            arParms[2].Value = franchisoruser.TeamPicture;
            arParms[3] = new SqlParameter("@picture1", SqlDbType.VarChar, 2000);
            arParms[3].Value = franchisoruser.OtherPictures[0];
            arParms[4] = new SqlParameter("@picture2", SqlDbType.VarChar, 2000);
            arParms[4].Value = franchisoruser.OtherPictures[1];
            arParms[5] = new SqlParameter("@picture3", SqlDbType.VarChar, 2000);
            arParms[5].Value = franchisoruser.OtherPictures[2];
            arParms[6] = new SqlParameter("@picture4", SqlDbType.VarChar, 2000);
            arParms[6].Value = franchisoruser.OtherPictures[3];
            arParms[7] = new SqlParameter("@picture5", SqlDbType.VarChar, 2000);
            arParms[7].Value = franchisoruser.OtherPictures[4];
            arParms[8] = new SqlParameter("@picture6", SqlDbType.VarChar, 2000);
            arParms[8].Value = franchisoruser.OtherPictures[5];
            arParms[9] = new SqlParameter("@picture7", SqlDbType.VarChar, 2000);
            arParms[9].Value = franchisoruser.OtherPictures[6];
            arParms[10] = new SqlParameter("@picture8", SqlDbType.VarChar, 2000);
            arParms[10].Value = franchisoruser.OtherPictures[7];
            arParms[11] = new SqlParameter("@picture9", SqlDbType.VarChar, 2000);
            arParms[11].Value = franchisoruser.OtherPictures[8];
            arParms[12] = new SqlParameter("@picture10", SqlDbType.VarChar, 2000);
            arParms[12].Value = franchisoruser.OtherPictures[9];
            arParms[13] = new SqlParameter("@picture11", SqlDbType.VarChar, 2000);
            arParms[13].Value = franchisoruser.OtherPictures[10];
            arParms[14] = new SqlParameter("@picture12", SqlDbType.VarChar, 2000);
            arParms[14].Value = franchisoruser.OtherPictures[11];

            arParms[15] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[15].Value = UserID;
            arParms[16] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[16].Value = Shell;
            arParms[17] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[17].Value = Role;
            arParms[18] = new SqlParameter("@userroletype", SqlDbType.VarChar, 500);
            arParms[18].Value = ERoleType.Franchisor;
            arParms[19] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[19].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveuserimage", arParms);
            returnvalue = (Int64)arParms[19].Value;
            return returnvalue; ;
        }

        public List<EFranchisorUser> GetFranchisorUser(String filterString, String UserID, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            arParms[2] = new SqlParameter("@userid", SqlDbType.VarChar, 500);
            arParms[2].Value = UserID;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getfranchisoruser", arParms);

            List<EFranchisorUser> returnFranchisorUser = new List<EFranchisorUser>();
            returnFranchisorUser = ParseFranchisorUserDataSet(tempdataset);
            return returnFranchisorUser;
        }
        private List<EFranchisorUser> ParseFranchisorUserDataSet(DataSet franchisoruserDataSet)
        {
            List<EFranchisorUser> returnFranchisorUser = new List<EFranchisorUser>();

            for (int count = 0; count < franchisoruserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EFranchisorUser franchisoruser = new EFranchisorUser();
                    EUser user = new Entity.Other.EUser();
                    EAddress address = new EAddress();
                    user.UserID = Convert.ToInt32(franchisoruserDataSet.Tables[0].Rows[count]["UserID"]);
                    user.FirstName = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["FirstName"]);
                    user.MiddleName = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["MiddleName"]);
                    user.LastName = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["LastName"]);
                    user.PhoneHome = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["PhoneHome"]);
                    user.PhoneCell = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["PhoneCell"]);
                    user.PhoneOffice = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["PhoneOffice"]);
                    user.EMail1 = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["EMail1"]);
                    user.EMail2 = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["EMail2"]);
                    user.DOB = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["DOB"]);
                    user.SSN = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["SSN"]);

                    franchisoruser.FranchisorUserID = Convert.ToInt32(franchisoruserDataSet.Tables[0].Rows[count]["FranchisorUserID"]);
                    franchisoruser.MyPicture = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["MyPicture"]);
                    franchisoruser.TeamPicture = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["TeamPicture"]);
                    List<string> otherpicture = new List<string>();
                    for (int icount = 1; icount < 13; icount++)
                    {
                        otherpicture.Add(franchisoruserDataSet.Tables[0].Rows[count]["Picture" + icount].ToString());
                    }
                    franchisoruser.OtherPictures = otherpicture;

                    address.Address1 = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["Address1"]);
                    address.Address2 = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["Address2"]);
                    address.CityID = Convert.ToInt32(franchisoruserDataSet.Tables[0].Rows[count]["CityID"]);
                    address.City = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["City"]);
                    address.CountryID = Convert.ToInt32(franchisoruserDataSet.Tables[0].Rows[count]["CountryID"]);
                    address.Country = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["Country"]);
                    address.StateID = Convert.ToInt32(franchisoruserDataSet.Tables[0].Rows[count]["StateID"]);
                    address.State = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["State"]);
                    address.Zip = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["ZipCode"]);
                    //address.Active = Convert.ToBoolean(franchisoruserDataSet.Tables[0].Rows[count]["IsActive"]);

                    franchisoruser.ShellDescription = Convert.ToString(franchisoruserDataSet.Tables[0].Rows[count]["Description"]);

                    franchisoruser.User = user;
                    user.HomeAddress = address;
                    franchisoruser.Address = address;
                    returnFranchisorUser.Add(franchisoruser);
                }
                catch (Exception)
                {
                }
            }
            return returnFranchisorUser;
        }
        public List<EFranchisorUser> ContactEIP()
        {
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_geteipcontact", null);

            List<EFranchisorUser> returnFranchisorUser = new List<EFranchisorUser>();
            returnFranchisorUser = ParseContactEIPDataSet(tempdataset);
            return returnFranchisorUser;
        }
        private List<EFranchisorUser> ParseContactEIPDataSet(DataSet franchiseeuserDataSet)
        {
            List<EFranchisorUser> returnFranchisorUser = new List<EFranchisorUser>();

            for (int count = 0; count < franchiseeuserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EFranchisorUser franchiseeuser = new EFranchisorUser();
                    EUser user = new Entity.Other.EUser();
                    EAddress address = new EAddress();
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

                    franchiseeuser.User = user;
                    user.HomeAddress = address;
                    franchiseeuser.Address = address;
                    returnFranchisorUser.Add(franchiseeuser);
                }
                catch (Exception)
                {
                }

            }
            return returnFranchisorUser;
        }
        #endregion

        #region "FranchisorFranchisorUser"
        public Int64 SaveFranchisorFranchisorUser(EFranchisorFranchisorUser franchisorfranchisoruser, int Mode, long Shell)
        {
            SqlConnection conobj = new SqlConnection(connectionstring);
            if (conobj.State == ConnectionState.Closed)
            {
                conobj.Open();
            }
            SqlTransaction tranobj = conobj.BeginTransaction();
            Int64 returnvalue = new Int64();
            Int64 getreturn = new Int64();
            try
            {
                SqlParameter[] arParms = new SqlParameter[24];
                arParms[0] = new SqlParameter("@franchisorfranchisoruserid", SqlDbType.BigInt);
                arParms[0].Value = franchisorfranchisoruser.FranchisorFranchisorUserID;
                arParms[1] = new SqlParameter("@franchisoruserid", SqlDbType.BigInt);
                arParms[1].Value = franchisorfranchisoruser.FranchisorUser.FranchisorUserID;
                arParms[2] = new SqlParameter("@franchisorid", SqlDbType.BigInt);
                arParms[2].Value = franchisorfranchisoruser.Franchisor.FranchisorID;
                arParms[3] = new SqlParameter("@userid1", SqlDbType.BigInt);
                arParms[3].Value = franchisorfranchisoruser.FranchisorUser.User.UserID;
                arParms[4] = new SqlParameter("@addressid", SqlDbType.BigInt);
                arParms[4].Value = franchisorfranchisoruser.FranchisorUser.User.HomeAddress.AddressID;
                arParms[5] = new SqlParameter("@cityid", SqlDbType.BigInt);
                arParms[5].Value = franchisorfranchisoruser.FranchisorUser.User.HomeAddress.CityID;
                arParms[6] = new SqlParameter("@stateid", SqlDbType.BigInt);
                arParms[6].Value = franchisorfranchisoruser.FranchisorUser.User.HomeAddress.StateID;
                arParms[7] = new SqlParameter("@countryid", SqlDbType.BigInt);
                arParms[7].Value = franchisorfranchisoruser.FranchisorUser.User.HomeAddress.CountryID;
                arParms[8] = new SqlParameter("@address", SqlDbType.VarChar, 500);
                arParms[8].Value = franchisorfranchisoruser.FranchisorUser.User.HomeAddress.Address1;
                arParms[9] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
                arParms[9].Value = franchisorfranchisoruser.FranchisorUser.User.FirstName;
                arParms[10] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
                arParms[10].Value = franchisorfranchisoruser.FranchisorUser.User.LastName;
                arParms[11] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
                arParms[11].Value = franchisorfranchisoruser.FranchisorUser.User.PhoneHome;
                arParms[12] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
                arParms[12].Value = franchisorfranchisoruser.FranchisorUser.User.PhoneOffice;
                arParms[13] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
                arParms[13].Value = franchisorfranchisoruser.FranchisorUser.User.PhoneCell;
                arParms[14] = new SqlParameter("@email1", SqlDbType.VarChar, 500);
                arParms[14].Value = franchisorfranchisoruser.FranchisorUser.User.EMail1;
                arParms[15] = new SqlParameter("@email2", SqlDbType.VarChar, 500);
                arParms[15].Value = franchisorfranchisoruser.FranchisorUser.User.EMail2;
                arParms[16] = new SqlParameter("@zipid", SqlDbType.BigInt);
                arParms[16].Value = franchisorfranchisoruser.FranchisorUser.User.HomeAddress.ZipID;
                arParms[17] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
                arParms[17].Value = franchisorfranchisoruser.FranchisorUser.User.MiddleName;
                arParms[18] = new SqlParameter("@ssn", SqlDbType.VarChar, 500);
                arParms[18].Value = franchisorfranchisoruser.FranchisorUser.User.SSN;
                arParms[19] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
                arParms[19].Value = franchisorfranchisoruser.FranchisorUser.User.HomeAddress.Address2;
                arParms[20] = new SqlParameter("@dob", SqlDbType.VarChar, 500);
                arParms[20].Value = franchisorfranchisoruser.FranchisorUser.User.DOB;
                arParms[21] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
                arParms[21].Value = Mode;
                arParms[22] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
                arParms[22].Value = Shell;
                arParms[23] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
                arParms[23].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(tranobj, CommandType.StoredProcedure, "usp_savefranchisorfranchisoruser", arParms);
                returnvalue = (Int64)arParms[23].Value;
                MasterDAL masterdal = new Master.MasterDAL();
                if (Mode == 0)
                {
                    getreturn = masterdal.SaveUserImages(Convert.ToInt64(returnvalue), franchisorfranchisoruser.FranchisorUser.MyPicture, franchisorfranchisoruser.FranchisorUser.TeamPicture, franchisorfranchisoruser.FranchisorUser.OtherPictures, ERoleType.Franchisor, Mode, Shell, tranobj);
                }
                else
                {
                    getreturn = masterdal.SaveUserImages(Convert.ToInt64(franchisorfranchisoruser.FranchisorUser.User.UserID), franchisorfranchisoruser.FranchisorUser.MyPicture, franchisorfranchisoruser.FranchisorUser.TeamPicture, franchisorfranchisoruser.FranchisorUser.OtherPictures, ERoleType.Franchisor, Mode, Shell, tranobj);
                }
                if (getreturn == 999998 || getreturn == -1)
                {
                    tranobj.Rollback();
                    return -1;
                }
                tranobj.Commit();

            }
            catch (Exception ex)
            {
                tranobj.Rollback();
                throw ex;
            }
            return returnvalue; ;
        }
        public Int64 SaveFranchisorFranchisorUserImages(EFranchisorFranchisorUser franchisorfranchisoruser, int Mode, string UserID, string Shell, string Role)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[19];
            arParms[0] = new SqlParameter("@userid1", SqlDbType.BigInt);
            arParms[0].Value = franchisorfranchisoruser.FranchisorUser.User.UserID;
            arParms[1] = new SqlParameter("@mypicture", SqlDbType.VarChar, 2000);
            arParms[1].Value = franchisorfranchisoruser.FranchisorUser.MyPicture;
            arParms[2] = new SqlParameter("@teampicture", SqlDbType.VarChar, 2000);
            arParms[2].Value = franchisorfranchisoruser.FranchisorUser.TeamPicture;
            arParms[3] = new SqlParameter("@picture1", SqlDbType.VarChar, 2000);
            arParms[3].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[0];
            arParms[4] = new SqlParameter("@picture2", SqlDbType.VarChar, 2000);
            arParms[4].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[1];
            arParms[5] = new SqlParameter("@picture3", SqlDbType.VarChar, 2000);
            arParms[5].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[2];
            arParms[6] = new SqlParameter("@picture4", SqlDbType.VarChar, 2000);
            arParms[6].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[3];
            arParms[7] = new SqlParameter("@picture5", SqlDbType.VarChar, 2000);
            arParms[7].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[4];
            arParms[8] = new SqlParameter("@picture6", SqlDbType.VarChar, 2000);
            arParms[8].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[5];
            arParms[9] = new SqlParameter("@picture7", SqlDbType.VarChar, 2000);
            arParms[9].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[6];
            arParms[10] = new SqlParameter("@picture8", SqlDbType.VarChar, 2000);
            arParms[10].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[7];
            arParms[11] = new SqlParameter("@picture9", SqlDbType.VarChar, 2000);
            arParms[11].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[8];
            arParms[12] = new SqlParameter("@picture10", SqlDbType.VarChar, 2000);
            arParms[12].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[9];
            arParms[13] = new SqlParameter("@picture11", SqlDbType.VarChar, 2000);
            arParms[13].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[10];
            arParms[14] = new SqlParameter("@picture12", SqlDbType.VarChar, 2000);
            arParms[14].Value = franchisorfranchisoruser.FranchisorUser.OtherPictures[11];

            arParms[15] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[15].Value = UserID;
            arParms[16] = new SqlParameter("@shell", SqlDbType.VarChar, 1000);
            arParms[16].Value = Shell;
            arParms[17] = new SqlParameter("@role", SqlDbType.VarChar, 500);
            arParms[17].Value = Role;

            arParms[18] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[18].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savefranchisorfranchisoruserimage", arParms);
            returnvalue = (Int64)arParms[18].Value;
            return returnvalue; ;
        }
        public Int64 SaveFranchisorFranchisorUser(String franchisorfranchisoruserID, int Mode)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@franchisorfranchisoruserid", SqlDbType.VarChar, 3000);
            arParms[0].Value = franchisorfranchisoruserID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removefranchisorfranchisoruser", arParms);
            returnvalue = (Int64)arParms[2].Value;
            return returnvalue;
        }
        public List<EFranchisorFranchisorUser> GetFranchisorFranchisorUser(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getfranchisorfranchisoruser", arParms);

            List<EFranchisorFranchisorUser> returnFranchisorFranchisorUser = new List<EFranchisorFranchisorUser>();
            returnFranchisorFranchisorUser = ParseFranchisorFranchisorUserDataSet(tempdataset);
            return returnFranchisorFranchisorUser;
        }
        private List<EFranchisorFranchisorUser> ParseFranchisorFranchisorUserDataSet(DataSet franchisorfranchisoruserDataSet)
        {
            List<EFranchisorFranchisorUser> returnFranchisorFranchisorUser = new List<EFranchisorFranchisorUser>();

            for (int count = 0; count < franchisorfranchisoruserDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EFranchisorFranchisorUser franchisorfranchisoruser = new EFranchisorFranchisorUser();
                    EFranchisor franchisor = new EFranchisor();
                    EFranchisorUser franchisoruser = new EFranchisorUser();
                    EUser user = new Entity.Other.EUser();
                    EAddress address = new EAddress();

                    franchisorfranchisoruser.FranchisorFranchisorUserID = Convert.ToInt32(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["FranchisorFranchisorUserID"]);

                    franchisor.FranchisorID = Convert.ToInt32(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["FranchisorID"]);

                    user.UserID = Convert.ToInt32(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["UserID"]);
                    user.FirstName = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["FirstName"]);
                    user.MiddleName = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["MiddleName"]);
                    user.LastName = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["LastName"]);
                    user.PhoneHome = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["PhoneHome"]);
                    user.PhoneCell = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["PhoneCell"]);
                    user.PhoneOffice = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["PhoneOffice"]);
                    user.EMail1 = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["EMail1"]);
                    user.EMail2 = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["EMail2"]);
                    user.DOB = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["DOB"]);
                    user.SSN = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["SSN"]);

                    franchisoruser.FranchisorUserID = Convert.ToInt32(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["FranchisorUserID"]);
                    franchisoruser.MyPicture = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["MyPicture"]);
                    franchisoruser.TeamPicture = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["TeamPicture"]);
                    List<string> otherpicture = new List<string>();
                    for (int icount = 1; icount < 13; icount++)
                    {
                        otherpicture.Add(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["Picture" + icount].ToString());
                    }
                    franchisoruser.OtherPictures = otherpicture;

                    address.Address1 = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["Address1"]);
                    address.Address2 = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["Address2"]);
                    address.CityID = Convert.ToInt32(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["CityID"]);
                    address.City = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["City"]);
                    address.CountryID = Convert.ToInt32(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["CountryID"]);
                    address.Country = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["Country"]);
                    address.StateID = Convert.ToInt32(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["StateID"]);
                    address.State = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["State"]);
                    address.Zip = Convert.ToString(franchisorfranchisoruserDataSet.Tables[0].Rows[count]["ZipCode"]);
                    //address.Active = Convert.ToBoolean(franchisoruserDataSet.Tables[0].Rows[count]["IsActive"]);

                    franchisorfranchisoruser.FranchisorUser = franchisoruser;
                    franchisorfranchisoruser.Franchisor = franchisor;
                    franchisoruser.User = user;
                    user.HomeAddress = address;
                    franchisoruser.Address = address;
                    returnFranchisorFranchisorUser.Add(franchisorfranchisoruser);
                }
                catch (Exception)
                {
                }
            }
            return returnFranchisorFranchisorUser;
        }
        #endregion

        # region "Test"
        public Int64 SaveTest(ETest test, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[7];
            arParms[0] = new SqlParameter("@testid", SqlDbType.BigInt);
            arParms[0].Value = test.TestID;
            arParms[1] = new SqlParameter("@testname", SqlDbType.VarChar, 500);
            arParms[1].Value = test.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = test.Description;
            arParms[3] = new SqlParameter("@minimumprice", SqlDbType.Decimal);
            arParms[3].Value = test.MinimumPrice;
            arParms[4] = new SqlParameter("@recommendedprice", SqlDbType.BigInt);
            arParms[4].Value = test.RecommendedPrice;
            arParms[5] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[5].Value = Mode;

            arParms[6] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[6].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savetest", arParms);
            return (Int64)arParms[6].Value;
        }
        public Int64 SaveTest(String testID, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@testid", SqlDbType.VarChar, 3000);
            arParms[0].Value = testID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removetest", arParms);
            return (Int64)arParms[2].Value;

        }
        public List<ETest> GetTest(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_gettest", arParms);

            List<ETest> returnTest = new List<ETest>();
            returnTest = ParseTestDataSet(tempdataset);
            return returnTest;
        }
        private List<ETest> ParseTestDataSet(DataSet testDataSet)
        {
            List<ETest> returnTest = new List<ETest>();

            for (int count = 0; count < testDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    ETest test = new ETest();
                    test.Active = Convert.ToBoolean(testDataSet.Tables[0].Rows[count]["IsActive"]);
                    test.TestID = Convert.ToInt32(testDataSet.Tables[0].Rows[count]["TestID"]);
                    test.Description = Convert.ToString(testDataSet.Tables[0].Rows[count]["Description"]);
                    test.Name = Convert.ToString(testDataSet.Tables[0].Rows[count]["Name"]);
                    test.MinimumPrice = Convert.ToSingle(testDataSet.Tables[0].Rows[count]["MinimumPrice"]);
                    test.RecommendedPrice = Convert.ToSingle(testDataSet.Tables[0].Rows[count]["RecommendedPrice"]);
                    returnTest.Add(test);
                }
                catch (Exception)
                {
                }
            }
            return returnTest;
        }

        #endregion

        #region "Package"

        public List<ETest> GetTestByPodId(string podIds)
        {
            var arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@PodIds", SqlDbType.VarChar, 50) { Value = podIds };

            DataSet testDataSet = SqlHelper.ExecuteDataset(connectionstring,
                                                              "usp_getTestByPodId", arParms);
            var testList = new List<ETest>();
            if (testDataSet != null && testDataSet.Tables.Count > 0)
            {
                for (int count = 0; count < testDataSet.Tables[0].Rows.Count; count++)
                {

                    var test = new ETest
                                     {
                                         TestID = Convert.ToInt32(testDataSet.Tables[0].Rows[count]["TestId"]),
                                         MinimumPrice =
                                             Convert.ToSingle(
                                             testDataSet.Tables[0].Rows[count]["MinimumPrice"].ToString()),
                                         Name = Convert.ToString(testDataSet.Tables[0].Rows[count]["Name"]),
                                         Description =
                                             Convert.ToString(testDataSet.Tables[0].Rows[count]["Description"]),
                                         RecommendedPrice =
                                             Convert.ToSingle(
                                             testDataSet.Tables[0].Rows[count]["RecommendedPrice"].ToString()),
                                         IsTestDefaultSelected =
                                             Convert.ToBoolean(testDataSet.Tables[0].Rows[count]["IsDefaultSelected"])
                                     };
                    testList.Add(test);
                }
            }
            return testList;
        }

        public int CheckPodPackageChange(string packageIds, int eventId)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@PackageIds", SqlDbType.VarChar, 100);
            arParms[0].Value = packageIds;
            arParms[1] = new SqlParameter("@EventID", SqlDbType.BigInt);
            arParms[1].Value = eventId;
            arParms[2] = new SqlParameter("@returnValue", SqlDbType.Int);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_checkPodPackageChange", arParms);
            return Convert.ToInt32(arParms[2].Value);
        }
        #endregion

        #region Prospects

        /// <summary>
        /// To add prospect list
        /// </summary>
        /// <param name="prospectList">entity prospect list</param>
        /// <param name="userID">userid of user</param>
        /// <param name="shell">shell of user</param>
        /// <param name="role">role of user</param>
        /// <returns></returns>
        public Int64 SaveProspectsList(Entity.Other.EProspectList prospectList, long userId, long role, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[14];

            arParms[0] = new SqlParameter("@prospectfileid", SqlDbType.BigInt);
            arParms[0].Value = prospectList.ProspectListID;

            arParms[1] = new SqlParameter("@filename", SqlDbType.VarChar, 500);
            arParms[1].Value = CheckNull(prospectList.FileName);

            arParms[2] = new SqlParameter("@ListName", SqlDbType.VarChar, 255);
            arParms[2].Value = CheckNull(prospectList.ListName);

            arParms[3] = new SqlParameter("@ListSource", SqlDbType.VarChar, 255);
            arParms[3].Value = CheckNull(prospectList.ListSource);

            arParms[4] = new SqlParameter("@ListType", SqlDbType.Int);
            arParms[4].Value = prospectList.ListType;

            arParms[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[5].Direction = ParameterDirection.Output;

            arParms[6] = new SqlParameter("@LogList", SqlDbType.VarChar, 500);
            arParms[6].Value = CheckNull(prospectList.LogList);

            arParms[7] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[7].Value = mode;

            arParms[8] = new SqlParameter("@roleid", SqlDbType.Int);
            if (role > 0)
                arParms[8].Value = role;
            else arParms[8].Value = DBNull.Value;

            arParms[9] = new SqlParameter("@FileSize", SqlDbType.VarChar, 20);
            arParms[9].Value = CheckNull(prospectList.FileSize);

            arParms[10] = new SqlParameter("@UploadTime", SqlDbType.VarChar, 10);
            arParms[10].Value = prospectList.UploadTime;

            arParms[11] = new SqlParameter("@FranchiseeID", SqlDbType.BigInt);
            if (prospectList.FranchiseeID > 0)
                arParms[11].Value = prospectList.FranchiseeID;
            else
                arParms[11].Value = DBNull.Value;

            arParms[12] = new SqlParameter("@assigned", SqlDbType.Bit);
            arParms[12].Value = prospectList.Assigned;

            arParms[13] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[13].Value = userId;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveprospectlist", arParms);
            return (Int64)arParms[5].Value;
        }
        /// <summary>
        /// Check for duplicate prospect based on parameters
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="strFirstName"></param>
        /// <param name="strLastName"></param>
        /// <param name="strPhoneOffice"></param>
        /// <returns></returns>
        public Int64 DuplicateProspect(int mode, string strName, string strCity, string strState, int iZipCode)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[0].Value = mode;

            arParms[1] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            arParms[1].Value = CheckNull(strName);

            arParms[2] = new SqlParameter("@city", SqlDbType.VarChar, 100);
            arParms[2].Value = CheckNull(strCity);

            arParms[3] = new SqlParameter("@state", SqlDbType.VarChar, 100);
            arParms[3].Value = CheckNull(strState);

            arParms[4] = new SqlParameter("@zipcode", SqlDbType.Int);
            arParms[4].Value = iZipCode;

            arParms[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[5].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_ProspectListDuplicateContact", arParms);
            returnvalue = (Int64)arParms[5].Value;
            return returnvalue;

        }
        /// <summary>
        /// Check for duplicate prospect based on parameters
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="strFirstName"></param>
        /// <param name="strLastName"></param>
        /// <param name="strPhoneOffice"></param>
        /// <returns></returns>
        public Int64 DuplicateProspectCustomer(int mode, string strFirctName, string strLastName, string strCity, string strState, int iZipCode, string strDOB)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[8];

            arParms[0] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[0].Value = mode;

            arParms[1] = new SqlParameter("@firstname", SqlDbType.VarChar, 255);
            arParms[1].Value = CheckNull(strFirctName);

            arParms[2] = new SqlParameter("@lastname", SqlDbType.VarChar, 255);
            arParms[2].Value = CheckNull(strLastName);

            arParms[3] = new SqlParameter("@city", SqlDbType.VarChar, 100);
            arParms[3].Value = CheckNull(strCity);

            arParms[4] = new SqlParameter("@state", SqlDbType.VarChar, 100);
            arParms[4].Value = strState;

            arParms[5] = new SqlParameter("@zipcode", SqlDbType.Int);
            arParms[5].Value = iZipCode;

            arParms[6] = new SqlParameter("@dob", SqlDbType.VarChar, 100);
            arParms[6].Value = strDOB;

            arParms[7] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_ProspectListDuplicateCustomer", arParms);
            returnvalue = (Int64)arParms[7].Value;
            return returnvalue;
        }
        /// <summary>
        /// Assign Prospect
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="iProspectId"></param>
        /// <param name="iUserId"></param>
        public void AssignProspect(int mode, Int64 iProspectId, Int64 iUserId)
        {
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[0].Value = mode;

            arParms[1] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[1].Value = iProspectId;

            arParms[2] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[2].Value = iUserId;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_AssignProspect", arParms);


        }
        /// <summary>
        /// To save prospect detail
        /// </summary>
        /// <param name="prospect">entity prospect</param>
        /// <param name="userID">userid of user</param>
        /// <param name="shell">shell id of user</param>
        /// <param name="role">role of user</param>
        /// <returns></returns>
        public Int64 SaveProspect(Entity.Other.EProspect prospect, int mode, string userID, string shell, string role)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[35];

            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt); arParms[0].Value = prospect.ProspectID;
            arParms[1] = new SqlParameter("@prospectlistid", SqlDbType.BigInt);
            arParms[1].IsNullable = true;

            if (prospect.ProspectDetails.ProspectListID != 0)
                arParms[1].Value = prospect.ProspectDetails.ProspectListID;
            else
                arParms[1].Value = DBNull.Value;
            arParms[2] = new SqlParameter("@prospecttypeid", SqlDbType.BigInt);
            if (prospect.ProspectType != null && prospect.ProspectType.ProspectTypeID > 0)
            {
                arParms[2].Value = prospect.ProspectType.ProspectTypeID;
            }
            else
            {
                arParms[2].Value = DBNull.Value;
            }
            arParms[3] = new SqlParameter("@membership", SqlDbType.Decimal); arParms[3].Value = prospect.ActualMembership;
            arParms[4] = new SqlParameter("@attendance", SqlDbType.Decimal); arParms[4].Value = prospect.Attendance;
            if (prospect.Notes == null) prospect.Notes = "";
            arParms[5] = new SqlParameter("@notes", SqlDbType.VarChar, 5000); arParms[5].Value = CheckNull(prospect.Notes);

            arParms[6] = new SqlParameter("@emailid", SqlDbType.VarChar, 500); arParms[6].Value = CheckNull(prospect.EMailID);
            arParms[7] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500); arParms[7].Value = CheckNull(prospect.PhoneOffice);
            arParms[8] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500); arParms[8].Value = CheckNull(prospect.PhoneCell);
            arParms[9] = new SqlParameter("@phoneother", SqlDbType.VarChar, 500); arParms[9].Value = CheckNull(prospect.PhoneOther);
            arParms[10] = new SqlParameter("@website", SqlDbType.VarChar, 500); arParms[10].Value = CheckNull(prospect.WebSite);
            arParms[11] = new SqlParameter("@organizationname", SqlDbType.VarChar, 500); arParms[11].Value = CheckNull(prospect.OrganizationName);
            arParms[12] = new SqlParameter("@methodobtainedid", SqlDbType.BigInt); arParms[12].Value = prospect.MethodObtainedID;

            arParms[13] = new SqlParameter("@address1", SqlDbType.VarChar, 500); arParms[13].Value = CheckNull(prospect.Address.Address1);
            arParms[14] = new SqlParameter("@willcommunicate", SqlDbType.Int); arParms[14].Value = prospect.WillCommunicate;
            arParms[15] = new SqlParameter("@city", SqlDbType.VarChar, 100); arParms[15].Value = CheckNull(prospect.Address.City);
            arParms[16] = new SqlParameter("@state", SqlDbType.VarChar, 100); arParms[16].Value = CheckNull(prospect.Address.State);
            arParms[17] = new SqlParameter("@country", SqlDbType.VarChar, 100); arParms[17].Value = CheckNull(prospect.Address.Country);
            arParms[18] = new SqlParameter("@zipcode", SqlDbType.VarChar, 10); arParms[18].Value = prospect.Address.Zip;

            arParms[19] = new SqlParameter("@rowstate", SqlDbType.TinyInt); arParms[19].Value = mode;
            arParms[20] = new SqlParameter("@userid", SqlDbType.VarChar, 100); arParms[20].Value = CheckNull(userID);
            arParms[21] = new SqlParameter("@shell", SqlDbType.VarChar, 1000); arParms[21].Value = CheckNull(shell);
            arParms[22] = new SqlParameter("@role", SqlDbType.VarChar, 500); arParms[22].Value = CheckNull(role);
            arParms[23] = new SqlParameter("@returnvalue", SqlDbType.BigInt); arParms[23].Direction = ParameterDirection.Output;
            arParms[24] = new SqlParameter("@caddressid", SqlDbType.BigInt); arParms[24].Value = prospect.Address.AddressID;
            arParms[25] = new SqlParameter("@ccity", SqlDbType.VarChar, 100); arParms[25].Value = CheckNull(prospect.Address.City);
            arParms[26] = new SqlParameter("@cstate", SqlDbType.VarChar, 100); arParms[26].Value = CheckNull(prospect.Address.State);
            arParms[27] = new SqlParameter("@ccountry", SqlDbType.VarChar, 100); arParms[27].Value = CheckNull(prospect.Address.Country);
            arParms[28] = new SqlParameter("@czipid", SqlDbType.VarChar, 10); arParms[28].Value = prospect.Address.Zip;
            arParms[29] = new SqlParameter("@followdate", SqlDbType.VarChar, 100);
            if (prospect.FollowDate.Length > 0 || !prospect.FollowDate.Equals("null"))
                arParms[29].Value = prospect.FollowDate;
            else
                arParms[29].Value = DBNull.Value;
            arParms[30] = new SqlParameter("@ishost", SqlDbType.Bit); arParms[30].Value = prospect.IsHost;
            arParms[31] = new SqlParameter("@status", SqlDbType.VarChar, 100);
            if (prospect.Status != null)
            {
                if (prospect.Status.Length > 0 || !prospect.Status.Equals("null"))
                    arParms[31].Value = prospect.Status;
                else
                    arParms[31].Value = DBNull.Value;
            }
            else
                arParms[31].Value = DBNull.Value;

            arParms[32] = new SqlParameter("@address2", SqlDbType.VarChar, 500); arParms[32].Value = CheckNull(prospect.Address.Address2);
            // Fax Added
            arParms[33] = new SqlParameter("@fax", SqlDbType.VarChar, 100); arParms[33].Value = CheckNull(prospect.Address.Fax);

            arParms[34] = new SqlParameter("@ReasonWillcommunicate", SqlDbType.Text);
            if (prospect.ReasonWillCommunicate != null)
                arParms[34].Value = prospect.ReasonWillCommunicate;
            else
                arParms[34].Value = "";
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveprospect", arParms);

            returnvalue = (Int64)arParms[23].Value;
            return returnvalue;
        }
        /// <summary>
        /// Delete prospect and host
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="iProspectId"></param>
        /// <returns></returns>
        public Int64 DeleteProspectHost(int mode, Int64 iProspectId)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[0].Value = mode;

            arParms[1] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[1].Value = iProspectId;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_SRepDeleteProspectHost", arParms);

            returnvalue = (Int64)arParms[2].Value;
            return returnvalue;
        }

        /// <summary>
        /// To export prospect detail
        /// </summary>
        /// <param name="prospect">entity prospect</param>
        /// <param name="userID">userid of user</param>
        /// <param name="shell">shell id of user</param>
        /// <param name="role">role of user</param>
        /// <returns></returns>
        public Int64 ExportProspect(Entity.Other.EProspect prospect, int mode, string userID)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[45];

            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[0].Value = prospect.ProspectID;

            arParms[1] = new SqlParameter("@prospectlistid", SqlDbType.BigInt);
            arParms[1].IsNullable = true;

            if (prospect.ProspectDetails.ProspectListID != 0)
                arParms[1].Value = prospect.ProspectDetails.ProspectListID;
            else
                arParms[1].Value = DBNull.Value;

            arParms[2] = new SqlParameter("@prospecttypeid", SqlDbType.BigInt);
            if (prospect.ProspectType != null && prospect.ProspectType.ProspectTypeID > 0)
            {
                arParms[2].Value = prospect.ProspectType.ProspectTypeID;
            }
            else
            {
                arParms[2].Value = DBNull.Value;
            }

            arParms[3] = new SqlParameter("@membership", SqlDbType.Decimal);
            arParms[3].Value = prospect.ActualMembership;

            arParms[4] = new SqlParameter("@attendance", SqlDbType.Decimal);
            arParms[4].Value = prospect.Attendance;

            arParms[5] = new SqlParameter("@emailid", SqlDbType.VarChar, 500);
            arParms[5].Value = CheckNull(prospect.EMailID);

            arParms[6] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[6].Value = CheckNull(prospect.PhoneOffice);

            arParms[7] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[7].Value = CheckNull(prospect.PhoneCell);

            arParms[8] = new SqlParameter("@phoneother", SqlDbType.VarChar, 500);
            arParms[8].Value = CheckNull(prospect.PhoneOther);

            arParms[9] = new SqlParameter("@website", SqlDbType.VarChar, 500);
            arParms[9].Value = CheckNull(prospect.WebSite);

            arParms[10] = new SqlParameter("@organizationname", SqlDbType.VarChar, 500);
            arParms[10].Value = CheckNull(prospect.OrganizationName);

            arParms[11] = new SqlParameter("@notes", SqlDbType.VarChar, 5000);
            arParms[11].Value = CheckNull(prospect.Notes);

            arParms[12] = new SqlParameter("@methodobtainedid", SqlDbType.BigInt);
            arParms[12].Value = prospect.MethodObtainedID;

            arParms[13] = new SqlParameter("@willcommunicate", SqlDbType.Int);
            arParms[13].Value = prospect.WillCommunicate;

            arParms[14] = new SqlParameter("@ReasonWillcommunicate", SqlDbType.Text);
            arParms[14].Value = CheckNull(prospect.ReasonWillCommunicate);

            arParms[15] = new SqlParameter("@followdate", SqlDbType.VarChar, 100);
            arParms[15].Value = CheckNull(prospect.FollowDate);

            arParms[16] = new SqlParameter("@ishost", SqlDbType.Bit);
            arParms[16].Value = prospect.IsHost;

            arParms[17] = new SqlParameter("@status", SqlDbType.VarChar, 100);
            arParms[17].Value = CheckNull(prospect.Status);

            arParms[18] = new SqlParameter("@paddress1", SqlDbType.VarChar, 500);
            arParms[18].Value = CheckNull(prospect.Address.Address1);

            arParms[19] = new SqlParameter("@paddress2", SqlDbType.VarChar, 500);
            arParms[19].Value = CheckNull(prospect.Address.Address2);

            arParms[20] = new SqlParameter("@pcity", SqlDbType.VarChar, 100);
            arParms[20].Value = CheckNull(prospect.Address.City);

            arParms[21] = new SqlParameter("@pstate", SqlDbType.VarChar, 100);
            arParms[21].Value = CheckNull(prospect.Address.State);

            arParms[22] = new SqlParameter("@pzipcode", SqlDbType.BigInt);
            arParms[22].Value = prospect.Address.ZipID;

            arParms[23] = new SqlParameter("@pcountry", SqlDbType.VarChar, 100);
            arParms[23].Value = CheckNull(prospect.Address.Country);

            arParms[24] = new SqlParameter("@pfax", SqlDbType.VarChar, 100);
            arParms[24].Value = CheckNull(prospect.Address.Fax);

            arParms[25] = new SqlParameter("@saddress1", SqlDbType.VarChar, 500);
            arParms[25].Value = CheckNull(prospect.AddressMailing.Address1);

            arParms[26] = new SqlParameter("@saddress2", SqlDbType.VarChar, 500);
            arParms[26].Value = CheckNull(prospect.AddressMailing.Address2);

            arParms[27] = new SqlParameter("@scity", SqlDbType.VarChar, 100);
            arParms[27].Value = CheckNull(prospect.AddressMailing.City);

            arParms[28] = new SqlParameter("@sstate", SqlDbType.VarChar, 100);
            arParms[28].Value = CheckNull(prospect.AddressMailing.State);

            arParms[29] = new SqlParameter("@szipcode", SqlDbType.BigInt);
            arParms[29].Value = prospect.AddressMailing.ZipID;

            arParms[30] = new SqlParameter("@scountry", SqlDbType.VarChar, 100);
            arParms[30].Value = CheckNull(prospect.AddressMailing.Country);

            arParms[31] = new SqlParameter("@sfax", SqlDbType.VarChar, 100);
            arParms[31].Value = CheckNull(prospect.AddressMailing.Fax);

            arParms[32] = new SqlParameter("@title", SqlDbType.VarChar, 500);
            arParms[32].Value = CheckNull(prospect.Contact[0].Title);

            arParms[33] = new SqlParameter("@firstname", SqlDbType.VarChar, 500);
            arParms[33].Value = CheckNull(prospect.Contact[0].FirstName);

            arParms[34] = new SqlParameter("@middlename", SqlDbType.VarChar, 500);
            arParms[34].Value = CheckNull(prospect.Contact[0].MiddleName);

            arParms[35] = new SqlParameter("@lastname", SqlDbType.VarChar, 500);
            arParms[35].Value = CheckNull(prospect.Contact[0].LastName);

            arParms[36] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[36].Value = mode;

            arParms[37] = new SqlParameter("@userid", SqlDbType.VarChar, 100);
            arParms[37].Value = CheckNull(userID);

            //arParms[38] = new SqlParameter("@shell", SqlDbType.VarChar, 1000); 
            //arParms[38].Value = CheckNull(shell);

            //arParms[39] = new SqlParameter("@role", SqlDbType.VarChar, 500); 
            //arParms[39].Value = CheckNull(role);

            arParms[38] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[38].Direction = ParameterDirection.Output;

            arParms[39] = new SqlParameter("@SalesRepID", SqlDbType.BigInt);
            if (prospect.SalesRepID > 0)
                arParms[39].Value = prospect.SalesRepID;
            else arParms[39].Value = DBNull.Value;

            arParms[40] = new SqlParameter("@Gender", SqlDbType.Bit);
            if (prospect.Contact[0].Gender == null)
                arParms[40].Value = DBNull.Value;
            else arParms[40].Value = prospect.Contact[0].Gender;

            arParms[41] = new SqlParameter("@contactEmail", SqlDbType.VarChar, 255);
            arParms[41].Value = CheckNull(prospect.Contact[0].EMail);

            arParms[42] = new SqlParameter("@contactTitle", SqlDbType.VarChar, 255);
            arParms[42].Value = CheckNull(prospect.Contact[0].DesignationTitle);

            arParms[43] = new SqlParameter("@contactRole", SqlDbType.VarChar, 255);
            arParms[43].Value = CheckNull(prospect.Contact[0].ListProspectContactRole[0].ProspectContactRoleName);

            arParms[44] = new SqlParameter("@prospectType", SqlDbType.VarChar, 255);
            arParms[44].Value = CheckNull(prospect.ProspectType.Name);


            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_importprospect", arParms);

            returnvalue = (Int64)arParms[38].Value;
            return returnvalue;
        }

        /// <summary>
        /// To export customer prospect - for outbound call
        /// </summary>
        /// <param name="prospect">entity prospect</param>
        /// <param name="userID">userid of user</param>
        /// <param name="shell">shell id of user</param>
        /// <param name="role">role of user</param>
        /// <returns></returns>
        public Int64 ExportCustomerProspect(Entity.Other.EUser objUser, int mode)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[13];

            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = mode;

            arParms[1] = new SqlParameter("@first_name", SqlDbType.VarChar, 200);
            arParms[1].Value = CheckNull(objUser.FirstName);

            arParms[2] = new SqlParameter("@last_name", SqlDbType.VarChar, 200);
            arParms[2].Value = CheckNull(objUser.LastName);

            arParms[3] = new SqlParameter("@address", SqlDbType.VarChar, 400);
            arParms[3].Value = CheckNull(objUser.HomeAddress.Address1);

            arParms[4] = new SqlParameter("@city", SqlDbType.VarChar, 200);
            arParms[4].Value = CheckNull(objUser.HomeAddress.City);

            arParms[5] = new SqlParameter("@state", SqlDbType.VarChar, 200);
            arParms[5].Value = CheckNull(objUser.HomeAddress.State);

            arParms[6] = new SqlParameter("@zip_code", SqlDbType.VarChar, 200);
            arParms[6].Value = CheckNull(objUser.HomeAddress.Zip);

            arParms[7] = new SqlParameter("@phone", SqlDbType.VarChar, 100);
            arParms[7].Value = CheckNull(objUser.PhoneOffice);

            arParms[8] = new SqlParameter("@dob", SqlDbType.VarChar, 50);
            arParms[8].Value = CheckNull(objUser.DOB);

            arParms[9] = new SqlParameter("@email", SqlDbType.VarChar, 200);
            arParms[9].Value = CheckNull(objUser.EMail1);

            arParms[10] = new SqlParameter("@source", SqlDbType.VarChar, 200);
            arParms[10].Value = CheckNull(objUser.SSN);

            arParms[11] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[11].Direction = ParameterDirection.Output;

            arParms[12] = new SqlParameter("@prospectlistid", SqlDbType.BigInt);
            arParms[12].Value = objUser.LeadCount;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_ImportProspectCustomer", arParms);

            returnvalue = (Int64)arParms[11].Value;
            return returnvalue;
        }
        public List<EProspectListType> GetProspectListType(int mode)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_GetProspectListType", arParms);

            List<EProspectListType> returnProspectListType = new List<EProspectListType>();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EProspectListType objProspectListType = new EProspectListType();

                objProspectListType.ProspectListTypeID = Convert.ToInt32(dr["ProspectListTypeID"]);
                objProspectListType.ProspectListName = dr["ProspectListType"].ToString();

                returnProspectListType.Add(objProspectListType);
            }
            return returnProspectListType;
        }
        /// <summary>
        /// To save host detail
        /// </summary>
        /// <param name="prospect">entity prospect</param>
        /// <param name="userID">userid of user</param>
        /// <param name="shell">shell id of user</param>
        /// <param name="role">role of user</param>
        /// <returns></returns>
        public Int64 SaveHost(Entity.Other.EProspect prospect, int mode, string userID, string shell, string role)
        {
            SqlParameter[] arParms = new SqlParameter[41];

            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt); arParms[0].Value = prospect.ProspectID;
            arParms[1] = new SqlParameter("@prospectlistid", SqlDbType.BigInt);
            arParms[1].IsNullable = true;

            if (prospect.ProspectDetails.ProspectListID != 0)
                arParms[1].Value = prospect.ProspectDetails.ProspectListID;

            arParms[2] = new SqlParameter("@prospecttypeid", SqlDbType.BigInt);
            if (prospect.ProspectType != null)
            {
                arParms[2].Value = prospect.ProspectType.ProspectTypeID;
            }
            else
            {
                arParms[2].Value = DBNull.Value;
            }
            arParms[3] = new SqlParameter("@membership", SqlDbType.Decimal); arParms[3].Value = prospect.ActualMembership;
            arParms[4] = new SqlParameter("@attendance", SqlDbType.Decimal); arParms[4].Value = prospect.Attendance;
            arParms[5] = new SqlParameter("@notes", SqlDbType.VarChar, 500); arParms[5].Value = prospect.Notes;
            arParms[6] = new SqlParameter("@emailid", SqlDbType.VarChar, 500); arParms[6].Value = prospect.EMailID;
            arParms[7] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500); arParms[7].Value = prospect.PhoneOffice;
            arParms[8] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500); arParms[8].Value = prospect.PhoneCell;
            arParms[9] = new SqlParameter("@phoneother", SqlDbType.VarChar, 500); arParms[9].Value = prospect.PhoneOther;
            arParms[10] = new SqlParameter("@website", SqlDbType.VarChar, 500); arParms[10].Value = prospect.WebSite;
            arParms[11] = new SqlParameter("@organizationname", SqlDbType.VarChar, 500); arParms[11].Value = prospect.OrganizationName;
            arParms[12] = new SqlParameter("@methodobtainedid", SqlDbType.BigInt); arParms[12].Value = prospect.MethodObtainedID;

            arParms[13] = new SqlParameter("@address1", SqlDbType.VarChar, 500); arParms[13].Value = prospect.Address.Address1;
            arParms[14] = new SqlParameter("@willcommunicate", SqlDbType.Int); arParms[14].Value = prospect.WillCommunicate;
            arParms[15] = new SqlParameter("@cityid", SqlDbType.BigInt); arParms[15].Value = prospect.Address.CityID;
            arParms[16] = new SqlParameter("@stateid", SqlDbType.BigInt); arParms[16].Value = prospect.Address.StateID;
            arParms[17] = new SqlParameter("@countryid", SqlDbType.BigInt); arParms[17].Value = prospect.Address.CountryID;
            arParms[18] = new SqlParameter("@zipcode", SqlDbType.BigInt); arParms[18].Value = prospect.Address.ZipID;

            arParms[19] = new SqlParameter("@rowstate", SqlDbType.TinyInt); arParms[19].Value = mode;
            arParms[20] = new SqlParameter("@userid", SqlDbType.VarChar, 100); arParms[20].Value = userID;
            arParms[21] = new SqlParameter("@shell", SqlDbType.VarChar, 1000); arParms[21].Value = shell;
            arParms[22] = new SqlParameter("@role", SqlDbType.VarChar, 500); arParms[22].Value = role;
            arParms[23] = new SqlParameter("@returnvalue", SqlDbType.BigInt); arParms[23].Direction = ParameterDirection.Output;
            arParms[24] = new SqlParameter("@caddressid", SqlDbType.BigInt); arParms[24].Value = prospect.AddressMailing.AddressID;
            arParms[25] = new SqlParameter("@ccityid", SqlDbType.BigInt); arParms[25].Value = prospect.AddressMailing.CityID;
            arParms[26] = new SqlParameter("@cstateid", SqlDbType.BigInt); arParms[26].Value = prospect.AddressMailing.StateID;
            arParms[27] = new SqlParameter("@ccountryid", SqlDbType.BigInt); arParms[27].Value = prospect.AddressMailing.CountryID;
            arParms[28] = new SqlParameter("@czipid", SqlDbType.BigInt); arParms[28].Value = prospect.AddressMailing.ZipID;
            arParms[29] = new SqlParameter("@followdate", SqlDbType.VarChar, 100);
            if (prospect.FollowDate.Length > 0 || !prospect.FollowDate.Equals("null"))
                arParms[29].Value = prospect.FollowDate;
            else
                arParms[29].Value = DBNull.Value;


            arParms[30] = new SqlParameter("@ishost", SqlDbType.Bit); arParms[30].Value = prospect.IsHost;
            arParms[31] = new SqlParameter("@status", SqlDbType.VarChar, 100);

            if (prospect.Status != null)
            {
                if (prospect.Status.Length > 0 || !prospect.Status.Equals("null"))
                    arParms[31].Value = prospect.Status;
                else
                    arParms[31].Value = DBNull.Value;
            }
            else
                arParms[31].Value = DBNull.Value;


            arParms[32] = new SqlParameter("@address2", SqlDbType.VarChar, 500); arParms[32].Value = prospect.Address.Address2;
            arParms[33] = new SqlParameter("@fax", SqlDbType.VarChar, 100); arParms[33].Value = prospect.Address.Fax;

            arParms[34] = new SqlParameter("@caddress1", SqlDbType.VarChar, 500); arParms[34].Value = prospect.AddressMailing.Address1;
            arParms[35] = new SqlParameter("@caddress2", SqlDbType.VarChar, 500); arParms[35].Value = prospect.AddressMailing.Address2;

            arParms[36] = new SqlParameter("@addressid1", SqlDbType.BigInt); arParms[36].Value = prospect.Address.AddressID;

            arParms[37] = new SqlParameter("@ReasonWillcommunicate", SqlDbType.Text); arParms[37].Value = CheckNull(prospect.ReasonWillCommunicate);
            arParms[38] = new SqlParameter("@TaxIdNumber", SqlDbType.VarChar, 255); arParms[38].Value = CheckNull(prospect.TaxIdNumber);

            arParms[39] = new SqlParameter("@callCenterNotes", SqlDbType.VarChar); arParms[39].Value = CheckNull(prospect.CallCenterNotes);
            arParms[40] = new SqlParameter("@technicianNotes", SqlDbType.VarChar); arParms[40].Value = CheckNull(prospect.TechnicianNotes);

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savehost", arParms);

            return (Int64)arParms[23].Value;
        }


        /// <summary>
        /// this subroutine saves the details of the prospect which failed to upload.
        /// </summary>
        /// <param name="prospect"></param>
        /// <param name="mode"></param>
        /// <param name="userID"></param>
        /// <param name="shell"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public Int64 SaveFaliureProspect(Entity.Other.EProspect prospect, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[16];

            arParms[0] = new SqlParameter("@prospectlistid", SqlDbType.BigInt);
            arParms[0].Value = prospect.ProspectDetails.ProspectListID;

            arParms[1] = new SqlParameter("@fname", SqlDbType.VarChar, 100);
            arParms[1].Value = CheckNull(prospect.FirstName);


            arParms[2] = new SqlParameter("@lname", SqlDbType.VarChar, 100);
            arParms[2].Value = CheckNull(prospect.LastName);

            arParms[3] = new SqlParameter("@notes", SqlDbType.VarChar, 1000);
            arParms[3].Value = CheckNull(prospect.Notes);

            arParms[4] = new SqlParameter("@emailid", SqlDbType.VarChar, 100);
            arParms[4].Value = CheckNull(prospect.EMailID);

            arParms[5] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 100);
            arParms[5].Value = CheckNull(prospect.PhoneOffice);

            arParms[6] = new SqlParameter("@phonecell", SqlDbType.VarChar, 100);
            arParms[6].Value = CheckNull(prospect.PhoneCell);

            arParms[7] = new SqlParameter("@website", SqlDbType.VarChar, 100);
            arParms[7].Value = CheckNull(prospect.WebSite);

            arParms[8] = new SqlParameter("@organizationname", SqlDbType.VarChar, 500);
            arParms[8].Value = CheckNull(prospect.OrganizationName);

            arParms[9] = new SqlParameter("@address1", SqlDbType.VarChar, 100);
            arParms[9].Value = CheckNull(prospect.Address.Address1);

            arParms[10] = new SqlParameter("@city", SqlDbType.VarChar, 500);
            arParms[10].Value = CheckNull(prospect.Address.City);

            arParms[11] = new SqlParameter("@stateid", SqlDbType.BigInt);
            arParms[11].Value = prospect.Address.StateID;

            arParms[12] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[12].Value = prospect.Address.CountryID;

            arParms[13] = new SqlParameter("@zipcode", SqlDbType.BigInt);
            arParms[13].Value = prospect.Address.ZipID;

            arParms[14] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[14].Value = mode;

            arParms[15] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[15].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savefaliureprospect", arParms);

            return (Int64)arParms[15].Value;
        }

        /// <summary>
        /// this subroutine deletes the failure prospect entry and insert new prospect entry.  
        /// </summary>
        /// <param name="prospect"></param>
        /// <param name="mode"></param>
        /// <param name="userID"></param>
        /// <param name="shell"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public Int64 RemoveFaliureProspect(EProspect prospect, int mode)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[18];
            arParms[0] = new SqlParameter("@prospectlistid", SqlDbType.BigInt); arParms[0].Value = prospect.ProspectDetails.ProspectListID;
            arParms[1] = new SqlParameter("@fudate", SqlDbType.VarChar, 1000); arParms[1].Value = prospect.FollowDate;
            arParms[2] = new SqlParameter("@notes", SqlDbType.VarChar, 1000); arParms[2].Value = prospect.Notes;
            arParms[3] = new SqlParameter("@emailid", SqlDbType.VarChar, 100); arParms[3].Value = prospect.EMailID;
            arParms[4] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 100); arParms[4].Value = prospect.PhoneOffice;
            arParms[5] = new SqlParameter("@phonecell", SqlDbType.VarChar, 100); arParms[5].Value = prospect.PhoneCell;
            arParms[6] = new SqlParameter("@website", SqlDbType.VarChar, 100); arParms[6].Value = prospect.WebSite;
            arParms[7] = new SqlParameter("@organizationname", SqlDbType.VarChar, 500); arParms[7].Value = prospect.OrganizationName;
            arParms[8] = new SqlParameter("@address1", SqlDbType.VarChar, 100); arParms[8].Value = prospect.Address.Address1;
            arParms[9] = new SqlParameter("@cityid", SqlDbType.BigInt); arParms[9].Value = prospect.Address.CityID;
            arParms[10] = new SqlParameter("@stateid", SqlDbType.BigInt); arParms[10].Value = prospect.Address.StateID;
            arParms[11] = new SqlParameter("@countryid", SqlDbType.BigInt); arParms[11].Value = prospect.Address.CountryID;
            arParms[12] = new SqlParameter("@zipcode", SqlDbType.BigInt); arParms[12].Value = prospect.Address.ZipID;
            arParms[13] = new SqlParameter("@rowstate", SqlDbType.TinyInt); arParms[13].Value = mode;
            arParms[14] = new SqlParameter("@returnvalue", SqlDbType.BigInt); arParms[17].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removefaliureprospect", arParms);

            returnvalue = (Int64)arParms[14].Value;
            return returnvalue;
        }

        /// <summary>
        /// Save new contact
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="mode"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Int64 SaveContact(EContact contact, int mode, int userid)
        {
            Int64 returnvalue = new Int64();

            SqlParameter[] arParms = new SqlParameter[27];

            arParms[0] = new SqlParameter("@city", SqlDbType.VarChar, 100);
            arParms[1] = new SqlParameter("@state", SqlDbType.VarChar, 100);
            arParms[2] = new SqlParameter("@country", SqlDbType.VarChar, 100);
            arParms[9] = new SqlParameter("@zipcode", SqlDbType.VarChar, 500);
            arParms[17] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
            if (contact.Address == null)
            {
                arParms[0].Value = DBNull.Value;
                arParms[1].Value = DBNull.Value;
                arParms[2].Value = DBNull.Value;
                arParms[9].Value = DBNull.Value;
                arParms[17].Value = DBNull.Value;
            }
            else
            {
                if (contact.Address.City != null && contact.Address.City.Trim().Length > 0)
                    arParms[0].Value = contact.Address.City;
                else
                    arParms[0].Value = DBNull.Value;

                if (contact.Address.State != null && contact.Address.State.Trim().Length > 0)
                    arParms[1].Value = contact.Address.State;
                else
                    arParms[1].Value = DBNull.Value;

                if (contact.Address.Country != null && contact.Address.Country.Trim().Length > 0)
                    arParms[2].Value = contact.Address.Country;
                else
                    arParms[2].Value = DBNull.Value;

                if (contact.Address.Zip != null && contact.Address.Zip.Trim().Length > 0)
                    arParms[9].Value = contact.Address.Zip;
                else
                    arParms[9].Value = DBNull.Value;

                if (contact.Address.Address1 != null && contact.Address.Address1.Trim().Length > 0)
                    arParms[17].Value = contact.Address.Address1;
                else
                    arParms[17].Value = DBNull.Value;
            }
            arParms[3] = new SqlParameter("@fname", SqlDbType.VarChar, 500);
            arParms[3].Value = CheckNull(contact.FirstName);


            arParms[4] = new SqlParameter("@mname", SqlDbType.VarChar, 500);
            arParms[4].Value = CheckNull(contact.MiddleName);


            arParms[5] = new SqlParameter("@lname", SqlDbType.VarChar, 500);
            arParms[5].Value = CheckNull(contact.LastName);


            arParms[6] = new SqlParameter("@phonehome", SqlDbType.VarChar, 500);
            arParms[6].Value = CheckNull(contact.PhoneHome);


            arParms[7] = new SqlParameter("@phonecell", SqlDbType.VarChar, 500);
            arParms[7].Value = CheckNull(contact.PhoneCell);


            arParms[8] = new SqlParameter("@phoneoffice", SqlDbType.VarChar, 500);
            arParms[8].Value = CheckNull(contact.PhoneOffice);



            arParms[10] = new SqlParameter("@email", SqlDbType.VarChar, 500);
            if (contact.EMail != null && contact.EMail != "" && contact.EMail.Trim().Length > 0)
                arParms[10].Value = contact.EMail;
            else arParms[10].Value = DBNull.Value;

            arParms[11] = new SqlParameter("@organisation", SqlDbType.VarChar, 500);
            arParms[11].Value = CheckNull(contact.OrganizationName);


            arParms[12] = new SqlParameter("@website", SqlDbType.VarChar, 500);
            arParms[12].Value = CheckNull(contact.WebSite);


            arParms[15] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[15].Value = mode;

            arParms[16] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[16].Direction = ParameterDirection.Output;


            arParms[18] = new SqlParameter("@title", SqlDbType.VarChar, 500);
            arParms[18].Value = CheckNull(contact.Title);


            arParms[19] = new SqlParameter("@ext", SqlDbType.VarChar, 500);
            arParms[19].Value = CheckNull(contact.Phone1Extension);


            arParms[20] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[20].Value = userid;

            arParms[21] = new SqlParameter("@gender", SqlDbType.Bit);
            arParms[21].Value = contact.Gender;

            arParms[22] = new SqlParameter("@notes", SqlDbType.VarChar, 500);
            if (contact.ContactNotes != null && contact.ContactNotes.Count > 0)
                arParms[22].Value = CheckNull(contact.ContactNotes[0].Notes);
            else arParms[22].Value = CheckNull(contact.Note);


            arParms[23] = new SqlParameter("@contactid", SqlDbType.BigInt);
            arParms[23].Value = contact.ContactID;

            arParms[24] = new SqlParameter("@fax", SqlDbType.VarChar, 100);
            arParms[24].Value = CheckNull(contact.Fax);


            arParms[25] = new SqlParameter("@type", SqlDbType.BigInt);
            if (contact.ContactType != 0) arParms[25].Value = contact.ContactType;
            else arParms[25].Value = DBNull.Value;

            arParms[26] = new SqlParameter("@designationtitle", SqlDbType.VarChar, 100);
            arParms[26].Value = CheckNull(contact.DesignationTitle);


            arParms[13] = new SqlParameter("@emailoffice", SqlDbType.VarChar, 500);

            if (!string.IsNullOrEmpty(contact.EmailWork) && contact.EmailWork.Trim().Length > 0) arParms[13].Value = contact.EmailWork;
            else arParms[13].Value = DBNull.Value;

            arParms[14] = new SqlParameter("@dateofbirth", SqlDbType.DateTime);

            if (!string.IsNullOrEmpty(contact.DateOfBirth) && contact.DateOfBirth.Trim().Length > 0) arParms[14].Value = contact.DateOfBirth;
            else arParms[14].Value = DBNull.Value;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savecontact", arParms);

            returnvalue = (Int64)arParms[16].Value;

            return returnvalue;

        }

        public EContact GetContactByID(int contactid, int mode, out int iProspectID)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@contactid", SqlDbType.BigInt);
            arParms[0].Value = contactid;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getcontactbyid", arParms);

            iProspectID = 0;
            if (tempdataset.Tables[0].Rows.Count < 1)
                return null;

            DataRow dr = tempdataset.Tables[0].Rows[0];

            iProspectID = Convert.ToInt32(dr["ProspectID"]);
            EContact objContactDetails = new EContact();
            objContactDetails.ContactID = Convert.ToInt32(dr["ContactID"]);
            objContactDetails.EMail = dr["EMail"].ToString();
            objContactDetails.FirstName = dr["FirstName"].ToString();
            objContactDetails.LastName = dr["LastName"].ToString();
            objContactDetails.PhoneOffice = dr["PhoneOffice"].ToString();
            objContactDetails.Title = dr["Salutation"].ToString();
            objContactDetails.MiddleName = dr["MiddleName"].ToString();
            objContactDetails.PhoneCell = dr["PhoneCell"].ToString();
            objContactDetails.PhoneHome = dr["PhoneHome"].ToString();
            objContactDetails.WebSite = dr["WebSite"].ToString();
            objContactDetails.OrganizationName = dr["Organisation"].ToString();
            objContactDetails.Note = dr["Notes"].ToString();
            objContactDetails.Gender = Convert.ToBoolean(dr["Gender"]);
            objContactDetails.Fax = dr["Fax"].ToString();
            objContactDetails.Phone1Extension = dr["PhoneOfficeExtension"].ToString();
            objContactDetails.DesignationTitle = dr["Title"].ToString();
            objContactDetails.EmailWork = dr["EMailOffice"].ToString();
            objContactDetails.DateOfBirth = dr["DateOfBirth"].ToString();

            if (dr["ContactTypeID"] != DBNull.Value)
            {
                objContactDetails.ContactType = Convert.ToInt32(dr["ContactTypeID"]);
            }
            else
                objContactDetails.ContactType = 0;

            objContactDetails.Address = new EAddress();

            objContactDetails.Address.Address1 = dr["Address1"].ToString();
            objContactDetails.Address.Zip = dr["ZipCode"].ToString();
            objContactDetails.Address.City = dr["City"].ToString();
            if (dr["State"] != DBNull.Value)
            {
                objContactDetails.Address.State = dr["State"].ToString();
            }
            else
            {
                objContactDetails.Address.State = "Select State";
            }
            objContactDetails.Address.Country = dr["Country"].ToString();

            if (tempdataset.Tables.Count > 1)
            {
                if (tempdataset.Tables[1].Rows.Count > 0)
                {
                    if (tempdataset.Tables[1].Rows.Count > 0)
                    {
                        objContactDetails.ListProspectContactRole = new List<EProspectContactRole>();
                        foreach (DataRow dr1 in tempdataset.Tables[1].Rows)
                        {
                            EProspectContactRole objproscontrole = new EProspectContactRole();
                            objproscontrole.ProspectContactRoleID = Convert.ToInt16(dr1["ProspectContactRoleID"]);
                            objproscontrole.ProspectContactRoleName = dr1["ProspectContactRoleName"].ToString();
                            objContactDetails.ListProspectContactRole.Add(objproscontrole);
                        }
                    }
                }
            }

            return objContactDetails;
        }
        /// <summary>
        /// Get Contact Information based on prospect id.
        /// </summary>
        /// <param name="prospectID"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<EContact> GetContactByProspect(Int64 ProspectID, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@ProspectID", SqlDbType.BigInt);
            arParms[0].Value = ProspectID;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getContactByProspectID", arParms);

            List<EContact> returnContactDetails = new List<EContact>();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EContact objContactDetails = new EContact();
                EContactNotes objEContactNotes = new EContactNotes();
                objContactDetails.ContactNotes = new List<EContactNotes>();
                objContactDetails.ContactID = Convert.ToInt32(dr["ContactID"]);
                objContactDetails.Title = dr["Salutation"].ToString();
                objContactDetails.FirstName = dr["FirstName"].ToString();
                objContactDetails.MiddleName = dr["MiddleName"].ToString();
                objContactDetails.LastName = dr["LastName"].ToString();
                objContactDetails.DesignationTitle = dr["Title"].ToString();
                objEContactNotes.ContactNoteID = Convert.ToInt32(dr["ContactNotesID"]);
                objEContactNotes.Notes = dr["Notes"].ToString();
                objContactDetails.ContactNotes.Add(objEContactNotes);
                returnContactDetails.Add(objContactDetails);
            }
            return returnContactDetails;
        }

        public Int64 RemoveHost(Int32 prospectId, int mode, string userID, string shell, string role)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt); arParms[0].Value = prospectId;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt); arParms[1].Value = mode;
            arParms[2] = new SqlParameter("@userid", SqlDbType.VarChar, 100); arParms[2].Value = userID;
            arParms[3] = new SqlParameter("@shell", SqlDbType.VarChar, 1000); arParms[3].Value = shell;
            arParms[4] = new SqlParameter("@role", SqlDbType.VarChar, 500); arParms[4].Value = role;
            arParms[5] = new SqlParameter("@returnvalue", SqlDbType.BigInt); arParms[5].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removehostdetails", arParms);
            returnvalue = (Int64)arParms[5].Value;
            return returnvalue;
        }

        /// <summary>
        /// Get Prospect Uploaded List for any logged in user i.e. for given user id
        /// </summary>
        /// <param name="filterString">where condition value for UserId</param>
        /// <param name="inputMode">to filter the output by all/active only</param>
        /// <returns></returns>
        public List<EProspectDetails> GetUploadedProspectList(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getuploadprospectfilelist", arParms);

            List<EProspectDetails> returnProspectDetail = new List<EProspectDetails>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EProspectDetails objProspectList = new EProspectDetails();
                objProspectList.ProspectListID = Convert.ToInt32(dr["ProspectFileID"]);
                objProspectList.FileName = dr["FileName"].ToString();

                returnProspectDetail.Add(objProspectList);
            }

            return returnProspectDetail;
        }

        public List<EProspectList> GetProspectList(EProspectList objEProspectList, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[9];

            arParms[0] = new SqlParameter("@ListName", SqlDbType.VarChar, 500);
            arParms[0].Value = CheckNull(objEProspectList.ListName);

            arParms[1] = new SqlParameter("@ListSource", SqlDbType.VarChar, 500);
            arParms[1].Value = CheckNull(objEProspectList.ListSource);

            arParms[2] = new SqlParameter("@UploadedStartDate", SqlDbType.VarChar, 20);
            arParms[2].Value = CheckNull(objEProspectList.DateCreated);

            arParms[3] = new SqlParameter("@UploadedEndDate", SqlDbType.VarChar, 20);
            arParms[3].Value = CheckNull(objEProspectList.DateModified);

            arParms[4] = new SqlParameter("@UploadedBy", SqlDbType.VarChar, 50);
            arParms[4].Value = CheckNull(objEProspectList.Username);

            arParms[5] = new SqlParameter("@Status", SqlDbType.VarChar, 50);
            arParms[5].Value = CheckNull(objEProspectList.ProspectListUploadStatus);

            arParms[6] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[6].Value = inputMode;

            arParms[7] = new SqlParameter("@ProspectListId", SqlDbType.BigInt);
            arParms[7].Value = objEProspectList.ProspectListID;

            arParms[8] = new SqlParameter("@RoleID", SqlDbType.Int);
            arParms[8].Value = objEProspectList.RoleID;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_GetProspectLists", arParms);
            List<EProspectList> returnEProspectList = new List<EProspectList>();
            returnEProspectList = ParsedProspectList(tempdataset);
            return returnEProspectList;
        }
        public List<EProspectList> GetProspectListCustomer(EProspectList objEProspectList, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[9];

            arParms[0] = new SqlParameter("@ListName", SqlDbType.VarChar, 500);
            arParms[0].Value = CheckNull(objEProspectList.ListName);

            arParms[1] = new SqlParameter("@ListSource", SqlDbType.VarChar, 500);
            arParms[1].Value = CheckNull(objEProspectList.ListSource);

            arParms[2] = new SqlParameter("@UploadedStartDate", SqlDbType.VarChar, 20);
            arParms[2].Value = CheckNull(objEProspectList.DateCreated);

            arParms[3] = new SqlParameter("@UploadedEndDate", SqlDbType.VarChar, 20);
            arParms[3].Value = CheckNull(objEProspectList.DateModified);

            arParms[4] = new SqlParameter("@UploadedBy", SqlDbType.VarChar, 50);
            arParms[4].Value = CheckNull(objEProspectList.Username);

            arParms[5] = new SqlParameter("@Status", SqlDbType.VarChar, 50);
            arParms[5].Value = CheckNull(objEProspectList.ProspectListUploadStatus);

            arParms[6] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[6].Value = inputMode;

            arParms[7] = new SqlParameter("@ProspectListId", SqlDbType.BigInt);
            arParms[7].Value = objEProspectList.ProspectListID;

            arParms[8] = new SqlParameter("@RoleID", SqlDbType.Int);
            arParms[8].Value = objEProspectList.RoleID;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_GetProspectCustomerList", arParms);
            List<EProspectList> returnEProspectList = new List<EProspectList>();
            returnEProspectList = ParsedProspectList(tempdataset);
            return returnEProspectList;
        }
        public List<EProspectList> ParsedProspectList(DataSet tempdataset)
        {
            List<EProspectList> returnEProspectList = new List<EProspectList>();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EProspectList objEProspectList1 = new EProspectList();

                objEProspectList1.ProspectListID = Convert.ToInt32(dr["ProspectListID"]);
                objEProspectList1.FileName = dr["FileName"].ToString();
                objEProspectList1.ListName = dr["ListName"].ToString();
                objEProspectList1.ListType = Convert.ToInt32(dr["ListType"]);
                objEProspectList1.ListSource = dr["ListSource"].ToString();
                objEProspectList1.DateCreated = dr["DateCreated"].ToString();
                objEProspectList1.NoOfProspect = dr["NoOfProspects"].ToString();
                objEProspectList1.NoOfProspectFailure = dr["NoOfProspectsFailure"].ToString();
                if (dr["Status"] != DBNull.Value)
                {
                    objEProspectList1.ProspectListUploadStatus = dr["Status"].ToString();
                }
                if (dr["UserName"] != DBNull.Value)
                {
                    objEProspectList1.Username = dr["UserName"].ToString();
                }
                if (dr["Role"] != DBNull.Value)
                {
                    objEProspectList1.UserRole = dr["Role"].ToString();
                }
                objEProspectList1.FileSize = dr["FileSize"].ToString();

                returnEProspectList.Add(objEProspectList1);
            }
            return returnEProspectList;
        }
        public EProspectList GetProspectListLog(EProspectList objEProspectList, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[8];

            arParms[0] = new SqlParameter("@ListName", SqlDbType.VarChar, 500);
            arParms[0].Value = CheckNull(objEProspectList.ListName);

            arParms[1] = new SqlParameter("@ListSource", SqlDbType.VarChar, 500);
            arParms[1].Value = CheckNull(objEProspectList.ListSource);

            arParms[2] = new SqlParameter("@UploadedStartDate", SqlDbType.VarChar, 20);
            arParms[2].Value = CheckNull(objEProspectList.DateCreated);

            arParms[3] = new SqlParameter("@UploadedEndDate", SqlDbType.VarChar, 20);
            arParms[3].Value = CheckNull(objEProspectList.DateModified);

            arParms[4] = new SqlParameter("@UploadedBy", SqlDbType.VarChar, 50);
            arParms[4].Value = CheckNull(objEProspectList.Username);

            arParms[5] = new SqlParameter("@Status", SqlDbType.VarChar, 50);
            arParms[5].Value = CheckNull(objEProspectList.ProspectListUploadStatus);

            arParms[6] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[6].Value = mode;

            arParms[7] = new SqlParameter("@ProspectListId", SqlDbType.BigInt);
            arParms[7].Value = objEProspectList.ProspectListID;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_GetProspectLists", arParms);

            if (tempdataset.Tables.Count < 1)
                return null;

            if (tempdataset.Tables[0].Rows.Count < 1)
                return null;

            DataRow dr = tempdataset.Tables[0].Rows[0];

            objEProspectList = new EProspectList();

            objEProspectList.ProspectListID = Convert.ToInt32(dr["ProspectListID"]);
            objEProspectList.FileName = dr["FileName"].ToString();
            objEProspectList.ListName = dr["ListName"].ToString();
            objEProspectList.ListType = Convert.ToInt32(dr["ListType"]);
            objEProspectList.ListSource = dr["ListSource"].ToString();
            objEProspectList.DateCreated = dr["DateCreated"].ToString();
            objEProspectList.NoOfProspect = dr["NoOfProspects"].ToString();
            objEProspectList.NoOfProspectFailure = dr["NoOfProspectsFailure"].ToString();
            if (dr["Status"] != DBNull.Value)
            {
                objEProspectList.ProspectListUploadStatus = dr["Status"].ToString();
            }
            if (dr["UserName"] != DBNull.Value)
            {
                objEProspectList.Username = dr["UserName"].ToString();
            }
            if (dr["Role"] != DBNull.Value)
            {
                objEProspectList.UserRole = dr["Role"].ToString();
            }
            objEProspectList.FileSize = dr["FileSize"].ToString();
            objEProspectList.LogList = dr["LOG_LIST"].ToString();
            objEProspectList.UploadTime = dr["UploadTime"].ToString();


            return objEProspectList;
        }
        /// <summary>
        /// Erase Prospect List
        /// </summary>
        /// <param name="iProspectList"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public Int64 ProspectListErase(Int64 iProspectList, int mode)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@ProspectListId", SqlDbType.BigInt);
            arParms[0].Value = iProspectList;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_ProspectListErase", arParms);
            returnvalue = (Int64)arParms[2].Value;
            return returnvalue;
        }
        /// <summary>
        /// Saves Prospect and Contact Mapping
        /// </summary>
        /// <param name="objcontact"></param>
        /// <param name="prospectid"></param>
        public void SaveProspectContact(Int64 contactid, Int64 prospectid, bool isactive)
        {
            string sqlQuery = "UPDATE TblProspectContact SET [IsActive]=0 WHERE [ContactID]=@contactid";
            SqlParameter[] arparamsdeac = new SqlParameter[1];
            arparamsdeac[0] = new SqlParameter("@contactid", SqlDbType.BigInt);
            arparamsdeac[0].Value = contactid;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.Text, sqlQuery, arparamsdeac);

            SqlParameter[] arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@contactid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@isactive", SqlDbType.Bit);

            arparams[0].Value = prospectid;
            arparams[1].Value = contactid;
            arparams[2].Value = isactive;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveprospectcontact", arparams);

        }

        /// <summary>
        /// Saves Prospect and Contact Role  Mapping
        /// </summary>
        /// <param name="listproscontrole"></param>
        /// <param name="contactid"></param>
        /// <param name="prospectid"></param>
        public void SaveProspectContactRoleMapping(List<EProspectContactRole> listproscontrole, Int64 contactid, Int64 prospectid)
        {

            string sqlquery = "Update TblProspectContactRoleMapping Set IsActive = 0 where ProspectContactId in (Select ProspectContactID " +
                                " from TblProspectContact where prospectid = @prospectid and Contactid = @contactid)";

            SqlParameter[] arparamsdeac = new SqlParameter[2];
            arparamsdeac[0] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arparamsdeac[1] = new SqlParameter("@contactid", SqlDbType.BigInt);

            arparamsdeac[0].Value = prospectid;
            arparamsdeac[1].Value = contactid;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.Text, sqlquery, arparamsdeac);


            SqlParameter[] arparams = new SqlParameter[3];
            arparams[0] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arparams[1] = new SqlParameter("@contactid", SqlDbType.BigInt);
            arparams[2] = new SqlParameter("@prospectcontactroleid", SqlDbType.BigInt);
            if (listproscontrole != null)
                for (int icount = 0; icount < listproscontrole.Count; icount++)
                {
                    arparams[0].Value = prospectid;
                    arparams[1].Value = contactid;
                    arparams[2].Value = listproscontrole[icount].ProspectContactRoleID;

                    SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveprospectcontactrolemapping", arparams);
                }
        }



        public EProspect ParseProspect(DataSet tempdataset)
        {
            List<EProspect> returnProspectDetails = new List<EProspect>();

            if (tempdataset.Tables.Count > 0 && tempdataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in tempdataset.Tables[0].Rows)
                {
                    EProspect objProspectDetails = new EProspect();
                    EProspectDetails objProspectDetail = new EProspectDetails();
                    objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectID"]);
                    objProspectDetails.EMailID = dr["EmailID"].ToString();
                    objProspectDetails.PhoneOffice = dr["PhoneOffice"].ToString();
                    objProspectDetails.PhoneCell = dr["PhoneCell"].ToString();
                    objProspectDetails.PhoneOther = dr["PhoneOther"].ToString();
                    objProspectDetails.WebSite = dr["WebSite"].ToString();
                    objProspectDetails.Notes = dr["Notes"].ToString();
                    objProspectDetails.OrganizationName = dr["OrganizationName"].ToString();
                    objProspectDetails.SalesRep = dr["SalesRep"].ToString();
                    objProspectDetails.Fax = dr["Fax"].ToString();

                    if (dr["ProspectTypeID"] != DBNull.Value)
                    {
                        objProspectDetails.ProspectType = new EProspectType();
                        objProspectDetails.ProspectType.ProspectTypeID = Convert.ToInt32(dr["ProspectTypeID"]);
                        objProspectDetails.ProspectType.Name = Convert.ToString(dr["ProspectType"]);
                    }
                    if (dr["ActualMembership"] != DBNull.Value)
                    {
                        objProspectDetails.ActualMembership = Convert.ToDecimal(dr["ActualMembership"]);
                    }
                    else
                    {
                        objProspectDetails.ActualMembership = 0;
                    }
                    if (dr["ActualAttendance"] != DBNull.Value)
                    {
                        objProspectDetails.Attendance = Convert.ToDecimal(dr["ActualAttendance"]);
                    }
                    else
                    {
                        objProspectDetails.Attendance = 0;
                    }
                    if (dr["MethodObtainedID"] != DBNull.Value)
                    {
                        objProspectDetails.MethodObtainedID = Convert.ToInt32(dr["MethodObtainedID"]);
                    }
                    else
                    {
                        objProspectDetails.MethodObtainedID = 0;
                    }

                    if (dr["WillPromote"] != DBNull.Value)
                    {
                        objProspectDetails.WillCommunicate = Convert.ToInt32(dr["WillPromote"]);
                    }
                    else
                    {
                        objProspectDetails.WillCommunicate = 0;
                    }

                    if (dr["ReasonWillPromote"] != DBNull.Value)
                    {
                        objProspectDetails.ReasonWillCommunicate = Convert.ToString(dr["ReasonWillPromote"]);
                    }

                    if (dr["FUDate"] != DBNull.Value)
                    {
                        objProspectDetails.FollowDate = Convert.ToDateTime(dr["FUDate"]).ToShortDateString();
                    }
                    // *** BEGIN Fill Prospect ***
                    objProspectDetails.Status = dr["Status"].ToString();

                    if (dr["ProspectDetailsID"] != DBNull.Value)
                    {
                        objProspectDetail.ProspectDetailID = Convert.ToInt64(dr["ProspectDetailsID"]);
                    }
                    if (dr["FacilitiesFee"] != DBNull.Value)
                    {
                        objProspectDetail.FacilitiesFee = Convert.ToString(dr["FacilitiesFee"]);
                    }
                    if (dr["PaymentMethod"] != DBNull.Value)
                    {
                        objProspectDetail.PaymentMethod = Convert.ToString(dr["PaymentMethod"]);
                    }
                    if (dr["DepositsRequire"] != DBNull.Value)
                    {
                        objProspectDetail.DepositsRequire = Convert.ToInt16(dr["DepositsRequire"]);
                    }
                    if (dr["DepositsAmount"] != DBNull.Value)
                    {
                        objProspectDetail.DepositsAmount = Convert.ToDecimal(dr["DepositsAmount"]);
                    }
                    if (dr["ViableHostSite"] != DBNull.Value)
                    {
                        objProspectDetail.ViableHostSite = Convert.ToInt16(dr["ViableHostSite"]);
                    }
                    if (dr["HostedInPast"] != DBNull.Value)
                    {
                        objProspectDetail.HostedInPast = Convert.ToInt16(dr["HostedInPast"]);
                    }
                    if (dr["HostedInPastWith"] != DBNull.Value)
                    {
                        objProspectDetail.HostedInPastWith = Convert.ToString(dr["HostedInPastWith"]);
                    }
                    if (dr["WillHost"] != DBNull.Value)
                    {
                        objProspectDetail.WillHost = Convert.ToInt16(dr["WillHost"]);
                    }
                    ////
                    if (dr["ReasonViableHostSite"] != DBNull.Value)
                    {
                        objProspectDetail.ReasonViableHostSite = Convert.ToString(dr["ReasonViableHostSite"]);
                    }
                    if (dr["ReasonHostedInPast"] != DBNull.Value)
                    {
                        objProspectDetail.ReasonHostedInPast = Convert.ToString(dr["ReasonHostedInPast"]);
                    }
                    if (dr["ReasonWillHost"] != DBNull.Value)
                    {
                        objProspectDetail.ReasonWillHost = Convert.ToString(dr["ReasonWillHost"]);
                    }
                    objProspectDetails.ProspectDetails = new EProspectDetails();
                    objProspectDetails.ProspectDetails = objProspectDetail;
                    // *** END Fill Prospect ***


                    objProspectDetails.Address = new EAddress();
                    objProspectDetails.AddressMailing = new EAddress();

                    string prospectId = dr["ProspectID"].ToString();
                    if (tempdataset.Tables[1].Select("ProspectID=" + prospectId).Length > 0)
                    {
                        DataRow drAddressBilling = null;
                        DataRow drAddressMailing = null;
                        if (tempdataset.Tables[1].Select("ProspectID=" + prospectId + "And IsMailing=0").Length > 0)
                        {
                            drAddressBilling = tempdataset.Tables[1].Select("ProspectID=" + prospectId + "And IsMailing=0")[0];
                        }
                        if (tempdataset.Tables[1].Select("ProspectID=" + prospectId + "And IsMailing=1").Length > 0)
                        {
                            drAddressMailing = tempdataset.Tables[1].Select("ProspectID=" + prospectId + "And IsMailing=1")[0];
                        }

                        // Billing Address
                        if (drAddressBilling != null)
                        {
                            objProspectDetails.Address.AddressID = Convert.ToInt32(drAddressBilling["ProspectAddressID"]);
                            objProspectDetails.Address.Address1 = drAddressBilling["Address1"].ToString();
                            objProspectDetails.Address.Address2 = drAddressBilling["Address2"].ToString();
                            objProspectDetails.Address.Zip = Convert.ToString(drAddressBilling["ZIP"]);
                            objProspectDetails.Address.City = drAddressBilling["CityName"].ToString();
                            objProspectDetails.Address.State = drAddressBilling["StateName"].ToString();
                            objProspectDetails.Address.Country = drAddressBilling["CountryName"].ToString();
                            objProspectDetails.Address.Fax = drAddressBilling["Fax"].ToString();
                        }
                        // Mailing Address
                        if (drAddressMailing != null)
                        {
                            objProspectDetails.AddressMailing.AddressID = Convert.ToInt32(drAddressMailing["ProspectAddressID"]);
                            objProspectDetails.AddressMailing.Address1 = drAddressMailing["Address1"].ToString();
                            objProspectDetails.AddressMailing.Address2 = drAddressMailing["Address2"].ToString();
                            objProspectDetails.AddressMailing.Zip = Convert.ToString(drAddressMailing["ZIP"]);
                            objProspectDetails.AddressMailing.City = drAddressMailing["CityName"].ToString();
                            objProspectDetails.AddressMailing.State = drAddressMailing["StateName"].ToString();
                            objProspectDetails.AddressMailing.Country = drAddressMailing["CountryName"].ToString();
                            objProspectDetails.AddressMailing.Fax = drAddressMailing["Fax"].ToString();
                        }
                    }
                    if (tempdataset.Tables.Count >= 3 && tempdataset.Tables[2] != null)
                    {
                        if (tempdataset.Tables[2].Select("ProspectID=" + prospectId).Length > 0)
                        {
                            objProspectDetails.Contact = new List<EContact>();
                            for (int icount = 0; icount < tempdataset.Tables[2].Select("ProspectID=" + prospectId).Length; icount++)
                            {
                                DataRow drContact = tempdataset.Tables[2].Select("ProspectID=" + prospectId)[icount];
                                EContact objContact = new EContact();
                                EContactNotes objEContactNotes = new EContactNotes();

                                objContact.ContactID = Convert.ToInt32(drContact["ContactID"]);
                                objContact.Title = drContact["Salutation"].ToString();
                                objContact.FirstName = drContact["FirstName"].ToString();
                                objContact.MiddleName = drContact["MiddleName"].ToString();
                                objContact.LastName = drContact["LastName"].ToString();
                                objContact.EMail = drContact["EMail"].ToString();
                                objContact.EmailWork = drContact["EMailOffice"].ToString();
                                objContact.PhoneCell = drContact["PhoneCell"].ToString();
                                objContact.PhoneHome = drContact["PhoneHome"].ToString();
                                objContact.PhoneOffice = drContact["PhoneOffice"].ToString();
                                objContact.Phone1Extension = drContact["PhoneOfficeExtension"].ToString();
                                objContact.Fax = drContact["Fax"].ToString();
                                objContact.DesignationTitle = drContact["Title"].ToString();

                                objContact.Address = new EAddress();
                                objContact.Address.Address1 = drContact["Address1"].ToString();
                                objContact.Address.Address2 = drContact["Address2"].ToString();
                                objContact.Address.City = drContact["City"].ToString();
                                objContact.Address.State = drContact["State"].ToString();
                                objContact.Address.Zip = drContact["ZipCode"].ToString();

                                if (tempdataset.Tables[3].Rows.Count > 0)
                                {
                                    tempdataset.Tables[3].DefaultView.RowFilter = "ContactID = " + objContact.ContactID.ToString();
                                    if (tempdataset.Tables[3].DefaultView.Count > 0)
                                    {
                                        objContact.ListProspectContactRole = new List<EProspectContactRole>();
                                        foreach (DataRowView drv in tempdataset.Tables[3].DefaultView)
                                        {
                                            EProspectContactRole objproscontrole = new EProspectContactRole();
                                            objproscontrole.ProspectContactRoleID = Convert.ToInt16(drv["ProspectContactRoleID"]);
                                            objproscontrole.ProspectContactRoleName = drv["ProspectContactRoleName"].ToString();
                                            objContact.ListProspectContactRole.Add(objproscontrole);
                                        }
                                    }
                                }

                                // Add contact notes
                                objEContactNotes.ContactID = Convert.ToInt32(drContact["ContactID"]);
                                objEContactNotes.Notes = drContact["Notes"].ToString();
                                objContact.ContactNotes = new List<EContactNotes>();
                                objContact.ContactNotes.Add(objEContactNotes);

                                objProspectDetails.Contact.Add(objContact);
                            }
                        }
                    }

                    returnProspectDetails.Add(objProspectDetails);
                }
            }
            if (returnProspectDetails.Count > 0)
                return returnProspectDetails[0];
            else return null;
        }

        public EProspect ParseHost(DataSet tempdataset)
        {
            List<EProspect> returnProspectDetails = new List<EProspect>();

            if (tempdataset.Tables.Count > 0 && tempdataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in tempdataset.Tables[0].Rows)
                {
                    EProspect objProspectDetails = new EProspect();
                    objProspectDetails.ProspectType = new EProspectType();
                    EProspectDetails objProspectDetail = new EProspectDetails();

                    objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectID"]);
                    objProspectDetails.EMailID = dr["EmailID"].ToString();
                    objProspectDetails.PhoneOffice = dr["PhoneOffice"].ToString();
                    objProspectDetails.PhoneCell = dr["PhoneCell"].ToString();
                    objProspectDetails.PhoneOther = dr["PhoneOther"].ToString();
                    objProspectDetails.WebSite = dr["WebSite"].ToString();
                    objProspectDetails.OrganizationName = dr["OrganizationName"].ToString();
                    objProspectDetails.Notes = dr["Notes"].ToString();
                    objProspectDetails.SalesRep = dr["SalesRep"].ToString();
                    objProspectDetails.TaxIdNumber = dr["TaxIdNumber"].ToString();
                    objProspectDetails.Fax = dr["Fax"].ToString();
                    if (dr["ProspectType"] != DBNull.Value)
                    {
                        objProspectDetails.ProspectType.Name = dr["ProspectType"].ToString();
                    }
                    else
                    {
                        objProspectDetails.ProspectType.Name = "-N/A-";
                    }
                    if (dr["EventDate"] != DBNull.Value)
                    {
                        objProspectDetails.LastEventDate = dr["EventDate"].ToString();
                    }
                    else
                    {
                        objProspectDetails.LastEventDate = "-N/A-";
                    }
                    if (dr["EventName"] != DBNull.Value)
                    {
                        objProspectDetails.LastEventName = dr["EventName"].ToString();
                    }
                    else
                    {
                        objProspectDetails.LastEventName = "-N/A-";
                    }

                    if (dr["ProspectTypeID"] != DBNull.Value)
                    {
                        objProspectDetails.ProspectType.ProspectTypeID = Convert.ToInt32(dr["ProspectTypeID"]);
                    }
                    if (dr["ActualMembership"] != DBNull.Value)
                    {
                        objProspectDetails.ActualMembership = Convert.ToDecimal(dr["ActualMembership"]);
                    }
                    else
                    {
                        objProspectDetails.ActualMembership = 0;
                    }
                    if (dr["ActualAttendance"] != DBNull.Value)
                    {
                        objProspectDetails.Attendance = Convert.ToDecimal(dr["ActualAttendance"]);
                    }
                    else
                    {
                        objProspectDetails.Attendance = 0;
                    }
                    if (dr["MethodObtainedID"] != DBNull.Value)
                    {
                        objProspectDetails.MethodObtainedID = Convert.ToInt32(dr["MethodObtainedID"]);
                    }
                    else
                    {
                        objProspectDetails.MethodObtainedID = 0;
                    }

                    if (dr["WillPromote"] != DBNull.Value)
                    {
                        objProspectDetails.WillCommunicate = Convert.ToInt32(dr["WillPromote"]);
                    }
                    else
                    {
                        objProspectDetails.WillCommunicate = 0;
                    }

                    if (dr["FUDate"] != DBNull.Value)
                    {
                        objProspectDetails.FollowDate = Convert.ToDateTime(dr["FUDate"]).ToShortDateString();
                    }
                    objProspectDetails.Status = dr["Status"].ToString();

                    // *** BEGIN Fill Prospect ***                

                    if (dr["ProspectDetailsID"] != DBNull.Value)
                    {
                        objProspectDetail.ProspectDetailID = Convert.ToInt64(dr["ProspectDetailsID"]);
                    }
                    if (dr["FacilitiesFee"] != DBNull.Value)
                    {
                        objProspectDetail.FacilitiesFee = Convert.ToString(dr["FacilitiesFee"]);
                    }
                    if (dr["PaymentMethod"] != DBNull.Value)
                    {
                        objProspectDetail.PaymentMethod = Convert.ToString(dr["PaymentMethod"]);
                    }
                    if (dr["DepositsRequire"] != DBNull.Value)
                    {
                        objProspectDetail.DepositsRequire = Convert.ToInt16(dr["DepositsRequire"]);
                    }
                    if (dr["DepositsAmount"] != DBNull.Value)
                    {
                        objProspectDetail.DepositsAmount = Convert.ToDecimal(dr["DepositsAmount"]);
                    }
                    if (dr["ViableHostSite"] != DBNull.Value)
                    {
                        objProspectDetail.ViableHostSite = Convert.ToInt16(dr["ViableHostSite"]);
                    }
                    if (dr["HostedInPast"] != DBNull.Value)
                    {
                        objProspectDetail.HostedInPast = Convert.ToInt16(dr["HostedInPast"]);
                    }
                    if (dr["HostedInPastWith"] != DBNull.Value)
                    {
                        objProspectDetail.HostedInPastWith = Convert.ToString(dr["HostedInPastWith"]);
                    }
                    if (dr["WillHost"] != DBNull.Value)
                    {
                        objProspectDetail.WillHost = Convert.ToInt16(dr["WillHost"]);
                    }

                    objProspectDetails.ProspectDetails = new EProspectDetails();
                    objProspectDetails.ProspectDetails = objProspectDetail;
                    // *** END Fill Prospect ***

                    objProspectDetails.Address = new EAddress();
                    objProspectDetails.AddressMailing = new EAddress();

                    string prospectId = dr["ProspectID"].ToString();
                    DataRow drAddressBilling = null;
                    DataRow drAddressMailing = null;

                    if (tempdataset.Tables[1].Rows.Count > 0)
                    {
                        drAddressBilling = tempdataset.Tables[1].Rows[0];
                    }
                    if (tempdataset.Tables[1].Rows.Count > 1)
                    {
                        drAddressMailing = tempdataset.Tables[1].Rows[1];
                    }
                    // Billing Address
                    if (drAddressBilling != null)
                    {
                        objProspectDetails.Address.AddressID = Convert.ToInt32(drAddressBilling["AddressID"]);
                        objProspectDetails.Address.Address1 = drAddressBilling["Address1"].ToString();
                        objProspectDetails.Address.Address2 = drAddressBilling["Address2"].ToString();
                        objProspectDetails.Address.Zip = Convert.ToString(drAddressBilling["ZIPCode"]);
                        objProspectDetails.Address.City = drAddressBilling["CityName"].ToString();
                        objProspectDetails.Address.State = drAddressBilling["StateName"].ToString();
                        objProspectDetails.Address.Country = drAddressBilling["CountryName"].ToString();
                        objProspectDetails.Address.Fax = drAddressBilling["Fax"].ToString();
                        objProspectDetails.Address.GoogleAddressVerifiedBy = Convert.ToString(drAddressBilling["AddressVerifiedBy"]);
                    }
                    // Mailing Address
                    if (drAddressMailing != null)
                    {
                        objProspectDetails.AddressMailing.AddressID = Convert.ToInt32(drAddressMailing["AddressID"]);
                        objProspectDetails.AddressMailing.Address1 = drAddressMailing["Address1"].ToString();
                        objProspectDetails.AddressMailing.Address2 = drAddressMailing["Address2"].ToString();
                        objProspectDetails.AddressMailing.Zip = Convert.ToString(drAddressMailing["ZIPCode"]);
                        objProspectDetails.AddressMailing.City = drAddressMailing["CityName"].ToString();
                        objProspectDetails.AddressMailing.State = drAddressMailing["StateName"].ToString();
                        objProspectDetails.AddressMailing.Country = drAddressMailing["CountryName"].ToString();
                        objProspectDetails.AddressMailing.Fax = drAddressMailing["Fax"].ToString();
                    }


                    if (tempdataset.Tables.Count >= 3 && tempdataset.Tables[2] != null)
                    {
                        if (tempdataset.Tables[2].Select("ProspectID=" + prospectId).Length > 0)
                        {
                            objProspectDetails.Contact = new List<EContact>();
                            for (int icount = 0; icount < tempdataset.Tables[2].Select("ProspectID=" + prospectId).Length; icount++)
                            {
                                DataRow drContact = tempdataset.Tables[2].Select("ProspectID=" + prospectId)[icount];
                                EContact objContact = new EContact();
                                EContactNotes objEContactNotes = new EContactNotes();

                                objContact.ContactID = Convert.ToInt32(drContact["ContactID"]);
                                objContact.Title = drContact["Salutation"].ToString();
                                objContact.FirstName = drContact["FirstName"].ToString();
                                objContact.MiddleName = drContact["MiddleName"].ToString();
                                objContact.LastName = drContact["LastName"].ToString();
                                objContact.EMail = drContact["EMail"].ToString();
                                objContact.EmailWork = drContact["EMailOffice"].ToString();
                                objContact.PhoneCell = drContact["PhoneCell"].ToString();
                                objContact.PhoneHome = drContact["PhoneHome"].ToString();
                                objContact.PhoneOffice = drContact["PhoneOffice"].ToString();
                                objContact.Phone1Extension = drContact["PhoneOfficeExtension"].ToString();
                                objContact.Fax = drContact["Fax"].ToString();
                                objContact.DesignationTitle = drContact["Title"].ToString(); ;

                                objContact.Address = new EAddress();
                                objContact.Address.Address1 = drContact["Address1"].ToString();
                                objContact.Address.Address2 = drContact["Address2"].ToString();
                                objContact.Address.City = drContact["City"].ToString();
                                objContact.Address.State = drContact["State"].ToString();
                                objContact.Address.Zip = drContact["ZipCode"].ToString();

                                if (tempdataset.Tables[3].Rows.Count > 0)
                                {
                                    tempdataset.Tables[3].DefaultView.RowFilter = "ContactID = " + objContact.ContactID.ToString();
                                    if (tempdataset.Tables[3].DefaultView.Count > 0)
                                    {
                                        objContact.ListProspectContactRole = new List<EProspectContactRole>();
                                        foreach (DataRowView drv in tempdataset.Tables[3].DefaultView)
                                        {
                                            EProspectContactRole objproscontrole = new EProspectContactRole();
                                            objproscontrole.ProspectContactRoleID = Convert.ToInt16(drv["ProspectContactRoleID"]);
                                            objproscontrole.ProspectContactRoleName = drv["ProspectContactRoleName"].ToString();
                                            objContact.ListProspectContactRole.Add(objproscontrole);
                                        }
                                    }
                                }

                                // Add contact notes
                                objEContactNotes.ContactID = Convert.ToInt32(drContact["ContactID"]);
                                objEContactNotes.Notes = drContact["Notes"].ToString();
                                objContact.ContactNotes = new List<EContactNotes>();
                                objContact.ContactNotes.Add(objEContactNotes);

                                objProspectDetails.Contact.Add(objContact);
                            }
                        }
                    }
                    returnProspectDetails.Add(objProspectDetails);
                }
            }
            if (returnProspectDetails.Count > 0)
                return returnProspectDetails[0];
            else return null;
        }
        /// <summary>
        /// mode "0->All rows,1->Rows by ProspectListID,3->All inactive rows",name,dbid
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EProspect> GetProspectDetails(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getprospectdetails", arParms);

            List<EProspect> returnProspectDetails = new List<EProspect>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EProspect objProspectDetails = new EProspect();
                EProspectDetails objProspectDetail = new EProspectDetails();
                objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectID"]);
                objProspectDetails.EMailID = dr["EmailID"].ToString();
                objProspectDetails.PhoneOffice = dr["PhoneOffice"].ToString();
                objProspectDetails.PhoneCell = dr["PhoneCell"].ToString();
                objProspectDetails.PhoneOther = dr["PhoneOther"].ToString();
                objProspectDetails.WebSite = dr["WebSite"].ToString();
                objProspectDetails.Notes = dr["Notes"].ToString();
                objProspectDetails.OrganizationName = dr["OrganizationName"].ToString();
                objProspectDetails.Fax = dr["Fax"].ToString();
                if (dr["ProspectTypeID"] != DBNull.Value)
                {
                    objProspectDetails.ProspectType = new EProspectType();
                    objProspectDetails.ProspectType.ProspectTypeID = Convert.ToInt32(dr["ProspectTypeID"]);
                    objProspectDetails.ProspectType.Name = Convert.ToString(dr["ProspectType"]);
                }
                if (dr["ActualMembership"] != DBNull.Value)
                {
                    objProspectDetails.ActualMembership = Convert.ToDecimal(dr["ActualMembership"]);
                }
                else
                {
                    objProspectDetails.ActualMembership = 0;
                }
                if (dr["ActualAttendance"] != DBNull.Value)
                {
                    objProspectDetails.Attendance = Convert.ToDecimal(dr["ActualAttendance"]);
                }
                else
                {
                    objProspectDetails.Attendance = 0;
                }
                if (dr["MethodObtainedID"] != DBNull.Value)
                {
                    objProspectDetails.MethodObtainedID = Convert.ToInt32(dr["MethodObtainedID"]);
                }
                else
                {
                    objProspectDetails.MethodObtainedID = 0;
                }

                if (dr["WillPromote"] != DBNull.Value)
                {
                    objProspectDetails.WillCommunicate = Convert.ToInt32(dr["WillPromote"]);
                }
                else
                {
                    objProspectDetails.WillCommunicate = 0;
                }

                if (dr["ReasonWillPromote"] != DBNull.Value)
                {
                    objProspectDetails.ReasonWillCommunicate = Convert.ToString(dr["ReasonWillPromote"]);
                }

                if (dr["FUDate"] != DBNull.Value)
                {
                    objProspectDetails.FollowDate = Convert.ToDateTime(dr["FUDate"]).ToShortDateString();
                }
                // *** BEGIN Fill Prospect ***
                objProspectDetails.Status = dr["Status"].ToString();

                if (dr["ProspectDetailsID"] != DBNull.Value)
                {
                    objProspectDetail.ProspectDetailID = Convert.ToInt64(dr["ProspectDetailsID"]);
                }
                if (dr["FacilitiesFee"] != DBNull.Value)
                {
                    objProspectDetail.FacilitiesFee = Convert.ToString(dr["FacilitiesFee"]);
                }
                if (dr["PaymentMethod"] != DBNull.Value)
                {
                    objProspectDetail.PaymentMethod = Convert.ToString(dr["PaymentMethod"]);
                }
                if (dr["DepositsRequire"] != DBNull.Value)
                {
                    objProspectDetail.DepositsRequire = Convert.ToInt16(dr["DepositsRequire"]);
                }
                if (dr["DepositsAmount"] != DBNull.Value)
                {
                    objProspectDetail.DepositsAmount = Convert.ToDecimal(dr["DepositsAmount"]);
                }
                if (dr["ViableHostSite"] != DBNull.Value)
                {
                    objProspectDetail.ViableHostSite = Convert.ToInt16(dr["ViableHostSite"]);
                }
                if (dr["HostedInPast"] != DBNull.Value)
                {
                    objProspectDetail.HostedInPast = Convert.ToInt16(dr["HostedInPast"]);
                }
                if (dr["HostedInPastWith"] != DBNull.Value)
                {
                    objProspectDetail.HostedInPastWith = Convert.ToString(dr["HostedInPastWith"]);
                }
                if (dr["WillHost"] != DBNull.Value)
                {
                    objProspectDetail.WillHost = Convert.ToInt16(dr["WillHost"]);
                }
                ////
                if (dr["ReasonViableHostSite"] != DBNull.Value)
                {
                    objProspectDetail.ReasonViableHostSite = Convert.ToString(dr["ReasonViableHostSite"]);
                }
                if (dr["ReasonHostedInPast"] != DBNull.Value)
                {
                    objProspectDetail.ReasonHostedInPast = Convert.ToString(dr["ReasonHostedInPast"]);
                }
                if (dr["ReasonWillHost"] != DBNull.Value)
                {
                    objProspectDetail.ReasonWillHost = Convert.ToString(dr["ReasonWillHost"]);
                }
                objProspectDetails.ProspectDetails = new EProspectDetails();
                objProspectDetails.ProspectDetails = objProspectDetail;
                // *** END Fill Prospect ***


                objProspectDetails.Address = new EAddress();
                objProspectDetails.AddressMailing = new EAddress();

                string prospectId = dr["ProspectID"].ToString();
                if (tempdataset.Tables[1].Select("ProspectID=" + prospectId).Length > 0)
                {
                    DataRow drAddressBilling = null;
                    DataRow drAddressMailing = null;
                    if (tempdataset.Tables[1].Select("ProspectID=" + prospectId + "And IsMailing=0").Length > 0)
                    {
                        drAddressBilling = tempdataset.Tables[1].Select("ProspectID=" + prospectId + "And IsMailing=0")[0];
                    }
                    if (tempdataset.Tables[1].Select("ProspectID=" + prospectId + "And IsMailing=1").Length > 0)
                    {
                        drAddressMailing = tempdataset.Tables[1].Select("ProspectID=" + prospectId + "And IsMailing=1")[0];
                    }

                    // Billing Address
                    if (drAddressBilling != null)
                    {
                        objProspectDetails.Address.AddressID = Convert.ToInt32(drAddressBilling["ProspectAddressID"]);
                        objProspectDetails.Address.Address1 = drAddressBilling["Address1"].ToString();
                        objProspectDetails.Address.Address2 = drAddressBilling["Address2"].ToString();
                        objProspectDetails.Address.Zip = Convert.ToString(drAddressBilling["ZIP"]);
                        objProspectDetails.Address.City = drAddressBilling["CityName"].ToString();
                        objProspectDetails.Address.State = drAddressBilling["StateName"].ToString();
                        objProspectDetails.Address.Country = drAddressBilling["CountryName"].ToString();
                        objProspectDetails.Address.Fax = drAddressBilling["Fax"].ToString();
                    }
                    // Mailing Address
                    if (drAddressMailing != null)
                    {
                        objProspectDetails.AddressMailing.AddressID = Convert.ToInt32(drAddressMailing["ProspectAddressID"]);
                        objProspectDetails.AddressMailing.Address1 = drAddressMailing["Address1"].ToString();
                        objProspectDetails.AddressMailing.Address2 = drAddressMailing["Address2"].ToString();
                        objProspectDetails.AddressMailing.Zip = Convert.ToString(drAddressMailing["ZIP"]);
                        objProspectDetails.AddressMailing.City = drAddressMailing["CityName"].ToString();
                        objProspectDetails.AddressMailing.State = drAddressMailing["StateName"].ToString();
                        objProspectDetails.AddressMailing.Country = drAddressMailing["CountryName"].ToString();
                        objProspectDetails.AddressMailing.Fax = drAddressMailing["Fax"].ToString();
                    }
                }
                if (tempdataset.Tables.Count >= 3 && tempdataset.Tables[2] != null)
                {
                    if (tempdataset.Tables[2].Select("ProspectID=" + prospectId).Length > 0)
                    {
                        objProspectDetails.Contact = new List<EContact>();
                        for (int icount = 0; icount < tempdataset.Tables[2].Select("ProspectID=" + prospectId).Length; icount++)
                        {
                            DataRow drContact = tempdataset.Tables[2].Select("ProspectID=" + prospectId)[icount];
                            EContact objContact = new EContact();
                            EContactNotes objEContactNotes = new EContactNotes();

                            objContact.ContactID = Convert.ToInt32(drContact["ContactID"]);
                            objContact.Title = drContact["Salutation"].ToString();
                            objContact.FirstName = drContact["FirstName"].ToString();
                            objContact.MiddleName = drContact["MiddleName"].ToString();
                            objContact.LastName = drContact["LastName"].ToString();
                            objContact.EMail = drContact["EMail"].ToString();
                            objContact.EmailWork = drContact["EMailOffice"].ToString();
                            objContact.PhoneHome = drContact["PhoneHome"].ToString();
                            objContact.PhoneCell = drContact["PhoneCell"].ToString();
                            objContact.PhoneOffice = drContact["PhoneOffice"].ToString();
                            objContact.Phone1Extension = drContact["PhoneOfficeExtension"].ToString();
                            objContact.Fax = drContact["Fax"].ToString();
                            objContact.DateOfBirth = drContact["DateOfBirth"].ToString();
                            objContact.DesignationTitle = drContact["Title"].ToString();
                            objContact.Gender = Convert.ToBoolean(drContact["Gender"]);

                            objContact.Address = new EAddress();
                            objContact.Address.Address1 = drContact["Address1"].ToString();
                            objContact.Address.Address2 = drContact["Address2"].ToString();
                            objContact.Address.City = drContact["City"].ToString();
                            objContact.Address.State = drContact["State"].ToString();
                            objContact.Address.Zip = drContact["ZipCode"].ToString();

                            if (tempdataset.Tables[3].Rows.Count > 0)
                            {
                                tempdataset.Tables[3].DefaultView.RowFilter = "ContactID = " + objContact.ContactID.ToString();
                                if (tempdataset.Tables[3].DefaultView.Count > 0)
                                {
                                    objContact.ListProspectContactRole = new List<EProspectContactRole>();
                                    foreach (DataRowView drv in tempdataset.Tables[3].DefaultView)
                                    {
                                        EProspectContactRole objproscontrole = new EProspectContactRole();
                                        objproscontrole.ProspectContactRoleID = Convert.ToInt16(drv["ProspectContactRoleID"]);
                                        objproscontrole.ProspectContactRoleName = drv["ProspectContactRoleName"].ToString();
                                        objContact.ListProspectContactRole.Add(objproscontrole);
                                    }
                                }
                            }

                            // Add contact notes
                            objEContactNotes.ContactID = Convert.ToInt32(drContact["ContactID"]);
                            objEContactNotes.Notes = drContact["Notes"].ToString();
                            objContact.ContactNotes = new List<EContactNotes>();
                            objContact.ContactNotes.Add(objEContactNotes);

                            objProspectDetails.Contact.Add(objContact);
                        }
                    }
                }

                returnProspectDetails.Add(objProspectDetails);
            }

            return returnProspectDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EProspect> GetHostDetails(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_gethostdetails", arParms);

            List<EProspect> returnProspectDetails = new List<EProspect>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EProspect objProspectDetails = new EProspect();
                objProspectDetails.ProspectType = new EProspectType();
                EProspectDetails objProspectDetail = new EProspectDetails();

                objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectID"]);
                objProspectDetails.EMailID = dr["EmailID"].ToString();
                objProspectDetails.PhoneOffice = dr["PhoneOffice"].ToString();
                objProspectDetails.PhoneCell = dr["PhoneCell"].ToString();
                objProspectDetails.PhoneOther = dr["PhoneOther"].ToString();
                objProspectDetails.WebSite = dr["WebSite"].ToString();
                objProspectDetails.OrganizationName = dr["OrganizationName"].ToString();
                objProspectDetails.Notes = dr["Notes"].ToString();
                objProspectDetails.Fax = dr["Fax"].ToString();
                objProspectDetails.IsHost = true;

                if (dr["ProspectType"] != DBNull.Value)
                {
                    objProspectDetails.ProspectType.Name = dr["ProspectType"].ToString();
                }
                else
                {
                    objProspectDetails.ProspectType.Name = "-N/A-";
                }
                if (dr["EventDate"] != DBNull.Value)
                {
                    objProspectDetails.LastEventDate = dr["EventDate"].ToString();
                }
                else
                {
                    objProspectDetails.LastEventDate = "-N/A-";
                }
                if (dr["EventName"] != DBNull.Value)
                {
                    objProspectDetails.LastEventName = dr["EventName"].ToString();
                }
                else
                {
                    objProspectDetails.LastEventName = "-N/A-";
                }

                if (dr["ProspectTypeID"] != DBNull.Value)
                {
                    objProspectDetails.ProspectType.ProspectTypeID = Convert.ToInt32(dr["ProspectTypeID"]);
                }
                if (dr["ActualMembership"] != DBNull.Value)
                {
                    objProspectDetails.ActualMembership = Convert.ToDecimal(dr["ActualMembership"]);
                }
                else
                {
                    objProspectDetails.ActualMembership = 0;
                }
                if (dr["ActualAttendance"] != DBNull.Value)
                {
                    objProspectDetails.Attendance = Convert.ToDecimal(dr["ActualAttendance"]);
                }
                else
                {
                    objProspectDetails.Attendance = 0;
                }
                if (dr["MethodObtainedID"] != DBNull.Value)
                {
                    objProspectDetails.MethodObtainedID = Convert.ToInt32(dr["MethodObtainedID"]);
                }
                else
                {
                    objProspectDetails.MethodObtainedID = 0;
                }

                if (dr["WillPromote"] != DBNull.Value)
                {
                    objProspectDetails.WillCommunicate = Convert.ToInt32(dr["WillPromote"]);
                }
                else
                {
                    objProspectDetails.WillCommunicate = 0;
                }

                if (dr["ReasonWillPromote"] != DBNull.Value)
                {
                    objProspectDetails.ReasonWillCommunicate = Convert.ToString(dr["ReasonWillPromote"]);
                }

                if (dr["FUDate"] != DBNull.Value)
                {
                    objProspectDetails.FollowDate = Convert.ToDateTime(dr["FUDate"]).ToShortDateString();
                }
                objProspectDetails.Status = dr["Status"].ToString();

                // *** BEGIN Fill Prospect ***                

                if (dr["ProspectDetailsID"] != DBNull.Value)
                {
                    objProspectDetail.ProspectDetailID = Convert.ToInt64(dr["ProspectDetailsID"]);
                }
                if (dr["FacilitiesFee"] != DBNull.Value)
                {
                    objProspectDetail.FacilitiesFee = Convert.ToString(dr["FacilitiesFee"]);
                }
                if (dr["PaymentMethod"] != DBNull.Value)
                {
                    objProspectDetail.PaymentMethod = Convert.ToString(dr["PaymentMethod"]);
                }
                if (dr["DepositsRequire"] != DBNull.Value)
                {
                    objProspectDetail.DepositsRequire = Convert.ToInt16(dr["DepositsRequire"]);
                }
                if (dr["DepositsAmount"] != DBNull.Value)
                {
                    objProspectDetail.DepositsAmount = Convert.ToDecimal(dr["DepositsAmount"]);
                }
                if (dr["TaxIdNumber"] != DBNull.Value)
                    objProspectDetails.TaxIdNumber = dr["TaxIdNumber"].ToString();

                if (dr["ViableHostSite"] != DBNull.Value)
                {
                    objProspectDetail.ViableHostSite = Convert.ToInt16(dr["ViableHostSite"]);
                }
                if (dr["HostedInPast"] != DBNull.Value)
                {
                    objProspectDetail.HostedInPast = Convert.ToInt16(dr["HostedInPast"]);
                }
                if (dr["HostedInPastWith"] != DBNull.Value)
                {
                    objProspectDetail.HostedInPastWith = Convert.ToString(dr["HostedInPastWith"]);
                }
                if (dr["WillHost"] != DBNull.Value)
                {
                    objProspectDetail.WillHost = Convert.ToInt16(dr["WillHost"]);
                }

                ////
                if (dr["ReasonViableHostSite"] != DBNull.Value)
                {
                    objProspectDetail.ReasonViableHostSite = Convert.ToString(dr["ReasonViableHostSite"]);
                }
                if (dr["ReasonHostedInPast"] != DBNull.Value)
                {
                    objProspectDetail.ReasonHostedInPast = Convert.ToString(dr["ReasonHostedInPast"]);
                }
                if (dr["ReasonWillHost"] != DBNull.Value)
                {
                    objProspectDetail.ReasonWillHost = Convert.ToString(dr["ReasonWillHost"]);
                }

                objProspectDetails.ProspectDetails = new EProspectDetails();
                objProspectDetails.ProspectDetails = objProspectDetail;
                // *** END Fill Prospect ***

                objProspectDetails.Address = new EAddress();
                objProspectDetails.AddressMailing = new EAddress();

                string prospectId = dr["ProspectID"].ToString();
                DataRow drAddressBilling = null;
                DataRow drAddressMailing = null;

                if (tempdataset.Tables[1].Rows.Count > 0)
                {
                    drAddressBilling = tempdataset.Tables[1].Rows[0];
                }
                if (tempdataset.Tables[1].Rows.Count > 1)
                {
                    drAddressMailing = tempdataset.Tables[1].Rows[1];
                }
                // Billing Address
                if (drAddressBilling != null)
                {
                    objProspectDetails.Address.AddressID = Convert.ToInt32(drAddressBilling["AddressID"]);
                    objProspectDetails.Address.Address1 = drAddressBilling["Address1"].ToString();
                    objProspectDetails.Address.Address2 = drAddressBilling["Address2"].ToString();
                    objProspectDetails.Address.Zip = Convert.ToString(drAddressBilling["ZIPCode"]);
                    objProspectDetails.Address.City = drAddressBilling["CityName"].ToString();
                    objProspectDetails.Address.State = drAddressBilling["StateName"].ToString();
                    objProspectDetails.Address.Country = drAddressBilling["CountryName"].ToString();
                    objProspectDetails.Address.Fax = drAddressBilling["Fax"].ToString();
                }
                // Mailing Address
                if (drAddressMailing != null)
                {
                    objProspectDetails.AddressMailing.AddressID = Convert.ToInt32(drAddressMailing["AddressID"]);
                    objProspectDetails.AddressMailing.Address1 = drAddressMailing["Address1"].ToString();
                    objProspectDetails.AddressMailing.Address2 = drAddressMailing["Address2"].ToString();
                    objProspectDetails.AddressMailing.Zip = Convert.ToString(drAddressMailing["ZIPCode"]);
                    objProspectDetails.AddressMailing.City = drAddressMailing["CityName"].ToString();
                    objProspectDetails.AddressMailing.State = drAddressMailing["StateName"].ToString();
                    objProspectDetails.AddressMailing.Country = drAddressMailing["CountryName"].ToString();
                    objProspectDetails.AddressMailing.Fax = drAddressMailing["Fax"].ToString();
                }


                if (tempdataset.Tables.Count >= 3 && tempdataset.Tables[2] != null)
                {
                    if (tempdataset.Tables[2].Select("ProspectID=" + prospectId).Length > 0)
                    {
                        objProspectDetails.Contact = new List<EContact>();
                        for (int icount = 0; icount < tempdataset.Tables[2].Select("ProspectID=" + prospectId).Length; icount++)
                        {
                            DataRow drContact = tempdataset.Tables[2].Select("ProspectID=" + prospectId)[icount];
                            EContact objContact = new EContact();
                            EContactNotes objEContactNotes = new EContactNotes();

                            objContact.ContactID = Convert.ToInt32(drContact["ContactID"]);
                            objContact.Title = drContact["Salutation"].ToString();
                            objContact.FirstName = drContact["FirstName"].ToString();
                            objContact.MiddleName = drContact["MiddleName"].ToString();
                            objContact.LastName = drContact["LastName"].ToString();
                            objContact.EMail = drContact["EMail"].ToString();
                            objContact.PhoneHome = drContact["PhoneHome"].ToString();
                            objContact.PhoneOffice = drContact["PhoneOffice"].ToString();
                            objContact.PhoneCell = drContact["PhoneCell"].ToString();
                            objContact.Phone1Extension = drContact["PhoneOfficeExtension"].ToString();
                            objContact.Fax = drContact["Fax"].ToString();
                            objContact.EmailWork = drContact["EMailOffice"].ToString();
                            objContact.DesignationTitle = drContact["Title"].ToString();
                            objContact.Gender = Convert.ToBoolean(drContact["Gender"]);

                            objContact.Address = new EAddress();
                            objContact.Address.Address1 = drContact["Address1"].ToString();
                            objContact.Address.Address2 = drContact["Address2"].ToString();
                            objContact.Address.City = drContact["City"].ToString();
                            objContact.Address.State = drContact["State"].ToString();
                            objContact.Address.Zip = drContact["ZipCode"].ToString();

                            if (tempdataset.Tables[3].Rows.Count > 0)
                            {
                                tempdataset.Tables[3].DefaultView.RowFilter = "ContactID = " + objContact.ContactID.ToString();
                                if (tempdataset.Tables[3].DefaultView.Count > 0)
                                {
                                    objContact.ListProspectContactRole = new List<EProspectContactRole>();
                                    foreach (DataRowView drv in tempdataset.Tables[3].DefaultView)
                                    {
                                        EProspectContactRole objproscontrole = new EProspectContactRole();
                                        objproscontrole.ProspectContactRoleID = Convert.ToInt16(drv["ProspectContactRoleID"]);
                                        objproscontrole.ProspectContactRoleName = drv["ProspectContactRoleName"].ToString();
                                        objContact.ListProspectContactRole.Add(objproscontrole);
                                    }
                                }
                            }

                            // Add contact notes
                            objEContactNotes.ContactID = Convert.ToInt32(drContact["ContactID"]);
                            objEContactNotes.Notes = drContact["Notes"].ToString();
                            objContact.ContactNotes = new List<EContactNotes>();
                            objContact.ContactNotes.Add(objEContactNotes);

                            objProspectDetails.Contact.Add(objContact);
                        }
                    }
                }
                returnProspectDetails.Add(objProspectDetails);
            }

            return returnProspectDetails;
        }

        /// <summary>
        /// Retrieves the details for prospect according to filter criteria applied
        /// </summary>
        /// <param name="prospectName">Organisation Name</param>
        /// <param name="startDate">from created date</param>
        /// <param name="endDate">to created date</param>
        /// <param name="salesPersonId">sales person id for which prospect have to be retrieved</param>
        /// <param name="statusId">status id</param>
        /// <param name="typeId">prospect type id</param>
        /// <returns></returns>
        public List<EProspect> GetProspectsDetail(string prospectName, string startDate, string endDate, Int64 franchiseeID, int statusId,
            int typeId, int mode, string zipcode, int distance, int IsHost, int IsFeeder, Int64 userIdSalesRepId, int TerritoryID, string strSortColumn, string strSortOrder, int PageSize, int PageNo, out Int64 TotalRecord, int iWillPromote, int iWillHost, int iHostedInPast, long assignedTo, string role, long prospectTypeId)
        {

            TotalRecord = 0;
            if (prospectName == null)
                prospectName = "";

            if (startDate == null)
                startDate = "";

            if (endDate == null)
                endDate = "";

            SqlParameter[] arParms = new SqlParameter[23];
            //SqlParameter[] arParms = new SqlParameter[22];

            arParms[0] = new SqlParameter("@ProspectName", SqlDbType.VarChar, 500);
            arParms[0].Value = prospectName;

            arParms[1] = new SqlParameter("@StartDate", SqlDbType.VarChar, 100);
            arParms[1].Value = startDate;

            arParms[2] = new SqlParameter("@EndDate", SqlDbType.VarChar, 100);
            arParms[2].Value = endDate;

            arParms[3] = new SqlParameter("@franchiseeID", SqlDbType.BigInt);
            arParms[3].Value = franchiseeID;

            arParms[4] = new SqlParameter("@StatusId", SqlDbType.Int);
            arParms[4].Value = statusId;

            arParms[5] = new SqlParameter("@TypeId", SqlDbType.Int);
            arParms[5].Value = typeId;

            arParms[6] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[6].Value = mode;

            arParms[7] = new SqlParameter("@zipcode", SqlDbType.VarChar);
            arParms[7].Value = zipcode;

            arParms[8] = new SqlParameter("@distance", SqlDbType.Int);
            arParms[8].Value = distance;

            arParms[9] = new SqlParameter("@IsHost", SqlDbType.Int);
            arParms[9].Value = IsHost;

            arParms[10] = new SqlParameter("@AssignedStatus", SqlDbType.Int);
            arParms[10].Value = IsFeeder;

            arParms[11] = new SqlParameter("@UserID", SqlDbType.BigInt);
            arParms[11].Value = userIdSalesRepId;

            arParms[12] = new SqlParameter("@TerritoryID", SqlDbType.Int);
            arParms[12].Value = TerritoryID;

            arParms[13] = new SqlParameter("@SortColumn", SqlDbType.VarChar, 255);
            arParms[13].Value = strSortColumn;

            arParms[14] = new SqlParameter("@SortOrder", SqlDbType.VarChar, 10);
            arParms[14].Value = strSortOrder;

            arParms[15] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParms[15].Value = PageSize;

            arParms[16] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParms[16].Value = PageNo;

            arParms[17] = new SqlParameter("@WillPromote", SqlDbType.Int);
            arParms[17].Value = iWillPromote;

            arParms[18] = new SqlParameter("@WillHost", SqlDbType.Int);
            arParms[18].Value = iWillHost;

            arParms[19] = new SqlParameter("@HostedInPast", SqlDbType.Int);
            arParms[19].Value = iHostedInPast;

            arParms[20] = new SqlParameter("@assignedTo", SqlDbType.BigInt);
            arParms[20].Value = assignedTo;

            arParms[21] = new SqlParameter("@role", SqlDbType.VarChar, 255);
            arParms[21].Value = role;

            arParms[22] = new SqlParameter("@prospectTypeId", SqlDbType.BigInt);
            arParms[22].Value = prospectTypeId;


            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getprospectsdetail", arParms);

            List<EProspect> returnProspectDetails = new List<EProspect>();

            returnProspectDetails = ParsedProspectDetails(tempdataset, mode);

            // Get Total Record
            if (tempdataset.Tables.Count > 1)
            {
                TotalRecord = Convert.ToInt64(tempdataset.Tables[1].Rows[0]["TotalRecord"]);
            }

            return returnProspectDetails;
        }

        public List<EProspect> GetProspectsDetailByProspectListID(Int64 ProspectListID, int mode, out Int64 TotalRecord, int pageSize, int pageIndex, string sortColumn, string sortOrder, long assignedTo)
        {
            TotalRecord = 0;

            SqlParameter[] arParms = new SqlParameter[7];

            arParms[0] = new SqlParameter("@ProspectListID", SqlDbType.BigInt);
            arParms[0].Value = ProspectListID;

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;

            arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParms[2].Value = pageSize;

            arParms[3] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParms[3].Value = pageIndex;

            arParms[4] = new SqlParameter("@SortColumn", SqlDbType.VarChar, 255);
            arParms[4].Value = sortColumn;

            arParms[5] = new SqlParameter("@SortOrder", SqlDbType.VarChar, 10);
            arParms[5].Value = sortOrder;

            arParms[6] = new SqlParameter("@assignedTo ", SqlDbType.BigInt);
            arParms[6].Value = assignedTo;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getprospectsdetailByProspectlistID", arParms);

            List<EProspect> returnProspectDetails = new List<EProspect>();

            returnProspectDetails = ParsedProspectDetails(tempdataset, mode);

            // Get Total Record
            if (tempdataset.Tables.Count > 1)
            {
                TotalRecord = Convert.ToInt64(tempdataset.Tables[1].Rows[0]["TotalRecord"]);
            }
            return returnProspectDetails;
        }
        /// <summary>
        /// Parsed Prospect Details
        /// </summary>
        /// <param name="tempdataset"></param>
        /// <param name="mode"></param>
        /// <returns></returns>

        private List<EProspect> ParsedProspectDetails(DataSet tempdataset, int mode)
        {
            List<EProspect> returnProspectDetails = new List<EProspect>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                //For Prospect details
                EProspect objProspectDetails = new EProspect();
                if (dr["ProspectId"] != DBNull.Value)
                    objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectId"]);

                if (dr["SalesRepID"] != DBNull.Value)
                    objProspectDetails.SalesRepID = Convert.ToInt32(dr["SalesRepID"]);
                else objProspectDetails.SalesRepID = 0;

                objProspectDetails.OrganizationName = Convert.ToString(dr["ProspectName"]);
                objProspectDetails.ProspectDate = Convert.ToString(dr["ProspectCreatedDate"]);

                if (dr["AssignedStatus"] != DBNull.Value)
                    objProspectDetails.AssignedStatus = Convert.ToInt16(dr["AssignedStatus"]);
                else objProspectDetails.AssignedStatus = 0;

                if (dr["PhoneOffice"] != DBNull.Value)
                    objProspectDetails.PhoneOffice = Convert.ToString(dr["PhoneOffice"]);

                objProspectDetails.Status = Convert.ToString(dr["ProspectStatus"]);
                if (dr["NoOFCalls"] != DBNull.Value)
                    objProspectDetails.NoOfCalls = Convert.ToInt32(dr["NoOFCalls"]);
                if (dr["NoOFMeeting"] != DBNull.Value)
                    objProspectDetails.NoOfMeetings = Convert.ToInt32(dr["NoOFMeeting"]);
                if (dr["NoOfContacts"] != DBNull.Value)
                    objProspectDetails.NoOfContacts = Convert.ToInt32(dr["NoOfContacts"]);

                if (dr["SalesPersonFirstName"] != DBNull.Value)
                    objProspectDetails.FirstName = Convert.ToString(dr["SalesPersonFirstName"]);
                if (dr["SalesPersonLastName"] != DBNull.Value)
                    objProspectDetails.LastName = Convert.ToString(dr["SalesPersonLastName"]);
                if (dr["FranchiseeName"] != DBNull.Value)
                    objProspectDetails.FranchiseeName = Convert.ToString(dr["FranchiseeName"]);

                //For address details of prospect
                EAddress objAddress = new EAddress();
                objAddress.AddressID = Convert.ToInt32(dr["ProspectAddressId"]);
                objAddress.Address1 = Convert.ToString(dr["ProspectAddress1"]);
                objAddress.Address2 = Convert.ToString(dr["ProspectAddress2"]);
                objAddress.City = Convert.ToString(dr["ProspectCity"]);
                objAddress.State = Convert.ToString(dr["ProspectState"]);
                objAddress.Zip = Convert.ToString(dr["ProspectZip"]);
                objAddress.Country = Convert.ToString(dr["ProspectCountry"]);

                //For primary details of a prospect 
                EContact objContact = new EContact();
                objContact.FirstName = Convert.ToString(dr["ContactFirstName"]);
                objContact.LastName = Convert.ToString(dr["ContactLastName"]);
                objContact.PhoneHome = Convert.ToString(dr["ContactPhone"]);
                objContact.EMail = Convert.ToString(dr["ContactEmail"]);

                //Get details of last call for a prospect
                EContactCall objContactCall = new EContactCall();
                objContactCall.StartDate = Convert.ToString(dr["ContactCallDate"]);

                //Get status of last call for a prospect
                ECallStatus objCallStatus = new ECallStatus();
                objCallStatus.Status = Convert.ToString(dr["ContactCallStatus"]);
                objCallStatus.Duration = Convert.ToString(dr["Duration"]);
                objCallStatus.Notes = Convert.ToString(dr["Notes"]);

                objContactCall.CallStatus = objCallStatus;
                List<EContact> lstContact = new List<EContact>();
                lstContact.Add(objContact);
                objProspectDetails.Contact = lstContact;
                objProspectDetails.ContactCall = objContactCall;
                objProspectDetails.Address = objAddress;

                returnProspectDetails.Add(objProspectDetails);
            }
            return returnProspectDetails;
        }



        /// <summary>
        /// To Save values in TblProspectUserAccessDetails table
        /// </summary>
        /// <param name="prospectId"></param>
        /// <param name="franchisorUserId"></param>
        /// <param name="mode"></param>
        /// <param name="userID"></param>
        /// <param name="shell"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public Int64 SaveProspectUserAccessDetail(Int32 prospectId, Int32 franchisorUserId, int mode, SqlTransaction transaction)
        {
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt); arParms[0].Value = prospectId;
            arParms[1] = new SqlParameter("@franchisoruserid", SqlDbType.BigInt); arParms[1].Value = franchisorUserId;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt); arParms[2].Direction = ParameterDirection.Output;

            if (transaction == null)
                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveprospectuseraccessdetail", arParms);
            else
                SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "usp_saveprospectuseraccessdetail", arParms);

            return (Int64)arParms[2].Value;
        }

        public List<EProspect> GetUserProspect(string name, int userid, int roleid, int shellid, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userid;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[1].Value = roleid;
            arParms[2] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[2].Value = shellid;
            arParms[3] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            arParms[3].Value = name;
            arParms[4] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[4].Value = mode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getuserprospect", arParms);

            List<EProspect> returnProspectDetails = new List<EProspect>();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EProspect objProspectDetails = new EProspect();
                objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectID"]);
                objProspectDetails.EMailID = dr["EmailID"].ToString();
                objProspectDetails.PhoneOffice = dr["PhoneOffice"].ToString();
                objProspectDetails.PhoneCell = dr["PhoneCell"].ToString();
                objProspectDetails.PhoneOther = dr["PhoneOther"].ToString();
                objProspectDetails.WebSite = dr["WebSite"].ToString();
                objProspectDetails.OrganizationName = dr["OrganizationName"].ToString();

                objProspectDetails.Address = new EAddress();

                objProspectDetails.Address.AddressID = Convert.ToInt32(dr["ProspectAddressID"]);
                objProspectDetails.Address.Address1 = dr["Address1"].ToString();
                objProspectDetails.Address.ZipID = Convert.ToInt32(dr["Zip"]);
                objProspectDetails.Address.City = dr["City"].ToString();
                objProspectDetails.Address.State = dr["State"].ToString();
                objProspectDetails.Address.Country = dr["Country"].ToString();



                returnProspectDetails.Add(objProspectDetails);
            }
            return returnProspectDetails;
        }



        public List<EProspect> GetUserHost(string name, int userid, int roleid, int shellid, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt);
            arParms[0].Value = userid;
            arParms[1] = new SqlParameter("@roleid", SqlDbType.BigInt);
            arParms[1].Value = roleid;
            arParms[2] = new SqlParameter("@shellid", SqlDbType.BigInt);
            arParms[2].Value = shellid;
            arParms[3] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            arParms[3].Value = name;
            arParms[4] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[4].Value = mode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getuserprospect", arParms);

            List<EProspect> returnProspectDetails = new List<EProspect>();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EProspect objProspectDetails = new EProspect();
                objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectID"]);
                objProspectDetails.EMailID = dr["EmailID"].ToString();
                objProspectDetails.PhoneOffice = dr["PhoneOffice"].ToString();
                objProspectDetails.PhoneCell = dr["PhoneCell"].ToString();
                objProspectDetails.PhoneOther = dr["PhoneOther"].ToString();
                objProspectDetails.WebSite = dr["WebSite"].ToString();
                objProspectDetails.OrganizationName = dr["OrganizationName"].ToString();

                objProspectDetails.Address = new EAddress();

                string addressId = dr["AddressID"].ToString();

                if (dr["AddressID"] != DBNull.Value) // address should be present with valid address id
                {
                    //DataRow drAddress = tempdataset.Tables[].Select("AddressID=" + addressId)[0];
                    objProspectDetails.Address.AddressID = Convert.ToInt32(dr["AddressID"]);
                    objProspectDetails.Address.Address1 = dr["Address1"].ToString();
                    objProspectDetails.Address.Address2 = dr["Address2"].ToString();
                    objProspectDetails.Address.ZipID = Convert.ToInt32(dr["ZipCode"]);
                    objProspectDetails.Address.City = dr["City"].ToString();
                    objProspectDetails.Address.State = dr["State"].ToString();
                    objProspectDetails.Address.Country = dr["Country"].ToString();


                }
                returnProspectDetails.Add(objProspectDetails);
            }
            return returnProspectDetails;
        }

        public List<EContact> GetContacts(int prospectid, string filterstring, int mode, int pagenumber, Int16 pagesize, out int iTotalRecordCount)
        {
            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[0].Value = prospectid;
            arParms[1] = new SqlParameter("@filterstring", SqlDbType.VarChar, 500);
            arParms[1].Value = filterstring;
            arParms[2] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[2].Value = mode;
            arParms[3] = new SqlParameter("@pagenumber", SqlDbType.Int);
            arParms[3].Value = pagenumber;
            arParms[4] = new SqlParameter("@pagesize", SqlDbType.TinyInt);
            arParms[4].Value = pagesize;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getprospectcontacts", arParms);

            iTotalRecordCount = 0;
            if (tempdataset != null && tempdataset.Tables[1].Rows.Count > 0)
                iTotalRecordCount = Convert.ToInt32(tempdataset.Tables[1].Rows[0][0]);

            List<EContact> returnContactDetails = new List<EContact>();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EContact objContactDetails = new EContact();
                objContactDetails.ContactID = Convert.ToInt32(dr["ContactID"]);
                objContactDetails.EMail = dr["EMail"].ToString();
                objContactDetails.FirstName = dr["FirstName"].ToString();
                objContactDetails.LastName = dr["LastName"].ToString();
                objContactDetails.PhoneOffice = dr["PhoneOffice"].ToString();
                objContactDetails.PhoneHome = dr["PhoneHome"].ToString();
                objContactDetails.PhoneCell = dr["PhoneCell"].ToString();
                objContactDetails.Fax = dr["Fax"].ToString();
                objContactDetails.EmailWork = dr["EmailOffice"].ToString();

                if (dr["ContactType"] != DBNull.Value && dr["ContactType"] != null)
                {
                    if (dr["ContactType"].ToString().Trim().Length > 0)
                    {
                        objContactDetails.ContactType = Convert.ToInt32(dr["ContactType"]);
                    }
                    else objContactDetails.ContactType = 0;
                }
                else
                {
                    objContactDetails.ContactType = 0;
                }

                objContactDetails.Address = new EAddress();

                objContactDetails.Address.Address1 = dr["Address1"].ToString();
                if (dr["ZipCode"] != DBNull.Value)
                {
                    objContactDetails.Address.Zip = dr["ZipCode"].ToString();
                }
                else
                {
                    objContactDetails.Address.Zip = "-N/A-";
                }
                objContactDetails.Address.City = dr["City"].ToString();
                objContactDetails.Address.State = dr["State"].ToString();
                objContactDetails.Address.Country = dr["Country"].ToString();

                returnContactDetails.Add(objContactDetails);
            }
            return returnContactDetails;
        }

        public Int64 ConvertProspectToHost(int UserID, int ProspectID)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@userid", SqlDbType.BigInt); arParms[0].Value = UserID;
            arParms[1] = new SqlParameter("@prospectid", SqlDbType.VarChar, 100); arParms[1].Value = ProspectID;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt); arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_convertprospecttohost", arParms);
            returnvalue = (Int64)arParms[2].Value;
            return returnvalue;

        }

        public Int64 RemoveContact(Int32 contactid, int mode)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@contactid", SqlDbType.BigInt); arParms[0].Value = contactid;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt); arParms[1].Value = mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt); arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removecontact", arParms);
            returnvalue = (Int64)arParms[2].Value;
            return returnvalue;
        }

        public List<EProspect> GetFaliureProspect(string filterstring, int inputmode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterstring", SqlDbType.VarChar, 100);
            arParms[0].Value = filterstring;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputmode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getfaliureprospect", arParms);

            List<EProspect> returnProspectDetails = new List<EProspect>();
            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EProspect objProspectDetails = new EProspect();
                objProspectDetails.ProspectDetails = new EProspectDetails();
                objProspectDetails.ProspectDetails.ProspectListID = Convert.ToInt32(dr["ProspectFileID"]);
                objProspectDetails.ProspectDetails.FileName = dr["FileName"].ToString();
                objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectID"]);
                objProspectDetails.EMailID = dr["Email"].ToString();
                objProspectDetails.FirstName = dr["FirstName"].ToString();
                objProspectDetails.LastName = dr["LastName"].ToString();
                objProspectDetails.Notes = dr["Notes"].ToString();
                objProspectDetails.PhoneOffice = dr["PhoneOffice"].ToString();
                objProspectDetails.PhoneCell = dr["PhoneCell"].ToString();
                objProspectDetails.WebSite = dr["WebSite"].ToString();
                objProspectDetails.OrganizationName = dr["Organisation"].ToString();

                objProspectDetails.Address = new EAddress();

                objProspectDetails.Address.Address1 = dr["Address1"].ToString();
                objProspectDetails.Address.ZipID = Convert.ToInt32(dr["ZipCode"]);
                objProspectDetails.Address.City = dr["City"].ToString();
                objProspectDetails.Address.StateID = Convert.ToInt32(dr["StateID"]);
                objProspectDetails.Address.CountryID = Convert.ToInt32(dr["CountryID"]);

                returnProspectDetails.Add(objProspectDetails);
            }
            return returnProspectDetails;
        }

        public Int64 SaveProspectType(EProspectType hosttype, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@prospecttypeid", SqlDbType.BigInt);
            arParms[0].Value = hosttype.ProspectTypeID;
            arParms[1] = new SqlParameter("@prospecttypename", SqlDbType.VarChar, 500);
            arParms[1].Value = hosttype.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = hosttype.Description;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = Mode;


            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveprospecttype", arParms);
            return (Int64)arParms[4].Value;
        }

        public Int64 SaveProspectType(String hosttypeID, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@prospecttypeid", SqlDbType.VarChar, 3000);
            arParms[0].Value = hosttypeID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removeprospecttype", arParms);
            return (Int64)arParms[2].Value;
        }

        public Int64 SaveCall(EContactCall call, int Mode)
        {

            SqlParameter[] arParms = new SqlParameter[22];

            arParms[0] = new SqlParameter("@contactcallid", SqlDbType.BigInt);
            arParms[0].Value = call.ContactCallID;
            arParms[1] = new SqlParameter("@contactid", SqlDbType.BigInt);
            if (call.Contact.ContactID == 0)
                arParms[1].Value = DBNull.Value;
            else
                arParms[1].Value = call.Contact.ContactID;

            arParms[2] = new SqlParameter("@callsubject", SqlDbType.VarChar, 1500);
            arParms[2].Value = call.Subject;
            arParms[3] = new SqlParameter("@notes", SqlDbType.VarChar, 5000);
            arParms[3].Value = call.Notes;

            arParms[4] = new SqlParameter("@startdate", SqlDbType.VarChar, 500);
            if (!string.IsNullOrEmpty(call.StartDate))
                arParms[4].Value = call.StartDate;
            else arParms[4].Value = DBNull.Value;

            arParms[5] = new SqlParameter("@starttime", SqlDbType.VarChar, 500);
            if (!string.IsNullOrEmpty(call.StartTime))
                arParms[5].Value = call.StartTime;
            else arParms[5].Value = DBNull.Value;

            arParms[6] = new SqlParameter("@contactcallstatusid", SqlDbType.BigInt);
            if (call.CallStatus.CallStatusID > 0)
                arParms[6].Value = call.CallStatus.CallStatusID;
            else
                arParms[6].Value = DBNull.Value;
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

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveContactCall", arParms);

            return (Int64)arParms[18].Value;

        }

        public Int64 SaveMeeting(EContactMeeting Meeting, int Mode)
        {

            SqlParameter[] arParms = new SqlParameter[22];

            arParms[0] = new SqlParameter("@contactmeetingid", SqlDbType.BigInt);
            arParms[0].Value = Meeting.ContactMeetingID;
            arParms[1] = new SqlParameter("@contactid", SqlDbType.BigInt);
            if (Meeting.Contact.ContactID == 0)
                arParms[1].Value = DBNull.Value;
            else
                arParms[1].Value = Meeting.Contact.ContactID;

            arParms[2] = new SqlParameter("@meetingsubject", SqlDbType.VarChar, 1500);
            arParms[2].Value = Meeting.Subject;
            arParms[3] = new SqlParameter("@description", SqlDbType.VarChar, 5000);
            arParms[3].Value = Meeting.Description;

            arParms[4] = new SqlParameter("@startdate", SqlDbType.DateTime);
            if (!string.IsNullOrEmpty(Meeting.StartDate))
                arParms[4].Value = Convert.ToDateTime(Meeting.StartDate);
            else arParms[4].Value = DBNull.Value;

            arParms[5] = new SqlParameter("@starttime", SqlDbType.DateTime);
            if (!string.IsNullOrEmpty(Meeting.StartTime))
                arParms[5].Value = Convert.ToDateTime(Meeting.StartTime);
            else arParms[5].Value = DBNull.Value;

            arParms[6] = new SqlParameter("@contactmeetingstatusid", SqlDbType.BigInt);
            if (Meeting.CallStatus.CallStatusID > 0)
                arParms[6].Value = Meeting.CallStatus.CallStatusID;
            else
                arParms[6].Value = DBNull.Value;
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
                arParms[20].Value = Convert.ToDateTime(Meeting.FollowUpDate);
            else arParms[20].Value = DBNull.Value;

            arParms[21] = new SqlParameter("@MeetingType", SqlDbType.Int);
            arParms[21].Value = Meeting.MeetingType;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveContactMeeting", arParms);

            return (Int64)arParms[18].Value;

        }

        public Int64 SaveTask(ETask task, int Mode, string UserID, string Shell, string Role)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[21];

            arParms[0] = new SqlParameter("@taskid", SqlDbType.BigInt);
            arParms[0].Value = task.TaskID;
            arParms[1] = new SqlParameter("@tasksubject", SqlDbType.VarChar, 500);
            arParms[1].Value = task.Subject;
            arParms[2] = new SqlParameter("@notes", SqlDbType.VarChar, 1000);
            if (task.Notes == null)
                arParms[2].Value = DBNull.Value;
            else
                arParms[2].Value = task.Notes;
            arParms[3] = new SqlParameter("@startdate", SqlDbType.VarChar, 500);
            if (task.StartDate == null)
                arParms[3].Value = DBNull.Value;
            else
                arParms[3].Value = task.StartDate;
            arParms[4] = new SqlParameter("@starttime", SqlDbType.VarChar, 500);
            if (task.StartTime == null)
                arParms[4].Value = DBNull.Value;
            else
                arParms[4].Value = task.StartTime;
            arParms[5] = new SqlParameter("@duedate", SqlDbType.VarChar, 500);
            if (task.DueDate == null)
                arParms[5].Value = DBNull.Value;
            else
                arParms[5].Value = task.DueDate;
            arParms[6] = new SqlParameter("@duetime", SqlDbType.VarChar, 500);
            if (task.DueTime == null)
                arParms[6].Value = DBNull.Value;
            else
                arParms[6].Value = task.DueTime;
            arParms[7] = new SqlParameter("@taskstatusid", SqlDbType.BigInt);
            if (task.TaskStatusType.TaskStatusTypeID == 0)
                arParms[7].Value = DBNull.Value;
            else
                arParms[7].Value = task.TaskStatusType.TaskStatusTypeID;

            arParms[8] = new SqlParameter("@taskpriorityid", SqlDbType.BigInt);
            if (task.TaskPriorityType.TaskPriorityTypeID == 0)
                arParms[8].Value = DBNull.Value;
            else
                arParms[8].Value = task.TaskPriorityType.TaskPriorityTypeID;
            arParms[9] = new SqlParameter("@createdby", SqlDbType.BigInt);
            arParms[9].Value = task.CreatedBY;
            arParms[10] = new SqlParameter("@modifiedby", SqlDbType.BigInt);
            arParms[10].Value = task.ModifiedBY;
            arParms[11] = new SqlParameter("@assignedTouserid", SqlDbType.BigInt);
            arParms[11].Value = task.UserShellModule.UserID;
            arParms[12] = new SqlParameter("@assignedToshellid", SqlDbType.BigInt);
            arParms[12].Value = task.UserShellModule.ShellID;
            arParms[13] = new SqlParameter("@assignedToroleid", SqlDbType.BigInt);
            arParms[13].Value = task.UserShellModule.RoleID;

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

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savetaskdetails", arParms);

            returnvalue = (Int64)arParms[18].Value;
            return returnvalue;
        }
        /// <summary>
        /// mode "0->All rows,1->Rows by ProspectListID,3->All inactive rows",name,dbid
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public EProspectAll ProspectHostDetailsAll(Int64 iProspectID, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[0].Value = iProspectID;

            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = Mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getProspectHostDetailsAll", arParms);

            EProspectAll objEProspectAll = new EProspectAll();
            EProspect objEProspect = new EProspect();

            // Assign Prospects or host
            if (Mode == 1)
            {
                objEProspect = new EProspect();
                objEProspect = ParseProspect(tempdataset);
                objEProspectAll.Prospect = objEProspect;
            }
            else if (Mode == 2)
            {
                objEProspect = new EProspect();
                objEProspect = ParseHost(tempdataset);
                objEProspectAll.Prospect = objEProspect;
            }

            // Assign calls
            if (tempdataset.Tables.Count >= 5)
            {
                DataSet calldataset = new DataSet();
                calldataset.Tables.Add(tempdataset.Tables[4].Copy());
                objEProspectAll.Calls = new List<EContactCall>();
                objEProspectAll.Calls = ParsedCalls(calldataset);
            }
            // Assign task
            if (tempdataset.Tables.Count >= 6)
            {
                DataSet taskdataset = new DataSet();
                taskdataset.Tables.Add(tempdataset.Tables[5].Copy());
                objEProspectAll.Tasks = new List<ETask>();
                objEProspectAll.Tasks = ParseTask(taskdataset);
            }
            // Assign meetings
            if (tempdataset.Tables.Count >= 7)
            {
                DataSet meetingdataset = new DataSet();
                meetingdataset.Tables.Add(tempdataset.Tables[6].Copy());
                objEProspectAll.Meetings = new List<EContactMeeting>();
                objEProspectAll.Meetings = ParseMeeting(meetingdataset);
            }
            // Assign notes
            if (tempdataset.Tables.Count >= 8)
            {
                DataSet notesdataset = new DataSet();
                notesdataset.Tables.Add(tempdataset.Tables[7].Copy());

                objEProspectAll.Notes = new List<ENotesDetails>();
                objEProspectAll.Notes = ParseNotes(notesdataset);
            }
            // Assign call,meeting,task
            if (tempdataset.Tables.Count >= 9)
            {
                DataSet alldataset = new DataSet();
                alldataset.Tables.Add(tempdataset.Tables[8].Copy());

                objEProspectAll.CallMeetingTask = new List<EContactCall>();
                objEProspectAll.CallMeetingTask = ParseCallsMeetingsTasks(alldataset);
            }
            return objEProspectAll;
        }
        private List<EContactCall> ParsedCalls(DataSet tempdataset)
        {
            List<EContactCall> listcall = new List<EContactCall>();
            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    EContactCall objcall = new EContactCall();

                    objcall.UserShellModule = new Entity.User.EUserShellModuleRole();
                    objcall.Contact = new EContact();
                    objcall.CallStatus = new ECallStatus();

                    objcall.ContactCallID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["ContactCallID"]);
                    objcall.Subject = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Subject"]);
                    objcall.Notes = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Notes"]);
                    objcall.Duration = Convert.ToDecimal(tempdataset.Tables[0].Rows[icount]["Duration"]);

                    objcall.StartDate = Convert.ToString(tempdataset.Tables[0].Rows[icount]["StartDate"]);
                    objcall.StartTime = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Starttime"]);
                    objcall.CallStatus.Status = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Status"]);

                    if (tempdataset.Tables[0].Rows[icount]["AssignedToUserId"] != DBNull.Value)
                        objcall.AssignedToUserId =
                            Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["AssignedToUserId"]);

                    objcall.Contact.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["FirstName"]);
                    objcall.Contact.LastName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["LastName"]);

                    objcall.UserShellModule.UserName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Assignedby"]);

                    listcall.Add(objcall);
                }
            }
            return listcall;
        }

        private List<ETask> ParseTask(DataSet tempdataset)
        {

            List<ETask> listtask = new List<ETask>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    ETask objtask = new ETask();
                    objtask.TaskStatusType = new ETaskStatusType();
                    objtask.TaskPriorityType = new ETaskPriorityType();

                    objtask.TaskID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["TaskID"]);
                    objtask.Subject = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Subject"]);
                    if (tempdataset.Tables[0].Rows[icount]["DueDate"] != DBNull.Value && tempdataset.Tables[0].Rows[icount]["DueDate"] != null)
                        objtask.DueDate = Convert.ToString(tempdataset.Tables[0].Rows[icount]["DueDate"]);
                    else objtask.DueDate = "";

                    if (tempdataset.Tables[0].Rows[icount]["StartDate"] != DBNull.Value && tempdataset.Tables[0].Rows[icount]["StartDate"] != null)
                        objtask.StartDate = Convert.ToString(tempdataset.Tables[0].Rows[icount]["StartDate"]);
                    else objtask.StartDate = "";

                    objtask.TaskStatusType.Name = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Status"]);
                    objtask.Contact = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Contact"]);

                    objtask.DueTime = Convert.ToString(tempdataset.Tables[0].Rows[icount]["DueTime"]);

                    objtask.TaskPriorityType.Name = Convert.ToString(tempdataset.Tables[0].Rows[icount]["PriorityTypesName"]);
                    objtask.Notes = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Notes"]);

                    listtask.Add(objtask);
                }
            }
            return listtask;
        }

        private List<EContactMeeting> ParseMeeting(DataSet tempdataset)
        {
            List<EContactMeeting> returnMeeting = new List<EContactMeeting>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    EContactMeeting objmeeting = new EContactMeeting();
                    objmeeting.CallStatus = new ECallStatus();
                    objmeeting.Contact = new EContact();
                    objmeeting.UserShellModule = new Entity.User.EUserShellModuleRole();

                    if (tempdataset.Tables[0].Rows[icount]["ContactMeetingID"] != DBNull.Value)
                        objmeeting.ContactMeetingID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["ContactMeetingID"]);

                    if (tempdataset.Tables[0].Rows[icount]["Subject"] != DBNull.Value)
                        objmeeting.Subject = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Subject"]);

                    if (tempdataset.Tables[0].Rows[icount]["Notes"] != DBNull.Value)
                        objmeeting.Description = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Notes"]);


                    if (tempdataset.Tables[0].Rows[icount]["Duration"] != DBNull.Value)
                        objmeeting.Duration = Convert.ToDecimal(tempdataset.Tables[0].Rows[icount]["Duration"]);

                    if (tempdataset.Tables[0].Rows[icount]["MeetingVenue"] != DBNull.Value)
                        objmeeting.Venue = Convert.ToString(tempdataset.Tables[0].Rows[icount]["MeetingVenue"]);

                    if (tempdataset.Tables[0].Rows[icount]["StartDate"] != DBNull.Value)
                        objmeeting.StartDate = Convert.ToString(tempdataset.Tables[0].Rows[icount]["StartDate"]);

                    if (tempdataset.Tables[0].Rows[icount]["StartTime"] != DBNull.Value)
                        objmeeting.StartTime = Convert.ToString(tempdataset.Tables[0].Rows[icount]["StartTime"]);

                    if (tempdataset.Tables[0].Rows[icount]["Status"] != DBNull.Value)
                        objmeeting.CallStatus.Status = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Status"]);

                    if (tempdataset.Tables[0].Rows[icount]["ContactID"] != DBNull.Value)
                        objmeeting.Contact.ContactID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["ContactID"]);

                    if (tempdataset.Tables[0].Rows[icount]["FirstName"] != DBNull.Value)
                        objmeeting.Contact.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["FirstName"]);

                    if (tempdataset.Tables[0].Rows[icount]["LastName"] != DBNull.Value)
                        objmeeting.Contact.LastName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["LastName"]);

                    if (tempdataset.Tables[0].Rows[icount]["MeetingVenue"] != DBNull.Value)
                        objmeeting.Venue = Convert.ToString(tempdataset.Tables[0].Rows[icount]["MeetingVenue"]);

                    if (tempdataset.Tables[0].Rows[icount]["AssignedBy"] != DBNull.Value)
                        objmeeting.UserShellModule.UserName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["AssignedBy"]);

                    returnMeeting.Add(objmeeting);
                }
            }
            return returnMeeting;
        }

        private List<ENotesDetails> ParseNotes(DataSet tempdataset)
        {
            List<ENotesDetails> returnENotesDetails = new List<ENotesDetails>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {

                ENotesDetails objENotesDetails = new ENotesDetails();

                if (dr["NoteID"] != DBNull.Value)
                    objENotesDetails.NoteID = Convert.ToInt64(dr["NoteID"]);

                if (dr["Notes"] != DBNull.Value)
                    objENotesDetails.Notes = Convert.ToString(dr["Notes"]);

                if (dr["DateCreated"] != DBNull.Value)
                    objENotesDetails.DateCreated = Convert.ToString(dr["DateCreated"]);

                if (dr["DateModified"] != DBNull.Value)
                    objENotesDetails.DateModified = Convert.ToString(dr["DateModified"]);

                returnENotesDetails.Add(objENotesDetails);
            }

            return returnENotesDetails;
        }

        private List<EContactCall> ParseCallsMeetingsTasks(DataSet tempdataset)
        {
            List<EContactCall> listcall = new List<EContactCall>();

            if (tempdataset.Tables[0].Rows.Count > 0)
            {
                for (int icount = 0; icount < tempdataset.Tables[0].Rows.Count; icount++)
                {
                    EContactCall objcall = new EContactCall();

                    objcall.UserShellModule = new Entity.User.EUserShellModuleRole();
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
                        objcall.Contact.ContactID = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["ContactID"]);

                    if (tempdataset.Tables[0].Rows[icount]["ContactName"] != DBNull.Value)
                        objcall.Contact.FirstName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["ContactName"]);
                    else objcall.Contact.FirstName = "";

                    if (tempdataset.Tables[0].Rows[icount]["AssignedToUserId"] != DBNull.Value)
                        objcall.AssignedToUserId = Convert.ToInt32(tempdataset.Tables[0].Rows[icount]["AssignedToUserId"]);
                    else objcall.AssignedToUserId = 0;

                    if (tempdataset.Tables[0].Rows[icount]["Assignedby"] != DBNull.Value)
                        objcall.UserShellModule.UserName = Convert.ToString(tempdataset.Tables[0].Rows[icount]["Assignedby"]);
                    else objcall.UserShellModule.UserName = "";

                    objcall.StartTime = Convert.ToString(tempdataset.Tables[0].Rows[icount]["DateModified"]);

                    listcall.Add(objcall);
                }
            }

            return listcall;

        }

        /// <summary>
        /// mode "0->All rows,1->Rows by ProspectListID,3->All inactive rows",name,dbid
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="inputMode"></param>
        /// <returns></returns>
        public List<EProspectType> GetProspectType(string filterstring, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterstring;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getprospecttype", arParms);

            List<EProspectType> returnProspectType = new List<EProspectType>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                EProspectType objProspectDetails = new EProspectType();
                objProspectDetails.Active = Convert.ToBoolean(dr["IsActive"]);
                objProspectDetails.Description = dr["Description"].ToString();
                objProspectDetails.Name = dr["Name"].ToString();
                objProspectDetails.ProspectTypeID = Convert.ToInt32(dr["ProspectTypeID"]);

                returnProspectType.Add(objProspectDetails);

            }

            return returnProspectType;
        }

        /// <summary>
        /// Save Prospect Address
        /// </summary>
        /// <param name="objEAddress"></param>
        /// <param name="iProspectID"></param>
        public void SaveProspectAddress(EAddress objEAddress, Int64 iProspectID)
        {
            SqlParameter[] arParms = new SqlParameter[10];

            arParms[0] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[0].Value = iProspectID;

            arParms[1] = new SqlParameter("@prospectaddressid", SqlDbType.BigInt);
            arParms[1].Value = objEAddress.AddressID;

            arParms[2] = new SqlParameter("@address1", SqlDbType.VarChar, 500);
            arParms[2].Value = CheckNull(objEAddress.Address1);

            arParms[3] = new SqlParameter("@address2", SqlDbType.VarChar, 500);
            arParms[3].Value = CheckNull(objEAddress.Address2);

            arParms[4] = new SqlParameter("@fax", SqlDbType.VarChar, 100);
            arParms[4].Value = CheckNull(objEAddress.Fax);

            arParms[5] = new SqlParameter("@city", SqlDbType.VarChar, 100);
            arParms[5].Value = CheckNull(objEAddress.City);

            arParms[6] = new SqlParameter("@state", SqlDbType.VarChar, 100);
            arParms[6].Value = CheckNull(objEAddress.State);

            arParms[7] = new SqlParameter("@country", SqlDbType.VarChar, 100);
            arParms[7].Value = CheckNull(objEAddress.Country);

            arParms[8] = new SqlParameter("@zipcode", SqlDbType.VarChar, 10);
            arParms[8].Value = objEAddress.Zip;

            arParms[9] = new SqlParameter("@IsMailing", SqlDbType.Bit);
            arParms[9].Value = objEAddress.IsMailing;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveprospectAddress", arParms);


        }

        public void SaveProspectDetails(EProspectDetails objEProspectDetails, Int64 iProspectID)
        {
            SqlParameter[] arParms = new SqlParameter[13];

            arParms[0] = new SqlParameter("@prospectdetailsid", SqlDbType.BigInt);
            arParms[0].Value = objEProspectDetails.ProspectDetailID;

            arParms[1] = new SqlParameter("@prospectid", SqlDbType.BigInt);
            arParms[1].Value = iProspectID;

            arParms[2] = new SqlParameter("@FacilitiesFee", SqlDbType.VarChar, 50);
            arParms[2].Value = objEProspectDetails.FacilitiesFee;

            arParms[3] = new SqlParameter("@PaymentMethod", SqlDbType.VarChar, 50);
            arParms[3].Value = objEProspectDetails.PaymentMethod;

            arParms[4] = new SqlParameter("@DepositsRequire", SqlDbType.Int);
            arParms[4].Value = objEProspectDetails.DepositsRequire;

            arParms[5] = new SqlParameter("@DepositsAmount", SqlDbType.Decimal);
            arParms[5].Value = objEProspectDetails.DepositsAmount;

            arParms[6] = new SqlParameter("@ViableHostSite", SqlDbType.Int);
            arParms[6].Value = objEProspectDetails.ViableHostSite;

            arParms[7] = new SqlParameter("@HostedInPast", SqlDbType.Int);
            arParms[7].Value = objEProspectDetails.HostedInPast;

            arParms[8] = new SqlParameter("@HostedInPastWith", SqlDbType.VarChar, 50);
            arParms[8].Value = objEProspectDetails.HostedInPastWith;

            arParms[9] = new SqlParameter("@WillHost", SqlDbType.Int);
            arParms[9].Value = objEProspectDetails.WillHost;

            arParms[10] = new SqlParameter("@ReasonViableHostSite", SqlDbType.Text);
            if (objEProspectDetails.ReasonViableHostSite != null)
            {
                arParms[10].Value = objEProspectDetails.ReasonViableHostSite;
            }
            else
            {
                arParms[10].Value = "";
            }

            arParms[11] = new SqlParameter("@ReasonHostedInPast", SqlDbType.Text);
            if (objEProspectDetails.ReasonHostedInPast != null)
            {
                arParms[11].Value = objEProspectDetails.ReasonHostedInPast;
            }
            else
            {
                arParms[11].Value = "";
            }

            arParms[12] = new SqlParameter("@ReasonWillHost", SqlDbType.Text);
            if (objEProspectDetails.ReasonWillHost != null)
            {
                arParms[12].Value = objEProspectDetails.ReasonWillHost;
            }
            else
            {
                arParms[12].Value = "";
            }


            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_saveprospectDetails", arParms);


        }

        public bool SaveProspectNotes(string notes, int prospectid)
        {
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@notes", SqlDbType.VarChar, 5000);
            arParms[0].Value = notes;

            arParms[1] = new SqlParameter("prospectid", SqlDbType.Int);
            arParms[1].Value = prospectid;

            arParms[2] = new SqlParameter("IsSaved", SqlDbType.Bit);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_UpdateProspectNotes", arParms);
            bool result = new bool();
            result = Convert.ToBoolean(arParms[2].Value);
            return result;
        }
        #endregion

        #region "ManageNotificationService"

        public void CleanUpNotificationAfterInboundCall(long prospectCustomerId)
        {
            SqlParameter param = new SqlParameter("@prospectCustomerId", SqlDbType.BigInt);
            param.Value = prospectCustomerId;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_CleanUpNotificationAfterInboundCall", param);
        }

        public long GetNotificationPhoneIdforMappingOutboundCall(long prospectCustomerId)
        {
            string findNotificationQuery = "SELECT max( TblNotificationPhone.PhoneNotificationId) from TblProspectCustomerNotification " +
                    " inner join TblNotificationPhone on TblProspectCustomerNotification.NotificationId = TblNotificationPhone.PhoneNotificationId " +
                    " where isnull(TblNotificationPhone.ServicedBy, 0) = 0 and TblProspectCustomerNotification.ProspectCustomerId = @prospectCustomerId";

            var arparam = new SqlParameter("@prospectCustomerId", SqlDbType.BigInt);
            arparam.Value = prospectCustomerId;

            var notificationPhoneId = SqlHelper.ExecuteScalar(connectionstring, CommandType.Text, findNotificationQuery, arparam);

            if (notificationPhoneId != null && notificationPhoneId != DBNull.Value)
                return Convert.ToInt64(notificationPhoneId);

            return 0;
        }

        // TODO: To be moved into Infrastructure when Notification Module is created.
        public long GetNotificationIdfromNotificationPhoneId(long notificationPhoneId)
        {
            string sqlQuery = "Select NotificationId from TblNotificationPhone where NotificationPhoneId = @notificationPhoneId";

            var arparam = new SqlParameter("@notificationPhoneId", SqlDbType.BigInt);
            arparam.Value = notificationPhoneId;

            var returnValue = SqlHelper.ExecuteScalar(connectionstring, CommandType.Text, sqlQuery, arparam);

            if (returnValue != null && returnValue != DBNull.Value)
                return Convert.ToInt64(returnValue);

            return 0;
        }

        //TODO: To be moved into Infrastructure whene Notification Module is created.
        public bool CreateNotificationforRequeingProspectCustomer(DateTime notificationDate, long prospectCustomerId)
        {
            int returnResult = 0;
            string sqlQuery = "Update TblProspectCustomer set IsQueuedForCallBack = 0 where ProspectCustomerId = @prospectCustomerId";

            var arparam = new SqlParameter("@prospectCustomerId", SqlDbType.BigInt);
            arparam.Value = prospectCustomerId;

            var connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlTransaction sqlTransaction = connection.BeginTransaction();


            returnResult = SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, sqlQuery, arparam);
            if (returnResult == 0)
            {
                sqlTransaction.Rollback(); return false;
            }

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@notificationDate", SqlDbType.DateTime);
            arParams[1] = new SqlParameter("@prospectCustId", SqlDbType.BigInt);

            arParams[0].Value = notificationDate;
            arParams[1].Value = prospectCustomerId;

            SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.StoredProcedure, "usp_ProspectCustomerOutBoundNotify", arParams);
            sqlTransaction.Commit();

            if (sqlTransaction.Connection != null && sqlTransaction.Connection.State != ConnectionState.Closed) sqlTransaction.Connection.Close();

            return true;
        }

        /// <summary>
        /// Get details about Notification Services Type
        /// </summary>
        /// <param name="ServiceName"></param>
        /// <param name="ServiceStatus"></param>
        /// <returns>List<ENotificationType></returns>
        public List<ENotificationType> GetNotificationType(string ServiceName, int ServiceStatus)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@NotificationtTypeName", SqlDbType.VarChar, 255);
            arParms[0].Value = ServiceName;
            arParms[1] = new SqlParameter("@NotificationtTypeStatus", SqlDbType.TinyInt);
            arParms[1].Value = ServiceStatus;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_NotificationManage", arParms);

            List<ENotificationType> lstENotificationType = new List<ENotificationType>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                ENotificationType objENotificationType = new ENotificationType();
                objENotificationType.NotificationTypeID = Convert.ToInt64(dr["NotificationTypeID"]);
                objENotificationType.NotificationTypeName = Convert.ToString(dr["NotificationTypeName"]);
                objENotificationType.Description = Convert.ToString(dr["Description"]);
                objENotificationType.Total = Convert.ToInt64(dr["Total"]);
                objENotificationType.Serviced = Convert.ToInt64(dr["Serviced"]);
                objENotificationType.NotServiced = Convert.ToInt64(dr["NotServiced"]);
                objENotificationType.ServiceStatus = Convert.ToString(dr["ServiceStatus"]);
                if (dr["LastStatusChangedDate"] != DBNull.Value)
                {
                    objENotificationType.LastStatusChangedDate = Convert.ToString(dr["LastStatusChangedDate"]);
                }
                if (string.IsNullOrEmpty(objENotificationType.LastStatusChangedDate))
                {
                    objENotificationType.LastStatusChangedDate = " -NA- ";
                }
                if (Convert.ToInt16(dr["Status"]) == 0)
                    objENotificationType.IsStarted = false;
                else
                    objENotificationType.IsStarted = true;

                if (Convert.ToInt16(dr["EscalateToPhone"]) == 0)
                    objENotificationType.EscalateToPhone = false;
                else
                    objENotificationType.EscalateToPhone = true;

                objENotificationType.NoOfAttempts = Convert.ToInt32(dr["NoOfAttempts"]);

                // Add notification to list
                lstENotificationType.Add(objENotificationType);

            }

            return lstENotificationType;
        }

        /// <summary>
        /// Get Notification Type
        /// </summary>
        /// <param name="ServiceName"></param>
        /// <param name="ServiceStatus"></param>
        /// <returns>List<ENotificationType></returns>
        public List<ENotificationType> GetNotificationType(int mode)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[0].Value = mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_NotificationGetType", arParms);

            List<ENotificationType> lstENotificationType = new List<ENotificationType>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                ENotificationType objENotificationType = new ENotificationType();
                objENotificationType.NotificationTypeID = Convert.ToInt64(dr["NotificationTypeID"]);
                objENotificationType.NotificationTypeName = Convert.ToString(dr["NotificationTypeName"]);
                // Add notification to list
                lstENotificationType.Add(objENotificationType);

            }

            return lstENotificationType;
        }

        /// <summary>
        /// Change Service Status
        /// </summary>
        /// <param name="NotificationTypeID"></param>        
        public void ChangeServiceStatus(Int64 NotificationTypeID)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@NotificationtTypeID", SqlDbType.BigInt);
            arParms[0].Value = NotificationTypeID;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_NotificationManageChangeStatus", arParms);
        }

        /// <summary>
        /// Get Notification Type 
        /// </summary>
        /// <param name="NotificationTypeID"></param>        
        public ENotificationType GetNotification(Int64 NotificationTypeID)
        {
            ENotificationType objENotificationType = new ENotificationType();
            DataSet tempdataset = new DataSet();
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@NotificationtTypeID", SqlDbType.BigInt);
            arParms[0].Value = NotificationTypeID;

            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_NotificationManageGet", arParms);

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                objENotificationType.NotificationTypeID = Convert.ToInt64(dr["NotificationTypeID"]);
                objENotificationType.NotificationTypeName = Convert.ToString(dr["NotificationTypeName"]);
                objENotificationType.Description = Convert.ToString(dr["Description"]);
                if (Convert.ToInt16(dr["IsStarted"]) == 1)
                    objENotificationType.IsStarted = true;
                else
                    objENotificationType.IsStarted = false;

                if (Convert.ToInt16(dr["EscalateToPhone"]) == 0)
                    objENotificationType.EscalateToPhone = false;
                else
                    objENotificationType.EscalateToPhone = true;

                objENotificationType.NoOfAttempts = Convert.ToInt32(dr["NoOfAttempts"]);
            }
            return objENotificationType;
        }

        /// <summary>
        /// Edit Notification Type 
        /// </summary>
        /// <param name="NotificationTypeID"></param>        
        public void UpdateNotification(ENotificationType objENotificationType, bool isStarted)
        {
            try
            {
                SqlParameter[] arParms = new SqlParameter[6];

                arParms[0] = new SqlParameter("@NotificationTypeId", SqlDbType.BigInt);

                arParms[0].Value = objENotificationType.NotificationTypeID;

                arParms[1] = new SqlParameter("@NotificationTypeName", SqlDbType.VarChar, 255);
                arParms[1].Value = objENotificationType.NotificationTypeName;

                arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar, 1024);
                arParms[2].Value = objENotificationType.Description;

                arParms[3] = new SqlParameter("@IsStarted", SqlDbType.Bit);
                arParms[3].Value = isStarted; //objENotificationType.IsStarted;

                arParms[4] = new SqlParameter("@EscalateToPhone", SqlDbType.Bit);
                arParms[4].Value = objENotificationType.EscalateToPhone;

                arParms[5] = new SqlParameter("@NoOfAttempts", SqlDbType.Int);
                arParms[5].Value = objENotificationType.NoOfAttempts;

                SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_NotificationManageUpdate", arParms);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Get Notification Medium
        /// </summary>
        /// <returns>List<ENotificationMedium></returns>
        public List<ENotificationMedium> GetNotificationMedium()
        {
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_NotificationGetMedium", null);

            List<ENotificationMedium> lstENotificationMedium = new List<ENotificationMedium>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                ENotificationMedium objENotificationMedium = new ENotificationMedium();
                objENotificationMedium.NotificationMediumID = Convert.ToInt32(dr["NotificationMediumID"]);
                objENotificationMedium.NotificationMedium = Convert.ToString(dr["NotificationMedium"]);
                // Add notification to list
                lstENotificationMedium.Add(objENotificationMedium);
            }

            return lstENotificationMedium;
        }

        /// <summary>
        /// Get Notification Type
        /// </summary>        
        /// <returns>List<ENotificationOther></returns>
        public List<ENotificationOther> GetNotificationOther(string Name, Int64 CustomerID,
                                                            string StartDate, string EndDate,
                                                            int NotificationTypeId, int ServiceStatus,
                                                            int NotificationMediumID
                                                            )
        {


            SqlParameter[] arParms = new SqlParameter[7];

            arParms[0] = new SqlParameter("@Name", SqlDbType.VarChar, 255);
            arParms[0].Value = Name;

            arParms[1] = new SqlParameter("@CustomerID", SqlDbType.BigInt);
            arParms[1].Value = CustomerID;

            arParms[2] = new SqlParameter("@StartDate", SqlDbType.VarChar, 20);
            arParms[2].Value = StartDate;

            arParms[3] = new SqlParameter("@EndDate", SqlDbType.VarChar, 20);
            arParms[3].Value = EndDate;

            arParms[4] = new SqlParameter("@NotificationTypeId", SqlDbType.Int);
            arParms[4].Value = NotificationTypeId;

            arParms[5] = new SqlParameter("@ServiceStatus", SqlDbType.Int);
            arParms[5].Value = ServiceStatus;

            arParms[6] = new SqlParameter("@NotificationMediumID", SqlDbType.Int);
            arParms[6].Value = NotificationMediumID;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_NotificationCenterGet", arParms);

            List<ENotificationOther> lstENotificationOther = new List<ENotificationOther>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                ENotificationOther objENotificationOther = new ENotificationOther();
                objENotificationOther.NotificationID = Convert.ToInt64(dr["NotificationID"]);
                objENotificationOther.UserID = Convert.ToInt64(dr["UserID"]);
                objENotificationOther.CustomerID = Convert.ToInt64(dr["CustomerID"]);
                objENotificationOther.CustomerName = Convert.ToString(dr["Name"]);
                objENotificationOther.NotificationType = Convert.ToString(dr["NotificationTypeName"]);
                objENotificationOther.NotificationMedium = Convert.ToString(dr["NotificationMedium"]);
                objENotificationOther.ServiceStatus = Convert.ToString(dr["ServiceStatus"]);
                objENotificationOther.AttemptCount = Convert.ToInt64(dr["AttemptCount"]);
                objENotificationOther.ServicedBy = Convert.ToString(dr["ServicedBy"]);
                objENotificationOther.NotificationDate = Convert.ToString(dr["ServicedDate"]);


                // Add notification to list
                lstENotificationOther.Add(objENotificationOther);

            }

            return lstENotificationOther;
        }
        /// <summary>
        /// ReServiced Notification
        /// </summary>        
        /// <returns>int</returns>

        public Int64 NotificationReServiced(Int64 NotificationID, string ClientLabel,
                                            Int64 RequestedBy, string NotificationMedium,
                                            string EmailSubject, string EmailBody, int mode
                                            )
        {

            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[8];

            arParms[0] = new SqlParameter("@NotificationID", SqlDbType.BigInt);
            arParms[0].Value = NotificationID;

            arParms[1] = new SqlParameter("@ClientLabel", SqlDbType.VarChar, 255);
            arParms[1].Value = ClientLabel;

            arParms[2] = new SqlParameter("@RequestedBy", SqlDbType.BigInt);
            arParms[2].Value = RequestedBy;

            arParms[3] = new SqlParameter("@NotificationMedium", SqlDbType.VarChar, 100);
            arParms[3].Value = NotificationMedium;

            arParms[4] = new SqlParameter("@Emailsubject", SqlDbType.VarChar, 255);
            arParms[4].Value = EmailSubject;

            arParms[5] = new SqlParameter("@EmailBody", SqlDbType.Text);
            arParms[5].Value = EmailBody;

            arParms[6] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[6].Value = mode;

            arParms[7] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_NotificationCenterReServiced", arParms);
            returnvalue = (Int64)arParms[7].Value;
            return returnvalue;
        }

        /// <summary>
        /// Get Notification View
        /// </summary>        
        /// <returns><ENotificationOther></returns>
        public ENotificationOther GetNotificationViewOther(Int64 NotificationID)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@NotificationID", SqlDbType.BigInt);
            arParms[0].Value = NotificationID;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_NotificationViewGet", arParms);

            ENotificationOther objENotificationOther = new ENotificationOther();

            if (tempdataset.Tables.Count > 0)
            {
                if (tempdataset.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = tempdataset.Tables[0].Rows[0];
                    objENotificationOther.NotificationID = Convert.ToInt64(dr["NotificationID"]);
                    objENotificationOther.UserID = Convert.ToInt64(dr["UserID"]);
                    objENotificationOther.CustomerName = Convert.ToString(dr["Name"]);
                    objENotificationOther.Email = Convert.ToString(dr["Email"]);
                    objENotificationOther.CustomerID = Convert.ToInt64(dr["CustomerID"]);
                    objENotificationOther.Gender = Convert.ToString(dr["Gender"]);
                    objENotificationOther.Dob = Convert.ToString(dr["DOB"]);
                    objENotificationOther.ImagePath = Convert.ToString(dr["Picture"]);
                    objENotificationOther.Username = Convert.ToString(dr["Username"]);
                    objENotificationOther.Address = Convert.ToString(dr["Address"]);
                    objENotificationOther.PhoneNo = Convert.ToString(dr["Phone"]);
                    objENotificationOther.SignUpDate = Convert.ToString(dr["SignupDate"]);
                    objENotificationOther.LastLoginDate = Convert.ToString(dr["LastLoginDate"]);
                    objENotificationOther.NotificationDate = Convert.ToString(dr["NotificationDate"]);
                    objENotificationOther.NotificationType = Convert.ToString(dr["NotificationTypeName"]);
                    objENotificationOther.NotificationMedium = Convert.ToString(dr["NotificationMedium"]);
                    objENotificationOther.ServicedBy = Convert.ToString(dr["ServicedBy"]);
                    objENotificationOther.MailSubject = Convert.ToString(dr["Subject"]);
                    objENotificationOther.MailBody = Convert.ToString(dr["Body"]);
                }
            }
            return objENotificationOther;
        }

        /// <summary>
        /// Get Notified Customers
        /// </summary>        
        /// <returns>List<ENotificationOther></returns>
        public List<ENotificationOther> GetNotificationOtherCustomers(Int64 CustomerID)
        {


            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@CustomerID", SqlDbType.BigInt);
            arParms[0].Value = CustomerID;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_NotificationCustomerGet", arParms);

            List<ENotificationOther> lstENotificationOther = new List<ENotificationOther>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                ENotificationOther objENotificationOther = new ENotificationOther();
                objENotificationOther.NotificationID = Convert.ToInt64(dr["NotificationID"]);
                objENotificationOther.CustomerName = Convert.ToString(dr["Name"]);
                objENotificationOther.NotificationType = Convert.ToString(dr["NotificationTypeName"]);
                objENotificationOther.NotificationMedium = Convert.ToString(dr["NotificationMedium"]);
                objENotificationOther.ServiceStatus = Convert.ToString(dr["ServiceStatus"]);
                objENotificationOther.ServicedBy = Convert.ToString(dr["ServicedBy"]);
                objENotificationOther.NotificationDate = Convert.ToString(dr["ServicedDate"]);               
                objENotificationOther.CallId = Convert.ToInt64(dr["CallId"]);
                objENotificationOther.CCRep = Convert.ToString(dr["CCRep"]);
                objENotificationOther.CallType = Convert.ToString(dr["CallType"]);
                objENotificationOther.CallDuration = Convert.ToString(dr["CallDuration"]);
                objENotificationOther.CallOutcome = Convert.ToInt64(dr["CallOutcome"]);
                objENotificationOther.Disposition = Convert.ToString(dr["Disposition"]);
                objENotificationOther.NotInterestedReasonId = Convert.ToInt64(dr["NotInterestedReasonId"]);
                objENotificationOther.IsInvalidAddress =(string.IsNullOrEmpty(dr["IsInvalidAddress"].ToString()) ? Convert.ToBoolean(null) : Convert.ToBoolean(dr["IsInvalidAddress"]));
                objENotificationOther.IsCallQueueCall = Convert.ToString(dr["IsCallQueueCall"]);
                objENotificationOther.Notes = Convert.ToString(dr["Notes"]);
                // Add notification to list
                lstENotificationOther.Add(objENotificationOther);
            }

            return lstENotificationOther;
        }

        /// <summary>
        /// Get OutBound Customers
        /// </summary>        
        /// <returns>List<ENotificationOther></returns>
        public List<ENotificationOther> GetNotificationOtherPhone(Int64 NotificationTypeID)
        {
            DataSet tempdataset = new DataSet();

            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@NotificationTypeID", SqlDbType.BigInt);
            arParms[0].Value = NotificationTypeID;

            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_notificationGetPhone", arParms);

            List<ENotificationOther> lstENotificationOther = new List<ENotificationOther>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                ENotificationOther objENotificationOther = new ENotificationOther();

                objENotificationOther.CustomerID = Convert.ToInt64(dr["CustomerID"]);
                objENotificationOther.NotificationPhoneID = Convert.ToInt64(dr["NotificationPhoneID"]);
                objENotificationOther.NotificationID = Convert.ToInt64(dr["NotificationID"]);
                objENotificationOther.UserID = Convert.ToInt64(dr["UserID"]);
                objENotificationOther.CustomerName = Convert.ToString(dr["Name"]);
                objENotificationOther.NotificationType = Convert.ToString(dr["NotificationTypeName"]);
                objENotificationOther.PhoneOffice = Convert.ToString(dr["PhoneOffice"]);
                objENotificationOther.PhoneCell = Convert.ToString(dr["PhoneCell"]);
                objENotificationOther.PhoneHome = Convert.ToString(dr["PhoneHome"]);
                objENotificationOther.NotificationDate = Convert.ToString(dr["DeadLine"]);
                objENotificationOther.Source = Convert.ToString(dr["Source"]);
                objENotificationOther.ProspectCustomerId = Convert.ToInt32(dr["ProspectCustomerID"]);
                objENotificationOther.Tag = Convert.ToString(dr["Tag"]);
                objENotificationOther.SalesRepId = Convert.ToInt64(dr["SalesRepId"]);
                objENotificationOther.SalesRep = Convert.ToString(dr["SalesRep"]);

                // Add notification to list
                lstENotificationOther.Add(objENotificationOther);

            }

            return lstENotificationOther;
        }

        /// <summary>
        /// Check OutBound Call Status
        /// </summary>        
        /// <returns>boolean</returns>
        public bool CheckNotificationPhoneStatus(Int64 PhoneNotificationID)
        {
            bool blnStatus = false;
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@NotificationPhoneId", SqlDbType.BigInt);
            arParms[0].Value = PhoneNotificationID;

            arParms[1] = new SqlParameter("@Status", SqlDbType.BigInt);
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_notificationCheckStatusPhone", arParms);

            returnvalue = (Int64)arParms[1].Value;
            if (returnvalue > 0)
                blnStatus = true;
            return blnStatus;
        }

        /// <summary>
        /// Update OutBound Call Status
        /// </summary>        
        /// <returns></returns>
        public void UpdateNotificationPhoneStatus(Int64 PhoneNotificationID, Int64 ServicedBy)
        {

            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@NotificationPhoneId", SqlDbType.BigInt);
            arParms[0].Value = PhoneNotificationID;

            arParms[1] = new SqlParameter("@ServicedBy", SqlDbType.BigInt);
            arParms[1].Value = ServicedBy;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_notificationUpdatePhoneStatus", arParms);

        }

        public bool DeleteNotificationByID(int NotificationID)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@notificationid", SqlDbType.BigInt);
            arParms[0].Value = NotificationID;

            arParms[1] = new SqlParameter("@returnvalue", SqlDbType.Bit);
            arParms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_deleteNotificationByID", arParms);

            bool returnvalue = Convert.ToBoolean(arParms[1].Value);
            return returnvalue;
        }

        public bool DeleteNotificationByNotificationTypeID(int NotificationTypeID, int ServiceStatus)
        {
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@NotificationTypeID", SqlDbType.BigInt);
            arParms[0].Value = NotificationTypeID;

            arParms[1] = new SqlParameter("@ServiceStatus", SqlDbType.BigInt);
            arParms[1].Value = ServiceStatus;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.Bit);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_deleteNotificationByNotificationTypeID", arParms);

            bool returnvalue = Convert.ToBoolean(arParms[2].Value);
            return returnvalue;
        }

        /// <summary>
        /// Save Notification Subscriber
        /// </summary>        
        /// <returns>int</returns>

        public Int64 NotificationSubscriberSave(ENotificationSubscriber objNotificationSubscriber, int mode)
        {

            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[8];

            arParms[0] = new SqlParameter("@NotificationSubscriberID", SqlDbType.BigInt);
            arParms[0].Value = objNotificationSubscriber.NotificationSubscriberID;

            arParms[1] = new SqlParameter("@Name", SqlDbType.VarChar, 255);
            arParms[1].Value = CheckNull(objNotificationSubscriber.Name);

            arParms[2] = new SqlParameter("@Email", SqlDbType.VarChar, 255);
            arParms[2].Value = CheckNull(objNotificationSubscriber.Email);

            arParms[3] = new SqlParameter("@Phone", SqlDbType.VarChar, 100);
            arParms[3].Value = CheckNull(objNotificationSubscriber.Phone);

            arParms[4] = new SqlParameter("@UserId", SqlDbType.BigInt);
            arParms[4].Value = objNotificationSubscriber.UserId;

            arParms[5] = new SqlParameter("@NotificationTypeId", SqlDbType.Int);
            arParms[5].Value = objNotificationSubscriber.NotificationTypeID;

            arParms[6] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[6].Value = mode;

            arParms[7] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_NotificationSubscriber", arParms);
            returnvalue = (Int64)arParms[7].Value;
            return returnvalue;
        }

        public ENotificationSubscriber NotificationSubscriberGetUser(Int64 iUserId, int mode)
        {
            ENotificationSubscriber objNotificationSubscriber = null;
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
            arParms[0].Value = iUserId;

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_GetUserByUserID", arParms);

            if (tempdataset.Tables.Count > 0)
            {
                if (tempdataset.Tables[0].Rows.Count > 0)
                {
                    objNotificationSubscriber = new ENotificationSubscriber();
                    objNotificationSubscriber.UserId = Convert.ToInt64(tempdataset.Tables[0].Rows[0]["UserId"]);
                    objNotificationSubscriber.Email = Convert.ToString(tempdataset.Tables[0].Rows[0]["Email"]);
                    objNotificationSubscriber.Name = Convert.ToString(tempdataset.Tables[0].Rows[0]["Name"]);
                    objNotificationSubscriber.Phone = Convert.ToString(tempdataset.Tables[0].Rows[0]["Phone"]);
                }
            }
            return objNotificationSubscriber;
        }

        public ENotificationSubscriber NotificationSubscriberGet(int iNotificationTypeId, Int64 iNotificationScubsriberId)
        {
            ENotificationSubscriber objNotificationSubscriber = new ENotificationSubscriber();
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@NotificationSubscriberID", SqlDbType.BigInt);
            arParms[0].Value = iNotificationScubsriberId;

            arParms[1] = new SqlParameter("@NotificationTypeId", SqlDbType.Int);
            arParms[1].Value = iNotificationTypeId;

            arParms[2] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[2].Value = 2;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_GetNotificationSubscriber", arParms);

            if (tempdataset.Tables.Count > 0)
            {
                if (tempdataset.Tables[0].Rows.Count > 0)
                {
                    objNotificationSubscriber.NotificationSubscriberID = Convert.ToInt64(tempdataset.Tables[0].Rows[0]["NotificationSubscriberID"]);
                    objNotificationSubscriber.NotificationTypeID = Convert.ToInt32(tempdataset.Tables[0].Rows[0]["NotificationTypeID"]);
                    objNotificationSubscriber.UserId = Convert.ToInt64(tempdataset.Tables[0].Rows[0]["UserId"]);
                    objNotificationSubscriber.Email = Convert.ToString(tempdataset.Tables[0].Rows[0]["Email"]);
                    objNotificationSubscriber.Name = Convert.ToString(tempdataset.Tables[0].Rows[0]["Name"]);
                    objNotificationSubscriber.Phone = Convert.ToString(tempdataset.Tables[0].Rows[0]["Phone"]);
                }
            }
            return objNotificationSubscriber;
        }

        public List<ENotificationSubscriber> NotificationSubscriberGetByTypeID(int iNotificationTypeId, Int64 iNotificationScubsriberId, int PageSize, int PageIndex)
        {
            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@NotificationSubscriberID", SqlDbType.BigInt);
            arParms[0].Value = iNotificationScubsriberId;

            arParms[1] = new SqlParameter("@NotificationTypeId", SqlDbType.Int);
            arParms[1].Value = iNotificationTypeId;

            arParms[2] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[2].Value = 1;

            arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParms[3].Value = PageSize;

            arParms[4] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParms[4].Value = PageIndex;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_GetNotificationSubscriber", arParms);
            List<ENotificationSubscriber> lstNotificationSubscriber = new List<ENotificationSubscriber>();


            if (tempdataset.Tables.Count > 0)
            {
                if (tempdataset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in tempdataset.Tables[0].Rows)
                    {

                        ENotificationSubscriber objNotificationSubscriber = new ENotificationSubscriber();
                        objNotificationSubscriber.NotificationSubscriberID = Convert.ToInt64(dr["NotificationSubscriberID"]);
                        objNotificationSubscriber.NotificationTypeID = Convert.ToInt32(dr["NotificationTypeID"]);
                        objNotificationSubscriber.UserId = Convert.ToInt64(dr["UserId"]);
                        objNotificationSubscriber.Email = Convert.ToString(dr["Email"]);
                        objNotificationSubscriber.Name = Convert.ToString(dr["Name"]);
                        objNotificationSubscriber.Phone = Convert.ToString(dr["Phone"]);
                        lstNotificationSubscriber.Add(objNotificationSubscriber);
                    }
                    if (tempdataset.Tables.Count > 1)
                    {
                        if (tempdataset.Tables[1].Rows.Count > 0)
                        {
                            lstNotificationSubscriber[0].TotalRecord = Convert.ToInt32(tempdataset.Tables[1].Rows[0]["TotalRecords"]);
                        }
                    }
                }

            }
            return lstNotificationSubscriber;
        }


        #endregion

        #region "Contacts"
        /// <summary>
        /// Retrieves the details for Contact according to filter criteria applied
        /// </summary>
        /// <param name="prospectName">Contact Name</param>
        /// <param name="startDate">from created date</param>
        /// <param name="endDate">to created date</param>
        /// <param name="salesPersonId">sales person id for which prospect have to be retrieved</param>
        /// <param name="Mode">Mode</param>
        /// <param name="Zipcode"></param>
        /// <param name="Distance"></param>
        /// <returns></returns>
        public List<EProspect> GetContactDetails(string ContactName, string startDate, string endDate, Int64 SalesRepID, int mode, string zipcode, int distance)
        {

            if (ContactName == null)
                ContactName = "";

            if (startDate == null)
                startDate = "";

            if (endDate == null)
                endDate = "";

            SqlParameter[] arParms = new SqlParameter[7];

            arParms[0] = new SqlParameter("@ContactName", SqlDbType.VarChar, 500);
            arParms[0].Value = ContactName;

            arParms[1] = new SqlParameter("@StartDate", SqlDbType.VarChar, 100);
            arParms[1].Value = startDate;

            arParms[2] = new SqlParameter("@EndDate", SqlDbType.VarChar, 100);
            arParms[2].Value = endDate;

            arParms[3] = new SqlParameter("@SalesRepID", SqlDbType.BigInt);
            arParms[3].Value = SalesRepID;

            arParms[4] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[4].Value = mode;

            arParms[5] = new SqlParameter("@zipcode", SqlDbType.VarChar);
            arParms[5].Value = zipcode;

            arParms[6] = new SqlParameter("@distance", SqlDbType.Int);
            arParms[6].Value = distance;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getcontacts", arParms);

            List<EProspect> returnProspectDetails = new List<EProspect>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {
                //For Prospect details
                EProspect objProspectDetails = new EProspect();
                if (dr["ProspectId"] != DBNull.Value)
                    objProspectDetails.ProspectID = Convert.ToInt32(dr["ProspectId"]);
                objProspectDetails.OrganizationName = Convert.ToString(dr["ProspectName"]);
                objProspectDetails.ProspectDate = Convert.ToString(dr["ProspectCreatedDate"]);
                objProspectDetails.Status = Convert.ToString(dr["ProspectStatus"]);
                if (dr["NoOFCalls"] != DBNull.Value)
                    objProspectDetails.NoOfCalls = Convert.ToInt32(dr["NoOFCalls"]);
                if (dr["NoOFMeeting"] != DBNull.Value)
                    objProspectDetails.NoOfMeetings = Convert.ToInt32(dr["NoOFMeeting"]);
                //if (dr["NoOfContacts"] != DBNull.Value)
                //    objProspectDetails.NoOfContacts = Convert.ToInt32(dr["NoOfContacts"]);

                if (dr["IsHost"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(dr["IsHost"]) == true)
                        objProspectDetails.IsHost = true;
                    else
                        objProspectDetails.IsHost = false;
                }
                else objProspectDetails.IsHost = false;

                objProspectDetails.FirstName = Convert.ToString(dr["SalesRep"]);

                //For address details of prospect
                EAddress objAddress = new EAddress();

                objAddress.Address1 = Convert.ToString(dr["ProspectAddress1"]);
                objAddress.Address2 = Convert.ToString(dr["ProspectAddress2"]);
                objAddress.City = Convert.ToString(dr["ProspectCity"]);
                objAddress.State = Convert.ToString(dr["ProspectState"]);
                objAddress.Zip = Convert.ToString(dr["ProspectZip"]);
                objAddress.Country = Convert.ToString(dr["ProspectCountry"]);

                //For primary details of a prospect 
                EContact objContact = new EContact();

                objContact.ContactID = Convert.ToInt32(dr["ContactID"]);
                objContact.FirstName = Convert.ToString(dr["Name"]);
                objContact.PhoneHome = Convert.ToString(dr["Phone"]);
                objContact.EMail = Convert.ToString(dr["Email"]);

                //Get details of last call for a prospect
                EContactCall objContactCall = new EContactCall();
                objContactCall.StartDate = Convert.ToString(dr["ContactCallDate"]);

                //Get status of last call for a prospect
                ECallStatus objCallStatus = new ECallStatus();
                objCallStatus.Status = Convert.ToString(dr["ContactCallStatus"]);
                objCallStatus.Duration = Convert.ToString(dr["Duration"]);
                objCallStatus.Notes = Convert.ToString(dr["Notes"]);

                objContactCall.CallStatus = objCallStatus;
                List<EContact> lstContact = new List<EContact>();
                lstContact.Add(objContact);
                objProspectDetails.Contact = lstContact;
                objProspectDetails.ContactCall = objContactCall;
                objProspectDetails.Address = objAddress;


                returnProspectDetails.Add(objProspectDetails);
            }

            return returnProspectDetails;
        }
        #endregion

        # region "Territory"

        public Int64 SaveTerritory(ETerritory objTerritory, Int32 mode)
        {
            SqlParameter[] arParms = new SqlParameter[11];

            arParms[0] = new SqlParameter("@Name", SqlDbType.VarChar, 100);
            arParms[0].Value = objTerritory.Name;

            arParms[1] = new SqlParameter("@Description", SqlDbType.VarChar, 1000);
            arParms[1].Value = objTerritory.Description;

            arParms[2] = new SqlParameter("@Type", SqlDbType.TinyInt);
            arParms[2].Value = objTerritory.Type;

            arParms[3] = new SqlParameter("@TerritoryFranchiseeID", SqlDbType.BigInt);
            if (objTerritory.TerritoryFranchiseeID == 0)
                arParms[3].Value = DBNull.Value;
            else
                arParms[3].Value = objTerritory.TerritoryFranchiseeID;

            arParms[4] = new SqlParameter("@ParentTerritoryID", SqlDbType.BigInt);
            arParms[4].Value = objTerritory.ParentTerritoryID;

            arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
            arParms[5].Value = objTerritory.IsActive;

            arParms[6] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[6].Value = mode;

            arParms[7] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[7].Direction = ParameterDirection.Output;

            arParms[8] = new SqlParameter("@TerritoryID", SqlDbType.BigInt);
            arParms[8].Value = objTerritory.TerritoryID;

            arParms[9] = new SqlParameter("@TerritorySalesRepID", SqlDbType.BigInt);
            if (objTerritory.TerritorySalesRepID == 0)
                arParms[9].Value = DBNull.Value;
            else
                arParms[9].Value = objTerritory.TerritorySalesRepID;

            arParms[10] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            if (objTerritory.CreatedBy == 0)
                arParms[10].Value = DBNull.Value;
            else
                arParms[10].Value = objTerritory.CreatedBy;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_addTerritory", arParms);
            Int64 returnresult = new Int64();
            returnresult = Convert.ToInt64(arParms[7].Value);
            return returnresult;

        }

        public Int64 SaveTerritoryZip(ETerritoryZipMap objTerritoryZip, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@TerritoryID", SqlDbType.BigInt);
            arParms[0].Value = objTerritoryZip.TerritoryID;

            arParms[1] = new SqlParameter("@ZipID", SqlDbType.BigInt);
            arParms[1].Value = objTerritoryZip.ZipID;

            arParms[2] = new SqlParameter("@IsActive", SqlDbType.Bit);
            arParms[2].Value = objTerritoryZip.IsActive;

            arParms[3] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[3].Value = mode;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;

            Int64 returnresult = new Int64();
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_addTerritoryZip", arParms);
            returnresult = Convert.ToInt64(arParms[4].Value);

            return returnresult;
        }

        public List<ETerritory> GetFranchiseeTerritory(string filtertext, string zipcode, int mode, long franchiseeid, long roleid, long userid)
        {
            SqlParameter[] arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@filtertext", SqlDbType.VarChar, 50);
            arParms[0].Value = filtertext;

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;

            arParms[2] = new SqlParameter("@franchiseeid", SqlDbType.BigInt);
            arParms[2].Value = franchiseeid;

            arParms[3] = new SqlParameter("@roleid", SqlDbType.Int);
            arParms[3].Value = roleid;

            arParms[4] = new SqlParameter("@userid", SqlDbType.Int);
            arParms[4].Value = userid;

            arParms[5] = new SqlParameter("@zipcode", SqlDbType.VarChar, 10);
            if (zipcode.Trim().Length > 0)
                arParms[5].Value = zipcode;
            else
                arParms[5].Value = DBNull.Value;

            List<ETerritory> objListTerritory = new List<ETerritory>();
            DataSet ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getTerritory", arParms);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataTable dtTotalZipCount = ds.Tables[1];
                DataTable dtAssignedZipCount = ds.Tables[2];
                for (int count = 0; count < dt.Rows.Count; count++)
                {
                    ETerritory objTerritory = new ETerritory();
                    objTerritory.TerritoryID = Convert.ToInt32(dt.Rows[count]["TerritoryID"]);
                    objTerritory.Name = Convert.ToString(dt.Rows[count]["TerritoryName"]);
                    objTerritory.Description = Convert.ToString(dt.Rows[count]["Description"]);
                    objTerritory.FranchiseeName = Convert.ToString(dt.Rows[count]["Franchisee"]);
                    objTerritory.ParentTerritoryID = Convert.ToInt32(dt.Rows[count]["ParentTerritoryID"]);
                    if (objTerritory.ParentTerritoryID == 0)
                    {
                        dtTotalZipCount.DefaultView.RowFilter = "TerritoryID = " + objTerritory.TerritoryID.ToString();
                        if (dtTotalZipCount.DefaultView.Count > 0)
                            objTerritory.TotalZipCount = Convert.ToInt32(dtTotalZipCount.DefaultView[0]["TotalZipsCount"]);

                        dtAssignedZipCount.DefaultView.RowFilter = "TerritoryID = " + objTerritory.TerritoryID.ToString();
                        if (dtAssignedZipCount.DefaultView.Count > 0)
                            objTerritory.AssignedZipCount = Convert.ToInt32(dtAssignedZipCount.DefaultView[0]["AssignedZipsCount"]);

                        objTerritory.UnassignedZipCount = objTerritory.TotalZipCount - objTerritory.AssignedZipCount;
                    }
                    else
                    {
                        dtTotalZipCount.DefaultView.RowFilter = "TerritoryID = " + objTerritory.TerritoryID.ToString();
                        if (dtTotalZipCount.DefaultView.Count > 0)
                            objTerritory.TotalZipCount = Convert.ToInt32(dtTotalZipCount.DefaultView[0]["TotalZipsCount"]);

                        objTerritory.AssignedZipCount = objTerritory.TotalZipCount;
                    }
                    objListTerritory.Add(objTerritory);
                }
            }
            return objListTerritory;
        }

        public bool DeleteTerritory(string territoryid, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@TerritoryID", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt32(territoryid);

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;

            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.Bit);
            arParms[2].Direction = ParameterDirection.Output;

            bool returnresult = new bool();
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_deleteTerritory", arParms);

            returnresult = Convert.ToBoolean(arParms[2].Value);

            return returnresult;

        }

        public ETerritory GetTerritoryDetail(string territoryid, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@TerritoryID", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt32(territoryid);

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;

            ETerritory objTerritory = new ETerritory();
            DataSet ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getTerritoryDetail", arParms);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dtTerritory = ds.Tables[0];
                if (dtTerritory.Rows.Count > 0)
                {
                    objTerritory.TerritoryID = Convert.ToInt32(dtTerritory.Rows[0]["TerritoryID"]);
                    objTerritory.Name = Convert.ToString(dtTerritory.Rows[0]["TerritoryName"]);
                    objTerritory.Description = Convert.ToString(dtTerritory.Rows[0]["Description"]);
                    objTerritory.FranchiseeName = Convert.ToString(dtTerritory.Rows[0]["Franchisee"]);
                }
                if (ds.Tables.Count > 1)
                {
                    DataTable dtZip = ds.Tables[1];
                    objTerritory.TerritoryZipMap = new List<ETerritoryZipMap>();
                    if (dtZip.Rows.Count > 0)
                    {
                        for (int count = 0; count < dtZip.Rows.Count; count++)
                        {
                            ETerritoryZipMap objTZip = new ETerritoryZipMap();
                            objTZip.ZipID = Convert.ToInt32(dtZip.Rows[count]["ZipID"]);
                            objTZip.ZipDetail = Convert.ToString(dtZip.Rows[count]["ZipDetail"]);
                            objTerritory.TerritoryZipMap.Add(objTZip);
                        }

                    }
                }
            }
            return objTerritory;
        }

        public string[] GetAllZipCodesByTerritory(string territoryid)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@TerritoryID", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt32(territoryid);

            DataSet ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getTotalZipsByTerritoryID", arParms);
            string[] arr_ZipCodes = new string[0];
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                arr_ZipCodes = new string[ds.Tables[0].Rows.Count];
                for (int count = 0; count < ds.Tables[0].Rows.Count; count++)
                {
                    arr_ZipCodes[count] = Convert.ToString(ds.Tables[0].Rows[count]["ZipCode"]);
                }
            }
            return arr_ZipCodes;
        }

        public string[] GetUnAssignedCodesByTerritory(string territoryid)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@TerritoryID", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt32(territoryid);

            DataSet ds = SqlHelper.ExecuteDataset(connectionstring, "usp_getUnAssignedZipsByTerritoryID", arParms);
            string[] arr_ZipCodes = new string[0];
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                arr_ZipCodes = new string[ds.Tables[0].Rows.Count];
                for (int count = 0; count < ds.Tables[0].Rows.Count; count++)
                {
                    arr_ZipCodes[count] = Convert.ToString(ds.Tables[0].Rows[count]["ZipCode"]);
                }
            }
            return arr_ZipCodes;
        }
        # endregion

        #region Notes Details

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<ENotesDetails> GetProspectNotesDetails(string filterString, int mode)
        {

            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;

            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_GetNotes", arParms);

            List<ENotesDetails> returnENotesDetails = new List<ENotesDetails>();

            foreach (DataRow dr in tempdataset.Tables[0].Rows)
            {

                ENotesDetails objENotesDetails = new ENotesDetails();

                if (dr["NoteID"] != DBNull.Value)
                    objENotesDetails.NoteID = Convert.ToInt64(dr["NoteID"]);

                if (dr["Notes"] != DBNull.Value)
                    objENotesDetails.Notes = Convert.ToString(dr["Notes"]);

                if (dr["DateCreated"] != DBNull.Value)
                    objENotesDetails.DateCreated = Convert.ToString(dr["DateCreated"]);

                if (dr["DateModified"] != DBNull.Value)
                    objENotesDetails.DateModified = Convert.ToString(dr["DateModified"]);

                returnENotesDetails.Add(objENotesDetails);
            }

            return returnENotesDetails;
        }

        public void DeleteNotesDetails(Int64 NotesID, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[2];

            arParms[0] = new SqlParameter("@NotesID", SqlDbType.BigInt);
            arParms[0].Value = NotesID;

            arParms[1] = new SqlParameter("@mode", SqlDbType.Int);
            arParms[1].Value = mode;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_DeleteNotes", arParms);

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
