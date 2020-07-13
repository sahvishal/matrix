using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IResultParserHelper
    {
        IEnumerable<ResultArchiveLog> ResultArchiveLogs { get; }
        void AddResultArchiveLog(string summary, TestType testId, long customerId, MedicalEquipmentTag medicalEquipmentTag, bool isSuccessful = true);
        void AddTestResulttoEventCustomerAggregate(List<EventCustomerScreeningAggregate> eventCustomerAggregates, long eventId, long customerId, TestResult testResult);
    }
}