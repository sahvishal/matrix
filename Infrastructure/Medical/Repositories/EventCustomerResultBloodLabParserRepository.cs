using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class EventCustomerResultBloodLabParserRepository : PersistenceRepository, IEventCustomerResultBloodLabParserRepository
    {
         public  EventCustomerResultBloodLabParser Save(EventCustomerResultBloodLabParser domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ecrblp in linqMetaData.EventCustomerResultBloodLabParser where ecrblp.EventCustomerResultId == domain.EventCustomerResultId select ecrblp).SingleOrDefault();
                if (entity == null || !entity.IsActive)
                {
                    entity = Mapper.Map<EventCustomerResultBloodLabParser, EventCustomerResultBloodLabParserEntity>(domain);
                    adapter.SaveEntity(entity, true, false);
                    return Mapper.Map<EventCustomerResultBloodLabParserEntity, EventCustomerResultBloodLabParser>(entity);
                }

                return domain;
            }
        }

         public EventCustomerResultBloodLabParser GetByEventCustomerResultId(long eventCustomerResultId)
         {
             using (var adapter = PersistenceLayer.GetDataAccessAdapter())
             {
                 var linqMetaData = new LinqMetaData(adapter);

                 var entity = (from ecrblp in linqMetaData.EventCustomerResultBloodLabParser
                               where ecrblp.EventCustomerResultId == eventCustomerResultId
                               && ecrblp.IsActive
                               select ecrblp).SingleOrDefault();

                 if (entity == null)
                     return null;
                 return Mapper.Map<EventCustomerResultBloodLabParserEntity, EventCustomerResultBloodLabParser>(entity);
             }
        
         }

         public EventCustomerResultBloodLabParser GetByEventIdAndCustomerId(long eventId, long customerId)
         {
             using (var adapter = PersistenceLayer.GetDataAccessAdapter())
             {
                 var linqMetaData = new LinqMetaData(adapter);

                 var entity = (from ecrbl in linqMetaData.EventCustomerResultBloodLabParser
                               join ecr in linqMetaData.EventCustomerResult on ecrbl.EventCustomerResultId equals ecr.EventCustomerResultId
                               where ecr.EventId == eventId && ecr.CustomerId == customerId
                               && ecrbl.IsActive
                               select ecrbl).SingleOrDefault();

                 if (entity == null)
                     return null;
                 return Mapper.Map<EventCustomerResultBloodLabParserEntity, EventCustomerResultBloodLabParser>(entity);
             }
             
         }
    }
}
