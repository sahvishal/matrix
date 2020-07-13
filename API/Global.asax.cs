using System;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using API.Controllers;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.ACL.Impl;
using Falcon.App.Infrastructure.Application.Impl;
using FluentValidation.WebApi;

namespace API
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        private static readonly IHttpModule Module = new RequestDecryptionModule();

        public override void Init()
        {
            base.Init();

            if (bool.Parse(ConfigurationManager.AppSettings["IsDevEnvironment"])) return;
            Module.Init(this);
        }


        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;

            Response.Clear();
            Server.ClearError();

            if (exception != null)
            {
                IoC.Resolve<ILogManager>().GetLogger("Logs").Error("Application Error: " + exception.Message);
                IoC.Resolve<ILogManager>().GetLogger("Logs").Error("Application Error: " + exception.StackTrace);
            }

            var routeData = new RouteData();
            routeData.Values["controller"] = "Errors";
            routeData.Values["action"] = "General";
            routeData.Values["exception"] = exception;

            Response.StatusCode = 500;
            if (httpException != null)
            {
                Response.StatusCode = httpException.GetHttpCode();
                switch (Response.StatusCode)
                {
                    case 403:
                        routeData.Values["action"] = "Http403";
                        break;
                    case 404:
                        routeData.Values["action"] = "Http404";
                        break;
                    case 401:
                        routeData.Values["action"] = "Http401";
                        break;
                }
            }

            IController errorController = new ErrorController();
            var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
            errorController.Execute(rc);
        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            DependencyRegistrar.RegisterDependencies();
            ApiDependencyRegistrar.RegisterDepndencies();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters);
            FilterConfig.RegisterHttpFilters(GlobalConfiguration.Configuration.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();

            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            GlobalConfiguration.Configuration.Services.Add(typeof(System.Web.Http.Validation.ModelValidatorProvider), new FluentValidationModelValidatorProvider(new ValidatorFactory()));
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            var httpRequest = HttpContext.Current.Request;
            var url = httpRequest.RawUrl.ToLower();

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, token, timezoneoffset");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }

            SetupSessionContext(HttpContext.Current.Request);
            LogIncomingRequest();
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            IoC.Resolve<IAppSessionContext>().ClearStorage();
            AppContextStore.ClearAll();
        }

        private void SetupSessionContext(HttpRequest request)
        {
            var token = request.Headers.Get("Auth-token");
            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            SetSessionModel(token);
        }

        private void SetSessionModel(string token)
        {
            try
            {
                var userLoginLogRepository = IoC.Resolve<IUserLoginLogRepository>();
                var decryptedToken = token.Decrypt();
                var userData = decryptedToken.Split('_');
                var userId = 0L;
                if (userData.Length > 1)
                {
                    var sessionId = userData[0];
                    userId = long.Parse(userData[1]);
                    userId = userLoginLogRepository.GetAuthenticatedUserSessionIdUserId(sessionId, userId);
                }

                if (userId <= 0)
                {
                    var logger = IoC.Resolve<ILogManager>().GetLogger("API");
                    logger.Error(" User Id could not retrieved");

                    if (string.IsNullOrEmpty(decryptedToken))
                    {
                        logger.Error("token: is Blank");
                    }
                    else
                    {
                        logger.Error("token: " + decryptedToken);    
                    }

                    throw new HttpException(401, "Request tempered");
                }
                var sessionContext = IoC.Resolve<ISessionContext>();
                var userloginService = IoC.Resolve<IUserLoginService>();

                sessionContext.UserSession = userloginService.GetUserSessionModel(userId);

                if (userData.Length > 3)
                {
                    var currentOrganiztionRole = sessionContext.UserSession.CurrentOrganizationRole;
                    var roleId = long.Parse(userData[2]);
                    var organizationId = long.Parse(userData[3]);

                    if (roleId != currentOrganiztionRole.RoleId || organizationId != currentOrganiztionRole.OrganizationId)
                    {
                        sessionContext.UserSession = userloginService.SwitchOrganizationRole(sessionContext.UserSession, roleId, organizationId);
                    }

                }

                var userLoginLog = userLoginLogRepository.GetCurrentLoggedInLogforUser(userId);
                sessionContext.UserSession.UserLoginLogId = userLoginLog.Id;

            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger("API");
                logger.Error("ex: " + ex.Message + " stack trace: " + ex.StackTrace);
                throw new HttpException(401, "Request tempered");
            }
        }
        private void LogIncomingRequest()
        {
            var url = HttpContext.Current.Request.Url;
            var token = HttpContext.Current.Request.Headers.Get("Auth-token");
            var userAgent = HttpContext.Current.Request.UserAgent;


            //string message = string.Format("Url: {0}, Token: {1}, UserAgent: {2}", url, token, userAgent);

            //IoC.Resolve<ILogManager>().GetLogger("API").Info(message);
        }
    }
}