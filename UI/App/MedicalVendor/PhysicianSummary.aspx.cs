using System;
using System.Web.UI;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.Entity.User;

namespace Falcon.App.UI.App.MedicalVendor
{
    public partial class PhysicianSummary : Page
    {
        protected long _medicalVendorId;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetMedicalVendorUserId();
        }

        private void SetMedicalVendorUserId()
        {
            _medicalVendorId = IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
        }
    }
}
