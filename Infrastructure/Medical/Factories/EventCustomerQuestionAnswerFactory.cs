using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class EventCustomerQuestionAnswerFactory : IEventCustomerQuestionAnswerFactory
    {
        public ListModelBase<DisqualifiedTestReportViewModel, DisqualifiedTestReportFilter> Create(IEnumerable<DisqualifiedTestModel> disqualifiedTests, IEnumerable<Customer> customers, IEnumerable<Test> tests,
            IEnumerable<OrderedPair<string, string>> tagHealthPlanNamePairs, IEnumerable<PreQualificationQuestion> questions, IEnumerable<DisqualifiedTest> pagedDisqualifiedTestList)
        {
            var listModel = new DisqualifiedTestReportListModel();
            var collection = new List<DisqualifiedTestReportViewModel>();

            /*var disQualifiedTests = (from dt in disqualifiedTests
                                     group dt by new { dt.CustomerId, dt.EventId, dt.TestId } into dts
                                     select new { dts.Key.CustomerId, dts.Key.EventId, dts.Key.TestId }).ToArray();*/

            foreach (var item in disqualifiedTests)
            {
                var disqualifiedTest = pagedDisqualifiedTestList.Where(x => x.CustomerId == item.CustomerId && x.EventId == item.EventId && x.TestId == item.TestId && x.Version == item.Version);

                var customer = customers.First(x => x.CustomerId == item.CustomerId);

                var test = tests.First(x => x.Id == item.TestId);
                var reason = "N/A";
                var healthPlan = "N/A";
                if (!string.IsNullOrEmpty(customer.Tag))
                    healthPlan = !tagHealthPlanNamePairs.IsNullOrEmpty() ? tagHealthPlanNamePairs.First(x => x.FirstValue == customer.Tag).SecondValue : healthPlan;

                reason = GetReason(disqualifiedTest, questions);
                // reason = !questionAnswers.IsNullOrEmpty() ? string.Join(", ", questionAnswers.Select(x => x.DisqualifiedReason)) : reason;


                var model = new DisqualifiedTestReportViewModel
                {
                    CustomerId = customer.CustomerId,
                    HealthPlan = healthPlan,
                    TestName = test.Name,
                    Reason = reason,
                    EventId = item.EventId
                };
                collection.Add(model);
            }
            listModel.Collection = collection;
            return listModel;
        }

        public IEnumerable<EventCustomerQuestionAnswer> GetEventCustomerQuestionAnswerListModel(string questionAnsTestId, long customerId, long eventId, long version, long orgUserId)
        {
            var model = new List<EventCustomerQuestionAnswer>();

            var queAnsIds = questionAnsTestId.Split('|');

            foreach (var item in queAnsIds)
            {
                var eventCustomerQuestionAnswer = new EventCustomerQuestionAnswer();
                var queAns = item.Split(',');
                var queId = queAns[0];
                var ans = queAns[1];
                eventCustomerQuestionAnswer.Answer = ans;
                eventCustomerQuestionAnswer.QuestionId = Convert.ToInt64(queId);
                eventCustomerQuestionAnswer.Version = version + 1;
                eventCustomerQuestionAnswer.CreatedBy = orgUserId;
                eventCustomerQuestionAnswer.CustomerId = customerId;
                eventCustomerQuestionAnswer.EventId = eventId;
                eventCustomerQuestionAnswer.CreatedDate = DateTime.Now;
                eventCustomerQuestionAnswer.IsActive = true;
                model.Add(eventCustomerQuestionAnswer);
            }
            return model;
        }

        public IEnumerable<DisqualifiedTest> GetDisqualifiedTestListModel(string disqualifed, long customerId, long eventId, long version, long orgUserId)
        {
            var model = new List<DisqualifiedTest>();

            var disQualification = disqualifed.Split('|');

            foreach (var item in disQualification)
            {
                var disqualified = new DisqualifiedTest();
                var data = item.Split(',');
                var disqualifiedTestId = data[0];
                var disqualifiedQueId = data[1];
                var disqualifiedAns = data[2];

                disqualified.Answer = disqualifiedAns;
                disqualified.QuestionId = Convert.ToInt64(disqualifiedQueId);
                disqualified.TestId = Convert.ToInt64(disqualifiedTestId);
                disqualified.Version = version + 1;
                disqualified.CreatedBy = orgUserId;
                disqualified.CreatedDate = DateTime.Now;
                disqualified.CustomerId = customerId;
                disqualified.EventId = eventId;
                disqualified.IsActive = true;
                model.Add(disqualified);
            }
            return model;
        }

        public IEnumerable<EventCustomerQuestionAnswerEditModel> GetEventCustomerQuestionAnswer(IEnumerable<PreQualificationQuestion> questions, IEnumerable<EventCustomerQuestionAnswer> eventCustomerQuestionAnswer)
        {
            var listModel = new List<EventCustomerQuestionAnswerEditModel>();
            if (!questions.IsNullOrEmpty() && !eventCustomerQuestionAnswer.IsNullOrEmpty())
            {
                var result = (from ecq in eventCustomerQuestionAnswer
                              join q in questions on ecq.QuestionId equals q.Id
                              group ecq by new { ecq.CustomerId, ecq.EventId, ecq.QuestionId, q.TestId } into ecqg
                              select new EventCustomerQuestionAnswerEditModel
                              {
                                  CustomerId = ecqg.Key.CustomerId,
                                  EventId = ecqg.Key.EventId,
                                  TestId = ecqg.Key.TestId,
                                  QuestionId = ecqg.Key.QuestionId,
                                  Version = ecqg.Max(x => x.Version)
                              }).ToList();

                listModel = (from lst in result
                             from ecq in eventCustomerQuestionAnswer.Where(x => lst.Version == x.Version && lst.QuestionId == x.QuestionId).DefaultIfEmpty()
                             select new EventCustomerQuestionAnswerEditModel
                             {
                                 CustomerId = lst.CustomerId,
                                 EventId = lst.EventId,
                                 TestId = lst.TestId,
                                 QuestionId = lst.QuestionId,
                                 Version = lst.Version,
                                 Answer = ecq.Answer

                             }).ToList();

            }
            return listModel;
        }

        public List<DependentDisqualifiedTest> GetDependentDisqualifiedTestDomains(long customerId, long eventId, IEnumerable<long> disqualifiedTests, int version, long orgUserId, long? eventCustomerId = null)
        {
            if (disqualifiedTests.IsNullOrEmpty())
                return new List<DependentDisqualifiedTest>();

            return disqualifiedTests.Select(x => new DependentDisqualifiedTest
            {
                CustomerId = customerId,
                EventId = eventId,
                TestId = x,
                Version = version + 1,
                IsActive = true,
                EventCustomerId = eventCustomerId
            }).ToList();

        }
        public string GetReason(IEnumerable<DisqualifiedTest> disqualifiedTest, IEnumerable<PreQualificationQuestion> questions)
        {
            var questionAnswers = questions.Where(x => disqualifiedTest.Select(y => y.QuestionId).Contains(x.Id));

            var questionParentIdNull = questionAnswers.Where(x => x.ParentId == null);

            string additionalDisQualificationReasion = "";
            var tempreason = "";
            var reason = "N/A";
            if (questionParentIdNull != null)
            {
                if (questionParentIdNull.Count() > 0)
                {
                    foreach (var qa in questionParentIdNull)
                    {
                        long dft = disqualifiedTest.Where(x => x.QuestionId == qa.Id).Select(x => x.QuestionId).FirstOrDefault();
                        var tChild = questions.Where(x => x.ParentId == dft).Select(x => x.Id).ToArray();


                        var dftAnswer = disqualifiedTest.Where(x => tChild.Contains(x.QuestionId)).Select(x => x.Answer).FirstOrDefault();


                        long dDateChild = questions.Where(x => x.ParentId != null && tChild.Contains((long)x.ParentId)).Select(x => x.Id).FirstOrDefault();

                        var dftDateAnswer = disqualifiedTest.Where(x => x.QuestionId == dDateChild).Select(x => x.Answer).FirstOrDefault();

                        additionalDisQualificationReasion = qa.DisqualifiedReason + ",";
                        if (dftAnswer != null)
                        {

                            if (dftDateAnswer != null)
                            {
                                additionalDisQualificationReasion += dftAnswer + " : " + dftDateAnswer;

                            }
                            else
                            {
                                additionalDisQualificationReasion += dftAnswer;
                            }
                        }


                        tempreason = !string.IsNullOrEmpty(additionalDisQualificationReasion) ? tempreason + " " + additionalDisQualificationReasion : reason;
                    }
                }
                else
                {
                    tempreason = tempreason + " " + questionAnswers.Select(x => x.DisqualifiedReason).FirstOrDefault();
                }
            }
            return tempreason == "" ? reason : tempreason.TrimEnd(',');
        }

        public IEnumerable<EventCustomerQuestionAnswer> CreateEventCustomerQuestionAnswerListModel(IEnumerable<EventCustomerQuestionAnswer> listEventCustomerQuestionAnswer, long customerId, long eventId, long orgUserId, long version = 0)
        {
            var model = new List<EventCustomerQuestionAnswer>();
            foreach (var item in listEventCustomerQuestionAnswer)
            {
                var eventCustomerQuestionAnswer = new EventCustomerQuestionAnswer();
                eventCustomerQuestionAnswer.Answer = item.Answer;
                eventCustomerQuestionAnswer.QuestionId = item.QuestionId;
                eventCustomerQuestionAnswer.Version = version + 1;
                eventCustomerQuestionAnswer.CreatedBy = orgUserId;
                eventCustomerQuestionAnswer.CustomerId = customerId;
                eventCustomerQuestionAnswer.EventId = eventId;
                eventCustomerQuestionAnswer.CreatedDate = DateTime.Now;
                eventCustomerQuestionAnswer.IsActive = true;
                model.Add(eventCustomerQuestionAnswer);
            }
            return model;
        }
        public IEnumerable<DisqualifiedTest> CreateDisqualifiedTestListModel(IEnumerable<DisqualifiedTest> listDisqualifed, long customerId, long eventId, long orgUserId, long version = 0)
        {
            var model = new List<DisqualifiedTest>();
            foreach (var item in listDisqualifed)
            {
                var disqualified = new DisqualifiedTest();
                disqualified.Answer = item.Answer;
                disqualified.QuestionId = item.QuestionId;
                disqualified.TestId = item.TestId;
                disqualified.Version = version + 1;
                disqualified.CreatedBy = orgUserId;
                disqualified.CreatedDate = DateTime.Now;
                disqualified.CustomerId = customerId;
                disqualified.EventId = eventId;
                disqualified.IsActive = true;
                model.Add(disqualified);
            }
            return model;
        }


    }
}
