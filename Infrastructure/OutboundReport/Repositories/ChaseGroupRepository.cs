using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class ChaseGroupRepository : PersistenceRepository, IChaseGroupRepository
    {
        public ChaseGroup GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cg in linqMetaData.ChaseGroup where cg.ChaseGroupId == id select cg).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseGroupEntity, ChaseGroup>(entity);
            }
        }

        public IEnumerable<ChaseGroup> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cg in linqMetaData.ChaseGroup where ids.Contains(cg.ChaseGroupId) select cg).ToArray();

                return Mapper.Map<IEnumerable<ChaseGroupEntity>, IEnumerable<ChaseGroup>>(entities);
            }
        }

        public ChaseGroup Save(ChaseGroup domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ChaseGroup, ChaseGroupEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<ChaseGroupEntity, ChaseGroup>(entity);
            }
        }

        public ChaseGroup GetByNameNumberAndDivision(string groupName, string groupNumber, string groupDivision)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cg in linqMetaData.ChaseGroup where cg.Name == groupName && cg.Number == groupNumber && cg.Division == groupDivision select cg).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseGroupEntity, ChaseGroup>(entity);
            }
        }
    }
}
