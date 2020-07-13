using Falcon.App.Core.Application;
using Falcon.App.Core.Users.ViewModels;

namespace API
{
    public class SessionContext : ISessionContext
    {
        private readonly IAppSessionContext _appSessionContext;

        public SessionContext(IAppSessionContext appSessionContext)
        {
            _appSessionContext = appSessionContext;
        }

        public UserSessionModel UserSession
        {
            get { return _appSessionContext.Get("UserSession") as UserSessionModel; }
            set
            {
                _appSessionContext.UpdateItem("UserSession", value);
            }
        }

        public string LastLoggedInTime { get; set; }
    }
}