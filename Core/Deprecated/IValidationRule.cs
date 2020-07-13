namespace Falcon.App.Core.Deprecated
{
    public interface IValidationRule<T>
        where T : class
    {
        string GetErrorMessage(T objectToValidate);
        bool IsValid(T objectToValidate);
    }
}