using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;

namespace Falcon.App.UI.App.Common
{
    public partial class AsyncManageHost : Page
    {
        /// <summary>
        /// Get the boolean value to display salesperson dropdown
        /// </summary>
        private bool FranchiseeView { get; set; }
        protected string _prospectDetailsPage = string.Empty;

        public AsyncManageHost()
        {
            FranchiseeView = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current != null)
                {
                    var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

                    if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                    {
                        FranchiseeView = true;
                        _prospectDetailsPage = "/App/Franchisor/ProspectDetails.aspx?Type=Host";
                    }
                    else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
                    {
                        _prospectDetailsPage = "/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Host";
                    }
                    SearchProspects();
                }
                else
                {
                    string redirectUrl = ConfigurationManager.AppSettings["SessionExpireRedirectPage"];
                    Response.RedirectUser(redirectUrl);
                }
            }
            catch (Exception ex)
            {
                string errorMessage= "<div style='float:left; width:746px; border:solid 1px #E7F0F5; padding:10px 0px 10px 0px; display:block;' runat='server'>";
                errorMessage = errorMessage + "<p class='divnoitemtxt_custdbrd'>" + " <b> Some Error occured, data could not be loaded. Message: " + ex.Message + " </b></p>";
                Response.Write(errorMessage);
            }
            finally
            {
                Response.End();
            }
        }

        /// <summary>
        /// Method to search prospects based on search criteria
        /// </summary>
        private void SearchProspects()
        {
            
            // format phone no.
            CommonCode objCommonCode = new CommonCode();

            //saving search parameter
            var parameterString = new string[18];
            bool blnReset = false;
            string roleName = string.Empty;            
            // reset flag
            if (Request["isreset"] != null && Request["isreset"] == "true")
            {
                blnReset = true;
                Session["ParameterStringHost"] = null;
            }

            if (Session["ParameterStringHost"] != null && blnReset == false)
            {
                parameterString = (string[])Session["ParameterStringHost"];
            }

            if (Request["prospectname"] != null) parameterString[0] = Request["prospectname"];
            if (Request["startdate"] != null) parameterString[1] = Request["startdate"];
            if (Request["enddate"] != null) parameterString[2] = Request["enddate"];
            if (Request["salesrepid"] != null) parameterString[3] = Request["salesrepid"];
            if (Request["distance"] != null) parameterString[4] = Request["distance"];
            if (Request["zipcode"] != null) parameterString[5] = Request["zipcode"];
            if (Request["status"] != null) parameterString[6] = Request["status"];
            if (Request["hasevent"] != null) parameterString[7] = Request["hasevent"];
            if (Request["territory"] != null) parameterString[8] = Request["territory"];
            if (Request["pagenumber"] != null) parameterString[9] = Request["pagenumber"];
            if (Request["pagesize"] != null) parameterString[10] = Request["pagesize"];
            // Assigned To 
            if (Request["assignedTo"] != null) parameterString[16] = Request["assignedTo"];
            // login role
            if (Request["role"] != null) roleName = Request["role"];
            // prospectTypeId
            if (Request["hostType"] != null) parameterString[17] = Request["hostType"];

            Session["ParameterStringHost"] = parameterString;

            long franchiseeid = 0;
            int territoryid = 0;
            string strProspectName = string.Empty;
            string strStartDate = string.Empty;
            string strEndDate = string.Empty;
            long iSalesPersonId = 0;
            long prospectTypeId = 0;
            int istatusId = 0;
            int itypeId = 0;

            string strUserId = string.Empty;
            string strZipCode = string.Empty;
            string strDistance = "0";
            string strNotesToolTip = string.Empty;
            const int isFeeder = 4;

            string strSortColomn = string.Empty;
            string strSortOrder = string.Empty;
            int iPageSize = 5;
            int iPageIndex = 1;
            long iTotalRecord;
            long assignedTo = 0;

            var objFranchisorDal=new FranchisorDAL();
            EProspect[] objProspects = null;

            // Prospect Name
            if (!string.IsNullOrEmpty(parameterString[0]))
            {
                strProspectName = parameterString[0];
            }
            // Start Name
            if (!string.IsNullOrEmpty(parameterString[1]))
            {
                strStartDate = parameterString[1];
            }
            // End Name
            if (!string.IsNullOrEmpty(parameterString[2]))
            {
                strEndDate = parameterString[2];
            }
            // SalesPersonId
            if (!string.IsNullOrEmpty(parameterString[3]))
            {
                iSalesPersonId = Convert.ToInt64(parameterString[3]);
            }

            if (!string.IsNullOrEmpty(parameterString[4]) && (!string.IsNullOrEmpty(parameterString[5])))
            {
                strDistance = parameterString[4];
                strZipCode = parameterString[5];
            }

            //StatusID
            if (!string.IsNullOrEmpty(parameterString[6]))
            {
                istatusId = Convert.ToInt32(parameterString[6]);
            }
            //event status
            if (!string.IsNullOrEmpty(parameterString[7]))
            {
                itypeId = Convert.ToInt32(parameterString[7]);
            }
            // Territory id
            if (!string.IsNullOrEmpty(parameterString[8]))
            {
                territoryid = Convert.ToInt32(parameterString[8]);
            }

            // Get Page Number
            if (!string.IsNullOrEmpty(parameterString[9]))
            {
                iPageIndex = Convert.ToInt32(parameterString[9]);
            }

            // Get Page Size
            if (!string.IsNullOrEmpty(parameterString[10]))
            {
                iPageSize = Convert.ToInt32(parameterString[10]);
            }

            // Franchisee id
            if (!string.IsNullOrEmpty(Request["franchiseeid"]))
            {
                franchiseeid = Convert.ToInt64(Request["franchiseeid"]);
            }
            
            // AssignedTo (FranchiFranchiseesUserId)
            if (!string.IsNullOrEmpty(parameterString[16]))
            {
                assignedTo = Convert.ToInt64(parameterString[16]);
            }
            // ProspectTypeId 
            if (!string.IsNullOrEmpty(parameterString[17]))
            {
                prospectTypeId = Convert.ToInt64(parameterString[17]);
            }

            // Get Sort Column
            if (!string.IsNullOrEmpty(Request["sortcolumn"]))
            {
                strSortColomn = Request["sortcolumn"];
            }
            // Get Sort Order
            if (!string.IsNullOrEmpty(Request["sortorder"]))
            {
                strSortOrder = Request["sortorder"];
            }
            if (strSortOrder.Equals("Ascending")) strSortOrder = " Asc ";
            if (strSortOrder.Equals("Descending")) strSortOrder = " Desc ";

            //Get data for salesperson selected in dropdown id true else call all data
            if (FranchiseeView)
            {
                if (strUserId == "" && strZipCode == "" && (strDistance == "" || strDistance == "0"))
                {
                    var listProspects = objFranchisorDal.GetProspectsDetail(strProspectName, strStartDate, strEndDate,
                        franchiseeid, istatusId, itypeId, 2, "", 0, 1, isFeeder, iSalesPersonId,
                        territoryid, strSortColomn, strSortOrder, iPageSize, iPageIndex, out iTotalRecord, 2, 2, 2, assignedTo, roleName, prospectTypeId);
                    if (listProspects != null)
                    {
                        objProspects = listProspects.ToArray();
                    }
                }
                else if (strUserId != "" && strZipCode != "" && strDistance != "" && strDistance != "0")
                {
                    var listProspects = objFranchisorDal.GetProspectsDetail(strProspectName, strStartDate, strEndDate,
                        franchiseeid, istatusId, itypeId, 2, strZipCode, Convert.ToInt32(strDistance), 1, isFeeder,
                        iSalesPersonId, territoryid, strSortColomn, strSortOrder, iPageSize, iPageIndex, out iTotalRecord, 2, 2, 2, assignedTo, roleName, prospectTypeId);
                    if (listProspects != null)
                    {
                        objProspects = listProspects.ToArray();
                    }
                }
                else
                {
                    var listProspects = objFranchisorDal.GetProspectsDetail(strProspectName, strStartDate, strEndDate,
                        franchiseeid, istatusId, itypeId, 2, strZipCode, Convert.ToInt32(strDistance), 1, isFeeder,
                        Convert.ToInt64(iSalesPersonId), territoryid, strSortColomn, strSortOrder, iPageSize, iPageIndex, out iTotalRecord, 2, 2, 2, assignedTo, roleName, prospectTypeId);
                    if (listProspects != null)
                    {
                        objProspects = listProspects.ToArray();
                    }
                }
            }
            else
            {
                string shellId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId.ToString();
                var listProspects = objFranchisorDal.GetProspectsDetail(strProspectName, strStartDate, strEndDate,
                    long.Parse(shellId), istatusId, itypeId, 2, strZipCode, int.Parse(strDistance), 1, isFeeder,
                    iSalesPersonId, territoryid, strSortColomn, strSortOrder, iPageSize, iPageIndex, out iTotalRecord, 2, 2, 2, assignedTo, roleName, prospectTypeId);
                if (listProspects != null)
                {
                    objProspects = listProspects.ToArray();
                }
            }

            if (objProspects != null)
            {
                if (objProspects.Length == 1 && Request.QueryString["QuickSearch"] != null &&
                    Request.QueryString["QuickSearch"].Equals("True"))
                {
                    Response.Write("/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Host&QuickSearch=True&ProspectID=" +
                        objProspects[0].ProspectID);
                }
                else
                {
                    var dtProspect = new DataTable();

                    //Create template for data table
                    dtProspect.Columns.Add("ProspectId", typeof (Int32));
                    dtProspect.Columns.Add("ProspectName");
                    dtProspect.Columns.Add("ProspectCreatedDate");
                    dtProspect.Columns.Add("PhoneOffice");
                    dtProspect.Columns.Add("ProspectStatus");
                    dtProspect.Columns.Add("NoOFCalls");
                    dtProspect.Columns.Add("NoOFMeeting");

                    dtProspect.Columns.Add("NoOfContacts");
                    dtProspect.Columns.Add("SalesPersonFirstName");
                    dtProspect.Columns.Add("SalesPersonLastName");
                    dtProspect.Columns.Add("FranchiseeName");
                    dtProspect.Columns.Add("ProspectAddressId");
                    dtProspect.Columns.Add("ProspectAddress1");
                    dtProspect.Columns.Add("ProspectAddress2");
                    dtProspect.Columns.Add("ProspectCity");
                    dtProspect.Columns.Add("ProspectState");

                    dtProspect.Columns.Add("ProspectZip");
                    dtProspect.Columns.Add("ProspectCountry");
                    dtProspect.Columns.Add("ProspectCompleteAddress");

                    dtProspect.Columns.Add("ContactFirstName");
                    dtProspect.Columns.Add("ContactLastName");
                    dtProspect.Columns.Add("ContactPhone");
                    dtProspect.Columns.Add("ContactEmail");

                    dtProspect.Columns.Add("ContactCallDate");
                    dtProspect.Columns.Add("ContactCallStatus");

                    dtProspect.Columns.Add("LnkContactViewAll");
                    dtProspect.Columns.Add("LnkContactAddCall");
                    dtProspect.Columns.Add("LnkContactAddMeeting");
                    dtProspect.Columns.Add("LnkactivityNotes");
                    dtProspect.Columns.Add("LnkViewDetails");
                    dtProspect.Columns.Add("LnkAddContact");
                    dtProspect.Columns.Add("LnkConvertToHost");
                    dtProspect.Columns.Add("NotesToolTip");


                    //Add all the fetched data tto data table
                    if (objProspects.Length > 0)
                    {
                        //// Case SalesRep
                        //if (usershellmodulerole.RoleName == Roles.SalesRep.ToString())
                        //{
                        //    //TODO: This filter is only for SaleRep and need to do for Franchisee also

                        //    // Sales Reps with territory assignments should only see hosts applicable to them.
                        //    long salesRepId = usershellmodulerole.RoleShellID;
                        //    ITerritoryRepository territoryRepository = new TerritoryRepository();
                        //    IHostRepository hostRepository = new HostRepository();
                        //    List<SalesRepTerritory> salesRepTerritories = territoryRepository.GetTerritoriesForSalesRep(salesRepId);
                        //    if (!salesRepTerritories.IsEmpty())
                        //    {
                        //        IEnumerable<string> acceptableZipCodes = salesRepTerritories.
                        //            SelectMany(srt => srt.ZipCodes).Distinct().Select(z => z.Zip);

                        //        // Filter out hosts not located in zip codes of this sales rep's territories.
                        //        objProspects = objProspects.Where(p => acceptableZipCodes.Contains(p.Address.Zip)).ToArray();

                        //        // Filter out hosts that do not host events of the type that the sales rep can see.
                        //        var prospectsToRemove = new List<EProspect>();
                        //        foreach (EProspect prospect in objProspects)
                        //        {
                        //            string hostingZipCode = prospect.Address.Zip;
                        //            SalesRepTerritory territoryEventIsHostedIn = salesRepTerritories.Single(srt => srt.ZipCodes.Select(z => z.Zip).
                        //                Contains(hostingZipCode));
                        //            EventType salesRepPermission = territoryEventIsHostedIn.SalesRepTerritoryAssignments.
                        //                Single(srta => srta.SalesRep.SalesRepresentativeId == salesRepId).EventTypeSetupPermission;

                        //            var acceptableEventTypes = hostRepository.GetEventTypesForHost(prospect.ProspectID);
                        //            if (salesRepPermission != EventType.Both && !acceptableEventTypes.Contains(salesRepPermission))
                        //            {
                        //                prospectsToRemove.Add(prospect);
                        //            }
                        //        }
                        //        objProspects = objProspects.Except(prospectsToRemove).ToArray();
                        //        iTotalRecord = objProspects.Count();
                        //    }
                        //}

                        foreach (var objProspect in objProspects)
                        {
                            DataRow drProspect = dtProspect.NewRow();
                            drProspect["ProspectId"] = objProspect.ProspectID;
                            drProspect["ProspectName"] = string.IsNullOrEmpty(objProspect.OrganizationName) ? "N/A" : objProspect.OrganizationName;
                            drProspect["ProspectCreatedDate"] = string.IsNullOrEmpty(objProspect.ProspectDate) ? "N/A" :
                                Convert.ToDateTime(objProspect.ProspectDate).ToShortDateString();
                            drProspect["PhoneOffice"] = !string.IsNullOrEmpty(objProspect.PhoneOffice) ? objCommonCode.FormatPhoneNumberGet(objProspect.PhoneOffice) : "N/A";

                            if (string.IsNullOrEmpty(objProspect.Status))
                            {
                                drProspect["ProspectStatus"] = "N/A";
                            }
                            else
                            {
                                string status;
                                switch (objProspect.Status)
                                {
                                    case "1":
                                        status = "Hot";
                                        break;
                                    case "2":
                                        status = "Cold";
                                        break;
                                    case "3":
                                        status = "Dead";
                                        break;
                                    case "4":
                                        status = "Call Back";
                                        break;
                                    default:
                                        status = "none";
                                        break;
                                }
                                drProspect["ProspectStatus"] = status;
                            }

                            drProspect["NoOFCalls"] = objProspect.NoOfCalls;
                            drProspect["NoOFMeeting"] = objProspect.NoOfMeetings;
                            drProspect["NoOfContacts"] = objProspect.NoOfContacts;

                            if (string.IsNullOrEmpty(objProspect.FirstName) && string.IsNullOrEmpty(objProspect.LastName))
                            {
                                drProspect["SalesPersonFirstName"] = "N/A";
                                drProspect["SalesPersonLastName"] = "";
                            }
                            else
                            {
                                drProspect["SalesPersonFirstName"] = objProspect.FirstName;
                                drProspect["SalesPersonLastName"] = objProspect.LastName;
                            }
                            if (string.IsNullOrEmpty(objProspect.FranchiseeName))
                                drProspect["FranchiseeName"] = "N/A";
                            else
                                drProspect["FranchiseeName"] = objProspect.FranchiseeName;

                            
                            var objAddress = objProspect.Address;

                            // Set Initially the new line in address
                            drProspect["ProspectAddressId"] = objAddress.AddressID.ToString();
                            drProspect["ProspectAddress1"] = string.IsNullOrEmpty(objAddress.Address1) ? "" : objAddress.Address1;
                            drProspect["ProspectAddress2"] = string.IsNullOrEmpty(objAddress.Address2) ? "" : objAddress.Address2;
                            drProspect["ProspectCity"] = string.IsNullOrEmpty(objAddress.City) ? "N/A" : objAddress.City;
                            drProspect["ProspectState"] = string.IsNullOrEmpty(objAddress.State) ? "N/A" : objAddress.State;

                            if (string.IsNullOrEmpty(objAddress.Zip) || (objAddress.Zip == "0"))
                            {
                                drProspect["ProspectZip"] = "N/A";
                            }
                            else
                            {
                                drProspect["ProspectZip"] = objAddress.Zip;
                            }

                            // Format Address
                            string prospectCompleteAddress = CommonCode.AddressMultiLine(objAddress.Address1,
                                objAddress.Address2, objAddress.City, objAddress.State, objAddress.Zip);
                            drProspect["ProspectCompleteAddress"] = prospectCompleteAddress;

                            var objContact = objProspect.Contact.ToArray();
                            if (string.IsNullOrEmpty(objContact[0].FirstName))
                            {
                                if (string.IsNullOrEmpty(objContact[0].LastName))
                                {
                                    drProspect["ContactFirstName"] = "N/A";
                                    drProspect["ContactLastName"] = "";
                                }
                                else
                                {
                                    drProspect["ContactFirstName"] = objContact[0].FirstName;
                                    drProspect["ContactLastName"] = objContact[0].LastName;
                                }
                            }
                            else
                            {
                                drProspect["ContactFirstName"] = objContact[0].FirstName;
                                drProspect["ContactLastName"] = objContact[0].LastName;
                            }

                            if (string.IsNullOrEmpty(objContact[0].PhoneHome))
                            {
                                drProspect["ContactPhone"] = "N/A";
                            }
                            else if (objContact[0].PhoneHome.Trim().Equals("(___)-___-____"))
                            {
                                drProspect["ContactPhone"] = "N/A";
                            }
                            else
                            {
                                drProspect["ContactPhone"] = objCommonCode.FormatPhoneNumberGet(objContact[0].PhoneHome);
                            }

                            drProspect["ContactEmail"] = string.IsNullOrEmpty(objContact[0].EMail) ? "N/A" : objContact[0].EMail;

                            var objContactCall = objProspect.ContactCall;
                            drProspect["ContactCallDate"] = string.IsNullOrEmpty(objContactCall.StartDate) ? "N/A" : objContactCall.StartDate;


                            var objCallStatus = objContactCall.CallStatus;
                            drProspect["ContactCallStatus"] = string.IsNullOrEmpty(objCallStatus.Status) ? "N/A" : objCallStatus.Status;

                            // Prepare Notes ToolTips
                            bool blnNotes = false;
                            strNotesToolTip = strNotesToolTip + "<table cellpadding='3' cellspacing='0' border='0' width='100%'>";
                            // Date and Time
                            if (!string.IsNullOrEmpty(objContactCall.StartDate))
                            {
                                string[] strDateTime = objContactCall.StartDate.Split(' ');
                                if (strDateTime.Length >= 2)
                                {
                                    strNotesToolTip = strNotesToolTip + "<tr><td>Date: " + strDateTime[0] +
                                        "</td><td>Time: " + strDateTime[1] + "</td></tr>";
                                    blnNotes = true;
                                }
                            }
                            // Duration
                            if (!string.IsNullOrEmpty(objCallStatus.Duration) && (objCallStatus.Duration != "0.00"))
                            {
                                strNotesToolTip = strNotesToolTip + "<tr><td colspan=2>Duration: " +
                                    objCallStatus.Duration + " mins.</td></tr>";
                                blnNotes = true;
                            }
                            // Status
                            if (!string.IsNullOrEmpty(objCallStatus.Status))
                            {
                                strNotesToolTip = strNotesToolTip + "<tr><td colspan=2>Status: " + objCallStatus.Status +
                                    "</td></tr>";
                                blnNotes = true;
                            }
                            // Notes
                            if (!string.IsNullOrEmpty(objCallStatus.Notes))
                            {
                                strNotesToolTip = strNotesToolTip + "<tr><td colspan=2>Notes: </td></tr><tr><td colspan=2>" +
                                    objCallStatus.Notes + "</td></tr>";
                                blnNotes = true;
                            }
                            strNotesToolTip = strNotesToolTip + "</table>";

                            drProspect["NotesToolTip"] = blnNotes ? strNotesToolTip
                                : "<table cellpadding='3' cellspacing='0' border='0' width='100%'><tr><td> Details Not Available </td></tr></table>";
                            strNotesToolTip = string.Empty;
                            dtProspect.Rows.Add(drProspect);
                        }
                    }

                    if (dtProspect.Rows.Count > 0)
                    {
                        grdProspect.DataSource = dtProspect;
                        grdProspect.DataBind();
                        string pagingstring = ImplementPaging(iPageIndex, iPageSize, iTotalRecord);

                        HtmlForm formNew = Page.Form;
                        formNew.Controls.Clear();
                        formNew.Controls.Add(grdProspect);

                        var sb = new System.Text.StringBuilder();
                        var htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));

                        formNew.RenderControl(htWriter);

                        string strRenderedHTML = sb.ToString();
                        int startindex = strRenderedHTML.IndexOf("<table");
                        int endindex = strRenderedHTML.LastIndexOf("</table>");
                        int length = (endindex - startindex) + 8;
                        strRenderedHTML = strRenderedHTML.Substring(startindex, length);
                        string totalRecord = "<span id=spnTotalRecordAsync>" + iTotalRecord + "</span>";
                        strRenderedHTML = "<div style='float: left; width: 746px'>" + strRenderedHTML + "</div>";

                        Response.Write(strRenderedHTML + pagingstring +
                            "<p class=\"blueboxbotbg_cl\"><img src=\"/App/Images/specer.gif\" width=\"746\" height=\"5\" /></p>" + totalRecord);
                    }
                    else
                    {
                        string noRecordFound =
                            "<div style='float:left; width:746px; border:solid 1px #E7F0F5; padding:10px 0px 10px 0px; display:block;' id='dvNoProspectFound' runat='server'>";
                        noRecordFound = noRecordFound +
                            "<div class='divnoitemfound_custdbrd' style='margin-top:0px;'><p class='divnoitemtxt_custdbrd'><span class='orngbold18_default'>No Records Found</span></p></div></div>";
                        Response.Write(noRecordFound);
                    }
                }
            }
        }

        /// <summary>
        /// Hides convert to host button for franchisor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdProspect_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // format phone no.
            CommonCode objCommonCode = new CommonCode();

            if (FranchiseeView)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

                    if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                    {
                        var franchiseeName = e.Row.FindControl("spFranchisee") as HtmlContainerControl;
                        franchiseeName.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }
                    else if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                    {
                        var spanRateHost = e.Row.FindControl("HostRatingSpan") as HtmlContainerControl;
                        if (spanRateHost != null)
                            spanRateHost.Style[HtmlTextWriterStyle.Display] = "block";
                    }
                }
            }           
            // Code to visible primary contact link
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var googleAddressVerification = e.Row.FindControl("googleAddressVerification") as HtmlContainerControl;
                
                var spnName = (HtmlContainerControl)e.Row.FindControl("spnName");
                var spnPhone = (HtmlContainerControl)e.Row.FindControl("spnPhone");
                var spnEmail = (HtmlContainerControl)e.Row.FindControl("spnEmail");
                var spnAddPrimaryContact = (HtmlContainerControl)e.Row.FindControl("spnAddPrimaryContact");
                var divNamePhoneEmail = (HtmlContainerControl)e.Row.FindControl("divNamePhoneEmail");

                if (googleAddressVerification != null)
                {

                }
                spnName.InnerText = spnName.InnerText.Trim();
                spnPhone.InnerText = objCommonCode.FormatPhoneNumberGet(spnPhone.InnerText.Trim());
                spnEmail.InnerText = spnEmail.InnerText.Trim();
                if (spnName.InnerText.Equals("N/A") && spnPhone.InnerText.Equals("N/A") && spnEmail.InnerText.Equals("N/A"))
                {

                    spnAddPrimaryContact.Style.Add(HtmlTextWriterStyle.Display, "block");
                    spnAddPrimaryContact.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                    // Hide all span
                    divNamePhoneEmail.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divNamePhoneEmail.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
                else
                {
                    spnAddPrimaryContact.Style.Add(HtmlTextWriterStyle.Display, "none");
                    spnAddPrimaryContact.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
            }
        }

        private string ImplementPaging(long pagenumber, long pagesize, long recordcount)
        {

            if (recordcount <= pagesize) return "";

            // Calculates Total number of pages possible
            long numberofpages = recordcount / pagesize;
            if ((pagesize * numberofpages) != recordcount) numberofpages++;

            //Calculates first and last page number to display in paging tab, so as to decide whole range
            long minpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 1) : ((((pagenumber / 10) - 1) * 10) + 1);
            long maxpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 10) : ((pagenumber / 10) * 10);

            if (maxpagenumtodisplay > numberofpages)
            {
                if ((maxpagenumtodisplay - numberofpages) < minpagenumtodisplay) minpagenumtodisplay = minpagenumtodisplay - (maxpagenumtodisplay - numberofpages);
                maxpagenumtodisplay = numberofpages;
            }

            // Forms the paging tab string
            string pagingtableHTML = "<table  style=\"border:none; float:left; \"><tr> ";

            if (recordcount > 10 && minpagenumtodisplay > 1) // Applied if number of pages are greater than 10 and number of records are more than page size
            {
                pagingtableHTML += "<td><a href=\"javascript:LoadProspectTableonPageChange('" + Convert.ToString(minpagenumtodisplay - 1) + "')\">...</a></td>";
            }

            // Forms the Paging Number HTML .... for the range
            for (long icount = minpagenumtodisplay; icount <= maxpagenumtodisplay; icount++)
            {
                if (pagenumber == icount)
                {
                    pagingtableHTML += "<td style=\" padding:4px; \">" + Convert.ToString(icount) + "</td>";
                }
                else
                {
                    pagingtableHTML += "<td style=\" padding:4px;\"><a href=\"javascript:LoadProspectTableonPageChange('" +
                                       Convert.ToString(icount) + "')\">" + Convert.ToString(icount) + "</a></td>";
                }
            }

            if (numberofpages > 10 && maxpagenumtodisplay < numberofpages) // Applied if number of pages are greater than 10 and there are still more pages to come.
            {
                pagingtableHTML += "<td><a href=\"javascript:LoadProspectTableonPageChange('" + Convert.ToString(maxpagenumtodisplay + 1) + "')\">...</a></td>";
            }

            pagingtableHTML += " </tr></table>";
            return pagingtableHTML;
        }
    }
}