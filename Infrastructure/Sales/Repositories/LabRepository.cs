using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class LabRepository : PersistenceRepository, ILabRepository
    {
        public IEnumerable<Lab> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from l in linqMetaData.Lab
                                where l.IsActive
                                select l).ToArray();
                if (entities.IsNullOrEmpty())
                    return null;

                return Mapper.Map<IEnumerable<LabEntity>, IEnumerable<Lab>>(entities);
            }
        }

        public Lab GetByName(string name)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from l in linqMetaData.Lab
                              where l.IsActive
                              && l.Name.Trim().ToLower() == name
                              select l).SingleOrDefault();
                if (entity == null)
                    return null;

                return Mapper.Map<LabEntity, Lab>(entity);
            }
        }

        public Lab Save(Lab domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<Lab, LabEntity>(domain);

                adapter.SaveEntity(entity, true);

                return Mapper.Map<LabEntity, Lab>(entity);
            }
        }

        public Lab GetById(long id)
        {
            try
            {
                var relationPredicateBucket = new RelationPredicateBucket(LabFields.Id == id);

                return Get(relationPredicateBucket).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<Lab>(id);
            }

        }

        private IEnumerable<Lab> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<LabEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var callQueues = Mapper.Map<IEnumerable<LabEntity>, IEnumerable<Lab>>(entities);

                return callQueues.OrderBy(t => t.Name).ToArray();
            }
        }

    }
}
