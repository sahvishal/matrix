using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IOperationsReportingService
    {
        ListModelBase<CdImageStatusModel, CdImageStatusModelFilter> GetCdImageStatusmodel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        CustomerLabelListModel GetCustomerLabels(long eventId, int shippingStatus);

        ListModelBase<CustomerCdContentTrackingModel, CustomerCdConentTrackingModelFilter> GetCustomerCdContentTrackingModel(
            int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        IEnumerable<BloodworksLabelViewModel> GetBloodworksLabel(long eventId);
        BloodworksLabelViewModel GetBloodworksLabelForCustomer(long eventId, long customerId);
        IEnumerable<CdLabelViewModel> GetCdLabelForEvent(long eventId);
        IEnumerable<BatchLabelViewModel> GetBatchLabelsForEvent(long eventId);
        BloodworksLabelViewModel GetBloodworksLabelForCustomer(Event eventData, Customer customer, List<Test> tests);
    }
}