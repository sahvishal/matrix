namespace Falcon.App.Core.Medical
{
    public interface IResultPdfDownloadPollingAgentHelper
    {
        void ExportResultInPdfFormat(string fileName, string sourcePath, string destinationFolderPdf);
        void ExportResultInTiffFormat(string fileName, string sourceUrl, string destinationFolderTiffP);

        void ExportResultInPdfFormat(string fileName, string sourcePath, string destinationFolderPdf, string fileNameWithCustomerName);
    }
}