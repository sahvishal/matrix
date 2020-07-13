using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class ResultParserHelper : IResultParserHelper
    {
        private List<ResultArchiveLog> _resultArchiveLogs;
        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultArchiveLogs; }
        }

        public ResultParserHelper()
        {
            _resultArchiveLogs = new List<ResultArchiveLog>();
        }

        public void AddResultArchiveLog(string summary, TestType testId, long customerId, MedicalEquipmentTag medicalEquipmentTag, bool isSuccessful = true)
        {
            var log = _resultArchiveLogs.SingleOrDefault(rl => rl.CustomerId == customerId && rl.TestId == testId);
            if (isSuccessful && !string.IsNullOrEmpty(summary)) isSuccessful = false;
            if (log == null)
            {
                log = new ResultArchiveLog
                          {
                              CustomerId = customerId,
                              IsSuccessful = isSuccessful,
                              Notes = summary,
                              TestId = testId,
                              CreatedDate = DateTime.Now,
                              MedicalEquipmentTag = medicalEquipmentTag.ToString()
                          };
                _resultArchiveLogs.Add(log);
            }
            else
            {
                log.Notes = summary;
                log.IsSuccessful = isSuccessful;
                log.CreatedDate = DateTime.Now;
            }
        }

        public void AddTestResulttoEventCustomerAggregate(List<EventCustomerScreeningAggregate> eventCustomerAggregates, long eventId, long customerId, TestResult testResult)
        {
            if (testResult != null)
            {
                var eventCustomerAggregate = eventCustomerAggregates.Where(
                    ec => ec.EventId == eventId && ec.CustomerId == customerId).SingleOrDefault() ??
                                             new EventCustomerScreeningAggregate()
                                                 {
                                                     CustomerId = customerId,
                                                     EventId = eventId,
                                                     TestResults = new List<TestResult>()
                                                 };

                List<TestResult> trs = eventCustomerAggregate.TestResults.ToList();
                trs.Add(testResult);
                eventCustomerAggregate.TestResults = trs;
                if (eventCustomerAggregate.TestResults.Count() == 1) eventCustomerAggregates.Add(eventCustomerAggregate);
            }
        }
    }
}