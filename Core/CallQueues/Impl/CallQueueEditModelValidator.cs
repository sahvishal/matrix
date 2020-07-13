using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Geo;
using FluentValidation;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CallQueueEditModel>))]
    public class CallQueueEditModelValidator : AbstractValidator<CallQueueEditModel>
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        public static string Message { get; set; }

        public CallQueueEditModelValidator(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;

            Message = "Atleast one assignment needs to be added";
            RuleFor(x => x.Name).NotNull().WithMessage("(required)").NotEmpty().WithMessage("(required)");
            RuleFor(x => x.Attempts).GreaterThan(0).WithMessage("(required)");
            RuleFor(x => x.QueueGenerationInterval).NotNull().WithMessage("(required)");
            RuleFor(x => x.QueueGenerationInterval).Must(interval => interval.HasValue && interval.Value > 0).WithMessage("(required)");
            RuleFor(x => x.Criterias).NotNull().WithMessage("(Atleast one criteria needs to be added.)");

            RuleFor(x => x.Criterias).Must((x, criterias) => CritariaValidation(criterias, x.Id)).When(x => x.Criterias != null && x.Criterias.Any()).WithLocalizedMessage(() => Message);

            RuleFor(x => x.Assignments).NotNull().WithMessage("(Atleast one assignment needs to be added.)");

            RuleFor(x => x.Assignments).Must((x, assignments) => AssignmentValidation(assignments)).When(x => x.Assignments != null && x.Assignments.Any()).WithLocalizedMessage(() => Message);

            RuleFor(x => x.ScriptText).NotNull().WithMessage("(required)").NotEmpty().WithMessage("(required)");
        }

        private bool AssignmentValidation(IEnumerable<CallQueueAssignmentEditModel> assignments)
        {
            if (assignments.Any(a => a.Percentage <= 0))
            {
                if (assignments.Count(a => a.Percentage <= 0) == 1)
                    Message = "One of the agent does not has percentange assigned.";
                else
                    Message = "Some of the agents does not have percentange assigned.";
                return false;
            }

            if (assignments.Sum(a => a.Percentage) > 100)
            {
                Message = "Total assignment is greater than 100.";
                return false;
            }

            if (assignments.Sum(a => a.Percentage) < 100)
            {
                Message = "Total assignment is less than 100.";
                return false;
            }
            return true;
        }

        private bool CritariaValidation(IEnumerable<CallQueueCriteriaEditModel> criterias, long callQueueId)
        {
            if (criterias.Any(c => c.CriteriaId == (long) QueueCriteria.AllProspects && string.IsNullOrEmpty(c.CallReason)))
            {
                Message = "Please enter call reason.";
                return false;
            }

            if (criterias.Any(c => c.CriteriaId == (long)QueueCriteria.AllProspects && c.CallReason.Length > 100))
            {
                Message = "Max length for call reason is 100 characters.";
                return false;
            }

            foreach (var criteria in criterias)
            {
                try
                {
                    _zipCodeRepository.GetZipCode(criteria.Zipcode);
                }
                catch (Exception)
                {
                    Message = string.Format("'{0}' is not a valid zipcode", criteria.Zipcode);
                    return false;
                }
            }
            return true;
        }
    }
}
