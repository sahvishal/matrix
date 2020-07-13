using System;
using System.Data;
using System.Web.UI.WebControls;
using Falcon.Entity.Other;

namespace Falcon.App.UI.App.Common.CreateEventWizard
{
    public partial class AsyncEventWizard : System.Web.UI.Page
    {
        
        public bool isLock { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Type"] != null && Request.QueryString["Type"] == "SettingControlsdata")
            {
                if (Session["EventWizard"] != null)
                {
                    var objEventWizard = (EEventWizard)Session["EventWizard"];
                    if (Request.QueryString["Data"] != null)
                    {
                        switch (Request.QueryString["Data"])
                        {
                            case "EventDate":
                                objEventWizard.EventDate = Request.QueryString["Value"];
                                break;
                            case "TeamArrivalTime":
                                objEventWizard.TeamArrivalTime = Request.QueryString["Value"];
                                break;
                            case "TeamDepartureTime":
                                objEventWizard.TeamDepartureTime = Request.QueryString["Value"];
                                break;
                            case "TimeZone":
                                objEventWizard.TimeZone = Request.QueryString["Value"];
                                break;
                            case "ScheduleTemplate":
                                objEventWizard.ScheduleTemplateID = Convert.ToInt32(Request.QueryString["Value"]);
                                break;
                            case "EventType":
                                objEventWizard.EventType = new EEventType();
                                objEventWizard.EventType.EventTypeID = Convert.ToInt32(Request.QueryString["Value"]);
                                break;
                            case "InvitationCode":
                                objEventWizard.InvitationCode = Request.QueryString["Value"];
                                break;
                            case "EventStatus":
                                objEventWizard.EventStatus = Convert.ToInt32(Request.QueryString["Value"]);
                                break;
                            case "EventNotes":
                                objEventWizard.Notes = Request.QueryString["Value"];
                                break;
                            case "EventTaskTemplate":
                                objEventWizard.EventActivityTemplateID = Convert.ToInt32(Request.QueryString["Value"]);
                                break;
                            case "HSCSalesRep":
                                objEventWizard.HSCSalesRepID = Convert.ToInt32(Request.QueryString["Value"]);
                                break;

                        }
                    }
                    Session["EventWizard"] = objEventWizard;
                }
            }
            Response.End();
        }

        protected void gdAdvocates_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Session["TblSearchedAdvocate"] != null)
                {
                    DataTable dtAdvocate = (DataTable)Session["TblSearchedAdvocate"];
                    DataRowView drvCurrent = dtAdvocate.DefaultView[e.Row.DataItemIndex]; // current row from datatable in view state, corresponding to the current grid row.
                    CheckBox chkBxAdovcate = (CheckBox)e.Row.FindControl("chkBxAdovcate");
                    if (Convert.ToBoolean(drvCurrent["Added"]) == true)
                    {
                        chkBxAdovcate.Checked = true;
                    }
                }
            }
        }

        protected void gdAddedAdvocate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var advocateId = Convert.ToInt64(((DataRowView)(e.Row.DataItem)).Row["AffiliateID"]);
                var eventId = Convert.ToInt64(Request.QueryString["EventID"]);
 

            }
        }
    }
}