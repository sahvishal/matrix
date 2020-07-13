using System;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Screening
{
    public class FraminghamCalculationSourceMapper : DomainEntityMapper<FraminghamCalculationSource, 
        FraminghamCalculationSourceEntity>
    {
        protected override void MapDomainFields(FraminghamCalculationSourceEntity entity,
            FraminghamCalculationSource domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.CalculationSourceId;
            domainObjectToMapTo.Reading = (ReadingLabels) entity.ReadingId;
            domainObjectToMapTo.MinValue = entity.MinValue;
            domainObjectToMapTo.MaxValue = entity.MaxValue;
            domainObjectToMapTo.MaleScore = entity.MaleScore;
            domainObjectToMapTo.FemaleScore = entity.FemaleScore;
        }

        protected override void MapEntityFields(FraminghamCalculationSource domainObject, 
            FraminghamCalculationSourceEntity entityToMapTo)
        {
            throw new NotImplementedException();
        }
    }
}