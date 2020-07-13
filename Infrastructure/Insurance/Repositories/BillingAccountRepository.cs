using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Insurance.Repositories
{
    [DefaultImplementation]
    public class BillingAccountRepository : PersistenceRepository, IBillingAccountRepository
    {
        public IEnumerable<BillingAccount> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ba in linqMetaData.BillingAccount where ba.IsActive select ba);

                return Mapper.Map<IEnumerable<BillingAccountEntity>, IEnumerable<BillingAccount>>(entities);
            }
        }

        public IEnumerable<BillingAccountTest> GetAllBillingAccountTests()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ba in linqMetaData.BillingAccount
                                join bat in linqMetaData.BillingAccountTest on ba.BillingAccountId equals bat.BillingAccountId
                                where ba.IsActive
                                select bat);

                return Mapper.Map<IEnumerable<BillingAccountTestEntity>, IEnumerable<BillingAccountTest>>(entities);
            }
        }

        public BillingAccountTest GetByTestId(long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ba in linqMetaData.BillingAccount
                    join bat in linqMetaData.BillingAccountTest on ba.BillingAccountId equals bat.BillingAccountId
                    where ba.IsActive && bat.TestId == testId
                    select bat).SingleOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<BillingAccountTestEntity, BillingAccountTest>(entity);
            }
        }

        public void SaveBillingAccountTest(long? billingAccountId,long testId)
        {
            DeleteBillingAccountTest(testId);
            if (billingAccountId.HasValue && billingAccountId.Value > 0)
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    adapter.SaveEntity(new BillingAccountTestEntity(billingAccountId.Value, testId));
                }
            }
        }

        private void DeleteBillingAccountTest(long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(BillingAccountTestFields.TestId == testId);

                adapter.DeleteEntitiesDirectly(typeof(BillingAccountTestEntity), relationPredicateBucket);
            }
        }
    }
}
