using System.Collections.Generic;
using System.Text;

namespace Falcon.App.Core.Application
{
    public interface IPdfGenerator
    {
        string Generate(string sourcePath, string destinationPath, string pdfConverterPath = "", string fileName = "");

        string Generate(StringBuilder htmlStream, string destinationPath, string pdfConverterPath = "", string fileName = "");
        void SetDefaultSwitch(WkHtmltoPdfSwitches defaultSwitches);

        void GeneratePdf(string pageurl, string fileSavePath, bool showFooterText = false, string footerText = "",
                            string coverSheetPages = "", string customizedLetter = "", string contentpages = "", string kynFile = "", string bloodLetter = "", string doctorLetter = "", string corporateFluffLetter = "",
                            bool isPpCustomer = false, string awvTestResult = "", bool isPcpReport = false, bool generatePcpLetter = false, string scannedDocumentsPdf = "", string eawvPdfReport = "", string focAttestation = "",
                            string attestationForm = "", bool hasSectionToDisplay = true, string mammogram = "", string ifobt = "", string urineMicroalbumin = "", string participantLetter = "", string chlamydia = "", string awvBoneMass = "",
            string osteoporosis = "", string quantaFloAbi = "", string hkyn = "", string mybioCheckAssessment = "", string memberLetter = "", string greenFormAttestation = "", string dpn = "");

        void GetPdffilesfromLocationandMergeintoOne(string sourcePath, string destinationFileName);
        void Merge(string parentFile, IEnumerable<string> filesToMerge);

        bool AllowLoadingJavascriptbeforePdfGenerate { get; set; }
        string PaperSize { get; set; }
        void GeneratePdfForHaf(string pageurl, string fileSavePath, string corporateSurveyPdf = "", string basicBiometricFile = "", string focAttestationFile = "", string corporateCheckListPdf = "", string annualComprehensiveExamPdf = "",
            string memberInformationProfilePdf = "");

        void ExtractPdfPages(string sourcePath, string destinationPath, int startPageNumber, int endPageNumber);
        string ExtractPdfPagesFromEnd(string sourcePath, string destinationPath, int numberOfPages);

        void GenerateHtml(string body, string destinationPath, string pageUrl, string destinationPdfPath);
    }
}