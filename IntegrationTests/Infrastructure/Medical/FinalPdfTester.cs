using Falcon.App.Core.Medical;
using Falcon.App.Infrastructure.Medical.Impl;
using NUnit.Framework;
using Falcon.App.DependencyResolution;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class FinalPdfTester
    {
        private IGenerateFinalPdf _generateFinalPdf;
        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            _generateFinalPdf = IoC.Resolve<IGenerateFinalPdf>();
        }

        [Test]
        public void CreateFinalPdf()
        {
            //_generateFinalPdf.CreatePremiumPdf("", 467374, 24344);
           // _generateFinalPdf.CreateClinicalForm("", 467374, 24344);
        }
    }
}
