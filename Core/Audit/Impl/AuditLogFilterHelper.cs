using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Audit.ViewModel;

namespace Falcon.App.Core.Audit.Impl
{
    [DefaultImplementation]
    public class AuditLogFilterHelper : IAuditLogFilterHelper
    {
        private readonly ISessionContext _sessionContext;
        private readonly IActivityLogService _activityLogService;

        public AuditLogFilterHelper(ISessionContext sessionContext, IActivityLogService activityLogService)
        {
            _sessionContext = sessionContext;
            _activityLogService = activityLogService;
        }

        public long GetEditModelIdValue(dynamic model)
        {
            var exceptions = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("AdminEditModel","AccountId")
            };
            var type = (System.Type)model.GetType();
            if (exceptions.Exists(x => x.Key == type.Name))
            {
                var propertyName = exceptions.Find(x => x.Key == type.Name).Value;

                return GetIdValue(propertyName, model);

            }

            return GetIdValue("Id", model);
        }

        public long GetIdValue(string propertyName, dynamic model)
        {
            long idValue = 0;
            var idProp = model.GetType().GetProperty(propertyName);
            if (idProp != null)
            {
                idValue = long.Parse(idProp.GetValue(model).ToString());
            }

            return idValue;
        }

        public ActivityLogEditModel GetActivityLogEditModel(dynamic request, dynamic model, string activityType)
        {
            if(_sessionContext == null || _sessionContext.UserSession == null) return null;

            var logModel = new ActivityLogEditModel
            {
                Action = activityType,
                UrlAccessed = request.FilePath ?? string.Empty,
                ModelFullName = model.GetType().FullName,
                ModelName = model.GetType().Name,
                RequestType = request.RequestType,
                Timestamp = DateTime.Now,
                UserLogId = _sessionContext.UserSession.UserLoginLogId,
                AccessById = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
            };

            return logModel;
        }

        public ActivityLogEditModel GetActivityLogEditModel(string filePath, string requestType, dynamic model, string activityType)
        {
            var logModel = new ActivityLogEditModel
            {
                Action = activityType,
                UrlAccessed = filePath,
                ModelFullName = model.GetType().FullName,
                ModelName = model.GetType().Name,
                RequestType = requestType,
                Timestamp = DateTime.Now,
                UserLogId = _sessionContext.UserSession.UserLoginLogId,
                AccessById = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
            };

            return logModel;
        }

        public async void AsyncLogModel(ModelType modelType, ActivityLogEditModel logModel, dynamic model, bool fromAPI = false)
        {
            if (modelType == ModelType.List)
            {
               await _activityLogService.LogListModel(logModel, model, fromAPI);
            }
            else if (modelType == ModelType.View)
            {
                await _activityLogService.LogViewModel(logModel, model, fromAPI);
            }
            else if (modelType == ModelType.Edit)
            {
                var modelId = GetEditModelIdValue(logModel);

                if (modelId > 0)
                {
                    await _activityLogService.LogEditModel(logModel, model, fromAPI);
                }
                else
                {
                    await _activityLogService.LogViewModel(logModel, model, fromAPI);
                }

            }
            else
            {
                await _activityLogService.LogEditModel(logModel, model, fromAPI);
            }
        }

        public void LogModel(ModelType modelType, ActivityLogEditModel logModel, dynamic model, bool fromAPI = false)
        {
            if (modelType == ModelType.List)
            {
                _activityLogService.LogListModel(logModel, model, fromAPI);
            }
            else if (modelType == ModelType.View)
            {
                _activityLogService.LogViewModel(logModel, model, fromAPI);
            }
            else if (modelType == ModelType.Edit)
            {
                var modelId = GetEditModelIdValue(logModel);

                if (modelId > 0)
                {
                    _activityLogService.LogEditModel(logModel, model, fromAPI);
                }
                else
                {
                    _activityLogService.LogViewModel(logModel, model, fromAPI);
                }

            }
            else
            {
                _activityLogService.LogEditModel(logModel, model, fromAPI);
            }
        }
    }
}
