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
    public partial class Vision : UserControl
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                vision_hip.Visible = false;
                vision_chat.Visible = true;

            }
            else
            {
                vision_hip.Visible = true;
                vision_chat.Visible = false;
            }
            FillAllStaticGrids();

            var showHideRepeatVisionConfrontationDate = IoC.Resolve<ISettings>().ShowHideRepeatVisionConfrontationDate;
            if (EventDate >= showHideRepeatVisionConfrontationDate)
            {
                ConfrontationBothEyeDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                ConfrontationOneEyeDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Vision) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenVisionDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenVisionDataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonVision.DataSource = listTestNotPerformedData;
                    ddlTestNotPerformedReasonVision.DataTextField = "Name";
                    ddlTestNotPerformedReasonVision.DataValueField = "Id";
                    ddlTestNotPerformedReasonVision.DataBind();
                    ddlTestNotPerformedReasonVision.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonVision.Visible = false;
                }
            }
        }
    }
}