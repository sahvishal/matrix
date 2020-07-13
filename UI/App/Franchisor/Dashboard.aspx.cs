using System;

public partial class Franchisor_Dashboard : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Dashboard");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();

        if (!IsPostBack)
        {
            if (Session["LastLoginTime"] != null && Session["LastLoginTime"].ToString().Trim() != "")
            {
                spLastLogin.InnerText = "Last login: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).ToString("MMMM dd, yyyy, hh:mm tt");
            }
            else
            {
                divLastLogin.Visible = false;
            }
        }
    }
}

