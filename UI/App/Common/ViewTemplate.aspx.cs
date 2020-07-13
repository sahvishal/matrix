using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

public partial class App_Franchisor_ViewTemplate : System.Web.UI.Page
{

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "View Template";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.setpoductitle("View Template", "Template");
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/ViewTemplate.aspx\">Template</a>";
        if (!IsPostBack)
        {
            ViewState["SortTemplate"] = SortDirection.Ascending;
            ViewState["SortExp"] = "TemplateName";

            var currentOrgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            if (currentOrgUser.CheckRole((long)Roles.FranchiseeAdmin))
            {
                if (Request.QueryString["searchtext"] != null)
                {
                    SearchTemplateForFranchise(Request.QueryString["searchtext"].ToString(), currentOrgUser.OrganizationId);
                }
                else
                {
                    SearchTemplateForFranchise("", currentOrgUser.OrganizationId);
                }
            }
            else
            {
                if (Request.QueryString["searchtext"] != null)
                {
                    SearchTemplate(Request.QueryString["searchtext"].ToString());
                }
                else
                {
                    LoadTemplate();
                }
            }
            
        }
    }

    protected void dgviewtemplates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chklistname1");
        if (chktempheader != null)
        {
            chktempheader.Attributes["onClick"] = "GridMasterCheck()";
        }

        HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
        if (chktemprow != null)
        {
            chktemprow.Attributes["onClick"] = "GridChildCheck();";
        }
    }


    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgviewtemplates_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtTemplate = (DataTable)ViewState["DSGRID"];
        if ((!ViewState["SortExp"].ToString().Equals(e.SortExpression)) || (SortDirection)ViewState["SortTemplate"] == SortDirection.Descending)
        {
            dtTemplate.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortTemplate"] = SortDirection.Ascending;
        }
        else
        {
            dtTemplate.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortTemplate"] = SortDirection.Descending;
        }
        ViewState["SortExp"] = e.SortExpression;
        dtTemplate = dtTemplate.DefaultView.ToTable();

        dgviewtemplates.DataSource = dtTemplate;
        ViewState["DSGRID"] = dtTemplate;

        dgviewtemplates.DataBind();
    }


    #endregion
    
    #region Methods

    void LoadTemplate()
    {
        var masterDal = new MasterDAL();
        List<EScheduleTemplate> objscheduletemplate = masterDal.GetEventScheduleTemplate(string.Empty, 0, 0);
        if (objscheduletemplate != null && objscheduletemplate.Count > 0)
        {
            DataTable tbltemp = new DataTable();
            tbltemp.Columns.Add("TemplateName");
            tbltemp.Columns.Add("Dateadded", typeof(DateTime));
            tbltemp.Columns.Add("Status");
            tbltemp.Columns.Add("TemplateID");
            tbltemp.Columns.Add("Global");
            tbltemp.Columns.Add("IsGlobal", typeof(bool));

            for (int count = 0; count < objscheduletemplate.Count; count++)
            {
                string global = "";

                if (objscheduletemplate[count].Global) global = "True";
                else global = "False";

                if (objscheduletemplate[count].IsActive == true)
                    tbltemp.Rows.Add(new object[] { objscheduletemplate[count].Name, Convert.ToDateTime(objscheduletemplate[count].DateCreated), "Active", objscheduletemplate[count].ScheduleTemplateID, global, false });
                else
                    tbltemp.Rows.Add(new object[] { objscheduletemplate[count].Name, Convert.ToDateTime(objscheduletemplate[count].DateCreated), "InActive", objscheduletemplate[count].ScheduleTemplateID, global, false });

            }

            if ((SortDirection)ViewState["SortTemplate"] == SortDirection.Descending)
            {
                tbltemp.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            else
            {
                tbltemp.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            tbltemp = tbltemp.DefaultView.ToTable();
            ViewState["DSGRID"] = tbltemp;
            dgviewtemplates.DataSource = tbltemp;
            dgviewtemplates.DataBind();
        }
        else
        {
            divErrorMsg.InnerText = "No Record found";
            divErrorMsg.Visible = true;
        }
    }

    void SearchTemplate(string filterstring)
    {
        var masterDal = new MasterDAL();
        List<EScheduleTemplate> objscheduletemplate = masterDal.GetEventScheduleTemplate(filterstring,0,2);
        if (objscheduletemplate != null && objscheduletemplate.Count > 0)
        {
            DataTable tbltemp = new DataTable();
            tbltemp.Columns.Add("TemplateName");
            tbltemp.Columns.Add("Dateadded", typeof(DateTime));
            tbltemp.Columns.Add("Status");
            tbltemp.Columns.Add("TemplateID");
            tbltemp.Columns.Add("Global");
            tbltemp.Columns.Add("IsGlobal", typeof(bool));

            for (int count = 0; count < objscheduletemplate.Count; count++)
            {
                string global = "";

                if (objscheduletemplate[count].Global) global = "True";
                else global = "False";

                if (objscheduletemplate[count].IsActive == true)
                    tbltemp.Rows.Add(new object[] { objscheduletemplate[count].Name, Convert.ToDateTime(objscheduletemplate[count].DateCreated), "Active", objscheduletemplate[count].ScheduleTemplateID, global, false });
                else
                    tbltemp.Rows.Add(new object[] { objscheduletemplate[count].Name, Convert.ToDateTime(objscheduletemplate[count].DateCreated), "InActive", objscheduletemplate[count].ScheduleTemplateID, global, false });

            }

            if ((SortDirection)ViewState["SortTemplate"] == SortDirection.Descending)
            {
                tbltemp.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            else
            {
                tbltemp.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            tbltemp = tbltemp.DefaultView.ToTable();
            ViewState["DSGRID"] = tbltemp;

            dgviewtemplates.DataSource = tbltemp;
            dgviewtemplates.DataBind();
        }
        else
        {
            divErrorMsg.InnerText = "No Record found";
            divErrorMsg.Visible = true;
        }
    }

    void SearchTemplateForFranchise(string filterstring, long franchiseeid)
    {
        var masterDal = new MasterDAL();
        List<EScheduleTemplate> objscheduletemplate = masterDal.GetEventScheduleTemplate(filterstring, franchiseeid, 3);
        if (objscheduletemplate != null && objscheduletemplate.Count > 0)
        {
            DataTable tbltemp = new DataTable();
            tbltemp.Columns.Add("TemplateName");
            tbltemp.Columns.Add("Dateadded", typeof(DateTime));
            tbltemp.Columns.Add("Status");
            tbltemp.Columns.Add("TemplateID");
            tbltemp.Columns.Add("Global");
            tbltemp.Columns.Add("IsGlobal", typeof(bool));

            for (int count = 0; count < objscheduletemplate.Count; count++)
            {
                string global = "";

                if (objscheduletemplate[count].Global) global = "True";
                else global = "False";

                if (objscheduletemplate[count].IsActive == true)
                    tbltemp.Rows.Add(new object[] { objscheduletemplate[count].Name, Convert.ToDateTime(objscheduletemplate[count].DateCreated), "Active", objscheduletemplate[count].ScheduleTemplateID, global, objscheduletemplate[count].Global });
                else
                    tbltemp.Rows.Add(new object[] { objscheduletemplate[count].Name, Convert.ToDateTime(objscheduletemplate[count].DateCreated), "InActive", objscheduletemplate[count].ScheduleTemplateID, global, objscheduletemplate[count].Global });

            }

            if ((SortDirection)ViewState["SortTemplate"] == SortDirection.Descending)
            {
                tbltemp.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            else
            {
                tbltemp.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            tbltemp = tbltemp.DefaultView.ToTable();
            ViewState["DSGRID"] = tbltemp;
            
            dgviewtemplates.DataSource = tbltemp;
            dgviewtemplates.DataBind();
        }
        else
        {
            divErrorMsg.InnerText = "No Record found";
            divErrorMsg.Visible = true;
        }
    }

    #endregion

}
