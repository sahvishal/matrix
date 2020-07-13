using System;
using System.Collections.Generic;
using System.Linq;
using API.Areas.Users.Models;
using AutoMapper;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace API.Areas.Users.Impl
{
    public class PatientProfileUpdateService : IPatientProfileUpdateService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventService _eventService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IParticipationConsentSignatureRepository _participationConsentSignatureRepository;
        private readonly IFluConsentSignatureRepository _fluConsentSignatureRepository;
        private readonly IPhysicianRecordRequestSignatureRepository _physicianRecordRequestSignatureRepository;
        private readonly IEventCustomerGiftCardRepository _eventCustomerGiftCardRepository;
        private readonly IChaperoneSignatureRepository _chaperoneSignatureRepository;

        public PatientProfileUpdateService(ICustomerRepository customerRepository, ICustomerService customerService, IEventCustomerRepository eventCustomerRepository, IAppointmentRepository appointmentRepository, IEventRepository eventRepository,
            IHostRepository hostRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IEventService eventService, ICorporateAccountRepository corporateAccountRepository,
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IParticipationConsentSignatureRepository participationConsentSignatureRepository, IFluConsentSignatureRepository fluConsentSignatureRepository,
            IPhysicianRecordRequestSignatureRepository physicianRecordRequestSignatureRepository, IEventCustomerGiftCardRepository eventCustomerGiftCardRepository, IChaperoneSignatureRepository chaperoneSignatureRepository)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _eventService = eventService;
            _corporateAccountRepository = corporateAccountRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _participationConsentSignatureRepository = participationConsentSignatureRepository;
            _fluConsentSignatureRepository = fluConsentSignatureRepository;
            _physicianRecordRequestSignatureRepository = physicianRecordRequestSignatureRepository;
            _eventCustomerGiftCardRepository = eventCustomerGiftCardRepository;
            _chaperoneSignatureRepository = chaperoneSignatureRepository;
        }

        public void Save(Patient patient, long orgRoleId)
        {
            if (IsValidEmail(patient))
            {
                _customerService.SaveCustomer(CreateCustomer(patient), orgRoleId);
            }
        }

        private bool IsValidEmail(Patient patient)
        {
            if (string.IsNullOrEmpty(patient.Email))
                return true;

            if (!_customerRepository.UniqueEmail(patient.CustomerId, patient.Email.Trim())) throw new InvalidAddressException("Entered email is already in-use, please enter different email address");

            return true;
        }

        private Customer CreateCustomer(Patient patient)
        {
            var customer = _customerRepository.GetCustomer(patient.CustomerId);

            Address patientAddress = null;

            if (patient.Address != null)
            {
                patient.Address.Id = patient.Address != null ? customer.Address.Id : 0;
                patientAddress = patient.Address == null ? null : Mapper.Map<AddressEditModel, Address>(patient.Address);
            }

            customer.Name = patient.Name;
            customer.Email = string.IsNullOrEmpty(patient.Email) ? null : new Email(patient.Email);
            customer.DateOfBirth = patient.DateofBirth;
            customer.Race = patient.Race;
            customer.Address = patientAddress;
            customer.HomePhoneNumber = patient.PhoneHome;
            customer.MobilePhoneNumber = patient.PhoneCell;
            customer.OfficePhoneNumber = patient.PhoneOffice;
            customer.DateModified = DateTime.Now;
            customer.Gender = patient.Gender;

            return customer;
        }

        public CustomerEventDetailViewModel GetPatients(PatientSearchFilter filter, long technicianId)
        {
            var list = new List<ShortPatientInfoViewModel>();
            var patientList = _customerRepository.GetPatientList(filter);
            if (patientList.IsNullOrEmpty()) return new CustomerEventDetailViewModel();

            var customerIds = patientList.Select(x => x.CustomerId);

            var eventCustomers = _eventCustomerRepository.GetByCustomerIdEventDate(customerIds, DateTime.Today, DateTime.Now.AddDays(-1), technicianId).Where(x => x.AppointmentId.HasValue).ToArray();
            if (eventCustomers.IsNullOrEmpty()) return new CustomerEventDetailViewModel();

            customerIds = eventCustomers.Select(x => x.CustomerId).Distinct().ToList();

            var appointmentIds = eventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.AppointmentId.Value).ToArray();
            var appointments = _appointmentRepository.GetByIds(appointmentIds);

            var eventIds = eventCustomers.Select(x => x.EventId).Distinct().ToArray();
            var events = _eventRepository.GetEventsByIds(eventIds);

            var eventModels = _eventService.GetShortEventInfoList(events);

            var hosts = _hostRepository.GetEventHosts(eventIds);

            var eventCustomerIds = eventCustomers.Select(x => x.Id);
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var participationConsentSignatures = _participationConsentSignatureRepository.GetByEventCustomerIds(eventCustomerIds);
            var fluConsentSignatures = _fluConsentSignatureRepository.GetByEventCustomerIds(eventCustomerIds);
            var physicianRecordRequestSignatures = _physicianRecordRequestSignatureRepository.GetByEventCustomerIds(eventCustomerIds);
            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

            foreach (var eventCustomer in eventCustomers)
            {
                var patient = patientList.First(x => x.CustomerId == eventCustomer.CustomerId);

                var appointment = appointments.First(x => x.Id == eventCustomer.AppointmentId);

                var theEvent = events.First(x => x.Id == eventCustomer.EventId);
                var host = hosts.First(x => x.Id == theEvent.HostId);

                var order = orders.Single(o => o.CustomerId == eventCustomer.CustomerId);

                var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventCustomer.EventId);

                var eventTests = _eventTestRepository.GetTestsForEvent(eventCustomer.EventId);

                var eventpackageId = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventPackageItem)
                    .Select(od => od.OrderItem.ItemId).SingleOrDefault();
                var eventPackage = eventPackages.SingleOrDefault(ep => eventpackageId == ep.Id);

                var eventTestIds = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId).ToArray();
                var eventTestsonOrder = eventTests.Where(et => eventTestIds.Contains(et.Id)).ToArray();

                var chaperoneSignature = _chaperoneSignatureRepository.GetByEventCustomerId(eventCustomer.Id);

                var model = new ShortPatientInfoViewModel
                {
                    CustomerId = patient.CustomerId,
                    EventCustomerId = eventCustomer.Id,
                    FirstName = patient.Name.FirstName,
                    MiddleName = patient.Name.MiddleName,
                    LastName = patient.Name.LastName,
                    Email = patient.Email.ToString(),
                    HomePhone = patient.HomePhoneNumber.FormatPhoneNumber,
                    MobileNumber = patient.MobilePhoneNumber.FormatPhoneNumber,
                    EventId = eventCustomer.EventId,
                    AppointmentTime = appointment.StartTime,
                    Packages = eventPackage != null ? eventPackage.Package.Name : "",
                    Tests = !eventTestsonOrder.IsNullOrEmpty() ? string.Join(", ", eventTestsonOrder.Select(t => t.Test.Name)) : "",
                    HipaaConsent = eventCustomer.HIPAAStatus,
                    CheckInTime = appointment.CheckInTime,
                    CheckOutTime = appointment.CheckOutTime,
                    MatrixConsent = participationConsentSignatures != null && participationConsentSignatures.SingleOrDefault(x => x.EventCustomerId == eventCustomer.Id) != null,
                    PhysicianRecordRequest = physicianRecordRequestSignatures != null && physicianRecordRequestSignatures.SingleOrDefault(x => x.EventCustomerId == eventCustomer.Id) != null,
                    FluVaccine = fluConsentSignatures != null && fluConsentSignatures.SingleOrDefault(x => x.EventCustomerId == eventCustomer.Id) != null,
                    NoShow = eventCustomer.AppointmentId.HasValue && eventCustomer.NoShow,
                    LeftWithoutScreening = eventCustomer.AppointmentId.HasValue && eventCustomer.LeftWithoutScreeningReasonId.HasValue,
                    ChaperoneConsent = chaperoneSignature!=null?true: false
                };

                var pcp = primaryCarePhysicians != null ? primaryCarePhysicians.FirstOrDefault(x => x.CustomerId == eventCustomer.CustomerId) : null;
                if (pcp != null)
                {
                    var pcpAddress = pcp.Address != null ? Mapper.Map<Address, AddressViewModel>(pcp.Address) : null;
                    model.PrimaryCarePhysician = new PcpInfoViewModel
                    {
                        Name = pcp.Name.FullName,
                        Address = pcpAddress,
                        PhoneNumber = pcp.Primary != null ? pcp.Primary.FormatPhoneNumber : pcp.Secondary != null ? pcp.Secondary.FormatPhoneNumber : "",
                        Fax = pcp.Fax != null ? pcp.Fax.FormatPhoneNumber : ""
                    };
                }

                list.Add(model);
            }

            return new CustomerEventDetailViewModel
            {
                Customers = list,
                Events = eventModels
            };
        }

        public CustomerAppointmentViewModel GetPatientDetail(long eventCustomerId)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            if (eventCustomer == null) return null;

            var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);

            var account = !string.IsNullOrWhiteSpace(customer.Tag) ? _corporateAccountRepository.GetByTagWithOrganization(customer.Tag) : null;

            var appointment = eventCustomer.AppointmentId.HasValue ? _appointmentRepository.GetById(eventCustomer.AppointmentId.Value) : null;

            var order = _orderRepository.GetOrderByEventCustomerId(eventCustomerId);

            var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventCustomer.EventId);

            var eventTests = _eventTestRepository.GetTestsForEvent(eventCustomer.EventId);

            var eventpackageId = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventPackageItem)
                .Select(od => od.OrderItem.ItemId).SingleOrDefault();
            var eventPackage = eventPackages.SingleOrDefault(ep => eventpackageId == ep.Id);

            var eventTestIds = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId).ToArray();
            var eventTestsonOrder = eventTests.Where(et => eventTestIds.Contains(et.Id)).ToArray();

            var address = Mapper.Map<Address, AddressViewModel>(customer.Address);

            var pcp = _primaryCarePhysicianRepository.Get(eventCustomer.CustomerId);

            var isParticipationConsentSaved = _participationConsentSignatureRepository.IsSaved(eventCustomerId);
            var isGiftCardSaved = _eventCustomerGiftCardRepository.IsSaved(eventCustomerId);
            var isFluConsentSaved = _fluConsentSignatureRepository.IsSaved(eventCustomerId);
            var isPhysicianRecordRequestSaved = _physicianRecordRequestSignatureRepository.IsSaved(eventCustomerId);
            var chaperoneSignature = _chaperoneSignatureRepository.GetByEventCustomerId(eventCustomer.Id);

            var model = new CustomerAppointmentViewModel
            {
                CustomerId = customer.CustomerId,
                EventCustomerId = eventCustomer.Id,
                FirstName = customer.Name.FirstName,
                MiddleName = customer.Name.MiddleName,
                LastName = customer.Name.LastName,
                Email = customer.Email.ToString(),
                Address = address,
                HomePhone = customer.HomePhoneNumber.FormatPhoneNumber,
                MobileNumber = customer.MobilePhoneNumber.FormatPhoneNumber,
                MemberId = customer.InsuranceId,
                Dob = customer.DateOfBirth,
                Gender = customer.Gender.GetDescription(),
                HealthPlan = account != null ? account.Name : "",
                EventId = eventCustomer.EventId,
                AppointmentId = appointment != null ? appointment.Id : (long?)null,
                AppointmentTime = appointment != null ? appointment.StartTime : (DateTime?)null,
                CheckInTime = appointment != null ? appointment.CheckInTime : null,
                CheckOutTime = appointment != null ? appointment.CheckOutTime : null,
                Packages = eventPackage != null ? eventPackage.Package.Name : "",
                Tests = !eventTestsonOrder.IsNullOrEmpty() ? string.Join(", ", eventTestsonOrder.Select(t => t.Test.Name)) : "",
                HipaaConsent = eventCustomer.HIPAAStatus,
                PcpConsent = eventCustomer.PcpConsentStatus,
                MatrixConsent = isParticipationConsentSaved,
                PhysicianRecordRequest = isPhysicianRecordRequestSaved,
                GiftCard = isGiftCardSaved,
                FluVaccine = isFluConsentSaved,
                Survey = false,
                ExitInterview = false,
                NoShow = eventCustomer.AppointmentId.HasValue && eventCustomer.NoShow,
                LeftWithoutScreening = eventCustomer.AppointmentId.HasValue && eventCustomer.LeftWithoutScreeningReasonId.HasValue,
                ChaperoneConsent = chaperoneSignature != null ? true : false
            };

            if (pcp != null)
            {
                var pcpAddress = pcp.Address != null ? Mapper.Map<Address, AddressViewModel>(pcp.Address) : null;
                model.PrimaryCarePhysician = new PcpInfoViewModel
                {
                    Name = pcp.Name.FullName,
                    Address = pcpAddress,
                    PhoneNumber = pcp.Primary != null ? pcp.Primary.FormatPhoneNumber : pcp.Secondary != null ? pcp.Secondary.FormatPhoneNumber : "",
                    Fax = pcp.Fax != null ? pcp.Fax.FormatPhoneNumber : ""
                };
            }

            return model;
        }
    }
}