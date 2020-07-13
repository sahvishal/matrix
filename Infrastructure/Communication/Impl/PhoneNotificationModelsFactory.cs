using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Communication.Impl
{

    [DefaultImplementation]
    public class PhoneNotificationModelsFactory : IPhoneNotificationModelsFactory
    {
        private readonly IEventService _eventService;
        private readonly IAppointmentRepository _appointmentRepository;

        public PhoneNotificationModelsFactory(IEventService eventService, IAppointmentRepository appointmentRepository)
        {
            _eventService = eventService;
            _appointmentRepository = appointmentRepository;
        }

        private PhoneCommunicationViewModelBase CreateBase()
        {
            return new PhoneCommunicationViewModelBase();
        }

        public PhoneNotificationModel GetDummyScreeningReminderSmsNotificationModel()
        {
            return new PhoneNotificationModel(CreateBase())
            {
                CustomerName = new Name
                {
                    FirstName = "Customer",
                    LastName = "Name"
                },
                EventDate = DateTime.Now,
                AppointmentTime = DateTime.Now,
                LocationName = "[Event Location Name]",
                AddressOfVenue = new AddressViewModel()
                {
                    StreetAddressLine1 = "[Dummy Address 1]",
                    StreetAddressLine2 = "",
                    City = "[Dummy City]",
                    State = "[Dummy State]",
                    ZipCode = "[Dummy Zip]",
                    Country = "USA"
                }
            };
        }

        public PhoneNotificationModel GetScreeningReminderSmsNotificationModel(Customer customer, Event theEvent)
        {
            var eventHostViewData = _eventService.GetById(theEvent.Id);

            var appointment = _appointmentRepository.GetEventCustomerAppointment(theEvent.Id, customer.CustomerId);

            return new PhoneNotificationModel(CreateBase())
            {
                CustomerName = customer.Name,
                EventDate = eventHostViewData.EventDate,
                AppointmentTime = appointment.StartTime,
                LocationName = eventHostViewData.OrganizationName,
                AddressOfVenue = new AddressViewModel()
                {
                    StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                    StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                    City = eventHostViewData.City,
                    State = eventHostViewData.State,
                    ZipCode = eventHostViewData.Zip,
                    Country = "USA"
                }

            };
        }



        public CustomEventSmsNotificatonViewModel GetCustomEventSmsNotificatonModel(string body)
        {
            return new CustomEventSmsNotificatonViewModel(CreateBase())
            {
                Body = body
            };
        }

        public CustomEventSmsNotificatonViewModel GetDummyCustomEventSmsNotificatonModel()
        {
            return new CustomEventSmsNotificatonViewModel(CreateBase())
            {
                Body = "Dummy Text."
            };
        }

        public UserLoginOtpModel GetUserLoginOtpModel(string otp)
        {
            return new UserLoginOtpModel(CreateBase())
            {
                Otp = otp
            };
        }

        public UserLoginOtpModel GetDummyUserLoginOtpModel()
        {
            return new UserLoginOtpModel(CreateBase())
            {
                Otp = "123456"
            };
        }

        public WrongSmsResponseNotificationViewModel GetDummyWrongSmsResponseNotificationViewModel()
        {
            return new WrongSmsResponseNotificationViewModel(CreateBase());
        }

        public WellcomeSmsNotificationViewModel GetDummyWellcomeSmsNotificationViewModel()
        {
            return new WellcomeSmsNotificationViewModel(CreateBase());
        }

        public WrongSmsResponseNotificationViewModel GetWrongSmsResponseNotificationViewModel()
        {
            return new WrongSmsResponseNotificationViewModel(CreateBase());
        }

        public WellcomeSmsNotificationViewModel GetWellcomeSmsNotificationViewModel()
        {
            return new WellcomeSmsNotificationViewModel(CreateBase());
        }
    }
}
