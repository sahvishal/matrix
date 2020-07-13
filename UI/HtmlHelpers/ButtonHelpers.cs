using System.Web.Mvc;

namespace Falcon.App.UI.HtmlHelpers
{
  

    public static class ButtonHelpers
    {
        public static MvcHtmlString SubmitButton(this HtmlHelper helper, string value = "Submit", string id= "Submit")
        {
            return MvcHtmlString.Create(string.Format(@"<input type=""submit"" id=""{0}"" value=""{1}"" />", helper.AttributeEncode(id), helper.AttributeEncode(value)));
        }

        public static MvcHtmlString PostLink(this HtmlHelper helper, string url, string text)
        {
            return MvcHtmlString.Create(string.Format(@"<form action=""{0}"" method=""post"" class=""post-link-form""><div>", helper.AttributeEncode(url)) + helper.AntiForgeryToken() + helper.SubmitButton(text) + "</div></form>");
        }
    }
}