using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{// TODO: Needs refactoring and reconsideration
    public class ReadingNotBlankRule<T> : IValidationRule<ResultReading<T>>
    {

        #region IValidationRule<ResultReading<T>> Members

        public string GetErrorMessage(ResultReading<T> objectToValidate)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(ResultReading<T> objectToValidate)
        {
            if (objectToValidate != null)
            {
                if (objectToValidate.Reading is string)
                {
                    if (string.IsNullOrEmpty(objectToValidate.Reading.ToString()) == false)
                    {
                        if (objectToValidate is CompoundResultReading<T>)
                        {
                            if (((CompoundResultReading<T>)objectToValidate).Finding != null)
                                return true;
                        }
                        else
                            return true;
                    }
                }
                else
                {
                    if (objectToValidate.Reading != null)
                    {
                        if (objectToValidate is CompoundResultReading<T>)
                        {
                            if (((CompoundResultReading<T>)objectToValidate).Finding != null)
                                return true;
                        }
                        else
                            return true;
                    }
                }
            }
            return false;
        }

        #endregion
    }
}
