using System;
using System.Web;
using System.Web.WebPages;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.Lib
{
    public static class UrlValidator
    {
        public static bool IsUrlLocalToHost(HttpRequest request, string url)
        {
            if (url.IsEmpty())
            {
                return false;
            }

            Uri absoluteUri;
            if (Uri.TryCreate(url, UriKind.Absolute, out absoluteUri))
            {
                if (String.Equals(request.Url.Host, absoluteUri.Host, StringComparison.OrdinalIgnoreCase))
                    return true;
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Invalid Url" + url);
                return false;
            }
            bool isLocal = !url.StartsWith("http:", StringComparison.OrdinalIgnoreCase)
                           && !url.StartsWith("https:", StringComparison.OrdinalIgnoreCase)
                           && Uri.IsWellFormedUriString(url, UriKind.Relative);
            if( isLocal)
                return true;

            IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Invalid Url" + url);
            return false;
        }
    }
}