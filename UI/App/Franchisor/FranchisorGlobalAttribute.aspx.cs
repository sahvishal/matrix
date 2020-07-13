using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Master;
using Falcon.Entity.Franchisor;
using Falcon.Entity.Other;


public partial class Franchisor_FranchisorGlobalAttribute : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Global Settings";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Global Settings");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Dashboard > Admin </a>";
        obj.hideucsearch();
        if (!IsPostBack)
        {
            var masterDal = new MasterDAL();
            List<EScheduleTemplate> arrScheduleTemplate = masterDal.GetEventScheduleTemplate("", 0, 1);
            ddlEventScheduleTemp.Items.Clear();
            ddlEventScheduleTemp.Items.Add(new ListItem("Select Schedule Template", "0"));
            if (arrScheduleTemplate != null)
            {
                for (int count = 0; count < arrScheduleTemplate.Count; count++)
                {
                    ddlEventScheduleTemp.Items.Add(new ListItem(arrScheduleTemplate[count].Name, arrScheduleTemplate[count].ScheduleTemplateID.ToString()));
                }
            }
            for (int count = 0; count < 60; count++)
            {
                string mm = count.ToString();
                if (mm.Length == 1)
                    mm = "0" + mm;
                ddlMMStartTime.Items.Add(new ListItem(mm, mm));
                ddlMMEndTime.Items.Add(new ListItem(mm, mm));
                ddlMMLunchStartTime.Items.Add(new ListItem(mm, mm));
            }

            GetglobalAttributes();
        }
        txtGCutoffDate.Attributes.Add("ReadOnly", "ReadOnly");
    }
    /// <summary>
    /// Get all Global attributes for Franchisee
    /// </summary>
    private void GetglobalAttributes()
    {
        var franchisorDal = new FranchisorDAL();
        var eGlobalAttributes = franchisorDal.GetFranchisorGlobalAttributes();

        //txtAppointmentSlot.Text = EGlobalAttributes.AppointmentSlot.ToString();
        ddlEventScheduleTemp.SelectedValue = eGlobalAttributes.ScheduleTemplateID.ToString();
        txtOtherPicture.Text = eGlobalAttributes.NumberOfPictures.ToString();
        txtPasswordDay.Text = eGlobalAttributes.DaysToChangePassword.ToString();
        txtGCutoffDate.Text = eGlobalAttributes.GlobalCutOffDate;

        txtSystemVersion.Text = eGlobalAttributes.SystemVersion;
        txtEventdistance.Text = eGlobalAttributes.Eventdistance.ToString();

        txtAdministratorEmailAddress.Text = eGlobalAttributes.AdministratorEmailAddress;

        txtCouponPrefix.Text = eGlobalAttributes.CouponPrefix;
        txtDisplayQABar.Text = eGlobalAttributes.DisplayQABar;
        txtMaxCommissionDollarAdvocate.Text = eGlobalAttributes.MaxDollarCommission.ToString();

        txtMaxCommissionDollarSalesRep.Text = eGlobalAttributes.MaxDollarCommissionSalesRep.ToString();
        txtMaxCommissionPercentAdvocate.Text = eGlobalAttributes.MaxPercentCommission.ToString();
        txtMaxCommissionPercentSalesRep.Text = eGlobalAttributes.MaxPercentCommissionSalesRep.ToString();
        CancellationFeeTextbox.Text = eGlobalAttributes.CancellationFee.ToString();
        txtHealthYesCompetitor.Text = eGlobalAttributes.HealthYesCompetitor;

        ddlHHStartTime.SelectedValue = eGlobalAttributes.EventStartTime.Substring(0, 2);
        ddlMMStartTime.SelectedValue = eGlobalAttributes.EventStartTime.Substring(3, 2);
        ddlAMPMStartTime.SelectedValue = eGlobalAttributes.EventStartTime.Substring(6, 2);

        ddlHHEndTime.SelectedValue = eGlobalAttributes.EventEndTime.Substring(0, 2);
        ddlMMEndTime.SelectedValue = eGlobalAttributes.EventEndTime.Substring(3, 2);
        ddlAMPMEndTime.SelectedValue = eGlobalAttributes.EventEndTime.Substring(6, 2);

        txtMinumPurchaseAmount.Text = eGlobalAttributes.MinimumPurchaseAmount.ToString("0.00");

        if (Convert.ToBoolean(eGlobalAttributes.IncomingPhoneLineRequired))
            IncomingPhoneLineRequiredYes.Checked = true;
        else
            IncomingPhoneLineRequiredNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.EnableAlaCarte))
            EnableAlacarteYes.Checked = true;
        else
            EnableAlaCarteNo.Checked = true;

        txtAreaCode.Text = eGlobalAttributes.AreaCode;

        if (Convert.ToBoolean(eGlobalAttributes.EnableBarCode))
            EnableBarCodeYes.Checked = true;
        else
            EnableBarCodeNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.UpsellPackage))
            UpsellPackageYes.Checked = true;
        else
            UpsellPackageNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.UpsellCd))
            UpsellCdYes.Checked = true;
        else
            UpsellCdNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.UpsellAlaCarte))
            UpsellAlaCarteYes.Checked = true;
        else
            UpsellAlaCarteNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.DisplayPremiumVersiononPortal))
            DisplayPremVersionYes.Checked = true;
        else
            DisplayPremVersionNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.EnableResultDeliveryNotification))
            EnableDelNotificationYes.Checked = true;
        else
            EnableDelNotificationNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.EnableNewsletterPrompt))
            EnableNewsletterYes.Checked = true;
        else
            EnableNewsletterNo.Checked = true;

        SourceCodeLabelText.Text = eGlobalAttributes.SourceCodeLabel;

        MaxNoOfEventToShowOnlineTextbox.Text = eGlobalAttributes.MaxNoOfEventToShowOnline.ToString();
        MaxNoOfAppointmentSlotsToShowOnlineTextbox.Text = eGlobalAttributes.MaxNoOfAppointmentSlotsToShowOnline.ToString();
        EventListPageSizeOnlineTextbox.Text = eGlobalAttributes.EventListPageSizeOnline.ToString();
        CutoffHoursforOnlineEventSelTextBox.Text = eGlobalAttributes.CutOffHourNumberforOnlineEventSelection.ToString();

        PaperSizeDropDownList.SelectedValue = eGlobalAttributes.PaperSize;

        if (Convert.ToBoolean(eGlobalAttributes.DisplayRescheduleAppointmentPortal))
            DisplayRescheduleAppointmentYes.Checked = true;
        else
            DisplayRescheduleAppointmentNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.ShowBasicBiometric))
            ShowBasicBiometricYes.Checked = true;
        else
            ShowBasicBiometricNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.EnableQuickOnsiteRegistration))
            EnableQuickOnsiteRegistrationYes.Checked = true;
        else
            EnableQuickOnsiteRegistrationNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.PayLaterOnlineRegistration))
            PayLaterOnlineRegistrationYes.Checked = true;
        else
            PayLaterOnlineRegistrationNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.RestrictAvailableTimeSlotForCorporate))
            RestrictAvailableTimeSlotForCorporateYes.Checked = true;
        else
            RestrictAvailableTimeSlotForCorporateNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.ScreeningReminderNotification))
            ScreeningReminderNotificationYes.Checked = true;
        else
            ScreeningReminderNotificationNo.Checked = true;


        if (Convert.ToBoolean(eGlobalAttributes.IsHipaaEnabled))
            HipaaEnabledYes.Checked = true;
        else
            HipaaEnabledNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.EnableDynamicSlot))
            EnableDynamicSlotYes.Checked = true;
        else
            EnableDynamicSlotNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.SendEmptyQueueEvaluationReminder))
            SendEmptyQueueEvaluationReminderYes.Checked = true;
        else
            SendEmptyQueueEvaluationReminderNo.Checked = true;

        ddlHHLunchStartTime.SelectedValue = eGlobalAttributes.LunchStartTime.Substring(0, 2);
        ddlMMLunchStartTime.SelectedValue = eGlobalAttributes.LunchStartTime.Substring(3, 2);
        ddlAMPMLunchStartTime.SelectedValue = eGlobalAttributes.LunchStartTime.Substring(6, 2);

        EventBookingTresholdTextbox.Text = eGlobalAttributes.EventBookingThreshold.ToString();

        if (Convert.ToBoolean(eGlobalAttributes.PackageSelectionInfo))
            PackageSelectionInfoYes.Checked = true;
        else
            PackageSelectionInfoNo.Checked = true;

        //Load Hidden variable
        hidGCutoffDate.Value = txtGCutoffDate.Text;
        hidSystemVersion.Value = txtSystemVersion.Text;
        hidEventdistance.Value = txtEventdistance.Text;
        hidAdministratorEmailAddress.Value = txtAdministratorEmailAddress.Text;

        hidCouponPrefix.Value = txtCouponPrefix.Text;
        hidEventScheduleTemp.Value = ddlEventScheduleTemp.SelectedValue;
        hidDisplayQABar.Value = txtDisplayQABar.Text;
        hidMaxCommissionDollar.Value = txtMaxCommissionDollarAdvocate.Text;

        hidSalesRepMaxCommissionDollar.Value = txtMaxCommissionDollarSalesRep.Text;
        hidMaxCommissionPercent.Value = txtMaxCommissionPercentAdvocate.Text;
        hidSalesRepMaxCommissionPercent.Value = txtMaxCommissionPercentSalesRep.Text;
        hfHealthYesCompetitor.Value = txtHealthYesCompetitor.Text;
        CancellationFeeHiddenbox.Value = CancellationFeeTextbox.Text;

        if (Convert.ToBoolean(eGlobalAttributes.EnableSmsNotification))
            SmsEnabledYes.Checked = true;
        else
            SmsEnabledNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.EnableVoiceMailNotification))
            VoiceMailEnabledYes.Checked = true;
        else
            VoiceMailEnabledNo.Checked = true;
       

        if (Convert.ToBoolean(eGlobalAttributes.EnablePhysicianPartnerCustomerResultFaxNotification))
            FaxEnabledYes.Checked = true;
        else
            FaxEnabledNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.EnableAWVCustomerResultFaxNotification))
            AWVFaxEnabledYes.Checked = true;
        else
            AWVFaxEnabledNo.Checked = true;

        if (Convert.ToBoolean(eGlobalAttributes.AskPreQualificationQuestion))
            AskPreQualificationQuestionYes.Checked = true;
        else
            AskPreQualificationQuestionNo.Checked = true;

        passwordExpiryDaysCount.Text = eGlobalAttributes.PasswordExpirationDays;
        previousPasswordNonRepetitionCount.Text = eGlobalAttributes.PreviousPasswordNonRepetitionCount;


        otpEmail.Checked = Convert.ToBoolean(eGlobalAttributes.OtpNotificationMediumEmail);
        otpSms.Checked = Convert.ToBoolean(eGlobalAttributes.OtpNotificationMediumSms);
        googleAuthenticator.Checked = Convert.ToBoolean(eGlobalAttributes.OtpByGoogleAuthenticator);

        otpExpirationMinutes.Text = eGlobalAttributes.OtpExpirationMinutes.ToString();
        otpMisMatchAttemptCount.Text = eGlobalAttributes.OtpMisMatchAttemptCount.ToString();

        allowSafeComputerRemember.Checked = Convert.ToBoolean(eGlobalAttributes.AllowSafeComputerRemember);
        safeDeviceExpiryDays.Text = eGlobalAttributes.SafeDeviceExpiryDays.ToString();

        alertBeforePasswordExpirationInDays.Text = eGlobalAttributes.AlertBeforePasswordExpirationInDays.ToString();
    }

    /// <summary>
    /// Save the Changes in the Global attributes of the Franchisee.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, ImageClickEventArgs e)
    {
        var eGlobalAttributes = new EGlobalAttributes
                                    {
                                        AppointmentSlot = 0,
                                        NumberOfPictures = Convert.ToInt32(txtOtherPicture.Text),
                                        DaysToChangePassword = Convert.ToInt32(txtPasswordDay.Text),
                                        ScheduleTemplateID =
                                            Convert.ToInt32(ddlEventScheduleTemp.SelectedValue),
                                        GlobalCutOffDate = txtGCutoffDate.Text,
                                        SystemVersion = Convert.ToString(txtSystemVersion.Text),
                                        Eventdistance = Convert.ToInt64(txtEventdistance.Text),
                                        AdministratorEmailAddress =
                                            Convert.ToString(txtAdministratorEmailAddress.Text),
                                        CouponPrefix = Convert.ToString(txtCouponPrefix.Text),
                                        DisplayQABar = txtDisplayQABar.Text,
                                        MaxDollarCommission =
                                            Convert.ToDecimal(txtMaxCommissionDollarAdvocate.Text),
                                        MaxDollarCommissionSalesRep =
                                            Convert.ToDecimal(txtMaxCommissionDollarSalesRep.Text),
                                        MaxPercentCommission =
                                            Convert.ToDecimal(txtMaxCommissionPercentAdvocate.Text),
                                        MaxPercentCommissionSalesRep =
                                            Convert.ToDecimal(txtMaxCommissionPercentSalesRep.Text),
                                        CancellationFee = Convert.ToDecimal(CancellationFeeTextbox.Text),
                                        HealthYesCompetitor = txtHealthYesCompetitor.Text,
                                        EventStartTime = ddlHHStartTime.SelectedItem.Text + ":" + ddlMMStartTime.SelectedItem.Text + " " + ddlAMPMStartTime.SelectedValue,
                                        EventEndTime = ddlHHEndTime.SelectedItem.Text + ":" + ddlMMEndTime.SelectedItem.Text + " " + ddlAMPMEndTime.SelectedValue,
                                        MinimumPurchaseAmount = Convert.ToDecimal(txtMinumPurchaseAmount.Text),
                                        IncomingPhoneLineRequired = IncomingPhoneLineRequiredYes.Checked ? Boolean.TrueString : Boolean.FalseString,
                                        EnableAlaCarte = EnableAlacarteYes.Checked ? Boolean.TrueString : Boolean.FalseString,
                                        AreaCode = txtAreaCode.Text,
                                        EnableBarCode = EnableBarCodeYes.Checked ? Boolean.TrueString : Boolean.FalseString,
                                        UpsellPackage = UpsellPackageYes.Checked ? Boolean.TrueString : Boolean.FalseString,
                                        UpsellCd = UpsellCdYes.Checked ? Boolean.TrueString : Boolean.FalseString,
                                        UpsellAlaCarte = UpsellAlaCarteYes.Checked ? Boolean.TrueString : Boolean.FalseString,
                                        MaxNoOfEventToShowOnline = Convert.ToInt32(MaxNoOfEventToShowOnlineTextbox.Text),
                                        MaxNoOfAppointmentSlotsToShowOnline = Convert.ToInt32(MaxNoOfAppointmentSlotsToShowOnlineTextbox.Text),
                                        EventListPageSizeOnline = Convert.ToInt32(EventListPageSizeOnlineTextbox.Text),
                                        PaperSize = PaperSizeDropDownList.SelectedValue,
                                        DisplayPremiumVersiononPortal = DisplayPremVersionYes.Checked ? bool.TrueString : bool.FalseString,
                                        EnableResultDeliveryNotification = EnableDelNotificationYes.Checked ? bool.TrueString : bool.FalseString,
                                        EnableNewsletterPrompt = EnableNewsletterYes.Checked ? bool.TrueString : bool.FalseString,
                                        SourceCodeLabel = SourceCodeLabelText.Text,
                                        CutOffHourNumberforOnlineEventSelection = Convert.ToInt32(CutoffHoursforOnlineEventSelTextBox.Text),
                                        DisplayRescheduleAppointmentPortal = DisplayRescheduleAppointmentYes.Checked ? bool.TrueString : bool.FalseString,
                                        ShowBasicBiometric = ShowBasicBiometricYes.Checked ? bool.TrueString : bool.FalseString,
                                        EnableQuickOnsiteRegistration = EnableQuickOnsiteRegistrationYes.Checked ? bool.TrueString : bool.FalseString,
                                        PayLaterOnlineRegistration = PayLaterOnlineRegistrationYes.Checked ? bool.TrueString : bool.FalseString,
                                        RestrictAvailableTimeSlotForCorporate = RestrictAvailableTimeSlotForCorporateYes.Checked ? bool.TrueString : bool.FalseString,
                                        ScreeningReminderNotification = ScreeningReminderNotificationYes.Checked ? bool.TrueString : bool.FalseString,
                                        IsHipaaEnabled = HipaaEnabledYes.Checked ? bool.TrueString : bool.FalseString,
                                        EnableDynamicSlot = EnableDynamicSlotYes.Checked ? bool.TrueString : bool.FalseString,
                                        LunchStartTime = ddlHHLunchStartTime.SelectedItem.Text + ":" + ddlMMLunchStartTime.SelectedItem.Text + " " + ddlAMPMLunchStartTime.SelectedValue,
                                        SendEmptyQueueEvaluationReminder = SendEmptyQueueEvaluationReminderYes.Checked ? bool.TrueString : bool.FalseString,
                                        EventBookingThreshold = Convert.ToInt32(EventBookingTresholdTextbox.Text),
                                        PackageSelectionInfo = PackageSelectionInfoYes.Checked ? bool.TrueString : bool.FalseString,
                                        EnableSmsNotification = SmsEnabledYes.Checked ? bool.TrueString : bool.FalseString,
                                        EnablePhysicianPartnerCustomerResultFaxNotification = FaxEnabledYes.Checked ? bool.TrueString : bool.FalseString,
                                        EnableAWVCustomerResultFaxNotification = AWVFaxEnabledYes.Checked ? bool.TrueString : bool.FalseString,
                                        AskPreQualificationQuestion = AskPreQualificationQuestionYes.Checked ? bool.TrueString : bool.FalseString,
                                        PasswordExpirationDays = passwordExpiryDaysCount.Text,
                                        PreviousPasswordNonRepetitionCount = previousPasswordNonRepetitionCount.Text,
                                        OtpNotificationMediumEmail = otpEmail.Checked ? bool.TrueString : bool.FalseString,
                                        OtpNotificationMediumSms = otpSms.Checked ? bool.TrueString : bool.FalseString,
                                        OtpExpirationMinutes = Convert.ToInt32(otpExpirationMinutes.Text),
                                        OtpMisMatchAttemptCount = Convert.ToInt32(otpMisMatchAttemptCount.Text),

                                        OtpByGoogleAuthenticator = googleAuthenticator.Checked ? bool.TrueString : bool.FalseString,
                                        AllowSafeComputerRemember = allowSafeComputerRemember.Checked ? bool.TrueString : bool.FalseString,
                                        SafeDeviceExpiryDays =  Convert.ToInt32(safeDeviceExpiryDays.Text),
                                        AlertBeforePasswordExpirationInDays = Convert.ToInt32(alertBeforePasswordExpirationInDays.Text),
                                        EnableVoiceMailNotification = VoiceMailEnabledYes.Checked ? bool.TrueString : bool.FalseString,

                                    };


        var franchisorDal = new FranchisorDAL();
        Int64 returnresult = franchisorDal.SaveFranchisorGlobalAttributes(eGlobalAttributes);

        divErrorMsg.Visible = true;

    }


}
