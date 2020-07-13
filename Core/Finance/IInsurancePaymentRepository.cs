using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IInsurancePaymentRepository : Interfaces.IPaymentInstrumentRepository, IUniqueItemRepository<InsurancePayment>
    {
        void Delete(long insurancePaymentId);
    }
}
