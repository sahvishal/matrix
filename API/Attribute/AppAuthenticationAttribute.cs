using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using System;
using System.Linq;
using System.Web.Http.Filters;

namespace API.Attribute
{
    public class AppAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private readonly IApplicationAuthenticationService _applicationAuthenticationService;

        public AppAuthenticationAttribute()
        {
            _applicationAuthenticationService = new ApplicationAuthenticationService();
        }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                var appToken = actionContext.Request.Headers.GetValues("AppToken").FirstOrDefault();
                var token = actionContext.Request.Headers.GetValues("AppTokenFromDatabase").FirstOrDefault();

                if (token == null || appToken != token)
                    throw new UnauthorizedException();
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>()
                    .GetLogger<AppAuthenticationAttribute>().Error("Error Occurred: Message: " + ex.Message + " \n StackTrace: " + ex.StackTrace);
                throw new UnauthorizedException();
            }
        }
    }
}