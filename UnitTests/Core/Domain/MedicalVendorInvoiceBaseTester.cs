using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using System;

namespace HealthYes.Web.UnitTests.Core.Domain
{
    [TestFixture]
    public class MedicalVendorInvoiceBaseTester
    {
        [Test]
        public void ToStringContainsId()
        {
            const long expectedMedicalVendorInvoiceId = 3;
            string expectedMedicalvendorInvoiceIdString = expectedMedicalVendorInvoiceId.ToString();
            var invoice = new FakeMedicalVendorInvoiceBase(expectedMedicalVendorInvoiceId);

            string invoiceString = invoice.ToString();

            Assert.IsTrue(invoiceString.Contains(expectedMedicalvendorInvoiceIdString),
                "Expected '{0}' to contain id '{1}'.", invoiceString, expectedMedicalvendorInvoiceIdString);
        }

        [Test]
        public void ToStringContainsMedicalVendorName()
        {
            const string expectedMedicalVendorName = "Bob Parr";
            var invoice = new FakeMedicalVendorInvoiceBase {MedicalVendorName = expectedMedicalVendorName};

            string invoiceString = invoice.ToString();

            Assert.IsTrue(invoiceString.Contains(expectedMedicalVendorName),
                "Expected '{0}' to contain medical vendor name '{1}'.", invoiceString, expectedMedicalVendorName);
        }

        [Test]
        public void ToStringContainsPhysicianName()
        {
            const string expectedPhysicianName = "Citizen Kane";
            var invoice = new FakeMedicalVendorInvoiceBase { PhysicianName = expectedPhysicianName };

            string invoiceString = invoice.ToString();

            Assert.IsTrue(invoiceString.Contains(expectedPhysicianName),
                "Expected '{0}' to contain physician name '{1}'.", invoiceString, expectedPhysicianName);
        }

        [Test]
        public void ToStringContainsPayPeriodString()
        {
            var payPeriodStartDate = new DateTime(2001, 1, 1);
            var payPeriodEndDate = new DateTime(2003, 2, 1);
            var invoice = new FakeMedicalVendorInvoiceBase { PayPeriodStartDate = payPeriodStartDate, PayPeriodEndDate = payPeriodEndDate };
            string expectedPayPeriodString = invoice.PayPeriodString;

            string invoiceString = invoice.ToString();

            Assert.IsTrue(invoiceString.Contains(expectedPayPeriodString),
                "Expected '{0}' to contain pay period string '{1}'.", invoiceString, expectedPayPeriodString);
        }
    }
}