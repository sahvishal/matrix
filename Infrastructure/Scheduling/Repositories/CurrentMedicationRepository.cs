using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class CurrentMedicationRepository : PersistenceRepository, ICurrentMedicationRepository
    {
        public IEnumerable<CurrentMedication> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from pat in linqMetaData.CurrentMedication where pat.IsActive && !pat.DateEnd.HasValue && pat.CustomerId == customerId select pat);

                return Mapper.Map<IEnumerable<CurrentMedicationEntity>, IEnumerable<CurrentMedication>>(enetities);
            }
        }

        public void SaveCurrentMedication(long customerId, List<OrderedPair<long, string>> ndcs, long createdByOrgRoleUserId)
        {
            DeactiveCurrentMedication(customerId);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CurrentMedicationEntity>();
                foreach (var ndc in ndcs)
                {
                    entities.Add(new CurrentMedicationEntity
                    {
                        CustomerId = customerId,
                        NdcId = ndc.FirstValue,
                        DateCreated = DateTime.Now,
                        CreatedByOrgRoleUserId = createdByOrgRoleUserId,
                        IsActive = true,
                        IsPrescribed = ndc.SecondValue == "p",
                        IsOtc = ndc.SecondValue == "o",
                        IsNew = true
                    });
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        private void DeactiveCurrentMedication(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var entity = new CurrentMedicationEntity()
                {
                    IsActive = false,
                    DateEnd = DateTime.Now
                };

                var bucket = new RelationPredicateBucket(CurrentMedicationFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(CurrentMedicationFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }
    }
}