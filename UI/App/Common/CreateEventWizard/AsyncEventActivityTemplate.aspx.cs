using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Enum;
using Falcon.DataAccess.Master;
using EEventActivityTemplate=Falcon.Entity.Other.EEventActivityTemplate;
using EEventActivityTemplateActivity=Falcon.Entity.Other.EEventActivityTemplateActivity;
using ERole=Falcon.Entity.Other.ERole;


namespace Falcon.App.UI.App.Common.CreateEventWizard
{
    public partial class AsyncEventActivityTemplate : System.Web.UI.Page
    {
        protected enum AssignedRoles { Host_PrimaryContact = 0, Host_DecissionMaker, Specific_System_User, Specific_Email_Address };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventActivityTemplateID"] != null)
            {
                DataTable dtactivities = new DataTable();
                dtactivities.Columns.Add("ActivityID", typeof(Int64));
                dtactivities.Columns.Add("ActivityName");
                dtactivities.Columns.Add("Subject");
                dtactivities.Columns.Add("ActivityDay");
                dtactivities.Columns.Add("ForAfterEvent", typeof(bool));
                dtactivities.Columns.Add("Notes");
                dtactivities.Columns.Add("RoleID", typeof(Int64));
                dtactivities.Columns.Add("RoleShellID", typeof(Int64));
                dtactivities.Columns.Add("RoleName");
                dtactivities.Columns.Add("SpecifiedUserName");
                dtactivities.Columns.Add("SpecifiedEmail");
                dtactivities.Columns.Add("IsDeleted", typeof(bool));

                var masterDal = new MasterDAL();
                EEventActivityTemplate objeventactivitytemplate = masterDal.GetEventActivityTemplatebyID(Convert.ToInt32(Request.QueryString["EventActivityTemplateID"]));
                //HealthYes.Web.UI.RoleService.RoleService objRoleSvc = new HealthYes.Web.UI.RoleService.RoleService();
                //HealthYes.Web.UI.RoleService.ERole[] arrrole = objRoleSvc.GetAllActiveRole();
                MasterDAL objMasterDal=new MasterDAL();
                var listRole = objMasterDal.GetRole(string.Empty, 3);
                ERole[] arrrole = null;
                if (listRole != null)
                    arrrole = listRole.ToArray();
                
                if (objeventactivitytemplate != null && objeventactivitytemplate.ListActivities != null && objeventactivitytemplate.ListActivities.Count> 0)
                {
                    foreach (EEventActivityTemplateActivity objactivity in objeventactivitytemplate.ListActivities)
                    {
                        string strrolename = "";
                        for (int icount = 0; icount < arrrole.Length; icount++)
                        {
                            if (arrrole[icount].RoleID == objactivity.ResponsibleRoleID)
                            {
                                strrolename = arrrole[icount].Name;
                                break;
                            }
                        }
                        
                        if (objactivity.ResponsibleRoleID > 0 && objactivity.ResponsibleRoleShellID > 0)
                            strrolename = AssignedRoles.Specific_System_User.ToString().Replace("_", " ");

                        if (objactivity.ResponsibleRoleID == 0 && objactivity.ResponsibleRoleShellID == 0)
                            strrolename = AssignedRoles.Specific_Email_Address.ToString().Replace("_", " ");

                        dtactivities.Rows.Add(new object[] { objactivity.ActivityID, objactivity.EventActivity.ToString(), objactivity.Subject, objactivity.ActivityDay,
                                                        objactivity.ForAfterEvent, (objactivity.EventActivity == EEventActivity.EMail ? objactivity.EmailContent : objactivity.Notes),
                                                        objactivity.ResponsibleRoleID, objactivity.ResponsibleRoleShellID, strrolename,
                                                        objactivity.SpecifiedUserName, objactivity.ResponsibleSpecifiedEmail, false});
                    }
                    gridActivitytime.DataSource = dtactivities;
                    gridActivitytime.DataBind();
                }
            }
            RenderActivityDetail();
            Response.End();
        }

        private void RenderActivityDetail()
        {
            HtmlForm newForm = this.form1;
            newForm.Controls.Clear();
            newForm.Controls.Add(divEventActivity);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            HtmlTextWriter htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));


            newForm.RenderControl(htWriter);

            string strRenderedHTML = sb.ToString();
            strRenderedHTML = strRenderedHTML.Substring(strRenderedHTML.IndexOf("<div id=\"divEventActivity\""), strRenderedHTML.LastIndexOf("</div") - strRenderedHTML.IndexOf("<div id=\"divEventActivity\"") + 6);
            Response.Write(strRenderedHTML);
        }
    }
}
