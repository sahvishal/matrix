using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventProductTypeRepository : PersistenceRepository, IEventProductTypeRepository
    {

        public EventProductTypeRepository()
        {

        }
        public IEnumerable<EventProductType> GetByEventIds(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventProductTypeList = (from ept in
                                                linqMetaData.EventProductType
                                            where eventIds.Contains(ept.EventId) && ept.IsActive
                                            select new EventProductType
                                            {
                                                Id = 0,
                                                StartDate = System.DateTime.Today,
                                                EventID = ept.EventId,
                                                IsActive = ept.IsActive,
                                                ProductTypeId = ept.ProductTypeId
                                            }).ToArray();
                //if (eventProductTypeList != null && eventProductTypeList.Count() > 0)
                //{
                //    var eventList = (from e in linqMetaData.Events
                //                     where eventIds.Contains(e.EventId) && !eventProductTypeList.Select(x => x.EventID).Contains(e.EventId) && e.IsActive
                //                     select new EventProductType { Id = 0, StartDate = System.DateTime.Today, EventID = e.EventId, IsActive = e.IsActive, ProductTypeId = 0 }
                //                                          ).ToArray();
                //    eventProductTypeList = eventProductTypeList.Union(eventList).ToArray();
                //}
                //else
                //{
                //    eventProductTypeList = (from e in linqMetaData.Events
                //                            where eventIds.Contains(e.EventId) && e.IsActive
                //                            select new EventProductType { Id = 0, StartDate = System.DateTime.Today, EventID = e.EventId, IsActive = e.IsActive, ProductTypeId = 0 }
                //                                          ).ToArray();
                //}

                return eventProductTypeList;

            }

        }

        public IEnumerable<EventProductType> GetByEventIdAndCustomerId(long eventId, long customerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);


                var eventProductTypeList = (from ept in linqMetaData.EventProductType
                                            join cp in linqMetaData.CustomerProfile on ept.ProductTypeId equals cp.ProductTypeId
                                            where ept.EventId == eventId && ept.IsActive && cp.CustomerId == customerId
                                            select ept).ToArray();

                return Mapper.Map<IEnumerable<EventProductTypeEntity>, IEnumerable<EventProductType>>(eventProductTypeList);

            }
        }
        public long[] GetProductTypeByEventId(long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);


                var eventProductTypeList = (from ept in linqMetaData.EventProductType
                                            where ept.EventId == eventId && ept.IsActive
                                            select ept.ProductTypeId).ToArray();
                return eventProductTypeList;
            }
        }
    }
}
