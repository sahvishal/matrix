using System.IO;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ResultPdfDownloadPollingAgentHelper : IResultPdfDownloadPollingAgentHelper
    {
        private readonly IConvertPdfToTiff _convertPdfToTiff;

        public ResultPdfDownloadPollingAgentHelper(IConvertPdfToTiff convertPdfToTiff)
        {
            _convertPdfToTiff = convertPdfToTiff;
        }

        public void ExportResultInPdfFormat(string fileName, string sourcePath, string destinationFolderPdf)
        {
            CreateDistinationDirectory(destinationFolderPdf);

            var destinationPdfFile = Path.Combine(destinationFolderPdf, fileName);
            if (File.Exists(destinationPdfFile)) File.Delete(destinationPdfFile);

            File.Copy(sourcePath, destinationPdfFile);
        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }

        public void ExportResultInPdfFormat(string fileName, string sourcePath, string destinationFolderPdf, string fileNameWithCustomerName)
        {
            CreateDistinationDirectory(destinationFolderPdf);

            var tempDestination = destinationFolderPdf + "/" + fileName;

            if (File.Exists(tempDestination))
            {
                tempDestination = destinationFolderPdf + "/" + fileNameWithCustomerName;
                if (File.Exists(tempDestination))
                {
                    File.Delete(tempDestination);
                }
            }

            File.Copy(sourcePath, tempDestination);
        }

        public void ExportResultInTiffFormat(string fileName, string sourceUrl, string destinationFolderTiff)
        {
            CreateDistinationDirectory(destinationFolderTiff);

            var destinationTiffFile = destinationFolderTiff + "/" + fileName;

            if (File.Exists(destinationTiffFile)) File.Delete(destinationTiffFile);

            _convertPdfToTiff.SavePdfAsTiffImage(sourceUrl, destinationTiffFile);
        }
    }
}