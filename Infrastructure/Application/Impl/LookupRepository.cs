using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class LookupRepository : PersistenceRepository, ILookupRepository
    {
        public IEnumerable<Lookup> GetByLookupId(long lookupId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var lookupTypeId = (from l in linqMetaData.Lookup
                                    where l.LookupId == lookupId
                                    select l.LookupTypeId).SingleOrDefault();

                var entities = (from l in linqMetaData.Lookup
                                where l.LookupTypeId == lookupTypeId && l.IsActive
                                orderby l.RelativeOrder
                                select l).ToArray();

                return Mapper.Map<IEnumerable<LookupEntity>, IEnumerable<Lookup>>(entities);
            }
        }
    }
}
