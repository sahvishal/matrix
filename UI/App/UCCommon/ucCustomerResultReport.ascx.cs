using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Lib;

public partial class App_UCCommon_ucCustomerResultReport : System.Web.UI.UserControl
{

    #region "Events"
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        errordiv.Style[HtmlTextWriterStyle.Display] = "none";

        if (!IsPostBack)
        {
            ViewState["PageNumber"] = 1;
            ViewState["PageSize"] = 10;
            ViewState["EventID"] = 0;
            ViewState["EventText"] = "";
            ViewState["EventDateFrom"] = "";
            ViewState["EventDateTo"] = "";

            GetCustomerListfromDB();
        }
        else
        {
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"] == "PageNumber")
            {
                ViewState["PageNumber"] = Request.Form["__EVENTARGUMENT"];
                GetCustomerListfromDB();
            }
        }
        txtDateFrom.Attributes.Add("ReadOnly", "ReadOnly");
        txtDateTo.Attributes.Add("ReadOnly", "ReadOnly");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkNoResults_CheckedChanged(object sender, EventArgs e)
    {
        GetCustomerListfromDB();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkParResults_CheckedChanged(object sender, EventArgs e)
    {
        GetCustomerListfromDB();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkNoImages_CheckedChanged(object sender, EventArgs e)
    {
        GetCustomerListfromDB();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        int eventid = 0;
        string eventtext = "";

        if (!Int32.TryParse(txtEvent.Text.Trim(), out eventid))
        {
            if (txtEvent.Text.Trim().Length > 0)
            {

                string eventname = txtEvent.Text.Trim();
                int startpoint = eventname.IndexOf("[ID:");
                int length = (eventname.Length - 1) - (startpoint + 4);
                if (startpoint > 0 )
                {
                    Int32.TryParse(eventname.Substring(startpoint + 4, length), out eventid);
                }
                if (eventid == 0)
                    eventtext = txtEvent.Text;
            }
        }

        ViewState["EventID"] = eventid;
        ViewState["EventText"] = eventtext;
        ViewState["EventDateFrom"] = txtDateFrom.Text;
        ViewState["EventDateTo"] = txtDateTo.Text;

        GetCustomerListfromDB();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnReset_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["PageNumber"] = 1;
        ViewState["EventID"] = 0;
        ViewState["EventText"] = "";
        ViewState["EventDateFrom"] = "";
        ViewState["EventDateTo"] = "";
        txtDateFrom.Text = "";
        txtDateTo.Text = "";
        txtEvent.Text = "";

        GetCustomerListfromDB();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRecords_SelectedIndexChanged(object sender, EventArgs e)
    {
        int curpagenum, newpagenum;
        int curpagesize, newpagesize;

        curpagesize = Convert.ToInt32(ViewState["PageSize"]);
        newpagesize = Convert.ToInt32(ddlRecords.SelectedItem.Value);

        curpagenum = Convert.ToInt32(ViewState["PageNumber"]);

        newpagenum = (((curpagenum - 1) * curpagesize) / newpagesize) + 1;

        ViewState["PageNumber"] = newpagenum;
        ViewState["PageSize"] = ddlRecords.SelectedItem.Text;
        GetCustomerListfromDB();
    }
    
    #endregion


    #region "User Built Functions"

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrevents"></param>
    private void LoadGridCustomers(List<EEvent> arrevents)
    {
        if (arrevents == null)
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Style[HtmlTextWriterStyle.Display] = "block";
            divResults.Style[HtmlTextWriterStyle.Display] = "none";
            grdResults.DataSource = null;
            grdResults.DataBind();
            return;
        }

        divResults.Style[HtmlTextWriterStyle.Display] = "block";

        DataTable dtlistcustomers = new DataTable();
        dtlistcustomers.Columns.Add("EventID", typeof(int));
        dtlistcustomers.Columns.Add("CustomerID", typeof(int));
        dtlistcustomers.Columns.Add("EventCustomerID", typeof(int));
        dtlistcustomers.Columns.Add("CustomerName");
        dtlistcustomers.Columns.Add("EventName");
        dtlistcustomers.Columns.Add("EventDate");
        dtlistcustomers.Columns.Add("RegisteredOn");
        dtlistcustomers.Columns.Add("EventURL");
        dtlistcustomers.Columns.Add("CustomerURL");

        var orgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

        for (int icount = 0; icount < arrevents.Count; icount++)
        {
            for (int iinnercount = 0; iinnercount < arrevents[icount].Customer.Count; iinnercount++)
            {
                string customername = arrevents[icount].Customer[iinnercount].Customer.User.FirstName.Trim() + " " + arrevents[icount].Customer[iinnercount].Customer.User.LastName.Trim();
                string eventurl = "";
                string customerurl = "";

                if (orgUser.CheckRole((long)Roles.Technician))
                {
                    eventurl = "/App/Franchisee/Technician/TechnicianEventCustomerResult.aspx?AllRecordsEventID=" + arrevents[icount].EventID.ToString();
                    customerurl = "/App/Franchisee/Technician/ManualEntryTestResultTabsView.aspx?EventID=" + arrevents[icount].EventID.ToString() + "&CustomerID=" + arrevents[icount].Customer[iinnercount].Customer.CustomerID;
                }
                else if (orgUser.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    eventurl = "/App/Franchisee/FranchiseeEventCustomerResult.aspx?AllRecordsEventID=" + arrevents[icount].EventID.ToString();
                    customerurl = "/App/Franchisee/AuditPostEntryStackView.aspx?EventID=" + arrevents[icount].EventID.ToString() + "&CustomerID=" + arrevents[icount].Customer[iinnercount].Customer.CustomerID;
                }
                else if (orgUser.CheckRole((long)Roles.FranchisorAdmin))
                {
                    eventurl = "/App/Franchisor/EventCustomerResult.aspx?AllRecordsEventID=" + arrevents[icount].EventID.ToString();
                    customerurl = "javascript:void(0);";
                }

                dtlistcustomers.Rows.Add(new object[] { arrevents[icount].EventID, arrevents[icount].Customer[iinnercount].Customer.CustomerID, arrevents[icount].Customer[iinnercount].EventCustomerID,
                                                             customername, arrevents[icount].Name, Convert.ToDateTime(arrevents[icount].EventDate).ToString("MM/dd/yyyy"), arrevents[icount].Customer[iinnercount].DateCreated.ToString("MM/dd/yyyy"), eventurl, customerurl});
            }
        }

        grdResults.PageSize = Convert.ToInt32(ViewState["PageSize"]);
        grdResults.DataSource = dtlistcustomers;
        grdResults.DataBind();

        tblPostAuditPaging.InnerHtml = ImplementPaging(Convert.ToInt32(ViewState["PageNumber"]), Convert.ToInt32(ViewState["PageSize"]));
    }

    /// <summary>
    /// 
    /// </summary>
    private void GetCustomerListfromDB()
    {
        Int16 pagenumber, pagesize;
        int  eventid;
        string eventtext, eventdatefrom, eventdateto;

        pagenumber = Convert.ToInt16(ViewState["PageNumber"]);
        pagesize = Convert.ToInt16(ViewState["PageSize"]);
        eventid = Convert.ToInt32(ViewState["EventID"]);

        eventtext = ViewState["EventText"].ToString();
        eventdatefrom = ViewState["EventDateFrom"].ToString();
        eventdateto = ViewState["EventDateTo"].ToString();

        var masterDal = new MasterDAL();
        List<EEvent> arrevents = null;

        int itotalrecords = 0;

        if (chkNoImages.Checked)
        {
            arrevents = masterDal.GetEventsMissingRecordDetail(2, pagenumber, pagesize, eventid, eventtext, eventdatefrom, eventdateto, out itotalrecords);
        }
        else if (chkNoResults.Checked)
        {
            arrevents = masterDal.GetEventsMissingRecordDetail(0,pagenumber, pagesize, eventid, eventtext, eventdatefrom, eventdateto, out itotalrecords);
        }
        else if (chkParResults.Checked)
        {
            arrevents = masterDal.GetEventsMissingRecordDetail(1, pagenumber, pagesize,  eventid,  eventtext, eventdatefrom, eventdateto, out itotalrecords);
        }

        ViewState["TotalRecords"] = itotalrecords;
        LoadGridCustomers(arrevents);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagenumber"></param>
    /// <param name="pagesize"></param>
    /// <param name="recordcount"></param>
    /// <returns></returns>
    private string ImplementPaging(int pagenumber, int pagesize)
    {
        int recordcount = Convert.ToInt32(ViewState["TotalRecords"]);

        if (recordcount <= pagesize) return "";

        // Calculates Total number of pages possible
        int numberofpages = recordcount / pagesize;
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
            pagingtableHTML += "<td><a href=\"javascript:__doPostBack('PageNumber','" + Convert.ToString(minpagenumtodisplay - 1) + "')\">...</a></td>";
        }

        // Forms the Paging Number HTML .... for the range
        for (int icount = minpagenumtodisplay; icount <= maxpagenumtodisplay; icount++)
        {
            if (pagenumber == icount)
                pagingtableHTML += "<td style=\" padding:4px; \">" + Convert.ToString(icount) + "</td>";
            else
                pagingtableHTML += "<td style=\" padding:4px;\"><a href=\"javascript:__doPostBack('PageNumber','" + Convert.ToString(icount) + "')\">" + Convert.ToString(icount) + "</a></td>";
        }

        if (numberofpages > 10 && maxpagenumtodisplay < numberofpages) // Applied if number of pages are greater than 10 and there are still more pages to come.
        {
            pagingtableHTML += "<td><a href=\"javascript:__doPostBack('PageNumber','" + Convert.ToString(maxpagenumtodisplay + 1) + "')\">...</a></td>";
        }

        pagingtableHTML += " </tr></table>";
        return pagingtableHTML;
    }

    #endregion

}
