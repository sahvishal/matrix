using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Repositories;

namespace Falcon.App.UI.App.MedicalVendor
{
    public partial class ApproveInvoice : Page
    {
        protected int _medicalVendorMedicalVenderUserId;
        private readonly IPhysicianRepository _physicianRepository = new PhysicianRepository();

        
        protected bool _canSeeEarnings;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "MVUserDashBoard";
            var objmaster = (MedicalVendor_MedicalVendorMaster) Master;
            objmaster.SetBreadCrumbRoot = "Invoice Approval Notice";
            
            _canSeeEarnings = _physicianRepository.CanSeeEarnings(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
     
    }
}
