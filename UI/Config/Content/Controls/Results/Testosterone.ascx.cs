﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Testosterone : UserControl
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                Testosterone_hip.Visible = false;
                Testosterone_chat.Visible = true;

            }
            else
            {
                Testosterone_hip.Visible = true;
                Testosterone_chat.Visible = false;
            }
            FillAllStaticGrids();

            var settings = IoC.Resolve<ISettings>();
            var captureBloodTest = settings.CaptureBloodTest;
            var bloodTestChangeDate = settings.BloodTestChangeDate;

            if (captureBloodTest && EventDate.Date >= bloodTestChangeDate)
                TestosteroneReadingDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
            else
                TestosteroneReadingDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Testosterone) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

                //Filling Unable Screen Reason DataLists
                UnableToScreenTestosteroneDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenTestosteroneDataList.DataBind();
            }
        }
    }
}