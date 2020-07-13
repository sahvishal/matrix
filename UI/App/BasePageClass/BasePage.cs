using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Audit;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Type = Falcon.App.Core.Audit.Enum.Type;

namespace Falcon.App.UI.App.BasePageClass
{
    public abstract class BasePage : Page
    {
        private long _modelId = 0;
        private Type _activityType;
        private readonly IAuditLogFilterHelper _auditLogFilterHelper = IoC.Resolve<IAuditLogFilterHelper>();
        private readonly IActivityLogService _activityLogService = IoC.Resolve<IActivityLogService>();
        protected void LogAudit(ModelType modelType, dynamic model, long customerId)
        {
            if (!IoC.Resolve<ISettings>().AuditEnabled) return;
            try
            {
                if (modelType == ModelType.Edit)
                {
                    _modelId = _auditLogFilterHelper.GetEditModelIdValue(model);
                }

                _activityType = modelType == ModelType.Edit && _modelId > 0
                    ? Type.Updated
                    : (modelType == ModelType.Edit ? Type.Created : Type.Retrieved);

                var logModel = _auditLogFilterHelper.GetActivityLogEditModel(this.Request, model, _activityType.ToString());

                if (logModel != null)
                {
                    if (customerId > 0)
                    {
                        logModel.CustomerId = customerId;
                    }
                    _auditLogFilterHelper.LogModel(modelType, logModel, model);
                }
                else
                {
                    var logger = IoC.Resolve<ILogManager>().GetLogger("BasePage");
                    logger.Info("Session is null while Saving Audit Data");
                }
                
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger("BasePage");
                logger.Error("Error in BasePage LogAudit");
                logger.Error("Message: " + ex.Message);
                logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        protected void LogFilterListPairAudit(dynamic filter, dynamic model)
        {

            if (!IoC.Resolve<ISettings>().AuditEnabled) return;
            try
            {
                _activityType = Type.Retrieved;

                var logModel = _auditLogFilterHelper.GetActivityLogEditModel(this.Request, model, _activityType.ToString());
                if (logModel != null)
                    _activityLogService.LogFilterModelPair(logModel, filter, model);
                else
                {
                    var logger = IoC.Resolve<ILogManager>().GetLogger("BasePage");
                    logger.Info("Session is null while Saving Audit Data");
                }
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger("BasePage");
                logger.Error("Error in BasePage LogFilterListPairAudit");
                logger.Error("Message: " + ex.Message);
                logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }
        protected void LogRelatedModel(dynamic filter, dynamic model, long customerId)
        {
            if (!IoC.Resolve<ISettings>().AuditEnabled) return;
            try
            {
                _activityType = Type.Retrieved;

                var logModel = _auditLogFilterHelper.GetActivityLogEditModel(this.Request, model, _activityType.ToString());

                if (logModel != null)
                {
                    if (customerId > 0)
                    {
                        logModel.CustomerId = customerId;
                    }
                    _activityLogService.LogRelatedModel(logModel, model);
                }
                else
                {
                    var logger = IoC.Resolve<ILogManager>().GetLogger("BasePage");
                    logger.Info("Session is null while Saving Audit Data");
                }
                
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger("BasePage");
                logger.Error("Error in BasePage LogRelatedModel");
                logger.Error("Message: " + ex.Message);
                logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

    }
}