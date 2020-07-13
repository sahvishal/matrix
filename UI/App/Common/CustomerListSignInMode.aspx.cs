using System;
using System.Data;

public partial class App_Common_CustomerListSignInMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("Time");
        tbltemp.Columns.Add("CustName");
        tbltemp.Columns.Add("Package");
        tbltemp.Columns.Add("Coupon");
        tbltemp.Columns.Add("Amount");
        tbltemp.Columns.Add("Status");
        tbltemp.Columns.Add("Checkinout");
        tbltemp.Columns.Add("Action");

        tbltemp.Rows.Add(new object[] { "9:00 AM", "", "T", "AUTX51011($20)", "$179.95", "", "", "" });
        tbltemp.Rows.Add(new object[] { "9:00 AM", "", "T", "AUTX51011($20)", "$179.95", "", "", "" });


        dgcustomerlist.DataSource = tbltemp;
        dgcustomerlist.DataBind();
    }
}
