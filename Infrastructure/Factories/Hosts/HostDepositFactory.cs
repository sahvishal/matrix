using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Hosts
{
    public class HostDepositFactory : IHostDepositFactory
    {

        public HostPaymentEntity CreateHostPayment(HostDeposit hostDeposit)
        {
            var hostPaymentFactory = new HostPaymentFactory();
            var entityToMapTo = hostPaymentFactory.CreateHostPaymentEntity(hostDeposit);
            entityToMapTo.IsDeposit = true;
            entityToMapTo.DepositType = (long)hostDeposit.DepositApplicablityMode;
            entityToMapTo.DepositFullRefundDays = hostDeposit.DepositFullRefundDueDays;
            entityToMapTo.IsNew = hostDeposit.Id == 0;
            return entityToMapTo;
        }

        public HostDeposit CreateHostDeposit(HostPaymentEntity hostPaymentEntity, Address address)
        {
            var hostPaymentFactory = new HostPaymentFactory();
            var domainObjectToMapTo = new HostDeposit();
            hostPaymentFactory.CreateHostDeposit(hostPaymentEntity, domainObjectToMapTo, address);
            domainObjectToMapTo.DepositApplicablityMode = (DepositType)hostPaymentEntity.DepositType;
            domainObjectToMapTo.DepositFullRefundDueDays = hostPaymentEntity.DepositFullRefundDays;
            return domainObjectToMapTo;
        }


    }
}