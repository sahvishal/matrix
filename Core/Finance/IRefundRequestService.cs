using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IRefundRequestService
    {
        ListModelBase<RefundRequestBasicInfoModel, RefundRequestListModelFilter> GetPendingRequests(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        RefundRequest SaveRequest(RefundRequestEditModel model);
        bool CheckifCancelAppointmentRequestExistsforaCustomer(long eventId, long customerId);
        void UndoApplySourceCodeRefundRequest(RefundRequest refundRequest);
        void UndoManualRefundRequest(RefundRequest refundRequest);
        void UndoCdRemoveRequest(RefundRequest refundRequest);
        void UndoCancelShippingRequest(RefundRequest refundRequest);
    }
}