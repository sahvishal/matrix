using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class WellMedAttestationRepository : PersistenceRepository, IWellMedAttestationRepository
    {
        public IEnumerable<WellMedAttestation> GetbyEventCustumerResultId(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ctqc in linqMetaData.WellMedAttestation
                             where ctqc.EventCustomerResultId == eventCustomerResultId
                             select ctqc);

                return Mapper.Map<IEnumerable<WellMedAttestationEntity>, IEnumerable<WellMedAttestation>>(query);
            }
        }

        public void Save(IEnumerable<WellMedAttestation> attestations)
        {
            var wellMedAttestations = attestations as WellMedAttestation[] ?? attestations.ToArray();
            
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<WellMedAttestationEntity>();
                foreach (var criteria in wellMedAttestations)
                {
                    entities.Add(Mapper.Map<WellMedAttestation, WellMedAttestationEntity>(criteria));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public void Delete(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(WellMedAttestationFields.EventCustomerResultId == eventCustomerResultId);
                adapter.DeleteEntitiesDirectly(typeof(WellMedAttestationEntity), relationPredicateBucket);
            }
        }
    }
}
