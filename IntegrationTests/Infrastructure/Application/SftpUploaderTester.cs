using System.IO;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.Web.IntegrationTests.Fakes;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    [TestFixture]
    public class SftpUploaderTester
    {
        [Test]
        public void UploadResultPdfFileTest()
        {
            var logger = new NLogLogManager().GetLogger("Upload");
            var setting = new FakeSettings();
            var strinname = Directory.GetParent("//download//Reports//pdf//09-08-2015");
            var processFtp = new ProcessFtp(logger, setting.HcpNvSftpHost, setting.HcpNvSftpUserName, setting.HcpNvSftpPassword);
            var destinationPathOnSftp = (!string.IsNullOrEmpty(setting.HcpNvSftpResultReportDownloadPath) ? setting.HcpNvSftpResultReportDownloadPath + "/" : string.Empty) + "IncorrectPhoneNumber";
            processFtp.UploadSingleFile(@"F:\test.pdf", destinationPathOnSftp, ("test_20170828" + ".pdf"));
            //processFtp.DownloadFiles(setting.HcpNvLockCorporateEventFolderLocation + "/HomeVisitRequest", @"F:\SFTP\HCP NV\HomeVisitRequest");

            // processFtp.UploadSingleFile(@"D:\Projects\Falcon\branches\QA\src\UI\media.falcon.com\ResultPacket\39786\PremiumVersion\847108\PcpResultReport.pdf", @"download\Reports\pdf\09-08-2015", ("999988" + ".pdf"));
        }
    }
}
