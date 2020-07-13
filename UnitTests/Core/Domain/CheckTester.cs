using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using NUnit.Framework;


namespace HealthYes.Web.UnitTests.Core.Domain
{
    [TestFixture]
    public class CheckTester
    {
        [Test]
        public void GetPaymentTypeReturnsCheckPaymentType()
        {
            //Assert.IsInstanceOf<PaymentType.Check.GetType()>(new Check().PaymentType);
        }

        [Test]
        public void ToStringReturnsCheck()
        {
            const string expectedString = "Check";
            Assert.AreEqual(expectedString, new Check().ToString());
        }
    }
}