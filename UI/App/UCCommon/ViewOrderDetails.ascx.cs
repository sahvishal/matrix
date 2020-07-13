using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class ViewOrderDetails : UserControl
    {
        public long RoleId
        {
            get
            {
                return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId;
            }
        }
        
        public long OrganizationRoleUserId
        {
            get { return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId; }
        }

        public bool ShowasJDialog = true;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}