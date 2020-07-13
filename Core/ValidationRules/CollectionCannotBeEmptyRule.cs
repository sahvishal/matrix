using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;
using System.Collections.Generic;

namespace Falcon.App.Core.ValidationRules
{
    public class CollectionCannotBeEmptyRule<T, N> : IValidationRule<T>
        where T : class
    {
        private readonly Func<T, IEnumerable<N>> _collectionToCheck;
        private readonly string _propertyName;

        public CollectionCannotBeEmptyRule(Func<T, IEnumerable<N>> collectionToCheck, string propertyName)
        {
            if (collectionToCheck == null)
            {
                throw new ArgumentNullException("collectionToCheck", "Function delegating which collection to check must be provided.");
            }
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName", "Property name must be provided.");
            }
            _collectionToCheck = collectionToCheck;
            _propertyName = propertyName;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return objectToValidate != null ? string.Format("The colleciton {0} cannot be null or empty.",
                _propertyName) : "The given object to get message for was null.";
        }

        public bool IsValid(T objectToValidate)
        {
            return objectToValidate != null && _collectionToCheck(objectToValidate) != null &&
                !_collectionToCheck(objectToValidate).IsEmpty();
        }
    }
}