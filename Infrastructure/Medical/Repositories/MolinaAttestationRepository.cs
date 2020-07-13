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
    public class MolinaAttestationRepository : PersistenceRepository, IMolinaAttestationRepository
    {
        public IEnumerable<MolinaAttestation> GetbyEventCustumerResultId(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ctqc in linqMetaData.MolinaAttestation
                             where ctqc.EventCustomerResultId == eventCustomerResultId
                             select ctqc);

                return Mapper.Map<IEnumerable<MolinaAttestationEntity>, IEnumerable<MolinaAttestation>>(query);
            }
        }

        public void Save(IEnumerable<MolinaAttestation> attestations)
        {
            var molinaAttestations = attestations as MolinaAttestation[] ?? attestations.ToArray();
            if (attestations != null && molinaAttestations.Any())
                Delete(molinaAttestations.First().EventCustomerResultId);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<MolinaAttestationEntity>();
                foreach (var criteria in molinaAttestations)
                {
                    entities.Add(Mapper.Map<MolinaAttestation, MolinaAttestationEntity>(criteria));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public bool Save(MolinaAttestation attestation)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<MolinaAttestationEntity>();

                entities.Add(Mapper.Map<MolinaAttestation, MolinaAttestationEntity>(attestation));

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
                return true;
            }
        }

        public void Delete(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(MolinaAttestationFields.EventCustomerResultId == eventCustomerResultId);
                adapter.DeleteEntitiesDirectly(typeof(MolinaAttestationEntity), relationPredicateBucket);
            }
        }
    }
}
