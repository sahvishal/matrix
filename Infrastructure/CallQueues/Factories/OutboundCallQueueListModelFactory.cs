using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Call = Falcon.App.Core.CallCenter.Domain.Call;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class OutboundCallQueueListModelFactory : IOutboundCallQueueListModelFactory
    {
        private readonly INotesViewModelFactory _notesViewModelFactory;

        public OutboundCallQueueListModelFactory(INotesViewModelFactory notesViewModelFactory)
        {

            _notesViewModelFactory = notesViewModelFactory;
        }

        public OutboundCallQueueListModel Create(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<ProspectCustomer> prospectCustomers,
            IEnumerable<CallQueueCriteria> callQueueCriterias, IEnumerable<Criteria> criterias, IEnumerable<CallQueueCustomerCall> callQueueCustomerCalls, IEnumerable<Call> calls,
            IEnumerable<CallCenterNotes> callCenterNoteses, IEnumerable<CustomerCallNotes> customerCallNotes, IEnumerable<OrderedPair<long, string>> idNamePair)
        {
            var model = new OutboundCallQueueListModel();
            var collection = new List<OutboundCallQueueViewModel>();

            callQueueCustomers.ToList().ForEach(cqc =>
             {
                 Customer customer = null;
                 var prospectCustomer = new ProspectCustomer();

                 if (cqc.CustomerId.HasValue)
                     customer = customers.FirstOrDefault(c => c.CustomerId == cqc.CustomerId.Value);

                 if (cqc.ProspectCustomerId > 0)
                     prospectCustomer = prospectCustomers.First(pc => pc.Id == cqc.ProspectCustomerId);

                 CallQueueCriteria callQueueCriteria = null;
                 var callReason = string.Empty;

                 if (callQueueCriterias != null && callQueueCriterias.Any() && criterias != null && criterias.Any())
                 {
                     if (cqc.CallQueueCriteriaId.HasValue && cqc.CallQueueCriteriaId.Value > 0)
                         callQueueCriteria = callQueueCriterias.Single(cqcs => cqcs.Id == cqc.CallQueueCriteriaId.Value);
                     if (callQueueCriteria != null)
                     {
                         var criteria = criterias.Single(c => c.Id == callQueueCriteria.CriteriaId);

                         callReason = criteria.Name;

                         if (callQueueCriteria.CriteriaId == (long)QueueCriteria.AllProspects)
                         {
                             callReason = prospectCustomer.Tag.GetDescription();

                         }
                     }
                 }

                 var prospectNotes = _notesViewModelFactory.GetProspectCustomerNotes(cqc.ProspectCustomerId ?? 0, customerCallNotes, idNamePair);
                 var email = string.Empty;
                 PhoneNumber mobilePhoneNumber = null;
                 PhoneNumber officePhoneNumber = null;

                 if (customer != null)
                 {
                     email = (customer.Email != null) ? customer.Email.ToString() : string.Empty;
                     mobilePhoneNumber = customer.OfficePhoneNumber;
                     officePhoneNumber = customer.MobilePhoneNumber;
                 }
                 else
                 {
                     email = prospectCustomer.Email != null ? prospectCustomer.Email.ToString() : string.Empty;
                 }

                 var outboundModel = new OutboundCallQueueViewModel
                 {
                     CallQueueCustomerId = cqc.Id,
                     ProspectCustomerId = cqc.ProspectCustomerId,
                     CustomerId = cqc.CustomerId,
                     FirstName = customer != null ? customer.Name.FirstName : prospectCustomer.FirstName,
                     MiddleName = customer != null ? customer.Name.MiddleName : "",
                     LastName = customer != null ? customer.Name.LastName : prospectCustomer.LastName,
                     Gender = customer != null ? customer.Gender : prospectCustomer.Gender,
                     Email = email,
                     CallBackPhoneNumber = customer != null ? customer.HomePhoneNumber : prospectCustomer.CallBackPhoneNumber,
                     MobilePhoneNumber = mobilePhoneNumber,
                     OfficePhoneNumber = officePhoneNumber,
                     DateOfBirth = customer != null ? customer.DateOfBirth : prospectCustomer.BirthDate,
                     CreatedOn = cqc.DateCreated,
                     CallReason = callReason,
                     Notes = prospectNotes,
                     ProspectCreatedOn = prospectCustomer != null && prospectCustomer.CreatedOn != DateTime.MinValue ? prospectCustomer.CreatedOn : (DateTime?)null,
                 };

                 if (callQueueCustomerCalls != null && callQueueCustomerCalls.Any())
                 {
                     var callIds = callQueueCustomerCalls.Where(cqcc => cqcc.CallQueueCustomerId == cqc.Id).Select(cqcc => cqcc.CallId).ToArray();
                     if (callIds.Any())
                     {
                         var customerCalls = calls.Where(c => callIds.Contains(c.Id)).Select(c => c);
                         var callHistoryList = new List<CallHistoryViewModel>();
                         foreach (var customerCall in customerCalls)
                         {
                             var callHistory = new CallHistoryViewModel()
                             {
                                 CallId = customerCall.Id,
                                 DateCreated = customerCall.CallDateTime
                             };

                             if (callCenterNoteses != null && callCenterNoteses.Any())
                             {
                                 var customerNotes = callCenterNoteses.Where(ccn => ccn.CallId == customerCall.Id).Select(ccn => ccn).ToArray();
                                 callHistory.Notes = customerNotes.Select(cn => new NotesViewModel() { Note = cn.Notes, EnteredOn = cn.DateCreated });
                             }

                             callHistoryList.Add(callHistory);
                         }

                         outboundModel.CallHistory = callHistoryList;
                     }
                 }

                 collection.Add(outboundModel);
             });

            model.OutboundCallQueues = collection;
            return model;
        }

        public OutboundCallQueueListModel SystemGeneratedCallQueueCustomers(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<ProspectCustomer> prospectCustomers,
            IEnumerable<CallQueueCustomerCallViewModel> callQueueCustomerCalls, IEnumerable<CallCenterNotes> callCenterNoteses, IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags)
        {
            var model = new OutboundCallQueueListModel();
            var collection = new List<OutboundCallQueueViewModel>();

            callQueueCustomers.ToList().ForEach(cqc =>
            {
                Customer customer = null;
                var prospectCustomer = new ProspectCustomer();

                if (cqc.CustomerId.HasValue)
                    customer = customers.FirstOrDefault(c => c.CustomerId == cqc.CustomerId.Value);

                if (cqc.ProspectCustomerId > 0)
                    prospectCustomer = prospectCustomers.First(pc => pc.Id == cqc.ProspectCustomerId);


                var email = string.Empty;
                PhoneNumber mobilePhoneNumber = null;
                PhoneNumber officePhoneNumber = null;

                if (customer != null)
                {
                    email = (customer.Email != null) ? customer.Email.ToString() : string.Empty;
                    mobilePhoneNumber = customer.MobilePhoneNumber;
                    officePhoneNumber = customer.OfficePhoneNumber;
                }
                else
                {
                    email = prospectCustomer.Email != null ? prospectCustomer.Email.ToString() : string.Empty;
                }

                Event theEvent = null;
                Host host = null;
                AddressViewModel eventLocation = null;
                var customTags = string.Empty;
                if (corporateCustomerCustomTags != null && corporateCustomerCustomTags.Any() && cqc.CustomerId.HasValue)
                {
                    var tags = corporateCustomerCustomTags.Where(x => x.CustomerId == cqc.CustomerId.Value).OrderByDescending(x => x.DataRecorderMetaData.DateCreated);

                    if (tags != null && tags.Any())
                    {
                        customTags = string.Join(",", tags.Select(x => x.Tag));
                    }

                }

                if (events != null && cqc.EventId.HasValue && events.Any(e => e.Id == cqc.EventId.Value))
                {
                    theEvent = events.First(e => e.Id == cqc.EventId.Value);
                    host = hosts.Single(h => h.Id == theEvent.HostId);
                    eventLocation = Mapper.Map<Address, AddressViewModel>(host.Address);
                }

                var outboundModel = OutboundCallQueueViewModel(cqc, customer, prospectCustomer, email, mobilePhoneNumber, officePhoneNumber, theEvent, host, eventLocation, customTags);

                SetHistoryViewModelList(callQueueCustomerCalls, callCenterNoteses, cqc, outboundModel);

                collection.Add(outboundModel);
            });

            model.OutboundCallQueues = collection;
            model.IsQueueGenerated = true;
            return model;
        }

        public OutboundCallQueueListModel CallQueueCustomersForUpsellAndConfimration(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers,
           IEnumerable<CallQueueCustomerCallViewModel> callQueueCustomerCalls, IEnumerable<CallCenterNotes> callCenterNoteses, IEnumerable<Event> events, IEnumerable<Host> hosts,
            IEnumerable<Pod> pods, IEnumerable<Appointment> appointments, IEnumerable<EventCustomer> eventCustomers, IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles)
        {
            var model = new OutboundCallQueueListModel();
            var collection = new List<OutboundCallQueueViewModel>();

            callQueueCustomers.ToList().ForEach(cqc =>
            {
                Customer customer = customers.FirstOrDefault(c => c.CustomerId == cqc.CustomerId.Value);

                var email = (customer.Email != null) ? customer.Email.ToString() : string.Empty;

                var theEvent = events.First(e => e.Id == cqc.EventId.Value);
                var host = hosts.Single(h => h.Id == theEvent.HostId);
                var eventLocation = Mapper.Map<Address, AddressViewModel>(host.Address);

                var eventcustomer = eventCustomers.Single(ec => ec.EventId == theEvent.Id && ec.CustomerId == customer.CustomerId);
                var appointment = appointments.Single(a => a.Id == eventcustomer.AppointmentId.Value);
                var registeredBy = (eventcustomer.DataRecorderMetaData == null || eventcustomer.DataRecorderMetaData.DataRecorderCreator == null ? null : agents.FirstOrDefault(a => a.Id == eventcustomer.DataRecorderMetaData.DataRecorderCreator.Id));
                var agentRole = string.Empty;

                if (registeredBy != null)
                {
                    agentRole = registeredBy.RoleId == (long)Roles.Customer ? "Online" : roles.First(r => r.Id == registeredBy.RoleId).DisplayName;
                }

                var outboundModel = OutboundCallQueueViewModel(cqc, customer, null, email, customer.MobilePhoneNumber, customer.OfficePhoneNumber, theEvent, host, eventLocation, null);
                outboundModel.Pod = string.Join(",", pods.Where(p => theEvent.PodIds.Contains(p.Id)).Select(x => x.Name));
                outboundModel.AppointmentTime = appointment.StartTime;
                outboundModel.RegistrationMode = agentRole;

                SetHistoryViewModelList(callQueueCustomerCalls, callCenterNoteses, cqc, outboundModel);

                collection.Add(outboundModel);
            });

            model.OutboundCallQueues = collection;
            model.IsQueueGenerated = true;
            return model;
        }

        private OutboundCallQueueViewModel OutboundCallQueueViewModel(CallQueueCustomer cqc, Customer customer, ProspectCustomer prospectCustomer, string email, PhoneNumber mobilePhoneNumber, PhoneNumber officePhoneNumber, Event theEvent, Host host, AddressViewModel eventLocation, string customTags)
        {
            var outboundModel = new OutboundCallQueueViewModel
             {
                 CallQueueCustomerId = cqc.Id,
                 ProspectCustomerId = cqc.ProspectCustomerId,
                 CustomerId = cqc.CustomerId,
                 FirstName = customer != null ? customer.Name.FirstName : prospectCustomer.FirstName,
                 MiddleName = customer != null ? customer.Name.MiddleName : "",
                 LastName = customer != null ? customer.Name.LastName : prospectCustomer.LastName,
                 Gender = customer != null ? customer.Gender : prospectCustomer.Gender,
                 Email = email,
                 CallBackPhoneNumber = customer != null ? customer.HomePhoneNumber : prospectCustomer.CallBackPhoneNumber,
                 MobilePhoneNumber = mobilePhoneNumber,
                 OfficePhoneNumber = officePhoneNumber,
                 DateOfBirth = customer != null ? customer.DateOfBirth : prospectCustomer.BirthDate,
                 CreatedOn = cqc.DateCreated,
                 ProspectCreatedOn =
                     prospectCustomer != null && prospectCustomer.CreatedOn != DateTime.MinValue
                         ? prospectCustomer.CreatedOn
                         : (DateTime?)null,
                 EventId = theEvent != null ? theEvent.Id : (long?)null,
                 EventDate = theEvent != null ? theEvent.EventDate : (DateTime?)null,
                 HostName = host != null ? host.OrganizationName : string.Empty,
                 EventLocation = eventLocation,
                 Tag = prospectCustomer != null ? prospectCustomer.Tag.GetDescription() : string.Empty,
                 ZipCode = customer != null ? customer.Address.ZipCode.Zip : prospectCustomer.Address.ZipCode.Zip,
                 IsDoNotCallCustomer = (prospectCustomer != null && prospectCustomer.Status == (long)ProspectCustomerConversionStatus.Declined) || (customer != null && customer.DoNotContactTypeId.HasValue && (customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotCall)), //customer.DoNotContactReasonId != null
                 RequestedCallBackDateTime = prospectCustomer != null && prospectCustomer.IsQueuedForCallBack ? prospectCustomer.CallBackRequestedDate : (DateTime?)null,
                 CustomCorporateTags = customTags

             };

            return outboundModel;
        }

        private void SetHistoryViewModelList(IEnumerable<CallQueueCustomerCallViewModel> callQueueCustomerCalls, IEnumerable<CallCenterNotes> callCenterNoteses, CallQueueCustomer cqc, OutboundCallQueueViewModel outboundModel)
        {
            if (callQueueCustomerCalls != null && callQueueCustomerCalls.Any())
            {
                var calls = callQueueCustomerCalls.Where(
                                    cqcc => (cqc.CustomerId.HasValue && cqcc.CustomerId == cqc.CustomerId.Value) ||
                                             (cqc.ProspectCustomerId.HasValue && cqcc.ProspectCustomerId == cqc.ProspectCustomerId.Value))
                                            .Select(cqcc => cqcc).ToArray();

                if (calls.Any())
                {
                    calls = calls.OrderByDescending(x => x.CallDateTime).ToArray();
                    var callHistoryList = new List<CallHistoryViewModel>();
                    foreach (var customerCall in calls)
                    {
                        var callHistory = new CallHistoryViewModel()
                        {
                            CallId = customerCall.CallId,
                            DateCreated = customerCall.CallDateTime
                        };

                        if (callCenterNoteses != null && callCenterNoteses.Any())
                        {
                            var customerNotes = callCenterNoteses.Where(ccn => ccn.CallId == customerCall.CallId).Select(ccn => ccn).ToArray();
                            callHistory.Notes = customerNotes.Select(cn => new NotesViewModel() { Note = cn.Notes, EnteredOn = cn.DateCreated }).OrderByDescending(x => x.EnteredOn);
                        }

                        callHistoryList.Add(callHistory);
                    }

                    outboundModel.CallHistory = callHistoryList;
                }
            }
        }
        
    }
}
