using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class OptumResultZipCreationPollingAgent : IOptumResultZipCreationPollingAgent
    {
        private readonly IZipHelper _zipHelper;

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ISftpCridentialManager _sftpCridentialManager;
        private readonly ILogger _logger;
        private readonly string _optumZipFolderDownloadFromPath;
        private readonly string _optumZipFolderPostToPath;
        private readonly IEnumerable<long> _accountIds;
        private readonly IEnumerable<long> _monarchAccountIds;
        private readonly string _monarchZipFolderPath;
        private readonly string _sftpResouceFilePath;
        private readonly string _monarchResultPdfArchive;
        public OptumResultZipCreationPollingAgent(IZipHelper zipHelper, ILogManager logManager, ISettings settings, ICorporateAccountRepository corporateAccountRepository, ISftpCridentialManager sftpCridentialManager)
        {
            _zipHelper = zipHelper;
            _corporateAccountRepository = corporateAccountRepository;
            _sftpCridentialManager = sftpCridentialManager;
            _logger = logManager.GetLogger("OptumSFTZip");

            _accountIds = settings.OptumZipFolderDownloadAccountIds;
            _optumZipFolderDownloadFromPath = settings.OptumZipFolderDownloadFromPath;
            _optumZipFolderPostToPath = settings.OptumZipFolderPostToPath;
            _monarchAccountIds = settings.MonarchAccountIds;
            _monarchZipFolderPath = settings.MonarchZipFolderPostToPath;
            _sftpResouceFilePath = settings.SftpResouceFilePath;

            _monarchResultPdfArchive = settings.MonarchResultPdfArchive;
        }

        public void CreateZipFile()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty()) return;
                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);
                foreach (var account in corporateAccounts)
                {
                    try
                    {
                        _logger.Info(string.Format("Creating zip for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                        var fileName = account.FolderName.Replace("_", "") + "_DATA_" + DateTime.Today.ToString("MMyydd");

                        var sourceFile = string.Format(_optumZipFolderDownloadFromPath, account.FolderName);
                        var destinationPath = string.Format(_optumZipFolderPostToPath, account.FolderName);

                        if (_monarchAccountIds.Contains(account.Id))
                        {
                            destinationPath = string.Format(_monarchZipFolderPath, account.FolderName);
                            fileName = account.FolderName + "_DATA_" + DateTime.Today.ToString("yyyyMMdd");
                        }

                        _logger.Info("Destination Path:" + destinationPath);

                        if (!DirectoryOperationsHelper.IsDirectoryExist(destinationPath))
                            Directory.CreateDirectory(destinationPath);

                        var destinationfile = destinationPath + "\\" + fileName + ".zip";

                        if (DirectoryOperationsHelper.IsFileExist(destinationfile))
                            DirectoryOperationsHelper.Delete(destinationfile);

                        var directoryToDeleteFrom = new DirectoryInfo(destinationPath);

                        if (_monarchAccountIds.Contains(account.Id))
                        {
                            var zipFiles = directoryToDeleteFrom.GetFiles(account.FolderName + "_DATA_*.zip");

                            foreach (var file in zipFiles)
                            {
                                _logger.Info("Deleting zip file : " + file.Name);
                                file.Delete();
                            }
                        }
                        else
                        {
                            var fileNotToBeDelete = GetFileNotDeleted();

                            var zipFiles = directoryToDeleteFrom.GetFiles(account.FolderName.Replace("_", "") + "_DATA_*.zip");
                            
                            foreach (var file in zipFiles)
                            {
                                if(fileNotToBeDelete.Any(x => file.Name.EndsWith(x)))
                                    continue;

                                _logger.Info("Deleting zip file : " + file.Name);
                                file.Delete();
                            }
                        }

                        _zipHelper.CreateZipFiles(sourceFile, destinationfile, true);


                        if (_monarchAccountIds.Contains(account.Id))
                        {
                            var sftpCridential = _sftpCridentialManager.Deserialize(_sftpResouceFilePath + account.Tag + ".xml");

                            try
                            {
                                ExportResultInSftp(fileName + ".zip", destinationfile, sftpCridential);
                            }
                            catch (Exception exception)
                            {
                                _logger.Error("message: " + exception.Message);
                                _logger.Error("stack trace: " + exception.StackTrace);
                            }

                            var archiveDestinationPath = string.Format(_monarchResultPdfArchive, account.FolderName);

                            DirectoryOperationsHelper.CreateDirectoryIfNotExist(archiveDestinationPath + "\\pdfs\\");

                            var sourceDir = new DirectoryInfo(sourceFile + "/pdfs/");
                            var destinationDir = new DirectoryInfo(archiveDestinationPath + "\\pdfs\\");

                            DeepCopy(sourceDir, destinationDir);
                            Directory.Delete(sourceFile + "/pdfs/", true);
                        }

                        _logger.Info("Zip File Created");
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Some Error occurred for Account Id " + account.Id + " Account Tag " + account.Tag);
                        _logger.Error("Message " + ex.Message);
                        _logger.Error("Stack Trace " + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some Error occurred ");
                _logger.Error("Message " + ex.Message);
                _logger.Error("Stack Trace " + ex.StackTrace);
            }
        }

        public List<string> GetFileNotDeleted()
        {
            var date = DateTime.Today;
            var list = new List<string>();

            for (int i = 1; i < 7; i++)
            {
                list.Add((date.AddDays(-i).ToString("MMyydd")) + ".zip");
            }
            return list;
        }

        public void DeepCopy(DirectoryInfo source, DirectoryInfo target)
        {
            // Recursively call the DeepCopy Method for each Directory
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                var subDirectoryInfo = target.CreateSubdirectory(dir.Name);
                _logger.Info("Creating Subdirectory: " + subDirectoryInfo.FullName);
                DeepCopy(dir, subDirectoryInfo);
            }

            _logger.Info("Source directory: " + source.FullName);
            _logger.Info("target directory: " + target.FullName);

            var files = source.GetFiles();

            _logger.Info(files.Count() + " files in Source Directory to Copy");

            // Go ahead and copy each file in "source" to the "target" directory
            foreach (FileInfo file in files)
            {
                var destinationFilePath = Path.Combine(target.FullName, file.Name);

                _logger.Info("Source File Path: " + file.FullName + " Destination File Path: " + destinationFilePath);

                if (File.Exists(destinationFilePath))
                    File.Delete(destinationFilePath);

                file.MoveTo(destinationFilePath);
            }
        }

        private void ExportResultInSftp(string fileName, string sourcePath, SftpCridential sftpCridential)
        {
            _logger.Info("Destination Path:  " + sftpCridential.SftpPath + "\\" + fileName);
            _logger.Info("Source Path: " + sourcePath);

            var processFtp = new ProcessFtp(_logger, sftpCridential.HostName, sftpCridential.UserName, sftpCridential.Password);
            processFtp.UploadSingleFile(sourcePath, sftpCridential.SftpPath, fileName);

            _logger.Info("Sending data to sftp succeded ");

        }
    }
}