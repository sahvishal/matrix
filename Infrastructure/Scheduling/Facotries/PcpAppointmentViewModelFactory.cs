using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class PcpAppointmentViewModelFactory : IPcpAppointmentViewModelFactory
    {
        public IEnumerable<PcpAppointmentViewModel> Create(IEnumerable<ViewPcpAppointmentDisposition> vwPcpDispositions, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags,
            IEnumerable<PrimaryCarePhysician> primaryCarePhysician, IEnumerable<OrderedPair<long, string>> agentOrderedPairs, EventVolumeListModel eventListModel,
            IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<PcpDisposition> pcpDispositions, IEnumerable<CustomerEligibility> customerEligibilities)
        {
            var pcpAppointmentCollection = new List<PcpAppointmentViewModel>();

            foreach (var vwData in vwPcpDispositions)
            {
                var eventCustomer = eventCustomers.First(x => x.Id == vwData.EventCustomerId);

                var customerId = eventCustomer.CustomerId;
                var eventId = eventCustomer.EventId;
                var customerEligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == customerId);

                var customer = customers.First(c => c.CustomerId == customerId);
                var eventModel = eventListModel.Collection.First(x => x.EventCode == eventId);

                var pcp = primaryCarePhysician.FirstOrDefault(x => x.CustomerId == customerId);
                var pcpAppointment = pcpAppointments.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id);

                var customTags = "N/A";

                if (corporateCustomerCustomTags.Any())
                {
                    var customerCustomTag = corporateCustomerCustomTags.Where(x => x.CustomerId == customerId).OrderByDescending(x => x.DataRecorderMetaData.DateCreated).Select(x => x.Tag);
                    if (!customerCustomTag.IsNullOrEmpty())
                    {
                        customTags = string.Join(", ", customerCustomTag);
                    }
                }
                var eligibilityStatus = "N/A";
                if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
                {
                    if (customerEligibility.IsEligible.Value)
                        eligibilityStatus = EligibleStatus.Yes.ToString();
                    else
                        eligibilityStatus = EligibleStatus.No.ToString();
                }

                var pcpAppointmentViewModel = GetPcpAppointmentViewModel(customerId, customer, customTags, eligibilityStatus, eventModel, pcp);

                if (vwData.PcpDispositionId <= 0 && pcpAppointment != null)
                {
                    pcpAppointmentViewModel.ModifiedByAgentName = "N/A";
                    pcpAppointmentViewModel.AgentName = "N/A";

                    if (pcpAppointment.ModifiedBy.HasValue)
                    {
                        var agent = agentOrderedPairs.First(x => x.FirstValue == pcpAppointment.ModifiedBy.Value);
                        pcpAppointmentViewModel.AppointmentModifiedOn = pcpAppointment.ModifiedOn;
                        pcpAppointmentViewModel.ModifiedByAgentName = agent.SecondValue;
                    }

                    if (pcpAppointment.CreatedBy.HasValue)
                    {
                        var agent = agentOrderedPairs.First(x => x.FirstValue == pcpAppointment.CreatedBy.Value);
                        pcpAppointmentViewModel.AppointmentCreatedOn = pcpAppointment.CreatedOn;
                        pcpAppointmentViewModel.AgentName = agent.SecondValue;
                    }

                    pcpAppointmentViewModel.AppointmentCreatedOn = pcpAppointment.CreatedOn;

                    pcpAppointmentViewModel.AppointmentDateTime = pcpAppointment.AppointmentOn;
                    pcpAppointmentCollection.Add(pcpAppointmentViewModel);
                }

                if (vwData.PcpDispositionId > 0)
                {
                    var disposition = pcpDispositions.First(x => x.PcpDispositionId == vwData.PcpDispositionId);

                    var agent = agentOrderedPairs.First(x => x.FirstValue == disposition.DataRecorderMetaData.DataRecorderCreator.Id);

                    pcpAppointmentViewModel.PcpDisposition = disposition.Disposition.GetDescription();
                    pcpAppointmentViewModel.DispositionsCreatedBy = agent.SecondValue;
                    pcpAppointmentViewModel.DispositionsCreatedOn = disposition.DataRecorderMetaData.DateCreated;
                    pcpAppointmentViewModel.Notes = string.IsNullOrEmpty(disposition.Notes) ? "N/A" : disposition.Notes;

                    pcpAppointmentCollection.Add(pcpAppointmentViewModel);
                }
            }

            return pcpAppointmentCollection;
        }

        private static PcpAppointmentViewModel GetPcpAppointmentViewModel(long customerId, Customer customer, string customTags,
            string eligibilityStatus, EventVolumeModel eventModel, PrimaryCarePhysician pcp)
        {
            var pcpAppointmentViewModel = new PcpAppointmentViewModel
            {
                CustomerId = customerId,
                CustomerName = customer.NameAsString,
                InsuranceId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                Hicn = string.IsNullOrEmpty(customer.Hicn) ? "N/A" : customer.Hicn,
                Mbi = string.IsNullOrEmpty(customer.Mbi) ? "N/A" : customer.Mbi,
                Tag = string.IsNullOrEmpty(customer.Tag) ? "N/A" : customer.Tag,
                CustomerTag = customTags,
                IsEligible = eligibilityStatus,
                EventId = eventModel.EventCode,
                EventName = eventModel.Location,
                EventDate = eventModel.EventDate,
                Pod = eventModel.Pod,
                PcpName = pcp != null ? pcp.Name.FullName : "N/A",
                PcpPhoneNumber = pcp != null && pcp.Primary != null && !string.IsNullOrEmpty(pcp.Primary.ToString()) ? pcp.Primary.ToString() : "N/A",
                PcpFax = pcp != null && pcp.Fax != null && !string.IsNullOrEmpty(pcp.Fax.ToString()) ? pcp.Fax.ToString() : "N/A",
            };
            return pcpAppointmentViewModel;
        }
    }
}
