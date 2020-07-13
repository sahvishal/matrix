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
    public partial class Hypertension : System.Web.UI.UserControl
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }
        public bool EnableAbnormalBp { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                Hypertension_hip.Visible = false;
                Hypertension_chat.Visible = true;

            }
            else
            {
                Hypertension_hip.Visible = true;
                Hypertension_chat.Visible = false;
            }
            FillAllStaticGrids();
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Hypertension) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

                //Filling Unable Screen Reason DataLists
                UnableToScreenHypertensionDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenHypertensionDataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonHypertension.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonHypertension.DataTextField = "Name";
                    ddlTestNotPerformedReasonHypertension.DataValueField = "Id";
                    ddlTestNotPerformedReasonHypertension.DataBind();
                    ddlTestNotPerformedReasonHypertension.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonHypertension.Visible = false;
                }
            }
        }
    }
}