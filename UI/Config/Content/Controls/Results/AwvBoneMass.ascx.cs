using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Application;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class AwvBoneMass : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                AwvBoneMass_hip.Visible = false;
                AwvBoneMass_chat.Visible = true;

            }
            else
            {
                AwvBoneMass_hip.Visible = true;
                AwvBoneMass_chat.Visible = false;
            }

            FillAllStaticGrids();
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvBoneMass, (int)ReadingLabels.EstimatedTScore);

                gvFindingsAwvBoneMass.DataSource = standardFindingList;
                gvFindingsAwvBoneMass.DataBind();

                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvBoneMass) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenAwvBoneMassDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAwvBoneMassDataList.DataBind();
            }

            SetTestNotPerfomred();
        }

        private void SetTestNotPerfomred()
        {
            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                if (IsResultEntrybyChat)
                {
                    ddlTestNotPerformedReasonAwvBoneMass_CHAT.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvBoneMass_CHAT.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvBoneMass_CHAT.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvBoneMass_CHAT.DataBind();
                    ddlTestNotPerformedReasonAwvBoneMass_CHAT.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvBoneMass.DataSource = listTestNotPerformedData;
                    ddlTestNotPerformedReasonAwvBoneMass.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvBoneMass.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvBoneMass.DataBind();
                    ddlTestNotPerformedReasonAwvBoneMass.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonAwvBoneMass.Visible = false;
                ddlTestNotPerformedReasonAwvBoneMass_CHAT.Visible = false;
            }
        }

    }
}