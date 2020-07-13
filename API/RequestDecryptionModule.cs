using System;
using System.Configuration;
using System.Linq;
using System.Web;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application;

namespace API
{
    public class RequestDecryptionModule : IHttpModule
    {
        private readonly int[] _codes = { 500, 403, 404, 401 };
        private static readonly string[] ExcludedUrls =
        {
            "/api/communication/webhook/twillioresponse"
        };
        public void Init(HttpApplication context)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["IsDevEnvironment"])) return;

            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }
        private void context_EndRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var httpRequest = app.Context.Request;
            var url = httpRequest.RawUrl.ToLower();
            if (ExcludedUrls.Contains(url)) return;

            var applicationIdentity = httpRequest.Headers["ApplicationIdentity"];
            if (!string.IsNullOrWhiteSpace(applicationIdentity) && applicationIdentity == ConfigurationManager.AppSettings["ApplicationIdentity"]) return;

            if (!string.IsNullOrWhiteSpace(applicationIdentity))
            {
                var appToken = app.Context.Request.Headers.GetValues("ExternalUser").FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(appToken))
                {
                    return;
                }
            }

            try
            {
                if (Array.IndexOf(_codes, app.Response.StatusCode) == -1)
                {
                    var filter = (OutputFilterStream)app.Context.Items["filter"];
                    var stream = filter.ReadStream();
                    app.Context.Response.Clear();
                    app.Context.Response.Write(stream.Encrypt());
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<RequestDecryptionModule>().Error("Exception on End Request\n", ex);
                throw;
            }
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var filter = new OutputFilterStream(app.Context.Response.Filter);
            app.Context.Response.Filter = filter;
            app.Context.Items["filter"] = filter;

            var httpRequest = app.Context.Request;

            var applicationIdentity = httpRequest.Headers["ApplicationIdentity"];
            if (!string.IsNullOrWhiteSpace(applicationIdentity) && applicationIdentity == ConfigurationManager.AppSettings["ApplicationIdentity"]) return;

            if (!string.IsNullOrWhiteSpace(applicationIdentity))
            {
                try
                {
                    IoC.Resolve<ILogManager>().GetLogger<RequestDecryptionModule>().Info("Getting ApplicationAuthentication from database...");
                    app.Context.Request.Headers.Add("ExternalUser", "ExternalUser");
                    var appAuthModel = IoC.Resolve<IApplicationAuthenticationRepository>().GetByAppId(Rijndael.Decrypt(applicationIdentity));
                    if (appAuthModel != null)
                    {
                        app.Context.Request.Headers.Add("AppTokenFromDatabase", Rijndael.Encrypt(appAuthModel.Token));
                        return;
                    }
                    else
                    {
                        IoC.Resolve<ILogManager>().GetLogger<RequestDecryptionModule>().Error("ApplicationAuthentication not found by AppId: " + applicationIdentity);
                        throw new UnauthorizedException();
                    }
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<RequestDecryptionModule>().Error("Exception on context_BeginRequest for external user access\n", ex);

                    throw new UnauthorizedException();
                }
            }

            var url = httpRequest.RawUrl.ToLower();
            if (ExcludedUrls.Contains(url)) return;

            url = httpRequest.QueryString["q"];

            var rawUrl = httpRequest.RawUrl.ToLower();
            if ("/favicon.ico" != rawUrl && !rawUrl.EndsWith("/users/login/post") && Array.IndexOf(_codes, app.Context.Response.StatusCode) == -1)
            {
                try
                {
                    var decryptedUrl = rawUrl.Substring(1);
                    if (decryptedUrl.Length > 0)
                    {
                        var rewritePathUrl = url.Decrypt();
                        app.Context.RewritePath(httpRequest.Url.LocalPath + rewritePathUrl);
                    }
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<RequestDecryptionModule>().Error("Exception on context_BeginRequest\n", ex);
                    throw new HttpException(404, "Resource not found");
                }

            }

        }
        public void Dispose()
        {

        }
    }
}