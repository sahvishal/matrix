using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Impl;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using FluentValidation;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    public class VanRepository : PersistenceRepository, IVanRepository
    {
        private readonly IValidator<Van> _validator;
        private readonly IMapper<Van, VanDetailsEntity> _mapper;

        public VanRepository()
            : this(new SqlPersistenceLayer(), new VanValidator() , new VanMapper())
        { }

        public VanRepository(IPersistenceLayer persistenceLayer,  IValidator<Van> validator, IMapper<Van, VanDetailsEntity> mapper)
            : base(persistenceLayer)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public Van GetVan(long vanId)
        {
            var vanDetailsEntity = new VanDetailsEntity(vanId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.FetchEntity(vanDetailsEntity))
                {
                    throw new ObjectNotFoundInPersistenceException<Van>(vanId);
                }
            }
            return _mapper.Map(vanDetailsEntity);
        }

        public List<Van> GetVans(string vanName)
        {
            var vanDetailEntities = new EntityCollection<VanDetailsEntity>();

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(VanDetailsFields.Name % ("%" + vanName + "%"));
                myAdapter.FetchEntityCollection(vanDetailEntities, bucket);
            }
            return _mapper.MapMultiple(vanDetailEntities).ToList();
        }

        public List<Van> GetAllVans()
        {
            var vanDetailEntities = new EntityCollection<VanDetailsEntity>();

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(vanDetailEntities, null);
            }
            return _mapper.MapMultiple(vanDetailEntities).ToList();
        }

        public Van SaveVan(Van van)
        {
            if (van == null)
            {
                throw new ArgumentNullException("van", "The given van cannot be null.");
            }

            _validator.ValidateAndThrow(van);
            
            VanDetailsEntity vanDetailsEntity = _mapper.Map(van);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(vanDetailsEntity, true))
                {
                    throw new PersistenceFailureException();
                }
            }
            return _mapper.Map(vanDetailsEntity);
        }

        public void UpdateVan(Van van)
        {
            if (van == null)
            {
                throw new ArgumentNullException("van", "The given van cannot be null.");
            }

            _validator.ValidateAndThrow(van);

            VanDetailsEntity vanDetailsEntity = _mapper.Map(van);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(VanDetailsFields.VanId == van.Id);
                if (myAdapter.UpdateEntitiesDirectly(vanDetailsEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public void DeleteVan(long vanId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(VanDetailsFields.VanId == vanId);
                if (myAdapter.DeleteEntitiesDirectly(typeof(VanDetailsEntity), bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public bool IsVanNameUnique(string vanName, long excludedId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);   
                if (excludedId == 0)
                {
                    return !linqMetaData.VanDetails.Any(v => v.Name == vanName);
                }
                return    !linqMetaData.VanDetails.Any(v => v.Name == vanName && v.VanId != excludedId);
            }
            
        }
    }    
}
