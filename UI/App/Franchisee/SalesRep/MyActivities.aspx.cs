using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.DependencyResolution;
using System.Data;
using Falcon.DataAccess.Franchisee;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace HealthYes.Web.App.Franchisee.SalesRep
{
    public partial class MyActivities : Page
    {
        private readonly FranchiseeDAL franchiseeDal = new FranchiseeDAL();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            Franchisor_FranchisorMaster obj;
            obj = (Franchisor_FranchisorMaster)this.Master;

            Page.Title = "My Activities";
            obj.settitle("My Activities");

            obj.hideucsearch();
            obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/SalesRep/Dashboard.aspx\">Dashboard</a>";
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Tab"]))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscodestart", "LoadActivityTable('" + Request.QueryString["Tab"] + "');",
                                                       true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscodestart", "LoadActivityTable('All');",
                                                       true);
                }
                LoadTodayActivity();
            }
            txtStartDate.Attributes.Add("ReadOnly", "ReadOnly");
            txtEndDate.Attributes.Add("ReadOnly", "ReadOnly");
        }

        private void LoadTodayActivity()
        {
            long totalrecords = 0;
            var todayActivity = franchiseeDal.GetSalesRepMyActivityInfo(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId, 0, 0, "", "", "", 0, "", false, 0, out totalrecords, 2);

            DataTable dtactivities = new DataTable();
            dtactivities.Columns.Add("ActivityID");
            dtactivities.Columns.Add("ContactID");
            dtactivities.Columns.Add("ProspectID");
            dtactivities.Columns.Add("ProspectContactID");
            dtactivities.Columns.Add("Prospect");
            dtactivities.Columns.Add("Contact");
            dtactivities.Columns.Add("Subject");
            dtactivities.Columns.Add("ActivityTime");
            dtactivities.Columns.Add("ActivityType");
            dtactivities.Columns.Add("ActivityTypeImage");
            dtactivities.Columns.Add("ActivityTimeImage");
            dtactivities.Columns.Add("ProspectHostEventLink");
            dtactivities.Columns.Add("ActivityLink");
            dtactivities.Columns.Add("IsHost", typeof(Boolean));
            dtactivities.Columns.Add("EventId", typeof(Int64));
            dtactivities.Columns.Add("EventName");
            dtactivities.Columns.Add("ActivityText");
            dtactivities.Columns.Add("ContactWith");
            dtactivities.Columns.Add("EventStatus");
            dtactivities.Columns.Add("DeleteActivityLink");
            dtactivities.Columns.Add("ActivityStatus", typeof(bool));
            // added event status

            if (todayActivity != null)
            {
                for (int icount = 0; icount < todayActivity.Count; icount++)
                {
                    string timeimage = "";
                    string activitytime = "";
                    string activitytext = "";
                    string withtext = string.Empty;
                    string strEventStatus = string.Empty;

                    string editlink = "javascript:alert('Link not available');";

                    if (todayActivity[icount].EventId > 0)
                    {
                        editlink = "/App/Common/EventDetails.aspx?Tab=Activities&EventID=" + todayActivity[icount].EventId.ToString();
                        activitytext = "Event";
                    }
                    else if (todayActivity[icount].IsHost)
                    {
                        editlink = "/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Host&MyActivity=True&ProspectID=" + todayActivity[icount].ProspectID;
                        activitytext = "Host";
                    }
                    else
                    {
                        editlink = "/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Prospect&MyActivity=True&ProspectID=" + todayActivity[icount].ProspectID;
                        activitytext = "Prospect";
                    }

                    string activitylink = "javascript:alert('Link not available');";
                    string deletelink = "javascript:alert('Link not available');";

                    if (todayActivity[icount].ActivityTime != null && todayActivity[icount].ActivityTime.Trim().Length > 0)
                    {
                        if (Convert.ToDateTime(todayActivity[icount].ActivityTime).ToString("MM/dd/yyyy").Equals(todayActivity[icount].ActivityTime.Trim()))
                        {
                            activitytime = Convert.ToDateTime(todayActivity[icount].ActivityTime).ToString("MMMM dd, yyyy");
                            todayActivity[icount].ActivityTime = Convert.ToDateTime(todayActivity[icount].ActivityTime).ToString("MM/dd/yyyy") + " 11:30 PM";
                        }

                        else
                            activitytime = Convert.ToDateTime(todayActivity[icount].ActivityTime).ToString("MMMM dd, yyyy @ hh:mm tt");

                        if (DateTime.Now.Date == Convert.ToDateTime(todayActivity[icount].ActivityTime).Date)
                        {
                            if (DateTime.Now.TimeOfDay.CompareTo(Convert.ToDateTime(todayActivity[icount].ActivityTime).TimeOfDay) == 1)
                                timeimage = "<img src='/App/Images/red-flag.gif' alt='' title = 'Past Activity' />";
                            else
                                timeimage = "<img src='/App/Images/orng-flag.gif' alt='' title = \"Today's Activity\" />";
                        }
                        else if (DateTime.Now < Convert.ToDateTime(todayActivity[icount].ActivityTime).Date)
                            timeimage = "<img src='/App/Images/green-flag.gif' alt='' title = 'Future Activity' />";
                        else
                            timeimage = "<img src='/App/Images/red-flag.gif' alt='' title = 'Past Activity' />";
                    }

                    string typeimage = "<img src='/App/Images/red-box-ma.gif' alt='' />";

                    if (todayActivity[icount].ActivityType == "Task") { activitylink = "/App/Franchisor/AddTask.aspx?TaskID=" + todayActivity[icount].ActivityID + "&Parent=Activity"; typeimage = "<img src='/App/Images/icon-task.gif' alt='Task' title='Task' />"; }
                    if (todayActivity[icount].ActivityType == "Call") { activitylink = "/App/Franchisor/AddCallProspect.aspx?ContactCallID=" + todayActivity[icount].ActivityID + "&Parent=Activity"; typeimage = "<img src='/App/Images/icon-call.gif' alt='Call' title='Call' />"; }
                    if (todayActivity[icount].ActivityType == "Meeting") { activitylink = "/App/Franchisor/AddMeeting.aspx?ContactMeetingID=" + todayActivity[icount].ActivityID + "&Parent=Activity"; typeimage = "<img src='/App/Images/icon-meeting.gif' alt='Meeting' title='Meeting' />"; }

                    deletelink = "javascript:DeleteActivity('" + todayActivity[icount].ActivityType + "'," +
                                 todayActivity[icount].ActivityID + ",'" + todayActivity[icount].ActivityMarkedStatus + "');";

                    if (todayActivity[icount].EventId > 0)
                    {
                        todayActivity[icount].Prospect = todayActivity[icount].EventName;
                        strEventStatus = "<br>Event Status:" + Convert.ToString(Enum.Parse(typeof(EventStatus), todayActivity[icount].EventStatus.ToString()));
                    }
                    if (todayActivity[icount].ContactID > 0)
                    {
                        withtext = "With";
                    }


                    dtactivities.Rows.Add(new object[]
                                          {
                                              todayActivity[icount].ActivityID,
                                              todayActivity[icount].ContactID,
                                              todayActivity[icount].ProspectID,
                                              todayActivity[icount].ProspectContactID,
                                              todayActivity[icount].Prospect,
                                              todayActivity[icount].ContactName,
                                              todayActivity[icount].Subject, activitytime,
                                              todayActivity[icount].ActivityType, typeimage, timeimage,
                                              editlink, activitylink, todayActivity[icount].IsHost,
                                              todayActivity[icount].EventId,
                                              todayActivity[icount].EventName, activitytext, withtext,
                                              strEventStatus, deletelink,todayActivity[icount].ActivityMarkedStatus
                                          });

                }
            }
            if (todayActivity != null && todayActivity.Count > 0)
            {
                if (todayActivity.Count > 10)
                {
                    todayActivityDiv.Style.Add(HtmlTextWriterStyle.OverflowY, "auto");
                    todayActivityDiv.Style.Add(HtmlTextWriterStyle.OverflowX, "hidden");
                    todayActivityDiv.Style.Add(HtmlTextWriterStyle.Height, "300px");
                }
                todayactivities.DataSource = dtactivities;
                todayactivities.DataBind();
                _noRecordFoundTodayActivity.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else
            {
                todayActivityMessage.ShowErrorMessage("No activity scheduled for today.");
                _noRecordFoundTodayActivity.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
        }

        protected void todayactivities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var activityStatus = e.Row.FindControl("ActivityStatus") as HtmlContainerControl;
                var markedUnmarked = e.Row.FindControl("markedUnmarked") as HtmlImage;
                if (activityStatus != null)
                {
                    if (activityStatus.InnerHtml.Trim().ToLower() == "true")
                    {
                        if (markedUnmarked != null)
                        {
                            markedUnmarked.Src = @"/App/Images/icon_check.png";
                        }
                        e.Row.CssClass = "strikethru";
                    }
                    else e.Row.CssClass = "rostyle";
                }
            }
        }

    }
}
