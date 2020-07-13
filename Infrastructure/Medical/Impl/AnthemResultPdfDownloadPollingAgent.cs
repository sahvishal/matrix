using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

using Doc = WebSupergoo.ABCpdf10.Doc;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class AnthemResultPdfDownloadPollingAgent : IAnthemResultPdfDownloadPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IResultPdfDownloadPollingAgentHelper _resultPdfDownloaderHelper;
        private readonly IPgpFileEncryptionHelper _pgpFileEncryptionHelper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateTagRepository _corporateTagRepository;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;

        private readonly ILogger _logger;

        private readonly string _customSettingFile;
        private readonly DateTime _cutOfDate;

        private readonly string _resultPostedToPlanPath;
        private readonly IResultPdfFileHelper _resultPdfFileHelper;
        private readonly IXmlSerializer<ResultPdfNotPosted> _resultPdfNotPostedSerializer;
        private readonly IResultPdfEmailNotificationHelper _resultPdfEmailNotificationHelper;

        private readonly ICustomerResultPosedService _customerResultPosedService;

        private readonly IMedicareApiService _medicareApiService;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        private readonly IEnumerable<long> _accountIds;
        private readonly int _maxPagesinBatch;
        private readonly DateTime _cutOfDateForSendingReport;

        private readonly string _crosswalkFilePath;
        private readonly int _crosswalkFileYear;

        private const int MaxCustomerinBatch = 134;

        public AnthemResultPdfDownloadPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, ISettings settings, ILogManager logManager,
            IMediaRepository mediaRepository, ICustomSettingManager customSettingManager, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            IResultPdfDownloadPollingAgentHelper resultPdfDownloaderHelper, IPgpFileEncryptionHelper pgpFileEncryptionHelper, ICustomerRepository customerRepository,
            IEventRepository eventRepository, ICorporateTagRepository corporateTagRepository, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer,
            IResultPdfFileHelper resultPdfFileHelper, IXmlSerializer<ResultPdfNotPosted> resultPdfNotPostedSerializer,
            IResultPdfEmailNotificationHelper resultPdfEmailNotificationHelper, ICustomerResultPosedService customerResultPosedService,
            IMedicareApiService medicareApiService, IEventCustomerRepository eventCustomerRepository)
        {
            _cutOfDate = settings.AnthemDownloadCutOfDate;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _settings = settings;
            _mediaRepository = mediaRepository;
            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;

            _resultPdfDownloaderHelper = resultPdfDownloaderHelper;
            _pgpFileEncryptionHelper = pgpFileEncryptionHelper;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _corporateTagRepository = corporateTagRepository;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _resultPostedToPlanPath = settings.ResultPostedToPlanPath;
            _resultPdfFileHelper = resultPdfFileHelper;

            _logger = logManager.GetLogger("Anthem_ResultPdf");

            _accountIds = settings.AnthemAccountIds;

            _customSettingFile = settings.PcpResultPdfDownloadSettings;
            _resultPdfNotPostedSerializer = resultPdfNotPostedSerializer;
            _resultPdfEmailNotificationHelper = resultPdfEmailNotificationHelper;

            _customerResultPosedService = customerResultPosedService;

            _medicareApiService = medicareApiService;
            _eventCustomerRepository = eventCustomerRepository;

            _cutOfDateForSendingReport = settings.AnthemCutOfDateForSendingReport;

            _maxPagesinBatch = settings.BatchPageSize;

            _crosswalkFilePath = settings.CrosswalkFilePath;
            _crosswalkFileYear = settings.CrosswalkFileYear;


        }

        private ResultPdfPostedXml _resultPdfPostedXml = null;

        private List<AnthemPdfCrossWalkVeiwModel> _anthemPdfCrossWalkVeiwModel = null;
        private ResultPdfNotPosted _resultPdfNotPosted = null;
        private CustomSettings _customSettings = null;

        public void PollForPdfDownload()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty())
                {
                    _logger.Info("Account Ids Can not be empty: ");
                    return;
                }

                var accounts = _corporateAccountRepository.GetByIds(_accountIds);

                if (accounts.IsNullOrEmpty())
                {
                    _logger.Info("No valid account Found");
                    return;
                }

                var destinationFolderPdf = _settings.AnthemDownloadPath;
                destinationFolderPdf = Path.Combine(destinationFolderPdf, "pdf");

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFolderPdf);

                foreach (var corporateAccount in accounts)
                {
                    PostResultAccountWise(corporateAccount, destinationFolderPdf);
                }

                CreateEobFile(_anthemPdfCrossWalkVeiwModel, destinationFolderPdf);
                CreateCrossWalkFile(destinationFolderPdf, _anthemPdfCrossWalkVeiwModel);

                _resultPdfPostedXml = null;
                _anthemPdfCrossWalkVeiwModel = null;
                _resultPdfNotPosted = null;
                _customSettings = null;

            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("some error occured Exception Message: \n{0}, \n stack Trace: \n\t {1} ", exception.Message, exception.StackTrace));
            }
        }

        private void PostResultAccountWise(CorporateAccount corporateAccount, string destinationFolderPdf)
        {
            try
            {
                _resultPdfPostedXml = null;
                //_anthemPdfCrossWalkVeiwModel = null;
                _resultPdfNotPosted = null;

                var customerResultObject = new AnthemResultPostedViewModel
                {
                    Tag = corporateAccount.Tag,
                    DestinationFilePath = destinationFolderPdf,
                    ExportToTime = DateTime.Now.AddHours(-1),
                    CorporateAccount = corporateAccount,
                };

                var customerResults = GetEventCustomersToPostResult(customerResultObject);

                foreach (var ecr in customerResults)
                {
                    try
                    {
                        customerResultObject.EventCustomerResult = ecr;
                        SetSourcePath(customerResultObject);

                        if (File.Exists(customerResultObject.SourceFilePath))
                        {
                            var ec = _eventCustomerRepository.GetById(ecr.Id);
                            if (ec.AwvVisitId.HasValue)
                            {
                                try
                                {
                                    _logger.Info(" fetching NPI info for VistId :" + ec.AwvVisitId.Value);
                                    var visitDetails = new EhrAssignedNursePractitionerDetails
                                    {
                                        VisitId = ec.AwvVisitId.Value
                                    };

                                   // var model = _medicareApiService.PostAnonymous<EhrAssignedNursePractitionerDetails>(_settings.MedicareApiUrl + MedicareApiUrl.AssignedNursePractitionerDetails, visitDetails);
                                    var npi = string.Empty;
                                    if (!string.IsNullOrWhiteSpace(npi))
                                    {
                                        customerResultObject.Npi = npi;
                                        _logger.Info("NPI: " + npi + " for VistId :" + ec.AwvVisitId.Value);
                                    }
                                    else
                                    {
                                        var mssage =  "NPI Is Null or Empty";
                                        mssage = mssage + " for visit id: " + ec.AwvVisitId.Value;
                                        _logger.Info(mssage);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error("exception while fetching NPI information");
                                    _logger.Error("Message: " + ex.Message);
                                    _logger.Error("stack Trace: " + ex.StackTrace);
                                    AddToResultNotPosted(customerResultObject);
                                    continue;
                                }
                            }

                            SetEventCustomerDetail(customerResultObject);

                            SetDestinationFileNameWithoutExt(customerResultObject);

                            PostResultPdf(customerResultObject);
                        }
                        else
                        {
                            AddToResultNotPosted(customerResultObject);
                        }

                    }
                    catch (Exception exception)
                    {
                        _logger.Error(string.Format("some error occurred for the customerId {0}, {1},\n Message {2} \n Stack Trace {3}",
                            ecr.CustomerId, ecr.EventId, exception.Message, exception.StackTrace));
                    }
                }

                SaveExportStartTime(customerResultObject);

                CreateResultPostedLoger(corporateAccount);

                SetResultPostedList(corporateAccount.Tag, _resultPdfPostedXml);

                SaveResultNotPosted(corporateAccount.Tag);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("some error occurred for custom tag: {0} Exception Message: \n{1}, \n stack Trace: \n\t {2} ", corporateAccount.Id, ex.Message, ex.StackTrace));
            }
            finally
            {
                _resultPdfPostedXml = null;
                //_anthemPdfCrossWalkVeiwModel = null;
                _resultPdfNotPosted = null;
                _customSettings = null;
            }
        }
        private IEnumerable<EventCustomerResult> GetEventCustomersToPostResult(AnthemResultPostedViewModel resultObject)
        {
            var corporatTags = _corporateTagRepository.GetByCustomTags(_settings.AnthemCustomTags);

            var eventCustomerResults = GetFreshCustomerResultToPost(corporatTags, resultObject);

            var customerResults = GetFinalEventCustomers(resultObject.Tag, eventCustomerResults);

            if (customerResults == null || !customerResults.Any())
            {
                _logger.Info(string.Format("No event customer result list for {0} Result Pdf Download.", resultObject.Tag));
                return eventCustomerResults;
            }

            _logger.Info(string.Format("Found {0} customers for {1} Result Pdf Download. ", customerResults.Count(), resultObject.Tag));
            return eventCustomerResults;
        }

        private void CreateResultPostedLoger(CorporateAccount corporateAccount)
        {
            if (_resultPdfPostedXml != null && !_resultPdfPostedXml.Customer.IsNullOrEmpty())
            {
                _logger.Info("Result posted Log for " + corporateAccount.Tag);
                _resultPdfPostedXml = _resultPdfFileHelper.CorrectMissingRecords(_resultPdfPostedXml);

                var pdfLogfile = string.Format(_settings.PdfLogFilePath, corporateAccount.FolderName);
                pdfLogfile = Path.Combine(pdfLogfile, "Download");

                try
                {
                    _resultPdfFileHelper.CreateCsvForFileShared(_resultPdfPostedXml.Customer, pdfLogfile,
                        corporateAccount.Tag + "_PdfLogFile");
                }
                catch (Exception ex)
                {
                    _logger.Error("some error occurred");
                    _logger.Error("exception: " + ex.Message);
                    _logger.Error("stack trace: " + ex.StackTrace);
                }

                _logger.Info("Result posted Log Completed for " + corporateAccount.Tag);
            }
        }

        private void SetSourcePath(AnthemResultPostedViewModel customerResultObject)
        {
            var ecr = customerResultObject.EventCustomerResult;

            var pcpResultReport = _mediaRepository.GetPdfFileNameForPcpResultReport();
            var healthPlanResultReport = _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

            var sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + healthPlanResultReport;

            if (!DirectoryOperationsHelper.IsFileExist(sourcePath))
            {
                sourcePath = _mediaRepository.GetPremiumVersionResultPdfLocation(ecr.EventId, ecr.CustomerId).PhysicalPath + pcpResultReport;
            }

            customerResultObject.SourceFilePath = sourcePath;
        }

        private void SetEventCustomerDetail(AnthemResultPostedViewModel customerResultObject)
        {

            var ecr = customerResultObject.EventCustomerResult;

            int pageCountInPdf = GetPdfPageCount(customerResultObject.SourceFilePath);

            if ((customerResultObject.TotalFilesInBatch <= 0 || ((customerResultObject.TotalFilesInBatch + pageCountInPdf) > _maxPagesinBatch)) || (customerResultObject.TotalCustomersInBatch <= 0 || customerResultObject.TotalCustomersInBatch > MaxCustomerinBatch))
            {
                customerResultObject.TotalFilesInBatch = 0;
                customerResultObject.TotalCustomersInBatch = 0;
                customerResultObject.BatchName = "IC" + DateTime.Now.ToString("yyyyMMddhhmmss");
            }

            customerResultObject.TotalFilesInBatch = customerResultObject.TotalFilesInBatch + pageCountInPdf;

            var customerData = _customerRepository.GetCustomer(ecr.CustomerId);
            var eventData = _eventRepository.GetById(ecr.EventId);

            customerResultObject.TotalCustomersInBatch++;

            customerResultObject.JulianDateFormate = GetJulianDate(ecr);
            customerResultObject.Identification = GetIdentificationNumber(ecr);
            customerResultObject.EventCustomerResult = ecr;
            customerResultObject.EventCustomerId = ecr.Id;

            customerResultObject.PagesInfile = pageCountInPdf;
            customerResultObject.Customer = customerData;
            customerResultObject.Event = eventData;


            DirectoryOperationsHelper.CreateDirectoryIfNotExist(customerResultObject.DestinationPathWithBatchName);
        }

        private IEnumerable<EventCustomerResult> GetFreshCustomerResultToPost(IEnumerable<CorporateTag> corporatTags, AnthemResultPostedViewModel resultObject)
        {
            string[] customTags = null;
            var corporateAccount = resultObject.CorporateAccount;
            if (!corporatTags.IsNullOrEmpty())
            {
                customTags = corporatTags.Where(x => x.CorporateId == corporateAccount.Id).Select(x => x.Tag).ToArray();
            }

            _logger.Info(string.Format("Generating for accountId {0} and account tag {1}. ", corporateAccount.Id, corporateAccount.Tag));

            var exportFromTime = GetExportStartTime(resultObject.Tag);

            //in case of Anthem (Anthem-CA) we send all files
            if (corporateAccount.Id == _settings.AnthemAccountId)
            {
                customTags = null;
            }

            DateTime? stopSendingPdftoHealthPlanDate = null;
            if (corporateAccount.IsHealthPlan)
            {
                stopSendingPdftoHealthPlanDate = _settings.StopSendingPdftoHealthPlanDate;
            }

            var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false,
                    resultObject.ExportToTime, exportFromTime, corporateAccount.Id, corporateAccount.Tag, true, customTags, true, true, _cutOfDateForSendingReport, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

            return eventCustomerResults;
        }

        private DateTime GetExportStartTime(string tag)
        {
            var customSettings = GetCustomSettings(tag);
            var exportFromTime = customSettings.LastTransactionDate ?? _cutOfDate;
            return exportFromTime;
        }

        private CustomSettings GetCustomSettings(string tag)
        {
            if (_customSettings == null)
            {
                var customSettingFilePath = string.Format(_customSettingFile, tag);

                _customSettings = _customSettingManager.Deserialize(customSettingFilePath);
            }

            return _customSettings;
        }

        private void SaveExportStartTime(AnthemResultPostedViewModel customerResultObject)
        {
            var customSettingFilePath = string.Format(_customSettingFile, customerResultObject.Tag);
            var customSettings = GetCustomSettings(customerResultObject.Tag);
            customSettings.LastTransactionDate = customerResultObject.ExportToTime;

            _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);
        }

        private void SetDestinationFileNameWithoutExt(AnthemResultPostedViewModel customerResultObject)
        {
            var customerData = customerResultObject.Customer;
            var ecr = customerResultObject.EventCustomerResult;
            var corporateAccount = customerResultObject.CorporateAccount;

            var patientMemerId = string.IsNullOrEmpty(customerData.InsuranceId) ? "No_MemberId_" + ecr.CustomerId : customerData.InsuranceId;

            var fileName = "_" + patientMemerId + "-" + customerResultObject.UniqueIdetificationDocketNumber;


            if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                fileName += "_" + corporateAccount.PennedBackText;

            customerResultObject.DestinationFileNameWithoutExt = fileName;

            SetFileNameWithVersion(customerResultObject);
        }

        private void SetFileNameWithVersion(AnthemResultPostedViewModel customerResultObject)
        {
            if (_resultPdfPostedXml == null)
            {
                GetResultPostedList(customerResultObject.Tag);
            }

            var ecr = customerResultObject.EventCustomerResult;
            var fileName = customerResultObject.DestinationFileNameWithoutExt;

            fileName = _resultPdfFileHelper.GetFileName(_resultPdfPostedXml.Customer, ecr, fileName, (long)ResultFormatType.PDF, false);

            fileName = GenerateNameForFilePostd(customerResultObject.BatchName, fileName, customerResultObject.CorporateAccount.Id);

            customerResultObject.DestinationFileNameWithoutExt = fileName;
        }

        private void GetResultPostedList(string tag)
        {
            var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", tag));
            var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
            _resultPdfPostedXml = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;
        }

        private void SetResultPostedList(string tag, ResultPdfPostedXml resultPdfPosted)
        {
            var resultPostedToPlanFileName = Path.Combine(_resultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", tag));
            _resultPdfPostedSerializer.SerializeandSave(resultPostedToPlanFileName, resultPdfPosted);
        }

        private void AddToResultNotPosted(AnthemResultPostedViewModel customerResultObject)
        {
            if (_resultPdfNotPosted == null)
            {
                _resultPdfNotPosted = new ResultPdfNotPosted { EventCustomer = new List<EventCustomerInfo>() };
            }
            var ecr = customerResultObject.EventCustomerResult;

            _resultPdfNotPosted.EventCustomer.Add(new EventCustomerInfo
                                        {
                                            EventCustomerId = ecr.Id,
                                            EventId = ecr.EventId,
                                            CustomerId = ecr.CustomerId,
                                            Error = "file not Moved on HIP SFTP."
                                        });

        }

        private string GetResultNotPostedXmlFilePath(string tag)
        {
            var resultNotPostedFileName = string.Format("ResultNotPostedto_{0}.xml", tag);
            var xmlFilePath = Path.Combine(_settings.ResultNotPostedToPlanPath, resultNotPostedFileName);

            return xmlFilePath;
        }

        private IEnumerable<EventCustomerResult> GetFinalEventCustomers(string tag, IEnumerable<EventCustomerResult> newEventCustomerResult)
        {

            var xmlFilePath = GetResultNotPostedXmlFilePath(tag);

            var resultNotPosted = _resultPdfNotPostedSerializer.Deserialize(xmlFilePath);
            if (resultNotPosted == null || resultNotPosted.EventCustomer.IsNullOrEmpty())
            {
                return newEventCustomerResult;
            }

            var eventCustomerIds = resultNotPosted.EventCustomer.Select(x => x.EventCustomerId);

            if (!newEventCustomerResult.IsNullOrEmpty())
            {
                var freshCustomerEventCustomerIds = newEventCustomerResult.Select(x => x.Id);
                eventCustomerIds = (from q in eventCustomerIds where !freshCustomerEventCustomerIds.Contains(q) select q).ToList();
            }

            var resultNotPostedEventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsByIdsAndResultState(eventCustomerIds, (int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false);

            if (resultNotPostedEventCustomerResults.IsNullOrEmpty())
                return newEventCustomerResult;

            return newEventCustomerResult.IsNullOrEmpty() ? resultNotPostedEventCustomerResults.ToArray() : newEventCustomerResult.Concat(resultNotPostedEventCustomerResults).ToArray();

        }

        private void SaveResultNotPosted(string tag)
        {
            var filePath = GetResultNotPostedXmlFilePath(tag);
            DirectoryOperationsHelper.DeleteFileIfExist(filePath);

            if (_resultPdfNotPosted != null)
            {
                _resultPdfNotPostedSerializer.SerializeandSave(GetResultNotPostedXmlFilePath(tag), _resultPdfNotPosted);

                if (_resultPdfNotPosted.EventCustomer.Count > 0)
                    _resultPdfEmailNotificationHelper.SendEmailNotificationForFileNotPosted(tag, _resultPdfNotPosted.EventCustomer.Count, _logger);

                _resultPdfNotPosted = null;
            }

        }

        private void PostResultPdf(AnthemResultPostedViewModel resultPostedViewModel)
        {
            var ecr = resultPostedViewModel.EventCustomerResult;
            var pdfResultFile = resultPostedViewModel.DestinationPdfFileName;
            var corporateAccount = resultPostedViewModel.CorporateAccount;
            var sourceFile = resultPostedViewModel.SourceFilePath;

            if (DirectoryOperationsHelper.IsFileExist(sourceFile))
            {
                try
                {
                    _resultPdfDownloaderHelper.ExportResultInPdfFormat(pdfResultFile, resultPostedViewModel.SourceFilePath, resultPostedViewModel.DestinationPathWithBatchName);

                    var pgpFilePath = _pgpFileEncryptionHelper.EncryptFile(corporateAccount, pdfResultFile);
                    var finalFilePosted = Path.GetFileName(pgpFilePath);

                    WriteTransactFile(resultPostedViewModel);
                    AddToCrosswalkList(resultPostedViewModel);

                    var customerInfo = _resultPdfFileHelper.GetCustomerInfo(resultPostedViewModel.Event, finalFilePosted, (long)ResultFormatType.PDF, resultPostedViewModel.Customer, ecr.Id);
                    AddToResultPosted(corporateAccount.Tag, customerInfo);

                    var destination = Path.Combine(resultPostedViewModel.DestinationPathWithBatchName, pdfResultFile);

                    _logger.Info("Source: " + resultPostedViewModel.SourceFilePath);
                    _logger.Info("destination: " + destination);
                }
                catch (Exception ex)
                {
                    _logger.Error("result not posted for Customer Id: " + ecr.CustomerId + " and event Id " + ecr.EventId);
                    _logger.Error(string.Format("some error occurred: Message {0} \\n Stack Trace: {1} ", ex.Message, ex.StackTrace));

                    AddToResultNotPosted(resultPostedViewModel);
                }
            }
            else
            {
                _logger.Info(string.Format("File not generated or removed for the Customer Id: {0}, Event Id: {1}", ecr.CustomerId, ecr.EventId));
                AddToResultNotPosted(resultPostedViewModel);
            }
        }


        private void WriteTransactFile(AnthemResultPostedViewModel anthemResultPostedView)
        {
            if (DirectoryOperationsHelper.IsDirectoryExist(anthemResultPostedView.DestinationPathWithBatchName))
            {
                var transactFile = Path.Combine(anthemResultPostedView.DestinationPathWithBatchName, "transact.dat");
                if (DirectoryOperationsHelper.IsFileExist(transactFile))
                {
                    AppentTransactFile(anthemResultPostedView, transactFile);
                }
                else
                {
                    CreatNewTransactFile(anthemResultPostedView, transactFile);
                }
            }
        }

        private string FormateDate(DateTime? dateTime)
        {
            if (!dateTime.HasValue) return string.Empty;

            return dateTime.Value.ToString("MM/dd/yyyy");
        }


        private void CreatNewTransactFile(AnthemResultPostedViewModel anthemResultPostedView, string filePath)
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                var tranactRow = GetTransactEntry(anthemResultPostedView);
                sw.WriteLine(tranactRow);
            }
        }

        private void AppentTransactFile(AnthemResultPostedViewModel anthemResultPostedView, string filePath)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                var tranactRow = GetTransactEntry(anthemResultPostedView);
                sw.WriteLine(tranactRow);
            }
        }

        private string GetTransactEntry(AnthemResultPostedViewModel anthemResultPostedView)
        {
            var eventData = anthemResultPostedView.Event;
            var customer = anthemResultPostedView.Customer;
            var dcnNumber = anthemResultPostedView.DocketNumber;
            var edncNumber = anthemResultPostedView.EDocketNumber;
            var batchName = anthemResultPostedView.BatchName;
            var fileName = anthemResultPostedView.DestinationPdfFileName;

            var memberId = string.IsNullOrWhiteSpace(customer.InsuranceId) ? customer.CustomerId.ToString() : customer.InsuranceId;

            var sb = new StringBuilder();
            sb.Append("131:" + anthemResultPostedView.Npi + ",Commercial,SCAN," + FormateDate(eventData.EventDate) + ",,," + FormateDate(customer.DateOfBirth) + ",,,,"
                      + anthemResultPostedView.Npi + ",,,,CORRO,," + FormateDate(eventData.EventDate) + ",,,,,,,,,," + dcnNumber + "," + batchName + "," + memberId + ",," + edncNumber + ",,,HLTHFAIR,,application/pdf::" + fileName);

            return sb.ToString();
        }

        private void AddToCrosswalkList(AnthemResultPostedViewModel resultPostedViewModel)
        {
            if (_anthemPdfCrossWalkVeiwModel == null)
                _anthemPdfCrossWalkVeiwModel = new List<AnthemPdfCrossWalkVeiwModel>();

            _anthemPdfCrossWalkVeiwModel.Add(new AnthemPdfCrossWalkVeiwModel
            {
                FileName = resultPostedViewModel.DestinationPdfFileName,
                DateOfAssessment = resultPostedViewModel.Event.EventDate,
                DateOfTransferred = DateTime.Today,
                PageCount = resultPostedViewModel.PagesInfile,
                Dcn = resultPostedViewModel.DocketNumber,
                Batch = resultPostedViewModel.BatchName
            });
        }
        private void AddToResultPosted(string tag, CustomerInfo customerInfo)
        {
            if (_resultPdfPostedXml == null)
            {
                GetResultPostedList(tag);
            }
            _resultPdfPostedXml.Customer.Add(customerInfo);
        }

        private string RemoveIllegalFileChar(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            return fileName
                .Replace('/', ' ')
                .Replace('\\', ' ')
                .Replace('*', ' ')
                .Replace('.', ' ')
                .Replace('"', ' ')
                .Replace('[', ' ')
                .Replace(']', ' ')
                .Replace(':', ' ')
                .Replace(';', ' ')
                .Replace('|', ' ')
                .Replace('=', ' ')
                .Replace(',', ' ')
                .Replace('?', ' ')
                .Replace('<', ' ')
                .Replace('>', ' ')
                .Trim();
        }

        private DateTime GetPdfGenerationDate(EventCustomerResult ecr)
        {
            return ecr.RegenerationDate.HasValue ? ecr.RegenerationDate.Value : ecr.DataRecorderMetaData.DateModified.Value;
        }

        private string GetJulianDate(EventCustomerResult eventCustomerResult)
        {
            var pdfGeneration = GetPdfGenerationDate(eventCustomerResult);
            var calendar = new JulianCalendar();
            return pdfGeneration.ToString("yy") + calendar.GetDayOfYear(pdfGeneration).ToString("000");
        }

        private long GetIdentificationNumber(EventCustomerResult eventCustomerResult)
        {
            var resultPosted = _customerResultPosedService.GetCusterResultPosted(eventCustomerResult.CustomerId);
            return resultPosted.ResultPostId;
        }

        private string GenerateNameForFilePostd(string batchName, string fileName, long accountId)
        {
            var marketName = GetMarketName(accountId);
            if (string.IsNullOrWhiteSpace(marketName))
                return RemoveIllegalFileChar("HLTHFAIR_RAHIX_" + batchName + fileName);
            else
                return RemoveIllegalFileChar("HLTHFAIR_RAHIX_" + marketName + "_" + batchName + fileName);
        }



        private int GetPdfPageCount(string sourcePath)
        {
            var sourceDocPdfDoc = new Doc();
            try
            {
                sourceDocPdfDoc.Read(sourcePath);
                return sourceDocPdfDoc.PageCount;
            }
            finally
            {
                sourceDocPdfDoc.Clear();
                sourceDocPdfDoc.Dispose();
            }
        }

        private void CreateEobFile(List<AnthemPdfCrossWalkVeiwModel> anthemPdfCrossWalkList, string destinationFolderPath)
        {
            if (anthemPdfCrossWalkList != null)
            {
                var batchFiles = anthemPdfCrossWalkList.Select(x => x.Batch).Distinct()
                    .ToArray();

                if (batchFiles.Any())
                {
                    foreach (var batchFile in batchFiles)
                    {
                        var sb = new StringBuilder();
                        var batchNode = anthemPdfCrossWalkList.Where(x => x.Batch == batchFile);
                        sb.Append("../" + batchFile);
                        sb.Append(" " + batchNode.Count());
                        sb.Append(" " + batchNode.Sum(x => x.PageCount));

                        //var batchFoler = Path.Combine(destinationFolderPath, batchFile);

                        var eobFilePath = Path.Combine(destinationFolderPath, batchFile + ".eob");

                        using (var f = new StreamWriter(eobFilePath))
                        {
                            f.WriteLine(sb.ToString());
                        }
                    }
                }
            }
        }

        private void CreateCrossWalkFile(string csvFilePath, IEnumerable<AnthemPdfCrossWalkVeiwModel> modelData)
        {
            try
            {
                if (modelData.IsNullOrEmpty())
                {
                    _logger.Info("No Data found to generate crosswalk file ");
                    return;
                }
                try
                {
                    DirectoryOperationsHelper.DeleteFiles(csvFilePath, "CrosswalkFile_*.csv");
                }
                catch (Exception exception)
                {
                    _logger.Error(" While deleting old files");
                    _logger.Error("message: " + exception);
                    _logger.Error("stack Trace: " + exception.StackTrace);
                }

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(_crosswalkFilePath);
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(csvFilePath);

                var filePath = Path.Combine(_crosswalkFilePath, "CrosswalkFile_" + _crosswalkFileYear + ".csv");

                bool createHeaderRow = !DirectoryOperationsHelper.IsFileExist(filePath);

                _logger.Info("File Path: " + filePath);

                if (createHeaderRow)
                {
                    _logger.Info("Header info being created");
                }

                var csvFileName = Path.Combine(csvFilePath, "CrosswalkFile_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv");

                using (var streamWriter = new StreamWriter(filePath, append: !createHeaderRow))
                {
                    var members = (typeof(AnthemPdfCrossWalkVeiwModel)).GetMembers();

                    if (createHeaderRow)
                    {
                        var header = new List<string>();
                        foreach (var memberInfo in members)
                        {
                            if (memberInfo.MemberType != MemberTypes.Property)
                                continue;

                            var propInfo = (memberInfo as PropertyInfo);
                            if (propInfo != null)
                            {
                                if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                                    continue;
                            }
                            else
                                continue;

                            string propertyName = memberInfo.Name;
                            bool isHidden = false;

                            var attributes = propInfo.GetCustomAttributes(false);
                            if (!attributes.IsNullOrEmpty())
                            {
                                foreach (var attribute in attributes)
                                {
                                    if (attribute is HiddenAttribute)
                                    {
                                        isHidden = true;
                                        break;
                                    }
                                    if (attribute is DisplayNameAttribute)
                                    {
                                        propertyName = (attribute as DisplayNameAttribute).DisplayName;
                                    }
                                }
                            }

                            if (isHidden) continue;

                            header.Add(propertyName);
                        }

                        streamWriter.Write(string.Join(",", header.ToArray()) + Environment.NewLine);
                    }

                    var sanitizer = new CSVSanitizer();
                    foreach (var model in modelData)
                    {
                        var values = new List<string>();
                        foreach (var memberInfo in members)
                        {
                            if (memberInfo.MemberType != MemberTypes.Property)
                                continue;

                            var propInfo = (memberInfo as PropertyInfo);
                            if (propInfo != null)
                            {
                                if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                                    continue;
                            }
                            else
                                continue;


                            bool isHidden = false;
                            FormatAttribute formatter = null;

                            var attributes = propInfo.GetCustomAttributes(false);
                            if (!attributes.IsNullOrEmpty())
                            {
                                foreach (var attribute in attributes)
                                {
                                    if (attribute is HiddenAttribute)
                                    {
                                        isHidden = true;
                                        break;
                                    }
                                    if (attribute is FormatAttribute)
                                    {
                                        formatter = (FormatAttribute)attribute;
                                    }
                                }
                            }

                            if (isHidden) continue;
                            var obj = propInfo.GetValue(model, null);
                            if (obj == null)
                                values.Add(string.Empty);
                            else if (formatter != null)
                                values.Add(formatter.ToString(obj));
                            else
                                values.Add(sanitizer.EscapeString(obj.ToString()));
                        }
                        streamWriter.Write(string.Join(",", values.ToArray()) + Environment.NewLine);
                    }

                    streamWriter.Close();

                    _logger.Info("crosswalk .csv has been created at following location: ");
                    _logger.Info(filePath);

                    if (DirectoryOperationsHelper.IsFileExist(filePath))
                    {
                        DirectoryOperationsHelper.DeleteFileIfExist(csvFileName);
                        DirectoryOperationsHelper.Copy(filePath, csvFileName);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("While Generating crosswalk file: message " + ex.Message + " stack trace:  " + ex.StackTrace);
            }
        }


        private string GetMarketName(long accountId)
        {
            return string.Empty;

            //dont remove this code as client some time asked to add Market name in file in that case only un comm
            //var orderPairList = new List<OrderedPair<long, string>>
            //{
            //    new OrderedPair<long, string>(1034, "CA"),
            //    new OrderedPair<long, string>(1068, "CT"),
            //    new OrderedPair<long, string>(1070, "GA"),
            //    new OrderedPair<long, string>(1071, "NV"),
            //    new OrderedPair<long, string>(1072, "OH"),
            //    new OrderedPair<long, string>(1073, "VA"),
            //    new OrderedPair<long, string>(1074, "ME"),
            //    new OrderedPair<long, string>(1117, "CO"),
            //};

            //var pair = orderPairList.FirstOrDefault(x => x.FirstValue == accountId);
            //if (pair == null) return string.Empty;

            //return pair.SecondValue;
        }
    }
}