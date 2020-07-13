using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Core.Application
{
   [TestFixture]
    public class PdfGeneratorTester
   {
       private PdfGenerator _pdfGenerator;

        [SetUp]
        public void SetUp()
        {
            string source =
                "www.msn.com";
            _pdfGenerator = new PdfGenerator(source,@"C:\Bidhan\", "" );

        }

        [Test]
        public void Test1()
        {
            Assert.IsNotNull(_pdfGenerator.GeneratePdf());
        }
    }
}

