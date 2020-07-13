using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Lib;
using Falcon.Entity.User;

namespace Falcon.App.UI.App.MedicalVendor
{
    public partial class EarningSummary : Page
    {
        protected long _medicalVendorId;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetMedicalVendorUserId();
            LoadPhysicianDropDownList();
        }

        private void SetMedicalVendorUserId()
        {

            _medicalVendorId = IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
        }

        private void LoadPhysicianDropDownList()
        {
            IMedicalVendorMedicalVendorUserRepository medicalVendorMedicalVendorUserRepository = 
                new MedicalVendorMedicalVendorUserRepository();

            List<MedicalVendorMedicalVendorUser> medicalVendorMedicalVendorUsers = medicalVendorMedicalVendorUserRepository.
                GetMedicalVendorMedicalVendorUsersForMedicalVendor(_medicalVendorId);
            var namesAndIds = medicalVendorMedicalVendorUsers.Select(u => new { u.Name.FullName, u.Id });
            PhysicianDropDownList.DataSource = namesAndIds;
            PhysicianDropDownList.DataTextField = "FullName";
            PhysicianDropDownList.DataValueField = "Id";
            PhysicianDropDownList.DataBind();
            PhysicianDropDownList.Items.Insert(0, new ListItem("All Physicians", "0"));
        }
    }
}
