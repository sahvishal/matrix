using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class EventCustomerPcpAppointmentService : IEventCustomerPcpAppointmentService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventPackageRepository _eventPackageRepository;

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IPrimaryCarePhysicianHelper _primaryCarePhysicianHelper;
        private readonly IPcpAppointmentRepository _pcpAppointmentRepository;
        private readonly IPcpDispositionRepository _pcpDispositionRepository;


        public EventCustomerPcpAppointmentService(ICustomerRepository customerRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
            IEventRepository eventRepository, IHostRepository hostRepository, IEventCustomerRepository eventCustomerRepository, IOrderRepository orderRepository,
            IEventTestRepository eventTestRepository, IEventPackageRepository eventPackageRepository, ICorporateAccountRepository corporateAccountRepository, IOrganizationRepository organizationRepository,
            IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository, IPrimaryCarePhysicianHelper primaryCarePhysicianHelper, IPcpAppointmentRepository pcpAppointmentRepository, IPcpDispositionRepository pcpDispositionRepository)
        {
            _customerRepository = customerRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _orderRepository = orderRepository;
            _eventTestRepository = eventTestRepository;
            _eventPackageRepository = eventPackageRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _organizationRepository = organizationRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _primaryCarePhysicianHelper = primaryCarePhysicianHelper;
            _pcpAppointmentRepository = pcpAppointmentRepository;
            _pcpDispositionRepository = pcpDispositionRepository;
        }

        public EventCustomerPcpAppointmentEditModel GetEventCustomerPcpAppointment(long eventcustomerId)
        {
            var model = GetEventCustomerEventModel(eventcustomerId);
            model.Pcp = GetPrimaryCarePhysicianEditModel(model.CustomerId);
            return model;
        }

        public EventCustomerPcpAppointmentEditModel GetEventCustomerEventModel(long eventcustomerId)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventcustomerId);

            var account = _corporateAccountRepository.GetbyEventId(eventCustomer.EventId);
            var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);
            var theEvent = _eventRepository.GetById(eventCustomer.EventId);
            var host = _hostRepository.GetHostForEvent(eventCustomer.EventId);

            var order = _orderRepository.GetOrder(eventCustomer.CustomerId, eventCustomer.EventId);
            var eventPackage = _eventPackageRepository.GetPackageForOrder(order.Id);
            var eventTest = _eventTestRepository.GetTestsForOrder(order.Id);

            var pcpDispositions = _pcpDispositionRepository.GetByCustomerIdEventId(eventCustomer.CustomerId, eventCustomer.EventId);
            var pcpAppointment = GetPcpAppointment(eventCustomer, pcpDispositions);

            PcpDisposition pcpDisposition = null;
            if (!pcpDispositions.IsNullOrEmpty())
            {
                pcpDisposition = pcpDispositions.OrderByDescending(pd => pd.DataRecorderMetaData.DateCreated).First();
            }


            var customerTest = new List<string>();

            if (eventPackage != null)
            {
                customerTest.AddRange(eventPackage.Tests.Select(x => x.Test.Name));
            }

            if (eventTest != null && eventTest.Any())
            {
                customerTest.AddRange(eventTest.Select(x => x.Test.Name));
            }

            var model = new EventCustomerPcpAppointmentEditModel
            {
                EventCustomerId = eventCustomer.Id,
                EventId = eventCustomer.EventId,
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                PhoneNumber = customer.HomePhoneNumber,
                CustomerEmail = customer.Email,
                ScreeningDate = theEvent.EventDate,
                HostName = host.OrganizationName,
                Location = host.Address,
                ScreenedForTest = customerTest,
                BookAfterNumberOfDays = account != null ? account.NumberOfDays : 0,
                NotAbleToSchedule = (pcpAppointment == null && pcpDisposition != null),
                DispositionId = (pcpAppointment == null && pcpDisposition != null) ? (long)pcpDisposition.Disposition : 0,
                Notes = (pcpAppointment == null && pcpDisposition != null) ? pcpDisposition.Notes : string.Empty,
                AppointmentDate = pcpAppointment != null ? pcpAppointment.AppointmentOn.Date : (DateTime?)null,
                AppointmentTime = pcpAppointment != null ? pcpAppointment.AppointmentOn.ToString("hh:mm: tt") : null,
                PreferredContactMethod = pcpAppointment != null ? pcpAppointment.PreferredContactMethod : -1,
                EventDate = theEvent.EventDate
            };

            return model;
        }

        public PrimaryCarePhysicianEditModel GetPrimaryCarePhysicianEditModel(long customerId)
        {
            return _primaryCarePhysicianHelper.GetPrimaryCarePhysicianEditModel(customerId);
        }

        public void UpdatePcpAppointmentTime(EventCustomerPcpAppointmentEditModel model, long orgRoleUserId)
        {
            _primaryCarePhysicianHelper.UpdatePrimaryCarePhysician(model.Pcp, model.CustomerId, orgRoleUserId);

            if (!model.NotAbleToSchedule && model.AppointmentDateTime.HasValue)
            {
                var pcpAppointment = _pcpAppointmentRepository.GetByEventCustomerId(model.EventCustomerId);

                if (pcpAppointment != null)
                {
                    pcpAppointment.ModifiedOn = DateTime.Now;
                    pcpAppointment.ModifiedBy = orgRoleUserId;
                }
                else
                {
                    pcpAppointment = new PcpAppointment
                    {
                        CreatedOn = DateTime.Now,
                        CreatedBy = orgRoleUserId,
                        ModifiedOn = DateTime.Now,
                        ModifiedBy = orgRoleUserId,
                        EventCustomerId = model.EventCustomerId,
                    };
                }

                pcpAppointment.AppointmentOn = model.AppointmentDateTime.Value;
                pcpAppointment.PreferredContactMethod = model.PreferredContactMethod.HasValue && model.PreferredContactMethod > 0 ? model.PreferredContactMethod : null;

                _pcpAppointmentRepository.Save(pcpAppointment);
            }
            else if (model.NotAbleToSchedule)
            {
                var pcpDiposition = new PcpDisposition
                  {
                      Disposition = (PcpAppointmentDisposition)model.DispositionId,
                      EventCustomerId = model.EventCustomerId,
                      Notes = model.Notes,
                      DataRecorderMetaData = new DataRecorderMetaData(orgRoleUserId, DateTime.Now, DateTime.Now)
                  };

                pcpDiposition.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(orgRoleUserId);

                _pcpDispositionRepository.Save(pcpDiposition);
            }
        }

        public EventCustomerPcpAppointmentViewModel GetEventCustomerPcpAppointmentViewModel(long eventId, long customerId)
        {

            var account = _corporateAccountRepository.GetbyEventId(eventId);
            var customer = _customerRepository.GetCustomer(customerId);
            var theEventData = _eventRepository.GetById(eventId);
            var pcp = _primaryCarePhysicianRepository.Get(customerId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);


            return GetEventCustomerPcpAppointmentViewModel(theEventData, customer, account, pcp, eventCustomer);
        }

        public EventCustomerPcpAppointmentViewModel GetEventCustomerPcpAppointmentViewModel(Event eventData, Customer customer, CorporateAccount account, PrimaryCarePhysician pcp, EventCustomer eventCustomer)
        {
            var pcpDispositions = _pcpDispositionRepository.GetByEventCustomerId(eventCustomer.Id);

            var pcpAppointment = GetPcpAppointment(eventCustomer, pcpDispositions);

            var logoUrl = string.Empty;
            if (account != null)
            {
                var org = _organizationRepository.GetOrganizationbyId(account.Id);
                var file = org.LogoImageId > 0 ? _fileRepository.GetById(org.LogoImageId) : null;
                if (file != null)
                {
                    var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                    logoUrl = location.Url + file.Path;
                }
            }

            return new EventCustomerPcpAppointmentViewModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                AppointmentDateTime = pcpAppointment != null ? pcpAppointment.AppointmentOn : (DateTime?)null,
                Pcp = pcp,
                AccountLogoUrl = logoUrl,
                BookAfterNumberOfDays = account != null ? account.NumberOfDays : 0,
                EventDate = eventData.EventDate,

            };
        }

        private PcpAppointment GetPcpAppointment(EventCustomer eventCustomer, IEnumerable<PcpDisposition> pcpDispositions)
        {
            var pcpAppointment = _pcpAppointmentRepository.GetByEventCustomerId(eventCustomer.Id);

            if (!pcpDispositions.IsNullOrEmpty() && pcpAppointment != null)
            {
                var pcpDisposition = pcpDispositions.OrderByDescending(x => x.DataRecorderMetaData.DateCreated).First();
                var dateOfLatestDisposition = pcpDisposition.DataRecorderMetaData.DateCreated;

                if (pcpAppointment.CreatedOn < dateOfLatestDisposition &&
                    (pcpAppointment.ModifiedOn == null || pcpAppointment.ModifiedOn.Value < dateOfLatestDisposition))
                {
                    pcpAppointment = null;
                }
            }
            return pcpAppointment;
        }
    }
}
