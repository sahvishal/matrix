using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventCustomerPreApprovedPackageTestRepository : PersistenceRepository, IEventCustomerPreApprovedPackageTestRepository
    {
        public void DeletePreApprovedPackageTests(long eventcustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(EventCustomerPreApprovedPackageTestFields.EventCustomerId == eventcustomerId);

                adapter.DeleteEntitiesDirectly(typeof(EventCustomerPreApprovedPackageTestEntity), relationPredicateBucket);
            }
        }

        public void Save(long eventcustomerId, long pacakgeId, IEnumerable<long> testIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                DeletePreApprovedPackageTests(eventcustomerId);

                var entities = new EntityCollection<EventCustomerPreApprovedPackageTestEntity>();

                foreach (var testId in testIds)
                {
                    entities.Add(new EventCustomerPreApprovedPackageTestEntity(eventcustomerId, testId, pacakgeId)
                    {
                        IsNew = true
                    });
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public long GetPreApprovedTestByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecpat in linqMetaData.EventCustomerPreApprovedPackageTest
                        where ecpat.EventCustomerId == eventCustomerId
                        select ecpat.PackageId).SingleOrDefault();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetCustomerIdPreApprovedPackageTests(IEnumerable<long> eventcustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecpapt in linqMetaData.EventCustomerPreApprovedPackageTest
                        join t in linqMetaData.Test on ecpapt.TestId equals t.TestId
                        join ec in linqMetaData.EventCustomers on ecpapt.EventCustomerId equals ec.EventCustomerId
                        where eventcustomerId.Contains(ecpapt.EventCustomerId)
                        select new OrderedPair<long, string>(ec.CustomerId, t.Name)).ToArray();
            }
        }
    }
}