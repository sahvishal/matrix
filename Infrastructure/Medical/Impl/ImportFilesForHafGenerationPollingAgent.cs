using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ImportFilesForHafGenerationPollingAgent : IImportFilesForHafGenerationPollingAgent
    {
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ILogger _logger;

        public ImportFilesForHafGenerationPollingAgent(ISettings settings, ILogManager logManager, IMediaRepository mediaRepository, ICorporateAccountRepository corporateAccountRepository)
        {
            _settings = settings;
            _mediaRepository = mediaRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _logger = logManager.GetLogger("ImportFilesForHafGeneration");
        }

        public void PollForFileImport()
        {
            try
            {
                var accounts = _corporateAccountRepository.GetAllHealthPlansForPrintAceAndMip();

                if (!accounts.Any())
                {
                    _logger.Info("No Health Plans found.");
                    return;
                }

                _logger.Info("File import started.");

                foreach (var corporateAccount in accounts)
                {
                    var sourceFilePath = string.Format(_settings.AcePdfSourceLocation, corporateAccount.FolderName, DateTime.Now.Year);

                    if (!Directory.Exists(sourceFilePath))
                    {
                        Directory.CreateDirectory(sourceFilePath);
                    }

                    ImportFiles("ACE", sourceFilePath, corporateAccount.FolderName);

                    ImportFiles("MIP", sourceFilePath, corporateAccount.FolderName);
                }

                _logger.Info("File import completed.");
            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
            
        }

        private void ImportFiles(string searchPattern, string sourcePath, string accountFolder)
        {
            _logger.Info(string.Format("Importing {0} files from {1}", searchPattern, sourcePath));

            var files = Directory.GetFiles(sourcePath, "*" + searchPattern + ".pdf");

            var archiveFolder = sourcePath + "\\Archive\\";
            if (!Directory.Exists(archiveFolder))
            {
                Directory.CreateDirectory(archiveFolder);
            }

            if (!files.Any())
            {
                _logger.Info(string.Format("No {0} files found to import.", searchPattern));
            }

            foreach (var file in files)
            {
                try
                {
                    var fileName = Path.GetFileName(file);

                    var fileNameArray = fileName.Split('_');
                    var folderName = string.Empty;
                    if (fileNameArray.Length > 0)
                    {
                        folderName = fileNameArray[0];
                        if (fileNameArray.Length > 1)
                        {
                            folderName += "_" + fileNameArray[1];
                        }
                        if (fileNameArray.Length > 2)
                        {
                            folderName += "_" + fileNameArray[2];
                        }
                    }


                    if (!string.IsNullOrEmpty(folderName))
                    {
                        var location = _mediaRepository.GetAceMipLocation(accountFolder, folderName, searchPattern);

                        _logger.Info("Copying file from " + file);

                        if (File.Exists(location.PhysicalPath + fileName))
                        {
                            File.Delete(location.PhysicalPath + fileName);
                        }

                        File.Copy(file, location.PhysicalPath + fileName, true);

                        _logger.Info("Copied file to " + location.PhysicalPath + fileName);

                        File.Move(file, archiveFolder + fileName);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Error copying file from {0}.\nMessage: {1}", file, ex.Message));
                }
            }

            _logger.Info(string.Format("{0} files imported.", searchPattern));
        }
    }
}
