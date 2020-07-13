using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;

namespace API.Attribute
{
    public class BasicExceptionFilterAtribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var controller = (actionExecutedContext.ActionContext.ControllerContext.Controller as BaseController);

            var logger = IoC.Resolve<ILogManager>().GetLogger("api");

            if (controller != null && actionExecutedContext.Exception != null)
            {
                logger.Error("Message: " + actionExecutedContext.Exception.Message + "\n StackTrace: " + actionExecutedContext.Exception.StackTrace);

                if (actionExecutedContext.Exception is UnauthorizedException)
                {
                    controller.ResponseModel.SetUnauthorizedMessage(actionExecutedContext.Exception.Message);
                }
                else
                {
                    controller.ResponseModel.SetErrorMessage(actionExecutedContext.Exception.Message);
                }

                var objectContent = new ObjectContent(controller.ResponseModel.GetType(), controller.ResponseModel, new JsonMediaTypeFormatter());

                if (actionExecutedContext.Response == null)
                    actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.OK);

                actionExecutedContext.Response.Content = objectContent;
            }
            else if (actionExecutedContext.Exception != null)
            {
                if (actionExecutedContext.Exception is UnauthorizedException)
                {
                    actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    actionExecutedContext.Response.Content = new ObjectContent(typeof(string), "Unauthorized access", new JsonMediaTypeFormatter());
                }

                logger.Error("Message: " + actionExecutedContext.Exception.Message + "\n StackTrace: " + actionExecutedContext.Exception.StackTrace);
            }
        }
    }
}