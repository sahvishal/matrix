using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

public partial class App_Customer_CustomerDashboardLatest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //DataTable dttemp = new DataTable();
        //dttemp.Columns.Add("col1");

        //dttemp.Rows.Add(new object[] { "AAA (more info)" });
        //dttemp.Rows.Add(new object[] { "Carted Artery (more info)" });
        //dttemp.Rows.Add(new object[] { "Osteoporosis (more info)" });
        //dttemp.Rows.Add(new object[] { "ASI (more info)" });


        //dghealthsummery.DataSource = dttemp;
        //dghealthsummery.DataBind();


        //DataTable tbltemp = new DataTable();
        //tbltemp.Columns.Add("EventName");
        //tbltemp.Columns.Add("Date");
        //tbltemp.Columns.Add("Zip");
        ////country.Columns.Add("City");

        //tbltemp.Rows.Add(new object[] { "Cardio care at abc church", "19-12-2007", "68598" });
        //tbltemp.Rows.Add(new object[] { "Event 2", "19-12-2007", "68598" });
        //tbltemp.Rows.Add(new object[] { "Event 3", "22-12-2007", "68598" });

        //gridupcomingevents_cdb.DataSource = tbltemp;
        //gridupcomingevents_cdb.DataBind();
    }
    protected void ibtnGo_Click(object sender, ImageClickEventArgs e)
    {
        var masterDal = new MasterDAL();
        //TODO:(Sandeep) Page Out of Use. Need Check with Bidhan 
        List<EEvent> eevent = null; // txtSearchevent.Text.Length > 0 ? masterDal.SearchEventDetails(0, txtSearchevent.Text, "", "", "", "", "", 3) : masterDal.SearchEventDetails(0, string.Empty, "", "", "", "", "", 3);
     
        DataTable dtEvent = new DataTable();
        dtEvent.Columns.Add("EventID");
        dtEvent.Columns.Add("EventName");
        dtEvent.Columns.Add("Date");
        dtEvent.Columns.Add("Zip");
        if (eevent.Count > 0)
        {
            for (int icount = 0; icount < eevent.Count; icount++)
            {

                dtEvent.Rows.Add(new object[] { eevent[icount].EventID, eevent[icount].Name, eevent[icount].EventDate, eevent[0].Host.Address.ZipID.ToString() });
                
            }
            grdEventDetails.DataSource = dtEvent;
            grdEventDetails.DataBind();
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('no records found');", true);
            

            

        }

    }
   
}
