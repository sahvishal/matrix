using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Deprecated.Enum;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Other;
using Falcon.App.Lib;
using Falcon.App.Core.Impl;


public partial class App_UCCommon_ucEventSummaryPanel : System.Web.UI.UserControl
{
    public delegate void DelLinkCountClick(object sender, EventArgs e);
    public event DelLinkCountClick LinkCountClick;

    public string PackageFormationString { set { sppackagecountstring.InnerHtml = value; } }
    public string TestFormationString { set { _testNameSpan.InnerHtml = value; } }

    private readonly CryptographyService _cryptographyService = new DigitalDeliveryCryptographyService();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //public void LoadEventSummaryPanel(EEvent eventData)
    public void LoadEventSummaryPanel(EventMetricsViewData eventMetricsViewData, EventHostViewData eventHostViewData, EEvent eventPodDetails)
    {

        if (eventMetricsViewData == null || eventHostViewData == null)
            return;

        // format phone no.
        var commonCode = new CommonCode();

        string key = EPDFType.ResultPdf + "~" + eventHostViewData.EventId + "~0~" + "ALL";
        key = _cryptographyService.Encrypt(key);
        aPrintBulkResult.HRef = "javascript:showClinicalForm('" + key + "');";

        key = EPDFType.ClinicalForm + "~" + eventHostViewData.EventId + "~0~" + "ALL";
        key = _cryptographyService.Encrypt(key);
        aPrintBulkClinicalForm.HRef = "javascript:showClinicalForm('" + key + "');";

        ancopenpopupaddslot.HRef = "/App/Common/AddSlot.aspx?EventDate=" + eventHostViewData.EventDate.ToShortDateString() + "&keepThis=true&TB_iframe=true&width=295&height=140&modal=true";

        Session["EventID"] = eventHostViewData.EventId;
        ViewState["EventDate"] = eventHostViewData.EventDate;
        ViewState["EventName"] = eventHostViewData.Name;

        Session["EventDate"] = eventHostViewData.EventDate;
        Session["EventName"] = eventHostViewData.Name;

        if (Convert.ToDateTime(eventHostViewData.EventDate).Date > DateTime.Now.Date)
        {
            aResultStatus.Visible = false;
            //if (!eventPodDetails.IsTeamConfiguredOnEventDay) spIsTeamConfigured.Style[System.Web.UI.HtmlTextWriterStyle.Display] = "none";
        }
        else
        {
            //if (!eventPodDetails.IsTeamConfiguredOnEventDay) spIsTeamConfigured.Style[System.Web.UI.HtmlTextWriterStyle.Display] = "block";

            long shell = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId;
            if (shell == (int)Roles.FranchisorAdmin) aResultStatus.HRef = "/App/Franchisor/EventCustomerResult.aspx?AllRecordsEventID=" + eventHostViewData.EventId;
            else aResultStatus.HRef = "/App/Franchisee/FranchiseeEventCustomerResult.aspx?AllRecordsEventID=" + eventHostViewData.EventId;
        }

        speventdate.InnerText = Convert.ToDateTime(eventHostViewData.EventDate).ToShortDateString();
        speventloc.InnerHtml = eventHostViewData.StreetAddressLine1 + ", " + eventHostViewData.City + ", " + eventHostViewData.State + ", " + eventHostViewData.Zip;
        sphostphone.InnerText = commonCode.FormatPhoneNumberGet(eventPodDetails.Host.PhoneOffice);
        ViewState["HostName"] = eventHostViewData.OrganizationName;
        ViewState["HostAddress"] = eventHostViewData.StreetAddressLine1;
        ViewState["HostCityStateZip"] = eventHostViewData.City + " " + eventHostViewData.State + " " + eventHostViewData.Zip;

        Session["HostName"] = eventHostViewData.OrganizationName;
        Session["HostAddress"] = eventHostViewData.StreetAddressLine1;
        Session["HostCityStateZip"] = eventHostViewData.City + " " + eventHostViewData.State + " " + eventHostViewData.Zip;

        spBPEIPDeposit.InnerText = decimal.Round((eventMetricsViewData.CashRevenue + eventMetricsViewData.CheckRevenue), 2).ToString();

        spBPCashPayment.InnerText = decimal.Round(eventMetricsViewData.CashRevenue, 2).ToString();
        spBPCardPayment.InnerText = decimal.Round(eventMetricsViewData.ChargeCardRevenue, 2).ToString();
        spBPCheckPayment.InnerText = decimal.Round(eventMetricsViewData.CheckRevenue, 2).ToString();
        spBPeCheckPayment.InnerText = decimal.Round(eventMetricsViewData.ECheckRevenue, 2).ToString();
        decimal totalRevenue = eventMetricsViewData.ChargeCardRevenue + eventMetricsViewData.CheckRevenue +
                               eventMetricsViewData.CashRevenue + eventMetricsViewData.ECheckRevenue +
                               eventMetricsViewData.GiftCertificateRevenue +
                               eventMetricsViewData.UnPaidExcluedeNoShowRevenue;
        spBPTotalPayment.InnerText = decimal.Round(totalRevenue, 2).ToString();
        spBPEventID.InnerText = eventHostViewData.EventId.ToString();

        lnkBPRegCustomer.Text = eventMetricsViewData.RegisteredCustomersCount.ToString();
        spBPCanceledCustomer.InnerHtml = eventMetricsViewData.CancelledCustomersCount.ToString();
        lnkBPNoshowCustomer.Text = eventMetricsViewData.NoShowCustomersCount.ToString();
        lnkBPPaidCustomer.Text = eventMetricsViewData.PaidCustomersCount.ToString();
        lnkBPUnpaidCustomer.Text = eventMetricsViewData.UnPaidCount.ToString();
        lnkBPActCustomer.Text = eventMetricsViewData.AttendedCustomersCount.ToString();
        lnkBPCardPaymentCount.Text = eventMetricsViewData.ChargeCardCount.ToString();
        lnkBPCashPayment.Text = eventMetricsViewData.CashCount.ToString();
        lnkBPCheckPayment.Text = eventMetricsViewData.CheckCount.ToString();
        lnkBPeCheckPayment.Text = eventMetricsViewData.ECheckCount.ToString();

        spPhoneCount.InnerText = decimal.Round(eventMetricsViewData.PhonePayments, 2).ToString();
        lnkPhoneCount.Text = eventMetricsViewData.PhonePaymentCount.ToString();
        spINetCount.InnerText = decimal.Round(eventMetricsViewData.InternetPayments, 2).ToString();
        lnkInetCount.Text = eventMetricsViewData.InternetPaymentCount.ToString();
        spOnsiteCount.InnerText = decimal.Round(eventMetricsViewData.OnsitePayments, 2).ToString();
        lnkOnsiteCount.Text = eventMetricsViewData.OnsitePaymentCount.ToString();
        spUpgradeCount.InnerText = decimal.Round(eventMetricsViewData.UpGradePayments, 2).ToString();
        lnkUpgradeCount.Text = eventMetricsViewData.UpGradePaymentCount.ToString();
        spDowngradeCount.InnerText = Convert.ToString(decimal.Round((eventMetricsViewData.DownGradePayments < 0 ? eventMetricsViewData.DownGradePayments * -1 : eventMetricsViewData.DownGradePayments), 2));
        lnkDowngradeCount.Text = eventMetricsViewData.DownGradePaymentCount.ToString();

        //TODO: Need to filter customers paid by GC
        // added giftCertificate
        _spnGcPaymentTotal.InnerText = decimal.Round(eventMetricsViewData.GiftCertificateRevenue, 2).ToString();
        _lnkGcPaymentCount.Text = eventMetricsViewData.GiftCertificateCount.ToString();

        sphostname.InnerText = eventHostViewData.OrganizationName;
        agmap.HRef = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" + eventHostViewData.StreetAddressLine1 + "," + eventHostViewData.City + "," + eventHostViewData.State + "," + eventHostViewData.Zip + "&ie=UTF8&z=16";

        string poddetailstring = "N/A";

        foreach (EEventPod objeventpod in eventPodDetails.EventPod)
        {
            if (poddetailstring == "N/A")
            {
                poddetailstring = "";
            }

            string strpodteam = "";
            string strpoddescription = "";
            string vandescription = "";

            strpoddescription = "<p class='roundarrowpopuprow_ecl'>Processing Capacity of " + objeventpod.Pod.PodProcessingCapacity.ToString() + " </p>";
            vandescription = "<p class='roundarrowpopuprow_ecl'> Vehicle: " + objeventpod.Pod.Van.Name + "," + objeventpod.Pod.Van.Make + " (" + objeventpod.Pod.Van.VIN + ") </p>";

            foreach (EFranchiseeFranchiseeUser objfranchiseefruser in objeventpod.Pod.TeamIDList)
            {
                strpodteam += "&bull; &nbsp;" + objfranchiseefruser.FranchiseeUser.User.FirstName + " " + objfranchiseefruser.FranchiseeUser.User.MiddleName + " " + objfranchiseefruser.FranchiseeUser.User.LastName + "(" + objfranchiseefruser.RoleType + ")(" + objfranchiseefruser.FranchiseeFranchiseeUserID + ")<br />";
            }

            string currentpod = "<div class='maindiv_roundmbox_ecl'><div class='innerdiv_roundmbox'><div class='lefttop_roundmbox'><img src='/App/Images/specer.gif' width='254' height='15' /></div><div class='midinner_roundmbox'>";
            currentpod += "<p class='headertxt_roundmbox_ecl'>Pod Description</p><div class='divinnerbody_mbox'>";
            currentpod += strpoddescription;
            currentpod += "<p><img src='/App/Images/specer.gif' width='220' height='5' /></p>" + vandescription;
            currentpod += "<p><img src='/App/Images/specer.gif' width='220' height='5' /></p><p class='roundarrowpopuprow_ecl'><u>Team Detail</u></p>";
            currentpod += "<p><img src='/App/Images/specer.gif' width='220' height='5' /></p><div class='roundarrowpopuprow_ecl'>";
            currentpod += strpodteam + "</div></div></div><div class='roundcornerbot_roundmbox'>";
            currentpod += "<img src='/App/Images/specer.gif' width='254' height='15' /></div></div></div>";

            poddetailstring = poddetailstring + objeventpod.Pod.Name + "<a href='javascript:void(0)' class='apd'> (More Info) <span class='tooltip'> " + currentpod + " </span> </a>";

            aConfigureTeam.HRef = "javascript:OpenPopUp('/App/Franchisee/Technician/TeamConfiguration.aspx?EventID=" + eventHostViewData.EventId + "&PodID=" + objeventpod.Pod.PodID + "&EventDate=" + eventHostViewData.EventDate.ToShortDateString() + "');";

        }
        sppoddetail.InnerHtml = poddetailstring;

        // BEGIN added upgrade/downgrade story(#7548)
        int totalCustomer = (eventMetricsViewData.PaidCustomersCount + eventMetricsViewData.UnPaidCount) - eventMetricsViewData.NoShowCustomersCount;

        _lnkAverageCustomers.Text = totalCustomer > 0 ? totalCustomer.ToString() : "0";

        _spnAverageRevenueAmount.InnerHtml = totalCustomer > 0
                                        ? decimal.Round((totalRevenue / totalCustomer), 2).ToString()
                                        : "0.00";

        _spnUnpaidTotal.InnerHtml = decimal.Round(eventMetricsViewData.UnPaidExcluedeNoShowRevenue, 2).ToString();
        _lnkUnpaidCount.Text = eventMetricsViewData.UnPaidExcluedeNoShowCount.ToString();

        // END added upgrade/downgrade story(#7548)

        // Added HipaaStatus
        decimal _HipaapercentageDecimal;

        if (eventMetricsViewData.HipaaSignedCount > 0)
        {

            _HipaapercentageDecimal = Math.Round(
                Convert.ToDecimal(eventMetricsViewData.HipaaSignedCount) /
                Convert.ToDecimal(eventMetricsViewData.HipaaSignedCount + eventMetricsViewData.HipaaUnSignedCount) * 100,
                2);

            if (_HipaapercentageDecimal > 0)
                _spnHippaStatus.InnerText = Convert.ToString(_HipaapercentageDecimal) + "% " + "(" +
                                            eventMetricsViewData.HipaaSignedCount + "/" +
                                            (eventMetricsViewData.HipaaSignedCount + eventMetricsViewData.HipaaUnSignedCount) + ")";
        }
        else
        {
            _spnHippaStatus.InnerText = "0% (0/0)";
        }
    }

    protected void lnkCustomerFilter_Click(object sender, EventArgs e)
    {
        if (LinkCountClick != null)
            LinkCountClick(sender, e);
    }

    protected void ddlfiltergrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LinkCountClick != null)
            LinkCountClick(sender, e);
    }

}
