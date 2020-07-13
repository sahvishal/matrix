using System;
using System.Collections.Generic;
using HealthYes.Web.Core.Domain.Event;
using HealthYes.Web.Core.Domain.Hosts.Enum;
using HealthYes.Web.Core.Domain.Hosts.Interfaces;
using HealthYes.Web.Core.Domain.Hosts.ViewData;
using HealthYes.Web.Core.Domain.PrintOrder.Enum;
using HealthYes.Web.Core.Domain.PrintOrder.Interfaces;
using HealthYes.Web.Core.Domain.PrintOrder.ViewData;
using HealthYes.Web.Core.Interfaces;
using HealthYes.Web.Infrastructure.Repositories.Events;
using HealthYes.Web.Infrastructure.Repositories.Host;
using HealthYes.Web.Infrastructure.Repositories.PrintOrder;
using System.Linq;
using HealthYes.Web.Core.Extensions;


namespace HealthYes.Web.Infrastructure.Service
{
    class PrintOrderItemTrackingService : IPrintOrderItemTrackingService
    {

        private readonly IPrintOrderItemTrackingRepository _printOrderItemTrackingRepository;


        public PrintOrderItemTrackingService()
            : this(new PrintOrderItemTrackingRepository())
        { }

        public PrintOrderItemTrackingService(IPrintOrderItemTrackingRepository printOrderItemTrackingRepository)
        {
            _printOrderItemTrackingRepository = printOrderItemTrackingRepository;

        }


        public List<PrintOrderItemTrackingViewData> GetPrintOrderItemTrackingByFilters(long? eventId, DateTime? eventStartDate,
            DateTime? eventEndDate, ItemShippingStatus? status, int pageNumber, int pageSize, out long totalRecord)
        {

            var printOrderItemTrackingViewData = _printOrderItemTrackingRepository.GetPrintOrderItemTrackingDetailByFilters
                (eventId, eventStartDate, eventEndDate, status,  pageNumber,  pageSize, out  totalRecord);

            totalRecord = printOrderItemTrackingViewData.Count;
            return printOrderItemTrackingViewData.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(); 

        }
    }
}
