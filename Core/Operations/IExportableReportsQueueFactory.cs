using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Operations
{
    public interface IExportableReportsQueueFactory
    {
        ExportableReportsQueueListModel Create(IEnumerable<ExportableReportsQueue> exportableReports, MediaLocation mediaLocation, IEnumerable<File> files);
    }
}
