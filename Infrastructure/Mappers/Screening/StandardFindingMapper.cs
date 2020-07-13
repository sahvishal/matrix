using System;
using Falcon.App.Core.Medical.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Screening
{
    public class StandardFindingMapper<T> : DomainEntityMapper<StandardFinding<T>, StandardFindingEntity>
    {
        protected override void MapDomainFields(StandardFindingEntity entity, 
            StandardFinding<T> domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.StandardFindingId;
            domainObjectToMapTo.Label = entity.Label;
            domainObjectToMapTo.Description = entity.Description;
            if (typeof(T) == typeof(int?))
            {
                int returnValue;
                if (entity.MinValue.HasValue)
                {
                    returnValue = decimal.ToInt32(entity.MinValue.Value);
                    domainObjectToMapTo.MinValue = (T)Convert.ChangeType(returnValue, typeof(int));
                }
                else
                {
                    domainObjectToMapTo.MinValue = default(T);
                }
                if (entity.MaxValue.HasValue)
                {
                    returnValue = decimal.ToInt32(entity.MaxValue.Value);
                    domainObjectToMapTo.MaxValue = (T)Convert.ChangeType(returnValue, typeof(int));
                }
                else
                {
                    domainObjectToMapTo.MaxValue = default(T);
                }
            }
            else if (typeof(T) == typeof(decimal?))
            {
                domainObjectToMapTo.MinValue = entity.MinValue.HasValue
                    ? (T) Convert.ChangeType(entity.MinValue, typeof (decimal))
                    : default(T);
                domainObjectToMapTo.MaxValue = entity.MaxValue.HasValue
                    ? (T) Convert.ChangeType(entity.MaxValue, typeof (decimal))
                    : default(T);
            }
        }

        protected override void MapEntityFields(StandardFinding<T> domainObject, 
            StandardFindingEntity entityToMapTo)
        {
            entityToMapTo.StandardFindingId = (int)domainObject.Id;
            entityToMapTo.Label = domainObject.Label;
            entityToMapTo.Description = domainObject.Description;
            //entityToMapTo.MinValue = domainObject.MinValue;
            //entityToMapTo.MaxValue = domainObject.MaxValue;
        }
    }
}