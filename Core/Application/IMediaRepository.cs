using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Application
{
    public interface IMediaRepository
    {
        MediaLocation GetTempJpgFileLocation();
        MediaLocation GetTempMediaFileLocation();
        MediaLocation GetBlurbMediaFileLocation();
        MediaLocation GetGiftCertificateMediaFileLocation();
        MediaLocation GetResultMediaFileLocation(long customerId, long eventId);
        MediaLocation GetResultArchiveMediaFileLocation(long eventId);
        MediaLocation GetPhysicianSignatureMediaFileLocation();
        MediaLocation GetOrganizationLogoImageFolderLocation();
        MediaLocation GetOrganizationResultLetterFolderLocation();
        MediaLocation GetLogFolderLocation();
        MediaLocation GetResultPacketMediaLocation(long eventId, bool createDirectoryifNotExists = true);
        MediaLocation GetCdContentFolderLocation(long eventId, long customerId, bool createDirectoryifNotExists = true);
        MediaLocation GetCdContentFolderLocation(long eventId, bool createDirectoryifNotExists = true);
        MediaLocation GetPremiumVersionResultPdfLocation(long eventId, long customerId, bool createDirectoryifNotExists = true);
        MediaLocation GetClinicalFormResultPdfLocation(long eventId, long customerId, bool createDirectoryifNotExists = true);
        MediaLocation GetMedicalHistoryMediaLocation(long eventId, bool createDirectoryifNotExists = true);
        MediaLocation GetHostImagesFileLocation();
        MediaLocation GetScannedDocumentStorageFileLocation(long eventId);
        MediaLocation GetScannedDocumentStorageFolderLocation();
        string GetHtmlFileNameForResultReport();
        string GetHtmlFileNameForResultReportWithImages();
        string GetPdfFileNameForResultReport();
        string GetPdfFileNameForResultReportWithImages();
        string GetHtmlFileNameForCoverLetter();
        string GetPdfFileNameForCoverLetter();

        string GetAllPremiumPdfName(long eventId);
        string GetHtmlFileNameForResultReportPaperBack();
        string GetPdfFileNameForResultReportPaperBack();
        MediaLocation GetPackageImageFolderLocation();
        MediaLocation GetKynRawDataRepositoryLocation();
        MediaLocation GetKynIntegrationOutputDataLocation(long eventId, bool createdDirectoryifnotExists = true);
        MediaLocation GetKynIntegrationOutputDataLocation(long eventId, long customerId);
        string GetAllPremiumPdfWithEmailName(long eventId);
        string GetAllPremiumPdfWithoutEmailName(long eventId);
        string GetAllPremiumPdfWithImages(long eventId);
        string GetAllPremiumPdfPaperCopyOnly(long eventId);
        string GetAllPremiumPdfOnlineOnly(long eventId);
        string GetAllPremiumPdfPcpOnly(long eventId);
        string GetAllPremiumPdfEawvReportOnly(long eventId);

        string GetHtmlFileNameForBloodLetter();
        string GetPdfFileNameForBloodLetter();
        MediaLocation GetCorporateFluffLetterFolderLocation();
        MediaLocation GetUploadCsvMediaFileLocation();

        string GetHtmlFileNameForPcpCoverLetter();
        string GetPdfFileNameForPcpCoverLetter();
        string GetHtmlFileNameForPcpResultReport();
        string GetPdfFileNameForPcpResultReport();

        MediaLocation GetOrganizationDoctorLetterFolderLocation();
        MediaLocation GetCorporateSurveyPdfFolderLocation();
        MediaLocation GetCorporatePcpLetterPdfFolderLocation();
        MediaLocation GetResultMediaFileLocation(long eventId, bool createDirectoryifNotExists = false);
        string GetPdfFileNameForEawvPreventionPlanReport();
        MediaLocation GethHostImageMediaLocation();
        MediaLocation GetPublicKeyFolderLocation();
        MediaLocation GetUnlockEventsParseLocation(long eventId, bool createDirectoryifNotExists = false);
        string GetHtmlFileNameForHealthPlanResultReport();
        string GetPdfFileNameForHealthPlanResultReport();
        string GetAllPremiumPdfHealthPlanReportOnly(long eventId);
        MediaLocation GetWellMedAttestationImageFolderLocation();
        MediaLocation GetCallUploadMediaFileLocation();

        MediaLocation GetExportToCsvMediaFileLocation();

        MediaLocation GetCorporateParticipantLetterFolderLocation();
        MediaLocation GetRapsUploadMediaFileLocation();
        MediaLocation GetCorporateCheckListPdfFolderLocation();

        MediaLocation GetOutboundUploadMediaFileLocation(string accountFolderName, string folderName);

        MediaLocation GetAceMipLocation(string folderName, string hicn, string docType);
        MediaLocation GetMonarchAttestaionLocation();

        MediaLocation GetEawvHraResultMediaLocation();
        MediaLocation GetEawvHraResultArchiveMediaLocation();

        MediaLocation GetLoincMediaLocation();
        MediaLocation GetLoincArchiveMediaLocation();

        MediaLocation GetCallCenterScriptPdfFolderLocation();
        MediaLocation GetBioCheckAssessmentLocation(long eventId, bool createdDirectoryifnotExists = true);
        MediaLocation GetBioCheckAssessmentLocation(long eventId, long customerId);
        MediaLocation GetCustomerPhoneNumberUploadLocation();
        MediaLocation GetSamplesLocation();

        MediaLocation GetMergeCustomerUploadMediaFileLocation();
        MediaLocation GetMassAgentAssignmentUploadMediaFileLocation();
        MediaLocation GetGMSDialerMediaFileLocation();
        MediaLocation GetGMSDialerArchiveMediaLocation();

        MediaLocation GetEligibilityUploadMediaFileLocation();
        MediaLocation GetStaffScheduleUploadMediaFileLocation();
        MediaLocation GetQuestUploadMediaFileLocation();

        MediaLocation GetMedicationUploadMediaFileLocation();
        MediaLocation GetParsePatientDataMediaFileLocation();
        MediaLocation GetSuspectConditionUploadMediaFileLocation();

        MediaLocation GetCorporateMemberLetterPdfFolderLocation();
        MediaLocation GetCustomerEligibilityUploadFolderLocation();
        MediaLocation GetMemberUploadbyAcesFolderLocation();
        MediaLocation GetIpResultPdfLocation(long eventId, long customerId, bool createDirectoryifNotExists = true);
        MediaLocation GetIpResultPdfMediaLocation(long eventId, bool createDirectoryifNotExists = true);
        string GetPdfFileNameForIpResultPdf(long CustomerId, string acesId, string firstName, string lastName, int year);
        string GetHtmlFileNameForIpResultPdf(long CustomerId, string acesId, string firstName, string lastName, int year);

        MediaLocation GetExitInterviewSignaturePath(long eventId, long customerId);
        MediaLocation GetGiftCardSignatureLocation(long eventId, long customerId);
        MediaLocation GetPhysicianRecordRequestSignatureLocation(long eventId, long customerId);
        MediaLocation GetParticipationConsentSignatureLocation(long eventId, long customerId);
        MediaLocation GetFluVaccineConsentSignatureLocation(long eventId, long customerId);

        MediaLocation GetBloodResultParseMediaLocation();
        MediaLocation GetChaperoneSignatureLocation(long eventId, long customerId);
        MediaLocation GetDpnEventDateFolderLocation();
        MediaLocation GetCustomerActivityTypeUploadMediaFileLocation();
        MediaLocation GetCustomerWithSameAcesIdFileLocation();
    }
}