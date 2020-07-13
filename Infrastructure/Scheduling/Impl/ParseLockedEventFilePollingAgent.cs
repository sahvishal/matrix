using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class ParseLockedEventFilePollingAgent : IParseLockedEventFilePollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger _logger;
        private readonly ISettings _settings;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        public ParseLockedEventFilePollingAgent(IEventRepository eventRepository, ILogManager logManager, IMediaRepository mediaRepository, ISettings settings,
            ICorporateAccountRepository corporateAccountRepository, ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository)
        {
            _eventRepository = eventRepository;

            _mediaRepository = mediaRepository;
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _logger = logManager.GetLogger("ParseLockedEventFile");
        }

        public void PollForParseLockedEventFiles()
        {
            _logger.Info("Start parsing for Except Wellmed Account ");
            ParseLockedEventFilesExceptWellmed();
            _logger.Info("End parsing for Except Wellmed Account ");
        }

        private void ParseLockedEventFilesExceptWellmed()
        {
            try
            {
                var lockCorporateEventFolderLocation = string.Empty;
                var corporateAccounts = _corporateAccountRepository.GetAllHealthPlan();
                var sourcePath = _settings.LockCorporateEventFolderLocation;
                foreach (var corporateAccount in corporateAccounts)
                {
                    _logger.Info("Getting events for Account : " + corporateAccount.Tag);
                    if (corporateAccount != null && (corporateAccount.Id == _settings.WellmedAccountId || corporateAccount.Id == _settings.WellmedTxAccountId))
                    {
                        continue;
                    }
                    var eventIds = _eventRepository.GetEventIdsByAccountIdAndDate(corporateAccount.Id, DateTime.Today, DateTime.Today.AddDays(1));

                    if (eventIds.IsNullOrEmpty())
                    {
                        _logger.Info("No events found for Account : " + corporateAccount.Tag);
                        continue;
                    }
                    if (corporateAccount != null && string.IsNullOrWhiteSpace(corporateAccount.AcesClientShortName))
                    {
                        _logger.Info("AcesClient Short Name not specified for Account : " + corporateAccount.Tag);
                        continue;
                    }

                    lockCorporateEventFolderLocation = Path.Combine(sourcePath, corporateAccount.AcesClientShortName);

                    if (!DirectoryOperationsHelper.IsDirectoryExist(lockCorporateEventFolderLocation))
                    {
                        _logger.Info("Path does not exist for Account :" + corporateAccount.Tag + " Path @" + lockCorporateEventFolderLocation);
                        continue;
                    }

                    foreach (var eventId in eventIds)
                    {
                        _logger.Info("Importing for EventId " + eventId);
                        try
                        {

                            var location = _mediaRepository.GetUnlockEventsParseLocation(eventId, true);

                            var eventCustomers = _eventCustomerRepository.GetEventCustomersbyEventId(eventId);
                            if (!eventCustomers.IsNullOrEmpty())
                            {
                                var customerIds = eventCustomers.Select(x => x.CustomerId).ToArray();
                                if (!customerIds.IsNullOrEmpty())
                                {
                                    ParseFileFromBPShare(customerIds, lockCorporateEventFolderLocation, location.PhysicalPath);
                                }
                            }
                            _logger.Info("Import completed for EventId " + eventId);
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

        private void ParseFileFromBPShare(IEnumerable<long> customerIds, string sourceDirectory, string destinationDirectory)
        {
            try
            {
                var filesFocAttestation = DirectoryOperationsHelper.GetFiles(sourceDirectory, "*.pdf");
                foreach (var customerId in customerIds)
                {
                    _logger.Info("Proccessed for Customer Id " + customerId);
                    var focAttestationFile = string.Empty;
                    var destinationFile = string.Empty;

                    var attestationfile = filesFocAttestation.FirstOrDefault(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileNameWithoutExtension(fsd).ToLower().Trim() == customerId.ToString());

                    if (attestationfile.IsNullOrEmpty())
                    {
                        _logger.Info("File not found for customer Id " + customerId);
                        continue;
                    }
                    destinationFile = Path.Combine(destinationDirectory, customerId + ".pdf");
                    _logger.Info("File Moving for customer Id " + customerId + " Source file name :" + attestationfile + ", destination file name : " + destinationFile);

                    DirectoryOperationsHelper.DeleteFileIfExist(destinationFile);

                    DirectoryOperationsHelper.Move(attestationfile, destinationFile);
                    _logger.Info("File Moved for customer Id " + customerId + " Source file name :" + attestationfile + ", destination file name : " + destinationFile);

                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Error on Copy File From BPShare Message: " + exception.Message + "\n stack trace: " + exception.StackTrace));
            }
        }
    }
}