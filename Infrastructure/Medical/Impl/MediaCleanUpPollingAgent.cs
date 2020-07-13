using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.ValueTypes;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MediaCleanUpPollingAgent : IMediaCleanUpPollingAgent
    {
        private readonly IResultArchiveUploadRepository _resultArchiveUploadRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICdContentGeneratorTrackingRepository _cdContentGeneratorTrackingRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ISettings _settings;
        private readonly ILogger _logger;

        public MediaCleanUpPollingAgent(IResultArchiveUploadRepository resultArchiveUploadRepository, IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository, IEventCustomerResultRepository eventCustomerResultRepository,
                                    ILogManager logManager, ISettings settings, IEventRepository eventRepository, ICdContentGeneratorTrackingRepository cdContentGeneratorTrackingRepository)
        {
            _resultArchiveUploadRepository = resultArchiveUploadRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _logger = logManager.GetLogger("CleanUpMedia_Log");
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _cdContentGeneratorTrackingRepository = cdContentGeneratorTrackingRepository;
            _eventRepository = eventRepository;
            _settings = settings;
        }

        public void PollForCleanUp()
        {
            if (!_settings.IsDevEnvironment && DateTime.Now.TimeOfDay > new TimeSpan(0, 0, 0) && DateTime.Now.TimeOfDay < new TimeSpan(1, 0, 0))
            {
                if (DateTime.Now.Date.Day % 15 == 0)
                {
                    ExecuteCleanUp(true);
                }
                else
                {
                    ExecuteCleanUp(false);
                }
            }
        }

        public void ExecuteCleanUp(bool executeFortnightCheck)
        {
            try
            {
                if (_settings.IsDevEnvironment) return;
                ArchivethePreviousFiles();
            }
            catch (Exception ex)
            {
                _logger.Error("\n Error while Archiving the Past Result Archives. Message : " + ex.Message + "\n\t StackTrace: " + ex.StackTrace);
            }

            try
            {
                CleanUpCdContentFolder();
            }
            catch (Exception ex)
            {
                _logger.Error("\n Error while Routine Cleaning up of Cd Content Folder. Message : " + ex.Message + "\n\t StackTrace: " + ex.StackTrace);
            }

            if (executeFortnightCheck)
            {
                try
                {
                    CleanUpPastCdContentFolder();
                }
                catch (Exception ex)
                {
                    _logger.Error("\n Error while Fortnight Cleaning up of Cd Content Folder. Message : " + ex.Message + "\n\t StackTrace: " + ex.StackTrace);
                }

                try
                {
                    CleanUpResultPacketSupportFiles();
                }
                catch (Exception ex)
                {
                    _logger.Error("\n Error while Fortnight Cleaning up of Result Packet Folder. Message : " + ex.Message + "\n\t StackTrace: " + ex.StackTrace);
                }

                try
                {
                    CleanUpArchiveFolder();
                }
                catch (Exception ex)
                {
                    _logger.Error("\n Error while Fortnight Cleaning up of Result Archive Folder. Message : " + ex.Message + "\n\t StackTrace: " + ex.StackTrace);
                }

            }
        }

        public void ArchivethePreviousFiles()
        {
            if (_settings.ResultArchiveWaitDays < 1) return;

            var dateForMovingtoArchives = DateTime.Now.Date.AddDays(-1 * _settings.ResultArchiveWaitDays);
            var filter = new ResultArchiveUploadListModelFilter
            {
                ToUploadDate = dateForMovingtoArchives,
                IsArchived = true
            };

            _logger.Info(
                "\n\n ****************************************** Result Archive ****************************************");

            _logger.Info("\nBatch Started -------------------------------------------------------------------\n");
            while (true)
            {
                int totalRecords = 0;
                var records = _resultArchiveUploadRepository.GetByFilter(filter, 1, 100, out totalRecords);
                if (records == null || records.Count() < 1) break;

                foreach (ResultArchive resultArchive in records)
                {
                    if (!resultArchive.FileId.HasValue) continue;

                    var file = _fileRepository.GetById(resultArchive.FileId.Value);
                    var mediaLocation = _mediaRepository.GetResultArchiveMediaFileLocation(resultArchive.EventId);

                    try
                    {
                        var folder = _settings.ResultArchiveSharedDrivePath + resultArchive.EventId + @"\";
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        if (System.IO.File.Exists(mediaLocation.PhysicalPath + file.Path))
                        {
                            _logger.Info("\nMoving File For Event [" + resultArchive.EventId + "] [" + mediaLocation.PhysicalPath + file.Path + "].\n");

                            var destinationFilePath = folder + file.Path;
                            if (System.IO.File.Exists(destinationFilePath))
                                System.IO.File.Delete(destinationFilePath);

                            System.IO.File.Move(mediaLocation.PhysicalPath + file.Path, destinationFilePath);

                            //Removes inherited source directory permission and sets destination directory permission
                            var fs = System.IO.File.GetAccessControl(destinationFilePath);
                            fs.SetAccessRuleProtection(false, false);
                            System.IO.File.SetAccessControl(destinationFilePath, fs);

                            if (System.IO.File.Exists(mediaLocation.PhysicalPath + file.Path))
                                System.IO.File.Delete(mediaLocation.PhysicalPath + file.Path);
                        }
                        else
                        {
                            _logger.Info("\nFile Not Found For Event [" + resultArchive.EventId + "] [" + mediaLocation.PhysicalPath + file.Path + "]\n");
                        }

                        var files = Directory.GetFiles(mediaLocation.PhysicalPath, "*.zip");
                        if (files.Count() < 1)
                            Directory.Delete(mediaLocation.PhysicalPath, true);

                        ((IFileRepository)_fileRepository).MarkasArchived(file.Id);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("\nResult Archive Id = " + resultArchive.Id + ". Path : [" + mediaLocation.PhysicalPath + file.Path + "]. \nMessage: " + ex.Message + "\n\tStack trace:" + ex.StackTrace);
                    }
                }
            }

            _logger.Info("\nBatch Completed -------------------------------------------------------------------\n");
        }

        public void CleanUpArchiveFolder()
        {

            _logger.Info(
                "\n\n ****************************************** Result Archive  (Fortnight Loop) ****************************************");

            _logger.Info("\nBatch Started -------------------------------------------------------------------\n");

            var mediaLocation = _mediaRepository.GetResultArchiveMediaFileLocation(1);
            var root = Path.GetDirectoryName(Path.GetDirectoryName(mediaLocation.PhysicalPath));
            foreach (var dir in Directory.GetDirectories(root))
            {
                var files = Directory.GetFiles(dir, "*.zip");
                if (files.Count() < 1)
                {
                    _logger.Info("\nCleaning Up Directory [" + dir + "]");
                    Directory.Delete(dir, true);
                }
            }
        }

        public void CleanUpCdContentFolder()
        {
            if (_settings.ResultArchiveWaitDays < 1) return;
            var dateForCleaningUpCdContent = DateTime.Now.Date.AddDays(-1 * _settings.ResultArchiveWaitDays);

            var cdContentTrackingRecords = _cdContentGeneratorTrackingRepository.GetCdContentGeneratedforCleanUp(dateForCleaningUpCdContent);
            if (cdContentTrackingRecords == null || cdContentTrackingRecords.Count() < 1) return;

            var eventCustomerResultIds = cdContentTrackingRecords.Select(cd => cd.EventCustomerResultId).ToArray();

            _logger.Info(
                "\n\n ****************************************** Cd Content (Routine) ****************************************");

            _logger.Info("\nBatch Started -------------------------------------------------------------------\n");

            for (int i = 0; i < eventCustomerResultIds.Count(); i = i + 100)
            {
                var ids = eventCustomerResultIds.Skip(i).Take(100);
                var eventCustomerResults = _eventCustomerResultRepository.GetByIds(ids);
                CleanUpCdContentForRecords(eventCustomerResults, cdContentTrackingRecords);
            }
        }

        public void CleanUpPastCdContentFolder()
        {
            if (_settings.ResultArchiveWaitDays < 1) return;

            const int days = 45;
            var dateForCleaningUpCdContent = DateTime.Now.Date.AddDays(-1 * days);
            var filter = new EventBasicInfoViewModelFilter
            {
                DateTo = dateForCleaningUpCdContent,
                DateFrom = dateForCleaningUpCdContent.AddDays(-1 * days)
            };

            int pageNumber = 1;

            _logger.Info(
                "\n\n ****************************************** Cd Content (Fortnight Loop) ****************************************");

            _logger.Info("\nBatch Started -------------------------------------------------------------------\n");

            while (true)
            {
                int totalRecords = 0;
                var events = _eventRepository.GetEventsbyFilters(filter, pageNumber++, 100, out totalRecords);

                if (events == null || events.Count() < 1) break;

                foreach (var @event in events)
                {
                    try
                    {
                        var eventCustomerResults = _eventCustomerResultRepository.GetByEventId(@event.Id);
                        if (eventCustomerResults == null || eventCustomerResults.Count() < 1) continue;

                        var eventCustomerResultIds = eventCustomerResults.Select(ecr => ecr.Id).ToArray();

                        var cdContentTrackingRecords = _cdContentGeneratorTrackingRepository.GetCdContentGeneratedforEventCustomerIds(eventCustomerResultIds);
                        cdContentTrackingRecords = cdContentTrackingRecords != null ? cdContentTrackingRecords.Where(r => r.IsContentGenerated && (!r.ContentGeneratedDate.HasValue || r.ContentGeneratedDate < DateTime.Now.AddDays(-1 * _settings.ResultArchiveWaitDays))) : null;

                        if (cdContentTrackingRecords != null && cdContentTrackingRecords.Count() > 0)
                        {
                            eventCustomerResultIds = cdContentTrackingRecords.Select(cd => cd.EventCustomerResultId).ToArray();
                            eventCustomerResults = eventCustomerResults.Where(ecr => eventCustomerResultIds.Contains(ecr.Id)).ToArray();

                            CleanUpCdContentForRecords(eventCustomerResults, cdContentTrackingRecords);
                        }

                        var location = _mediaRepository.GetCdContentFolderLocation(@event.Id, false);
                        if (location == null) continue;

                        if (Directory.Exists(location.PhysicalPath))
                        {
                            var files = Directory.GetFiles(location.PhysicalPath, "*.zip");
                            if (files.Count() < 1)
                                Directory.Delete(location.PhysicalPath, true);
                        }
                        var zipFileName = Path.GetDirectoryName(Path.GetDirectoryName(location.PhysicalPath)) + "\\" + @event.Id + ".zip";
                        if (System.IO.File.Exists(zipFileName))
                        {
                            System.IO.File.Delete(zipFileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("\n Failed For Event Id [" + @event.Id + "]. Message: " + ex.Message + ".\n\t Stack Trace:  " + ex.StackTrace);
                    }
                }
            }
        }

        public void CleanUpResultPacketSupportFiles()
        {
            try
            {
                if (!_settings.CleanUpHtmlFiles) return;

                var eventIds = _eventCustomerResultRepository.GetEventWithResultDeliveredRecords();

                if (eventIds == null) return;

                var cleanUpRoutine = new Func<MediaLocation, string, bool>((mediaLocation, resulpacketstring) =>
                {
                    var pdfPath = mediaLocation.PhysicalPath + _mediaRepository.GetPdfFileNameForResultReport();
                    var pdfPathPaperBack = mediaLocation.PhysicalPath + _mediaRepository.GetPdfFileNameForResultReportPaperBack();
                    var pdfPathImageBack = mediaLocation.PhysicalPath + _mediaRepository.GetPdfFileNameForResultReportWithImages();
                    var htmlPath = mediaLocation.PhysicalPath + _mediaRepository.GetHtmlFileNameForResultReport();

                    var pdfPathforPcpResultPdf = mediaLocation.PhysicalPath + _mediaRepository.GetPdfFileNameForPcpResultReport();
                    var eawvGeneratedFileName = mediaLocation.PhysicalPath + _mediaRepository.GetPdfFileNameForEawvPreventionPlanReport();
                    var pdfPathforHealthPlanResultPdf = mediaLocation.PhysicalPath + _mediaRepository.GetPdfFileNameForHealthPlanResultReport();

                    if (System.IO.File.Exists(htmlPath))
                    {
                        try
                        {
                            CleanUpDirectory(mediaLocation.PhysicalPath, new[] { pdfPath, pdfPathPaperBack, pdfPathImageBack, pdfPathforPcpResultPdf, eawvGeneratedFileName, pdfPathforHealthPlanResultPdf });
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Cleaning Up " + resulpacketstring + " Directory path [" + mediaLocation.PhysicalPath + "]. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                            return false;
                        }
                    }

                    return true;
                });


                _logger.Info(
                    "\n\n ****************************************** Result Packet (Fortnight Loop) ****************************************");

                _logger.Info("\nBatch Started -------------------------------------------------------------------\n");
                foreach (var eventId in eventIds)
                {
                    var eventCustomers = _eventCustomerResultRepository.GetByEventId(eventId);
                    eventCustomers = eventCustomers.Where(ecr => ecr.ResultState >= (int)TestResultStateNumber.PostAudit && ecr.IsResultPdfGenerated && ecr.IsClinicalFormGenerated);

                    foreach (var eventCustomer in eventCustomers)
                    {
                        var mediaLocationPremiumVersion = _mediaRepository.GetPremiumVersionResultPdfLocation(eventCustomer.EventId, eventCustomer.CustomerId, false);
                        cleanUpRoutine(mediaLocationPremiumVersion, "Premium Version");
                    }

                    var location = _mediaRepository.GetResultPacketMediaLocation(eventId, false);
                    if (!Directory.Exists(location.PhysicalPath))
                        continue;

                    string allDownloadPdfDirectoryName = _mediaRepository.GetAllPremiumPdfName(eventId);
                    try
                    {
                        if (Directory.Exists(location.PhysicalPath + allDownloadPdfDirectoryName))
                        {
                            _logger.Info("\nCleaning Up Directory [" + location.PhysicalPath + allDownloadPdfDirectoryName + "]");
                            CleanUpDirectory(location.PhysicalPath + allDownloadPdfDirectoryName);
                            Directory.Delete(location.PhysicalPath + allDownloadPdfDirectoryName, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Cleaning Up All Result Pdf Directory path [" + location.PhysicalPath + allDownloadPdfDirectoryName + "]. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                    }

                    string allDownloadPdfWithEmailDirectoryName = _mediaRepository.GetAllPremiumPdfWithEmailName(eventId);
                    try
                    {
                        if (Directory.Exists(location.PhysicalPath + allDownloadPdfWithEmailDirectoryName))
                        {
                            _logger.Info("\nCleaning Up Directory [" + location.PhysicalPath + allDownloadPdfWithEmailDirectoryName + "]");
                            CleanUpDirectory(location.PhysicalPath + allDownloadPdfWithEmailDirectoryName);
                            Directory.Delete(location.PhysicalPath + allDownloadPdfWithEmailDirectoryName, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Cleaning Up All Result Pdf With Email Directory path [" + location.PhysicalPath + allDownloadPdfWithEmailDirectoryName + "]. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                    }

                    string allDownloadPdfWithoutEmailDirectoryName = _mediaRepository.GetAllPremiumPdfWithoutEmailName(eventId);
                    try
                    {
                        if (Directory.Exists(location.PhysicalPath + allDownloadPdfWithoutEmailDirectoryName))
                        {
                            _logger.Info("\nCleaning Up Directory [" + location.PhysicalPath + allDownloadPdfWithoutEmailDirectoryName + "]");
                            CleanUpDirectory(location.PhysicalPath + allDownloadPdfWithoutEmailDirectoryName);
                            Directory.Delete(location.PhysicalPath + allDownloadPdfWithoutEmailDirectoryName, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Cleaning Up All Result Pdf Without Email Directory path [" + location.PhysicalPath + allDownloadPdfWithoutEmailDirectoryName + "]. Message: " + ex.Message + "/n/t Stack Trace" + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("\nError occured while Cleaning Up Result Packet For All Generated Events. Message: " + ex.Message + "\n\tStack Trace: " + ex.StackTrace);
            }
        }

        private void CleanUpCdContentForRecords(IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<CdContentGeneratorTracking> cdContentTrackingRecords)
        {
            foreach (var eventCustomerResult in eventCustomerResults)
            {
                var mediaLocation = _mediaRepository.GetCdContentFolderLocation(eventCustomerResult.EventId, eventCustomerResult.CustomerId, false);
                if (mediaLocation == null) continue;

                string directoryPath = mediaLocation.PhysicalPath.Trim();
                directoryPath = directoryPath.LastIndexOf("\\") + 1 == directoryPath.Length ? directoryPath.Remove(directoryPath.LastIndexOf("\\")) : directoryPath;

                _logger.Info("\n Cleaning up for Customer Id [" + eventCustomerResult.CustomerId + "] [" + directoryPath + "].");
                try
                {
                    if (Directory.Exists(directoryPath)) Directory.Delete(directoryPath, true);
                    //if (System.IO.File.Exists(directoryPath + ".zip")) System.IO.File.Delete(directoryPath + ".zip");
                }
                catch (Exception ex)
                {
                    _logger.Error("\n Error while deleting for Customer Id [" + eventCustomerResult.CustomerId + "] [" + directoryPath + "]. Message: " + ex.Message + ". Exception Type:  " + ex.GetType());
                }

                //var record =
                //    cdContentTrackingRecords.Where(r => r.EventCustomerResultId == eventCustomerResult.Id).Single();

                //record.IsContentGenerated = false;
                //_cdContentGeneratorTrackingRepository.Save(record);
            }
        }

        private static void CleanUpDirectory(string path, IEnumerable<string> fileException = null)
        {
            fileException = fileException == null ? new string[0] : fileException.Select(f => f.ToLower()).ToArray();

            foreach (var file in Directory.GetFiles(path))
            {
                if (fileException.Contains(file.ToLower())) continue;
                System.IO.File.Delete(file);
            }

            foreach (var dir in Directory.GetDirectories(path))
            {
                CleanUpDirectory(dir);
                Directory.Delete(dir);
            }
        }
    }
}
