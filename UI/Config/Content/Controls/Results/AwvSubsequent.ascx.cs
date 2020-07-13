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
    public partial class AwvSubsequent : UserControl
    {
        protected long EventId { get; set; }
        protected long CustomerId { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                AwvSubsequent_hip.Visible = false;
                AwvSubsequent_chat.Visible = true;

            }
            else
            {
                AwvSubsequent_hip.Visible = true;
                AwvSubsequent_chat.Visible = false;
            }


            long eventId = 0;
            long customerId = 0;
            if (Request.QueryString["EventId"] != null && long.TryParse(Request.QueryString["EventId"], out eventId))
            {
                EventId = eventId;
            }


            if (Request.QueryString["CustomerId"] != null && long.TryParse(Request.QueryString["CustomerId"], out customerId))
            {
                CustomerId = customerId;
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
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvSubsequent) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenAwvSubsequentDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAwvSubsequentDataList.DataBind();
            }
        }
    }
}