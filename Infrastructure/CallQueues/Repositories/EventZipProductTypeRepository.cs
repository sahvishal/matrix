using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class EventZipProductTypeRepository : PersistenceRepository, IEventZipProductTypeRepository
    {
        public EventZipProductType SaveEventZipProductType(EventZipProductType eventZipProductType)
        {


            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventZipProductType, EventZipProductTypeEntity>(eventZipProductType);
                adapter.SaveEntity(entity, true);

                return Mapper.Map<EventZipProductTypeEntity, EventZipProductType>(entity);
            }


        }

        public EventZipProductType SaveEventZipProductTypeSubstitute(EventZipProductType eventZipProductType)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventZipProductType, EventZipProductTypeSubstituteEntity>(eventZipProductType);
                adapter.SaveEntity(entity, true);

                return Mapper.Map<EventZipProductTypeSubstituteEntity, EventZipProductType>(entity);
            }


        }
        public void DeleteEventZipProductType()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ezp in linqMetaData.EventZipProductType select ezp).ToArray(); ;
                var entityProductType = entity.Select(x => x.ProductTypeId).Distinct();

                var model = Mapper.Map<IEnumerable<EventZipProductTypeEntity>, IEnumerable<EventZipProductType>>(entity);

                var relationPredicateBucket = new RelationPredicateBucket(EventZipProductTypeFields.ProductTypeId == 0);
                adapter.DeleteEntitiesDirectly(typeof(EventZipProductTypeEntity), relationPredicateBucket);

                foreach (var item in entityProductType)
                {
                    relationPredicateBucket = new RelationPredicateBucket(EventZipProductTypeFields.ProductTypeId == item);
                    adapter.DeleteEntitiesDirectly(typeof(EventZipProductTypeEntity), relationPredicateBucket);
                }


            }
        }
        public void DeleteEventZipProductTypeSubstitute()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ezp in linqMetaData.EventZipProductTypeSubstitute select ezp).ToArray(); ;
                var entityProductType = entity.Select(x => x.ProductTypeId).Distinct();

                var model = Mapper.Map<IEnumerable<EventZipProductTypeSubstituteEntity>, IEnumerable<EventZipProductType>>(entity);
              
                var relationPredicateBucket = new RelationPredicateBucket(EventZipProductTypeSubstituteFields.ProductTypeId == 0);
                adapter.DeleteEntitiesDirectly(typeof(EventZipProductTypeSubstituteEntity), relationPredicateBucket);
               
                foreach (var item in entityProductType)
                {
                    relationPredicateBucket = new RelationPredicateBucket(EventZipProductTypeSubstituteFields.ProductTypeId == item);
                    adapter.DeleteEntitiesDirectly(typeof(EventZipProductTypeSubstituteEntity), relationPredicateBucket);
                }


            }
        }
    }
}
