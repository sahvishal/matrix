using System;
using System.Data;

public partial class App_Common_BlockDays : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("Name");
        tbltemp.Columns.Add("Address");

        tbltemp.Rows.Add(new object[] {"Nitin Tikkha", "123 St. Gereveen house , Texas"});
        tbltemp.Rows.Add(new object[] { "Nitin Tikkha", "123 St. Gereveen house , Texas" });
        tbltemp.Rows.Add(new object[] { "Nitin Tikkha", "123 St. Gereveen house , Texas" });

        grdblockdays.DataSource = tbltemp;
        grdblockdays.DataBind();
    }
}
