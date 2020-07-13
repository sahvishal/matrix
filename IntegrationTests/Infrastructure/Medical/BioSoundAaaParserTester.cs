using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class BioSoundAaaParserTester
    {
        public BioSoundAaaParserTester()
        {
            DependencyRegistrar.RegisterDependencies();          
        }

        [Test]
        public void GetAaaTestResult_fromAaaParser()
        {
            var bioSoundAaaParser = new BioSoundAaaParser(@"D:\Project Docs\AaaFile\Report.xml", @"D:\Projects\Falcon\trunk\src\UI\Media.falcon.com\ResultMedia\123\21\", IoC.Resolve<ILogManager>().GetLogger("Log_File_Tester"));
            var aaaTestResult = bioSoundAaaParser.Parse();

            Assert.IsNotNull(aaaTestResult);
        }

    }
}