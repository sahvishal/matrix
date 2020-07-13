using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class CustomerActivityTypeUploadPollingAgent : ICustomerActivityTypeUploadPollingAgent
    {
        private readonly ICustomerActivityTypeUploadRepository _customerActivityTypeUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly ICsvReader _csvReader;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerProfileHistoryRepository _customerProfileHistoryRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private readonly IActivityTypeRepository _activityTypeRepository;
        private readonly IAddressService _addressService;
        private readonly ICallQueueCustomerPubFactory _callQueueCustomerPubFactory;
        private readonly ICallQueueCustomerPublisher _callQueueCustomerPublisher;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ILogger _logger;
        private const int PageSize = 100;

        public CustomerActivityTypeUploadPollingAgent(ILogManager logManager, ICustomerActivityTypeUploadRepository customerActivityTypeUploadRepository, IUniqueItemRepository<File> fileRepository,
            IMediaRepository mediaRepository, ISettings settings, ICsvReader csvReader, ICustomerRepository customerRepository,
            ICustomerProfileHistoryRepository customerProfileHistoryRepository, ICustomerEligibilityRepository customerEligibilityRepository, IActivityTypeRepository activityTypeRepository,
            IAddressService addressService, ICallQueueCustomerPubFactory callQueueCustomerPubFactory, ICallQueueCustomerPublisher callQueueCustomerPublisher, IEventCustomerRepository eventCustomerRepository)
        {
            _customerActivityTypeUploadRepository = customerActivityTypeUploadRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _settings = settings;
            _csvReader = csvReader;
            _customerRepository = customerRepository;
            _customerProfileHistoryRepository = customerProfileHistoryRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
            _activityTypeRepository = activityTypeRepository;
            _addressService = addressService;
            _callQueueCustomerPubFactory = callQueueCustomerPubFactory;
            _callQueueCustomerPublisher = callQueueCustomerPublisher;
            _eventCustomerRepository = eventCustomerRepository;
            _logger = logManager.GetLogger("CustomerActivityTypeUploadPollingAgent");
        }

        public void PollForParsingCustomerActivityTypeUpload()
        {
            try
            {
                var today = DateTime.Now;
                if (_settings.IsDevEnvironment || today.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    _logger.Info("Entering CustomerActivityTypeUpload parse polling agent @:" + today);

                    var customerActivityTypeFilesForParsing = _customerActivityTypeUploadRepository.GetFilesToParse();

                    if (customerActivityTypeFilesForParsing.IsNullOrEmpty())
                    {
                        _logger.Info("No file found for parsing");
                        return;
                    }

                    _logger.Info("No. of files to Parse:" + customerActivityTypeFilesForParsing.Count());

                    var parseFileIds = customerActivityTypeFilesForParsing.Select(x => x.FileId);
                    var uploadedFiles = _fileRepository.GetByIds(parseFileIds);
                    var filesLocation = _mediaRepository.GetCustomerActivityTypeUploadMediaFileLocation();

                    foreach (var customerActivityTypeUploadDomain in customerActivityTypeFilesForParsing)
                    {
                        var failedRecords = new List<CustomerActivityTypeUploadLogViewModel>();
                        try
                        {
                            customerActivityTypeUploadDomain.ParseStartTime = DateTime.Now;
                            var file = uploadedFiles.FirstOrDefault(x => x.Id == customerActivityTypeUploadDomain.FileId);
                            if (file == null)
                            {
                                UpdateParsingStatus(customerActivityTypeUploadDomain, (long)CallUploadStatus.FileNotFound);
                                _logger.Info("Parsing Failed: FileNotFound CustomerActivityTypeUpload Id: " + customerActivityTypeUploadDomain.Id);
                                continue;
                            }

                            var filePhysicalLocation = filesLocation.PhysicalPath + file.Path;

                            if (!System.IO.File.Exists(filePhysicalLocation))
                            {
                                UpdateParsingStatus(customerActivityTypeUploadDomain, (long)CallUploadStatus.FileNotFound);
                                _logger.Info("Parsing Failed, FileNotFound: File: " + file.Path);
                                continue;
                            }

                            var fInfo = new FileInfo(filePhysicalLocation);
                            if (fInfo.Extension != ".csv")
                            {
                                UpdateParsingStatus(customerActivityTypeUploadDomain, (long)CallUploadStatus.InvalidFileFormat);
                                _logger.Info("Parsing Failed: InvalidFileFormat File: " + file.Path);
                                continue;
                            }

                            _logger.Error("Parsing started for File: " + file.Path);

                            UpdateParsingStatus(customerActivityTypeUploadDomain, (long)CallUploadStatus.Parsing, false);

                            var customerEligibleUploadTable = _csvReader.ReadWithTextQualifier(filePhysicalLocation);
                            var recordsInFile = customerEligibleUploadTable.Rows.Count;

                            var totalPages = recordsInFile / PageSize + (recordsInFile % PageSize != 0 ? 1 : 0);
                            _logger.Info("Total no. of Pages: " + totalPages + " , Total Records: " + recordsInFile);
                            var pageNumber = 1;

                            while (pageNumber <= totalPages)
                            {
                                try
                                {
                                    IEnumerable<CustomerActivityTypeUploadLogViewModel> tempParsedRecords = null;
                                    var query = customerEligibleUploadTable.AsEnumerable();
                                    _logger.Info("Parsing For Page Number: " + pageNumber);
                                    var rows = query.Skip(PageSize * (pageNumber - 1)).Take(PageSize);
                                    pageNumber++;

                                    tempParsedRecords = ParseDataTable(rows, failedRecords);

                                    if (tempParsedRecords.IsNullOrEmpty())
                                        continue;

                                    UpdateActivityType(tempParsedRecords, failedRecords, file.UploadedBy.Id);

                                }
                                catch (Exception ex)
                                {
                                    _logger.Info(string.Format("Parsing failed for Page: {0} File name: {1}", pageNumber, file.Path));
                                    _logger.Error("ExceptionMessage: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                                    continue;
                                }
                            }
                            customerActivityTypeUploadDomain.SuccessfullUploadCount = recordsInFile - failedRecords.Count();
                            customerActivityTypeUploadDomain.ParseEndTime = DateTime.Now;
                            customerActivityTypeUploadDomain.StatusId = (long)CallUploadStatus.Parsed;

                            UpdateCustomerActivityTypeUploadDetail(customerActivityTypeUploadDomain, failedRecords, filePhysicalLocation);
                            _logger.Error("Parse Succeeded : File name: " + file.Path);
                        }
                        catch (Exception ex)
                        {
                            var fileDomain = uploadedFiles.FirstOrDefault(x => x.Id == customerActivityTypeUploadDomain.FileId);

                            if (fileDomain != null)
                            {
                                _logger.Error("Failed to parse File , File name: " + fileDomain.Path);
                                var filePhysicalLocation = filesLocation.PhysicalPath + fileDomain.Path;
                                customerActivityTypeUploadDomain.StatusId = (long)CallUploadStatus.ParseFailed;
                                UpdateCustomerActivityTypeUploadDetail(customerActivityTypeUploadDomain, failedRecords, filePhysicalLocation);
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
                    _logger.Info(string.Format("CustomerActivityTypeUpload Parser can not be invoked as time of day is {0}", today.TimeOfDay));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception occurred during execution of CustomerActivityTypeUploadPollingAgent \nException Message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                return;
            }
        }

        private void UpdateActivityType(IEnumerable<CustomerActivityTypeUploadLogViewModel> parsedRecords, List<CustomerActivityTypeUploadLogViewModel> failedRecords, long fileUploader)
        {
            var activities = _activityTypeRepository.GetAll();

            foreach (var parsedRecord in parsedRecords)
            {
                try
                {
                    var customerId = Convert.ToInt64(parsedRecord.CustomerId);

                    if (customerId > 0)
                    {
                        var customer = _customerRepository.GetCustomer(customerId);
                        if (customer != null)
                        {

                            _logger.Info(string.Format("Saving Customer for CustomerId: {0}, ActivityType: {1}, AcesId: {2}", parsedRecord.CustomerId, parsedRecord.ActivityType, parsedRecord.AcesId));
                            var customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(customerId, DateTime.Now.Year);
                            var customerProfileHistoryId = _customerProfileHistoryRepository.CreateCustomerHistory(customerId, fileUploader, customerEligibility);
                            _eventCustomerRepository.UpdateCustomerProfileIdByCustomerId(customer.CustomerId, customerProfileHistoryId);

                            var activityId = !activities.IsNullOrEmpty() ? activities.First(x => parsedRecord.ActivityType.ToLower() == x.Name.ToLower()).Id : (long?)null;

                            customer.ActivityId = activityId;
                            customer.ActivityTypeIsManual = true;
                            _customerRepository.SaveCustomer(customer);

                            var address = _addressService.GetSanitizeAddress(customer.Address);
                            var callQueueCustomer = _callQueueCustomerPubFactory.GetCallQueueCustomerPubViewModel(customer, address);
                            _callQueueCustomerPublisher.UpdateCustomerDetailOnCallQueueResponse(callQueueCustomer);


                            _logger.Info(string.Format("Activity Type saved successfully for CustomerId: {0}, ActivityType: {1}, AcesId: {2}", parsedRecord.CustomerId, parsedRecord.ActivityType, parsedRecord.AcesId));
                        }
                        else
                        {
                            parsedRecord.ErrorMessage = "No Customer found for CustomerId: " + customerId;
                            failedRecords.Add(parsedRecord);
                        }
                    }
                    else
                    {
                        parsedRecord.ErrorMessage = "CustomerId can not be " + parsedRecord.CustomerId;
                        failedRecords.Add(parsedRecord);
                    }
                }
                catch (Exception ex)
                {
                    parsedRecord.ErrorMessage = "Parse failed";
                    failedRecords.Add(parsedRecord);

                    _logger.Info(string.Format("Exception occurred while parsing record, CustomerId: {0} , AcesId: {1}, ActivityType: {2} ", parsedRecord.CustomerId, parsedRecord.AcesId, parsedRecord.ActivityType));
                    _logger.Error("ExceptionMessage: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                }
            }
        }

        private IEnumerable<CustomerActivityTypeUploadLogViewModel> ParseDataTable(IEnumerable<DataRow> rows, List<CustomerActivityTypeUploadLogViewModel> failedRecords)
        {
            var collection = new List<CustomerActivityTypeUploadLogViewModel>();

            foreach (DataRow row in rows)
            {
                var data = GetDataRow(row);
                long customerId = 0;
                if (string.IsNullOrWhiteSpace(data.CustomerId) || !long.TryParse(data.CustomerId, out customerId) || customerId <= 0)
                {
                    data.ErrorMessage = "Invalid " + CustomerActivityTypeUploadColumn.CustomerId;
                }

                //if (string.IsNullOrWhiteSpace(data.AcesId))
                //{
                //    data.ErrorMessage = string.IsNullOrWhiteSpace(data.ErrorMessage) ? "Invalid " + CustomerActivityTypeUploadColumn.AcesId :
                //        data.ErrorMessage + ", Invalid " + CustomerActivityTypeUploadColumn.AcesId;
                //}

                if (string.IsNullOrWhiteSpace(data.ActivityType)
                    || !(data.ActivityType.ToLower() == UploadActivityType.MailOnly.GetDescription().ToLower()
                    || data.ActivityType.ToLower() == UploadActivityType.OnlyCall.GetDescription().ToLower()
                    || data.ActivityType.ToLower() == UploadActivityType.BothMailAndCall.GetDescription().ToLower()
                    || data.ActivityType.ToLower() == UploadActivityType.DoNotCallDoNotMail.GetDescription().ToLower()
                    || data.ActivityType.ToLower() == UploadActivityType.None.GetDescription().ToLower()))
                {
                    data.ErrorMessage = string.IsNullOrWhiteSpace(data.ErrorMessage) ? "Invalid " + CustomerActivityTypeUploadColumn.ActivityType :
                        data.ErrorMessage + ", Invalid " + CustomerActivityTypeUploadColumn.ActivityType;
                }

                if (!string.IsNullOrWhiteSpace(data.ErrorMessage))
                    failedRecords.Add(data);
                else
                    collection.Add(data);

            }
            return collection;
        }

        private CustomerActivityTypeUploadLogViewModel GetDataRow(DataRow row)
        {
            var model = new CustomerActivityTypeUploadLogViewModel
            {
                CustomerId = GetRowValue(row, CustomerActivityTypeUploadColumn.CustomerId),
                AcesId = GetRowValue(row, CustomerActivityTypeUploadColumn.AcesId),
                ActivityType = GetRowValue(row, CustomerActivityTypeUploadColumn.ActivityType)
            };
            return model;
        }

        private long ConvertToLong(string customerIdString)
        {
            long customerId;
            long.TryParse(customerIdString, out customerId);

            return customerId;
        }

        private string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        private void UpdateParsingStatus(CustomerActivityTypeUpload customerActivityTypeUploadDomain, long statusId, bool isCompleted = true)
        {
            customerActivityTypeUploadDomain.StatusId = statusId; ;
            customerActivityTypeUploadDomain.ParseEndTime = DateTime.Now;
            customerActivityTypeUploadDomain.ParseEndTime = isCompleted ? DateTime.Now : (DateTime?)null;

            _customerActivityTypeUploadRepository.Save(customerActivityTypeUploadDomain);
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

        private void UpdateCustomerActivityTypeUploadDetail(CustomerActivityTypeUpload customerActivityTypeUploadDomain, List<CustomerActivityTypeUploadLogViewModel> failedRecordsList, string fileName)
        {
            if (failedRecordsList.Any())
            {
                try
                {
                    var location = _mediaRepository.GetCustomerActivityTypeUploadMediaFileLocation();
                    var failedFilePath = location.PhysicalPath + Path.GetFileNameWithoutExtension(fileName) + "_Failed.csv";
                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CustomerActivityTypeUploadLogViewModel>();
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
                    customerActivityTypeUploadDomain.FailedUploadCount = failedRecordsList.Count();
                    customerActivityTypeUploadDomain.LogFileId = file.Id;
                }
                catch (Exception ex)
                {
                    _logger.Error("Exception Raised while creating failed records CSV\n message: " + ex.Message + " stacktrace: " + ex.StackTrace);
                }
            }
            _customerActivityTypeUploadRepository.Save(customerActivityTypeUploadDomain);
        }
    }
}
