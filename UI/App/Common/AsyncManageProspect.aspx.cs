using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.App.Lib;

namespace HealthYes.Web.App.Common
{
    public partial class AsyncManageProspect : Page
    {
        /// <summary>
        /// Get the boolean value to display salesperson dropdown
        /// </summary>
        public bool FranchiseeView { get; set; }

        protected string strProspectDetailsPage = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
                if (HttpContext.Current != null)
                {
                    if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                    {
                        FranchiseeView = true;
                        strProspectDetailsPage = "/App/Franchisor/ProspectDetails.aspx?Type=Prospect";
                    }
                    else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
                    {
                        strProspectDetailsPage = "/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Prospect";
                    }
                    SearchProspects();
                }
                else
                {
                    string strRedirectURL = ConfigurationManager.AppSettings["SessionExpireRedirectPage"];
                    Response.RedirectUser(strRedirectURL);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "<div style='float:left; width:746px; border:solid 1px #E7F0F5; padding:10px 0px 10px 0px; display:block;' runat='server'>";
                errorMessage = errorMessage + "<p class='divnoitemtxt_custdbrd'>" + " <b> Some Error occured, data could not be loaded. Message: " + ex.Message + " </b></p>";
                Response.Write(errorMessage);
            }
            finally
            {
                Response.End();
            }
        }

        private void SearchProspects()
        {
            // format phone no.
            CommonCode objCommonCode = new CommonCode();

            //saving search parameter 
            var parameterString = new string[17];
            bool blnReset=false;
            string roleName = string.Empty;
            // reset flag
            if (Request["isreset"] != null && Request["isreset"] == "true")
            {
                blnReset = true;
                Session["ParameterStringProspect"] = null;
            }

            if (Session["ParameterStringProspect"] != null && blnReset==false)
            {
                parameterString = (string[])Session["ParameterStringProspect"];
            }
            
            // prospect name 
            if (Request["prospectname"] != null) parameterString[0] = Request["prospectname"];
            //start date
            if (Request["startdate"] != null) parameterString[1] = Request["startdate"];
            //end date
            if (Request["enddate"] != null) parameterString[2] = Request["enddate"];
            //sales person
            if (Request["salesrepid"] != null) parameterString[3] = Request["salesrepid"];
            //distance
            if (Request["distance"] != null) parameterString[4] = Request["distance"];
            // zipcode
            if (Request["zipcode"] != null) parameterString[5] = Request["zipcode"];
            // progress
            if (Request["progress"] != null) parameterString[6] = Request["progress"];
            // type
            if (Request["type"] != null) parameterString[7] = Request["type"];
            // assigned status
            if (Request["assignedstatus"] != null) parameterString[8] = Request["assignedstatus"];
            // territory
            if (Request["territory"] != null) parameterString[9] = Request["territory"];
            // page number
            if (Request["pagenumber"] != null) parameterString[10] = Request["pagenumber"];
            // page size
            if (Request["pagesize"] != null) parameterString[11] = Request["pagesize"];
            // will promote
            if (Request["willpromote"] != null) parameterString[12] = Request["willpromote"];
            // will host
            if (Request["willhost"] != null) parameterString[13] = Request["willhost"];
            // hosted in past
            if (Request["hostedinpast"] != null) parameterString[14] = Request["hostedinpast"];
            // prospect list id
            parameterString[15] = Request["prospectlistid"] ?? "0";
            // Assigned To 
            if (Request["assignedTo"] != null) parameterString[16] = Request["assignedTo"];
            // login role
            if (Request["role"] != null) roleName = Request["role"];
            Session["ParameterStringProspect"] = parameterString;

            long prospectListId = 0;
            long franchiseeid = 0;
            int territoryId = 0;
            string strProspectName = string.Empty;
            string strStartDate = string.Empty;
            string strEndDate = string.Empty;
            long iSalesPersonId = 0;
            int istatusId = 0;
            int itypeId = 0;

            string strUserId = string.Empty;
            string strZipCode = string.Empty;
            string strDistance = "0";
            string strNotesToolTip = string.Empty;
            int isAssigned = 0;
            string strSortColomn = "";
            string strSortOrder = " Asc";
            int iPageSize = 5;
            int iPageIndex = 1;
            long iTotalRecord;
            int iWillPrompte = 3;
            int iWillHost = 3;
            int iHostedInPast = 3;
            long assignedTo = 0;

            Falcon.Entity.Other.EProspect[] objProspects = null;
            var objFranchisorDal=new FranchisorDAL();

            // Prospect ListID
            if (!string.IsNullOrEmpty(parameterString[15]))
            {
                if (parameterString[15]!="0")
                prospectListId = Convert.ToInt64(parameterString[15]);
            }
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
            //StatusID
            if (!string.IsNullOrEmpty(parameterString[6]))
            {
                istatusId = Convert.ToInt32(parameterString[6]);
            }
            //TypeId
            if (!string.IsNullOrEmpty(parameterString[7]))
            {
                itypeId = Convert.ToInt32(parameterString[7]);
            }
            // Assign Status
            if (!string.IsNullOrEmpty(parameterString[8]))
            {
                isAssigned = Convert.ToInt32(parameterString[8]);
            }
            if (!string.IsNullOrEmpty(parameterString[4]) && (!string.IsNullOrEmpty(parameterString[5])))
            {
                strDistance = parameterString[4];
                strZipCode = parameterString[5];
            }
            // Will Promote
            if (!string.IsNullOrEmpty(parameterString[12]))
            {
                iWillPrompte = Convert.ToInt32(parameterString[12]);
            }
            // Will Host
            if (!string.IsNullOrEmpty(parameterString[13]))
            {
                iWillHost = Convert.ToInt32(parameterString[13]);
            }
            // Hosted In Past
            if (!string.IsNullOrEmpty(parameterString[14]))
            {
                iHostedInPast = Convert.ToInt32(parameterString[14]);
            }
            // Get Page Size
            if (!string.IsNullOrEmpty(parameterString[11]))
            {
                iPageSize = Convert.ToInt32(parameterString[11]);
            }
            // Get Page Size
            if (!string.IsNullOrEmpty(parameterString[10]))
            {
                iPageIndex = Convert.ToInt32(parameterString[10]);
            }
            // Franchisee id
            if (!string.IsNullOrEmpty(Request["franchiseeid"]))
            {
                franchiseeid = Convert.ToInt64(Request["franchiseeid"]);
            }
            // Territory id
            if (!string.IsNullOrEmpty(parameterString[9]))
            {
                territoryId = Convert.ToInt32(parameterString[9]);
            }
            // AssignedTo (FranchiFranchiseesUserId)
            if (!string.IsNullOrEmpty(parameterString[16]))
            {
                assignedTo = Convert.ToInt64(parameterString[16]);
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
            // Case when prospect list
            if (prospectListId > 0)
            {
                var listProspects = objFranchisorDal.GetProspectsDetailByProspectListID(prospectListId, 1, out iTotalRecord, iPageSize, iPageIndex, strSortColomn, strSortOrder, assignedTo);
                if (listProspects != null)
                    objProspects = listProspects.ToArray();
            }
            // normal case
            else
            {
                //Get data for salesperson selected in dropdown id true else call all data
                if (FranchiseeView)
                {
                    if (strUserId == "" && strZipCode == "" && (strDistance == "" || strDistance == "0"))
                    {
                        var listProspects = objFranchisorDal.GetProspectsDetail(strProspectName, strStartDate,
                                                                                 strEndDate, franchiseeid, istatusId,
                                                                                 itypeId, 0, "", 0, 0, isAssigned,
                                                                                 iSalesPersonId,
                                                                                 territoryId, strSortColomn,
                                                                                 strSortOrder, iPageSize, iPageIndex,
                                                                                 out iTotalRecord, iWillPrompte,
                                                                                 iWillHost, iHostedInPast, assignedTo, roleName,0);
                        if (listProspects != null)
                            objProspects = listProspects.ToArray();
                        
                    }
                    else if (strUserId != "" && strZipCode != "" && strDistance != "" && strDistance != "0")
                    {
                        var listProspects = objFranchisorDal.GetProspectsDetail(strProspectName, strStartDate,
                                                                                strEndDate, franchiseeid, istatusId,
                                                                                itypeId, 0, strZipCode,
                                                                                Convert.ToInt32(strDistance), 0,
                                                                                isAssigned,
                                                                                iSalesPersonId,
                                                                                territoryId, strSortColomn, strSortOrder,
                                                                                iPageSize, iPageIndex, out iTotalRecord,
                                                                                iWillPrompte, iWillHost, iHostedInPast, assignedTo, roleName,0);
                                                                   
                        if (listProspects != null)
                            objProspects = listProspects.ToArray();
                        
                    }
                    else
                    {
                        var listProspects = objFranchisorDal.GetProspectsDetail(strProspectName, strStartDate,
                                                                                strEndDate, franchiseeid, istatusId,
                                                                                itypeId, 0, strZipCode,
                                                                                Convert.ToInt32(strDistance), 0,
                                                                                isAssigned,
                                                                                iSalesPersonId,
                                                                                territoryId, strSortColomn, strSortOrder,
                                                                                iPageSize, iPageIndex, out iTotalRecord,
                                                                                iWillPrompte, iWillHost, iHostedInPast, assignedTo, roleName,0);
                        if (listProspects != null)
                            objProspects = listProspects.ToArray();
                    }
                }
                else
                {
                    string shellId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId.ToString();
                    var listProspects = objFranchisorDal.GetProspectsDetail(strProspectName, strStartDate, strEndDate, Convert.ToInt64(shellId), istatusId, itypeId, 1, strZipCode, Convert.ToInt32(strDistance), 0, isAssigned, iSalesPersonId, territoryId, strSortColomn, strSortOrder, iPageSize, iPageIndex, out iTotalRecord, iWillPrompte, iWillHost, iHostedInPast, assignedTo, roleName,0);
                    if (listProspects != null)
                        objProspects = listProspects.ToArray();
                }
            }

            if (objProspects.Length == 1 && Request.QueryString["QuickSearch"] != null && Request.QueryString["QuickSearch"].Equals("True"))
            {
                Response.Write("/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Prospect&QuickSearch=True&ProspectID=" + objProspects[0].ProspectID);
            }
            else
            {
                var dtProspect = new DataTable();

                //Create template for data table

                dtProspect.Columns.Add("ProspectId", typeof(Int32));
                dtProspect.Columns.Add("ProspectName");
                dtProspect.Columns.Add("ProspectCreatedDate");
                dtProspect.Columns.Add("PhoneOffice");
                dtProspect.Columns.Add("ProspectStatus");
                dtProspect.Columns.Add("AssignedStatus");
                dtProspect.Columns.Add("NoOFCalls");
                dtProspect.Columns.Add("NoOFMeeting");

                dtProspect.Columns.Add("NoOfContacts");
                dtProspect.Columns.Add("SalesPersonFirstName");
                dtProspect.Columns.Add("SalesPersonLastName");
                dtProspect.Columns.Add("FranchiseeName");
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
                dtProspect.Columns.Add("ProspectStatusImage");

                //Add all the fetched data to data table
                if (objProspects != null && objProspects.Length > 0)
                {
                    foreach (var objProspect in objProspects)
                    {
                        DataRow drProspect = dtProspect.NewRow();
                        drProspect["ProspectId"] = objProspect.ProspectID;
                        drProspect["ProspectName"] = string.IsNullOrEmpty(objProspect.OrganizationName) ? "N/A" : objProspect.OrganizationName;
                        drProspect["ProspectCreatedDate"] = string.IsNullOrEmpty(objProspect.ProspectDate) ? "N/A" : 
                            Convert.ToDateTime(objProspect.ProspectDate).ToShortDateString();

                        drProspect["PhoneOffice"] = !string.IsNullOrEmpty(objProspect.PhoneOffice) ? objCommonCode.FormatPhoneNumberGet(objProspect.PhoneOffice) : "N/A";

                        drProspect["AssignedStatus"] = objProspect.AssignedStatus.ToString();

                        if (string.IsNullOrEmpty(objProspect.Status))
                            drProspect["ProspectStatus"] = "N/A";
                        else
                        {
                            string status;
                            //Set the status according to status id
                            switch (objProspect.Status)
                            {
                                case "1":
                                    status = "Hot";
                                    drProspect["ProspectStatusImage"] = "<img src='/App/Images/hot-icon.gif' alt='Hot' />";
                                    break;
                                case "2":
                                    status = "Cold";
                                    drProspect["ProspectStatusImage"] = "<img src='/App/Images/cold-icon.gif' alt='Cold' />";
                                    break;
                                case "3":
                                    status = "Warm";
                                    drProspect["ProspectStatusImage"] = "<img src='/App/Images/warm-icon.gif' alt='Warm' />";
                                    break;
                                default:
                                    status = "none";
                                    drProspect["ProspectStatusImage"] = "";
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

                        //EAddress objAddress = objProspect.Address;
                        var objAddress = objProspect.Address;

                        // Set Initially the new line in address
                        string strProspectCompleteAddress;

                        drProspect["ProspectAddress1"] = string.IsNullOrEmpty(objAddress.Address1) ? "" : objAddress.Address1;
                        drProspect["ProspectAddress2"] = string.IsNullOrEmpty(objAddress.Address2) ? "" : objAddress.Address2;
                        drProspect["ProspectCity"] = string.IsNullOrEmpty(objAddress.City) ? "N/A" : objAddress.City;
                        drProspect["ProspectState"] = string.IsNullOrEmpty(objAddress.State) ? "N/A" : objAddress.State;
                        
                        if (string.IsNullOrEmpty(objAddress.Zip) || (objAddress.Zip == "0"))
                            drProspect["ProspectZip"] = "N/A";
                        else
                        {
                            drProspect["ProspectZip"] = objAddress.Zip;
                        }
                        // Format Address
                        strProspectCompleteAddress = CommonCode.AddressMultiLine(objAddress.Address1, objAddress.Address2, objAddress.City, objAddress.State, objAddress.Zip);
                        drProspect["ProspectCompleteAddress"] = strProspectCompleteAddress;

                        var listContact = objProspect.Contact;
                        Falcon.Entity.Other.EContact[] objContact;
                        objContact = listContact.ToArray();
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
                            drProspect["ContactPhone"] = "N/A";
                        else if (objContact[0].PhoneHome.Trim().Equals("(___)-___-____"))
                            drProspect["ContactPhone"] = "N/A";
                        else
                            drProspect["ContactPhone"] = objCommonCode.FormatPhoneNumberGet(objContact[0].PhoneHome);

                        drProspect["ContactEmail"] = string.IsNullOrEmpty(objContact[0].EMail) ? "N/A" : objContact[0].EMail;

                        var objContactCall = objProspect.ContactCall;
                        drProspect["ContactCallDate"] = string.IsNullOrEmpty(objContactCall.StartDate) ? "N/A" : objContactCall.StartDate;

                        var objCallStatus = objContactCall.CallStatus;
                        if (string.IsNullOrEmpty(objCallStatus.Status))
                            drProspect["ContactCallStatus"] = "N/A";
                        else
                            drProspect["ContactCallStatus"] = objCallStatus.Status;

                        // Prepare Notes ToolTips
                        bool blnNotes = false;
                        strNotesToolTip = strNotesToolTip + "<table cellpadding='3' cellspacing='0' border='0' width='100%'>";
                        //Date and Time
                        if (!string.IsNullOrEmpty(objContactCall.StartDate))
                        {
                            string[] strDateTime = objContactCall.StartDate.Split(' ');
                            if (strDateTime.Length >= 2)
                            {
                                strNotesToolTip = strNotesToolTip + "<tr><td>Date: " + strDateTime[0] + "</td><td>Time: " + strDateTime[1] + "</td></tr>";
                                blnNotes = true;
                            }
                        }
                        // Duration
                        if (!string.IsNullOrEmpty(objCallStatus.Duration))
                        {
                            strNotesToolTip = strNotesToolTip + "<tr><td colspan=2>Duration: " + objCallStatus.Duration + " mins.</td></tr>";
                            blnNotes = true;
                        }
                        // Status
                        if (!string.IsNullOrEmpty(objCallStatus.Status))
                        {
                            strNotesToolTip = strNotesToolTip + "<tr><td colspan=2>Status: " + objCallStatus.Status + "</td></tr>";
                            blnNotes = true;
                        }
                        // Notes
                        if (!string.IsNullOrEmpty(objCallStatus.Notes))
                        {
                            strNotesToolTip = strNotesToolTip + "<tr><td colspan=2>Notes: </td></tr><tr><td colspan=2>" + objCallStatus.Notes + "</td></tr>";
                            blnNotes = true;
                        }
                        strNotesToolTip = strNotesToolTip + "</table>";

                        drProspect["NotesToolTip"] = blnNotes ? strNotesToolTip : "<table cellpadding='3' cellspacing='0' border='0' width='100%'><tr><td> Details Not Available </td></tr></table>";
                        strNotesToolTip = string.Empty;
                        dtProspect.Rows.Add(drProspect);
                    }
                }

                // Bind data with grid if rowcount is greate than 0 else shows No record found message
                if (dtProspect.Rows.Count > 0)
                {
                    grdProspect.DataSource = dtProspect;
                    grdProspect.DataBind();

                    if (dtProspect.Rows.Count == 1)
                    {
                        //spCount.InnerHtml = iTotalRecord.ToString() + " Result Found";
                    }
                    string pagingstring = ImplementPaging(iPageIndex, iPageSize, iTotalRecord);

                    HtmlForm newForm = Page.Form;
                    newForm.Controls.Clear();
                    newForm.Controls.Add(grdProspect);

                    var sb = new System.Text.StringBuilder();
                    var htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));

                    newForm.RenderControl(htWriter);

                    string strRenderedHTML = sb.ToString();
                    string strTottalRecord;
                    int startindex = strRenderedHTML.IndexOf("<table");
                    int endindex = strRenderedHTML.LastIndexOf("</table>");
                    int length = (endindex - startindex) + 8;
                    strRenderedHTML = strRenderedHTML.Substring(startindex, length);
                    strTottalRecord = "<span id=spnTotalRecordAsync>" + iTotalRecord.ToString() + "</span>";
                    strRenderedHTML = "<div style='float: left; width: 746px'>" + strRenderedHTML + "</div>";

                    Response.Write(strRenderedHTML + pagingstring + "<p class=\"blueboxbotbg_cl\"><img src=\"/App/Images/specer.gif\" width=\"746\" height=\"5\" /></p>" + strTottalRecord);

                }
                else
                {
                    string noRecordFound = "<div style='float:left; width:746px; border:solid 1px #E7F0F5; padding:10px 0px 10px 0px; display:block;' id='dvNoProspectFound' runat='server'>";
                    noRecordFound = noRecordFound + "<div class='divnoitemfound_custdbrd' style='margin-top:0px;'><p class='divnoitemtxt_custdbrd'><span class='orngbold18_default'>No Records Found</span></p></div></div>";
                    Response.Write(noRecordFound);
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
            if (FranchiseeView)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var currentRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
                    if (currentRole.CheckRole((long)Roles.FranchisorAdmin))
                    {
                        var franchiseeName = e.Row.FindControl("spFranchisee") as HtmlContainerControl;
                        franchiseeName.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //e.Row.FindControl("spSalesPerson").Visible = true;
                    //e.Row.FindControl("spFranchisee").Visible = false;
                    var spnAssigned = (HtmlContainerControl)e.Row.FindControl("spnAssigned");
                    if (spnAssigned != null)
                    {
                        if (spnAssigned.InnerHtml.Trim().Equals("2"))
                        {
                            var spnSummary = (HtmlContainerControl)e.Row.FindControl("spnSummary");
                            if (spnSummary != null)
                            {
                                spnSummary.InnerHtml = "<img src='/App/images/unassigned-icon.gif' title='Unassigned' />";
                            }
                        }
                    }
                }
            }
            // Code to visible primary contact link
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // format phone no.
                CommonCode objCommonCode = new CommonCode();

                var spnName = (HtmlContainerControl)e.Row.FindControl("spnName");
                var spnPhone = (HtmlContainerControl)e.Row.FindControl("spnPhone");
                var spnEmail = (HtmlContainerControl)e.Row.FindControl("spnEmail");
                var spnAddPrimaryContact = (HtmlContainerControl)e.Row.FindControl("spnAddPrimaryContact");
                var divNamePhoneEmail = (HtmlContainerControl)e.Row.FindControl("divNamePhoneEmail");

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
                    pagingtableHTML += "<td style=\" padding:4px; \">" + Convert.ToString(icount) + "</td>";
                else
                    pagingtableHTML += "<td style=\" padding:4px;\"><a href=\"javascript:LoadProspectTableonPageChange('" + Convert.ToString(icount) + "')\">" + Convert.ToString(icount) + "</a></td>";
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