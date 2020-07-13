using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IGenerateFinalPdf
    {
        bool CreatePremiumPdf(string saveFilePath, Customer customer, Event eventData, bool isTestDependent, IEnumerable<long> testIds, bool showHeaderImageInReport, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview, bool getPhysicianEvaluatedTest = false);
        //  void CreateClinicalForm(string saveFilePath, long customerId, long eventId);
        void CreatePacketIndexPage(string saveFilePath, Customer customer, Event eventdata);
        //  void CreatePremiumPdfPaperBack(string saveFilePath, long customerId, long eventId, bool isTestDependent, IEnumerable<long> testIds, bool showHeaderImageInReport, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations);
        void CreateBloodLetterforPremiumPdf(string saveFilePathBloodLetter);
        //  void CreatePremiumPdfWithImages(string saveFilePath, long customerId, long eventId, bool isTestDependent, IEnumerable<long> testIds, bool showHeaderImageInReport, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations);
        bool CreatePcpResultPdf(string saveFilePath, Customer customer, Event eventData, bool isTestDependent, IEnumerable<long> testIds, bool copyMedia, bool copySupportMedia, bool showHeaderImageInReport,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview);

        void CreateCoverLetterForCustomerResultReport(long customerId, string saveFilePathCoverLetter);
        void CreateCorporateCoverLetterForPremiumPdf(long customerId, long corporateAccountId, string saveFilePathCoverLetter);
        void CreateCoverLetterForPcpResultReportWithDiagnosisCode(long customerId, string saveFilePathCoverLetter, Event theEvent, long[] testIds);
        void CreateCoverLetterForPcpResultReport(long customerId, string saveFilePathCoverLetter, long corporateAccountId, bool generatePcpletter, bool isPcpLetterUploaded, bool isForPcp);

        void CopySupportMediaFiles(string saveFilePath, bool copySupportMediaOtherThanPhysician);
    }
}