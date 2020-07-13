using System;
using System.Data;

public partial class App_Franchisee_Technician_SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("AppointmentTime");
        tbltemp.Columns.Add("Serial");
        tbltemp.Columns.Add("CustomerName");
        tbltemp.Columns.Add("PackageTests");
        tbltemp.Columns.Add("PackageCost");
        tbltemp.Columns.Add("Discount");
        tbltemp.Columns.Add("Paymentstatus");
        tbltemp.Columns.Add("CheckinTime");
        tbltemp.Columns.Add("Action");


        tbltemp.Rows.Add(new object[] { "10.00-10:30", "#1", "Karina Wangler", "Total Health", "50$", "20%", "Paid", "Record Time", "Save" });
        tbltemp.Rows.Add(new object[] { "12:00-01:00", "#2", "Paul Wagner", "Total Health", "50$", "20%", "Paid", "Record Time", "Save" });
        tbltemp.Rows.Add(new object[] { "02:00-03:00", "#3", "John Makin", "Total Health", "50$", "20%", "Not Paid<br>(Recieve Payment)", "(Accept Payment First)", "Save" });
        tbltemp.Rows.Add(new object[] { "04:00-05:00", "#4", "Georze Kim", "Total Health", "50$", "20%", "Paid", "Record", "Save" });

        grdPrintRoster.DataSource = tbltemp;
        grdPrintRoster.DataBind();
    }
}
