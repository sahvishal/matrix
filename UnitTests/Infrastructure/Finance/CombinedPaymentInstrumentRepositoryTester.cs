using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories.Payment;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore]
    public class CombinedPaymentInstrumentRepositoryTester
    {
        private MockRepository _mocks;
        private ICombinedPaymentInstrumentRepository _repository;
        private IPaymentInstrumentRepository _creditCardRepository;
        private IPaymentInstrumentRepository _checkRepository;
        private IKeyValueDictionaryFactory<PaymentType, IPaymentInstrumentRepository> _keyValueDictionaryFactory;
        private Dictionary<PaymentType, IPaymentInstrumentRepository> _repositoryDictionary;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _creditCardRepository = _mocks.StrictMock<IPaymentInstrumentRepository>();
            _checkRepository = _mocks.StrictMock<IPaymentInstrumentRepository>();
            _keyValueDictionaryFactory = _mocks.StrictMock<IKeyValueDictionaryFactory<PaymentType, IPaymentInstrumentRepository>>();
            _repository = new CombinedPaymentInstrumentRepository(
                new List<IPaymentInstrumentRepository> { _creditCardRepository, _checkRepository },
                _keyValueDictionaryFactory);

            _repositoryDictionary = new Dictionary<PaymentType, IPaymentInstrumentRepository> {
                {PaymentType.CreditCard, _creditCardRepository},
                {PaymentType.Check, _checkRepository}
            };
        }

        [Test]
        public void SavingChargeCardPaymentCallsSaveMethodOfChargeCardRepository()
        {
            var chargeCardPayment = new ChargeCardPayment();

            Expect.Call(_keyValueDictionaryFactory.GetDictionary(null, null)).IgnoreArguments().Return(_repositoryDictionary);
            Expect.Call(() => _creditCardRepository.SavePaymentInstrument(chargeCardPayment)).Return(null);

            _mocks.ReplayAll();
            _repository.SavePaymentInstrument(chargeCardPayment);
            _mocks.VerifyAll();
        }

        [Test]
        public void SavingCheckPaymentCallsSaveMethodOfCheckPaymentRepository()
        {
            var checkPayment = new CheckPayment();

            Expect.Call(_keyValueDictionaryFactory.GetDictionary(null, null)).IgnoreArguments().Return(_repositoryDictionary);
            Expect.Call(() => _checkRepository.SavePaymentInstrument(checkPayment)).Return(null);

            _mocks.ReplayAll();
            _repository.SavePaymentInstrument(checkPayment);
            _mocks.VerifyAll();
        }
    }
}