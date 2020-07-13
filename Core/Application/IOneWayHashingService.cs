using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Application
{
    public interface IOneWayHashingService
    {
        SecureHash CreateHash(string text);
        bool Validate(string text, SecureHash goodHash);
    }
}
