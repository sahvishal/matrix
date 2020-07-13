using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Hosts
{
    public class HostPaymentTransactionMapper : DomainEntityMapper<HostPaymentTransaction, HostPaymentTransactionEntity>
    {
        protected override void MapDomainFields(HostPaymentTransactionEntity hostPaymentTransactionEntity, HostPaymentTransaction domainObjectToMapTo)
        {
            domainObjectToMapTo.HostPaymentId = hostPaymentTransactionEntity.HostPaymentId;
            domainObjectToMapTo.TransactionType = (HostPaymentStatus)hostPaymentTransactionEntity.TransactionType;
            domainObjectToMapTo.TransactionMethod = (HostPaymentType)hostPaymentTransactionEntity.PaymentMethod;
            domainObjectToMapTo.Amount = hostPaymentTransactionEntity.Amount;
            domainObjectToMapTo.Notes = hostPaymentTransactionEntity.Notes;
            domainObjectToMapTo.TransactionDate = hostPaymentTransactionEntity.TransactionDate;
            domainObjectToMapTo.TransactionRecordedBy =
               hostPaymentTransactionEntity.CreatedByOrgRoleUserId > 0 ? new OrganizationRoleUser(hostPaymentTransactionEntity.CreatedByOrgRoleUserId) : null;
        }

        protected override void MapEntityFields(HostPaymentTransaction domainObject, HostPaymentTransactionEntity entityToMapTo)
        {
            entityToMapTo.HostPaymentId = domainObject.HostPaymentId;
            entityToMapTo.TransactionType = (long)domainObject.TransactionType;
            entityToMapTo.PaymentMethod = (long)domainObject.TransactionMethod;
            entityToMapTo.Amount = domainObject.Amount;
            entityToMapTo.Notes = domainObject.Notes;
            entityToMapTo.TransactionDate = domainObject.TransactionDate;
            entityToMapTo.CreatedByOrgRoleUserId = domainObject.TransactionRecordedBy != null ? domainObject.TransactionRecordedBy.Id : 0;
        }
    }
}
