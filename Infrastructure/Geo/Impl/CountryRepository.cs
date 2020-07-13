using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Geo.Impl
{
    public class CountryRepository : UniqueItemRepository<Country, CountryEntity>, ICountryRepository
    {
        public CountryRepository()
            : base(new CountryMapper())
        { }

        protected override EntityField2 EntityIdField
        {
            get { return CountryFields.CountryId; }
        }

        public List<Country> GetAll()
        {
            var countryEntities = new EntityCollection<CountryEntity>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(countryEntities, new RelationPredicateBucket());
                if (countryEntities.IsEmpty())
                    throw new EmptyCollectionException();
                return Mapper.MapMultiple(countryEntities).ToList();
            }
        }

        public string GetCountryCode(long countryId)
        {
            var countryEntity = new CountryEntity(countryId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntity(countryEntity);
                return countryEntity.CountryCode;
            }
        }

        public long GetCountryId(string countryName)
        {
            var countryEntities = new EntityCollection<CountryEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(CountryFields.Name == countryName);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(countryEntities, bucket);
                if (countryEntities.IsEmpty())
                    throw new EmptyCollectionException();
                if (countryEntities.Count > 1)
                    throw new DuplicateObjectException<Country>();
                return countryEntities.Single().CountryId;
            }
        }

        public Country GetCountryByStateId(long stateId)
        {
            var countryEntity = new CountryEntity();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var stateEntity = new StateEntity(stateId);
                if (!adapter.FetchEntity(stateEntity))
                {
                    throw new ObjectNotFoundInPersistenceException<State>(stateId);
                }
                else
                {
                    if (stateEntity.CountryId != null)
                    {
                        countryEntity.CountryId = stateEntity.CountryId.Value;
                        adapter.FetchEntity(countryEntity);
                    }
                    else
                    {
                        throw new ObjectIncompleteInPersistenceException<State>(stateId, "CountryId is null in persistence");
                    }
                }
            }
            return Mapper.Map(countryEntity);
        }
    }
}