using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class KynAppLipidParserTester
    {
        private IKynAppLipidParser _kynAppLipidParser;
        private const string TagforBiomarker = "biomarker";
        private const string XmlPath = @"D:\Project Docs\kyn\kyn\520496.xml";

        public KynAppLipidParserTester()
        {
            DependencyRegistrar.RegisterDependencies();
            _kynAppLipidParser = new KynAppLipidParser(IoC.Resolve<ILogManager>().GetLogger("LogFile"), TagforBiomarker,
                                                       "name", "value", IoC.Resolve<ILipidParserHelper>());
        }

        [Test]
        public void IsLipidDataExtracted_Valid_Test()
        {
            var testResult = (LipidTestResult)_kynAppLipidParser.Parse(12, XmlPath,TestType.Lipid);
            Assert.IsNotNull(testResult);

            Assert.IsNotNull(testResult.HDL);
            Assert.IsNotNull(testResult.HDL.Reading);
            Assert.AreEqual("32", testResult.HDL.Reading);


            Assert.IsNotNull(testResult.TotalCholestrol);
            Assert.IsNotNull(testResult.TotalCholestrol.Reading);
            Assert.AreEqual("135", testResult.TotalCholestrol.Reading);

            Assert.IsNotNull(testResult.LDL);
            Assert.IsNotNull(testResult.LDL.Reading);
            Assert.AreEqual(92, testResult.LDL.Reading);


            Assert.IsNotNull(testResult.TriGlycerides);
            Assert.IsNotNull(testResult.TriGlycerides.Reading);
            Assert.AreEqual("55", testResult.TriGlycerides.Reading);


            Assert.IsNotNull(testResult.Glucose);
            Assert.IsNotNull(testResult.Glucose.Reading);
            Assert.AreEqual(88, testResult.Glucose.Reading);


            Assert.IsNotNull(testResult.TCHDLRatio);
            Assert.IsNotNull(testResult.TCHDLRatio.Reading);
            Assert.AreEqual(4.22, testResult.TCHDLRatio.Reading);


        }

    }
}
