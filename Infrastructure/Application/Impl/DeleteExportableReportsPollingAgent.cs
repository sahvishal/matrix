using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class DeleteExportableReportsPollingAgent : IDeleteExportableReportsPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IExportableReportsQueueRepository _exportableReportsQueueRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly string _locationPath;
        private readonly int _noOfdays;
        private readonly bool _isDevEnvironment;
        public DeleteExportableReportsPollingAgent(ISettings settings, IMediaRepository mediaRepository, ILogManager logManager, IExportableReportsQueueRepository exportableReportsQueueRepository,
            IUniqueItemRepository<File> fileRepository)
        {
            _logger = logManager.GetLogger("Delete Reports");
            _exportableReportsQueueRepository = exportableReportsQueueRepository;
            _fileRepository = fileRepository;
            _noOfdays = settings.NoOfDaysAfterDeleteReports;
            _locationPath = mediaRepository.GetExportToCsvMediaFileLocation().PhysicalPath;

            _isDevEnvironment = settings.IsDevEnvironment;
        }

        public void DeleteReports()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {

                    var queues = _exportableReportsQueueRepository.GetExportableReportsQueuesForDelete(_noOfdays);
                    if (queues.IsNullOrEmpty())
                    {
                        _logger.Info("No exportable queue found.");
                        return;
                    }
                    var fileIds = queues.Where(q => q.FileId.HasValue && q.FileId > 0).Select(q => q.FileId.Value).ToArray();
                    var files = _fileRepository.GetByIds(fileIds);
                    foreach (var exportableReportsQueue in queues)
                    {
                        try
                        {
                            if (exportableReportsQueue.FileId.HasValue && exportableReportsQueue.FileId > 0)
                            {
                                var file = files.Single(f => f.Id == exportableReportsQueue.FileId);

                                var completePath = _locationPath + file.Path;
                                if (System.IO.File.Exists(completePath))
                                    System.IO.File.Delete(completePath);
                                _exportableReportsQueueRepository.Delete(exportableReportsQueue.Id);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Error while deleting Exportable report queue id :" + exportableReportsQueue.Id);
                            _logger.Error("Message :" + ex.Message);
                            _logger.Error("Stack Trace :" + ex.StackTrace);
                        }

                    }


                    _logger.Info("Reports Deleted Successfully");
                }
                else
                {
                    _logger.Info(string.Format("Delete Report can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Message :" + ex.Message);
                _logger.Error("Stack Trace :" + ex.StackTrace);
            }
        }
    }
}
