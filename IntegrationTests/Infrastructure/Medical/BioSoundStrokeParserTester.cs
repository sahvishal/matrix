using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class BioSoundStrokeParserTester
    {
        public BioSoundStrokeParserTester()
        {
            DependencyRegistrar.RegisterDependencies();             
        }

        [Test]
        public void GetStrokeTestResult_fromStrokeParser()
        {
            var bioSoundStrokeParser = new BioSoundStrokeParser(@"D:\DB for Restore\HFFiles\Bio Sound\BEVAN_CHRIS1\20110714171300\resources\Report.xml", @"D:\Projects\Falcon\trunk\src\UI\Media.falcon.com\ResultMedia\123\21\", IoC.Resolve<ILogManager>().GetLogger("Log_File_Tester"));
            var testResult = bioSoundStrokeParser.Parse();

            Assert.IsNotNull(testResult);
        }
    }
}