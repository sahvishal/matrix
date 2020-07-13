using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.DataAccess.Franchisee;
using Falcon.Entity.Franchisee;

namespace HealthYes.Web.App.Franchisee.SalesRep
{
    public partial class Async_MyActivities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Int16 pagenumber = 1;
                Int16 pagesize = 10;
                Int64 salesrepid = 0;

                Int16 viewmode = 0;
                Int16 relatedmode = 0;

                string relatedkeyword = "";
                string keyword = "";
                string datefrom, dateto;
                datefrom = ""; dateto = "";

                if (Request.QueryString["PageNumber"] != null) pagenumber = Convert.ToInt16(Request.QueryString["PageNumber"]);
                if (Request.QueryString["PageSize"] != null) pagesize = Convert.ToInt16(Request.QueryString["PageSize"]);
                if (Request.QueryString["SalesRepID"] != null) salesrepid = Convert.ToInt64(Request.QueryString["SalesRepID"]);

                if (Request.QueryString["DateFrom"] != null) datefrom = Request.QueryString["DateFrom"];
                if (Request.QueryString["DateTo"] != null) dateto = Request.QueryString["DateTo"];

                if (Request.QueryString["ViewMode"] != null)
                {
                    if (Request.QueryString["ViewMode"].ToUpper() == "ALL") viewmode = 0;
                    else if (Request.QueryString["ViewMode"].ToUpper() == "PROSPECT") viewmode = 1;
                    else if (Request.QueryString["ViewMode"].ToUpper() == "HOST") viewmode = 2;
                    else if (Request.QueryString["ViewMode"].ToUpper() == "EVENT") viewmode = 3;
                }
                if (Request.QueryString["RelatedMode"] != null)
                {
                    if (Request.QueryString["RelatedMode"].ToUpper() == "PROSPECT") relatedmode = 1;
                    else if (Request.QueryString["RelatedMode"].ToUpper() == "HOST") relatedmode = 2;
                    else if (Request.QueryString["RelatedMode"].ToUpper() == "CONTACT") relatedmode = 3;
                    else if (Request.QueryString["RelatedMode"].ToUpper() == "EVENT") relatedmode = 4;
                }
                if (Request.QueryString["RelatedKeyword"] != null)
                    relatedkeyword = Request.QueryString["RelatedKeyword"];
                

                if (Request.QueryString["Keyword"] != null)
                {
                    keyword = Request.QueryString["Keyword"];
                }

                //FranchiseeService objservice = new HealthYes.Web.UI.FranchiseeService.FranchiseeService();
                FranchiseeDAL franchiseeDAL = new FranchiseeDAL();
                List<ESalesRepMyActivity> arrsalesrepmyactivity = null;

                long totalrecords;

                if (Request.QueryString["SearchMode"] != null)
                {
                    arrsalesrepmyactivity = franchiseeDAL.GetSalesRepMyActivityInfo(salesrepid, pagenumber, pagesize, datefrom, dateto, relatedkeyword, relatedmode, keyword, true, viewmode, out totalrecords,1);
                }
                else
                {
                    arrsalesrepmyactivity = franchiseeDAL.GetSalesRepMyActivityInfo(salesrepid, pagenumber, pagesize, "", "", "", 0, "", false, viewmode, out totalrecords,1);
                }

                if (arrsalesrepmyactivity != null)
                {
                    FillGridforMyActivity(arrsalesrepmyactivity);
                    string pagingstring = ImplementPaging(pagenumber, pagesize, totalrecords);

                    HtmlForm Formnew = this.Page.Form;
                    Formnew.Controls.Clear();
                    Formnew.Controls.Add(grdMyActivities);

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    HtmlTextWriter htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));

                    Formnew.RenderControl(htWriter);

                    string strRenderedHTML = sb.ToString();
                    int startindex = strRenderedHTML.IndexOf("<table");
                    int endindex = strRenderedHTML.IndexOf("</table>");
                    int length = (endindex - startindex) + 8;
                    strRenderedHTML = strRenderedHTML.Substring(startindex, length);

                    strRenderedHTML = "<div style='float: left; width: 746px'>" + strRenderedHTML + "</div>";

                    Response.Write(strRenderedHTML + pagingstring + "<p class=\"blueboxbotbg_cl\"><img src=\"/App/Images/specer.gif\" width=\"746\" height=\"5\" /></p>");
                }
                else Response.Write("<div id=\"divNoRecords\" style=\"float: left; width: 714px; display: block; padding: 10px 10px 10px 20px; border: solid 1px #DFEEF5;\"><div class=\"divnoitemfound1_custdbrd\"><p class=\"divnoitemtxt_custdbrd\"><span class=\"orngbold18_default\">No Record Found</span></p></div></div>");
                //else
                //{
                //    HtmlForm Formnew = this.Page.Form;
                //    Formnew.Controls.Clear();

                //    activityMessage.ShowErrorMessage("No Records Found.");
                //    activityDiv.Style.Add(HtmlTextWriterStyle.Display, "block");

                //    Formnew = this.Page.Form;
                //    Formnew.Controls.Clear();
                //    Formnew.Controls.Add(activityDiv);

                //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //    HtmlTextWriter htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));
                //    Formnew.RenderControl(htWriter);

                //    string strRenderedHTML = sb.ToString();
                //    int startindex = strRenderedHTML.IndexOf("<div id=\"activityDiv\"");
                //    int endindex = strRenderedHTML.IndexOf("</div>");
                //    int length = (endindex - startindex) + 6;
                //    strRenderedHTML = strRenderedHTML.Substring(startindex, length);

                //    Response.Write(strRenderedHTML);
                //}
            
            }
            catch (Exception ex)
            {
                //Response.Write("<span style='float:left; padding:5px; font-size:14px'> <b> Some Error occured, data could not be loaded. </b> </span>");
                Response.Write("<span style='float:left; padding:5px; font-size:14px'> <b> " + ex.Message + "</b> </span>");
                
            }
            finally
            {
                Response.End();
            }
        }

        private void FillGridforMyActivity(List<ESalesRepMyActivity> arrsalesrepmyactivity)
        {
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
            dtactivities.Columns.Add("ActivityStatus",typeof(bool));
            // added event status
            

            for (int icount = 0; icount < arrsalesrepmyactivity.Count; icount++)
            {
                string timeimage = "";
                string activitytime = "";
                string activitytext = "";
                string withtext = string.Empty;
                string strEventStatus = string.Empty;

                string editlink = "javascript:alert('Link not available');";
               


                if (arrsalesrepmyactivity[icount].EventId > 0)
                {
                    editlink = "/App/Common/EventDetails.aspx?Tab=Activities&EventID=" + arrsalesrepmyactivity[icount].EventId.ToString();
                    activitytext = "Event";
                }
                else if (arrsalesrepmyactivity[icount].IsHost)
                {
                    editlink = "/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Host&MyActivity=True&ProspectID=" + arrsalesrepmyactivity[icount].ProspectID;
                    activitytext = "Host";
                }
                else
                {
                    editlink = "/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Prospect&MyActivity=True&ProspectID=" + arrsalesrepmyactivity[icount].ProspectID;
                    activitytext = "Prospect";
                }
                

                string activitylink = "javascript:alert('Link not available');";
                string deletelink = "javascript:alert('Link not available');";

                if (arrsalesrepmyactivity[icount].ActivityTime != null && arrsalesrepmyactivity[icount].ActivityTime.Trim().Length > 0)
                {
                    if (Convert.ToDateTime(arrsalesrepmyactivity[icount].ActivityTime).ToString("MM/dd/yyyy").Equals(arrsalesrepmyactivity[icount].ActivityTime.Trim()))
                        {
                            activitytime = Convert.ToDateTime(arrsalesrepmyactivity[icount].ActivityTime).ToString("MMMM dd, yyyy");
                            arrsalesrepmyactivity[icount].ActivityTime = Convert.ToDateTime(arrsalesrepmyactivity[icount].ActivityTime).ToString("MM/dd/yyyy") + " 11:30 PM";
                        }
                   
                    else
                        activitytime = Convert.ToDateTime(arrsalesrepmyactivity[icount].ActivityTime).ToString("MMMM dd, yyyy <br /> @ hh:mm tt");

                    if (DateTime.Now.Date == Convert.ToDateTime(arrsalesrepmyactivity[icount].ActivityTime).Date)
                    {
                        if (DateTime.Now.TimeOfDay.CompareTo(Convert.ToDateTime(arrsalesrepmyactivity[icount].ActivityTime).TimeOfDay) == 1)
                            timeimage = "<img src='/App/Images/red-flag.gif' alt='' title = 'Past Activity' />";
                        else
                            timeimage = "<img src='/App/Images/orng-flag.gif' alt='' title = \"Today's Activity\" />";
                    }
                    else if (DateTime.Now < Convert.ToDateTime(arrsalesrepmyactivity[icount].ActivityTime).Date)
                        timeimage = "<img src='/App/Images/green-flag.gif' alt='' title = 'Future Activity' />";
                    else
                        timeimage = "<img src='/App/Images/red-flag.gif' alt='' title = 'Past Activity' />";
                }

                
                string typeimage = "<img src='/App/Images/red-box-ma.gif' alt='' />";

                if (arrsalesrepmyactivity[icount].ActivityType == "Task") { activitylink = "/App/Franchisor/AddTask.aspx?TaskID=" + arrsalesrepmyactivity[icount].ActivityID + "&Parent=Activity"; typeimage = "<img src='/App/Images/icon-task.gif' alt='Task' title='Task' />"; }
                if (arrsalesrepmyactivity[icount].ActivityType == "Call") { activitylink = "/App/Franchisor/AddCallProspect.aspx?ContactCallID=" + arrsalesrepmyactivity[icount].ActivityID + "&Parent=Activity"; typeimage = "<img src='/App/Images/icon-call.gif' alt='Call' title='Call' />"; }
                if (arrsalesrepmyactivity[icount].ActivityType == "Meeting") { activitylink = "/App/Franchisor/AddMeeting.aspx?ContactMeetingID=" + arrsalesrepmyactivity[icount].ActivityID + "&Parent=Activity"; typeimage = "<img src='/App/Images/icon-meeting.gif' alt='Meeting' title='Meeting' />"; }

                deletelink = "javascript:DeleteActivity('" + arrsalesrepmyactivity[icount].ActivityType + "'," +
                             arrsalesrepmyactivity[icount].ActivityID + ",'" + arrsalesrepmyactivity[icount].ActivityMarkedStatus + "');";

                if (arrsalesrepmyactivity[icount].EventId > 0)
                {
                    arrsalesrepmyactivity[icount].Prospect = arrsalesrepmyactivity[icount].EventName;
                    strEventStatus = "<br>Event Status:" + Convert.ToString(Enum.Parse(typeof(EventStatus), arrsalesrepmyactivity[icount].EventStatus.ToString()));
                }
                if (arrsalesrepmyactivity[icount].ContactID > 0)
                {
                    withtext = "With";
                }


                dtactivities.Rows.Add(new object[]
                                          {
                                              arrsalesrepmyactivity[icount].ActivityID,
                                              arrsalesrepmyactivity[icount].ContactID,
                                              arrsalesrepmyactivity[icount].ProspectID,
                                              arrsalesrepmyactivity[icount].ProspectContactID,
                                              arrsalesrepmyactivity[icount].Prospect,
                                              arrsalesrepmyactivity[icount].ContactName,
                                              arrsalesrepmyactivity[icount].Subject, activitytime,
                                              arrsalesrepmyactivity[icount].ActivityType, typeimage, timeimage,
                                              editlink, activitylink, arrsalesrepmyactivity[icount].IsHost,
                                              arrsalesrepmyactivity[icount].EventId,
                                              arrsalesrepmyactivity[icount].EventName, activitytext, withtext,
                                              strEventStatus, deletelink,arrsalesrepmyactivity[icount].ActivityMarkedStatus
                                          });

            }

            grdMyActivities.DataSource = dtactivities;
            grdMyActivities.DataBind();
        }

        protected void grdMyActivities_RowDataBound(object sender, GridViewRowEventArgs e)
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
                            markedUnmarked.Alt = "Mark Activity";
                        }
                        e.Row.CssClass = "strikethru";
                    }
                }
            }
        }
        private string ImplementPaging(Int16 pagenumber, Int16 pagesize, long recordcount)
        {
            if (recordcount <= pagesize) return "";

            // Calculates Total number of pages possible
            int numberofpages = Convert.ToInt32(recordcount / pagesize);
            if ((pagesize * numberofpages) != recordcount) numberofpages++;

            int minpagenumtodisplay, maxpagenumtodisplay;

            //Calculates first and last page number to display in paging tab, so as to decide whole range
            minpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 1) : ((((pagenumber / 10) - 1) * 10) + 1);
            maxpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 10) : ((pagenumber / 10) * 10);

            if (maxpagenumtodisplay > numberofpages)
            {
                if ((maxpagenumtodisplay - numberofpages) < minpagenumtodisplay) minpagenumtodisplay = minpagenumtodisplay - (maxpagenumtodisplay - numberofpages);
                maxpagenumtodisplay = numberofpages;
            }

            // Forms the paging tab string
            string pagingtableHTML = "<table  style=\"border:none; float:left; \"><tr> ";

            if (recordcount > 10 && minpagenumtodisplay > 1) // Applied if number of pages are greater than 10 and number of records are more than page size
            {
                pagingtableHTML += "<td><a href=\"javascript:LoadActivityTableonPageChange('" + Convert.ToString(minpagenumtodisplay - 1) + "')\">...</a></td>";
            }

            // Forms the Paging Number HTML .... for the range
            for (int icount = minpagenumtodisplay; icount <= maxpagenumtodisplay; icount++)
            {
                if (pagenumber == icount)
                    pagingtableHTML += "<td style=\" padding:4px; \">" + Convert.ToString(icount) + "</td>";
                else
                    pagingtableHTML += "<td style=\" padding:4px;\"><a href=\"javascript:LoadActivityTableonPageChange('" + Convert.ToString(icount) + "')\">" + Convert.ToString(icount) + "</a></td>";
            }

            if (numberofpages > 10 && maxpagenumtodisplay < numberofpages) // Applied if number of pages are greater than 10 and there are still more pages to come.
            {
                pagingtableHTML += "<td><a href=\"javascript:LoadActivityTableonPageChange('" + Convert.ToString(maxpagenumtodisplay + 1) + "')\">...</a></td>";
            }

            pagingtableHTML += " </tr></table>";
            pagingtableHTML = "<div style='float: left; width: 730px;'> " + pagingtableHTML + " </div>";
            return pagingtableHTML;
        }


    }
}
