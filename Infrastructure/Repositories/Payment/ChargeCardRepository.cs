using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers.Payments;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Payment
{
    [DefaultImplementation(Interface = typeof(IChargeCardRepository))]
    public class ChargeCardRepository : UniqueItemRepository<ChargeCard, ChargeCardEntity>, IChargeCardRepository
    {
        public ChargeCardRepository()
            : this(new ChargeCardMapper())
        {}

        public ChargeCardRepository(IMapper<ChargeCard, ChargeCardEntity> mapper) 
            : base(mapper)
        {}

        public ChargeCardRepository(IPersistenceLayer persistenceLayer, 
            IMapper<ChargeCard, ChargeCardEntity> mapper, 
            RepositoryStrategySet<ChargeCard> strategySet) 
            : base(persistenceLayer, mapper, strategySet)
        {}

        protected override EntityField2 EntityIdField
        {
            get { return ChargeCardFields.ChargeCardId; }
        }

        public List<OrderedPair<long, string>> GetAllChargeCardType()
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.CreditCardType.Where(cc => cc.IsActive)
                    .Select(cc => new OrderedPair<long, string>(cc.CreditCardTypeId, cc.Name)).ToList();
                

            }
        }
    }
}