
namespace Falcon.App.Core.Application
{
    public interface IApplicationAuthenticationService
    {
        bool ValidateApplicationToken(string appId, string appToken);
    }
}
