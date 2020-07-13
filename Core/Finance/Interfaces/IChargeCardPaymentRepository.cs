using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IChargeCardPaymentRepository : IPaymentInstrumentRepository, IUniqueItemRepository<ChargeCardPayment>
    {
        IEnumerable<ChargeCardPayment> Get(CreditCardReconcileModelFilter filter, int pageNumber, int pageSize,
                                           out int totalRecords);
    }
}