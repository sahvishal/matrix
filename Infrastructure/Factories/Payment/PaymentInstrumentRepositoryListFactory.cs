using System.Collections.Generic;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Finance.Repositories;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Factories.Payment
{
    [DefaultImplementation]
    public class PaymentInstrumentRepositoryListFactory : IPaymentInstrumentRepositoryListFactory
    {
        public IEnumerable<IPaymentInstrumentRepository> GetPaymentInstrumentRepositories()
        {
            return new List<IPaymentInstrumentRepository>
            {
                new ChargeCardPaymentRepository(),
                new CheckPaymentRepository(),
                new ECheckPaymentRepository(),
                new CashPaymentRepository(),
                new GiftCertificatePaymentRepository(),
                new InsurancePaymentRepository()
            };
        }
    }
}