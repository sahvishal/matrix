using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Infrastructure.Application.Repositories;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class ApplicationAuthenticationService : IApplicationAuthenticationService
    {
        private readonly IApplicationAuthenticationRepository _applicationAuthenticationRepository;

        public ApplicationAuthenticationService()
        {
            _applicationAuthenticationRepository = new ApplicationAuthenticationRepository();
        }

        public bool ValidateApplicationToken(string appId, string appToken)
        {
            if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(appToken)) return false;

            var appAuth = _applicationAuthenticationRepository.GetByAppIdAndTokenId(Rijndael.Decrypt(appId), Rijndael.Decrypt(appToken));
            if (appAuth != null)
                return true;

            return false;
        }
    }
}
