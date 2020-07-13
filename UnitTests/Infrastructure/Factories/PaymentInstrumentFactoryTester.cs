using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using NUnit.Framework;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Factories;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class PaymentInstrumentFactoryTester
    {
        private readonly MockRepository _mocks = new MockRepository();
        private IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;
        private IPaymentInstrumentFactory _paymentInstrumentFactory;

        [SetUp]
        public void SetUp()
        {
            _dataRecorderMetaDataFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();
            _paymentInstrumentFactory = new PaymentInstrumentFactory(_dataRecorderMetaDataFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _dataRecorderMetaDataFactory = null;
            _paymentInstrumentFactory = null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePaymentInstrumentThrowsExceptionWhenNullEntityGiven()
        {
            _mocks.ReplayAll();
            _paymentInstrumentFactory.CreatePaymentInstrument(null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreatePaymentInstrumentSetsMetaDataToCreatedMetaData()
        {
            var checkEntity = new CheckEntity
            {
                DateCreated = new DateTime(2001, 1, 1),
                DateModified = new DateTime(2002, 2, 2),
                DataRecoderCreatorId = 234,
                DataRecoderModifierId = 456
            };
            var expectedDataRecorderMetaData = new DataRecorderMetaData();
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(checkEntity.DataRecoderCreatorId,
                checkEntity.DateCreated, checkEntity.DataRecoderModifierId, checkEntity.DateModified))
                .Return(expectedDataRecorderMetaData);

            _mocks.ReplayAll();
            PaymentInstrument paymentInstrument = _paymentInstrumentFactory.
                CreatePaymentInstrument(checkEntity);
            _mocks.VerifyAll();
            
            Assert.AreEqual(expectedDataRecorderMetaData, paymentInstrument.DataRecorderMetaData);
        }

        [Test]
        public void CreatePaymentInstrumentSetsPropertiesToGivenEntityProperties()
        {
            const string expectedAccountNumber = "12345";
            const decimal expectedAmount = 5.33m;
            var expectedCheckDate = new DateTime(2001, 1, 1);
            var checkEntity = new CheckEntity
            {
                AccountNumber = expectedAccountNumber,
                Amount = expectedAmount,
                CheckDate = expectedCheckDate
            };

            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0, new DateTime(2001, 2, 1), null, null))
                .IgnoreArguments().Return(new DataRecorderMetaData());

            _mocks.ReplayAll();
            PaymentInstrument paymentInstrument = _paymentInstrumentFactory.CreatePaymentInstrument(checkEntity);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedAccountNumber, ((Check)paymentInstrument).AccountNumber);
            Assert.AreEqual(expectedAmount, paymentInstrument.Amount);
            Assert.AreEqual(expectedCheckDate, ((Check)paymentInstrument).CheckDate);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePaymentInstrumentsThrowsExceptionWhenNullCollectionGiven()
        {
            _mocks.ReplayAll();
            _paymentInstrumentFactory.CreatePaymentInstruments(null);
            _mocks.VerifyAll();
        }

        [Test]
        public void CreatePaymentInstrumentsReturnsEmptyListOfInstrumentsWhenEmptyCollectionGiven()
        {
            _mocks.ReplayAll();
            List<PaymentInstrument> paymentInstruments = _paymentInstrumentFactory.
                CreatePaymentInstruments(new EntityCollection<CheckEntity>());
            _mocks.VerifyAll();

            Assert.IsNotNull(paymentInstruments);
            Assert.IsEmpty(paymentInstruments);
        }

        [Test]
        public void CreatePaymentInstrumentsReturnsOneInstrumentWhenGivenCollectionHasOneItem()
        {
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0, new DateTime(2001, 2, 1), null, null))
                .IgnoreArguments().Return(new DataRecorderMetaData());

            _mocks.ReplayAll();
            List<PaymentInstrument> paymentInstruments = _paymentInstrumentFactory.
                CreatePaymentInstruments(new EntityCollection<CheckEntity> {new CheckEntity()});
            _mocks.VerifyAll();

            Assert.IsNotNull(paymentInstruments);
            Assert.IsTrue(paymentInstruments.HasSingleItem());
        }

        [Test]
        public void CreatePaymentInstrumentsReturns3InstrumentsWhenGivenCollectionHas3Items()
        {
            var checkEntities = new EntityCollection<CheckEntity> { new CheckEntity(), new CheckEntity(), new CheckEntity() };

            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0, new DateTime(2001, 2, 1), null, null))
                .IgnoreArguments().Return(new DataRecorderMetaData()).Repeat.Times(3);

            _mocks.ReplayAll();
            List<PaymentInstrument> paymentInstruments = _paymentInstrumentFactory.
                CreatePaymentInstruments(checkEntities);
            _mocks.VerifyAll();

            Assert.IsNotNull(paymentInstruments);
            Assert.IsTrue(paymentInstruments.Count == 3);
        }
    }
}