using System;
using System.Collections.Generic;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.Enum;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class OutboundFileImportPollingAgent : IOutboundFileImportPollingAgent
    {
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IOutboundUploadRepository _outboundUploadRepository;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ILogger _logger;

        private readonly string _accountIds;

        public OutboundFileImportPollingAgent(ISettings settings, IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository, IOutboundUploadRepository outboundUploadRepository,
            IPipeDelimitedReportHelper pipeDelimitedReportHelper, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ILogManager logManager)
        {
            _settings = settings;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _outboundUploadRepository = outboundUploadRepository;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _corporateAccountRepository = corporateAccountRepository;

            _accountIds = settings.FloridaBlueAccountId;
            _logger = logManager.GetLogger("OutboundFileImport");
        }

        public void PollForOutboundFileImport()
        {
            try
            {
                _logger.Info("entering in service");
                var accountIds = _accountIds.Split(',');

                foreach (var accountId in accountIds)
                {
                    var account = _corporateAccountRepository.GetById(Convert.ToInt32(accountId));

                    _logger.Info("Getting files for " + account.Tag);

                    var sourceLocation = string.Format(_settings.OutboundSourceFileLocation, account.FolderName);

                    var chaseOutboundFileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "Chase");
                    var careCodingOutboundFileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "CareCoding");
                    var patientDetailFileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "PatientDetail");
                    var diagnosisReportFileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "DiagnosisReport");

                    var chaseFiles = Directory.GetFiles(sourceLocation, _pipeDelimitedReportHelper.GetReportName(ReportType.ChaseOutbound) + "*.txt");
                    UploadOutboundFiles(chaseFiles, chaseOutboundFileLocation.PhysicalPath, (long)OutboundUploadType.ChaseOutbound);

                    var careCodingFiles = Directory.GetFiles(sourceLocation, _pipeDelimitedReportHelper.GetReportName(ReportType.CareCodingOutbound) + "*.txt");
                    UploadOutboundFiles(careCodingFiles, careCodingOutboundFileLocation.PhysicalPath, (long)OutboundUploadType.CareCodingOutbound);

                    var patientDetailFiles = Directory.GetFiles(sourceLocation, "*" + _pipeDelimitedReportHelper.GetReportName(ReportType.PatientDetail) + "*.csv");
                    UploadOutboundFiles(patientDetailFiles, patientDetailFileLocation.PhysicalPath, (long)OutboundUploadType.PatientDetail);

                    var diagnosisReportFiles = Directory.GetFiles(sourceLocation, "*" + _pipeDelimitedReportHelper.GetReportName(ReportType.DiagnosisReport) + "*.csv");
                    UploadOutboundFiles(diagnosisReportFiles, diagnosisReportFileLocation.PhysicalPath, (long)OutboundUploadType.DiagnosisReport);
                }
            }
            catch (Exception exception)
            {
                _logger.Info("some exception occured while Importing File");
                _logger.Info("message " + exception.Message);
                _logger.Info("stack Trace " + exception.StackTrace);
            }
        }

        private void UploadOutboundFiles(IEnumerable<string> sourceFiles, string uploadMediaLocation, long typeId)
        {
            foreach (var sourceFile in sourceFiles)
            {
                try
                {
                    var fileName = Path.GetFileName(sourceFile);
                    var destinationFile = uploadMediaLocation + fileName;
                    System.IO.File.Move(sourceFile, destinationFile);

                    var fileInfo = new FileInfo(destinationFile);

                    var file = _fileRepository.Save(new File
                    {
                        Path = fileInfo.Name,
                        FileSize = fileInfo.Length,
                        Type = FileType.Csv,
                        UploadedBy = new OrganizationRoleUser(1),
                        UploadedOn = DateTime.Now
                    });

                    _outboundUploadRepository.Save(new OutboundUpload
                    {
                        FileId = file.Id,
                        TypeId = typeId,
                        StatusId = (long)OutboundUploadStatus.Pending,
                        UploadTime = DateTime.Now
                    });
                }
                catch (Exception exception)
                {
                    _logger.Info("some exception occured while Moving File type " + ((OutboundUploadType)typeId).GetDescription());
                    _logger.Info("message " + exception.Message);
                    _logger.Info("stack Trace " + exception.StackTrace);
                }
            }
        }
    }
}
