using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Audit;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Audit.Helper;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Type = Falcon.App.Core.Audit.Enum.Type;

namespace API.Filters
{
    public class AuditLogActionFilter : ActionFilterAttribute
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        //private readonly IActivityLogDeleteService _activityLogDeleteService;
        private long _modelId = 0;
        //private dynamic _deletedEntity = null;
        private Type _activityType;
        private readonly ISessionContext _sessionContext;
        private readonly IActivityLogService _activityLogService;

        private readonly IAuditLogFilterHelper _auditLogFilterHelper;

        public AuditLogActionFilter()
        {
            _auditLogFilterHelper = IoC.Resolve<IAuditLogFilterHelper>();
            _settings = IoC.Resolve<ISettings>();
            _logger = IoC.Resolve<ILogManager>().GetLogger("AuditLogActionFilter");
            //_activityLogDeleteService = IoC.Resolve<IActivityLogDeleteService>();

            _activityLogService = IoC.Resolve<IActivityLogService>();
            _sessionContext = IoC.Resolve<ISessionContext>();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                ParseRequestOnActionExecuting(actionContext);
            }
            catch (Exception ex)
            {
                _logger.Error("While API OnActionExecuting", ex);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                ParseRequestOnActionExecuted(actionExecutedContext);
            }
            catch (Exception ex)
            {
                _logger.Error("While API OnActionExecuted", ex);
            }
        }


        private void ParseRequestOnActionExecuting(HttpActionContext actionContext)
        {
            var request = HttpContext.Current.Request;

            //var actionName = actionContext.ActionDescriptor.ActionName.ToLower();
            //if ((request.RequestType.ToUpper() == "POST" || request.RequestType.ToUpper() == "DELETE") && (actionName.Contains("remove") || actionName.Contains("delete")))
            //{
            //    _deletedEntity = _activityLogDeleteService.GetEntity(actionContext);
            //    return;
            //}

            if (actionContext.ActionDescriptor.ControllerDescriptor.ControllerType.GetCustomAttributes(true).Any(m => m.GetType() == typeof(IgnoreAuditAttribute)))
                return;

            if (actionContext.ActionDescriptor.ReturnType.GetCustomAttributes(true).Any(m => m.GetType() == typeof(IgnoreAuditAttribute)))
                return;

            if (request.RequestType.ToUpper() != "POST" || !actionContext.ActionArguments.Any(x => x.Key.ToLower().Contains("model") || x.Key.ToLower().Contains("filter")) || !_settings.AuditEnabled) return;

            if (_sessionContext.UserSession == null) return;

            //var model = actionContext.ActionArguments["model"];
            var model = actionContext.ActionArguments.First(x => x.Key.ToLower().Contains("model")).Value;
            if (model == null)
            {
                model = actionContext.ActionArguments.First(x => x.Key.ToLower().Contains("filter")).Value;

                if (model == null) return;
            }

            var modelType = ReflectionHelper.GetModelType(model);
            var modelState = actionContext.ModelState;

            if (modelType == ModelType.Edit)
            {
                _modelId = _auditLogFilterHelper.GetEditModelIdValue(model);
            }
            _activityType = modelType == ModelType.Edit && _modelId > 0
               ? Type.Updated
               : (modelType == ModelType.Edit ? Type.Created : Type.Retrieved);

            var logModel = _auditLogFilterHelper.GetActivityLogEditModel(request, model, _activityType.ToString());
            if (logModel != null)
            {
                if (modelState.IsValid && (_activityType == Type.Created || _activityType == Type.Updated))
                {
                    _activityLogService.LogEditModel(logModel, model, true);
                }
            }
            else
            {
                _logger.Info("Session is null while Saving Audit Data");
            }

        }

        private void ParseRequestOnActionExecuted(HttpActionExecutedContext actionContext)
        {

            var request = HttpContext.Current.Request;

            if (actionContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerType.GetCustomAttributes(true).Any(m => m.GetType() == typeof(IgnoreAuditAttribute)))
                return;

            if (actionContext.ActionContext.ActionDescriptor.ReturnType.GetCustomAttributes(true).Any(m => m.GetType() == typeof(IgnoreAuditAttribute)))
                return;

            if (!_settings.AuditEnabled) return;

            if (_sessionContext.UserSession == null) return;

            var responseModel = actionContext.Response.Content as ObjectContent;

            if (responseModel == null) return;

            var model = responseModel.Value; //holding the returned value

            if (model == null) return;

            _activityType = Type.Retrieved;

            if (request.RequestType.ToUpper() == "GET")
            {
                var logModel = _auditLogFilterHelper.GetActivityLogEditModel(request, model, _activityType.ToString());

                var modelType = ReflectionHelper.GetModelType(model);
                if (logModel != null)
                {
                    _auditLogFilterHelper.AsyncLogModel(modelType, logModel, model, true);
                }
                else
                {
                    _logger.Info("Session is null while Saving Audit Data");
                }


            }
            //else if ((request.RequestType.ToUpper() == "POST" || request.RequestType.ToUpper() == "DELETE") &&
            //         (actionContext.ActionContext.ActionDescriptor.ActionName.ToLower() == "remove" ||
            //          actionContext.ActionContext.ActionDescriptor.ActionName.ToLower() == "delete"))
            //{

            //    if (!_activityLogDeleteService.IsDeleted(actionContext)) return;

            //    var logModel = new ActivityLogEditModel
            //    {
            //        Action = Type.Deleted.ToString(),
            //        UrlAccessed = request.FilePath ?? string.Empty,
            //        ModelFullName = _deletedEntity != null ? _deletedEntity.GetType().FullName : string.Empty,
            //        ModelName = _deletedEntity != null ? _deletedEntity.GetType().Name : string.Empty,
            //        RequestType = request.RequestType,
            //        Timestamp = DateTime.UtcNow,
            //        UserLogId =
            //            _sessionContext != null && _sessionContext.UserSession != null
            //                ? _sessionContext.UserSession.GetUserLog()
            //                : 0,
            //        AccessById = _sessionContext.UserSession.UserId
            //    };
            //    _activityLogService.LogDeleteActivity(logModel, _deletedEntity);
            //}
            else if (
                actionContext.ActionContext.ActionDescriptor.ReturnType.GetCustomAttributes(true)
                    .Any(m => m.GetType() == typeof(MustAuditAttribute)))
            {

                var logModel = _auditLogFilterHelper.GetActivityLogEditModel(request, model, _activityType.ToString());

                var modelType = ReflectionHelper.GetModelType(model);

                if (logModel != null)
                {
                    _auditLogFilterHelper.AsyncLogModel(modelType, logModel, model, true);
                }
                else
                {
                    _logger.Info("Session is null while Saving Audit Data");
                }
            }

        }
    }
}