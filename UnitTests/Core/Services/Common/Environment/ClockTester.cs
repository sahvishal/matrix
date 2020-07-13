using System;
using Falcon.App.Core.Services.Common.Environment.Impl;
using NUnit.Framework;
using Falcon.App.Core.Services.Common.Environment;

namespace HealthYes.Web.UnitTests.Core.Services.Common.Environment
{
    [TestFixture]
    public class ClockTester
    {
        [Test]
        public void NowReturnsTheExpectedSetTime()
        {
            DateTime dateTime = new DateTime(2010,1,31,10,0,0);
            IClock clock = new Clock(dateTime);
            
            Assert.AreEqual(clock.Now,dateTime);
            
            

        }
      
    }


}