using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IRefundRequestRepository
    {
        RefundRequest Get(long id);
        IEnumerable<RefundRequest> Get(int pageNumber, int pageSize, RefundRequestListModelFilter filter, out int totalRecords);
        IEnumerable<RefundRequest> GetbyOrderId(long orderId, bool resolved = false);
        void SaveRequestandGiftCertificateMapping(long requestId, long giftCertificateId);
        void SaveProcessorNotes(long id, string notes);
        IEnumerable<RefundRequest> GeRefundRequestByOrderIds(IEnumerable<long> orderIds, RefundRequestType refundRequestType);
    }
}