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
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using DomainFile = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IHafGenerationPollingAgent))]
    public class HafGenerationPollingAgent : IHafGenerationPollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IUniqueItemRepository<DomainFile> _fileRepository;
        private readonly ICustomerRepository _customerRepository;

        private const int NumberOfPagesToExtractFromAcePdf = 3;
        

        public HafGenerationPollingAgent(IEventRepository eventRepository, IMediaRepository mediaRepository, IEventCustomerRepository eventCustomerRepository, IPdfGenerator pdfGenerator, ISettings settings, ILogManager logManager,
            IConfigurationSettingRepository configurationSettingRepository, ICorporateAccountRepository corporateAccountRepository, IUniqueItemRepository<DomainFile> fileRepository, ICustomerRepository customerRepository)
        {
            _eventRepository = eventRepository;
            _mediaRepository = mediaRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _pdfGenerator = pdfGenerator;
            _settings = settings;
            _pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
            _logger = logManager.GetLogger("Health_Assessment_Form_Generator");
            _configurationSettingRepository = configurationSettingRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _fileRepository = fileRepository;
            _customerRepository = customerRepository;
        }

        public void PollforHealthAssessmentFormGeneration()
        {
            try
            {
                //_pdfGenerator.PaperSize = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PaperSize);

                //foreach (var eventId in eventIds)
                //{
                //    try
                //    {
                //        _logger.Info("Generating HAF for Event Id: " + eventId);
                //        var mediaLocation = _mediaRepository.GetMedicalHistoryMediaLocation(eventId);
                //        if (mediaLocation.PhysicalPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                //            throw new InvalidDirectoryPathException();
                //        var files = Directory.GetFiles(mediaLocation.PhysicalPath);

                //        foreach (var file in files)
                //        {
                //            File.Delete(file);
                //        }
                //        var account = _corporateAccountRepository.GetbyEventId(eventId);
                //        var corporateSurveyPdf = "";
                //        if (account != null && account.CaptureSurvey)
                //        {
                //            if (account.SurveyPdfFileId > 0)
                //            {
                //                var surveyPdf = _fileRepository.GetById(account.SurveyPdfFileId);
                //                if (surveyPdf != null)
                //                    corporateSurveyPdf = _mediaRepository.GetCorporateSurveyPdfFolderLocation().PhysicalPath + surveyPdf.Path;
                //            }
                //        }
                //        var corporateCheckListPdf = "";

                //        var filesFocAttestation = new[] { "" };
                //        var mediaLocFocAttestation = _mediaRepository.GetUnlockEventsParseLocation(eventId);

                //        if (Directory.Exists(mediaLocFocAttestation.PhysicalPath))
                //        {
                //            filesFocAttestation = Directory.GetFiles(mediaLocFocAttestation.PhysicalPath, "*.pdf");
                //            filesFocAttestation = filesFocAttestation.Where(fsd => !string.IsNullOrEmpty(fsd)).ToArray();
                //        }

                //        var tempMediaLocation = _mediaRepository.GetTempMediaFileLocation();

                //        var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);

                //        if (eventCustomers != null && eventCustomers.Any())
                //        {
                //            eventCustomers = eventCustomers.Where(ec => ec.AppointmentId.HasValue).ToArray();

                //            if (eventCustomers != null && eventCustomers.Any())
                //            {
                //                var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

                //                int index = 0;
                //                foreach (var eventCustomer in eventCustomers)
                //                {
                //                    _logger.Info(string.Format("Generating HAF for Event Id: {0} and Customer Id : {1} ", eventId, eventCustomer.CustomerId));
                //                    string url = _settings.HealthAssessmentFormUrl + string.Format("?eventId={0}&customerId={1}&LoadLayout=false&showKynEditModel=true&bulkPrint=true&removeChache={2}", eventCustomer.EventId, eventCustomer.CustomerId, Guid.NewGuid());

                //                    var customer = customers.First(c => c.CustomerId == eventCustomer.CustomerId);

                //                    var focAttestationFile = string.Empty;

                //                    if (account != null)
                //                    {
                //                        if (account.Id == _settings.WellmedAccountId || account.Id == _settings.WellmedWellCareAccountId)
                //                        {
                //                            var memberId = string.IsNullOrEmpty(customer.InsuranceId) ? "" : customer.InsuranceId.ToLower().Trim();
                //                            focAttestationFile = filesFocAttestation.FirstOrDefault(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileNameWithoutExtension(fsd).ToLower().Trim() == memberId);
                //                        }
                //                        else if (account.Id == _settings.MolinaAccountId)
                //                        {
                //                            var hicn = string.IsNullOrEmpty(customer.Hicn) ? "" : customer.Hicn.ToLower().Trim();

                //                            focAttestationFile = filesFocAttestation.FirstOrDefault(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileNameWithoutExtension(fsd).ToLower().Trim() == hicn);
                //                        }
                //                        else if (account.Id == _settings.HcpNvAccountId)
                //                        {
                //                            var memberId = string.IsNullOrEmpty(customer.InsuranceId) ? "" : customer.InsuranceId.ToLower().Trim();

                //                            if (!string.IsNullOrEmpty(memberId))
                //                            {
                //                                focAttestationFile = GetFocAttestationFile(filesFocAttestation, memberId.ToLower(), focAttestationFile);
                //                            }
                //                        }
                //                        else if (_settings.MonarchAccountIds.Contains(account.Id))
                //                        {
                //                            var gmpi = string.IsNullOrEmpty(customer.AdditionalField4) ? "" : customer.AdditionalField4.ToLower().Trim();

                //                            if (!string.IsNullOrEmpty(gmpi))
                //                            {
                //                                focAttestationFile = GetFocAttestationFile(filesFocAttestation, "_" + gmpi.ToLower(), focAttestationFile);
                //                            }
                //                        }
                //                        else if (account.Id == _settings.AppleCareAccountId)
                //                        {
                //                            focAttestationFile = GetFocAttestationFile(filesFocAttestation, customer.CustomerId.ToString(), focAttestationFile);
                //                        }
                //                    }

                //                    var focAttestationFilePath = string.Empty;

                //                    _logger.Info("focAttestationFile: " + focAttestationFile);

                //                    if (!string.IsNullOrEmpty(focAttestationFile))
                //                        focAttestationFilePath = focAttestationFile;

                //                    var annualComprehensiveExamPdf = string.Empty;
                //                    var memberInformationProfilePdf = string.Empty;

                //                    if (!string.IsNullOrEmpty(customer.Hicn))
                //                    {
                //                        var fileNamePattern = customer.Hicn + (customer.Name != null ? "_" + customer.Name.LastName + "_" + customer.Name.FirstName : "");
                //                        if (account != null && account.PrintAceForm)
                //                        {
                //                            try
                //                            {
                //                                var mediaLocationForAce = _mediaRepository.GetAceMipLocation(account.FolderName, fileNamePattern, "ACE");
                //                                var aceFiles = Directory.GetFiles(mediaLocationForAce.PhysicalPath, fileNamePattern + "*_ACE.pdf");
                //                                if (aceFiles.Any())
                //                                {
                //                                    annualComprehensiveExamPdf = _pdfGenerator.ExtractPdfPagesFromEnd(aceFiles.First(), tempMediaLocation.PhysicalPath + "Ripped_" + customer.Hicn + "_ACE.pdf", NumberOfPagesToExtractFromAcePdf);
                //                                }
                //                            }
                //                            catch (Exception ex)
                //                            {
                //                                _logger.Error(string.Format("Unable to attach ACE form to the bulk HAF for CustomerID : {0}\nMessage : {1}", customer.CustomerId, ex.Message));
                //                            }
                //                        }
                //                        if (account != null && account.PrintMipForm)
                //                        {
                //                            try
                //                            {
                //                                var mediaLocationForMip = _mediaRepository.GetAceMipLocation(account.FolderName, fileNamePattern, "MIP");
                //                                var mipFiles = Directory.GetFiles(mediaLocationForMip.PhysicalPath, fileNamePattern + "*_MIP.pdf");
                //                                if (mipFiles.Any())
                //                                {
                //                                    memberInformationProfilePdf = mipFiles.First();
                //                                }
                //                            }
                //                            catch (Exception ex)
                //                            {
                //                                _logger.Error(string.Format("Unable to attach MIP to the bulk HAF for CustomerID : {0}\nMessage : {1}", customer.CustomerId, ex.Message));
                //                            }
                //                        }
                //                    }

                //                    _pdfGenerator.GeneratePdfForHaf(url, mediaLocation.PhysicalPath + (++index).ToString("000.") + eventCustomer.CustomerId + ".pdf", corporateSurveyPdf, "", focAttestationFilePath, corporateCheckListPdf,
                //                        annualComprehensiveExamPdf, memberInformationProfilePdf);

                //                }

                //                _logger.Info("Merging HAF for Event Id: " + eventId);
                //                _pdfGenerator.GetPdffilesfromLocationandMergeintoOne(mediaLocation.PhysicalPath, mediaLocation.PhysicalPath + "Event_" + eventId + ".pdf");
                //                _eventRepository.SetAfterGenrateHealthAssesmentForm(eventId);

                //                index = 0;

                //                foreach (var eventCustomer in eventCustomers)
                //                {
                //                    DirectoryOperationsHelper.Delete(mediaLocation.PhysicalPath + (++index).ToString("000.") + eventCustomer.CustomerId + ".pdf");
                //                }
                //            }
                //            else
                //            {
                //                _logger.Info("No customer found with appointment attached with this event. Merging HAF for Event Id: " + eventId);
                //                _eventRepository.SetAfterGenrateHealthAssesmentForm(eventId);
                //            }

                //        }
                //        else
                //        {
                //            _logger.Info("No customer found attached with this event. Merging HAF for Event Id: " + eventId);
                //            _eventRepository.SetAfterGenrateHealthAssesmentForm(eventId);
                //        }

                //    }
                //    catch (Exception ex)
                //    {
                //        _logger.Error("\n" + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
                //    }

                //}

            }
            catch (Exception ex)
            {
                _logger.Error("\n" + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
            }
        }

        private string GetFocAttestationFile(IEnumerable<string> filesFocAttestation, string selector, string focAttestationFile)
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
                    _logger.Error("some Error occurred while merging Attestation form");
                    _logger.Error("Message: " + ex.Message);
                    _logger.Error("Stack Trace: " + ex.StackTrace);
                }
            }
            return focAttestationFile;
        }


    }
}