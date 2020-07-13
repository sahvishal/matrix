using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core.ACL.ViewModel;
using Falcon.App.Infrastructure.ACL.Impl;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Helper;

namespace Falcon.App.UI.Filters
{
    public class RoleBasedAuthorizeAttribute : AuthorizeAttribute
    {
        private const string UnAuthorizedUrl = "/Home/UnauthorizeAccess";
        private IEnumerable<EntityType> _entityTypes;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.Controller is BaseAuthorizationController)
                _entityTypes = (filterContext.Controller as BaseAuthorizationController).GetEntityTypes();
            else
                _entityTypes = new EntityType[0];

            AuthenticationHelper.CheckAuthentication(filterContext);

            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.Url == null) return false;

            var requestedUrl = httpContext.Request.Url.AbsolutePath.ToLower();

            if (AuthenticationHelper.CheckUrl(requestedUrl))
                return true;

            if (!new AccessControlHelper().CheckAccess(requestedUrl, _entityTypes)) return false;

            //return base.AuthorizeCore(httpContext);
            return true;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            var requestedUrl = filterContext.RequestContext.HttpContext.Request.Url;

            if (requestedUrl == null) return;

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                base.HandleUnauthorizedRequest(filterContext);
                response.StatusCode = 401;
                response.End();
                return;
            }

            filterContext.HttpContext.RewritePath(UnAuthorizedUrl);
            filterContext.Result = new RedirectResult(UnAuthorizedUrl);
        }

    }

}