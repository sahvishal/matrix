using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerQuestionAnswerService
    {
        void SavePreQualifiedTestAnswers(string questionAnsTestId, string disqualified, long? eventCustomerId, long customerId, long eventId, long orgUserId);
        ListModelBase<DisqualifiedTestReportViewModel, DisqualifiedTestReportFilter> GetDisqualifiedTestReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        IEnumerable<EventCustomerQuestionAnswerEditModel> GetEventCustomerQuestionAnswer(long customerId);
        string GetQuestionAnswerTestIdString(long customerId, long eventId);
        void UpdatePreQualifiedTestAnswers(long customerId, long eventId, long oldEventId, long orgUserId);
    }
}
