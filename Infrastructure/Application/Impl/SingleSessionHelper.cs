using System;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class SingleSessionHelper : ISingleSessionHelper
    {
        private readonly IHttpCache<UserLoginSessionInfo> _httpCache;
        private const string SessionCacheKey = "_UserSingleSession_";

        public SingleSessionHelper(IHttpCache<UserLoginSessionInfo> httpCache)
        {
            _httpCache = httpCache;
        }

        private UserLoginSessionInfo GetFromCacheInfo(string userName)
        {
            UserLoginSessionInfo userLoginSessionInfo;
            _httpCache.Get((SessionCacheKey + userName), out userLoginSessionInfo);
            if (userLoginSessionInfo == null)
            {
                Thread.Sleep(5000);
                _httpCache.Get((SessionCacheKey + userName), out userLoginSessionInfo);
            }

            return userLoginSessionInfo;
        }

        private void AddtoCacheInfo(UserLoginSessionInfo userLoginCacheInfo)
        {
            var userSessionKey = (SessionCacheKey + userLoginCacheInfo.UserName);

            _httpCache.Clear(userSessionKey);

            _httpCache.Set(userSessionKey, userLoginCacheInfo);
        }

        public void RemoveUserSessionFromCache(string userName, string sessionToken)
        {
            UserLoginSessionInfo userLoginSessionInfo;

            var useSessionKey = (SessionCacheKey + userName);
            _httpCache.Get(useSessionKey, out userLoginSessionInfo);
            if (userLoginSessionInfo == null)
            {
                Thread.Sleep(5000);
                _httpCache.Get((SessionCacheKey + userName), out userLoginSessionInfo);
            }
            
            if (userLoginSessionInfo != null && userLoginSessionInfo.SessionToken==sessionToken)
            {
                _httpCache.Clear(useSessionKey);
            }
        }

        public void CreateAndStoreSessionToken(string userName, string sessionToken)
        {
            var loginInfo = new UserLoginSessionInfo
             {
                 SessionToken = sessionToken,
                 UserName = userName,
                 LastAccessTime = DateTime.Now
             };

            loginInfo.LastAccessTime = DateTime.Now;

            AddtoCacheInfo(loginInfo);
        }

        public bool ValidatingUserSession(string userName, string sessionToken)
        {
            var userSessionInfo = GetFromCacheInfo(userName);

            return userSessionInfo != null && userSessionInfo.SessionToken == sessionToken;
        }

        public bool IsUserExist(string userName)
        {
            var userSessionInfo = GetFromCacheInfo(userName);

            return userSessionInfo != null;
        }

    }
}