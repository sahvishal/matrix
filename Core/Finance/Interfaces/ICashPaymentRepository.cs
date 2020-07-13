using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface ICashPaymentRepository : IPaymentInstrumentRepository, IUniqueItemRepository<CashPayment>
    {}
}