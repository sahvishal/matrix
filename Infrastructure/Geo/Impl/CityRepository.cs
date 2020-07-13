using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Geo.Impl
{
    public class CityRepository : UniqueItemRepository<City, CityEntity>, ICityRepository
    {

        public CityRepository()
            : base(new CityMapper())
        { }

        protected override EntityField2 EntityIdField
        {
            get { return CityFields.CityId; }
        }

        public City GetCityByStateAndName(long stateId, string cityName)
        {
            var entityCollection = new EntityCollection<CityEntity>();

            var bucket = new RelationPredicateBucket(CityFields.StateId == stateId);
            bucket.PredicateExpression.AddWithAnd(CityFields.Name == cityName);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(entityCollection, bucket);
            }

            if (entityCollection.Count < 1) return null;

            return Mapper.Map(entityCollection.SingleOrDefault());
        }

        public City GetCity(string cityName)
        {
            var entityCollection = new EntityCollection<CityEntity>();

            var bucket = new RelationPredicateBucket(CityFields.Name == cityName);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(entityCollection, bucket);
            }

            City domainObject = Mapper.Map(entityCollection.SingleOrDefault());

            return domainObject;
        }

        public City GetCityByZipCode(string zipCode)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var cityEntity = (from c in linqMetaData.City
                                  join z in linqMetaData.Zip on c.CityId equals z.CityId
                                  where z.ZipCode == zipCode
                                  orderby c.CityId
                                  select c).FirstOrDefault();
                return Mapper.Map(cityEntity);
            }
        }

        public IEnumerable<City> GetbyPrefixTest(string prefixTest)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return Mapper.MapMultiple(from c in linqMetaData.City where c.Name.Contains(prefixTest) select c);
            }
        }
    }
}
