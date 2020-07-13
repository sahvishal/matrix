using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class EligibilityUploadParsePollingAgent : IEligibilityUploadParsePollingAgent
    {
        private readonly IEligibilityUploadRepository _eligibilityUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly ICsvReader _csvReader;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomerEligibilityService _customerEligibilityService;
        private readonly ILogger _logger;
        private const int PageSize = 100;
        private readonly bool _isDevEnvironment;

        const string PatientId = "Patient ID";
        const string EligibilityStatus = "Eligibility status";
        const string EligibilityYear = "Eligibility Year";

        public EligibilityUploadParsePollingAgent(ILogManager logManager, IEligibilityUploadRepository eligibilityUploadRepository, IUniqueItemRepository<File> fileRepository, 
            IMediaRepository mediaRepository,ISettings settings, ICsvReader csvReader, ICustomerRepository customerRepository, ICorporateAccountRepository corporateAccountRepository,
            ICustomerEligibilityService customerEligibilityService)
        {
            _eligibilityUploadRepository = eligibilityUploadRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _settings = settings;
            _csvReader = csvReader;
            _customerRepository = customerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _customerEligibilityService = customerEligibilityService;
            _logger = logManager.GetLogger("EligibilityUploadParsePollingAgent");
            _isDevEnvironment = settings.IsDevEnvironment;
        }


        public void PollForParsingEligibilityUpload()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(3, 0, 0))
                {

                    _logger.Info("Entering EligibilityUpload parse polling agent @:" + timeOfDay);

                    var eligibilityFilesForParsing = (IReadOnlyCollection<EligibilityUpload>)_eligibilityUploadRepository.GetFilesToParse();

                    if (eligibilityFilesForParsing.IsNullOrEmpty())
                    {
                        _logger.Info("No file found for parsing , exiting");
                        return;
                    }

                    _logger.Info("No. of files to Parse:" + eligibilityFilesForParsing.Count());

                    var parseFileIds = eligibilityFilesForParsing.Select(x => x.FileId);
                    var uploadedFiles = (IReadOnlyCollection<File>)_fileRepository.GetByIds(parseFileIds);
                    var filesLocation = _mediaRepository.GetEligibilityUploadMediaFileLocation();
                    var corporateAccounts = (IReadOnlyCollection<CorporateAccount>)_corporateAccountRepository.GetByIds(eligibilityFilesForParsing.Select(x => x.AccountId).Distinct());

                    foreach (var eligibilityUploadDomain in eligibilityFilesForParsing)
                    {
                        var failedRecords = new List<EligibilityUploadLogViewModel>();
                        try
                        {
                            eligibilityUploadDomain.ParseStartTime = DateTime.Now;
                            var fileDomain = uploadedFiles.FirstOrDefault(x => x.Id == eligibilityUploadDomain.FileId);
                            if (fileDomain == null)
                            {
                                UpdateParsingStatus(eligibilityUploadDomain, (long)EligibilityUploadStatus.FileNotFound);
                                _logger.Info("Parsing Failed: FileNotFound EligibilityUpload Id: " + eligibilityUploadDomain.Id);
                                continue;
                            }

                            var corporateAccount = corporateAccounts.FirstOrDefault(x => x.Id == eligibilityUploadDomain.AccountId);
                            if (corporateAccount == null)
                            {
                                UpdateParsingStatus(eligibilityUploadDomain, (long)EligibilityUploadStatus.ParseFailed);
                                _logger.Info("Parsing Failed: Corporate Account not found File name: " + fileDomain.Path + " AccountId: " + eligibilityUploadDomain.AccountId);
                                continue;
                            }

                            var filePhysicalLocation = filesLocation.PhysicalPath + fileDomain.Path;
                            _logger.Info("Parsing for File: " + filePhysicalLocation);

                            if (!System.IO.File.Exists(filePhysicalLocation))
                            {
                                UpdateParsingStatus(eligibilityUploadDomain, (long)EligibilityUploadStatus.FileNotFound);
                                _logger.Info("Parsing Failed: FileNotFound on Physical Storage File name: " + fileDomain.Path);
                                continue;
                            }

                            var fInfo = new FileInfo(filePhysicalLocation);
                            if (fInfo.Extension != ".csv")
                            {
                                UpdateParsingStatus(eligibilityUploadDomain, (long)EligibilityUploadStatus.InvalidFileFormat);
                                _logger.Info("Parsing Failed: InvalidFileFormat File name: " + fileDomain.Path);
                                continue;
                            }

                            _logger.Error("Beginning to Parse File : File name: " + fileDomain.Path);
                            UpdateParsingStatus(eligibilityUploadDomain, (long)EligibilityUploadStatus.Parsing, false);
                            var customerEligibleUploadTable = _csvReader.ReadWithTextQualifier(filePhysicalLocation);
                            var recordsInFile = customerEligibleUploadTable.Rows.Count;

                            var totalPages = recordsInFile / PageSize + (recordsInFile % PageSize != 0 ? 1 : 0);
                            _logger.Info("Total no. of Pages to process: " + totalPages + " ,total records to parse: " + recordsInFile);
                            var pageNumber = 1;

                            while (pageNumber <= totalPages)
                            {
                                try
                                {
                                    IEnumerable<CustomerEligibilityViewModel> tempParsedRecords = null;
                                    var query = customerEligibleUploadTable.AsEnumerable();
                                    _logger.Info("Parsing For Page Number: " + pageNumber);
                                    var rows = query.Skip(PageSize * (pageNumber - 1)).Take(PageSize);
                                    pageNumber++;

                                    //failedRecords is updated for invalid CustomerId and Year while parsed
                                    tempParsedRecords = ParseEligibilityDataTable(rows, failedRecords);

                                    if (tempParsedRecords.IsNullOrEmpty())
                                        continue;

                                    UpdateEligibilityStatus(tempParsedRecords, failedRecords, corporateAccount, fileDomain.UploadedBy.Id);

                                }
                                catch (Exception ex)
                                {
                                    _logger.Info(string.Format("Parsing failed for Page: {0} File name: {1}", pageNumber, fileDomain.Path));
                                    _logger.Error("ExceptionMessage: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                                    continue;
                                }
                            }
                            eligibilityUploadDomain.SuccessfullUploadCount = recordsInFile - failedRecords.Count();
                            eligibilityUploadDomain.ParseEndTime = DateTime.Now;
                            eligibilityUploadDomain.StatusId = (long)EligibilityUploadStatus.Parsed;

                            UpdateEligibilityUploadDetail(eligibilityUploadDomain, failedRecords, filePhysicalLocation);
                            _logger.Error("Parse Succeeded : File name: " + fileDomain.Path);
                        }
                        catch (Exception ex)
                        {
                            var fileDomain = uploadedFiles.FirstOrDefault(x => x.Id == eligibilityUploadDomain.FileId);

                            if (fileDomain != null)
                            {
                                _logger.Error("Failed to parse File , File name: " + fileDomain.Path);
                                var filePhysicalLocation = filesLocation.PhysicalPath + fileDomain.Path;
                                eligibilityUploadDomain.StatusId = (long)EligibilityUploadStatus.ParseFailed;
                                UpdateEligibilityUploadDetail(eligibilityUploadDomain, failedRecords, filePhysicalLocation);
                            }
                            else
                                _logger.Error("Record does not exist in file table");

                            _logger.Error("ExceptionMessage: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                            continue;
                        }
                    }
                }
                else
                {
                    _logger.Info(string.Format("Eligibility Upload Parser can not be invoked as time of day is {0}", timeOfDay.TimeOfDay));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception occurred during execution of polling agent\nException Message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                return;
            }
        }

        private void UpdateEligibilityStatus(IEnumerable<CustomerEligibilityViewModel> parsedRecords, List<EligibilityUploadLogViewModel> failedRecords, CorporateAccount corporateAccount, long fileUploader)
        {
            IEnumerable<EligibilityUploadCustomerDataViewModel> customerIdAndTags = null;
            try
            {
                IEnumerable<long> customerIds = parsedRecords.Select(x => x.CustomerId).ToArray();
                customerIdAndTags = _customerRepository.GetCustomerDataForEligibilityUpload(customerIds);
            }
            catch (Exception ex)
            {
                failedRecords.AddRange(parsedRecords.Select(record => new EligibilityUploadLogViewModel
                {
                    CustomerId = record.CustomerId.ToString(),
                    ErrorMessage = "Batch processing failed",
                    ForYear = record.ForYear.ToString(),
                    IsEligible = record.IsEligible
                }));

                _logger.Error("Exception occurred while getting Customer Data from database.");
                _logger.Error("ExceptionMessage: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                return;
            }

            foreach (var parsedRecord in parsedRecords)
            {
                try
                {
                    var customerIdAndTag = customerIdAndTags.FirstOrDefault(x => x.CustomerId == parsedRecord.CustomerId);
                    if (customerIdAndTag != null)
                    {
                        if (customerIdAndTag.Tag == corporateAccount.Tag)
                        {
                            bool? isEligible = null;
                            if (string.Compare(parsedRecord.IsEligible, "yes", StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                isEligible = true;
                            }
                            else if (string.Compare(parsedRecord.IsEligible, "no", StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                isEligible = false;
                            }

                            _customerEligibilityService.Save(parsedRecord.CustomerId, parsedRecord.ForYear, isEligible, fileUploader, _logger, true);
                        }
                        else
                        {
                            failedRecords.Add(new EligibilityUploadLogViewModel
                            {
                                CustomerId = parsedRecord.CustomerId.ToString(),
                                ErrorMessage = "Customer is not member of Account :" + corporateAccount.Name,
                                ForYear = parsedRecord.ForYear.ToString(),
                                IsEligible = parsedRecord.IsEligible
                            });
                        }
                    }
                    else
                    {
                        failedRecords.Add(new EligibilityUploadLogViewModel
                        {
                            CustomerId = parsedRecord.CustomerId.ToString(),
                            ErrorMessage = "No patient found for this patient Id",
                            ForYear = parsedRecord.ForYear.ToString(),
                            IsEligible = parsedRecord.IsEligible
                        });
                    }
                }
                catch (Exception ex)
                {
                    failedRecords.Add(new EligibilityUploadLogViewModel
                    {
                        CustomerId = parsedRecord.CustomerId.ToString(),
                        ErrorMessage = "Parse failed",
                        ForYear = parsedRecord.ForYear.ToString(),
                        IsEligible = parsedRecord.IsEligible
                    });
                    _logger.Info(string.Format("Exception occurred while parsing record, CustomerId: {0} , Year: {1}, IsEligible: {2} ", parsedRecord.CustomerId, parsedRecord.ForYear, parsedRecord.IsEligible));
                    _logger.Error("ExceptionMessage: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                    continue;
                }
            }
        }

        private IEnumerable<CustomerEligibilityViewModel> ParseEligibilityDataTable(IEnumerable<DataRow> rows, List<EligibilityUploadLogViewModel> failedRecords)
        {
            var collection = new List<CustomerEligibilityViewModel>();

            foreach (DataRow row in rows)
            {
                var data = GetDataRow(row);
                if (data.CustomerId == 0)
                {
                    failedRecords.Add(new EligibilityUploadLogViewModel
                    {
                        CustomerId = GetRowValue(row, PatientId),
                        ForYear = GetRowValue(row, EligibilityYear),
                        IsEligible = GetRowValue(row, EligibilityStatus),
                        ErrorMessage = "Invalid Patient Id"
                    });
                    continue;
                }
                if (data.ForYear == 0)
                {
                    failedRecords.Add(new EligibilityUploadLogViewModel
                    {
                        CustomerId = GetRowValue(row, PatientId),
                        ForYear = GetRowValue(row, EligibilityYear),
                        IsEligible = GetRowValue(row, EligibilityStatus),
                        ErrorMessage = "Invalid Eligibility Year"
                    });
                    continue;
                }
                if (string.IsNullOrEmpty(data.IsEligible))
                {
                    failedRecords.Add(new EligibilityUploadLogViewModel
                    {
                        CustomerId = GetRowValue(row, PatientId),
                        ForYear = GetRowValue(row, EligibilityYear),
                        IsEligible = GetRowValue(row, EligibilityStatus),
                        ErrorMessage = "Eligibility status not provided"
                    });
                    continue;
                }

                if (string.Compare(data.IsEligible, "yes", StringComparison.InvariantCultureIgnoreCase) != 0 
                    && string.Compare(data.IsEligible, "no", StringComparison.InvariantCultureIgnoreCase) != 0
                    && string.Compare(data.IsEligible, "n/a", StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    failedRecords.Add(new EligibilityUploadLogViewModel
                    {
                        CustomerId = GetRowValue(row, PatientId),
                        ForYear = GetRowValue(row, EligibilityYear),
                        IsEligible = GetRowValue(row, EligibilityStatus),
                        ErrorMessage = "Eligibility Status should be Yes,No or N/A"
                    });
                    continue;
                }
                collection.Add(data);
            }
            return collection;
        }

        private CustomerEligibilityViewModel GetDataRow(DataRow row)
        {
            var statusString = GetRowValue(row, EligibilityStatus);

            var customerEligibility = new CustomerEligibilityViewModel
            {
                CustomerId = ConvertToLong(GetRowValue(row, PatientId)),
                ForYear = ConvertToInt(GetRowValue(row, EligibilityYear)),
                IsEligible = statusString.Trim()
            };
            return customerEligibility;
        }

        private long ConvertToLong(string customerIdString)
        {
            long customerId;
            long.TryParse(customerIdString, out customerId);

            return customerId;
        }

        private int ConvertToInt(string year)
        {
            int integer;
            int.TryParse(year, out integer);

            return integer;
        }

        private string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        private void UpdateParsingStatus(EligibilityUpload eligibilityUploadDomain, long statusId, bool isCompleted = true)
        {
            eligibilityUploadDomain.StatusId = statusId; ;
            eligibilityUploadDomain.ParseEndTime = DateTime.Now;
            eligibilityUploadDomain.ParseEndTime = isCompleted ? DateTime.Now : (DateTime?)null;

            _eligibilityUploadRepository.Save(eligibilityUploadDomain);
        }

        private void WriteCsv<T>(string fileName, CSVExporter<T> exporter, IEnumerable<T> modelData)
        {
            var csvStringBuilder = new StringBuilder();
            csvStringBuilder.Append(exporter.Header + Environment.NewLine);
            foreach (string line in exporter.ExportObjects(modelData))
            {
                csvStringBuilder.Append(line + Environment.NewLine);
            }
            System.IO.File.AppendAllText(fileName, csvStringBuilder.ToString());
        }

        private void UpdateEligibilityUploadDetail(EligibilityUpload eligibilityUploadDomain, List<EligibilityUploadLogViewModel> failedRecordsList, string fileName)
        {
            if (failedRecordsList.Any())
            {
                try
                {
                    var location = _mediaRepository.GetEligibilityUploadMediaFileLocation();
                    var failedFilePath = location.PhysicalPath + Path.GetFileNameWithoutExtension(fileName) + "_Failed.csv";
                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<EligibilityUploadLogViewModel>();
                    WriteCsv(failedFilePath, exporter, failedRecordsList);
                    var failedRecords = new FileInfo(failedFilePath);
                    var file = new File
                    {
                        Path = failedRecords.Name,
                        FileSize = failedRecords.Length,
                        Type = FileType.Csv,
                        UploadedBy = new OrganizationRoleUser(1),
                        UploadedOn = DateTime.Now
                    };
                    file = _fileRepository.Save(file);
                    eligibilityUploadDomain.FailedUploadCount = failedRecordsList.Count();
                    eligibilityUploadDomain.LogFileId = file.Id;
                }
                catch (Exception ex)
                {
                    _logger.Error("Exception Raised while creating failed records CSV\n message: " + ex.Message + " stacktrace: " + ex.StackTrace);
                }
            }
            _eligibilityUploadRepository.Save(eligibilityUploadDomain);
        }
    }
}