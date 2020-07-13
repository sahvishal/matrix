using System;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.TypedViewClasses;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class MedicalVendorEarningAggregateRepositoryTester : RepositoryTesterBase
    {
        private IMedicalVendorEarningAggregateFactory _medicalVendorEarningAggregateFactory;
        private IMedicalVendorEarningAggregateRepository _medicalVendorEarningAggregateRepository;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _medicalVendorEarningAggregateFactory = _mocks.StrictMock<IMedicalVendorEarningAggregateFactory>();
            _medicalVendorEarningAggregateRepository = new MedicalVendorEarningAggregateRepository
                (_persistenceLayer, _medicalVendorEarningAggregateFactory);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<MedicalVendorMedicalVendorUser>))]
        public void GetMedicalVendorEarningAggregateThrowsExceptionWhenInvalidIdGiven()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchTypedView();

            _mocks.ReplayAll();
            _medicalVendorEarningAggregateRepository.GetMedicalVendorEarningAggregate(0, 1, true);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetMedicalVendorEarningAggregateThrowsExceptionWhenMoreThanOneInvoiceFound()
        {
            var rowsToReturn = new MedicalVendorEarningInfoTypedView();
            rowsToReturn.Rows.Add();
            rowsToReturn.Rows.Add();

            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchTypedView(rowsToReturn);

            _mocks.ReplayAll();
            _medicalVendorEarningAggregateRepository.GetMedicalVendorEarningAggregate(0, 1, true);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMedicalVendorEarningAggregateThrowsExceptionWhenNoTestLockIdFound()
        {
            var rowsToReturn = new MedicalVendorEarningInfoTypedView();
            rowsToReturn.Rows.Add();

            ExpectGetDataAccessAdapterAndDispose(2);
            ExpectFetchTypedView(rowsToReturn);
            ExpectFetchEntityCollection();

            _mocks.ReplayAll();
            _medicalVendorEarningAggregateRepository.GetMedicalVendorEarningAggregate(0, 1, true);
            _mocks.VerifyAll();
        }
    }
}