using System;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.ValidationRules
{
    public class DateMustBeInRangeRule<T> : IValidationRule<T>
        where T : class
    {
        private readonly Func<T, DateTime?> _dateToValidate;
        private readonly DateTime _minimumDate;
        private readonly DateTime _maximumDate;
        private readonly bool _isNullDateValid;
        private readonly string _propertyName;

        public DateMustBeInRangeRule(Func<T, DateTime?> dateToValidate, string propertyName)
            : this (dateToValidate, propertyName, new DateTime(1900, 1, 1), DateTime.Today.GetEndOfDay(), true)
        {}

        public DateMustBeInRangeRule(Func<T, DateTime?> dateToValidate, string propertyName, bool isNullDateValid)
            : this(dateToValidate, propertyName, new DateTime(1900, 1, 1), DateTime.Today.GetEndOfDay(), isNullDateValid)
        { }

        public DateMustBeInRangeRule(Func<T, DateTime?> dateToValidate, string propertyName, DateTime minimumDate, DateTime maximumDate)
            : this(dateToValidate, propertyName, minimumDate, maximumDate, true)
        {}

        public DateMustBeInRangeRule(Func<T, DateTime?> dateToValidate, string propertyName, DateTime minimumDate, DateTime maximumDate, bool isNullDateValid)
        {
            if (dateToValidate == null)
            {
                throw new ArgumentNullException("dateToValidate", "A function delegating which date to validate must be provided.");
            }
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName", "A property name must be provided.");
            }
            if (minimumDate > maximumDate)
            {
                throw new DateCannotExceedOtherDateException(minimumDate, maximumDate);
            }
            _dateToValidate = dateToValidate;
            _propertyName = propertyName;
            _minimumDate = minimumDate;
            _maximumDate = maximumDate;
            _isNullDateValid = isNullDateValid;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return objectToValidate != null ? string.Format("{0} must be between {1} and {2}. Given date: {3}",
                _propertyName, _minimumDate.ToShortDateString(), _maximumDate.ToShortDateString(), 
                _dateToValidate(objectToValidate).Value.ToShortDateString()) 
                : "The given object to validate to get message for was null.";
        }

        public bool IsValid(T objectToValidate)
        {
            if (objectToValidate == null)
            {
                return false;
            }
            DateTime? dateToValidate = _dateToValidate(objectToValidate);
            return dateToValidate != null ? dateToValidate >= _minimumDate && dateToValidate <= _maximumDate : _isNullDateValid;
        }
    }
}