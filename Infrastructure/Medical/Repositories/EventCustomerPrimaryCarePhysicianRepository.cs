using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using System.Linq;
namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class EventCustomerPrimaryCarePhysicianRepository : PersistenceRepository, IEventCustomerPrimaryCarePhysicianRepository
    {
        private bool DeleteEventCustomerPrimaryCarePhysician(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventCustomerPrimaryCarePhysicianFields.EventCustomerId == eventCustomerId);
                if (adapter.DeleteEntitiesDirectly("EventCustomerPrimaryCarePhysicianEntity", bucket) > 0)
                    return true;
                return false;

            }
        }
        public EventCustomerPrimaryCarePhysician Save(EventCustomerPrimaryCarePhysician domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                DeleteEventCustomerPrimaryCarePhysician(domain.EventCustomerId);

                var entity = Mapper.Map<EventCustomerPrimaryCarePhysician, EventCustomerPrimaryCarePhysicianEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<EventCustomerPrimaryCarePhysicianEntity, EventCustomerPrimaryCarePhysician>(entity);
            }
        }

        public IEnumerable<EventCustomerPrimaryCarePhysician> GetEventCustomerPrimaryCarePhysicianByIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ec in linqMetaData.EventCustomerPrimaryCarePhysician
                                where eventCustomerIds.Contains(ec.EventCustomerId)
                                select ec).ToArray();
                return AutoMapper.Mapper.Map<IEnumerable<EventCustomerPrimaryCarePhysicianEntity>, IEnumerable<EventCustomerPrimaryCarePhysician>>(entities);
            }
        }
    }
}
