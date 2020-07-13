using System;

public partial class App_Customer_ChangeAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Reschedule Appointment";
        Customer_CustomerMaster obj;
        obj = (Customer_CustomerMaster)this.Master;
       // obj.SetTitle("Reschedule Appointment");
       // obj.HideUcSearch();
        obj.SetBreadcrumb = "DashBoard";
        obj.SetPageView("DashBoard");
        obj.SetBreadcrumb = "<a href=\"/App/Customer/HomePage.aspx\" >Home</a>";

        if (!IsPostBack)
        {
            if (Session["LastLoginTime"] != null && Session["LastLoginTime"].ToString().Trim() != "")
            {
                spLastLogin.InnerHtml = "Last login: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).ToString("MMMM dd, yyyy, hh:mm tt");
            }
            else
            {
                divLastLogin.Visible = false;
            }
        }
    }
    public void SetName(object sender, EventArgs e)
    {
       // spFullName.InnerHtml = uc1.CustName;

    }
}
