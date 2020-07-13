using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class RapsRepository : PersistenceRepository, IRapsRepository
    {
        public Raps SaveRaps(Raps domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<Raps, RapsEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Raps");

                return Mapper.Map<RapsEntity, Raps>(entity);
            }
        }

        public IEnumerable<Raps> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from h in linqMetaData.Raps
                              where h.CustomerId == customerId && h.IsSynced == false
                              select h).ToArray();


                return Mapper.Map<IEnumerable<RapsEntity>, IEnumerable<Raps>>(entity);
            }
        }

        public IEnumerable<Raps> GetRapsForSync(int skipCount)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from h in linqMetaData.Raps
                              where h.IsSynced == false
                              orderby h.Id descending
                              select h).Skip(skipCount).Take(100).ToArray();


                return Mapper.Map<IEnumerable<RapsEntity>, IEnumerable<Raps>>(entity);
            }
        }
    }
}
