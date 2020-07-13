using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical.Domain;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Screening
{
    [TestFixture]
    public class ASITestResultTester
    {
        [Test]
        public void  OneValueOfASIReturnsSameValueAsTheAverage()
        {
            ASITestResult asiTestResult = new ASITestResult();
            var reading = new ResultReading<int>() { Reading = 20 };
            asiTestResult.RawASI = new List<ResultReading<int>>();
            asiTestResult.RawASI.Add(reading);

            Assert.AreEqual(20,asiTestResult.AverageASI);
        }

        [Test]
        public void TwoValueOfASIOf20And30ShouldReturns25()
        {
            ASITestResult asiTestResult = new ASITestResult();
            var reading1 = new ResultReading<int>() { Reading = 20 };
            var reading2 = new ResultReading<int>() { Reading = 30 };

            asiTestResult.RawASI = new List<ResultReading<int>>();
            asiTestResult.RawASI.Add(reading1);
            asiTestResult.RawASI.Add(reading2);

            Assert.AreEqual(25, asiTestResult.AverageASI);
        }
              
    }
}
