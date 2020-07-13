using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SendTestMediaFilesService : ISendTestMediaFilesService
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly ILogger _logger;

        private readonly IEventRepository _eventRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly ISendMediaFileHelper _sendMediaFileHelper;
        private readonly IMediaHelper _mediaHelper;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public SendTestMediaFilesService(IEventCustomerResultRepository eventCustomerResultRepository, IMediaRepository mediaRepository,
            ISettings settings, ILogManager logManager, IEventRepository eventRepository,
            ICustomerRepository customerRepository, ISendMediaFileHelper sendMediaFileHelper, IMediaHelper mediaHelper, ICorporateAccountRepository corporateAccountRepository)
        {
            _logger = logManager.GetLogger("SendTestMediaFilesService");
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _settings = settings;

            _eventRepository = eventRepository;

            _customerRepository = customerRepository;
            _sendMediaFileHelper = sendMediaFileHelper;
            _mediaHelper = mediaHelper;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public void SubscriberForSendTestMediaFiles(long eventId, long customerId)
        {
            try
            {
                var testIds = _settings.IpSendMediaFilesForTestIds;
                if (!testIds.Any())
                {
                    _logger.Info("No Test id found in config, please provide TestIds.");
                    return;
                }

                _logger.Info("\n************************************************************************************************************ \n");
                _logger.Info("**************************************** Starting for Customer Id: " + customerId + " and Event Id: " + eventId + " **************************************** \n");
                var mediaFiles = _eventCustomerResultRepository.GetMediaAndTestIdByEventIdAndCustomerId(eventId, customerId, testIds);

                mediaFiles = !mediaFiles.IsNullOrEmpty() ? mediaFiles.Where(x => !x.FirstValue.Contains("Thumb_")) : null;
                if (mediaFiles.IsNullOrEmpty())
                {
                    _logger.Info("There is not any media file availble for Customer Id: " + customerId + " and Event Id: " + eventId);
                    return;
                }

                RenameAndCopyMediaFile(customerId, eventId, mediaFiles);
                _logger.Info("**************************************** Media File Copied for Customer Id: " + customerId + " and Event Id: " + eventId + " **************************************** \n");

            }
            catch (Exception ex)
            {
                _logger.Error("Message:" + ex.Message);
                _logger.Error("StackTrace:" + ex.StackTrace);
            }
        }

        private void RenameAndCopyMediaFile(long customerId, long eventId, IEnumerable<OrderedPair<string, long>> mediaFiles)
        {
            try
            {
                var customer = _customerRepository.GetCustomer(customerId);
                if (customer == null)
                {
                    _logger.Info("Customer not found for Customer Id :" + customerId + " and Event Id :" + eventId);
                    return;
                }

                var eventData = _eventRepository.GetEventOnlyById(eventId);
                if (eventData == null)
                {
                    _logger.Info("Event not found for Customer Id :" + customerId + " and Event Id :" + eventId);
                    return;
                }

                var eventDate_ = eventData.EventDate;
                if (eventDate_ < _settings.StopSendingMediaFileDate)
                {
                    _logger.Info("We are not Sending media file of event which event Date is less then " + _settings.StopSendingMediaFileDate + ". Event Id " + eventId + ", Customer Id " + customerId);
                    return;
                }

                var mediaPath = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath;
                var account = _corporateAccountRepository.GetbyEventId(eventId);

                foreach (var fileDetail in mediaFiles)
                {
                    var testType = (TestType)fileDetail.SecondValue;
                    var mediaFileName = fileDetail.FirstValue;

                    var fileExtention = Path.GetExtension(mediaFileName);

                    var sourceImagePath = Path.Combine(mediaPath, mediaFileName);

                    if (ConvertToPdf(testType))
                    {
                        var fileAndFolderName = _sendMediaFileHelper.GetSftpFileAndFolder(account, customer, eventData, testType.ToString(), fileExtention, true);
                        var pdfPath = ConvertToPdf(sourceImagePath);

                        CopyMediaFile(pdfPath, fileAndFolderName.SecondValue, fileAndFolderName.FirstValue);

                    }
                    else
                    {
                        var fileAndFolderName = _sendMediaFileHelper.GetSftpFileAndFolder(account, customer, eventData, testType.ToString(), fileExtention, true);
                        CopyMediaFile(sourceImagePath, fileAndFolderName.SecondValue, fileAndFolderName.FirstValue);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message:" + ex.Message);
                _logger.Error("StackTrace:" + ex.StackTrace);
            }
        }


        private bool ConvertToPdf(TestType testType)
        {
            return (TestType.Spiro == testType || TestType.AwvSpiro == testType || TestType.QuantaFloABI == testType);
        }

        private string ConvertToPdf(string sourcePath)
        {
            var tempPhysicialpath = _mediaRepository.GetTempMediaFileLocation().PhysicalPath;
            var pdfPath = Path.Combine(tempPhysicialpath, Guid.NewGuid() + ".pdf");

            var mediaFileName = _settings.HighImageQuality + Path.GetFileName(sourcePath);
            var location = Directory.GetParent(sourcePath).FullName;
            var highQualityImage = Path.Combine(location, mediaFileName);
            if (DirectoryOperationsHelper.IsFileExist(highQualityImage))
            {
                _mediaHelper.ConvertPdfFromImage(highQualityImage, pdfPath);
            }
            else
            {
                _mediaHelper.ConvertPdfFromImage(sourcePath, pdfPath);
            }

            return pdfPath;


        }

        private void CopyMediaFile(string sourceFileName, string destinationPath, string newFileName)
        {
            try
            {
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationPath);

                if (DirectoryOperationsHelper.IsFileExist(sourceFileName))
                {
                    var destinationFile = Path.Combine(destinationPath, newFileName);
                    DirectoryOperationsHelper.CopyWithReplace(sourceFileName, destinationFile);

                    _logger.Info("Media file ( " + sourceFileName + " ) successfully copied with new Name " + newFileName + " on location " + destinationPath);
                }
                else
                {
                    _logger.Info("Media file ( " + sourceFileName + " ) does not exist on Media file Location");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message: Media file ( " + sourceFileName + " ) does not exist on Media file Location. Exception : " + ex.Message);
                _logger.Error("StackTrace:" + ex.StackTrace);
            }
        }

        private void CopyMediaFile(string mediaPath, string destinationPath, string mediaFile, string newFileName)
        {
            var sourceFileName = Path.Combine(mediaPath, mediaFile);
            try
            {
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationPath);

                if (DirectoryOperationsHelper.IsFileExist(sourceFileName))
                {
                    DirectoryOperationsHelper.DeleteFileIfExist(Path.Combine(destinationPath, newFileName));
                    DirectoryOperationsHelper.Copy(sourceFileName, Path.Combine(destinationPath, newFileName));
                    _logger.Info("Media file ( " + sourceFileName + " ) successfully copied with new Name " + newFileName + " on location " + destinationPath);
                }
                else
                {
                    _logger.Info("Media file ( " + sourceFileName + " ) does not exist on Media file Location");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("");
                _logger.Error("Message: Media file ( " + sourceFileName + " ) does not exist on Media file Location. Exception : " + ex.Message);
                _logger.Error("StackTrace:" + ex.StackTrace);
            }
        }
    }

}
