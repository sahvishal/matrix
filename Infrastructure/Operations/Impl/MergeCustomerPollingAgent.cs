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
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class MergeCustomerPollingAgent : IMergeCustomerPollingAgent
    {
        private readonly bool _isDevEnvironment;
        private readonly ILogger _logger;
        private readonly IMergeCustomerUploadRepository _mergeCustomerUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly IMergeCustomerUploadHelper _mergeCustomerUploadHelper;
        private readonly IMergeCustomerUploadLogRepository _mergeCustomerUploadLogRepository;
        private readonly IMergeCustomerUploadService _mergeCustomerUploadService;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;

        public MergeCustomerPollingAgent(ISettings settings, ILogManager logManager, IMergeCustomerUploadRepository mergeCustomerUploadRepository, IUniqueItemRepository<File> fileRepository,
            IMediaRepository mediaRepository, ICsvReader csvReader, IMergeCustomerUploadHelper mergeCustomerUploadHelper, IMergeCustomerUploadLogRepository mergeCustomerUploadLogRepository,
            IMergeCustomerUploadService mergeCustomerUploadService, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier)
        {
            _mergeCustomerUploadRepository = mergeCustomerUploadRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _csvReader = csvReader;
            _mergeCustomerUploadHelper = mergeCustomerUploadHelper;
            _mergeCustomerUploadLogRepository = mergeCustomerUploadLogRepository;
            _mergeCustomerUploadService = mergeCustomerUploadService;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _isDevEnvironment = settings.IsDevEnvironment;
            _logger = logManager.GetLogger("MergeCustomer");
        }

        public void PollForMergeCustomerUpload()
        {
            try
            {
                _logger.Info("Entering In Merge Customer Polling Agent");
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || (timeOfDay.TimeOfDay > new TimeSpan(22, 0, 0) || timeOfDay.TimeOfDay < new TimeSpan(0, 30, 0)) || (timeOfDay.TimeOfDay > new TimeSpan(2, 0, 0) && timeOfDay.TimeOfDay < new TimeSpan(3, 30, 0)))
                {
                    var uploads = _mergeCustomerUploadRepository.GetMergeCustomerUploadsForMerging();
                    if (uploads.IsNullOrEmpty())
                    {
                        _logger.Info("No file found for Merging");
                        return;
                    }

                    _logger.Info("No Of File Found For merging: " + uploads.Count());

                    var uploadedFileIds = uploads.Select(x => x.FileId);
                    var uploadedFiles = _fileRepository.GetByIds(uploadedFileIds);
                    var location = _mediaRepository.GetMergeCustomerUploadMediaFileLocation();

                    foreach (var mergeCustomerUpload in uploads)
                    {
                        try
                        {
                            timeOfDay = DateTime.Now;
                            if (_isDevEnvironment || (timeOfDay.TimeOfDay > new TimeSpan(22, 0, 0) || timeOfDay.TimeOfDay < new TimeSpan(0, 30, 0)) || (timeOfDay.TimeOfDay > new TimeSpan(2, 0, 0) && timeOfDay.TimeOfDay < new TimeSpan(3, 30, 0)))
                            {
                                var currentStatus = mergeCustomerUpload.StatusId;

                                var fileDomain = uploadedFiles.FirstOrDefault(x => x.Id == mergeCustomerUpload.FileId);

                                if (fileDomain == null)
                                {
                                    UpdateParsingStatus(mergeCustomerUpload, MergeCustomerUploadStatus.FileNotFound);
                                    _logger.Info("Parsin Failed: FileNotFound UploadId: " + mergeCustomerUpload.Id);
                                    continue;
                                }

                                var file = location.PhysicalPath + fileDomain.Path;
                                _logger.Info("Parsing For File " + file);

                                if (!System.IO.File.Exists(file))
                                {
                                    UpdateParsingStatus(mergeCustomerUpload, MergeCustomerUploadStatus.FileNotFound);
                                    _logger.Info("Parsin Failed: FileNotFound  UploadId: " + mergeCustomerUpload.Id);
                                    continue;
                                }

                                var fInfo = new FileInfo(file);
                                if (fInfo.Extension != ".csv")
                                {
                                    UpdateParsingStatus(mergeCustomerUpload, MergeCustomerUploadStatus.InvalidFileFormat);
                                    _logger.Info("Parsin Failed: InvalidFileFormat CallUploadId: " + mergeCustomerUpload.Id);
                                    continue;
                                }

                                UpdateParsingStatus(mergeCustomerUpload, MergeCustomerUploadStatus.Parsing);

                                if (currentStatus == (long)MergeCustomerUploadStatus.Uploaded)
                                {
                                    var customerTable = _csvReader.ReadWithTextQualifier(file);
                                    var totalCustomers = customerTable.Rows.Count;
                                    var query = customerTable.AsEnumerable();

                                    foreach (var dataRow in query)
                                    {
                                        var uploadLog = _mergeCustomerUploadHelper.GetUploadLog(dataRow, mergeCustomerUpload.Id);
                                        _mergeCustomerUploadLogRepository.Save(uploadLog);
                                    }
                                }

                                var uploadLogs = _mergeCustomerUploadLogRepository.GetUploadLogsForMerge(mergeCustomerUpload.Id);
                                var isNotSuitableForMerging = false;

                                foreach (var mergeCustomerUploadLog in uploadLogs)
                                {
                                    timeOfDay = DateTime.Now;
                                    if (_isDevEnvironment || (timeOfDay.TimeOfDay > new TimeSpan(22, 0, 0) || timeOfDay.TimeOfDay < new TimeSpan(0, 30, 0)) || (timeOfDay.TimeOfDay > new TimeSpan(2, 0, 0) && timeOfDay.TimeOfDay < new TimeSpan(3, 30, 0)))
                                    {
                                        var uploadLog = _mergeCustomerUploadService.ParseMergeCustomerLog(mergeCustomerUploadLog, mergeCustomerUpload.UploadedBy);
                                        _mergeCustomerUploadLogRepository.Save(uploadLog);
                                    }
                                    else
                                    {
                                        isNotSuitableForMerging = true;
                                        break;
                                    }
                                }

                                if (isNotSuitableForMerging)
                                    break;

                                var successCount = _mergeCustomerUploadLogRepository.GetSuccessfulCustomersCount(mergeCustomerUpload.Id);
                                var failedCustomers = _mergeCustomerUploadLogRepository.GetFailedCustomers(mergeCustomerUpload.Id);

                                if (failedCustomers.Any())
                                {
                                    var failedCustomerCount = failedCustomers.Count();
                                    mergeCustomerUpload.FailedUploadCount = failedCustomerCount;

                                    var fileId = GenerateFailedCustomerLogFile(failedCustomers, file);
                                    if (fileId > 0)
                                        mergeCustomerUpload.LogFileId = fileId;

                                    SendFailNotification(mergeCustomerUpload.Id, mergeCustomerUpload.UploadTime, fileDomain.Path);
                                }

                                mergeCustomerUpload.SuccessUploadCount = successCount;

                                UpdateParsingStatus(mergeCustomerUpload, MergeCustomerUploadStatus.Parsed);
                            }
                            else
                                break;
                        }
                        catch (Exception ex)
                        {
                            UpdateParsingStatus(mergeCustomerUpload, MergeCustomerUploadStatus.ParseFailed);
                            _logger.Error("Customer Merge Exception Message: " + ex.Message + "\n Stack Trace:" + ex.StackTrace);
                        }
                    }
                }
                else
                {
                    _logger.Info(string.Format("Merge Customer Parser can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Customer Merge Exception Message: " + ex.Message + "\n Stack Trace:" + ex.StackTrace);
            }
        }

        private void UpdateParsingStatus(MergeCustomerUpload upload, MergeCustomerUploadStatus status)
        {
            upload.StatusId = (long)status;
            if (MergeCustomerUploadStatus.Parsing == status)
                upload.ParseStartTime = DateTime.Now;
            else
                upload.ParseEndTime = DateTime.Now;
            upload = _mergeCustomerUploadRepository.Save(upload);
        }

        private long GenerateFailedCustomerLogFile(IEnumerable<MergeCustomerUploadLog> failedCustomerList, string fileName)
        {
            try
            {
                var location = _mediaRepository.GetMergeCustomerUploadMediaFileLocation();
                var failedFilePath = location.PhysicalPath + Path.GetFileNameWithoutExtension(fileName) + "_FailedCustomer.csv";

                var modelData = Mapper.Map<IEnumerable<MergeCustomerUploadLog>, IEnumerable<MergeCustomerUploadLogViewModel>>(failedCustomerList);

                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<MergeCustomerUploadLogViewModel>();

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
                return file.Id;
            }
            catch (Exception ex)
            {
                _logger.Error("Error while creating failed customers log  file \n message: " + ex.Message + " stacktrace: " + ex.StackTrace);
            }

            return 0;
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

        private void SendFailNotification(long uploadId, DateTime uploadTime, string fileName)
        {
            try
            {
                var mergeCustomerModel = _emailNotificationModelsFactory.GetMergeCustomerViewModel(uploadId, uploadTime, fileName);
                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.MergeCustomer, EmailTemplateAlias.MergeCustomer, mergeCustomerModel, 0, 1, "Merge Customer");
            }
            catch (Exception ex)
            {
                _logger.Error("Error while sending merge customer notification for upload Id:" + uploadId);
                _logger.Error("Message:" + ex.Message);
                _logger.Error("Stack Trace:" + ex.StackTrace);
            }

        }
    }
}
