using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class OutreachCallReportListModelFactory : IOutreachCallReportListModelFactory
    {
        public OutreachCallReportListModel Create(List<Customer> customers, IEnumerable<Core.Sales.Domain.CorporateCustomerCustomTag> customerTags, IEnumerable<Call> calls, List<EventCustomer> eventCustomers,
            EventBasicInfoListModel eventBasicInfoListModel, List<Appointment> appointments, IEnumerable<OrderedPair<long, string>> registeredbyAgentNameIdPair, IEnumerable<CallCenterNotes> callCenterCallNotes,
            IEnumerable<OrderedPair<long, long>> orderedPairsCustomersShippingDetails, IEnumerable<ShippingDetail> customersShippingDetails, List<Address> addresses, IEnumerable<CallQueue> callQueues,
            IEnumerable<CustomerEligibility> customerEligibilities)
        {
            var model = new OutreachCallReportListModel();
            var collection = new List<OutreachCallReportModel>();
            var events = eventBasicInfoListModel != null && eventBasicInfoListModel.Events != null ? eventBasicInfoListModel.Events : null;

            calls.ToList().ForEach(c =>
            {

                var customer = (from cd in customers where cd.CustomerId == c.CalledCustomerId select cd).First();
                
                var customerEligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                Appointment appointment = null;
                var eventDetail = events != null ? events.SingleOrDefault(x => x.Id == c.EventId) : null;
                if (eventCustomers != null)
                {
                    var eventCustomer = eventCustomers.SingleOrDefault(x => x.EventId == c.EventId && x.CustomerId == c.CalledCustomerId);

                    if (eventCustomer != null && eventCustomer.AppointmentId.HasValue)
                    {
                        appointment = appointments.Single(x => x.Id == eventCustomer.AppointmentId.Value);
                    }
                }

                var callQueueName = string.Empty;

                if (c.CallQueueId.HasValue)
                    callQueueName = callQueues.Single(x => x.Id == c.CallQueueId.Value).Name;

                var customerTag = "N/A";
                if (customerTags != null && customerTags.Any())
                {
                    var customTag = (from ct in customerTags where ct.CustomerId == c.CalledCustomerId select ct.Tag).ToArray();

                    if (customTag != null && customTag.Any())
                    {
                        customerTag = string.Join(", ", customTag);
                    }
                }

                ProspectCustomerTag prospectCustomerTag;
                Enum.TryParse(c.Disposition, out prospectCustomerTag);
                var isDefined = Enum.IsDefined(typeof(ProspectCustomerTag), prospectCustomerTag);

                var agentName = "N/A";
                if (registeredbyAgentNameIdPair != null && registeredbyAgentNameIdPair.Any())
                {
                    agentName = registeredbyAgentNameIdPair.Single(ap => ap.FirstValue == c.CreatedByOrgRoleUserId).SecondValue;
                }

                var state = "N/A";
                if (orderedPairsCustomersShippingDetails != null && orderedPairsCustomersShippingDetails.Any())
                {
                    var shippingDetais = orderedPairsCustomersShippingDetails.Where(x => x.FirstValue == c.CalledCustomerId);

                    if (shippingDetais != null && shippingDetais.Any())
                    {
                        var shippingDeatilsIds = shippingDetais.Select(x => x.SecondValue);
                        var customerShippingAdderss = customersShippingDetails.FirstOrDefault(x => shippingDeatilsIds.Contains(x.Id));
                        if (customerShippingAdderss != null)
                        {
                            var address = addresses.FirstOrDefault(x => x.Id == customerShippingAdderss.ShippingAddress.Id);
                            state = address.State;
                        }
                        else if (customer.Address != null)
                        {
                            state = customer.Address.State;
                        }
                    }
                    else if (customer.Address != null)
                    {
                        state = customer.Address.State;
                    }
                }
                else if (customer.Address != null)
                {
                    state = customer.Address.State;
                }

                var isEligible = "N/A";
                if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
                {
                    if (customerEligibility.IsEligible.Value)
                        isEligible = EligibleStatus.Yes.ToString();
                    else
                        isEligible = EligibleStatus.No.ToString();
                }

                var customerZipCode = "N/A";
                if (customer.Address != null)
                {
                    if (customer.Address.ZipCode != null)
                        customerZipCode = customer.Address.ZipCode.ToString();
                }

                var outreachTime = String.Format("{0:hh:mm tt}", DateTime.Today);
                var callOutreachTime = String.Format("{0:hh:mm tt}", c.CallDateTime);

                var outreachcallQueueModel = new OutreachCallReportModel
                {
                    CustomerId = c.CalledCustomerId,
                    Name = customer.Name,
                    MemberId = customer.InsuranceId,
                    MedicareId = customer.Hicn,
                    DateOfBirth = customer.DateOfBirth,
                    EventDate = eventDetail != null ? eventDetail.EventDate : (DateTime?)null,
                    EventId = eventDetail != null ? eventDetail.Id.ToString() : "N/A",
                    AppointmentTime = appointment != null ? appointment.StartTime : (DateTime?)null,
                    AppointmentBookedDate = appointment != null ? appointment.DateCreated : (DateTime?)null,
                    Tag = customer.Tag,
                    SponsoredBy = eventDetail != null ? eventDetail.Sponsor : "N/A",
                    Outcome = ((CallStatus)c.Status).GetDescription(),
                    Disposition = c.Disposition != string.Empty && isDefined ? prospectCustomerTag.GetDescription() : "N/A",
                    Reason = c.NotInterestedReasonId.HasValue && c.NotInterestedReasonId.Value > 0 ? ((NotInterestedReason)c.NotInterestedReasonId.Value).GetDescription() : "N/A",
                    OutreachDate = c.CallDateTime,
                    OutreachTime = (callOutreachTime != outreachTime) ? callOutreachTime : "N/A",
                    OutreachType = "Outbound",
                    CustomTags = customerTag,
                    Agent = agentName,
                    State = state,
                    Notes = callCenterCallNotes.Where(cn => cn.CallId == c.Id).Select(x => x).ToArray(),
                    ZipCode = customerZipCode,
                    IsEligible = isEligible,
                    CallQueue = callQueueName,
                    CalledCustomTags = !string.IsNullOrEmpty(c.CustomTags) ? c.CustomTags : "N/A",
                    ProductType = c.ProductTypeId.HasValue && c.ProductTypeId.Value > 0 ? ((ProductType)c.ProductTypeId.Value).GetDescription() : "N/A"
                };

                collection.Add(outreachcallQueueModel);
            });

            model.Collection = collection;
            return model;
        }

        public HourlyOutreachCallReportListModel CreateHourlyModel(List<Customer> customers, IEnumerable<Core.Sales.Domain.CorporateCustomerCustomTag> customerTags, IEnumerable<Call> calls, List<EventCustomer> eventCustomers,
        EventBasicInfoListModel eventBasicInfoListModel, List<Appointment> appointments, IEnumerable<OrderedPair<long, string>> registeredbyAgentNameIdPair, IEnumerable<CallCenterNotes> callCenterCallNotes,
        IEnumerable<OrderedPair<long, long>> orderedPairsCustomersShippingDetails, IEnumerable<ShippingDetail> customersShippingDetails, List<Address> addresses, IEnumerable<CallQueue> callQueues,
        IEnumerable<CustomerEligibility> customerEligibilities)
        {
            var model = new HourlyOutreachCallReportListModel();
            var collection = new List<HourlyOutreachCallReportModel>();
            var events = eventBasicInfoListModel != null && eventBasicInfoListModel.Events != null ? eventBasicInfoListModel.Events : null;

            calls.ToList().ForEach(c =>
            {

                var customer = (from cd in customers where cd.CustomerId == c.CalledCustomerId select cd).First();
                var customerEligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                Appointment appointment = null;
                var eventDetail = events != null ? events.SingleOrDefault(x => x.Id == c.EventId) : null;
                if (eventCustomers != null)
                {
                    var eventCustomer = eventCustomers.SingleOrDefault(x => x.EventId == c.EventId && x.CustomerId == c.CalledCustomerId);

                    if (eventCustomer != null && eventCustomer.AppointmentId.HasValue)
                    {
                        appointment = appointments.Single(x => x.Id == eventCustomer.AppointmentId.Value);
                    }
                }

                var callQueueName = string.Empty;

                if (c.CallQueueId.HasValue)
                    callQueueName = callQueues.Single(x => x.Id == c.CallQueueId.Value).Name;

                var customerTag = "N/A";
                if (customerTags != null && customerTags.Any())
                {
                    var customTag = (from ct in customerTags where ct.CustomerId == c.CalledCustomerId select ct.Tag).ToArray();

                    if (customTag != null && customTag.Any())
                    {
                        customerTag = string.Join(", ", customTag);
                    }
                }

                ProspectCustomerTag prospectCustomerTag;
                Enum.TryParse(c.Disposition, out prospectCustomerTag);
                var isDefined = Enum.IsDefined(typeof(ProspectCustomerTag), prospectCustomerTag);

                var agentName = "N/A";
                if (registeredbyAgentNameIdPair != null && registeredbyAgentNameIdPair.Any())
                {
                    agentName = registeredbyAgentNameIdPair.Single(ap => ap.FirstValue == c.CreatedByOrgRoleUserId).SecondValue;
                }

                var state = "N/A";
                if (orderedPairsCustomersShippingDetails != null && orderedPairsCustomersShippingDetails.Any())
                {
                    var shippingDetais = orderedPairsCustomersShippingDetails.Where(x => x.FirstValue == c.CalledCustomerId);

                    if (shippingDetais != null && shippingDetais.Any())
                    {
                        var shippingDeatilsIds = shippingDetais.Select(x => x.SecondValue);
                        var customerShippingAdderss = customersShippingDetails.FirstOrDefault(x => shippingDeatilsIds.Contains(x.Id));
                        if (customerShippingAdderss != null)
                        {
                            var address = addresses.FirstOrDefault(x => x.Id == customerShippingAdderss.ShippingAddress.Id);
                            state = address.State;
                        }
                        else if (customer.Address != null)
                        {
                            state = customer.Address.State;
                        }
                    }
                    else if (customer.Address != null)
                    {
                        state = customer.Address.State;
                    }
                }
                else if (customer.Address != null)
                {
                    state = customer.Address.State;
                }

                var isEligible = "N/A";
                if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
                {
                    if (customerEligibility.IsEligible.Value)
                        isEligible = EligibleStatus.Yes.ToString();
                    else
                        isEligible = EligibleStatus.No.ToString();
                }

                var customerZipCode = "N/A";
                if (customer.Address != null)
                {
                    if (customer.Address.ZipCode != null)
                        customerZipCode = customer.Address.ZipCode.ToString();
                }

                var outreachTime = String.Format("{0:hh:mm tt}", DateTime.Today);
                var callOutreachTime = String.Format("{0:hh:mm tt}", c.CallDateTime);

                var outreachcallQueueModel = new HourlyOutreachCallReportModel
                {
                    CustomerId = c.CalledCustomerId,
                    EventDate = eventDetail != null ? eventDetail.EventDate : (DateTime?)null,
                    EventId = eventDetail != null ? eventDetail.Id.ToString() : "N/A",
                    AppointmentTime = appointment != null ? appointment.StartTime : (DateTime?)null,
                    AppointmentBookedDate = appointment != null ? appointment.DateCreated : (DateTime?)null,
                    Tag = customer.Tag,
                    SponsoredBy = eventDetail != null ? eventDetail.Sponsor : "N/A",
                    Outcome = ((CallStatus)c.Status).GetDescription(),
                    Disposition = c.Disposition != string.Empty && isDefined ? prospectCustomerTag.GetDescription() : "N/A",
                    Reason = c.NotInterestedReasonId.HasValue && c.NotInterestedReasonId.Value > 0 ? ((NotInterestedReason)c.NotInterestedReasonId.Value).GetDescription() : "N/A",
                    OutreachDate = c.CallDateTime,
                    OutreachTime = (callOutreachTime != outreachTime) ? callOutreachTime : "N/A",
                    OutreachType = "Outbound",
                    CustomTags = customerTag,
                    Agent = agentName,
                    State = state,
                    Notes = callCenterCallNotes.Where(cn => cn.CallId == c.Id).Select(x => x).ToArray(),
                    ZipCode = customerZipCode,
                    IsEligible = isEligible,
                    CallQueue = callQueueName,
                    CalledCustomTags = !string.IsNullOrEmpty(c.CustomTags) ? c.CustomTags : "N/A"
                };

                collection.Add(outreachcallQueueModel);
            });

            model.Collection = collection;
            return model;
        }

        public HousecallOutreachCallReportListModel CreateHousecallModel(List<Customer> customers, IEnumerable<Call> calls, EventBasicInfoListModel eventBasicInfoListModel,
            IEnumerable<OrderedPair<long, long>> orderedPairsCustomersShippingDetails, IEnumerable<ShippingDetail> customersShippingDetails, List<Address> addresses,
            List<EventCustomer> eventCustomers, List<Appointment> appointments)
        {
            var model = new HousecallOutreachCallReportListModel();
            var collection = new List<HousecallOutreachReportModel>();
            var events = eventBasicInfoListModel != null && eventBasicInfoListModel.Events != null ? eventBasicInfoListModel.Events : null;

            calls.ToList().ForEach(c =>
            {
                var customer = (from cd in customers where cd.CustomerId == c.CalledCustomerId select cd).First();

                var eventDetail = events != null ? events.SingleOrDefault(x => x.Id == c.EventId) : null;
                Appointment appointment = null;
                if (eventCustomers != null)
                {
                    var eventCustomer = eventCustomers.SingleOrDefault(x => x.EventId == c.EventId && x.CustomerId == c.CalledCustomerId);

                    if (eventCustomer != null && eventCustomer.AppointmentId.HasValue)
                    {
                        appointment = appointments.Single(x => x.Id == eventCustomer.AppointmentId.Value);
                    }
                }

                ProspectCustomerTag prospectCustomerTag;
                Enum.TryParse(c.Disposition, out prospectCustomerTag);
                var isDefined = Enum.IsDefined(typeof(ProspectCustomerTag), prospectCustomerTag);

                var state = "N/A";
                if (orderedPairsCustomersShippingDetails != null && orderedPairsCustomersShippingDetails.Any())
                {
                    var shippingDetais = orderedPairsCustomersShippingDetails.Where(x => x.FirstValue == c.CalledCustomerId);

                    if (shippingDetais != null && shippingDetais.Any())
                    {
                        var shippingDeatilsIds = shippingDetais.Select(x => x.SecondValue);
                        var customerShippingAdderss = customersShippingDetails.FirstOrDefault(x => shippingDeatilsIds.Contains(x.Id));
                        if (customerShippingAdderss != null)
                        {
                            var address = addresses.FirstOrDefault(x => x.Id == customerShippingAdderss.ShippingAddress.Id);
                            state = address.State;
                        }
                        else if (customer.Address != null)
                        {
                            state = customer.Address.State;
                        }
                    }
                    else if (customer.Address != null)
                    {
                        state = customer.Address.State;
                    }
                }
                else if (customer.Address != null)
                {
                    state = customer.Address.State;
                }


                var customerZipCode = "N/A";
                if (customer.Address != null)
                {
                    if (customer.Address.ZipCode != null)
                        customerZipCode = customer.Address.ZipCode.ToString();
                }

                var outreachTime = String.Format("{0:hh:mm tt}", DateTime.Today);
                var callOutreachTime = String.Format("{0:hh:mm tt}", c.CallDateTime);

                var outreachcallQueueModel = new HousecallOutreachReportModel
                {
                    CustomerId = c.CalledCustomerId,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    State = state,
                    ZipCode = customerZipCode,
                    MemberId = customer.InsuranceId,
                    Hicn = customer.Hicn,
                    OutreachDate = c.CallDateTime,
                    OutreachTime = (callOutreachTime != outreachTime) ? callOutreachTime : "N/A",
                    Outcome = ((CallStatus)c.Status).GetDescription(),
                    Disposition = c.Disposition != string.Empty && isDefined ? prospectCustomerTag.GetDescription() : "N/A",
                    Reason = c.NotInterestedReasonId.HasValue && c.NotInterestedReasonId.Value > 0 ? ((NotInterestedReason)c.NotInterestedReasonId.Value).GetDescription() : "N/A",
                    EventDate = eventDetail != null ? eventDetail.EventDate : (DateTime?)null,
                    EventId = eventDetail != null ? eventDetail.Id.ToString() : "N/A",
                    EventTime = appointment != null ? appointment.StartTime : (DateTime?)null,
                };

                collection.Add(outreachcallQueueModel);
            });

            model.Collection = collection;
            return model;
        }

    }


}
