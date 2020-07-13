using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Finance.Repositories;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Service
{
    public class HostDepositService : IHostDepositService
    {
        private readonly IUniqueItemRepository<Event> _uniqueItemRepository;
        private readonly IHostPaymentRepository _hostPaymentRepository;
        private readonly IHostDeositRepository _hostDeositRepository;
        private readonly IHostRepository _hostRepository;

        public HostDepositService()
            : this(new HostPaymentRepository(), new EventRepository(), new HostDepositRepository(), new HostRepository())
        { }

        public HostDepositService(IHostPaymentRepository hostPaymentRepository, IUniqueItemRepository<Event> uniqueItemRepository, IHostDeositRepository hostDeositRepository, IHostRepository hostRepository)
        {
            _hostPaymentRepository = hostPaymentRepository;
            _uniqueItemRepository = uniqueItemRepository;
            _hostDeositRepository = hostDeositRepository;
            _hostRepository = hostRepository;
        }

        public List<EventHostDepositViewData> GetHostDepositsByFilters(long? eventId, DateTime? dueStartDate,
            DateTime? dueEndDate, HostPaymentStatus? hostPaymentStatus, bool? isDeposit, int pageNumber,
            int pageSize, out long totalRecord)
        {
            if (isDeposit.HasValue && !isDeposit.Value)
            {
                var eventHostPaymentViewDatas = GetEventHostPaymentViewData(eventId, dueStartDate, dueEndDate,
                                                                             hostPaymentStatus);

                totalRecord = eventHostPaymentViewDatas.Count();

                return eventHostPaymentViewDatas.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }

            if (isDeposit.HasValue && (isDeposit.Value))
            {
                var eventHostDepositViewDatas = GetEventHostDepositViewDatas(eventId, dueStartDate, dueEndDate,
                                                                             hostPaymentStatus);

                totalRecord = eventHostDepositViewDatas.Count();

                return eventHostDepositViewDatas.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(); ;
            }

            else
            {
                var eventHostPaymentViewDatas = GetEventHostPaymentViewData(eventId, dueStartDate, dueEndDate,
                                                                             hostPaymentStatus);

                var eventHostDepositViewDatas = GetEventHostDepositViewDatas(eventId, dueStartDate, dueEndDate,
                                                                             hostPaymentStatus);

                eventHostPaymentViewDatas = ArrangeHostPaymentAndHostDepositViewDatas(eventHostPaymentViewDatas,
                                                                                      eventHostDepositViewDatas);
                //TODO: Need to change the logic to arrange data 
                if ( (eventHostDepositViewDatas != null && eventHostDepositViewDatas.Count>0) && (eventHostPaymentViewDatas == null || eventHostPaymentViewDatas.Count==0))
                {
                    eventHostPaymentViewDatas = eventHostDepositViewDatas;
                }
                totalRecord = eventHostPaymentViewDatas.Count();

                return eventHostPaymentViewDatas.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(); ;
            }
        }

        private static List<EventHostDepositViewData> ArrangeHostPaymentAndHostDepositViewDatas(List<EventHostDepositViewData> eventHostPaymentViewDatas, List<EventHostDepositViewData> eventHostDepositViewDatas)
        {
            eventHostPaymentViewDatas = eventHostPaymentViewDatas.OrderBy(eh => eh.DueDate).ToList();

            for (int counter = 0; counter < eventHostPaymentViewDatas.Count; counter++)
            {
                if (eventHostPaymentViewDatas[counter] != null && !eventHostPaymentViewDatas[counter].IsDeposit)
                {
                    int index = counter;
                    int i = index;
                    var currentHostDepositForPayment =
                        eventHostDepositViewDatas.FirstOrDefault(
                            hdv => hdv.EventId == eventHostPaymentViewDatas[i].EventId);
                    if (currentHostDepositForPayment != null)
                        eventHostPaymentViewDatas.Insert(++index, currentHostDepositForPayment);
                }
            }
            return eventHostPaymentViewDatas;
        }

        private List<EventHostDepositViewData> GetEventHostDepositViewDatas(long? eventId, DateTime? dueStartDate, DateTime? dueEndDate, HostPaymentStatus? hostPaymentStatus)
        {
            var hostDeposits = _hostDeositRepository.GetByFilters(eventId, dueStartDate, dueEndDate,
                                                                  hostPaymentStatus);

            var eventIds = hostDeposits.Select(hp => hp.EventId);

            var events = _uniqueItemRepository.GetByIds(eventIds);

            var hosts = _hostRepository.GetEventHosts(eventIds);

            return hostDeposits.HostDepositViewData(events, hosts);
        }

        private List<EventHostDepositViewData> GetEventHostPaymentViewData(long? eventId, DateTime? dueStartDate, DateTime? dueEndDate, HostPaymentStatus? hostPaymentStatus)
        {
            var hostPayments = _hostPaymentRepository.GetByFilters(eventId, dueStartDate, dueEndDate,
                                                                   hostPaymentStatus);

            var eventIds = hostPayments.Select(hp => hp.EventId);

            var events = _uniqueItemRepository.GetByIds(eventIds);

            var hosts = _hostRepository.GetEventHosts(eventIds);

            return hostPayments.HostPaymentViewData(events, hosts);
        }
        
    }
}