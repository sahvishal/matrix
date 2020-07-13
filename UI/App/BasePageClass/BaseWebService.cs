using System;
using System.Collections.Generic;
using System.Web.Services;
using Falcon.App.Core.Application;
using Falcon.App.Core.Audit;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Type = Falcon.App.Core.Audit.Enum.Type;

namespace Falcon.App.UI.App.BasePageClass
{
    public abstract class BaseWebService : WebService
    {
        private long _modelId = 0;
        private Type _activityType;
        public List<object> logList = new List<object>();

        private readonly IAuditLogFilterHelper _auditLogFilterHelper = IoC.Resolve<IAuditLogFilterHelper>();
        private readonly IActivityLogService _activityLogService = IoC.Resolve<IActivityLogService>();
        protected void LogAudit(ModelType modelType, dynamic model, string filePath, string requestType,long customerId)
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


                var logModel = _auditLogFilterHelper.GetActivityLogEditModel(filePath, requestType, model, _activityType.ToString());
                if (customerId > 0)
                {
                    logModel.CustomerId = customerId;
                } 
                _auditLogFilterHelper.LogModel(modelType, logModel, model);
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger("BaseWebService");
                logger.Error("Error in BaseWebService LogAudit", ex);
            }
        }
        protected void LogFilterListPairAudit(ModelType modelType, dynamic filter, dynamic model, string filePath, string requestType)
        {
            if (!IoC.Resolve<ISettings>().AuditEnabled) return;
            try
            {
                _activityType = modelType == ModelType.Edit
                        ? Type.Updated
                        : (modelType == ModelType.Edit ? Type.Created : Type.Retrieved);

                var logModel = _auditLogFilterHelper.GetActivityLogEditModel(filePath, requestType, model, _activityType.ToString());
                _activityLogService.LogFilterModelPair(logModel, filter, model);
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger("BaseWebService");
                logger.Error("Error in BaseWebService LogFilterListPairAudit", ex);
            }
        }

        protected void LogRelatedModel(dynamic filter, dynamic model, string filePath, string requestType, long customerId)
        {
            if (!IoC.Resolve<ISettings>().AuditEnabled) return;
            try
            {
                _activityType = Type.Retrieved;

                var logModel = _auditLogFilterHelper.GetActivityLogEditModel(filePath, requestType, model, _activityType.ToString());
                if (customerId > 0)
                {
                    logModel.CustomerId = customerId;
                } 
                _activityLogService.LogRelatedModel(logModel, model);
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger("BaseWebService");
                logger.Error("Error in BaseWebService LogRelatedModel", ex);
            }
        }
    }
}