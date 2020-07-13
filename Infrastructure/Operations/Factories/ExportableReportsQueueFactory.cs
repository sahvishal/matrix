using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Operations.Factories
{
    [DefaultImplementation]
    public class ExportableReportsQueueFactory : IExportableReportsQueueFactory
    {
        public ExportableReportsQueueListModel Create(IEnumerable<ExportableReportsQueue> exportableReports, MediaLocation mediaLocation, IEnumerable<File> files)
        {
            var model = new ExportableReportsQueueListModel();
            var list = new List<ExportableReportsQueueViewModel>();

            foreach (var exportableReportQueue in exportableReports)
            {
                var file = files.SingleOrDefault(f => f.Id == exportableReportQueue.FileId);
                var viewModel = new ExportableReportsQueueViewModel()
                {
                    Name = ((ExportableReportType)exportableReportQueue.ReportId).GetDescription(),
                    Status = ((ExportableReportStatus)exportableReportQueue.StatusId).GetDescription(),
                    RequestedDate = exportableReportQueue.RequestedOn,
                    DownloadUrl = file != null ? mediaLocation.Url + file.Path : string.Empty
                };
                list.Add(viewModel);
            }

            model.Collection = list;
            return model;
        }
    }
}
