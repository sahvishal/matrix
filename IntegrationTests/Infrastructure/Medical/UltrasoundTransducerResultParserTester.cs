using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class UltrasoundTransducerResultParserTester
    {
        private UltrasoundTransducerResultParser _parser;
        private const string UltrasoundPath= @"D:\Project Docs\ResultArchives\Integra-Event\Event 30-3\Event 30";

        public UltrasoundTransducerResultParserTester()
        {
            DependencyRegistrar.RegisterDependencies();

            _parser = new UltrasoundTransducerResultParser(UltrasoundPath, 12, IoC.Resolve<ILogManager>().GetLogger("logger"), IoC.Resolve<ISettings>());
        }

        [Test]
        public void Parse_Tester()
        {
            var obj = _parser.Parse();

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj.ToArray());
        }
    }
}
