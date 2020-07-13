using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using System.Linq;
using System.Collections.Generic;
using Falcon.Data.Linq;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class UnitRepository : PersistenceRepository, IUnitRepository
    {
        public IEnumerable<Unit> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.Unit.OrderBy(x => x.Name).ToArray();
                return entities.IsNullOrEmpty() ? null : Mapper.Map<IEnumerable<UnitEntity>, IEnumerable<Unit>>(entities);
            }
        }
    }
}
