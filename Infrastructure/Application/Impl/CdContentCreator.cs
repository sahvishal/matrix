using System;
using System.IO;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation(Interface = typeof(ICdContentCreator))]
    public class CdContentCreator : ICdContentCreator
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICdContentGeneratorTrackingRepository _cdContentGeneratorTracking;
        private readonly IMediaRepository _mediaRepository;
        private readonly IZipHelper _zipHelper;
        private readonly ITestResultRepository _testResultRepository;

        private const string VideoFileFormat = ".flv";
        private const string CDVideoFileFormat = ".mp4";

        public CdContentCreator(IEventCustomerRepository eventCustomerRepository, IElectronicProductRepository electronicProductRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            ICdContentGeneratorTrackingRepository cdContentGeneratorTracking, IMediaRepository mediaRepository, IZipHelper zipHelper)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _electronicProductRepository = electronicProductRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _cdContentGeneratorTracking = cdContentGeneratorTracking;
            _mediaRepository = mediaRepository;
            _zipHelper = zipHelper;
            _testResultRepository = new TestResultRepository();
        }

        public bool GenerateCdContent(long eventId, long customerId, CorporateAccount corporateAccount)
        {
            //2. Customer who is having CD in the order, pick up those Customer Ids
            var isCdPurchased = _electronicProductRepository.IsProductPurchased(eventId, customerId, Product.UltraSoundImages);
            if (isCdPurchased)
            {
                //3. Check whether cd content is generated or not
                var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                if (eventCustomerResult == null) return false;

                var cdContentGeneratedRecords = _cdContentGeneratorTracking.GetCdContentGeneratedforEventCustomerIds(new[] { eventCustomerResult.Id });
                CdContentGeneratorTracking record = cdContentGeneratedRecords != null ? cdContentGeneratedRecords.SingleOrDefault() : null;
                var cdContentGenerated = record != null ? record.IsContentGenerated : false;

                if (!cdContentGenerated)
                {
                    //4. Check whether Pdf generated or not
                    if (eventCustomerResult.IsResultPdfGenerated)
                    {
                        //5. Pickup the folder for images
                        var sourceFolderPathforMedia = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath;
                        //6. Convert the physician evaluation (readonly) page to index page
                        //7. Pick up result Pdf 
                        //8. Dump the content as 
                        /*
                             * Media-Location
                             *  CdContent
                             *      EventId
                             *          CustomerId
                             *              Media
                             *              ResultPdf
                             *              Index.html
                             * 
                             * 
                             */
                        var physicalPathForCdContent = _mediaRepository.GetCdContentFolderLocation(eventId, customerId, false).PhysicalPath;
                        try
                        {
                            if (!Directory.Exists(physicalPathForCdContent))
                                Directory.Delete(physicalPathForCdContent, true);
                        }
                        catch
                        { }

                        physicalPathForCdContent = _mediaRepository.GetCdContentFolderLocation(eventId, customerId).PhysicalPath;

                        var files = _testResultRepository.GetTestMedia(eventId, customerId);

                        foreach (OrderedPair<string, string> file in files)
                        {
                            var destinationDirectory = Path.Combine(physicalPathForCdContent + @"Media\");
                            if (!Directory.Exists(destinationDirectory))
                                Directory.CreateDirectory(destinationDirectory);

                            if (!string.IsNullOrEmpty(file.FirstValue))
                            {
                                file.FirstValue = file.FirstValue.Replace(VideoFileFormat, CDVideoFileFormat);
                                var sourceFile = Path.Combine(sourceFolderPathforMedia, file.FirstValue);
                                var destFile = Path.Combine(destinationDirectory, file.FirstValue);

                                File.Copy(sourceFile, destFile, true);
                            }

                            if (!string.IsNullOrEmpty(file.SecondValue))
                            {
                                var sourceFile = Path.Combine(sourceFolderPathforMedia, file.SecondValue);
                                var destFile = Path.Combine(destinationDirectory, file.SecondValue);
                                File.Copy(sourceFile, destFile, true);
                            }
                        }

                        string sourcePdfFile;

                        if (corporateAccount != null && corporateAccount.AddImagesForAbnormal)
                        {
                            sourcePdfFile = _mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).PhysicalPath + _mediaRepository.GetPdfFileNameForResultReport();
                            if (!File.Exists(sourcePdfFile))
                                sourcePdfFile = _mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).PhysicalPath + _mediaRepository.GetPdfFileNameForPcpResultReport();
                        }
                        else
                        {
                            sourcePdfFile = _mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).PhysicalPath + _mediaRepository.GetPdfFileNameForResultReport();
                        }

                        if (File.Exists(sourcePdfFile))
                        {
                            var pdfFileName = _mediaRepository.GetPdfFileNameForResultReport();//Path.GetFileName(sourcePdfFile);
                            if (!Directory.Exists(physicalPathForCdContent + @"ResultPdf\"))
                                Directory.CreateDirectory(physicalPathForCdContent + @"ResultPdf\");

                            var destPdfFile = Path.Combine(physicalPathForCdContent + @"ResultPdf\", pdfFileName);
                            File.Copy(sourcePdfFile, destPdfFile, true);
                        }

                        ZipCdContentsforEventCustomer(eventId, customerId);

                        var cdContentTracking = new CdContentGeneratorTracking
                                                    {
                                                        EventCustomerResultId = eventCustomerResult.Id,
                                                        IsContentGenerated = true,
                                                        IsContentDownloaded = false,
                                                        DownloadedByOrgRoleUserId = null,
                                                        DownloadedDate = null,
                                                        ContentGeneratedDate = DateTime.Now
                                                    };

                        if (record != null)
                        {
                            cdContentTracking = record;
                            cdContentTracking.IsContentGenerated = true;
                            cdContentTracking.ContentGeneratedDate = DateTime.Now;
                        }

                        _cdContentGeneratorTracking.Save(cdContentTracking);
                        //9. Save CD content tracking
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ZipCdContentsPerEvent(long eventId)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomersWithCdPurchaseByEventId(eventId);
            var cdPurchasedCount = eventCustomers.Count();
            var cdContentGeneratedCount = eventCustomers.Select(eventCustomer => _cdContentGeneratorTracking.IsCdContentGenerated(eventCustomer.EventId, eventCustomer.CustomerId)).Count(isCdContentGenerated => isCdContentGenerated);

            if (cdContentGeneratedCount == 0) return false;

            var sourcePath = _mediaRepository.GetCdContentFolderLocation(eventId).PhysicalPath;

            //TODO:Extract zip files for the customer whose cd content folder has been deleted.
            var files = Directory.GetFiles(sourcePath).Where(file => file.EndsWith(".zip"));
            foreach (var file in files)
            {
                string directoryName = Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file);

                if (Directory.Exists(directoryName))
                {
                    try
                    {
                        Directory.Delete(directoryName, true);
                        _zipHelper.ExtractZipFiles(file);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            var outPutPath = _zipHelper.CreateZipFiles(sourcePath, true);

            var eventPath = _mediaRepository.GetResultPacketMediaLocation(eventId).PhysicalPath;
            var fileName = eventPath + eventId + ".zip";

            if (File.Exists(fileName))
                File.Delete(fileName);

            File.Move(outPutPath, fileName);

            if (cdContentGeneratedCount >= cdPurchasedCount)
            {
                foreach (var dir in Directory.GetDirectories(sourcePath))
                {
                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch
                    {

                    }
                }
            }
            return true;
        }

        public bool ZipCdContentsPerEventPerCustomer(long eventId, long customerId)
        {
            var isCdContentGenerated = _cdContentGeneratorTracking.IsCdContentGenerated(eventId, customerId);
            if (isCdContentGenerated)
            {
                ZipCdContentsforEventCustomer(eventId, customerId);
                return true;
            }
            return false;
        }

        private void ZipCdContentsforEventCustomer(long eventId, long customerId)
        {

            var sourcePath = _mediaRepository.GetCdContentFolderLocation(eventId, customerId).PhysicalPath;
            _zipHelper.CreateZipFiles(sourcePath, true);

        }
    }
}