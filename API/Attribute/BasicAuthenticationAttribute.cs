using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Falcon.App.Core.ACL.ViewModel;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Infrastructure.ACL.Impl;

namespace API.Attribute
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["IsDevEnvironment"])) return;

            if (IsAuthenticated(actionContext)) return;

            //throw new HttpException(401, "Unauthorized access");
            throw new UnauthorizedException();
        }

        protected bool IsAuthenticated(HttpActionContext actionContext)
        {
            if (IsAnonymousRoleAllowed(actionContext)) return true;

            if (!AuthorizePageAccess(actionContext)) return false;

            if (!actionContext.Request.Headers.Contains("Auth-token"))
            {
                return false;
            }

            var token = actionContext.Request.Headers.GetValues("Auth-token").First();

            if (string.IsNullOrEmpty(token)) return false;


            return true;
        }

        private bool IsAnonymousRoleAllowed(HttpActionContext actionContext)
        {
            var attributes =
                   ((ReflectedHttpActionDescriptor)actionContext.ActionDescriptor).MethodInfo.CustomAttributes;

            if (attributes != null && attributes.Any(x => x.AttributeType == typeof(AllowAnonymousAttribute)))
                return true;

            attributes =
                   actionContext.ControllerContext.Controller.GetType().CustomAttributes;

            if (attributes != null && attributes.Any(x => x.AttributeType == typeof(AllowAnonymousAttribute)))
                return true;

            return false;
        }

        private bool AuthorizePageAccess(HttpActionContext httpContext)
        {
            if (httpContext.Request.RequestUri == null) return false;

            var requestedUrl = httpContext.Request.RequestUri.AbsolutePath.ToLower();

            if (!new AccessControlHelper().CheckAccess(requestedUrl, new List<EntityType>())) return false;

            return true;

        }
    }
}