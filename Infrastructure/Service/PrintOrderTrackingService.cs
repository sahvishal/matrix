using System;
using System.Collections.Generic;
using HealthYes.Web.Core.Domain.Event;
using HealthYes.Web.Core.Domain.Hosts.Enum;
using HealthYes.Web.Core.Domain.Hosts.Interfaces;
using HealthYes.Web.Core.Domain.Hosts.ViewData;
using HealthYes.Web.Core.Domain.PrintOrder.Enum;
using HealthYes.Web.Core.Domain.PrintOrder.ViewData;
using HealthYes.Web.Core.Interfaces;
using HealthYes.Web.Infrastructure.Repositories.Events;
using HealthYes.Web.Infrastructure.Repositories.PrintOrder;
using System.Linq;
using HealthYes.Web.Core.Extensions;

namespace HealthYes.Web.Infrastructure.Service
{
    class PrintOrderItemService : IPrintOrderTrackingService
    {
        private readonly IUniqueItemRepository<Event> _uniqueItemRepository;
        ///private readonly IPrintOrderRepository _hostPaymentRepository;
        public PrintOrderItemService()
            : this( new EventRepository())
        { }

        public PrintOrderItemService(IUniqueItemRepository<Event> uniqueItemRepository)
        {
           
            _uniqueItemRepository = uniqueItemRepository;
          
        }

        public List<PrintOrderItemTrackingViewData> GetPrintOrderItemTrackingByFilters(long? eventId, DateTime? depositStartDate,
                                                               DateTime? depositEndDate,
                                                               ItemShippingStatus? printOrderItemShippingStatus, int pageNumber, int pageSize, out long totalRecord
                                                               )
        {
            totalRecord = 0;
            return null;
            //if (isDeposit.HasValue && !isDeposit.Value)
            //{
            //    var eventHostPaymentViewDatas = GetEventHostPaymentViewData(eventId, dueStartDate, dueEndDate,
            //                                                                 hostPaymentStatus);

            //    totalRecord = eventHostPaymentViewDatas.Count();

            //    return eventHostPaymentViewDatas.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            //}

            //if (isDeposit.HasValue && (isDeposit.Value))
            //{
            //    var eventHostDepositViewDatas = GetEventHostDepositViewDatas(eventId, dueStartDate, dueEndDate,
            //                                                                 hostPaymentStatus);

            //    totalRecord = eventHostDepositViewDatas.Count();

            //    return eventHostDepositViewDatas.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(); ;
            //}

            //else
            //{
            //    var eventHostPaymentViewDatas = GetEventHostPaymentViewData(eventId, dueStartDate, dueEndDate,
            //                                                                 hostPaymentStatus);

            //    var eventHostDepositViewDatas = GetEventHostDepositViewDatas(eventId, dueStartDate, dueEndDate,
            //                                                                 hostPaymentStatus);

            //    eventHostPaymentViewDatas = ArrangeHostPaymentAndHostDepositViewDatas(eventHostPaymentViewDatas,
            //                                                                          eventHostDepositViewDatas);
            //    //TODO: Need to change the logic to arrange data 
            //    if ((eventHostDepositViewDatas != null && eventHostDepositViewDatas.Count > 0) && (eventHostPaymentViewDatas == null || eventHostPaymentViewDatas.Count == 0))
            //    {
            //        eventHostPaymentViewDatas = eventHostDepositViewDatas;
            //    }
            //    totalRecord = eventHostPaymentViewDatas.Count();

            //    return eventHostPaymentViewDatas.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(); ;
            //}
        }


        private List<PrintOrderItemTrackingViewData> GetPrintOrderItemTrackingViewData(long? eventId, DateTime? depositStartDate, DateTime? depositEndDate, ItemShippingStatus? printOrderItemShippingStatus)
        {
            //var hostPayments = _hostPaymentRepository.GetByFilters(eventId, dueStartDate, dueEndDate,
            //                                                       hostPaymentStatus);

            //var eventIds = hostPayments.Select(hp => hp.EventId);

            //var events = _uniqueItemRepository.GetByIds(eventIds);

            //var hosts = _hostRepository.GetEventHosts(eventIds);

            //return hostPayments.HostPaymentViewData(events, hosts);
            return null;
        }
    }
}
