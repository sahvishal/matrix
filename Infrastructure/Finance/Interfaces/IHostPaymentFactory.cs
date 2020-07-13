using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IHostPaymentFactory
    {
        HostPaymentEntity CreateHostPaymentEntity(HostPayment hostPayment);
        HostPayment CreateHostPayment(HostPaymentEntity hostPaymentEntity, Address address);
        void CreateHostDeposit(HostPaymentEntity hostPaymentEntity, HostPayment hostPayment, Address address);
    }
}