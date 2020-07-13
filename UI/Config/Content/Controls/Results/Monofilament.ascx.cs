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
    public partial class Monofilament : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillAllStaticGrids();
            if (IsResultEntrybyChat)
            {
                Monofilament_hip.Visible = false;
                Monofilament_chat.Visible = true;
            }
            else
            {
                Monofilament_hip.Visible = true;
                Monofilament_chat.Visible = false;
            }
        }
        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            if (!IsResultEntrybyChat)
            {
                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Monofilament) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

                //Filling Unable Screen Reason DataLists
                UnableToScreenMonofilamentDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenMonofilamentDataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonMonofilament.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonMonofilament.DataTextField = "Name";
                    ddlTestNotPerformedReasonMonofilament.DataValueField = "Id";
                    ddlTestNotPerformedReasonMonofilament.DataBind();
                    ddlTestNotPerformedReasonMonofilament.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonMonofilament.Visible = false;
                }
            }
        }
    }
}