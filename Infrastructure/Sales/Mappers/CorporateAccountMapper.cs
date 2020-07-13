using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Sales.Mappers
{
    public class CorporateAccountMapper : DomainEntityMapper<CorporateAccount, AccountEntity>
    {
        protected override void MapDomainFields(AccountEntity entity, CorporateAccount domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.AccountId;
            domainObjectToMapTo.ContractNotes = entity.ContractNotes;
            
        }

        protected override void MapEntityFields(CorporateAccount domainObject, AccountEntity entityToMapTo)
        {
            entityToMapTo.AccountId = domainObject.Id;
            entityToMapTo.ContractNotes = domainObject.ContractNotes;
        }
    }
}