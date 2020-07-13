using System;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Core.Medical.Impl
{
    public class ResultArchiveUploadEditModelValidator : AbstractValidator<ResultArchiveUploadEditModel>
    {
        private IEventRepository _eventRepository;
        public ResultArchiveUploadEditModelValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            RuleFor(x => x.EventId).NotNull().WithMessage("Can not be null.").NotEmpty().WithMessage("Can not be empty.").GreaterThan(0).WithMessage("Greater than Zero.").Must((x, eventId) => CheckIfEventisValidPastDatedEvent(eventId)).WithMessage("Event can not be a future dated event.");
        }

        private bool CheckIfEventisValidPastDatedEvent(long eventId)
        {
            if (eventId < 1) return false;
            var theEvent = _eventRepository.GetById(eventId);
            if (theEvent == null || theEvent.EventDate > DateTime.Now) return false;
            return true;
        }
    }
}