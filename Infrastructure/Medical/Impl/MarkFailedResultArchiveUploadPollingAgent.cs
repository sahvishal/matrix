using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MarkFailedResultArchiveUploadPollingAgent : IMarkFailedResultArchiveUploadPollingAgent
    {
        private readonly IResultArchiveUploadRepository _resultArchiveUploadRepository;
        private readonly int _markFailedAfterHours;
        private readonly ILogger _logger;

        public MarkFailedResultArchiveUploadPollingAgent(ILogManager logManager, IResultArchiveUploadRepository resultArchiveUploadRepository, ISettings settings)
        {
            _resultArchiveUploadRepository = resultArchiveUploadRepository;
            _markFailedAfterHours = settings.MarkResultArchiveFailedAfterHours;
            _logger = logManager.GetLogger("Result Archive Failed Records");
        }

        public void PollForFailedArchiveUpload()
        {
            try
            {
                _logger.Info("polling Result archive in progress...");

                var resultInProgress = _resultArchiveUploadRepository.GetResultArchiveUploadingAfterHours(_markFailedAfterHours);

                if (resultInProgress != null && resultInProgress.Any())
                {
                    _logger.Info("Number of result in progress " + resultInProgress.Count());

                    foreach (var resultArchive in resultInProgress)
                    {
                        resultArchive.Status = ResultArchiveUploadStatus.UploadFailed;
                        if (!resultArchive.UploadEndTime.HasValue)
                            resultArchive.UploadEndTime = DateTime.Now;

                        _resultArchiveUploadRepository.Save(resultArchive);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("exception occurred: " + ex.Message);
                _logger.Error("Stack trace: " + ex.StackTrace);
            }

            _logger.Info("result marking is done");
        }
    }
}
