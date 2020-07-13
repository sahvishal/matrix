using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.Entity.User;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;

public partial class App_Common_BlockSlot : System.Web.UI.Page
{

    #region "Form Events"

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtReason.Focus();
            if (Request.QueryString["AppointmentID"] != null) ViewState["AppointmentID"] = Request.QueryString["AppointmentID"];
        }
    }
    
    /// <summary>
    /// Blocks the slot for the purposes other than Customer Registration
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnBlockSlot_Click(object sender, ImageClickEventArgs e)
    {
        var objeventappointment = new EEventAppointment
                                      {
                                          AppointmentID = Convert.ToInt32(ViewState["AppointmentID"]),
                                          EventID = Convert.ToInt32(Session["EventID"]),
                                          Reason = txtReason.Text,
                                          Subject = "Blocked",
                                          ScheduleByID = Convert.ToInt32(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                                      };

        var masterDal = new MasterDAL();

        if (masterDal.UpdateAppointmentSlot(objeventappointment, Convert.ToInt16(EOperationMode.Update) ) != -1)
            Page.ClientScript.RegisterStartupScript(typeof(string), "js_blockappt", " parent.ClosePopUp();", true);
    }

    #endregion

}
