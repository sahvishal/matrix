using System;
using System.Web.UI;
using Falcon.App.UI.Extentions;

public partial class App_MedicalVendor_CustomerMedicalHistory : System.Web.UI.Page
{
    protected long CustomerId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Health Assessment";

        if (!IsPostBack)
        {
            CustomerId = Convert.ToInt64(Request.QueryString["CustomerID"]);
        }
    }


    protected void ibtnsave_Click(object sender, EventArgs e)
    {
        Response.RedirectUser("MVUserDashBoard.aspx?PageView=PastEvaluation");
    }

    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser("MVUserDashBoard.aspx?PageView=PastEvaluation");
    }

}
