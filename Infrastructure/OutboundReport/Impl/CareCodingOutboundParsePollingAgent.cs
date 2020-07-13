using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Enum;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class CareCodingOutboundParsePollingAgent : ICareCodingOutboundParsePollingAgent
    {
        private readonly IOutboundUploadRepository _outboundUploadRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly ICareCodingOutboundFactory _careCodingOutboundFactory;
        private readonly ICareCodingOutboundRepository _careCodingOutboundRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ILogger _logger;

        private readonly string _accountIds;

        private const string LogHeader = "Tenant_Id" + "|" + "Client_Id" + "|" + "Campaign_Id" + "|" + "Individual_ID_Number" + "|" + "Contract_Number" + "|" + "Contract_Person_Number" + "|" + "Consumer_Id" + "|" + ",ErrorMessage";

        public CareCodingOutboundParsePollingAgent(IOutboundUploadRepository outboundUploadRepository, ILogManager logManager, IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository, IPipeDelimitedReportHelper pipeDelimitedReportHelper,
            IChaseOutboundRepository chaseOutboundRepository, ICareCodingOutboundFactory careCodingOutboundFactory, ICareCodingOutboundRepository careCodingOutboundRepository, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository)
        {
            _outboundUploadRepository = outboundUploadRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _chaseOutboundRepository = chaseOutboundRepository;
            _careCodingOutboundFactory = careCodingOutboundFactory;
            _careCodingOutboundRepository = careCodingOutboundRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _logger = logManager.GetLogger("CareCoding_Outbound_Import");
            _accountIds = settings.FloridaBlueAccountId;
        }

        public void PollForOutboundCareCoding()
        {
            var outboundUploads = _outboundUploadRepository.GetAllUploadedFilesByType((long)OutboundUploadType.CareCodingOutbound);
            if (outboundUploads == null || !outboundUploads.Any())
            {
                _logger.Info("No new files uploaded.");
                return;
            }

            var accountIds = _accountIds.Split(',');

            foreach (var accountId in accountIds)
            {
                var account = _corporateAccountRepository.GetById(Convert.ToInt32(accountId));

                var fileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "CareCoding");
                var archivedFileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "CareCodingArchived");

                foreach (var outboundUpload in outboundUploads)
                {
                    try
                    {
                        outboundUpload.StatusId = (long)OutboundUploadStatus.Parsing;
                        outboundUpload.ParseStartTime = DateTime.Now;
                        _outboundUploadRepository.Save(outboundUpload);

                        var file = _fileRepository.GetById(outboundUpload.FileId);
                        _logger.Info("Importing File : " + file.Path);

                        DataTable table = _pipeDelimitedReportHelper.Read(fileLocation.PhysicalPath + file.Path);

                        if (table.Rows.Count <= 0)
                        {
                            _logger.Info("No rows found.");
                            outboundUpload.ParseEndTime = DateTime.Now;
                            outboundUpload.StatusId = (long)OutboundUploadStatus.Parsed;
                            _outboundUploadRepository.Save(outboundUpload);
                            continue;
                        }

                        var csvStringBuilder = new StringBuilder();
                        csvStringBuilder.Append(LogHeader + Environment.NewLine);

                        var successRows = 0;

                        foreach (DataRow row in table.Rows)
                        {
                            var model = GetCareCodingOutboundModel(row);
                            var errorRow = model.TenantId + "|" + model.ClientId + "|" + model.CampaignId + "|" + model.IndividualIdNumber + "|" + model.ContractNumber + "|" + model.ContractPersonNumber + "|" + model.ConsumerId;
                            try
                            {
                                var chaseOutbound = _chaseOutboundRepository.GetByIndividualIdNumber(model.IndividualIdNumber, model.ConsumerId);
                                if (chaseOutbound == null)
                                {
                                    csvStringBuilder.Append(errorRow + "|" + "Could not find a Customer with Individual_Id_Number : " + model.IndividualIdNumber + " and Consumer_Id : " + model.ConsumerId);
                                    continue;
                                }
                                /*var existingCareCoding = _careCodingOutboundRepository.GetByCustomerId(chaseOutbound.CustomerId);*/
                                var careCodingOutbound = _careCodingOutboundFactory.Create(model);
                                careCodingOutbound.CustomerId = chaseOutbound.CustomerId;

                                if (!string.IsNullOrEmpty(model.MedicalCodeServiceDate))
                                {
                                    try
                                    {
                                        careCodingOutbound.MedicalCodeServiceDate = Convert.ToDateTime(model.MedicalCodeServiceDate);
                                    }
                                    catch (Exception)
                                    {
                                        csvStringBuilder.Append(errorRow + "|" + "Medical_Code_Service_Date is not in correct format. Please Provide in DD/MM/YYYY" + Environment.NewLine);
                                        continue;
                                    }
                                }

                                _careCodingOutboundRepository.Save(careCodingOutbound);

                                successRows++;
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("While Parsing Care Coding");
                                _logger.Error("Message: " + ex.Message);
                                _logger.Error("Stack Tracke: " + ex.StackTrace);

                                csvStringBuilder.Append(errorRow + "|" + ex.Message + Environment.NewLine);
                            }
                        }

                        if (successRows < table.Rows.Count)
                        {
                            var logFileName = _pipeDelimitedReportHelper.GetReportName(ReportType.Exception);

                            var logFile = SaveLogFile(fileLocation.PhysicalPath + logFileName + ".txt", csvStringBuilder);
                            outboundUpload.LogFileId = logFile.Id;
                        }

                        outboundUpload.SuccessUploadCount = successRows;
                        outboundUpload.FailedUploadCount = table.Rows.Count - successRows;
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
                        _logger.Error("While Parsing File ");
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Tracke: " + ex.StackTrace);

                        outboundUpload.StatusId = (long)OutboundUploadStatus.ParseFailed;
                        _outboundUploadRepository.Save(outboundUpload);
                    }
                }
            }
        }

        private CareCodingOutboundViewModel GetCareCodingOutboundModel(DataRow row)
        {
            var model = new CareCodingOutboundViewModel
            {
                TenantId = GetRowValue(row, CareCodingOutboundColumn.TenantId),
                CampaignId = GetRowValue(row, CareCodingOutboundColumn.CampaignId),
                IndividualIdNumber = GetRowValue(row, CareCodingOutboundColumn.IndividualIdNumber),
                ClientId = GetRowValue(row, CareCodingOutboundColumn.ClientId),
                ContractNumber = GetRowValue(row, CareCodingOutboundColumn.ContractNumber),
                ContractPersonNumber = GetRowValue(row, CareCodingOutboundColumn.ContractPersonNumber),
                ConsumerId = GetRowValue(row, CareCodingOutboundColumn.ConsumerId),
                CampaignCode = GetRowValue(row, CareCodingOutboundColumn.CampaignCode),
                CampaignMemberId = GetRowValue(row, CareCodingOutboundColumn.CampaignMemberId),
                CareCodeLabType = GetRowValue(row, CareCodingOutboundColumn.CareCodeLabType),
                CareCodeLabDesc = GetRowValue(row, CareCodingOutboundColumn.CareCodeLabDesc),
                StatusOfCoding = GetRowValue(row, CareCodingOutboundColumn.StatusOfCoding),
                MedicalCode = GetRowValue(row, CareCodingOutboundColumn.MedicalCode),
                MedicalCodeType = GetRowValue(row, CareCodingOutboundColumn.MedicalCodeType),
                MedicalCodeServiceDate = GetRowValue(row, CareCodingOutboundColumn.MedicalCodeServiceDate)
            };

            return model;
        }

        private static string GetRowValue(DataRow row, string fieldName, bool format = true)
        {
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
    }
}
