using System;
using System.IO;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    [TestFixture]
    public class PdfGeneratorTester
    {
        private IPdfGenerator _pdfGenerator;


        //private string _roasterUrl =
        //    @"http://qa-app.preventionhealth.org/App/Franchisee/Technician/PrintRosterNew.aspx?EventID=1&EventName=ABC%20Host&EventDate=5/22/2011&EventAddress=Austin,Texas,78705&HostName=ABC%20Host&HostPhone=2222222222&Type=Roster";

        private const string RoasterUrl = @"http://localhost/media.falcon.com/temp/FInalPdf_customer.htm";


        [SetUp]
        public void SetUp()
        {

            _pdfGenerator = new PdfGenerator();

        }

        [Test]
        public void GeneratePdfBasicTest()
        {
            var tempPath = Environment.GetEnvironmentVariable("temp");

            var fileCreated = _pdfGenerator.Generate(RoasterUrl, tempPath + @"\", "");

            Assert.IsNotNull(fileCreated);

            FileInfo fileInfo = new FileInfo(tempPath + @"\" + fileCreated);
            fileInfo.Delete();

        }

        [Test]
        public void GeneratePdfforDocTest()
        {
            var fileCreated = _pdfGenerator.Generate("D:\\SampleDoc.doc", "D:\\");
            Assert.IsNotNull(fileCreated);
        }

        [Test]
        public void GeneratePdfFromStringBuilderBasicTest()
        {
            var tempPath = Environment.GetEnvironmentVariable("temp");

            var requestedString = new StringBuilder("Bidhan Baruah");

            var fileCreated = _pdfGenerator.Generate(requestedString, tempPath + @"\", "");

            Assert.IsNotNull(fileCreated);

            FileInfo fileInfo = new FileInfo(tempPath + @"\" + fileCreated);
            fileInfo.Delete();

        }

        [Test]
        [Ignore("Run it locally to check if the instances are properly closed or not!")]
        public void GeneratePdfLoadTest()
        {
            var tempPath = Environment.GetEnvironmentVariable("temp");

            for (int generationNumber = 0; generationNumber < 100; generationNumber++)
            {
                var fileCreated = _pdfGenerator.Generate(RoasterUrl, tempPath + @"\", "");
                
                Assert.IsNotNull(fileCreated);

                FileInfo fileInfo = new FileInfo(tempPath + @"\" + fileCreated);
                fileInfo.Delete();
            }
        }

        [Test]
        [Ignore("Run it by setting project target X86 applications to support 32 bit dll.")]
        public void GeneratePdf_usingAbcPdf()
        {
            _pdfGenerator.GeneratePdf("http://localhost/config/content/ResultPacket/coverletter.htm", @"D:\CoverLetter.pdf");
            
        }
    }
}

