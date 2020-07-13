using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ITestResultRepository
    {
        //Modified for NewResultFlow
        TestResult GetTestResults(long customerId, long eventId, bool isNewResultFlow);

        bool SaveTestResults(TestResult currentTestResult, long customerId, long eventId, long organizationRoleUserId);
        bool DeleteCustomerTestReadingResult(long customerEventReadingId);
        bool DeleteIncidentalFinding(long customerEventTestIncidentalFindingId);
        List<OrderedPair<int, int>> GetListOfTestReadingAndReadingId(int testId);
        bool UpdateTestResultState(int state, bool isPartial, long customerEventScreeningTestId, long updateByOrgRoleUserid);
        List<ResultReading<int>> GetReadingsForTest();
        List<ResultReading<int>> GetAllReadings(int testId);
        bool UpdateTestResultStatusForCorrection(long customerEventScreeningTestId);
        TestResult GetTestResult(long customerId, long eventId, int testId, bool isNewResultFlow);
        long GetNextCustomerPostAudit(long eventId, long customerId, bool isNewResultFlow);
        long GetNextCustomerEntryandAudit(long eventId, long customerId, bool isNewResultFlow);
        void UpdateStateforSkipEvaluation(long eventCustomerResultId, long? evaluatedby);
        void UpdateStateforCustomerNotification(long eventCustomerResultId);
        IEnumerable<OrderedPair<string, string>> GetTestMedia(long eventId, long customerId);
        void UpdateStateforPacketGenerated(long eventCustomerResultId);
        void UpdateStateforNotReviewableTests(long eventId, long customerId, bool isPartial, bool isNewResultFlow);
        IEnumerable<long> GetCustomerEventScreeningTestIds(long eventId, long customerId);
        void SetResultstoState(long eventId, long customerId, int number, bool isPartial, long updatedBy);
        void SetResultstoState(int number, bool isPartial, long updatedBy, IEnumerable<long> customerEventScreeningTestIds);
        void DeleteTestData(long eventId, long customerId, long testId);
        void DeleteTestDataByEventIdAndCustomerId(long eventId, long customerId);
        void RemoveSelfPresent(long eventId, long customerId, long testId);

        void RemovePriorityInQueue(long eventId, long customerId, long testId);
        void RemovePriorityInQueueByEventCustomerResultId(long eventCustomerResultId);

        long GetEventIdbySerialKeyAndTestId(int testId, string serialKey);
        void UpdateStateforSkipEvaluationForNewResultFlow(long eventCustomerResultId, long? evaluatedby, bool isPartial);
    }
}
