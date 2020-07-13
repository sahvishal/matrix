using System;
using System.Data;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Enum;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;


namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class DiagnosisReportParsingPollingAgent : IDiagnosisReportParsingPollingAgent
    {
        private readonly IOutboundUploadRepository _outboundUploadRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ICsvReader _csvReader;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IDiagnosisReportFactory _diagnosisReportFactory;
        private readonly IEventCustomerDiagnosisRepository _eventCustomerDiagnosisRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ILogger _logger;

        private readonly string _accountIds;

        public DiagnosisReportParsingPollingAgent(IOutboundUploadRepository outboundUploadRepository, ILogManager logManager, IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository, ICsvReader csvReader,
            IEventCustomerRepository eventCustomerRepository, IDiagnosisReportFactory diagnosisReportFactory, IEventCustomerDiagnosisRepository eventCustomerDiagnosisRepository, ISettings settings,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository)
        {
            _outboundUploadRepository = outboundUploadRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _csvReader = csvReader;
            _eventCustomerRepository = eventCustomerRepository;
            _diagnosisReportFactory = diagnosisReportFactory;
            _eventCustomerDiagnosisRepository = eventCustomerDiagnosisRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _logger = logManager.GetLogger("DiagnosisReport_Parse");
            _accountIds = settings.FloridaBlueAccountId;
        }

        public void PollForDiagnosisReportParsing()
        {
            var outboundUploads = _outboundUploadRepository.GetAllUploadedFilesByType((long)OutboundUploadType.DiagnosisReport);
            if (outboundUploads == null || !outboundUploads.Any())
            {
                _logger.Info("No new files uploaded.");
                return;
            }

            var accountIds = _accountIds.Split(',');

            foreach (var accountId in accountIds)
            {
                var account = _corporateAccountRepository.GetById(Convert.ToInt32(accountId));

                var fileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "DiagnosisReport");
                var archivedFileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "DiagnosisReportArchived");

                foreach (var outboundUpload in outboundUploads)
                {
                    try
                    {
                        outboundUpload.StatusId = (long)OutboundUploadStatus.Parsing;
                        outboundUpload.ParseStartTime = DateTime.Now;
                        _outboundUploadRepository.Save(outboundUpload);

                        var file = _fileRepository.GetById(outboundUpload.FileId);

                        if (!System.IO.File.Exists(fileLocation.PhysicalPath + file.Path))
                        {
                            _logger.Info("File not found : " + fileLocation.PhysicalPath + file.Path);
                            continue;
                        }

                        _logger.Info("Importing File : " + file.Path);

                        var dataTable = _csvReader.CsvToDataTable(fileLocation.PhysicalPath + file.Path, true);

                        if (dataTable == null || dataTable.Rows.IsNullOrEmpty())
                        {
                            _logger.Info("No rows found.");
                            outboundUpload.ParseEndTime = DateTime.Now;
                            outboundUpload.StatusId = (long)OutboundUploadStatus.Parsed;
                            _outboundUploadRepository.Save(outboundUpload);
                            continue;
                        }

                        var successRows = 0;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            var model = GetPatientDiagnosisModel(row);
                            try
                            {
                                var customerId = Convert.ToInt64(model.CustomerId);
                                var eventId = Convert.ToInt64(model.EventId);
                                var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);

                                if (eventCustomer == null)
                                {
                                    _logger.Info("No EventCustomer found for CustomerId : " + model.CustomerId + " and EventId : " + model.EventId);
                                    continue;
                                }

                                var eventCustomerDiagnosis = _diagnosisReportFactory.Create(model, eventCustomer.Id);
                                _eventCustomerDiagnosisRepository.Save(eventCustomerDiagnosis);

                                successRows++;
                            }
                            catch (Exception ex)
                            {
                                _logger.Error(string.Format("While Parsing Diagnosis Report for CustomerId : {0} and EventId : {1} and Icd Code : {2}", model.CustomerId, model.EventId, model.Icd));
                                _logger.Error("Message: " + ex.Message);
                                _logger.Error("Stack Tracke: " + ex.StackTrace);
                            }
                        }

                        outboundUpload.SuccessUploadCount = successRows;
                        outboundUpload.FailedUploadCount = dataTable.Rows.Count - successRows;
                        outboundUpload.ParseEndTime = DateTime.Now;
                        outboundUpload.StatusId = successRows > 0 ? (long)OutboundUploadStatus.Parsed : (long)OutboundUploadStatus.ParseFailed;
                        _outboundUploadRepository.Save(outboundUpload);

                        if (successRows > 1)
                        {
                            System.IO.File.Move(fileLocation.PhysicalPath + file.Path, archivedFileLocation.PhysicalPath + file.Path);
                            ((IFileRepository)_fileRepository).MarkasArchived(file.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("While Parsing File.");
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Tracke: " + ex.StackTrace);

                        outboundUpload.StatusId = (long)OutboundUploadStatus.ParseFailed;
                        _outboundUploadRepository.Save(outboundUpload);
                    }
                }
            }
        }

        private DiagnosisReportViewModel GetPatientDiagnosisModel(DataRow row)
        {
            var model = new DiagnosisReportViewModel
            {
                CustomerId = GetRowValue(row, DiagnosisReportColumn.CustomerId),
                EventId = GetRowValue(row, DiagnosisReportColumn.EventId),
                Diagnosis = GetRowValue(row, DiagnosisReportColumn.Diagnosis),
                Accepted = GetRowValue(row, DiagnosisReportColumn.Status) == "Accepted",
                ClinicalMonitor = GetRowValue(row, DiagnosisReportColumn.ClinicalMonitor),
                ClinicalEvaluation = GetRowValue(row, DiagnosisReportColumn.ClinicalEvaluation),
                ClinicalAssessment = GetRowValue(row, DiagnosisReportColumn.ClinicalAssessment),
                ClinicalTreatment = GetRowValue(row, DiagnosisReportColumn.ClinicalTreatment),
                ClinicalComment = GetRowValue(row, DiagnosisReportColumn.ClinicalComment),
                Icd = GetRowValue(row, DiagnosisReportColumn.Icd),
                IsIcd10 = "1"
            };

            return model;
        }

        private static string GetRowValue(DataRow row, string fieldName, bool format = true)
        {
            if (row == null || row[fieldName] == null || row[fieldName].ToString().ToLower() == "null") return null;
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            if (format)
                return FormatSentence(row[fieldName].ToString().Trim());
            return row[fieldName].ToString().Trim();
        }

        private static string FormatSentence(string source)
        {
            var words = source.Split(' ').Select(t => t.ToCharArray()).ToList();
            words.ForEach(t =>
            {
                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = i.Equals(0) ? char.ToUpper(t[i]) : char.ToLower(t[i]);
                }
            });
            return string.Join(" ", words.Select(t => new string(t)));
        }
    }
}
