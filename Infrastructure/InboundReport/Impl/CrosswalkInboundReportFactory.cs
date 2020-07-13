using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class CrosswalkInboundReportFactory : ICrosswalkInboundReportFactory
    {
        private readonly ISettings _settings;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;

        private const string FileNamePrefix = "GWC_CW";

        public CrosswalkInboundReportFactory(ISettings settings, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer)
        {
            _settings = settings;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
        }

        public List<CrosswalkInboundViewModel> Create(IEnumerable<Customer> customers, IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns,
            IEnumerable<Relationship> relationships, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events, CorporateAccount corporateAccount,
            IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests, IEnumerable<OrderedPair<long, long>> customerEventScreeningTestIdFileIdPairs)
        {
            var collection = new List<CrosswalkInboundViewModel>();

            ResultPdfPostedXml resultPosted = null;
            if (!customers.IsNullOrEmpty())
            {
                var resultPostedToPlanFileName = Path.Combine(_settings.ResultPostedToPlanPath, string.Format("ResultPostedto_{0}.xml", corporateAccount.Tag));
                resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);
                resultPosted = resultPosted == null || resultPosted.Customer.IsNullOrEmpty() ? new ResultPdfPostedXml { Customer = new List<CustomerInfo>() } : resultPosted;
            }

            foreach (var eventCustomerResult in eventCustomerResults)
            {
                var customer = customers.FirstOrDefault(x => x.CustomerId == eventCustomerResult.CustomerId);
                if (customer == null) continue;

                var theEvent = events.FirstOrDefault(x => x.Id == eventCustomerResult.EventId);
                if (theEvent == null) continue;

                var chaseOutbound = chaseOutbounds.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                if (chaseOutbound == null) continue;
                var customerChaseCampaign = !customerChaseCampaigns.IsNullOrEmpty() ? customerChaseCampaigns.FirstOrDefault(x => x.CustomerId == customer.CustomerId) : null;
                var campaign = !chaseCampaigns.IsNullOrEmpty() && customerChaseCampaign != null ? chaseCampaigns.FirstOrDefault(x => x.Id == customerChaseCampaign.ChaseCampaignId) : null;
                var relationship = !relationships.IsNullOrEmpty() && chaseOutbound.RelationshipId.HasValue ? relationships.FirstOrDefault(x => x.Id == chaseOutbound.RelationshipId.Value) : null;
                var eventCustomer = eventCustomers.First(x => x.CustomerId == customer.CustomerId);

                var postedPdf = resultPosted.Customer.FirstOrDefault(x => x.CustomerId == eventCustomerResult.CustomerId && x.EventId == eventCustomerResult.EventId);
                /*if (postedPdf != null)
                {
                    var eventScreeningTests = customerEventScreeningTests.Where(x => x.EventCustomerResultId == eventCustomerResult.Id);
                    if (eventScreeningTests.Any())
                    {
                        if (customerEventScreeningTestIdFileIdPairs.Any(x => eventScreeningTests.Select(est => est.Id).Contains(x.FirstValue)))
                            continue;
                    }
                }*/

                var crosswalkInboundViewModel = new CrosswalkInboundViewModel
                {
                    TenantId = chaseOutbound.TenantId,
                    ClientId = chaseOutbound.ClientId,
                    CampaignId = campaign != null ? campaign.CampaignId : "",
                    IndividualIDNumber = chaseOutbound.IndividualId,
                    ContractNumber = chaseOutbound.ContractNumber,
                    ContractPersonNumber = chaseOutbound.ContractPersonNumber,
                    ConsumerId = chaseOutbound.ConsumerId,
                    ExtractDate = DateTime.Now,
                    RelationshipCode = relationship != null ? "\"" + relationship.Code + "\"" : "",
                    LastName = customer.Name.LastName,
                    FirstName = customer.Name.FirstName,
                    BirthDate = customer.DateOfBirth,
                    FileName = GetResultPdfFileName(chaseOutbound, customer, eventCustomerResult, corporateAccount),
                    ServiceStartDate = theEvent.EventDate,
                    ServiceEndDate = theEvent.EventDate,
                    EventId = eventCustomer.EventId,
                    CustomerId = eventCustomer.CustomerId,
                    ClientProviderID = "NURSE",
                    ProjectTypeName = "Wkly Mbr",
                    Npi = "Dr. Pham",
                    DocumentID = customer.CustomerId.ToString()
                };

                collection.Add(crosswalkInboundViewModel);
            }

            return collection;
        }

        public ListModelBase<CrosswalkLabInboundViewModel, CrosswalkLabInboundFilter> CreateCrosswalkLabInboundList(IEnumerable<Customer> customers, IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<CustomerChaseCampaign> customerChaseCampaigns,
            IEnumerable<ChaseCampaign> chaseCampaigns, IEnumerable<Relationship> relationships, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events,
            IEnumerable<CustomerEventScreeningTests> customerEventScreeningTests, IEnumerable<OrderedPair<long, long>> customerEventScreeningTestIdFileIdPairs, IEnumerable<File> files)
        {
            var collection = new List<CrosswalkLabInboundViewModel>();

            foreach (var eventCustomerResult in eventCustomerResults)
            {
                var customer = customers.FirstOrDefault(x => x.CustomerId == eventCustomerResult.CustomerId);
                if (customer == null) continue;

                var theEvent = events.FirstOrDefault(x => x.Id == eventCustomerResult.EventId);
                if (theEvent == null) continue;

                var chaseOutbound = chaseOutbounds.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                if (chaseOutbound == null) continue;
                var customerChaseCampaign = !customerChaseCampaigns.IsNullOrEmpty() ? customerChaseCampaigns.FirstOrDefault(x => x.CustomerId == customer.CustomerId) : null;
                var campaign = !chaseCampaigns.IsNullOrEmpty() && customerChaseCampaign != null ? chaseCampaigns.FirstOrDefault(x => x.Id == customerChaseCampaign.ChaseCampaignId) : null;
                var relationship = !relationships.IsNullOrEmpty() && chaseOutbound.RelationshipId.HasValue ? relationships.FirstOrDefault(x => x.Id == chaseOutbound.RelationshipId.Value) : null;
                var eventCustomer = eventCustomers.First(x => x.CustomerId == customer.CustomerId);

                var ifobtCustomerEventScreeningTest = customerEventScreeningTests.FirstOrDefault(x => x.EventCustomerResultId == eventCustomerResult.Id && x.TestId == (long)TestType.IFOBT);
                var microAlbuminCustomerEventScreeningTest = customerEventScreeningTests.FirstOrDefault(x => x.EventCustomerResultId == eventCustomerResult.Id && x.TestId == (long)TestType.UrineMicroalbumin);

                var ifobtPair = ifobtCustomerEventScreeningTest != null ? customerEventScreeningTestIdFileIdPairs.FirstOrDefault(x => x.FirstValue == ifobtCustomerEventScreeningTest.Id) : null;
                var ifobtFile = ifobtPair != null ? files.FirstOrDefault(x => x.Id == ifobtPair.SecondValue) : null;

                var microAlbuminPair = microAlbuminCustomerEventScreeningTest != null ? customerEventScreeningTestIdFileIdPairs.FirstOrDefault(x => x.FirstValue == microAlbuminCustomerEventScreeningTest.Id) : null;
                var microAlbuminFile = microAlbuminPair != null ? files.FirstOrDefault(x => x.Id == microAlbuminPair.SecondValue) : null;

                if (ifobtFile != null)
                {
                    collection.Add(new CrosswalkLabInboundViewModel
                    {
                        TenantId = chaseOutbound.TenantId,
                        ClientId = chaseOutbound.ClientId,
                        CampaignId = campaign != null ? campaign.CampaignId : "",
                        IndividualIDNumber = chaseOutbound.IndividualId,
                        ContractNumber = chaseOutbound.ContractNumber,
                        ContractPersonNumber = chaseOutbound.ContractPersonNumber,
                        ConsumerId = chaseOutbound.ConsumerId,
                        ExtractDate = DateTime.Now,
                        RelationshipCode = relationship != null ? "\"" + relationship.Code + "\"" : "",
                        LastName = customer.Name.LastName,
                        FirstName = customer.Name.FirstName,
                        BirthDate = customer.DateOfBirth,
                        FileName = eventCustomer.CustomerId + "_" + TestType.IFOBT + ".pdf",
                        ServiceStartDate = theEvent.EventDate,
                        ServiceEndDate = theEvent.EventDate,
                        EventId = eventCustomer.EventId,
                        CustomerId = eventCustomer.CustomerId,
                        TestPdf = ifobtFile.Path,
                        ClientProviderID = "NURSE",
                        ProjectTypeName = "Wkly Mbr",
                        Npi = "Dr. Pham",
                        DocumentID = ifobtFile.Id.ToString()
                    });
                }

                if (microAlbuminFile != null)
                {
                    collection.Add(new CrosswalkLabInboundViewModel
                    {
                        TenantId = chaseOutbound.TenantId,
                        ClientId = chaseOutbound.ClientId,
                        CampaignId = campaign != null ? campaign.CampaignId : "",
                        IndividualIDNumber = chaseOutbound.IndividualId,
                        ContractNumber = chaseOutbound.ContractNumber,
                        ContractPersonNumber = chaseOutbound.ContractPersonNumber,
                        ConsumerId = chaseOutbound.ConsumerId,
                        ExtractDate = DateTime.Now,
                        RelationshipCode = relationship != null ? "\"" + relationship.Code + "\"" : "",
                        LastName = customer.Name.LastName,
                        FirstName = customer.Name.FirstName,
                        BirthDate = customer.DateOfBirth,
                        FileName = eventCustomer.CustomerId + "_" + TestType.UrineMicroalbumin + ".pdf",
                        ServiceStartDate = theEvent.EventDate,
                        ServiceEndDate = theEvent.EventDate,
                        EventId = eventCustomer.EventId,
                        CustomerId = eventCustomer.CustomerId,
                        TestPdf = microAlbuminFile.Path,
                        ClientProviderID = "NURSE",
                        ProjectTypeName = "Wkly Mbr",
                        Npi = "Dr. Pham",
                        DocumentID = microAlbuminFile.Id.ToString()
                    });
                }
            }

            return new CrosswalkLabInboundListModel
            {
                Collection = collection
            };
        }

        private string GetResultPdfFileName(ChaseOutbound chaseOutbound, Customer customer, EventCustomerResult ecr, CorporateAccount corporateAccount)
        {
            string fileName;

            if (!string.IsNullOrEmpty(chaseOutbound.ClientId))
                fileName = string.Format("{0}_{1}.pdf", FileNamePrefix, chaseOutbound.ClientId);

            else if (!string.IsNullOrEmpty(customer.InsuranceId))
                fileName = string.Format("{0}_{1}.pdf", FileNamePrefix, customer.InsuranceId);

            else
                fileName = string.Format("{0}_NoMemberId_{1}.pdf", FileNamePrefix, customer.CustomerId);

            if (corporateAccount.MarkPennedBack && ecr.IsPennedBack)
                fileName += "_" + corporateAccount.PennedBackText;

            return fileName;
        }
    }
}
