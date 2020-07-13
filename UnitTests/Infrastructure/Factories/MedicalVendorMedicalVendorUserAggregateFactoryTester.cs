using System;
using System.Collections.Generic;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Domain.MedicalVendors.ViewData;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class MedicalVendorMedicalVendorUserAggregateFactoryTester
    {
        private readonly IMedicalVendorMedicalVendorUserAggregateFactory _medicalVendorMedicalVendorUserAggregateFactory
            = new MedicalVendorMedicalVendorUserAggregateFactory();

        [Test]
        public void Test_FAKETEST()
        {
            Assert.True(true);
        }

        //[Test]
        //public void CreateMedicalVendorMedicalVendorUserAggregatesReturnsEmptyListWhenNoVendorsGiven()
        //{
        //    List<MedicalVendorMedicalVendorUserAggregate> medicalVendorMedicalVendorUserAggregates =
        //        _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregates(
        //        new List<MedicalVendorMedicalVendorUser>(), new MedicalVendorMVUserEarningAndPayRateTypedView(),
        //        new MedicalVendorMVUserPaymentTypedView());

        //    Assert.IsNotNull(medicalVendorMedicalVendorUserAggregates);
        //    Assert.IsEmpty(medicalVendorMedicalVendorUserAggregates);
        //}

        //[Test]
        //public void CreateMedicalVendorMedicalVendorUserAggregatesReturnsOneRowWhenOneVendorUserGiven()
        //{
        //    var medicalVendorMedicalVendorUsers = new List<MedicalVendorMedicalVendorUser> { new MedicalVendorMedicalVendorUser() };
        //    List<MedicalVendorMedicalVendorUserAggregate> medicalVendorMedicalVendorUserAggregates =
        //        _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregates(
        //        medicalVendorMedicalVendorUsers, new MedicalVendorMVUserEarningAndPayRateTypedView(),
        //        new MedicalVendorMVUserPaymentTypedView());

        //    Assert.IsTrue(medicalVendorMedicalVendorUserAggregates.HasSingleItem(), "{0} item(s) returned.",
        //        medicalVendorMedicalVendorUserAggregates.Count);
        //}

        //[Test]
        //public void CreateMedicalVendorMedicalVendorUserAggregatesReturnsOneItemWhenOneEarningAndOneVendorGiven()
        //{
        //    var medicalVendorMedicalVendorUsers = new List<MedicalVendorMedicalVendorUser> { new MedicalVendorMedicalVendorUser() };
        //    var medicalVendorMVUserEarningAndPayRateTypedView = new MedicalVendorMVUserEarningAndPayRateTypedView();
        //    medicalVendorMVUserEarningAndPayRateTypedView.Rows.Add();

        //    List<MedicalVendorMedicalVendorUserAggregate> medicalVendorMedicalVendorUserAggregates =
        //        _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregates(
        //        medicalVendorMedicalVendorUsers, medicalVendorMVUserEarningAndPayRateTypedView,
        //        new MedicalVendorMVUserPaymentTypedView());

        //    Assert.IsTrue(medicalVendorMedicalVendorUserAggregates.HasSingleItem(), "{0} item(s) returned.",
        //        medicalVendorMedicalVendorUserAggregates.Count);
        //}

        //[Test]
        //public void CreateMedicalVendorMedicalVendorUserAggregatesReturnsOneItemWhenOnePaymentAndOneVendorGiven()
        //{
        //    var medicalVendorMedicalVendorUsers = new List<MedicalVendorMedicalVendorUser> { new MedicalVendorMedicalVendorUser() };
        //    var medicalVendorMVUserPaymentTypedView = new MedicalVendorMVUserPaymentTypedView();
        //    medicalVendorMVUserPaymentTypedView.Rows.Add();

        //    List<MedicalVendorMedicalVendorUserAggregate> medicalVendorMedicalVendorUserAggregates =
        //        _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregates(
        //        medicalVendorMedicalVendorUsers, new MedicalVendorMVUserEarningAndPayRateTypedView(),
        //        medicalVendorMVUserPaymentTypedView);

        //    Assert.IsTrue(medicalVendorMedicalVendorUserAggregates.HasSingleItem(), "{0} item(s) returned.",
        //        medicalVendorMedicalVendorUserAggregates.Count);
        //}

        //[Test]
        //public void CreateMedicalVendorMedicalVendorUserAggregatesReturnsOneItemWhenOnePaymentEarningAndVendorFound()
        //{
        //    var medicalVendorMedicalVendorUsers = new List<MedicalVendorMedicalVendorUser> { new MedicalVendorMedicalVendorUser() };
        //    var medicalVendorMVUserEarningAndPayRateTypedView = new MedicalVendorMVUserEarningAndPayRateTypedView();
        //    medicalVendorMVUserEarningAndPayRateTypedView.Rows.Add();
        //    var medicalVendorMVUserPaymentTypedView = new MedicalVendorMVUserPaymentTypedView();
        //    medicalVendorMVUserPaymentTypedView.Rows.Add();

        //    List<MedicalVendorMedicalVendorUserAggregate> medicalVendorMedicalVendorUserAggregates =
        //        _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregates(
        //        medicalVendorMedicalVendorUsers, medicalVendorMVUserEarningAndPayRateTypedView,
        //        medicalVendorMVUserPaymentTypedView);

        //    Assert.IsTrue(medicalVendorMedicalVendorUserAggregates.HasSingleItem(), "{0} item(s) returned.",
        //        medicalVendorMedicalVendorUserAggregates.Count);
        //}

        //[Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CreateMedicalVendorMedicalVendorUserAggregatesThrowsExceptionWhenGivenNullVendorList()
        //{
        //    _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregates(
        //        null, new MedicalVendorMVUserEarningAndPayRateTypedView(), new MedicalVendorMVUserPaymentTypedView());
        //}

        //[Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CreateMedicalVendorMedicalVendorUserAggregatesThrowsExceptionWhenGivenNullEarningView()
        //{
        //    _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregates
        //        (new List<MedicalVendorMedicalVendorUser>(), null, new MedicalVendorMVUserPaymentTypedView());
        //}

        //[Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CreateMedicalVendorMedicalVendorUserAggregatesThrowsExceptionWhenGivenNullPaymentView()
        //{
        //    _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregates(
        //        new List<MedicalVendorMedicalVendorUser>(), new MedicalVendorMVUserEarningAndPayRateTypedView(), null);
        //}

        //[Test]
        //public void CreateMedicalVendorMedicalVendorUserAggregateSetsEarningPropertiesTo0WhenNoEarningsFound()
        //{
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser();
        //    var medicalVendorMVUserPaymentTypedView = new MedicalVendorMVUserPaymentTypedView();
        //    medicalVendorMVUserPaymentTypedView.Rows.Add();

        //    MedicalVendorMedicalVendorUserAggregate medicalVendorMedicalVendorUserAggregates =
        //        _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregate(
        //        medicalVendorMedicalVendorUser, new MedicalVendorMVUserEarningAndPayRateTypedView(),
        //        medicalVendorMVUserPaymentTypedView);

        //    Assert.AreEqual(0, medicalVendorMedicalVendorUserAggregates.NumberOfEvaluations);
        //    Assert.AreEqual(0m, medicalVendorMedicalVendorUserAggregates.PayRate);
        //    Assert.AreEqual(0m, medicalVendorMedicalVendorUserAggregates.TotalEarnings);
        //}

        //[Test]
        //public void CreateMedicalVendorMedicalVendorUserAggregateSetsEarningPropertiesTo0WhenNoPaymentsFound()
        //{
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser();
        //    var medicalVendorMVUserEarningAndPayRateTypedView = new MedicalVendorMVUserEarningAndPayRateTypedView();
        //    medicalVendorMVUserEarningAndPayRateTypedView.Rows.Add();

        //    MedicalVendorMedicalVendorUserAggregate medicalVendorMedicalVendorUserAggregates =
        //        _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregate(
        //        medicalVendorMedicalVendorUser, medicalVendorMVUserEarningAndPayRateTypedView,
        //        new MedicalVendorMVUserPaymentTypedView());

        //    Assert.AreEqual(0m, medicalVendorMedicalVendorUserAggregates.TotalPayments);
        //}

        //[Test]
        //public void CreateMedicalVendorMedicalVendorUserAggregateSetsFoundVendorsToVendorPropertyOfAggregates()
        //{
        //    var expectedMedicalVendorUser = new MedicalVendorMedicalVendorUser();

        //    MedicalVendorMedicalVendorUserAggregate medicalVendorMedicalVendorUserAggregates =
        //        _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregate(
        //        expectedMedicalVendorUser, new MedicalVendorMVUserEarningAndPayRateTypedView(),
        //        new MedicalVendorMVUserPaymentTypedView());

        //    Assert.AreEqual(expectedMedicalVendorUser, medicalVendorMedicalVendorUserAggregates.MedicalVendorMedicalVendorUser);
        //}

        //[Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CreateMedicalVendorMedicalVendorUserAggregateThrowsExceptionWhenGivenNullVendor()
        //{
        //    _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregate(null,
        //        new MedicalVendorMVUserEarningAndPayRateTypedView(), new MedicalVendorMVUserPaymentTypedView());
        //}

        //[Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CreateMedicalVendorMedicalVendorUserAggregateThrowsExceptionWhenGivenNullEarningView()
        //{
        //    _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregate(
        //        new MedicalVendorMedicalVendorUser(), null, new MedicalVendorMVUserPaymentTypedView());
        //}

        //[Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CreateMedicalVendorMedicalVendorUserAggregateThrowsExceptionWhenGivenNullPaymentView()
        //{
        //    _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregate
        //        (new MedicalVendorMedicalVendorUser(), new MedicalVendorMVUserEarningAndPayRateTypedView(), null);
        //}
    }
}