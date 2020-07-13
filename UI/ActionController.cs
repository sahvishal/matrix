using System.IO;
using System.Web.Mvc;

namespace Falcon.App.UI
{

    public abstract class ActionController : Controller
    {
        private const string CANONICAL_ACTION_NAME = "execute";

        public string CurrentAction { get; private set; }
        public string CurrentController { get; private set; }

        public string ContainerClass { get; set; }
        public string NavigationSection { get; set; }

        protected override void ExecuteCore()
        {
            if (NavigationSection == null)
            {
                object routeNavigationSection = ControllerContext.RouteData.Values["navigationSection"];
                NavigationSection = routeNavigationSection == null ? null : routeNavigationSection.ToString();
            }

            CurrentAction = ControllerContext.RouteData.Values["action"].ToString();
            CurrentController = ControllerContext.RouteData.Values["controller"].ToString();

            ControllerContext.RouteData.Values["action"] = GetControllerName();
            ControllerContext.RouteData.Values["controller"] = GetNamespace();
            bool succeeded = ActionInvoker.InvokeAction(ControllerContext, CANONICAL_ACTION_NAME);
            if (!succeeded)
            {
                HandleUnknownAction(CANONICAL_ACTION_NAME);
            }
        }

        private string GetControllerName()
        {
            return GetType().Name.ToLowerInvariant().Replace("controller", "");
        }

        private string GetNamespace()
        {
            string[] namespaces = GetType().Namespace.Split('.');
            string immediateNamespace = namespaces[namespaces.Length - 1];
            return immediateNamespace;
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter stringWriter = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, stringWriter);
                viewResult.View.Render(viewContext, stringWriter);

                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
