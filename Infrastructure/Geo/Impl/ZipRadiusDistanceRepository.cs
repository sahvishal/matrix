using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Geo.Impl
{
    [DefaultImplementation]
    public class ZipRadiusDistanceRepository : PersistenceRepository, IZipRadiusDistanceRepository
    {

        private IEnumerable<ZipRadiusDistance> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<ZipRadiusDistanceEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var zipRadiusDistances = Mapper.Map<IEnumerable<ZipRadiusDistanceEntity>, IEnumerable<ZipRadiusDistance>>(entities);

                return zipRadiusDistances.ToArray();
            }
        }

        public IEnumerable<ZipRadiusDistance> GetBySourceZipIdAndRadius(long sourceZipId, int radius)
        {
            var expresion = new RelationPredicateBucket(ZipRadiusDistanceFields.SourceZipId == sourceZipId);
            expresion.PredicateExpression.AddWithAnd(ZipRadiusDistanceFields.Radius <= radius);

            return Get(expresion);
        }

        public IEnumerable<ZipRadiusDistance> GetDistacanceBetweenTwoZip(long sourceZipId, int distinationZipId)
        {
            var expresion = new RelationPredicateBucket(ZipRadiusDistanceFields.SourceZipId == sourceZipId);
            expresion.PredicateExpression.AddWithAnd(ZipRadiusDistanceFields.DestinationZipId == sourceZipId);

            return Get(expresion);

        }

        public bool Save(ZipRadiusDistance zipRadiusDistance)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ZipRadiusDistance, ZipRadiusDistanceEntity>(zipRadiusDistance);

                if (!adapter.SaveEntity(entity, false))
                {
                    throw new PersistenceFailureException();
                }

                return true;
            }
        }

        public IEnumerable<ZipRadiusDistance> GetBySourceZipId(long sourceZipId)
        {
            var expresion = new RelationPredicateBucket(ZipRadiusDistanceFields.SourceZipId == sourceZipId);
            
            return Get(expresion);
        }
    }
}
