using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    class PhoneNumberUpdatePollingAgent : IPhoneNumberUpdatePollingAgent
    {
        private readonly ICustomerPhoneNumberUpdateUploadRepository _customerPhoneNumberUpdateUploadRepository;
        private readonly ILogger _logger;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly ICustomerService _customerService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPhoneNumberFactory _phoneNumberFactory;
        private readonly ICustomerPhoneNumberUpdateUploadLogRepository _customerPhoneNumberUpdateUploadLogRepository;
        private readonly ICustomerNotesService _customerNotesService;

        private const string _phoneTypeHome = "home";
        private const string _phoneTypeCell = "cell";

        private const string LogHeader = PhoneNumberUpdateUploadLogColumn.CustomerId + "," +
                                        PhoneNumberUpdateUploadLogColumn.FirstName + "," +
                                        PhoneNumberUpdateUploadLogColumn.LastName + "," +
                                        PhoneNumberUpdateUploadLogColumn.DOB + "," +
                                        PhoneNumberUpdateUploadLogColumn.MemberId + "," +
                                        PhoneNumberUpdateUploadLogColumn.PhoneNumber + "," +
                                        PhoneNumberUpdateUploadLogColumn.PhoneType + "," +
                                        "ErrorMessage";

        public PhoneNumberUpdatePollingAgent(ICustomerPhoneNumberUpdateUploadRepository customerPhoneNumberUpdateUploadRepository, IUniqueItemRepository<File> fileRepository,
            IMediaRepository mediaRepository, ICsvReader csvReader, ICustomerService customerService, ICustomerRepository customerRepository, IPhoneNumberFactory phoneNumberFactory,
            ICustomerPhoneNumberUpdateUploadLogRepository customerPhoneNumberUpdateUploadLogRepository, ILogManager logManager, ICustomerNotesService customerNotesService)
        {
            _customerPhoneNumberUpdateUploadRepository = customerPhoneNumberUpdateUploadRepository;
            _logger = logManager.GetLogger("PhoneNumber_Update");
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _csvReader = csvReader;
            _customerService = customerService;
            _customerRepository = customerRepository;
            _phoneNumberFactory = phoneNumberFactory;
            _customerPhoneNumberUpdateUploadLogRepository = customerPhoneNumberUpdateUploadLogRepository;
            _customerNotesService = customerNotesService;
        }

        public void PollForPhoneNumberUpdate()
        {
            _logger.Info("Starting Customer Phone Number Update Service : DateTime :" + DateTime.Now);
            var uploadedFilesInfo = _customerPhoneNumberUpdateUploadRepository.GetUploadedFilesInfo();

            var phoneNumberUpdateFilesLocation = _mediaRepository.GetCustomerPhoneNumberUploadLocation();
            if (uploadedFilesInfo.IsNullOrEmpty())
            {
                _logger.Info("No new Files Uploaded");
                return;
            }

            foreach (var uploadFileInfo in uploadedFilesInfo)    //parsing all Uploaded Status Files
            {
                var failedRecords = new StringBuilder();
                failedRecords.Append(LogHeader + Environment.NewLine);
                var successCount = 0L;

                try
                {
                    var fileInfo = GetFile(uploadFileInfo.FileId);
                    if (!System.IO.File.Exists(phoneNumberUpdateFilesLocation.PhysicalPath + fileInfo.Path))
                    {
                        uploadFileInfo.StatusId = (long)PhoneNumberUploadStatus.FileNotFound;
                        _customerPhoneNumberUpdateUploadRepository.Save(uploadFileInfo);

                        _logger.Info("File not found : " + phoneNumberUpdateFilesLocation.PhysicalPath + fileInfo.Path);
                        continue;
                    }
                    _logger.Info("Importing File : " + fileInfo.Path);

                    uploadFileInfo.StatusId = (long)PhoneNumberUploadStatus.Parsing;
                    uploadFileInfo.ParseStartTime = DateTime.Now;
                    _customerPhoneNumberUpdateUploadRepository.Save(uploadFileInfo);

                    DataTable table = _csvReader.CsvToDataTable(phoneNumberUpdateFilesLocation.PhysicalPath + fileInfo.Path, true);

                    if (table.Rows.Count <= 0)
                    {
                        _logger.Info("No rows found in File : " + fileInfo.Path + " having FileId :" + uploadFileInfo.FileId);
                        uploadFileInfo.ParseEndTime = DateTime.Now;

                        uploadFileInfo.StatusId = (long)PhoneNumberUploadStatus.ParseFailed;
                        _customerPhoneNumberUpdateUploadRepository.Save(uploadFileInfo);
                        continue;
                    }

                    foreach (DataRow row in table.Rows)         //Parsing Records in File
                    {
                        var errorRow = "";
                        var phoneNumberUploadLog = new CustomerPhoneNumberUpdateUploadLog();
                        try
                        {
                            var customerId = 0L;
                            var phoneNumber = "";
                            var phoneNumberType = "";
                            var phoneNumberDomain = new PhoneNumber();
                            var customer = new Customer();
                            bool isCustomerIdProvided = false;

                            var model = GetPhoneNumberUpdateLogModel(row);
                            errorRow = model.CustomerId + "," +
                                               model.FirstName + "," +
                                               model.LastName + "," +
                                               model.DOB + "," +
                                               model.MemberId + "," +
                                               model.PhoneNumber + "," +
                                               model.PhoneType;

                            GetFileRowForLog(phoneNumberUploadLog, model, uploadFileInfo.Id);

                            #region CustomerId
                            try                 //CustomerId
                            {
                                if (!string.IsNullOrEmpty(model.CustomerId))
                                {
                                    Int64.TryParse(model.CustomerId, out customerId);
                                    if (customerId == 0)
                                    {
                                        const string errorMessage = "Invalid Customer Id";
                                        SaveUploadLogToDb(phoneNumberUploadLog, errorMessage);

                                        failedRecords.Append(errorRow + "," + errorMessage + Environment.NewLine);
                                        continue;
                                    }
                                    isCustomerIdProvided = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                const string errorMessage = "Error importing CustomerId";
                                SaveUploadLogToDb(phoneNumberUploadLog, errorMessage + " Exception Message: " + ex.Message);

                                _logger.Error(errorMessage);
                                _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                                failedRecords.Append(errorRow + "," + "CustomerId Invalid" + Environment.NewLine);
                                continue;
                            }
                            #endregion

                            if (!isCustomerIdProvided)
                            {
                                if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName)
                                    || string.IsNullOrEmpty(model.DOB) || string.IsNullOrEmpty(model.MemberId))
                                {
                                    const string errorMessage = "Incomplete customer data.";
                                    SaveUploadLogToDb(phoneNumberUploadLog, errorMessage);

                                    failedRecords.Append(errorRow + "," + errorMessage + Environment.NewLine);
                                    continue;
                                }
                            }

                            #region PhoneNumber
                            try                 //PhoneNumber
                            {
                                phoneNumber = ToNumber(model.PhoneNumber);
                                if (string.IsNullOrEmpty(phoneNumber))
                                {
                                    const string errorMessage = "Invalid phone number";
                                    SaveUploadLogToDb(phoneNumberUploadLog, errorMessage);

                                    failedRecords.Append(errorRow + "," + errorMessage + Environment.NewLine);
                                    continue;
                                }
                            }
                            catch (Exception ex)
                            {
                                const string errorMessage = "Error importing PhoneNumber";
                                SaveUploadLogToDb(phoneNumberUploadLog, errorMessage + " Exception Message: " + ex.Message);

                                failedRecords.Append(errorRow + "," + "Invalid Phone Number" + Environment.NewLine);

                                _logger.Error(errorMessage);
                                _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                                continue;
                            }

                            #endregion

                            #region PhoneNumberType
                            try                 //Phone Type (requirement was for only Home and Cell phone numbers)
                            {
                                phoneNumberType = model.PhoneType;
                                if (string.IsNullOrEmpty(phoneNumberType))
                                {
                                    const string errorMessage = "Phone type should be Home or Cell";
                                    SaveUploadLogToDb(phoneNumberUploadLog, errorMessage);

                                    failedRecords.Append(errorRow + "," + errorMessage + Environment.NewLine);
                                    continue;
                                }

                                if (phoneNumberType.ToLower() != _phoneTypeHome.ToLower() && phoneNumberType.ToLower() != _phoneTypeCell.ToLower())
                                {
                                    const string errorMessage = "Phone type should be Home or Cell";
                                    SaveUploadLogToDb(phoneNumberUploadLog, errorMessage);

                                    failedRecords.Append(errorRow + "," + errorMessage + Environment.NewLine);
                                    continue;
                                }
                            }
                            catch (Exception ex)
                            {
                                const string errorMessage = "Error importing PhoneType";
                                SaveUploadLogToDb(phoneNumberUploadLog, errorMessage + " Exception Message: " + ex.Message);

                                failedRecords.Append(errorRow + "," + "Phone type should be Home or Cell" + Environment.NewLine);

                                _logger.Error(errorMessage);
                                _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                                continue;
                            }

                            #endregion

                            #region CreatePhoneNumber
                            // Creating Phone Number
                            try
                            {
                                var phoneNumberTypeEnumValue = (phoneNumberType.ToLower() == _phoneTypeHome.ToLower()) ? PhoneNumberType.Home : PhoneNumberType.Mobile;
                                phoneNumberDomain = _phoneNumberFactory.CreatePhoneNumber(phoneNumber, phoneNumberTypeEnumValue);

                                if (phoneNumberDomain.PhoneNumberType == PhoneNumberType.Unknown)
                                {
                                    const string errorMessage = "Phone number not valid";
                                    SaveUploadLogToDb(phoneNumberUploadLog, errorMessage);

                                    failedRecords.Append(errorRow + "," + errorMessage + Environment.NewLine);
                                    continue;
                                }
                            }
                            catch (Exception ex)
                            {
                                const string errorMessage = "Error while Creating PhoneNumberDomain";
                                SaveUploadLogToDb(phoneNumberUploadLog, errorMessage + " Exception Message: " + ex.Message);

                                failedRecords.Append(errorRow + "," + "Phone number not valid" + Environment.NewLine);

                                _logger.Error(errorMessage);
                                _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                                continue;
                            }

                            #endregion

                            #region Get Customer
                            try
                            {
                                var dob = new DateTime();
                                if (isCustomerIdProvided)
                                    customer = _customerRepository.GetCustomer(customerId);
                                else
                                {
                                    try
                                    {
                                        dob = Convert.ToDateTime(model.DOB);
                                    }
                                    catch (Exception ex)
                                    {
                                        const string errorMessage = "Invalid date format";
                                        SaveUploadLogToDb(phoneNumberUploadLog, errorMessage + " Exception Message: " + ex.Message);

                                        failedRecords.Append(errorRow + "," + errorMessage + Environment.NewLine);
                                        continue;
                                    }

                                    try
                                    {
                                        customer = _customerRepository.GetCustomerForPhoneNumberUpdate(model.FirstName, model.LastName, dob, model.MemberId);
                                    }
                                    catch (Exception ex)
                                    {
                                        const string errorMessage = "No record present for this data.";
                                        SaveUploadLogToDb(phoneNumberUploadLog, errorMessage + " Exception Message: " + ex.Message);

                                        failedRecords.Append(errorRow + "," + errorMessage + Environment.NewLine);
                                        continue;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                const string errorMessage = "No record present for this CustomerId";
                                SaveUploadLogToDb(phoneNumberUploadLog, errorMessage + " Exception Message: " + ex.Message);

                                failedRecords.Append(errorRow + "," + errorMessage + Environment.NewLine);
                                continue;
                            }
                            #endregion

                            #region Saving Data
                            try
                            {
                                var shouldSaveNotes = customer.IsIncorrectPhoneNumber;
                                if (phoneNumberType.ToLower() == _phoneTypeHome.ToLower())
                                {
                                    customer.HomePhoneNumber = phoneNumberDomain;
                                }
                                else
                                {
                                    customer.MobilePhoneNumber = phoneNumberDomain;
                                }
                                customer.IsIncorrectPhoneNumber = false;
                                customer.IncorrectPhoneNumberMarkedDate = null;

                                //saves CustomerProfile and Creates History and Updates CallQueueCustomer
                                _customerService.SaveCustomer(customer, uploadFileInfo.UploadedByOrgRoleUserId);

                                if (shouldSaveNotes)
                                {
                                    _customerNotesService.SavePhoneNumberUpdatedMessage(customer.CustomerId, uploadFileInfo.UploadedByOrgRoleUserId);
                                }

                                SaveUploadLogToDb(phoneNumberUploadLog, "");        //Log Success
                                successCount++;

                            }
                            catch (Exception ex)
                            {
                                const string errorMessage = "Error while saving Details";
                                SaveUploadLogToDb(phoneNumberUploadLog, errorMessage + " Exception Message: " + ex.Message);

                                failedRecords.Append(errorRow + "," + "Save Failed" + Environment.NewLine);

                                _logger.Error(errorMessage);
                                _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                                continue;
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            const string errorMessage = "Some Error Occurred";
                            SaveUploadLogToDb(phoneNumberUploadLog, errorMessage + " Exception Message: " + ex.Message);

                            failedRecords.Append(errorRow + "," + "Save Failed" + Environment.NewLine);

                            _logger.Error(errorMessage);
                            _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                            continue;
                        }
                    }

                    if (successCount < table.Rows.Count)
                    {
                        var logFileName = "FailRecords_" + fileInfo.Path;
                        var logFile = SaveLogFile(phoneNumberUpdateFilesLocation.PhysicalPath + logFileName, failedRecords);
                        uploadFileInfo.LogFileId = logFile.Id;
                    }

                    uploadFileInfo.SuccessUploadCount = successCount;
                    uploadFileInfo.FailedUploadCount = table.Rows.Count - successCount;
                    uploadFileInfo.ParseEndTime = DateTime.Now;
                    uploadFileInfo.StatusId = successCount > 0 ? (long)PhoneNumberUploadStatus.Parsed : (long)PhoneNumberUploadStatus.ParseFailed;
                    _customerPhoneNumberUpdateUploadRepository.Save(uploadFileInfo);
                }
                catch (Exception ex)
                {
                    uploadFileInfo.StatusId = (long)PhoneNumberUploadStatus.ParseFailed;
                    _customerPhoneNumberUpdateUploadRepository.Save(uploadFileInfo);
                    _logger.Error("Parse Failed while parsing File , FileId:" + uploadFileInfo.FileId);
                    _logger.Error("Ex Message" + ex.Message);
                    _logger.Error("Ex Stack Trace " + ex.StackTrace);
                }
            }
        }

        private File GetFile(long fileId)
        {
            var file = _fileRepository.GetById(fileId);
            return file;
        }

        private CustomerPhoneNumberUpdateUploadLog GetPhoneNumberUpdateLogModel(DataRow row)
        {
            var model = new CustomerPhoneNumberUpdateUploadLog
            {
                CustomerId = GetRowValue(row, PhoneNumberUpdateUploadLogColumn.CustomerId),
                FirstName = GetRowValue(row, PhoneNumberUpdateUploadLogColumn.FirstName),
                LastName = GetRowValue(row, PhoneNumberUpdateUploadLogColumn.LastName),
                DOB = GetRowValue(row, PhoneNumberUpdateUploadLogColumn.DOB),
                MemberId = GetRowValue(row, PhoneNumberUpdateUploadLogColumn.MemberId),
                PhoneNumber = GetRowValue(row, PhoneNumberUpdateUploadLogColumn.PhoneNumber),
                PhoneType = GetRowValue(row, PhoneNumberUpdateUploadLogColumn.PhoneType)
            };
            return model;
        }

        private static string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        private File SaveLogFile(string logFilePath, StringBuilder csvStringBuilder)
        {
            WriteCsv(logFilePath, csvStringBuilder);

            var failedRecords = new FileInfo(logFilePath);

            var file = new File
            {
                Path = failedRecords.Name,
                FileSize = failedRecords.Length,
                Type = FileType.Csv,
                UploadedBy = new OrganizationRoleUser(1),
                UploadedOn = DateTime.Now
            };
            file = _fileRepository.Save(file);

            return file;
        }

        private void WriteCsv(string fileName, StringBuilder csvStringBuilder)
        {
            System.IO.File.AppendAllText(fileName, csvStringBuilder.ToString());
        }

        private void GetFileRowForLog(CustomerPhoneNumberUpdateUploadLog phoneNumberUploadLog, CustomerPhoneNumberUpdateUploadLog model, long uploadId)
        {
            phoneNumberUploadLog.CustomerId = model.CustomerId;
            phoneNumberUploadLog.DOB = model.DOB;
            phoneNumberUploadLog.FirstName = model.FirstName;
            phoneNumberUploadLog.LastName = model.LastName;
            phoneNumberUploadLog.MemberId = model.MemberId;
            phoneNumberUploadLog.PhoneNumber = model.PhoneNumber;
            phoneNumberUploadLog.PhoneType = model.PhoneType;
            phoneNumberUploadLog.UploadId = uploadId;
            phoneNumberUploadLog.IsSuccessful = false;
        }

        private void SaveUploadLogToDb(CustomerPhoneNumberUpdateUploadLog domain, string errorMessage)
        {
            if (errorMessage == "")
            {
                domain.IsSuccessful = true;
                domain.ErrorMessage = null;
            }
            else
            {
                domain.ErrorMessage = errorMessage;
            }
            _customerPhoneNumberUpdateUploadLogRepository.Save(domain);
        }

        private string ToNumber(string number)
        {
            var cleanPhone = number.Replace("(", "").Replace(")", "").Replace("-", "");
            cleanPhone = cleanPhone.Replace("_", "");
            if (cleanPhone.Length != 10)
                number = "";
            else
                number = cleanPhone;

            return number;
        }
    }
}