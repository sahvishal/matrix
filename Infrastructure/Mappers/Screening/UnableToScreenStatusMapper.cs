using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Screening
{
    // TODO: Is UnableToScreenStatus a DomainObject? Should DomainObjectBase have an ID if it is?
    [DefaultImplementation(Interface = typeof(IMapper<UnableScreenReason, LookupEntity>))]
    public class UnableToScreenReasonMapper : Mapper<UnableScreenReason, LookupEntity>
    {
        public override UnableScreenReason Map(LookupEntity objectToMap)
        {
            return new UnableScreenReason(0)
            {
                DisplayName = objectToMap.DisplayName,
                Reason = (UnableToScreenReason)objectToMap.LookupId
            };
        }

        public override LookupEntity Map(UnableScreenReason objectToMap)
        {
            throw new NotImplementedException();
        }
    }
}