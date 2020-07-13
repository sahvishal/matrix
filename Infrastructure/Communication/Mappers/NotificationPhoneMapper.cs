using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Communication.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<NotificationPhoneMapper, NotificationPhoneEntity>))]
    public class NotificationPhoneMapper : Mapper<NotificationPhone, NotificationPhoneEntity>
    {
        private readonly IPhoneNumberFactory _phoneNumberFactory;
        public NotificationPhoneMapper(IPhoneNumberFactory phoneNumberFactory)
        {
            _phoneNumberFactory = phoneNumberFactory;
        }

        public override NotificationPhone Map(NotificationPhoneEntity objectToMap)
        {
            return new NotificationPhone(objectToMap.NotificationPhoneId)
            {
                PhoneCell = _phoneNumberFactory.CreatePhoneNumber(objectToMap.PhoneCell, PhoneNumberType.Mobile),
                Message = objectToMap.Message,
                ServicedBy = objectToMap.ServicedBy
            };
        }

        public override NotificationPhoneEntity Map(NotificationPhone objectToMap)
        {
            return new NotificationPhoneEntity(objectToMap.Id)
            {
                PhoneCell = objectToMap.PhoneCell != null ? objectToMap.PhoneCell.AreaCode + objectToMap.PhoneCell.Number : "",
                Message = objectToMap.Message,
                ServicedBy = objectToMap.ServicedBy
            };
        }
    }
}