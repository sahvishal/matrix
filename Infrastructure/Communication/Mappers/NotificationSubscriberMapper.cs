using System.Data.SqlTypes;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Communication.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<NotificationSubscriber, NotificationSubscribersEntity>))]
    public class NotificationSubscriberMapper : Mapper<NotificationSubscriber, NotificationSubscribersEntity>
    {
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        public NotificationSubscriberMapper(IPhoneNumberFactory phoneNumberFactory)
        {
            _phoneNumberFactory = phoneNumberFactory;
        }

        public override NotificationSubscriber Map(NotificationSubscribersEntity objectToMap)
        {
            return new NotificationSubscriber(objectToMap.NotificationSubscriberId)
            {
                DateCreated = objectToMap.DateCreated.GetValueOrDefault(SqlDateTime.MinValue.Value),
                DateModified = objectToMap.DateModified,
                Email = new Email(objectToMap.Email),
                Name = objectToMap.Name,
                Phone = _phoneNumberFactory.CreatePhoneNumber(objectToMap.Phone, PhoneNumberType.Unknown),
                UserId = objectToMap.UserId,
                NotificationTypeId = objectToMap.NotificationTypeId,
            };
        }

        public override NotificationSubscribersEntity Map(NotificationSubscriber objectToMap)
        {
            return new NotificationSubscribersEntity(objectToMap.Id)
            {
                DateCreated = objectToMap.DateCreated,
                DateModified = objectToMap.DateModified,
                Email = objectToMap.Email.ToString(),
                Phone = objectToMap.Phone.ToString(),
                IsNew = objectToMap.Id == 0,
                UserId = objectToMap.UserId,
                NotificationTypeId = objectToMap.NotificationTypeId,
            };
        }
    }
}