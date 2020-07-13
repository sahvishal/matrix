using System;
using System.Web;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;

//using HealthYes.Web.UI.UserService;

public partial class Franchisee_Technician_UploadResults : System.Web.UI.Page
{
    #region "Form Events"

    /// <summary>
    /// Page load Events calling routine
    /// to fill events dropdown with All occured events 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Session["UploadInfo"] = new UploadInfo { IsReady = false };
        this.Page.Title = "Upload Results";
        Franchisee_Technician_TechnicianMaster obj;
        obj = (Franchisee_Technician_TechnicianMaster)this.Master;

        obj.SetBreadcrumb = "<a href=\"HomePage.aspx\">DashBoard</a>";

        if (!IsPostBack)
        {
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;

            ClientScript.RegisterStartupScript(typeof(string), "jsuploadfile", " document.getElementById('uploadFrame').src = 'Upload.aspx?TechnicianID=" + currentSession.CurrentOrganizationRole.OrganizationRoleUserId + "&RoleID=" + currentSession.CurrentOrganizationRole.RoleId + "&ShellID=" + currentSession.CurrentOrganizationRole.OrganizationId + "'; ", true);
        }
        
    }
    
    #endregion

    // <summary>
    /// 
    /// </summary>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static object GetUploadStatus()
    {
        //  get the length of the file on disk and divide that
        //  by the length of the stream ...
        UploadInfo info = HttpContext.Current.Session["UploadInfo"] as UploadInfo;

        if (info != null && info.IsReady)
        {
            int soFar = info.UploadedLength;
            int total = info.ContentLength;

            int percentComplete = (int)Math.Ceiling((double)soFar / (double)total * 100);
            string message = string.Format("Uploading {0} ... {1} of {2} Bytes", info.FileName, soFar, total);

            //  return the percentage
            return new { percentComplete = percentComplete, message = message };
        }

        //  not ready yet ...
        return null;
    }


}
