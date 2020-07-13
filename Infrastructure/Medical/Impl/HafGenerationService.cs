using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HafGenerationService : IHafGenerationService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly ISettings _settings;
        private readonly ILogManager _logManager;
        private readonly ILogger _logger;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ICustomerRepository _customerRepository;

        private const int NumberOfPagesToExtractFromAcePdf = 3;

        public HafGenerationService(IEventRepository eventRepository, IMediaRepository mediaRepository, IEventCustomerRepository eventCustomerRepository,
            IPdfGenerator pdfGenerator, ISettings settings, ILogManager logManager, IConfigurationSettingRepository configurationSettingRepository,
            ICorporateAccountRepository corporateAccountRepository, IUniqueItemRepository<File> fileRepository,
            ICustomerRepository customerRepository)
        {
            _eventRepository = eventRepository;
            _mediaRepository = mediaRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _pdfGenerator = pdfGenerator;
            _settings = settings;
            _logManager = logManager;
            _pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
            _logger = logManager.GetLogger("Health_Assessment_Form_Generator");
            _configurationSettingRepository = configurationSettingRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _fileRepository = fileRepository;
            _customerRepository = customerRepository;
        }

        public void GenerateHafAssessment(long eventId)
        {
            try
            {
                var eventLogger = _logManager.GetLogger("HealthAssessmentFormGenerator_" + eventId);
                eventLogger.Info("Generating HAF for Event Id: " + eventId);
                _pdfGenerator.PaperSize = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PaperSize);

                try
                {
                    var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);

                    if (eventCustomers != null && eventCustomers.Any())
                    {
                        eventCustomers = eventCustomers.Where(ec => ec.AppointmentId.HasValue).ToArray();

                        if (eventCustomers != null && eventCustomers.Any())
                        {
                            eventLogger.Info("found EventCustomers Count: " + eventCustomers.Count());

                            var mediaLocation = _mediaRepository.GetMedicalHistoryMediaLocation(eventId);

                            DirectoryOperationsHelper.CreateDirectoryIfNotExist(mediaLocation.PhysicalPath);

                            DirectoryOperationsHelper.DeleteFiles(mediaLocation.PhysicalPath);
                            var eventData = _eventRepository.GetById(eventId);
                            var account = _corporateAccountRepository.GetbyEventId(eventId);

                            var corporateSurveyPdf = "";
                            if (account != null && account.CaptureSurvey)
                            {
                                if (account.SurveyPdfFileId > 0)
                                {
                                    var surveyPdf = _fileRepository.GetById(account.SurveyPdfFileId);
                                    if (surveyPdf != null)
                                        corporateSurveyPdf = _mediaRepository.GetCorporateSurveyPdfFolderLocation().PhysicalPath + surveyPdf.Path;
                                }
                            }

                            var corporateCheckListPdf = "";
                            if (account != null && account.PrintCheckList && account.CheckListFileId > 0 && eventData.EventDate >= _settings.ChecklistChangeDate)
                            {
                                var checkListFilePdf = _fileRepository.GetById(account.CheckListFileId);
                                if (checkListFilePdf != null)
                                    corporateCheckListPdf = _mediaRepository.GetCorporateCheckListPdfFolderLocation().PhysicalPath + checkListFilePdf.Path;
                            }

                            var filesFocAttestation = new[] { "" };
                            var mediaLocFocAttestation = _mediaRepository.GetUnlockEventsParseLocation(eventId);

                            if (account != null && account.Id == _settings.HcpNvAccountId)
                            {
                                if (DirectoryOperationsHelper.IsDirectoryExist(mediaLocFocAttestation.PhysicalPath))
                                {
                                    filesFocAttestation = Directory.GetFiles(mediaLocFocAttestation.PhysicalPath, "*.*");
                                    filesFocAttestation = filesFocAttestation.Where(fsd => !string.IsNullOrEmpty(fsd)).ToArray();
                                }
                            }
                            else
                            {
                                if (DirectoryOperationsHelper.IsDirectoryExist(mediaLocFocAttestation.PhysicalPath))
                                {
                                    filesFocAttestation = Directory.GetFiles(mediaLocFocAttestation.PhysicalPath, "*.pdf");
                                    filesFocAttestation = filesFocAttestation.Where(fsd => !string.IsNullOrEmpty(fsd)).ToArray();
                                }
                            }

                            var tempMediaLocation = _mediaRepository.GetTempMediaFileLocation();
                            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

                            int index = 0;
                            foreach (var eventCustomer in eventCustomers)
                            {
                                eventLogger.Info(string.Format("Generating HAF for Event Id: {0} and Customer Id : {1} ", eventId, eventCustomer.CustomerId));
                                string url = _settings.HealthAssessmentFormUrl + string.Format("?eventId={0}&customerId={1}&LoadLayout=false&showKynEditModel=true&bulkPrint=true&removeChache={2}", eventCustomer.EventId, eventCustomer.CustomerId, Guid.NewGuid());
                                var customer = customers.First(c => c.CustomerId == eventCustomer.CustomerId);
                                var focAttestationFile = string.Empty;

                                if (account != null)
                                {
                                    var questFile = Path.Combine(_mediaRepository.GetQuestUploadMediaFileLocation().PhysicalPath, account.Tag + "_Quest.pdf");

                                    if (account.Id == _settings.WellmedAccountId || account.Id == _settings.WellmedTxAccountId)
                                    {
                                        var memberId = string.IsNullOrEmpty(customer.InsuranceId) ? "" : customer.InsuranceId.ToLower().Trim();
                                        focAttestationFile = filesFocAttestation.FirstOrDefault(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileNameWithoutExtension(fsd).ToLower().Trim() == memberId);
                                        eventLogger.Info(string.Format("focAttestationFile : {0}", focAttestationFile));

                                        var _files = new List<string>();

                                        if (!string.IsNullOrEmpty(focAttestationFile) && DirectoryOperationsHelper.IsFileExist(focAttestationFile))
                                        {
                                            eventLogger.Info(string.Format("focAttestationFile : First if {0}", focAttestationFile));
                                            _files.Add(focAttestationFile);
                                        }

                                        if (DirectoryOperationsHelper.IsFileExist(questFile))
                                        {
                                            eventLogger.Info(string.Format("focAttestationFile : 2nd if {0}", questFile));
                                            _files.Add(questFile);
                                        }

                                        if (!_files.IsNullOrEmpty())
                                        {
                                            if (_files.Count() > 1)
                                            {
                                                eventLogger.Info(string.Format("focAttestationFile : File Count {0}", _files.Count()));
                                                focAttestationFile = GetFocAttestationFileMerge(_files, focAttestationFile, eventLogger);
                                            }
                                            else
                                            {
                                                eventLogger.Info(string.Format("focAttestationFile : File[0] {0}", _files[0]));
                                                focAttestationFile = _files[0];
                                                eventLogger.Info(string.Format("focAttestationFile : Last {0}", focAttestationFile));
                                            }
                                        }
                                    }
                                    else { focAttestationFile = GetFocAttestationFileForMht(filesFocAttestation, customer.CustomerId.ToString(), eventLogger); }
                                    //else if (account.Id == _settings.MolinaAccountId)
                                    //{
                                    //    var hicn = string.IsNullOrEmpty(customer.Hicn) ? "" : customer.Hicn.ToLower().Trim();
                                    //    focAttestationFile = filesFocAttestation.FirstOrDefault(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileNameWithoutExtension(fsd).ToLower().Trim() == hicn);
                                    //}
                                    //else if (account.Id == _settings.HcpNvAccountId)
                                    //{
                                        
                                    //}
                                    //else if (_settings.MonarchAccountIds.Contains(account.Id))
                                    //{
                                    //    var gmpi = string.IsNullOrEmpty(customer.AdditionalField4) ? "" : customer.AdditionalField4.ToLower().Trim();

                                    //    if (!string.IsNullOrEmpty(gmpi))
                                    //    {
                                    //        focAttestationFile = GetFocAttestationFile(filesFocAttestation, "_" + gmpi.ToLower(), focAttestationFile, eventLogger);
                                    //    }
                                    //}
                                    //else if (account.Id == _settings.AppleCareAccountId)
                                    //{
                                    //    focAttestationFile = GetFocAttestationFile(filesFocAttestation, customer.CustomerId.ToString(), focAttestationFile, eventLogger);
                                    //}
                                    //else if (account.Id == _settings.NammAccountId)
                                    //{
                                    //    focAttestationFile = GetFocAttestationFile(filesFocAttestation, customer.CustomerId.ToString(), focAttestationFile, eventLogger);
                                    //}
                                }

                                var focAttestationFilePath = string.Empty;
                                eventLogger.Info("focAttestationFile: " + focAttestationFile);

                                if (!string.IsNullOrEmpty(focAttestationFile))
                                    focAttestationFilePath = focAttestationFile;

                                var annualComprehensiveExamPdf = string.Empty;
                                var memberInformationProfilePdf = string.Empty;

                                if (!string.IsNullOrEmpty(customer.Hicn))
                                {
                                    var fileNamePattern = customer.Hicn + (customer.Name != null ? "_" + customer.Name.LastName + "_" + customer.Name.FirstName : "");
                                    if (account != null && account.PrintAceForm)
                                    {
                                        try
                                        {
                                            var mediaLocationForAce = _mediaRepository.GetAceMipLocation(account.FolderName, fileNamePattern, "ACE");
                                            var aceFiles = DirectoryOperationsHelper.GetFiles(mediaLocationForAce.PhysicalPath, fileNamePattern + "*_ACE.pdf");
                                            if (aceFiles.Any())
                                            {
                                                annualComprehensiveExamPdf = _pdfGenerator.ExtractPdfPagesFromEnd(aceFiles.First(), tempMediaLocation.PhysicalPath + "Ripped_" + customer.Hicn + "_ACE.pdf", NumberOfPagesToExtractFromAcePdf);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            eventLogger.Error(string.Format("Unable to attach ACE form to the bulk HAF for CustomerID : {0}\nMessage : {1}", customer.CustomerId, ex.Message));
                                        }
                                    }

                                    if (account != null && account.PrintMipForm)
                                    {
                                        try
                                        {
                                            var mediaLocationForMip = _mediaRepository.GetAceMipLocation(account.FolderName, fileNamePattern, "MIP");
                                            var mipFiles = DirectoryOperationsHelper.GetFiles(mediaLocationForMip.PhysicalPath, fileNamePattern + "*_MIP.pdf");
                                            if (mipFiles.Any())
                                            {
                                                memberInformationProfilePdf = mipFiles.First();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            eventLogger.Error(string.Format("Unable to attach MIP to the bulk HAF for CustomerID : {0}\nMessage : {1}", customer.CustomerId, ex.Message));
                                        }
                                    }
                                }
                                var consentHeaderWithChecklistpdf = string.Empty;

                                if (!string.IsNullOrWhiteSpace(corporateCheckListPdf) && DirectoryOperationsHelper.IsFileExist(corporateCheckListPdf))
                                {
                                    var tempPath = _mediaRepository.GetTempMediaFileLocation();
                                    var consentHeader = Path.Combine(tempPath.PhysicalPath, Guid.NewGuid() + ".pdf");
                                    string consentHeaderUrl = _settings.ConsentHeaderFormUrl + string.Format("?eventId={0}&customerId={1}&removeChache={2}", eventCustomer.EventId, eventCustomer.CustomerId, Guid.NewGuid());
                                    _pdfGenerator.GeneratePdf(consentHeaderUrl, consentHeader);

                                    consentHeaderWithChecklistpdf = Path.Combine(tempPath.PhysicalPath, Guid.NewGuid() + ".pdf");
                                    var consentHeaderWithChecklistpdfArray = new string[] { consentHeader, corporateCheckListPdf };
                                    _pdfGenerator.Merge(consentHeaderWithChecklistpdf, consentHeaderWithChecklistpdfArray);
                                }


                                _pdfGenerator.GeneratePdfForHaf(url, mediaLocation.PhysicalPath + (++index).ToString("000.") + eventCustomer.CustomerId + ".pdf", corporateSurveyPdf, "", focAttestationFilePath, consentHeaderWithChecklistpdf,
                                    annualComprehensiveExamPdf, memberInformationProfilePdf);
                            }

                            eventLogger.Info("Merging HAF for Event Id: " + eventId);
                            _pdfGenerator.GetPdffilesfromLocationandMergeintoOne(mediaLocation.PhysicalPath, mediaLocation.PhysicalPath + "Event_" + eventId + ".pdf");
                            _eventRepository.SetGenrateHealthAssesmentFormStatus(eventId, false, (long)GenerateHealthAssesmentFormStatus.Completed);

                            index = 0;

                            foreach (var eventCustomer in eventCustomers)
                            {
                                DirectoryOperationsHelper.Delete(mediaLocation.PhysicalPath + (++index).ToString("000.") + eventCustomer.CustomerId + ".pdf");
                            }
                        }
                        else
                        {
                            eventLogger.Info("No customer found with appointment attached with this event. Merging HAF for Event Id: " + eventId);
                            _eventRepository.SetGenrateHealthAssesmentFormStatus(eventId, false, (long)GenerateHealthAssesmentFormStatus.Completed);
                        }
                    }
                    else
                    {
                        eventLogger.Info("No customer found attached with this event. Merging HAF for Event Id: " + eventId);
                        _eventRepository.SetGenrateHealthAssesmentFormStatus(eventId, false, (long)GenerateHealthAssesmentFormStatus.Completed);
                    }
                }
                catch (Exception ex)
                {
                    _eventRepository.SetGenrateHealthAssesmentFormStatus(eventId, true, (long)GenerateHealthAssesmentFormStatus.Pending);
                    eventLogger.Error("\n" + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
                }
            }
            catch (Exception ex)
            {
                _eventRepository.SetGenrateHealthAssesmentFormStatus(eventId, true, (long)GenerateHealthAssesmentFormStatus.Pending);
                _logger.Error("\n" + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
            }
        }

        private string GetFocAttestationFile(IEnumerable<string> filesFocAttestation, string selector, string focAttestationFile, ILogger eventLogger)
        {
            var attestationfiles = filesFocAttestation.Where(fsd => fsd.ToLower().Contains(selector));

            if (!attestationfiles.IsNullOrEmpty() && attestationfiles.Count() == 1)
            {
                focAttestationFile = attestationfiles.First();
            }
            else if (!attestationfiles.IsNullOrEmpty() && attestationfiles.Count() > 1)
            {
                try
                {
                    var tempLocation = _mediaRepository.GetTempMediaFileLocation();
                    var tempfile = tempLocation.PhysicalPath + Guid.NewGuid() + ".pdf";

                    _pdfGenerator.Merge(tempfile, attestationfiles);

                    focAttestationFile = tempfile;
                }
                catch (Exception ex)
                {
                    eventLogger.Error("some Error occurred while merging Attestation form");
                    eventLogger.Error("Message: " + ex.Message);
                    eventLogger.Error("Stack Trace: " + ex.StackTrace);
                }
            }
            return focAttestationFile;
        }

        private string GetFocAttestationFileForMht(IEnumerable<string> filesFocAttestation, string selector, ILogger eventLogger)
        {
            var attestationfiles = filesFocAttestation.Where(fsd => fsd.ToLower().Contains(selector) && fsd.ToLower().EndsWith(".mht"));

            var tempLocation = _mediaRepository.GetTempMediaFileLocation();
            var pinkFlagFiles = string.Empty;

            if (!attestationfiles.IsNullOrEmpty())
            {
                if (attestationfiles.Count() == 1)
                {
                    var filePath = Path.Combine(tempLocation.PhysicalPath, Guid.NewGuid() + ".pdf");

                    ConvertMhtToPdf(attestationfiles.First(), filePath, eventLogger);
                    if (DirectoryOperationsHelper.IsFileExist(filePath))
                        pinkFlagFiles = filePath;
                }
                else if (attestationfiles.Count() > 1)
                {
                    try
                    {
                        var tempAttestationList = new List<string>();
                        string tempFileName = string.Empty;

                        foreach (var attestationfile in attestationfiles)
                        {
                            tempFileName = tempLocation.PhysicalPath + Guid.NewGuid() + ".pdf";
                            ConvertMhtToPdf(attestationfile, tempFileName, eventLogger);

                            if (DirectoryOperationsHelper.IsFileExist(tempFileName))
                            {
                                tempAttestationList.Add(tempFileName);
                            }
                        }

                        tempFileName = tempLocation.PhysicalPath + Guid.NewGuid() + ".pdf";

                        _pdfGenerator.Merge(tempFileName, tempAttestationList);

                        pinkFlagFiles = tempFileName;
                    }
                    catch (Exception ex)
                    {
                        eventLogger.Error("some Error occurred while merging Attestation form");
                        eventLogger.Error("Message: " + ex.Message);
                        eventLogger.Error("Stack Trace: " + ex.StackTrace);
                    }
                }
            }

            attestationfiles = filesFocAttestation.Where(fsd => fsd.ToLower().Contains(selector) && fsd.ToLower().EndsWith(".pdf"));
            var pirFiles = string.Empty;

            if (!attestationfiles.IsNullOrEmpty())
            {
                pirFiles = GetFocAttestationFile(attestationfiles, selector, pirFiles, eventLogger);
            }

            if (string.IsNullOrEmpty(pinkFlagFiles) && string.IsNullOrEmpty(pirFiles))
                return string.Empty;

            if (!string.IsNullOrEmpty(pinkFlagFiles) && string.IsNullOrEmpty(pirFiles))
            {
                return DirectoryOperationsHelper.IsFileExist(pinkFlagFiles) ? pinkFlagFiles : string.Empty;
            }

            if (string.IsNullOrEmpty(pinkFlagFiles) && !string.IsNullOrEmpty(pirFiles))
            {
                return DirectoryOperationsHelper.IsFileExist(pirFiles) ? pirFiles : string.Empty;
            }

            var tempfile = tempLocation.PhysicalPath + Guid.NewGuid() + ".pdf";
            var combinefiles = new List<string>();
            if (DirectoryOperationsHelper.IsFileExist(pinkFlagFiles))
                combinefiles.Add(pinkFlagFiles);

            if (DirectoryOperationsHelper.IsFileExist(pirFiles))
                combinefiles.Add(pirFiles);

            if (combinefiles.IsNullOrEmpty())
                return string.Empty;

            _pdfGenerator.Merge(tempfile, combinefiles);

            return tempfile;
        }

        private void ConvertMhtToPdf(string sourceFile, string destinationFile, ILogger eventLogger)
        {
            try
            {
                _pdfGenerator.GeneratePdf(sourceFile, destinationFile);
            }
            catch (Exception ex)
            {
                eventLogger.Error("some Error occurred while merging Attestation form");
                eventLogger.Error("Message: " + ex.Message);
                eventLogger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private string GetFocAttestationFileMerge(IEnumerable<string> filesFocAttestation, string focAttestationFile, ILogger eventLogger)
        {
            try
            {
                var tempLocation = _mediaRepository.GetTempMediaFileLocation();
                var tempfile = tempLocation.PhysicalPath + Guid.NewGuid() + ".pdf";
                _pdfGenerator.Merge(tempfile, filesFocAttestation);
                focAttestationFile = tempfile;
            }
            catch (Exception ex)
            {
                eventLogger.Error("some Error occurred while merging Attestation form");
                eventLogger.Error("Message: " + ex.Message);
                eventLogger.Error("Stack Trace: " + ex.StackTrace);
            }
            return focAttestationFile;
        }
    }
}