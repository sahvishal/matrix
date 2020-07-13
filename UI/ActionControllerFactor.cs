using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI
{
    public class ActionControllerFactory : DefaultControllerFactory
    {

        private readonly string _assemblyNamespace;

        public ActionControllerFactory()
        {
            _assemblyNamespace = Assembly.GetExecutingAssembly().GetName().Name;
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsAbstract && !t.IsInterface))
            {
                if (typeof(ActionController).IsAssignableFrom(type))
                {
                    //todo: This will not work, as we need fully qualifined names spaces, change at a later datyte.
                    var namespaceParts = type.Namespace.Split('.');
                    string controllerName = namespaceParts[namespaceParts.Length - 1].ToUpperInvariant();
                    string actionName = type.Name.ToUpperInvariant();
                    IoC.Register<IController>(controllerName + "." + actionName, type);
                }
                else if (typeof(Controller).IsAssignableFrom(type))
                {
                    IoC.Register<IController>(type.FullName.ToUpperInvariant(), type);
                }
            }
        }

        [DebuggerNonUserCode]
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            controllerName = requestContext.RouteData.DataTokens.ContainsKey("area")
                                 ? _assemblyNamespace + ".Areas." + requestContext.RouteData.DataTokens["area"] +
                                   ".Controllers." + controllerName
                                 : _assemblyNamespace + ".Controllers." + controllerName;

            try
            {
                string name = (controllerName + "." + requestContext.RouteData.GetRequiredString("action") + "Controller").ToUpperInvariant();
                return IoC.Resolve<IController>(name);
            }
            catch
            {
                string toUpperInvariant = (controllerName + "Controller").ToUpperInvariant();
                return IoC.Resolve<IController>(toUpperInvariant);
            }
        }
    }
}

//Falcon.App.UI.Areas.Users.Controllers