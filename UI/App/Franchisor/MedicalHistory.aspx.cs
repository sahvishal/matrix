using System;
using System.Web.UI;

public partial class App_Franchisor_MedicalHistory : Page
{
    protected long CustomerId { get; set; }
    protected long EventId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Health Assessment Form";
        
        if (Request.QueryString["CustomerID"] != null)
        {
            CustomerId = Convert.ToInt64(Request.QueryString["CustomerID"]);
        }

        if (Request.QueryString["EventId"] != null)
        {
            EventId = Convert.ToInt64(Request.QueryString["EventId"]);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["OpenJQueryDialog"]))
            ClientScript.RegisterStartupScript(typeof(string), "jscode_MedHistoryClose", "parent.ClosePopUp();", true);
        else
            ClientScript.RegisterStartupScript(typeof(string), "jscode_MedHistoryClose", "window.close(); parent.parent.GB_hide();", true);
    }

}
