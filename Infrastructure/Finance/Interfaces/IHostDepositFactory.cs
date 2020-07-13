using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IHostDepositFactory
    {
        HostPaymentEntity CreateHostPayment(HostDeposit hostDeposit);
        HostDeposit CreateHostDeposit(HostPaymentEntity hostPaymentEntity, Address address);
    }
}