using System;
using System.Data;

public partial class App_Common_ViewNotifications : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("Date");
        tbltemp.Columns.Add("Subject");
        tbltemp.Columns.Add("PeopleNotified");
        tbltemp.Columns.Add("Read");
        tbltemp.Columns.Add("Unread");
        tbltemp.Columns.Add("Failure");

        tbltemp.Rows.Add(new object[] { "06/03/2008", "Report Status to be modified", "55", "", "", "" });
       

        dgnotifications.DataSource = tbltemp;
        dgnotifications.DataBind();
    }
}
