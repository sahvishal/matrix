using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Lib;
using Falcon.DataAccess.Master;
using EContact = Falcon.Entity.Other.EContact;
using EContactCall = Falcon.Entity.Other.EContactCall;
using EContactMeeting = Falcon.Entity.Other.EContactMeeting;
using EEvent = Falcon.Entity.Other.EEvent;
using EProspect = Falcon.Entity.Other.EProspect;
using ETask = Falcon.Entity.Other.ETask;
using Falcon.App.Core.Enum;
using System.Linq;
using Falcon.App.Infrastructure.Service;

public partial class App_UCCommon_UCProspectDetails : UserControl
{
    string strProspect = string.Empty;
    private string _sortColumn = string.Empty;
    private string _sortOrder = string.Empty;
    private int _pageSize = 10;
    private int _pageIndex = 1;
    private long _totalRecordsEventOnHost;
    private long _totalRecordsEventOnHostZip;
    private long _totalRecordsEventOnHostDistance;
    private readonly MasterDAL masterDal = new MasterDAL();
    protected string HostName
    {
        get
        {
            if (ViewState["HostName"] == null) ViewState["HostName"] = "";
            return Convert.ToString(ViewState["HostName"]);
        }
        set { ViewState["HostName"] = value; }
    }
    protected string HostZipCode
    {
        get
        {
            if (ViewState["HostZipCode"] == null) ViewState["HostZipCode"] = "";
            return Convert.ToString(ViewState["HostZipCode"]);
        }
        set { ViewState["HostZipCode"] = value; }
    }

    protected string HostDistanceMiles
    {
        get
        {
            if (ViewState["HostDistanceMiles"] == null) ViewState["HostDistanceMiles"] = 0;
            return Convert.ToString(ViewState["HostDistanceMiles"]);
        }
        set { ViewState["HostDistanceMiles"] = value; }
    }

    public Roles CurrentRole = (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request["Action"] != null && Request["Action"] != "")
        {
            if (Request["Action"] != null && Request["Action"] != "" && Request["Type"] != null && Request["Type"] != "")
            {
                // prospect
                if (Request["Action"].Equals("Alert"))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "jscodealertmessage",
                                                            Request["Type"].Equals("Prospect")
                                                                ? "alert('Prospect details updated successfully!');"
                                                                : "alert('Host details updated successfully!');", true);
                }
            }
        }

        if (!IsPostBack)
        {
            ViewState["SortExp"] = "StartDate";
            ViewState["SortExpContacts"] = "Name";

            ViewState["SortExpEventHost"] = "EventDate";
            ViewState["SortExpEventHostZip"] = "EventDate";
            ViewState["SortExpEventHostDistance"] = "EventDate";

            ViewState["SortDir"] = SortDirection.Descending;
            ViewState["SortDirEventHost"] = "DESC";
            ViewState["SortDirEventHostZip"] = "DESC";
            ViewState["SortDirEventHostDistance"] = "DESC";

            if (Request.UrlReferrer != null)
            {
                ViewState["ReferedURL"] = Request.UrlReferrer.PathAndQuery;
            }
            // set withIn X miles
            var otherDal = new OtherDAL();
            HostDistanceMiles = Convert.ToString(otherDal.GetConfigurationValue("HostEventDistance"));

            // Fill labels
            FillLabels();

            if (Request.QueryString["ProspectID"] != null)
            {
                long ProspectID = Convert.ToInt64(Request.QueryString["ProspectID"]);
                hfProsectID.Value = Convert.ToString(ProspectID);

                if (CurrentRole == Roles.FranchiseeAdmin)
                {
                    //spnSeperator.Style.Add(HtmlTextWriterStyle.Display, "none");
                    spnConvertToHost.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                LoadGrids(ProspectID);
            }
        }
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "jscode_tabSelection", "sel_caption('" + hfheader.Value + "');", true);
        switch (hfheader.Value)
        {
            case "divHeaderCall":
                tbpnlContainer.ActiveTab = pnlCall;
                break;
            case "divHeaderTask":
                tbpnlContainer.ActiveTab = pnlTask;
                break;
            case "divHeaderMeeting":
                tbpnlContainer.ActiveTab = pnlMy;
                break;
            case "divHeaderNotes":
                tbpnlContainer.ActiveTab = pnlNotes;
                break;
            case "divHeaderAll":
                tbpnlContainer.ActiveTab = pnlAll;
                break;
            default:
                return;
        }
        // Handle paging.
        if (Page.IsPostBack)
        {
            string eventArg = Request["__EVENTARGUMENT"];
            if (eventArg.Equals("PageChangeEventHost"))
            {
                BindEventOnPageChange(1, "", "");
            }
            else if (eventArg.Equals("PageChangeEventHostZip"))
            {
                BindEventOnPageChange(2, "", "");
            }
            else if (eventArg.Equals("PageChangeEventHostDistance"))
            {
                BindEventOnPageChange(3, "", "");
            }
        }
    }

    /// <summary>
    /// Fill Labels for Prospect/Host
    /// </summary>
    private void FillLabels()
    {
        if (Request["Type"] == null) return;
        if (Request["Type"] == "Prospect")
        {
            spnTitle.InnerText = "Prospect Details";
            spnType.InnerText = "Prospect Type:";
            lnkProspect.Text = "Edit Prospect";

            spnConvertToHost.Style.Add(HtmlTextWriterStyle.Display, CurrentRole == Roles.SalesRep ? "block" : "none");
        }
        else
        {
            spnTitle.InnerText = "Host Details";
            spnType.InnerText = "Host Type:";
            lnkProspect.Text = "Edit Host";
            // Display the event
            divEvents.Style.Add(HtmlTextWriterStyle.Display, "block");
            spAddEvent.Style[HtmlTextWriterStyle.Display] = "block";
            spnConvertToHost.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
    }

    #region Prospect
    private void GetProspectDetails(EProspect prospect)
    {

        if (prospect == null) return;

        // format phone no.
        var objCommonCode = new CommonCode();

        spProspectName1.InnerText = prospect.OrganizationName;
        spProspectName2.InnerText = prospect.OrganizationName;
        HostName = prospect.OrganizationName;
        string strAddress = string.Empty;

        // format address 
        strAddress = CommonCode.AddressSingleLine(prospect.Address.Address1, prospect.Address.Address2, prospect.Address.City, prospect.Address.State, prospect.Address.Zip);
        spAddress.InnerText = strAddress;
        HostZipCode = prospect.Address.Zip;
        _fax.InnerText = !string.IsNullOrEmpty(prospect.Fax) ? objCommonCode.FormatPhoneNumberGet(prospect.Fax) : "-N/A-";
        _salesRep.InnerText = !string.IsNullOrEmpty(prospect.SalesRep) ? prospect.SalesRep : "-N/A-";

        GetFacilityDataAndRating(prospect.ProspectID);
        GetHostImages(prospect.ProspectID);

        // Set Google Address Verification Status
        if (!string.IsNullOrEmpty(Request["Type"]) && Request["Type"] == "Host")
        {
            if (!string.IsNullOrEmpty(prospect.Address.GoogleAddressVerifiedBy))
            {
                _addressVerifiedStatus.InnerHtml = "<a href=\"#\" class=\"jtip\" title=" + "'Google Map Address Verification|Address Verified By " + HttpUtility.HtmlEncode(prospect.Address.GoogleAddressVerifiedBy) + "'" + "><img src=\"/App/Images/info-icon.gif\" alt=\"Info\" title=\"Info\"/></a>";
            }
            else
            {
                _addressVerifiedStatus.InnerHtml = CommonCode.GetGoogleAddressNotVerifiedJtipHostDetails();
            }
        }
        else addressVerification.Style.Add(HtmlTextWriterStyle.Display, "none");

        // Mailing Address
        if (prospect.AddressMailing != null)
        {
            _mailingAddress.InnerText = CommonCode.AddressSingleLine(prospect.AddressMailing.Address1, prospect.AddressMailing.Address2, prospect.AddressMailing.City, prospect.AddressMailing.State, prospect.AddressMailing.Zip);
        }
        else _mailingAddress.InnerText = "-N/A-";


        spURL.Text = prospect.WebSite.Length > 0 ? prospect.WebSite : "-N/A-";
        if (prospect.PhoneCell.Length > 0)
        {
            spPhone.InnerText = objCommonCode.FormatPhoneNumberGet(prospect.PhoneCell);
        }
        else if (prospect.PhoneOffice.Length > 0)
        {
            spPhone.InnerText = objCommonCode.FormatPhoneNumberGet(prospect.PhoneOffice);
        }
        else if (prospect.PhoneOther.Length > 0)
        {
            spPhone.InnerText = objCommonCode.FormatPhoneNumberGet(prospect.PhoneOther);
        }
        else
        {
            spPhone.InnerText = "-N/A-";
        }

        string email = "-N/A-";
        string spnTemp = "-N/A-";
        if (prospect.EMailID.Length > 0)
        {
            email = prospect.EMailID;
        }

        spOther.InnerHtml = (prospect.EMailID.Length > 0) ? HttpUtility.HtmlEncode(email) : "-N/A-";

        // Prospect type
        spnProspectType.InnerHtml = !string.IsNullOrEmpty(prospect.ProspectType.Name) ? HttpUtility.HtmlEncode(prospect.ProspectType.Name) : "-N/A-";
        // Members/Employees
        spnMembersEmployees.InnerHtml = prospect.ActualMembership > 0 ? HttpUtility.HtmlEncode(prospect.ActualMembership.ToString()) : "-N/A-";
        // Actual Attendence
        spnAttendence.InnerHtml = prospect.Attendance > 0 ? HttpUtility.HtmlEncode(prospect.Attendance.ToString()) : "-N/A-";
        // Facilities Fee
        if (!string.IsNullOrEmpty(prospect.ProspectDetails.FacilitiesFee))
        {
            spnFacilitiesFee.InnerText = "Yes";
            string facilitiesFeeDetails = string.Empty;
            facilitiesFeeDetails = "(<a href=\"#\" class=\"jtip\" title='Fee Details|";
            facilitiesFeeDetails = facilitiesFeeDetails + "<table>";
            facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Room Rent:</strong></td><td>$" + HttpUtility.HtmlEncode(prospect.ProspectDetails.FacilitiesFee) + "</td></tr>";

            //TODO: Need to map Payment Method to enum
            if (!string.IsNullOrEmpty(prospect.ProspectDetails.PaymentMethod))
            {
                if (prospect.ProspectDetails.PaymentMethod.Trim() == "1")
                {
                    facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Payment Method:</strong></td><td>" + HttpUtility.HtmlEncode(HostPaymentType.Check.ToString()) + "</td></tr>";
                }
                else if (prospect.ProspectDetails.PaymentMethod.Trim() == "2")
                {
                    facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Payment Method:</strong></td><td>" + HttpUtility.HtmlEncode(HostPaymentType.CreditCard.ToString()) + "</td></tr>";
                }
                else
                {
                    facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Payment Method:</strong></td><td>" + HttpUtility.HtmlEncode(HostPaymentType.CreditCard.ToString()) + "/" + HttpUtility.HtmlEncode(HostPaymentType.Check.ToString()) + "</td></tr>";
                }
            }
            else
            {
                facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Payment Method:</strong></td><td>-N/A-</td></tr>";
            }
            if (prospect.ProspectDetails.DepositsRequire == 1)
            {
                facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Deposits Required:</strong></td><td>Yes</td></tr>";
                facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Deposits Amount:</strong></td><td>$" + HttpUtility.HtmlEncode(prospect.ProspectDetails.DepositsAmount.ToString()) + "</td></tr>";
            }
            else facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Deposits Required:</strong></td><td>-N/A-</td></tr>";

            if (!string.IsNullOrEmpty(prospect.TaxIdNumber))
            {
                facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>TaxId Number:</strong></td><td>" + HttpUtility.HtmlEncode(prospect.TaxIdNumber) + "</td></tr>";
            }
            else facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>TaxId Number:</strong></td><td>-N/A-</td></tr>";

            // close table
            facilitiesFeeDetails = facilitiesFeeDetails + "</table>'";
            facilitiesFeeDetails = facilitiesFeeDetails + ">View Details</a>)";
            _facilitiesFeeDetails.InnerHtml = facilitiesFeeDetails;
            _facilitiesFeeDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            spnFacilitiesFee.InnerText = "-N/A-";
            _facilitiesFeeDetails.Style.Add(HtmlTextWriterStyle.Display, "none");

        }

        // Will Promote
        if (prospect.WillCommunicate >= 0)
        {
            switch (prospect.WillCommunicate)
            {
                case 0:
                    spnTemp = "No";
                    break;
                case 1:
                    spnTemp = "Yes";
                    break;
                case 2:
                    spnTemp = "Unknown";
                    break;
                default:
                    spnTemp = "-N/A-";
                    break;
            }
            spnWillPromote.InnerText = spnTemp;
            spnTemp = "";
        }
        // Hosted In Past
        _hostedInPastDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
        if (prospect.ProspectDetails.HostedInPast == 1)
        {
            hostInPastWith.InnerText = "Yes";
            _hostedInPastDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
            if (!string.IsNullOrEmpty(prospect.ProspectDetails.HostedInPastWith))
            {
                _hostedInPastDetails.InnerHtml = "(<a href=\"#\" class=\"jtip\" title='Competitors|" + HttpUtility.HtmlEncode(prospect.ProspectDetails.HostedInPastWith) + "'" + ">View Details</a>)";
            }
            else _hostedInPastDetails.InnerHtml = "(<a href=\"#\" class=\"jtip\" title='Competitors|Competitors : -N/A-'>View Details</a>)";
        }
        else
        {
            _hostedInPastDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
            if (prospect.ProspectDetails.HostedInPast == 0) hostInPastWith.InnerText = "No";
            else if (prospect.ProspectDetails.HostedInPast == 2) hostInPastWith.InnerText = "Unknown";
        }
        // Viable Host Site
        if (prospect.ProspectDetails.ViableHostSite < 0) return;
        switch (prospect.ProspectDetails.ViableHostSite)
        {
            case 0:
                spnTemp = "No";
                break;
            case 1:
                spnTemp = "Yes";
                break;
            case 2:
                spnTemp = "Unknown";
                break;
            default:
                spnTemp = "-N/A-";
                break;
        }
        spnViableHostSite.InnerText = spnTemp;
        spnTemp = "";
    }

    private void GetFacilityDataAndRating(long id)
    {
        IHostFacilityRankingService hostFacilityRankingService = new HostFacilityRankingService();

        var hostFacilityRankingbyHsc = hostFacilityRankingService.GetHostFacilityRankingByHSC(id);
        var hostFacilityRankingbyFranchisee = hostFacilityRankingService.GetHostFacilityRankingByFranchisee(id);

        if (hostFacilityRankingbyHsc == null && hostFacilityRankingbyFranchisee == null)
        {
            HostFacilityDataDiv.Style[HtmlTextWriterStyle.Display] = "none";
            return;
        }

        if (hostFacilityRankingbyHsc != null)
        {
            NumberofPlugPointsSpan.InnerText = hostFacilityRankingbyHsc.NumberOfPlugPoints != null ? hostFacilityRankingbyHsc.NumberOfPlugPoints.Value.ToString() : "";
            HostRankingByHsc.InnerText = hostFacilityRankingbyHsc.Ranking != null ? hostFacilityRankingbyHsc.Ranking.Name : "";
            RoomNeedClearedSpan.InnerText = hostFacilityRankingbyHsc.RoomNeedsCleared != null ? (hostFacilityRankingbyHsc.RoomNeedsCleared.Value ? "Yes" : "No") : "";
            RoomSizeSpan.InnerText = hostFacilityRankingbyHsc.RoomSize;
            InternetAccessSpan.InnerText = hostFacilityRankingbyHsc.InternetAccess != null ? hostFacilityRankingbyHsc.InternetAccess.Name : "";
        }

        if (hostFacilityRankingbyFranchisee != null)
        {
            HostRankingbyFranchiseeSpan.InnerText = hostFacilityRankingbyFranchisee.Ranking != null ? HttpUtility.HtmlEncode(hostFacilityRankingbyFranchisee.Ranking.Name) : "";
            CommentsbyFranchiseeSpan.InnerText = hostFacilityRankingbyFranchisee.Notes;
        }
        else
        {
            FranchiseeRatingNotAvailSpan.Style[HtmlTextWriterStyle.Display] = "block";
        }
    }

    private void GetHostImages(long id)
    {
        IHostRepository _hostRepository = new HostRepository();
        var hostImages = _hostRepository.GetHostImages(id);

        string imageHtml = "";
        var hostImagesforHsc = hostImages.FindAll(hostImage => hostImage.UploadedBy.RoleId == (long)(Roles.SalesRep) || GetParentRoleIdByRoleId(hostImage.UploadedBy.RoleId) == (long)(Roles.SalesRep));

        if (hostImagesforHsc != null && hostImagesforHsc.Count > 0)
        {
            hostImagesforHsc.ForEach(hostImage => imageHtml += "<span style='width:120px; float:left; margin:5px;'> " +
                    "<img src='" + HttpUtility.HtmlEncode(hostImage.Path) + "' style='height:80px; wdith:120px; cursor:pointer;' onclick='OpenImageDisplyDialog(this.src);' alt='' />"
                      + " <br /> " + HttpUtility.HtmlEncode(hostImage.ImageType.Name) + " </span>");

            HostImageDiv.Style[HtmlTextWriterStyle.Display] = "block";
        }

        HostImageInnerDiv.InnerHtml = imageHtml;
    }

    private long GetParentRoleIdByRoleId(long roleId)
    {
        var roleRepository = IoC.Resolve<IRoleRepository>();
        var role = roleRepository.GetByRoleId(roleId);

        if (role == null) return 0;

        return role.ParentId ?? 0;
    }

    #endregion

    #region Host

    private void GetHostDetails(EProspect prospect)
    {

        //FranchisorService service = new FranchisorService();
        //HealthYes.Web.UI.FranchisorService.EProspect[] prospect;
        //prospect = service.GetHostDetailsBYHostID(hostid, true);
        if (prospect == null) return;

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        spProspectName1.InnerText = prospect.OrganizationName;
        spProspectName2.InnerText = prospect.OrganizationName;
        spURL.Text = prospect.WebSite.ToString();
        string strAddress = string.Empty;

        if (!string.IsNullOrEmpty(prospect.Address.Address1))
        {
            strAddress = strAddress + prospect.Address.Address1 + ", ";
        }
        // Suit
        if (!string.IsNullOrEmpty(prospect.Address.Address2))
        {
            strAddress = strAddress + prospect.Address.Address2 + ", ";
        }
        // City
        if (!string.IsNullOrEmpty(prospect.Address.City))
        {
            strAddress = strAddress + prospect.Address.City + ", ";
        }
        // State
        if (!string.IsNullOrEmpty(prospect.Address.State))
        {
            strAddress = strAddress + prospect.Address.State + ", ";
        }
        // ZipID
        if (!string.IsNullOrEmpty(prospect.Address.Zip))
        {
            strAddress = strAddress + prospect.Address.Zip + ", ";
        }

        spAddress.InnerHtml = strAddress;

        if (spAddress.InnerHtml.Length > 0)
        {
            if ((spAddress.InnerHtml.Substring(spAddress.InnerHtml.Length - 2, 2) == ", "))
            {
                spAddress.InnerHtml = spAddress.InnerHtml.Substring(0, spAddress.InnerHtml.Length - 2);
            }
            if (spAddress.InnerHtml.Length > 0)
            {
                if ((spAddress.InnerHtml.Substring(spAddress.InnerHtml.Length - 1, 1) == ","))
                {
                    spAddress.InnerHtml = spAddress.InnerHtml.Substring(0, spAddress.InnerHtml.Length - 1);
                }
            }
            if (spAddress.InnerHtml.Length > 0)
            {
                if ((spAddress.InnerHtml.Substring(0, 1) == ","))
                {
                    spAddress.InnerHtml = spAddress.InnerHtml.Substring(1, spAddress.InnerHtml.Length - 1);
                }
            }
            else spAddress.InnerText = "-N/A-";
        }
        else spAddress.InnerText = "-N/A-";

        spURL.Text = prospect.WebSite.Length > 0 ? prospect.WebSite : "-N/A-";
        if (prospect.PhoneCell.Length > 0)
        {
            spPhone.InnerText = objCommonCode.FormatPhoneNumberGet(prospect.PhoneCell);
        }
        else if (prospect.PhoneOffice.Length > 0)
        {
            spPhone.InnerText = objCommonCode.FormatPhoneNumberGet(prospect.PhoneOffice);
        }
        else if (prospect.PhoneOther.Length > 0)
        {
            spPhone.InnerText = objCommonCode.FormatPhoneNumberGet(prospect.PhoneOther);
        }
        else
        {
            spPhone.InnerText = "-N/A-";
        }

        string email = "-N/A-";
        string spnTemp = "-N/A-";
        if (prospect.EMailID.Length > 0)
        {
            email = prospect.EMailID;
        }

        spOther.InnerText = (prospect.EMailID.Length > 0) ? email : "-N/A-";

        if (prospect.LastEventName.Length > 0)
            Convert.ToDateTime(prospect.LastEventDate).ToLongDateString();

        if (!string.IsNullOrEmpty(prospect.ProspectType.Name))
            spnProspectType.InnerText = prospect.ProspectType.Name;
        else spnProspectType.InnerText = "-N/A-";
        // Members/Employees
        spnMembersEmployees.InnerText = prospect.ActualMembership > 0 ? prospect.ActualMembership.ToString() : "-N/A-";
        // Actual Attendence
        spnAttendence.InnerText = prospect.Attendance > 0 ? prospect.Attendance.ToString() : "-N/A-";

        // Facilities Fee
        if (!string.IsNullOrEmpty(prospect.ProspectDetails.FacilitiesFee))
        {
            spnFacilitiesFee.InnerText = "Yes";
            string facilitiesFeeDetails = string.Empty;
            facilitiesFeeDetails = "(<a href=\"#\" class=\"jtip\" title='Fee Details|";
            facilitiesFeeDetails = facilitiesFeeDetails + "<table>";
            facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Room Rent:</strong></td><td>$" + prospect.ProspectDetails.FacilitiesFee + "</td></tr>";

            //TODO: Need to map Payment Method to enum
            if (!string.IsNullOrEmpty(prospect.ProspectDetails.PaymentMethod))
            {
                if (prospect.ProspectDetails.PaymentMethod.Trim() == "1")
                {
                    facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Payment Method:</strong></td><td>" + HostPaymentType.Check.ToString() + "</td></tr>";
                }
                else if (prospect.ProspectDetails.PaymentMethod.Trim() == "2")
                {
                    facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Payment Method:</strong></td><td>" + HostPaymentType.CreditCard.ToString() + "</td></tr>";
                }
                else
                {
                    facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Payment Method:</strong></td><td>" + HostPaymentType.CreditCard.ToString() + "/" + HostPaymentType.Check.ToString() + "</td></tr>";
                }
            }
            else
            {
                facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Payment Method:</strong></td><td>-N/A-</td></tr>";
            }
            if (prospect.ProspectDetails.DepositsRequire == 1)
            {
                facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Deposits Required:</strong></td><td>Yes</td></tr>";
                facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Deposits Amount:</strong></td><td>$" + prospect.ProspectDetails.DepositsAmount.ToString() + "</td></tr>";
            }
            else facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>Deposits Required:</strong></td><td>-N/A-</td></tr>";

            if (!string.IsNullOrEmpty(prospect.TaxIdNumber))
            {
                facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>TaxId Number:</strong></td><td>" + prospect.TaxIdNumber + "</td></tr>";
            }
            else facilitiesFeeDetails = facilitiesFeeDetails + "<tr><td><strong>TaxId Number:</strong></td><td>-N/A-</td></tr>";

            // close table
            facilitiesFeeDetails = facilitiesFeeDetails + "</table>";
            facilitiesFeeDetails = facilitiesFeeDetails + ">View Details</a>)";
            _facilitiesFeeDetails.InnerHtml = facilitiesFeeDetails;
            _facilitiesFeeDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            spnFacilitiesFee.InnerText = "-N/A-";
            _facilitiesFeeDetails.Style.Add(HtmlTextWriterStyle.Display, "none");

        }
        // Hosted In Past
        _hostedInPastDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
        if (prospect.ProspectDetails.HostedInPast == 1)
        {
            hostInPastWith.InnerText = "Yes";
            _hostedInPastDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
            if (!string.IsNullOrEmpty(prospect.ProspectDetails.HostedInPastWith))
            {
                _hostedInPastDetails.InnerHtml = "(<a href=\"#\" class=\"jtip\" title='Competitors|" + prospect.ProspectDetails.HostedInPastWith + "'" + ">View Details</a>)";
            }
            else _hostedInPastDetails.InnerHtml = "(<a href=\"#\" class=\"jtip\" title='Competitors|Competitors : -N/A-'>View Details</a>)";
        }
        else
        {
            _hostedInPastDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
            if (prospect.ProspectDetails.HostedInPast == 0) hostInPastWith.InnerText = "No";
            else if (prospect.ProspectDetails.HostedInPast == 2) hostInPastWith.InnerText = "Unknown";
        }

        // Will Promote
        if (prospect.WillCommunicate >= 0)
        {
            switch (prospect.WillCommunicate)
            {
                case 0:
                    spnTemp = "No";
                    break;
                case 1:
                    spnTemp = "Yes";
                    break;
                case 2:
                    spnTemp = "Unknown";
                    break;
                default:
                    spnTemp = "-N/A-";
                    break;
            }
            spnWillPromote.InnerHtml = spnTemp;
            spnTemp = "";
        }
        // Viable Host Site
        if (prospect.ProspectDetails.ViableHostSite >= 0)
        {
            switch (prospect.ProspectDetails.ViableHostSite)
            {
                case 0:
                    spnTemp = "No";
                    break;
                case 1:
                    spnTemp = "Yes";
                    break;
                case 2:
                    spnTemp = "Unknown";
                    break;
                default:
                    spnTemp = "-N/A-";
                    break;
            }
            spnViableHostSite.InnerHtml = spnTemp;
            spnTemp = "";
        }
    }

    #endregion

    #region Call

    private void GetCalls(EContactCall[] objContact)
    {
        BindCall(objContact);
    }
    private void BindCall(EContactCall[] objContactcall)
    {

        string IsHost = "False";
        DataTable dtContact = new DataTable();
        dtContact.Columns.Add("CallID");
        dtContact.Columns.Add("ContactName");
        dtContact.Columns.Add("Subject");
        dtContact.Columns.Add("StartDate");
        dtContact.Columns.Add("Status");
        dtContact.Columns.Add("Assignedby");
        dtContact.Columns.Add("ProspectID");
        dtContact.Columns.Add("IsHost");
        dtContact.Columns.Add("Notes");

        if (!string.IsNullOrEmpty(Request["Type"]))
        {
            if (Request["Type"].Equals("Host"))
                IsHost = "True";
        }
        if (objContactcall != null && objContactcall.Length > 0)
        {
            if (!string.IsNullOrEmpty(Request["ProspectID"]))
            {
                strProspect = Request["ProspectID"];
            }
            for (int icount = 0; icount < objContactcall.Length; icount++)
            {
                int time = Convert.ToInt32(objContactcall[icount].Duration);
                int hour = time / 60;
                int minute = time % 60;
                string startdate = "";
                if (!string.IsNullOrEmpty(objContactcall[icount].StartDate))
                    startdate = Convert.ToDateTime(objContactcall[icount].StartDate).ToString("MM/dd/yyyy");
                string strNotesToolTip = "";
                strNotesToolTip = "<table cellpadding='3' cellspacing='0' border='0' width='100%'>";
                //Date
                if (!string.IsNullOrEmpty(objContactcall[icount].StartDate))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Date:</b> " + Convert.ToDateTime(objContactcall[icount].StartDate).ToString("MM/dd/yyyy") + "</td></tr>";

                }
                //Time
                if (!string.IsNullOrEmpty(objContactcall[icount].StartTime))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Time:</b> " + Convert.ToDateTime(objContactcall[icount].StartTime).ToString("hh:mm tt") + "</td></tr>";

                }

                // Duration
                if (objContactcall[icount].Duration.ToString() != "")
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td ><b>Duration:</b> " + objContactcall[icount].Duration + " mins.</td></tr>";

                }
                //// Status
                if (!string.IsNullOrEmpty(objContactcall[icount].CallStatus.Status))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Status:</b> " + objContactcall[icount].CallStatus.Status + "</td></tr>";

                }
                // Notes
                if (!string.IsNullOrEmpty(objContactcall[icount].Notes))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Notes:</b>" + objContactcall[icount].Notes + "</td></tr>";

                }
                strNotesToolTip = strNotesToolTip + "</table>";

                dtContact.Rows.Add(new object[] { objContactcall[icount].ContactCallID, 
                                                  objContactcall[icount].Contact.FirstName + " " + objContactcall[icount].Contact.LastName, 
                                                  objContactcall[icount].Subject,                                                 
                                                  startdate,
                                                  objContactcall[icount].CallStatus.Status,
                                                  objContactcall[icount].UserShellModule.UserName,
                                                  strProspect,IsHost,strNotesToolTip});


            }

            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dtContact.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            else
            {
                dtContact.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            dtContact = dtContact.DefaultView.ToTable();
            HtmlContainerControl spCallCount = (HtmlContainerControl)pnlCall.FindControl("spCallcount");
            spCallCount.InnerText = dtContact.Rows.Count.ToString();
            ViewState["GRDCALL"] = dtContact;
            grdCall.DataSource = dtContact;
            grdCall.DataBind();

            divCalls.Style.Add(HtmlTextWriterStyle.Display, "block");
            divNoResultsCalls.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            HtmlContainerControl spCallCount = (HtmlContainerControl)pnlCall.FindControl("spCallcount");
            spCallCount.InnerText = dtContact.Rows.Count.ToString();
            divCalls.Style.Add(HtmlTextWriterStyle.Display, "none");
            divNoResultsCalls.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

    }
    protected void grdCall_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtContact = (DataTable)ViewState["GRDCALL"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtContact.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtContact.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtContact = dtContact.DefaultView.ToTable();
        ViewState["SortExp"] = e.SortExpression;
        ViewState["GRDCALL"] = dtContact;
        grdCall.DataSource = dtContact;
        grdCall.DataBind();
    }
    protected void grdCall_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCall.PageIndex = e.NewPageIndex;
        grdCall.DataSource = (DataTable)ViewState["GRDCALL"];
        grdCall.DataBind();
    }
    protected void grdCall_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgCloseCall = (ImageButton)e.Row.FindControl("ibtnDelete");
            imgCloseCall.OnClientClick = "return confirm('Are you sure to delete call?');";
        }

    }

    #endregion

    #region Task

    private void GetTask(ETask[] objTask)
    {
        BindTask(objTask);
    }

    private void BindTask(ETask[] objTask)
    {
        DataTable dtTask = new DataTable();
        dtTask.Columns.Add("TaskID");
        dtTask.Columns.Add("Subject");
        dtTask.Columns.Add("StartDate");
        dtTask.Columns.Add("DueDate");
        dtTask.Columns.Add("DueTime");
        dtTask.Columns.Add("Status");
        dtTask.Columns.Add("Assignedby");
        dtTask.Columns.Add("Priority");
        dtTask.Columns.Add("Notes");

        string startDate = string.Empty;
        string dueDate = string.Empty;
        string dueTime = string.Empty;

        if (objTask != null && objTask.Length > 0)
        {
            for (int icount = 0; icount < objTask.Length; icount++)
            {
                startDate = objTask[icount].StartDate;
                dueDate = objTask[icount].DueDate;
                dueTime = objTask[icount].DueTime;

                if (!string.IsNullOrEmpty(objTask[icount].DueDate))
                    dueDate = Convert.ToDateTime(objTask[icount].DueDate).ToString("MM/dd/yyyy");
                if (!string.IsNullOrEmpty(objTask[icount].DueTime))
                    dueTime = Convert.ToDateTime(objTask[icount].DueTime).ToString("hh:mm tt");

                dtTask.Rows.Add(new object[] { objTask[icount].TaskID, 
                                                  objTask[icount].Subject, 
                                                  startDate,
                                                  dueDate,
                                                  dueTime,
                                                  objTask[icount].TaskStatusType.Name,
                                                  objTask[icount].Contact,
                                                  objTask[icount].TaskPriorityType.Name,
                                                  objTask[icount].Notes
                                                });
                startDate = "";
                dueDate = "";
                dueTime = "";
            }

            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dtTask.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            else
            {
                dtTask.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            dtTask = dtTask.DefaultView.ToTable();

            HtmlContainerControl spTaskCount = (HtmlContainerControl)pnlTask.FindControl("spTaskCount");
            spTaskCount.InnerText = dtTask.Rows.Count.ToString();
            ViewState["GRDTASK"] = dtTask;
            grdTask.DataSource = dtTask;
            grdTask.DataBind();

            divTaskResults.Style.Add(HtmlTextWriterStyle.Display, "block");
            divNoResultsTask.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            HtmlContainerControl spTaskCount = (HtmlContainerControl)pnlTask.FindControl("spTaskCount");
            spTaskCount.InnerText = dtTask.Rows.Count.ToString();
            divTaskResults.Style.Add(HtmlTextWriterStyle.Display, "none");
            divNoResultsTask.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

    }
    protected void grdTask_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtTask = (DataTable)ViewState["GRDTASK"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtTask.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtTask.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtTask = dtTask.DefaultView.ToTable();
        ViewState["SortExp"] = e.SortExpression;
        ViewState["GRDTASK"] = dtTask;
        grdTask.DataSource = dtTask;
        grdTask.DataBind();
    }
    protected void grdTask_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdTask.PageIndex = e.NewPageIndex;
        grdTask.DataSource = (DataTable)ViewState["GRDTASK"];
        grdTask.DataBind();
    }
    protected void grdTask_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    #endregion

    #region Meeting


    private void GetMeetings(EContactMeeting[] objMeeting)
    {
        BindMeeting(objMeeting);
    }

    private void BindMeeting(EContactMeeting[] objMeeting)
    {

        string IsHost = "False";
        DataTable dtMeeting = new DataTable();
        dtMeeting.Columns.Add("MeetingID");
        dtMeeting.Columns.Add("ContactName");
        dtMeeting.Columns.Add("Subject");
        dtMeeting.Columns.Add("Duration");
        dtMeeting.Columns.Add("StartDate");
        dtMeeting.Columns.Add("StartTime");
        dtMeeting.Columns.Add("Venue");
        dtMeeting.Columns.Add("Notes");
        dtMeeting.Columns.Add("Status");
        dtMeeting.Columns.Add("Assignedby");
        dtMeeting.Columns.Add("ProspectID");
        dtMeeting.Columns.Add("IsHost");
        dtMeeting.Columns.Add("ContactID");


        if (!string.IsNullOrEmpty(Request["Type"]))
        {
            if (Request["Type"].Equals("Host"))
                IsHost = "True";
        }
        if (objMeeting != null && objMeeting.Length > 0)
        {
            if (!string.IsNullOrEmpty(Request["ProspectID"]))
            {
                strProspect = Request["ProspectID"];
            }
            for (int icount = 0; icount < objMeeting.Length; icount++)
            {
                string Duration = string.Empty;
                string strStartTime = string.Empty;
                DateTime dtStartTime;
                int time = Convert.ToInt32(objMeeting[icount].Duration);
                int hour = time / 60;
                int minute = time % 60;

                if (!string.IsNullOrEmpty(objMeeting[icount].StartTime))
                {
                    dtStartTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + objMeeting[icount].StartTime);
                    strStartTime = dtStartTime.ToString("h:mm:ss tt");
                }
                dtMeeting.Rows.Add(new object[] { objMeeting[icount].ContactMeetingID, 
                                                  objMeeting[icount].Contact.FirstName + " " + objMeeting[icount].Contact.LastName, 
                                                  objMeeting[icount].Subject,
                                                  hour + "h" + " " + minute + "m",
                                                  objMeeting[icount].StartDate,
                                                  strStartTime,
                                                  objMeeting[icount].Venue,
                                                  objMeeting[icount].Description,
                                                  objMeeting[icount].CallStatus.Status,                                                  
                                                  objMeeting[icount].UserShellModule.UserName,
                                                  strProspect,IsHost,objMeeting[icount].Contact.ContactID
                                                });


            }

            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dtMeeting.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            else
            {
                dtMeeting.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            dtMeeting = dtMeeting.DefaultView.ToTable();

            HtmlContainerControl spMeetingCount = (HtmlContainerControl)pnlMy.FindControl("spMeetingCount");
            spMeetingCount.InnerText = dtMeeting.Rows.Count.ToString();
            ViewState["GRDMEETING"] = dtMeeting;
            grdMeeting.DataSource = dtMeeting;
            grdMeeting.DataBind();

            divMeetingResults.Style.Add(HtmlTextWriterStyle.Display, "block");
            divNoResultsMeeting.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            HtmlContainerControl spMeetingCount = (HtmlContainerControl)pnlMy.FindControl("spMeetingCount");
            spMeetingCount.InnerText = dtMeeting.Rows.Count.ToString();

            divMeetingResults.Style.Add(HtmlTextWriterStyle.Display, "none");
            divNoResultsMeeting.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

    }

    protected void grdMeeting_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtMeeting = (DataTable)ViewState["GRDMEETING"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtMeeting.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtMeeting.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtMeeting = dtMeeting.DefaultView.ToTable();
        ViewState["SortExp"] = e.SortExpression;
        ViewState["GRDMEETING"] = dtMeeting;
        grdMeeting.DataSource = dtMeeting;
        grdMeeting.DataBind();
    }
    protected void grdMeeting_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdMeeting.PageIndex = e.NewPageIndex;
        grdMeeting.DataSource = (DataTable)ViewState["GRDMEETING"];
        grdMeeting.DataBind();
    }
    protected void grdMeeting_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    #endregion

    #region Contact

    private void GetContacts(EContact[] arrContact, long ProspectID)
    {
        if (arrContact != null && arrContact.Length > 0)
        {
            // format phone no.
            CommonCode objCommonCode = new CommonCode();

            DataTable tblContact = new DataTable();

            tblContact.Columns.Add("ContactID", typeof(Int32));
            tblContact.Columns.Add("ProspectID", typeof(Int32));
            tblContact.Columns.Add("Name");
            tblContact.Columns.Add("Address");
            tblContact.Columns.Add("Email");
            tblContact.Columns.Add("EmailOffice");
            tblContact.Columns.Add("PhoneOffice");
            tblContact.Columns.Add("PhoneHome");
            tblContact.Columns.Add("PhoneCell");
            tblContact.Columns.Add("ContactType");


            //foreach (HealthYes.Web.UI.FranchisorService.EContact objContact in arrContact)
            foreach (EContact objContact in arrContact)
            {
                string address = "";
                string strPhoneOffce = string.Empty;
                string strPhoneHome = string.Empty;
                string strPhoneCell = string.Empty;
                string name = string.Empty;
                string contactRole = string.Empty;
                if (objContact.Address.Address1.Length > 0)
                {
                    address = Falcon.App.Lib.CommonCode.AddressSingleLine(objContact.Address.Address1, objContact.Address.Address2,
                                            objContact.Address.City, objContact.Address.State, objContact.Address.Zip.ToString());
                }
                name = CommonClass.FormatName(objContact.FirstName, "", objContact.LastName);
                if (objContact.PhoneOffice.Trim().Equals("(___)-___-____"))
                    strPhoneOffce = "-N/A-";
                else strPhoneOffce = objCommonCode.FormatPhoneNumberGet(objContact.PhoneOffice);

                strPhoneHome = !string.IsNullOrEmpty(objContact.PhoneHome) ? objCommonCode.FormatPhoneNumberGet(objContact.PhoneHome) : "-N/A-";
                strPhoneCell = !string.IsNullOrEmpty(objContact.PhoneCell) ? objCommonCode.FormatPhoneNumberGet(objContact.PhoneCell) : "-N/A-";

                if (objContact.ListProspectContactRole != null && objContact.ListProspectContactRole.Count > 0)
                {
                    contactRole = objContact.ListProspectContactRole[0].ProspectContactRoleName;
                }
                else contactRole = "-N/A-";

                tblContact.Rows.Add(objContact.ContactID, ProspectID.ToString(), name, address, objContact.EMail, objContact.EmailWork, strPhoneOffce, strPhoneHome, strPhoneCell, contactRole);
            }

            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                tblContact.DefaultView.Sort = ViewState["SortExpContacts"].ToString() + " asc";
            }
            else
            {
                tblContact.DefaultView.Sort = ViewState["SortExpContacts"].ToString() + " desc";
            }


            tblContact = tblContact.DefaultView.ToTable();
            ViewState["GRDCONTACT"] = tblContact;
            grdContacts.DataSource = tblContact;
            grdContacts.DataBind();
            divNoContacts.Visible = false;
        }
        else
        {
            divNoContacts.Visible = true;
        }

    }
    protected void grdContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdContacts.PageIndex = e.NewPageIndex;
        grdContacts.DataSource = (DataTable)ViewState["GRDCONTACT"];
        grdContacts.DataBind();

    }
    protected void grdContacts_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtContact = (DataTable)ViewState["GRDCONTACT"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExpContacts"].ToString() != e.SortExpression))
        {
            dtContact.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtContact.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtContact = dtContact.DefaultView.ToTable();
        ViewState["SortExpContacts"] = e.SortExpression;
        ViewState["GRDCONTACT"] = dtContact;
        grdContacts.DataSource = dtContact;
        grdContacts.DataBind();
    }

    #endregion

    #region Notes

    //private void GetNotes(HealthYes.Web.UI.FranchisorService.ENotesDetails[] objENotesDetails)
    private void GetNotes(ENotesDetails[] objENotesDetails)
    {
        //FranchisorService service = new FranchisorService();
        //HealthYes.Web.UI.FranchisorService.ENotesDetails[] objENotesDetails = service.GetProspectNotesDetails((ProspectId.ToString()));

        BindNotes(objENotesDetails);

    }
    private void GetNotes(int ProspectId, bool blnReferesh)
    {
        //FranchisorService service = new FranchisorService();
        //HealthYes.Web.UI.FranchisorService.ENotesDetails[] objENotesDetails = service.GetProspectNotesDetails((ProspectId.ToString()));

        FranchisorDAL objDAL = new FranchisorDAL();
        ENotesDetails[] objENotesDetails = null;
        var listNoteDetails = objDAL.GetProspectNotesDetails(ProspectId.ToString(), 0);

        if (listNoteDetails != null) objENotesDetails = listNoteDetails.ToArray();

        BindNotes(objENotesDetails);

    }

    //private void BindNotes(HealthYes.Web.UI.FranchisorService.ENotesDetails[] objENotesDetails)
    private void BindNotes(ENotesDetails[] objENotesDetails)
    {
        DataTable dtNotes = new DataTable();
        dtNotes.Columns.Add("NotesID");
        dtNotes.Columns.Add("Notes");
        dtNotes.Columns.Add("DateCreated");
        dtNotes.Columns.Add("DateModified");

        if (objENotesDetails != null && objENotesDetails.Length > 0)
        {
            for (int icount = 0; icount < objENotesDetails.Length; icount++)
            {
                dtNotes.Rows.Add(new object[] { objENotesDetails[icount].NoteID, 
                                                objENotesDetails[icount].Notes , 
                                                objENotesDetails[icount].DateCreated,
                                                objENotesDetails[icount].DateModified
                                               });
            }
            dtNotes = dtNotes.DefaultView.ToTable();
            HtmlContainerControl spNotesCount = (HtmlContainerControl)pnlNotes.FindControl("spNotesCount");
            spNotesCount.InnerText = dtNotes.Rows.Count.ToString();
            ViewState["GRDNOTES"] = dtNotes;
            grdNotes.DataSource = dtNotes;
            grdNotes.DataBind();

            divNotesResults.Style.Add(HtmlTextWriterStyle.Display, "block");
            divNoResultsNotes.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            HtmlContainerControl spNotesCount = (HtmlContainerControl)pnlNotes.FindControl("spNotesCount");
            spNotesCount.InnerText = dtNotes.Rows.Count.ToString();
            divNotesResults.Style.Add(HtmlTextWriterStyle.Display, "none");
            divNoResultsNotes.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
    }
    protected void grdNotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdNotes.PageIndex = e.NewPageIndex;
        grdNotes.DataSource = (DataTable)ViewState["GRDNOTES"];
        grdNotes.DataBind();
    }
    //grdNotes_Sorting

    protected void grdNotes_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtContact = (DataTable)ViewState["GRDNOTES"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExpContacts"].ToString() != e.SortExpression))
        {
            dtContact.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtContact.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtContact = dtContact.DefaultView.ToTable();
        ViewState["SortExpContacts"] = e.SortExpression;
        ViewState["GRDNOTES"] = dtContact;
        grdNotes.DataSource = dtContact;
        grdNotes.DataBind();
    }
    #endregion

    #region All

    //private void GetAllTab(HealthYes.Web.UI.FranchisorService.EContactCall[] objEContactCalls)
    private void GetAllTab(EContactCall[] objEContactCalls)
    {
        //ContactCallService service = new ContactCallService();
        //HealthYes.Web.UI.ContactCallService.EContactCall[] objEContactCalls = service.GetCallsMeetingsTasks(ProspectId, true);
        BindAll(objEContactCalls);
    }

    //private void BindAll(HealthYes.Web.UI.FranchisorService.EContactCall[] objEContactCalls)
    private void BindAll(EContactCall[] objEContactCalls)
    {
        DataTable dtAll = new DataTable();
        dtAll.Columns.Add("Type");
        dtAll.Columns.Add("ID");
        dtAll.Columns.Add("Subject");
        dtAll.Columns.Add("Duration");
        dtAll.Columns.Add("StartDate");
        dtAll.Columns.Add("AssignToUserID");
        dtAll.Columns.Add("ContactName");
        dtAll.Columns.Add("ContactID");
        dtAll.Columns.Add("AssignedBy");
        dtAll.Columns.Add("DateModified");

        if (objEContactCalls != null && objEContactCalls.Length > 0)
        {
            for (int icount = 0; icount < objEContactCalls.Length; icount++)
            {
                dtAll.Rows.Add(new object[] { objEContactCalls[icount].Type, 
                                                objEContactCalls[icount].ContactCallID, 
                                                objEContactCalls[icount].Subject,
                                                objEContactCalls[icount].Duration,
                                                objEContactCalls[icount].StartDate,
                                                objEContactCalls[icount].AssignedToUserId,
                                                objEContactCalls[icount].Contact.FirstName,
                                                objEContactCalls[icount].Contact.ContactID,                                                
                                                objEContactCalls[icount].UserShellModule.UserName,
                                                objEContactCalls[icount].StartTime
                                               });
            }
            dtAll = dtAll.DefaultView.ToTable();
            HtmlContainerControl spAllcount = (HtmlContainerControl)pnlAll.FindControl("spnAllCount");

            spAllcount.InnerText = dtAll.Rows.Count.ToString();
            ViewState["GRDALL"] = dtAll;
            grdAll.DataSource = dtAll;
            grdAll.DataBind();

            divAllResults.Style.Add(HtmlTextWriterStyle.Display, "block");
            divNoResultsAll.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            HtmlContainerControl spAllcount = (HtmlContainerControl)pnlAll.FindControl("spnAllCount");
            spAllcount.InnerText = dtAll.Rows.Count.ToString();
            divAllResults.Style.Add(HtmlTextWriterStyle.Display, "none");
            divNoResultsAll.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
    }
    protected void grdAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAll.PageIndex = e.NewPageIndex;
        grdAll.DataSource = (DataTable)ViewState["GRDALL"];
        grdAll.DataBind();
    }
    protected void grdAll_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtContact = (DataTable)ViewState["GRDALL"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExpContacts"].ToString() != e.SortExpression))
        {
            dtContact.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtContact.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtContact = dtContact.DefaultView.ToTable();
        ViewState["SortExpContacts"] = e.SortExpression;
        ViewState["GRDALL"] = dtContact;
        grdAll.DataSource = dtContact;
        grdAll.DataBind();
    }
    #endregion

    #region Host Events
    private void BindEventOnPageChange(int mode, string sortOrder, string sortColumn)
    {
        var roleID = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId;
        var shellID = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
        var userID = IoC.Resolve<ISessionContext>().UserSession.UserId;
        long HostID = 0;

        if (ViewState["HostId"] != null)
        {
            HostID = Convert.ToInt64(ViewState["HostId"]);
        }

        string strPaging = string.Empty;
        _sortOrder = string.IsNullOrEmpty(sortOrder) ? "DESC" : sortOrder;
        _sortColumn = string.IsNullOrEmpty(sortColumn) ? "EventDate" : sortColumn;
        _pageIndex = string.IsNullOrEmpty(hidpageindex.Value) ? 1 : Convert.ToInt32(hidpageindex.Value);


        List<EEvent> eevent = masterDal.GetViewEventForHostDetails(HostID.ToString(), mode, userID, roleID, shellID, _sortColumn, _sortOrder, _pageSize, _pageIndex, out _totalRecordsEventOnHost, out _totalRecordsEventOnHostZip, out _totalRecordsEventOnHostDistance);

        var eventsHost = eevent.Select(events => new
        {
            events.EventID,
            Date = events.EventDate,
            EventName = events.Name,
            HostName = events.Host.Name,
            events.Host.HostID,
            events.CustomerCount,
            SalesRepID = events.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID,
            events.EventStatus
        }).ToList();

        // event Host
        if (mode == 1)
        {
            if (eventsHost.Count() > 0)
            {
                grdevents.DataSource = eventsHost;
                grdevents.DataBind();
                strPaging = ImplementPaging(_pageIndex, Convert.ToInt16(_pageSize), Convert.ToInt32(_totalRecordsEventOnHost), "ChangePageEventHost");
                eventsOnHostPaging.InnerHtml = strPaging;
            }
            else
            {
                divNoEvents.Style.Add(HtmlTextWriterStyle.Display, "block");
                eventsOnHostPaging.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }
        else if (mode == 2)
        {
            // events on HostZip
            if (eventsHost.Count() > 0)
            {
                _eventsOnHostZip.DataSource = eventsHost;
                _eventsOnHostZip.DataBind();
                strPaging = ImplementPaging(_pageIndex, Convert.ToInt16(_pageSize), Convert.ToInt32(_totalRecordsEventOnHost), "ChangePageEventHostZip");
                eventsOnHostZipPaging.InnerHtml = strPaging;
            }
            else
            {
                _eventHostZipNoRecord.Style.Add(HtmlTextWriterStyle.Display, "block");
                eventsOnHostZipPaging.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }
        else if (mode == 3)
        {
            // events on HostZip With In Distance
            if (eventsHost.Count() > 0)
            {
                _eventsOnHostZipDistance.DataSource = eventsHost;
                _eventsOnHostZipDistance.DataBind();
                strPaging = ImplementPaging(_pageIndex, Convert.ToInt16(_pageSize), Convert.ToInt32(_totalRecordsEventOnHost), "ChangePageEventHostDistance");
                eventsOnHostDistancePaging.InnerHtml = strPaging;
            }
            else
            {
                _eventHostZipDistanceNoRecord.Style.Add(HtmlTextWriterStyle.Display, "block");
                eventsOnHostDistancePaging.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }
    }
    private void GetEvents(long HostID)
    {
        var roleID = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId;
        var shellID = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
        var userID = IoC.Resolve<ISessionContext>().UserSession.UserId;
        string strPaging = string.Empty;
        _sortOrder = "DESC";
        _sortColumn = "EventDate";
        ViewState["HostId"] = HostID.ToString();
        var masterDal = new MasterDAL();
        List<EEvent> eevent = masterDal.GetViewEventForHostDetails(HostID.ToString(), 4, userID, roleID, shellID, _sortColumn, _sortOrder, _pageSize, _pageIndex, out _totalRecordsEventOnHost, out _totalRecordsEventOnHostZip, out _totalRecordsEventOnHostDistance);

        var eventsHost = eevent.Where(eventHost => eventHost.HostEventType == 1).Select(events => new
       {
           events.EventID,
           Date = events.EventDate,
           EventName = events.Name,
           HostName = events.Host.Name,
           events.Host.HostID,
           events.CustomerCount,
           SalesRepID = events.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID,
           events.EventStatus
       }).ToList();

        var eventsHostZip = eevent.Where(eventHost => eventHost.HostEventType == 2).Select(events => new
        {
            events.EventID,
            Date = events.EventDate,
            EventName = events.Name,
            HostName = events.Host.Name,
            events.Host.HostID,
            events.CustomerCount,
            SalesRepID = events.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID,
            events.EventStatus
        }).ToList();
        var eventsHostZipDistance = eevent.Where(eventHost => eventHost.HostEventType == 3).Select(events => new
        {
            events.EventID,
            Date = events.EventDate,
            EventName = events.Name,
            HostName = events.Host.Name,
            events.CustomerCount,
            SalesRepID = events.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID,
            events.EventStatus
        }).ToList();


        if (eventsHost.Count() > 0)
        {
            grdevents.DataSource = eventsHost;
            grdevents.DataBind();
            strPaging = ImplementPaging(_pageIndex, Convert.ToInt16(_pageSize), Convert.ToInt32(_totalRecordsEventOnHost), "ChangePageEventHost");
            eventsOnHostPaging.InnerHtml = strPaging;
        }
        else
        {
            divNoEvents.Style.Add(HtmlTextWriterStyle.Display, "block");
            eventsOnHostPaging.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        // events on HostZip
        if (eventsHostZip.Count() > 0)
        {
            _eventsOnHostZip.DataSource = eventsHostZip;
            _eventsOnHostZip.DataBind();
            strPaging = ImplementPaging(_pageIndex, Convert.ToInt16(_pageSize), Convert.ToInt32(_totalRecordsEventOnHostZip), "ChangePageEventHostZip");
            eventsOnHostZipPaging.InnerHtml = strPaging;
        }
        else
        {
            _eventHostZipNoRecord.Style.Add(HtmlTextWriterStyle.Display, "block");
            eventsOnHostZipPaging.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        // events on HostZip With In Distance
        if (eventsHostZipDistance.Count() > 0)
        {
            _eventsOnHostZipDistance.DataSource = eventsHostZipDistance;
            _eventsOnHostZipDistance.DataBind();
            strPaging = ImplementPaging(_pageIndex, Convert.ToInt16(_pageSize), Convert.ToInt32(_totalRecordsEventOnHostDistance), "ChangePageEventHostDistance");
            eventsOnHostDistancePaging.InnerHtml = strPaging;
        }
        else
        {
            _eventHostZipDistanceNoRecord.Style.Add(HtmlTextWriterStyle.Display, "block");
            eventsOnHostDistancePaging.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
    }


    #endregion
    #region Event

    // Events On Host 
    protected void grdevents_Sorting(object sender, GridViewSortEventArgs e)
    {
        _sortColumn = e.SortExpression;
        if (ViewState["SortDirEventHost"] == null)
        {
            ViewState["SortDirEventHost"] = "DESC";
            _sortOrder = "DESC";
        }
        else if (ViewState["SortDirEventHost"] != null && ViewState["SortDirEventHost"].ToString() == "DESC")
        {
            ViewState["SortDirEventHost"] = "ASC";
            _sortOrder = "ASC";
        }
        else if (ViewState["SortDirEventHost"] != null && ViewState["SortDirEventHost"].ToString() == "ASC")
        {
            ViewState["SortDirEventHost"] = "DESC";
            _sortOrder = "DESC";
        }
        BindEventOnPageChange(1, _sortOrder, _sortColumn);
    }
    // Events On Host Zip
    protected void EventsOnHostZip_Sorting(object sender, GridViewSortEventArgs e)
    {
        _sortColumn = e.SortExpression;
        if (ViewState["SortDirEventHostZip"] == null)
        {
            ViewState["SortDirEventHostZip"] = "DESC";
            _sortOrder = "DESC";
        }
        else if (ViewState["SortDirEventHostZip"] != null && ViewState["SortDirEventHostZip"].ToString() == "DESC")
        {
            ViewState["SortDirEventHostZip"] = "ASC";
            _sortOrder = "ASC";
        }
        else if (ViewState["SortDirEventHostZip"] != null && ViewState["SortDirEventHostZip"].ToString() == "ASC")
        {
            ViewState["SortDirEventHostZip"] = "DESC";
            _sortOrder = "DESC";
        }
        BindEventOnPageChange(2, _sortOrder, _sortColumn);
    }
    // Events On Host Zip WithIn Distance
    protected void EventsOnHostZipDistance_Sorting(object sender, GridViewSortEventArgs e)
    {
        _sortColumn = e.SortExpression;
        if (ViewState["SortDirEventHostDistance"] == null)
        {
            ViewState["SortDirEventHostDistance"] = "DESC";
            _sortOrder = "DESC";
        }
        else if (ViewState["SortDirEventHostDistance"] != null && ViewState["SortDirEventHostDistance"].ToString() == "DESC")
        {
            ViewState["SortDirEventHostDistance"] = "ASC";
            _sortOrder = "ASC";
        }
        else if (ViewState["SortDirEventHostDistance"] != null && ViewState["SortDirEventHostDistance"].ToString() == "ASC")
        {
            ViewState["SortDirEventHostDistance"] = "DESC";
            _sortOrder = "DESC";
        }
        BindEventOnPageChange(3, _sortOrder, _sortColumn);
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton tempButton = (ImageButton)sender;
        int ContactCallID = Convert.ToInt32(tempButton.CommandArgument);
        Int64 tempreturnspecified;
        MasterDAL objMasterDal = new MasterDAL();
        tempreturnspecified = objMasterDal.ChangeCallStatus(ContactCallID, 0);
        LoadGrids(Convert.ToInt32(Request.QueryString["ProspectID"]));
    }

    protected void lnkCall_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string contactid = lnk.CommandArgument;
        string IsHost = "False";

        if (!string.IsNullOrEmpty(Request["Type"]))
        {
            if (Request["Type"].Equals("Host"))
                IsHost = "True";
        }
        Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/AddCallProspect.aspx?ProspectID=" + Request.QueryString["ProspectID"].ToString() + "&ContactID=" + contactid + "&Parent=Prospect" + "&IsHost=" + IsHost));
    }

    protected void lnkTask_Click(object sender, EventArgs e)
    {
        string IsHost = "False";

        if (!string.IsNullOrEmpty(Request["Type"]))
        {
            if (Request["Type"].Equals("Host"))
                IsHost = "True";
        }
        Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/AddTask.aspx?ProspectID=" + Request.QueryString["ProspectID"].ToString() + "&Parent=Prospect" + "&IsHost=" + IsHost));
    }

    protected void lnkMeeting_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string contactid = lnk.CommandArgument;

        string IsHost = "False";
        if (!string.IsNullOrEmpty(Request["Type"]))
        {
            if (Request["Type"].Equals("Host"))
                IsHost = "True";
        }
        Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/AddMeeting.aspx?ProspectID=" + Request.QueryString["ProspectID"].ToString() + "&ContactID=" + contactid + "&Parent=Prospect" + "&IsHost=" + IsHost));
    }

    protected void lnkContact_Click(object sender, EventArgs e)
    {
        Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/AddNewContact.aspx?Parent=Prospect" + "&ProspectID=" + Request.QueryString["ProspectID"].ToString()));

    }

    protected void lnkEvent_Click(object sender, EventArgs e)
    {
        Response.RedirectUser(this.ResolveUrl("~/App/Common/CreateEventWizard/Step1.aspx?Type=Create&Parent=Host&HostID=" + Request.QueryString["ProspectID"].ToString()));
    }

    protected void lnkProspect_Click(object sender, EventArgs e)
    {
        if (Request["Type"] == null) return;

        if (Request["Type"] == "Prospect")
        {
            Response.RedirectUser(this.ResolveUrl("~/App/Common/AddNewProspect.aspx?ProspectID=" + Request.QueryString["ProspectID"] + "&Parent=Prospect"));
        }
        else
        {
            Response.RedirectUser(this.ResolveUrl("~/App/Common/AddNewHost.aspx?HostID=" + Request.QueryString["ProspectID"] + "&Parent=Host"));
        }
    }

    private void LoadGrids(long prospectID)
    {
        Int64 iProspectID = prospectID;
        FranchisorDAL objDAL = new FranchisorDAL();
        EProspectAll prospectAll = null;

        if (!string.IsNullOrEmpty(Request["Type"]))
        {
            if (Request["Type"].Equals("Prospect"))
            {
                // Mode 1 is used tyo Fetch All Prospects
                prospectAll = objDAL.ProspectHostDetailsAll(iProspectID, 1);
            }
            else
            {
                // Mode 2 is used to Fetch All Hosts
                prospectAll = objDAL.ProspectHostDetailsAll(iProspectID, 2);
                GetEvents(prospectID);
            }
            if (prospectAll.Prospect == null)
            {
                if (Request["Type"].Equals("Prospect"))
                {
                    Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepManageProspects.aspx?prospectname=" + hfProsectID.Value);
                }
                else
                {
                    Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepManageHost.aspx?hostname=" + hfProsectID.Value);
                }
            }
            if (prospectAll != null)
            {
                if (prospectAll.Prospect != null)
                    GetProspectDetails(prospectAll.Prospect);
                if (prospectAll.Calls != null)
                    GetCalls(prospectAll.Calls.ToArray());
                if (prospectAll.Tasks != null)
                    GetTask(prospectAll.Tasks.ToArray());
                if (prospectAll.Meetings != null)
                    GetMeetings(prospectAll.Meetings.ToArray());
                if (prospectAll.Prospect.Contact != null)
                    GetContacts(prospectAll.Prospect.Contact.ToArray(), prospectID);
                else divNoContacts.Visible = true;
                if (prospectAll.Notes != null)
                    GetNotes(prospectAll.Notes.ToArray());
                if (prospectAll.CallMeetingTask != null)
                    GetAllTab(prospectAll.CallMeetingTask.ToArray());
            }
        }
    }

    protected void ibtnback_Click(object sender, ImageClickEventArgs e)
    {
        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        // case added for my activity page
        if (Request.QueryString["MyActivity"] != null && Request.QueryString["MyActivity"].Equals("True"))
        {
            if (Request.QueryString["Type"] != null)
                Response.RedirectUser("/App/Franchisee/SalesRep/MyActivities.aspx?Tab=" + Request.QueryString["Type"]);
        }
        else if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
        {
            if (Request.QueryString["From"] != null && Request.QueryString["From"].Equals("ManageEvents"))
            {
                Response.RedirectUser("/Scheduling/Event/Index?showUpcoming=true");
            }
            else
            {
                if (Request.QueryString["Type"] != null && Request.QueryString["Type"].Equals("Host"))
                {
                    Response.RedirectUser("/App/Franchisor/ManageHost.aspx");
                }
                else
                {
                    Response.RedirectUser("/App/Franchisor/ManageProspect.aspx");
                }
            }
        }
        else if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            if (Request.QueryString["From"] != null && Request.QueryString["From"].Equals("ManageEvents"))
            {
                Response.RedirectUser("/Scheduling/Event/Index?showUpcoming=true");
            }
            else
            {
                if (Request.QueryString["Type"] != null && Request.QueryString["Type"].Equals("Host"))
                {
                    Response.RedirectUser("/App/Franchisor/ManageHost.aspx");
                }
                else
                {
                    Response.RedirectUser("/App/Franchisor/ManageProspect.aspx");
                }
            }
        }
        else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
        {
            if (Request.QueryString["From"] != null && Request.QueryString["From"].Equals("ManageEvents"))
            {
                Response.RedirectUser("/Scheduling/Event/Index?showUpcoming=true");
            }
            else
            {
                if (Request.QueryString["Type"] != null && Request.QueryString["Type"].Equals("Host"))
                {
                    Response.RedirectUser("/App/Franchisee/SalesRep/SalesRepManageHost.aspx");
                }
                else
                {
                    Response.RedirectUser("/App/Franchisee/SalesRep/SalesRepManageProspects.aspx");
                }
            }
        }
    }

    protected void lnkCall_Click1(object sender, EventArgs e)
    {
        string ProspectID = string.Empty;
        string Url = string.Empty;
        if (!string.IsNullOrEmpty(Request["ProspectID"]))
        {
            ProspectID = Request["ProspectID"].ToString();
            Url = @"/App/Franchisor/AddCallProspect.aspx?Parent=True&ProspectID=" + ProspectID;
        }
        if (!string.IsNullOrEmpty(Request["Type"]))
        {
            if (Request["Type"].Equals("Host"))
            {
                Url = @"/App/Franchisor/AddCallProspect.aspx?Parent=True&IsHost=True&ProspectID=" + ProspectID;
            }
        }
        Response.RedirectUser(Url);

    }
    protected void lnkMeeting_Click1(object sender, EventArgs e)
    {
        string ProspectID = string.Empty;
        string Url = string.Empty;
        if (!string.IsNullOrEmpty(Request["ProspectID"]))
        {
            ProspectID = Request["ProspectID"].ToString();
            Url = @"/App/Franchisor/AddMeeting.aspx?Parent=True&ProspectID=" + ProspectID;
        }
        if (!string.IsNullOrEmpty(Request["Type"]))
        {
            if (Request["Type"].Equals("Host"))
            {
                Url = @"/App/Franchisor/AddMeeting.aspx?Parent=True&IsHost=True&ProspectID=" + ProspectID;
            }
        }
        Response.RedirectUser(Url);

    }

    /// <summary>
    /// Command Buttone Notes
    /// Delete Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Command_Button_Click(Object sender, CommandEventArgs e)
    {
        Int64 NotesID = 0;
        switch (e.CommandName)
        {

            case "DeleteNotes":
                NotesID = Convert.ToInt32(e.CommandArgument.ToString());

                //HealthYes.Web.UI.FranchisorService.FranchisorService service = new FranchisorService();
                //service.DeleteNotesDetails(NotesID, true);

                FranchisorDAL objDAL = new FranchisorDAL();
                objDAL.DeleteNotesDetails(NotesID, 0);

                if (!string.IsNullOrEmpty(Request["ProspectID"]))
                {
                    GetNotes(Convert.ToInt32(Request["ProspectID"]), true);
                }
                hfheader.Value = "divHeaderNotes";
                break;
        }
    }

    protected void lnkConvertToHost_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ProspectID"] != null && Request.QueryString["ProspectID"] != "")
        {
            Response.RedirectUser(this.ResolveUrl("~/App/Common/AddNewHost.aspx?HostID=" + Convert.ToInt32(Request.QueryString["ProspectID"]) + "&Action=ConvertToHost"));
        }
    }

    #endregion

    #region Paging Function
    private string ImplementPaging(int pagenumber, short pagesize, int recordcount, string functionToCall)
    {

        if (recordcount <= pagesize) return "";

        // Calculates Total number of pages possible
        int numberofpages = recordcount / pagesize;
        if ((pagesize * numberofpages) != recordcount) numberofpages++;

        //Calculates first and last page number to display in paging tab, so as to decide whole range
        int minpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 1) : ((((pagenumber / 10) - 1) * 10) + 1);
        int maxpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 10) : ((pagenumber / 10) * 10);

        if (maxpagenumtodisplay > numberofpages)
        {
            if ((maxpagenumtodisplay - numberofpages) < minpagenumtodisplay) minpagenumtodisplay = minpagenumtodisplay - (maxpagenumtodisplay - numberofpages);
            maxpagenumtodisplay = numberofpages;
        }

        // Forms the paging tab string
        string pagingtableHTML = "<table  style=\"border:none; float:left; \"><tr> ";

        if (recordcount > 10 && minpagenumtodisplay > 1) // Applied if number of pages are greater than 10 and number of records are more than page size
        {
            pagingtableHTML += "<td><a href=\"javascript:" + functionToCall + "('" + Convert.ToString(minpagenumtodisplay - 1) + "')\">...</a></td>";
        }

        // Forms the Paging Number HTML .... for the range
        for (int icount = minpagenumtodisplay; icount <= maxpagenumtodisplay; icount++)
        {
            if (pagenumber == icount)
                pagingtableHTML += "<td style=\" padding:4px; \">" + Convert.ToString(icount) + "</td>";
            else
                pagingtableHTML += "<td style=\" padding:4px;\"><a href=\"javascript:" + functionToCall + "('" + Convert.ToString(icount) + "')\">" + Convert.ToString(icount) + "</a></td>";
        }

        if (numberofpages > 10 && maxpagenumtodisplay < numberofpages) // Applied if number of pages are greater than 10 and there are still more pages to come.
        {
            pagingtableHTML += "<td><a href=\"javascript:" + functionToCall + "('" + Convert.ToString(maxpagenumtodisplay + 1) + "')\">...</a></td>";
        }
        pagingtableHTML += " </tr></table>";
        return pagingtableHTML;
    }
    #endregion

}
