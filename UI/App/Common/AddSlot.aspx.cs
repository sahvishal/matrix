using System;
using System.Web.UI;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.Entity.User;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;

public partial class App_Common_AddSlot : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtstarttime.Focus();
            if (Request.QueryString["EventDate"] != null) ViewState["EventDate"] = Request.QueryString["EventDate"];
        }
    }

    /// <summary>
    /// Adds a new appointmentslot
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnAddSlot_Click(object sender, ImageClickEventArgs e)
    {
        var masterDal = new MasterDAL();
        var objeventappointment = new EEventAppointment { StartTime = txtstarttime.Text };
        if (txtendtime.Text.Trim().Length < 1)
            objeventappointment.EndTime = Convert.ToDateTime(txtstarttime.Text).AddMinutes(15.00).ToString("hh:mm tt");
        else
            objeventappointment.EndTime = txtendtime.Text;

        objeventappointment.EventID =Convert.ToInt32(Request.QueryString["EventId"]);
        objeventappointment.StartDate = Convert.ToDateTime(ViewState["EventDate"]).ToString();
        objeventappointment.EndDate = Convert.ToDateTime(ViewState["EventDate"]).ToString();
        objeventappointment.ScheduleByID = 0;

        long returnresult = masterDal.UpdateAppointmentSlot(objeventappointment, Convert.ToInt16(EOperationMode.Insert));
        if (returnresult != -1)
        {
            if (returnresult == 0)
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "jscodeaddslot", " alert('Added slot time should fall between the event start and end timing.'); ", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "jscodeaddslot", " parent.ClosePopUp();  ", true);
                //FillData(Convert.ToInt32(ViewState["EventID"]));
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(typeof(string), "jscodeaddslot", " alert('Slot could not be added because of database error.'); ", true);
        }
    }


}
