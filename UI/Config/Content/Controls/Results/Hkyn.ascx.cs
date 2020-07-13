using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using System;
using System.Collections.Generic;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Hkyn : System.Web.UI.UserControl
    {
        protected long EventId { get; set; }
        protected long CustomerId { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            long s = 0;
            if (Request.QueryString["EventId"] != null && long.TryParse(Request.QueryString["EventId"], out s))
            {
                EventId = s;
            }

            s = 0;
            if (Request.QueryString["CustomerId"] != null && long.TryParse(Request.QueryString["CustomerId"], out s))
            {
                CustomerId = s;
            }
            FillAllStaticGrids();
            if (IsResultEntrybyChat)
            {
                hkyn_hip.Visible = false;
                hkyn_chat.Visible = true;

            }
            else
            {
                hkyn_hip.Visible = true;
                hkyn_chat.Visible = false;
            }
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
            var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.HKYN) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

            if (listUnableScreenReasonData.Count < 1)
                listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
            //Filling Unable Screen Reason DataLists
            UnableToScreenHKYNDataList.DataSource = listUnableScreenReasonData;
            UnableToScreenHKYNDataList.DataBind();
        }
    }
}