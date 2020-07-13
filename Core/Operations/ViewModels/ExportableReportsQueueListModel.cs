using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class ExportableReportsQueueListModel : ListModelBase<ExportableReportsQueueViewModel, ExportableReportsQueueFilter>
    {
        public override IEnumerable<ExportableReportsQueueViewModel> Collection { get; set; }

        public override ExportableReportsQueueFilter Filter { get; set; }
    }
}
