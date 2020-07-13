using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class ParseMonarchAttesationFormPollingAgent : IParseMonarchAttesationFormPollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly IEnumerable<long> _accountIds;
        private const int PageSize = 100;
        private readonly ILogger _logger;
        private readonly ISettings _settings;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;

        public ParseMonarchAttesationFormPollingAgent(IEventRepository eventRepository, ISettings settings,
            IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository,
            ICorporateAccountRepository corporateAccountRepository, ILogManager logManager,
            IMediaRepository mediaRepository, IPdfGenerator pdfGenerator, IConfigurationSettingRepository configurationSettingRepository)
        {
            _eventRepository = eventRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _mediaRepository = mediaRepository;

            _accountIds = settings.AttestionFormParseAccountIds;
            _logger = logManager.GetLogger("Parsing Monarch Attestation");
            _settings = settings;
            _pdfGenerator = pdfGenerator;
            _pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
            _configurationSettingRepository = configurationSettingRepository;
        }

        public void PollforAttestationForm()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty())
                {
                    _logger.Info("no account id provided");
                    return;
                }

                var accounts = (_corporateAccountRepository).GetByIds(_accountIds);
                _pdfGenerator.PaperSize = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PaperSize);
                foreach (var account in accounts)
                {
                    try
                    {
                        _logger.Info("Starting fetching attestation Form for tag: " + account.Tag);

                        var filter = new EventBasicInfoViewModelFilter { AccountId = account.Id, DateFrom = DateTime.Today, DateTo = DateTime.Today };
                        var pageNumber = 1;

                        while (true)
                        {
                            int totalRecords;
                            var events = _eventRepository.GetEventsbyFilters(filter, pageNumber, PageSize, out totalRecords);

                            _logger.Info("Total no of records found: " + totalRecords);

                            if (totalRecords < 1) break;

                            foreach (var theEventData in events)
                            {
                                try
                                {
                                    _logger.Info("Parsing started for Event ID : " + theEventData.Id);

                                    var eventCustomers = _eventCustomerRepository.GetbyEventId(theEventData.Id);

                                    if (eventCustomers.IsNullOrEmpty())
                                    {
                                        _logger.Info("No event customers found for the event : " + theEventData.Id);
                                        continue;
                                    }

                                    var customers = _customerRepository.GetCustomersWoithoutLoginAndAddressDetails(eventCustomers.Select(x => x.CustomerId).ToArray());
                                    var unlockedParseLocation = _mediaRepository.GetUnlockEventsParseLocation(theEventData.Id, true);

                                    if (_settings.MonarchAccountIds.Contains(account.Id))
                                    {
                                        customers = customers.Where(x => !string.IsNullOrEmpty(x.AdditionalField4)).ToList();
                                        ParseMonarchAttestationForm(customers, unlockedParseLocation);
                                    }

                                    if (_settings.AppleCareAccountId == account.Id)
                                    {
                                        if (customers.IsNullOrEmpty()) continue;

                                        ParseAppleCareAttestationForm(customers, unlockedParseLocation, account);
                                    }

                                    if (_settings.NammAccountId == account.Id)
                                    {
                                        if (customers.IsNullOrEmpty()) continue;

                                        ParseNammAttestationForm(customers, unlockedParseLocation, account, theEventData.Id);
                                    }

                                    _logger.Info("Parsing completed for Event ID : " + theEventData.Id);
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error("Message: " + ex.Message);
                                    _logger.Error("Stack Trace: " + ex.StackTrace);
                                }
                            }


                            pageNumber++;
                            if ((pageNumber * PageSize) > totalRecords)
                                break;
                        }

                        _logger.Info("Attestation Form for tag: " + account.Tag + " completed");
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Trace: " + ex.StackTrace);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }


        }

        private string MergeAttestationFils(IEnumerable<string> filesFocAttestation)
        {
            try
            {
                var tempLocation = _mediaRepository.GetTempMediaFileLocation();
                var tempfile = tempLocation.PhysicalPath + Guid.NewGuid() + ".pdf";
                _pdfGenerator.Merge(tempfile, filesFocAttestation);
                return tempfile;
            }
            catch (Exception ex)
            {
                _logger.Error("some Error occurred while merging Attestation form");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
            return string.Empty;
        }

        private void ParseMonarchAttestationForm(IEnumerable<Customer> customers, MediaLocation unlockedParseLocation)
        {
            var monarchLocation = _mediaRepository.GetMonarchAttestaionLocation();
            foreach (var customer in customers)
            {
                if (!string.IsNullOrEmpty(customer.AdditionalField4))
                {
                    _logger.Info("CustomerId: " + customer.CustomerId);
                    _logger.Info("GMPI: " + customer.AdditionalField4);

                    try
                    {
                        AttachAttestationForm(monarchLocation.PhysicalPath, customer.AdditionalField4, unlockedParseLocation.PhysicalPath);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Trace: " + ex.StackTrace);
                    }
                }
                else
                {
                    _logger.Info("GMPI is not available for Customer ID : " + customer.CustomerId);
                }
            }
        }

        private void AttachAttestationForm(string sourcePath, string searchPattern, string destinationFolder, string destinationFileName = "")
        {
            if (DirectoryOperationsHelper.IsDirectoryExist(sourcePath))
            {
                var files = DirectoryOperationsHelper.GetFiles(sourcePath, "*" + searchPattern + ".pdf");
                if (files != null && files.Any())
                {
                    foreach (var file in files)
                    {
                        var destinationFile = Path.Combine(destinationFolder, !string.IsNullOrEmpty(destinationFileName) ? destinationFileName + ".pdf" : Path.GetFileNameWithoutExtension(file) + ".pdf");
                        if (DirectoryOperationsHelper.IsFileExist(destinationFile))
                        {
                            DirectoryOperationsHelper.Delete(destinationFile);
                        }

                        DirectoryOperationsHelper.Copy(file, destinationFile);
                    }
                }
                else
                {
                    _logger.Info(string.Format("No file Found in folder : {0} for search pattern : {1}", sourcePath, searchPattern));
                }
            }
        }

        private void DownloadAttestationForm(string sourceFile, string destinationFolder, string destinationFileName = "")
        {
            if (DirectoryOperationsHelper.IsDirectoryExist(destinationFolder))
            {

                var fileName = !string.IsNullOrEmpty(destinationFileName) ? destinationFileName : Path.GetFileNameWithoutExtension(sourceFile) + ".pdf";
                destinationFileName = Path.Combine(destinationFolder, fileName);

                _logger.Info("source: " + sourceFile);
                _logger.Info("destination: " + destinationFileName);

                if (DirectoryOperationsHelper.IsFileExist(destinationFileName))
                {
                    DirectoryOperationsHelper.Delete(destinationFileName);
                }

                DirectoryOperationsHelper.Copy(sourceFile, destinationFileName);
            }
        }

        private void ParseAppleCareAttestationForm(IEnumerable<Customer> customers, MediaLocation unlockedParseLocation, CorporateAccount account)
        {
            var appleCareLocation = string.Format(_settings.AppleCareAttestationFormsPath, account.FolderName);
            var appleCareSharedFiles = DirectoryOperationsHelper.GetFiles(appleCareLocation, "*.pdf");
            if (appleCareSharedFiles.Length < 1)
            {
                _logger.Info("No attestation file found");
                return;
            }
            appleCareSharedFiles = appleCareSharedFiles.Select(x => x.ToLower()).ToArray();

            foreach (var customer in customers)
            {
                if (!customer.DateOfBirth.HasValue)
                {
                    _logger.Info("customer do not have DoB to match");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(customer.Mrn))
                {
                    _logger.Info("customer do not have Mrn to match");
                    continue;
                }

                _logger.Info("looking for Files: first Name: " + customer.Name.FirstName + " Last Name: " + customer.Name.LastName + " DoB: " + customer.DateOfBirth.Value.ToString("MMddyyyy") + " Mrn: " + customer.Name.FirstName);

                var files = appleCareSharedFiles.Select(x => x.Trim().ToLower());

                files = files.Where(x =>
                                x.Contains(customer.Name.FirstName.ToLower()) &&
                                x.Contains(customer.Name.LastName.ToLower()) &&
                                x.Contains(customer.DateOfBirth.Value.ToString("MMddyyyy")) &&
                                x.Contains(customer.Mrn.ToLower())
                            ).ToArray();

                if (files.IsNullOrEmpty())
                {
                    _logger.Info("no files found with matching first name, last name, DoB and MRN");
                    continue;
                }

                _logger.Info("found: " + files.Count() + " Files");

                try
                {
                    var sourceFileName = files.FirstOrDefault();
                    if (files.Count() > 1)
                    {
                        sourceFileName = MergeAttestationFils(files);
                    }

                    DownloadAttestationForm(sourceFileName, unlockedParseLocation.PhysicalPath, customer.CustomerId + ".pdf");
                }
                catch (Exception ex)
                {
                    _logger.Error("Message: " + ex.Message);
                    _logger.Error("Stack Trace: " + ex.StackTrace);
                }

            }
        }

        private void ParseNammAttestationForm(IEnumerable<Customer> customers, MediaLocation unlockedParseLocation, CorporateAccount account, long eventId)
        {
            if (!customers.IsNullOrEmpty() && _settings.IsSftpEnableforNaamAccount)
            {
                _logger.Info("Total no. of Customers found " + customers.Count());
                try
                {
                    if (!string.IsNullOrWhiteSpace(_settings.NammSourceDirectory) && !string.IsNullOrWhiteSpace(_settings.NammSftpHost) && !string.IsNullOrWhiteSpace(_settings.NammSftpUserName) && !string.IsNullOrWhiteSpace(_settings.NammSftpPassword))
                    {
                        DowloadFilesFromSftp(customers.Select(x => x.CustomerId.ToString()).ToList(), Path.Combine(_settings.NammSourceDirectory, eventId.ToString()), unlockedParseLocation.PhysicalPath, _settings.NammSftpHost, _settings.NammSftpUserName, _settings.NammSftpPassword, "", "");
                    }
                    else
                    {
                        _logger.Info("FTP Setting missing.");
                    }
                    
                }
                catch (Exception ex)
                {
                    _logger.Error("Message: " + ex.Message);
                    _logger.Error("Stack Trace: " + ex.StackTrace);
                }
            }
            else
            {
                var nammLocation = _settings.NammAttestationFormsPath;
                foreach (var customer in customers)
                {
                    _logger.Info("CustomerId: " + customer.CustomerId);
                    try
                    {
                        AttachAttestationForm(nammLocation, customer.CustomerId.ToString(), unlockedParseLocation.PhysicalPath);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Trace: " + ex.StackTrace);
                    }
                }
            }
        }

        private void DowloadFilesFromSftp(IEnumerable<string> filesToDownload, string sourceDirectory, string destinationDirectory, string sftpHost, string sftpUserName, string sftpPassword, string prefix, string subdirectory)
        {
            var processFtp = new ProcessFtp(_logger, sftpHost, sftpUserName, sftpPassword);

            _logger.Info("source directory: " + sourceDirectory);
            _logger.Info("destination directory: " + destinationDirectory);
            processFtp.DownloadFilesFromSubdirectories(filesToDownload, sourceDirectory, destinationDirectory, prefix, subdirectory);
        }


        //private void DowloadFilesFromSftp(string sourceDirectory, string destinationDirectory, string sftpHost, string sftpUserName, string sftpPassword)
        //{
        //    var processFtp = new ProcessFtp(_logger, sftpHost, sftpUserName, sftpPassword);

        //    _logger.Info("source directory: " + sourceDirectory);
        //    _logger.Info("destination directory: " + destinationDirectory);
        //    processFtp.DownloadFiles(sourceDirectory, destinationDirectory);
        //}
    }
}