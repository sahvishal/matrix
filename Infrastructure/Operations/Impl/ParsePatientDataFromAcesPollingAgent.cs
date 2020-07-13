using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class ParsePatientDataFromAcesPollingAgent : IParsePatientDataFromAcesPollingAgent
    {

        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerProfileHistoryRepository _customerProfileHistoryRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private const long orgRoleId = 1;

        public ParsePatientDataFromAcesPollingAgent(IMediaRepository mediaRepository, ISettings settings, IPipeDelimitedReportHelper pipeDelimitedReportHelper, ILogManager logManager,
            ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository, ICustomerProfileHistoryRepository customerProfileHistoryRepository,
            ICustomerEligibilityRepository customerEligibilityRepository)
        {
            _mediaRepository = mediaRepository;
            _settings = settings;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerProfileHistoryRepository = customerProfileHistoryRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
            _logger = logManager.GetLogger("ParsePatientDataFromAcesPollingAgent");
        }

        public void PollForParsePatientDataFromAces()
        {
            try
            {
                _logger.Info("Entering Parse Patient Data From Aces Polling Agent @:" + DateTime.Now);

                var sftpFileLocation = _settings.ParsePatientDataSftpPath;
                var mediaLocation = _mediaRepository.GetParsePatientDataMediaFileLocation();

                var archiveFolder = Path.Combine(mediaLocation.PhysicalPath, "Archive", DateTime.Today.ToString("yyyyMMdd"));
                var failedFolder = Path.Combine(mediaLocation.PhysicalPath, "Failed", DateTime.Today.ToString("yyyyMMdd"));

                var getFilesFromSftp = DirectoryOperationsHelper.GetFiles(sftpFileLocation, "TCPA_AcesID_HipID*.txt");

                if (getFilesFromSftp.IsNullOrEmpty())
                {
                    _logger.Info("No files found for parsing.");
                    return;
                }

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(archiveFolder);

                foreach (var file in getFilesFromSftp)
                {
                    var fileName = Path.GetFileName(file);
                    MoveFile(file, Path.Combine(mediaLocation.PhysicalPath, fileName));
                }

                var filesToParse = DirectoryOperationsHelper.GetFiles(mediaLocation.PhysicalPath, "*.txt");
                _logger.Info("Number of files to Parse:" + filesToParse.Count());
                const int pageSize = 100;

                foreach (var file in filesToParse)
                {
                    try
                    {
                        var fileName = Path.GetFileName(file);
                        var sourceFile = Path.Combine(mediaLocation.PhysicalPath, fileName);

                        var patientData = _pipeDelimitedReportHelper.Read(sourceFile);
                        var recordsInFile = patientData.Rows.Count;
                        if (recordsInFile == 0)
                        {
                            _logger.Info("No record found in " + fileName);
                            MoveFile(sourceFile, Path.Combine(archiveFolder, fileName));
                            continue;
                        }
                        _logger.Info("Parsing file: " + fileName);
                        _logger.Info("Total number of records to file: " + recordsInFile);
                        var failedRecords = new List<PatientParsedDataViewModel>();
                        var parsedPatientData = ParsePatientData(patientData.AsEnumerable(), failedRecords);
                        if (parsedPatientData.Any())
                        {
                            var pageNumber = 1;
                            int totalRecords = parsedPatientData.Count();

                            var totalPages = (totalRecords / pageSize) + (totalRecords % pageSize != 0 ? 1 : 0);
                            do
                            {
                                var pagedCustomers = parsedPatientData.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
                                var parsedCustomerIds = pagedCustomers.Select(x => x.CustomerId).ToArray();
                                var customerIds = _customerRepository.CheckCustomerExists(parsedCustomerIds).ToArray();
                                if (parsedCustomerIds.Count() != customerIds.Count())
                                {
                                    var customerIdNotExist = parsedCustomerIds.Except(customerIds);
                                    var failedCustomers = pagedCustomers.Where(x => customerIdNotExist.Contains(x.CustomerId));
                                    failedCustomers.ForEach(x => x.Error = "HIPID does not exist.");
                                    failedRecords.AddRange(failedCustomers);
                                    pagedCustomers = pagedCustomers.Where(x => customerIds.Contains(x.CustomerId));
                                }

                                var customerIdsAlreadyHaveAcesId = _customerRepository.CheckCustomerAlreadyHaveAcesId(customerIds);
                                if (customerIdsAlreadyHaveAcesId.Count() != 0)
                                {
                                    var customersAlreadyHaveAcesId = pagedCustomers.Where(x => customerIdsAlreadyHaveAcesId.Contains(x.CustomerId));
                                    customersAlreadyHaveAcesId.ForEach(x => x.Error = "Patient already have ACESID.");
                                    failedRecords.AddRange(customersAlreadyHaveAcesId);
                                    pagedCustomers = pagedCustomers.Where(x => !customerIdsAlreadyHaveAcesId.Contains(x.CustomerId));
                                }

                                var acesIdAlreadyAssignedToCustomers = _customerRepository.CheckAcesIdAlreadyAssignedToCustomer(pagedCustomers.Select(x => x.AcesId.ToLower()).ToArray());
                                if (acesIdAlreadyAssignedToCustomers.Count() != 0)
                                {
                                    var acesIdAlreadyAssignedCustomers = pagedCustomers.Where(x => acesIdAlreadyAssignedToCustomers.Contains(x.AcesId));
                                    acesIdAlreadyAssignedCustomers.ForEach(x => x.Error = "ACESID already assigned to a patient.");
                                    failedRecords.AddRange(acesIdAlreadyAssignedCustomers);
                                    pagedCustomers = pagedCustomers.Where(x => !acesIdAlreadyAssignedToCustomers.Contains(x.AcesId.ToLower()));
                                }
                                _logger.Info(string.Format("Number of customer to parse: {0} in page: {1}", pagedCustomers.Count(), pageNumber));
                                foreach (var customer in pagedCustomers)
                                {
                                    try
                                    {
                                        _logger.Info("Parsing data for CustomerId: " + customer.CustomerId);
                                        var customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);
                                        var customerProfileHistoryId = _customerProfileHistoryRepository.CreateCustomerHistory(customer.CustomerId, orgRoleId, customerEligibility);
                                        _eventCustomerRepository.UpdateCustomerProfileIdByCustomerId(customer.CustomerId, customerProfileHistoryId);
                                        _customerRepository.UpdateAcesId(customer.CustomerId, customer.AcesId);
                                    }
                                    catch (Exception ex)
                                    {
                                        failedRecords.Add(new PatientParsedDataViewModel() { AcesId = customer.AcesId, CustomerId = customer.CustomerId, Error = "Some error occurred while updating." });
                                        _logger.Error(string.Format("Error occurred while updating record for CustomerId: {0}.\nMessage: {1}\n\tStackTrace: {2}", customer.CustomerId, ex.Message, ex.StackTrace));
                                    }
                                }

                                pageNumber++;
                            }
                            while (totalPages >= pageNumber);
                        }
                        CreateFailedPatientFile(fileName, failedFolder, failedRecords);
                        MoveFile(sourceFile, Path.Combine(archiveFolder, fileName));
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Error occurred while processing the {0}.\nMessage: {1}\n\tStackTrace: {2}", file, ex.Message, ex.StackTrace));
                        var fileName = Path.GetFileName(file);
                        MoveFile(file, Path.Combine(archiveFolder, fileName));
                    }


                }
                _logger.Info("File parsing completed @ " + DateTime.Now);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception occurred during execution of servcie. \nException Message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                return;
            }
        }

        private IEnumerable<PatientParsedDataViewModel> ParsePatientData(IEnumerable<DataRow> rows, List<PatientParsedDataViewModel> failedRecords)
        {
            var collection = new List<PatientParsedDataViewModel>();

            foreach (DataRow row in rows)
            {
                var parsedData = GetDataRow(row);

                if (parsedData.CustomerId == 0)
                {
                    failedRecords.Add(new PatientParsedDataViewModel() { AcesId = parsedData.AcesId, CustomerId = parsedData.CustomerId, Error = "HIPID is not provided." });
                    continue;
                }
                if (string.IsNullOrEmpty(parsedData.AcesId))
                {
                    failedRecords.Add(new PatientParsedDataViewModel() { AcesId = parsedData.AcesId, CustomerId = parsedData.CustomerId, Error = "ACESID is not provided." });
                    continue;
                }
                collection.Add(parsedData);
            }
            return collection;
        }

        private PatientParsedDataViewModel GetDataRow(DataRow row)
        {
            var patientParsedData = new PatientParsedDataViewModel
            {
                CustomerId = ConvertToLong(GetRowValue(row, PatientParsedDataColumn.CustomerId.GetDescription()).Trim()),
                AcesId = GetRowValue(row, PatientParsedDataColumn.AcesId.GetDescription()).Trim(),
            };
            return patientParsedData;
        }

        private string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        private long ConvertToLong(string value)
        {
            long parsedValue;
            long.TryParse(value, out parsedValue);
            return parsedValue;
        }

        private DateTime? ConvertToDateTime(string value)
        {
            DateTime parsedValue;
            if (DateTime.TryParse(value, out parsedValue))
                return parsedValue;
            else
                return null;
        }

        private void CreateFailedPatientFile(string fileName, string folderPath, List<PatientParsedDataViewModel> failedRecords)
        {
            if (failedRecords.Any())
            {
                try
                {
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(folderPath);

                    _logger.Info("Number of failed Records: " + failedRecords.Count);
                    _logger.Info("Creating file for failed records...");
                    var failedFileName = Path.GetFileNameWithoutExtension(fileName) + "_Failed_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
                    //DirectoryOperationsHelper.DeleteFileIfExist(Path.Combine(folderPath, failedFileName));
                    _pipeDelimitedReportHelper.Write(failedRecords.OrderBy(x => x.CustomerId), folderPath, failedFileName);
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
