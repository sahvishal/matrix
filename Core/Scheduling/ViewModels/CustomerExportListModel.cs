using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerExportListModel : ListModelBase<CustomerExportModel, CustomerExportListModelFilter>
    {
        public override IEnumerable<CustomerExportModel> Collection { get; set; }

        public override CustomerExportListModelFilter Filter { get; set; }
    }
}
