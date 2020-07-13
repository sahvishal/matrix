using Falcon.App.Core.Application.Domain;

namespace Falcon.App.Core.Application
{
    public interface IApplicationAuthenticationRepository
    {
        ApplicationAuthentication GetByAppIdAndTokenId(string appId, string appToken);
        ApplicationAuthentication GetByAppId(string appId);
    }
}
