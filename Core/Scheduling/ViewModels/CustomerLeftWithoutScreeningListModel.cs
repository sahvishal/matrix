using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerLeftWithoutScreeningListModel : ListModelBase<CustomerLeftWithoutScreeningModel, CustomerLeftWithoutScreeningModelFilter>
    {
        public override IEnumerable<CustomerLeftWithoutScreeningModel> Collection { get; set; }
        public override CustomerLeftWithoutScreeningModelFilter Filter { get; set; }
    }
}
