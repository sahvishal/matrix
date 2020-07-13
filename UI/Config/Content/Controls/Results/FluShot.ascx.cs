using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class FluShot : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillAllStaticGrids();
            if (IsResultEntrybyChat)
            {
                fluShot_hip.Visible = false;
                fluShot_chat.Visible = true;

            }
            else
            {
                fluShot_hip.Visible = true;
                fluShot_chat.Visible = false;
            }

        }

        private void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
            var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.FluShot) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

            if (listUnableScreenReasonData.Count < 1)
                listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

            //Filling Unable Screen Reason DataLists
            dtlFluShotSelectedUnableToScreen.DataSource = listUnableScreenReasonData;
            dtlFluShotSelectedUnableToScreen.DataBind();

            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                ddlTestNotPerformedReasonFluShot.DataSource = listTestNotPerformedData;

                ddlTestNotPerformedReasonFluShot.DataTextField = "Name";
                ddlTestNotPerformedReasonFluShot.DataValueField = "Id";
                ddlTestNotPerformedReasonFluShot.DataBind();
                ddlTestNotPerformedReasonFluShot.Items[0].Selected = true;
            }
            else
            {
                ddlTestNotPerformedReasonFluShot.Visible = false;
            }
        }
    }
}