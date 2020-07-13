using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class SystemGeneratedCallQueueCriteriaRepository : PersistenceRepository, ISystemGeneratedCallQueueCriteriaRepository
    {
        public IEnumerable<SystemGeneratedCallQueueCriteria> GetQueueCriteriasByQueueId(long callQueueId)
        {
            var expresion = new RelationPredicateBucket(SystemGeneratedCallQueueCriteriaFields.CallQueueId == callQueueId);
            return Get(expresion);

        }
        public IEnumerable<SystemGeneratedCallQueueCriteria> GetSystemGeneratedCallQueueCriteriaNotGenerated(long callQueueId)
        {
            var expresion = new RelationPredicateBucket(SystemGeneratedCallQueueCriteriaFields.CallQueueId == callQueueId);
            expresion.PredicateExpression.AddWithAnd(SystemGeneratedCallQueueCriteriaFields.IsQueueGenerated == false);

            return Get(expresion);
        }
        private IEnumerable<SystemGeneratedCallQueueCriteria> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<SystemGeneratedCallQueueCriteriaEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var systemGeneratedCallQueueCriteriaTags = Mapper.Map<IEnumerable<SystemGeneratedCallQueueCriteriaEntity>, IEnumerable<SystemGeneratedCallQueueCriteria>>(entities);

                return systemGeneratedCallQueueCriteriaTags.ToArray();
            }
        }

        public SystemGeneratedCallQueueCriteria GetById(long criteriaId)
        {
            try
            {
                var expresion = new RelationPredicateBucket(SystemGeneratedCallQueueCriteriaFields.Id == criteriaId); 

                return Get(expresion).Single(); 
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<SystemGeneratedCallQueueCriteria>(criteriaId);
            }
        }

        public SystemGeneratedCallQueueCriteria GetQueueCriteria(long callQueueId, long? organisationUserRoleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from c in linqMetaData.SystemGeneratedCallQueueCriteria where c.CallQueueId == callQueueId && (c.AssignedToOrgRoleUserId == organisationUserRoleId || c.IsDefault) select c).OrderByDescending(x => x.AssignedToOrgRoleUserId).FirstOrDefault();

                return Mapper.Map<SystemGeneratedCallQueueCriteriaEntity, SystemGeneratedCallQueueCriteria>(enetities);
            }
        }

        public SystemGeneratedCallQueueCriteria Save(SystemGeneratedCallQueueCriteria systemGeneratedCallQueueCriteria)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<SystemGeneratedCallQueueCriteria, SystemGeneratedCallQueueCriteriaEntity>(systemGeneratedCallQueueCriteria);
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<SystemGeneratedCallQueueCriteriaEntity, SystemGeneratedCallQueueCriteria>(entity);
            }
        }
    }
}
