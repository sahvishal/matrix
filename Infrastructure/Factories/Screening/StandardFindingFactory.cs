using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    [DefaultImplementation(Interface = typeof(IStandardFindingFactory))]
    public class StandardFindingFactory : IStandardFindingFactory
    {

        public StandardFinding<T> CreateStandardFinding<T>(StandardFindingEntity standardFindingEntity)
        {
            if (standardFindingEntity == null)
                throw new ArgumentNullException("standardFindingEntity", "Standard Finding Entity must be provided.");

            var standardFinding = new StandardFinding<T>(standardFindingEntity.StandardFindingId)
            {
                Label = standardFindingEntity.Label,
                Description = standardFindingEntity.Description,
                ResultInterpretation = standardFindingEntity.ResultInterpretation,
                PathwayRecommendation = standardFindingEntity.PathwayRecommendation,
                LongDescription = standardFindingEntity.LongDescription,
                WorstCaseOrder = standardFindingEntity.WorstCaseOrder
            };

            if (typeof(T) == typeof(int?) || typeof(T) == typeof(int)) // For Type Int
            {
                int returnValue;
                // Setting for Min Value
                if (standardFindingEntity.MinValue != null)
                {
                    returnValue = decimal.ToInt32((decimal)standardFindingEntity.MinValue);
                    standardFinding.MinValue = (T)Convert.ChangeType(returnValue, typeof(int));
                }
                else
                    standardFinding.MinValue = default(T);

                //Setting for Max Value
                if (standardFindingEntity.MaxValue != null)
                {
                    returnValue = decimal.ToInt32((decimal)standardFindingEntity.MaxValue);
                    standardFinding.MaxValue = (T)Convert.ChangeType(returnValue, typeof(int));
                }
                else
                    standardFinding.MaxValue = default(T);
            }
            else if (typeof(T) == typeof(decimal?) || typeof(T) == typeof(decimal)) // For Type Decimal
            {
                // Setting for min Value
                if (standardFindingEntity.MinValue != null)
                    standardFinding.MinValue = (T)Convert.ChangeType(standardFindingEntity.MinValue, typeof(decimal));
                else
                    standardFinding.MinValue = default(T);

                // Setting for max Value
                if (standardFindingEntity.MaxValue != null)
                    standardFinding.MaxValue = (T)Convert.ChangeType(standardFindingEntity.MaxValue, typeof(decimal));
                else
                    standardFinding.MaxValue = default(T);
            }
            return standardFinding;
        }

        public List<StandardFinding<T>> CreateStandardFindings<T>(List<StandardFindingEntity> standardFindingEntities) 
        {
            if (standardFindingEntities == null)
            {
                throw new ArgumentNullException("standardFindingEntities", "Standard Finding Entities must be provided.");
            }

            return standardFindingEntities.Select(CreateStandardFinding<T>).ToList();
        }

        public StandardFindingEntity CreateStandardFinding<T>(StandardFinding<T> standardFinding)
        {
            if (standardFinding == null)
            {
                throw new ArgumentNullException("standardFinding", "Standard Finding must be provided.");
            }

            var standardFindingEntity = new StandardFindingEntity((int)standardFinding.Id)
                                            {
                                                Label = standardFinding.Label,
                                                Description = standardFinding.Description
                                            };
            return standardFindingEntity;
        }

    }

    
}
