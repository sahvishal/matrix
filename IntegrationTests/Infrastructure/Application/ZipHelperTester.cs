using System.IO;
using System.Linq;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;
namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    [TestFixture]
    public class ZipHelperTester
    {
        public ZipHelperTester()
        {

        }

        [Test]
        public void ExtractZipFile_Tester()
        {
            var tester = new ZipHelper();
            string path = tester.ExtractZipFiles(@"D:\ITR1_2011_12_R7.zip");
            Assert.IsNotNullOrEmpty(path);
        }

        [Test]
        public void ExtractZipFile_ExtracttoDestFolder_Tester()
        {
            var tester = new ZipHelper();
            string path = tester.ExtractZipFiles(@"D:\DBforRestore\25840-1355.zip", @"D:\DBforRestore\25840");
            Assert.IsNotNullOrEmpty(path);
        }

        [Test]
        public void CreateZipFile__Tester()
        {
            var tester = new ZipHelper();
            var path = tester.CreateZipFiles(@"C:\Temp\ResultMedia\24344\",true);
            Assert.IsNotNullOrEmpty(path);
        }

        [Test]
        public void CreateZipFile_CreateToDestFolder_Tester()
        {
            var tester = new ZipHelper();
            tester.CreateZipFiles(@"C:\Temp\ResultMedia\24344", @"C:\Temp\ResultMedia\2344.zip");
        }

        [Test]
        public void ExtractZipFile_TesterForAllCdContent()
        {
            var tester = new ZipHelper();
            string sourcePath = @"D:\Projects\Falcon\tags\Prod_HF_03122013\src\UI\media.falcon.com\ResultPacket\27922\CdContent";
            var files = Directory.GetFiles(sourcePath).Where(file => file.EndsWith(".zip"));
            string path = "";
            foreach (var file in files)
            {
                string directoryName = Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file);
                if (!Directory.Exists(directoryName))
                    path = tester.ExtractZipFiles(file);
            }
            
            Assert.IsNotNullOrEmpty(path);
        }

        [Test]
        public void CreateZipFile_CreateZipOfSingleFile_Tester()
        {
            var tester = new ZipHelper();
            //tester.CreateZipOfSingleFile(@"D:\Backup\HF\HCPCA CustomerNotes.csv", null);
            tester.CreateZipOfSingleFile(@"D:\Backup\HF\HCPCA CustomerNotes.csv", "asdf1234");
        }
    }
}