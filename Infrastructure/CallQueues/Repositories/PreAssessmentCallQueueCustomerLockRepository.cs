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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class PreAssessmentCallQueueCustomerLockRepository : PersistenceRepository,IPreAssessmentCallQueueCustomerLockRepository
    {

        public PreAssessmentCallQueueCustomerLock SavePreAssessmentCallQueueCustomerLock(PreAssessmentCallQueueCustomerLock preAssessmentCallQueueCustomerLock)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PreAssessmentCallQueueCustomerLock, PreAssessmentCallQueueCustomerLockEntity>(preAssessmentCallQueueCustomerLock);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<PreAssessmentCallQueueCustomerLockEntity, PreAssessmentCallQueueCustomerLock>(entity);
            }
            
        }
        public void UpdatePreAssessmentCallQueueCustomerLock(PreAssessmentCallQueueCustomerLock preAssessmentCallQueueCustomerLock)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var preAssessmentCallQueueCustomerLockEntity = new PreAssessmentCallQueueCustomerLockEntity() { CreatedOn = DateTime.Now };
                var bucket = new RelationPredicateBucket(PreAssessmentCallQueueCustomerLockFields.CustomerId == preAssessmentCallQueueCustomerLock.CustomerId);

                if (adapter.UpdateEntitiesDirectly(preAssessmentCallQueueCustomerLockEntity, bucket) == 0)
                {
                    SavePreAssessmentCallQueueCustomerLock(preAssessmentCallQueueCustomerLock);
                }
            }
        }

        public void RelasePreAssessmentCallQueueCustomerLock(long CustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var model = GetCallQueueCustomerLock(CustomerId);

                if (model != null)
                {
                    var entity = Mapper.Map<PreAssessmentCallQueueCustomerLock, PreAssessmentCallQueueCustomerLockEntity>(model);
                    adapter.DeleteEntity(entity);
                }
            }
        }

        private PreAssessmentCallQueueCustomerLock GetCallQueueCustomerLock(long CustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);


                var preAssessmentCallQueueCustomerLock = (from cqucl in linqMetaData.PreAssessmentCallQueueCustomerLock
                                     where
                                     (cqucl.CustomerId == CustomerId)
                                     select cqucl).FirstOrDefault();
                if (preAssessmentCallQueueCustomerLock == null)
                    return null;

                return Mapper.Map<PreAssessmentCallQueueCustomerLockEntity, PreAssessmentCallQueueCustomerLock>(preAssessmentCallQueueCustomerLock);
            }
        }
        public void ReleaseIdPreAssessmentCallQueueCustomerLock(int interval)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerLocks = new EntityCollection<PreAssessmentCallQueueCustomerLockEntity>();
                var bucket = new RelationPredicateBucket(PreAssessmentCallQueueCustomerLockFields.CreatedOn <= DateTime.Now.AddHours(-1 * interval));
                adapter.FetchEntityCollection(customerLocks, bucket);

                foreach (var callQueueCustomer in customerLocks)
                {
                    var relationPredicateBucket = new RelationPredicateBucket(PreAssessmentCallQueueCustomerLockFields.CustomerId == callQueueCustomer.CustomerId);

                    adapter.DeleteEntitiesDirectly(typeof(PreAssessmentCallQueueCustomerLockEntity), relationPredicateBucket);
                }
            }
        }
    }
}
