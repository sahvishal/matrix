using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<EventAppointmentEditModel>))]
    public class EventAppointmentEditModelValidator : AbstractValidator<EventAppointmentEditModel>
    {
        private readonly IUniqueItemRepository<Event> _eventRepository;
        public EventAppointmentEditModelValidator(IUniqueItemRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(x => x.StartTime).NotNull().NotEmpty();
            RuleFor(x => x.EndTime).NotNull().NotEmpty();
            RuleFor(x => x.StartTime).LessThan(x => x.EndTime).WithMessage("Should be less than end time");
            RuleFor(x => x.StartTime).Must((x, startTime) => CheckAppointmentStartTime(startTime, x.EventId)).WithMessage("Should be greater than event start time.");

            RuleFor(x => x.EventPodRoomId).NotNull().NotEmpty().WithMessage("required").When(x => !x.EventPodRoomIds.IsNullOrEmpty());
            RuleFor(x => x.EventPodRoomId).Must((x, roomId) => x.EventPodRoomId.Value > 0).WithMessage("required").When(x => !x.EventPodRoomIds.IsNullOrEmpty() && x.EventPodRoomId.HasValue);
        }

        private bool CheckAppointmentStartTime(DateTime startTime, long eventId)
        {
            var eventData = _eventRepository.GetById(eventId);
            return Convert.ToDateTime(startTime.ToShortTimeString()) >= Convert.ToDateTime(eventData.EventStartTime.ToShortTimeString());
        }
    }
}