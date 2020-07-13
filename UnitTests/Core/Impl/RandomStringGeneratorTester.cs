using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class RandomStringGeneratorTester
    {
        [Test]
        public void RandomStringGeneratorReturnsStringOfCorrectLength()
        {
            IRandomStringGenerator randomStringGenerator = new RandomStringGenerator();

            for (int i = 0; i < 20; ++i)
            {
                string randomString = randomStringGenerator.GetRandomString(i);
                Assert.AreEqual(i, randomString.Length);
            }
        }
    }
}