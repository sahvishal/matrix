using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ArchiveResultDataPollingAgent : IArchiveResultDataPollingAgent
    {

        private readonly ICustomSettingManager _customSettingManager;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventRepository _eventRepository;

        private readonly ILogger _logger;
        private readonly string _aricheResultCustomSettingsPath;
        private readonly int _archiveResultDataForOlderThanDays;
        private readonly string _aricheResultCustomPath;
        private readonly string _mediaLocation;
        private readonly bool _stopMediaArchiveService;
        public ArchiveResultDataPollingAgent(ILogManager logManager, ISettings settings, ICustomSettingManager customSettingManager, IMediaRepository mediaRepository, IEventRepository eventRepository)
        {

            _customSettingManager = customSettingManager;
            _mediaRepository = mediaRepository;
            _eventRepository = eventRepository;
            _mediaLocation = settings.MediaLocation;
            _stopMediaArchiveService = settings.StopMediaArchiveService;

            _logger = logManager.GetLogger("ArchiveResultDataPollingAgent");

            _aricheResultCustomSettingsPath = settings.ArchiveResultDataSettingsPath;
            _archiveResultDataForOlderThanDays = settings.ArchiveResultDataForOlderThanDays;
            _aricheResultCustomPath = settings.ArchiveMediaLocation;

        }

        public void PollToArchiveResultData()
        {
            try
            {
                if (_stopMediaArchiveService)
                {
                    _logger.Info("Archive Service has been stoped"); 
                    return;
                }

                var customSettings = _customSettingManager.Deserialize(_aricheResultCustomSettingsPath);

                var exportToTime = DateTime.Now.AddDays(-_archiveResultDataForOlderThanDays);
                var exportFromTime = customSettings.LastTransactionDate.HasValue ? customSettings.LastTransactionDate.Value.Date : customSettings.LastTransactionDate;

                var eventIds = _eventRepository.GetEventsToArchive(exportToTime.Date, exportFromTime);

                // eventIds = eventIds.OrderByDescending(o => o);

                if (eventIds.IsNullOrEmpty())
                {
                    _logger.Info("No Data found to Archive Date to " + exportToTime.ToShortDateString() + " Date From " + (exportFromTime ?? DateTime.MinValue).ToShortDateString());
                }
                else
                {
                    _logger.Info("Total number of Records found to Archiv " + eventIds.Count() + " Date to " + exportToTime.ToShortDateString() + " Date From " + (exportFromTime ?? DateTime.MinValue).ToShortDateString());

                    foreach (var eventId in eventIds)
                    {
                        try
                        {
                            _logger.Info("==========Moving result Packet Data started For EventID " + eventId + "===============\n\n");
                            var resultPacket = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
                            var sourceFolderPath = resultPacket.PhysicalPath;

                            if (!sourceFolderPath.Contains(_aricheResultCustomPath))
                            {
                                MoveFileToArchiveFolder(resultPacket);
                                _logger.Info("==========Moving result Packet Data completed For EventID " + eventId + "===============\n\n");
                            }
                            else
                            {
                                _logger.Info("==========Result Packet for EventID " + eventId + " Already Archived===============\n\n");
                            }

                            _logger.Info("==========Moving Scanned Document started For EventID " + eventId + "===============\n\n");
                            var scannedDoucment = _mediaRepository.GetScannedDocumentStorageFileLocation(eventId);
                            sourceFolderPath = scannedDoucment.PhysicalPath;

                            if (!sourceFolderPath.Contains(_aricheResultCustomPath))
                            {
                                MoveFileToArchiveFolder(scannedDoucment);
                                _logger.Info("==========Moving Scanned Document Zip for EventID " + eventId + "===============");

                                var scannedDoumentLocation = _mediaRepository.GetScannedDocumentStorageFolderLocation();
                                var fileName = eventId + ".zip";
                                sourceFolderPath = scannedDoumentLocation.PhysicalPath + fileName;

                                if (!sourceFolderPath.Contains(_aricheResultCustomPath))
                                {
                                    ScannedDocumentZipFolder(scannedDoumentLocation, fileName);
                                }

                                _logger.Info("==========Moving Scanned Document completed For EventID " + eventId + "===============\n\n");
                            }
                            else
                            {
                                _logger.Info("==========Scanned Document for EventID " + eventId + " Already Archived ===============");
                            }

                            _logger.Info("==========Moving Kyn Integration Output Data started For EventID " + eventId + "===============\n\n");
                            var kynData = _mediaRepository.GetKynIntegrationOutputDataLocation(eventId, false);

                            sourceFolderPath = kynData.PhysicalPath;

                            if (!sourceFolderPath.Contains(_aricheResultCustomPath))
                            {
                                MoveFileToArchiveFolder(kynData);
                                _logger.Info("==========Moving Kyn Integration Output Data completed For EventID " + eventId + "===============\n\n");
                            }
                            else
                            {
                                _logger.Info("==========Kyn Integration Output Data For EventID " + eventId + " Already Archived===============\n\n");
                            }

                            _logger.Info("==========Moving Result Media started For EventID " + eventId + "===============\n\n");
                            var resultMedia = _mediaRepository.GetResultMediaFileLocation(eventId, false);

                            sourceFolderPath = resultMedia.PhysicalPath;

                            if (!sourceFolderPath.Contains(_aricheResultCustomPath))
                            {
                                MoveFileToArchiveFolder(resultMedia);
                                _logger.Info("==========Moving Result Media  completed For EventID " + eventId + "===============\n\n");
                            }
                            else
                            {
                                _logger.Info("==========Result Media For EventID " + eventId + " Already Archived===============\n\n");
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Error occured for eventId: {0} while moving Result Data Message: {1} \n stack Trace: {2}", eventId, ex.Message, ex.StackTrace));
                        }
                    }
                }

                customSettings.LastTransactionDate = exportToTime;
                _customSettingManager.SerializeandSave(_aricheResultCustomSettingsPath, customSettings);
            }
            catch (Exception exception)
            {
                _logger.Error(" error occure while moving Result Data Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
            }
        }

        private void MoveFileToArchiveFolder(MediaLocation mediaRepository)
        {

            if (!Directory.Exists(mediaRepository.PhysicalPath))
            {
                _logger.Info("No Directory does not Exist " + mediaRepository.PhysicalPath);
                return;
            }

            var destinationPath = GetTargetFolderPath(mediaRepository.PhysicalPath);

            if (string.IsNullOrEmpty(destinationPath)) return;

            _logger.Info("Starting Deep copy for source: " + mediaRepository.PhysicalPath + " destination " + destinationPath);

            var sourecInfo = new DirectoryInfo(mediaRepository.PhysicalPath);
            var destiFoldeInfo = new DirectoryInfo(destinationPath);

            DeepCopy(sourecInfo, destiFoldeInfo);
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

            _logger.Info("deleting source Folder Path: " + source.FullName);
            if (Directory.Exists(source.FullName))
                Directory.Delete(source.FullName, true);
        }

        public void ScannedDocumentZipFolder(MediaLocation mediaRepository, string fileName)
        {
            var sourceFile = mediaRepository.PhysicalPath + fileName;

            if (!File.Exists(sourceFile))
            {
                _logger.Info("No file found at to Move " + sourceFile);
                return;
            }

            var destinationPath = GetTargetFolderPath(mediaRepository.PhysicalPath);
            if (string.IsNullOrEmpty(destinationPath)) return;

            var distinationFile = destinationPath + @"\" + fileName;

            _logger.Info("Source File Path: " + sourceFile + " Destination File Path: " + distinationFile);
            var fileInfo = new FileInfo(sourceFile);

            fileInfo.MoveTo(distinationFile);
        }

        private string GetTargetFolderPath(string sourceFolder)
        {
            if (sourceFolder.Contains(_aricheResultCustomPath)) return string.Empty;

            if (string.IsNullOrEmpty(_mediaLocation)) return string.Empty;
            var destinationPath = sourceFolder.Replace(_mediaLocation, _aricheResultCustomPath);

            if (string.IsNullOrEmpty(destinationPath)) return string.Empty;

            if (!Directory.Exists(destinationPath))
                Directory.CreateDirectory(destinationPath);

            return destinationPath;
        }
    }
}