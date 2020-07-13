using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MedicationUploadFileParserPollingAgent : IMedicationUploadFileParserPollingAgent
    {
        private readonly IMedicationUploadRepository _medicationUploadRepository;
        private readonly IMedicationUploadLogRepository _medicationUploadLogRepository;
        private readonly IMedicationRepository _medicationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICsvReader _csvReader;
        private readonly IMedicationUploadHelper _medicationUploadHelper;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly INdcRepository _ndcRepository;
        private readonly ISyncMedicationPollingAgent _syncMedicationPollingAgent;
        private readonly IUnitRepository _unitRepository;

        private readonly ILogger _logger;
        private readonly bool _isDevEnvironment;
        private readonly int _pageSize;

        private const string UnknownUnitAlias = "Unknown";

        public MedicationUploadFileParserPollingAgent(IMedicationUploadRepository medicationUploadRepository, IMedicationUploadLogRepository medicationUploadLogRepository,
            IMedicationRepository medicationRepository, ICustomerRepository customerRepository, ICsvReader csvReader, IMedicationUploadHelper medicationUploadHelper,
            IUniqueItemRepository<File> fileRepository, ILogManager logManager, ISettings settings, IMediaRepository mediaRepository, INdcRepository ndcRepository,
            ISyncMedicationPollingAgent syncMedicationPollingAgent, IUnitRepository unitRepository)
        {
            _medicationUploadRepository = medicationUploadRepository;
            _medicationUploadLogRepository = medicationUploadLogRepository;
            _medicationRepository = medicationRepository;
            _customerRepository = customerRepository;
            _csvReader = csvReader;
            _medicationUploadHelper = medicationUploadHelper;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _ndcRepository = ndcRepository;
            _syncMedicationPollingAgent = syncMedicationPollingAgent;
            _unitRepository = unitRepository;

            _logger = logManager.GetLogger("MedicationUploadFileParserPollingAgent");
            _isDevEnvironment = settings.IsDevEnvironment;
            _pageSize = 100;
        }


        public void PollForParsingMedicationUpload()
        {
            try
            {
                _logger.Info("Entering Medication upload File parser");

                var timeOfDay = DateTime.Now;

                if (_isDevEnvironment || (DateTime.Now.TimeOfDay < new TimeSpan(23, 0, 0) && DateTime.Now.TimeOfDay > new TimeSpan(4, 0, 0)))     //condition to restrict run time here
                {
                    var filesToParse = (IReadOnlyCollection<MedicationUpload>)_medicationUploadRepository.GetFilesToParse();
                    if (filesToParse.IsNullOrEmpty())
                    {
                        _logger.Info("No file found for Parsing");
                        return;
                    }
                    _logger.Info("Number Of File Found For parsing: " + filesToParse.Count());

                    var uploadedFileIds = filesToParse.Select(x => x.FileId);
                    var uploadedFiles = _fileRepository.GetByIds(uploadedFileIds);
                    var location = _mediaRepository.GetMedicationUploadMediaFileLocation();

                    foreach (var medicationUploadDomain in filesToParse)
                    {
                        try
                        {
                            medicationUploadDomain.ParseStartTime = DateTime.Now;

                            var fileDomain = uploadedFiles.FirstOrDefault(x => x.Id == medicationUploadDomain.FileId);
                            if (fileDomain == null)
                            {
                                UpdateParsingStatus(medicationUploadDomain, (long)MedicationUploadStatus.FileNotFound);
                                _logger.Info("Parsing Failed: FileNotFound MedicationUploadId: " + medicationUploadDomain.Id);
                                continue;
                            }

                            var file = location.PhysicalPath + fileDomain.Path;
                            _logger.Info("\t Beginning parsing for File : " + file);

                            UpdateParsingStatus(medicationUploadDomain, (long)MedicationUploadStatus.Parsing, false);

                            _csvReader.Delimiter = _csvReader.GetFileDelimiter(file).ToString();
                            var medicationTable = _csvReader.ReadWithTextQualifier(file);

                            var totalMedication = medicationTable.Rows.Count;
                            var totalPages = totalMedication / _pageSize + (totalMedication % _pageSize != 0 ? 1 : 0);
                            _logger.Info("Total No. Of Pages: " + totalPages + " Total No. of Records " + totalMedication);

                            var pageNumber = 1;
                            var failedRecordsList = new List<MedicationUploadLog>();
                            var units = _unitRepository.GetAll();

                            while (totalPages >= pageNumber)
                            {
                                var query = medicationTable.AsEnumerable();
                                _logger.Info("Parsing For Page Number: " + pageNumber);

                                var rows = query.Skip(_pageSize * (pageNumber - 1)).Take(_pageSize);
                                ParseMedicationUploaded(rows, failedRecordsList, medicationUploadDomain, units);
                                pageNumber++;
                            }

                            medicationUploadDomain.SuccessfullUploadCount = (totalMedication - failedRecordsList.Count(s => !s.IsSuccessFull));

                            medicationUploadDomain.ParseEndTime = DateTime.Now;
                            medicationUploadDomain.StatusId = (long)MedicationUploadStatus.Parsed;

                            UpdateMedicationUploadDetail(medicationUploadDomain, failedRecordsList, file);

                            _logger.Info("Passing control to Sync Service");
                            _syncMedicationPollingAgent.SyncMedicationData(_logger, medicationUploadDomain.UploadedBy, true);
                            _logger.Info("Control returned from Sync Service");

                            _logger.Info("\n\t Medication Upload Parsing succeeded for file: " + file);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Error while parsing FileId {0} Message: {1} \n\t StackTrace: {2}", medicationUploadDomain.FileId, ex.Message, ex.StackTrace));
                        }
                    }
                }
                else
                {
                    _logger.Info(string.Format("Medication Upload Parser can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }
                _logger.Info(string.Format("Exiting Medication Upload Parser : {0}", timeOfDay.TimeOfDay));
            }
            catch (Exception ex)
            {
                _logger.Error("all Upload Parser Exception: " + ex + "\n Stack Trace:" + ex.StackTrace);
            }
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

        private void UpdateParsingStatus(MedicationUpload medicationFile, long statusId, bool isCompleted = true)
        {
            medicationFile.StatusId = statusId;
            medicationFile.ParseEndTime = DateTime.Now;
            medicationFile.ParseEndTime = isCompleted ? DateTime.Now : (DateTime?)null;

            _medicationUploadRepository.Save(medicationFile);
        }

        private void UpdateMedicationUploadDetail(MedicationUpload medicationUpload, IReadOnlyCollection<MedicationUploadLog> failedRecordsList, string fileName)
        {
            if (failedRecordsList.Any())
            {
                try
                {
                    var location = _mediaRepository.GetMedicationUploadMediaFileLocation();
                    var failedFilePath = location.PhysicalPath + Path.GetFileNameWithoutExtension(fileName) + "_Failed.csv";

                    var modelData = Mapper.Map<IEnumerable<MedicationUploadLog>, IEnumerable<MedicationUploadLogViewModel>>(failedRecordsList);

                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<MedicationUploadLogViewModel>();

                    WriteCsv(failedFilePath, exporter, modelData);

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
                    medicationUpload.FailedUploadCount = failedRecordsList.Count();
                    medicationUpload.LogFileId = file.Id;
                }
                catch (Exception ex)
                {
                    _logger.Error("Exception raised while creating failed customer records \n Message: " + ex.Message + "\n\tStack trace: " + ex.StackTrace);
                }
            }
            try
            {
                _medicationUploadRepository.Save(medicationUpload);
            }
            catch (Exception ex)
            {
                _logger.Error("Exception raised while saving medicationUpload \n Message: " + ex.Message + "\n\tStack trace: " + ex.StackTrace);
            }
        }

        private void ParseMedicationUploaded(IEnumerable<DataRow> rows, List<MedicationUploadLog> failedRecordsList, MedicationUpload medicationUpload, IEnumerable<Unit> units)
        {
            var medicationUploadLogs = rows.Select(row => _medicationUploadHelper.GetUploadLog(row, medicationUpload.Id)).ToList();
            var ndcProductCodesFromFile = medicationUploadLogs.Where(x => x.IsSuccessFull == true).Select(x => x.NdcProductCode).ToList();
            var ndcList = _ndcRepository.GetByNdcCode(ndcProductCodesFromFile);

            if (medicationUploadLogs.IsNullOrEmpty())
            {
                _logger.Info("No Record Found For Parsing in file");
                return;
            }

            foreach (var medicationUploadLog in medicationUploadLogs)
            {
                try
                {
                    if (!medicationUploadLog.IsSuccessFull)
                    {
                        failedRecordsList.Add(medicationUploadLog);
                        continue;
                    }

                    var serviceDate = _medicationUploadHelper.CovertToDate(medicationUploadLog.ServiceDate).Value;
                    if (serviceDate >= DateTime.Today.AddDays(1))
                    {
                        medicationUploadLog.ErrorMessage = "Date of Service can not be future date.";
                        failedRecordsList.Add(medicationUploadLog);
                        continue;
                    }

                    var ndc = ndcList.FirstOrDefault(x => x.NdcCode.ToUpper() == medicationUploadLog.NdcProductCode.ToUpper());
                    if (ndc == null)
                    {
                        medicationUploadLog.ErrorMessage = "Invalid product Ndc";
                        medicationUploadLog.IsSuccessFull = false;

                        failedRecordsList.Add(medicationUploadLog);
                        continue;
                    }

                    var memberDob = _medicationUploadHelper.CovertToDate(medicationUploadLog.MemberDob).Value;

                    var unit = units.FirstOrDefault(x => x.Name == ndc.ActiveIngredUnit);
                    var alias = unit != null ? unit.Alias : UnknownUnitAlias;

                    var customers = _customerRepository.GetCustomerForMedicationParsing(medicationUploadLog.CmsHicn, medicationUploadLog.MemberId, memberDob);

                    if (customers.IsNullOrEmpty())
                    {
                        medicationUploadLog.IsSuccessFull = false;
                        medicationUploadLog.ErrorMessage = "Customer not found for with following criteria:";

                        if (!string.IsNullOrEmpty(medicationUploadLog.CmsHicn))
                        {
                            medicationUploadLog.ErrorMessage = medicationUploadLog.ErrorMessage + " Hicn";
                            if (!string.IsNullOrEmpty(medicationUploadLog.MemberId))
                            {
                                medicationUploadLog.ErrorMessage = medicationUploadLog.ErrorMessage + " or MemberId";
                            }
                        }
                        else if (!string.IsNullOrEmpty(medicationUploadLog.MemberId))
                        {
                            medicationUploadLog.ErrorMessage = medicationUploadLog.ErrorMessage + " MemberId";
                        }

                        failedRecordsList.Add(medicationUploadLog);
                        continue;
                    }
                    if (customers.Count() > 1)
                    {
                        medicationUploadLog.IsSuccessFull = false;
                        medicationUploadLog.ErrorMessage = "Multiple Customer found for with following criteria:";

                        if (!string.IsNullOrEmpty(medicationUploadLog.CmsHicn))
                        {
                            medicationUploadLog.ErrorMessage = medicationUploadLog.ErrorMessage + " Hicn and Date Of Birth";
                        }
                        else if (!string.IsNullOrEmpty(medicationUploadLog.MemberId))
                        {
                            medicationUploadLog.ErrorMessage = medicationUploadLog.ErrorMessage + " MemberId and Date Of Birth";
                        }

                        failedRecordsList.Add(medicationUploadLog);
                        continue;
                    }
                    long customerId = customers.Single().CustomerId;

                    var medicationsForCustomer = (IReadOnlyCollection<Medication>)_medicationRepository.GetByCustomerId(customerId);
                    Medication doesMedicationAlreadyExists = null;

                    if (!medicationsForCustomer.IsNullOrEmpty())
                    {
                        doesMedicationAlreadyExists = medicationsForCustomer.FirstOrDefault(x => x.ServiceDate == serviceDate && x.NdcProductCode.ToUpper() == medicationUploadLog.NdcProductCode.ToUpper());
                    }

                    if (doesMedicationAlreadyExists != null)
                    {
                        medicationUploadLog.IsSuccessFull = false;
                        medicationUploadLog.ErrorMessage = "Medication for this record already present";

                        failedRecordsList.Add(medicationUploadLog);
                        continue;
                    }

                    SaveDataForCustomer(customerId, medicationUploadLog, medicationUpload.UploadedBy, ndc, alias, memberDob, serviceDate);

                    medicationUploadLog.IsSuccessFull = true;
                    medicationUploadLog.ErrorMessage = null;
                }
                catch (Exception ex)
                {
                    medicationUploadLog.IsSuccessFull = false;
                    medicationUploadLog.ErrorMessage = "Some Error occurred while parsing Recored";

                    _logger.Error("Hicn " + medicationUploadLog.CmsHicn);
                    _logger.Error("MemberId " + medicationUploadLog.MemberId);

                    _logger.Error(string.Format("Error on Message: {0} \n Stack Trace: {1}", ex.Message, ex.StackTrace));
                }
            }
            try
            {
                _medicationUploadLogRepository.BulkSaveMedicationUploadLog(medicationUploadLogs);                               // medication upload LOGs are being saved according to paging
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while saving MedicationLog , exception message: {0} \n\t Stack Trace: {1}", ex.Message, ex.StackTrace));
            }
        }

        private void SaveDataForCustomer(long customerId, MedicationUploadLog medicationUploadLog, long uploadedBy, Ndc ndcData,
            string unitAlias, DateTime memberDob, DateTime serviceDate)
        {

            //no medication present for customer , so save what we get
            var medicationNew = new Medication
            {
                CustomerId = customerId,

                CreatedBy = uploadedBy,
                DateCreated = DateTime.Now,

                MemberDob = memberDob,
                MemberId = medicationUploadLog.MemberId,
                ServiceDate = serviceDate,
                Hicn = medicationUploadLog.CmsHicn,
                NdcProductCode = medicationUploadLog.NdcProductCode,

                ProprietaryName = ndcData.ProductName,
                Unit = unitAlias,
                IsActive = true,
            };

            _medicationRepository.SaveMedication(medicationNew);
        }

        //private long CheckAndSaveDataForCustomer(long customerId, MedicationUploadLog medicationUploadLog, long uploadedBy,
        //    List<MedicationUploadLog> failedRecordsList, Ndc ndcData, string unitAlias)
        //{
        //    var successCount = 0;

        //    var medicationsForCustomer = (IReadOnlyCollection<Medication>)_medicationRepository.GetByCustomerId(customerId);

        //    //this will parse correctly as we do not proceed with failed to parse records till here
        //    var serviceDate = _medicationUploadHelper.CovertToDate(medicationUploadLog.ServiceDate).Value;

        //    var memberDob = _medicationUploadHelper.CovertToDate(medicationUploadLog.MemberDob).Value;

        //    if (!medicationsForCustomer.IsNullOrEmpty())
        //    {
        //        var doesMedicationAlreadyExists = medicationsForCustomer.FirstOrDefault(x => x.ServiceDate == serviceDate
        //            && x.NdcProductCode.ToUpper() == medicationUploadLog.NdcProductCode.ToUpper());

        //        if (doesMedicationAlreadyExists == null)
        //        {
        //            var medication = new Medication
        //            {
        //                CustomerId = customerId,

        //                CreatedBy = uploadedBy,
        //                DateCreated = DateTime.Now,

        //                MemberDob = memberDob,
        //                MemberId = medicationUploadLog.MemberId,
        //                ServiceDate = serviceDate,
        //                Hicn = medicationUploadLog.CmsHicn,
        //                NdcProductCode = medicationUploadLog.NdcProductCode,

        //                ProprietaryName = ndcData.ProductName,
        //                Unit = unitAlias,
        //                IsActive = true,
        //            };
        //            _medicationRepository.SaveMedication(medication);

        //            medicationUploadLog.ErrorMessage = null;
        //            medicationUploadLog.IsSuccessFull = true;

        //            return ++successCount;
        //        }
        //        else
        //        {
        //            medicationUploadLog.ErrorMessage = "";
        //            medicationUploadLog.IsSuccessFull = false;
        //            failedRecordsList.Add(medicationUploadLog);
        //            return successCount;
        //        }
        //    }

        //    //no medication present for customer , so save what we get
        //    var medicationNew = new Medication
        //    {
        //        CustomerId = customerId,

        //        CreatedBy = uploadedBy,
        //        DateCreated = DateTime.Now,

        //        MemberDob = memberDob,
        //        MemberId = medicationUploadLog.MemberId,
        //        ServiceDate = serviceDate,
        //        Hicn = medicationUploadLog.CmsHicn,
        //        NdcProductCode = medicationUploadLog.NdcProductCode,

        //        ProprietaryName = ndcData.ProductName,
        //        Unit = unitAlias,
        //        IsActive = true,
        //    };
        //    _medicationRepository.SaveMedication(medicationNew);

        //    medicationUploadLog.IsSuccessFull = true;
        //    medicationUploadLog.ErrorMessage = null;

        //    return ++successCount;
        //}

    }
}