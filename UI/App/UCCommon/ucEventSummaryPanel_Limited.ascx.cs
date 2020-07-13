using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Other;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using System.Linq;

public partial class App_UCCommon_ucEventSummaryPanel_Limited : System.Web.UI.UserControl
{
    public delegate void delLinkCountClick(object sender, EventArgs e);
    public event delLinkCountClick LinkCountClick;

    public string PackageFormationString { set { sppackagecountstring.InnerHtml = value; } }
    public string TestFormationString { set { _testNameSpan.InnerHtml = value; } }
    private string _roleDisplayName;

    protected string EmrNotes = "";

    protected string RoleDisplayName
    {
        get
        {
            if (string.IsNullOrEmpty(_roleDisplayName))
            {
                var roleRepository = IoC.Resolve<IRoleRepository>();
                var roles = roleRepository.GetAll();
                _roleDisplayName = roles.Where(r => r.Id == (int)Roles.SalesRep).Select(r => r.DisplayName).SingleOrDefault();

            }
            return _roleDisplayName;
        }
    }

    public long EventId
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["EventID"]))
            {
                long eventId = 0;
                if (Int64.TryParse(Request.QueryString["EventID"], out eventId))
                {
                    return eventId;
                }
            }
            return 0;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (EventId > 0)
            {
                aDepositeSlip.HRef = "javascript:popupmenu3('/App/Franchisee/Technician/GenerateDepositeSlip.aspx?EventID=" + EventId + "&PrintDepositSlip=Yes" + "',520,620)";

            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventid"></param>
    public void LoadEventSummaryPanel(EventMetricsViewData eventMetricsViewData, EventHostViewData eventHostViewData, EEvent eventPodDetails)
    {

        if (eventMetricsViewData == null || eventHostViewData == null)
            return;

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        aPrintBulkResult.HRef = "javascript:showPopup('" + eventHostViewData.EventId + "');";

        aExistingCustomer.HRef = ResolveUrl("~/App/Common/SearchCustomer.aspx?Eventid=" + eventHostViewData.EventId);

        ancopenpopupaddslot.HRef = "/App/Common/AddSlot.aspx?EventDate=" + eventHostViewData.EventDate.ToShortDateString() + "&EventId=" + eventHostViewData.EventId + "&keepThis=true&TB_iframe=true&width=295&height=140&modal=true";

        if (IoC.Resolve<ISettings>().ShowPartnerRelease)
            aEndOfDay.HRef = "javascript:popupmenu4('/Scheduling/Event/EndofDay?id=" + eventHostViewData.EventId + "',1100,900)";

        updateHostRankingAnchor.HRef = "javascript:popupmenu3('/App/Franchisee/Technician/EndOfDayProcess.aspx?HostRanking=true&EventID=" + eventHostViewData.EventId + "&EventName=" + eventHostViewData.Name.Replace("'", "\\'") + "',550,620)";

        Session["EventID"] = eventHostViewData.EventId;
        ViewState["EventDate"] = eventHostViewData.EventDate;
        ViewState["EventName"] = eventHostViewData.Name;

        var notes = IoC.Resolve<IEventRepository>().GetEmrNotes(eventHostViewData.EventId);
        if (notes != null) EmrNotes = notes.Text;

        Session["EventDate"] = eventHostViewData.EventDate;
        Session["EventName"] = eventHostViewData.Name;

        if (Convert.ToDateTime(eventHostViewData.EventDate).Date > DateTime.Now.Date)
        {
            spResultStatus.Visible = false;
            spEndofDay.Style[System.Web.UI.HtmlTextWriterStyle.Display] = "none";
        }
        else
        {
            aResultStatus.HRef = "/Medical/Results/ResultStatusList?EventId=" + eventHostViewData.EventId;
        }

        speventdate.InnerText = Convert.ToDateTime(eventHostViewData.EventDate).ToShortDateString();
        speventloc.InnerText = CommonCode.AddressSingleLine(eventHostViewData.StreetAddressLine1, eventHostViewData.StreetAddressLine2, eventHostViewData.City, eventHostViewData.State, eventHostViewData.Zip);
        sphostphone.InnerText = objCommonCode.FormatPhoneNumberGet(eventPodDetails.Host.PhoneOffice);

        var hostFacilityRankingService = IoC.Resolve<IHostFacilityRankingService>();
        var hostFacilityRankingbyHsc = hostFacilityRankingService.GetHostFacilityRankingByHSC(eventHostViewData.HostId);
        if (hostFacilityRankingbyHsc != null)
        {
            spPlugPoints.InnerText = hostFacilityRankingbyHsc.NumberOfPlugPoints != null ? hostFacilityRankingbyHsc.NumberOfPlugPoints.Value.ToString() : "";
            spRoomSize.InnerText = hostFacilityRankingbyHsc.RoomSize;
            spInternetAccess.InnerText = hostFacilityRankingbyHsc.InternetAccess != null ? hostFacilityRankingbyHsc.InternetAccess.Name : "";
            spHostRanking.InnerText = hostFacilityRankingbyHsc.Ranking != null ? hostFacilityRankingbyHsc.Ranking.Name : "";
            spRoomNeedCleared.InnerText = hostFacilityRankingbyHsc.RoomNeedsCleared != null ? (hostFacilityRankingbyHsc.RoomNeedsCleared.Value ? "Yes" : "No") : "";
        }

        ViewState["HostName"] = eventHostViewData.OrganizationName;
        ViewState["HostAddress"] = eventHostViewData.StreetAddressLine1;
        ViewState["HostCityStateZip"] = eventHostViewData.City + " " + eventHostViewData.State + " " + eventHostViewData.Zip;

        Session["HostName"] = eventHostViewData.OrganizationName;
        Session["HostAddress"] = eventHostViewData.StreetAddressLine1;
        Session["HostCityStateZip"] = eventHostViewData.City + " " + eventHostViewData.State + " " + eventHostViewData.Zip;

        spEIPdeposit.InnerHtml = decimal.Round(eventMetricsViewData.CashRevenue + eventMetricsViewData.CheckRevenue, 2).ToString();

        speventid.InnerHtml = eventHostViewData.EventId.ToString();

        spcashpayment.InnerHtml = decimal.Round(eventMetricsViewData.CashRevenue, 2).ToString();
        spcardpayment.InnerHtml = decimal.Round(eventMetricsViewData.ChargeCardRevenue, 2).ToString();
        spchequepayment.InnerHtml = decimal.Round(eventMetricsViewData.CheckRevenue, 2).ToString();
        spBPeCheckPayment.InnerHtml = decimal.Round(eventMetricsViewData.ECheckRevenue, 2).ToString();
        decimal totalRevenue = eventMetricsViewData.ChargeCardRevenue + eventMetricsViewData.CheckRevenue +
                            eventMetricsViewData.CashRevenue + eventMetricsViewData.ECheckRevenue +
                            eventMetricsViewData.GiftCertificateRevenue +
                            eventMetricsViewData.UnPaidExcluedeNoShowRevenue;
        sptotalpayment.InnerHtml = decimal.Round(totalRevenue, 2).ToString();

        ancregistered.Text = eventMetricsViewData.RegisteredCustomersCount.ToString();
        spncancelled.InnerHtml = "<a href=\"javascript:void(0)\" onclick=\"showCancelledCustomers();\">" + eventMetricsViewData.CancelledCustomersCount.ToString() + "</a>";
        ancnoshow.Text = eventMetricsViewData.NoShowCustomersCount.ToString();
        ancpaid.Text = eventMetricsViewData.PaidCustomersCount.ToString();
        ancunpaid.Text = eventMetricsViewData.UnPaidCount.ToString();
        ancactual.Text = eventMetricsViewData.AttendedCustomersCount.ToString();
        anccardpaymentcount.Text = eventMetricsViewData.ChargeCardCount.ToString();
        anccashpaymentcount.Text = eventMetricsViewData.CashCount.ToString();
        ancchequepaymentcount.Text = eventMetricsViewData.CheckCount.ToString();
        lnkBPeCheckPayment.Text = eventMetricsViewData.ECheckCount.ToString();
        if (eventPodDetails.FranchiseeFranchiseeUser != null)
        {
            spnSalesrepname.InnerHtml = eventPodDetails.FranchiseeFranchiseeUser.FranchiseeUser.User.FirstName + " " + eventPodDetails.FranchiseeFranchiseeUser.FranchiseeUser.User.LastName;
            if (eventPodDetails.FranchiseeFranchiseeUser.FranchiseeUser.User.PhoneHome.Trim().Length > 0)
                spnContactInfo.InnerHtml = objCommonCode.FormatPhoneNumberGet(eventPodDetails.FranchiseeFranchiseeUser.FranchiseeUser.User.PhoneHome);
            else
                spnContactInfo.InnerHtml = eventPodDetails.FranchiseeFranchiseeUser.FranchiseeUser.User.EMail1;
        }
        // BEGIN added upgrade/downgrade story(#7548)
        spUpgradeCount.InnerHtml = decimal.Round(eventMetricsViewData.UpGradePayments, 2).ToString();
        lnkUpgradeCount.Text = eventMetricsViewData.UpGradePaymentCount.ToString();
        spDowngradeCount.InnerHtml = Convert.ToString(decimal.Round(eventMetricsViewData.DownGradePayments < 0 ? eventMetricsViewData.DownGradePayments * -1 : eventMetricsViewData.DownGradePayments, 2));
        lnkDowngradeCount.Text = eventMetricsViewData.DownGradePaymentCount.ToString();
        // END added upgrade/downgrade story(#7548)

        // BEGIN added upgrade/downgrade story(#7548)
        //spUpgradeCount.InnerHtml = eventMetricsViewData.UpGradePayments.ToString();
        //lnkUpgradeCount.Text = eventMetricsViewData.UpGradePaymentCount.ToString();
        //spDowngradeCount.InnerHtml = Convert.ToString(eventMetricsViewData.DownGradePayments < 0 ? eventMetricsViewData.DownGradePayments * -1 : eventMetricsViewData.DownGradePayments);
        //lnkDowngradeCount.Text = eventMetricsViewData.DownGradePaymentCount.ToString();

        int totalCustomer = (eventMetricsViewData.PaidCustomersCount + eventMetricsViewData.UnPaidCount) - eventMetricsViewData.NoShowCustomersCount;

        _spnAverageRevenueCount.InnerText = totalCustomer > 0
                                        ? decimal.Round((totalRevenue / totalCustomer), 2).ToString()
                                        : "0.00";
        _lnkAverageCustomers.Text = totalCustomer > 0 ? totalCustomer.ToString() : "0";

        _spnUnpaidTotal.InnerText = decimal.Round(eventMetricsViewData.UnPaidExcluedeNoShowRevenue, 2).ToString();
        _lnkUnpaidCount.Text = eventMetricsViewData.UnPaidExcluedeNoShowCount.ToString();

        // added Onsite for Technician 
        spOnsiteCount.InnerText = decimal.Round(eventMetricsViewData.OnsitePayments, 2).ToString();
        lnkOnsiteCount.Text = eventMetricsViewData.OnsitePaymentCount.ToString();

        // END added upgrade/downgrade story(#7548)

        //TODO: Need to filter customers paid by GC
        // added giftCertificate
        _spnGcPaymentTotal.InnerText = decimal.Round(eventMetricsViewData.GiftCertificateRevenue, 2).ToString();
        _lnkGcPaymentCount.Text = eventMetricsViewData.GiftCertificateCount.ToString();

        // Added HipaaStatus
        decimal _HipaapercentageDecimal;

        if (eventMetricsViewData.HipaaSignedCount > 0)
        {
            _HipaapercentageDecimal = Math.Round(
                Convert.ToDecimal(eventMetricsViewData.HipaaSignedCount) /
                Convert.ToDecimal(eventMetricsViewData.HipaaSignedCount + eventMetricsViewData.HipaaUnSignedCount) * 100,
                2);

            _spnHippaStatus.InnerHtml = Convert.ToString(_HipaapercentageDecimal) + "% " + "(" +
                                        eventMetricsViewData.HipaaSignedCount + "/" +
                                        (eventMetricsViewData.HipaaSignedCount + eventMetricsViewData.HipaaUnSignedCount) + ")";
        }
        else
        {
            _spnHippaStatus.InnerHtml = "0% (0/0)";
        }

        txtEventNotes.Text = eventHostViewData.TechnicianNotes;

        sphostname.InnerHtml = eventHostViewData.OrganizationName;
        sphostname.InnerHtml = eventHostViewData.OrganizationName;

        string googleMapLink = CommonCode.GetGoogleMapAddress(eventHostViewData.StreetAddressLine1, eventHostViewData.City, eventHostViewData.State, eventHostViewData.Zip, eventHostViewData.Latitude + "," + eventHostViewData.Longitude, eventHostViewData.UseLatitudeAndLongitudeForMapping);
        agmap.HRef = googleMapLink;
        //agmap.HRef = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" + objevent.Host.Address.Address1 + "," + objevent.Host.Address.City + "," + objevent.Host.Address.State + "," + objevent.Host.Address.Zip + "&ie=UTF8&z=16";


        // Set Google Address Verification Status
        if (eventHostViewData.GoogleAddressVerifiedBy.HasValue)
        {
            string googleAddressVerified = GetAddressVerifiedUser(eventHostViewData.GoogleAddressVerifiedBy.Value);
            _addressVerifiedStatus.InnerHtml = googleAddressVerified;
        }
        else
        {
            _addressVerifiedStatus.InnerHtml = CommonCode.GetGoogleAddressNotVerifiedJtip();
        }

        string poddetailstring = "N/A";

        foreach (EEventPod objeventpod in eventPodDetails.EventPod)
        {
            if (poddetailstring == "N/A")
            {
                poddetailstring = "";
            }

            string strpodteam = string.Empty;
            string strpoddescription = string.Empty;
            string vandescription = string.Empty;
            strpoddescription = "<p class='prow'>Processing Capacity of " + objeventpod.Pod.PodProcessingCapacity.ToString() + " </p>";
            vandescription = "<p class='prow'> Vehicle: " + objeventpod.Pod.Van.Name + "," + objeventpod.Pod.Van.Make + " (" + objeventpod.Pod.Van.VIN + ") </p>";
            foreach (EFranchiseeFranchiseeUser objfranchiseefruser in objeventpod.Pod.TeamIDList)
            {
                strpodteam += "&bull; &nbsp;" + objfranchiseefruser.FranchiseeUser.User.FirstName + " " + objfranchiseefruser.FranchiseeUser.User.MiddleName + " " + objfranchiseefruser.FranchiseeUser.User.LastName + "(" + objfranchiseefruser.RoleType + ")(" + objfranchiseefruser.FranchiseeFranchiseeUserID + ")<br />";
            }
            string currentpod = "<div class='maindiv_roundmbox_ecl'>" + strpoddescription;
            currentpod += vandescription;
            currentpod += "<p class='prow'><u>Team Detail</u></p>";
            currentpod += "<p class='prow'>" + strpodteam + "</p></div>";

            poddetailstring = poddetailstring + objeventpod.Pod.Name + "<a href='javascript:void(0)' class='apd jtipLocal' title=\"Pod Details|" + currentpod + "\"> (More Info) </a>";

        }
        sppoddetail.InnerHtml = poddetailstring;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCustomerFilter_Click(object sender, EventArgs e)
    {
        if (LinkCountClick != null)
            LinkCountClick(sender, e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlfiltergrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LinkCountClick != null)
            LinkCountClick(sender, e);
    }

    private string GetAddressVerifiedUser(long organizationRoleUserId)
    {
        string userName = string.Empty;
        if (organizationRoleUserId > 0)
        {
            IOrganizationRoleUserRepository organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var organizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId);
            if (organizationRoleUser != null)
            {
                IUserRepository<Customer> userRepository =
                       new UserRepository<Customer>();
                var user = userRepository.GetUser(organizationRoleUser.UserId);
                if (user != null)
                {
                    userName = "Address Verified By " + user.Name.FullName;
                }
            }
        }
        return userName;
    }

}
