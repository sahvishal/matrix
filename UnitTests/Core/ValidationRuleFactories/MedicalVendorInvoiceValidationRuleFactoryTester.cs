using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValidationRuleFactories
{
    [TestFixture]
    public class MedicalVendorInvoiceValidationRuleFactoryTester
    {
        private static readonly FakeValidator<MedicalVendorInvoiceItem> _medicalVendorInvoiceItemValidator =
            new FakeValidator<MedicalVendorInvoiceItem>();
        private static readonly FakeValidator<PhysicianInvoiceBase> _medicalVendorInvoiceBaseValidator =
            new FakeValidator<PhysicianInvoiceBase>();

        private readonly IValidator<PhysicianInvoice> _medicalVendorInvoiceValidator =
            new Validator<PhysicianInvoice>(new MedicalVendorInvoiceValidationRuleFactory
            (_medicalVendorInvoiceBaseValidator, _medicalVendorInvoiceItemValidator));

        private PhysicianInvoice _medicalVendorInvoice;

        [SetUp]
        public void SetUp()
        {
            _medicalVendorInvoice = GetValidMedicalVendorInvoice();
        }

        [TearDown]
        public void TearDown()
        {
            _medicalVendorInvoice = null;
        }

        private static PhysicianInvoice GetValidMedicalVendorInvoice()
        {
            return new PhysicianInvoice
            {
                MedicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> {new MedicalVendorInvoiceItem()},
            };
        }

        [Test]
        public void IsValidReturnsFalseWhenInvoiceItemCollectionHasNoItems()
        {
            _medicalVendorInvoiceItemValidator.IsValidReturnValue = true;
            _medicalVendorInvoiceBaseValidator.IsValidReturnValue = true;
            _medicalVendorInvoice.MedicalVendorInvoiceItems.Clear();

            bool isValid = _medicalVendorInvoiceValidator.IsValid(_medicalVendorInvoice);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenInvoiceItemCollectionIsInvalid()
        {
            _medicalVendorInvoiceItemValidator.IsValidReturnValue = false;
            _medicalVendorInvoiceBaseValidator.IsValidReturnValue = true;
            
            bool isValid = _medicalVendorInvoiceValidator.IsValid(_medicalVendorInvoice);
            
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsTrueWhenInvoiceItemCollectionIsValid()
        {
            _medicalVendorInvoiceItemValidator.IsValidReturnValue = true;
            _medicalVendorInvoiceBaseValidator.IsValidReturnValue = true;

            bool isValid = _medicalVendorInvoiceValidator.IsValid(_medicalVendorInvoice);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenInvoiceBaseIsInvalid()
        {
            _medicalVendorInvoiceItemValidator.IsValidReturnValue = true;
            _medicalVendorInvoiceBaseValidator.IsValidReturnValue = false;

            bool isValid = _medicalVendorInvoiceValidator.IsValid(_medicalVendorInvoice);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsTrueWhenInvoiceBaseIsInvalid()
        {
            _medicalVendorInvoiceItemValidator.IsValidReturnValue = true;
            _medicalVendorInvoiceBaseValidator.IsValidReturnValue = true;

            bool isValid = _medicalVendorInvoiceValidator.IsValid(_medicalVendorInvoice);

            Assert.IsTrue(isValid);
        }
    }
}