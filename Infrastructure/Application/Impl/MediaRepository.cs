using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class MediaRepository : IMediaRepository
    {
        private readonly ISettings _settings;

        public MediaRepository(ISettings settings)
        {
            _settings = settings;
        }

        public MediaLocation GetTempJpgFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\temp";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            string fileName = Guid.NewGuid() + ".jpg";


            return new MediaLocation
                       {
                           Url = Uri.EscapeUriString(_settings.MediaUrl + @"/temp/" + fileName),
                           PhysicalPath = tempLocation + @"\" + fileName
                       };

        }

        public MediaLocation GetTempMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\temp";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/temp/"),
                PhysicalPath = tempLocation + @"\"
            };

        }

        public MediaLocation GetBlurbMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\Blurb";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/Blurb/"),
                PhysicalPath = tempLocation + @"\"
            };

        }

        public MediaLocation GetGiftCertificateMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\GiftCertificate";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/GiftCertificate/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetResultMediaFileLocation(long customerId, long eventId)
        {
            var tempLocation = _settings.MediaLocation + @"\ResultMedia\" + eventId + @"\" + customerId;
            var tempArchiveLocation = _settings.ArchiveMediaLocation + @"\ResultMedia\" + eventId + @"\" + customerId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (tempArchiveLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            var mediaLocationExists = Directory.Exists(tempLocation);
            var archiveMediaLocationExists = Directory.Exists(tempArchiveLocation);

            if (!mediaLocationExists && !archiveMediaLocationExists)
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }

            if (!mediaLocationExists && archiveMediaLocationExists)
            {
                return new MediaLocation
                {
                    Url = Uri.EscapeUriString(_settings.ArchiveMediaUrl + "/ResultMedia/" + eventId + "/" + customerId + "/"),
                    PhysicalPath = tempArchiveLocation + @"\"
                };
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/ResultMedia/" + eventId + "/" + customerId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetResultArchiveMediaFileLocation(long eventId)
        {
            var tempLocation = _settings.MediaLocation + @"\ResultArchive\" + eventId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/ResultArchive/" + eventId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetPhysicianSignatureMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\PhysicianSignature";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/PhysicianSignature/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetMedicalHistoryMediaLocation(long eventId, bool createDirectoryifNotExists = true)
        {
            var tempLocation = _settings.MediaLocation + @"\HealthAssessmentForm\" + eventId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (createDirectoryifNotExists && !Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/HealthAssessmentForm/" + eventId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetOrganizationLogoImageFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\LogoImage\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/LogoImage/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetOrganizationResultLetterFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\ResultLetter\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/ResultLetter/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetScannedDocumentStorageFileLocation(long eventId)
        {
            var tempLocation = _settings.MediaLocation + @"\ScannedDocuments\" + eventId + @"\";
            var tempArchiveLocation = _settings.ArchiveMediaLocation + @"\ScannedDocuments\" + eventId + @"\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (tempArchiveLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            var mediaLocationExists = Directory.Exists(tempLocation);
            var archiveMediaLocationExists = Directory.Exists(tempArchiveLocation);

            if (!mediaLocationExists && archiveMediaLocationExists)
            {
                return new MediaLocation
                {
                    Url = Uri.EscapeUriString(_settings.ArchiveMediaUrl + "/ScannedDocuments/" + eventId + "/"),
                    PhysicalPath = tempArchiveLocation
                };
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/ScannedDocuments/" + eventId + "/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetScannedDocumentStorageFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\ScannedDocuments\";
            var tempArchiveLocation = _settings.ArchiveMediaLocation + @"\ScannedDocuments\";

            var mediaLocationExists = Directory.Exists(tempLocation);
            var archiveMediaLocationExists = Directory.Exists(tempArchiveLocation);

            if (!mediaLocationExists && archiveMediaLocationExists)
            {
                return new MediaLocation
                {
                    Url = Uri.EscapeUriString(_settings.ArchiveMediaUrl + "/ScannedDocuments/"),
                    PhysicalPath = tempArchiveLocation
                };
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/ScannedDocuments/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetLogFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\logs\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/logs/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetResultPacketMediaLocation(long eventId, bool createDirectoryifNotExists = true)
        {
            var tempLocation = _settings.MediaLocation + @"\ResultPacket\" + eventId;
            var tempArchiveLocation = _settings.ArchiveMediaLocation + @"\ResultPacket\" + eventId;

            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;
            if (tempArchiveLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            var mediaLocationExists = Directory.Exists(tempLocation);
            var archiveMediaLocationExists = Directory.Exists(tempArchiveLocation);

            if (createDirectoryifNotExists && !mediaLocationExists && !archiveMediaLocationExists)
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }

            if (!mediaLocationExists && archiveMediaLocationExists)
            {
                return new MediaLocation
                {
                    Url = Uri.EscapeUriString(_settings.ArchiveMediaUrl + "/ResultPacket/" + eventId + "/"),
                    PhysicalPath = tempArchiveLocation + @"\"
                };
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/ResultPacket/" + eventId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetCdContentFolderLocation(long eventId, bool createDirectoryifNotExists = true)
        {
            var mediaLocation = GetResultPacketMediaLocation(eventId);
            mediaLocation.PhysicalPath = mediaLocation.PhysicalPath + @"CdContent\";
            if (mediaLocation.PhysicalPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;
            if (createDirectoryifNotExists && !Directory.Exists(mediaLocation.PhysicalPath))
            {
                DirectoryOperationsHelper.CreateDirectory(mediaLocation.PhysicalPath);
            }
            mediaLocation.Url = mediaLocation.Url + "CdContent/";

            return mediaLocation;
        }

        public MediaLocation GetCdContentFolderLocation(long eventId, long customerId, bool createDirectoryifNotExists = true)
        {
            var mediaLocation = GetCdContentFolderLocation(eventId);
            mediaLocation.PhysicalPath = mediaLocation.PhysicalPath + customerId + @"\";
            if (mediaLocation.PhysicalPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (createDirectoryifNotExists && !Directory.Exists(mediaLocation.PhysicalPath))
            {
                DirectoryOperationsHelper.CreateDirectory(mediaLocation.PhysicalPath);
            }
            mediaLocation.Url = Uri.EscapeUriString(mediaLocation.Url + customerId + "/");
            return mediaLocation;
        }

        public MediaLocation GetPremiumVersionResultPdfLocation(long eventId, long customerId, bool createDirectoryifNotExists = true)
        {
            var mediaLocation = GetResultPacketMediaLocation(eventId);
            mediaLocation.PhysicalPath += @"PremiumVersion\" + customerId + @"\";
            if (mediaLocation.PhysicalPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (createDirectoryifNotExists && !Directory.Exists(mediaLocation.PhysicalPath))
                DirectoryOperationsHelper.CreateDirectory(mediaLocation.PhysicalPath);

            mediaLocation.Url += "PremiumVersion/" + customerId + "/";
            return mediaLocation;
        }

        public MediaLocation GetClinicalFormResultPdfLocation(long eventId, long customerId, bool createDirectoryifNotExists = true)
        {
            var mediaLocation = GetResultPacketMediaLocation(eventId);
            mediaLocation.PhysicalPath += @"ClinicalForm\" + customerId + @"\";

            if (mediaLocation.PhysicalPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (createDirectoryifNotExists && !Directory.Exists(mediaLocation.PhysicalPath))
                DirectoryOperationsHelper.CreateDirectory(mediaLocation.PhysicalPath);

            mediaLocation.Url += "ClinicalForm/" + customerId + "/";
            return mediaLocation;
        }

        public MediaLocation GetKynRawDataRepositoryLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\KynRawDataRepository";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/KynRawDataRepository/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetKynIntegrationOutputDataLocation(long eventId, bool createdDirectoryifnotExists = true)
        {
            var tempLocation = _settings.MediaLocation + @"\KynIntegrationOutputData\" + eventId;
            var tempArchiveLocation = _settings.ArchiveMediaLocation + @"\KynIntegrationOutputData\" + eventId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;
            if (tempArchiveLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            var mediaLocationExists = Directory.Exists(tempLocation);
            var archiveMediaLocationExists = Directory.Exists(tempArchiveLocation);

            if (createdDirectoryifnotExists && !mediaLocationExists && !archiveMediaLocationExists)
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }

            if (!mediaLocationExists && archiveMediaLocationExists)
            {
                return new MediaLocation
                {
                    Url = Uri.EscapeUriString(_settings.ArchiveMediaUrl + "/KynIntegrationOutputData/" + eventId + "/"),
                    PhysicalPath = tempArchiveLocation + @"\"
                };
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/KynIntegrationOutputData/" + eventId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetKynIntegrationOutputDataLocation(long eventId, long customerId)
        {
            var location = GetKynIntegrationOutputDataLocation(eventId, false);

            location.PhysicalPath += customerId + "\\";
            location.Url += customerId + "/";

            return location;
        }

        public string GetHtmlFileNameForResultReport()
        {
            return "ResultReport.html";
        }

        public string GetHtmlFileNameForResultReportWithImages()
        {
            return "ResultReportWithImages.html";
        }

        public string GetHtmlFileNameForResultReportPaperBack()
        {
            return "ResultReportPaperBack.html";
        }

        public string GetHtmlFileNameForCoverLetter()
        {
            return "CoverLetter.html";
        }

        public string GetPdfFileNameForResultReport()
        {
            return "ResultReport.pdf";
        }

        public string GetPdfFileNameForResultReportWithImages()
        {
            return "ResultReportWithImages.pdf";
        }

        public string GetPdfFileNameForResultReportPaperBack()
        {
            return "ResultReportPaperBack.pdf";
        }

        public string GetPdfFileNameForCoverLetter()
        {
            return "CoverLetter.pdf";
        }

        public string GetAllPremiumPdfName(long eventId)
        {
            return eventId + "_AllResultReport";
        }

        public string GetAllPremiumPdfWithEmailName(long eventId)
        {
            return eventId + "_AllResultReportWithEmail";
        }

        public string GetAllPremiumPdfWithoutEmailName(long eventId)
        {
            return eventId + "_AllResultReportWithoutEmail";
        }

        public string GetAllPremiumPdfWithImages(long eventId)
        {
            return eventId + "_AllResultReportWithImages";
        }

        public string GetAllPremiumPdfPaperCopyOnly(long eventId)
        {
            return eventId + "_AllResultReportPaperCopyOnly";
        }

        public string GetAllPremiumPdfOnlineOnly(long eventId)
        {
            return eventId + "_AllResultReportOnlineOnly";
        }

        public string GetAllPremiumPdfPcpOnly(long eventId)
        {
            return eventId + "_AllResultReportPcpOnly";
        }

        public string GetAllPremiumPdfEawvReportOnly(long eventId)
        {
            return eventId + "_AllEawvResultReportOnly";
        }
        public MediaLocation GetHostImagesFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\HostImages";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/HostImages/"),
                PhysicalPath = tempLocation + @"\"
            };

        }

        public MediaLocation GetPackageImageFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\PackageImage\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/PackageImage/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public string GetHtmlFileNameForBloodLetter()
        {
            return "BloodLetter.html";
        }

        public string GetPdfFileNameForBloodLetter()
        {
            return "BloodLetter.pdf";
        }

        public MediaLocation GetCorporateFluffLetterFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\FluffLetter\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/FluffLetter/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetUploadCsvMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\UploadCsv";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/UploadCsv/"),
                PhysicalPath = tempLocation + @"\"
            };

        }


        public string GetHtmlFileNameForPcpCoverLetter()
        {
            return "PcpCoverLetter.html";
        }

        public string GetPdfFileNameForPcpCoverLetter()
        {
            return "PcpCoverLetter.pdf";
        }

        public string GetHtmlFileNameForPcpResultReport()
        {
            return "PcpResultReport.html";
        }

        public string GetPdfFileNameForPcpResultReport()
        {
            return "PcpResultReport.pdf";
        }

        public MediaLocation GetOrganizationDoctorLetterFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\DoctorLetter\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/DoctorLetter/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetCorporateSurveyPdfFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\SurveyPdf\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/SurveyPdf/"),
                PhysicalPath = tempLocation
            };
        }


        public MediaLocation GetCorporatePcpLetterPdfFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\PcpLetterPdf\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/PcpLetterPdf/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetResultMediaFileLocation(long eventId, bool createDirectoryifNotExists = false)
        {
            var tempLocation = _settings.MediaLocation + @"\ResultMedia\" + eventId;
            var tempArchiveLocation = _settings.ArchiveMediaLocation + @"\ResultMedia\" + eventId;

            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;
            if (tempArchiveLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            var mediaLocationExists = Directory.Exists(tempLocation);
            var archiveMediaLocationExists = Directory.Exists(tempArchiveLocation);

            if (createDirectoryifNotExists && !mediaLocationExists && !archiveMediaLocationExists)
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }

            if (!mediaLocationExists && archiveMediaLocationExists)
            {
                return new MediaLocation
                {
                    Url = Uri.EscapeUriString(_settings.ArchiveMediaUrl + "/ResultMedia/" + eventId + "/"),
                    PhysicalPath = tempArchiveLocation + @"\"
                };
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/ResultMedia/" + eventId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public string GetPdfFileNameForEawvPreventionPlanReport()
        {
            return "EawvPreventionPlan.pdf";
        }

        public MediaLocation GethHostImageMediaLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\HostImages";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/HostImage/"),
                PhysicalPath = tempLocation + @"\"
            };

        }

        public MediaLocation GetPublicKeyFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\PublicKey\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/PublicKey/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetUnlockEventsParseLocation(long eventId, bool createDirectoryifNotExists = false)
        {
            var tempLocation = _settings.MediaLocation + @"\UnlockEvents\Parse\" + eventId + "\\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation) && createDirectoryifNotExists)
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/UnlockEvents/Parse/" + eventId + "/"),
                PhysicalPath = tempLocation
            };
        }

        public string GetHtmlFileNameForHealthPlanResultReport()
        {
            return "HealthPlanResultReport.html";
        }

        public string GetPdfFileNameForHealthPlanResultReport()
        {
            return "HealthPlanResultReport.pdf";
        }

        public string GetAllPremiumPdfHealthPlanReportOnly(long eventId)
        {
            return eventId + "_AllHealthPlanResultReportOnly";
        }

        public MediaLocation GetWellMedAttestationImageFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\WellMedAttestationImage\";
            if (!Directory.Exists(tempLocation))
            {
                Directory.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = _settings.MediaUrl + "/WellMedAttestationImage/",
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetCallUploadMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\CallUpload";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/CallUpload/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetExportToCsvMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\ExportToCsv";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/ExportToCsv/"),
                PhysicalPath = tempLocation + @"\"
            };

        }

        public MediaLocation GetCorporateParticipantLetterFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\ParticipantLetter\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/ParticipantLetter/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetRapsUploadMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\RepsUpload";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/RepsUpload/"),
                PhysicalPath = tempLocation + @"\"
            };
        }
        public MediaLocation GetCorporateCheckListPdfFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\CheckListPdf\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/CheckListPdf/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetOutboundUploadMediaFileLocation(string accountFolderName, string folderName)
        {
            var tempLocation = _settings.MediaLocation + @"\Outbound\" + accountFolderName + @"\" + folderName;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/Outbound/" + accountFolderName + "/" + folderName),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetAceMipLocation(string folderName, string hicn, string docType)
        {
            var location = _settings.MediaLocation + "\\" + folderName + "\\" + DateTime.Now.Year + "\\" + hicn + "\\" + docType;
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/" + folderName + "/" + DateTime.Now.Year + "/" + hicn + "/" + docType),
                PhysicalPath = location + @"\"
            };
        }

        public MediaLocation GetMonarchAttestaionLocation()
        {
            var location = _settings.MediaLocation + "\\Monarch\\";
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/Monarch/"),
                PhysicalPath = location + @"\"
            };
        }

        public MediaLocation GetEawvHraResultMediaLocation()
        {
            var location = Path.Combine(_settings.MediaLocation, @"EawvHraResult\");
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/EawvHraResult/"),
                PhysicalPath = location + @"\"
            };
        }

        public MediaLocation GetEawvHraResultArchiveMediaLocation()
        {
            var eawvHraResultLocation = GetEawvHraResultMediaLocation();
            eawvHraResultLocation.PhysicalPath = Path.Combine(eawvHraResultLocation.PhysicalPath, @"Archive\");
            if (eawvHraResultLocation.PhysicalPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(eawvHraResultLocation.PhysicalPath))
            {
                DirectoryOperationsHelper.CreateDirectory(eawvHraResultLocation.PhysicalPath);
            }

            eawvHraResultLocation.Url = eawvHraResultLocation.Url + "Archive/";

            return eawvHraResultLocation;
        }

        public MediaLocation GetLoincMediaLocation()
        {
            var location = Path.Combine(_settings.MediaLocation, @"Loinc\");
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/Loinc/"),
                PhysicalPath = location + @"\"
            };
        }

        public MediaLocation GetLoincArchiveMediaLocation()
        {
            var location = Path.Combine(_settings.MediaLocation, @"Loinc\Archive\");
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/Loinc/Archive/"),
                PhysicalPath = location + @"\"
            };
        }

        public MediaLocation GetHkynRawDataRepositoryLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\HkynRawDataRepository";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/HkynRawDataRepository/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetCallCenterScriptPdfFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\CallCenterScripts\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/CallCenterScripts/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetBioCheckAssessmentLocation(long eventId, bool createdDirectoryifnotExists = true)
        {
            var tempLocation = _settings.MediaLocation + @"\BioCheckAssessment\" + eventId;
            var tempArchiveLocation = _settings.ArchiveMediaLocation + @"\BioCheckAssessment\" + eventId;


            var mediaLocationExists = DirectoryOperationsHelper.IsDirectoryExist(tempLocation);
            var archiveMediaLocationExists = DirectoryOperationsHelper.IsDirectoryExist(tempArchiveLocation);

            if (createdDirectoryifnotExists && !mediaLocationExists && !archiveMediaLocationExists)
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }

            if (!mediaLocationExists && archiveMediaLocationExists)
            {
                return new MediaLocation
                {
                    Url = Uri.EscapeUriString(_settings.ArchiveMediaUrl + "/BioCheckAssessment/" + eventId + "/"),
                    PhysicalPath = tempArchiveLocation + @"\"
                };
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/BioCheckAssessment/" + eventId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetBioCheckAssessmentLocation(long eventId, long customerId)
        {
            var location = GetBioCheckAssessmentLocation(eventId);

            location.PhysicalPath += customerId + "\\";
            location.Url += customerId + "/";

            return location;
        }

        public MediaLocation GetCustomerPhoneNumberUploadLocation()
        {
            var location = Path.Combine(_settings.MediaLocation, @"CustomerPhoneNumberUpload\");
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/CustomerPhoneNumberUpload/"),
                PhysicalPath = location + @"\"
            };
        }

        public MediaLocation GetSamplesLocation()
        {
            var location = Path.Combine(_settings.MediaLocation, @"Samples\");
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/Samples/"),
                PhysicalPath = location + @"\"
            };
        }

        public MediaLocation GetMergeCustomerUploadMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\MergeCustomer";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/MergeCustomer/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetMassAgentAssignmentUploadMediaFileLocation()
        {
            var location = _settings.MediaLocation + @"\MassAgentAssignment";
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/MassAgentAssignment/"),
                PhysicalPath = location + @"\"
            };
        }

        public MediaLocation GetGMSDialerMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\GMS\Dialer";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/GMS/Dialer/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetGMSDialerArchiveMediaLocation()
        {
            var location = _settings.MediaLocation + @"\GMS\Dialer\Archive";
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/GMS/Dialer/Archive/"),
                PhysicalPath = location + @"\"
            };
        }

        public MediaLocation GetEligibilityUploadMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\EligibilityUpload";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/EligibilityUpload/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetStaffScheduleUploadMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\EventStaffSchedule";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/EventStaffSchedule/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetMedicationUploadMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\MedicationUpload";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/MedicationUpload/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetParsePatientDataMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\AcesPatientData";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/AcesPatientData/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetSuspectConditionUploadMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\SuspectConditionUpload";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/SuspectConditionUpload/"),
                PhysicalPath = tempLocation + @"\"
            };
        }
        public MediaLocation GetQuestUploadMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\QuestFile";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/QuestFile/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetCorporateMemberLetterPdfFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\MemberLetterPdf\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/MemberLetterPdf/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetMemberUploadbyAcesFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\MemberUploadbyAces\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/MemberUploadbyAces/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetCustomerEligibilityUploadFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\CustomerEligibilityUpload\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/CustomerEligibilityUpload/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetIpResultPdfLocation(long eventId, long customerId, bool createDirectoryifNotExists = true)
        {
            var mediaLocation = GetIpResultPdfMediaLocation(eventId);
            mediaLocation.PhysicalPath += customerId + @"\";
            if (mediaLocation.PhysicalPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (createDirectoryifNotExists && !Directory.Exists(mediaLocation.PhysicalPath))
                DirectoryOperationsHelper.CreateDirectory(mediaLocation.PhysicalPath);

            mediaLocation.Url += customerId + "/";
            return mediaLocation;
        }

        public MediaLocation GetIpResultPdfMediaLocation(long eventId, bool createDirectoryifNotExists = true)
        {
            var tempLocation = _settings.MediaLocation + @"\IpResultPdf\" + eventId;
            var tempArchiveLocation = _settings.ArchiveMediaLocation + @"\IpResultPdf\" + eventId;

            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;
            if (tempArchiveLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            var mediaLocationExists = Directory.Exists(tempLocation);
            var archiveMediaLocationExists = Directory.Exists(tempArchiveLocation);

            if (createDirectoryifNotExists && !mediaLocationExists && !archiveMediaLocationExists)
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }

            if (!mediaLocationExists && archiveMediaLocationExists)
            {
                return new MediaLocation
                {
                    Url = Uri.EscapeUriString(_settings.ArchiveMediaUrl + "/IpResultPdf/" + eventId + "/"),
                    PhysicalPath = tempArchiveLocation + @"\"
                };
            }

            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/IpResultPdf/" + eventId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public string GetPdfFileNameForIpResultPdf(long CustomerId, string acesId, string firstName, string lastName, int year)
        {
            var appentAcesIdOrCustomerId = string.IsNullOrEmpty(acesId) ? "NoAcesId_" + CustomerId.ToString() : acesId;
            return "IP_" + appentAcesIdOrCustomerId + "_" + lastName.Replace(" ", string.Empty) + "_" + firstName.Replace(" ", string.Empty) + "_" + year + ".pdf";
        }

        public string GetHtmlFileNameForIpResultPdf(long CustomerId, string acesId, string firstName, string lastName, int year)
        {
            var appentAcesIdOrCustomerId = string.IsNullOrEmpty(acesId) ? "NoAcesId_" + CustomerId.ToString() : acesId;
            return "IP_" + appentAcesIdOrCustomerId + "_" + lastName.Replace(" ", string.Empty) + "_" + firstName.Replace(" ", string.Empty) + "_" + year + ".html";
        }

        public MediaLocation GetExitInterviewSignaturePath(long eventId, long customerId)
        {
            var tempLocation = _settings.MediaLocation + @"\ExitInterview\" + eventId + @"\" + customerId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/ExitInterview/" + eventId + "/" + customerId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetGiftCardSignatureLocation(long eventId, long customerId)
        {
            var tempLocation = _settings.MediaLocation + @"\GiftCard\" + eventId + @"\" + customerId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/GiftCard/" + eventId + "/" + customerId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetPhysicianRecordRequestSignatureLocation(long eventId, long customerId)
        {
            var tempLocation = _settings.MediaLocation + @"\PhysicianRecordRequest\" + eventId + @"\" + customerId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/PhysicianRecordRequest/" + eventId + "/" + customerId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetParticipationConsentSignatureLocation(long eventId, long customerId)
        {
            var tempLocation = _settings.MediaLocation + @"\ParticipationConsent\" + eventId + @"\" + customerId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/ParticipationConsent/" + eventId + "/" + customerId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetFluVaccineConsentSignatureLocation(long eventId, long customerId)
        {
            var tempLocation = _settings.MediaLocation + @"\FluVaccineConsent\" + eventId + @"\" + customerId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/FluVaccineConsent/" + eventId + "/" + customerId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetBloodResultParseMediaLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\BloodResultParse\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/BloodResultParse/"),
                PhysicalPath = tempLocation
            };
        }

        public MediaLocation GetChaperoneSignatureLocation(long eventId, long customerId)
        {
            var tempLocation = _settings.MediaLocation + @"\Chaperone\" + eventId + @"\" + customerId;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/Chaperone/" + eventId + "/" + customerId + "/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetDpnEventDateFolderLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\DpnEventDateFolder\";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/DpnEventDateFolder/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetCustomerActivityTypeUploadMediaFileLocation()
        {
            var tempLocation = _settings.MediaLocation + @"\CustomerActivityTypeUpload";
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + @"/CustomerActivityTypeUpload/"),
                PhysicalPath = tempLocation + @"\"
            };
        }

        public MediaLocation GetCustomerWithSameAcesIdFileLocation()
        {
            var today = DateTime.Today.ToString("MMddyyyy");
            var tempLocation = _settings.MediaLocation + @"\CustomerWithSameAcesId\" + today;
            if (tempLocation.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            if (!Directory.Exists(tempLocation))
            {
                DirectoryOperationsHelper.CreateDirectory(tempLocation);
            }
            return new MediaLocation
            {
                Url = Uri.EscapeUriString(_settings.MediaUrl + "/CustomerWithSameAcesId/" + today + "/"),
                PhysicalPath = tempLocation + @"\"
            };

        }

    }
}