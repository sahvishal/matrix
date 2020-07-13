using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Falcon.App.UI.HtmlHelpers
{
    public static class DateHelpers
    {
        public static MvcHtmlString DateFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes = null) where TModel : class
        {
            return DateFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString DateFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IDictionary<string, object> htmlAttributes) where TModel : class
        {
            htmlAttributes.Add("type", "date");
            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }
    }
}