using Falcon.App.Core.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Application
{
    public interface IPhoneNumberFactory
    {
        PhoneNumber CreatePhoneNumber(string phoneNumber, PhoneNumberType phoneNumberType);
    }
}