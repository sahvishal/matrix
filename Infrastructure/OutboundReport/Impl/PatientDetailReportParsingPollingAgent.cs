using System;
using System.Data;
using System.Globalization;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Enum;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class PatientDetailReportParsingPollingAgent : IPatientDetailReportParsingPollingAgent
    {
        private readonly IOutboundUploadRepository _outboundUploadRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ICsvReader _csvReader;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ILogger _logger;

        private readonly string _accountIds;

        public PatientDetailReportParsingPollingAgent(IOutboundUploadRepository outboundUploadRepository, ILogManager logManager, IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository, ICsvReader csvReader,
            IEventCustomerRepository eventCustomerRepository, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository)
        {
            _outboundUploadRepository = outboundUploadRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _csvReader = csvReader;
            _eventCustomerRepository = eventCustomerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _logger = logManager.GetLogger("PatientDetail_Parse");
            _accountIds = settings.FloridaBlueAccountId;
        }

        public void PollForPatientDetailReportParsing()
        {
            var outboundUploads = _outboundUploadRepository.GetAllUploadedFilesByType((long)OutboundUploadType.PatientDetail);
            if (outboundUploads == null || !outboundUploads.Any())
            {
                _logger.Info("No new files uploaded.");
                return;
            }

            var accountIds = _accountIds.Split(',');
            foreach (var accountId in accountIds)
            {
                var account = _corporateAccountRepository.GetById(Convert.ToInt32(accountId));

                var fileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "PatientDetail");
                var archivedFileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "PatientDetailArchived");

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

                        DataTable table = _csvReader.ReadWithTextQualifier(fileLocation.PhysicalPath + file.Path);

                        if (table.Rows.Count <= 0)
                        {
                            _logger.Info("No rows found.");
                            outboundUpload.ParseEndTime = DateTime.Now;
                            outboundUpload.StatusId = (long)OutboundUploadStatus.Parsed;
                            _outboundUploadRepository.Save(outboundUpload);
                            continue;
                        }

                        var successRows = 0;

                        foreach (DataRow row in table.Rows)
                        {
                            var model = GetPatientDetailModel(row);
                            try
                            {
                                if (string.IsNullOrEmpty(model.MedicalRecordNo))
                                {
                                    _logger.Info("MedicalRecordNo empty for MemberId : " + model.MaPlanMemberId);
                                    continue;
                                }

                                var medicalRecordNo = Convert.ToInt64(model.MedicalRecordNo);

                                var eventCustomer = _eventCustomerRepository.GetByCustomerIdAndEventDate(medicalRecordNo, model.AwvDate);
                                if (eventCustomer == null)
                                {
                                    _logger.Info("Event Customer not found for Medical Record No : " + model.MedicalRecordNo + " and Awv Date : " + model.AwvDate);
                                    continue;
                                }

                                eventCustomer.PatientDetailId = model.Id;

                                _eventCustomerRepository.Save(eventCustomer);

                                successRows++;
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("While Parsing Patient Detail for Medical Record No : " + model.MedicalRecordNo);
                                _logger.Error("Message: " + ex.Message);
                                _logger.Error("Stack Tracke: " + ex.StackTrace);
                            }
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
                        _logger.Error("While Parsing File.");
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Tracke: " + ex.StackTrace);

                        outboundUpload.StatusId = (long)OutboundUploadStatus.ParseFailed;
                        _outboundUploadRepository.Save(outboundUpload);
                    }
                }
            }
        }

        private PatientDetailReportViewModel GetPatientDetailModel(DataRow row)
        {
            var model = new PatientDetailReportViewModel
            {
                SiteName = GetRowValue(row, PatientDetailReportColumn.SiteName),
                Id = Convert.ToInt64(GetRowValue(row, PatientDetailReportColumn.Id)),
                CmsHicn = GetRowValue(row, PatientDetailReportColumn.CmsHicn),
                FirstName = GetRowValue(row, PatientDetailReportColumn.FirstName),
                LastName = GetRowValue(row, PatientDetailReportColumn.LastName),
                AwvDate = Convert.ToDateTime(GetRowValue(row, PatientDetailReportColumn.AwvDate)),
                Dob = Convert.ToDateTime(GetRowValue(row, PatientDetailReportColumn.Dob)),
                Age = !string.IsNullOrEmpty(GetRowValue(row, PatientDetailReportColumn.Age)) ? Convert.ToInt32(GetRowValue(row, PatientDetailReportColumn.Age)) : 0,
                Gender = GetRowValue(row, PatientDetailReportColumn.Gender),
                Race = GetRowValue(row, PatientDetailReportColumn.Address),
                Address = GetRowValue(row, PatientDetailReportColumn.Address),
                City = GetRowValue(row, PatientDetailReportColumn.City),
                State = GetRowValue(row, PatientDetailReportColumn.State),
                Zip = GetRowValue(row, PatientDetailReportColumn.Zip),
                Phone = GetRowValue(row, PatientDetailReportColumn.Phone),
                Email = GetRowValue(row, PatientDetailReportColumn.Email),
                PrimaryCareMd = GetRowValue(row, PatientDetailReportColumn.PrimaryCareMd),
                Providers = GetRowValue(row, PatientDetailReportColumn.Providers),
                Medications = GetRowValue(row, PatientDetailReportColumn.Medications),
                Allergies = GetRowValue(row, PatientDetailReportColumn.Allergies),
                ESignature = GetRowValue(row, PatientDetailReportColumn.ESignature),
                MedicalRecordNo = GetRowValue(row, PatientDetailReportColumn.MedicalRecordNo),
                MaPlan = GetRowValue(row, PatientDetailReportColumn.MaPlan),
                MaPlanMemberId = GetRowValue(row, PatientDetailReportColumn.MaPlanMemberId),
                AwvStatus = GetRowValue(row, PatientDetailReportColumn.AwvStatus),
                SignedDateTime = GetRowValue(row, PatientDetailReportColumn.SignedDateTime),
                MetalType = GetRowValue(row, PatientDetailReportColumn.MetalType),
                SignedByNpi = GetRowValue(row, PatientDetailReportColumn.SignedByNpi)
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
    }
}
