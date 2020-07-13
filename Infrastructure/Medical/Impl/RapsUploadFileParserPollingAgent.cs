using System;
using System.Collections.Generic;
using System.Data;
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
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class RapsUploadFileParserPollingAgent : IRapsUploadFileParserPollingAgent
    {
        private readonly IRapsUploadRepository _rapsUploadRepository;
        private readonly IRapsUploadLogRepository _rapsUploadLogRepository;
        private readonly IRapsRepository _rapsRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly IRapsUploadHelper _rapsUploadHelper;
        private readonly ICustomerRepository _customerRepository;

        private readonly ILogger _logger;
        private readonly bool _isDevEnvironment;
        private const int PageSize = 15;

        public RapsUploadFileParserPollingAgent(IRapsUploadRepository rapsUploadRepository, IRapsUploadLogRepository rapsUploadLogRepository, IRapsRepository rapsRepository, ILogManager logManager,
            ISettings settings, IUniqueItemRepository<File> fileRepository,
            IMediaRepository mediaRepository, ICsvReader csvReader, IRapsUploadHelper rapsUploadHelper, ICustomerRepository customerRepository)
        {
            _rapsUploadRepository = rapsUploadRepository;
            _rapsUploadLogRepository = rapsUploadLogRepository;
            _rapsRepository = rapsRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _csvReader = csvReader;
            _rapsUploadHelper = rapsUploadHelper;
            _customerRepository = customerRepository;
            _isDevEnvironment = settings.IsDevEnvironment;
            _logger = logManager.GetLogger("RapsUploadPollingAgent");
        }

        public void PollForParsingRapsUpload()
        {
            try
            {
                _logger.Info("Entering In Raps Upload File Parser Polling Agent");

                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    var rapsUploads = _rapsUploadRepository.GetFilesToParse();
                    if (rapsUploads.IsNullOrEmpty())
                    {
                        _logger.Info("No file found for Parsing");
                        return;
                    }

                    _logger.Info("Number Of File Found For parsing: " + rapsUploads.Count());

                    var uploadedFileIds = rapsUploads.Select(x => x.FileId);
                    var uploadedFiles = _fileRepository.GetByIds(uploadedFileIds);
                    var location = _mediaRepository.GetRapsUploadMediaFileLocation();

                    foreach (var rapsUploadDomain in rapsUploads)
                    {
                        try
                        {
                            rapsUploadDomain.ParseStartTime = DateTime.Now;

                            var fileDomain = uploadedFiles.FirstOrDefault(x => x.Id == rapsUploadDomain.FileId);

                            if (fileDomain == null)
                            {
                                UpdateParsingStatus(rapsUploadDomain, (long)RapsUploadStatus.FileNotFound);
                                _logger.Info("Parsing Failed: FileNotFound RapsUploadId: " + rapsUploadDomain.Id);
                                continue;
                            }

                            var file = location.PhysicalPath + fileDomain.Path;
                            _logger.Info("Parsing For File " + file);

                            //if (!System.IO.File.Exists(file))
                            //{
                            //    UpdateParsingStatus(rapsUploadDomain, (long)RapsUploadStatus.FileNotFound);
                            //    _logger.Info("Parsing Failed: FileNotFound  RapsUploadId: " + rapsUploadDomain.Id);
                            //    continue;
                            //}

                            //var fInfo = new FileInfo(file);
                            //if (fInfo.Extension != ".csv")
                            //{
                            //    UpdateParsingStatus(rapsUploadDomain, (long)RapsUploadStatus.InvalidFileFormat);
                            //    _logger.Info("Parsing Failed: InvalidFileFormat RapsUploadId: " + rapsUploadDomain.Id);
                            //    continue;
                            //}

                            UpdateParsingStatus(rapsUploadDomain, (long)RapsUploadStatus.Parsing, false);
                            _csvReader.Delimiter = _csvReader.GetFileDelimiter(file).ToString();
                            var rapsTable = _csvReader.ReadWithTextQualifier(file);
                            var totalRaps = rapsTable.Rows.Count;

                            var totalPages = totalRaps / PageSize + (totalRaps % PageSize != 0 ? 1 : 0);

                            _logger.Info("Total No. Of Pages: " + totalPages + " Total No. of Records " + totalRaps);

                            var pageNumber = 1;
                            var failedRapsList = new List<RapsUploadLog>();

                            var successfulUploadCount = 0L;

                            while (totalPages >= pageNumber)
                            {
                                var successCount = 0L;
                                var query = rapsTable.AsEnumerable();
                                _logger.Info("Parsing For Page Number: " + pageNumber);

                                var rows = query.Skip(PageSize * (pageNumber - 1)).Take(PageSize);

                                ParseRapsUploaded(rows, failedRapsList, rapsUploadDomain.Id, out successCount);

                                successfulUploadCount += successCount;
                                pageNumber++;
                            }

                            rapsUploadDomain.SuccessfullUploadCount = successfulUploadCount;
                            rapsUploadDomain.ParseEndTime = DateTime.Now;
                            rapsUploadDomain.StatusId = (long)RapsUploadStatus.Parsed;
                            UpdateRapsUploadDetail(rapsUploadDomain, failedRapsList, file);

                        }
                        catch (Exception exception)
                        {
                            _logger.Error(string.Format("Error on Message: {0} \n StackTrace: {1}", exception.Message, exception.StackTrace));
                        }
                    }
                    _logger.Info("Raps parsing complete");
                }
                else
                {
                    _logger.Info(string.Format("Raps Upload Parser can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }

            }
            catch (Exception exception)
            {
                _logger.Error("all Upload Parser Exception: " + exception + "\n Stack Trace:" + exception.StackTrace);
            }
        }
        private void UpdateParsingStatus(RapsUpload rapsFile, long statusId, bool isCompleted = true)
        {
            rapsFile.StatusId = statusId;
            rapsFile.ParseEndTime = DateTime.Now;
            rapsFile.ParseEndTime = isCompleted ? DateTime.Now : (DateTime?)null;

            _rapsUploadRepository.Save(rapsFile);
        }

        private void UpdateRapsUploadDetail(RapsUpload rapsUpload, List<RapsUploadLog> failedCustomerList, string fileName)
        {

            if (failedCustomerList.Any())
            {
                try
                {
                    var location = _mediaRepository.GetRapsUploadMediaFileLocation();
                    var failedFilePath = location.PhysicalPath + Path.GetFileNameWithoutExtension(fileName) + "_FailedRaps.csv";

                    var modelData = Mapper.Map<IEnumerable<RapsUploadLog>, IEnumerable<RapsUploadLogViewModel>>(failedCustomerList);

                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<RapsUploadLogViewModel>();

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
                    rapsUpload.FailedUploadCount = failedCustomerList.Count();
                    rapsUpload.LogFileId = file.Id;
                }
                catch (Exception ex)
                {
                    _logger.Error("exception Raised While Creating Failed Customer Records \n message: " + ex.Message + " stack trace: " + ex.StackTrace);
                }
            }

            _rapsUploadRepository.Save(rapsUpload);
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

        private void ParseRapsUploaded(IEnumerable<DataRow> rows, List<RapsUploadLog> failedRapsList, long rapsUploadId, out long successCount)
        {
            var rapsUploadLogs = rows.Select(row => _rapsUploadHelper.GetUploadLog(row, rapsUploadId));
            successCount = 0;
            if (rapsUploadLogs.IsNullOrEmpty())
            {
                _logger.Info("No Record Found For Parsing in file");
                return;
            }

            foreach (var rapsUploadLog in rapsUploadLogs)
            {

                try
                {
                    if (!rapsUploadLog.IsSuccessFull)
                    {
                        _rapsUploadLogRepository.SaveRapsUploadLog(rapsUploadLog);
                        failedRapsList.Add(rapsUploadLog);
                        continue;
                    }
                    var customerIds = new List<long>();
                    if (!string.IsNullOrEmpty(rapsUploadLog.CmsHicn))
                        customerIds =
                            _customerRepository.GetCustomerIdForRaps(rapsUploadLog.CmsHicn, rapsUploadLog.FirstName,
                                rapsUploadLog.SecondName, rapsUploadLog.MemberDob).ToList();
                    if (!customerIds.Any())
                    {
                        rapsUploadLog.IsSuccessFull = false;
                        rapsUploadLog.ErrorMessage = "Customer Not found for this HICN,First Name,Last Name and Date combination";
                        _rapsUploadLogRepository.SaveRapsUploadLog(rapsUploadLog);
                        failedRapsList.Add(rapsUploadLog);
                        continue;
                        //if (!string.IsNullOrEmpty(rapsUploadLog.MemberId))
                        //{
                        //    customerIds = _customerRepository.GetCustomerIdByInsuranceId(rapsUploadLog.MemberId).ToList();

                        //    if (!customerIds.Any())
                        //    {
                        //        rapsUploadLog.IsSuccessFull = false;
                        //        rapsUploadLog.ErrorMessage = "Customer Not found for this CMSHICN Or MemberId";
                        //        _rapsUploadLogRepository.SaveRapsUploadLog(rapsUploadLog);
                        //        failedRapsList.Add(rapsUploadLog);
                        //        continue;
                        //    }
                        //}
                    }
                    foreach (var customerId in customerIds)
                    {
                        var savedRaps = _rapsRepository.GetByCustomerId(customerId).ToArray();
                        var isExisting = savedRaps.FirstOrDefault(x => x.IcdCode == rapsUploadLog.IcdCode &&
                                                                       x.ServiceDate == rapsUploadLog.ServiceDate
                            ) != null;
                        if (!isExisting)
                        {
                            var rapDomain = new Raps
                            {
                                CmsHicn = rapsUploadLog.CmsHicn,
                                CustomerId = customerId,
                                ServiceDate = rapsUploadLog.ServiceDate,
                                IcdCode = rapsUploadLog.IcdCode,
                                MemberDob = rapsUploadLog.MemberDob,
                                RapsUploadId = rapsUploadId,
                                MemberId = rapsUploadLog.MemberId,
                                IcdVersion = rapsUploadLog.IcdVersion,
                                FirstName = rapsUploadLog.FirstName,
                                SecondName = rapsUploadLog.SecondName,
                            };
                            _rapsRepository.SaveRaps(rapDomain);
                        }
                    }
                    successCount++;
                }
                catch (Exception exception)
                {

                    _logger.Error(string.Format("Error on Message: {0} \n Stack Trace: {1}", exception.Message, exception.StackTrace));
                }
            }
        }
    }
}
