using System;
using System.Data;

public partial class App_Common_Calendarweekly : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("Time");
        tbltemp.Columns.Add("Day1");
        tbltemp.Columns.Add("Day2");
        tbltemp.Columns.Add("Day3");
        tbltemp.Columns.Add("Day4");
        tbltemp.Columns.Add("Day5");
        tbltemp.Columns.Add("Day6");
        tbltemp.Columns.Add("Day7");

        tbltemp.Rows.Add(new object[] { "", "", "", "", "", "", "", "" });
        


        dgcalendarweekly.DataSource = tbltemp;
        dgcalendarweekly.DataBind();
    }
}
