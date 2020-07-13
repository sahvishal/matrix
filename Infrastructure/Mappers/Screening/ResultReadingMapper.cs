using System;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Screening
{
    public class ResultReadingMapper<T> : DomainEntityMapper<ResultReading<T>, ReadingEntity>
    {
        protected override void MapDomainFields(ReadingEntity entity, ResultReading<T> domainObjectToMapTo)
        {
            domainObjectToMapTo.Label = (ReadingLabels)entity.ReadingId;
            domainObjectToMapTo.ReadingSource = entity.DefaultInputSource.Trim() ==
                ReadingSource.Manual.ToString() ? ReadingSource.Manual : ReadingSource.Automatic;
            domainObjectToMapTo.LableText = entity.Label;
        }

        protected override void MapEntityFields(ResultReading<T> domainObject, ReadingEntity entityToMapTo)
        {
            throw new NotImplementedException();
        }
    }
}