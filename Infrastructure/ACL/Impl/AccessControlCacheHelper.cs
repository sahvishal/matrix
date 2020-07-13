using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.ACL;
using Falcon.App.Core.ACL.ViewModel;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.ACL.Impl
{
    public class AccessControlCacheHelper
    {
        const string CacheKey = "_AccessControlCache_";

        static readonly object LockObject = new object();

        public static void BuildCache()
        {
            IEnumerable<AccessControlObjectCacheItem> cacheObject;
            if (((cacheObject = GetObjectforCurrentRole()) == null || !cacheObject.Any()))
                BuildCache(GetLoggedinRole());
        }

        private static void BuildCache(long roleId)
        {
            BuildSystemCache(roleId);

            var roleRepository = ApplicationManager.DependencyInjection.Resolve<IRoleRepository>();

            var roles = roleRepository.GetAll();
            var roleIds = roles.Where(r => r.Id != roleId).Select(r => r.Id).ToArray();

            BuildSystemCacheAllRoles(roleIds);
        }

        public static void BuildSystemCache(long roleId)
        {
            var httpCache = ApplicationManager.DependencyInjection.Resolve<IHttpCache<IEnumerable<AccessControlObjectCacheItem>>>();
            var repository = ApplicationManager.DependencyInjection.Resolve<IAccessControlObjectRepository>();

            var accessControlObjects = repository.GetAllowedAccessControlObjectsByRoleId(roleId);

            var cacheKey = CacheKey + roleId;

            lock (LockObject)
            {
                httpCache.Clear(cacheKey);

                httpCache.Set(cacheKey, accessControlObjects.Select(x => new AccessControlObjectCacheItem
                    {
                        DataScope = x.RoleAccessControlObjects.First().DataScope,
                        Name = x.Title,
                        Alias = x.Alias,
                        ResourceUrls = x.Urls.Select(m => m.Url.ToLower()).ToArray()
                    }).ToArray());

            }
        }

        private static void BuildSystemCacheAllRoles(IEnumerable<long> roleIds)
        {
            var httpCache = ApplicationManager.DependencyInjection.Resolve<IHttpCache<IEnumerable<AccessControlObjectCacheItem>>>();
            var repository = ApplicationManager.DependencyInjection.Resolve<IAccessControlObjectRepository>();

            if (roleIds != null && roleIds.Any())
            {
                foreach (var roleId in roleIds)
                {
                    var accessControlObjects = repository.GetAllowedAccessControlObjectsByRoleId(roleId);
                    var cacheKey = CacheKey + roleId;

                    lock (LockObject)
                    {
                        httpCache.Clear(cacheKey);

                        httpCache.Set(cacheKey, accessControlObjects.Select(x => new AccessControlObjectCacheItem
                        {
                            DataScope = x.RoleAccessControlObjects.First().DataScope,
                            Name = x.Title,
                            Alias = x.Alias,
                            ResourceUrls = x.Urls.Select(m => m.Url.ToLower()).ToArray()
                        }).ToArray());
                    }
                }
            }
        }

        public static IEnumerable<AccessControlObjectCacheItem> GetObjectforCurrentRole()
        {
            return GetfromCache();
        }

        private static long GetLoggedinRole()
        {
            var sessionContext = ApplicationManager.DependencyInjection.Resolve<ISessionContext>();

            if (sessionContext == null || sessionContext.UserSession == null)
            {
                throw new InvalidDataException();
            }

            return sessionContext.UserSession.CurrentOrganizationRole.RoleId;
        }

        public static IEnumerable<AccessControlObjectCacheItem> GetfromCache()
        {
            var httpCache = ApplicationManager.DependencyInjection.Resolve<IHttpCache<IEnumerable<AccessControlObjectCacheItem>>>();
            var cacheKey = CacheKey + GetLoggedinRole();
            IEnumerable<AccessControlObjectCacheItem> list;

            httpCache.Get(cacheKey, out list);
            return list ?? new List<AccessControlObjectCacheItem>();
        }

    }
}