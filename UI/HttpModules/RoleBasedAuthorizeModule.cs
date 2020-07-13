using System;
using System.Collections.Generic;
using System.Web;
using Falcon.App.Core.ACL.ViewModel;
using Falcon.App.Infrastructure.ACL.Impl;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Helper;

namespace Falcon.App.UI.HttpModules
{
    public class RoleBasedAuthorizeModule : IHttpModule
    {
        private const string UnAuthorizedUrl = "/Home/UnauthorizeAccess";

        private IEnumerable<EntityType> _entityTypes;
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            _entityTypes = new EntityType[0];
            context.AcquireRequestState += context_AcquireRequestState;
        }

        void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext httpContext = ((HttpApplication)sender).Context;

            var requestedUrl = httpContext.Request.Url.AbsolutePath.ToLower();

            if (!(requestedUrl.Contains("aspx") || requestedUrl.Contains("ascx") || requestedUrl.Contains("asmx"))) return;

            if (AuthenticationHelper.CheckAuthentication(httpContext))
                return;

            if (!new AccessControlHelper().CheckAccess(requestedUrl, _entityTypes))
            {
                httpContext.Response.RedirectUser(UnAuthorizedUrl);
            }
        }
    }

}