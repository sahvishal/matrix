using System;
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
    public partial class Psa : UserControl
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                psa_hip.Visible = false;
                psa_chat.Visible = true;

            }
            else
            {
                psa_hip.Visible = true;
                psa_chat.Visible = false;
            }

            FillAllStaticGrids();

            var settings = IoC.Resolve<ISettings>();
            var captureBloodTest = settings.CaptureBloodTest;
            var bloodTestChangeDate = settings.BloodTestChangeDate;

            if (captureBloodTest && EventDate.Date >= bloodTestChangeDate)
                PsaReadingDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
            else
                PsaReadingDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Psa) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

                //Filling Unable Screen Reason DataLists
                UnableToScreenPsaDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenPsaDataList.DataBind();
            }
        }
    }
}