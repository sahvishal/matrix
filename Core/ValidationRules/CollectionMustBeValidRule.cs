using System;
using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.ValidationRules
{
    public class CollectionMustBeValidRule<T, N> : IValidationRule<T> 
        where T : class
        where N : class
    {
        private readonly Func<T, List<N>> _collectionToValidate;
        private readonly IValidationRule<N> _validationRule;
        private readonly IValidationErrorMessageFormatter<N> _formatter;
        private readonly List<string> _invalidObjectErrorMessages = new List<string>();

        public CollectionMustBeValidRule(Func<T, List<N>> collectionToValidate, IValidationRule<N> validationRule)
            : this (collectionToValidate, validationRule, new ValidationErrorMessageFormatter<N>())
        {}

        public CollectionMustBeValidRule(Func<T, List<N>> collectionToValidate, IValidationRule<N> validationRule, 
            IValidationErrorMessageFormatter<N> formatter)
        {
            if (collectionToValidate == null)
            {
                throw new ArgumentNullException("collectionToValidate", "A collection to validate must be provided.");
            }
            if (validationRule == null)
            {
                throw new ArgumentNullException("validationRule", "A validation rule must be provided.");
            }
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter", "A validation error message formatter must be provided.");
            }
            _collectionToValidate = collectionToValidate;
            _validationRule = validationRule;
            _formatter = formatter;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return objectToValidate != null ? _formatter.FormatErrorMessages(_invalidObjectErrorMessages, "\t") :
                "The given object to validate to get message for was null.";
        }

        public bool IsValid(T objectToValidate)
        {
            _invalidObjectErrorMessages.Clear();
            if (objectToValidate != null)
            {
                foreach (N item in _collectionToValidate(objectToValidate))
                {
                    if (!_validationRule.IsValid(item))
                    {
                        _invalidObjectErrorMessages.Add(_validationRule.GetErrorMessage(item));
                    }
                }
            }
            else
            {
                _invalidObjectErrorMessages.Add("The object given to validate was null.");
            }
            return _invalidObjectErrorMessages.IsEmpty();
        }
    }
}