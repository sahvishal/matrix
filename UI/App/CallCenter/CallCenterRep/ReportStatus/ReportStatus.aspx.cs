using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.Entity.CallCenter;
using Falcon.Entity.Other;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Lib;

public partial class App_CallCenter_ReportStatus_ReportStatus : Page
{
    protected long ExistingCallId
    {
        get
        {
            long callId = 0;
            if (Session["CallId"] != null) long.TryParse(Session["CallId"].ToString(), out callId);
            return callId;
        }
    }

    protected long? CustomerId
    {
        get
        {
            if (Session["CustomerId"] != null && !string.IsNullOrEmpty(Session["CustomerId"].ToString()))
            {
                long customerId;
                if (Int64.TryParse(Session["CustomerId"].ToString(), out customerId))
                    return customerId;
            }
            return null;
        }
    }

    private Customer Customer
    {
        get
        {
            if (!CustomerId.HasValue)
                return null;
            ICustomerRepository customerRepository = new CustomerRepository();
            return customerRepository.GetCustomer(CustomerId.Value);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Get the customer detail
        Page.Title = "Report Status";
        CallCenter_CallCenterMaster1 obj;
        obj = (CallCenter_CallCenterMaster1)this.Master;
        obj.SetTitle("Report Status");
        obj.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";

        obj.hideucsearch();
        if (!IsPostBack)
        {
            
           
            var repository = new CallCenterCallRepository();
            ECall objCall = repository.GetCallCenterEntity(ExistingCallId);
            hfCallStartTime.Value = objCall.TimeCreated;

            if (CustomerId.HasValue && Customer!=null)
            {

                spnCustomerName.InnerText = Customer.NameAsString;
                string strCustAddress = CommonClass.FormatAddress(Customer.Address.StreetAddressLine1,
                                                                  Customer.Address.StreetAddressLine2,
                                                                  Customer.Address.City,
                                                                  Customer.Address.State,
                                                                  Customer.Address.ZipCode.Zip);
                spnAddress.InnerHtml = strCustAddress;
                spnEmail.InnerText = Customer.Email != null ? Customer.Email.ToString() : string.Empty;


                var masterDal = new MasterDAL();
                List<EEvent> customerEvent = masterDal.GetCustomerEvent(CustomerId.Value.ToString(), 1);

                DataTable tbltemp = new DataTable();
                tbltemp.Columns.Add("Id");
                tbltemp.Columns.Add("Name");
                tbltemp.Columns.Add("Date");
                tbltemp.Columns.Add("City");
                tbltemp.Columns.Add("AppTime");
                tbltemp.Columns.Add("Package");
                tbltemp.Columns.Add("PaymentMethod");
                tbltemp.Columns.Add("Status");
                tbltemp.Columns.Add("EventCustomerID");
                tbltemp.Columns.Add("HostName");
                tbltemp.Columns.Add("HostAddress");

                if (customerEvent != null)
                {

                    for (Int32 intCounter = 0; intCounter < customerEvent.Count; intCounter++)
                    {
                        string strEventDate =
                            Convert.ToDateTime(customerEvent[intCounter].EventDate).ToString("MMM dd yyyy");

                        string strAppointmentStartTime =
                            Convert.ToDateTime(customerEvent[intCounter].Customer[0].EventAppointment.StartTime).
                                ToString("hh:mm tt");
                        string strAppointmentEndTime =
                            Convert.ToDateTime(customerEvent[intCounter].Customer[0].EventAppointment.EndTime).ToString(
                                "hh:mm tt");
                        string strAppointmentTime = strAppointmentStartTime + " - " +
                                                    strAppointmentEndTime;
                        string strPackage = customerEvent[intCounter].Customer[0].EventPackage.Package.PackageName;
                        string strReportStatus = customerEvent[intCounter].Customer[0].Interpreted.ToString();
                        string strPayMethod = customerEvent[intCounter].Customer[0].PaymentDetail.PaymentType.Name;

                        tbltemp.Rows.Add(new object[]
                                             {
                                                 customerEvent[intCounter].EventID, customerEvent[intCounter].Name,
                                                 strEventDate, customerEvent[intCounter].Host.Address.City,
                                                 strAppointmentTime, strPackage, strPayMethod, strReportStatus,
                                                 customerEvent[intCounter].Customer[0].CustomerEventTestID,
                                                 customerEvent[intCounter].Host.Name, "HostAddress"
                                             });
                    }

                    dgeventhistory.DataSource = tbltemp;
                    ViewState["DSGRID"] = tbltemp;
                    dgeventhistory.DataBind();


                    dbsearch.Visible = true;
                    dbsearch.Style["display"] = "";

                }
                else
                {
                    dbsearch.Visible = false;
                    dbsearch.Style["display"] = "";

                    dgeventhistory.Visible = false;
                    dvSearchResult.InnerText = "No Result found";
                }
            }
        }
    }
    protected void dgeventhistory_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dgeventhistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgeventhistory.PageIndex = e.NewPageIndex;
        dgeventhistory.DataSource = (DataTable)ViewState["DSGRID"];
        dgeventhistory.DataBind();
    }
    protected void imgEndCall_Click(object sender, ImageClickEventArgs e)
    {

        CommonCode objCommoncode = new CommonCode();
        objCommoncode.EndCCRepCall(this.Page);


    }
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser("../SearchCustomer.aspx?Type='ReportStatus'");
    }
}
