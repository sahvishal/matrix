using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class MarketingMaterialRepository : PersistenceRepository, IMarketingMaterialRepository
    {
        private readonly IMapper<MarketingMaterial, AfmarketingMaterialEntity> _mapper;

        public MarketingMaterialRepository()
            : this(new MarketingMaterialMapper())
        { }

        public MarketingMaterialRepository(IMapper<MarketingMaterial, AfmarketingMaterialEntity> mapper)
        {
            _mapper = mapper;
        }

        public MarketingMaterial GetMarketingMaterialById(long id)
        {
            var entity = new AfmarketingMaterialEntity(id);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.FetchEntity(entity))
                {
                    throw new ObjectNotFoundInPersistenceException<MarketingMaterial>(id);
                }
            }

            return _mapper.Map(entity);
        }

        public List<MarketingMaterial> GetMarketingMaterialsByIds(List<long> ids)
        {
            var entities = new EntityCollection<AfmarketingMaterialEntity>();

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket();
                bucket.PredicateExpression.Add(AfmarketingMaterialFields.MarketingMaterialId == ids);
                adapter.FetchEntityCollection(entities, bucket);
            }

            return _mapper.MapMultiple(entities).ToList();
        }

        public MarketingMaterial SaveMarketingMaterial(MarketingMaterial mm)
        {
            throw new NotImplementedException();
        }

        public void DeleteMarketingMaterial(MarketingMaterial mm)
        {
            throw new NotImplementedException();
        }
    }
}