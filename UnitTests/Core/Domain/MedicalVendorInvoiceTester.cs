using System.Linq;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using NUnit.Framework;
using Falcon.App.Core.Domain;

namespace HealthYes.Web.UnitTests.Core.Domain
{
    [TestFixture]
    public class MedicalVendorInvoiceTester
    {
        private PhysicianInvoice _medicalVendorInvoice;

        [SetUp]
        public void SetUp()
        {
            _medicalVendorInvoice = new PhysicianInvoice();
        }

        [TearDown]
        public void TearDown()
        {
            _medicalVendorInvoice = null;
        }

        [Test]
        public void MedicalVendorInvoiceItemsIsInitializedOnInstantiation()
        {
            Assert.IsNotNull(_medicalVendorInvoice.MedicalVendorInvoiceItems);
        }

        [Test]
        public void InvoiceAmountReturnsZeroWhenInvoiceItemsCollectionIsEmpty()
        {
            _medicalVendorInvoice.MedicalVendorInvoiceItems.Clear();

            const decimal expectedInvoiceAmount = 0m;
            Assert.AreEqual(expectedInvoiceAmount, _medicalVendorInvoice.InvoiceAmount);
        }

        [Test]
        public void InvoiceAmountReturnsAmountOfSingleInvoiceItemAmountEarnedWhenOneExists()
        {
            const decimal expectedInvoiceAmount = 5.55m;

            _medicalVendorInvoice.MedicalVendorInvoiceItems.Add(new MedicalVendorInvoiceItem 
                {MedicalVendorAmountEarned = expectedInvoiceAmount});

            Assert.AreEqual(expectedInvoiceAmount, _medicalVendorInvoice.InvoiceAmount);
        }

        [Test]
        public void InvoiceAmountReturnsTotalAmountEarnedOfThreeInvoiceItemsInCollection()
        {
            _medicalVendorInvoice.MedicalVendorInvoiceItems.Add(new MedicalVendorInvoiceItem { MedicalVendorAmountEarned = 3.32m });
            _medicalVendorInvoice.MedicalVendorInvoiceItems.Add(new MedicalVendorInvoiceItem { MedicalVendorAmountEarned = 5.32m });
            _medicalVendorInvoice.MedicalVendorInvoiceItems.Add(new MedicalVendorInvoiceItem { MedicalVendorAmountEarned = 3.32m });

            decimal expectedInvoiceAmount = _medicalVendorInvoice.MedicalVendorInvoiceItems.Sum(m => m.MedicalVendorAmountEarned);
            Assert.AreEqual(expectedInvoiceAmount, _medicalVendorInvoice.InvoiceAmount);
        }

        [Test]
        public void NumberOfEvaluationsReturnsZeroWhenInvoiceHasNoInvoiceItems()
        {
            _medicalVendorInvoice.MedicalVendorInvoiceItems.Clear();

            Assert.AreEqual(0, _medicalVendorInvoice.NumberOfEvaluations);
        }

        [Test]
        public void NumberOfEvaluationsReturnsOneWhenOneInvoiceHasOneInvoiceItem()
        {
            _medicalVendorInvoice.MedicalVendorInvoiceItems.Add(new MedicalVendorInvoiceItem());

            Assert.AreEqual(1, _medicalVendorInvoice.NumberOfEvaluations);
        }

        [Test]
        public void NumberOfEvaluationsReturnsNumberOfInvoiceItemsInvoiceHas()
        {
            _medicalVendorInvoice.MedicalVendorInvoiceItems.Add(new MedicalVendorInvoiceItem());
            for (int i = 2; i < 10; i++)
            {
                _medicalVendorInvoice.MedicalVendorInvoiceItems.Add(new MedicalVendorInvoiceItem());
                Assert.AreEqual(i, _medicalVendorInvoice.NumberOfEvaluations, string.Format("{0} evaluations returned when {1} expected.",
                    _medicalVendorInvoice.NumberOfEvaluations, i));
            }
        }
    }
}