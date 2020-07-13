using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

namespace Falcon.App.UI.App.Common
{
    public partial class AsyncViewEventActivity : System.Web.UI.Page
    {
        public int Eventid { set { eventid = value; } get { return eventid; } }
        int eventid = 0;
        static int ipagesize = 10;
        int ipageindex = 1;
        string strSortOrder = string.Empty;
        string strSortColumn = string.Empty;
        string strType = string.Empty;
        int iTotalRecord = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Request["type"] != null && Request["type"] != "")
                {
                    strType = Request.QueryString["type"];
                    if (Request.QueryString["eventid"] != null)
                    {
                        eventid = Convert.ToInt32(Request.QueryString["eventid"]);
                    }
                    if (Request.QueryString["pagesize"] != null)
                    {
                        ipagesize = Convert.ToInt32(Request.QueryString["pagesize"]);
                    }
                    if (Request.QueryString["pageindex"] != null)
                    {
                        ipageindex = Convert.ToInt32(Request.QueryString["pageindex"]);
                    }
                    if (Request.QueryString["sortorder"] != null)
                    {
                        strSortOrder = Convert.ToString(Request.QueryString["sortorder"]);
                    }
                    if (Request.QueryString["sortcolumn"] != null)
                    {
                        strSortColumn = Convert.ToString(Request.QueryString["sortcolumn"]);
                    }
                    // Activity
                    if (Request["type"].Equals("Activities"))
                    {
                        GetActivity(eventid);
                    }
                }
            }
            catch
            {
                string ErrorMessage = "<div style='float:left; width:746px; border:solid 1px #E7F0F5; padding:10px 0px 10px 0px; display:block;' runat='server'>";
                ErrorMessage = ErrorMessage + "<p class='divnoitemtxt_custdbrd'>" + " <b> Some Error occured, data could not be loaded. </b>" + "</p>";
                Response.Write(ErrorMessage);
            }
            finally
            {
                Response.End();
            }
        }

        #region Method

        private void GetActivity(Int64 iEventId)
        {
            var masterDal = new MasterDAL();
            List<EContactCall> objContactCall = masterDal.GetEventActivity(iEventId, ipageindex, ipagesize, strSortOrder, strSortColumn, out iTotalRecord);
            string DaysToEvent = string.Empty;
            if (objContactCall != null && objContactCall.Count > 0)
            {
                DataTable dtTemp = new DataTable();
                dtTemp.Columns.Add("ID", typeof(Int64));
                dtTemp.Columns.Add("DaysToEvent");
                dtTemp.Columns.Add("Type");
                dtTemp.Columns.Add("Subject");
                dtTemp.Columns.Add("Notes");
                dtTemp.Columns.Add("Date");
                dtTemp.Columns.Add("Status");

                // Bind all records
                foreach (EContactCall objEContactCall in objContactCall)
                {
                    DaysToEvent = objEContactCall.CallResult.ToString();
                    if (DaysToEvent == "0") DaysToEvent = "";
                    if (objEContactCall.CallResult < 0)
                        DaysToEvent = ((-1) * objEContactCall.CallResult).ToString() + " day(s) before event.";
                    else if(objEContactCall.CallResult > 0)
                        DaysToEvent = objEContactCall.CallResult.ToString() + " day(s) after event.";

                    dtTemp.Rows.Add(objEContactCall.ContactCallID, DaysToEvent, objEContactCall.Type, objEContactCall.Subject, objEContactCall.Notes, objEContactCall.StartDate, objEContactCall.CallStatus.Status);
                }

                grdViewEventActivity.DataSource = dtTemp.DefaultView;
                grdViewEventActivity.DataBind();
                WriteResponse(grdViewEventActivity, iTotalRecord);
            }
            else
            {
                string NoRecordFound = "<div style='float:left; width:746px; border:solid 1px #E7F0F5; padding:10px 0px 10px 0px; display:block;' id='dvNoProspectFound' runat='server'>";
                NoRecordFound = NoRecordFound + "<div class='divnoitemfound_custdbrd' style='margin-top:0px;'><p class='divnoitemtxt_custdbrd'><span class='orngbold18_default'>No Records Found</span></p></div></div>";
                Response.Write(NoRecordFound);
            }
        }

        protected void grdViewEventActivity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //
                HtmlContainerControl spnStatus = (HtmlContainerControl)e.Row.FindControl("spnStatus");
                HtmlContainerControl spnMarkComplete = (HtmlContainerControl)e.Row.FindControl("spnMarkComplete");
                if (spnStatus != null)
                {
                    if (spnStatus.InnerHtml.Length > 0)
                    {
                        if (spnStatus.InnerHtml.Trim().Equals("Completed") || spnStatus.InnerHtml.Trim().Equals("Held"))
                        {
                            if (spnMarkComplete != null)
                            {
                                spnMarkComplete.InnerHtml = "<a href=\'#'>Completed</a>";
                            }
                        }
                    }
                }
                //<a href="javascript:ChangeActivityStatus('<%# DataBinder.Eval(Container.DataItem, "Type") %>',<%# DataBinder.Eval(Container.DataItem, "ID") %>);">Mark Complete</a>
                //HtmlAnchor aMarkedComplete = (HtmlAnchor)e.Row.FindControl("aMarkedComplete");
                //strPrepareActionCol += " <span style=\"width:110px; float:left;\">&bull;&nbsp;<a id='" + rowindex + "_MedicalHistory' href=\"/App/Franchisee/Technician/MedicalHistory.aspx?" + drvCurrent["MedicalHistoryURLQuStr"].ToString() + "\">Health Assessment</a><br /></span>";
            }
        }

        /// <summary>
        /// Write response.
        /// </summary>
        /// <param name="grdGrid"></param>
        /// <param name="total"></param>
        private void WriteResponse(GridView grdGrid, int total)
        {
            // Render Html
            string pagingstring = ImplementPaging(ipageindex, ipagesize, total);
            HtmlForm Formnew = this.Page.Form;
            Formnew.Controls.Clear();
            Formnew.Controls.Add(grdGrid);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            HtmlTextWriter htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));

            Formnew.RenderControl(htWriter);

            string strRenderedHTML = sb.ToString();
            
            int startindex = strRenderedHTML.IndexOf("<table");
            int endindex = strRenderedHTML.LastIndexOf("</table>");
            int length = (endindex - startindex) + 8;
            strRenderedHTML = strRenderedHTML.Substring(startindex, length);
            strRenderedHTML = "<div style='float: left; width: 746px'>" + strRenderedHTML + "</div>";
            Response.Write(strRenderedHTML + pagingstring + "<p class=\"blueboxbotbg_cl\"><img src=\"/App/Images/specer.gif\" width=\"746\" height=\"5\" /></p>");
        }
        /// <summary>
        ///  Implement Paging
        /// </summary>
        /// <param name="pagenumber"></param>
        /// <param name="pagesize"></param>
        /// <param name="recordcount"></param>
        /// <returns></returns>
        private string ImplementPaging(long pagenumber, long pagesize, long recordcount)
        {

            if (recordcount <= pagesize) return "";

            // Calculates Total number of pages possible
            long numberofpages = recordcount / pagesize;
            if ((pagesize * numberofpages) != recordcount) numberofpages++;

            long minpagenumtodisplay, maxpagenumtodisplay;

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
                pagingtableHTML += "<td><a href=\"javascript:GetTablePageChange('" + strType + "','" + Convert.ToString(minpagenumtodisplay - 1) + "')\">...</a></td>";
            }

            // Forms the Paging Number HTML .... for the range
            for (long icount = minpagenumtodisplay; icount <= maxpagenumtodisplay; icount++)
            {
                if (pagenumber == icount)
                    pagingtableHTML += "<td style=\" padding:4px; \">" + Convert.ToString(icount) + "</td>";
                else
                    pagingtableHTML += "<td style=\" padding:4px;\"><a href=\"javascript:GetTablePageChange('" + strType + "','" + Convert.ToString(icount) + "')\">" + Convert.ToString(icount) + "</a></td>";
            }

            if (numberofpages > 10 && maxpagenumtodisplay < numberofpages) // Applied if number of pages are greater than 10 and there are still more pages to come.
            {
                pagingtableHTML += "<td><a href=\"javascript:GetTablePageChange('" + "'" + strType + "','" + Convert.ToString(maxpagenumtodisplay + 1) + "')\">...</a></td>";
            }

            pagingtableHTML += " </tr></table>";
            return pagingtableHTML;
        }
        #endregion
    }
}
