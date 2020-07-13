using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.DataAccess.Franchisor;
namespace HealthYes.Web.App.Common
{
    public partial class AscAddTask : System.Web.UI.Page
    {
        string XmlDeclartion = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["Add"]))
                {
                    if (Request["Add"].Equals("Task"))
                    {
                        AddTask();
                    }
                }
                else if (!string.IsNullOrEmpty(Request["Delete"]))
                {
                    if (Request["Delete"].Equals("Prospect"))
                    {
                        if (!string.IsNullOrEmpty(Request["prospectid"]))
                        {
                            Int64 iProspectId = Convert.ToInt64(Request["prospectid"]);
                            DeleteProspect(iProspectId);
                        }
                    }
                    else if (Request["Delete"].Equals("Host"))
                    {
                        if (!string.IsNullOrEmpty(Request["hostid"]))
                        {
                            Int64 iHostId = Convert.ToInt64(Request["hostid"]);
                            DeleteHost(iHostId);
                        }
                    }

                }
            }
            catch
            {
                Response.End();
            }
            finally
            {
                Response.End();
            }
        }
        /// <summary>
        /// Add Task
        /// </summary>
        private void AddTask()
        {
            
            if ((!string.IsNullOrEmpty(Request["subject"])) || !string.IsNullOrEmpty(Request["duedate"]) || !string.IsNullOrEmpty(Request["duetime"]))
            {

                if (!string.IsNullOrEmpty(Request["prospectid"]))
                {
                    Response.Clear();
                    Response.ContentType = "text/xml";
                    // Add Task
                    string strSubject = string.Empty;
                    string strDueDate = string.Empty;
                    string strDueTime = string.Empty;
                    string strProspectid = string.Empty;
                    string strAssignedStatus = string.Empty;

                    long temp;

                    if (!string.IsNullOrEmpty(Request["subject"]))
                    {
                        strSubject = Request["subject"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["duedate"]))
                    {
                        strDueDate = Request["duedate"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["duetime"]))
                    {
                        strDueTime = Request["duetime"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["prospectid"]))
                    {
                        strProspectid = Request["prospectid"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["assignedstatus"]))
                    {
                        strAssignedStatus = Request["assignedstatus"].ToString();
                    }

                    var masterDal = new Falcon.DataAccess.Master.MasterDAL();
                    var task = new Falcon.Entity.Other.ETask();

                    //TaskService objTaskService = new TaskService();
                    //EUserShellModuleRole objEUserShellModuleRole = new EUserShellModuleRole();

                    //ETask task = new ETask();

                    //task.TaskStatusType = new ETaskStatusType();
                    //task.TaskPriorityType = new ETaskPriorityType();
                    //task.TaskType = new ETaskType();
                    //task.UserShellModule = new HealthYes.Web.UI.TaskService.EUserShellModuleRole();

                    task.TaskStatusType = new Falcon.Entity.Other.ETaskStatusType();
                    task.TaskPriorityType = new Falcon.Entity.Other.ETaskPriorityType();
                    task.TaskType = new Falcon.Entity.Other.ETaskType();
                    task.UserShellModule = new Falcon.Entity.User.EUserShellModuleRole();


                    var currentSession = IoC.Resolve<ISessionContext>().UserSession;


                    task.Active = true;
                    task.Subject = strSubject;
                    if (strDueDate != "")
                        task.DueDate = strDueDate;
                    if (strDueTime != "")
                        task.DueTime = strDueTime;
                    task.Notes = "";
                    task.StartDate = "";
                    task.StartTime = "";

                    task.UserShellModule.ShellID = currentSession.CurrentOrganizationRole.OrganizationId.ToString();
                    task.UserShellModule.RoleShellID = (int)currentSession.CurrentOrganizationRole.OrganizationRoleUserId;
                    task.UserShellModule.RoleID = currentSession.CurrentOrganizationRole.RoleId.ToString();
                    task.UserShellModule.UserID = currentSession.UserId.ToString();
                    
                    //task.UserShellModule = objEUserShellModuleRole;
                    task.ProspectID = 0;
                    if (!string.IsNullOrEmpty(strProspectid))
                    {
                        task.ProspectID = Convert.ToInt64(strProspectid);
                    }
                    task.ContactID = 0;
                    task.CreatedBY = Convert.ToInt32(currentSession.UserId);
                    task.ModifiedBY = task.CreatedBY;

                    //objTaskService.AddTask(task, objEUserShellModuleRole, out temp, out temp1);

                    temp = masterDal.SaveTask(task, Convert.ToInt32(EOperationMode.Insert), currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(), currentSession.CurrentOrganizationRole.RoleId.ToString());
                    if (temp == 0)
                    {
                        temp = 9999990;
                    }

                    if (Request["ishost"] == null || Request["ishost"] == "")
                    {
                        // Assign Prospect
                        if (task.ProspectID > 0)
                        {
                            if (currentSession.CurrentOrganizationRole.CheckRole((long) Roles.SalesRep) && strAssignedStatus.Equals("2"))
                            {
                                FranchisorDAL objFranchisorDal=new FranchisorDAL();
                                //mode - 1 for Assign Prospect
                                objFranchisorDal.AssignProspect(1, Convert.ToInt64(task.ProspectID), Convert.ToInt64(currentSession.UserId));
                                XmlDeclartion = XmlDeclartion + "<result>1</result>";
                                Response.Write(XmlDeclartion);
                            }
                            else
                            {
                                XmlDeclartion = XmlDeclartion + "<result>0</result>";
                                Response.Write(XmlDeclartion);
                            }
                        }
                    }
                    // task added to prospect
                    else if(Request["ishost"] != null && Request["ishost"] != "")
                    {
                        XmlDeclartion = XmlDeclartion + "<result>1</result>";
                        Response.Write(XmlDeclartion);
                    }
                }
            }
            else
            {
                        XmlDeclartion = XmlDeclartion + "<result>2</result>";
                        Response.Write(XmlDeclartion);
            }
        }
        /// <summary>
        /// Delete prospect
        /// </summary>
        /// <param name="iProspectId"></param>
        private void DeleteProspect(Int64 iProspectId)
        {
            Int64 ireturnvalue=0;
            FranchisorDAL objFranchisorDal=new FranchisorDAL();
            //mode - 1 for delete prospect
            ireturnvalue = objFranchisorDal.DeleteProspectHost(1, iProspectId);
            // clear response
            Response.Clear();
            Response.ContentType = "text/xml"; 

            if (ireturnvalue == 1)
            {
                XmlDeclartion = XmlDeclartion + "<result>1</result>";
                Response.Write(XmlDeclartion);
            }
            else
            {
                XmlDeclartion = XmlDeclartion + "<result>0</result>";
                Response.Write(XmlDeclartion);
            }
        }
        /// <summary>
        /// Delete Host
        /// </summary>
        /// <param name="iProspectId"></param>
        private void DeleteHost(Int64 iProspectId)
        {
            Int64 ireturnvalue = 0;
            //HealthYes.Web.UI.FranchisorService.FranchisorService service = new HealthYes.Web.UI.FranchisorService.FranchisorService();
            //service.DeleteHost(iProspectId, true, out ireturnvalue, out blnreturnvalue);
            FranchisorDAL objFranchisorDal=new FranchisorDAL();
            //mode - 2 delete host
            ireturnvalue = objFranchisorDal.DeleteProspectHost(2, iProspectId);
            if (ireturnvalue == 1)
            {
                XmlDeclartion = XmlDeclartion + "<result>1</result>";
                Response.Write(XmlDeclartion);
            }
            else if (ireturnvalue == 2)
            {
                XmlDeclartion = XmlDeclartion + "<result>2</result>";
                Response.Write(XmlDeclartion);
            }
            else
            {
                XmlDeclartion = XmlDeclartion + "<result>0</result>";
                Response.Write(XmlDeclartion);
            }
        }
    }
}
