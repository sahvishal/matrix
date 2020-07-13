using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;


public partial class App_Franchisor_FranchisorHostDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "View Host";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.setpoductitle("View Host", "Host");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Host</a>";
        if (!IsPostBack)
        {
            ViewState["SortExp"] = "Name";
            ViewState["SortDir"] = SortDirection.Ascending;
           
            if (Request.QueryString["searchtext"] != null)
            {
                SearchHost(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetHost();
            }
        }
    }

    private void GetHost()
    {
        var masterDal = new MasterDAL();
        List<EEvent> objevent = masterDal.GetFranchisorHost(string.Empty, 0);


        DataTable dthost = new DataTable();
        dthost.Columns.Add("ProspectID");
        dthost.Columns.Add("Name");
        dthost.Columns.Add("DateCreated");
        dthost.Columns.Add("Capacity",typeof(Int32));
        dthost.Columns.Add("Franchisee");
        dthost.Columns.Add("Count");
        dthost.Columns.Add("EventName");
        dthost.Columns.Add("EventDate");
        dthost.Columns.Add("CustomerCount");

        if (objevent != null )
        {
            for (int icount = 0; icount < objevent.Count; icount++)
            {
                string date = "-N/A-";
                string name = "-N/A-";
                if (objevent[icount].Name.Length > 0)
                {
                    name = objevent[icount].Name;
                    date = objevent[icount].EventDate;
                }

                dthost.Rows.Add(new object[] { objevent[icount].Prospect.ProspectID, objevent[icount].Prospect.OrganizationName, objevent[icount].Prospect.FollowDate, objevent[icount].Prospect.ActualMembership, objevent[icount].Franchisee.Name, objevent[icount].SlotCount, name, date, objevent[icount].AttendedCustomersCount.ToString() });

            }

            errordiv.Visible = false;
            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dthost.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            else
            {
                dthost.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }


            divGrdHost.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            divGrdHost.Style.Add(HtmlTextWriterStyle.Display, "none");
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }



        grdHost.DataSource = dthost;
        ViewState["Host"] = dthost;
        grdHost.DataBind();

    }

    private void SearchHost(string searchtext)
    {
        var masterDal = new MasterDAL();
        List<EEvent> objevent = masterDal.GetFranchisorHost(searchtext,1);


        DataTable dthost = new DataTable();
        dthost.Columns.Add("ProspectID");
        dthost.Columns.Add("Name");
        dthost.Columns.Add("DateCreated");
        dthost.Columns.Add("Capacity",typeof(Int32));
        dthost.Columns.Add("Franchisee");
        dthost.Columns.Add("Count");
        dthost.Columns.Add("EventName");
        dthost.Columns.Add("EventDate");
        dthost.Columns.Add("CustomerCount");

        if (objevent != null )
        {
            for (int icount = 0; icount < objevent.Count; icount++)
            {
                string date = "-N/A-";
                string name = "-N/A-";
                if (objevent[icount].Name.Length > 0)
                {
                    name = objevent[icount].Name;
                    date = objevent[icount].EventDate;
                }

                dthost.Rows.Add(new object[] { objevent[icount].Prospect.ProspectID, objevent[icount].Prospect.OrganizationName, objevent[icount].Prospect.FollowDate, objevent[icount].Prospect.ActualMembership, objevent[icount].Franchisee.Name, objevent[icount].SlotCount,name,date,objevent[icount].AttendedCustomersCount.ToString() });

            }
            errordiv.Visible = false;

            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dthost.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            else
            {
                dthost.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }

            divGrdHost.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            divGrdHost.Style.Add(HtmlTextWriterStyle.Display, "none");
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }


        ViewState["Host"] = dthost;
        grdHost.DataSource = dthost;
        grdHost.DataBind();

    }

    protected void grdHost_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdHost_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdHost.PageIndex = e.NewPageIndex;
        grdHost.DataSource = (DataTable)ViewState["Host"];
        grdHost.DataBind();
    }

    protected void grdHost_Sorting(object sender, GridViewSortEventArgs e)
    {

        DataTable dtHost = (DataTable)ViewState["Host"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtHost.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtHost.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtHost = dtHost.DefaultView.ToTable();
        ViewState["SortExp"] = e.SortExpression;
        ViewState["Host"] = dtHost;
        grdHost.DataSource = dtHost;
        grdHost.DataBind();
    }
}
