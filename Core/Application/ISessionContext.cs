using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Application
{
    public interface ISessionContext
    {
        UserSessionModel UserSession { get; set; }
        string LastLoggedInTime { get; set; }
    }
}