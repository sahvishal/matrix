using System;
using System.Net;
using System.Threading;
using System.Web;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using System.Web.Mvc;
using System.Web.Routing;
using Falcon.App.Infrastructure.ACL.Impl;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.UI.Filters;
using FluentValidation.Mvc;


namespace Falcon.App.UI
{
    public class Global : HttpApplication
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new AuditLogActionFilter());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*allaspx}", new { allaspx = @".*\.aspx(/.*)?" });
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();


            RegisterRoutes(RouteTable.Routes);
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();
            ControllerBuilder.Current.SetControllerFactory(new ActionControllerFactory());

            RegisterGlobalFilters(GlobalFilters.Filters);
            IoC.Resolve<ILogManager>().GetLogger<Global>().Info("Application started up @" + DateTime.Now);


            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            var validatorProvider = new FluentValidationModelValidatorProvider(new ValidatorFactory());
            ModelValidatorProviders.Providers.Add(validatorProvider);

            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            RedirectIfTechnicianAddonProductUrl(app.Request);
        }

        private void RedirectIfTechnicianAddonProductUrl(HttpRequest request)
        {
            const string techUrlforAddon = "franchisee/technician/additionalproductrequest";
            const string techUrlforAddOnPayment = "/App/Franchisee/Technician/MakePaymentforAddonProduct";

            if (request.Url.AbsolutePath.ToLower().Contains(techUrlforAddon))
            {
                Context.RewritePath("/App/CallCenter/CallCenterRep/RequestReport/AdditionalProductRequest.aspx?Call=No&CustomerId=" + request.QueryString["id"] + "&EventId=" + request.QueryString["EventId"] + "&guid=" + request.QueryString["guid"]);
            }
            else if (request.Url.AbsolutePath.ToLower().Contains(techUrlforAddOnPayment.ToLower()))
            {
                Context.RewritePath("/App/CallCenter/CallCenterRep/RequestReport/SendReportStep3.aspx?Call=No&CustomerId=" + request.QueryString["id"] + "&guid=" + request.QueryString["guid"]);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var settings = IoC.Resolve<ISettings>();
            var app = Context;

            if (HttpContext.Current.Session == null) return;

            var sessionTimeOut = HttpContext.Current.Session.Timeout;
            var myCookie = new HttpCookie("exptimer") { Value = sessionTimeOut.ToString() };

            bool isUserLoggedIn;
            try
            {
                var session = IoC.Resolve<ISessionContext>();
                isUserLoggedIn = (session != null && session.UserSession != null);
            }
            catch (Exception)
            {
                isUserLoggedIn = false;
            }

            myCookie.Values["enabletimer"] = isUserLoggedIn.ToString();
            myCookie.Values["lasttime"] = DateTime.Now.ToString("yyyy/MM/dd HH':'mm':'ss");

            myCookie.Values["logoutat"] = DateTime.Now.AddMinutes(sessionTimeOut).ToString("yyyy/MM/dd HH':'mm':'ss");
            myCookie.Values["warningtime"] = DateTime.Now.AddMinutes((sessionTimeOut - settings.WarningMessageTime)).ToString("yyyy/MM/dd HH':'mm':'ss");

            app.Response.Cookies.Add(myCookie);

            if (isUserLoggedIn)
                AccessControlCacheHelper.BuildCache();
        }

        private void Application_Error(object sender, EventArgs e)
        {
            //Server.ClearError();
            //Response.Redirect("/Home/Error", false);
            //Context.ApplicationInstance.CompleteRequest();
            Exception ex = Server.GetLastError();
            if (ex is ThreadAbortException)
            {
                //IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Application Error @" + DateTime.Now + "\n " + ex.Message + "Stack Trace: \n" + ex.StackTrace);
                return;
            }


            //IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Application Error @" + DateTime.Now + "\n " + ex.Message + "Stack Trace: \n" + ex.StackTrace);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            AppContextStore.ClearAll();
        }
    }
}