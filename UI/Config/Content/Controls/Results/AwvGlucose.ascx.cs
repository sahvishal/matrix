using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class AwvGlucose : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                AwvGlucose_hip.Visible = false;
                AwvGlucose_chat.Visible = true;

            }
            else
            {
                AwvGlucose_hip.Visible = true;
                AwvGlucose_chat.Visible = false;
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
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvGlucose) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();

                var standardFindingGlucose = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.AwvGlucose, (int)ReadingLabels.Glucose);
                GlucoseFindingGridView.DataSource = standardFindingGlucose;
                GlucoseFindingGridView.DataBind();
                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenAwvGlucoseDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAwvGlucoseDataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonAwvGlucose.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvGlucose.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvGlucose.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvGlucose.DataBind();
                    ddlTestNotPerformedReasonAwvGlucose.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvGlucose.Visible = false;
                }
            }
        }
    }
}