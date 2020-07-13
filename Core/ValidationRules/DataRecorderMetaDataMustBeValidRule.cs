using System;
using System.Text;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.ValidationRules
{
    public class DataRecorderMetaDataMustBeValidRule<T> : IValidationRule<T>
        where T : class
    {
        private readonly Func<T, DataRecorderMetaData> _metaDataToCheck;
        private bool _isDateCreatedInRange;
        private bool _isModificationMetaDataValid;
        private bool _isCreatorSet;

        public DataRecorderMetaDataMustBeValidRule(Func<T, DataRecorderMetaData> metaDataToCheck)
        {
            _metaDataToCheck = metaDataToCheck;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            if (objectToValidate == null)
            {
                return "Given object to get message for was null.";
            }
            if (_metaDataToCheck(objectToValidate) != null)
            {
                return "Object has no DataRecorderMetaData.";
            }

            var stringBuilder = new StringBuilder("DataRecorderMetaData was invalid:");
            if (!_isDateCreatedInRange)
            {
                stringBuilder.AppendLine("Creation data out of range.");
            }
            if (!_isModificationMetaDataValid)
            {
                stringBuilder.AppendLine("Modification data in mixed state.");
            }
            if (!_isCreatorSet)
            {
                stringBuilder.AppendLine("No DataRecorderCreator specified.");
            }
            return stringBuilder.ToString();
        }

        public bool IsValid(T objectToValidate)
        {
            if (objectToValidate == null || _metaDataToCheck(objectToValidate) == null)
            {
                return false;
            }
            DataRecorderMetaData metaDataToCheck = _metaDataToCheck(objectToValidate);

            _isDateCreatedInRange = metaDataToCheck.DateCreated < DateTime.Today.GetEndOfDay();
            _isModificationMetaDataValid = !((metaDataToCheck.DateModified == null) ^ (metaDataToCheck.DataRecorderModifier == null));
            _isCreatorSet = metaDataToCheck.DataRecorderCreator != null;

            return _isDateCreatedInRange && _isModificationMetaDataValid && _isCreatorSet;
        }
    }
}