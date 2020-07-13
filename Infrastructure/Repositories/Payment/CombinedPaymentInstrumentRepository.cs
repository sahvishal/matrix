using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Factories.Payment;
using Falcon.Data.Linq;
using IPaymentInstrumentRepository = Falcon.App.Core.Finance.Interfaces.IPaymentInstrumentRepository;

namespace Falcon.App.Infrastructure.Repositories.Payment
{
    [DefaultImplementation]
    public class CombinedPaymentInstrumentRepository : PersistenceRepository, ICombinedPaymentInstrumentRepository
    {
        private readonly IEnumerable<IPaymentInstrumentRepository> _paymentInstrumentRepositories;
        private readonly IKeyValueDictionaryFactory<PaymentType, IPaymentInstrumentRepository> _dictionaryFactory;

        private Dictionary<PaymentType, IPaymentInstrumentRepository> _repositoryDictionary;
        private Dictionary<PaymentType, IPaymentInstrumentRepository> RepositoryDictionary
        {
            get
            {
                if (_repositoryDictionary == null)
                {
                    _repositoryDictionary = _dictionaryFactory.GetDictionary(_paymentInstrumentRepositories, pir => pir.PaymentType);
                }
                return _repositoryDictionary;
            }
        }

        public CombinedPaymentInstrumentRepository()
            : this(new PaymentInstrumentRepositoryListFactory(), new KeyValueDictionaryFactory<PaymentType, IPaymentInstrumentRepository>())
        { }

        public CombinedPaymentInstrumentRepository(IPaymentInstrumentRepositoryListFactory paymentInstrumentRepositoryListFactory)
            : this(paymentInstrumentRepositoryListFactory, new KeyValueDictionaryFactory<PaymentType, IPaymentInstrumentRepository>())
        { }

        public CombinedPaymentInstrumentRepository(IPaymentInstrumentRepositoryListFactory paymentInstrumentRepositoryListFactory,
            IKeyValueDictionaryFactory<PaymentType, IPaymentInstrumentRepository> dictionaryFactory)
            : this(paymentInstrumentRepositoryListFactory.GetPaymentInstrumentRepositories(), dictionaryFactory)
        { }

        public CombinedPaymentInstrumentRepository(IEnumerable<IPaymentInstrumentRepository> paymentInstrumentRepositories,
            IKeyValueDictionaryFactory<PaymentType, IPaymentInstrumentRepository> dictionaryFactory)
        {
            _paymentInstrumentRepositories = paymentInstrumentRepositories;
            _dictionaryFactory = dictionaryFactory;
        }

        public IEnumerable<PaymentInstrument> GetByPaymentId(long paymentId)
        {
            return _paymentInstrumentRepositories.SelectMany(repo => repo.GetByPaymentId(paymentId));
        }

        public IEnumerable<PaymentInstrument> GetByPaymentId(List<long> paymentIds)
        {
            return paymentIds.SelectMany(pid => GetByPaymentId(pid));
        }

        public IEnumerable<PaymentInstrument> GetByOrderId(long orderId)
        {
            // TODO: Does this need to take into account how much of a payment is applied to a given order?
            IEnumerable<long> paymentIds;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                paymentIds = linqMetaData.PaymentOrder.Where(po => po.OrderId == orderId).
                    Select(po => po.PaymentId).ToList();
            }
            return paymentIds.SelectMany(pid => GetByPaymentId(pid));
        }

        public void SavePaymentInstrument(PaymentInstrument paymentInstrument)
        {
            var newPaymentInstrument = RepositoryDictionary[paymentInstrument.PaymentType].SavePaymentInstrument(paymentInstrument);
            paymentInstrument.Id = newPaymentInstrument.Id;
        }

        public void SavePaymentInstruments(IEnumerable<PaymentInstrument> paymentInstruments)
        {
            foreach (var paymentInstrument in paymentInstruments)
            {
                SavePaymentInstrument(paymentInstrument);
            }
        }
    }
}