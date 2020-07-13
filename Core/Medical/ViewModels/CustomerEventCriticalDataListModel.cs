using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerEventCriticalDataListModel : ListModelBase<CustomerEventCriticalDataViewModel, CustomerEventCriticalDataListModelFilter>
    {
        public override IEnumerable<CustomerEventCriticalDataViewModel> Collection { get; set; }

        public override CustomerEventCriticalDataListModelFilter Filter { get; set; }
    }
}
