using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Audit;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Audit.Helper;
using Falcon.App.Core.Audit.ViewModel;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Impl;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Type = Falcon.App.Core.Audit.Enum.Type;

namespace Falcon.App.UI.Filters
{
    public class AuditLogActionFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        // private readonly IActivityLogDeleteService _activityLogDeleteService;
        private long _modelId = 0;
        // private dynamic _deletedEntity = null;
        private Type _activityType;
        private readonly IActivityLogService _activityLogService;
        private readonly ISessionContext _sessionContext;

        private readonly IAuditLogFilterHelper _auditLogFilterHelper;

        public AuditLogActionFilter()
        {
            _settings = IoC.Resolve<ISettings>();
            _sessionContext = IoC.Resolve<ISessionContext>();
            _activityLogService = IoC.Resolve<IActivityLogService>();
            _logger = IoC.Resolve<ILogManager>().GetLogger("AuditLogActionFilter");
            // _activityLogDeleteService = IoC.Resolve<IActivityLogDeleteService>();

            _auditLogFilterHelper = IoC.Resolve<IAuditLogFilterHelper>();
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {

                ParseRequestOnActionExecuting(filterContext);

            }
            catch (Exception ex)
            {
                _logger.Error("While OnActionExecuting", ex);
            }
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                ParseRequestOnActionExecuted(filterContext);
            }
            catch (Exception ex)
            {
                _logger.Error("While OnActionExecuted", ex);
            }
        }

        private void ParseRequestOnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.HttpContext.Request;

            //if ((request.RequestType.ToUpper() == "POST" || request.RequestType.ToUpper() == "DELETE") && (actionName.Contains("remove") || actionName.Contains("delete")))
            //{
            //    _deletedEntity = _activityLogDeleteService.GetEntity(filterContext);
            //    return;
            //}

            if (filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(true).Any(m => m.GetType() == typeof(IgnoreAuditAttribute)))
                return;

            if (filterContext.ActionDescriptor.GetCustomAttributes(true).Any(m => m.GetType() == typeof(IgnoreAuditAttribute)))
                return;

            if (request.RequestType.ToUpper() != "POST" || !filterContext.ActionParameters.Keys.Any(x => x.ToLower().Contains("model")) || !_settings.AuditEnabled) return;

            if (_sessionContext.UserSession == null) return;

            var model = filterContext.ActionParameters.FirstOrDefault(x => x.Key.ToLower().Contains("model")).Value;

            if (model == null) return;

            var modelName = (string)model.GetType().Name;

            var modelType = ReflectionHelper.GetModelType(model);
            var modelState = filterContext.Controller.ViewData.ModelState;

            if (modelType == ModelType.Edit)
            {
                _modelId = _auditLogFilterHelper.GetEditModelIdValue(model);
            }

            _activityType = modelType == ModelType.Edit && _modelId > 0
                ? Type.Updated
                : (modelType == ModelType.Edit ? Type.Created : Type.Retrieved);

            var logModel = _auditLogFilterHelper.GetActivityLogEditModel(request, model, _activityType.ToString());

            var customer = filterContext.ActionParameters.FirstOrDefault(x => x.Key.ToLower().Equals("customerid"));

            int customerId = Convert.ToInt32(customer.Value);

            if (logModel != null)
            {
                logModel.CustomerId = customerId;

                bool isLogged = ExceptionClassLogging(modelName, model, logModel);

                if (!isLogged && modelState.IsValid && (_activityType == Type.Created || _activityType == Type.Updated))
                {
                    _activityLogService.LogEditModel(logModel, model);
                }
            }
            else
            {
                _logger.Info("Session is null while Saving Audit Data");
            }
        }

        private void ParseRequestOnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(true).Any(m => m.GetType() == typeof(IgnoreAuditAttribute)))
                return;

            if (filterContext.ActionDescriptor.GetCustomAttributes(true).Any(m => m.GetType() == typeof(IgnoreAuditAttribute)))
                return;

            if (!(filterContext.Result is ViewResultBase || filterContext.Result is JsonResult || filterContext.Result is RedirectResult || filterContext.Result is ContentResult))
                return;

            if (_sessionContext.UserSession == null) return;

            dynamic model = null;

            if ((filterContext.Result is ViewResultBase)) model = ((ViewResultBase)filterContext.Result).Model;
            if ((filterContext.Result is JsonResult)) model = ((JsonResult)filterContext.Result).Data;
            if ((filterContext.Result is RedirectResult)) model = ((RedirectResult)filterContext.Result);
            if ((filterContext.Result is ContentResult)) model = ((ContentResult)filterContext.Result);

            if (model == null) return;

            _activityType = Type.Retrieved;

            var customerId = 0;
            var customer = filterContext.ActionDescriptor.GetParameters().FirstOrDefault(x => x.ParameterName.ToLower().Equals("customerid"));

            if (customer != null)
            {
                customerId = Convert.ToInt32(filterContext.Controller.ValueProvider.GetValue(customer.ParameterName).AttemptedValue);
            }

            HttpRequestBase request = filterContext.HttpContext.Request;

            if (_settings.AuditEnabled)
            {
                if (request.RequestType.ToUpper() == "GET")
                {
                    var logModel = _auditLogFilterHelper.GetActivityLogEditModel(request, model, _activityType.ToString());

                    if (logModel != null)
                    {
                        logModel.CustomerId = customerId;

                        var modelType = ReflectionHelper.GetModelType(model);

                        modelType = GetModelTypeForExceptions(model, modelType);

                        _auditLogFilterHelper.AsyncLogModel(modelType, logModel, model);    
                    }
                    else
                    {
                        _logger.Info("Session is null while Saving Audit Data");
                    }
                }
                else if ((request.RequestType.ToUpper() == "POST" || request.RequestType.ToUpper() == "DELETE") &&
                         (filterContext.ActionDescriptor.ActionName.ToLower().Contains("remove") ||
                          filterContext.ActionDescriptor.ActionName.ToLower().Contains("delete")))
                {
                    //if (_activityLogDeleteService.IsDeleted(filterContext))
                    //{
                    //    var logModel = CreateModel(request);

                    //    logModel.CustomerId = customerId;

                    //    _activityLogService.LogDeleteActivity(logModel, _deletedEntity);
                    //}
                }
                else if (filterContext.ActionDescriptor.GetCustomAttributes(true).Any(m => m.GetType() == typeof(MustAuditAttribute)))
                {

                    var logModel = _auditLogFilterHelper.GetActivityLogEditModel(request, model, _activityType.ToString());

                    if (logModel != null)
                    {
                        logModel.CustomerId = customerId;

                        var modelType = ReflectionHelper.GetModelType(model);

                        _auditLogFilterHelper.AsyncLogModel(modelType, logModel, model);
                    }
                    else
                    {
                        _logger.Info("Session is null while Saving Audit Data");
                    }

                }

            }

        }

        private ModelType GetModelTypeForExceptions(dynamic model, dynamic modelType)
        {
            if (model is HealthAssessmentEditModel)
            {
                modelType = ModelType.List;
            }
            return modelType;
        }
        
        private bool ExceptionClassLogging(string modelName, object model, ActivityLogEditModel logModel)
        {
            if (modelName.ToLower().Equals("healthassessmenteditmodel"))
            {
                 _activityLogService.LogListModel(logModel, model);
                return true;
            }

            if (modelName.ToLower().Equals("massregistrationlistmodel"))
            {
                 LogMassRegistrationModel(model, logModel);
                return true;
            }

            if (modelName.ToLower().Equals("usereditmodel"))
            {
                 LogUserEditModel(model, logModel);
                return true;
            }
            return false;
        }
        
        private void LogMassRegistrationModel(dynamic model, ActivityLogEditModel logModel)
        {
            var registrationValidator = IoC.Resolve<MassRegistrationEditModelValidator>();
            foreach (var registrationEditModel in ((MassRegistrationListModel)model).Registrations)
            {
                if (registrationEditModel.HomeNumber != null &&
                    !string.IsNullOrEmpty(registrationEditModel.HomeNumber.ToString()))
                    registrationEditModel.HomeNumber =
                        PhoneNumber.Create(registrationEditModel.HomeNumber.ToNumber().ToString(),
                            PhoneNumberType.Home);
                var result = registrationValidator.Validate(registrationEditModel);
                if (result.IsValid)
                {
                    logModel.Action = Type.Created.ToString();
                    _activityLogService.LogEditModel(logModel, registrationEditModel);
                }
            }
        }

        private void LogUserEditModel(dynamic model, ActivityLogEditModel logModel)
        {
            var userEditModel = (UserEditModel) model;
            if (userEditModel.UsersRoles != null && userEditModel.UsersRoles.Count() > 0)
            {
                if (!userEditModel.UsersRoles.Any(ur => ur.GetSystemRoleId == (long)Roles.MedicalVendorUser))
                    userEditModel.PhysicianProfile = null;
            }
            var userValidator = IoC.Resolve<UserEditModelValidator>();
            var result = userValidator.Validate(model);
            if (result.IsValid)
            {
                _activityLogService.LogEditModel(logModel, userEditModel);
            }
        }

    }
}