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
    public partial class AwvFluShot : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                AwvFluShot_hip.Visible = false;
                AwvFluShot_chat.Visible = true;

            }
            else
            {
                AwvFluShot_hip.Visible = true;
                AwvFluShot_chat.Visible = false;
            }
            FillAllStaticGrids();
        }

        private void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
            var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvFluShot) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

            if (listUnableScreenReasonData.Count < 1)
                listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

            //Filling Unable Screen Reason DataLists
            dtlAwvFluShotSelectedUnableToScreen.DataSource = listUnableScreenReasonData;
            dtlAwvFluShotSelectedUnableToScreen.DataBind();

            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                ddlTestNotPerformedReasonAwvFluShot.DataSource = listTestNotPerformedData;

                ddlTestNotPerformedReasonAwvFluShot.DataTextField = "Name";
                ddlTestNotPerformedReasonAwvFluShot.DataValueField = "Id";
                ddlTestNotPerformedReasonAwvFluShot.DataBind();
                ddlTestNotPerformedReasonAwvFluShot.Items[0].Selected = true;
            }
            else
            {
                ddlTestNotPerformedReasonAwvFluShot.Visible = false;
            }
        }
    }
}