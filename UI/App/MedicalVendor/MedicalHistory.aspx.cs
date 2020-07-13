using System;

public partial class App_MedicalVendor_MedicalHistory : System.Web.UI.Page
{
    protected long CustomerId { get; set; }
    protected long EventId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Title = "Health Assessment Form";
            
            if(Request.QueryString["CustomerID"]!=null)
            {
                CustomerId = Convert.ToInt64(Request.QueryString["CustomerID"]);
            }

            if (Request.QueryString["EventId"] != null)
            {
                EventId = Convert.ToInt64(Request.QueryString["EventId"]);
            }

            if (Request.UrlReferrer != null)
                ViewState["BackUrlRefferer"] = Request.UrlReferrer.PathAndQuery;
        }
    }    
}
