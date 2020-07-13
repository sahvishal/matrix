using System;
using System.Data;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

public partial class App_Franchisee_SalesRep_TemplateTimeSlots : System.Web.UI.Page
{
    
    /// <summary>
    /// Page Load for time slots pop up.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (Request.Params["__EVENTTARGET"].ToString().Equals("GetValue"))
            {
                var masterDal = new MasterDAL();
                EScheduleTemplate objscheduletemplate = masterDal.GetScheduleTemplateDetails(Convert.ToInt32(Request.Params["__EVENTARGUMENT"]));

                spschedtemplatename.InnerText = objscheduletemplate.Name;

                DataTable dttimeslots = new DataTable();
                dttimeslots.Columns.Add("TimeSlot");
                dttimeslots.Columns.Add("NumberPatient");

                string prevslot = "";
                int timecount = 0;

                if (objscheduletemplate != null && objscheduletemplate.ScheduleTemplateTime != null)
                {
                    for (int icount = 0; icount < objscheduletemplate.ScheduleTemplateTime.Count; icount++)
                    {
                        if (prevslot == objscheduletemplate.ScheduleTemplateTime[icount].StartTime)
                        {
                            timecount = Convert.ToInt32(dttimeslots.Rows[dttimeslots.Rows.Count - 1]["NumberPatient"]);
                            timecount++;
                            dttimeslots.Rows[dttimeslots.Rows.Count - 1]["NumberPatient"] = timecount;
                            continue;
                        }
                        timecount = 0;
                        dttimeslots.Rows.Add(new object[] { objscheduletemplate.ScheduleTemplateTime[icount].StartTime, 1 });
                        prevslot = objscheduletemplate.ScheduleTemplateTime[icount].StartTime;
                    }
                    gvtimeslots.DataSource = dttimeslots;
                    gvtimeslots.DataBind();
                }
            }
        }
    }

}
