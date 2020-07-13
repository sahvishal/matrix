using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRuleFactories
{
    [TestFixture]
    public class MedicalVendorPaymentValidationRuleFactoryTester
    {
        private const PaymentStatus INVALID_PAYMENT_STATUS = 0;

        private MedicalVendorPayment _medicalVendorPayment;
        private IValidator<MedicalVendorPayment> _medicalVendorPaymentValidator;

        [SetUp]
        public void SetUp()
        {
            _medicalVendorPayment = GetValidMedicalVendorPayment();
            _medicalVendorPaymentValidator = new Validator<MedicalVendorPayment>(new MedicalVendorPaymentValidationRuleFactory());
        }

        [TearDown]
        public void TearDown()
        {
            _medicalVendorPayment = null;
            _medicalVendorPaymentValidator = null;
        }

        private static MedicalVendorPayment GetValidMedicalVendorPayment()
        {
            return new MedicalVendorPayment(1)
            {
                PaymentStatus = PaymentStatus.Paid,
                DataRecorderMetaData = new DataRecorderMetaData()
            };
        }

        [Test]
        public void IsValidReturnsFalseWhenPaymentStatusIsNotPaidOrUnpaid()
        {
            _medicalVendorPayment.PaymentStatus = INVALID_PAYMENT_STATUS;

            Assert.IsFalse(_medicalVendorPaymentValidator.IsValid(_medicalVendorPayment));
        }

        [Test]
        public void IsValidReturnsTrueWhenPaymentStatusIsUnpaidOrPaid()
        {
            _medicalVendorPayment.PaymentStatus = PaymentStatus.Paid;
            Assert.IsTrue(_medicalVendorPaymentValidator.IsValid(_medicalVendorPayment));

            _medicalVendorPayment.PaymentStatus = PaymentStatus.Unpaid;
            Assert.IsTrue(_medicalVendorPaymentValidator.IsValid(_medicalVendorPayment));
        }

        [Test]
        public void IsValidReturnsFalseWhenPaymentInstrumentValidationIsFalse()
        {
            _medicalVendorPayment.PaymentInstruments.Add(new Check { Amount = -.01m });

            Assert.IsFalse(_medicalVendorPaymentValidator.IsValid(_medicalVendorPayment));
        }

        [Test]
        public void IsValidReturnsFalseWhenDataRecorderMetaDataIsNull()
        {
            _medicalVendorPayment.DataRecorderMetaData = null;

            Assert.IsFalse(_medicalVendorPaymentValidator.IsValid(_medicalVendorPayment));
        }

        [Test]
        public void IsValidReturnsTrueWhenDataRecorderMetaDataIsNotNull()
        {
            _medicalVendorPayment.DataRecorderMetaData = new DataRecorderMetaData();

            Assert.IsTrue(_medicalVendorPaymentValidator.IsValid(_medicalVendorPayment));
        }
    }
}