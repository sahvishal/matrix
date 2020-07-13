using System.Linq;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Impl;
using NUnit.Framework;
using Falcon.App.Core.Interfaces;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class CardiovisionParserTester
    {
        public CardiovisionParserTester()
        {
            DependencyRegistrar.RegisterDependencies();          
        }

        [Test]
        public void GetTestResultfromCardiovisonFile_NotNull_NotEmpty_ContainsLipidPadAsi_Tester()
        {
            var parser = new CardiovisionResultParser(@"D:\DB for Restore\HFFiles\cardiovision exports", 1234, IoC.Resolve<ILogManager>().GetLogger("Log_File_Tester"), false);
            var eventCustomerScreeningAggregates = parser.Parse();

            Assert.IsNotNull(eventCustomerScreeningAggregates);
            Assert.IsNotEmpty(eventCustomerScreeningAggregates.ToArray());

            var containsPad =
                eventCustomerScreeningAggregates.Where(
                    ecs => ecs.TestResults != null && ecs.TestResults.Where(t => t.TestType == TestType.PAD).Count() > 0)
                    .ToArray();

            var containsAsi =
                eventCustomerScreeningAggregates.Where(
                    ecs => ecs.TestResults != null && ecs.TestResults.Where(t => t.TestType == TestType.ASI).Count() > 0)
                    .ToArray();

            var containsLipid =
                eventCustomerScreeningAggregates.Where(
                    ecs => ecs.TestResults != null && ecs.TestResults.Where(t => t.TestType == TestType.Lipid).Count() > 0)
                    .ToArray();

            Assert.IsNotNull(containsPad);
            Assert.IsNotEmpty(containsPad);
            
            Assert.IsNotNull(containsAsi);
            Assert.IsNotEmpty(containsAsi);

            Assert.IsNotNull(containsLipid);
            Assert.IsNotEmpty(containsLipid);
        }
    }
}