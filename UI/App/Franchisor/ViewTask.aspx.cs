using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Lib;
//using HealthYes.Web.UI.TaskService;

public partial class App_Franchisor_ViewTask : System.Web.UI.Page
{

    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "View Task";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("View Task");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();
        obj.setpoductitle("View Task","Task");       
       
        if (!IsPostBack)
        {
            ViewState["SortExpr"] = "subject";
            ViewState["SortDir"] = SortDirection.Ascending;

            if (Request.QueryString["searchtext"] != null)
            {
                searctaskbysubject(Request.QueryString["searchtext"].ToString());
            }
            else if (Request.QueryString["Action"] != null)
            {
                if (Request.QueryString["Action"].ToString().Equals("Updated"))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('Task updated Successfully');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('Task added Successfully');", true);
                }
                loadgrid();

            }
            else
            {
                loadgrid();
            }
        }
    }

    protected void dgviewtask_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        dgviewtask.PageIndex = e.NewPageIndex;
        dgviewtask.DataSource = (DataTable)ViewState["DSGRID"];
        dgviewtask.DataBind();
   
    }
    protected void dgviewtask_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tbltask = (DataTable)ViewState["DSGRID"];
        if (e.SortExpression != ViewState["SortExpr"].ToString() || (SortDirection)ViewState["SortDir"] == SortDirection.Descending)
        {
            tbltask.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            tbltask.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }

        ViewState["SortExpr"] = e.SortExpression;
        tbltask = tbltask.DefaultView.ToTable();
        ViewState["DSGRID"] = tbltask;
        dgviewtask.DataSource = tbltask;
        dgviewtask.DataBind();

   
    }
   
   
    protected void btnAddTask_Click(object sender, EventArgs e)
    {
        Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/AddTask.aspx"));
    }
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        searctaskbysubject(txtSearchTask.Text);
    }

    private void loadgrid()
    {
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        ETask[] task = null;
        MasterDAL masterDal = new MasterDAL();
        var listTask = masterDal.GetTask(string.Empty, 3, Convert.ToInt32(currentSession.UserId),
                                         Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId),
                                         Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId));

        if (listTask != null) task = listTask.ToArray();

        DataTable tbltask = new DataTable();
        tbltask.Columns.Add("TaskID");
        tbltask.Columns.Add("Subject");
        tbltask.Columns.Add("Contact");
        tbltask.Columns.Add("DueDate");
        tbltask.Columns.Add("DueTime");
        tbltask.Columns.Add("AssignedTo");
        tbltask.Columns.Add("Notes");
        tbltask.Columns.Add("Status");
        tbltask.Columns.Add("Priority");
        if (task != null && task.Length > 0)
        {
            for (int i = 0; i < task.Length; i++)
            {
                string dueDate = "";
                string dueTime = "";
                if (!string.IsNullOrEmpty(task[i].DueDate))
                    dueDate = Convert.ToDateTime(task[i].DueDate).ToString("MM/dd/yyyy");
                if (!string.IsNullOrEmpty(task[i].DueTime))
                    dueTime = Convert.ToDateTime(task[i].DueTime).ToString("hh:mm:ss tt");
                tbltask.Rows.Add(task[i].TaskID, task[i].Subject, task[i].Contact, dueDate, dueTime, task[i].UserShellModule.UserName,task[i].Notes,task[i].TaskStatusType.Name,task[i].TaskPriorityType.Name);

            }
            divErrorMsg.Visible = false;
            Span2.InnerText = task.Length.ToString() + " Results Found";
            if ((SortDirection)ViewState["SortDir"] == SortDirection.Descending)
            {
                tbltask.DefaultView.Sort = ViewState["SortExpr"].ToString() + " desc";
            }
            else
            {
                tbltask.DefaultView.Sort = ViewState["SortExpr"].ToString() + " asc";
            }

            tbltask = tbltask.DefaultView.ToTable();
            ViewState["DSGRID"] = tbltask;
            dgviewtask.DataSource = tbltask;
            dgviewtask.DataBind();
        }
        else
        {
            if (task!=null)
                Span2.InnerText = task.Length.ToString() + " Results Found";
        }


    }


    private void searctaskbysubject(string SearchString)
    {

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        ETask[] task = null;
        MasterDAL masterDal = new MasterDAL();
        // Mode '2' is used for Fetching List of Task by Subject
        var listTask = masterDal.GetTask(SearchString, 2, Convert.ToInt32(currentSession.UserId), Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId), Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId));

        if (listTask != null) task = listTask.ToArray();

        DataTable tbltask = new DataTable();

        tbltask.Columns.Add("TaskID");
        tbltask.Columns.Add("Subject");
        tbltask.Columns.Add("Contact");
        tbltask.Columns.Add("DueDate");
        tbltask.Columns.Add("DueTime");
        tbltask.Columns.Add("AssignedTo");
        tbltask.Columns.Add("Notes");
        tbltask.Columns.Add("Status");
        tbltask.Columns.Add("Priority");

        if (task != null && task.Length > 0)
        {

            for (int i = 0; i < task.Length; i++)
            {
                string dueDate = "";
                string dueTime = "";
                if (!string.IsNullOrEmpty(task[i].DueDate))
                    dueDate = Convert.ToDateTime(task[i].DueDate).ToString("MM/dd/yyyy");
                if (!string.IsNullOrEmpty(task[i].DueTime))
                    dueTime = Convert.ToDateTime(task[i].DueTime).ToString("hh:mm:ss tt");
                tbltask.Rows.Add(task[i].TaskID, task[i].Subject, task[i].Contact, dueDate, dueTime, task[i].UserShellModule.UserName, task[i].Notes, task[i].TaskStatusType.Name, task[i].TaskPriorityType.Name);

            }
            divErrorMsg.Visible = false;
            Span2.InnerText = task.Length.ToString() + " Results Found";
            if ((SortDirection)ViewState["SortDir"] == SortDirection.Descending)
            {
                tbltask.DefaultView.Sort = ViewState["SortExpr"].ToString() + " desc";
            }
            else
            {
                tbltask.DefaultView.Sort = ViewState["SortExpr"].ToString() + " asc";
            }


            tbltask = tbltask.DefaultView.ToTable();
            dvNoRecordFound.Style.Add(HtmlTextWriterStyle.Display, "none");
            ViewState["DSGRID"] = tbltask;
            dgviewtask.DataSource = tbltask;
            dgviewtask.DataBind();
        }
        else
        {
            dvNoRecordFound.Style.Add(HtmlTextWriterStyle.Display, "block");
            dgviewtask.DataSource = null;
            dgviewtask.DataBind();
            if (task!=null)
                Span2.InnerText = task.Length.ToString() + " Results Found";
        }


    }
}
