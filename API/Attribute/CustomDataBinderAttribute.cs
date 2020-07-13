using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using API.Areas.Application.Controllers;
using API.Enum;
using API.Impl;

namespace API.Attribute
{
    public class CustomDataBinderAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controller = SetController(actionContext);
            if (controller == null) return;

            SetMethodType(actionContext, controller);

            if (controller.MethodType == HttpMethodType.Get || controller.MethodType == HttpMethodType.Delete) return;

            if (actionContext.ActionArguments == null) return;

            controller.SetActionArguments(actionContext.ActionArguments);

            if (!actionContext.ModelState.IsValid)
            {
                controller.SetValidationResult(actionContext.ModelState);
                throw new ValidationFailureException();
            }

            foreach (var argument in actionContext.ActionArguments)
            {
                FillActionAttribute(argument.Value);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var controller = SetController(actionExecutedContext.ActionContext);
            if (controller != null && actionExecutedContext.Exception == null)
            {
                var data = controller.SetData((actionExecutedContext.Response.Content as ObjectContent).Value);

                if (!data.IsFeedbackSet)
                    data.SetSuccessMessage("Request succeeded successfully.");

                actionExecutedContext.Response.Content = new ObjectContent(controller.ResponseModel.GetType(), data, new JsonMediaTypeFormatter());
            }
        }

        private void FillActionAttribute(object actionArgument)
        {
            if (actionArgument == null) return;


            foreach (var item in actionArgument.GetType().GetProperties().Where(x => !x.PropertyType.IsValueType && !x.PropertyType.IsPrimitive && !x.PropertyType.FullName.StartsWith("System.")).ToArray())
            {
                FillActionAttribute(item.GetValue(actionArgument));
            }
        }

        private void SetMethodType(HttpActionContext actionContext, BaseController controller)
        {
            var method = actionContext.Request.Method.Method.ToLower();

            switch (method)
            {
                case "get":
                    controller.SetResponseModel(HttpMethodType.Get);
                    break;
                case "delete":
                    controller.SetResponseModel(HttpMethodType.Delete);
                    break;
                case "post":
                    controller.SetPostResponseModel(HttpMethodType.Post);
                    break;
                case "put":
                    controller.SetPostResponseModel(HttpMethodType.Put);
                    break;
            }
        }

        private BaseController SetController(HttpActionContext actionContext)
        {
            var controller = (actionContext.ControllerContext.Controller as BaseController);
            if (controller == null) return null;//throw new InvalidOperationException("Invalid controller");
            return controller;
        }
    }
}