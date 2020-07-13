using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class MailRoundCustomersListModel : ListModelBase<MailRoundCustomersReportViewModel, OutboundCallQueueFilter>
    {
        public override IEnumerable<MailRoundCustomersReportViewModel> Collection { get; set; }

        public override OutboundCallQueueFilter Filter { get; set; }
    }
}
