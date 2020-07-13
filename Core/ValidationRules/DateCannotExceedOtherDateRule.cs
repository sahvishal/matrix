using System;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Core.ValidationRules
{
    public class DateCannotExceedOtherDateRule<T> : IValidationRule<T>
        where T : class
    {
        private readonly Func<T, DateTime?> _dateThatCannotExceedOtherDate;
        private readonly Func<T, DateTime?> _dateThatCannotBeExceeded;
        private readonly string _dateThatCannotExceedOtherDatePropertyName;
        private readonly string _dateThatCannotBeExceededPropertyName;

        public DateCannotExceedOtherDateRule(Func<T, DateTime?> dateThatCannotExceedOtherDate, string dateThatCannotExceedOtherDatePropertyName,
            Func<T, DateTime?> dateThatCannotBeExceeded, string dateThatCannotBeExceededPropertyName)
        {
            if (dateThatCannotExceedOtherDate == null)
            {
                throw new ArgumentNullException("dateThatCannotExceedOtherDate", 
                    "Function delegating which date that cannot exceed the other is required.");
            }
            if (dateThatCannotExceedOtherDatePropertyName == null)
            {
                throw new ArgumentNullException("dateThatCannotExceedOtherDatePropertyName", 
                    "Function delegating which date that cannot exceed the other is required.");
            }
            if (dateThatCannotBeExceeded == null)
            {
                throw new ArgumentNullException("dateThatCannotBeExceeded", 
                    "Function delegating which date that cannot exceed the other is required.");
            }
            if (dateThatCannotBeExceededPropertyName == null)
            {
                throw new ArgumentNullException("dateThatCannotBeExceededPropertyName", 
                    "Function delegating which date that cannot exceed the other is required.");
            }
            _dateThatCannotExceedOtherDate = dateThatCannotExceedOtherDate;
            _dateThatCannotExceedOtherDatePropertyName = dateThatCannotExceedOtherDatePropertyName;
            _dateThatCannotBeExceeded = dateThatCannotBeExceeded;
            _dateThatCannotBeExceededPropertyName = dateThatCannotBeExceededPropertyName;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            DateTime? dateThatCannotExceedOtherDate = _dateThatCannotExceedOtherDate(objectToValidate);
            DateTime? dateThatCannotBeExceeded = _dateThatCannotBeExceeded(objectToValidate);
            return objectToValidate != null && dateThatCannotExceedOtherDate.HasValue && dateThatCannotBeExceeded.HasValue 
                ? string.Format("{0} ({1}) cannot exceed date {2} ({3}).", 
                _dateThatCannotExceedOtherDatePropertyName, dateThatCannotExceedOtherDate.Value.ToShortDateString(),
                _dateThatCannotBeExceededPropertyName, dateThatCannotBeExceeded.Value.ToShortDateString()) 
                : "The given object (or one of its properties) to get message for was null.";
        }

        public bool IsValid(T objectToValidate)
        {
            if (objectToValidate == null)
            {
                return false;
            }
            if (_dateThatCannotExceedOtherDate(objectToValidate) == null || _dateThatCannotBeExceeded(objectToValidate) == null)
            {
                return true;
            }
            return _dateThatCannotExceedOtherDate(objectToValidate) <= _dateThatCannotBeExceeded(objectToValidate);
        }
    }
}