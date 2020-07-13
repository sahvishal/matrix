using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class LabFormService : ILabFormService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IPhysicianLabTestRepository _physicianLabTestRepository;
        private readonly IHostRepository _hostRepository;

        public LabFormService(IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository,
            IEventRepository eventRepository, IPhysicianRepository physicianRepository, IPhysicianLabTestRepository physicianLabTestRepository, IHostRepository hostRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _physicianRepository = physicianRepository;
            _physicianLabTestRepository = physicianLabTestRepository;
            _hostRepository = hostRepository;
        }

        public LabFormViewModel GetIfobtLabFormViewModel(long eventId, long customerId)
        {
            var eventData = _eventRepository.GetById(eventId);
            var customer = _customerRepository.GetCustomer(customerId);
            var host = _hostRepository.GetHostForEvent(eventData.Id);

            return GetIfobtLabFormViewModel(eventData, customer, host);
        }

        public LabFormViewModel GetIfobtLabFormViewModel(Event eventData, Customer customer, Host host)
        {

            var physicianLabTests = _physicianLabTestRepository.GetPhysicicanLabTestByStateId(host.Address.StateId);
            PhysicianLabTest physicianLabTest = null;

            if (!physicianLabTests.IsNullOrEmpty())
            {
                physicianLabTest = physicianLabTests.FirstOrDefault();
            }

            PhoneNumber customerPhoneNumber = null;
            if (customer.HomePhoneNumber != null && !string.IsNullOrEmpty(customer.HomePhoneNumber.Number))
            {
                customerPhoneNumber = customer.HomePhoneNumber;
            }
            Physician physician = null;
            if (physicianLabTest != null)
                physician = _physicianRepository.GetPhysician(physicianLabTest.PhysicianId);

            return new LabFormViewModel
            {
                PatientName = customer.Name,
                Gender = customer.Gender != Gender.Unspecified ? customer.Gender.ToString() : string.Empty,
                DateOfBirth = customer.DateOfBirth,
                EventId = eventData.Id,
                EventDate = eventData.EventDate,
                PatientId = customer.CustomerId,
                PatientAddress = customer.Address,
                PatientPhone = customerPhoneNumber,
                PolicyHolderName = customer.Name,
                PolicyHolderAddress = customer.Address,
                PhysicianName = physician == null ? null : physician.Name,
                Npi = (physician == null || string.IsNullOrEmpty(physician.Npi)) ? string.Empty : physician.Npi,
                PhysicianAccountNumber = physicianLabTest != null ? physicianLabTest.IfobtLicenseNo : string.Empty
            };
        }

        public LabFormViewModel GetMicroalbumineLabFormViewModel(long eventid, long customerid)
        {
            var eventData = _eventRepository.GetById(eventid);
            var customer = _customerRepository.GetCustomer(customerid);
            var host = _hostRepository.GetHostForEvent(eventData.Id);

            return GetMicroalbumineLabFormViewModel(eventData, customer, host);
        }

        public LabFormViewModel GetMicroalbumineLabFormViewModel(Event eventData, Customer customer, Host host)
        {
            var physicianLabTests = _physicianLabTestRepository.GetPhysicicanLabTestByStateId(host.Address.StateId);
            PhysicianLabTest physicianLabTest = null;

            if (!physicianLabTests.IsNullOrEmpty())
            {
                physicianLabTest = physicianLabTests.FirstOrDefault();
            }
            PhoneNumber customerPhoneNumber = null;
            if (customer.HomePhoneNumber != null && !string.IsNullOrEmpty(customer.HomePhoneNumber.Number))
            {
                customerPhoneNumber = customer.HomePhoneNumber;
            }
            Physician physician = null;
            if (physicianLabTest != null)
                physician = _physicianRepository.GetPhysician(physicianLabTest.PhysicianId);

            return new LabFormViewModel
            {
                PatientName = customer.Name,
                Gender = customer.Gender != Gender.Unspecified ? customer.Gender.ToString() : string.Empty,
                DateOfBirth = customer.DateOfBirth,
                EventId = eventData.Id,
                EventDate = eventData.EventDate,
                PatientId = customer.CustomerId,
                PatientAddress = customer.Address,
                PatientPhone = customerPhoneNumber,
                PolicyHolderName = customer.Name,
                PolicyHolderAddress = customer.Address,
                PhysicianName = physician == null ? null : physician.Name,
                Npi = (physician == null || string.IsNullOrEmpty(physician.Npi)) ? string.Empty : physician.Npi,
                PhysicianAccountNumber = physicianLabTest != null ? physicianLabTest.MicroalbumineLicenseNo : string.Empty
            };
        }
    }
}
