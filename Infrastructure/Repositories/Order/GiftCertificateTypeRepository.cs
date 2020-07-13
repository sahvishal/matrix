using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Order
{
    public class GiftCertificateTypeRepository : UniqueItemRepository
        <GiftCertificateType, GiftCertificateTypeEntity>, IGiftCertificateTypeRepository
    {
        public GiftCertificateTypeRepository()
            : base(new GiftCertificateTypeMapper())
        {}

        protected override EntityField2 EntityIdField
        {
            get { return GiftCertificateTypeFields.GiftCertificateTypeId; }
        }

        public IEnumerable<GiftCertificateType> GetAllGiftCertificateTypes()
        {
            var entityCollection = new EntityCollection<GiftCertificateTypeEntity>();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(entityCollection, null);
            }
            return Mapper.MapMultiple(entityCollection);
        }
    }
}
