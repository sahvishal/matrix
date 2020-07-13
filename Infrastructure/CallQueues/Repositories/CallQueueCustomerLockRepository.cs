using System;
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
    public class CallQueueCustomerLockRepository : PersistenceRepository, ICallQueueCustomerLockRepository
    {
        public CallQueueCustomerLock GetCallQueueCustomerLock(CallQueueCustomer callqueueCustomer)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueueLock = (from cqucl in linqMetaData.CallQueueCustomerLock
                                     where
                                     (cqucl.CustomerId == callqueueCustomer.CustomerId && cqucl.ProspectCustomerId == callqueueCustomer.ProspectCustomerId)
                                     select cqucl).FirstOrDefault();
                if (callQueueLock == null)
                    return null;

                return Mapper.Map<CallQueueCustomerLockEntity, CallQueueCustomerLock>(callQueueLock);
            }
        }

        public CallQueueCustomerLock SaveCallQueueCustomerLock(CallQueueCustomerLock callQueueCustomerLock)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CallQueueCustomerLock, CallQueueCustomerLockEntity>(callQueueCustomerLock);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<CallQueueCustomerLockEntity, CallQueueCustomerLock>(entity);
            }
        }

        public void RelaseCallQueueCustomerLock(long callQueueCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var model = GetCallQueueCustomerLock(callQueueCustomerId);

                if (model != null)
                {
                    var entity = Mapper.Map<CallQueueCustomerLock, CallQueueCustomerLockEntity>(model);
                    adapter.DeleteEntity(entity);
                }
            }
        }

        public void ReleaseIdleCallQuequeCustomerLock(int interval)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerLocks = new EntityCollection<CallQueueCustomerLockEntity>();
                var bucket = new RelationPredicateBucket(CallQueueCustomerLockFields.CreatedOn <= DateTime.Now.AddHours(-1 * interval));
                adapter.FetchEntityCollection(customerLocks, bucket);

                foreach (var callQueueCustomer in customerLocks)
                {
                    var relationPredicateBucket = new RelationPredicateBucket(CallQueueCustomerLockFields.CallQueueCustomerId == callQueueCustomer.CallQueueCustomerId);

                    adapter.DeleteEntitiesDirectly(typeof(CallQueueCustomerLockEntity), relationPredicateBucket);
                }
            }
        }

        public bool CheckCustomerLockByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueueLock = (from cqucl in linqMetaData.CallQueueCustomerLock
                                     where (cqucl.CustomerId.HasValue && cqucl.CustomerId.Value == customerId)
                                     select cqucl).FirstOrDefault();

                return callQueueLock != null;
            }
        }

        private CallQueueCustomerLock GetCallQueueCustomerLock(long callQueueCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callqueueCustomer = (from cquc in linqMetaData.CallQueueCustomer
                                         where cquc.CallQueueCustomerId == callQueueCustomerId
                                         select cquc).First();

                var callQueueLock = (from cqucl in linqMetaData.CallQueueCustomerLock
                                     where
                                     (cqucl.CustomerId == callqueueCustomer.CustomerId && cqucl.ProspectCustomerId == callqueueCustomer.ProspectCustomerId)
                                     select cqucl).FirstOrDefault();
                if (callQueueLock == null)
                    return null;

                return Mapper.Map<CallQueueCustomerLockEntity, CallQueueCustomerLock>(callQueueLock);
            }
        }

        public void UpdateCallQueueCustomerLock(CallQueueCustomerLock callQueueCustomerLock)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callQueueCustomerLockEntity = new CallQueueCustomerLockEntity() { CreatedOn = DateTime.Now };
                var bucket = new RelationPredicateBucket(CallQueueCustomerLockFields.CallQueueCustomerId == callQueueCustomerLock.CallQueueCustomerId);

                if (adapter.UpdateEntitiesDirectly(callQueueCustomerLockEntity, bucket) == 0)
                {
                    SaveCallQueueCustomerLock(callQueueCustomerLock);
                }
            }
        }

    }
}