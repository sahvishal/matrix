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
    public partial class AwvHemaglobin : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                awvHemaglobin_hip.Visible = false;
                awvHemaglobin_chat.Visible = true;

            }
            else
            {
                awvHemaglobin_hip.Visible = true;
                awvHemaglobin_chat.Visible = false;
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
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvHBA1C) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenAwvHemaglobinDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAwvHemaglobinDataList.DataBind();
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
                    ddlTestNotPerformedReasonAwvHemaglobin_CHAT.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvHemaglobin_CHAT.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvHemaglobin_CHAT.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvHemaglobin_CHAT.DataBind();
                    ddlTestNotPerformedReasonAwvHemaglobin_CHAT.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvHemaglobin.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvHemaglobin.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvHemaglobin.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvHemaglobin.DataBind();
                    ddlTestNotPerformedReasonAwvHemaglobin.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonAwvHemaglobin.Visible = false;
                ddlTestNotPerformedReasonAwvHemaglobin_CHAT.Visible = false;
            }
        }
    }
}