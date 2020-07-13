using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class ChaseChannelLevelRepository : PersistenceRepository, IChaseChannelLevelRepository
    {
        public ChaseChannelLevel GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ccl in linqMetaData.ChaseChannelLevel where ccl.ChaseChannelLevelId == id select ccl).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseChannelLevelEntity, ChaseChannelLevel>(entity);
            }
        }

        public IEnumerable<ChaseChannelLevel> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccl in linqMetaData.ChaseChannelLevel where ids.Contains(ccl.ChaseChannelLevelId) select ccl).ToArray();

                return Mapper.Map<IEnumerable<ChaseChannelLevelEntity>, IEnumerable<ChaseChannelLevel>>(entities);
            }
        }

        public ChaseChannelLevel Save(ChaseChannelLevel domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ChaseChannelLevel, ChaseChannelLevelEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<ChaseChannelLevelEntity, ChaseChannelLevel>(entity);
            }
        }

        public IEnumerable<CustomerChaseChannel> GetCustomerChaseChannelsByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccc in linqMetaData.CustomerChaseChannel where ccc.CustomerId == customerId select ccc).ToArray();

                return Mapper.Map<IEnumerable<CustomerChaseChannelEntity>, IEnumerable<CustomerChaseChannel>>(entities);
            }
        }

        public IEnumerable<CustomerChaseChannel> GetCustomerChaseChannelsByChaseChannelId(long chaseChannelId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccc in linqMetaData.CustomerChaseChannel where ccc.ChaseChannelLevelId == chaseChannelId select ccc).ToArray();

                return Mapper.Map<IEnumerable<CustomerChaseChannelEntity>, IEnumerable<CustomerChaseChannel>>(entities);
            }
        }

        public IEnumerable<CustomerChaseChannel> SaveCustomerChaseChannels(IEnumerable<CustomerChaseChannel> domains)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = new EntityCollection<CustomerChaseChannelEntity>();

                foreach (var domain in domains)
                {
                    var entity = (from ccp in linqMetaData.CustomerChaseChannel where ccp.CustomerId == domain.CustomerId && ccp.ChaseChannelLevelId == domain.ChaseChannelLevelId select ccp).SingleOrDefault();
                    if (entity == null)
                        entities.Add(Mapper.Map<CustomerChaseChannel, CustomerChaseChannelEntity>(domain));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<IEnumerable<CustomerChaseChannelEntity>, IEnumerable<CustomerChaseChannel>>(entities);
            }
        }

        public CustomerChaseChannel SaveCustomerChaseChannel(CustomerChaseChannel domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ccp in linqMetaData.CustomerChaseChannel where ccp.CustomerId == domain.CustomerId && ccp.ChaseChannelLevelId == domain.ChaseChannelLevelId select ccp).SingleOrDefault();
                entity = entity ?? Mapper.Map<CustomerChaseChannel, CustomerChaseChannelEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<CustomerChaseChannelEntity, CustomerChaseChannel>(entity);
            }
        }

        public ChaseChannelLevel GetByNameAndLevel(string channelName, int level)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ccl in linqMetaData.ChaseChannelLevel where ccl.ChannelName == channelName && ccl.ChannelLevel == level select ccl).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseChannelLevelEntity, ChaseChannelLevel>(entity);
            }
        }

        public void DeleteByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccc in linqMetaData.CustomerChaseChannel where ccc.CustomerId == customerId select ccc);

                foreach (var customerChaseChannelEntity in entities)
                {
                    adapter.DeleteEntity(customerChaseChannelEntity);
                }
            }
        }
    }
}
