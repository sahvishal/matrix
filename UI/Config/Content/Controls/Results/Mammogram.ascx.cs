using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class Mammogram : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillAllStaticGrids();
            if (IsResultEntrybyChat)
            {
                Mammogram_hip.Visible = false;
                Mammogram_chat.Visible = true;

            }
            else
            {
                Mammogram_hip.Visible = true;
                Mammogram_chat.Visible = false;
            }
        }
        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.Mammogram);

                gvFindingsMammogram.DataSource = standardFindingList;
                gvFindingsMammogram.DataBind();

                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Mammogram) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenmammogramDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenmammogramDataList.DataBind();
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
                    ddlTestNotPerformedReasonMammogram_CHAT.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonMammogram_CHAT.DataTextField = "Name";
                    ddlTestNotPerformedReasonMammogram_CHAT.DataValueField = "Id";
                    ddlTestNotPerformedReasonMammogram_CHAT.DataBind();
                    ddlTestNotPerformedReasonMammogram_CHAT.Items[0].Selected = true;
                }
                else
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonMammogram.DataSource = listTestNotPerformedData;
                    ddlTestNotPerformedReasonMammogram.DataTextField = "Name";
                    ddlTestNotPerformedReasonMammogram.DataValueField = "Id";
                    ddlTestNotPerformedReasonMammogram.DataBind();
                    ddlTestNotPerformedReasonMammogram.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonMammogram.Visible = false;
                ddlTestNotPerformedReasonMammogram_CHAT.Visible = false;
            }
        }

    }
}