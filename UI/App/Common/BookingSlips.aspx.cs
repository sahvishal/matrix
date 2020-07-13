using System;
using System.Data;

public partial class App_Common_BookingSlips : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("PaymentType");
        tbltemp.Columns.Add("Dollars");
        tbltemp.Columns.Add("Cents");


        tbltemp.Rows.Add(new object[] { "", "", ""});
        tbltemp.Rows.Add(new object[] { "", "", "" });
        tbltemp.Rows.Add(new object[] { "", "", "" });
        tbltemp.Rows.Add(new object[] { "", "", "" });
        tbltemp.Rows.Add(new object[] { "", "", "" });
        tbltemp.Rows.Add(new object[] { "", "", "" });
        tbltemp.Rows.Add(new object[] { "", "", "" });
        tbltemp.Rows.Add(new object[] { "", "", "" });
        tbltemp.Rows.Add(new object[] { "", "", "" });
        tbltemp.Rows.Add(new object[] { "", "", "" });
        tbltemp.Rows.Add(new object[] { "", "", "" });

        dgbookingslips.DataSource = tbltemp;
        dgbookingslips.DataBind();
    }
}
