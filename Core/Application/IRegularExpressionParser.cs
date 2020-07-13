
namespace Falcon.App.Core.Application
{
    public interface IRegularExpressionParser
    {
        string GetSourceCode(string completeString);
        string GetDate(string completeString);
        string GetName(string completeString);
    }
}