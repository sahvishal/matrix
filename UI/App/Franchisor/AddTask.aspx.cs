using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.Entity.User;
using Falcon.App.Core.Enum;

public partial class App_Franchisor_AddTask : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "Add New Task";
        var obj = (Franchisor_FranchisorMaster)Master;
        obj.settitle("Add Task");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();
      
        if (!IsPostBack)
        {
            GetDropDownInfo();
            
            if (Request.QueryString["Parent"] != null)
            {
                ViewState["ReferedURL"] = Request.UrlReferrer.PathAndQuery;
                if (ViewState["ReferedURL"] != null && ViewState["ReferedURL"].ToString() != "")
                {
                    ViewState["ReferedURL"] = ViewState["ReferedURL"].ToString().Replace("&Action=Alert", "");
                }
                if (Request.QueryString["TaskID"] != null)
                {
                    sptitle.InnerText = "Edit Task";
                    obj.settitle("Edit Task");
                    Page.Title = "Edit Task";
                    ViewState["TaskID"] = Request.QueryString["TaskID"];
                    divCloseAndCreate.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divCloseAndCreate.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    FillTask();                    
                }
            }
            else if (Request.QueryString["TaskID"] != null && Request.QueryString["Parent"] == null)
            {
                sptitle.InnerText = "Edit Task";
                obj.settitle("Edit Task");
                Page.Title = "Edit Task";
                ViewState["TaskID"] = Request.QueryString["TaskID"].ToString();                
                FillTask();
            }
            else
            {
               
                txtduedate.Text = DateTime.Now.ToShortDateString();
                if (Request.QueryString["Date"] != null)
                {
                    string strDate = Request.QueryString["Date"];
                    DateTime dtEventDate;


                    if (DateTime.TryParse(strDate, out dtEventDate))
                    {
                        txtduedate.Text = dtEventDate.ToShortDateString();
                    }
                }
            }
        }
    }
    
    private void FillTask()
    {
        
        ETask[] task = null;

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        var masterDal = new MasterDAL();
        var listTask = masterDal.GetTask(Convert.ToInt32(ViewState["TaskID"]).ToString(), 1,
                                        (int)currentSession.UserId,
                                         (int)currentSession.CurrentOrganizationRole.OrganizationId,
                                         (int)currentSession.CurrentOrganizationRole.RoleId);

        if (listTask != null) task = listTask.ToArray();

        if (task != null && task.Length > 0)
        {
            ViewState["TaskID"] = task[0].TaskID.ToString();
            txtSubject.Text = task[0].Subject;
            ddlStatus.SelectedValue = task[0].TaskStatusType.TaskStatusTypeID.ToString();
            ddlPriority.SelectedValue = task[0].TaskPriorityType.TaskPriorityTypeID.ToString();

            if (task[0].DueDate.Trim().Equals("1900-01-01 00:00:00.000") || task[0].DueDate.Trim().Equals("01/01/1900"))
            {
                task[0].DueDate= "";
            }
            if (task[0].DueTime.Trim().Equals("00:00:00"))
            {
                task[0].DueTime = "";
            }
            if (!string.IsNullOrEmpty(task[0].DueTime))
            task[0].DueTime = Convert.ToString(Convert.ToDateTime(task[0].DueTime).ToShortTimeString());
            
            if (!string.IsNullOrEmpty(task[0].DueDate))
                txtduedate.Text = Convert.ToDateTime(task[0].DueDate).ToShortDateString();


            ViewState["contact"] = task[0].CreatedBY.ToString();
            TxtNotes.Text = task[0].Notes;            
            txtStartTime.Text = task[0].DueTime;
        }

    }  

   
        
    private void GetDropDownInfo()
    {
        GetStatus();
        GetPriority();
    }

    private void GetPriority()
    {

        ETaskPriorityType[] priority = null;
        var masterDal = new MasterDAL();
        //Mode '3' used for getting all Active TaskPriorityTypes
        var listTaskPriorityType = masterDal.GetTaskPriorityType(string.Empty, 3);

        if (listTaskPriorityType != null) priority = listTaskPriorityType.ToArray();

        if (priority!=null && priority.Length > 0)
        {
            for (int count = 0; count < priority.Length; count++)
            {
                ddlPriority.Items.Add(new ListItem(priority[count].Name.ToString(), priority[count].TaskPriorityTypeID.ToString()));
            }
            if (ddlPriority.Items.FindByText("Medium") != null)
            {
                ddlPriority.SelectedIndex = -1;
                ddlPriority.Items.FindByText("Medium").Selected = true;
            }
        }
    }

    private void GetStatus()
    {

        ETaskStatusType[] status = null;

        var masterDal = new MasterDAL();
        // Mode '3' used here for getting All Active Status Type
        var listTaskStatusType = masterDal.GetTaskStatusType(string.Empty, 3);

        if (listTaskStatusType != null) status = listTaskStatusType.ToArray();

        if (status!=null && status.Length > 0)
        {
            for (int count = 0; count < status.Length; count++)
            {
                ddlStatus.Items.Add(new ListItem(status[count].Name, status[count].TaskStatusTypeID.ToString()));
            }
            if (ddlStatus.Items.FindByText("In Progress") != null)
            {
                ddlStatus.SelectedIndex = -1;
                ddlStatus.Items.FindByText("In Progress").Selected = true;
            }
        }
    }

    private bool Savetask()
    {
        Int64 iProspectId = 0;

        var task = new ETask();

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        long tempResult;
        task.TaskPriorityType = new ETaskPriorityType();
        task.TaskStatusType = new ETaskStatusType();

        if (ViewState["TaskID"] != null)
        {
            task.TaskID =Convert.ToInt32(ViewState["TaskID"]);
        }

        task.Subject = txtSubject.Text;
        task.Notes = TxtNotes.Text;
        task.DueDate = txtduedate.Text;
        task.DueTime = txtStartTime.Text;
             
        task.TaskStatusType.TaskStatusTypeID = Convert.ToInt32(ddlStatus.SelectedValue);
        task.TaskPriorityType.TaskPriorityTypeID = Convert.ToInt32(ddlPriority.SelectedValue);
        task.CreatedBY = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
        task.ModifiedBY = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationRoleUserId);

        var role = new EUserShellModuleRole();
        
        task.UserShellModule = role;
        
        if(!string.IsNullOrEmpty(Request["ProspectID"]))
        {
            iProspectId = Convert.ToInt64(Request["ProspectID"]);
        }
        task.ProspectID = iProspectId;
        
        var masterDal = new MasterDAL();
        if (ViewState["TaskID"] != null)
        {
            if (ViewState["TaskID"].ToString() != string.Empty)
            {
                try
                {
                    tempResult = masterDal.SaveTask(task, Convert.ToInt32(EOperationMode.Update), currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(), currentSession.CurrentOrganizationRole.RoleId.ToString());
                }
                catch (Exception)
                {
                    tempResult = - 1;
                }
                
                if (!(tempResult == 999999 || tempResult == -1))
                    tempResult = 9999990;

                //service.UpdateTask(task, usershellmodulerole1, out tempResult, out tempResult1);
            }
        }
        else
        {
            tempResult = masterDal.SaveTask(task, Convert.ToInt32(EOperationMode.Insert), currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(), currentSession.CurrentOrganizationRole.RoleId.ToString());
            if (tempResult == 0)
            {
                tempResult = 9999990;
            }
            
        }

        // Assign prospect to salesrep
        if (iProspectId > 0)
        {
            if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
            {
                var franchisorDal = new FranchisorDAL();
                franchisorDal.AssignProspect(1, iProspectId, Convert.ToInt64(currentSession.UserId));
            }
        }
        if (Request.QueryString["Referrer"] != null)
        {
            string strReferrer = Request.QueryString["Referrer"];
            if ((strReferrer != string.Empty) && (strReferrer == "Calendar"))
            {
                Response.RedirectUser(ResolveUrl("~/App/Common/Calendar.aspx"));
            }
        }
        return true;

    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
       bool value= Savetask(); 

        if ((ViewState["TaskID"] != null) && (ViewState["TaskID"].ToString() != string.Empty))
        {
            if (Request.QueryString["Parent"] != null)
            {
                Response.RedirectUser(ViewState["ReferedURL"].ToString());
            }
            else
            {
                Response.RedirectUser(ResolveUrl("~/App/Franchisor/ViewTask.aspx?Action=Updated"));
            }

        }
        else
        {
            if (Request.QueryString["Parent"] != null)
            {
                Response.RedirectUser(ViewState["ReferedURL"].ToString());
            }
            Response.RedirectUser(ResolveUrl("~/App/Franchisor/ViewTask.aspx?Action=Added"));
        }
    }


    protected void btnCancle_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["Referrer"] != null)
        {
            string strReferrer = Request.QueryString["Referrer"];
            if ((strReferrer != string.Empty) && (strReferrer == "Calendar"))
            {
                Response.RedirectUser(ResolveUrl("~/App/Common/Calendar.aspx"));
            }
        }
        else if (Request.QueryString["Parent"] != null)
        {
            Response.RedirectUser(ViewState["ReferedURL"].ToString());
        }
        else
        {
            Response.RedirectUser(ResolveUrl("~/App/Franchisor/ViewTask.aspx"));
        }
    }


    protected void btn_CloseAndCreate_Click(object sender, ImageClickEventArgs e)
    {
        bool value = Savetask();
        txtSubject.Text = "";
        if (ddlPriority.Items.FindByText("Medium") != null)
        {
            ddlPriority.SelectedIndex = -1;
            ddlPriority.Items.FindByText("Medium").Selected = true;
        }
        if (ddlStatus.Items.FindByText("In Progress") != null)
        {
            ddlStatus.SelectedIndex = -1;
            ddlStatus.Items.FindByText("In Progress").Selected = true;
        }
        txtduedate.Text = "";
        txtStartTime.Text = "";
        TxtNotes.Text = "";
        ClientScript.RegisterStartupScript(typeof(string), "jscodeTaskAdded", "alert('Task added sucessfully.');", true);
        return;
    }

}
