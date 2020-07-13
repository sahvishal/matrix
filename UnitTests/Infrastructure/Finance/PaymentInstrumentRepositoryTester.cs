using System.Collections.Generic;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;
using Rhino.Mocks;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class PaymentInstrumentRepositoryTester : RepositoryTesterBase
    {
        private IPaymentInstrumentRepository _paymentInstrumentRepository;
        private IPaymentInstrumentFactory _paymentInstrumentFactory;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _paymentInstrumentFactory = _mocks.StrictMock<IPaymentInstrumentFactory>();
            _paymentInstrumentRepository = new CombinedPaymentInstrumentRepository(_persistenceLayer, _paymentInstrumentFactory);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
            _paymentInstrumentRepository = null;
        }

        private int _numberOfEntitiesGivenToFactory;
        private delegate bool GetPaymentInstrumentsFromCheckEntitiesDelegate(EntityCollection<CheckEntity> checkEntities);
        private bool GetPaymentInstrumentsFromCheckEntities(EntityCollection<CheckEntity> checkEntities)
        {
            _numberOfEntitiesGivenToFactory = checkEntities.Count;
            return true;
        }

        private void ExpectGetPaymentInstrumentsFromCheckEntities()
        {
            Expect.Call(_paymentInstrumentFactory.CreatePaymentInstruments(null)).IgnoreArguments()
                .Callback(new GetPaymentInstrumentsFromCheckEntitiesDelegate(GetPaymentInstrumentsFromCheckEntities))
                .Return(new List<PaymentInstrument>());
        }

        private void ExpectGetInstrumentsForPayment(IEntityCollection2 checkEntitiesToReturn)
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntityCollection(checkEntitiesToReturn);
            ExpectGetPaymentInstrumentsFromCheckEntities();
        }

        [Test]
        public void GetPaymentInstrumentsForMedicalVendorPaymentGivesEmptyCollectionToFactoryForInvalidId()
        {
            ExpectGetInstrumentsForPayment(null);

            _mocks.ReplayAll();
            _paymentInstrumentRepository.GetPaymentInstrumentsForPayment(0);
            _mocks.VerifyAll();

            Assert.AreEqual(0, _numberOfEntitiesGivenToFactory);
        }

        [Test]
        public void GetPaymentInstrumentsForMedicalVendorPaymentGivesOneInstrumentToFactoryForValidIdWithOneInstrument()
        {
            var checkEntitiesToReturn = new EntityCollection<CheckEntity> {new CheckEntity()};
            ExpectGetInstrumentsForPayment(checkEntitiesToReturn);

            _mocks.ReplayAll();
            _paymentInstrumentRepository.GetPaymentInstrumentsForPayment(1);
            _mocks.VerifyAll();

            Assert.AreEqual(1, _numberOfEntitiesGivenToFactory);
        }

        [Test]
        public void GetPaymentInstrumentsForMedicalVendorPaymentGivesThreePaymentsToFactoryForIdWithThreeInstruments()
        {
            var checkEntitiesToReturn = new EntityCollection<CheckEntity>
                { new CheckEntity(), new CheckEntity(), new CheckEntity() };
            ExpectGetInstrumentsForPayment(checkEntitiesToReturn);

            _mocks.ReplayAll();
            _paymentInstrumentRepository.GetPaymentInstrumentsForPayment(2);
            _mocks.VerifyAll();

            Assert.AreEqual(3, _numberOfEntitiesGivenToFactory);
        }

        [Test]
        public void GetPaymentInstrumentsForInvoiceGetsInstrumentsFor0PaymentsWhenInvoiceDoesNotExist()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntityCollection();

            _mocks.ReplayAll();
            _paymentInstrumentRepository.GetPaymentInstrumentsForInvoice(0);
            _mocks.VerifyAll();
        }
    }
}