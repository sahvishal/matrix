using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.App.Common
{
    public partial class EditResult : System.Web.UI.Page
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        protected bool IsNewResultFlow { get; set; }
        protected string VersionNumber { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            var master = ((Franchisor_FranchisorMaster)Master);
            if (master != null)
            {
                master.HideLeftContainer = true;
                master.hideucsearch();
                master.settitle("Edit Result");
                master.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
            }

            long s = 0;
            if (Request.QueryString["EventId"] != null && long.TryParse(Request.QueryString["EventId"], out s))
            {
                EventId = s;

                var eventRepository = IoC.Resolve<IEventRepository>();

                IsNewResultFlow = eventRepository.IsEventHasNewResultFlow(EventId);

                if (IsNewResultFlow)
                    ClientScript.RegisterHiddenField("IsNewResultFlowInputHidden", "true");
                else
                    ClientScript.RegisterHiddenField("IsNewResultFlowInputHidden", "false");
            }

            s = 0;
            if (Request.QueryString["CustomerId"] != null && long.TryParse(Request.QueryString["CustomerId"], out s))
            {
                CustomerId = s;
            }

        }
    }
}