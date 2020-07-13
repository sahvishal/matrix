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
    public class ParseWellmedLockedEventFilePollingAgent : IParseWellmedLockedEventFilePollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger _logger;
        private readonly ISettings _settings;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        public ParseWellmedLockedEventFilePollingAgent(IEventRepository eventRepository, ILogManager logManager, IMediaRepository mediaRepository, ISettings settings,
            ICorporateAccountRepository corporateAccountRepository, ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository)
        {
            _eventRepository = eventRepository;

            _mediaRepository = mediaRepository;
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _logger = logManager.GetLogger("ParseWellmedLockedEventFile");
        }

        public void PollForParseLockedEventFiles()
        {
            _logger.Info("Start parsing for Wellmed Account ");
            ParseLockedEventFilesForWellmed();
            _logger.Info("End parsing for Wellmed Account ");
        }

        public void ParseLockedEventFilesForWellmed()
        {
            try
            {
                var lockCorporateEventFolderLocation = string.Empty;
                var wellmedFlAccountId = _settings.WellmedAccountId;
                var wellmedTxAccountId = _settings.WellmedTxAccountId;
                long[] wellmedAccountIds = { wellmedFlAccountId, wellmedTxAccountId };

                var corporateAccounts = _corporateAccountRepository.GetByIds(wellmedAccountIds);

                foreach (var corporateAccount in corporateAccounts)
                {
                    _logger.Info("Getting events for Account : " + corporateAccount.Tag);

                    if (corporateAccount != null && corporateAccount.Id == _settings.WellmedAccountId)
                    {
                        lockCorporateEventFolderLocation = _settings.WellmedFlLockCorporateEventFolderLocation;
                    }
                    else if (corporateAccount != null && corporateAccount.Id == _settings.WellmedTxAccountId)
                    {
                        lockCorporateEventFolderLocation = _settings.WellmedTxLockCorporateEventFolderLocation;
                    }

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
                            var location = _mediaRepository.GetUnlockEventsParseLocation(eventId, true);

                            var eventCustomers = _eventCustomerRepository.GetEventCustomersbyEventId(eventId);
                            if (!eventCustomers.IsNullOrEmpty())
                            {
                                var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());
                                if (!customers.IsNullOrEmpty())
                                {
                                    var memberIds = customers.Where(x => !x.InsuranceId.IsNullOrEmpty()).Select(x => x.InsuranceId).ToArray();
                                    if (!memberIds.IsNullOrEmpty())
                                    {
                                        CopyFileFromBPShare(memberIds, lockCorporateEventFolderLocation, location.PhysicalPath);
                                    }
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
        private void CopyFileFromBPShare(IEnumerable<string> memberIds, string sourceDirectory, string destinationDirectory)
        {
            try
            {
                var filesFocAttestation = DirectoryOperationsHelper.GetFiles(sourceDirectory, "*.pdf");
                foreach (var memberId in memberIds)
                {
                    _logger.Info("Proccessed for Member Id " + memberId);
                    var focAttestationFile = string.Empty;
                    var destinationFile = string.Empty;
                    //var attestationfile = filesFocAttestation.FirstOrDefault(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileNameWithoutExtension(fsd).ToLower().Trim() == memberId.ToLower().Trim());

                    var attestationfile = filesFocAttestation.FirstOrDefault(fsd => !string.IsNullOrEmpty(fsd) &&
                        Path.GetFileNameWithoutExtension(fsd).ToLower().Trim().Contains(memberId.ToLower().Trim()+"_"));

                    if (attestationfile.IsNullOrEmpty())
                    {
                        _logger.Info("File not found for Member Id " + memberId);
                        continue;
                    }
                    destinationFile = Path.Combine(destinationDirectory, memberId + ".pdf");
                    _logger.Info("File Moving for Member Id " + memberId + " Source file name :" + attestationfile + ", destination file name : " + destinationFile);

                    DirectoryOperationsHelper.DeleteFileIfExist(destinationFile);

                    DirectoryOperationsHelper.Move(attestationfile, destinationFile);
                    _logger.Info("File Moved for Member Id " + memberId + " Source file name :" + attestationfile + ", destination file name : " + destinationFile);
                    
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Error on Copy File From BPShare Message: " + exception.Message + "\n stack trace: " + exception.StackTrace));
            }
        }
    }
}