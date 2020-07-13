using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class ImportEventFilesPollingAgent : IImportEventFilesPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IEventRepository _eventRepository;
        private readonly ISettings _settings;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;


        private readonly IEnumerable<long> _accountIds;

        public ImportEventFilesPollingAgent(ILogManager logManager, IEventRepository eventRepository, ISettings settings, ICorporateAccountRepository corporateAccountRepository, IMediaRepository mediaRepository,
            IEventCustomerRepository eventCustomerRepository)
        {
            _logger = logManager.GetLogger("ImportEventFilesPollingAgent");
            _eventRepository = eventRepository;
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _mediaRepository = mediaRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _accountIds = settings.AccountIdsForEventFileImport;
        }

        public void PollForEventFilesImport()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty())
                {
                    _logger.Info("No accounts for Event File Import.");
                    return;
                }

                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

                foreach (var corporateAccount in corporateAccounts)
                {
                    _logger.Info("Getting events for Account : " + corporateAccount.Tag);

                    var eventIds = _eventRepository.GetEventIdsByAccountIdAndDate(corporateAccount.Id, DateTime.Today, DateTime.Today.AddDays(1));

                    if (eventIds.IsNullOrEmpty())
                    {
                        _logger.Info("No events found for Account : " + corporateAccount.Tag);
                        continue;
                    }

                    foreach (var eventId in eventIds)
                    {
                        _logger.Info("Importing for EventId " + eventId);
                        try
                        {
                            string sftpHost = string.Empty;
                            string sftpUserName = string.Empty;
                            string sftpPassword = string.Empty;
                            string corporateEventFolderLocation = string.Empty;
                            string subdirectoryPattern = string.Empty;

                            if (corporateAccount != null && corporateAccount.Id == _settings.HcpNvAccountId)
                            {
                                sftpHost = _settings.HcpNvSftpHost;
                                sftpUserName = _settings.HcpNvSftpUserName;
                                sftpPassword = _settings.HcpNvSftpPassword;

                                corporateEventFolderLocation = _settings.HcpNvLockCorporateEventFolderLocation + "\\" + DateTime.Today.Year + "\\PIRs and Pink Flags\\";
                                subdirectoryPattern = "PIRs " + DateTime.Today.ToString("M.d.yy");
                            }

                            var location = _mediaRepository.GetUnlockEventsParseLocation(eventId, true);

                            if (corporateAccount != null && corporateAccount.Id == _settings.HcpNvAccountId)
                            {
                                var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);
                                if (!eventCustomers.IsNullOrEmpty())
                                {
                                    var customerIds = eventCustomers.Select(x => x.CustomerId.ToString()).ToArray();
                                    DowloadPinkFlagFromSftp(customerIds, corporateEventFolderLocation, location.PhysicalPath, sftpHost, sftpUserName, sftpPassword, "", subdirectoryPattern);
                                }
                            }
                            else if (!string.IsNullOrEmpty(sftpHost))
                            {
                                DowloadFilesFromSftp(corporateEventFolderLocation, location.PhysicalPath, sftpHost, sftpUserName, sftpPassword);
                            }
                        }
                        catch (Exception exception)
                        {
                            _logger.Error("some error occurred while parsing event id " + eventId);
                            _logger.Error(string.Format("Message: " + exception.Message + "\n stack trace: " + exception.StackTrace));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message: " + exception.Message + "\n stack trace: " + exception.StackTrace));
            }

        }

        private void DowloadFilesFromSftp(string sourceDirectory, string destinationDirectory, string sftpHost, string sftpUserName, string sftpPassword)
        {
            var processFtp = new ProcessFtp(_logger, sftpHost, sftpUserName, sftpPassword);

            _logger.Info("source directory: " + sourceDirectory);
            _logger.Info("destination directory: " + destinationDirectory);
            processFtp.DownloadFiles(sourceDirectory, destinationDirectory);
        }

        private void DowloadPinkFlagFromSftp(IEnumerable<string> filesToDownload, string sourceDirectory, string destinationDirectory, string sftpHost, string sftpUserName, string sftpPassword, string prefix, string subdirectory)
        {
            var processFtp = new ProcessFtp(_logger, sftpHost, sftpUserName, sftpPassword);

            _logger.Info("source directory: " + sourceDirectory);
            _logger.Info("destination directory: " + destinationDirectory);
            processFtp.DownloadFilesFromSubdirectories(filesToDownload, sourceDirectory, destinationDirectory, prefix, subdirectory);
        }
    }
}
