using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.Enum;

public partial class App_Common_ScheduleTemplate : System.Web.UI.Page
{

   
    protected void Page_Load(object sender, EventArgs e)
    {

        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;

        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"ViewTemplate.aspx\">Template</a>";
        this.Page.Title = "EventSchedule Template";

        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

        if (!IsPostBack)
        {
            txtduration.Attributes.Add("onKeyDown", "return txtkeypress(event);");

            if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                this.GetActiveFranchisee();
            }
            else
            {
                pFranchiseeList.Visible = false;
            }

            if (Request.QueryString["TemplateID"] != null)
            {

                obj.settitle("Edit Schedule Template");
                dvTitle.InnerText = "Edit Event Schedule Template";

                if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                    this.GetTemplateDetails(Convert.ToInt32(Request.QueryString["TemplateID"]), false);
                else
                    this.GetTemplateDetails(Convert.ToInt32(Request.QueryString["TemplateID"]), true);
            }
            else
            {
                obj.settitle("Create Schedule Template");
                dvTitle.InnerText = "Create Event Schedule Template";
            }
            for (int count = 0; count < 60; count++)
            {
                string mm = count.ToString();
                if (mm.Length == 1)
                    mm = "0" + mm;
                ddlMMStartTime.Items.Add(new ListItem(mm, mm));
                ddlMMEndTime.Items.Add(new ListItem(mm, mm));
            }

        }
        //pnlmodalpopup.Attributes.Add("Display", "none");
    }

  
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        this.save();
    }

   
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser("ViewTemplate.aspx");
    }
    
    private void GetActiveFranchisee()
    {
        var organizationRepository = IoC.Resolve<IOrganizationRepository>();
        var franchiseeList = organizationRepository.GetOrganizationIdNamePairs(OrganizationType.Franchisee);
        chklstFranchisee.DataSource = franchiseeList;
        chklstFranchisee.DataTextField = "FirstValue";
        chklstFranchisee.DataValueField = "SecondValue";
        chklstFranchisee.DataBind();
    }
    
    private void GetTemplateDetails(int templateid, bool isfranchisee)
    {

        var masterDal = new MasterDAL();
        EScheduleTemplate objscheduletemplate = masterDal.GetScheduleTemplateDetails(templateid);
        //ViewState["EditObject"] = objscheduletemplate;

        txtschedulename.Text = objscheduletemplate.Name;
        chkisactive.Checked = objscheduletemplate.IsActive;
        txtdescription.Text = objscheduletemplate.Description;
        if (isfranchisee == false)
        {
            if (objscheduletemplate.Global)
                rbtAllFranchisee.Checked = true;
            else
            {
                rbtSpecFranch.Checked = true;
                ClientScript.RegisterStartupScript(typeof(string), "jsspecificfranch", " HandleDivHide('block'); ", true);
                foreach (EScheduleTemplateFranchiseeAccess objfranchiseeaccess in objscheduletemplate.ScheduleTemplateFranchiseeAccess)
                {
                    ListItem itemtemp = chklstFranchisee.Items.FindByValue(objfranchiseeaccess.FranchiseeID.ToString());
                    if (itemtemp != null)
                        itemtemp.Selected = true;
                }
            }
        }

        int index = 0;
        foreach (EScheduleTemplateTime objscheduletemplatetime in objscheduletemplate.ScheduleTemplateTime)
        {
            string starttime = objscheduletemplatetime.StartTime;
            if (index == 0)
                index++;
            else
                txttimeslots.Text += "\n";
            txttimeslots.Text += starttime;

        }
    }
    
    private void save()
    {
        var masterDal = new MasterDAL();
        EScheduleTemplate objSchedule = new EScheduleTemplate();

        if (Request.QueryString["TemplateID"] != "")
            objSchedule.ScheduleTemplateID = Convert.ToInt32(Request.QueryString["TemplateID"]);

        objSchedule.Name = txtschedulename.Text;
        objSchedule.ScheduleTemplateFranchiseeAccess = null;
        objSchedule.ScheduleTemplateTime = null;

        objSchedule.Name = txtschedulename.Text;
        objSchedule.Description = txtdescription.Text;
        objSchedule.IsActive = chkisactive.Checked;
        objSchedule.Global = false;

        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

        if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            objSchedule.ScheduleTemplateFranchiseeAccess = new List<EScheduleTemplateFranchiseeAccess>();
            objSchedule.Global = false;
            objSchedule.ScheduleTemplateFranchiseeAccess.Add(new EScheduleTemplateFranchiseeAccess { FranchiseeID = currentOrgRole.OrganizationId });
        }
        else
        {
            if (rbtAllFranchisee.Checked)
            {
                objSchedule.Global = true;
                objSchedule.ScheduleTemplateFranchiseeAccess = null;
            }
            else
            {
                objSchedule.ScheduleTemplateFranchiseeAccess=new List<EScheduleTemplateFranchiseeAccess>();
                foreach (ListItem itemtemp in chklstFranchisee.Items)
                {
                    if (itemtemp.Selected)
                        objSchedule.ScheduleTemplateFranchiseeAccess.Add(new EScheduleTemplateFranchiseeAccess { FranchiseeID = Convert.ToInt32(itemtemp.Value) });
                }
            }
        }

        objSchedule.ScheduleTemplateTime = new List<EScheduleTemplateTime>();

        foreach (string str in txttimeslots.Text.Split(new char[] { '\n' }))
        {
            DateTime timevar;
            if (DateTime.TryParse(str.Trim(), out timevar) == true)
            {
                if (objSchedule.ScheduleTemplateTime.Count > 0)
                {
                    EScheduleTemplateTime objScheduleTemplateTime =
                    objSchedule.ScheduleTemplateTime.Find(eSchedule => eSchedule.StartTime == timevar.ToString("hh:mm tt"));
                    if (objScheduleTemplateTime != null)
                    {
                        objScheduleTemplateTime.AppointmentCount++;
                        continue;
                    }
                }

                objSchedule.ScheduleTemplateTime.Add(new EScheduleTemplateTime()
                {
                    StartTime = timevar.ToString("hh:mm tt"),
                    AppointmentCount = 1
                });
            }
        }


        if (objSchedule.ScheduleTemplateID > 0)
        {
            objSchedule.ModifiedByRole = false;
            if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                objSchedule.ModifiedByRole = true;
            }
            objSchedule.ModifiedBy = currentOrgRole.OrganizationRoleUserId;
        }
        else
        {
            objSchedule.CreatedByRole = false;
            if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                objSchedule.CreatedByRole = true;
            }
            objSchedule.CreateBy = currentOrgRole.OrganizationRoleUserId;
        }
        
        Int64 returnresult;
        
        if (objSchedule.ScheduleTemplateID > 0)
        {
            returnresult = masterDal.SaveScheduleTemplate(objSchedule, Convert.ToInt16(Falcon.App.Core.Enum.EOperationMode.Update));
        }
        else
        {
            returnresult = masterDal.SaveScheduleTemplate(objSchedule, Convert.ToInt16(Falcon.App.Core.Enum.EOperationMode.Insert));

        }

        if (returnresult == -6)
        {
            divErrorMsg.InnerText = "Template Name entered is not unique. Please provide a new name.";
            divErrorMsg.Visible = true;
        }

        if (returnresult > 0)
        {
            if (objSchedule.ScheduleTemplateID > 0)
                ClientScript.RegisterStartupScript(typeof(string), "jscode_DisplayMsg", "DisplaySuccessMessage(false);", true);
            else
                ClientScript.RegisterStartupScript(typeof(string), "jscode_DisplayMsg", "DisplaySuccessMessage(true);", true);

        }
    }




}
