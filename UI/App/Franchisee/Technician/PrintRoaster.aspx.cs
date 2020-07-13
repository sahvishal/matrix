using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.DataAccess.Master;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Deprecated.Utility;
using EEventCustomer=Falcon.Entity.Other.EEventCustomer;
using Falcon.App.Lib;

public partial class App_Franchisee_Technician_PrintRoaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Print Roster";
        Franchisee_Technician_TechnicianMaster objmaster = (Franchisee_Technician_TechnicianMaster)this.Master;
        objmaster.SetBreadcrumb = "Event Customers";
     
        string EventID = string.Empty;
        string EventName = string.Empty;

        img_btnPrint.OnClientClick = "return OpenPDFPage('" + Request.Url.Host + "');";

        if (!IsPostBack)
        {
            ViewState["SortDirection"] = SortDirection.Descending;
            if (Request.QueryString["EventID"] != null)
            {
                EventID = Request.QueryString["EventID"].ToString();
                EventName = Request.QueryString["EventName"].ToString();
                Session["EventName"] = EventName;
                Session["EventID"] = EventID;
                Session["EventAddress"] = Request.QueryString["EventAddress"].ToString();
                Session["EventDate"] = Request.QueryString["EventDate"].ToString();
                Session["HostDetails"] = Request.QueryString["HostName"].ToString() + "/" + Request.QueryString["HostPhone"].ToString();
                LoadGrid();
            }
            else
            {
                divMsg.Visible = true;
                divMsg.InnerHtml = "No Records of this Event";
                img_btnPrint.Visible = false;
                divError.Visible = false;
            }
            

        }
        System.Text.StringBuilder strJS = new System.Text.StringBuilder();
        strJS.Append(" <script language = 'Javascript'>OpenPDFPage('" + Request.Url.Host + "');</script>");
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "JSCode", strJS.ToString(), false);

    }

    private void LoadGrid()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        var masterDal = new MasterDAL();
        List<EEventCustomer> eevent = masterDal.GetCustomerListRoaster(Session["EventID"].ToString(),0);
        
        DataTable tblEvent = new DataTable();
    
        tblEvent.Columns.Add("Serial");
        tblEvent.Columns.Add("AppointmentTime", typeof(DateTime));
        tblEvent.Columns.Add("CustomerID");
        tblEvent.Columns.Add("CustomerName");
        tblEvent.Columns.Add("PackageTests");
        tblEvent.Columns.Add("Amount");
        tblEvent.Columns.Add("Discount");
        tblEvent.Columns.Add("PaymentStatus");
        tblEvent.Columns.Add("CheckInTime");
        tblEvent.Columns.Add("CheckOutTime");
        tblEvent.Columns.Add("Signature");
        tblEvent.Columns.Add("CouponCode");
        tblEvent.Columns.Add("Email");
        tblEvent.Columns.Add("Phone");
      
        int i = 1;
        if (eevent.Count > 0)
        {
            foreach (EEventCustomer objEvent in eevent)
            {
                string name = CommonClass.FormatName(objEvent.Customer.User.FirstName, "", objEvent.Customer.User.LastName);
                DateTime appointment = Convert.ToDateTime(objEvent.EventAppointment.StartTime);
               // string starttime = appointment.ToShortTimeString();
                string email = objEvent.Customer.User.EMail1;
                string phone = objCommonCode.FormatPhoneNumberGet(objEvent.Customer.User.PhoneCell);
                if (Convert.ToInt32(objEvent.Paid)==0)
                {
                    tblEvent.Rows.Add(i, appointment, objEvent.Customer.CustomerID, name, objEvent.EventPackage.Package.PackageName, "$" + objEvent.PaymentDetail.Amount.ToString(), "$" + String.Format("{0:F2}", objEvent.Coupon.CouponValue), "No", objEvent.EventAppointment.CheckInTime, objEvent.EventAppointment.CheckOutTime, "________", objEvent.Coupon.CouponCode, email, phone);
                }
                else
                {
                    tblEvent.Rows.Add(i, appointment, objEvent.Customer.CustomerID, name, objEvent.EventPackage.Package.PackageName, "$" + objEvent.PaymentDetail.Amount.ToString(), "$" + String.Format("{0:F2}", objEvent.Coupon.CouponValue), "Yes", objEvent.EventAppointment.CheckInTime, objEvent.EventAppointment.CheckOutTime, "________", objEvent.Coupon.CouponCode, email, phone);
                }
                i++;
         
            }
     
        }
        else
        {
            divMsg.Visible = true;
            divMsg.InnerHtml = "No Records of this Event";
            img_btnPrint.Visible = false;
            divError.Visible = false;
        }

        //if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
        //{
        //    tblEvent.DefaultView.Sort = "AppointmentTime desc";
        //    ViewState["SortDirection"] = SortDirection.Descending;
        //}
        //else
        //{
        //    tblEvent.DefaultView.Sort = "AppointmentTime asc";
        //    ViewState["SortDirection"] = SortDirection.Ascending;
        //}
        tblEvent = tblEvent.DefaultView.ToTable();

        grdPrintRoster.DataSource = tblEvent;
        ViewState["DSGRID"] = tblEvent;
        Session["TableEventCustomerList"] = (DataTable)ViewState["DSGRID"];
        grdPrintRoster.DataBind();

    }


    protected void grdPrintRoster_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tblEvent = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
        {
            tblEvent.DefaultView.Sort = "AppointmentTime desc";
            ViewState["SortDirection"] = SortDirection.Descending;
        }
        else
        {
            tblEvent.DefaultView.Sort = "AppointmentTime asc";
            ViewState["SortDirection"] = SortDirection.Ascending;
        }
        tblEvent = tblEvent.DefaultView.ToTable();
        grdPrintRoster.DataSource = tblEvent;
        grdPrintRoster.DataBind();
        ViewState["DSGRID"] = tblEvent;
    }
}
