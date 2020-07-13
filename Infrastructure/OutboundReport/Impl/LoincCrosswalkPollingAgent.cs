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
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class LoincCrosswalkPollingAgent : ILoincCrosswalkPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILoincCrosswalkRepository _loincCrosswalkRepository;
        private readonly ICsvReader _csvReader;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IOutboundUploadRepository _outboundUploadRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger _logger;

        private const string LogHeader = "LOINC_NUM" + "," + "COMPONENT" + "," + "SYSTEM" + "," + "METHOD_TYP" + "," + "VersionLastChanged" + "," + "DefinitionDescription" + "," + "FORMULA" + "," + "SPECIES" + "," + "EXMPL_ANSWERS" + "," +
            "SURVEY_QUEST_TEXT" + "," + "SURVEY_QUEST_SRC" + "," + "UNITSREQUIRED" + "," + "SUBMITTED_UNITS" + "," + "CDISC_COMMON_TESTS" + "," + "HL7_FIELD_SUBFIELD_ID" + "," + "EXTERNAL_COPYRIGHT_NOTICE" + "," + "EXAMPLE_UNITS" + "," +
            "LONG_COMMON_NAME" + "," + "ErrorMessage";

        public LoincCrosswalkPollingAgent(ILogManager logManager, ISettings settings, ILoincCrosswalkRepository loincCrosswalkRepository, ICsvReader csvReader, IUniqueItemRepository<File> fileRepository, IOutboundUploadRepository outboundUploadRepository,
            IMediaRepository mediaRepository)
        {
            _settings = settings;
            _loincCrosswalkRepository = loincCrosswalkRepository;
            _csvReader = csvReader;
            _fileRepository = fileRepository;
            _outboundUploadRepository = outboundUploadRepository;
            _mediaRepository = mediaRepository;
            _logger = logManager.GetLogger("LonicCrosswalkParser");
        }

        public void Parse()
        {
            try
            {
                _logger.Info("Running Loinc Crosswalk");

                if (!DirectoryOperationsHelper.CreateDirectoryIfNotExist(_settings.LoincCrosswalkPath))
                {
                    _logger.Info(string.Format("Folder could not be created. Please check path: {0} ", _settings.LoincCrosswalkPath));
                    return;
                }

                var loincMediaLocation = _mediaRepository.GetLoincMediaLocation();
                var archiveLocation = _mediaRepository.GetLoincArchiveMediaLocation();

                var loincCrosswalkfiles = DirectoryOperationsHelper.GetFiles(_settings.LoincCrosswalkPath, "*.csv");
                if (loincCrosswalkfiles.IsNullOrEmpty())
                {
                    _logger.Info(string.Format("No csv file found at following location {0}", _settings.LoincCrosswalkPath));
                }
                else
                {
                    UploadLoincFiles(loincCrosswalkfiles, loincMediaLocation.PhysicalPath, (long)OutboundUploadType.LoincCrosswalk);
                }

                var uploadedFiles = _outboundUploadRepository.GetAllUploadedFilesByType((long)OutboundUploadType.LoincCrosswalk);
                if (uploadedFiles.IsNullOrEmpty())
                {
                    _logger.Info("No new files uploaded for Loinc Crosswalk.");
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

                        var dataTable = _csvReader.CsvToDataTable(loincMediaLocation.PhysicalPath + file.Path, true, ",");

                        var csvStringBuilder = new StringBuilder();
                        csvStringBuilder.Append(LogHeader + Environment.NewLine);

                        long totalRows = 0, successRows = 0;

                        if (dataTable.Rows.Count == 0)
                        {
                            _logger.Info("No records found for file : " + loincMediaLocation.PhysicalPath + file.Path);
                            continue;
                        }
                        foreach (DataRow row in dataTable.Rows)
                        {
                            totalRows++;
                            var model = GetLoincCrosswalk(row);
                            var errorRow = model.LoincNumber + "," + model.Component + "," + model.System + "," + model.MethodType + "," + model.VersionLastChanged + "," + model.DefinitionDescription + "," + model.Formula + model.Species
                                + model.ExampleAnswers + "," + model.SurveyQuestionText + "," + model.SurveyQuestionSource + "," + model.UnitsRequired + "," + model.SubmittedUnits + "," + model.CdiscCommonTests + "," + model.Hl7FieldSubfieldId
                                + model.ExternalCopyrightNotice + model.ExampleUnits + model.LongCommonName;

                            try
                            {
                                if (!model.IsEmpty())
                                {
                                    model.Year = DateTime.Today.Year;
                                    model.DateCreated = DateTime.Now;
                                    model.UploadId = uploadedFile.Id;
                                }
                                _loincCrosswalkRepository.Save(model);
                                successRows++;
                            }
                            catch (Exception ex)
                            {
                                _logger.Error(string.Format("Some Error Occurred Message: {0} \n stack Trace: {1}", ex.Message, ex.StackTrace));
                                csvStringBuilder.Append(errorRow + "," + ex.Message + Environment.NewLine);
                            }
                        }

                        if (successRows < totalRows)
                        {
                            var logFileName = file.Path + "_Log.csv";

                            var logFile = SaveLogFile(_settings.LoincCrosswalkPath + logFileName, csvStringBuilder);
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
                _logger.Error("Error while Parsing Loinc Crosswalk Files.");
                _logger.Error(ex);
            }
        }

        private LoincCrosswalk GetLoincCrosswalk(DataRow row)
        {
            return new LoincCrosswalk
            {
                LoincNumber = GetRowValue(row, "LOINC_NUM"),
                Component = GetRowValue(row, "COMPONENT"),
                System = GetRowValue(row, "SYSTEM"),
                MethodType = GetRowValue(row, "METHOD_TYP"),
                VersionLastChanged = GetRowValue(row, "VersionLastChanged"),
                DefinitionDescription = GetRowValue(row, "DefinitionDescription"),
                Formula = GetRowValue(row, "FORMULA"),
                Species = GetRowValue(row, "SPECIES"),
                ExampleAnswers = GetRowValue(row, "EXMPL_ANSWERS"),
                SurveyQuestionText = GetRowValue(row, "SURVEY_QUEST_TEXT"),
                SurveyQuestionSource = GetRowValue(row, "SURVEY_QUEST_SRC"),
                UnitsRequired = GetRowValue(row, "UNITSREQUIRED"),
                SubmittedUnits = GetRowValue(row, "SUBMITTED_UNITS"),
                CdiscCommonTests = GetRowValue(row, "CDISC_COMMON_TESTS"),
                Hl7FieldSubfieldId = GetRowValue(row, "HL7_FIELD_SUBFIELD_ID"),
                ExternalCopyrightNotice = GetRowValue(row, "EXTERNAL_COPYRIGHT_NOTICE"),
                ExampleUnits = GetRowValue(row, "EXAMPLE_UNITS"),
                LongCommonName = GetRowValue(row, "LONG_COMMON_NAME"),
            };
        }

        private string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;

            return row[fieldName].ToString().Trim();
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
