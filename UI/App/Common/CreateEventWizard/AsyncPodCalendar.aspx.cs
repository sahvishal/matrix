using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Falcon.DataAccess.Master;


namespace HealthYes.Web.App.Common.CreateEventWizard
{
    public partial class AsyncPodCalendar : System.Web.UI.Page
    {
        int currentMonth = 0;
        int currentYear = 0;
        string startDate = "";
        string endDate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PodID"] != null && Request.QueryString["Month"] != null && Request.QueryString["Year"] != null)
            {
                currentMonth = Convert.ToInt32(Request.QueryString["Month"]);
                currentYear = Convert.ToInt32(Request.QueryString["Year"]);
                SetDate(currentMonth, currentYear);
                var masterDal = new MasterDAL();
                DataSet ds = masterDal.GetPodCalendarDetailsByPodID(Convert.ToInt32(Request.QueryString["PodID"]), startDate, endDate);
                
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dtPodEventDetail = new DataTable();
                    dtPodEventDetail.Columns.Add("EventID");
                    dtPodEventDetail.Columns.Add("EventDate");
                    dtPodEventDetail.Columns.Add("EventName");
                    dtPodEventDetail.Columns.Add("JtipInfo");

                    for (int count = 0; count < ds.Tables[0].Rows.Count; count++)
                    {
                        string jtipInfoString = "Event Details |" + "<b>" + ds.Tables[0].Rows[count]["EventName"].ToString() + "</b>|";
                        jtipInfoString = jtipInfoString + Falcon.App.Lib.CommonCode.AddressMultiLine(ds.Tables[0].Rows[count]["Address1"].ToString(), ds.Tables[0].Rows[count]["Address2"].ToString(), ds.Tables[0].Rows[count]["City"].ToString(), ds.Tables[0].Rows[count]["State"].ToString(), ds.Tables[0].Rows[count]["ZipCode"].ToString());
                        jtipInfoString = jtipInfoString.Replace("<br>", "|");
                        
                        dtPodEventDetail.Rows.Add(new object[] { ds.Tables[0].Rows[count]["EventID"].ToString()
                                                                ,Convert.ToDateTime(ds.Tables[0].Rows[count]["EventDate"].ToString()).ToString("MM/dd/yyyy")
                                                                ,ds.Tables[0].Rows[count]["EventName"].ToString(),jtipInfoString
                                                                });
                    }

                    dcEvents.DataSource = dtPodEventDetail;
                    dcEvents.VisibleDate = Convert.ToDateTime(startDate);
                }

            }
            RenderCalendarDetail();
            Response.End();
        }

        private void SetDate(int currentMonth,int currentYear)
        {
            
            if (currentMonth == 1 || currentMonth == 3 || currentMonth == 5 || currentMonth == 7 || currentMonth == 8 || currentMonth == 10 || currentMonth == 12)
            {
                if (currentMonth < 10)
                {
                    startDate = "0" + currentMonth.ToString() + "/01/" + currentYear.ToString();
                    endDate = "0" + currentMonth.ToString() + "/31/" + currentYear.ToString();
                }
                else
                {
                    startDate = currentMonth.ToString() + "/01/" + currentYear.ToString();
                    endDate = currentMonth.ToString() + "/31/" + currentYear.ToString();
                }
            }
            else if (currentMonth == 4 || currentMonth == 6 || currentMonth == 9 || currentMonth == 11)
            {
                if (currentMonth < 10)
                {
                    startDate = "0" + currentMonth.ToString() + "/01/" + currentYear.ToString();
                    endDate = "0" + currentMonth.ToString() + "/30/" + currentYear.ToString();
                }
                else
                {
                    startDate = currentMonth.ToString() + "/01/" + currentYear.ToString();
                    endDate = currentMonth.ToString() + "/30/" + currentYear.ToString();
                }
            }
            else if (currentMonth == 2)
            {
                startDate = currentMonth.ToString() + "/01/" + currentYear.ToString();
                endDate = currentMonth.ToString() + "/28/" + currentYear.ToString();
            }
        }

        private void RenderCalendarDetail()
        {
            HtmlForm newForm = this.form1;
            newForm.Controls.Clear();
            newForm.Controls.Add(divPodCalendar);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            HtmlTextWriter htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));


            newForm.RenderControl(htWriter);

            string strRenderedHTML = sb.ToString();
            strRenderedHTML = strRenderedHTML.Substring(strRenderedHTML.IndexOf("<div id=\"divPodCalendar\""), strRenderedHTML.LastIndexOf("</div") - strRenderedHTML.IndexOf("<div id=\"divPodCalendar\"") + 6);
            Response.Write(strRenderedHTML);
        }

        
    }
}
