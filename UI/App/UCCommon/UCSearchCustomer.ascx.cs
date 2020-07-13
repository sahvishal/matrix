using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.App.BasePageClass;
using Falcon.DataAccess.Master;
using Falcon.App.Lib;
using EEvent = Falcon.Entity.Other.EEvent;
using Falcon.App.Core.Enum;

public partial class App_UCCommon_UCSearchCustomer : BaseUserControl
{
    private const int PAGE_SIZE = 10;
    private int pageNumber = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        long organizationId = 0;

        ViewState["SortExp"] = "DateCreated";
        ViewState["SortDir"] = SortDirection.Descending;
        txtFirstName.Attributes.Add("onKeyDown", "return txtkeypress_AlphanumericOnly(event);");
        txtLastName.Attributes.Add("onKeyDown", "return txtkeypress_AlphanumericOnly(event);");
        txtCustomerID.Attributes.Add("onKeyDown", "return txtkeypress(event);");

        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        if (currentOrgRole.CheckRole((long)Roles.Technician))
        {
            divTab.Style.Add(HtmlTextWriterStyle.Display, "none");
            divTab.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

            pChkAbdCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else if (currentOrgRole.CheckRole((long)Roles.CallCenterRep))
        {
            organizationId = currentOrgRole.OrganizationId;
            divTab.Style.Add(HtmlTextWriterStyle.Display, "block");
            divTab.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        }
        if (!IsPostBack)
        {
            divConfrmCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divConfrmCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            divProspectCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divProspectCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            if (Request.QueryString["Action"] != null)
            {
                switch (Request.QueryString["Action"])
                {
                    case "Disable":
                        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('User disabled successfully');", true);
                        break;

                    case "Enable":
                        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('User enabled successfully');", true);
                        break;

                    case "Erase":
                        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('User erased successfully');", true);
                        break;

                    case "Deleted":
                        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('Appointment deleted successfully');", true);
                        break;
                }
            }

            //Quick search

            if (Request.QueryString["Action"] != null)
            {
                switch (Request.QueryString["Action"].ToString())
                {
                    case "Disable":
                        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('User disabled successfully');", true);
                        break;

                    case "Enable":
                        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('User enabled successfully');", true);
                        break;

                    case "Erase":
                        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('User erased successfully');", true);
                        break;

                    case "Deleted":
                        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('Appointment deleted successfully');", true);
                        break;
                }
            }
            else if (Request.QueryString["QuickNavigation"] != null && Request.QueryString["CustomerName"] != null)
            {
                var masterDal = new MasterDAL();
                EEvent objevent;
                string customername = Request.QueryString["CustomerName"].ToString().Replace("''", "'");
                string pagecount = string.Empty;
                bool AbdCustomer = false;

                // Set Status
                if (Request["ShowAll"] != null)
                {
                    if (Request["ShowAll"].Equals("True"))
                    {
                        AbdCustomer = true;
                        chkAbdCustomer.Checked = true;
                    }
                }
                if (customername.IndexOf(" ") > 0)
                {
                    txtFirstName.Text = customername.Substring(0, customername.IndexOf(" "));
                    txtLastName.Text = customername.Substring(customername.IndexOf(" ") + 1);
                }
                else
                {
                    txtFirstName.Text = customername;
                }
                long totalRecords = 0;
                if (AbdCustomer)
                {
                    objevent = masterDal.GetTechnicianCustomerList(txtFirstName.Text.Trim().Replace("'", "''"), txtLastName.Text.Trim().Replace("'", "''"), "", "", "", "", "", Convert.ToInt32(AbdCustomer), PAGE_SIZE, pageNumber, out totalRecords, txtPhoneNumber.Text, "", "", "", "", organizationId,"");
                }
                else
                {
                    objevent = masterDal.GetTechnicianCustomerList(txtFirstName.Text.Trim().Replace("'", "''"), txtLastName.Text.Trim().Replace("'", "''"), "", "", "", "", "", Convert.ToInt32(AbdCustomer), PAGE_SIZE, pageNumber, out totalRecords, txtPhoneNumber.Text, "", "", "", "", organizationId, "");
                }

                divConfrmCust.Style.Add(HtmlTextWriterStyle.Display, "block");
                divConfrmCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                divProspectCust.Style.Add(HtmlTextWriterStyle.Display, "none");
                divProspectCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                hfCnfrmCustResults.Value = "1";


                DataTable dtcustomer = new DataTable();
                dtcustomer.Columns.Add("Name");
                dtcustomer.Columns.Add("EventID");
                dtcustomer.Columns.Add("Email");
                dtcustomer.Columns.Add("Phone");
                dtcustomer.Columns.Add("RegDate");
                dtcustomer.Columns.Add("EventDate");
                dtcustomer.Columns.Add("Marketing");
                dtcustomer.Columns.Add("Address");
                dtcustomer.Columns.Add("RestAddress");
                dtcustomer.Columns.Add("Event");
                dtcustomer.Columns.Add("Host");
                dtcustomer.Columns.Add("Package");
                dtcustomer.Columns.Add("AddressID");
                dtcustomer.Columns.Add("FranchiseeID");
                dtcustomer.Columns.Add("CustomerID");
                dtcustomer.Columns.Add("TotalRevenue", typeof(float));
                dtcustomer.Columns.Add("State");
                dtcustomer.Columns.Add("City");
                dtcustomer.Columns.Add("Country");
                dtcustomer.Columns.Add("Zip");
                dtcustomer.Columns.Add("DateCreated", typeof(DateTime));
                dtcustomer.Columns.Add("FName");
                dtcustomer.Columns.Add("LName");
                dtcustomer.Columns.Add("AddedBY");
                dtcustomer.Columns.Add("Gender");
                dtcustomer.Columns.Add("DOB");
                dtcustomer.Columns.Add("Paid");
                if (objevent != null && objevent.Customer.Count > 0)
                {
                    tblGridPagingConFirmCust.InnerHtml = ImplementPaging(pageNumber, PAGE_SIZE, totalRecords > 50 ? 50 : totalRecords);
                    if (objevent.Customer.Count > 20)
                    {
                        divCnfrmCustMoreResults.Visible = true;
                    }
                    // format phone no.
                    CommonCode objCommonCode = new CommonCode();

                    for (int jcount = 0; jcount < objevent.Customer.Count; jcount++)
                    {
                        string address = objevent.Customer[jcount].Customer.BillingAddress.Address1;
                        if (!string.IsNullOrEmpty(objevent.Customer[jcount].Customer.BillingAddress.Address2))
                        {
                            address = address + "<br>" + objevent.Customer[jcount].Customer.BillingAddress.Address2;
                        }

                        string restaddress = objevent.Customer[jcount].Customer.BillingAddress.City + ",&nbsp;" + objevent.Customer[jcount].Customer.BillingAddress.State + "&nbsp;&nbsp;" + objevent.Customer[jcount].Customer.BillingAddress.Zip;

                        string username = string.Empty;
                        if (objevent.Customer[jcount].Customer.User.MiddleName.Length > 0)
                        {
                            username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.MiddleName + " " + objevent.Customer[jcount].Customer.User.LastName;
                        }
                        else
                        {
                            username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.LastName;
                        }

                        string role = string.Empty;
                        switch (objevent.Customer[jcount].Customer.AddedBy.ToString())
                        {
                            case "10":
                                role = "Call Center";
                                break;
                            case "8":
                                role = "Walk Ins";
                                break;
                            default:
                                role = "Internet";
                                break;
                        }
                        string paid = "False";
                        if (objevent.Customer[jcount].PaymentDetail.Amount > 0)
                        {
                            paid = "True";
                        }
                        string regdateLong = "-N/A-";
                        string regdateShort = "-N/A-";
                        float amount = 0;
                        if (objevent.Customer[jcount].Customer.User.DateApplied.ToString().Length > 0 && objevent.Customer[jcount].Customer.User.DateApplied != null)
                        {
                            regdateLong = objevent.Customer[jcount].Customer.User.DateApplied.ToLongDateString();
                            regdateShort = objevent.Customer[jcount].Customer.User.DateApplied.ToString("MM/dd/yyyy");
                        }

                        string eventdate = "-N/A-";
                        if (objevent.Customer[jcount].Customer.User.DOB != null && objevent.Customer[jcount].Customer.User.DOB.ToString().Length > 0)
                        {
                            eventdate = objevent.Customer[jcount].Customer.User.DOB;
                        }
                        if ((objevent.Customer[jcount].PaymentDetail.Amount.ToString().Length > 0) && (objevent.Customer[jcount].PaymentDetail.Amount > 0))
                        {
                            amount = objevent.Customer[jcount].PaymentDetail.Amount;
                        }
                        dtcustomer.Rows.Add(new object[] { username, 
                                                    objevent.Customer[jcount].Customer.User.UserID,
                                                    objevent.Customer[jcount].Customer.User.EMail1, 
                                                    objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneOffice), 
                                                    regdateLong,
                                                    eventdate,
                                                    objevent.Customer[jcount].Customer.Gender,
                                                    address,
                                                    restaddress,
                                                    objevent.Customer[jcount].Customer.CollectionMode,
                                                    objevent.Customer[jcount].Customer.ContactMethod,
                                                    objevent.Customer[jcount].EventPackage.Package.PackageName,
                                                    objevent.Customer[jcount].Customer.User.HomeAddress.AddressID,
                                                    objevent.Customer[jcount].TechnicianID,
                                                    objevent.Customer[jcount].Customer.CustomerID, 
                                                    amount,
                                                    objevent.Customer[jcount].Customer.BillingAddress.State,
                                                    objevent.Customer[jcount].Customer.BillingAddress.City,
                                                    objevent.Customer[jcount].Customer.BillingAddress.Country,
                                                    objevent.Customer[jcount].Customer.BillingAddress.Zip,
                                                    regdateShort,
                                                    objevent.Customer[jcount].Customer.User.FirstName,
                                                    objevent.Customer[jcount].Customer.User.LastName,
                                                    role,
                                                    objevent.Customer[jcount].Customer.LastLogged,
                                                    objevent.Customer[jcount].Customer.Height,
                                                    paid});

                        if (jcount == 19)
                            break;
                    }

                    if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
                    {
                        dtcustomer.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
                    }
                    else
                    {
                        dtcustomer.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
                    }

                    dtcustomer = dtcustomer.DefaultView.ToTable();

                    if (currentOrgRole.CheckRole((long)Roles.Technician) && AbdCustomer)
                    {
                        grdCustomerList.Columns[grdProsCustomerList.Columns.Count - 2].Visible = false;
                        grdCustomerList.Columns[grdProsCustomerList.Columns.Count - 3].Visible = false;
                        grdCustomerList.Columns[grdProsCustomerList.Columns.Count - 1].Visible = true;
                    }
                    else
                    {
                        grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = false;
                        grdCustomerList.Columns[grdCustomerList.Columns.Count - 3].Visible = true;
                        grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = true;
                    }

                    dvSearchResultCrfmCust1.InnerText = "Total: ";
                    dvSearchResultCrfmCust.InnerText = totalRecords + " Result found";

                    divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");


                    grdCustomerList.DataSource = dtcustomer;
                    ViewState["DSGRID"] = dtcustomer;
                    grdCustomerList.DataBind();
                }
                else
                {
                    divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    dvSearchResultCrfmCust1.InnerText = "Total: ";
                    dvSearchResultCrfmCust.InnerText = dtcustomer.Rows.Count + " Result found";
                }
            }

        }
        else
        {
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"] == "PageNumber")
            {
                pageNumber = Convert.ToInt32(Request.Form["__EVENTARGUMENT"]);

                if (hfCnfrmCust.Value == "0")
                {
                    divConfrmCust.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divConfrmCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                    divProspectCust.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divProspectCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    hfCnfrmCustResults.Value = "1";
                    SearchConfirmedCustomer();
                    Page.ClientScript.RegisterStartupScript(typeof(string), "MaintainSearchCriteriaCnfrmCust", "MaintainCheckCnfrmCust();", true);
                }
                else if (hfCnfrmCust.Value == "1")
                {
                    divConfrmCust.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divConfrmCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    divProspectCust.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divProspectCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                    hfProsCustResults.Value = "1";
                    SearchProspectCustomer();
                    Page.ClientScript.RegisterStartupScript(typeof(string), "MaintainSearchCriteriaProsCust", "MaintainCheckProspect();", true);
                }

            }
        }
    }
    protected void grdCustomerList_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtCustomer = (DataTable)ViewState["DSGRID"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtCustomer.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtCustomer.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtCustomer = dtCustomer.DefaultView.ToTable();
        ViewState["SortExp"] = e.SortExpression;
        ViewState["DSGRID"] = dtCustomer;
        grdCustomerList.DataSource = dtCustomer;
        grdCustomerList.DataBind();
        divConfrmCust.Style.Add(HtmlTextWriterStyle.Display, "block");
        divConfrmCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        divProspectCust.Style.Add(HtmlTextWriterStyle.Display, "none");
        divProspectCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
        Page.ClientScript.RegisterStartupScript(typeof(string), "MaintainSearchCriteriaCnfrmCust", "MaintainCheckCnfrmCust();", true);
    }

    protected void grdCustomerList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var sessionContext = IoC.Resolve<ISessionContext>();

            int customerid = Convert.ToInt32(((DataTable)ViewState["DSGRID"]).Rows[e.Row.DataItemIndex]["CustomerID"]);
            int eventid = Convert.ToInt32(((DataTable)ViewState["DSGRID"]).Rows[e.Row.DataItemIndex]["EventID"]);

            var currentOrgRole = sessionContext.UserSession.CurrentOrganizationRole;

            if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {


               // HtmlAnchor eventname = (HtmlAnchor)e.Row.FindControl("EventName");
              //  eventname.HRef = "~/App/Common/EventDetails.aspx?EventId=" + eventid;

                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                customername.HRef = "~/App/Franchisee/FranchiseeEditCustomer.aspx?CustomerID=" + customerid.ToString() + "&Master=EventCustomer";

                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");
                customerlist.HRef = "~/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" + customerid.ToString();

            }
            else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                //HtmlAnchor eventname = (HtmlAnchor)e.Row.FindControl("EventName");
                //eventname.HRef = "~/App/Common/CommonEventCustomerList.aspx?EventID=" + eventid.ToString() + "&Master=EventCustomer";
               // eventname.HRef = "";

                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                customername.HRef = "~/App/Franchisee/SalesRep/SalesRepEditCustomer.aspx?CustomerID=" + customerid.ToString() + "&Master=EventCustomer";

                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");
                customerlist.HRef = "~/App/Franchisee/SalesRep/SalesRepCustomerDetails.aspx?CustomerID=" + customerid.ToString();


            }
            else if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {

               // HtmlAnchor eventname = (HtmlAnchor)e.Row.FindControl("EventName");
              //  eventname.HRef = "~/App/Common/EventDetails.aspx?EventId=" + eventid;


                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                customername.HRef = "~/App/Franchisor/FranchisorEditCustomer.aspx?CustomerID=" + customerid.ToString() + "&Master=EventCustomer";

                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");
                customerlist.HRef = "~/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + customerid.ToString();
            }
            else if (currentOrgRole.CheckRole((long)Roles.Technician))
            {
               // HtmlAnchor eventname = (HtmlAnchor)e.Row.FindControl("EventName");
                //eventname.HRef = "/Scheduling/EventCustomerList/Index?id=" + eventid;

                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                customername.HRef = "~/App/Franchisee/Technician/TechnicianEditCustomer.aspx?CustomerID=" + customerid.ToString() + "&Master=EventCustomer";

                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");
                customerlist.HRef = "~/App/Franchisee/Technician/TechnicianCustomerDetails.aspx?CustomerID=" + customerid.ToString();

            }
            else if (currentOrgRole.CheckRole((long)Roles.CallCenterRep) || currentOrgRole.CheckRole((long)Roles.CallCenterManager))
            {
                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");

                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    customername.HRef = "Javascript:void(0)";
                    customerlist.HRef = "~/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + customerid.ToString() + "&Call=No";
                }
                else if (Request.QueryString["Type"] != null && Request.QueryString["Type"].ToString() == "RegExistCustForSameEvent")
                {
                    customerlist.HRef = "~/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?Type=RegExistCustForSameEvent" + "&CustomerID=" + customerid.ToString();
                }
                else
                {
                    customername.HRef = "~/App/CallCenter/CallCenterRep/CallCenterRepEditCustomer.aspx?CustomerID=" + customerid.ToString() + "&Master=EventCustomer";
                    customerlist.HRef = "~/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + customerid.ToString();
                }
            }
        }
    }

    protected void ibtnReset_Click(object sender, ImageClickEventArgs e)
    {
        if (hfCnfrmCust.Value == "0")
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCustomerID.Text = "";
            txtZipCode.Text = "";
            divConfrmCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divConfrmCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            dvSearchResultCrfmCust1.InnerHtml = "";
            dvSearchResultCrfmCust.InnerHtml = "";
            hfCnfrmCustResults.Value = "0";
            Page.ClientScript.RegisterStartupScript(typeof(string), "MaintainResetCriteriaCnfrmCust", "MaintainCheckCnfrmCust();", true);
        }
        else if (hfCnfrmCust.Value == "1")
        {
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            divProspectCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divProspectCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            divGridProsCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divGridProsCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            dvSearchResultProsCust1.InnerHtml = "";
            dvSearchResultProsCust.InnerHtml = "";
            hfProsCustResults.Value = "0";
            Page.ClientScript.RegisterStartupScript(typeof(string), "MaintainResetCriteriaProsCust", "MaintainCheckProspect();", true);
        }
    }
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (hfCnfrmCust.Value == "0")
        {
            divConfrmCust.Style.Add(HtmlTextWriterStyle.Display, "block");
            divConfrmCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            divProspectCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divProspectCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            hfCnfrmCustResults.Value = "1";
            SearchConfirmedCustomer();
            Page.ClientScript.RegisterStartupScript(typeof(string), "MaintainSearchCriteriaCnfrmCust", "MaintainCheckCnfrmCust();", true);
        }
        else if (hfCnfrmCust.Value == "1")
        {
            divConfrmCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divConfrmCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            divProspectCust.Style.Add(HtmlTextWriterStyle.Display, "block");
            divProspectCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            hfProsCustResults.Value = "1";
            SearchProspectCustomer();
            Page.ClientScript.RegisterStartupScript(typeof(string), "MaintainSearchCriteriaProsCust", "MaintainCheckProspect();", true);
        }
    }

    protected void grdProsCustomerList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var sessionContext = IoC.Resolve<ISessionContext>();

            var currentOrgRole = sessionContext.UserSession.CurrentOrganizationRole;

            int customerid = Convert.ToInt32(((DataTable)ViewState["DSGRID"]).Rows[e.Row.DataItemIndex]["CustomerID"]);
            int eventid = Convert.ToInt32(((DataTable)ViewState["DSGRID"]).Rows[e.Row.DataItemIndex]["EventID"]);
            if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {


                HtmlAnchor eventname = (HtmlAnchor)e.Row.FindControl("ProsEventName");
                eventname.HRef = "/Scheduling/EventCustomerList/Index?id=" + eventid;

                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("ProsCustomerName");
                customername.HRef = "~/App/Franchisee/FranchiseeEditCustomer.aspx?CustomerID=" + customerid.ToString() + "&Master=EventCustomer";

                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("Proscustomerlist");
                customerlist.HRef = "~/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" + customerid.ToString();

            }
            else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                HtmlAnchor eventname = (HtmlAnchor)e.Row.FindControl("ProsEventName");
                //eventname.HRef = "~/App/Common/CommonEventCustomerList.aspx?EventID=" + eventid.ToString() + "&Master=EventCustomer";
                eventname.HRef = "";

                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("ProsCustomerName");
                customername.HRef = "~/App/Franchisee/SalesRep/SalesRepEditCustomer.aspx?CustomerID=" + customerid.ToString() + "&Master=EventCustomer";

                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("Proscustomerlist");
                customerlist.HRef = "~/App/Franchisee/SalesRep/SalesRepCustomerDetails.aspx?CustomerID=" + customerid.ToString();


            }
            else if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {

                HtmlAnchor eventname = (HtmlAnchor)e.Row.FindControl("ProsEventName");
                eventname.HRef = "/Scheduling/EventCustomerList/Index?id=" + eventid;


                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("ProsCustomerName");
                customername.HRef = "~/App/Franchisor/FranchisorEditCustomer.aspx?CustomerID=" + customerid + "&Master=EventCustomer";

                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("Proscustomerlist");
                customerlist.HRef = "~/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + customerid;
            }
            else if (currentOrgRole.CheckRole((long)Roles.Technician))
            {
                HtmlAnchor eventname = (HtmlAnchor)e.Row.FindControl("ProsEventName");
                eventname.HRef = "/Scheduling/EventCustomerList/Index?id=" + eventid;

                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("ProsCustomerName");
                customername.HRef = "~/App/Franchisee/Technician/TechnicianEditCustomer.aspx?CustomerID=" + customerid + "&Master=EventCustomer";

                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("Proscustomerlist");
                customerlist.HRef = "~/App/Franchisee/Technician/TechnicianCustomerDetails.aspx?CustomerID=" + customerid;

            }
            else if (currentOrgRole.CheckRole((long)Roles.CallCenterRep) || currentOrgRole.CheckRole((long)Roles.CallCenterManager))
            {
                HtmlAnchor customername = (HtmlAnchor)e.Row.FindControl("ProsCustomerName");
                HtmlAnchor customerlist = (HtmlAnchor)e.Row.FindControl("Proscustomerlist");

                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    customername.HRef = "Javascript:void(0)";
                    customerlist.HRef = "~/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + customerid + "&Call=No";
                }
                else if (Request.QueryString["Type"] != null && Request.QueryString["Type"] == "RegExistCustForSameEvent")
                {
                    customerlist.HRef = "~/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?Type=RegExistCustForSameEvent" + "&CustomerID=" + customerid;
                }
                else
                {
                    customername.HRef = "~/App/CallCenter/CallCenterRep/CallCenterRepEditCustomer.aspx?CustomerID=" + customerid + "&Master=EventCustomer";
                    customerlist.HRef = "~/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + customerid;
                }
            }
        }
    }

    protected void grdProsCustomerList_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtCustomer = (DataTable)ViewState["DSGRID"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtCustomer.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtCustomer.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtCustomer = dtCustomer.DefaultView.ToTable();
        ViewState["SortExp"] = e.SortExpression;
        ViewState["DSGRID"] = dtCustomer;
        grdProsCustomerList.DataSource = dtCustomer;
        grdProsCustomerList.DataBind();
        divConfrmCust.Style.Add(HtmlTextWriterStyle.Display, "none");
        divConfrmCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
        divProspectCust.Style.Add(HtmlTextWriterStyle.Display, "block");
        divProspectCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        Page.ClientScript.RegisterStartupScript(typeof(string), "MaintainSearchCriteriaProsCust", "MaintainCheckProspect();", true);
    }

    private void SearchConfirmedCustomer()
    {
        var masterDal = new MasterDAL();

        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        long organizationId = 0;
        if (currentOrgRole.GetSystemRoleId == (long) Roles.CallCenterRep)
        {
            organizationId = currentOrgRole.OrganizationId;
        }

        long totalRecords = 0;
        EEvent objevent = masterDal.GetTechnicianCustomerList(txtFirstName.Text.Trim().Replace("'", "''"), txtLastName.Text.Trim().Replace("'", "''"), txtZipCode.Text, txtCustomerID.Text, txtEventId.Text, txtEventStartDate.Text, txtEventEndDate.Text, Convert.ToInt32(chkAbdCustomer.Checked), PAGE_SIZE, pageNumber, out totalRecords, txtPhoneNumber.Text.Replace("(", "").Replace(")", "").Replace("-", ""), txtEmail.Text, txtHICN.Text, txtMemberId.Text, txtDOB.Text, organizationId,txtMBINumber.Text);

        var filter =
            new
            {
                FirstName = txtFirstName.Text.Trim().Replace("'", "''"),
                LastName = txtLastName.Text.Trim().Replace("'", "''"),
                Zip = txtZipCode.Text,
                CustomerID = txtCustomerID.Text,
                EventId = txtEventId.Text,
                EventStartDate = txtEventStartDate.Text,
                EventEndDate = txtEventEndDate.Text,
                PhoneNumber = txtPhoneNumber.Text.Replace("(", "").Replace(")", "").Replace("-", ""),
                Email = txtEmail.Text,
                DOB = txtDOB.Text
            };

        LogFilterListPairAudit(filter, objevent.Customer);

        DataTable dtcustomer = new DataTable();
        dtcustomer.Columns.Add("Name");
        dtcustomer.Columns.Add("EventID");
        dtcustomer.Columns.Add("Email");
        dtcustomer.Columns.Add("Phone");
        dtcustomer.Columns.Add("RegDate");
        dtcustomer.Columns.Add("EventDate");
        dtcustomer.Columns.Add("Marketing");
        dtcustomer.Columns.Add("Address");
        dtcustomer.Columns.Add("RestAddress");
        dtcustomer.Columns.Add("Event");
        dtcustomer.Columns.Add("Host");
        dtcustomer.Columns.Add("Package");
        dtcustomer.Columns.Add("AddressID");
        dtcustomer.Columns.Add("FranchiseeID");
        dtcustomer.Columns.Add("CustomerID");
        dtcustomer.Columns.Add("TotalRevenue", typeof(float));
        dtcustomer.Columns.Add("State");
        dtcustomer.Columns.Add("City");
        dtcustomer.Columns.Add("Country");
        dtcustomer.Columns.Add("Zip");
        dtcustomer.Columns.Add("DateCreated", typeof(DateTime));
        dtcustomer.Columns.Add("FName");
        dtcustomer.Columns.Add("LName");
        dtcustomer.Columns.Add("AddedBY");
        dtcustomer.Columns.Add("Gender");
        dtcustomer.Columns.Add("DOB");
        dtcustomer.Columns.Add("Paid");

        if (objevent != null && objevent.Customer.Count > 0)
        {
            tblGridPagingConFirmCust.InnerHtml = ImplementPaging(pageNumber, PAGE_SIZE, totalRecords > 50 ? 50 : totalRecords);
            if (totalRecords > 20)
            {
                divCnfrmCustMoreResults.Visible = true;
            }
            else
            {
                divCnfrmCustMoreResults.Visible = false;
            }
            // format phone no.
            CommonCode objCommonCode = new CommonCode();

            for (int jcount = 0; jcount < objevent.Customer.Count; jcount++)
            {
                string address = objevent.Customer[jcount].Customer.BillingAddress.Address1;
                if (objevent.Customer[jcount].Customer.BillingAddress.Address2 != null && objevent.Customer[jcount].Customer.BillingAddress.Address2 != "")
                {
                    address = address + "<br>" + objevent.Customer[jcount].Customer.BillingAddress.Address2;
                }
                string restaddress = objevent.Customer[jcount].Customer.BillingAddress.City + ",&nbsp;" + objevent.Customer[jcount].Customer.BillingAddress.State + "&nbsp;&nbsp;" + objevent.Customer[jcount].Customer.BillingAddress.Zip;

                string username = string.Empty;
                if (objevent.Customer[jcount].Customer.User.MiddleName.Length > 0)
                {
                    username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.MiddleName + " " + objevent.Customer[jcount].Customer.User.LastName;
                }
                else
                {
                    username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.LastName;
                }

                string role = string.Empty;
                switch (objevent.Customer[jcount].Customer.AddedBy.ToString())
                {
                    case "10":
                        role = "Call Center";
                        break;
                    case "8":
                        role = "Walk Ins";
                        break;
                    default:
                        role = "Internet";
                        break;
                }
                string paid = "False";
                if (objevent.Customer[jcount].PaymentDetail.Amount > 0)
                {
                    paid = "True";
                }
                string regdateLong = "-N/A-";
                string regdateShort = "-N/A-";
                float amount = 0;
                if (objevent.Customer[jcount].Customer.User.DateApplied.ToString().Length > 0 && objevent.Customer[jcount].Customer.User.DateApplied != null)
                {
                    regdateLong = objevent.Customer[jcount].Customer.User.DateApplied.ToLongDateString();
                    regdateShort = objevent.Customer[jcount].Customer.User.DateApplied.ToString("MM/dd/yyyy");
                }

                string eventdate = "-N/A-";
                if (objevent.Customer[jcount].Customer.User.DOB != null && objevent.Customer[jcount].Customer.User.DOB.ToString().Length > 0)
                {
                    eventdate = objevent.Customer[jcount].Customer.User.DOB;
                }
                if ((objevent.Customer[jcount].PaymentDetail.Amount.ToString().Length > 0) && (objevent.Customer[jcount].PaymentDetail.Amount > 0))
                {
                    amount = objevent.Customer[jcount].PaymentDetail.Amount;
                }
                var orderScreeningDetail =
                    !string.IsNullOrEmpty(objevent.Customer[jcount].EventPackage.Package.PackageName)
                        ? objevent.Customer[jcount].EventPackage.Package.PackageName
                        : string.Empty;
                var orderSeprator = !string.IsNullOrEmpty(objevent.Customer[jcount].EventPackage.Package.PackageName)
                                        ? ", "
                                        : string.Empty;

                orderScreeningDetail = !string.IsNullOrEmpty(objevent.Customer[jcount].AdditionalTest)
                                           ? orderScreeningDetail + orderSeprator +
                                             objevent.Customer[jcount].AdditionalTest
                                           : orderScreeningDetail;

                dtcustomer.Rows.Add(new object[] { username, 
                                                    objevent.Customer[jcount].Customer.User.UserID,
                                                    objevent.Customer[jcount].Customer.User.EMail1, 
                                                    objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneOffice), 
                                                    regdateLong,
                                                    eventdate,
                                                    objevent.Customer[jcount].Customer.Gender,
                                                    address,
                                                    restaddress,
                                                    objevent.Customer[jcount].Customer.CollectionMode,
                                                    objevent.Customer[jcount].Customer.ContactMethod,
                                                    orderScreeningDetail,
                                                    //objevent.Customer[jcount].EventPackage.Package.PackageName,
                                                    objevent.Customer[jcount].Customer.User.HomeAddress.AddressID,
                                                    objevent.Customer[jcount].TechnicianID,
                                                    objevent.Customer[jcount].Customer.CustomerID, 
                                                    amount,
                                                    objevent.Customer[jcount].Customer.BillingAddress.State,
                                                    objevent.Customer[jcount].Customer.BillingAddress.City,
                                                    objevent.Customer[jcount].Customer.BillingAddress.Country,
                                                    objevent.Customer[jcount].Customer.BillingAddress.Zip,
                                                    regdateShort,
                                                    objevent.Customer[jcount].Customer.User.FirstName,
                                                    objevent.Customer[jcount].Customer.User.LastName,
                                                    role,
                                                    objevent.Customer[jcount].Customer.LastLogged,
                                                    objevent.Customer[jcount].Customer.Height,
                                                    paid});
                if (jcount == 19)
                    break;
            }

            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dtcustomer.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            else
            {
                dtcustomer.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            dtcustomer = dtcustomer.DefaultView.ToTable();



            var sessionContext = IoC.Resolve<ISessionContext>();
            if (sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.Technician) && chkAbdCustomer.Checked)
            {
                grdCustomerList.Columns[grdProsCustomerList.Columns.Count - 2].Visible = false;
                grdCustomerList.Columns[grdProsCustomerList.Columns.Count - 3].Visible = false;
                grdCustomerList.Columns[grdProsCustomerList.Columns.Count - 1].Visible = true;
            }
            else
            {
                grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = false;
                grdCustomerList.Columns[grdCustomerList.Columns.Count - 3].Visible = true;
                grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = true;
            }
            dvSearchResultCrfmCust1.InnerText = "Total: ";
            dvSearchResultCrfmCust.InnerText = totalRecords + " Result found";

            divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Display, "block");
            divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

            grdCustomerList.DataSource = dtcustomer;
            ViewState["DSGRID"] = dtcustomer;
            grdCustomerList.DataBind();
        }
        else
        {
            divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divGridCrfmCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            dvSearchResultCrfmCust1.InnerText = "Total: ";
            dvSearchResultCrfmCust.InnerText = dtcustomer.Rows.Count + " Result found";
        }
    }

    private void SearchProspectCustomer()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        var masterDal = new MasterDAL();
        long totalRecords = 0;
        EEvent objevent = masterDal.GetTechnicianCustomerList("", "", "", "", "", txtStartDate.Text, txtEndDate.Text, Convert.ToInt32(chkAbdCustomer.Checked), PAGE_SIZE, pageNumber, out totalRecords, "", "", "", "", "", 0,"");


        DataTable dtcustomer = new DataTable();
        dtcustomer.Columns.Add("Name");
        dtcustomer.Columns.Add("EventID");
        dtcustomer.Columns.Add("Email");
        dtcustomer.Columns.Add("Phone");
        dtcustomer.Columns.Add("RegDate");
        dtcustomer.Columns.Add("EventDate");
        dtcustomer.Columns.Add("Marketing");
        dtcustomer.Columns.Add("Address");
        dtcustomer.Columns.Add("RestAddress");
        dtcustomer.Columns.Add("Event");
        dtcustomer.Columns.Add("Host");
        dtcustomer.Columns.Add("Package");
        dtcustomer.Columns.Add("AddressID");
        dtcustomer.Columns.Add("FranchiseeID");
        dtcustomer.Columns.Add("CustomerID");
        dtcustomer.Columns.Add("TotalRevenue", typeof(float));
        dtcustomer.Columns.Add("State");
        dtcustomer.Columns.Add("City");
        dtcustomer.Columns.Add("Country");
        dtcustomer.Columns.Add("Zip");
        dtcustomer.Columns.Add("DateCreated", typeof(DateTime));
        dtcustomer.Columns.Add("FName");
        dtcustomer.Columns.Add("LName");
        dtcustomer.Columns.Add("AddedBY");
        dtcustomer.Columns.Add("Gender");
        dtcustomer.Columns.Add("DOB");
        dtcustomer.Columns.Add("Paid");
        if (objevent != null && objevent.Customer.Count > 0)
        {
            //if (objevent.Customer.Length > 20)
            //{
            //    divProsCustMoreResults.Visible = true;
            //}
            //else
            //{
            //    divProsCustMoreResults.Visible = false;
            //}
            tblGridPagingProspectCust.InnerHtml = ImplementPaging(pageNumber, PAGE_SIZE, totalRecords);

            for (int jcount = 0; jcount < objevent.Customer.Count; jcount++)
            {
                string address = objevent.Customer[jcount].Customer.BillingAddress.Address1;
                if (!string.IsNullOrEmpty(objevent.Customer[jcount].Customer.BillingAddress.Address2))
                {
                    address = address + "<br>" + objevent.Customer[jcount].Customer.BillingAddress.Address2;
                }
                string restaddress = objevent.Customer[jcount].Customer.BillingAddress.City + ",&nbsp;" + objevent.Customer[jcount].Customer.BillingAddress.State + "&nbsp;&nbsp;" + objevent.Customer[jcount].Customer.BillingAddress.Zip;

                string username = string.Empty;
                if (objevent.Customer[jcount].Customer.User.MiddleName.Length > 0)
                {
                    username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.MiddleName + " " + objevent.Customer[jcount].Customer.User.LastName;
                }
                else
                {
                    username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.LastName;
                }

                string role = string.Empty;
                switch (objevent.Customer[jcount].Customer.AddedBy.ToString())
                {
                    case "10":
                        role = "Call Center";
                        break;
                    case "8":
                        role = "Walk Ins";
                        break;
                    default:
                        role = "Internet";
                        break;
                }
                string paid = "False";
                if (objevent.Customer[jcount].PaymentDetail.Amount > 0)
                {
                    paid = "True";
                }
                string regdateLong = "-N/A-";
                string regdateShort = "-N/A-";
                float amount = 0;
                if (objevent.Customer[jcount].Customer.User.DateApplied.ToString().Length > 0 && objevent.Customer[jcount].Customer.User.DateApplied != null)
                {
                    regdateLong = objevent.Customer[jcount].Customer.User.DateApplied.ToLongDateString();
                    regdateShort = objevent.Customer[jcount].Customer.User.DateApplied.ToString("MM/dd/yyyy");
                }

                string eventdate = "-N/A-";
                if (objevent.Customer[jcount].Customer.User.DOB != null && objevent.Customer[jcount].Customer.User.DOB.ToString().Length > 0)
                {
                    eventdate = objevent.Customer[jcount].Customer.User.DOB;
                }
                if ((objevent.Customer[jcount].PaymentDetail.Amount.ToString().Length > 0) && (objevent.Customer[jcount].PaymentDetail.Amount > 0))
                {
                    amount = objevent.Customer[jcount].PaymentDetail.Amount;
                }
                dtcustomer.Rows.Add(new object[] { username, 
                                                    objevent.Customer[jcount].Customer.User.UserID,
                                                    objevent.Customer[jcount].Customer.User.EMail1, 
                                                    objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneOffice), 
                                                    regdateLong,
                                                    eventdate,
                                                    objevent.Customer[jcount].Customer.Gender,
                                                    address,
                                                    restaddress,
                                                    objevent.Customer[jcount].Customer.CollectionMode,
                                                    objevent.Customer[jcount].Customer.ContactMethod,
                                                    objevent.Customer[jcount].EventPackage.Package.PackageName,
                                                    objevent.Customer[jcount].Customer.User.HomeAddress.AddressID,
                                                    objevent.Customer[jcount].TechnicianID,
                                                    objevent.Customer[jcount].Customer.CustomerID, 
                                                    amount,
                                                    objevent.Customer[jcount].Customer.BillingAddress.State,
                                                    objevent.Customer[jcount].Customer.BillingAddress.City,
                                                    objevent.Customer[jcount].Customer.BillingAddress.Country,
                                                    objevent.Customer[jcount].Customer.BillingAddress.Zip,
                                                    regdateShort,
                                                    objevent.Customer[jcount].Customer.User.FirstName,
                                                    objevent.Customer[jcount].Customer.User.LastName,
                                                    role,
                                                    objevent.Customer[jcount].Customer.LastLogged,
                                                    objevent.Customer[jcount].Customer.Height,
                                                    paid});
                //if (jcount == 19)
                //    break;
            }

            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dtcustomer.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            else
            {
                dtcustomer.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            dtcustomer = dtcustomer.DefaultView.ToTable();



            grdProsCustomerList.Columns[grdProsCustomerList.Columns.Count - 2].Visible = false;
            grdProsCustomerList.Columns[grdProsCustomerList.Columns.Count - 3].Visible = false;
            grdProsCustomerList.Columns[grdProsCustomerList.Columns.Count - 1].Visible = true;

            dvSearchResultProsCust1.InnerText = "Total: ";
            dvSearchResultProsCust.InnerText = totalRecords + " Result found";

            divGridProsCust.Style.Add(HtmlTextWriterStyle.Display, "block");
            divGridProsCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

            grdProsCustomerList.DataSource = dtcustomer;
            ViewState["DSGRID"] = dtcustomer;
            grdProsCustomerList.DataBind();

        }
        else
        {
            divGridProsCust.Style.Add(HtmlTextWriterStyle.Display, "none");
            divGridProsCust.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            dvSearchResultProsCust1.InnerText = "Total: ";
            dvSearchResultProsCust.InnerText = dtcustomer.Rows.Count + " Result found";
        }
    }

    private string ImplementPaging(int pagenumber, short pagesize, long recordcount)
    {

        if (recordcount <= pagesize) return "";

        // Calculates Total number of pages possible
        long numberofpages = recordcount / pagesize;
        if ((pagesize * numberofpages) != recordcount) numberofpages++;

        long minpagenumtodisplay;
        long maxpagenumtodisplay;

        //Calculates first and last page number to display in paging tab, so as to decide whole range
        minpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 1) : ((((pagenumber / 10) - 1) * 10) + 1);
        maxpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 10) : ((pagenumber / 10) * 10);

        if (maxpagenumtodisplay > numberofpages)
        {
            if ((maxpagenumtodisplay - numberofpages) < minpagenumtodisplay) minpagenumtodisplay = minpagenumtodisplay - (maxpagenumtodisplay - numberofpages);
            maxpagenumtodisplay = numberofpages;
        }

        // Forms the paging tab string
        string pagingtableHTML = "<table  style=\"border:none; float:left; \"><tr> ";

        if (recordcount > 10 && minpagenumtodisplay > 1) // Applied if number of pages are greater than 10 and number of records are more than page size
        {
            pagingtableHTML += "<td><a href=\"javascript:__doPostBack('PageNumber','" + Convert.ToString(minpagenumtodisplay - 1) + "')\">...</a></td>";
        }

        // Forms the Paging Number HTML .... for the range
        for (long icount = minpagenumtodisplay; icount <= maxpagenumtodisplay; icount++)
        {
            if (pagenumber == icount)
                pagingtableHTML += "<td style=\" padding:4px; \">" + Convert.ToString(icount) + "</td>";
            else
                pagingtableHTML += "<td style=\" padding:4px;\"><a href=\"javascript:__doPostBack('PageNumber','" + Convert.ToString(icount) + "')\">" + Convert.ToString(icount) + "</a></td>";
        }

        if (numberofpages > 10 && maxpagenumtodisplay < numberofpages) // Applied if number of pages are greater than 10 and there are still more pages to come.
        {
            pagingtableHTML += "<td><a href=\"javascript:__doPostBack('PageNumber','" + Convert.ToString(maxpagenumtodisplay + 1) + "')\">...</a></td>";
        }

        pagingtableHTML += " </tr></table>";
        return pagingtableHTML;
    }
}
