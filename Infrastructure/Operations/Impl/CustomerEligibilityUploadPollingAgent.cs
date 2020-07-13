using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;


namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class CustomerEligibilityUploadPollingAgent : ICustomerEligibilityUploadPollingAgent
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerEligibilityService _customerEligibilityService;
        private readonly ICorporateUploadHelper _corporateUploadHelper;

        private const long OrgRoleId = 1;
        private const string CustomerEligibilityYes = "Yes";
        private const string CustomerEligibilityNo = "No";

        public CustomerEligibilityUploadPollingAgent(IMediaRepository mediaRepository, ISettings settings, IPipeDelimitedReportHelper pipeDelimitedReportHelper, ILogManager logManager,
            ICustomerRepository customerRepository, ICustomerEligibilityService customerEligibilityService, ICorporateUploadHelper corporateUploadHelper)
        {
            _mediaRepository = mediaRepository;
            _settings = settings;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _customerRepository = customerRepository;
            _customerEligibilityService = customerEligibilityService;
            _corporateUploadHelper = corporateUploadHelper;

            _logger = logManager.GetLogger("CustomerEligibilityUploadService");
        }

        public void PollForCustomerEligibilityUpload()
        {
            try
            {
                if (_settings.StopCustomerEligibilityUpload)
                {
                    _logger.Info("Customer Eligibility Upload Polling Agent stopped @:" + DateTime.Now);    
                    return;
                }

                _logger.Info("Entering Customer Eligibility Upload Polling Agent @:" + DateTime.Now);

                var sftpFileLocation = _settings.CustomerEligibilityUploadSftpPath;
                var mediaLocation = _mediaRepository.GetCustomerEligibilityUploadFolderLocation();

                var archiveFolder = Path.Combine(mediaLocation.PhysicalPath, "Archive", DateTime.Today.ToString("yyyyMMdd"));
                var failedFolder = Path.Combine(mediaLocation.PhysicalPath, "Failed", DateTime.Today.ToString("yyyyMMdd"));

                var getFilesFromSftp = DirectoryOperationsHelper.GetFiles(sftpFileLocation, "*.txt").Where(x => x.ToLower().Contains("outtake") && x.ToLower().Contains("eligibility"));

                if (getFilesFromSftp.IsNullOrEmpty())
                {
                    _logger.Info("No files found for parsing.");
                    return;
                }

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(archiveFolder);
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(failedFolder);

                var timeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");

                foreach (var file in getFilesFromSftp)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    MoveFile(file, Path.Combine(mediaLocation.PhysicalPath, fileName + "_" + timeStamp + ".txt"));
                }

                var filesToParse = DirectoryOperationsHelper.GetFiles(mediaLocation.PhysicalPath, "*.txt");
                _logger.Info("Number of files to Parse:" + filesToParse.Count());

                foreach (var file in filesToParse)
                {
                    var fileName = Path.GetFileName(file);
                    try
                    {
                        var patientData = _pipeDelimitedReportHelper.ReadWithTextQualifier(file);

                        var columns = patientData.Columns.Cast<DataColumn>().Select(x => x.ColumnName.ToLower()).ToArray();
                        var missingColumnNames = _corporateUploadHelper.CheckAllCustomerEligibilityUploadColumnExist(columns);

                        if (!string.IsNullOrEmpty(missingColumnNames))
                        {
                            _logger.Info("Column Name(" + missingColumnNames + ") missing in file(" + fileName + ")");
                            MoveFile(file, Path.Combine(failedFolder, fileName));
                            continue;
                        }

                        var recordsInFile = patientData.Rows.Count;
                        if (recordsInFile == 0)
                        {
                            _logger.Info("No record found in " + fileName);
                            MoveFile(file, Path.Combine(archiveFolder, fileName));
                            continue;
                        }
                        _logger.Info("Parsing file: " + fileName);
                        _logger.Info("Total number of records in file: " + recordsInFile);

                        var failedRecords = new List<CustomerEligibilityUploadViewModel>();

                        var parseEligibilityData = ParseEligibilityData(patientData.AsEnumerable(), failedRecords);

                        if (parseEligibilityData.Any())
                        {
                            foreach (var customerEligibility in parseEligibilityData)
                            {
                                try
                                {
                                    _logger.Info("Getting customer for AcesId: " + customerEligibility.AcesId);
                                    List<Customer> customers = null;
                                    var errorMesage = string.Empty;

                                    if (!string.IsNullOrWhiteSpace((customerEligibility.AcesId)) || !string.IsNullOrWhiteSpace(customerEligibility.MemberId))
                                    {
                                        if (!string.IsNullOrWhiteSpace(customerEligibility.AcesId))
                                        {
                                            customers = _customerRepository.GetCustomersByAcesId(customerEligibility.AcesId);

                                            if (customers.IsNullOrEmpty())
                                            {
                                                errorMesage = "Customer not found for AcesId: " + customerEligibility.AcesId;
                                                _logger.Info(errorMesage);
                                            }
                                        }
                                        else
                                        {
                                            errorMesage = "AcesId not provided for Member Id: " + customerEligibility.MemberId;
                                            _logger.Info(errorMesage);
                                        }

                                        if (customers.IsNullOrEmpty())
                                        {
                                            if (!string.IsNullOrWhiteSpace(customerEligibility.MemberId))
                                            {
                                                customers = _customerRepository.GetCustomersByMemberId(customerEligibility.MemberId);

                                                if (customers.IsNullOrEmpty())
                                                {
                                                    errorMesage = errorMesage + ", " + "Customer not found for Member ID: " + customerEligibility.MemberId;
                                                    _logger.Info(errorMesage);
                                                }
                                            }
                                            else
                                            {
                                                errorMesage = errorMesage + " , " + "Member Id not provided for AcesId: " + customerEligibility.AcesId;
                                                _logger.Info(errorMesage);
                                            }
                                        }

                                        if (customers.IsNullOrEmpty())
                                        {
                                            customerEligibility.Error = errorMesage;
                                            failedRecords.Add(customerEligibility);

                                            _logger.Info("Record not parsed:  " + errorMesage);
                                            continue;
                                        }

                                        bool? eligibility = null;

                                        if (customerEligibility.Eligibility.ToLower() == CustomerEligibilityYes.ToLower())
                                            eligibility = true;

                                        else if (customerEligibility.Eligibility.ToLower() == CustomerEligibilityNo.ToLower())
                                            eligibility = false;

                                        int eligibilityYear = Convert.ToInt32(customerEligibility.EligibilityYear);

                                        foreach (var customer in customers)
                                        {
                                            _customerEligibilityService.Save(customer.CustomerId, eligibilityYear, eligibility, OrgRoleId, _logger);
                                            _logger.Info("Customer Eligibility inserted successfully for CustomerID: " + customer.CustomerId);
                                        }
                                    }
                                    else
                                    {
                                        errorMesage = "Aces Id or Member Id not provided ";
                                        customerEligibility.Error = errorMesage;
                                        failedRecords.Add(customerEligibility);

                                        _logger.Info("Record not parsed " + errorMesage);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    customerEligibility.Error = "Some error occurred while saving record.";
                                    failedRecords.Add(customerEligibility);
                                    _logger.Error(string.Format("Error occurred while saving record for AcesId: {0}.\nMessage: {1}\n\tStackTrace: {2}", customerEligibility.AcesId, ex.Message, ex.StackTrace));
                                }
                            }
                        }
                        CreateFailedUploadFile(fileName, failedFolder, failedRecords);
                        MoveFile(file, Path.Combine(archiveFolder, fileName));
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Error occurred while processing the {0}.\nMessage: {1}\n\tStackTrace: {2}", file, ex.Message, ex.StackTrace));

                        MoveFile(file, Path.Combine(failedFolder, fileName));
                    }

                }
                _logger.Info("File parsing completed @ " + DateTime.Now);

                try
                {
                    _logger.Info("Copying failed file at SFTP");
                    var failedFiles = DirectoryOperationsHelper.GetFiles(failedFolder, "*.txt");
                    if (failedFiles.IsNullOrEmpty())
                    {
                        _logger.Info("No failed files found to copy at SFTP.");
                        return;
                    }

                    _logger.Info("Creating failed folder at SFTP " + sftpFileLocation);
                    var sftpFailedFolder = Path.Combine(sftpFileLocation, "FailedCustomerRecords", DateTime.Today.ToString("yyyyMMdd"));
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(sftpFailedFolder);

                    foreach (var file in failedFiles)
                    {
                        var failedFileName = Path.GetFileName(file);
                        try
                        {
                            DirectoryOperationsHelper.Copy(file, Path.Combine(sftpFailedFolder, failedFileName));
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Copying faield file not succeed for {0}. \nException Message: {1}\n\tStackTrace:{2}", failedFileName, ex.Message, ex.StackTrace));
                        }
                    }
                    _logger.Info("All failed files copied at " + sftpFailedFolder + " location.");
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Exception occurred during copying failed file at SFTP. \nException Message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                    return;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception occurred during execution of servcie. \nException Message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                return;
            }
        }

        private IEnumerable<CustomerEligibilityUploadViewModel> ParseEligibilityData(IEnumerable<DataRow> rows, List<CustomerEligibilityUploadViewModel> failedRecords)
        {
            var collection = new List<CustomerEligibilityUploadViewModel>();

            foreach (DataRow row in rows)
            {
                var customerEligibility = GetDataRow(row);

                int eligibilityYear = 0;
                int.TryParse(customerEligibility.EligibilityYear, out eligibilityYear);

                //long customerId = 0;
                //long.TryParse(customerEligibility.CustomerId, out customerId);

                if (eligibilityYear != 0 && eligibilityYear >= DateTime.Today.Year && eligibilityYear <= (DateTime.Today.Year + 2) && (string.IsNullOrEmpty(customerEligibility.Eligibility) ||
                    customerEligibility.Eligibility.ToLower() == CustomerEligibilityYes.ToLower() || customerEligibility.Eligibility.ToLower() == CustomerEligibilityNo.ToLower()))
                {
                    collection.Add(customerEligibility);
                }
                else
                {
                    var error = new StringBuilder();

                    //if (string.IsNullOrEmpty(customerEligibility.AcesId))
                    //{
                    //    error.Append(CustomerEligibilityUploadColumn.AcesId + ", ");
                    //}

                    //if (customerId == 0)
                    //{
                    //    error.Append(CustomerEligibilityUploadColumn.CustomerId + ", ");
                    //}

                    if (eligibilityYear == 0 || eligibilityYear < DateTime.Now.Year || eligibilityYear > (DateTime.Now.Year + 2))
                    {
                        error.Append(CustomerEligibilityUploadColumn.EligibilityYear);
                    }

                    if (error.Length > 0)
                    {
                        //error.Length = error.Length - 2;
                        error.Append(" not provided or invalid");
                    }

                    if (!string.IsNullOrEmpty(customerEligibility.Eligibility))
                    {
                        if (customerEligibility.Eligibility.ToLower() != CustomerEligibilityYes.ToLower() && customerEligibility.Eligibility.ToLower() != CustomerEligibilityNo.ToLower())
                            customerEligibility.Error = "Eligibility values is not valid.";
                    }

                    customerEligibility.Error = customerEligibility.Error + "" + error;
                    failedRecords.Add(customerEligibility);
                }
            }

            return collection;
        }

        private CustomerEligibilityUploadViewModel GetDataRow(DataRow row)
        {
            var patientParsedData = new CustomerEligibilityUploadViewModel
            {
                CustomerId = GetRowValue(row, CustomerEligibilityUploadColumn.CustomerId),
                AcesId = GetRowValue(row, CustomerEligibilityUploadColumn.AcesId),
                DNC = GetRowValue(row, CustomerEligibilityUploadColumn.DNC),
                EligibilityYear = GetRowValue(row, CustomerEligibilityUploadColumn.EligibilityYear),
                MemberId = GetRowValue(row, CustomerEligibilityUploadColumn.MemberId),
                Eligibility = GetRowValue(row, CustomerEligibilityUploadColumn.Eligibility)
            };

            return patientParsedData;
        }

        private string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        private void CreateFailedUploadFile(string fileName, string folderPath, List<CustomerEligibilityUploadViewModel> failedRecords)
        {
            if (failedRecords.Any())
            {
                try
                {
                    _logger.Info("Number of failed Records: " + failedRecords.Count);
                    _logger.Info("Creating file for failed records...");
                    var failedFileName = Path.GetFileNameWithoutExtension(fileName) + "_Failed.txt";
                    _pipeDelimitedReportHelper.WriteWithTextQualifier(failedRecords.OrderBy(x => x.CustomerId), folderPath, failedFileName);
                    _logger.Info("failed records file created.");
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Error occurred while creating failed records file. \nException Message: {0}\n\tStackTrace: {1}", ex.Message, ex.StackTrace));
                }
            }
        }

        private void MoveFile(string sourceFile, string destinationFile)
        {
            try
            {
                DirectoryOperationsHelper.DeleteFileIfExist(destinationFile);
                DirectoryOperationsHelper.Move(sourceFile, destinationFile);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception occurred while moving file {0} to {1}. \nException Message: {2}\n\tStackTrace:{3}", sourceFile, destinationFile, ex.Message, ex.StackTrace));
            }
        }
    }
}
