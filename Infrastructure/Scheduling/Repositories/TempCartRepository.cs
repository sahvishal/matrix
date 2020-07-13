using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class TempCartRepository : PersistenceRepository, ITempCartRepository
    {
        public TempCart Get(string guid, bool isCompleted = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.TempCart.Where(t => t.Guid == guid && t.IsCompleted == isCompleted).SingleOrDefault();
                if (entity == null) return null;

                return Mapper.Map<TempCartEntity, TempCart>(entity);
            }
        }
        
        public TempCart Save(TempCart domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<TempCart, TempCartEntity>(domainObject);
                entity.Fields["IsUsedAppointmentSlotExpiryExtension"].IsChanged = true;
                entity.Fields["InChainAppointmentSlots"].IsChanged = true;

                if(!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();

                return Mapper.Map<TempCartEntity, TempCart>(entity);
            }
        }

        public void Delete(TempCart domainObject)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IEnumerable<TempCart> domainObjects)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteByProspectCustomerId(long prospectCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(TempCartFields.ProspectCustomerId == prospectCustomerId);
                adapter.DeleteEntitiesDirectly("TempCartEntity", bucket);
            }
        }

        public void DeleteByProspectCustomerIds(IEnumerable<long> prospectCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(TempCartFields.ProspectCustomerId == prospectCustomerIds.ToArray());
                adapter.DeleteEntitiesDirectly("TempCartEntity", bucket);
            }
        }
    }
}