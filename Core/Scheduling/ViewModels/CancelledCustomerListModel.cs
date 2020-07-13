using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CancelledCustomerListModel : ListModelBase<CancelledCustomerModel, CancelledCustomerModelFilter>
    {
        public override IEnumerable<CancelledCustomerModel> Collection { get; set; }

        public override CancelledCustomerModelFilter Filter { get; set; }
    }
}
