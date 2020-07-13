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
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class HealthPlanEventZipRepository : PersistenceRepository, IHealthPlanEventZipRepository
    {

        public void Save(HealthPlanEventZip healthPlanEventZip)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (healthPlanEventZip != null && healthPlanEventZip.AccountID > 0)
                {
                    Delete(healthPlanEventZip.AccountID);

                    var entity = Mapper.Map<HealthPlanEventZip, HealthPlanEventZipEntity>(healthPlanEventZip);
                    
                    if (!adapter.SaveEntity(entity, true))
                    {
                        throw new PersistenceFailureException();
                    }
                }
            }
        }

        public IEnumerable<HealthPlanEventZip> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from hpez in linqMetaData.HealthPlanEventZip
                                select hpez).ToArray();
                if (entities == null)
                    return null;

                return Mapper.Map<IEnumerable<HealthPlanEventZipEntity>, IEnumerable<HealthPlanEventZip>>(entities);
            }
        }

        public HealthPlanEventZip GetByAccountID(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from hpez in linqMetaData.HealthPlanEventZip
                              where hpez.AccountId == accountId
                              select hpez).SingleOrDefault();
                if (entity == null)
                    return null;

                return Mapper.Map<HealthPlanEventZipEntity, HealthPlanEventZip>(entity);
            }
        }

        public HealthPlanEventZip GetByTag(string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from hpez in linqMetaData.HealthPlanEventZip
                              where hpez.AccountTag == tag
                              select hpez).SingleOrDefault();
                if (entity == null)
                    return null;

                return Mapper.Map<HealthPlanEventZipEntity, HealthPlanEventZip>(entity);
            }
        }

        private void Delete(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(HealthPlanEventZipFields.AccountId == accountId);
                adapter.DeleteEntitiesDirectly(typeof(HealthPlanEventZipEntity), relationPredicateBucket);
            }
        }

        public IEnumerable<HealthPlanEventZip> GetByIsQueueGenerated(bool isQueueGenerated)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from hpez in linqMetaData.HealthPlanEventZip
                                where hpez.IsQueueGenerated == isQueueGenerated
                                select hpez).ToArray();
                if (entities == null)
                    return null;

                return Mapper.Map<IEnumerable<HealthPlanEventZipEntity>, IEnumerable<HealthPlanEventZip>>(entities);
            }
        }
    }
}
