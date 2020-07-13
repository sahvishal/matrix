using System;
using System.Data;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Franchisor;
using Falcon.App.Lib;

public partial class App_CallCenter_CallCenterRep_AjaxCallCenterDashBoard : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GetOutBoundCalls();

    }

    #region Get Outbound Calls
    private void GetOutBoundCalls()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        Int64 iCallType = 0;
        if (Request["CallType"] != null && Convert.ToString(Request["CallType"]) != "")
        {
            iCallType = Convert.ToInt64(Request["CallType"]);
        }
        
        FranchisorDAL objDAL = new FranchisorDAL();
        var listNotificationOther = objDAL.GetNotificationOtherPhone(iCallType);

        ENotificationOther[] objENotificationOther = null;

        if (listNotificationOther != null) objENotificationOther = listNotificationOther.ToArray();

        DataTable dtNotification = new DataTable();
        dtNotification.Columns.Add("CustomerID", typeof(Int64));
        dtNotification.Columns.Add("NotificationPhoneID", typeof(Int64));
        dtNotification.Columns.Add("NotificationID", typeof(Int64));
        dtNotification.Columns.Add("UserId", typeof(Int64));
        dtNotification.Columns.Add("CustomerName");
        dtNotification.Columns.Add("NotificationTypeName");
        dtNotification.Columns.Add("PhoneOffice");
        dtNotification.Columns.Add("PhoneCell");
        dtNotification.Columns.Add("PhoneHome");
        dtNotification.Columns.Add("DeadLine");
        dtNotification.Columns.Add("Source");
        dtNotification.Columns.Add("ProspectCustomerId");
        dtNotification.Columns.Add("Tag");
        dtNotification.Columns.Add("SalesRep");
        if (objENotificationOther != null)
        {
            for (int icount = 0; icount < objENotificationOther.Length; icount++)
            {
                dtNotification.Rows.Add(new object[] { objENotificationOther[icount].CustomerID, 
                    objENotificationOther[icount].NotificationPhoneID, 
                    objENotificationOther[icount].NotificationID, 
                    objENotificationOther[icount].UserID, 
                    objENotificationOther[icount].CustomerName, 
                    objENotificationOther[icount].NotificationType, 
                    objCommonCode.FormatPhoneNumberGet(objENotificationOther[icount].PhoneOffice), 
                    objCommonCode.FormatPhoneNumberGet(objENotificationOther[icount].PhoneCell), 
                    objCommonCode.FormatPhoneNumberGet(objENotificationOther[icount].PhoneHome), 
                    objENotificationOther[icount].NotificationDate,
                    objENotificationOther[icount].Source,
                    objENotificationOther[icount].ProspectCustomerId,
                    objENotificationOther[icount].Tag,
                    string.IsNullOrEmpty(objENotificationOther[icount].SalesRep)?"N/A" : objENotificationOther[icount].SalesRep });
            }
        }

        
        if (objENotificationOther.Length > 0)
        {
            grdCustomerList.DataSource = dtNotification.DefaultView;
            grdCustomerList.DataBind();
        }
        else
        {
            //divMessage.Style.Add(HtmlTextWriterStyle.Display,"block");
            dvNoItemFound.Style["display"] = "block";
        }

    }
    #endregion

    //protected void grdCustomerList_Sorting(object sender, GridViewSortEventArgs e)
    //{
    //    //if (e.SortExpression.ToString().Equals("CallType"))
    //    //{
    //    //    ViewState["SortExpression"] = "NotificationTypeName";
    //    //}
    //    //if (ViewState["SortDir"].ToString().Equals("asc"))
    //    //{
    //    //    ViewState["SortDir"] = "desc";
    //    //}
    //    //else
    //    //{
    //    //    ViewState["SortDir"] = "asc";
    //    //}
    //    //GetOutBoundCalls();
    //}

}
