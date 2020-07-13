using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class UncontactedCustomersReportListModel : ListModelBase<UncontactedCustomersReportModel, UncontactedCustomersReportModelFilter>
    {
        public override IEnumerable<UncontactedCustomersReportModel> Collection { get; set; }

        public override UncontactedCustomersReportModelFilter Filter { get; set; }
    }
}
