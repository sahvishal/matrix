using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class RescheduleCancelDispositionRepository : PersistenceRepository, IRescheduleCancelDispositionRepository
    {
        public IEnumerable<RescheduleCancelDisposition> GetByLookupIds(long[] lookupIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from rcd in linqMetaData.RescheduleCancelDisposition
                                where lookupIds.Contains(rcd.LookupId) && rcd.IsActive
                                orderby rcd.RelativeOrder
                                select rcd).ToArray();

                return Mapper.Map<IEnumerable<RescheduleCancelDispositionEntity>, IEnumerable<RescheduleCancelDisposition>>(entities);
            }
        }
    }
}
