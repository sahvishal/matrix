using System;
using System.Text;
using System.Web;

namespace Falcon.App.UI.Extentions
{
    public static class HttpResponseExtensions
    {
        public static void RedirectUser(this HttpResponse response, string url, bool endResponse=false)
        {
            if (response.IsRequestBeingRedirected)
                return;
            url = Uri.EscapeUriString(url);
            url = ValidateUrl(url);
            response.Redirect(url, endResponse);
            var context = HttpContext.Current;
            if (context != null)
            {
                context.ApplicationInstance.CompleteRequest();
            }
        }

        public static void RedirectUser(this HttpResponseBase response, string url)
        {
            if (response.IsRequestBeingRedirected)
                return;
            url = Uri.EscapeUriString(url);
            url = ValidateUrl(url);
            response.Redirect(url, false);
            var context = HttpContext.Current;
            if (context != null)
            {
                context.ApplicationInstance.CompleteRequest();
            }
        }

        private static string ValidateUrl(string currurl)
        {
             
            string querystring = null;
            string url = null;

            var iqs = currurl.IndexOf('?');
            if (iqs >= 0)
            {
                querystring = (iqs < currurl.Length - 1) ? currurl.Substring(iqs + 1) : String.Empty;
            }

            if (querystring == null) return currurl;
            url = currurl.Substring(0, iqs);
            var qscoll = HttpUtility.ParseQueryString(querystring);

            var sb = new StringBuilder("?");
            foreach (var s in qscoll.AllKeys)
            {
                sb.Append(s + "=" + System.Web.Security.AntiXss.AntiXssEncoder.UrlEncode(qscoll[s]) + "&");
            }

            return  url + sb.ToString().Substring(0, sb.Length - 1);
        }
    }
}