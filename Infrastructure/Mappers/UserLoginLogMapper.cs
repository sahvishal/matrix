using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<UserLoginLog, UserLoginLogEntity>))]
    public class UserLoginLogMapper : DomainEntityMapper<UserLoginLog, UserLoginLogEntity>
    {
        protected override void MapDomainFields(UserLoginLogEntity entity, UserLoginLog domainObjectToMapTo)
        {
            domainObjectToMapTo.BrowserSession = entity.BrowserSessionId;
            domainObjectToMapTo.BrowserName = entity.BrowserType;
            domainObjectToMapTo.LogInDateTime = entity.LoginDatetime;
            domainObjectToMapTo.LogOutDateTime = entity.LogoutDatetime;
            domainObjectToMapTo.RefferedUrl = string.IsNullOrEmpty(entity.ReferredlUrl) ? null : new Uri(entity.ReferredlUrl);
            domainObjectToMapTo.SessionIP = entity.SessionIp;
            domainObjectToMapTo.UserId = entity.UserId;
            domainObjectToMapTo.Id = entity.UserLoginLogId;
            domainObjectToMapTo.DeviceKey = entity.DeviceKey;
            domainObjectToMapTo.MedicareToken = entity.MedicareToken;
        }

        protected override void MapEntityFields(UserLoginLog domainObject, UserLoginLogEntity entityToMapTo)
        {
            entityToMapTo.BrowserSessionId = domainObject.BrowserSession;
            entityToMapTo.BrowserType = domainObject.BrowserName;
            entityToMapTo.LoginDatetime = domainObject.LogInDateTime;
            entityToMapTo.LogoutDatetime = domainObject.LogOutDateTime;
            entityToMapTo.ReferredlUrl = domainObject.RefferedUrl != null ? domainObject.RefferedUrl.AbsoluteUri : string.Empty;
            entityToMapTo.SessionIp = domainObject.SessionIP;
            entityToMapTo.UserId = domainObject.UserId;
            entityToMapTo.UserLoginLogId = domainObject.Id;
            entityToMapTo.DeviceKey = domainObject.DeviceKey;
            entityToMapTo.MedicareToken = domainObject.MedicareToken;
        }
    }
}
