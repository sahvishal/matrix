using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.App.UI.App.BasePageClass;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Lib;

public partial class App_UCCommon_UCCustomerList : BaseUserControl
{
    private int pageNumber = 1;

    private OrganizationRoleUserModel CurrentOrgRole
    {
        get { return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCustomerID.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtNCustomerID.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            chkAbdCustomer.Attributes["onClick"] = "return AbondonedCustomer()";

            GetDropDownInfo();
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

            if (Request.QueryString["QuickNavigation"] != null && Request.QueryString["CustomerName"] != null)
            {
                if (Request["ShowAll"] != null)
                {
                    if (Request["ShowAll"].Equals("True"))
                    {
                        chkAbdCustomer.Checked = true;
                    }
                }
                txtName.Text = Request.QueryString["CustomerName"];
                txtName.Text = txtName.Text.Replace("%", "");

                SearchCustomer(0, Request.QueryString["CustomerName"], "", "", "", "", "", 0, 0);
            }
            else
            {
                if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || CurrentOrgRole.CheckRole((long)Roles.CallCenterRep))
                {
                    divCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divCustomer.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                }
                else
                {
                    divCustomer.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divCustomer.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }

                if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    spButtons.Style.Add(HtmlTextWriterStyle.Display, "block");
                    spButtons.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                    ddlRecords.Visible = false;
                    spnPageLabel.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    spnPageLabel.Style.Add(HtmlTextWriterStyle.Display, "none");
                    GetCustomer();
                }
                else
                {
                    spButtons.Style.Add(HtmlTextWriterStyle.Display, "none");
                    spButtons.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    ddlRecords.Visible = false;

                    spnPageLabel.Style.Add(HtmlTextWriterStyle.Display, "none");
                    spnPageLabel.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }


                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    hfQueryString.Value = "No";
                    Session["ParameterString"] = null;
                    divStartCallSearch.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divStartCallSearch.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

                    divWithoutStartCallSearch.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divWithoutStartCallSearch.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

                    spPageSize.Style.Add(HtmlTextWriterStyle.Display, "none");
                    spPageSize.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
                if (Session["ParameterString"] != null)
                {
                    Session["ParameterString"] = null;
                    if (Request.QueryString["CustomerID"] != null || Request.QueryString["FranchiseeID"] != null || Request.QueryString["CustomerName"] != null || Request.QueryString["City"] != null || Request.QueryString["State"] != null || Request.QueryString["Zip"] != null || Request.QueryString["StartDate"] != null || Request.QueryString["EndDate"] != null || Request.QueryString["DateType"] != null)
                    {

                        int customerid = 0; string customername = "";
                        string city = ""; string state = "";
                        string zip = ""; string startdate = "";
                        string enddate = ""; int franchiseeid = 0; int datetype = 0;


                        if (Request.QueryString["CustomerID"] != null && Request.QueryString["CustomerID"].ToString().Trim().Length > 0)
                        {
                            customerid = Convert.ToInt32(Request.QueryString["CustomerID"]);

                        }

                        if (Request.QueryString["FranchiseeID"] != null && Request.QueryString["FranchiseeID"].ToString().Trim().Length > 0)
                        {
                            franchiseeid = Convert.ToInt32(Request.QueryString["FranchiseeID"]);

                        }

                        if (Request.QueryString["CustomerName"] != null)
                        {
                            if (Request.QueryString["CustomerName"].ToString().Trim().Length > 0)
                            {
                                customername = Convert.ToString(Request.QueryString["CustomerName"]);

                            }
                        }

                        if (Request.QueryString["City"] != null)
                        {
                            if (Request.QueryString["City"].ToString().Trim().Length > 0)
                            {
                                city = Convert.ToString(Request.QueryString["City"]);

                            }
                        }

                        if (Request.QueryString["State"] != null)
                        {
                            if (Request.QueryString["State"].ToString().Trim().Length > 0)
                            {
                                state = Convert.ToString(Request.QueryString["State"]);

                            }
                        }


                        if (Request.QueryString["Zip"] != null && Request.QueryString["Zip"].ToString().Trim().Length > 0)
                        {
                            if (Request.QueryString["Zip"].ToString().Trim().Length > 0)
                            {
                                zip = Convert.ToString(Request.QueryString["Zip"]);

                            }
                        }


                        if (Request.QueryString["StartDate"] != null)
                        {
                            if (Request.QueryString["StartDate"].ToString().Trim().Length > 0)
                            {
                                startdate = Convert.ToString(Request.QueryString["StartDate"]);

                            }
                        }

                        if (Request.QueryString["EndDate"] != null)
                        {
                            if (Request.QueryString["EndDate"].ToString().Trim().Length > 0)
                            {
                                enddate = Convert.ToString(Request.QueryString["EndDate"]);

                            }
                        }
                        if (Request.QueryString["DateType"] != null)
                        {
                            if (Request.QueryString["DateType"].ToString().Trim().Length > 0)
                            {
                                datetype = Convert.ToInt32(Request.QueryString["DateType"]);

                            }
                        }
                        if (Request.QueryString["Abondoned"] != null && Request.QueryString["Abondoned"].ToString() == "True")
                        {
                            chkAbdCustomer.Checked = true;
                        }
                        SearchCustomer(customerid, customername, city, state, zip, startdate, enddate, franchiseeid, datetype);
                    }

                }
            }
        }
        else
        {
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"] == "PageNumber")
            {
                pageNumber = Convert.ToInt32(Request.Form["__EVENTARGUMENT"]);
                int datetype = 0;
                switch (Convert.ToInt32(ddlDateType.SelectedValue))
                {
                    case 1:
                        datetype = 0;
                        break;
                    case 2:
                        datetype = 1;
                        break;
                    case 3:
                        datetype = 2;
                        break;
                    case 4:
                        datetype = 3;
                        break;
                }
                SearchCustomer(txtCustomerID.Text.Length > 0 ? Convert.ToInt32(txtCustomerID.Text) : 0, txtName.Text,
                               txtCity.Text, txtState.Text, txtZip.Text, txtStartDate.Text, txtEndDate.Text,
                               Convert.ToInt32(ddlFranchisee.SelectedValue), datetype);
            }
        }
    }

    private void GetDropDownInfo()
    {
        IOrganizationRepository franchiseeRepository = new OrganizationRepository();
        var franchisees =
            franchiseeRepository.GetOrganizationCollection(OrganizationType.Franchisee).OrderBy(fr => fr.Name).ToList();
        var namesAndIds = franchisees.Select(f => new { f.Name, f.Id });

        ddlFranchisee.DataSource = namesAndIds;
        ddlFranchisee.DataTextField = "Name";
        ddlFranchisee.DataValueField = "Id";
        ddlFranchisee.DataBind();
        ddlFranchisee.Items.Insert(0, new ListItem("Select Franchisee", "0"));
        ddlFranchisee.SelectedValue = "0";

        ddlFranchisee.Items.Add(new ListItem("Select Franchisee", "0"));

    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        int datetype = 0;
        //txtName.Text = txtName.Text.Replace("'", "''");
        //txtCity.Text = txtCity.Text.Replace("'", "''");
        //txtState.Text = txtState.Text.Replace("'", "''");
        //txtZip.Text = txtZip.Text.Replace("'", "''");
        grdCustomerList.PageIndex = 0;
        if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
        {
            if (txtNCustomerID.Text.Length > 0)
            {
                SearchCustomer(Convert.ToInt32(txtNCustomerID.Text), txtFirstName.Text.Replace("'", "''") + '%' + txtLastName.Text.Replace("'", "''"), "", "", txtZipCode.Text.Replace("'", "''"), "", "", 0, datetype);
            }
            else
            {
                SearchCustomer(0, txtFirstName.Text.Replace("'", "''") + '%' + txtLastName.Text.Replace("'", "''"), "", "", txtZipCode.Text.Replace("'", "''"), "", "", 0, datetype);
            }
        }
        else
        {
            switch (Convert.ToInt32(ddlDateType.SelectedValue))
            {
                case 1:
                    datetype = 0;
                    break;
                case 2:
                    datetype = 1;
                    break;
                case 3:
                    datetype = 2;
                    break;
                case 4:
                    datetype = 3;
                    break;
            }
            SearchCustomer(txtCustomerID.Text.Length > 0 ? Convert.ToInt32(txtCustomerID.Text) : 0, txtName.Text,
                           txtCity.Text, txtState.Text, txtZip.Text, txtStartDate.Text, txtEndDate.Text,
                           Convert.ToInt32(ddlFranchisee.SelectedValue), datetype);
        }
    }

    private class FranchisorCustomerListModel
    {
        public string Name { get; set; }
        public long EventID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RegDate { get; set; }
        public string EventDate { get; set; }
        public string Marketing { get; set; }
        public string Address { get; set; }
        public string RestAddress { get; set; }
        public string Event { get; set; }
        public string Host { get; set; }
        public string Package { get; set; }
        public long AddressID { get; set; }
        public long FranchiseeID { get; set; }
        public long CustomerID { get; set; }
        public float TotalRevenue { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string DateCreated { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string AddedBy { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string Paid { get; set; }
        public string IncomingNumber { get; set; }
        public string CallersPhoneNumber { get; set; }
        public bool IsLocked { get; set; }
        public string EventStatus { get; set; }
    }
    private void SearchCustomer(int customerid, string customername, string city, string state, string zip, string startdate, string enddate, int franchiseeid, int datetype)
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();
        List<FranchisorCustomerListModel> franchisorCustomerListModel = new List<FranchisorCustomerListModel>();

        string listparams = "";
        if (ViewState["ParameterString"] != null)
            listparams = ViewState["ParameterString"].ToString();

        listparams = "CustomerID=" + customerid + "&CustomerName=" + customername + "&City=" + city + "&State=" + state + "&Zip=" + zip + "&StartDate=" + startdate + "&EndDate=" + enddate + "&FranchiseeID=" + franchiseeid.ToString() + "&DateType=" + datetype.ToString() + "&Abondoned=" + chkAbdCustomer.Checked;
        ViewState["ParameterString"] = listparams;
        Session["ParameterString"] = listparams;
        var masterDal = new MasterDAL();
        EEvent objevent;
        long totalRecords;
        if (chkAbdCustomer.Checked == true)
        {
            objevent = masterDal.GetCustomerList(customerid, customername, city, state, zip, startdate, enddate, franchiseeid, datetype, 2, pageNumber, Convert.ToInt32(ddlRecords.SelectedValue), out totalRecords);
        }
        else
        {
            objevent = masterDal.SearchFranchisorCustomerList(customerid, customername, city, state, zip, startdate, enddate, franchiseeid, datetype, pageNumber, Convert.ToInt32(ddlRecords.SelectedValue), out totalRecords);
        }
        var filters = new {Customerid= customerid,Customername= customername, City = city, State = state, Zip = zip,  Startdate = startdate,Enddate = enddate, Franchiseeid = franchiseeid, Datetype = datetype, PageNumber = pageNumber};

        DataTable dtcustomer = new DataTable();
        dtcustomer.Columns.Add("Name");
        dtcustomer.Columns.Add("EventID");
        dtcustomer.Columns.Add("Email");
        dtcustomer.Columns.Add("Phone");
        dtcustomer.Columns.Add("RegDate", typeof(DateTime));
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
        dtcustomer.Columns.Add("IncomingNumber");
        dtcustomer.Columns.Add("CallersPhoneNumber");
        dtcustomer.Columns.Add("IsLocked", typeof(bool));
        dtcustomer.Columns.Add("EventStatus");

        if (objevent != null && objevent.Customer.Count > 0)
        {
            tblGridPagingConFirmCust.InnerHtml = ImplementPaging(pageNumber, Convert.ToInt32(ddlRecords.SelectedValue), totalRecords);
            for (int jcount = 0; jcount < objevent.Customer.Count; jcount++)
            {
                string address = objevent.Customer[jcount].Customer.BillingAddress.Address1;
                string restaddress = objevent.Customer[jcount].Customer.BillingAddress.City + " " + objevent.Customer[jcount].Customer.BillingAddress.State + " " + objevent.Customer[jcount].Customer.BillingAddress.Country + " " + objevent.Customer[jcount].Customer.BillingAddress.Zip;

                string username = string.Empty;

                if (objevent.Customer[jcount].Customer.User.MiddleName.Length > 0)
                {
                    username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.MiddleName + " " + objevent.Customer[jcount].Customer.User.LastName;
                }
                else
                {
                    username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.LastName;
                }

                var role = string.Empty;
                switch (objevent.Customer[jcount].Customer.AddedBy.ToString())
                {
                    case "10":
                        role = "Call Center";
                        break;
                    case "8":
                    case "7":
                    case "1":
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
                var strEventStatus = string.Empty;
                if (objevent.Customer[jcount].Customer.User.DateApplied.ToString().Length > 0 && objevent.Customer[jcount].Customer.User.DateApplied != null)
                {
                    //regdateLong = objevent.Customer[jcount].Customer.User.DateApplied.ToLongDateString();
                    regdateLong = objevent.Customer[jcount].Customer.User.DateApplied.ToString("dddd, MMMM dd, yyyy hh:mm tt ");
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
                // event status
                if (objevent.Customer[jcount].EventStatus > 0)
                {
                    strEventStatus = "<b>Status:</b>" + Convert.ToString(Enum.Parse(typeof(EventStatus), objevent.Customer[jcount].EventStatus.ToString()));
                }
                else strEventStatus = "";



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
                                                    paid,
                                                    objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.HomeAddress.PhoneNumber),
                                                    objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneCell),
                                                    objevent.Customer[jcount].Customer.User.Login.Locked,
                                                    strEventStatus});
                
                franchisorCustomerListModel.Add(new FranchisorCustomerListModel()
                {
                    Name = username,
                    EventID = objevent.Customer[jcount].Customer.User.UserID,
                    Email = objevent.Customer[jcount].Customer.User.EMail1,
                    Phone = objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneOffice),
                    RegDate = regdateLong,
                    EventDate = eventdate,
                    Marketing = objevent.Customer[jcount].Customer.Gender,
                    Address = address,
                    RestAddress = restaddress,
                    Event = objevent.Customer[jcount].Customer.CollectionMode,
                    Host = objevent.Customer[jcount].Customer.ContactMethod,
                    Package = orderScreeningDetail,
                    AddressID = objevent.Customer[jcount].Customer.User.HomeAddress.AddressID,
                    FranchiseeID = objevent.Customer[jcount].TechnicianID,
                    CustomerID = objevent.Customer[jcount].Customer.CustomerID,
                    TotalRevenue = amount,
                    State = objevent.Customer[jcount].Customer.BillingAddress.State,
                    City = objevent.Customer[jcount].Customer.BillingAddress.City,
                    Country = objevent.Customer[jcount].Customer.BillingAddress.Country,
                    Zip = objevent.Customer[jcount].Customer.BillingAddress.Zip,
                    DateCreated = regdateShort,
                    FName = objevent.Customer[jcount].Customer.User.FirstName,
                    LName = objevent.Customer[jcount].Customer.User.LastName,
                    AddedBy = role,
                    Gender = objevent.Customer[jcount].Customer.LastLogged,
                    Dob = objevent.Customer[jcount].Customer.Height,
                    Paid = paid,
                    IncomingNumber = objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.HomeAddress.PhoneNumber),
                    CallersPhoneNumber = objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneCell),
                    IsLocked = objevent.Customer[jcount].Customer.User.Login.Locked,
                    EventStatus = strEventStatus
                });

            }
            LogFilterListPairAudit(filters, franchisorCustomerListModel);
            divGrid.Style.Add(HtmlTextWriterStyle.Display, "block");
            divGrid.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            ibtnCSV.Visible = true;
            ibtnPDF.Visible = true;
        }
        else
        {
            divGrid.Style.Add(HtmlTextWriterStyle.Display, "none");
            divGrid.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            ibtnCSV.Visible = false;
            ibtnPDF.Visible = false;
        }
        dtcustomer = dtcustomer.DefaultView.ToTable();

        if (totalRecords <= 10)
        {
            ddlRecords.Visible = false;
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Display, "none");
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
        }
        else
        {
            ddlRecords.Visible = true;
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Display, "block");
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        }

        if (chkAbdCustomer.Checked || (Request.QueryString["Abondoned"] != null && Request.QueryString["Abondoned"] == "True"))
        {
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = true;
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = false;
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 3].Visible = false;
            if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = false;
            }

        }
        else// (chkAbdCustomer.Checked == false && (Request.QueryString["Abondoned"] != null && Request.QueryString["Abondoned"].ToString() == "False"))
        {
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 3].Visible = true;
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = true;
            if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = true;
            }
            else
            {
                grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = false;
            }

            if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = false;
            }
        }

        dvSearchResult1.InnerText = "Total: ";
        dvSearchResult.InnerText = totalRecords + " Result found";

        ViewState["TotalRecords"] = totalRecords;
        if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            spButtons.Style.Add(HtmlTextWriterStyle.Display, "block");
            spButtons.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        }
        else
        {
            spButtons.Style.Add(HtmlTextWriterStyle.Display, "none");
            spButtons.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
        }
        if (dtcustomer.Rows.Count <= 0)
        {
            ibtnCSV.Enabled = false;
            ibtnPDF.Enabled = false;
        }
        else
        {
            ibtnCSV.Enabled = true;
            ibtnPDF.Enabled = true;
        }
        if (chkAbdCustomer.Checked == true || (Request.QueryString["Abondoned"] != null && Request.QueryString["Abondoned"].ToString() == "True"))
        {
            ddlDateType.Enabled = false;
            ddlFranchisee.Enabled = false;
        }
        else
        {
            ddlDateType.Enabled = true;
            ddlFranchisee.Enabled = true;
        }

        grdCustomerList.DataSource = dtcustomer;
        grdCustomerList.DataBind();


    }

    private void GetCustomer()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();
        var masterDal = new MasterDAL();
        long pageCount;
        EEvent objevent = masterDal.GetCustomerList(0, "", "", "", "", "", "", 0, 0, 0, 1, 10, out pageCount);
        ViewState["ParameterString"] = "";
        var filters = new { Customerid = 0, Customername = "", City = "", State = "", Zip = "", Startdate = "", Enddate = "", Franchiseeid = 0, Datetype = 0, PageNumber = 1 };
        var franchisorCustomerListModel = new List<FranchisorCustomerListModel>();

        var dtcustomer = new DataTable();
        dtcustomer.Columns.Add("Name");
        dtcustomer.Columns.Add("EventID");
        dtcustomer.Columns.Add("Email");
        dtcustomer.Columns.Add("Phone");
        dtcustomer.Columns.Add("RegDate", typeof(DateTime));
        dtcustomer.Columns.Add("EventDate");
        dtcustomer.Columns.Add("Marketing");
        dtcustomer.Columns.Add("Address");
        dtcustomer.Columns.Add("RestAddress");
        dtcustomer.Columns.Add("Event");
        dtcustomer.Columns.Add("Host");
        dtcustomer.Columns.Add("Package");
        //dtcustomer.Columns.Add("AdditionalTest");
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
        dtcustomer.Columns.Add("IncomingNumber");
        dtcustomer.Columns.Add("CallersPhoneNumber");
        dtcustomer.Columns.Add("IsLocked", typeof(bool));
        dtcustomer.Columns.Add("EventStatus");

        if (objevent != null)
        {

            for (int jcount = 0; jcount < objevent.Customer.Count; jcount++)
            {
                string address = objevent.Customer[jcount].Customer.BillingAddress.Address1;
                string restaddress = objevent.Customer[jcount].Customer.BillingAddress.City + " " + objevent.Customer[jcount].Customer.BillingAddress.State + " " + objevent.Customer[jcount].Customer.BillingAddress.Country + " " + objevent.Customer[jcount].Customer.BillingAddress.Zip;
                string strEventStatus = string.Empty;

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
                    case "7":
                    case "1":
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
                // event status
                if (objevent.Customer[jcount].EventStatus > 0)
                {
                    strEventStatus = "<b>Status:</b>" + Convert.ToString(Enum.Parse(typeof(EventStatus), objevent.Customer[jcount].EventStatus.ToString()));
                }
                else strEventStatus = "";
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
                                                    objevent.Customer[jcount].Customer.User.DateApplied,
                                                    objevent.Customer[jcount].Customer.User.DOB,
                                                    objevent.Customer[jcount].Customer.Gender,
                                                    address,
                                                    restaddress,
                                                    objevent.Customer[jcount].Customer.CollectionMode,
                                                    objevent.Customer[jcount].Customer.ContactMethod,
                                                    orderScreeningDetail,
                                                   //objevent.Customer[jcount].EventPackage.Package.PackageName,
                                                   //objevent.Customer[jcount].AdditionalTest,
                                                   objevent.Customer[jcount].Customer.User.HomeAddress.AddressID,
                                                    objevent.Customer[jcount].TechnicianID,
                                                    objevent.Customer[jcount].Customer.CustomerID, 
                                                    objevent.Customer[jcount].PaymentDetail.Amount,
                                                    objevent.Customer[jcount].Customer.BillingAddress.State,
                                                    objevent.Customer[jcount].Customer.BillingAddress.City,
                                                    objevent.Customer[jcount].Customer.BillingAddress.Country,
                                                    objevent.Customer[jcount].Customer.BillingAddress.Zip,
                                                    objevent.Customer[jcount].Customer.User.DateApplied.ToString("MM/dd/yyyy"),
                                                    objevent.Customer[jcount].Customer.User.FirstName,
                                                    objevent.Customer[jcount].Customer.User.LastName,
                                                    role,
                                                    objevent.Customer[jcount].Customer.LastLogged,
                                                    objevent.Customer[jcount].Customer.Height,
                                                    paid,
                                                    objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.HomeAddress.PhoneNumber),
                                                    objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneCell),
                                                    objevent.Customer[jcount].Customer.User.Login.Locked,strEventStatus});

                franchisorCustomerListModel.Add(new FranchisorCustomerListModel()
                {
                    Name = username,
                    EventID = objevent.Customer[jcount].Customer.User.UserID,
                    Email = objevent.Customer[jcount].Customer.User.EMail1,
                    Phone = objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneOffice),
                    RegDate = objevent.Customer[jcount].Customer.User.DateApplied.ToShortDateString(),
                    EventDate = objevent.Customer[jcount].Customer.User.DOB,
                    Marketing = objevent.Customer[jcount].Customer.Gender,
                    Address = address,
                    RestAddress = restaddress,
                    Event = objevent.Customer[jcount].Customer.CollectionMode,
                    Host = objevent.Customer[jcount].Customer.ContactMethod,
                    Package = orderScreeningDetail,
                    AddressID = objevent.Customer[jcount].Customer.User.HomeAddress.AddressID,
                    FranchiseeID = objevent.Customer[jcount].TechnicianID,
                    CustomerID = objevent.Customer[jcount].Customer.CustomerID,
                    TotalRevenue = objevent.Customer[jcount].PaymentDetail.Amount,
                    State = objevent.Customer[jcount].Customer.BillingAddress.State,
                    City = objevent.Customer[jcount].Customer.BillingAddress.City,
                    Country = objevent.Customer[jcount].Customer.BillingAddress.Country,
                    Zip = objevent.Customer[jcount].Customer.BillingAddress.Zip,
                    DateCreated = objevent.Customer[jcount].Customer.User.DateApplied.ToString("MM/dd/yyyy"),
                    FName = objevent.Customer[jcount].Customer.User.FirstName,
                    LName = objevent.Customer[jcount].Customer.User.LastName,
                    AddedBy = role,
                    Gender = objevent.Customer[jcount].Customer.LastLogged,
                    Dob = objevent.Customer[jcount].Customer.Height,
                    Paid = paid,
                    IncomingNumber = objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.HomeAddress.PhoneNumber),
                    CallersPhoneNumber = objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneCell),
                    IsLocked = objevent.Customer[jcount].Customer.User.Login.Locked,
                    EventStatus = strEventStatus
                }); 

            }
        }
        LogFilterListPairAudit(filters, franchisorCustomerListModel);
        dtcustomer = dtcustomer.DefaultView.ToTable();
        if (dtcustomer.Rows.Count <= 10)
        {
            ddlRecords.Visible = false;
        }
        else
        {
            ddlRecords.Visible = true;
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Display, "block");
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        }
        grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = true;
        grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = true;
        grdCustomerList.Columns[grdCustomerList.Columns.Count - 3].Visible = true;

        if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
        {
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = true;
        }
        else
        {
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = false;
        }

        if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
        {
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = false;
        }

        dvSearchResult1.InnerText = "Total: ";
        //dvSearchResult.InnerText = dtcustomer.Rows.Count + " Result found";
        dvSearchResult.InnerText = objevent.TotalRecord + " Result found";

        if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            spButtons.Style.Add(HtmlTextWriterStyle.Display, "block");
            spButtons.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        }
        else
        {
            spButtons.Style.Add(HtmlTextWriterStyle.Display, "none");
            spButtons.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
        }
        if (dtcustomer.Rows.Count <= 0)
        {
            ibtnCSV.Enabled = false;
            ibtnPDF.Enabled = false;
        }
        else
        {
            ibtnCSV.Enabled = true;
            ibtnPDF.Enabled = true;
        }
        ddlDateType.Enabled = true;
        ddlFranchisee.Enabled = true;
        divGrid.Style.Add(HtmlTextWriterStyle.Display, "block");
        divGrid.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        grdCustomerList.PageSize = Convert.ToInt32(ddlRecords.SelectedValue);
        grdCustomerList.DataSource = dtcustomer;
        grdCustomerList.DataBind();


    }

    protected void ddlRecords_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ViewState["ParameterString"] != null && ViewState["ParameterString"].ToString().Length > 0)
        {
            int datetype = 0;
            if (Convert.ToInt32(ddlDateType.SelectedValue) == 1)
            {
                datetype = 0;
            }
            else if (Convert.ToInt32(ddlDateType.SelectedValue) == 2)
            {
                datetype = 1;
            }
            else if (Convert.ToInt32(ddlDateType.SelectedValue) == 3)
            {
                datetype = 2;

            }
            else if (Convert.ToInt32(ddlDateType.SelectedValue) == 4)
            {
                datetype = 3;

            }
            if (txtCustomerID.Text.Length > 0)
            {
                SearchCustomer(Convert.ToInt32(txtCustomerID.Text), txtName.Text, txtCity.Text, txtState.Text, txtZip.Text, txtStartDate.Text, txtEndDate.Text, Convert.ToInt32(ddlFranchisee.SelectedValue), datetype);
            }
            else
            {
                SearchCustomer(0, txtName.Text, txtCity.Text, txtState.Text, txtZip.Text, txtStartDate.Text, txtEndDate.Text, Convert.ToInt32(ddlFranchisee.SelectedValue), datetype);
            }
        }
        else
        {
            GetCustomer();
        }
    }

    protected void grdCustomerList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            long eventid = Convert.ToInt64(((DataRowView)(e.Row.DataItem)).Row["EventID"]);
            long customerid = Convert.ToInt64(((DataRowView)(e.Row.DataItem)).Row["CustomerID"]); ;
            if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                var eventname = (HtmlAnchor)e.Row.FindControl("EventName");
                eventname.HRef = "~/App/Common/EventDetails.aspx?EventId=" + eventid;

                var customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                customername.HRef = "~/App/Franchisee/FranchiseeEditCustomer.aspx?CustomerID=" + customerid + "&Master=EventCustomer";

                var customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");
                customerlist.HRef = "~/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" + customerid;

            }
            else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                var eventname = (HtmlAnchor)e.Row.FindControl("EventName");
                //eventname.HRef = "~/App/Common/CommonEventCustomerList.aspx?EventID=" + eventid.ToString() + "&Master=EventCustomer";
                eventname.HRef = "";

                var customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                customername.HRef = "~/App/Franchisee/SalesRep/SalesRepEditCustomer.aspx?CustomerID=" + customerid + "&Master=EventCustomer";

                var customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");
                customerlist.HRef = "~/App/Franchisee/SalesRep/SalesRepCustomerDetails.aspx?CustomerID=" + customerid;


            }
            else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {

                var eventname = (HtmlAnchor)e.Row.FindControl("EventName");
                eventname.HRef = "~/App/Common/EventDetails.aspx?EventId=" + eventid;


                var customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                customername.HRef = "~/App/Franchisor/FranchisorEditCustomer.aspx?CustomerID=" + customerid + "&Master=EventCustomer";

                var customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");
                customerlist.HRef = "~/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + customerid;
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.Technician))
            {
                var eventname = (HtmlAnchor)e.Row.FindControl("EventName");
                eventname.HRef = "/Scheduling/EventCustomerList/Index?id=" + eventid;

                var customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                customername.HRef = "~/App/Franchisee/Technician/TechnicianEditCustomer.aspx?CustomerID=" + customerid.ToString() + "&Master=EventCustomer";

                var customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");
                customerlist.HRef = "~/App/Franchisee/Technician/TechnicianCustomerDetails.aspx?CustomerID=" + customerid.ToString();

            }
            else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
            {
                var customername = (HtmlAnchor)e.Row.FindControl("CustomerName");
                var customerlist = (HtmlAnchor)e.Row.FindControl("customerlist");

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
        if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Display, "none");
            GetCustomer();
        }
        else
        {
            divCustomer.Style.Add(HtmlTextWriterStyle.Display, "none");
            divCustomer.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

            spButtons.Style.Add(HtmlTextWriterStyle.Display, "none");
            spButtons.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            ddlRecords.Visible = false;
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Display, "none");
            spnPageLabel.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

            dvSearchResult1.InnerText = "";
            dvSearchResult.InnerText = "";
            divGrid.Style.Add(HtmlTextWriterStyle.Display, "none");
            divGrid.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
        }
    }

    protected void ibtnCSV_Click(object sender, ImageClickEventArgs e)
    {

        if (chkAbdCustomer.Checked)
        {
            GetAbondonedCSV();
        }
        else
        {
            GetEventCustomerCSV();
        }


    }

    private void GetAbondonedCSV()
    {
        var objCommonCode = new CommonCode();

        string excelname = "CustomerListCSV_" + DateTime.Now.ToFileTimeUtc() + ".csv";
        if (!Directory.Exists(Server.MapPath("/CSV/")))
        {
            Directory.CreateDirectory(Server.MapPath("/CSV/"));
        }
        string servermappath = Server.MapPath("/CSV/" + excelname);
        var sw = new StreamWriter(servermappath);
        var strCustomer = new System.Text.StringBuilder();
        string header = "CustomerID" + "," + " FName " + "," + "LName" + "," + "Phone Number" + "," + "Gender" + "," + "DOB" + "," + "Address" +
                        "," + "City" + "," + "State" + "," + "Zip" + "," + "Signup Date" + "," + "Source" + "," + "Mode" +
                        "," + "Called/Incoming Number" + "," + "Users Caller Id" + "," + "Callback Status" + "," + "Do not call reason" + "," + "Last Screening Date";

        strCustomer.Append(header);
        sw.Write(header);
        header = "\r\n";
        strCustomer.Append(header);
        sw.Write(header);

        long totalRecords;
        var masterDal = new MasterDAL();
        int datetype = 0;
        switch (Convert.ToInt32(ddlDateType.SelectedValue))
        {
            case 1:
                datetype = 0;
                break;
            case 2:
                datetype = 1;
                break;
            case 3:
                datetype = 2;
                break;
            case 4:
                datetype = 3;
                break;
        }
        var objevent = masterDal.GetCustomerList(
            txtCustomerID.Text.Length > 0 ? Convert.ToInt32(txtCustomerID.Text) : 0, txtName.Text, txtCity.Text,
            txtState.Text, txtZip.Text, txtStartDate.Text, txtEndDate.Text, Convert.ToInt32(ddlFranchisee.SelectedValue),
            datetype, 2, pageNumber, ViewState["TotalRecords"] != null ? Convert.ToInt32(ViewState["TotalRecords"]) : 0,
            out totalRecords);

        if (objevent != null && objevent.Customer != null && objevent.Customer.Count > 0)
        {
            var role = string.Empty;
            for (int i = 0; i < objevent.Customer.Count; i++)
            {
                string s;
                try
                {
                    s = objevent.Customer[i].Customer.CustomerID.ToString();
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent.Customer[i].Customer.User.FirstName;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent.Customer[i].Customer.User.LastName;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent.Customer[i].Customer.User.PhoneOffice;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent.Customer[i].Customer.LastLogged;//Gender
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = !string.IsNullOrEmpty(objevent.Customer[i].Customer.Height) ? Convert.ToDateTime(objevent.Customer[i].Customer.Height).ToString("MM/dd/yyyy") : "";//DOB
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent.Customer[i].Customer.BillingAddress.Address1;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent.Customer[i].Customer.BillingAddress.City;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent.Customer[i].Customer.BillingAddress.State;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent.Customer[i].Customer.BillingAddress.Zip;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = Convert.ToDateTime(objevent.Customer[i].Customer.User.DateApplied).ToString("MM/dd/yyyy");
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent.Customer[i].Customer.Gender;//TrackingMarketingID
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    switch (objevent.Customer[i].Customer.AddedBy.ToString())
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

                    s = role;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objCommonCode.FormatPhoneNumberGet(objevent.Customer[i].Customer.User.HomeAddress.PhoneNumber);//IncomingPhoneLine
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objCommonCode.FormatPhoneNumberGet(objevent.Customer[i].Customer.User.PhoneCell);//CallersPhoneNumber
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);

                    s = objevent.Customer[i].Customer.DoNotContactReasonId > 0 ? "Do not call" : "Can call";
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);

                    s = objevent.Customer[i].Customer.DoNotContactReasonId > 0 ? ((DoNotContactReason)objevent.Customer[i].Customer.DoNotContactReasonId).GetDescription() : "";
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);

                    s = objevent.Customer[i].Customer.LastScreeningDate;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);

                    sw.Write(s);

                }
                catch (Exception)
                {

                }
                finally
                {
                    s = "\r\n";
                    strCustomer.Append(s);
                    sw.Write(s);

                }
            }
        }

        sw.Close();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=" + excelname);
        Response.Charset = "";
        ////Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = " text/csv";
        Response.Write(strCustomer.ToString());
        Response.End();
    }

    private void GetEventCustomerCSV()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();
        int datetype = 0;

        if (Convert.ToInt32(ddlDateType.SelectedValue) == 1)
        {
            datetype = 0;
        }
        else if (Convert.ToInt32(ddlDateType.SelectedValue) == 2)
        {
            datetype = 1;
        }
        else if (Convert.ToInt32(ddlDateType.SelectedValue) == 3)
        {
            datetype = 2;
        }
        else if (Convert.ToInt32(ddlDateType.SelectedValue) == 4)
        {
            datetype = 3;
        }
        var masterDal = new MasterDAL();
        List<EEventCustomer> objevent;
        if (txtCustomerID.Text.Length > 0)
        {
            objevent = masterDal.GetEventCustomerCSV(Convert.ToInt32(txtCustomerID.Text), txtName.Text, txtCity.Text, txtState.Text, txtZip.Text, txtStartDate.Text, txtEndDate.Text, Convert.ToInt32(ddlFranchisee.SelectedValue), datetype, 0);
        }
        else
        {
            objevent = masterDal.GetEventCustomerCSV(0, txtName.Text, txtCity.Text, txtState.Text, txtZip.Text, txtStartDate.Text, txtEndDate.Text, Convert.ToInt32(ddlFranchisee.SelectedValue), datetype, 0);
        }
        if (objevent != null && objevent.Count > 0)
        {
            string excelname = "CustomerListCSV_" + DateTime.Now.ToFileTimeUtc() + ".csv";
            if (!Directory.Exists(Server.MapPath("/CSV/")))
            {
                Directory.CreateDirectory(Server.MapPath("/CSV/"));
            }
            string servermappath = Server.MapPath("/CSV/" + excelname);
            StreamWriter sw = new StreamWriter(servermappath);
            System.Text.StringBuilder strCustomer = new System.Text.StringBuilder();
            string header = "CustomerID" + "," +
                            " FName " + "," +
                            "LName" + "," +
                            "Gender" + "," +
                            "DOB" + "," +
                            "Address" + "," +
                            "City" + "," +
                            "State" + "," +
                            "Zip" + "," +
                            "Signup Date" + "," +
                            "Source" + "," +
                            "Paid?" + "," +
                            "Amount" + "," +
                            "Package" + "," +
                            "Cost" + "," +
                            "Host" + "," +
                            "EventId" + "," +
                            "Event" + "," +
                            "EventDate" + "," +
                            "Adddress" + "," +
                            "City" + "," +
                            "State" + "," +
                            "Zip" + "," +
                            "Race" + "," +
                            "EMail" + "," +
                            "RequestedNewsLetter" + "," +
                            "Height" + "," +
                            "Weight" + "," +
                            "Cash" + "," +
                            "Check" + "," +
                            "CreditCard" + "," +
                            "Mode" + "," +
                            "CouponCode" + "," +
                            "Discount" + "," +
                            "Called/Incoming Number" + "," +
                            "Users Caller Id" + "," +
                            "PodName," + "Host Screening Co-coordinator" + "," + "Callback Status" + "," + "Do not call reason" + "," + "Last Screening Date";
            strCustomer.Append(header);
            sw.Write(header);
            header = "\r\n";
            strCustomer.Append(header);
            sw.Write(header);
            for (int icount = 0; icount < objevent.Count; icount++)
            {
                string s;
                //string cash = "0";
                //string credit = "0";
                //string check = "0";
                string Mode = "-N/A-";
                try
                {

                    s = objevent[icount].Customer.CustomerID.ToString();
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.User.FirstName;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.User.LastName;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.Gender;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.User.Answer;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.User.HomeAddress.Address1;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.User.HomeAddress.City;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.User.HomeAddress.State;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.User.HomeAddress.Zip;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = Convert.ToDateTime(objevent[icount].Customer.User.DOB).ToString("MM/dd/yyyy");
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.User.EMail1;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);


                    s = objevent[icount].Paid.ToString();
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].EventPackage.PackagePrice.ToString("C2");
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = !string.IsNullOrEmpty(objevent[icount].EventPackage.Package.PackageName)
                    ? objevent[icount].EventPackage.Package.PackageName : string.Empty;
                    var orderSeprator = !string.IsNullOrEmpty(objevent[icount].EventPackage.Package.PackageName)
                                            ? ", "
                                            : string.Empty;
                    s = !string.IsNullOrEmpty(objevent[icount].AdditionalTest)
                       ? s + orderSeprator + objevent[icount].AdditionalTest : s;




                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].EventPackage.Package.CostPrice.ToString("C2");
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.ContactMethod;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].EventID.ToString();
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.CollectionMode;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.User.DateApplied.ToString("MM/dd/yyyy");
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.BillingAddress.Address1;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.BillingAddress.City;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.BillingAddress.State;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.BillingAddress.Zip;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.Race;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].EventPackage.Package.Description;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.RequestForNewsLetter ? "Yes" : "No";
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.Height.ToString();
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.Weight.ToString();
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].CashPayment.ToString("C2");
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = (objevent[icount].CheckPayment + objevent[icount].EcheckPayment).ToString("C2");
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].CreditCardPayment.ToString("C2");
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    switch (objevent[icount].Customer.User.UserID.ToString())
                    {
                        case "10":
                            Mode = "Call Center";
                            break;
                        case "8":
                            Mode = "Walk In";
                            break;
                        case "9":
                            Mode = "Internet";
                            break;

                    }

                    s = Mode;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);


                    s = objevent[icount].Coupon.CouponCode;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Coupon.CouponAmount.ToString("C2");
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objCommonCode.FormatPhoneNumberGet(objevent[icount].Customer.User.HomeAddress.PhoneNumber.ToString());
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objCommonCode.FormatPhoneNumberGet(objevent[icount].Customer.User.PhoneCell.ToString());
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].PodName;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].SalesRep;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);
                    sw.Write(s);

                    s = objevent[icount].Customer.DoNotContactReasonId > 0 ? "Do not call" : "Can call";
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);

                    s = objevent[icount].Customer.DoNotContactReasonId > 0 ? ((DoNotContactReason)objevent[icount].Customer.DoNotContactReasonId).GetDescription() : "";
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);

                    s = objevent[icount].Customer.LastScreeningDate;
                    s = "\"" + s + "\"" + ",";
                    strCustomer.Append(s);

                }
                catch (Exception)
                {

                }
                finally
                {
                    s = "\r\n";
                    strCustomer.Append(s);
                    sw.Write(s);
                }


            }
            sw.Close();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + excelname);
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = " text/csv";
            Response.Write(strCustomer.ToString());
            Response.End();

        }

    }

    protected void ibtnPDF_Click(object sender, ImageClickEventArgs e)
    {
        string rolename = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias;

        string newpdfpath = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "/App/Common/PDFCustomerList.aspx");

        // Replace the query string in case it already cames from url
        if (newpdfpath.IndexOf('?') >= 0)
        {
            newpdfpath = newpdfpath.Substring(0, newpdfpath.IndexOf('?'));
        }

        if (ViewState["ParameterString"] != null && ViewState["ParameterString"].ToString().Length > 0)
            newpdfpath = newpdfpath + "?" + ViewState["ParameterString"].ToString() + "&RoleName=" + rolename;
        else
            newpdfpath = newpdfpath + "?" + "RoleName=" + rolename;

        var pdfConverterPath = Server.MapPath(@"~\bin");

        var mediaLocation = IoC.Resolve<IMediaRepository>().GetTempMediaFileLocation();

        var pdfname = IoC.Resolve<IPdfGenerator>().Generate(newpdfpath, mediaLocation.PhysicalPath, pdfConverterPath);


        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "javascript:popupmenu2('" + mediaLocation.Url + "/" + pdfname + "',680,700);", true);
    }

    protected string IncomingNumber(object incomingPhone)
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        if (incomingPhone.ToString() != "")
            return "<b>Incoming Phone:</b><br />" + objCommonCode.FormatPhoneNumberGet(incomingPhone.ToString());
        else
            return "";
    }

    private string ImplementPaging(int pagenumber, int pagesize, long recordcount)
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
