using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.UI;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    [TestFixture]
    public class PdfToImageConverterTester
    {
        private IPdftoImageConverter _pdftoImageConverter;

        private const string Source1 = @"C:\Users\Ashutosh\Desktop\PHS\13720-RODERICK-SENTZ.jpg";
        private const string Source2 = @"C:\Bidhan\Projects\BMS\Media.falcon.com\temp\472518_Hernandez Karen S_13092011_123820.pdf";

        private const string destination1 = @"C:\Users\Ashutosh\Desktop\PHS\EKG1.jpg";
        private const string destination2 = @"C:\Bidhan\Projects\BMS\Media.falcon.com\temp\EKG2.jpg";




        [SetUp]
        public void SetUp()
        {

            _pdftoImageConverter = new PdftoImageConverter();

        }

        [Test]
        public void GeneratePdfToImageBasicTest()
        {

            var fileCreated = _pdftoImageConverter.ConvertToImage(Source1, destination1, null, true);
            var fileCreated1 = _pdftoImageConverter.ConvertToImage(Source2, destination2, null, true);

            Assert.IsNotNull(fileCreated);
        }

        [Test]
        public void HideEcgFindingTest()
        {
            _pdftoImageConverter.HideEcgFinding(Source1, destination1, null, new List<RectangleDimesion> { new RectangleDimesion(60, 110, 1100, 240) });
        }


    }
}

