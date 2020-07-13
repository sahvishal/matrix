using System.Linq;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Infrastructure.Factories;
using NUnit.Framework;
using System;

namespace Falcon.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    [Ignore("Please revisit this test when we fix the payments for medical vendors")]
    public class MedicalVendorEarningAggregateFactoryTester
    {
        private readonly IMedicalVendorEarningAggregateFactory _medicalVendorEarningAggregateFactory = 
            new MedicalVendorEarningAggregateFactory();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorEarningAggregateThrowsExceptionWhenNullRowGiven()
        {
            _medicalVendorEarningAggregateFactory.CreateMedicalVendorEarningAggregate(null, 0);
        }

        [Test]
        public void CreateMedicalVendorEarningAggregateMapsPropertiesToAggregateProperties()
        {
            var medicalVendorEarningInfoTypedView = new MedicalVendorEarningInfoTypedView();
            medicalVendorEarningInfoTypedView.Rows.Add(1, 2, 4.33m);
            MedicalVendorEarningInfoRow medicalVendorEarningInfoRow = medicalVendorEarningInfoTypedView.Single();
            
            MedicalVendorEarningAggregate medicalVendorEarningAggregate = _medicalVendorEarningAggregateFactory.
                CreateMedicalVendorEarningAggregate(medicalVendorEarningInfoRow, 0);

            Assert.AreEqual(medicalVendorEarningInfoRow.OrganizationId,medicalVendorEarningAggregate.MedicalVendorMedicalVendorUserId);
            Assert.AreEqual(medicalVendorEarningInfoRow.OrganizationId,medicalVendorEarningAggregate.MedicalVendorId);
        }
    }
}