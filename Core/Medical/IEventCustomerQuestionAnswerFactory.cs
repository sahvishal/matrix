using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerQuestionAnswerFactory
    {
        ListModelBase<DisqualifiedTestReportViewModel, DisqualifiedTestReportFilter> Create(IEnumerable<DisqualifiedTestModel> disqualifiedTests, IEnumerable<Customer> customers, IEnumerable<Test> tests,
            IEnumerable<OrderedPair<string, string>> tagHealthPlanNamePairs, IEnumerable<PreQualificationQuestion> questions, IEnumerable<DisqualifiedTest> pagedDisqualifiedTestList);

        IEnumerable<EventCustomerQuestionAnswer> GetEventCustomerQuestionAnswerListModel(string questionAnsTestId, long customerId, long eventId, long version, long orgUserId);
        IEnumerable<DisqualifiedTest> GetDisqualifiedTestListModel(string disqualifed, long customerId, long eventId, long version, long orgUserId);
        IEnumerable<EventCustomerQuestionAnswerEditModel> GetEventCustomerQuestionAnswer(IEnumerable<PreQualificationQuestion> questions, IEnumerable<EventCustomerQuestionAnswer> eventCustomerQuestionAnswer);

        List<DependentDisqualifiedTest> GetDependentDisqualifiedTestDomains(long customerId, long eventId, IEnumerable<long> disqualifiedTests, int version, long orgUserId, long? eventCustomerId = null);

        IEnumerable<EventCustomerQuestionAnswer> CreateEventCustomerQuestionAnswerListModel(IEnumerable<EventCustomerQuestionAnswer> listEventCustomerQuestionAnswer, long customerId, long eventId, long orgUserId, long version = 0);
        IEnumerable<DisqualifiedTest> CreateDisqualifiedTestListModel(IEnumerable<DisqualifiedTest> listDisqualifed, long customerId, long eventId, long orgUserId, long version = 0);
    }
}
