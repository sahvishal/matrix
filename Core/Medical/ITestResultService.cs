using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ITestResultService
    {
        EventCustomerResultStatusListModel GetEventCustomerResultStatusList(EventCustomerResultStatusListModelFilter filter, long accountId);

        ListModelBase<EventResultStatusViewModel, EventResultStatusViewModelFilter> GetEventResultStatusList(
            int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        void UndoPreAudit(long eventId, long customerId, long updatedBy, bool isNewResultFlow);
        void UndoEvaluation(long eventId, long customerId, long updatedBy);

        void SetResultstoState(long eventId, long customerId, int number, bool isPartial, long updatedBy, bool isChartSignedOff = true);

        IEnumerable<EventCustomerResultStatusListModel> GetCustomerResultStatus(long customerId);

        ListModelBase<TechnicalLimitedScreeningCustomerViewModel, TechnicalLimitedScreeningCustomerListModelFilter> GetCustomerwithTechnicallimitedScreening(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        CustomerEventCriticalTestDataEditModel GetModel(long eventId, long customerId, long testId);
        void SaveModel(long eventId, long customerId, CustomerEventCriticalTestDataEditModel model, long updatorOrgRoleUserId);

        CustomerEventCriticalTestDataViewModel GetCustomerEventCriticalDataViewModel(long eventId, long customerId, long testId);

        ListModelBase<CustomerEventCriticalDataViewModel, CustomerEventCriticalDataListModelFilter>
            GetCustomerwithCriticalData(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<TestPerformedViewModel, TestPerformedListModelFilter> GetTestPerformed(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        PriorityInQueueTestEditModel GetPriorityInQueueTestEditModel(long eventId, long customerId, long testId);
        void SavePriorityInQueueTestEditModel(long eventId, long customerId, long testId, PriorityInQueueTestEditModel model, long updatorOrgRoleUserId);
        bool SaveCustomerResultSigned(MedicareCustomerResultSignedNPViewModel model, OrganizationRoleUser orgRoleUser);

        bool SaveCustomerResultAfterNpReview(MedicareCustomerResultVerifiedViewModel model, OrganizationRoleUser orgRoleUser);
        //void SaveCustomerResultSignedComplete(MedicareEventCustomerModel model);
        void SaveCustomerResultCoded(MedicareCustomerResultCodedViewModel model, OrganizationRoleUser orgRoleUser);
        bool SaveCustomerResultAcesApprovedOn(MedicareEventCustomerModel model, OrganizationRoleUser oru);
        EventCustomerStatusForResultEntryAndPreAudit GetEventCustomerStatusForEntryAndAudit(long customerId, long eventId, bool isNewResultFlow);
        ResultInvoiceEditModel UpdateInvoiceInformationDetail(ResultInvoiceEditModel model, long orgRoleId);
        bool IsTestPurchasedByCustomer(long eventcustomerId, long testId);

        IEnumerable<Test> TestPurchasedByCustomer(long eventcustomerId);
    }
}