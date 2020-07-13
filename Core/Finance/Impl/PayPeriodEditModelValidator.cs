using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PayPeriodEditModel>))]
    public class PayPeriodEditModelValidator : AbstractValidator<PayPeriodEditModel>
    {
        private readonly IPayPeriodRepository _payPeriodRepository;

        public PayPeriodEditModelValidator(IPayPeriodRepository payPeriodRepository)
        {
            _payPeriodRepository = payPeriodRepository;
            RuleFor(x => x.FromDate).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required");//.Must((x,y)=>);
            RuleFor(x => x.NumberOfWeek).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Required");
            RuleFor(x => x.Criteria).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must(CriteriaShouldNotBeEmpty).WithMessage("Required");
            RuleFor(x => x.FromDate).Must(IsOverlappingWithAnotherPayPeriod).WithMessage("Overlapping with another published pay period.");
            RuleFor(x => x.FromDate).Must(IsPayPeriodValid).WithMessage("The Effective date should be next day of end date of current pay cycle.");
        }

        private bool CriteriaShouldNotBeEmpty(PayPeriodEditModel model, IEnumerable<PayPeriodCriteriaEditModel> criteria)
        {
            return !criteria.IsNullOrEmpty();
        }

        private bool IsOverlappingWithAnotherPayPeriod(PayPeriodEditModel model, DateTime? effectiveDate)
        {
            if (!effectiveDate.HasValue) return false;

            var nextPublishedPayPeriod = _payPeriodRepository.GetNextPublishedPayPeriod(effectiveDate.Value, true);
            var previousPublishedPayPeriod = _payPeriodRepository.GetPreviousPublishedPayPeriod(effectiveDate.Value, true);

            if (previousPublishedPayPeriod != null)
            {
                if (effectiveDate.Value >= previousPublishedPayPeriod.StartDate && effectiveDate.Value <= previousPublishedPayPeriod.StartDate.AddDays((7 * previousPublishedPayPeriod.NumberOfWeeks) - 1))
                    return false;
            }

            if (nextPublishedPayPeriod != null)
            {
                if (effectiveDate.Value <= nextPublishedPayPeriod.StartDate && effectiveDate.Value.AddDays((7 * model.NumberOfWeek) - 1) >= nextPublishedPayPeriod.StartDate) return false;
            }

            return true;
        }

        private bool IsPayPeriodValid(PayPeriodEditModel model, DateTime? effectiveDate)
        {
            if (!effectiveDate.HasValue) return false;

            var nextPublishedPayPeriod = _payPeriodRepository.GetNextPublishedPayPeriod(effectiveDate.Value, true);
            var previousPublishedPayPeriod = _payPeriodRepository.GetPreviousPublishedPayPeriod(effectiveDate.Value, true);

            if (previousPublishedPayPeriod != null)
            {
                var startDate = previousPublishedPayPeriod.StartDate;
                var tempDate = previousPublishedPayPeriod.StartDate;
                while (tempDate <= effectiveDate.Value)
                {
                    startDate = tempDate;
                    tempDate = tempDate.AddDays((7 * previousPublishedPayPeriod.NumberOfWeeks));
                }

                if (startDate != effectiveDate.Value) return false;
            }

            if (nextPublishedPayPeriod != null)
            {
                var startDate = effectiveDate.Value;
                var tempDate = effectiveDate.Value;
                while (tempDate <= nextPublishedPayPeriod.StartDate)
                {
                    startDate = tempDate;
                    tempDate = tempDate.AddDays((7 * model.NumberOfWeek));
                }

                if (startDate != nextPublishedPayPeriod.StartDate) return false;
            }

            return true;
        }
    }
}