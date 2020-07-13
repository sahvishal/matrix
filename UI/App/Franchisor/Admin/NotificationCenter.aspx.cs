using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Franchisor;
using Falcon.App.Lib;
//using HealthYes.Web.UI.NotificationService;


public partial class App_Franchisor_Admin_NotificationCenter : System.Web.UI.Page
{

    # region "Page Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Notification Center";
        Franchisor_FranchisorMaster obj;

        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Notification Center");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();

        if (!IsPostBack)
        {
            
                grdNotificationCenter.PageSize = Convert.ToInt32(ddlRecords.SelectedValue);
                GetNotificationTypeMaster();
                GetNotificationMedium();
                GetNotificationStatus();
                // Sort Expression
                ViewState["SortExpression"] = "ServicedDate";
                ViewState["SortDir"] = "desc";
                ViewState["SearchStatus"] = "No";
                if (Request.QueryString["Mode"] == null)
                {
                    ViewState["StartDate"] = DateTime.Now.ToShortDateString();
                    ViewState["EndDate"] = DateTime.Now.ToShortDateString();
                    txtStartDate.Text = DateTime.Now.ToShortDateString();
                    txtEndDate.Text = DateTime.Now.ToShortDateString();
                    GetNotificationOther("", 0, "", "", 0, 3, 0);
                }
                else
                {
                    // Page back url
                    // Set Session.
                    // Customer Name Or CustomerID                
                    if (Session["CustomerID"] != null)
                    {
                        txtNameOrCustomerID.Text = Session["CustomerID"].ToString();
                        ViewState["CustomerID"] = txtNameOrCustomerID.Text;
                        ViewState["CustomerName"] = null;
                    }
                    else if (Session["CustomerName"] != null)
                    {
                        txtNameOrCustomerID.Text = Session["CustomerName"].ToString();
                        ViewState["CustomerName"] = txtNameOrCustomerID.Text;
                        ViewState["CustomerID"] = null;
                    }

                    // Start Date And EndDate
                    if (Session["StartDate"] != null && Session["EndDate"] != null)
                    {
                        txtStartDate.Text = Session["StartDate"].ToString();
                        ViewState["StartDate"] = txtStartDate.Text;
                        txtEndDate.Text = Session["EndDate"].ToString();
                        ViewState["EndDate"] = txtEndDate.Text;

                    }
                    else
                    {
                        ViewState["StartDate"] = null;
                        ViewState["EndDate"] = null;
                    }

                    // Service Status
                    if (Session["ddlStatus"] != null)
                    {
                        ddlStatus.SelectedValue=Session["ddlStatus"].ToString();
                        ViewState["ddlStatus"] = Session["ddlStatus"].ToString();
                    }

                    // Notification type
                    if (Session["ddlNotificationType"] != null)
                    {
                        ddlNotificationType.SelectedValue = Session["ddlNotificationType"].ToString();
                        ViewState["ddlNotificationType"] = Session["ddlNotificationType"].ToString();
                    }

                    // Notification Medium
                    if (Session["ddlMedium"] != null)
                    {
                        ddlMedium.SelectedValue = Session["ddlMedium"].ToString();
                        ViewState["ddlMedium"] = Session["ddlMedium"].ToString();
                    }
                    // Set search status to Yes
                    ViewState["SearchStatus"] = "No";
                    
                    // set all sessions to null
                    Session["CustomerID"]=null;
                    Session["CustomerName"]=null;
                    Session["StartDate"]=null;
                    Session["EndDate"]=null;
                    Session["ddlStatus"]=null;
                    Session["ddlNotificationType"]=null;
                    Session["ddlMedium"] = null;

                    GetNotificationOther("", 0, "", "", 0, 3, 0);
                }
        }
                // When page is postback - Reset
        if (Page.IsPostBack)
        {
            string eventArg = Request["__EVENTARGUMENT"];
            if (eventArg.Equals("Reset"))
            {
                ViewState["CustomerID"] = null;
                ViewState["CustomerName"] = null;
                ViewState["ddlStatus"]=null;
                ViewState["ddlNotificationType"]=null;
                ViewState["ddlMedium"] = null;
                ViewState["SortExpression"] = "ServicedDate";
                ViewState["SortDir"] = "desc";
                ViewState["SearchStatus"] = "No";
                ViewState["StartDate"] = DateTime.Now.ToShortDateString();
                ViewState["EndDate"] = DateTime.Now.ToShortDateString();
                txtStartDate.Text = DateTime.Now.ToShortDateString();
                txtEndDate.Text = DateTime.Now.ToShortDateString();
                GetNotificationOther("", 0, "", "", 0, 3, 0);
            }
        }
        

    }
    #endregion

    # region "Load Notification Type"
    private void GetNotificationTypeMaster()
    {
        //NotificationService objNotificationService = new NotificationService();
        //HealthYes.Web.UI.NotificationService.ENotificationType[] objENotificationType = new HealthYes.Web.UI.NotificationService.ENotificationType[0];

        //objENotificationType = objNotificationService.GetNotificationTypeMaster(1, true);

        FranchisorDAL objDAL = new FranchisorDAL();
        var listNotificationtype = objDAL.GetNotificationType(1);

        ENotificationType[] objENotificationType = null;
        if (listNotificationtype != null) objENotificationType = listNotificationtype.ToArray();

        ddlNotificationType.DataSource = objENotificationType;

        ddlNotificationType.Items.Clear();
        ddlNotificationType.Items.Add(new ListItem("All", "0"));

        for (int icount = 0; icount < objENotificationType.Length; icount++)
        {
            ddlNotificationType.Items.Add(new ListItem(objENotificationType[icount].NotificationTypeName, objENotificationType[icount].NotificationTypeID.ToString()));
        }
    }
    # endregion

    # region "Load Notification Medium"
    private void GetNotificationMedium()
    {
        //NotificationService objNotificationService = new NotificationService();
        //HealthYes.Web.UI.NotificationService.ENotificationMedium[] objENotificationMedium = new HealthYes.Web.UI.NotificationService.ENotificationMedium[0];

        //objENotificationMedium = objNotificationService.GetNotificationMedium();

        FranchisorDAL objDAL = new FranchisorDAL();
        ENotificationMedium[] objENotificationMedium = null;
        var listNotificationMedium = objDAL.GetNotificationMedium();

        if (listNotificationMedium != null) objENotificationMedium = listNotificationMedium.ToArray();

        ddlMedium.DataSource = objENotificationMedium;

        ddlMedium.Items.Clear();
        ddlMedium.Items.Add(new ListItem("All", "0"));

        for (int icount = 0; icount < objENotificationMedium.Length; icount++)
        {
            ddlMedium.Items.Add(new ListItem(objENotificationMedium[icount].NotificationMedium, objENotificationMedium[icount].NotificationMediumID.ToString()));
        }
    }
    # endregion

    # region "Load Notification Status"
    private void GetNotificationStatus()
    {
        ddlStatus.Items.Clear();
        ddlStatus.Items.Add(new ListItem("All", "3"));
        ddlStatus.Items.Add(new ListItem("Serviced", "1"));
        ddlStatus.Items.Add(new ListItem("Not Serviced", "0"));
        ddlStatus.Items.Add(new ListItem("Error", "2"));
    }
    # endregion

    # region "Load Notification Other"
    private void GetNotificationOther(string Name, Int64 CustomerID,
                                                            string StartDate, string EndDate,
                                                            int NotificationTypeId, int ServiceStatus,
                                                            int NotificationMediumID)
    {
        
        //NotificationService objNotificationService = new NotificationService();
        //HealthYes.Web.UI.NotificationService.ENotificationOther[] objENotificationOther = new HealthYes.Web.UI.NotificationService.ENotificationOther[0];

        // Get search parameters from viewstate
        if (ViewState["CustomerID"]!=null && (string) ViewState["CustomerID"]!="")
        {
            CustomerID=Convert.ToInt64(ViewState["CustomerID"]);
        }
        else if (ViewState["CustomerName"]!=null && (string) ViewState["CustomerName"]!="")
        {
            Name=ViewState["CustomerName"].ToString();
        }
        // StartDate and EndDate
        if (ViewState["StartDate"]!=null && ViewState["EndDate"]!=null)
        {
            if (ViewState["StartDate"].ToString() != "" && ViewState["EndDate"].ToString() != "")
            {                
            StartDate=ViewState["StartDate"].ToString();
            EndDate = ViewState["EndDate"].ToString();
            
            }
        }
        // Service Status
        if (ViewState["ddlStatus"]!=null && (string) ViewState["ddlStatus"]!="")
        {
            ServiceStatus=Convert.ToInt32(ViewState["ddlStatus"]);
        }
        
        // Notification Type
        if (ViewState["ddlNotificationType"]!=null && (string) ViewState["ddlNotificationType"]!="")
        {
            NotificationTypeId=Convert.ToInt32(ViewState["ddlNotificationType"]);
        }

        // Notification Medium
        if (ViewState["ddlMedium"]!=null && (string) ViewState["ddlMedium"]!="")
        {
            NotificationMediumID = Convert.ToInt32(ViewState["ddlMedium"]);
        }

        FranchisorDAL objDAL = new FranchisorDAL();
        var listNotificationOther = objDAL.GetNotificationOther(Name, CustomerID, StartDate, EndDate, NotificationTypeId, ServiceStatus, NotificationMediumID);
        ENotificationOther[] objENotificationOther = null;

        if (listNotificationOther != null) objENotificationOther = listNotificationOther.ToArray();

        //objENotificationOther = objNotificationService.GetNotificationOther(Name, CustomerID, true, StartDate, EndDate, NotificationTypeId, true, ServiceStatus, true, NotificationMediumID, true);

        DataTable dtNotification = new DataTable();

        dtNotification.Columns.Add("NotificationID", typeof(Int64));
        dtNotification.Columns.Add("UserID", typeof(Int64));
        dtNotification.Columns.Add("CustomerID", typeof(Int64));
        dtNotification.Columns.Add("CustomerName");
        dtNotification.Columns.Add("NotificationTypeName");
        dtNotification.Columns.Add("NotificationMedium");
        dtNotification.Columns.Add("ServiceStatus");
        dtNotification.Columns.Add("AttemptCount", typeof(Int64));
        dtNotification.Columns.Add("ServicedBy");
        dtNotification.Columns.Add("ServicedDate");


        if (objENotificationOther != null)
        {
            for (int icount = 0; icount < objENotificationOther.Length; icount++)
            {
                dtNotification.Rows.Add(new object[] { objENotificationOther[icount].NotificationID, objENotificationOther[icount].UserID, objENotificationOther[icount].CustomerID, objENotificationOther[icount].CustomerName, objENotificationOther[icount].NotificationType, objENotificationOther[icount].NotificationMedium, objENotificationOther[icount].ServiceStatus, objENotificationOther[icount].AttemptCount, objENotificationOther[icount].ServicedBy, objENotificationOther[icount].NotificationDate});
            }
        }

        if (ViewState["SortDir"].ToString().Equals("asc"))
        {
            dtNotification.DefaultView.Sort = " " + ViewState["SortExpression"].ToString() + " asc";

        }
        else
        {
            dtNotification.DefaultView.Sort = " " + ViewState["SortExpression"].ToString() + " desc";
        }

        grdNotificationCenter.DataSource = dtNotification.DefaultView;
        grdNotificationCenter.DataBind();

        if (ViewState["SearchStatus"].ToString().Equals("No"))
        {
            spnRecords.InnerText = "Found Total " + dtNotification.Rows.Count.ToString() + " Notifications Today";
        }
        else if (ViewState["SearchStatus"].ToString().Equals("Yes"))
        {
            spnRecords.InnerText = "Found " + dtNotification.Rows.Count.ToString() + " Notification Matching Creteria";
        }
        
        
        
        
    }
    # endregion

    #region "Page Index Changing Grid"
    protected void grdNotificationCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdNotificationCenter.PageIndex = e.NewPageIndex;
        GetNotificationOther("", 0, "", "", 0, 3, 0);
    }
    #endregion

    #region "SelectedIndexChanged "
    protected void ddlRecords_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdNotificationCenter.PageSize = Convert.ToInt32(ddlRecords.SelectedValue);
        GetNotificationOther("", 0, "", "", 0, 3, 0);
    }
    #endregion

    #region "Sorting Grid"
    protected void grdNotificationCenter_Sorting(object sender, GridViewSortEventArgs e)
    {
        grdNotificationCenter.PageIndex = 0;       
        ViewState["SortExpression"] = e.SortExpression.ToString();
        
        if (ViewState["SortDir"].ToString().Equals("asc"))
        {
            ViewState["SortDir"] = "desc";
        }
        else
        {
            ViewState["SortDir"] = "asc";
        }
        GetNotificationOther("", 0, "", "", 0, 3, 0);
    }
    #endregion

    #region "Search"
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        divDeleteMsg.Style.Add(HtmlTextWriterStyle.Display, "none");
        // Search Records.
        // Customer Name Or CustomerID
        if (IsNumeric(txtNameOrCustomerID.Text))
        {
            ViewState["CustomerID"] = txtNameOrCustomerID.Text;
            ViewState["CustomerName"] = null;
        }
        else
        {
            ViewState["CustomerName"] = txtNameOrCustomerID.Text;
            ViewState["CustomerID"] = null;
        }
        
        // Start Date And EndDate
        if (IsDate(txtStartDate.Text) && IsDate(txtEndDate.Text))
        {
            ViewState["StartDate"] = txtStartDate.Text;
            ViewState["EndDate"] = txtEndDate.Text;
        }
        else
        {
            ViewState["StartDate"] = null;
            ViewState["EndDate"] = null;
        }
        // Service Status
        if (ddlStatus.SelectedIndex > -1)
        {
            ViewState["ddlStatus"] = ddlStatus.SelectedValue;
        }

        // Notification type
        if (ddlNotificationType.SelectedIndex > -1)
        {
            ViewState["ddlNotificationType"] = ddlNotificationType.SelectedValue;
        }

        // Notification Medium
        if (ddlMedium.SelectedIndex > -1)
        {
            ViewState["ddlMedium"] = ddlMedium.SelectedValue;
        }
        // Set search status to Yes
        ViewState["SearchStatus"] = "Yes";

        // Search and bind the record to grid
        GetNotificationOther("", 0, "", "", 0, 3, 0);
    }

    #endregion

    #region IsNumeric
    /// <summary>
    /// Checks whether or not a string is number .
    /// </summary>
    /// <param name="string"></param>
    /// <returns>bool</returns>
    private bool IsNumeric(string strToTest)
    {
        Regex reNum = new Regex(@"^\d+$");
        return reNum.Match(strToTest).Success;
    }
    #endregion

    #region IsDate
    /// <summary>
    /// Checks whether or not a date is a valid date.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>bool</returns>
    public bool IsDate(string sdate)
    {

        DateTime dt;
        bool isDate = true;
        try
        {
            dt = DateTime.Parse(sdate);
        }
        catch
        {
            isDate = false;
        }
        return isDate;
    }
    #endregion

    #region Command_Button Grid
    /// <summary>
    /// Grid link button click
    /// </summary>
    /// 
    protected void Command_Button_Click(Object sender, CommandEventArgs e)
    {
        Int64 NotificationID = 0;
        switch (e.CommandName)
        {

           case "ViewNotification":
                NotificationID = Convert.ToInt32(e.CommandArgument.ToString());
                ViewNotification(NotificationID);
                break;
            case "ReServiceNotification":                
                NotificationID = Convert.ToInt32(e.CommandArgument.ToString());
                ReServiceNotification(NotificationID);                
                break;
            
        }
    }
    #endregion

    #region ViewNotification
    private void ViewNotification(Int64 NotificationID)
    {

        // Set Session.
        // Customer Name Or CustomerID
        if (IsNumeric(txtNameOrCustomerID.Text))
        {
            Session["CustomerID"] = txtNameOrCustomerID.Text;
            Session["CustomerName"] = null;
        }
        else
        {
            Session["CustomerName"] = txtNameOrCustomerID.Text;
            Session["CustomerID"] = null;
        }

        // Start Date And EndDate
        if (IsDate(txtStartDate.Text) && IsDate(txtEndDate.Text))
        {
            Session["StartDate"] = txtStartDate.Text;
            Session["EndDate"] = txtEndDate.Text;
        }
        else
        {
            Session["StartDate"] = null;
            Session["EndDate"] = null;
        }
        // Service Status
        if (ddlStatus.SelectedIndex > -1)
        {
            Session["ddlStatus"] = ddlStatus.SelectedValue;
        }

        // Notification type
        if (ddlNotificationType.SelectedIndex > -1)
        {
            Session["ddlNotificationType"] = ddlNotificationType.SelectedValue;
        }

        // Notification Medium
        if (ddlMedium.SelectedIndex > -1)
        {
            Session["ddlMedium"] = ddlMedium.SelectedValue;
        }
        // Set search status to Yes
        Session["SearchStatus"] = "No";

        // Redirect to ViewNotification Page
        //Response.RedirectUser("ViewNotification.aspx?NotificationID=" + NotificationID.ToString());
        string Url = "ViewNotification.aspx?NotificationID=" + NotificationID.ToString();
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "redirect", "location.href = " + "'" + Url + "'" + "", true);

        ScriptManager.RegisterClientScriptBlock(this, typeof(string), "redirect","location.href = " + "'" + Url + "'" + "", true);
    }
    #endregion

    #region ReServiceNotification
    private void ReServiceNotification(Int64 NotificationID)
    {
        string JSCode = string.Empty;
        Int64 returnvalue = 0;


        FranchisorDAL objDAL = new FranchisorDAL();
        returnvalue = objDAL.NotificationReServiced(NotificationID, @"App\Franchisor\Admin\NotificationCenter.aspx.cs", IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId, "Email", "", "", 1);


        JSCode = "alert('Re Service Notification Successfully ')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(string), "key", JSCode, true);

        GetNotificationOther("", 0, "", "", 0, 3, 0);

    }
    #endregion

    #region ImagePath
    protected string ImagePath(object strImagePath)
    {
        string ImagePathResult = string.Empty;
        string Imagepath = (string)strImagePath;
        if (Imagepath.Equals("Email"))
        {
            ImagePathResult = @"/App/Images/Email-icon.gif";
            
        }
        else
        {
            ImagePathResult = @"/App/Images/Phone-icon.gif";
        }
        return ImagePathResult;

    }
    #endregion

    private void DeleteNotification(int NotificationID)
    {
        bool returnResult = false;
        
        var objDAL = new FranchisorDAL();
        returnResult = objDAL.DeleteNotificationByID(NotificationID);

        if (returnResult == true)
            divDeleteMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
        else
            ClientScript.RegisterStartupScript(typeof(string), "jscode_deleteUnSuccessful", "alert('Notification can not be deleted');", true);

    }
    
    protected void lnkBtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnkBtnDelete = (LinkButton)sender;
        Int32 NotificationID = Convert.ToInt32(lnkBtnDelete.CommandArgument);
        DeleteNotification(NotificationID);
    }
    
    protected void grdNotificationCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GetNotificationOther("", 0, "", "", 0, 3, 0);
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "jscode_hideLoadingImage", "hideLoadingImage();", true);
    }

    /// <summary>
    /// Hide viewnotification and re-serviced notification for notification medium (phone).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdNotificationCenter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkViewNotification = (LinkButton)e.Row.FindControl("lnkViewNotification");
            LinkButton lnkReServiceNotification = (LinkButton)e.Row.FindControl("lnkReServiceNotification");
            HtmlImage imgMedium = (HtmlImage)e.Row.FindControl("imgMedium");
            if (imgMedium != null)
            {
                if (imgMedium.Alt.Equals("Phone"))
                {
                    lnkViewNotification.Enabled = false;
                    lnkReServiceNotification.Enabled = false;
                    lnkViewNotification.Style.Add(HtmlTextWriterStyle.Display, "none");
                    lnkReServiceNotification.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
            }

        }
    }
}
