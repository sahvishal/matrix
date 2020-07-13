using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Falcon.App.Core.ACL;
using Falcon.App.Core.ACL.Enum;
using Falcon.App.Core.ACL.ViewModel;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.Infrastructure.ACL.Impl
{
    public class AccessControlHelper
    {
        private IEnumerable<EntityType> _entityTypes;

        public AccessControlHelper()
        {
            _entityTypes = new EntityType[0];
        }

        public bool CheckAccess(string requestedUrl, IEnumerable<EntityType> entityTypes)
        {
            //try
            //{
            //    System.IO.File.AppendAllText("D:/Admin_Report_URL.txt", Environment.NewLine + requestedUrl);

            //}
            //catch (Exception)
            //{
            //    System.IO.File.AppendAllText("D:/Admin_Report_URL1.txt", Environment.NewLine + requestedUrl);
            //}

            _entityTypes = entityTypes;

            var cacheObjects = AccessControlCacheHelper.GetfromCache();

            if (cacheObjects == null || !cacheObjects.Any())
            {
                Thread.Sleep(5000);
                cacheObjects = AccessControlCacheHelper.GetfromCache();

                if (cacheObjects == null) return false;
            }

            var objectsForGivenUrl = CheckPageAccess(requestedUrl, cacheObjects);

            if (objectsForGivenUrl == null)
            {
                //System.IO.File.AppendAllText("D:/UnAuthorize_URL.txt", Environment.NewLine + requestedUrl);
                return false;
            }

            var result = IsAccessAuthorized(objectsForGivenUrl.DataScope);
            if (!result) return false;

            return true;
        }
        
        private AccessControlObjectCacheItem CheckPageAccess(string requestedUrl,IEnumerable<AccessControlObjectCacheItem> cacheObjects)
        {
            var objectsForGivenUrl = cacheObjects.FirstOrDefault(x => x.ResourceUrls.Any(p => p.Equals(requestedUrl)));
            return objectsForGivenUrl;
        }

        private bool IsAccessAuthorized(DataScope dataScope)
        {
            if (_entityTypes.Any())
            {
                try
                {
                    long accountId, organizationRoleUserId;
                    GetUserValuesfromSession(out accountId, out organizationRoleUserId);

                    foreach (var entityType in _entityTypes)
                    {
                        long entityId = GetEntityId(entityType.ParameterName);
                        if (entityId < 1) continue;
                        var authorizeEntity = GetAuthorizeEntity(entityType.Type);

                        switch (dataScope)
                        {
                            case DataScope.Account:
                                if (!authorizeEntity.AuthorizeAccount(entityId, entityType.RepositoryType, accountId)) return false;
                                break;

                            case DataScope.Self:
                                if (!authorizeEntity.AuthorizeSelf(entityId, entityType.RepositoryType, organizationRoleUserId)) return false;
                                break;
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }

            return true;
        }

        private IAuthorizeEntity GetAuthorizeEntity(Type entityType)
        {
            if (entityType == null)
            {
                return null;
            }

            var tp = typeof(AuthorizeEntity<>);
            return ApplicationManager.DependencyInjection.Resolve(tp.MakeGenericType(entityType)) as IAuthorizeEntity;
        }

        private void GetUserValuesfromSession(out long accountId, out long organizationRoleUserId)
        {
            var sessionContext = ApplicationManager.DependencyInjection.Resolve<ISessionContext>();

            if (sessionContext != null && sessionContext.UserSession != null)
            {
                organizationRoleUserId = sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                accountId = sessionContext.UserSession.CurrentOrganizationRole.UserId;
                return;
            }

            throw new InvalidOperationException();
        }

        private long GetEntityId(string parameterName)
        {
            long entityId;
            var parameter = HttpContext.Current.Request[parameterName];

            if (parameter != null && long.TryParse(parameter, out entityId)) return entityId;

            return 0; // note: can 0 be a valid value
        }

    }
}