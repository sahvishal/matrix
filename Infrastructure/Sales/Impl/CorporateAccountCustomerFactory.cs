using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class CorporateAccountCustomerFactory : ICorporateAccountCustomerFactory
    {
        private readonly IMediaRepository _mediaRepository;

        public CorporateAccountCustomerFactory(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public CorporateAccountCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests,
            IEnumerable<ShippingDetail> shippingDetails, ShippingOption cdShippingOption, IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events, IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, string>> eventIdCorporateAccountNamePairs,
            IEnumerable<CustomerResultStatusViewModel> resultStatuses, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<HealthAssessmentAnswer> healthAssessmentAnswers, IEnumerable<HealthAssessmentQuestion> healthAssessmentQuestions,
            IEnumerable<Language> languages, IEnumerable<EventCustomerNotification> eventCustomerNotifications, IEnumerable<EventHospitalPartner> eventHospitalPartners)
        {
            var collection = new List<CorporateAccountCustomerViewModel>();

            foreach (var eventCustomer in eventCustomers)
            {
                var customer = customers.FirstOrDefault(c => c.CustomerId == eventCustomer.CustomerId);
                var order =
                    orders.FirstOrDefault(
                        o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId);
                var package = order == null ? null : packages.FirstOrDefault(p => p.FirstValue == order.Id);
                var test = order == null ? null : tests.Where(t => t.FirstValue == order.Id).ToList();

                var productPurchased = string.Empty;

                if (package != null && !test.IsNullOrEmpty())
                    productPurchased = package.SecondValue + " + " +
                                       string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (!test.IsNullOrEmpty())
                    productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (package != null)
                    productPurchased = package.SecondValue;

                ShippingDetail shippingDetail = null;

                string cdPurchased = "N/A";

                if (order != null)
                {
                    var shippingDetailIds =
                        order.OrderDetails.SelectMany(
                            od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId)).ToArray();

                    shippingDetail =
                        shippingDetails.FirstOrDefault(
                            sd =>
                                shippingDetailIds.Contains(sd.Id) &&
                                sd.ShippingOption.Id != (cdShippingOption != null ? cdShippingOption.Id : 0));

                    var cdShippingDetail =
                        shippingDetails.FirstOrDefault(
                            sd =>
                                shippingDetailIds.Contains(sd.Id) &&
                                sd.ShippingOption.Id == (cdShippingOption != null ? cdShippingOption.Id : 0));

                    var cdOrderDetail =
                        order.OrderDetails.Where(od => od.IsCompleted && od.DetailType == OrderItemType.ProductItem)
                            .ToArray();
                    if (cdOrderDetail != null && cdOrderDetail.Any() && cdShippingDetail != null)
                        cdPurchased = "CD";
                    else if (cdOrderDetail != null && cdOrderDetail.Any() && cdShippingDetail == null)
                        cdPurchased = "Online";
                }
                var isEvaluated = false;
                var isPdfGenerated = false;

                var eventCustomerResult = eventCustomerResults.FirstOrDefault(ecr => ecr.Id == eventCustomer.Id);
                var result = "Not Processed";
                var recommendation = "Not Processed";
                if (eventCustomerResult != null)
                {
                    isEvaluated = true;
                    isPdfGenerated = eventCustomerResult.IsClinicalFormGenerated && eventCustomerResult.IsResultPdfGenerated;
                    result = eventCustomerResult.ResultSummary.HasValue ? ((ResultInterpretation)eventCustomerResult.ResultSummary.Value).GetDescription() : "Not Available";
                    recommendation = eventCustomerResult.PathwayRecommendation.HasValue ? ((PathwayRecommendation)eventCustomerResult.PathwayRecommendation.Value).GetDescription() : "Not Available";
                }

                var eventData = events.FirstOrDefault(e => e.Id == eventCustomer.EventId);
                var eventPods = pods.Where(p => eventData.PodIds.Contains(p.Id)).ToArray();
                var corporateAccountName = eventIdCorporateAccountNamePairs.Where(ecan => ecan.FirstValue == eventData.Id).Select(ecan => ecan.SecondValue).SingleOrDefault();

                var resultStatus = resultStatuses != null ? resultStatuses.SingleOrDefault(rs => rs.EventCustomerId == eventCustomer.Id) : null;
                IEnumerable<OrderedPair<long, string>> pairTestSummary = null;
                if (resultStatus != null && resultStatus.TestResults != null)
                {
                    pairTestSummary = resultStatus.TestResults.Select(tr => new OrderedPair<long, string>(tr.TestId, tr.TestInterpretation.HasValue ? ((ResultInterpretation)tr.TestInterpretation.Value).ToString() : ""));
                }

                var primaryCarePhysician = primaryCarePhysicians.SingleOrDefault(pcp => pcp.CustomerId == eventCustomer.CustomerId);
                var customerHealthAnswers = healthAssessmentAnswers.Where(haa => haa.EventCustomerId == eventCustomer.Id).ToArray();

                var primaryCareAnswer = "No";
                var mammogramProstateScreeningAnswer = "No";
                var colonoscopyAnswer = "No";
                var cancerAnswer = "No";
                var weightBariatricAnswer = "No";
                if (customerHealthAnswers.Any())
                {
                    var primaryCareQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.PrimaryCare.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                    if (primaryCareQuestionId > 0)
                    {
                        var healthassessmentAnswer = customerHealthAnswers.FirstOrDefault(cha => cha.QuestionId == primaryCareQuestionId);
                        if (healthassessmentAnswer != null)
                            primaryCareAnswer = healthassessmentAnswer.Answer;
                    }

                    var mammogramProstateScreeningQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.MammogramProstateScreening.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                    if (mammogramProstateScreeningQuestionId > 0)
                    {
                        var healthassessmentAnswer = customerHealthAnswers.SingleOrDefault(cha => cha.QuestionId == mammogramProstateScreeningQuestionId);
                        if (healthassessmentAnswer != null)
                            mammogramProstateScreeningAnswer = healthassessmentAnswer.Answer;
                    }

                    var colonoscopyQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.Colonoscopy.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                    if (colonoscopyQuestionId > 0)
                    {
                        var healthassessmentAnswer = customerHealthAnswers.SingleOrDefault(cha => cha.QuestionId == colonoscopyQuestionId);
                        if (healthassessmentAnswer != null)
                            colonoscopyAnswer = healthassessmentAnswer.Answer;
                    }

                    var cancerQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.Cancer.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                    if (cancerQuestionId > 0)
                    {
                        var healthassessmentAnswer = customerHealthAnswers.SingleOrDefault(cha => cha.QuestionId == cancerQuestionId);
                        if (healthassessmentAnswer != null)
                            cancerAnswer = healthassessmentAnswer.Answer;
                    }

                    var weightBariatricQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.WeightBariatric.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                    if (weightBariatricQuestionId > 0)
                    {
                        var healthassessmentAnswer = customerHealthAnswers.SingleOrDefault(cha => cha.QuestionId == weightBariatricQuestionId);
                        if (healthassessmentAnswer != null)
                            weightBariatricAnswer = healthassessmentAnswer.Answer;
                    }
                }

                var preferredLanguage = "N/A";
                if (customer.LanguageId.HasValue)
                {
                    var language = languages.FirstOrDefault(x => x.Id == customer.LanguageId);
                    if (language != null)
                    {
                        preferredLanguage = language.Name;
                    }
                }
                EventCustomerNotification eventCustomerNotification = null;

                if (eventCustomerNotifications != null && eventCustomerNotifications.Any())
                {
                    eventCustomerNotification = eventCustomerNotifications.FirstOrDefault(ecn => ecn.EventCustomerId == eventCustomer.Id);
                }

                var eventHospitalPartner = eventHospitalPartners.FirstOrDefault(ehp => ehp.EventId == eventCustomer.EventId);

                var scannedDocumentUrl = string.Empty;
                var mediaLocScannedDocs = _mediaRepository.GetScannedDocumentStorageFileLocation(eventCustomer.EventId);
                if (Directory.Exists(mediaLocScannedDocs.PhysicalPath))
                {
                    var filesScannedDocs = Directory.GetFiles(mediaLocScannedDocs.PhysicalPath);
                    if (filesScannedDocs.Any())
                    {
                        var filename = filesScannedDocs.Where(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileName(fsd).StartsWith(customer.CustomerId.ToString())).Select(Path.GetFileName).FirstOrDefault();
                        if (!string.IsNullOrEmpty(filename))
                            scannedDocumentUrl = mediaLocScannedDocs.Url + filename;
                    }
                }

                collection.Add(new CorporateAccountCustomerViewModel
                {
                    CustomerName = customer.Name,
                    Phone = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.FormatPhoneNumber : string.Empty,
                    PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.FormatPhoneNumber : string.Empty,
                    PhoneOffice = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.FormatPhoneNumber : string.Empty,
                    PhoneOfficeExtn = customer.PhoneOfficeExtension,
                    DateofBirth = customer.DateOfBirth,
                    Package = productPurchased,
                    CdPurchased = cdPurchased,
                    EventDate = eventData.EventDate,
                    CustomerId = customer.CustomerId,
                    EventId = eventCustomer.EventId,
                    Gender = customer.Gender.ToString(),
                    Height = customer.Height != null && customer.Height.TotalInches > 0 ? customer.Height.TotalInches.ToString() : "N/A",
                    Weight = customer.Weight != null && customer.Weight.Pounds > 0 ? customer.Weight.Pounds.ToString() : "N/A",
                    Pod = string.Join(", ", eventPods.Select(ep => ep.Name)),
                    IsEvaluated = isEvaluated,
                    IsPdfGenerated = isPdfGenerated,
                    Result = result,
                    Recommendation = recommendation,
                    Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    Address = Mapper.Map<Address, AddressViewModel>(customer.Address),
                    ShippingMode = shippingDetail != null ? "Paper" : "Online",
                    MailedStatus = shippingDetail != null ? shippingDetail.Status.ToString() : "Online",
                    MailedOn = shippingDetail != null ? shippingDetail.ShipmentDate : null,
                    CorporateSponsor = corporateAccountName ?? "N/A",
                    TestSummary = pairTestSummary,
                    PrimaryCarePhysicianName = primaryCarePhysician != null ? primaryCarePhysician.Name.FullName : "N/A",
                    PrimaryCare = primaryCareAnswer,
                    MammogramProstateScreening = mammogramProstateScreeningAnswer,
                    Colonoscopy = colonoscopyAnswer,
                    Cancer = cancerAnswer,
                    WeightBariatric = weightBariatricAnswer,
                    PreferredLanguage = preferredLanguage,
                    BestTimeToCall = customer.BestTimeToCall.HasValue && customer.BestTimeToCall.Value > 0 ? ((BestTimeToCall)customer.BestTimeToCall).GetDescription() : "N/A",
                    EventCustomerId = eventCustomer.Id,
                    IsCannedMessageSent = eventCustomerNotification != null,
                    Ssn = (eventHospitalPartner != null && eventHospitalPartner.CaptureSsn && !string.IsNullOrEmpty(customer.Ssn) && customer.Ssn.Length >= 9)
                                ? customer.Ssn.Substring(0, 3) + "-" + customer.Ssn.Substring(3, 2) + "-" + customer.Ssn.Substring(customer.Ssn.Length - 4)//"XXX-XX-" + customer.Ssn.Substring(customer.Ssn.Length - 4)
                                : string.Empty,
                    MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                    ScannedDocumentUrl = scannedDocumentUrl,
                    HicnNumber = customer.Hicn
                });
            }

            return new CorporateAccountCustomerListModel
            {
                Collection = collection
            };
        }
    }
}
