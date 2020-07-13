using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Repositories;

public partial class MedicalVendor_MedicalVendorMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            spcurdate.InnerText = DateTime.Now.ToString("dddd, dd MMMM, yyyy");
            Ucmenucontrol1.RoleName = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias;

            //TODO: This is too much pasing and type casting - Yasir April 2011
            var currentRole = (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId;
            Ucwelcomebox1.SetLinks(currentRole);
            ShowPendingAuthorization();
        }
               
    }

    /// <summary>
    /// Property to set breadcrumb's root name and link
    /// value should be like 
    /// <a href="/App/Franchisor/ViewProspects.aspx">Prospect</a>
    /// </summary>
    public string SetBreadCrumbRoot
    {
        set
        {
            spnRoot.InnerHtml = value;
        }
    }

    public void ShowPendingAuthorization()
    {
        
        if (Convert.ToBoolean(Session["AllowAuthorizations"]))
        {
            IPhysicianRepository physicianRepository = new PhysicianRepository();
            bool authorizationPending = physicianRepository.IsAuthorizationPending(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            if (authorizationPending)
            {
                MessageControl1.ShowSuccessMessage("There are authorizations pending for today and tomorrow's events. Please complete the authorizations before you do the reviews.");
            }
            else
            {
                MessageControl1.ShowSuccessMessage("There are no authorizations pending for today or tomorrow's events.");
            }
        }
    }
}
