using System;
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
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    [DefaultImplementation]
    public class HospitalPartnerCustomerViewModelFactory : IHospitalPartnerCustomerViewModelFactory
    {
        private readonly IMediaRepository _mediaRepository;
        public HospitalPartnerCustomerViewModelFactory(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public HospitalPartnerCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Order> orders, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests,
            IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers, IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<Event> events, IEnumerable<ShippingDetail> shippingDetails,
            IEnumerable<CustomerResultStatusViewModel> resultStatuses, ShippingOption cdShippingOption, IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, string>> eventHospitalPartnerNamePairs,
            IEnumerable<OrderedPair<long, string>> eventIdCorporateAccounrNamePairs, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<HealthAssessmentQuestion> healthAssessmentQuestions,
            IEnumerable<HealthAssessmentAnswer> healthAssessmentAnswers, IEnumerable<EventCustomerResult> eventCustomerResults, HospitalPartner hospitalPartner, IEnumerable<CustomerCallNotes> notes,
            IEnumerable<EventCustomerNotification> eventCustomerNotifications, IEnumerable<EventHospitalPartner> eventHospitalPartners, IEnumerable<OrderedPair<long, string>> eventCustomerIdHospitalFacilityNamePairs,
            IEnumerable<HospitalFacility> hospitalFacilities, IEnumerable<long> showScannedDocumentHospitalPartnerIds, IEnumerable<Language> languages)
        {
            var model = new HospitalPartnerCustomerListModel();
            var customerModels = new List<HospitalPartnerCustomerViewModel>();

            eventCustomers.ToList().ForEach(ec =>
                                                {
                                                    var order = orders.Where(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId).FirstOrDefault();
                                                    var customer =
                                                        customers.Where(c => c.CustomerId == ec.CustomerId).FirstOrDefault();
                                                    var package = order == null ? null :
                                                        packages.Where(p => p.FirstValue == order.Id).FirstOrDefault();

                                                    var test = order == null ? null : tests.Where(p => p.FirstValue == order.Id).ToList();
                                                    
                                                    var productPurchased = string.Empty;

                                                    if (package != null && !test.IsNullOrEmpty())
                                                        productPurchased =
                                                            package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                                                    else if (!test.IsNullOrEmpty())
                                                        productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                                                    else if (package != null)
                                                        productPurchased =
                                                            package.SecondValue;

                                                    ShippingDetail shippingDetail = null;

                                                    string cdPurhased = "N/A";
                                                    if (order != null)
                                                    {
                                                        var shippingDetailIds = order.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId)).ToArray();

                                                        shippingDetail = shippingDetails.Where(sd => shippingDetailIds.Contains(sd.Id) && sd.ShippingOption.Id != (cdShippingOption != null ? cdShippingOption.Id : 0)).FirstOrDefault();

                                                        var cdShippingDetail = shippingDetails.Where(sd => shippingDetailIds.Contains(sd.Id) && sd.ShippingOption.Id == (cdShippingOption != null ? cdShippingOption.Id : 0)).FirstOrDefault();

                                                        var cdOrderDetail = order.OrderDetails.Where(od => od.IsCompleted && od.DetailType == OrderItemType.ProductItem).ToArray();
                                                        if (cdOrderDetail != null && cdOrderDetail.Count() > 0 && cdShippingDetail != null)
                                                            cdPurhased = "CD";
                                                        else if (cdOrderDetail != null && cdOrderDetail.Count() > 0 && cdShippingDetail == null)
                                                            cdPurhased = "Online";
                                                    }
                                                    var isEvaluated = false;
                                                    var isPdfGenerated = false;

                                                    var evenCustomerResult = eventCustomerResults.Where(ecr => ecr.Id == ec.Id).FirstOrDefault();
                                                    var result = "Not Processed";
                                                    var recommendation = "Not Processed";
                                                    if (evenCustomerResult != null)
                                                    {
                                                        isEvaluated = true;
                                                        isPdfGenerated = evenCustomerResult.IsClinicalFormGenerated && evenCustomerResult.IsResultPdfGenerated;
                                                        result = evenCustomerResult.ResultSummary.HasValue ? ((ResultInterpretation)evenCustomerResult.ResultSummary.Value).GetDescription() : "Not Available";
                                                        recommendation = evenCustomerResult.PathwayRecommendation.HasValue ? ((PathwayRecommendation)evenCustomerResult.PathwayRecommendation.Value).GetDescription() : "Not Available";
                                                    }

                                                    HospitalPartnerCustomer hospitalPartnerCustomer = null;
                                                    var customerActivities = hospitalPartnerCustomers.Where(hpc => hpc.EventId == ec.EventId && hpc.CustomerId == ec.CustomerId).ToArray();
                                                    if (customerActivities.Count() > 0)
                                                    {
                                                        customerActivities = customerActivities.OrderBy(hpc => hpc.Id).ToArray();
                                                        hospitalPartnerCustomer = customerActivities.Last();
                                                    }

                                                    var care = "N/A";
                                                    if (hospitalPartnerCustomer != null)
                                                    {
                                                        care =
                                                            idNamePairs.Where(
                                                                cc =>
                                                                cc.FirstValue ==
                                                                hospitalPartnerCustomer.CareCoordinatorOrgRoleUserId).
                                                                First().SecondValue;
                                                    }

                                                    var resultStatus = resultStatuses != null ? resultStatuses.Where(rs => rs.EventCustomerId == ec.Id).SingleOrDefault() : null;
                                                    IEnumerable<OrderedPair<long, string>> pairTestSummary = null;
                                                    if (resultStatus != null && resultStatus.TestResults != null)
                                                    {
                                                        pairTestSummary = resultStatus.TestResults.Select(tr => new OrderedPair<long, string>(tr.TestId, tr.TestInterpretation.HasValue ? ((ResultInterpretation)tr.TestInterpretation.Value).ToString() : ""));
                                                    }

                                                    var eventData = events.Where(e => e.Id == ec.EventId).FirstOrDefault();
                                                    var eventPods =
                                                        pods.Where(p => eventData.PodIds.Contains(p.Id)).ToArray();

                                                    DateTime? initialCallDate = null;

                                                    if (evenCustomerResult != null && evenCustomerResult.ResultState == (int)TestResultStateNumber.ResultDelivered && (hospitalPartnerCustomer == null || ((HospitalPartnerCustomerStatus)hospitalPartnerCustomer.Status) == HospitalPartnerCustomerStatus.NotCalled))
                                                    {
                                                        if (shippingDetail != null && shippingDetail.Status == ShipmentStatus.Shipped)
                                                        {
                                                            initialCallDate = (shippingDetail.ShipmentDate ?? DateTime.Now).AddDays(1).AddDays(hospitalPartner != null && hospitalPartner.MailTransitDays != null ? hospitalPartner.MailTransitDays.Value : 0);
                                                        }
                                                        else if (shippingDetail == null)
                                                        {
                                                            initialCallDate = (evenCustomerResult.DataRecorderMetaData.DateModified ?? evenCustomerResult.DataRecorderMetaData.DateCreated).AddDays(1);
                                                        }
                                                    }

                                                    var hospitalPartnername = eventHospitalPartnerNamePairs.Where(ehp => ehp.FirstValue == eventData.Id).Select(ehp => ehp.SecondValue).SingleOrDefault();
                                                    var corporateAccountName = eventIdCorporateAccounrNamePairs.Where(ecan => ecan.FirstValue == eventData.Id).Select(ecan => ecan.SecondValue).SingleOrDefault();

                                                    var primaryCarePhysician = primaryCarePhysicians.Where(pcp => pcp.CustomerId == ec.CustomerId).SingleOrDefault();

                                                    var customerHealthAnswers = healthAssessmentAnswers.Where(haa => haa.EventCustomerId == ec.Id).ToArray();

                                                    var primaryCareAnswer = "No";
                                                    var mammogramProstateScreeningAnswer = "No";
                                                    var colonoscopyAnswer = "No";
                                                    var cancerAnswer = "No";
                                                    var weightBariatricAnswer = "No";
                                                    if (customerHealthAnswers.Count() > 0)
                                                    {
                                                        var primaryCareQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.PrimaryCare.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                                                        if (primaryCareQuestionId > 0)
                                                        {
                                                            var healthassessmentAnswer = customerHealthAnswers.Where(cha => cha.QuestionId == primaryCareQuestionId).FirstOrDefault();
                                                            if (healthassessmentAnswer != null)
                                                                primaryCareAnswer = healthassessmentAnswer.Answer;
                                                        }

                                                        var mammogramProstateScreeningQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.MammogramProstateScreening.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                                                        if (mammogramProstateScreeningQuestionId > 0)
                                                        {
                                                            var healthassessmentAnswer = customerHealthAnswers.Where(cha => cha.QuestionId == mammogramProstateScreeningQuestionId).SingleOrDefault();
                                                            if (healthassessmentAnswer != null)
                                                                mammogramProstateScreeningAnswer = healthassessmentAnswer.Answer;
                                                        }

                                                        var colonoscopyQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.Colonoscopy.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                                                        if (colonoscopyQuestionId > 0)
                                                        {
                                                            var healthassessmentAnswer = customerHealthAnswers.Where(cha => cha.QuestionId == colonoscopyQuestionId).SingleOrDefault();
                                                            if (healthassessmentAnswer != null)
                                                                colonoscopyAnswer = healthassessmentAnswer.Answer;
                                                        }

                                                        var cancerQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.Cancer.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                                                        if (cancerQuestionId > 0)
                                                        {
                                                            var healthassessmentAnswer = customerHealthAnswers.Where(cha => cha.QuestionId == cancerQuestionId).SingleOrDefault();
                                                            if (healthassessmentAnswer != null)
                                                                cancerAnswer = healthassessmentAnswer.Answer;
                                                        }

                                                        var weightBariatricQuestionId = healthAssessmentQuestions.Where(haq => haq.Label == HealthAssessmentQuestionLabel.WeightBariatric.GetDescription()).Select(haq => haq.Id).SingleOrDefault();
                                                        if (weightBariatricQuestionId > 0)
                                                        {
                                                            var healthassessmentAnswer = customerHealthAnswers.Where(cha => cha.QuestionId == weightBariatricQuestionId).SingleOrDefault();
                                                            if (healthassessmentAnswer != null)
                                                                weightBariatricAnswer = healthassessmentAnswer.Answer;
                                                        }
                                                    }

                                                    //var notes = _customerCallNotesRepository.GetCustomerNotes(eventData.Id, new[] { customer.CustomerId });
                                                    var customerNotes = notes.Where(n => n.CustomerId == customer.CustomerId && n.EventId == eventData.Id).Select(n => n).ToArray();
                                                    string postScreeningNotes = string.Empty;

                                                    if (!customerNotes.IsNullOrEmpty())
                                                    {
                                                        //postScreeningNotes = string.Join("\\n\\n", notes.Where(n => n.NotesType == CustomerRegistrationNotesType.PostScreeningFollowUpNotes).Select(n => n.Notes).ToArray());
                                                        postScreeningNotes = string.Join("\\n\\n", customerNotes.Select(n => n.Notes).ToArray());
                                                    }
                                                    EventCustomerNotification eventCustomerNotification = null;

                                                    if (eventCustomerNotifications != null && eventCustomerNotifications.Count() > 0)
                                                    {
                                                        eventCustomerNotification = eventCustomerNotifications.FirstOrDefault(ecn => ecn.EventCustomerId == ec.Id);
                                                    }

                                                    var eventHospitalPartner = eventHospitalPartners.SingleOrDefault(ehp => ehp.EventId == eventData.Id);

                                                    var showScannedDocumentUrl = false;
                                                    var scannedDocumentUrl = string.Empty;
                                                    if (eventHospitalPartner != null && showScannedDocumentHospitalPartnerIds != null)
                                                    {
                                                        showScannedDocumentUrl = showScannedDocumentHospitalPartnerIds.Contains(eventHospitalPartner.HospitalPartnerId);
                                                        if (showScannedDocumentUrl)
                                                        {
                                                            var mediaLocScannedDocs = _mediaRepository.GetScannedDocumentStorageFileLocation(eventHospitalPartner.EventId);
                                                            var filesScannedDocs = Directory.GetFiles(mediaLocScannedDocs.PhysicalPath);
                                                            if (filesScannedDocs.Any())
                                                            {
                                                                var filename = filesScannedDocs.Where(fsd => !string.IsNullOrEmpty(fsd) && Path.GetFileName(fsd).StartsWith(customer.CustomerId.ToString())).Select(Path.GetFileName).FirstOrDefault();
                                                                if (!string.IsNullOrEmpty(filename))
                                                                    scannedDocumentUrl = mediaLocScannedDocs.Url + filename;
                                                            }
                                                        }
                                                    }


                                                    HospitalFacility hospitalFacility = null;
                                                    var hospitalFacilityName = string.Empty;
                                                    if (ec.HospitalFacilityId.HasValue)
                                                    {
                                                        if (hospitalFacilities != null && hospitalFacilities.Any())
                                                        {
                                                            hospitalFacility = hospitalFacilities.FirstOrDefault(hf => hf.Id == ec.HospitalFacilityId);
                                                        }

                                                        if (eventCustomerIdHospitalFacilityNamePairs != null && eventCustomerIdHospitalFacilityNamePairs.Any())
                                                        {
                                                            hospitalFacilityName = eventCustomerIdHospitalFacilityNamePairs.Where(ehp => ehp.FirstValue == ec.Id).Select(ehp => ehp.SecondValue).FirstOrDefault();
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

                                                    customerModels.Add(new HospitalPartnerCustomerViewModel
                                                                           {
                                                                               CustomerName = customer.Name,
                                                                               Phone = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.FormatPhoneNumber : string.Empty,
                                                                               PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.FormatPhoneNumber : string.Empty,
                                                                               PhoneOffice = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.FormatPhoneNumber : string.Empty,
                                                                               PhoneOfficeExtn = customer.PhoneOfficeExtension,
                                                                               DateofBirth = customer.DateOfBirth,
                                                                               Package = productPurchased,
                                                                               CdPurchased = cdPurhased,
                                                                               EventDate = eventData.EventDate,
                                                                               CustomerId = customer.CustomerId,
                                                                               EventId = ec.EventId,
                                                                               Gender = customer.Gender.ToString(),
                                                                               Height = customer.Height != null && customer.Height.TotalInches > 0 ? customer.Height.TotalInches.ToString() : "N/A",
                                                                               Weight = customer.Weight != null && customer.Weight.Pounds > 0 ? customer.Weight.Pounds.ToString() : "N/A",
                                                                               Pod = string.Join(", ", eventPods.Select(ep => ep.Name)),
                                                                               IsEvaluated = isEvaluated,
                                                                               IsPdfGenerated = isPdfGenerated,
                                                                               Status = hospitalPartnerCustomer != null ? ((HospitalPartnerCustomerStatus)hospitalPartnerCustomer.Status).GetDescription() : HospitalPartnerCustomerStatus.NotCalled.GetDescription(),
                                                                               Outcome = hospitalPartnerCustomer != null ? ((HospitalPartnerCustomerOutcome)hospitalPartnerCustomer.Outcome).GetDescription() : HospitalPartnerCustomerOutcome.NotCalled.GetDescription(),
                                                                               Care = care,
                                                                               LastModified = hospitalPartnerCustomer != null ? hospitalPartnerCustomer.DataRecorderMetaData.DateModified : null,
                                                                               Result = result,
                                                                               Recommendation = recommendation,
                                                                               Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                                                                               Address = Mapper.Map<Address, AddressViewModel>(customer.Address),
                                                                               ShippingMode = shippingDetail != null ? "Paper" : "Online",
                                                                               MailedStatus = shippingDetail != null ? shippingDetail.Status.ToString() : "Online",
                                                                               MailedOn = shippingDetail != null ? shippingDetail.ShipmentDate : null,
                                                                               HospitalPartnerName = hospitalPartnername ?? "N/A",
                                                                               CorporateSponsor = corporateAccountName ?? "N/A",
                                                                               TestSummary = pairTestSummary,
                                                                               PrimaryCarePhysicianName = primaryCarePhysician != null ? primaryCarePhysician.Name.FullName : "N/A",
                                                                               Activities = GetHospitalPartnerCustomerActivities(customerActivities, idNamePairs),
                                                                               PrimaryCare = primaryCareAnswer,
                                                                               MammogramProstateScreening = mammogramProstateScreeningAnswer,
                                                                               Colonoscopy = colonoscopyAnswer,
                                                                               Cancer = cancerAnswer,
                                                                               InitialCallDate = initialCallDate,
                                                                               WeightBariatric = weightBariatricAnswer,
                                                                               PostScreeningFollowUpNotes = postScreeningNotes,
                                                                              // PreferredLanguage = string.IsNullOrEmpty(customer.PreferredLanguage) ? "N/A" : customer.PreferredLanguage,
                                                                               PreferredLanguage = preferredLanguage,
                                                                               BestTimeToCall = customer.BestTimeToCall.HasValue && customer.BestTimeToCall.Value > 0 ? ((BestTimeToCall)customer.BestTimeToCall).GetDescription() : "N/A",
                                                                               EventCustomerId = ec.Id,
                                                                               HasCannedMessage = (hospitalPartner != null && !string.IsNullOrEmpty(hospitalPartner.CannedMessage) || hospitalFacility != null && !string.IsNullOrEmpty(hospitalFacility.CannedMessage)),
                                                                               IsCannedMessageSent = eventCustomerNotification != null,
                                                                               Ssn = (eventHospitalPartner != null && eventHospitalPartner.CaptureSsn && !string.IsNullOrEmpty(customer.Ssn) && customer.Ssn.Length >= 9)
                                                                                           ? customer.Ssn.Substring(0, 3) + "-" + customer.Ssn.Substring(3, 2) + "-" + customer.Ssn.Substring(customer.Ssn.Length - 4)//"XXX-XX-" + customer.Ssn.Substring(customer.Ssn.Length - 4)
                                                                                           : string.Empty,//"N/A"
                                                                               HospitalFacility = string.IsNullOrEmpty(hospitalFacilityName) ? "N/A" : hospitalFacilityName,
                                                                               ShowScannedDocumentUrl = showScannedDocumentUrl,
                                                                               ScannedDocumentUrl = scannedDocumentUrl,
                                                                               MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId
                                                                           });
                                                });

            model.Collection = customerModels;
            return model;
        }

        public IEnumerable<HospitalPartnerCustomerActivityViewModel> GetHospitalPartnerCustomerActivities(IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers, IEnumerable<OrderedPair<long, string>> idNamePairs)
        {
            if (hospitalPartnerCustomers != null && hospitalPartnerCustomers.Count() > 0)
            {
                return
                    hospitalPartnerCustomers.Select(
                        hospitalPartnerCustomer => new HospitalPartnerCustomerActivityViewModel
                                                       {
                                                           Status = ((HospitalPartnerCustomerStatus)hospitalPartnerCustomer.Status).GetDescription(),
                                                           Outcome = ((HospitalPartnerCustomerOutcome)hospitalPartnerCustomer.Outcome).GetDescription(),
                                                           Notes = hospitalPartnerCustomer.Notes,
                                                           UpdateOn =
                                                               hospitalPartnerCustomer.DataRecorderMetaData.DateModified.HasValue
                                                                   ? hospitalPartnerCustomer.DataRecorderMetaData.DateModified.Value
                                                                   : hospitalPartnerCustomer.DataRecorderMetaData.DateCreated,
                                                           UpdatedBy =
                                                               idNamePairs.Where(cc => cc.FirstValue ==
                                                                   (hospitalPartnerCustomer.DataRecorderMetaData.DataRecorderModifier != null
                                                                        ? hospitalPartnerCustomer.DataRecorderMetaData.DataRecorderModifier.Id
                                                                        : hospitalPartnerCustomer.DataRecorderMetaData.DataRecorderCreator.Id)
                                                                        ).First().SecondValue
                                                       }).ToList();
            }
            return null;
        }
    }
}
