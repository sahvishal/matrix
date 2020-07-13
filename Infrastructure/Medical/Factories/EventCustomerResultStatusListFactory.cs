using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation(Interface = typeof(IEventCustomerResultStatusListFactory))]
    public class EventCustomerResultStatusListFactory : IEventCustomerResultStatusListFactory
    {
        private readonly ILogger _logger;
        public EventCustomerResultStatusListFactory(ILogManager logManager)
        {
            _logger = logManager.GetLogger("ResultStatusList");
        }

        public EventCustomerResultStatusListModel Create(Event theEvent, Host eventHost, IEnumerable<EventTest> eventTests, IEnumerable<EventCustomer> eventCustomers,
            IEnumerable<Customer> customers, IEnumerable<EventPackage> packages, IEnumerable<OrderedPair<long, long>> ecIdPackageIdpairs, IEnumerable<OrderedPair<long, long>> ecIdTestIdPairs,
            IEnumerable<ResultArchive> fileUploads, IEnumerable<ResultArchiveLog> parsingResults, List<CustomerResultStatusViewModel> customerResults,
            IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<OrderedPair<long, string>> physcianComments, Notes emrNotes,
            IEnumerable<AssignedPhysicianViewModel> assignedPhysicians, IEnumerable<Order> orders, CorporateAccount account, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians,
            IEnumerable<PriorityInQueue> priorityInQueues, bool printcheck, bool isNewResultFlow, IEnumerable<OrderedPair<long, long>> eventCustomerResultIdTestIdNotPerformedPairs, QuestionnaireType questionnaireType)
        {

            var model = new EventCustomerResultStatusListModel
                            {
                                EventId = theEvent.Id,
                                EventDate = theEvent.EventDate,
                                Address = Mapper.Map<Address, AddressViewModel>(eventHost.Address),
                                Host = eventHost.OrganizationName,
                                EmrNotes = emrNotes != null ? emrNotes.Text : "",
                                EventTests = eventTests.Where(et => et.Test.IsRecordable).Select(et => et.Test).OrderBy(et => et.Id).ToArray(),
                                CaptureAbnStatus = account != null && account.CaptureAbnStatus,
                                CaptureHaf = (account == null || account.CaptureHaf),
                                BloodPackageTracking = theEvent.BloodPackageTracking,
                                RecordsPackageTracking = theEvent.RecordsPackageTracking,
                                PrintCheckList = printcheck,
                            };

            if (eventCustomers == null || eventCustomers.Count() < 1) return model;
            var newCustomerResults = new List<CustomerResultStatusViewModel>();

            if (customerResults == null) customerResults = new List<CustomerResultStatusViewModel>();

            foreach (EventCustomer eventCustomer in eventCustomers)
            {
                var orderPurchased = "";

                var packageIdPurchased =
                    ecIdPackageIdpairs.Where(p => p.FirstValue == eventCustomer.Id).Select(p => p.SecondValue).SingleOrDefault();

                var customerTests = new List<Test>();
                if (packageIdPurchased > 0)
                {
                    var package = packages.SingleOrDefault(p => p.Id == packageIdPurchased);
                    orderPurchased = package.Package.Name;
                    customerTests.AddRange(package.Package.Tests);
                }

                var testIdsPurchased = ecIdTestIdPairs.Where(p => p.FirstValue == eventCustomer.Id).Select(p => p.SecondValue).ToArray();
                if (testIdsPurchased.Count() > 0)
                {
                    if (!string.IsNullOrEmpty(orderPurchased)) orderPurchased += " + ";
                    var addOnTests = eventTests.Where(et => testIdsPurchased.Contains(et.Id)).Select(et => et.Test).ToArray();
                    orderPurchased += string.Join(" + ", addOnTests.Select(t => t.Name));
                    customerTests.AddRange(addOnTests);
                }

                var customer = customerResults.SingleOrDefault(c => c.CustomerId == eventCustomer.CustomerId) ??
                               new CustomerResultStatusViewModel { CustomerId = eventCustomer.CustomerId };


                newCustomerResults.Add(customer);

                var theCustomerDo = customers.SingleOrDefault(c => c.CustomerId == eventCustomer.CustomerId);

                customer.CustomerName = theCustomerDo.NameAsString;
                customer.CustomerFirstName = theCustomerDo.Name.FirstName;
                customer.CustomerLastName = theCustomerDo.Name.LastName;
                customer.Address = Mapper.Map<Address, AddressViewModel>(theCustomerDo.Address);
                customer.Email = theCustomerDo.Email != null ? theCustomerDo.Email.ToString() : "";
                var phone = ((theCustomerDo.HomePhoneNumber ?? theCustomerDo.OfficePhoneNumber) ?? theCustomerDo.OfficePhoneNumber);
                if (phone != null) customer.Phone = phone.ToString();
                customer.OrderPurchased = orderPurchased;

                var eventCustomerResult = eventCustomerResults != null ? eventCustomerResults.SingleOrDefault(ec => ec.Id == eventCustomer.Id) : null;
                var isHraQuestionnaire = questionnaireType == QuestionnaireType.HraQuestionnaire;
                var isChatQuestionnaire = questionnaireType == QuestionnaireType.ChatQuestionnaire;

                bool ischartSignoff = false;
                if (isChatQuestionnaire)
                {
                    var hasPurchasedQVTest = customerTests.Any(x => x.Id == (long)TestType.Qv);
                    ischartSignoff = hasPurchasedQVTest || (eventCustomerResult != null && eventCustomerResult.SignedOffBy.HasValue);
                }
                else
                {
                    var hasPurchasedEawvTest = isHraQuestionnaire && customerTests.Any(x => x.Id == (long)TestType.eAWV);
                    var isEawvTestNotPerformed = eventCustomerResultIdTestIdNotPerformedPairs.Any(x => x.FirstValue == eventCustomer.Id && x.SecondValue == (int)TestType.eAWV);

                    ischartSignoff = (eventCustomerResult != null && eventCustomerResult.SignedOffBy.HasValue) || !hasPurchasedEawvTest || isEawvTestNotPerformed;
                }

                var eventTestResults = customerTests.Select(ct => new TestResultStatusViewModel
                   {
                       TestId = ct.Id,
                       Label = ct.Name,
                       Alias = ct.Alias,
                       ResultState = (isNewResultFlow ? (int)NewTestResultStateNumber.NoResults : (int)TestResultStateNumber.NoResults),
                       State = isNewResultFlow && ischartSignoff ? TestResultStateLabel.NoResultsChartSigned : TestResultStateLabel.NoResults
                   }).ToArray();


                var capturePcpConsent = false;
                if (account != null && account.CapturePcpConsent && primaryCarePhysicians != null && primaryCarePhysicians.Any())
                {
                    capturePcpConsent = primaryCarePhysicians.Any(x => x.CustomerId == customer.CustomerId);
                }

                bool isClinicalFormGenerated = false;
                bool isResultPdfGenerarted = false;
                bool isIpResultGenerated = false;

                if (eventCustomerResult != null)
                {
                    isClinicalFormGenerated = eventCustomerResult.IsClinicalFormGenerated;
                    isResultPdfGenerarted = eventCustomerResult.IsResultPdfGenerated;
                    isIpResultGenerated = eventCustomerResult.IsIpResultGenerated;
                }

                var order = orders.Where(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId).Select(o => o).SingleOrDefault();
                if (order != null)
                {
                    customer.IsPaid = order.DiscountedTotal > order.TotalAmountPaid ? false : true;
                }

                var priorityInqueue = priorityInQueues != null ? priorityInQueues.FirstOrDefault(piq => piq.EventCustomerResultId == eventCustomer.Id) : null;
                customer.InQueuePriority = priorityInqueue != null ? priorityInqueue.InQueuePriority : (long?)null;
                customer.HipaaStatus = eventCustomer.HIPAAStatus;
                customer.PartnerRelease = eventCustomer.PartnerRelease;
                customer.AbnStatus = eventCustomer.AbnStatus;

                customer.IsPremiumVersionPdfGenerated = isResultPdfGenerarted;
                customer.IsClinicalFormGenerated = isClinicalFormGenerated;
                customer.IsIpResultGenerated = isIpResultGenerated;

                customer.HospitalFacilityId = eventCustomer.HospitalFacilityId;

                customer.CapturePcpConsent = capturePcpConsent;
                customer.PcpConsentStatus = eventCustomer.PcpConsentStatus;
                customer.InsuranceReleaseStatus = eventCustomer.InsuranceReleaseStatus;

                customer.IsChartSigned = ischartSignoff;
                customer.IsCodingCompleted = eventCustomerResult != null && eventCustomerResult.CodedBy.HasValue;
                customer.InvoicingDate = eventCustomerResult != null ? eventCustomerResult.AcesApprovedOn : null;

                if (customer.EventCustomerId <= 0)
                    customer.EventCustomerId = eventCustomer.Id;

                customer.PhysicianComments = physcianComments != null ? physcianComments.Where(pc => pc.FirstValue == eventCustomer.Id).Select(pc => pc.SecondValue).FirstOrDefault() : string.Empty;

                customer.AcesId = theCustomerDo.AcesId;

                var allTestIds = customerTests.Select(x => x.Id).ToArray();

                customer.IsAnyTestinHip = eventTests.Any(t => allTestIds.Contains(t.TestId) && t.Test.ShowinCustomerPdf && (t.ResultEntryTypeId.HasValue == false || t.ResultEntryTypeId.Value == (long)ResultEntryType.Hip));

                if (assignedPhysicians != null)
                {
                    var assignedPhysician =
                        assignedPhysicians.SingleOrDefault(ap => ap.CustomerId == customer.CustomerId);

                    customer.AssignedPhysicians = assignedPhysician;
                }

                try
                {
                    customer.TestResults = CompareEventTestResults(customer.TestResults, eventTestResults, parsingResults != null ? parsingResults.Where(pr => pr.CustomerId == eventCustomer.CustomerId).ToArray() : null, isNewResultFlow, customer.IsChartSigned);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Loading Test Results! Customer[{0}] & Event[{1}]. Message: {2}. \nStack Trace: {3}", customer.CustomerId, eventCustomer.EventId, ex.Message, ex.StackTrace));
                    customer.TestResults = null;
                }
            }
            model.AccountId = account != null ? account.Id : 0;
            model.IsHealthPlan = account != null && account.IsHealthPlan;

            model.Customers = newCustomerResults;
            return model;
        }

        private IEnumerable<TestResultStatusViewModel> CompareEventTestResults(IEnumerable<TestResultStatusViewModel> resultsInDb, IEnumerable<TestResultStatusViewModel> eventTestResults,
            IEnumerable<ResultArchiveLog> parsingResults, bool isNewResultFlow, bool isChartSigned)
        {
            if (resultsInDb == null || resultsInDb.Count() < 1) return eventTestResults;

            var newEventTestResults = new List<TestResultStatusViewModel>();
            foreach (var eventTestResult in eventTestResults)
            {
                var result = resultsInDb.SingleOrDefault(t => t.TestId == eventTestResult.TestId);

                if (result == null)
                {
                    newEventTestResults.Add(eventTestResult);
                    continue;
                }

                result.Label = eventTestResult.Label;
                result.Alias = eventTestResult.Alias;

                result.State = isNewResultFlow ? ((NewTestResultStateNumber)result.ResultState).GetNewPresentationfromResultState(result.IsPartial, isChartSigned)
                                : ((TestResultStateNumber)result.ResultState).GetPresentationfromResultState(result.IsPartial);


                if (!isNewResultFlow && result.ResultState == (int)TestResultStateNumber.NoResults)
                {
                    result.State = TestResultStateLabel.NoResults;
                    if (parsingResults != null && parsingResults.Count() > 0)
                    {
                        var parsingResult = parsingResults.Where(p => p.TestId == (TestType)result.TestId).
                            OrderByDescending(p => p.Id).FirstOrDefault();
                        if (parsingResult != null && !parsingResult.IsSuccessful)
                            result.State = TestResultStateLabel.ParsingFailure;
                    }
                }
                if (isNewResultFlow && result.ResultState == (int)TestResultStateNumber.NoResults)
                {
                    result.State = isChartSigned ? TestResultStateLabel.NoResultsChartSigned : TestResultStateLabel.NoResults;
                }

                newEventTestResults.Add(result);
            }
            return newEventTestResults;
        }

        public EventCustomerResultStatusListModel Create(Event theEvent, Host eventHost, IEnumerable<EventTest> eventTests, EventCustomer eventCustomer, Customer customer,
            IEnumerable<EventPackage> packages, IEnumerable<OrderedPair<long, long>> ecIdPackageIdpairs, IEnumerable<OrderedPair<long, long>> ecIdTestIdPairs,
            IEnumerable<ResultArchiveLog> parsingResults, CustomerResultStatusViewModel customerResult, EventCustomerResult eventCustomerResult, bool isNewResultFlow, CorporateAccount account, QuestionnaireType questionnaireType)
        {
            var model = new EventCustomerResultStatusListModel
                            {
                                EventId = theEvent.Id,
                                EventDate = theEvent.EventDate,
                                Address = Mapper.Map<Address, AddressViewModel>(eventHost.Address),
                                Host = eventHost.OrganizationName,
                                EventTests = eventTests.Where(et => et.Test.IsRecordable).Select(et => et.Test).ToArray()
                            };
            var orderPurchased = "";
            var packageIdPurchased = ecIdPackageIdpairs.Where(p => p.FirstValue == eventCustomer.Id).Select(p => p.SecondValue).SingleOrDefault();

            var customerTests = new List<Test>();
            if (packageIdPurchased > 0)
            {
                var package = packages.Where(p => p.Id == packageIdPurchased).Select(p => p.Package).SingleOrDefault();
                orderPurchased = package.Name;
                customerTests.AddRange(package.Tests);
            }

            var testIdsPurchased = ecIdTestIdPairs.Where(p => p.FirstValue == eventCustomer.Id).Select(p => p.SecondValue).ToArray();
            if (testIdsPurchased.Count() > 0)
            {
                if (!string.IsNullOrEmpty(orderPurchased)) orderPurchased += " + ";
                var addOnTests = eventTests.Where(et => testIdsPurchased.Contains(et.Id)).Select(et => et.Test).ToArray();
                orderPurchased += string.Join(" + ", addOnTests.Select(t => t.Name));
                customerTests.AddRange(addOnTests);
            }

            var isHraQuestionnaire = questionnaireType == QuestionnaireType.HraQuestionnaire;
            var isChatQuestionnaire = questionnaireType == QuestionnaireType.ChatQuestionnaire;

            var hasPurchasedEawvTest = isHraQuestionnaire && customerTests.Any(x => x.Id == (long)TestType.eAWV);

            var hasPurchasedQVTest = isChatQuestionnaire && customerTests.Any(x => x.Id == (long)TestType.Qv);

            var newCustomerResults = new List<CustomerResultStatusViewModel>();


            if (customerResult == null)
            {
                customerResult = new CustomerResultStatusViewModel { CustomerId = eventCustomer.CustomerId };
            }
            newCustomerResults.Add(customerResult);

            customerResult.CustomerName = customer.NameAsString;
            customerResult.CustomerFirstName = customer.Name.FirstName;
            customerResult.CustomerLastName = customer.Name.LastName;
            customerResult.OrderPurchased = orderPurchased;

            var eventTestResults = customerTests.Select(ct => new TestResultStatusViewModel
                                                                  {
                                                                      TestId = ct.Id,
                                                                      Label = ct.Name,
                                                                      Alias = ct.Alias,
                                                                      ResultState = (isNewResultFlow ? (int)NewTestResultStateNumber.NoResults : (int)TestResultStateNumber.NoResults),
                                                                      State = TestResultStateLabel.NoResults
                                                                  }).ToArray();

            bool isClinicalFormGenerated = false;
            bool isResultPdfGenerarted = false;
            var isChartSignedOff = false;
            var isIpResultGenerated = false;

            if (isChatQuestionnaire)
            {
                isChartSignedOff = hasPurchasedQVTest || (eventCustomerResult != null && eventCustomerResult.SignedOffBy.HasValue);
            }
            else
            {
                isChartSignedOff = eventCustomerResult.SignedOffBy.HasValue || !hasPurchasedEawvTest;
            }

            if (eventCustomerResult != null)
            {
                isClinicalFormGenerated = eventCustomerResult.IsClinicalFormGenerated;
                isResultPdfGenerarted = eventCustomerResult.IsResultPdfGenerated;
                //isChartSignedOff = isChatQuestionnaire ? eventCustomerResult.SignedOffBy.HasValue : eventCustomerResult.SignedOffBy.HasValue || !hasPurchasedEawvTest;
                isIpResultGenerated = eventCustomerResult.IsIpResultGenerated;
            }

            customerResult.HipaaStatus = eventCustomer.HIPAAStatus;
            customerResult.PartnerRelease = eventCustomer.PartnerRelease;

            customerResult.IsPremiumVersionPdfGenerated = isResultPdfGenerarted;
            customerResult.IsClinicalFormGenerated = isClinicalFormGenerated;
            customerResult.IsChartSigned = isChartSignedOff;
            customerResult.IsIpResultGenerated = isIpResultGenerated;
            customerResult.IsCodingCompleted = eventCustomerResult != null && eventCustomerResult.CodedBy.HasValue;
            customerResult.InvoicingDate = eventCustomerResult != null ? eventCustomerResult.AcesApprovedOn : null;

            customerResult.TestResults = CompareEventTestResults(customerResult.TestResults, eventTestResults, parsingResults, isNewResultFlow, customerResult.IsChartSigned);

            model.Customers = newCustomerResults;
            return model;
        }
    }
}