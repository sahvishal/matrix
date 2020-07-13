using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.Enum;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Users.Domain;
using openDicom.Encoding;
using DateTime = System.DateTime;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class LoincLabDataPollingAgent : ILoincLabDataPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILoincLabDataRepository _loincLabDataRepository;
        private readonly ICsvReader _csvReader;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IOutboundUploadRepository _outboundUploadRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger _logger;

        private const string LogHeader = "MembID" + "," + "GMPI" + "," + "LOINC" + "," + "LOINCDesc" + "," + "ResultValue" + "," + "ResultUnits" + "," + "RefRange" + "," + "ErrorMessage";

        public LoincLabDataPollingAgent(ILogManager logManager, ISettings settings, ILoincLabDataRepository loincLabDataRepository, ICsvReader csvReader, IUniqueItemRepository<File> fileRepository, IOutboundUploadRepository outboundUploadRepository,
            IMediaRepository mediaRepository)
        {
            _settings = settings;
            _loincLabDataRepository = loincLabDataRepository;
            _csvReader = csvReader;
            _fileRepository = fileRepository;
            _outboundUploadRepository = outboundUploadRepository;
            _mediaRepository = mediaRepository;
            _logger = logManager.GetLogger("LonicLabDataParser");
        }

        public void Parse()
        {
            try
            {
                _logger.Info("Running Loinc Lab Data");

                if (!DirectoryOperationsHelper.CreateDirectoryIfNotExist(_settings.LoincLabDataPath))
                {
                    _logger.Info(string.Format("Folder could not be created. Please check path: {0} ", _settings.LoincLabDataPath));
                    return;
                }

                var loincMediaLocation = _mediaRepository.GetLoincMediaLocation();
                var archiveLocation = _mediaRepository.GetLoincArchiveMediaLocation();

                var loincLabfiles = DirectoryOperationsHelper.GetFiles(_settings.LoincLabDataPath, "*.csv");
                if (loincLabfiles.IsNullOrEmpty())
                {
                    _logger.Info(string.Format("No csv file found at following location {0}", _settings.LoincLabDataPath));
                }
                else
                {
                    UploadLoincFiles(loincLabfiles, loincMediaLocation.PhysicalPath, (long)OutboundUploadType.LoincLabData);
                }

                var uploadedFiles = _outboundUploadRepository.GetAllUploadedFilesByType((long)OutboundUploadType.LoincLabData);
                if (uploadedFiles.IsNullOrEmpty())
                {
                    _logger.Info("No new files uploaded for Loinc Lab Data.");
                    return;
                }

                foreach (var uploadedFile in uploadedFiles)
                {
                    try
                    {
                        var file = GetFile(uploadedFile.FileId);

                        if (!System.IO.File.Exists(loincMediaLocation.PhysicalPath + file.Path))
                        {
                            _logger.Info("File not found : " + loincMediaLocation.PhysicalPath + file.Path);
                            continue;
                        }

                        uploadedFile.StatusId = (long)OutboundUploadStatus.Parsing;
                        uploadedFile.ParseStartTime = DateTime.Now;
                        _outboundUploadRepository.Save(uploadedFile);

                        _logger.Info("Importing File : " + file.Path);

                        var loincLabData = _csvReader.ReadWithTextQualifierLargeData(loincMediaLocation.PhysicalPath + file.Path);

                        var csvStringBuilder = new StringBuilder();
                        csvStringBuilder.Append(LogHeader + Environment.NewLine);

                        long totalRows = 0, successRows = 0;

                        foreach (var dataTable in loincLabData)
                        {
                            if (dataTable.Rows.Count == 0)
                            {
                                _logger.Info("No records found for file : " + loincMediaLocation.PhysicalPath + file.Path);
                                continue;
                            }
                            foreach (DataRow row in dataTable.Rows)
                            {
                                totalRows++;
                                LoincLabDataEditModel model = null;

                                model = GetLoincLabData(row);

                                var errorRow = model.MemberId + "," + model.Gmpi + "," + model.Loinc + "," + model.LoincDescription + "," + model.ResultValue + "," + model.ResultUnits + "," + model.RefRange + "," + model.DoS;

                                try
                                {
                                    if (model != null && !model.IsEmpty())
                                    {
                                        var domain = new LoincLabData
                                        {
                                            MemberId = model.MemberId,
                                            Gmpi = model.Gmpi,
                                            Loinc = model.Loinc,
                                            LoincDescription = model.LoincDescription,
                                            ResultValue = model.ResultValue,
                                            ResultUnits = model.ResultUnits,
                                            RefRange = model.RefRange,
                                            DateOfService = GetRowDateValue(model.DoS),
                                            Year = DateTime.Today.Year,
                                            DateCreated = DateTime.Now,
                                            UploadId = uploadedFile.Id,

                                        };

                                        _loincLabDataRepository.Save(domain);
                                    }

                                    successRows++;
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error(string.Format("Some Error Occurred Message: {0} \n stack Trace: {1}", ex.Message, ex.StackTrace));
                                    csvStringBuilder.Append(errorRow + "," + ex.Message + Environment.NewLine);
                                }
                            }
                        }

                        if (successRows < totalRows)
                        {
                            var logFileName = file.Path + "_Log.csv";

                            var logFile = SaveLogFile(_settings.LoincLabDataPath + logFileName, csvStringBuilder);
                            uploadedFile.LogFileId = logFile.Id;
                        }

                        uploadedFile.SuccessUploadCount = successRows;
                        uploadedFile.FailedUploadCount = totalRows - successRows;
                        uploadedFile.ParseEndTime = DateTime.Now;
                        uploadedFile.StatusId = successRows > 0 ? (long)OutboundUploadStatus.Parsed : (long)OutboundUploadStatus.ParseFailed;
                        _outboundUploadRepository.Save(uploadedFile);

                        if (successRows > 1)
                        {
                            System.IO.File.Move(loincMediaLocation.PhysicalPath + file.Path, archiveLocation.PhysicalPath + file.Path);
                            ((IFileRepository)_fileRepository).MarkasArchived(file.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        uploadedFile.StatusId = (long)OutboundUploadStatus.ParseFailed;
                        _outboundUploadRepository.Save(uploadedFile);
                        _logger.Error(string.Format("while Parsing File"));
                        _logger.Error("Ex Message" + ex.Message);
                        _logger.Error("Ex Stack Trace " + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error while Parsing Loinc Lab Data Files.");
                _logger.Error(ex);
            }
        }

        private LoincLabDataEditModel GetLoincLabData(DataRow row)
        {
            var model = new LoincLabDataEditModel
             {
                 MemberId = GetRowValue(row, "MembID"),
                 Gmpi = GetRowValue(row, "GMPI"),
                 Loinc = GetRowValue(row, "LOINC"),
                 ResultValue = GetRowValue(row, "ResultValue"),
                 ResultUnits = GetRowValue(row, "ResultUnits"),
                 RefRange = GetRowValue(row, "RefRange"),
                 DoS = GetRowValue(row, "DOS")
             };

            //try
            //{
            //    model.LoincDescription = GetRowValue(row, "LOINCDesc");
            //}
            //catch (Exception ex)
            //{
            //   // _logger.Error("exception: " + exception.Message);
            //}

            return model;
        }

        private string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;

            return row[fieldName].ToString().Trim();
        }

        private DateTime? GetRowDateValue(string fieldValue)
        {
            if (string.IsNullOrEmpty(fieldValue)) return null;

            return DateTime.Parse(fieldValue);
        }

        private File GetFile(long fileId)
        {
            var file = _fileRepository.GetById(fileId);

            return file;
        }

        private void UploadLoincFiles(IEnumerable<string> sourceFiles, string uploadMediaLocation, long typeId)
        {
            foreach (var sourceFile in sourceFiles)
            {
                try
                {
                    using (var scope = new TransactionScope())
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

                        scope.Complete();
                    }
                }
                catch (Exception exception)
                {
                    _logger.Info("some exception occured while Moving File type : " + ((OutboundUploadType)typeId).GetDescription() + " and file name : " + sourceFile);
                    _logger.Info("message " + exception.Message);
                    _logger.Info("stack Trace " + exception.StackTrace);
                }
            }
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
