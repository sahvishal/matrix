using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IShippingDetailRepository : IUniqueItemRepository<ShippingDetail>
    {
        int GetAllCount(int status, long shippingOptionId);
        new ShippingDetail GetById(long shippingDetailId);
        IEnumerable<ShippingDetail> GetShippingDetailsForOrder(long orderDetailId);
        IEnumerable<ShippingDetail> GetCancelledShippingDetailsForOrder(long orderDetailId);
        decimal GetShippingPrice(long eventId, long customerId);
        IEnumerable<ShippingDetail> GetShippingDetailsForCancellation(long orderDetailId);
        IEnumerable<ShippingDetail> GetProductShippingDetailsForCancellation(long orderDetailId);
        DateTime? MailedDateForEvent(long eventId, long hospitalFacilityId = 0);
        IEnumerable<OrderedPair<long, DateTime>> GetRecentMailedHospitalPartnerEvents(long hospitalPartnerId);
        IEnumerable<ShippingDetail> GetShippingDetailsForEventCustomer(long eventId, long customerId);
        IEnumerable<ShippingDetail> GetEventCustomerShippingDetailForFilter(int pageNumber, int pageSize, EventCustomerShippingDetailViewDataFilter filter, out int totalRecords);
        IEnumerable<OrderedPair<long, long>> GetShippingDetailIdEventCustomerIdPairs(IEnumerable<long> shippingDetailIds);
        IEnumerable<OrderedPair<long, int>> GetEventIdShippingCountPair(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, decimal>> GetEventIdShippingRevenuePair(IEnumerable<long> eventIds);
        IEnumerable<ShippingDetail> GetShippingDetailsForCustomer(long customerId);
        IEnumerable<ShippingDetail> GetAllCancelledShippingForOrder(long orderId);
        IEnumerable<OrderedPair<long, DateTime>> GetRecentMailedHospitalFacilityEvents(long hospitalFacilityId);
        IEnumerable<OrderedPair<long, long>> GetShippingDetailsIdCustomerId(IEnumerable<long> customerIds);
        IEnumerable<ShippingDetail> GetShippingDetailsForCustomerIds(IEnumerable<long> customerIds);

        IEnumerable<ShippingDetail> GetEventCustomerShippingDetailForFilter(int pageNumber, int pageSize,
            PcpResultMailedReportModelFilter filter, IEnumerable<long> shippingOptions, out int totalRecords);

        IEnumerable<ShippingDetail> GetEventCustomerShippingDetailForFilter(int pageNumber, int pageSize, PcpSummaryLogReportModelFilter filter,
            IEnumerable<long> shippingOptions, out int totalRecords);

        //IEnumerable<ShippingDetail> GetEventCustomerMemberResultMailedReportFilter(int pageNumber, int pageSize,
        //    MemberResultMailedReportFilter filter,
        //    out int totalRecords);
    }
}
