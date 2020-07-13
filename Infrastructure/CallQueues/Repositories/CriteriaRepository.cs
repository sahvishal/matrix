using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class CriteriaRepository : PersistenceRepository, ICriteriaRepository
    {
        public IEnumerable<Criteria> GetAll()
        {
            using (var adapter= PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from c in linqMetaData.Criteria where c.IsActive select c);

                return Mapper.Map<IEnumerable<CriteriaEntity>, IEnumerable<Criteria>>(enetities);
            }
        }
    }
}
