using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.Impl
{
    public class ValidationErrorMessageFormatter<T> : IValidationErrorMessageFormatter<T>
    {
        public string FormatErrorMessages(IValidator<T> validator)
        {
            return FormatErrorMessages(validator, string.Empty);
        }

        public string FormatErrorMessages(List<string> brokenRuleErrorMessages)
        {
            return FormatErrorMessages(brokenRuleErrorMessages, string.Empty);
        }

        public string FormatErrorMessages(IValidator<T> validator, string prependString)
        {
            if (validator == null)
            {
                throw new ArgumentNullException("validator");
            }
            List<string> brokenRuleErrorMessages = validator.GetBrokenRuleErrorMessages();
            return FormatErrorMessages(brokenRuleErrorMessages, prependString);
        }

        public string FormatErrorMessages(List<string> brokenRuleErrorMessages, string prependString)
        {
            if (brokenRuleErrorMessages == null)
            {
                throw new ArgumentNullException("brokenRuleErrorMessages", "List of messages must be provided.");
            }
            if (prependString == null)
            {
                throw new ArgumentNullException("prependString", "String to prepend must be provided.");
            }
            string typeOfInvalidObject = typeof(T).ToString().Split(".".ToArray()).Last();
            if (brokenRuleErrorMessages.IsEmpty())
            {
                return string.Format(prependString + "The given {0} has no validation errors.", typeOfInvalidObject);
            }
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format(prependString +
                "The following validation errors occurred in the given {0}:", typeOfInvalidObject));
            foreach (var errorMessage in brokenRuleErrorMessages)
            {
                stringBuilder.Append(Environment.NewLine + prependString + errorMessage);
            }
            return stringBuilder.ToString();
        }
    }
}