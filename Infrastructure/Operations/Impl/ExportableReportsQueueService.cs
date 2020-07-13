using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Newtonsoft.Json;
using System;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class ExportableReportsQueueService : IExportableReportsQueueService
    {
        private readonly IExportableReportsQueueRepository _exportableReportsQueueRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IExportableReportsQueueFactory _exportableReportsQueueFactory;

        public ExportableReportsQueueService(IExportableReportsQueueRepository exportableReportsQueueRepository, IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository,
            IExportableReportsQueueFactory exportableReportsQueueFactory)
        {
            _exportableReportsQueueRepository = exportableReportsQueueRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _exportableReportsQueueFactory = exportableReportsQueueFactory;
        }

        public ExportableReportsQueue SaveExportableReportsQueue(object filter, long reportId, long requestedBy)
        {
            var filterObjectJson = JsonConvert.SerializeObject(filter);
            var exportableReportsQueue = new ExportableReportsQueue
            {
                ReportId = reportId,
                FilterData = filterObjectJson,
                RequestedBy = requestedBy,
                RequestedOn = DateTime.Now,
                StatusId = (long)ExportableReportStatus.Pending,
            };

            return _exportableReportsQueueRepository.Save(exportableReportsQueue);
        }

        public ListModelBase<ExportableReportsQueueViewModel, ExportableReportsQueueFilter> GetExportableReportQueue(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var exportableReports = _exportableReportsQueueRepository.GetExportableReportsQueue(pageNumber, pageSize, filter as ExportableReportsQueueFilter, out totalRecords);
            if (exportableReports.IsNullOrEmpty())
                return null;

            var fileIds = exportableReports.Where(x => x.FileId.HasValue).Select(x => x.FileId.Value).ToArray();

            var mediaLocation = _mediaRepository.GetExportToCsvMediaFileLocation();
            var files = _fileRepository.GetByIds(fileIds);

            return _exportableReportsQueueFactory.Create(exportableReports, mediaLocation, files);
        }
    }
}
