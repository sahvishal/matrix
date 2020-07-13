using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Domain.MedicalVendors.ViewData;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Factories;
using NUnit.Framework;
using Falcon.App.Infrastructure.Interfaces;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    [Ignore]
    public class MedicalVendorEarningCustomerAggregateFactoryTester
    {
        private readonly IMedicalVendorEarningCustomerAggregateFactory _medicalVendorEarningCustomerAggregateFactory =
            new MedicalVendorEarningCustomerAggregateFactory();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorEarningAggregateThrowsExceptionWhenNullRowGiven()
        {
            _medicalVendorEarningCustomerAggregateFactory.CreateMedicalVendorEarningAggregate(null);
        }

        [Test]
        public void CreateMedicalVendorEarningAggregateReturnsAggregateWhenRowGiven()
        {
            var medicalVendorEarningCustomerRow = (MedicalVendorEarningCustomerRow)new MedicalVendorEarningCustomerTypedView().Rows.Add();
            
            MedicalVendorEarningCustomerAggregate medicalVendorEarningCustomerAggregate = _medicalVendorEarningCustomerAggregateFactory.
                CreateMedicalVendorEarningAggregate(medicalVendorEarningCustomerRow);

            Assert.IsNotNull(medicalVendorEarningCustomerAggregate);
        }

        [Test]
        public void CreateMedicalVendorEarningAggregateMapsRowPropertiesToAggregateProperties()
        {
            var evaluationDate = new DateTime(2001, 1, 1);
            const decimal amountEarned = 3.22m;
            const int customerId = 5;
            const string packageName = "PackageName";
            var medicalVendorEarningCustomerRow = (MedicalVendorEarningCustomerRow)new MedicalVendorEarningCustomerTypedView().
                Rows.Add(customerId, 2, 3, amountEarned, evaluationDate, packageName);

            MedicalVendorEarningCustomerAggregate medicalVendorEarningCustomerAggregate = _medicalVendorEarningCustomerAggregateFactory.
                CreateMedicalVendorEarningAggregate(medicalVendorEarningCustomerRow);
            
            Assert.AreEqual(customerId, medicalVendorEarningCustomerAggregate.CustomerId);
            Assert.AreEqual(amountEarned, medicalVendorEarningCustomerAggregate.AmountEarned);
            Assert.AreEqual(packageName, medicalVendorEarningCustomerAggregate.PackageName);
            Assert.AreEqual(evaluationDate, medicalVendorEarningCustomerAggregate.EvaluationDate);
        }

        [Test]
        public void CreateMedicalVendorEarningAggregateCreatesCustomerNameObjectWithGivenNames()
        {
            var expectedName = new Name("FirstName", "MiddleName", "LastName");
            var medicalVendorEarningCustomerRow = (MedicalVendorEarningCustomerRow)new MedicalVendorEarningCustomerTypedView().
                Rows.Add(1, 2, 3, 4, new DateTime(), 6, expectedName.FirstName, expectedName.MiddleName, expectedName.LastName);

            MedicalVendorEarningCustomerAggregate medicalVendorEarningCustomerAggregate = _medicalVendorEarningCustomerAggregateFactory.
                CreateMedicalVendorEarningAggregate(medicalVendorEarningCustomerRow);

            Assert.AreEqual(expectedName.FullName, medicalVendorEarningCustomerAggregate.CustomerName.FullName);
        }

        [Test]
        public void CreateMedicalVendorEarningAggregateCreatesPhysicianNameObjectWithGivenNames()
        {
            var expectedName = new Name("FirstName", "MiddleName", "LastName");
            var medicalVendorEarningCustomerRow = (MedicalVendorEarningCustomerRow)new MedicalVendorEarningCustomerTypedView().
                Rows.Add(1, 2, 3, 4, new DateTime(), 6, 7, 8, 9, expectedName.FirstName, expectedName.MiddleName, expectedName.LastName);

            MedicalVendorEarningCustomerAggregate medicalVendorEarningCustomerAggregate = _medicalVendorEarningCustomerAggregateFactory.
                CreateMedicalVendorEarningAggregate(medicalVendorEarningCustomerRow);

            Assert.AreEqual(expectedName.FullName, medicalVendorEarningCustomerAggregate.PhysicianName.FullName);
        }

        [Test]
        public void CreateMedicalVendorEarningAggregateMapsIdsToObject()
        {
            const long expectedMedicalVendorId = 23;
            const long expectedOrganizationRoleUserId = 348;
            var medicalVendorEarningCustomerRow = (MedicalVendorEarningCustomerRow)new MedicalVendorEarningCustomerTypedView().
                Rows.Add(1, expectedMedicalVendorId, expectedOrganizationRoleUserId);
           
            MedicalVendorEarningCustomerAggregate medicalVendorEarningCustomerAggregate = _medicalVendorEarningCustomerAggregateFactory.
                CreateMedicalVendorEarningAggregate(medicalVendorEarningCustomerRow);

            Assert.AreEqual(expectedMedicalVendorId, medicalVendorEarningCustomerAggregate.MedicalVendorId);
            Assert.AreEqual(expectedOrganizationRoleUserId, medicalVendorEarningCustomerAggregate.OrganizationRoleUserId);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorEarningAggregatesThrowsExceptionWhenNullViewGiven()
        {
            _medicalVendorEarningCustomerAggregateFactory.CreateMedicalVendorEarningAggregates(null);
        }

        [Test]
        public void CreateMedicalVendorEarningAggregatesReturnsEmptyListWhenEmptyViewGiven()
        {
            List<MedicalVendorEarningCustomerAggregate> medicalVendorEarningCustomerAggregates = 
                _medicalVendorEarningCustomerAggregateFactory.CreateMedicalVendorEarningAggregates
                (new MedicalVendorEarningCustomerTypedView());

            Assert.IsNotNull(medicalVendorEarningCustomerAggregates);
            Assert.IsEmpty(medicalVendorEarningCustomerAggregates);
        }

        [Test]
        public void CreateMedicalVendorEarningAggregatesReturnsOneItemWhenGivenSingleRow()
        {
            var medicalVendorEarningCustomerTypedView = new MedicalVendorEarningCustomerTypedView();
            medicalVendorEarningCustomerTypedView.Rows.Add();

            List<MedicalVendorEarningCustomerAggregate> medicalVendorEarningCustomerAggregates =
                _medicalVendorEarningCustomerAggregateFactory.CreateMedicalVendorEarningAggregates
                (medicalVendorEarningCustomerTypedView);

            Assert.AreEqual(medicalVendorEarningCustomerTypedView.Rows.Count, medicalVendorEarningCustomerAggregates.Count);
        }

        [Test]
        public void CreateMedicalVendorEarningAggregatesReturnsThreeItemsWhenGivenThreeRows()
        {
            var medicalVendorEarningCustomerTypedView = new MedicalVendorEarningCustomerTypedView();
            medicalVendorEarningCustomerTypedView.Rows.Add();
            medicalVendorEarningCustomerTypedView.Rows.Add();
            medicalVendorEarningCustomerTypedView.Rows.Add();

            List<MedicalVendorEarningCustomerAggregate> medicalVendorEarningCustomerAggregates =
                _medicalVendorEarningCustomerAggregateFactory.CreateMedicalVendorEarningAggregates
                (medicalVendorEarningCustomerTypedView);

            Assert.AreEqual(medicalVendorEarningCustomerTypedView.Rows.Count, medicalVendorEarningCustomerAggregates.Count);
        }
    }
}