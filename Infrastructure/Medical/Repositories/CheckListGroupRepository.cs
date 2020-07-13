using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class CheckListGroupRepository : PersistenceRepository, ICheckListGroupRepository
    {
        public IEnumerable<CheckListGroup> GetAllGroups()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.CheckListGroup.Where(x => x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<CheckListGroupEntity>, IEnumerable<CheckListGroup>>(entities);
            }
        }

        public IEnumerable<CheckListGroup> GetAllGroupsByGroupIds(IEnumerable<long> groupIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from clg in linqMetaData.CheckListGroup where groupIds.Contains(clg.Id) select clg);

                return Mapper.Map<IEnumerable<CheckListGroupEntity>, IEnumerable<CheckListGroup>>(entities);
            }
        }
    }
}