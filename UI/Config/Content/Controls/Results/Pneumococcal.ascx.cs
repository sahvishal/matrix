using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Pneumococcal : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                Pneumococcal_hip.Visible = false;
                Pneumococcal_chat.Visible = true;

            }
            else
            {
                Pneumococcal_hip.Visible = true;
                Pneumococcal_chat.Visible = false;

            }
            FillAllStaticGrids();
        }

        private void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
            var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Pneumococcal) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

            if (listUnableScreenReasonData.Count < 1)
                listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

            //Filling Unable Screen Reason DataLists
            dtlPneumococcalSelectedUnableToScreen.DataSource = listUnableScreenReasonData;
            dtlPneumococcalSelectedUnableToScreen.DataBind();

            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                ddlTestNotPerformedReasonPneumococcal.DataSource = listTestNotPerformedData;
                ddlTestNotPerformedReasonPneumococcal.DataTextField = "Name";
                ddlTestNotPerformedReasonPneumococcal.DataValueField = "Id";
                ddlTestNotPerformedReasonPneumococcal.DataBind();
                ddlTestNotPerformedReasonPneumococcal.Items[0].Selected = true;
            }
            else
            {
                ddlTestNotPerformedReasonPneumococcal.Visible = false;
            }
        }
    }
}