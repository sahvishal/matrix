﻿using System;
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
    public partial class FocAttestation : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillAllStaticGrids();
            if (IsResultEntrybyChat)
            {
                focattestation_hip.Visible = false;
                focattestation_chat.Visible = true;

            }
            else
            {
                focattestation_hip.Visible = true;
                focattestation_chat.Visible = false;
            }
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
            var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.FocAttestation) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

            if (listUnableScreenReasonData.Count < 1)
                listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
            //Filling Unable Screen Reason DataLists
            UnableToScreenFocAttestationDataList.DataSource = listUnableScreenReasonData;
            UnableToScreenFocAttestationDataList.DataBind();

            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });
                if (!IsResultEntrybyChat)
                {
                    ddlTestNotPerformedReasonFocAttestation.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonFocAttestation.DataTextField = "Name";
                    ddlTestNotPerformedReasonFocAttestation.DataValueField = "Id";
                    ddlTestNotPerformedReasonFocAttestation.DataBind();
                    ddlTestNotPerformedReasonFocAttestation.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonFocAttestation_Chat.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonFocAttestation_Chat.DataTextField = "Name";
                    ddlTestNotPerformedReasonFocAttestation_Chat.DataValueField = "Id";
                    ddlTestNotPerformedReasonFocAttestation_Chat.DataBind();
                    ddlTestNotPerformedReasonFocAttestation_Chat.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonFocAttestation.Visible = false;
                ddlTestNotPerformedReasonFocAttestation_Chat.Visible = false;
            }
        }
    }
}