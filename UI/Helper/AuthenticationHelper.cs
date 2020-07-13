using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.Helper
{
    public class AuthenticationHelper
    {
        private const string LoginUrl = "/login";

        private static readonly string[] ExcludedUrls =
        {
            "/App/Logoff.aspx",
            "/login",
            "/login/otp",
            "/Home/UnauthorizeAccess",
            "/App/FirstTimeLoginStep.aspx",
            "/app/franchisee/technician/printrosternew.aspx",
            "/App/Common/PDFCustomerList.aspx",
            "/App/Common/BarCodeFeeder.aspx",
            "/login/Setup",
            "/login/Authenticator",
            "/login/RedirectToOtp",
            "/Users/Profile/ValidateUserAndGetPin",
            "/public/account/resetpasswordstep1.aspx",
            "/public/account/resetpasswordstep2.aspx",
            "/public/account/resetpasswordstep3.aspx",
            "/app/resetpassword.aspx",
            "/login/ResendOtp",
            "/FileManager/Uploader/Index",
            "/FileManager/Uploader/FileHolder",
            "/FileManager/Uploader/FileView",
            "/App/Common/GiftCertificatePDF.aspx",
            "/login/PasswordExpiration",
            "/App/Default.aspx"
        };

        private const string CallCenterUrl = "/CallCenter/ContactCustomer/GetCustomerContactView";
        private const string DialerPatientUrl = "/CallCenter/ContactCustomer/GetDialerPatient";
        private const string ConfirmationViciUrl = "/CallCenter/ContactCustomer/AppointmentConfirmation";
        private const string ViewResults = "/App/Common/Results.aspx";

        public static bool CheckAuthentication(HttpContext httpContext)
        {
            try
            {
                var requestedUrl = httpContext.Request.Url.AbsolutePath.ToLower();

                if (CheckUrl(requestedUrl)) return true;

                var sessionContext = IoC.Resolve<ISessionContext>();
                if (sessionContext == null || sessionContext.UserSession == null)
                {
                    var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                    logger.Info("Session is null");
                    logger.Info("Requested Url: " + requestedUrl);

                    var rawUrl = httpContext.Request.RawUrl;
                    var returnUrlParameter = "?returnUrl=" + rawUrl;

                    rawUrl = rawUrl.ToUpper();
                    if (rawUrl.Contains(ViewResults.ToUpper()))
                    {
                        httpContext.Response.RedirectUser(LoginUrl + returnUrlParameter);
                        return true;
                    }

                    httpContext.Response.RedirectUser(LoginUrl);
                    return true;
                }


                var sessionSessionHelper = IoC.Resolve<ISingleSessionHelper>();
                var sesionId = httpContext.Session.SessionID;

                var userName = sessionContext.UserSession.UserName;
                if (!sessionSessionHelper.ValidatingUserSession(userName, sesionId))
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Info(userName + " has been forced log out");

                    httpContext.Session.Abandon();
                    httpContext.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    sessionContext.UserSession = null;
                    FormsAuthentication.SignOut();
                    var loginUrl = sessionSessionHelper.IsUserExist(userName) ? LoginUrl + "?isSessionTaken=true" : LoginUrl;

                    IoC.Resolve<ILogManager>().GetLogger<Global>().Info("Invalid User Session");

                    httpContext.Response.RedirectUser(loginUrl);
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                logger.Error("Exception  Message:" + exception.Message);
                logger.Error("Exception  Stack Trace:" + exception.StackTrace);
            }

            return false;
        }

        public static void CheckAuthentication(AuthorizationContext filterContext)
        {
            if (filterContext != null && filterContext.HttpContext != null && filterContext.HttpContext.Request != null && filterContext.HttpContext.Request.Url != null)
            {
                var requestedUrl = filterContext.HttpContext.Request.Url.AbsolutePath.ToLower();

                if (CheckUrl(requestedUrl)) return;

                var sessionContext = IoC.Resolve<ISessionContext>();
                if (sessionContext == null || sessionContext.UserSession == null)
                {
                    var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                    logger.Info("Session is null");
                    logger.Info("Requested Url: " + requestedUrl);

                    var rawUrl = filterContext.HttpContext.Request.RawUrl;
                    var returnUrlParameter = "?returnUrl=" + HttpUtility.UrlEncode(rawUrl);

                    rawUrl = rawUrl.ToUpper();
                    if (rawUrl.Contains(CallCenterUrl.ToUpper()) || rawUrl.Contains(DialerPatientUrl.ToUpper()) || rawUrl.Contains(ConfirmationViciUrl.ToUpper()))
                    {
                        filterContext.HttpContext.RewritePath(LoginUrl + returnUrlParameter);
                        filterContext.Result = new RedirectResult(LoginUrl + returnUrlParameter);
                    }
                    else
                    {
                        filterContext.HttpContext.RewritePath(LoginUrl);
                        filterContext.Result = new RedirectResult(LoginUrl);
                    }

                    return;
                }

                if (filterContext.HttpContext.Session != null)
                {
                    var sessionSessionHelper = IoC.Resolve<ISingleSessionHelper>();
                    var sesionId = filterContext.HttpContext.Session.SessionID;

                    var userName = sessionContext.UserSession.UserName;
                    if (!sessionSessionHelper.ValidatingUserSession(userName, sesionId))
                    {
                        IoC.Resolve<ILogManager>().GetLogger<Global>().Info(userName + " has been forced log out");
                        filterContext.HttpContext.Session.Abandon();
                        sessionContext.UserSession = null;
                        FormsAuthentication.SignOut();
                        var loginUrl = sessionSessionHelper.IsUserExist(userName) ? LoginUrl + "?isSessionTaken=true" : LoginUrl;

                        filterContext.HttpContext.RewritePath(loginUrl);
                        filterContext.Result = new RedirectResult(loginUrl);

                        IoC.Resolve<ILogManager>().GetLogger<Global>().Info("Invalid User Session");
                    }
                }

            }
        }

        public static bool CheckUrl(string requestedUrl)
        {
            return ExcludedUrls.Any(x => x.ToLower().Equals(requestedUrl));
        }
    }
}