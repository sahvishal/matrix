using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    [DefaultImplementation]
    public class PayPeriodCriteriaRepository : PersistenceRepository, IPayPeriodCriteriaRepository
    {
        public IEnumerable<PayPeriodCriteria> GetByPayPeriodId(long payperiodId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from pp in linqMetaData.PayPeriodCriteria
                                where pp.PayPeriodId == payperiodId
                                orderby payperiodId
                                select pp).ToArray();

                return Mapper.Map<IEnumerable<PayPeriodCriteriaEntity>, IEnumerable<PayPeriodCriteria>>(entities);
            }
        }

        public bool DeleteCriteria(long payPeriodId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("PayPeriodCriteriaEntity", new RelationPredicateBucket(PayPeriodCriteriaFields.PayPeriodId == payPeriodId));
            }

            return true;
        }

        public PayPeriodCriteria Save(PayPeriodCriteria domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PayPeriodCriteria, PayPeriodCriteriaEntity>(domain);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Pay Period");

                return Mapper.Map<PayPeriodCriteriaEntity, PayPeriodCriteria>(entity);
            }
        }

        public void Save(IEnumerable<PayPeriodCriteria> domains, long payPeriodId)
        {
            DeleteCriteria(payPeriodId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                foreach (var domain in domains)
                {
                    var entity = Mapper.Map<PayPeriodCriteria, PayPeriodCriteriaEntity>(domain);
                    if (!adapter.SaveEntity(entity, false))
                        throw new PersistenceFailureException("Could not save Pay Period");
                }
            }
        }

        public IEnumerable<PayPeriodCriteria> GetByPayPeriodId(long[] payPeriodIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from pp in linqMetaData.PayPeriodCriteria
                                where payPeriodIds.Contains(pp.PayPeriodId)
                                select pp).ToArray();

                return Mapper.Map<IEnumerable<PayPeriodCriteriaEntity>, IEnumerable<PayPeriodCriteria>>(entities);
            }
        }
    }
}