using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales
{
    public interface ILanguageService
    {
        Language AddLanguage(string name, long orgRoleId);
    }
}