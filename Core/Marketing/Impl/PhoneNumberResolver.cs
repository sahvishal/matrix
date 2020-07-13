using System;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Marketing.Impl
{
    public class PhoneNumberResolver : IPhoneNumberResolver
    {
        public PhoneNumber GetIncomingPhoneNumber()
        {
            throw new NotImplementedException();
        }

        public PhoneNumber GetIncomingPhoneNumber(MarketingMaterialType marketingMaterialType)
        {
            throw new NotImplementedException();
        }
    }
}