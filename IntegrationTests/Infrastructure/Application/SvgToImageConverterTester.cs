using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    [TestFixture]
    public class SvgToImageConverterTester
    {
        private ISvgToImageConverter _svgToImageConverter;

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            _svgToImageConverter = IoC.Resolve<ISvgToImageConverter>();
        }

        [Test]
        public void GenerateFile_Tester()
        {
            const string svgFilePath = "D:\\CURVEGRAPH_QIMT.svg";
            var imageFilePath = _svgToImageConverter.GenerateImage(svgFilePath);
            Assert.IsTrue(File.Exists(imageFilePath));
        }
    }
}